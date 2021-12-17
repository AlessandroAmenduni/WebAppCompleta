using ITS.AmenduniA.SampleWebApp.Models;
using ITS.AmenduniA.SampleWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.AmenduniA.SampleWebApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        [BindProperty] //quando faccio il post i valori vengono presi in automatico
        public Product? Product { get; set; } //per prendere il prodotto in base all'id

        private readonly IProductsService _productservice;

        public DeleteModel(IProductsService productservice)
        {
            _productservice = productservice;
        }

        public IActionResult OnGet(int productId)
        {
            Product = _productservice.GetById(productId);

            if(Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int productId)
        {
            Product.Id = productId;

            _productservice.Delete(Product);

            return RedirectToPage("/index");
            //return Page();
        }
    }
}
