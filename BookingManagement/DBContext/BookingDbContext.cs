
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;
using BookingManagement.Models;

namespace BookingManagement.DBContext
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BookflightTbl> BookflightTbls { get; set; }
        public virtual DbSet<UserDetailTbl> UserDetailTbls { get; set; }
        
        public virtual DbSet<InventoryTbl> InventoryTbls { get; set; }
        
    }
   
}
