using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Domain.Entities
{
    public class OrderItem : OrderItemCore
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
    
    public class OrderItemCore : BaseEntity<int>
    {
        //ProductId
        public int Productld { get; set; }
        //OrdeIld
        public int OrdeIld { get; set; }
        //UniFrice
        public int UnitPrice { get; set; }
        //auantlty
        public int Quantity { get; set; }
        //Statüs
        //reationDate
        //decimal (1 6,2) 
        //datetime
    }
}
