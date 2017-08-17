using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenGameListWebApp.ViewModels;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenGameListWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        /// <summary>
        /// Returns the default number of items to retrieve when using the  parameterless overloads of the API methods retrieving item lists.
        /// </summary>
        private int DefaultNumberOfItems
        {
            get
            {
                return 5;
            }
        }
        /// <summary>
        /// Returns the maximum number of items to retrieve when using the API methods retrieving item lists.
        /// </summary>
        private int MaxNumberOfItems
        {
            get
            {
                return 100;
            }
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return NotFound(new { Error = "not found" });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(GetSampleItems()
                                    .Where(it => it.Id == id)
                                    .FirstOrDefault(), DefaultSeriializeSettings);
        }



        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return GetLatest(DefaultNumberOfItems);
        }

        //Get: api/Items/GetLatest/5
        [HttpGet("GetLatest/{num}")]
        public JsonResult GetLatest(int num)
        {
            if (num > MaxNumberOfItems) num = MaxNumberOfItems;
            var items = GetSampleItems(num).OrderBy(it => it.CreatedDate).Take(num);
            JsonSerializerSettings settings=new JsonSerializerSettings { Formatting= Formatting.Indented };
            return new JsonResult(items, settings);
        }

        [HttpGet("GetRandom")]
        public IActionResult GetRandom()
        {
            return GetRandom(DefaultNumberOfItems);
        }

        [HttpGet("GetRandom/{num}")]
        public IActionResult GetRandom(int num)
        {
            if (num > MaxNumberOfItems) num = MaxNumberOfItems;
            var items = GetSampleItems(num).OrderBy(it => Guid.NewGuid()).Take(num);
            return new JsonResult(items, DefaultSeriializeSettings);

        }

        [HttpGet("GetMostViewed")]
        public IActionResult GetMostViewed()
        {
            return GetMostViewed(DefaultNumberOfItems);
        }
        [HttpGet("GetMostViewed/{num}")]
        public IActionResult GetMostViewed(int num)
        {
            if (num > MaxNumberOfItems) num = MaxNumberOfItems;
            var items = GetSampleItems(num).OrderBy(it => it.ViewCount);
            return new JsonResult(items, DefaultSeriializeSettings);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<ItemViewModel> GetSampleItems(int num=999)
        {

            List<ItemViewModel> lista = new List<ItemViewModel>();
            DateTime fecha = DateTime.Now.AddDays(-num );
            for (var c = 0; c <= num; c++)
            {
                ItemViewModel item = new ItemViewModel();
                item.Id = c;
                item.Title = string.Format("Item {0} title ", c);
                item.Description = string.Format("Item {0} Description", c);
                item.CreatedDate = fecha.AddDays(c);
                item.ViewCount = num - c;
                lista.Add(item);

            }

            return lista;

        }

        private JsonSerializerSettings DefaultSeriializeSettings
        {
            get{
                return new JsonSerializerSettings(){  Formatting= Formatting.Indented};
            }
        }




    }
}
