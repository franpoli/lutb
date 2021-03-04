using System;
using System.Linq;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CompanyContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Companies.
            if (context.Companies.Any())
            {
                return;   // DB has been seeded
            }

            var productCategories = new ProductCategory[]
            {
                new ProductCategory{Category="Mobile"},
                new ProductCategory{Category="Laptop"},
                new ProductCategory{Category="Tablet"},
                new ProductCategory{Category="Desktop PC"},
                new ProductCategory{Category="Server"},
                new ProductCategory{Category="Router"}
            };

            context.ProductCategories.AddRange(productCategories);
            context.SaveChanges();

            var countries = new Country[]
            {
                new Country{CountryName="Australia", CountryCode="AUS", CurrencyCode="AUD"},
                new Country{CountryName="Canada", CountryCode="CAN", CurrencyCode="CAD"},
                new Country{CountryName="Denmark", CountryCode="DNK", CurrencyCode="DKK"},
                new Country{CountryName="Iceland", CountryCode="ISL", CurrencyCode="ISK"},
                new Country{CountryName="Italy", CountryCode="ITA", CurrencyCode="EUR"},
                new Country{CountryName="Mexico", CountryCode="MEX", CurrencyCode="MXN"},
                new Country{CountryName="Malaysia", CountryCode="MYS", CurrencyCode="MYR"},
                new Country{CountryName="Norway", CountryCode="NOR", CurrencyCode="NOK"},
                new Country{CountryName="New Zeland", CountryCode="NZL", CurrencyCode="NZD"},
                new Country{CountryName="Philippines", CountryCode="PHL", CurrencyCode="PHP"},
                new Country{CountryName="Qatar", CountryCode="QAT", CurrencyCode="QAR"},
                new Country{CountryName="Russia", CountryCode="RUS", CurrencyCode="RUB"},
                new Country{CountryName="Sweden", CountryCode="SWE", CurrencyCode="SEK"},
                new Country{CountryName="Switzerland", CountryCode="CHE", CurrencyCode="CHF"},
                new Country{CountryName="United State of America", CountryCode="USA", CurrencyCode="USD"}
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var companies = new Company[]
            {
                new Company{CompanyName="Lexicon Inc.", CountryId=15},
                new Company{CompanyName="Lexicon AB", CountryId=13},
                new Company{CompanyName="Lexicon SA", CountryId=14}
            };

            context.Companies.AddRange(companies);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{Brand="BQ", Name="BQ Aquaris", Model="M10", Price=309.00, ProductCategoryId=3},
                new Product{Brand="Volla", Name="Volla Phone", Model="UBport", Price=309.00, ProductCategoryId=1},
                new Product{Brand="Fairphone", Name="Fairphone", Model="3+", Price=439.00, ProductCategoryId=1},
                new Product{Brand="Fairphone", Name="Fairphone", Model="3", Price=399.00, ProductCategoryId=1},
                new Product{Brand="Fairphone", Name="Fairphone", Model="2", Price=149.99, ProductCategoryId=1},
                new Product{Brand="Fairphone", Name="Fairphone", Model="1", Price=149.99, ProductCategoryId=1},
                new Product{Brand="Pine64", Name="Pinephone", Model="CE Mobian", Price=149.99, ProductCategoryId=1},
                new Product{Brand="Pine64", Name="Pinephone", Model="CE Manjaro", Price=149.99, ProductCategoryId=1},
                new Product{Brand="Pine64", Name="Pinephone", Model="CE KDE Plasma", Price=149.99, ProductCategoryId=1},
                new Product{Brand="Pine64", Name="Pinebook Pro", Model="14 Inch", Price=199.00, ProductCategoryId=2},
                new Product{Brand="system76", Name="Jackal Pro", Model="2U", Price=917.00, ProductCategoryId=5},
                new Product{Brand="system76", Name="Meerkat", Model="Coreboot", Price=917.00, ProductCategoryId=4},
                new Product{Brand="system76", Name="Thelio Mega", Model="Coreboot", Price=14238.00, ProductCategoryId=4},
                new Product{Brand="system76", Name="Thelio", Model="Coreboot", Price=2268.00, ProductCategoryId=4},
                new Product{Brand="system76", Name="Oxy Pro", Model="Coreboot", Price=1267.00, ProductCategoryId=2},
                new Product{Brand="system76", Name="Darter Pro", Model="Coreboot", Price=1367.00, ProductCategoryId=2},
                new Product{Brand="system76", Name="Lemur Pro", Model="Coreboot", Price=1199.00, ProductCategoryId=2},
                new Product{Brand="Lenovo", Name="Thinkpad", Model="X1 Linux", Price=1314.00, ProductCategoryId=2},
                new Product{Brand="DELL", Name="XPS 13", Model="Dev Edition", Price=989.00, ProductCategoryId=2},
                new Product{Brand="Vikings", Name="D8 Workstation", Model="FSF RYF-Cer", Price=960.00, ProductCategoryId=4},
                new Product{Brand="Vikings", Name="WNDR3800", Model="LibreCMC", Price=39.95, ProductCategoryId=6},
                new Product{Brand="Vikings", Name="WNDR3800", Model="Freifunk", Price=39.95, ProductCategoryId=6},
                new Product{Brand="Technoethical", Name="Libreboot", Model="D16", Price=880.00, ProductCategoryId=5},
                new Product{Brand="Technoethical", Name="Libreboot", Model="T301", Price=880.00, ProductCategoryId=2},
                new Product{Brand="Technoethical", Name="Libreboot", Model="T500", Price=730.00, ProductCategoryId=2},
                new Product{Brand="Technoethical", Name="Libreboot", Model="T400", Price=580.00, ProductCategoryId=2},
                new Product{Brand="Technoethical", Name="Libreboot", Model="X200s", Price=540.00, ProductCategoryId=2},
                new Product{Brand="Mindfree", Name="Libreboot", Model="X200", Price=458.99, ProductCategoryId=2},
                new Product{Brand="Libiquity", Name="Taurinus", Model="X200", Price=495.00, ProductCategoryId=2},
                new Product{Brand="Purism", Name="Librem Mini", Model="Version 2", Price=699.00, ProductCategoryId=4},
                new Product{Brand="Purism", Name="Librem 14", Model="Version 1", Price=1499.00, ProductCategoryId=2},
                new Product{Brand="Purism", Name="Librem 5", Model="Version 1", Price=699.00, ProductCategoryId=1},
                new Product{Brand="Purism", Name="Librem Serveur", Model="L1UM-2X8C", Price=3299.00, ProductCategoryId=5}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var purchases = new Purchase[]
            {
                new Purchase{PurchaseDate=DateTime.Parse("2016-03-08"), ProductId=1, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-11"), ProductId=2, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-11"), ProductId=3, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2020-02-03"), ProductId=4, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2015-06-14"), ProductId=5, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2014-06-25"), ProductId=6, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2018-07-05"), ProductId=7, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2020-03-05"), ProductId=8, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2020-03-01"), ProductId=9, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2018-09-01"), ProductId=10, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2021-02-11"), ProductId=11, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2021-02-11"), ProductId=12, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2021-02-02"), ProductId=13, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-02-02"), ProductId=14, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2018-08-20"), ProductId=15, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2020-09-20"), ProductId=16, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2020-09-20"), ProductId=17, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2020-10-27"), ProductId=18, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2020-04-09"), ProductId=19, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-12"), ProductId=20, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-12"), ProductId=21, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2019-11-21"), ProductId=22, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2019-06-11"), ProductId=23, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2018-11-14"), ProductId=24, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2020-10-13"), ProductId=25, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2020-08-19"), ProductId=26, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2018-10-19"), ProductId=27, CompanyId=3},
                new Purchase{PurchaseDate=DateTime.Parse("2016-01-06"), ProductId=28, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2015-04-19"), ProductId=29, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-01"), ProductId=30, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-01"), ProductId=31, CompanyId=2},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-01"), ProductId=32, CompanyId=1},
                new Purchase{PurchaseDate=DateTime.Parse("2021-01-01"), ProductId=33, CompanyId=2}
            };
            
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

        }
    }
}