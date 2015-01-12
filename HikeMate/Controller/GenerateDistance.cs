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
        Locations location;
        DistanceCalc calc = new DistanceCalc();

        public GenerateDistance(Locations location)
        {
            this.location = location;
        }

        public Double CalculateDistanceTravelled()
        {

            Double ditanceTravelled = 0;
            ditanceTravelled = calc.distance(location.latitude, location.longitiude, location.currLattitude, location.currLongitiude, 'K');
            return ditanceTravelled;
        }
    }
}
