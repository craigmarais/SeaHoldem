using Microsoft.Extensions.DependencyInjection;
using SeaHoldemLogic;
using SeaHoldemLogic.Abstraction;

namespace SeaHoldemExtensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>Installs the holdem game.</summary>
        /// <param name="services">ASP's dependency injection services collection</param>
        /// <param name="options">the configuration for the holdem game</param>
        public static IServiceCollection AddHoldemGame(this IServiceCollection services, Action<HoldemOptions> options)
        {
            var holdemOptions = new HoldemOptions();
            options(holdemOptions);

            var game = new Game(holdemOptions.Logger);
            services.AddSingleton(game);
            services.AddSingleton(holdemOptions.Logger);

            return services;
        }
    }
}
