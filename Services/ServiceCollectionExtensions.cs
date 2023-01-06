using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Repository;

namespace CompetitionEventsManager.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMokymaiServices(this IServiceCollection services)
        {

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}

