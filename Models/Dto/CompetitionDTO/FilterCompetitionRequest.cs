using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.CompetitionDTO
{
    public class FilterCompetitionRequest
    {


        /// <summary>
        /// paieska pagal Artikula 
        /// </summary>
        [MaxLength(100)]
        public string? Article { get; set; }
        /// <summary>
        /// paieska pagal Klase  
        /// </summary>
        [MaxLength(100)]
        public string? Class { get; set; }
     
  



    }
}