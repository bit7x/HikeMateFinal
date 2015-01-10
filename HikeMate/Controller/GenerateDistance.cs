using HikeMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeMate.Controller
{
    class GenerateDistance
    {
        Location location;
        DistanceCalc calc = new DistanceCalc();

        public GenerateDistance(Location location)
        {
            this.location = location;
        }

        public Double CalculateDistanceTravelled()
        {

            Double ditanceTravelled = 0;
            ditanceTravelled = calc.distance(location.Latitude, location.Longitiude, location.CurrLattitude, location.CurrLongitiude, 'K');
            return ditanceTravelled;
        }
    }
}
