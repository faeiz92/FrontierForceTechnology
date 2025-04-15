using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectA.DTO;

namespace ProjectA.Entitites
{
    public class RepositoryContext : DbContext
    {
        /*protected readonly IConfiguration _configuration;
        public RepositoryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }*/
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
               : base(options)
        { }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderHeader>().ToTable("T_ORDER_HEADER");
            modelBuilder.Entity<OrderDetail>().ToTable("T_ORDER_DETAIL");

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.OrderHeader)  // Each OrderDetail has one OrderHeader
            .WithMany(oh => oh.OrderDetails)  // Each OrderHeader can have many OrderDetails
            .HasForeignKey(od => od.MawbReference);
        }



    }
}
