using System;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobileValidation = new ValidationService();

            var result = mobileValidation.IsMobileValid("07854321232");

            Console.WriteLine(result);
        }
    }
}
