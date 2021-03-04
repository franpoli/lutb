using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagement.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }  // Iso 3166 Alpha3
        [Required]
        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; } // Iso 4217

        public ICollection<Company> Companies { get; set; }
    }
}