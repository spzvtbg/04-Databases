namespace ProductShop.App
{
    using ProductShop.App.Commands;
    using ProductShop.Data;

    class Startup
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            using (ProductShopDbContext context = new ProductShopDbContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                engine.RunJsonTasks();
            }

            //using (ProductShopDbContext context = new ProductShopDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();
            //    engine.RunXmlTasks();
            //}
        }
    }
}
