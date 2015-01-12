using Microsoft.WindowsAzure.Mobile.Service;

namespace HikemateMobileService.DataObjects
{
    public class Locations : EntityData
    {
       
        public double longitiude { get; set; }
        public double latitude { get; set; }
        public double currLongitiude { get; set; }
        public double currLattitude { get; set; }
    }
}