namespace ProductShop.Resources
{
    using System.IO;
    using System.Reflection;

    public static class FormatProvider
    {
        public static string CategoriesJson
        {
            get
            {
                return ReadFile(@"Json\categories.json");
            }
        }

        public static string ProductsJson
        {
            get
            {
                return ReadFile(@"Json\products.json");
            }
        }

        public static string UsersJson
        {
            get
            {
                return ReadFile(@"Json\users.json");
            }
        }

        public static string CategoriesXml
        {
            get
            {
                return ReadFile(@"Xml\categories.json");
            }
        }

        public static string ProductsXml
        {
            get
            {
                return ReadFile(@"Xml\products.json");
            }
        }

        public static string UsersXml
        {
            get
            {
                return ReadFile(@"Xml\users.json");
            }
        }

        private static string ReadFile(string fileName)
        {
            string executingAssembliLocation = Assembly.GetExecutingAssembly().Location;
            string directoryName = Path.GetDirectoryName(executingAssembliLocation);
            return File.ReadAllText($@"{directoryName}\{fileName}");
        }
    }
}
