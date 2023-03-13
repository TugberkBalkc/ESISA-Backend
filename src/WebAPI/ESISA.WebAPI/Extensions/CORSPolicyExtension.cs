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
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
    }
}
