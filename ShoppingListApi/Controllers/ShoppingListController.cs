using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Application;

namespace ShoppingListApi.Controllers
{
    [ApiController]
    [Route("shopping-list")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ILogger<ShoppingListController> _logger;

        public ShoppingListController(ILogger<ShoppingListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ShoppingList GetShoppingList()
        {
            return new ShoppingListService().GetShoppingListEntries();
        }
    }
}