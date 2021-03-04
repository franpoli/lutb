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
    public class IndexModel : PageModel
    {
        private readonly AssetManagement.Data.CompanyContext _context;

        public IndexModel(AssetManagement.Data.CompanyContext context)
        {
            _context = context;
        }

        // Begin Constructors
        public string CompanySort { get; set; }
        public string CountrySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        // End Constructors

        public IList<Company> Companies { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            CompanySort = String.IsNullOrEmpty(sortOrder) ? "company_desc" : "";
            CountrySort = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";

            IQueryable<Company> companiesIQ = from s in _context.Companies
                .Include(c => c.Country)
                select s;

            switch (sortOrder)
            {
                case "company_desc":
                    companiesIQ = companiesIQ.OrderByDescending(s => s.CompanyName)
                        .ThenBy(c => c.Country.CountryName);
                    break;
                case "country_desc":
                    companiesIQ = companiesIQ.OrderByDescending(c => c.Country.CountryName)
                        .ThenBy(s => s.CompanyName);
                    break;
                default:
                    companiesIQ = companiesIQ.OrderBy(s => s.CompanyName)
                        .ThenBy(c => c.Country.CountryName);
                    break;
            }

            Companies = await companiesIQ.AsNoTracking().ToListAsync();
        }
    }
}
