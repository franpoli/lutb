# Asset Management Tool Demo

A Console App exercise using [Entity Framework by Microsoft](https://docs.microsoft.com/en-us/aspnet/entity-framework).

## How to run this demo

In order to run this program successfully you must have:

1. Informed your connection string in the file `AssetDbContext.cs` with a catalog name of your choice.
   ![Connection string](img/connectionstring-AssetMangementToolDemo-Microsoft_Visual_Studio.png)
2. You must have run the command `Add-Migration Init` successfully from the Package Manager Console.
   ![Add-Migration](img/Add-Migration_Init-AssetManagementToolDemo-Microsoft_Visual_Studio.png)
3. You must have run the command `Update-Database` from the Package Manager Console.
   ![Update-Database](img/Update-Database_AssetManagementToolDemo-Microsoft_Visual_Studio.png)
4. In Visual Studio, press F5 to execute the program.
   ![AssetManagementDemo](img/ConsoleApp-AssetManagementToolDemo-EntityFramework.png)