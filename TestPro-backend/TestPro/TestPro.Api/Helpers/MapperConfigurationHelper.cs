using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace TestPro.Api.Helpers
{
    public static class MapperConfigurationHelper
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
