using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asset
{
    public class Office
    {
        //public int Id { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaxId { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
        [Required]
        public string CountryCode { get; set; }

        public Office(int taxId, string companyName, string countryName, string countryCode)
        {
            TaxId = taxId;
            CompanyName = companyName;
            CountryName = countryName;
            CountryCode = countryCode;
        }
    }
}
