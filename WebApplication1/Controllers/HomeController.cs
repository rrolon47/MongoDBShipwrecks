using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IMongoCollection<Shipwreck> _shipwreckCollection;

        public HomeController(IMongoClient client)
        {
            //create collection 
            
            //points to atlas cluster 
            var database = client.GetDatabase("sample_geospatial");
            //points to what collection we want
            _shipwreckCollection = database.GetCollection<Shipwreck>("shipwrecks"); /*<bsondocument> is any bson data type, but here we specified*/
        }

        public IActionResult Index()
        {
            List<Shipwreck> shipwrecksVisble = _shipwreckCollection.Find(s => s.FeatureType == "Wrecks - Visible").ToList();
            return View(shipwrecksVisble);
        }

    
        //[HttpGet]
        //public IEnumerable<Shipwreck> Get()
        //{ 
        //    //search for data in collection collection.Find(...)
        //    return _shipwreckCollection.Find(s => s.FeatureType == "Wrecks - Visible").ToList();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
