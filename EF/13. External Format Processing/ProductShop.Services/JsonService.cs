namespace ProductShop.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.Services.Contracts;
    using ProductShop.Dtos;
    using AutoMapper;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class JsonService : IService
    {
        private readonly ProductShopDbContext Context;

        public JsonService(ProductShopDbContext context)
        {
            this.Context = context;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public int[] GetUsersIds()
        {
            return this.Context.Users.Select(x => x.UserId).ToArray();
        }

        public int[] GetProductsIds()
        {
            return this.Context.Products.Select(x => x.ProductId).ToArray();
        }

        public int[] GetCategoriesIds()
        {
            return this.Context.Categories.Select(x => x.CategoryId).ToArray();
        }

        public void AddUsersRange(UserDto[] users)
        {
            User[] mappedUsers = Mapper.Map<User[]>(users);
            this.Context.Users.AddRange(mappedUsers);
            this.Context.SaveChanges();
        }

        public void AddProductsRange(ProductDto[] products)
        {
            Product[] mappedProducts = Mapper.Map<Product[]>(products);
            this.Context.Products.AddRange(mappedProducts);
            this.Context.SaveChanges();
        }

        public void AddCategoriesRange(CategoryDto[] categories)
        {
            Category[] mappedCategories = Mapper.Map<Category[]>(categories);
            this.Context.Categories.AddRange(mappedCategories);
            this.Context.SaveChanges();
        }

        public void AddCategoriesProductsRange(List<CategoryProduct> categoriesProducts)
        {
            this.Context.CategoriesProducts.AddRange(categoriesProducts);
            this.Context.SaveChanges();
        }

        public Product[] GetProducts()
        {
            return this.Context.Products.ToArray();
        }

        public Category[] GetCategories()
        {
            return this.Context.Categories.ToArray();
        }

        public ProductsInSpecifedPriceDto[] GetProductsInPriceRange()
        {
            return this.Context.Products
                .Where(p => p.ProductPrice >= 500 && p.ProductPrice <= 1000)
                .Select(x => new ProductsInSpecifedPriceDto()
                {
                    name = x.ProductName,
                    price = x.ProductPrice,
                    seller = $"{x.ProductSeller.FirstName} " + x.ProductSeller.LastName
                })
                .OrderBy(p => p.price)
                .ToArray();
        }

        public SuccessfullySelledProductDto[] GetSuccessfullySelledProducts()
        {
            var collection = this.Context.Users
                .Include(p => p.ProductsSelled)
                .Where(u => u.ProductsBuyed.Count != 0).ToArray();

            var result = Mapper.Map<SuccessfullySelledProductDto[]>(collection);

            return result;
        }

        public CategoriesByProductDto[] GetCategoriesByProducts()
        {
            var collection = this.Context.Categories
                .Include(p => p.Products)
                .OrderBy(x => x.CategoryName)
                .Select(x => new CategoriesByProductDto()
                {
                    category = x.CategoryName,
                    productsCount = x.Products.Count,
                    averagePrice = Math.Round(x.Products.Select(p => p.Product.ProductPrice).Average(), 6),
                    totalRevenue = x.Products.Select(p => p.Product.ProductPrice).Sum()
                }).ToArray();

            return collection;
        }

        public UsersProductsDto GetUsersSoldProducts()
        {
            var collection = new UsersProductsDto()
            {
                usersCount = this.Context.Users
                .Include(p => p.ProductsSelled)
                .Where(x => x.ProductsSelled.Count > 0).Count(),
                users = this.Context.Users.Where(x => x.ProductsSelled.Count > 0)
                .Select(u => new UserDto()
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = u.ProductsSelled
                        .Select(p => new SoldProductsDtoByNameAndPrice()
                        {
                            count = u.ProductsSelled.Count,
                            products = u.ProductsSelled
                                .Select(x => new ProductDto()
                                {
                                    name = x.ProductName,
                                    price = x.ProductPrice
                                }).ToArray(),
                        }).ToArray(),
                })
                .OrderByDescending(x => x.soldProducts.Count)
                .ThenBy(x => x.lastName)
                .ToArray(),
            };

            return collection;
        }
    }
}
