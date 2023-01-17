using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.IServices;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Services
{
    /// <summary>
    /// thats responsible for messages
    /// </summary>
    public class NotificationService : INotificationService
    {

       
        private readonly ILogger<NotificationService> _logger;
        private readonly INotificationRepository _notiRepo;
       /// <summary>
       /// creates this service
       /// </summary>
       /// <param name="notiRepo"></param>
       /// <param name="logger"></param>

        public NotificationService(INotificationRepository notiRepo, ILogger<NotificationService> logger)
        {
            
            _logger = logger;
            _notiRepo = notiRepo;
         
        }

        /// <summary>
        /// the only task to make new message whit given data
        /// </summary>
        /// <param name="horseID"></param>
        /// <param name="riderID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task MakeNotificationForUserWithRegistration(int? horseID, int? riderID, int userId)
        {

            var naujasPranesimas = new Notification
            {
                
                Topic = "Sukurta nauja Rezervacija",
                Message = $"Sekmingai uzsiregistravote zirga nr. {horseID} su raiteliu {riderID} ",
                Status = false,
                UserId = userId
            };

            await _notiRepo.CreateAsync(naujasPranesimas);




        }




    }
}
