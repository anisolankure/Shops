using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shops.Core.Modules;
using Shops.Core.Services;

namespace Shops.Api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsAsync()
        {
            return new OkObjectResult(await _itemService.GetAllItemsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Shop>> GetItemByIdAsync(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}