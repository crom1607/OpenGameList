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
        //Get: api/Items/GetLatest/5
        [HttpGet("GetLatest/{num}")]
        public JsonResult GetLatest(int num)
        {

            List<ItemViewModel> lista = new List<ItemViewModel>();

            for (var c=0; c<=num; c++)
            {
                ItemViewModel item = new ItemViewModel();
                item.Id = c;
                item.Title = string.Format("Item {0} title ", c);
                item.Description= string.Format("Item {0} Description", c);
                lista.Add(item);
            }


            JsonSerializerSettings settings=new JsonSerializerSettings { Formatting= Formatting.Indented };
            return new JsonResult(lista,settings);

        }

        
            

    }
}
