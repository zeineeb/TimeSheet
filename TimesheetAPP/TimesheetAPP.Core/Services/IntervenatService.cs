using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimesheetAPP.Core.Entities;
using TimesheetAPP.Core.Interfaces;



namespace TimesheetAPP.Core.Services
{
    public class IntervenatService : IIntervenantService
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IDbContext _context;
        private readonly IEmailService _emailService;

        public IntervenatService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IDbContext context, IEmailService emailService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
        }
        public async Task<IEnumerable<Intervenant>> GetAllUsers()
        {
            return await _context.Intervenants.ToListAsync();
        }
        public async Task<Intervenant> GetUserById(int userId)
        {
            return await _context.Intervenants.FirstOrDefaultAsync(i => i.IntervenantId == userId);
        }
        public async Task<object> DeleteUserByUsername(string unsername)
        {
            var user = await userManager.FindByNameAsync(unsername);

            if (user == null)
                return new Responses { Status = "Error", Message = "User not found!" };

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                var firstError = result.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                return new Responses { Status = "Error", Message = $"User deletion failed: {firstError}" };
            }

            return new Responses { Status = "Success", Message = "User deleted successfully!" };
        }

        public async Task<object> DeleteIntervenantById(int intervenantId)
        {
            var intervenant = await _context.Intervenants.FirstOrDefaultAsync(i => i.IntervenantId == intervenantId);

            if (intervenant == null)
                return new Responses { Status = "Error", Message = "Intervenant not found!" };

            _context.Intervenants.Remove(intervenant);
            await _context.SaveChangesAsync();

            return new Responses { Status = "Success", Message = "Intervenant deleted successfully!" };
        }

        public async Task<object> Login(Intervenant model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                // Check if the user is verified and OTP is null
                if (user.EmailConfirmed == true)
                {
                    var userRoles = await userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                    return new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };
                }
                else
                {
                    return new Responses { Status = "Error", Message = "User is not verified or has a pending OTP. Login denied." };
                }
            }

            return null;
        }


        public async Task<object> Logout(Intervenant model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null)
                return new Responses { Status = "Error", Message = "User not found!" };

            // Perform the logout by revoking the user's token
            // This can be done by updating the SecurityStamp, which will invalidate the existing token
            user.SecurityStamp = Guid.NewGuid().ToString();

            await userManager.UpdateAsync(user);

            return new Responses { Status = "Success", Message = "User logged out successfully!" };
        }

        public async Task<object> Register(Intervenant model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new Responses { Status = "Error", Message = "User already exists!" };

            var emailExists = await userManager.FindByNameAsync(model.Email);
            if (emailExists != null)
                return new Responses { Status = "Error", Message = "Email already exists!" };

            var intervenant = new Intervenant
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsVerified = false
                // Set other properties as needed
            };
            _context.Intervenants.Add(intervenant);
            await _context.SaveChangesAsync();

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                EmailConfirmed = false
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var firstError = result.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                return new Responses { Status = "Error", Message = $"User creation failed: {firstError}" };
            }

            // Generate email confirmation token for the user
            var emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            


            // Send email containing the token
            await _emailService.SendEmailAsync(model.Email, "Confirm Your Email", $"Your email confirmation token: {emailConfirmationToken}");

            return new Responses { Status = "Success", Message = "User created successfully! Please check your email to confirm your account." };

        }

        public async Task<object> VerifyEmail(string userEmail, string token)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userEmail);

                if (user == null)
                    return new Responses { Status = "Error", Message = "Email verification failed. User not found!" };

                // Verify email using the token
                var result = await userManager.ConfirmEmailAsync(user, token);

                if (!result.Succeeded)
                {
                    // Log the specific reason for verification failure
                    var errorMessage = result.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                    return new Responses { Status = "Error", Message = $"Email verification failed: {errorMessage}" };
                }

                // Email verification succeeded, update your local entities if needed
                var intervenant = await _context.Intervenants.FirstOrDefaultAsync(i => i.Email == userEmail);
                if (intervenant != null)
                {
                    intervenant.IsVerified = true;
                    await _context.SaveChangesAsync();
                }

                return new Responses { Status = "Success", Message = "Email verified successfully!" };
            }
            catch (Exception ex)
            {
                return new Responses { Status = "Error", Message = "An error occurred while processing the request." };
            }
        }

        public async Task<object> ForgotPassword(string userEmail)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userEmail);

                if (user == null)
                    return new Responses { Status = "Error", Message = "Password reset request failed. User not found!" };

                // Generate password reset token
                var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

                // Send email containing the reset token
                await _emailService.SendEmailAsync(userEmail, "Password Reset", $"Your password reset token: {resetToken}");

                return new Responses { Status = "Success", Message = "Password reset token sent successfully! Check your email." };
            }
            catch (Exception ex)
            {
                return new Responses { Status = "Error", Message = "An error occurred while processing the request." };
            }
        }

        public async Task<object> ResetPassword(string userEmail, string resetToken, string newPassword)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(userEmail);

                if (user == null)
                    return new Responses { Status = "Error", Message = "Password reset failed. User not found!" };

                // Reset password using the token
                var result = await userManager.ResetPasswordAsync(user, resetToken, newPassword);

                if (!result.Succeeded)
                {
                    // Log the specific reason for reset failure
                    var errorMessage = result.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                    return new Responses { Status = "Error", Message = $"Password reset failed: {errorMessage}" };
                }

                return new Responses { Status = "Success", Message = "Password reset successfully!" };
            }
            catch (Exception ex)
            {
                return new Responses { Status = "Error", Message = "An error occurred while processing the request." };
            }
        }

    }
}
