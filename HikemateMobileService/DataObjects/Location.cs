using Microsoft.WindowsAzure.Mobile.Service;

namespace HikemateMobileService.DataObjects
{
    public class Location : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

        public double longitiude { get; set; }
        public double latitude { get; set; }
        public double currLongitiude { get; set; }
        public double currLattitude { get; set; }

    }
}
