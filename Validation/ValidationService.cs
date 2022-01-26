using System.Text.RegularExpressions;

namespace Validation
{
    public class ValidationService
    {
        public bool IsMobileValid(string mobileTel)
        {
            // serialize number to remove any characters
            var mobile = SerializeMobileNumber(mobileTel);

            // check if length is 11 and mobile starts with 07 (UK) return true
            if (mobile.Length == 11 && mobile.IndexOf("07") == 0)
            {
                return true;
            }

            // return false if string doesn't satisfy condition
            return false;
        }

        private string SerializeMobileNumber(string mobileTel)
        {
            //remove spaces from mobile number
            mobileTel = mobileTel.Replace(" ", string.Empty);

            //check if +44 is at beginning of mobile number and replace with 0
            if (mobileTel.IndexOf("+44") == 0)
            {
                mobileTel = mobileTel.Replace("+44", "0");
            }

            //check if +44 is at beginning of mobile number and replace with 0
            if (mobileTel.IndexOf("44") == 0)
            {
                mobileTel = mobileTel.Replace("44", "0");
            }

            //remove any special or weird characters
            var mobile = Regex.Replace(mobileTel, @"[^0-9a-zA-Z]+", string.Empty);

            //get count of characters/letters if any in number
            var characterCount = Regex.Matches(mobile, @"[a-zA-Z]").Count;

            //check if there are characters/letters return empty string
            if (characterCount > 0)
            {
                return string.Empty;
            }

            //return mobile
            return mobile;
        }
    }
}
