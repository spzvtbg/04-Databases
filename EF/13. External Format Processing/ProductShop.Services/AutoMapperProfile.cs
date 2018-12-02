namespace ProductShop.Services
{
    using AutoMapper;

    using ProductShop.Dtos;
    using ProductShop.Models;

    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.name));

            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(x => x.name))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(x => x.price));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(x => x.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(x => x.lastName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(x => x.age));

            CreateMap<Product, SoldProductsDto>()
                    .ForMember(d => d.name, o => o.MapFrom(s => s.ProductName))
                    .ForMember(d => d.price, o => o.MapFrom(s => s.ProductPrice))
                    .ForMember(d => d.buyerFirstName, o => o.MapFrom(s => s.ProductBuyer.FirstName))
                    .ForMember(d => d.buyerLastName, o => o.MapFrom(s => s.ProductBuyer.LastName));

            CreateMap<User, SuccessfullySelledProductDto>()
                .ForMember(dest => dest.firstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.lastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dest => dest.soldProducts, opt => opt.MapFrom(x => x.ProductsSelled));
        }
    }
}
