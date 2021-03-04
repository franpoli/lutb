namespace asset
{
    public class Mobile : Product
    {
        public bool HasDualSim { get; set; }
        public Mobile(string brand, string name, string model, double priceUSD, string purchaseDate, bool hasDualSim, int buyerTaxId)
        {
            Brand = brand;
            Name = name;
            Model = model;
            PriceUSD = priceUSD;
            PurchaseDate = purchaseDate;
            HasDualSim = hasDualSim;
            BuyerTaxId = buyerTaxId;
        }
    }
}
