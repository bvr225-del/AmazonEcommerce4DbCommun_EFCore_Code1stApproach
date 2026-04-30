using AmazonEcommerce_BusinessEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_DbConnectivity
{
    public class OrderContext: DbContext
    {
        //if you create any context class must be inherit from DbContext class.
        //DbContext class having Savechanges() method,it is used to save the data perminently.

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
        //you need to register model class into DbSet<>placeholder section.
        public DbSet<Order> Orders123 { get; set; }

    }
}
