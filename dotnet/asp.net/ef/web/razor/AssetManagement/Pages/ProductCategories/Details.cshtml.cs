using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.ProductCategories
{
    public class DetailsModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public DetailsModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public ProductCategory ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.ProductCategoryId == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
