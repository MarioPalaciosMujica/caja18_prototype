using System;
using Microsoft.EntityFrameworkCore;
using Orders.API.Entities;

namespace Orders.API.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
