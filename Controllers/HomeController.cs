using HPStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HPStore.Models.ViewModels;

namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        private IHPStoreRepository repository;
        public int PageSize = 3;
        public HomeController(IHPStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int Page = 1)
             => View(new TaingheListViewModel
             {
                 Tainghes = repository.Tainghes
             .Where(p => genre == null || p.Loai == genre)
             .OrderBy(p => p.TaingheID)
             .Skip((Page - 1) * PageSize)
             .Take(PageSize),
                 PagingInfo = new PagingInfo
                 {
                     CurrentPage = Page,
                     ItemsPerPage = PageSize,
                     TotalItems = repository.Tainghes.Count()

                 },
                 CurrentGenre = genre

             });
    }
}