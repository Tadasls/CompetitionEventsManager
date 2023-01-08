﻿using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class HorseRepository : Repository<Horse>, IHorseRepository
    {

        private readonly DBContext _db;

        public HorseRepository(DBContext db) : base(db)
        {
            _db = db;
        }






    }
}
