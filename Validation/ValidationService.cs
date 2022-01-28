using System.Text.RegularExpressions;

namespace Validation
{
    public class ValidationService
    {
        private Helpers _helpers;

        public ValidationService()
        {
            _helpers = new Helpers();
        }

        public string IsFieldValid(string value, string validationMessage)
        {
            // if valid return empty string else return validation message
            return _helpers.IsValueEntered(value) == true ? string.Empty : validationMessage;
        }

        public string IsFieldValid(int value, string validationMessage)
        {
            // if valid return empty string else return validation message
            return _helpers.IsValueEntered(value) == true ? string.Empty : validationMessage;
        }

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

        public bool IsEmailValid(string email)
        {
            // check if email format is valid
            var emailCheck = CheckEmailFormat(email);

            // return false if empty email string is returned
            if (string.IsNullOrEmpty(emailCheck))
            {
                return false;
            }

            // return true if format is correct
            return true;
        }

        private string SerializeMobileNumber(string mobileTel)
        {
            // remove spaces from mobile number
            mobileTel = mobileTel.Replace(" ", string.Empty);

            // check if +44 is at beginning of mobile number and replace with 0
            if (mobileTel.IndexOf("+44") == 0)
            {
                mobileTel = mobileTel.Replace("+44", "0");
            }

            // check if +44 is at beginning of mobile number and replace with 0
            if (mobileTel.IndexOf("44") == 0)
            {
                mobileTel = mobileTel.Replace("44", "0");
            }

            // remove any special or weird characters
            var mobile = Regex.Replace(mobileTel, @"[^0-9a-zA-Z]+", string.Empty);

            // get count of characters/letters if any in number
            var characterCount = Regex.Matches(mobile, @"[a-zA-Z]").Count;

            // check if there are characters/letters return empty string
            if (characterCount > 0)
            {
                return string.Empty;
            }

            // return mobile
            return mobile;
        }

        private string CheckEmailFormat(string email)
        {
            // at count variable declared
            int atCount = 0;

            // conditions for email return empty email string if true
            if (email.StartsWith(".") || email.StartsWith("@") || email.Contains("..") || email.Contains(".@") || email.Contains("@.") || email.EndsWith("@") || email.EndsWith(".") || email.Contains(" "))
            {
                return string.Empty;
            }

            // check if email contains required @ and . symbols
            if (email.Contains("@") && email.Contains("."))
            {
                // loop through email and check @
                foreach (var character in email)
                {
                    // if character has @
                    if (character == '@')
                    {
                        // increment value
                        atCount += 1;
                    }
                }

                // if atcount is more than 1 (should be only 1 for valid email) return empty email string
                if (atCount > 1)
                {
                    return string.Empty;
                }

                // return email if everything is fine
                return email;
            }

            // return empty email string to satisfy method type
            return string.Empty;
        }
    }
}
