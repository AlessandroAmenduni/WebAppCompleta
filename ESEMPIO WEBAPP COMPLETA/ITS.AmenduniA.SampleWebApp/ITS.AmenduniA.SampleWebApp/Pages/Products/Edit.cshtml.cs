using ITS.AmenduniA.SampleWebApp.Models;
using ITS.AmenduniA.SampleWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.AmenduniA.SampleWebApp.Pages.Products
{
    //di default risponde a => products/edit
    //vogliamo che questa pagina risponda a => Products/Edit/{id}. Si fa mettendo nella pag di cshtml @page "{productId}".
    //Deve essere chiamato come l'id nel OnGet

    public class EditModel : PageModel
    {
        private readonly IProductsService _productservice;

        [BindProperty] //quando faccio il post i valori vengono presi in automatico
        public Product? Product { get; set; }

        public EditModel(IProductsService productservice)
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
        
        public IActionResult OnPost(int productId)
        {          
            Product.Id = productId;
            _productservice.Update(Product);
            return RedirectToPage("/index");
        }
    }
}
