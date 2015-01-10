using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeMate.Models
{
    class Location
    {
        private Double longitiude;
        private Double latitude;
        private Double currLongitiude;
        private Double currLattitude;

        public Double Longitiude
        {
            get { return longitiude; }
            set { longitiude = value; }
        }

        public Double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }


        public Double CurrLattitude
        {
            get { return currLattitude; }
            set { currLattitude = value; }
        }


        public Double CurrLongitiude
        {
            get { return currLongitiude; }
            set { currLongitiude = value; }
        }
    }
}
