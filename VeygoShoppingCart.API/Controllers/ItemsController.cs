using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Models;
using VeygoShoppingCart.Domain.Repository;


namespace VeygoShoppingCart.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IVeygoShoppingCartRepo _repo;

        public ItemsController(IVeygoShoppingCartRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDTO>> GetAllItems()
        {
            return Ok(new Item());
        }
    }
}
