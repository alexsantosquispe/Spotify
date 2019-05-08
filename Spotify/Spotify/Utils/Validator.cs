using System;
using System.Text.RegularExpressions;

namespace Spotify.Utils
{
    public static class Validator
    {
        public static bool isEmailAddress(string email)
        {
            try
            {
                string pattern = "^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+[.])+[a-z]{2,5}$";                
                return Regex.IsMatch(email, pattern);

            }
            catch (Exception e)
            {
                Console.WriteLine("Email validation");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool IsEmpty(string value)
        {
            try
            {
                return string.IsNullOrEmpty(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Empty validation");
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
