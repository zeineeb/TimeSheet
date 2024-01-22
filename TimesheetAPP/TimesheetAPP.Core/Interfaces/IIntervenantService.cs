using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetAPP.Core.Entities;

namespace TimesheetAPP.Core.Interfaces
{
    public interface IIntervenantService
    {
        public Task<object> Login(Intervenant model);
        public Task<object> Register(Intervenant model);
        public Task<object> VerifyEmail(string userEmail, string token);
        public Task<IEnumerable<Intervenant>> GetAllUsers();
        public Task<Intervenant> GetUserById(int userId);
        public Task<object> DeleteIntervenantById(int intervenantId);
        public Task<object> DeleteUserByUsername(string unsername);
        public Task<object> Logout(Intervenant model);
        public Task<object> ForgotPassword(string userEmail);

        public Task<object> ResetPassword(string userEmail, string resetToken, string newPassword);








    }
}
