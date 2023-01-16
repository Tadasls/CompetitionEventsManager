using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.IServices;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Services
{
    public class NotificationService : INotificationService
    {

       
        private readonly ILogger<NotificationService> _logger;
        private readonly INotificationRepository _notiRepo;
       

        public NotificationService(DBContext db, INotificationRepository notiRepo, ILogger<NotificationService> logger)
        {
            
            _logger = logger;
            _notiRepo = notiRepo;
         
        }


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
