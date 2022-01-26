using System;
using System.Text.RegularExpressions;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsMobileValid(string.Empty);

            Console.WriteLine(result);
        }
    }
}
