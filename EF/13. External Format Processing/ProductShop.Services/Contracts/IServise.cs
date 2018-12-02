namespace ProductShop.Services.Contracts
{
    using System.Collections.Generic;

    using ProductShop.Models;
    using ProductShop.Dtos;

    public interface IService
    {
        int[] GetUsersIds();

        int[] GetProductsIds();

        int[] GetCategoriesIds();

        void SaveChanges();

        void AddUsersRange(UserDto[] users);

        void AddProductsRange(ProductDto[] products);

        void AddCategoriesRange(CategoryDto[] categories);

        void AddCategoriesProductsRange(List<CategoryProduct> categoriesProducts);

        Product[] GetProducts();

        Category[] GetCategories();

        ProductsInSpecifedPriceDto[] GetProductsInPriceRange();

        SuccessfullySelledProductDto[] GetSuccessfullySelledProducts();

        CategoriesByProductDto[] GetCategoriesByProducts();

        UsersProductsDto GetUsersSoldProducts();
    }
}
