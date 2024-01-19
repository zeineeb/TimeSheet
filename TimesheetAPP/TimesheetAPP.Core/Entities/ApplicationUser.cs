using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
     public string? Otp { get; set; }
     public bool? EmailConfirmed { get; set; }

    }
}
