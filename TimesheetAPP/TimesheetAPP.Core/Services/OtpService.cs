using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetAPP.Core.Interfaces;

namespace TimesheetAPP.Core.Services
{
    public class OtpService : IOtpService
    {
        private static readonly Random Random = new Random();

        public string GenerateOtp(int length = 6, bool includeSpecialChars = false)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than zero.", nameof(length));

            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            if (includeSpecialChars)
            {
                chars += "!@#$%^&*()_-+=<>?/";
            }

            StringBuilder otp = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                otp.Append(chars[Random.Next(chars.Length)]);
            }

            return otp.ToString();
        }
    }
}
