namespace PortalStore.Domain.Entities
{
    public class Order : OrderCore
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderCore : BaseEntity<int>
    {
        // Customerld int
        public int CustomerId { get; set; }
        // Addressld int
        public int AddressId { get; set; }
        // TotalPrice decimal(1 6,2)
        [Column(TypeName="decimal(16,2)")]
        public decimal TotalPrice { get; set; }
    }
}