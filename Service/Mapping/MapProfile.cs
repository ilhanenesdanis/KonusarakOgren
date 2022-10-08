using AutoMapper;
using Core.Entity;
using DTO;

namespace Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<BrandDto, Brand>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductFeatures, ProductFeaturesDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Brand, AddBrandDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
        }
    }
}
