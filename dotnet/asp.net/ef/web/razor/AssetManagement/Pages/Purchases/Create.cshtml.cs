using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssetManagement.Data;
using AssetManagement.Models;

namespace AssetManagement.Pages.Purchases
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
        ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductFullName");
            return Page();
        }

        [BindProperty]
        public Purchase Purchase { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
