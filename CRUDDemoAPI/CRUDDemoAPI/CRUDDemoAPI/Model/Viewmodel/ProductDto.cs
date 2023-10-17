namespace CRUDDemoAPI.Model.Viewmodel
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        
        public string productName { get; set; }
        
        public string category { get; set; }
        
        public string freshness { get; set; }
        
        public int price { get; set; }
        
        public string comment { get; set; }
        
        public string date { get; set; }
    }
}
