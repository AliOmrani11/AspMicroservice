using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }
        public ShoppingCart(string username)
        {
            Username = username;
        }


        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get
            {
                return this.Items.Sum(s => s.Price * s.Quantity);
            }
        }
    }
}
