using ITS.AmenduniA.SampleWebApp.Models;
using ITS.AmenduniA.SampleWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.AmenduniA.SampleWebApp.Pages.Products
{
    public class InsertModel : PageModel
    {
        [BindProperty]  //prende i campi in automatico in automatico
        public Product? Product { get; set; }

        private readonly IProductsService _productservice;

        public InsertModel(IProductsService productservice)
        {
            _productservice = productservice;
        }
        
        public IActionResult OnGet(int productId)
        {
            Product = _productservice.GetById(productId);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Product.Id = _productservice.GetAll().Count() + 1;
            _productservice.Insert(Product);

            return RedirectToPage("/index");
        }
    }
}
