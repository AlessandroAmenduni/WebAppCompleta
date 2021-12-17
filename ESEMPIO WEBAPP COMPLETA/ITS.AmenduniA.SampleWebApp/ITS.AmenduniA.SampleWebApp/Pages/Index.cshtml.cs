using ITS.AmenduniA.SampleWebApp.Models;
using ITS.AmenduniA.SampleWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.AmenduniA.SampleWebApp.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> List { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IProductsService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductsService productsService)
        {
            _logger = logger;
            _productService = productsService;
        }

        public void OnGet()
        {
            var products = _productService.GetAll();
            List = products;
        }
    }
}