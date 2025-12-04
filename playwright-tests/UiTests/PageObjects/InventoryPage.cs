using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.PageObjects
{
    public class InventoryPage : BasePage
    {
        private const string InventoryContainer = ".inventory_list";
        private const string InventoryItem = ".inventory_item";
        private const string ItemName = ".inventory_item_name";
        private const string ItemPrice = ".inventory_item_price";
        private const string AddToCartButtonPrefix = "button[data-test^='add-to-cart']";
        private const string CartLink = ".shopping_cart_link";
        private const string CartBadge = ".shopping_cart_badge";

        public InventoryPage(IPage page) : base(page) { }

        public async Task WaitForPageLoadedAsync()
        {
            await WaitForSelectorAsync(InventoryContainer);
        }

        public async Task<int> GetItemCountAsync()
        {
            var items = await Page.QuerySelectorAllAsync(InventoryItem);
            return items.Count;
        }

        public async Task AddFirstItemToCartAsync()
        {
            var firstButton = (await Page.QuerySelectorAllAsync(AddToCartButtonPrefix)).FirstOrDefault();
            if (firstButton != null)
            {
                await firstButton.ClickAsync();
            }
        }

        public async Task AddItemToCartByNameAsync(string productName)
        {
            var items = await Page.QuerySelectorAllAsync(InventoryItem);

            foreach (var item in items)
            {
                var nameElement = await item.QuerySelectorAsync(ItemName);
                var name = await nameElement.InnerTextAsync();

                if (name.Trim().Equals(productName))
                {
                    var button = await item.QuerySelectorAsync("button");
                    await button.ClickAsync();
                    break;
                }
            }
        }

        public async Task<string?> GetCartBadgeCountAsync()
        {
            var badge = await Page.QuerySelectorAsync(CartBadge);
            if (badge == null)
                return null;

            return (await badge.InnerTextAsync()).Trim();
        }

        public async Task GoToCartAsync()
        {
            await ClickAsync(CartLink);
        }
    }
}
