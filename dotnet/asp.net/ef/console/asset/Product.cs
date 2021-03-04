using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asset
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double PriceUSD { get; set; }
        [Required]
        public string PurchaseDate { get; set; }
        [ForeignKey("TaxId")]
        public int BuyerTaxId { get; set; }
        public Office Buyer { get; set; }
    }
}
