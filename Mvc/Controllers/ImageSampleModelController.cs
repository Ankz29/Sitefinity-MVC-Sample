using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitefinityWebApp.Mvc.Models;
using System.Web.Http;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name="ImageUpload",Title="ImageUpload",SectionName="MVCWidget")]
    public class ImageSampleModelController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Index(HttpPostedFileBase Image)
        {
            List<ImageSampleModel> model = new List<ImageSampleModel>();
            foreach (var item in model)
            {
                int ID = item.ID;
                string Title = item.Title;
                string Description = item.Description;

                if (Image != null)
                {
                    string pic = System.IO.Path.GetFileName(Image.FileName);
                    // string path = System.IO.Path.Combine(
                    /// Server.MapPath("~/imageC:\Program Files (x86)\Progress\Sitefinity\Projects\Default2\ResourcePackages\Bootstrap\assets\dist\images\Ankz_Images\s/profile"), pic);
                    // file is uploaded
                    string path = System.IO.Path.Combine(
                                         Server.MapPath("~/images/Ankz_Images"), pic);
                    // file is uploaded
                    Image.SaveAs(path);

                    model.Add(new ImageSampleModel
                    {
                        ID = item.ID,
                        Title = item.Title,
                        Description = item.Description,
                        Image = item.Image
                    });
                }
            }
            return View("Index", model);
        }
    }
}