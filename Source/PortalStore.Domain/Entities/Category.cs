using PortalStore.Domain.Contracts;

namespace PortalStore.Domain.Entities
{
    public class Category : CategoryCore 
    {
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CategoryCore : BaseEntity<int>
    {
        [Column(TypeName="nvarchar(50)")]
        public string Name { get; set; }
    }
}