using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Repository;


namespace VeygoShoppingCart.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IVeygoShoppingCartRepo _repo;
        private readonly IMapper _mapper;

        public ItemsController(IVeygoShoppingCartRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDTO>> GetAllItems()
        {
            var items = _repo.GetAllItems();

            var mapped_items = _mapper.Map<IEnumerable<ItemDTO>>(items);

            return Ok(mapped_items);
        }
    }
}
