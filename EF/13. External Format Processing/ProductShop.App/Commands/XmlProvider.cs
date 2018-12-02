namespace ProductShop.App.Commands
{
    using ProductShop.Dtos;
    using ProductShop.Services;
    using ProductShop.Services.Contracts;
    using System;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    internal static class XmlProvider
    {
        private static IService xmlService = ServiseBuilder.GetProvider<JsonService>();

        public static void ExportProductsInRange()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsInSpecifedPriceDto), 
                new XmlRootAttribute("products"));

            var collection = xmlService.GetProductsInPriceRange();

            foreach (var item in collection)
            {
                var name = item.name;
                var price = item.price;
                var seller = item.seller;

                XElement xElement = new XElement("product",
                   new XAttribute("name", item.name),
                   new XAttribute("price", item.price),
                   new XAttribute("seller", item.seller)
                    );

                xDocument.Element("products").Add(xElement);
            }

            String filePath = @"..\ProductShop.Resources\XmlExport\products-in-range.xml";
            File.WriteAllText(filePath, xDocument.ToString());
        }
    }

    //public static void DeserializeXml()
    //{
    //    String xmlContent = ReadFile(@"Xml\users.xml");
    //    XDocument xmlDoc = XDocument.Parse(xmlContent);
    //    IEnumerable<XElement> elements = xmlDoc.Root.Elements();

    //    foreach (XElement element in elements)
    //    {
    //        IEnumerable<XAttribute> attributes = element.Attributes();
    //        foreach (var attribute in attributes)
    //        {
    //            Console.WriteLine($"{attribute.Name} - {attribute.Value}");
    //        }
    //        Console.WriteLine();
    //    }
    //}

    //public static void SerializeXml()
    //{
    //    using (ProductShopDbContext context = new ProductShopDbContext())
    //    {
    //        var xmlDoc = new XDocument();
    //        xmlDoc.Add(new XElement("users"));

    //        foreach (var user in context.Users)
    //        {
    //            var name = new XElement("name", $"{user.FirstName} {user.LastName}");
    //            var age = new XElement("age", user.Age == null? 0 : user.Age);

    //            xmlDoc.Element("users").Add(new XElement("user", name, age));
    //        }
    //        Console.WriteLine(xmlDoc.ToString());
    //        File.WriteAllText("UsersExport.xml", xmlDoc.ToString());
    //    }
    //}
}
