using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPStore.Models;

namespace HPStore.ViewComponents
{
    public class GenreNavigation  : ViewComponent
    {
        private IHPStoreRepository repository;
        public GenreNavigation(IHPStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Tainghes
            .Select(x => x.Loai)
            .Distinct()
            .OrderBy(x => x));
        }


    }
}
