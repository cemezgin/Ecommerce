using ECommerce.Models;
using System.Collections.Generic;

namespace ECommerce.Services {
    public interface IProductService
    {
        Product Get(CartItem item);
    }
}