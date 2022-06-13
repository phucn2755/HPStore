using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPStore.Models
{
    public class EFHPStoreRepository : IHPStoreRepository
    {
        private HPStoreDbContext context;
        public EFHPStoreRepository(HPStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Tainghe> Tainghes => context.Tainghes;
        public void CreateTainghe(Tainghe b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteTainghe(Tainghe b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveTainghe(Tainghe b)
        {
            context.SaveChanges();
        }


    }
}