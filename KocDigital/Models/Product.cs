using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocDigital.Models
{
    public class Product
    {
        public Guid productID { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; }

        public double productPrice { get; set; }

        public int productStock { get; set; }
    }
}
