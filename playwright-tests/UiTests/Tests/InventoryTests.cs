using System.Threading.Tasks;
using NUnit.Framework;
using UiTests.PageObjects;

namespace UiTests.Tests
{
    [TestFixture]
    public class InventoryTests : TestBase
    {
        private const string StandardUser = "standard_user";
        private const string ValidPassword = "secret_sauce";

        [SetUp]
        public async Task Login()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync(BaseUrl);
            await loginPage.LoginAsync(StandardUser, ValidPassword);

            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.WaitForPageLoadedAsync();
        }

        [Test]
        public async Task Inventory_Should_Display_At_Least_One_Item()
        {
            var inventoryPage = new InventoryPage(Page);
            var count = await inventoryPage.GetItemCountAsync();

            NUnit.Framework.Assert.GreaterOrEqual(count, 1, "Expected at least one inventory item.");
        }

        [Test]
        public async Task Adding_First_Item_Should_Update_Cart_Badge()
        {
            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.AddFirstItemToCartAsync();

            var badgeCount = await inventoryPage.GetCartBadgeCountAsync();
            NUnit.Framework.Assert.AreEqual("1", badgeCount);
        }
    }
}
