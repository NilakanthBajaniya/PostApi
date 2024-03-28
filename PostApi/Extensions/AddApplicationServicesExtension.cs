using PostApi.DataAccess.Interfaces;
using PostApi.HttpClients;
using PostApi.Services;
using PostApi.Services.Interfaces;

namespace PostApi.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostApiClient, PostApiClient>();
            services.AddScoped<IPostService, PostService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
