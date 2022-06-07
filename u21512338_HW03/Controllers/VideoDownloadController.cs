using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21512338_HW03.Models;

namespace u21512338_HW03.Controllers
{
    public class VideoDownloadController : Controller
    {
        // GET: VideoDownload
        public ActionResult Index()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> videos = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                videos.Add(new FileModel { FileName = Path.GetFileName(filePath), Vid = "~/Media/Videos/" + Path.GetFileName(filePath) });
            }
            return View(videos);
        }

        public FileResult DownloadFile(string fileName) 
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Videos/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            string path = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}