using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuthenticationApi.Utility
{
    public static class Validation
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string input)
        {

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}"); // minimum of 8 characters

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
            return isValidated;
        }

        public static bool IsValidPhoneNumber(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string inTxt = input.Trim();
                if(inTxt.Length > 11 || inTxt.Length < 11)
                {
                    return false;
                }
                if (inTxt.Length == 11)
                {
                    return true;
                }
            }

            return false;

        }
        public static string ValidTempaTag(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string inTxt =  input.Trim();
                char at = inTxt[0];
                if (at.ToString() != "@" )
                {
                    return $"@{input}";
                }
               
            }

            return input;

        }

        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static string ReplaceWhitespace(string input, string replacement)
        {
            return sWhitespace.Replace(input, replacement);
        }
    }


}
