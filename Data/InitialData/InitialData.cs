using CompetitionEventsManager.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;

namespace CompetitionEventsManager.Data.InitialData
{
    public static class InitialData
    {
        public static readonly Rider[] DataSeedRider = new Rider[] {
            new Rider
            {
                Id = 1,
                FirstName = "Tadas",
                LastName = "Laurinaitis",
            },
             new Rider
            {
                Id = 1,
                FirstName = "Titas",
                LastName = "Laurinaitis",
            },



















    };
    }
}