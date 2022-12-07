namespace PortalStore.Domain.Entities
{
    public class Customer : CustomerReadQuery, BaseEntity<int>
    {
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class CustomerReadQuery : CustomerEditCommand, IReadQuery<int>
    {
        public DateTime CreationDate { get; set; }
    }

    public class CustomerEditCommand : CustomerCreateCommand, IEditCommand<int>
    {
        public int Id { get; set; }
    }

    public class CustomerCreateCommand : ICreateCommand
    {
        public Status Status { get; set; }
        // FirstName        nvarchar(50)
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        // LastName        nvarchar(50)
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        // Email        nvarchar(150)
        [Column(TypeName = "nvarchar(150)")]
        public string Email { get; set; }
        // TCID        bigint
        [Column(TypeName = "bigint")]
        public long TCID { get; set; }//https://stackoverflow.com/a/2113534/12878692
        // Birthdate        datetime
        public DateTime BirthDate { get; set; }
        // Gsm        nvarchar(20)
        [Column(TypeName = "nvarchar(20)")]
        public string Gsm { get; set; }
    }

    public class CustomerDeleteCommand : IDeleteCommand<int>
    {
        public int Id { get; set; }
    }
}