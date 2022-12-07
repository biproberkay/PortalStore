namespace PortalStore.Domain.Entities
{
    public class Order : OrderReadQuery, BaseEntity<int>
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderReadQuery : OrderEditCommand, IReadQuery<int>
    {
        public DateTime CreationDate { get; set; }
    }

    public class OrderEditCommand : OrderCreateCommand, IEditCommand<int>
    {
        public int Id { get; set; }
    }

    public class OrderCreateCommand : ICreateCommand
    {
        public Status Status { get; set; }
        // Customerld int
        public int CustomerId { get; set; }
        // Addressld int
        public int AddressId { get; set; }
        // TotalPrice decimal(1 6,2)
        [Column(TypeName = "decimal(16,2)")]
        public decimal TotalPrice { get; set; }
    }

    public class OrderDeleteCommand : IDeleteCommand<int>
    {
        public int Id { get; set; }
    }
}