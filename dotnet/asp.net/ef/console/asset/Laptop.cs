namespace asset
{
    public class Laptop : Product
    {
        public bool HasCdrom { get; set; }
        public Laptop(string brand, string name, string model, double priceUSD, string purchaseDate, bool hasCdrom, int buyerTaxId)
        {
            Brand = brand;
            Name = name;
            Model = model;
            PriceUSD = priceUSD;
            PurchaseDate = purchaseDate;
            HasCdrom = hasCdrom;
            BuyerTaxId = buyerTaxId;
        }
    }
}
