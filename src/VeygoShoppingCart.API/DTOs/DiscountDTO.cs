using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeygoShoppingCart.API.DTOs
{
    public class DiscountDTO
    {
        public string Code { get; set; }
        public double Percentage { get; set; }
        public string Description { get; set; }
    }
}
