using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wb.DAL.Entities
{
    public class Vendor:BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual VendorCountry   VendorCountry { get; set; }
    }
}
