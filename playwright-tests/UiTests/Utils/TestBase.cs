using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace UiTests
{
    public abstract class TestBase
    {
        protected IPage Page = null!;
        protected IBrowserContext Context = null!;
        protected const string BaseUrl = "https://www.saucedemo.com/";

        [SetUp]
        public async Task Setup()
        {
            NUnit.Framework.Assert.NotNull(PlaywrightFixture.Browser, 
                "Browser was not initialized in PlaywrightFixture.");

            Context = await PlaywrightFixture.Browser!.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            if (Context != null)
            {
                await Context.CloseAsync();
            }
        }
    }
}
