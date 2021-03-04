using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [ConcurrencyCheck, MaxLength(18,
            ErrorMessage="CompanyName must be 18 characters or less"),
            MinLength(5)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}