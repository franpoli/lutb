
# Table of Contents

1.  [Intro](#orga4bfb3f)
2.  [Getting started](#org8e5caf6)
    1.  [Prerequisites](#org5be351a)
3.  [Create the project template](#orgacb6662)
    1.  [Setting up the project](#org9c1dc6d)
4.  [Intial Styling](#orgbe0e054)
    1.  [Setting up the site style](#org72684bc)
5.  [Data model, Code First](#org6c86448)
    1.  [The Office entity](#org512be63)
    2.  [The Product entity](#org4df1cc7)
    3.  [The Country entity](#org1142bc7)
    4.  [The ProductCategory entity](#orgda5786e)
6.  [Scaffold](#org6edbcc7)
    1.  [Scaffold Office pages](#orgdf881e3)
    2.  [Generate the Product and Countries pages](#org0cbc066)
7.  [Database](#org9bda36b)
    1.  [Database connection string](#orgea69613)
    2.  [Update the database context class](#orge7b10d9)
    3.  [Startup.cs](#orgf78ba25)
    4.  [Add the database exception filter](#org5b5ef22)
    5.  [Create the database](#orgfd5c673)
    6.  [Seed the database](#org199a367)
    7.  [Asynchronous code](#org115c586)
    8.  [View the database with SQLite commands](#org155718e)
    9.  [Changing the navigation](#org02c674d)
8.  [Managing ressources](#orgf880739)
9.  [Revisiting the model](#org347ff95)
10. [Adding additional data to the details page](#org89ba43f)
11. [Overposting](#org771b38f)
12. [Sorting list](#org9ded6ec)
13. [Search functionality](#org91567c4)
14. [Adding ProductFullName property](#org0e00e1e)
15. [Adding soem conditional formating](#org22d747c)
16. [Web API](#org5068537)
17. [Going further](#org99cbd01)
    1.  [Fix issues](#org230f603)
    2.  [Adding features](#org54b13b7)
18. [Errata](#org27d0c0d)
    1.  [REMOVED - Consume 3rd party API](#orgaee7c95)



<a id="orga4bfb3f"></a>

# Intro

A step by step guide building the Asset Management App using Razor Pages with Entity Framework Core in ASP.NET Core.


<a id="org8e5caf6"></a>

# Getting started


<a id="org5be351a"></a>

## Prerequisites

-   [A text editor](https://www.gnu.org/software/emacs/) or a C# IDE as [Visual Studio Code](https://code.visualstudio.com/) for convenience
-   [.NET 5.0 SDK or later](https://dotnet.microsoft.com/)
-   [SQLite](https://www.sqlite.org/) Database engines

Optional EF diagram tools:

-   [GraphViz](https://graphviz.org/)
-   [SchemaSpy](http://schemaspy.org/)


<a id="orgacb6662"></a>

# Create the project template


<a id="org9c1dc6d"></a>

## Setting up the project

    dotnet new webapp -o AssetManagement
    cd AssetManagement

Running the first command above, will install the *webapp* template files into our project directory *AssetManagement*. Below you can see the directories structure that the command has generated:

    tree -d AssetManagement

    AssetManagement
    ├── obj
    ├── Pages
    │   └── Shared
    ├── Properties
    └── wwwroot
        ├── css
        ├── js
        └── lib
            ├── bootstrap
            │   └── dist
            │       ├── css
            │       └── js
            ├── jquery
            │   └── dist
            ├── jquery-validation
            │   └── dist
            └── jquery-validation-unobtrusive

The *wwwroot* folder is where our static ressources such as css, JavaScript, image files are stored.
The *Pages* folder holds our razor pages with the extension name *.cshtml*. The files with the extension *.cshtml.cs* contain our C# model classes.


<a id="orgbe0e054"></a>

# Intial Styling


<a id="org72684bc"></a>

## Setting up the site style

Copy and paste the following code into the `Pages/Shared/_Layout.cshtml`:

    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>@ViewData["Title"] - Asset Management</title>
        <!-- CSS files -->
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
        <link rel="stylesheet" href="~/css/site.css" />
    </head>
    <body>
        <header>
            <!-- Navigation -->
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                <div class="container">
                    <a class="navbar-brand" asp-area="" asp-page="/Index">Asset Management</a>
                    <button class="navbar-toggler"
                        type="button"
                        data-toggle="collapse" data-target=".navbar-collapse"
                        aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                        <ul class="navbar-nav flex-grow-1">
                            <li class="nav-item">
                                <a class="nav-link text-dark" asp-area="" asp-page="/Offices/Index">Offices</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" asp-area="" asp-page="/Countries/Index">Countries</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-dark" asp-area="" asp-page="/Products/Index">Products</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
        <!-- Page content -->
        <div class="container">
            <main role="main" class="pb-3">
                <!-- Razor injections here -->
                @RenderBody()
            </main>
        </div>
        <!-- Page footer -->
        <footer class="border-top footer text-muted">
            <div class="container">
                &copy; 2021 - Asset Management - <a asp-area="" asp-page="/Privacy">Privacy</a>
            </div>
        </footer>
        <!-- JavaScripts -->
        <script src="~/lib/jquery/dist/jquery.js"></script>
        <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
        <script src="~/js/site.js" asp-append-version="true"></script>
        @await RenderSectionAsync("Scripts", required: false)
    </body>
    </html>

The layout file sets the site header, footer, and menu. The preceding code makes the following changes:

-   Each occurrence of "AssetManagement" to "Asset Management". There are three occurrences.
-   The Home and Privacy menu entries are deleted.
-   Entries are added for Products, Offices, Mobiles, Laptops.

I have commented the main sections of thes layout file with the following tags:

    <!-- CSS files -->
    <!-- Navigation -->
    <!-- Page content -->
    <!-- Razor injections here -->
    <!-- Page footer -->
    <!-- JavaScripts -->   

In Pages/Index.cshtml, replace the contents of the file with the following code:

    @page
    @model IndexModel
    @{
        ViewData["Title"] = "Home page";
    }
    <div class="row mb-auto">
        <div class="col-md-4">
            <div class="row no-gutters border mb-4">
                <div class="col p-4 mb-4 ">
                    <p class="card-text">
                        Asset Management is a sample application that
                        demonstrates how to use Entity Framework Core in an
                        ASP.NET Core Razor Pages web app.
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="row no-gutters border mb-4">
                <div class="col p-4 d-flex flex-column position-static">
                    <p class="card-text mb-auto">
                        This application has been build on a GNU/Linux distribution. You should be able to reproduce this app using non proprietary software.
                    </p>
                    <p>
                        <a href="https://github.com/franpoli/lexutb" class="stretched-link">See the tutorial</a>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="row no-gutters border mb-4">
                <div class="col p-4 d-flex flex-column">
                    <p class="card-text mb-auto">
                        Most reference for building this app where found on Microsoft Official documentation.
                    </p>
                    <p>
                        <a href="https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0" class="stretched-link"></a>See the learning ressources.</a>
                    </p>
                </div>
            </div>
        </div>
    </div>

The preceding code replaces the text about ASP.NET Core with text about this app.

Run the app to verify that the home page appears.

    dotnet run


<a id="org6c86448"></a>

# Data model, Code First


<a id="org512be63"></a>

## The Office entity

Create a *Models* folder in the project directory and then create the *Models/Office.cs* with the following code:

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace AssetManagement.Models
    {
        public class Office
        {
            [Key]
            [Display(Name = "Office Id")]
            public int OfficeId { get; set; }
    
            [ConcurrencyCheck, MaxLength(18,
                ErrorMessage="CompanyName must be 18 characters or less"),
                MinLength(5)]
            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }
    
            [Display(Name = "Country Name")]
            public int CountryId { get; set; }      
            [Display(Name = "Country Name")]
            public Country Country { get; set; }
            public ICollection<Product> Product { get; set; }
        }
    }

By default EF Core will set any property called `Id` or alternatively `OfficeId` (ClassNameId) as the primary key.


<a id="org4df1cc7"></a>

## The Product entity

Create the file *Models/Product.cs* as follows:

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace AssetManagement.Models
    {
        public class Product
        {
            [Key]
            [Display(Name = "Product Id")]
            public int ProductId { get; set; }
            public string Brand { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
            [Display(Name = "Price (USD)")]
            public double PriceUSD { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                ApplyFormatInEditMode = true)]
            [Display(Name = "Purchase Date")]
            public DateTime PurchaseDate { get; set; }
    
            [Display(Name = "Produkt Category")]
            public int ProductCategoryId { get; set; }
            [Display(Name = "Produkt Category")]
            public ProductCategory ProductCategory { get; set; }
    
            [Display(Name = "Company Name")]
            public int OfficeId { get; set; }
            [Display(Name = "Company Name")]
            public Office Office { get; set; }
        }
    }

We defined above the property `BuyerTaxId` as a foreign key associated to the Office TaxId property.


<a id="org1142bc7"></a>

## The Country entity

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace AssetManagement.Models
    {
        public class Country
        {
            [Key]
            [Display(Name = "Country Id")]
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
    
            public ICollection<Office> Office { get; set; }
        }
    }


<a id="orgda5786e"></a>

## The ProductCategory entity

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace AssetManagement.Models
    {
        public class ProductCategory
        {
            [Key]
            [Display(Name = "Product Category Id")]
            public int ProductCategoryId { get; set; }
            public string Category { get; set; }
    
            public ICollection<Product> Product { get; set; }
        }
    }


<a id="org6edbcc7"></a>

# Scaffold


<a id="orgdf881e3"></a>

## Scaffold Office pages

We use the ASP.NET Core scaffolding tool to generate:

-   An EF Core `DbContext` class. The context is the main class that coordinates Entity Framework functionality for a given data model. It derives from the [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext) class.
-   Razor pages that handle Create, Read, Update, and Delete (CRUD) operations for the Office entity

Run the following .NET Core CLI commands to install required NuGet packages:

    dotnet add package Microsoft.EntityFrameworkCore.SQLite
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

The Microsoft.VisualStudio.Web.CodeGeneration.Design package is required for scaffolding. Although the app won't use SQL Server, the scaffolding tool needs the SQL Server package.

-   Create a *Pages/Offices* folder

-   Run the following command to install the [aspnet-codegenerator scaffolding](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator) tool
    
        dotnet tool install --global dotnet-aspnet-codegenerator

-   Run the following command to scaffold Office pages:
    
        dotnet aspnet-codegenerator razorpage -m Office -dc AssetManagement.Data.OfficeContext -udl -outDir Pages/Offices --referenceScriptLibraries -sqlite

The scaffolding process:

-   Creates Razor pages in the Pages/Offices folder:
    -   Create.cshtml and Create.cshtml.cs
    -   Delete.cshtml and Delete.cshtml.cs
    -   Details.cshtml and Details.cshtml.cs
    -   Edit.cshtml and Edit.cshtml.cs
    -   Index.cshtml and Index.cshtml.cs
-   Creates Data/OfficeContext.cs.
-   Adds the context to dependency injection in Startup.cs.
-   Adds a database connection string to appsettings.json.


<a id="org0cbc066"></a>

## Generate the Product and Countries pages

Create the folder *Pages/Products* and the folder *Pages/Countries*.

Run the following commands to scaffold the pages::

    dotnet aspnet-codegenerator razorpage -m Product -dc AssetManagement.Data.OfficeContext -udl -outDir Pages/Products --referenceScriptLibraries -sqlite
    dotnet aspnet-codegenerator razorpage -m Country -dc AssetManagement.Data.OfficeContext -udl -outDir Pages/Countries --referenceScriptLibraries -sqlite

Run the app and try if it builds properly.


<a id="org9bda36b"></a>

# Database


<a id="orgea69613"></a>

## Database connection string

The scaffolding tool generates a connection string in the *appsettings.json* file.

Shorten the SQLite connection string to AM.db:

    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "OfficeContext": "Data Source=AM.db"
      }
    }   


<a id="orge7b10d9"></a>

## Update the database context class

The main class that coordinates EF Core functionality for a given data model is the database context class. The context is derived from [Microsoft.EntityFrameworkCore.DbContext](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext). The context specifies which entities are included in the data model. In this project, the class is named `OfficeContext`.

Update Data/OfficeContext.cs with the following code:

    using Microsoft.EntityFrameworkCore;
    using AssetManagement.Models;
    
    namespace AssetManagement.Data
    {
        public class OfficeContext : DbContext
        {
            public OfficeContext (DbContextOptions<OfficeContext> options)
                : base(options)
            {
            }
    
            public DbSet<Office> Offices { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Country> Countries { get; set; }
            public DbSet<ProductKind> ProductsKind { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Office>().ToTable("Office");
                modelBuilder.Entity<Product>().ToTable("Product");
                modelBuilder.Entity<Country>().ToTable("Country");
                modelBuilder.Entity<ProductKind>().ToTable("ProductKind");
            }
        }
    }

The preceding code changes from the singular `DbSet<Office> Office` to the plural `DbSet<Office> Offices`. To make the Razor Pages code match the new `DBSet` name, make a global change from: `_context.Office` to `_context.Offices`. There are 8 occurences to modify. We can them all at once using the following command:

    grep -rlZ '_context.Office' | xargs -0 sed -i 's/_context.Office/_context.Offices/g'

You may check your modification as follows:

    grep -rn '_context.Office'

    Pages/Offices/Details.cshtml.cs:31:            Office = await _context.Offices.FirstOrDefaultAsync(m => m.OfficeId == id);
    Pages/Offices/Delete.cshtml.cs:32:            Office = await _context.Offices.FirstOrDefaultAsync(m => m.OfficeId == id);
    Pages/Offices/Delete.cshtml.cs:48:            Office = await _context.Offices.FindAsync(id);
    Pages/Offices/Delete.cshtml.cs:52:                _context.Offices.Remove(Office);
    Pages/Offices/Index.cshtml.cs:26:            Office = await _context.Offices.ToListAsync();
    Pages/Offices/Edit.cshtml.cs:33:            Office = await _context.Offices.FirstOrDefaultAsync(m => m.OfficeId == id);
    Pages/Offices/Edit.cshtml.cs:74:            return _context.Offices.Any(e => e.TaxId == id);
    Pages/Offices/Create.cshtml.cs:38:            _context.Offices.Add(Office);

Because an entity set contains multiple entities, many developers prefer the `DBSet` property names should be plural.

The OfficeContext class creates a [DbSet<TEntity>](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1) property for each entity set. In EF Core terminology:

-   An **entity set** typically corresponds to a database table.
-   An **entity** corresponds to a row in the table.

The OfficeContext class also calls [OnModelCreating](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.onmodelcreating):

-   Is called when `OfficeContext` has been initialized, but before the model has been locked down and used to initialize the context.
-   It is require if the `Office` entity have references to other entties.

Build the project to verify there are no compiler errors:

    dotnet build


<a id="orgf78ba25"></a>

## Startup.cs

ASP.NET Core is built with `dependency injection`. Services such as the OfficeContext are registered with dependency injection during app startup. Components that require these services, such as Razor Pages, are provided these services via constructor parameters.

The scaffolding tool automatically registered the context class with the dependency injection container.

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    
        services.AddDbContext<OfficeContext>(options =>
             options.UseSqlite(Configuration.GetConnectionString("OfficeContext")));
    }

The name of the connection string is passed in to the context by calling a method on a [DbContextOptions](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions) object. For local development, the [ASP.NET Core configuration system](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0) reads the connection string from the *appsettings.json* file.


<a id="org5b5ef22"></a>

## Add the database exception filter

Add [AddDatabaseDeveloperPageExceptionFilter](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.databasedeveloperpageexceptionfilterserviceextensions.adddatabasedeveloperpageexceptionfilter) to `ConfigureServices` as shown in the following code:

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
    
        services.AddDbContext<OfficeContext>(options =>
           options.UseSqlite(Configuration.GetConnectionString("OfficeContext")));
    
        services.AddDatabaseDeveloperPageExceptionFilter();
    }   

The `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore` NuGet package provides ASP.NET Core middleware for Entity Framework Core error pages. This middleware helps to detect and diagnose errors with Entity Framework Core migrations.
The `AddDatabaseDeveloperPageExceptionFilter` provides helpful error information in the [development environment](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-5.0).


<a id="orgfd5c673"></a>

## Create the database

Update *Program.cs* to create the database if it doesn't exist:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using AssetManagement.Data;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace AssetManagement
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // CreateHostBuilder(args).Build().Run();
                var host = CreateHostBuilder(args).Build();
                CreateDbIfNotExists(host);
                host.Run();
            }
    
            private static void CreateDbIfNotExists(IHost host)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
    
                    try
                    {
                        var context = services.GetRequiredService<OfficeContext>();
                        // context.Database.EnsureCreated();
                        DbInitializer.Initialize(context);
                    }
    
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred creating the DB.");
                    }
                }
            }
    
            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }

The [EnsureCreated](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.databasefacade.ensurecreated#Microsoft_EntityFrameworkCore_Infrastructure_DatabaseFacade_EnsureCreated) method takes no action if a database for the context exists. If no database exists, it creates the database and schema. EnsureCreated enables the following workflow for handling data model changes:

-   Delete the database. Any existing data is lost.
-   Change the data model. For example, add an `EmailAddress` field.
-   Run the app.
-   `EnsureCreated` creates a database with the new schema.

This workflow works well early in development when the schema is rapidly evolving, as long as you don't need to preserve data. The situation is different when data that has been entered into the database needs to be preserved. When that is the case, use migrations.


<a id="org199a367"></a>

## Seed the database

Create *Data/DbInitializer.cs* with the following code:

    using System;
    using System.Linq;
    using AssetManagement.Models;
    
    namespace AssetManagement.Data
    {
        public static class DbInitializer
        {
            public static void Initialize(OfficeContext context)
            {
                context.Database.EnsureCreated();
    
                // Look for any offices.
                if (context.Offices.Any())
                {
                    return;   // DB has been seeded
                }
    
                var productsKind = new ProductKind[]
                {
                    new ProductKind{Kind="Mobile"},
                    new ProductKind{Kind="Laptop"},
                    new ProductKind{Kind="Tablet"},
                    new ProductKind{Kind="PC"},
                    new ProductKind{Kind="Monitor"}
                };
    
                context.ProductsKind.AddRange(productsKind);
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
    
                var offices = new Office[]
                {
                    new Office{CompanyName="Lexicon Inc.", CountryId=15},
                    new Office{CompanyName="Lexicon AB", CountryId=13},
                    new Office{CompanyName="Lexicon SA", CountryId=14}
                };
    
                context.Offices.AddRange(offices);
                context.SaveChanges();
    
                var products = new Product[]
                {
                    new Product{Brand="Apple", Name="iPhone", Model="I4", PriceUSD=899.99, PurchaseDate=DateTime.Parse("2006-12-24"), ProductKindId=1, OfficeId=1},
                    new Product{Brand="Apple", Name="iPhone", Model="I11", PriceUSD=1899.29, PurchaseDate=DateTime.Parse("2021-01-04"), ProductKindId=1, OfficeId=2},
                    new Product{Brand="Apple", Name="iPhone", Model="I10", PriceUSD=1199.29, PurchaseDate=DateTime.Parse("2020-09-29"), ProductKindId=1, OfficeId=3},
                    new Product{Brand="Apple", Name="iPhone", Model="S6", PriceUSD=799.99, PurchaseDate=DateTime.Parse("2018-09-21"), ProductKindId=1, OfficeId=2},
                    new Product{Brand="Apple", Name="iPhone", Model="8", PriceUSD=949.39, PurchaseDate=DateTime.Parse("2018-10-21"), ProductKindId=1, OfficeId=1},
                    new Product{Brand="Samsung", Name="Galaxy", Model="S4", PriceUSD=199.99, PurchaseDate=DateTime.Parse("2015-01-12"), ProductKindId=1, OfficeId=3},
                    new Product{Brand="Samsung", Name="Galaxy", Model="S4 Plus", PriceUSD=399.99, PurchaseDate=DateTime.Parse("2015-01-12"), ProductKindId=1, OfficeId=1},
                    new Product{Brand="Samsung", Name="Galaxy", Model="S8 Pro", PriceUSD=899.99, PurchaseDate=DateTime.Parse("2018-08-01"), ProductKindId=1, OfficeId=2},
                    new Product{Brand="Nokia", Name="SONOK", Model="NK12", PriceUSD=81.99, PurchaseDate=DateTime.Parse("2012-04-19"), ProductKindId=1, OfficeId=1},
                    new Product{Brand="Nokia", Name="SONAK", Model="NK13", PriceUSD=169.99, PurchaseDate=DateTime.Parse("2018-07-19"), ProductKindId=1, OfficeId=3},
                    new Product{Brand="Nokia", Name="SONUK", Model="NK14", PriceUSD=169.99, PurchaseDate=DateTime.Parse("2020-07-21"), ProductKindId=1, OfficeId=2},
                    new Product{Brand="Apple", Name="iMack", Model="XB22", PriceUSD=399.99, PurchaseDate=DateTime.Parse("2006-12-24"), ProductKindId=2, OfficeId=1},
                    new Product{Brand="Apple", Name="Macbook Pro", Model="X34", PriceUSD=6999.99, PurchaseDate=DateTime.Parse("2018-06-29"), ProductKindId=2, OfficeId=2},
                    new Product{Brand="Apple", Name="Macbook Air", Model="U34", PriceUSD=999.99, PurchaseDate=DateTime.Parse("2020-09-29"), ProductKindId=2, OfficeId=3},
                    new Product{Brand="Asus", Name="AS10", Model="ASX", PriceUSD=199.99, PurchaseDate=DateTime.Parse("2015-01-12"), ProductKindId=2, OfficeId=3},
                    new Product{Brand="Asus", Name="AS20", Model="ASX", PriceUSD=399.99, PurchaseDate=DateTime.Parse("2015-01-12"), ProductKindId=2, OfficeId=2},
                    new Product{Brand="Asus", Name="AS30", Model="ASX", PriceUSD=899.99, PurchaseDate=DateTime.Parse("2018-08-09"), ProductKindId=2, OfficeId=1},
                    new Product{Brand="Lenovo", Name="Thinkpad", Model="X200", PriceUSD=289.99, PurchaseDate=DateTime.Parse("2012-04-19"), ProductKindId=2, OfficeId=1},
                    new Product{Brand="Lenovo", Name="Thinkpad", Model="X300", PriceUSD=389.99, PurchaseDate=DateTime.Parse("2019-08-19"), ProductKindId=2, OfficeId=3},
                    new Product{Brand="Lenovo", Name="Thinkpad", Model="X800", PriceUSD=899.99, PurchaseDate=DateTime.Parse("2021-01-06"), ProductKindId=2, OfficeId=2}
                };
    
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }

The code checks if there are any offices in the database. If there are no offices, it adds test data to the database. It creates the test data in arrays rather than List<T> collections to optimize performance.

In *Program.cs*, replace the `EnsureCreated` call with a DbInitializer.Initialize call:

    // context.Database.EnsureCreated();
    DbInitializer.Initialize(context);   

Stop the app if it's running, and delete the AM.db file. Then restrt the app with the command `dotnet run` and select the Offices page to see the seeded data.


<a id="org115c586"></a>

## Asynchronous code

Asynchronous programming is the default mode for ASP.NET Core and EF Core.

A web server has a limited number of threads available, and in high load situations all of the available threads might be in use. When that happens, the server can't process new requests until the threads are freed up. With synchronous code, many threads may be tied up while they aren't doing work because they're waiting for I/O to complete. With asynchronous code, when a process is waiting for I/O to complete, its thread is freed up for the server to use for processing other requests. As a result, asynchronous code enables server resources to be used more efficiently, and the server can handle more traffic without delays.

Asynchronous code does introduce a small amount of overhead at run time. For low traffic situations, the performance hit is negligible, while for high traffic situations, the potential performance improvement is substantial.

In the following code, the [async](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async) keyword, `Task` return value, `await` keyword, and `ToListAsync` method make the code execute asynchronously.

    public async Task OnGetAsync()
    {
        Students = await _context.Students.ToListAsync();
    }   

-   The `async` keyword tells the compiler to:
    -   Generate callbacks for parts of the method body.
    -   Create the [Task](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/async-return-types#BKMK_TaskReturnType) object that's returned.
-   The `Task` return type represents ongoing work.
-   The `await` keyword causes the compiler to split the method into two parts. The first part ends with the operation that's started asynchronously. The second part is put into a callback method that's called when the operation completes.
-   `ToListAsync` is the asynchronous version of the `ToList` extension method.

-   Only statements that cause queries or commands to be sent to the database are executed asynchronously. That includes `ToListAsync`, `SingleOrDefaultAsync`, `FirstOrDefaultAsync`, and `SaveChangesAsync`. It doesn't include statements that just change an `IQueryable`, such as `var students = context.Students.Where(s => s.LastName == "Davolio")`.

See also [Async Overview](https://docs.microsoft.com/en-us/dotnet/standard/async) and [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/).


<a id="org155718e"></a>

## View the database with SQLite commands

1.  Launch the SQLite application from the terminal:
    
        sqlite3
    
        SQLite version 3.34.1 2021-01-20 14:10:07
        Enter ".help" for usage hints.
        Connected to a transient in-memory database.

2.  Connect to the AM.db databse:
    
        sqlite> .open AM.db

3.  List the tables in the AM.db:
    
        sqlite> .tables
    
        ookup                 Product
        Office                ProductKind

4.  Select a conveninent output mode for the terminal:
    
        sqlite> .mode column
        sqlite> .headers on

5.  Query an available table:
    
        sqlite> SELECT * FROM Office;
    
        OfficeId  CompanyName   CountryId
        --------  ------------  --------
        1         Lexicon SA    14
        2         Lexicon AB    13
        3         Lexicon Inc.  15
    
        sqlite> SELECT * FROM Product LIMIT 10;;
    
        ProductId  Brand    Name      Model  PriceUSD  PurchaseDate         ProductKindId  OfficeId
        ---------  -------  --------  -----  --------  -------------------  -------------  --------
        1          Asus     AS10      ASX    199.99    2015-01-12 00:00:00  2              4
        2          Lenovo   Thinkpad  X200   289.99    2012-04-19 00:00:00  2              1
        3          Asus     AS30      ASX    899.99    2018-08-09 00:00:00  2              1
        4          Asus     AS20      ASX    399.99    2015-01-12 00:00:00  2              2
        5          Apple    iPhone    I4     899.99    2006-12-24 00:00:00  1              1
        6          Apple    iPhone    I11    1899.29   2021-01-04 00:00:00  1              2
        7          Apple    iPhone    I10    1199.29   2020-09-29 00:00:00  1              3
        8          Apple    iPhone    S6     799.99    2018-09-21 00:00:00  1              2
        9          Apple    iPhone    8      949.39    2018-10-21 00:00:00  1              1
        10         Samsung  Galaxy    S4     199.99    2015-01-12 00:00:00  1              3
    
        sqlite> SELECT * FROM Country;
    
        ountryName              CountryCode  CurrencyCode
        -----------------------  -----------  ------------
        Australia                AUS          AUD
        Canada                   CAN          CAD
        Denmark                  DNK          DKK
        Iceland                  ISL          ISK
        Italy                    ITA          EUR
        Mexico                   MEX          MXN
        Malaysia                 MYS          MYR
        Norway                   NOR          NOK
        New Zeland               NZL          NZD
        Philippines              PHL          PHP
        Qatar                    QAT          QAR
        Russia                   RUS          RUB
        Sweden                   SWE          SEK
        Switzerland              CHE          CHF
        United State of America  USA          USD

6.  Joining tables
    
        sqlite> SELECT
           ...>   P.Brand, P.Name, P.Model, P.Price, C.Category
           ...> FROM
           ...>  Product P JOIN ProductCategory C ON P.ProductCategoryId = C.ProductCategoryId
           ...> WHERE P.Price > 1000
           ...> ORDER BY P.Price DESC;
    
        Brand     Name            Model      Price    Category
        --------  --------------  ---------  -------  ----------
        system76  Thelio Mega     Coreboot   14238.0  Desktop PC
        Purism    Librem Serveur  L1UM-2X8C  3299.0   Server
        system76  Thelio          Coreboot   2268.0   Desktop PC

7.  Close SQLite once you are done with it:
    
        sqlite> .quit


<a id="org02c674d"></a>

## Changing the navigation

At this stage we are navigating using the primary keys. These keys are self generated and are unique for each record in our tables. However these keys are not human readable. We may want to change the navigation in our cshtml file in order to point to values that make sense for the users:

    git diff | grep '+\|-'

    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Offices/Delete.cshtml
    @@ -22,7 +22,7 @@
    +            @Html.DisplayFor(model => model.Office.Country.CountryName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Offices/Details.cshtml
    @@ -21,7 +21,7 @@
    +            @Html.DisplayFor(model => model.Office.Country.CountryName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Offices/Edit.cshtml.cs
    @@ -30,14 +30,14 @@ namespace AssetManagement.Pages.Offices
    +            Office = await _context.Offices
    +           ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Offices/Index.cshtml
    @@ -29,7 +29,7 @@
    +                @Html.DisplayFor(modelItem => item.Country.CountryName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Create.cshtml.cs
    @@ -21,8 +21,8 @@ namespace AssetManagement.Pages.Products
    +        ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "CompanyName");
    +        ViewData["ProductKindId"] = new SelectList(_context.ProductsKind, "ProductKindId", "Kind");
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Delete.cshtml
    @@ -46,13 +46,13 @@
    +            @Html.DisplayFor(model => model.Product.ProductKind.Kind)
    +            @Html.DisplayFor(model => model.Product.Office.CompanyName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Details.cshtml
    @@ -45,13 +45,13 @@
    +            @Html.DisplayFor(model => model.Product.ProductKind.Kind)
    +            @Html.DisplayFor(model => model.Product.Office.CompanyName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Edit.cshtml.cs
    @@ -30,16 +30,16 @@ namespace AssetManagement.Pages.Products
    +            Product = await _context.Products
    +                .Include(p => p.Office)
    +           ViewData["OfficeId"] = new SelectList(_context.Offices, "OfficeId", "CompanyName");
    +           ViewData["ProductKindId"] = new SelectList(_context.ProductsKind, "ProductKindId", "Kind");
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Index.cshtml
    @@ -56,10 +56,10 @@
    +                @Html.DisplayFor(modelItem => item.ProductKind.Kind)
    +                @Html.DisplayFor(modelItem => item.Office.CompanyName)
    +++ b/dotnet/asp.net/ef/web/AssetManagement/Pages/Products/Index.cshtml.cs
    @@ -23,8 +23,8 @@ namespace AssetManagement.Pages.Products
    +            Product = await _context.Products
    +                .Include(p => p.Office)


<a id="orgf880739"></a>

# Managing ressources

We can compress our CSS files and JavaScript files in order to save ressources on our server. We can make use of the tag helper `environment` to encapsulate the elements from the *Pages/Shared/<sub>Layout.cshtml</sub>* file we want to compress:

    <!DOCTYPE html>
    
        ...
    
        <!-- CSS files -->
        <environment include="Development">
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
        <link rel="stylesheet" href="~/css/site.css" />
        </environment>
        <environment include="Production">
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
        <link rel="stylesheet" href="~/css/site.min.css" />
        </environment>
    
        ...
    
        <!-- JavaScripts -->
        <environment include="Development">
        <script src="~/lib/jquery/dist/jquery.js"></script>
        <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
        </environment>
        <script src="~/js/site.js" asp-append-version="true"></script>
        @await RenderSectionAsync("Scripts", required: false)
        <environment include="Production">
        <script src="~/lib/jquery/dist/jquery.js"></script>
        <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.js"></script>
        </environment>
        <script src="~/js/site.js" asp-append-version="true"></script>
        @await RenderSectionAsync("Scripts", required: false)
    </body>
    </html>

In the above modification, we defined e development envrionment where CSS and JavaScript files are not compressed for easy reading, and a production environment where these file are going to be compressed.

To test if this works, you can switch to the production environment by changing the "ASPNETCORE<sub>ENVIRONMENT</sub>" property in the *Properties/launchSettings.json* file from "Development" to "Production" and tun your app.

Read more about Tag Helpers on the Microsoft [Tag Helpers in ASP.NET Core](https://docs.microsoft.com/en-US/aspnet/core/mvc/views/tag-helpers/intro?view=aspnetcore-5.0) documentation.


<a id="org347ff95"></a>

# Revisiting the model

At this stage we created a model focused on the Product class. As in real life, if we purchase multiple identical products we get several copies of this same product. If we need to delete a product because it has been sold or lost, we then delete this product from our database loosing also track from the purchase. We will introduce now a new model by creating the Purchase entity:

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace AssetManagement.Models
    {
        public class Purchase
        {
            [Key]
            public int PurchaseId { get; set; }
    
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                ApplyFormatInEditMode = true)]
            public DateTime PurchaseDate { get; set; }
    
            public int ProductId { get; set; }
            public Product Product { get; set; }
            public int OfficeId { get; set; }
            public Office Office { get; set; }
        }
    }  

The new entity hass to foreign keys to *Product* and *Office*. The other entities need to be modified accordingly and also the `DbInitializer.cs` class Check the git repsoitory to check the require modifications for th other enities.


<a id="org89ba43f"></a>

# Adding additional data to the details page

We may want to join data from other tables in our pages, here is an example of adding a list of purchased products inside the *Pages/Companies/Details.cshtml.cs*:

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Company = await _context.Companies
            .Include(c => c.Country)
            .Include(pch => pch.Purchases)
            .ThenInclude(pdt => pdt.Product)
            .ThenInclude(ptc => ptc.ProductCategory)
            .FirstOrDefaultAsync(m => m.CompanyId == id);
        if (Company == null)
        {
            return NotFound();
        }
        return Page();
    }  

Below is an example on displaying the added values on the *Pages/Companies/Details.cshtml*:

    <dd class="col-sm-10">
        <table class="table">
            <tr>
                <th>Purchase Date</th>
                <th>Product Category</th>
                <th>Price</th>
            </tr>
            @foreach (var item in Model.Company.Purchases)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => item.PurchaseDate)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => item.Product.ProductCategory.Category)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => item.Product.Price)
                    </td>
                </tr>
            }
        </table>
    </dd>  


<a id="org771b38f"></a>

# Overposting

Microsoft alert about "overposting risk" in case our code contains "secret" values that should not be set by the user, even if hidden. Possibly a coud practice would be to not use hidden value. For reference about overposting, please read [this article](https://aka.ms/RazorPagesCRUD).

Here is an example showing how to protect our page *Pages/Companies/Create.cshtml.cs*:

    /*
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
    
        _context.Companies.Add(Company);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
    */
    public async Task<IActionResult> OnPostAsync()
    {
        var emptyCompany = new Company();
    
        if (await TryUpdateModelAsync<Company>(
            emptyCompany,
            "company",   // Prefix for form value.
            s => s.CompanyName, s => s.CountryId, s => s.Country))
        {
            _context.Companies.Add(emptyCompany);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        return Page();
    }  

Similar operation can be performed on the *Pages/Companies(Edit.cshtml.cs*:

    /*
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
    
        _context.Attach(Company).State = EntityState.Modified;
    
        try
        {
            await _context.SaveChangesAsync();
        }
    
        catch (DbUpdateConcurrencyException)
        {
            if (!CompanyExists(Company.CompanyId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    
        return RedirectToPage("./Index");
    }
    */
    public async Task<IActionResult> OnPostAsync(int id)
    {
        var companyToUpdate = await _context.Companies.FindAsync(id);
    
        if (companyToUpdate == null)
        {
            return NotFound();
        }
    
        if (await TryUpdateModelAsync<Company>(
            companyToUpdate,
            "company",
            s => s.CompanyName, s => s.CountryId, s => s.CountryId))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    
        return Page();
    }


<a id="org9ded6ec"></a>

# Sorting list

Example of sorting function for *Pages/Companies/Index.cshtml.cs*:

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
    
            public string CompanySort { get; set; }
            public string CountrySort { get; set; }
            public string CurrentFilter { get; set; }
            public string CurrentSort { get; set; }
    
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

Displaying the to *cshtml* file:

    @page
    @model AssetManagement.Pages.Companies.IndexModel
    
    @{
        ViewData["Title"] = "Companies";
    }
    
    <h1>Index</h1>
    <h4>Companies</h4>
    
    <p>
        <a asp-page="Create">Create New</a>
    </p>
    <table class="table">
        <thead>
            <tr>
                <th>
                    <a asp-page="./Index" asp-route-sortOrder="@Model.CompanySort">
                        @Html.DisplayNameFor(model => model.Companies[0].CompanyName)
                    </a>
                </th>
                <th>
                    <a asp-page="./Index" asp-route-sortOrder="@Model.CountrySort">
                        @Html.DisplayNameFor(model => model.Companies[0].Country.CountryName)
                    </a>
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
    @foreach (var item in Model.Companies) {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.CompanyName)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Country.CountryName)
                </td>
                <td>
                    <a asp-page="./Edit" asp-route-id="@item.CompanyId">Edit</a> |
                    <a asp-page="./Details" asp-route-id="@item.CompanyId">Details</a> |
                    <a asp-page="./Delete" asp-route-id="@item.CompanyId">Delete</a>
                </td>
            </tr>
    }
        </tbody>
    </table>  


<a id="org91567c4"></a>

# Search functionality

Update the *Pages/index.cshtml.cs* as follows:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using AssetManagement.Data;
    using AssetManagement.Models;
    
    namespace AssetManagement.Pages.Products
    {
        public class IndexModel : PageModel
        {
            private readonly AssetManagement.Data.CompanyContext _context;
    
            public IndexModel(AssetManagement.Data.CompanyContext context)
            {
                _context = context;
            }
    
            public IList<Product> Product { get;set; }
    
            // Adding search functionalities
            [BindProperty(SupportsGet = true)]
            public string SearchString { get; set; }
            public SelectList Category { get; set; }
            [BindProperty(SupportsGet = true)]
            public string ProductBrand { get; set; }
    
            public async Task OnGetAsync()
            {
                Product = await _context.Products
                    .Include(p => p.ProductCategory).ToListAsync();
                // Search functionalities
                var products = from p in _context.Products
                     select p;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    products = products.Where(s => s.Brand.Contains(SearchString));
                }
                Product = await products.ToListAsync();
            }
        }
    }

Update the Razor page *Pages/index.cshtml* as follows:


<a id="org0e00e1e"></a>

# Adding ProductFullName property

We can generate different products of the same brand, the same name, and so on. To help user to identify more easily a product we want to provide the full name of product plus it unique id.

A way to this is by adding the following property to the *Models/Product.cs* file:

    //...
            public string ProductFullName
            {
                get
                {
                    return
                        ProductId + ", " 
                        + Brand + ", "
                        + Name + ", "
                        + Model;
                }
            }
    //...


<a id="org22d747c"></a>

# Adding soem conditional formating

Let's update the *Companies/Details.cshtml* in order to add some sy

    @* ... *@
    @foreach (var item in Model.Company.Purchases)
    {
        TimeSpan ts = DateTime.Now - item.PurchaseDate;
        var interval = (int)ts.TotalDays;
        var style = "";
        if (interval > (3*12*30 - 3*30))
        {
            style = "color:red";
        }
        else if (interval > (3*12*30 - 6*30))
        {
            style = "color:orange";
        }
        <tr>
            <td style="@style">
                @Html.DisplayFor(modelItem => item.PurchaseDate)
            </td>
            <td style="@style">
                @Html.DisplayFor(modelItem => item.Product.ProductCategory.Category)
            </td>
            <td style="@style">
                @Html.DisplayFor(modelItem => item.Product.ProductFullName)
            </td>
            <td style="@style">
                @Html.DisplayFor(modelItem => item.Product.Price)
            </td>
        </tr>
    }
    @* ... *@


<a id="org5068537"></a>

# Web API

Install the Microsoft.AspNet.WebApi.Client package:

    dotnet add package Microsoft.AspNet.WebApi.Client
    dotnet add package Microsoft.EntityFrameworkCore.InMemory
    dotnet add package Swashbuckle.AspNetCore

To be continued&#x2026;


<a id="org99cbd01"></a>

# Going further


<a id="org230f603"></a>

## Fix issues

1.  Uniqueness of property names used in the UI naviagtion
    
    We want to let users to enter entities in the database but we want to avoid duplicated propertie for certain columns other than than the primary keys. The [upcomming version of EF 6 implement this feature on the Data Annotations](https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/data-annotations). Using EF 5, the current version we need to implement this functionality by our own.


<a id="org54b13b7"></a>

## Adding features

1.  Making the code safer by adding overposting protection on every pages

2.  Update the *Pages/Companies/Delete.cshtml.cs* and the *Pages/Companies/Delete.cshtml* pages with `SaveChanges` fails.
    Check [this guide](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/crud?view=aspnetcore-5.0#update-the-delete-page) from MS.

3.  Add API functionalities on Razor pages


<a id="org27d0c0d"></a>

# Errata


<a id="orgaee7c95"></a>

## REMOVED - Consume 3rd party API

First we need to find a third party API service that would feet our application. A candidate might be <https://freecurrencyapi.net/>.

Below is the provided API call that will serve us:

    curl https://freecurrencyapi.net/api/v1/latest | jq .

We can notice that our application will need to accomodate to the available currencies returned by this call.

From this JSON result we can create the fiollowing class:

    public class Rates
    {
        public double CAD { get; set; }
        public double HKD { get; set; }
        public double ISK { get; set; }
        public double PHP { get; set; }
        public double DKK { get; set; }
        public double HUF { get; set; }
        public double CZK { get; set; }
        public double AUD { get; set; }
        public double RON { get; set; }
        public double SEK { get; set; }
        public double IDR { get; set; }
        public double INR { get; set; }
        public double BRL { get; set; }
        public double RUB { get; set; }
        public double HRK { get; set; }
        public double JPY { get; set; }
        public double THB { get; set; }
        public double CHF { get; set; }
        public double SGD { get; set; }
        public double PLN { get; set; }
        public double BGN { get; set; }
        public double TRY { get; set; }
        public double CNY { get; set; }
        public double NOK { get; set; }
        public double NZD { get; set; }
        public double ZAR { get; set; }
        public double USD { get; set; }
        public double MXN { get; set; }
        public double ILS { get; set; }
        public double GBP { get; set; }
        public double KRW { get; set; }
        public double MYR { get; set; }
    }
    public class Example
    {
        public Rates Rates { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
    }

Create the class *Models/Rate.cs*

    touch Models/Rate.cs

Then insert the classes above as follows:

    using Newtonsoft.Json;
    // using System.Text.Json;
    // using System.Text.Json.Serialization;
    namespace AssetManagement.Models
    
       public class Rates
       {
           [JsonProperty("CAD")]
           public double? CAD { get; set; }
           //...
       }
       public class CurrencyRate
       {
           [JsonProperty("rates")]
           public Rates Rates { get; set; }
           [JsonProperty("base")]
           public string Base { get; set; }
           [JsonProperty("date")]
           public string Date { get; set; }
       }

Add the [Polly and](https://github.com/App-vNext/Polly/wiki/Polly-and-HttpClientFactory#using-polly-with-ihttpclientfactory) and the [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) NuGet packages:

    dotnet add package Microsoft.Extensions.Http.Polly
    dotnet add package newtonsoft.json

Add a controller:

    dotnet aspnet-codegenerator controller -name HomeController -async -outDir Controllers

Update the *Controllers/HomeController.cs* file with the code from the git repository.

    //...
    using Polly;
    
    //...
    public void ConfigureServices(IServiceCollection services)
            {
                //...
    
                services.AddControllersWithViews();
    
                services.AddHttpClient("API Client", client => {
                    client.BaseAddress = new Uri("https://freecurrencyapi.net/");
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
    
                .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[] {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10)
                }));
            }
                //...

In this example we configured the controller to use a free currency service from [freecurrencyapi.net](https://freecurrencyapi.net/).

We implemented the code to call the API and turn the response into an instance.

We get an instance of `HttpClient` with the help of `HttpCientFactory`.

`JsonConvert.DeserializeObject<Rates>()` call converts the JSON response string to a C# instance class.

Update your *Startup.cs*:

Now we can display the result into the pages where we want to retrive this information:

