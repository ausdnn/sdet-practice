using System.Threading.Tasks;
using NUnit.Framework;
using UiTests.PageObjects;

namespace UiTests.Tests
{
    [TestFixture]
    public class CartTests : TestBase
    {
        private const string StandardUser = "standard_user";
        private const string ValidPassword = "secret_sauce";
        private const string TargetProduct = "Sauce Labs Backpack";

        [SetUp]
        public async Task LoginAndAddItem()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync(BaseUrl);
            await loginPage.LoginAsync(StandardUser, ValidPassword);

            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.WaitForPageLoadedAsync();
            await inventoryPage.AddItemToCartByNameAsync(TargetProduct);
            await inventoryPage.GoToCartAsync();
        }

        [Test]
        public async Task Cart_Should_Contain_Selected_Item()
        {
            var cartPage = new CartPage(Page);
            var count = await cartPage.GetCartItemCountAsync();

            NUnit.Framework.Assert.GreaterOrEqual(count, 1, "Expected at least one item in the cart.");
            var found = await cartPage.IsItemInCartAsync(TargetProduct);
            NUnit.Framework.Assert.IsTrue(found, $"Expected '{TargetProduct}' to be in the cart.");
        }
    }
}
