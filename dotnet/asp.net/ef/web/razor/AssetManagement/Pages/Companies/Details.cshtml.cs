using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public DetailsModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Companies
                .Include(c => c.Country)
                .Include(pch => pch.Purchases)
                .ThenInclude(pdt => pdt.Product)
                .ThenInclude(ptc => ptc.ProductCategory)
                .FirstOrDefaultAsync(m => m.CompanyId == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
