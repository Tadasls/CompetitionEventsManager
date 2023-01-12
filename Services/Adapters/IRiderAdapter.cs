﻿using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.RiderDTO;

namespace CompetitionEventsManager.Services.Adapters
{
    public interface IRiderAdapter
    {
        UpdateRiderDTO Bind(Rider rider);
        Rider Bind(UpdateRiderDTO updateRiderDTO, int id);
    }
}