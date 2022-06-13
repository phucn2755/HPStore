using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPStore.Models.ViewModels
{
    public class TaingheListViewModel
    {
        public IEnumerable<Tainghe> Tainghes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
