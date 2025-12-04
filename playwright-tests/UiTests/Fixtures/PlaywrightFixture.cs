using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace UiTests
{
    [SetUpFixture]
    public class PlaywrightFixture
    {
        public static IPlaywright? PlaywrightInstance { get; private set; }
        public static IBrowser? Browser { get; private set; }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            PlaywrightInstance = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }

            PlaywrightInstance?.Dispose();
        }
    }
}
