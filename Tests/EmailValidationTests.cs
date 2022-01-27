using NUnit.Framework;
using Validation;

namespace Tests
{
    [TestFixture]
    public class EmailValidationTests
    {
        private ValidationService _validationService;

        [SetUp]
        public void SetUp()
        {
            _validationService = new ValidationService();
        }

        [Test]
        [TestCase("rosemary.allan@live.com", true)]
        [TestCase("stephen-whittaker@email.com", true)]
        [TestCase("jamie.hudson@hotmail.co.uk", true)]
        [TestCase("joe1993.xyz@gmail.com", true)]
        public void IsEmailValid_WhenEmailIsInCorrectFormat_ReturnTrue(string email, bool expectedResult)
        {
            var result = _validationService.IsEmailValid(email);

            Assert.That(result == expectedResult);
        }

        [Test]
        [TestCase("john.smither@@aol.com", false)]
        [TestCase("jeremy-johnson @email.com", false)]
        [TestCase("ryan_shawcross@email..com", false)]
        [TestCase("michael-detweilercom.", false)]
        [TestCase("jamie.hudson@hotmail.co.uk@", false)]
        public void IsEmailValid_WhenEmailIsInInCorrectFormat_ReturnFalse(string email, bool expectedResult)
        {
            var result = _validationService.IsEmailValid(email);

            Assert.That(result == expectedResult);
        }
    }
}
