using System;

namespace ResourceAuthExample
{
    public static class ServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider provider)
            where TService : class
        {
            if (provider.GetService(typeof(TService)) is TService service)
            {
                return service;
            }

            throw new ArgumentException(
                $"Type: {typeof(TService).Name} could not be resolved from the ServiceProvider.");
        }
    }
}
