
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Data;
using Newtonsoft.Json;

namespace ECommerce.Models
{
    public class ShoppingCart
    {        
        public List<CartItem> CartItems { get; set; }
        public double TotalAmount { get; set;}
    }
}
