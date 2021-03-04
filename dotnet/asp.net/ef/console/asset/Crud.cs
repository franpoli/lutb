using System;
using System.Collections.Generic;
using System.Linq;
using static asset.AssetDbContext;

namespace asset
{
    class Crud
    {
        // Crud: Create demo

        // Strores values in Office table
        public static void FillOfficeTable()
        {
            List<Office> OfficesToDb = new List<Office>
            {
                // Fields: TaxId, CompanyName, CountryName, CountryCode
                new Office(10000, "Lexicon Inc.", CompanyName="United State of America", "USA"),
                new Office(20000, "Lexicon AB", CompanyName="Sweden", "SWE"),
                new Office(30000, "Lexicon SA", CompanyName="Switzerland", "CHE")
            };
            
            Console.Write("Crud: Creating the Office table... ");
            using var context = new AssetgDbContext(); 
            foreach (var obj in OfficesToDb)
            {
                context.Add(obj);
            }
            context.SaveChanges();
            Console.WriteLine("OK, Office table populated.");
        }

        // Strores products values in Mobiles and Laptops tables
        public static void FillProductTable()
        {
            List<Product> ProductsToDb = new List<Product>
            {
                // Fields: Brand, Name, Model, Price (in US $), PurchaseDate, Option (bool), BuyerTaxId
                // Mobile products
                new Mobile("Apple", "iPhone", "I4", 899.0, "2006-12-24", false, 10000),
                new Mobile("Apple", "iPhone", "I11", 1899.0, "2021-01-04", false, 20000),
                new Mobile("Apple", "iPhone", "I10", 1199.0, "2020-09-29", false, 30000),
                new Mobile("Apple", "iPhone", "S6", 799.0, "2018-09-21", false, 20000),
                new Mobile("Apple", "iPhone", "8", 949.0, "2018-10-21", false, 10000),
                new Mobile("Samsung", "Galaxy", "S4", 199.0, "2015-01-12", false, 30000),
                new Mobile("Samsung", "Galaxy", "S4 Plus", 399.0, "2015-01-12", true, 10000),
                new Mobile("Samsung", "Galaxy", "S8 Pro", 899.0, "2018-08-01", true, 20000),
                new Mobile("Nokia", "SONOK", "NK12", 81.0, "2012-04-19", true, 10000),
                new Mobile("Nokia", "SONAK", "NK13", 169.0, "2018-07-19", true, 30000),
                new Mobile("Nokia", "SONUK", "NK14", 169.0, "2020-07-21", true, 20000),
                // Laptop products
                new Laptop("Apple", "iMack", "XB22", 399.0, "2006-12-24", true, 10000),
                new Laptop("Apple", "Macbook Pro", "X34", 6999.0, "2018-06-29", false, 20000),
                new Laptop("Apple", "Macbook Air", "U34", 999.0, "2020-09-29", false, 30000),
                new Laptop("Asus", "AS10", "ASX", 199.0, "2015-01-12", false, 30000),
                new Laptop("Asus", "AS20", "ASX", 399.0, "2015-01-12", true, 10000),
                new Laptop("Asus", "AS30", "ASX", 899.0, "2018-08-09", false, 20000),
                new Laptop("Lenovo", "Thinkpad", "X200", 289.0, "2012-04-19", true, 10000),
                new Laptop("Lenovo", "Thinkpad", "X300", 389.0, "2019-08-19", true, 30000),
                new Laptop("Lenovo", "Thinkpad", "X800", 899.0, "2021-01-06", false, 20000)
            };

            Console.Write("Crud: Creating the Product tables... ");
            using var context = new AssetgDbContext();
            foreach (var obj in ProductsToDb)
            {
                context.Add(obj);
            }
            context.SaveChanges();
            Console.WriteLine("OK, Product tables populated.");
        }

