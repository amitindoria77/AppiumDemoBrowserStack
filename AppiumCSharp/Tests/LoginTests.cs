using NUnit.Framework;

namespace AppiumCSharp.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : TestBase
    {
        [Author("Tester")]
        [Category(TestCategory.SANITY)]
        [Description("Entering a VALID username and checking that the user is able to login")]
        [Test]
        public void IsLoginWithValidCredentialsSucceeded()
        {
            loginPage.Login(GetData("standardUser"), GetData("password"));
            homePage.IsAddToCartButtonDisplayed();
        }

        [Author("Tester")]
        [Category(TestCategory.SANITY)]
        [Description("Entering a INVALID username and checking that the user is NOT able to login")]
        [Test]
        public void IsLoginWithInvalidCredentialsWorksCorrectly()
        {
            loginPage.Login(GetData("lockedOutUser"), GetData("password"));
            loginPage.IsInvalidCredentialsErrorMessageAppears();
        }

        [Author("Tester")]
        [Category(TestCategory.SMOKE)]
        [Description("Checking that the password is dispalyed at the bottom of the screen")]
        [Test]
        public void IsPasswordDisplayedInLoginScreen() => 
            Assert.IsTrue(loginPage.IsPasswordDisplayed(), "Password is not displayed in the screen");
    }
}
