namespace ESISA.WebAPI.Extensions
{
    public static class LayerRegistration
    {
        public static void RegisterWebAPIDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
