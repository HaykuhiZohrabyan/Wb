using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wb.DAL.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public virtual Vendor Vednor { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public string ImageFileName { get; set; }
    }
}
