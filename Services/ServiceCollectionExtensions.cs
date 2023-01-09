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
            services.AddTransient<IRiderRepository, RiderRepository>();
            services.AddTransient<IHorseRepository, HorseRepository>();
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();
            services.AddTransient<IEntryRepository, EntryRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IPerformanceRepository, PerformanceRepository>();
            services.AddTransient<IStaffRepository, StaffRepository>();
          

            return services;
        }
    }
}

