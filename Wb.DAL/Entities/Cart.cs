using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Wb.DAL.Entities
{
    public class Cart:BaseEntity
    {
        public Guid UniqueId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
