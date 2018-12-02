namespace ProductShop.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Newtonsoft.Json;

    using ProductShop.Models;
    using ProductShop.Resources;
    using ProductShop.Services;
    using ProductShop.Services.Contracts;
    using ProductShop.Dtos;

    internal static class JsonProvider
    {
        internal static Random random = new Random();

        internal static IService jsonService = ServiseBuilder.GetProvider<JsonService>();

        internal static void ImportUsers()
        {
            UserDto[] users = JsonConvert.DeserializeObject<UserDto[]>(FormatProvider.UsersJson);
            jsonService.AddUsersRange(users);
        }

        internal static void ImportProducts()
        {
            ProductDto[] products = JsonConvert.DeserializeObject<ProductDto[]>(FormatProvider.ProductsJson);
            int[] userIDs = jsonService.GetUsersIds();
            int countProducts = 1;

            foreach (var product in products)
            {
                int index = random.Next(0, userIDs.Length);
                int sellerID = userIDs[index];
                product.ProductSellerId = sellerID;

                index = random.Next(0, userIDs.Length);
                int buyerID = userIDs[index];

                if (sellerID != buyerID || countProducts % 5 != 0)
                {
                    product.ProductBuyerId = buyerID;
                }
                countProducts++;
            }
            jsonService.AddProductsRange(products);
        }

        internal static void ImportCategories()
        {
            CategoryDto[] categories = JsonConvert.DeserializeObject<CategoryDto[]>(FormatProvider.CategoriesJson);
            jsonService.AddCategoriesRange(categories);
        }

        internal static void ImportCategoriesProducts()
        {
            int[] products = jsonService.GetProductsIds();
            int[] categories = jsonService.GetCategoriesIds();
            List<CategoryProduct> categoriesProducts = new List<CategoryProduct>();

            for (int index = 0; index < products.Length; index++)
            {
                HashSet<int> categoryIndexes = new HashSet<int>();
                for (int count = 0; count < 3; count++)
                {
                    categoryIndexes.Add(random.Next(0, categories.Length));
                }

                foreach (var integer in categoryIndexes)
                {
                    int productID = products[index];
                    int categoryID = categories[integer];
                    categoriesProducts.Add(new CategoryProduct(categoryID, productID));
                }
            }
            jsonService.AddCategoriesProductsRange(categoriesProducts);
        }

        internal static void ExportProductsInPriceRange()
        {
            ProductsInSpecifedPriceDto[] products = jsonService.GetProductsInPriceRange();
            String jsonString = JsonConvert
                .SerializeObject(products, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        FloatFormatHandling = FloatFormatHandling.DefaultValue
                    });

            String filePath = @"..\ProductShop.Resources\JsonExport\ProductsInPriceRange.json";
            File.WriteAllText(filePath, jsonString);
        }

        internal static void ExportSuccessfullySelledProducts()
        {
            SuccessfullySelledProductDto[] products = jsonService.GetSuccessfullySelledProducts();

            String jsonString = JsonConvert
                .SerializeObject(products, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        FloatFormatHandling = FloatFormatHandling.DefaultValue
                    });

            String filePath = @"..\ProductShop.Resources\JsonExport\SuccessfullySelledProducts.json";
            File.WriteAllText(filePath, jsonString);
        }

        internal static void ExportCategoriesByProducts()
        {
            CategoriesByProductDto[] categoriesByProducts = jsonService.GetCategoriesByProducts();

            String jsonString = JsonConvert
                .SerializeObject(categoriesByProducts, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        FloatFormatHandling = FloatFormatHandling.DefaultValue
                    });

            String filePath = @"..\ProductShop.Resources\JsonExport\CategoriesByProducts.json";
            File.WriteAllText(filePath, jsonString);
        }

        internal static void ExportUsersSoldProducts()
        {
            UsersProductsDto userProducts = jsonService.GetUsersSoldProducts();

            String jsonString = JsonConvert
                .SerializeObject(userProducts, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        FloatFormatHandling = FloatFormatHandling.DefaultValue
                    });

            String filePath = @"..\ProductShop.Resources\JsonExport\user-and-products.json";
            File.WriteAllText(filePath, jsonString);
        }
    }
}
