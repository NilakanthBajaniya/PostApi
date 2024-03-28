namespace PostApi.Extensions
{
    public static class UseApplicationCorsExtension
    {
        public static WebApplication UseApplicationCors(this WebApplication application)
        {
            string[]? frontEndUrls = application
                .Configuration
                .GetSection("FrontEndUrls")
                .Get<string[]>();

            if (frontEndUrls is null)
            {
                return application;
            }

            application.UseCors(builder =>
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins(frontEndUrls)
            );

            return application;
        }
    }
}
