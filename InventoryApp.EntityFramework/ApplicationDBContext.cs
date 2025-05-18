using InventoryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.EntityFramework
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options) { }
        public ApplicationDBContext() : base() { }
        
    }
}
