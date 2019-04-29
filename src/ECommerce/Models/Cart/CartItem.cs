using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

    }
}
