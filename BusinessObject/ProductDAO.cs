using BusinessObject.Entity;


namespace Data_Layers
{
    public class ProductDAO 
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }
    }
}
