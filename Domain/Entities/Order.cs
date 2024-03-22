using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderedDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public int State { get; set; }
        public double TotalCost { get; set; }
        public string CustomerAddress { get; set; }

        #region Relationship Mapping

       [ForeignKey("Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("ProductBelongToOrder")]
        public virtual int ProductBelongToOrderId { get; set; }
        public virtual ProductVarientBelongToOrder ProductBelongToOrder { get; set; }

        #endregion



    }
}
