using System;

namespace asset
{
    class Program
    {
        static void Main()
        {
            Pause("You are about to launch the asset management tool demo\n\nPress any key to continue...\n");

            Pause(
                "In order to run this program successfully you must have:\n\n" +
                "1) Informed your connection string in the file AssetDbContext.cs with a catalog name of your choice.\n" +
                "2) You must have run the command \"Add-Migration Init\" successfully from the Package Manager Console.\n" +
                "3) You must have run the command \"Update-Database\" from the Package Manager Console.\n\n" +
                "Press any key to continue...\n");

            // Create
            Crud.FillOfficeTable();
            Crud.FillProductTable();
            
            // Read
            Crud.ReadTables();

            Pause("\nLenovo welcomes our partnership by giving us a 20 percent discount on all its equipment.\n" +
                "Press any key to update the price list...\n\n");

            // Update
            Crud.TwentyPercentSalesOnLenovoLaptops();
            Crud.ReadTables();

            Pause("\nApple is ending support for non profitable devices.\n" +
                "Mobile phones less than 999 USD can no longer be purchased.\n" +
                "Press any key to remove unsuported devices from the database...\n\n");

            // Delete
            Crud.DeleteNonProfitableApplePhones();
            Crud.ReadTables();
        }

        public static void Pause(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }
    }
}
