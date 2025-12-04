using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UiTests.PageObjects
{
    public class CartPage : BasePage
    {
        private const string CartItem = ".cart_item";
        private const string ItemName = ".inventory_item_name";

        public CartPage(IPage page) : base(page) { }

        public async Task<int> GetCartItemCountAsync()
        {
            var items = await Page.QuerySelectorAllAsync(CartItem);
            return items.Count;
        }

        public async Task<bool> IsItemInCartAsync(string productName)
        {
            var items = await Page.QuerySelectorAllAsync(CartItem);
            foreach (var item in items)
            {
                var nameElement = await item.QuerySelectorAsync(ItemName);
                var name = await nameElement.InnerTextAsync();
                if (name.Trim().Equals(productName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
