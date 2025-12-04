using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.PageObjects
{
    public class LoginPage : BasePage
    {
        private const string UsernameInput = "#user-name";
        private const string PasswordInput = "#password";
        private const string LoginButton = "#login-button";
        private const string ErrorContainer = ".error-message-container";

        public LoginPage(IPage page) : base(page) { }

        public async Task GotoAsync(string baseUrl)
        {
            await Page.GotoAsync(baseUrl);
        }

        public async Task LoginAsync(string username, string password)
        {
            await FillAsync(UsernameInput, username);
            await FillAsync(PasswordInput, password);
            await ClickAsync(LoginButton);
        }

        public async Task<string> GetErrorMessageAsync()
        {
            await WaitForSelectorAsync(ErrorContainer);
            return await GetInnerTextAsync(ErrorContainer);
        }

        public async Task<bool> IsOnLoginPageAsync()
        {
            return await Task.FromResult(Page.Url.Contains("saucedemo.com"));
        }
    }
}
