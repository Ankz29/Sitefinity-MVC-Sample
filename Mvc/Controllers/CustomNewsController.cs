using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.News;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.RelatedData;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name="News Feed",Title="News Feed",SectionName="CustomWidget")]
    public class CustomNewsController : Controller
    {
        // GET: CustomNews
        public ActionResult Index()
        {
            NewsManager newsManager = NewsManager.GetManager();
            var news = newsManager.GetNewsItems().Where(m => m.Title == "News Feed");
            var newsItems= newsManager.GetNewsItems().Where(n => n.Status == ContentLifecycleStatus.Live).ToList();

            List<CustomNews> model = new List<Models.CustomNews>();

            foreach(var item in newsItems)
            {
                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();
                var Image1 = "";
                if(image!=null)
                {
                    Image1 = image.MediaUrl.ToString();
                }
                else
                {
                    Image1 = "";
                }

                var Title = item.Title;
                var Description = item.Content;
                var Author = item.Author;

                model.Add(new CustomNews
                {
                    Title = item.Title,
                    Description = item.Content,
                    Image = Image1,
                    Author=item.Author

                });


            }
            return View("Index",model);
        }
    }
}