using TimesheetAPP.Core.Interfaces;
using TimesheetAPP.Core.Services;
using TimesheetAPP.Infrastructure.Data;

namespace TimesheetAPP
{
    public static class ServiceInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<ITicketService, TicketService>(provider =>
            {
                // Resolve any dependencies manually if needed
                var orgName = "NourBenMehrez";  // Provide a value or retrieve it from configuration
                var personalAccessToken = "zpwzok4kqgnw5prpfy2ehiylbqvgbjfsdiqkejsxqamy7qbkep7q";  // Provide a value or retrieve it from configuration

                // Create an instance of TicketService with dependencies
                return new TicketService(orgName, personalAccessToken);
            });

            services.AddScoped<IIntervenantService, IntervenatService>();
            
            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
