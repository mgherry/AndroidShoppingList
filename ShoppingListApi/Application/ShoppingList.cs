namespace ShoppingListApi.Application
{
    public class ShoppingList
    {
        public required List<ShoppingListItem> Items { get; set; }
    }

    public class ShoppingListItem
    {
        public string Name { get; set; }
    }
}