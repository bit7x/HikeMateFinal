using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using HikemateMobileService.DataObjects;
using HikemateMobileService.Models;

namespace HikemateMobileService.Controllers
{
    public class LocationsController : TableController<Locations>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Locations>(context, Request, Services);
        }

        // GET tables/Locations
        public IQueryable<Locations> GetAllLocations()
        {
            return Query(); 
        }

        // GET tables/Locations/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Locations> GetLocations(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Locations/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Locations> PatchLocations(string id, Delta<Locations> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Locations
        public async Task<IHttpActionResult> PostLocations(Locations item)
        {
            Services.Log.Info("Hitted ");
            Locations current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Locations/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteLocations(string id)
        {
             return DeleteAsync(id);
        }

    }
}