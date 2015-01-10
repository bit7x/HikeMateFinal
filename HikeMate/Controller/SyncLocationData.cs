using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using HikeMate.Models;

namespace HikeMate.Controller
{
    class SyncLocationData
    {
        private MobileServiceCollection<Location, Location> LocationItems;
        private IMobileServiceTable<Location> LocationTable = App.MobileService.GetTable<Location>();

        public async void InsertLocationItem(Location locationData)
        {
            await LocationTable.InsertAsync(locationData);
            LocationItems.Add(locationData);
        }

        public async void checkInserted(System.ComponentModel.AsyncCompletedEventArgs actionComplete)
        {
            LocationItems = await LocationTable.ToCollectionAsync();
            if (LocationItems != null)
            {
                
            }
        }

    }
}
