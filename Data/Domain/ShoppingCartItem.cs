using System;
using System.Collections.Generic;
using System.Text;

namespace Crossways.Data.Domain
{
    public class ShoppingCartItem : Entity
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
