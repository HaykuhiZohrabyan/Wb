using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wb.Common.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public int VendorId { get; set; }
        public string ImageFileName { get; set; }
    }
}
