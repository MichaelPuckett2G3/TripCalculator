using Specky.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripCalculator.Dal;
using TripCalculator.Models;

namespace TripCalculator.ViewModels
{
    [Speck]
    public class TripViewModel
    {
        private readonly ITripDb tripDb;
        private readonly IList<Trip> trips;

        public TripViewModel(ITripDb tripDb)
        {
            this.tripDb = tripDb;
            trips = tripDb.Trips.ToList();
        }


    }
}
