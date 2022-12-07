using PortalStore.Domain.Contracts;

namespace PortalStore.Domain.Entities
{
    public class Category : CategoryReadQuery, IBaseEntity<int>
    {
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CategoryReadQuery : CategoryEditCommand, IReadQuery<int>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class CategoryEditCommand :CategoryCreateCommand, IEditCommand<int>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
    public class CategoryCreateCommand : ICreateCommand
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public Status Status { get; set; }
    }
    public class CategoryDeleteCommand : IDeleteCommand<int>
    {
        public int Id { get; set; }
    }
}