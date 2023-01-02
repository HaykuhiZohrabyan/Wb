using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wb.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Guid UniqueId { get; set; }
        public int CustomerId {get;set;}
        public virtual Customer Customer { get; set; }
    }
}
