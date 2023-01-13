using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Repository;
using Microsoft.AspNetCore.JsonPatch.Internal;
using CompetitionEventsManager.Services.Adapters;
using CompetitionEventsManager.Services.IServices;

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
            services.AddTransient<IStaffRepository, StaffRepository>();

            services.AddTransient<IHorseAdapter, HorseAdapter>();
            services.AddTransient<IRiderAdapter, RiderAdapter>();

            return services;
        }
    }
}

