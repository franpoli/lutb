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
    public class IndexModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public IndexModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; }

        public async Task OnGetAsync()
        {
            ProductCategory = await _context.ProductCategories.ToListAsync();
        }
    }
}
