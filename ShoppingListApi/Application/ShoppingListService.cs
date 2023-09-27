namespace ShoppingListApi.Application
{
    public class ShoppingListService
    {
        public ShoppingList GetShoppingListEntries()
        {
            return new ShoppingList
            { Items = new List<ShoppingListItem> { 
                new ShoppingListItem { Name = "toothbrush" },
                new ShoppingListItem { Name = "toothpase" }
            } };
        }
    }
}
