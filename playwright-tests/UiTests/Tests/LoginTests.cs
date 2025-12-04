using System.Threading.Tasks;
using NUnit.Framework;
using UiTests.PageObjects;

namespace UiTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        private const string StandardUser = "standard_user";
        private const string LockedOutUser = "locked_out_user";
        private const string ValidPassword = "secret_sauce";

        [Test]
        public async Task Valid_User_Can_Login()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync(BaseUrl);
            await loginPage.LoginAsync(StandardUser, ValidPassword);

            StringAssert.Contains("inventory.html", Page.Url);
        }

        [Test]
        public async Task Locked_Out_User_Sees_Error_Message()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync(BaseUrl);
            await loginPage.LoginAsync(LockedOutUser, ValidPassword);

            var error = await loginPage.GetErrorMessageAsync();
            StringAssert.Contains("locked out", error.ToLower());
        }

        [Test]
        public async Task Invalid_Password_Shows_Error()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync(BaseUrl);
            await loginPage.LoginAsync(StandardUser, "wrong_password");

            var error = await loginPage.GetErrorMessageAsync();
            StringAssert.Contains("username and password do not match", error.ToLower());
        }
    }
}
