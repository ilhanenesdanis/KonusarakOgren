using Core.IRepository;
using Core.IService;
using Core.IUnitOfWork;
using Data;
using Data.Repository;
using Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Service.Mapping;
using Service.Service;
using System.Reflection;

namespace Service.Dependencies
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Core 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<Context>(x =>
                x.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name);
                })
            );
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddAutoMapper(typeof(MapProfile));
            //Repository Katmanı
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductFeaturesRepository, ProductFeaturesRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            //Service Katmanı
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductFeaturesService, ProductFeaturesService>();
            services.AddScoped<IRoleService, RoleService>();
            
        }
    }
}
