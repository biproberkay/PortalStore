using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Domain.Entities
{
    public class OrderItem : OrderItemReadQuery, IBaseEntity<int>
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
    
    //OrderItemReadQuery
    public class OrderItemReadQuery : OrderItemEditCommand, IReadQuery<int>
    {
        public DateTime CreationDate { get; set; }
    }

    public class OrderItemEditCommand : OrderItemCreateCommand, IEditCommand<int>
    {
        public int Id { get; set; }
    }

    public class OrderItemCreateCommand : ICreateCommand
    {
        //ProductId
        public int Productld { get; set; }
        //OrdeIld
        public int OrdeIld { get; set; }
        //UniFrice
        //decimal (1 6,2) 
        [Column(TypeName = ("decimal(16,2)"))]
        public int UnitPrice { get; set; }
        //auantlty
        public int Quantity { get; set; }
        public Status Status { get; set; }
    }
    public class OrderItemDeleteCommand : IDeleteCommand<int>
    {
        public int Id { get; set; }
    }
}
