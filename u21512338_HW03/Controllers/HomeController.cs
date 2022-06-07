using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21512338_HW03.Models;

namespace u21512338_HW03.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult About()
        {
            return View();
        }

        // GET: FileUpload
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, FileModel model)
        {
            // Verify that the user selected a file
            // Not null and has a length
            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename
                var fileName = Path.GetFileName(files.FileName);
                //extract radio button type
                var selectedType = model.Type;

                if (selectedType == "Document") //document radio button
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Documents/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                else if (selectedType == "Image") //image radio button
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
                else if (selectedType == "Video") //video radio button
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Videos/"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
            }

            // redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
    }
}