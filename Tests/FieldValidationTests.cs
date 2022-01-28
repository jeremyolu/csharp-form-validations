using NUnit.Framework;
using Validation;

namespace Tests
{
    [TestFixture]
    public class FieldValidationTests
    {
        private ValidationService _validationService;

        [SetUp]
        public void Setup()
        {
            _validationService = new ValidationService();
        }

        [Test]
        [TestCase("Aaron", "Please enter required firstname field", "")]
        [TestCase("", "Please enter required firstname field", "Please enter required firstname field")]
        [TestCase("Smithers", "Please enter required surname field", "")]
        [TestCase(" ", "Please enter required surname field", "Please enter required surname field")]
        [TestCase("22", "Please enter your age", "")]
        public void IsFieldValid_IfValueEntered_CorrectReturnTypeReturned(string value, string errorMessage, string expectedResult)
        {
            var result = _validationService.IsFieldValid(value, errorMessage);

            Assert.That(result == expectedResult);
        }

    }
}
