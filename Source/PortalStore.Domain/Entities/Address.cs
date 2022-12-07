namespace PortalStore.Domain.Entities
{
    public class Address : AddressReadQuery, BaseEntity<int>
    {
        public Customer Customer { get; set; }
    }
    
    public class AddressReadQuery : AddressEditCommand, IReadQuery<int>
    {
        public DateTime CreationDate { get; set; }
    }

    public class AddressEditCommand : AddressCreateCommand, IEditCommand<int>
    {
        public int Id { get; set; }
    }

    public class AddressCreateCommand : ICreateCommand
    {
        // AdressLine nvarchar(250)
        [Column(TypeName = "nvarchar(250)")]
        public string AddressLine { get; set; }
        // Country  nvarchar(30)
        [Column(TypeName = "nvarchar(30)")]
        public string Country { get; set; }
        // City nvarchar(30)
        [Column(TypeName = "nvarchar(30)")]
        public string City { get; set; }
        // District nvarchar(30) 
        [Column(TypeName = "nvarchar(30)")]
        public string District { get; set; }
        // ZipCode int
        public int ZipCode { get; set; }
        // Customerld int
        public int Customerld { get; set; }
        public Status Status { get; set; }
    }

    public class AddressDeleteCommand : IDeleteCommand<int>
    {
        public int Id { get; set; }
    }
}