using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public IndexModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        // Adding search functionalities
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ProductBrand { get; set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.ProductCategory).ToListAsync();

            // Search functionalities
            var products = from p in _context.Products
                 select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Brand.Contains(SearchString));
            }

            Product = await products.ToListAsync();
        }
    }
}