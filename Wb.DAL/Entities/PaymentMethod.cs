using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Wb.Common.Enums;
namespace Wb.DAL.Entities
{
    public class PaymentMethod:BaseEntity
    {
        public string Last4Dight { get; set; }
        public string HolderName { get; set; }
        public int ExYear { get; set; }
        public int ExMonth { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public CardType CardType { get; set; }
    }
}
