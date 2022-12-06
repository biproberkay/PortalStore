namespace PortalStore.Domain.Entities
{
    public class Address : AddressCore
    {
        public Customer Customer { get; set; }
    }
    
    public class AddressCore : BaseEntity<int>
    {
        // AdressLine nvarchar(250)
        [Column(TypeName="nvarchar(250)")]
        public string AddressLine { get; set; }
        // Country  nvarchar(30)
        [Column(TypeName="nvarchar(30)")]
        public string Country { get; set; }
        // City nvarchar(30)
        [Column(TypeName="nvarchar(30)")]
        public string City { get; set; }
        // District nvarchar(30) 
        [Column(TypeName="nvarchar(30)")]
        public string District { get; set; }
        // ZipCode int
        public int ZipCode { get; set; }
        // Customerld int
        public int Customerld { get; set; }
    }
}