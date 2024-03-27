using PostApi.HttpClients;

namespace PostApi.Extensions
{
    public static class AddApplicationHttpClientsExtension
    {

        public static IServiceCollection AddApplicationHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<PostApiClient>((serviceProvider, client) =>
            {
                string postApiUrl = configuration.GetSection("PostApiUrl").Value;

                if (string.IsNullOrEmpty(postApiUrl))
                {
                    throw new ApplicationException("PostApiUrl is not set in settings");
                }

                client.BaseAddress = new Uri(postApiUrl);
            });

            return services;
        }
    }
}
