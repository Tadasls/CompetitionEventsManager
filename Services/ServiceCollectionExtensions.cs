using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Repository;
using Microsoft.AspNetCore.JsonPatch.Internal;
using CompetitionEventsManager.Services.Adapters;
using CompetitionEventsManager.Services.Adapters.IAdapters;
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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRiderRepository, RiderRepository>();
            services.AddScoped<IHorseRepository, HorseRepository>();
            services.AddScoped<ICompetitionRepository, CompetitionRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            services.AddTransient<IHorseAdapter, HorseAdapter>();
            services.AddTransient<IRiderAdapter, RiderAdapter>();
            services.AddTransient<IEntryAdapter, EntryAdapter>();

            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}

