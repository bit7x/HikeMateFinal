using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Web.Http;
using HikemateMobileService.DataObjects;
using HikemateMobileService.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace HikemateMobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            Database.SetInitializer(new MobileServiceInitializer());
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {

            List<Location> todoItems = new List<Location>
            {
              
                new Location { Id = Guid.NewGuid().ToString(), longitiude = 0, latitude = 0, currLattitude = 0, currLongitiude = 0}
            };

            foreach (Location todoItem in todoItems)
            {
                context.Set<Location>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

