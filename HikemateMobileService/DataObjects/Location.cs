using Microsoft.WindowsAzure.Mobile.Service;

namespace HikemateMobileService.DataObjects
{
    public class Location : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

        private double longitiude { get; set; }
        private double latitude { get; set; }
        private double currLongitiude { get; set; }
        private double currLattitude { get; set; }
    }
}
