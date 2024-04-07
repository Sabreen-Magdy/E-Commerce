using Domain.Entities.Other;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderedDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public OrderStates State { get; set; } // 0 for pending , 1 for confirmed , 2 for rejected
        public double TotalCost { get; set; }
        public string CustomerAddress { get; set; } = null!;
        public string Comment { get; set; } = null!;

        #region Relationship Mapping

        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<ProductVarientBelongToOrder> ProductBelongToOrders { get; set; } = null!;

        #endregion



    }
}
