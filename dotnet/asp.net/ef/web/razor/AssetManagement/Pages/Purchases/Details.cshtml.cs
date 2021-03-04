using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Purchases
{
    public class DetailsModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public DetailsModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public Purchase Purchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Purchase = await _context.Purchases
                .Include(p => p.Company)
                .Include(p => p.Product).FirstOrDefaultAsync(m => m.PurchaseId == id);

            if (Purchase == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
