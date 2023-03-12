namespace ESISA.WebAPI.Extensions
{
    public static class CORSPolicyExtension
    {
        public static void RegisterCORSPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:7256", "http://localhost:7256")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
    }
}
