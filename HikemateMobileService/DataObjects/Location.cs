using Microsoft.WindowsAzure.Mobile.Service;

namespace HikemateMobileService.DataObjects
{
    public class Location : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}