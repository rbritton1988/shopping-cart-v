namespace VeygoShoppingCart.API.DTOs
{
    public class DiscountsCreateDTO
    {
        public string Code { get; set; }
        public double Percentage { get; set; }
        public string Description { get; set; }
    }
}
