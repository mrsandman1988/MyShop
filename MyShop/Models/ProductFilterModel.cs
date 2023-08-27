using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public sealed class ProductFilterModel
    {
        public int? VendorId { get; set; }
        public int? CategoryId { get; set; }
        public int? FromPrice { get; set; }
        public int? ToPrice { get; set; }
        public bool HasDiscount { get; set; }
        public string Name { get; set; }
    }
}
