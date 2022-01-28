using System;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationService = new ValidationService();

            var validMobile = "07865423210";
            var validEmail = "rosemaryallan@live.com";

            var inValidMobile = "0785432*2-1";
            var inValidEmail = "rosemary.allan@@live.com";

            var validMobileResult = validationService.IsMobileValid(validMobile);
            var validEmailResult = validationService.IsEmailValid(validEmail);

            var inValidMobileResult = validationService.IsMobileValid(inValidMobile);
            var inValidEmailResult = validationService.IsEmailValid(inValidEmail);

            Console.WriteLine($"Mobile: {validMobile} - Valid: {validMobileResult}");
            Console.WriteLine($"Email: {validEmail} - Valid: {validEmailResult}");

            Console.WriteLine($"Mobile: {inValidMobile} - Invalid: {inValidMobileResult}");
            Console.WriteLine($"Email: {inValidEmail} - Invalid: {inValidEmailResult}");
        }
    }
}
