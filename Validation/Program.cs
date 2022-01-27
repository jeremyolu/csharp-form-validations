using System;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationService = new ValidationService();

            var mobile = "07865423210";
            var email = "rosemaryallan@live.com";

            var mobileResult = validationService.IsMobileValid(mobile);
            var emailResult = validationService.IsEmailValid(email);

            Console.WriteLine($"Mobile: {mobile} - Valid: {mobileResult}");
            Console.WriteLine($"Email: {email} - Valid: {emailResult}");
        }
        
    }
}
