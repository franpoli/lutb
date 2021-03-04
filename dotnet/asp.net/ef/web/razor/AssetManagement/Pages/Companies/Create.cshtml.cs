using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public CreateModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Companies.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCompany = new Company();

            if (await TryUpdateModelAsync<Company>(
                emptyCompany,
                "company",   // Prefix for form value.
                s => s.CompanyName, s => s.CountryId, s => s.CountryId))
            {
                _context.Companies.Add(emptyCompany);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
