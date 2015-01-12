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
        private MobileServiceCollection<Locations,Locations> LocationItems;
        private IMobileServiceTable<Locations> LocationTable = App.hikemateClient.GetTable<Locations>();

        public async void InsertLocationItem(Locations locationData)
        {
            try
            {
               
                await LocationTable.InsertAsync(locationData);
                LocationItems.Add(locationData);
            }
            catch (InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (NullReferenceException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
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
