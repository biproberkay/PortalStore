using PortalStore.Domain.Contracts;

namespace PortalStore.Domain.Entities
{
    public class Category : CategoryReadDto, IBaseEntity<int>
    {
        public virtual ICollection<Product> Products { get; set; }
    }

    public class CategoryReadDto : CategoryEditDto, IReadDto<int>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class CategoryEditDto :CategoryCreateDto, IEditDto<int>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
    }
    public class CategoryCreateDto : ICreateDto
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public Status Status { get; set; }
    }
    public class CategoryDeleteDto : IDeleteDto<int>
    {
        public int Id { get; set; }
    }
}