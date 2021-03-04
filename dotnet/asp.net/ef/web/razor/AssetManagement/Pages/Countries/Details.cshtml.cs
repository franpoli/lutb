using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Countries
{
    public class DetailsModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public DetailsModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await _context.Countries.FirstOrDefaultAsync(m => m.CountryId == id);

            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
