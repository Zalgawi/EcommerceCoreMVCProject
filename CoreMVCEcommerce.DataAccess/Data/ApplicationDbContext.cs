using System;
using System.Collections.Generic;
using System.Text;
using CoreMVCEcommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCEcommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
