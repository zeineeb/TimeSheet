using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetAPP.Core.Interfaces
{
    public interface IOtpService
    {
        public string GenerateOtp(int length = 6, bool includeSpecialChars = false);
    }
}
