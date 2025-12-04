using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        protected BasePage(IPage page)
        {
            Page = page;
        }

        protected Task ClickAsync(string selector) => Page.ClickAsync(selector);
        protected Task FillAsync(string selector, string text) => Page.FillAsync(selector, text);
        protected Task<string> GetInnerTextAsync(string selector) => Page.InnerTextAsync(selector);
        protected Task WaitForSelectorAsync(string selector) => Page.WaitForSelectorAsync(selector);
    }
}
