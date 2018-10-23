using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartProject
{
    public class CartItem : IEquatable<CartItem> //https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1?view=netframework-4.7.2
    {
        #region Properties

        public int Quantity { get; set; }
        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _product = null;
                _productId = value;
            }
        }

        private Item _product = null;
        public Item Prod
        {
            get
            {
                if (_product == null)
                {
                    _product = new Item(ProductId);
                }
                return _product;
            }
        }

        public string name
        {
            get { return Prod.name; }
        }

        public double price
        {
            get { return Prod.price; }
        }

        public double TotalPrice
        {
            get { return price * Quantity; }
        }

        #endregion

        public CartItem(int productId)
        {
            this.ProductId = productId;
        }


        public bool Equals(CartItem item)
        {
            return item.ProductId == this.ProductId;
        }
    }
}
