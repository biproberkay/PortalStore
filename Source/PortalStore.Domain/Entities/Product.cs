using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PortalStore.Domain.Contracts;

namespace PortalStore.Domain.Entities
{
    public class Product:ProductCore
    {
        public Category Category { get; set; }
    }

    public class ProductCore:BaseEntity<int>
    {
        //50
        [StringLength(50)]
        public string Name { get; set; }
        //250
        [Column(TypeName="nvarchar(250)")]
        public string Description { get; set; }
        //16,2
        [Column(TypeName="decimal(16,2)")]
        public decimal Price { get; set; }
        //16,2
        [Column(TypeName="decimal(16,2)")]
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
    }
}