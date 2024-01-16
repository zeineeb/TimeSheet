using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Infrastructure.Data
{
    internal static class InfrastructureExtension
    {
        public static string GetJsonConnectionString(this DbContext context, string configFileName)
        {
            var config = new ConfigurationBuilder().AddJsonFile(configFileName, true, true).Build();
            return config["ConnectionStrings:Default"];
        }
    }
}
