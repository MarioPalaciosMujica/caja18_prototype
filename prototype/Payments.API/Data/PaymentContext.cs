using System;
using Microsoft.EntityFrameworkCore;
using Payments.API.Entities;

namespace Payments.API.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

        public DbSet<PaymentOrder> PaymentOrders { get; set; }
    }
}