        // Crud: Read demo
        public static void ReadTables()
        {
            Console.Write("cRud: Reading tables... ");
            using var context = new AssetgDbContext();
            var productsInDb = ProductsInDb();
            Console.WriteLine("OK ");

            var Offices = context.Offices.ToList();

            var result = from office in Offices
                      join product in ProductsInDb()
                           on office.TaxId equals product.BuyerTaxId
                      orderby office.CompanyName, product.PurchaseDate ascending
                      select new
                      {
                          OfficeName = office.CompanyName,
                          OfficeCountry = office.CountryCode,
                          OfficeAssetName = product.Name,
                          OfficeAssetModel = product.Model,
                          OfficeAssetPrice = product.PriceUSD,
                          OfficeAssetBrand = product.Brand,
                          OfficeAssetDate = product.PurchaseDate
                      };

            foreach (var r in result)
            {
                
                ColoredMessage(
                    r.OfficeAssetDate,
                          $"{r.OfficeName, -16}"
                        + $"{r.OfficeCountry, -10}"
                        + $"{r.OfficeAssetName, -16}"
                        + $"{r.OfficeAssetModel, -12}"
                        + $"{LocalPrice(r.OfficeCountry, r.OfficeAssetPrice).ToString("0.00"), -10}"
                        + $"{CurrencyCode(r.OfficeCountry), -8}"
                        + $"{r.OfficeAssetBrand, -10}"
                        + $"{r.OfficeAssetDate, -10}"
                    );
            }

            Console.WriteLine("{0} {1} shared among {2} {3} stored in the database.",
                productsInDb.Count,
                (productsInDb.Count < 2 ? "product" : "products"),
                Offices.Count,
                (Offices.Count < 2 ? "office" : "offices"));
        }

        // Crud: Update demo
        public static void TwentyPercentSalesOnLenovoLaptops()
        {
            Console.Write("crUd: Updating prices... ");
            using var context = new AssetgDbContext();

            var Laptops = context.Laptops.ToList();

            var result = from device in Laptops
                      where device.Brand == "Lenovo"
                      select device;
            
            var counter = 0;
            
            foreach (var r in result)
            {
                r.PriceUSD *= 0.8;
                counter++;
            }
            context.SaveChanges();
            Console.WriteLine($"OK, {counter} prices updated.");
        }

        // Crud: Delete demo
        public static void DeleteNonProfitableApplePhones()
        {
            Console.Write("cruD: Deleting phones... ");
            using var context = new AssetgDbContext();

            var Mobiles = context.Mobiles;

            var result = from device in Mobiles
                         where device.PriceUSD < 900 && device.Brand == "Apple"
                         select device;

            var counter = 0;

            foreach (var r in result)
            {
                Mobiles.Remove(r);
                counter++;
            }
            context.SaveChanges();
            Console.WriteLine($"OK, {counter} phones deleted.");
        }

        private static List<Product> ProductsInDb()
        {
            using var context = new AssetgDbContext();

            var Mobiles = context.Mobiles.ToList();
            var Laptops = context.Laptops.ToList();

            List<Product> productsList = new List<Product>();
            foreach (var m in Mobiles)
            {
                productsList.Add(m);
            }
            foreach (var l in Laptops)
            {
                productsList.Add(l);
            }
            return productsList;
        }

        private static void ColoredMessage(string date, string message)
        {
            var currentTime = new DateTime();
            currentTime = DateTime.Now;

            var strDate = date;
            var purchasedDate = Convert.ToDateTime(strDate);
            var daysInterval = (currentTime - purchasedDate).TotalDays;

            if (daysInterval > (3*12*30 - 3*30))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (daysInterval > (3*12*30 - 6*30))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static double LocalPrice(string countryCode, double priceInUsDollar)
        {
            if (countryCode != "USA")
            {
                if (countryCode == "CHE")
                {
                    return priceInUsDollar * 0.83;
                }
                else
                {
                    return priceInUsDollar * 8.21;
                }
            }
            return priceInUsDollar;
        }

        private static string CurrencyCode(string countryCode)
        {
            if (countryCode != "USA")
            {
                if (countryCode == "CHE")
                {
                    return "CHF";
                }
                else
                {
                    return "SEK";
                }
            }
            return "USD";
        }
    }
}
