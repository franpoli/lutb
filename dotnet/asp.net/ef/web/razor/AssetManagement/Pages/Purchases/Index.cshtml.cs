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
    public class IndexModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public IndexModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; }

        public async Task OnGetAsync()
        {
            Purchase = await _context.Purchases
                .Include(p => p.Company)
                .Include(p => p.Product).ToListAsync();
        }
    }
}
