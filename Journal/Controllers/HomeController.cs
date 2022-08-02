using Microsoft.AspNetCore.Mvc;
using Journal.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;

namespace Journal.Controllers {
   public class HomeController : Controller {
      public IActionResult Index() {

         return View();
      }

      [HttpGet("/om-oss")]
       
      public IActionResult About() {
         var JsonStr = System.IO.File.ReadAllText("journal.json");
         var JsonObj = JsonConvert.DeserializeObject<List<JournalModel>>(JsonStr);
         return View(JsonObj);
      }
      
      [HttpGet("/dagbok")]      
      public IActionResult Journal() {
          // Read
         var JsonStr = System.IO.File.ReadAllText("journal.json");
         var JsonObj = JsonConvert.DeserializeObject<List<JournalModel>>(JsonStr);
         string ConfirmMessage = HttpContext.Session.GetString("PostConfirm");
         ViewBag.text = ConfirmMessage;
         
         return View(JsonObj);
      }

      public IActionResult Create() {
         return View();
      }

      [HttpPost]      
      public IActionResult Create(JournalModel model) {

         // Post
         if(ModelState.IsValid) {
            var JsonStr = System.IO.File.ReadAllText("journal.json");
            var JsonObj = JsonConvert.DeserializeObject<List<JournalModel>>(JsonStr);

            if (JsonObj != null) {
               JsonObj.Add(model);
            }
            System.IO.File.WriteAllText("journal.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));
            ModelState.Clear();
            Response.Redirect("/dagbok");
            string confirm = "Ditt inlägg lades till!";
            HttpContext.Session.SetString("PostConfirm", confirm);
         }
         return View();
      }

   }
}