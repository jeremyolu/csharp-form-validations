using NUnit.Framework;
using Validation;

namespace Tests
{
    [TestFixture]
    public class ValidationTests
    {
        private ValidationService _validationService;

        [SetUp]
        public void Setup()
        {
            _validationService = new ValidationService();
        }

        [Test]
        [TestCase("07841765239", true)]
        [TestCase("078543-23212", true)]
        [TestCase("0763*3276323*", true)]
        public void IsMobileValid_WhenMobileNumberEntered_ShouldValidateAndReturnTrue(string mobile, bool expectedResult)
        {
            //ARRANGE -> ACT -> ASSERT

            var result = _validationService.IsMobileValid(mobile);

            Assert.That(result == expectedResult);
        }

        [Test]
        [TestCase("07523*4", false)]
        [TestCase("042356me", false)]
        [TestCase("mobilenumber*", false)]
        public void IsMobileValid_WhenMobileNumberEntered_ShouldValidateAndReturnFalse(string mobile, bool expectedResult)
        {
            //ARRANGE -> ACT -> ASSERT

            var result = _validationService.IsMobileValid(mobile);

            Assert.That(result == expectedResult);
        }
    }
}