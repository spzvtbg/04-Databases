namespace ProductShop.App
{
    using System;

    using ProductShop.App.Commands;

    internal class Engine
    {
        internal ConsoleColor color = Console.ForegroundColor;

        internal void RunJsonTasks()
        {
            try
            {
                ////Import data into the database.
                //JsonProvider.ImportUsers();
                //JsonProvider.ImportProducts();
                //JsonProvider.ImportCategories();
                //JsonProvider.ImportCategoriesProducts();

                ////Export data from the database into Json.
                //JsonProvider.ExportProductsInPriceRange();
                //JsonProvider.ExportSuccessfullySelledProducts();
                //JsonProvider.ExportCategoriesByProducts();
                //JsonProvider.ExportUsersSoldProducts();

                ////Export data from the database into Xml.
                XmlProvider.ExportProductsInRange();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = this.color;
            }
        }
    }
}
