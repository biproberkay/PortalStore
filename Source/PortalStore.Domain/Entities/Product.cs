using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PortalStore.Domain.Contracts;

namespace PortalStore.Domain.Entities
{
    public class Product : ProductReadDto, IBaseEntity<int>
    {
        public Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public class ProductReadDto : ProductEditDto, IReadDto<int> 
    {
        public DateTime CreationDate { get; set; }
    }
    public class ProductEditDto : ProductCreateDto, IEditDto<int>
    {
        public int Id { get; set; }
    }
    public class ProductCreateDto : ICreateDto
    {
        //50
        [StringLength(50)]
        public string Name { get; set; }
        //250
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        //16,2
        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }
        //16,2
        [Column(TypeName = "decimal(16,2)")]
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public Status Status { get; set; }
    }

    public class ProductDeleteDto : IDeleteDto<int>
    {
        public int Id { get; set; }
    }
}