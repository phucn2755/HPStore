using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPStore.Models
{
    public interface IHPStoreRepository
    {
        IQueryable<Tainghe> Tainghes { get; }
        void SaveTainghe(Tainghe b);
        void CreateTainghe(Tainghe b);
        void DeleteTainghe(Tainghe b);
    }
}
