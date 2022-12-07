namespace PortalStore.Domain.Entities
{
    public class Order : OrderReadDto, IBaseEntity<int>
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
    public class OrderReadDto : OrderEditDto, IReadDto<int>
    {
        public DateTime CreationDate { get; set; }
    }

    public class OrderEditDto : OrderCreateDto, IEditDto<int>
    {
        public int Id { get; set; }
    }

    public class OrderCreateDto : ICreateDto
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

    public class OrderDeleteDto : IDeleteDto<int>
    {
        public int Id { get; set; }
    }
}