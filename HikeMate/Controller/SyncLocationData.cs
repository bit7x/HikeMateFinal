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
        private MobileServiceCollection<LocationModel, LocationModel> LocationItems;
        private IMobileServiceTable<LocationModel> LocationTable = App.hikemateClient.GetTable<LocationModel>();

        public async void InsertLocationItem(LocationModel locationData)
        {
            try
            {
                await LocationTable.InsertAsync(locationData);
                LocationItems.Add(locationData);
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
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
