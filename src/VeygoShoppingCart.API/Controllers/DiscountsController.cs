using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VeygoShoppingCart.API.DTOs;
using VeygoShoppingCart.Domain.Repository;


namespace VeygoShoppingCart.API.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IVeygoShoppingCartRepo _repo;
        private readonly IMapper _mapper;

        public DiscountsController(IVeygoShoppingCartRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiscountsReadDTO>> GetAllDiscounts()
        {
            var discounts = _repo.GetAllDiscounts();

            var mapped_discounts = _mapper.Map<IEnumerable<DiscountsReadDTO>>(discounts);

            return Ok(mapped_discounts);
        }
    }
}
