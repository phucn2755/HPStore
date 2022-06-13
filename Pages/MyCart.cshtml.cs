using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HPStore.MyTagHelper;
using HPStore.Models;
using System.Linq;



namespace HPStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IHPStoreRepository repository;
        public MyCartModel(IHPStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long taingheId, string returnUrl)
        {
            Tainghe tainghe = repository.Tainghes
            .FirstOrDefault(b => b.TaingheID == taingheId);
            myCart.AddItem(tainghe, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long taingheId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Tainghe.TaingheID == taingheId).Tainghe);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }

}
