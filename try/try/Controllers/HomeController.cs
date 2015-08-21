using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _try.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            foreach (var file in fileUpload)
            {
                if (file == null) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "UploadedFiles/";
                string filename = System.IO.Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("~/Files/" + filename));
            }

            return RedirectToAction("Finish");
        }

        public ActionResult Finish()
        {
            return View();
        }

    }
}
