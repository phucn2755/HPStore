using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    namespace HPStore.Models
    {
        public class HPStoreDbContext : DbContext
        {
            public HPStoreDbContext(DbContextOptions<HPStoreDbContext> options)
            : base(options) { }
            public DbSet<Tainghe> Tainghes { get; set; }
            public DbSet<Order> Orders { get; set; }
    }
}

