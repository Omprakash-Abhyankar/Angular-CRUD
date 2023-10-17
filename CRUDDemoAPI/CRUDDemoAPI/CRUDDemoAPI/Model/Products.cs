using System.ComponentModel.DataAnnotations;

namespace CRUDDemoAPI.Model
{
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string productName { get; set; }
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string category { get; set; }
        [Required(ErrorMessage = "Please Enter freshness")]
        public string freshness { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        public int price { get; set; }
        [Required(ErrorMessage = "Please Enter comment")]
        public string comment { get; set; }
        [Required(ErrorMessage = "Please Enter date")]
        public string date { get; set; }
        
    }
}
