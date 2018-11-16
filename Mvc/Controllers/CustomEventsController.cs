using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.RelatedData;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name="Events",Title="Events",SectionName="CustomWidget")]
    public class CustomEventsController : Controller
    {
        // GET: CustomEvents
        public ActionResult Index()
        {
            EventsManager eventsmanager = EventsManager.GetManager();
            var events = eventsmanager.GetEvents().Where(m => m.Title == "Events").FirstOrDefault();
            var eventsPosts=eventsmanager.GetEvents().Where(n => n.Status == ContentLifecycleStatus.Live).ToList();

            List<CustomEvents> model = new List<CustomEvents>();

            foreach(var item in eventsPosts)
            {
                var image=item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();
                string Image1 = "";

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
                var EventStart = item.EventStart;
                var EventEnd = item.EventEnd;
                var category = item.GetValue("Category");
                var Email = item.ContactEmail;
                var Phone = item.ContactPhone;

                model.Add(new CustomEvents
                {
                    Title=item.Title,
                    Description=item.Content,
                    EventStart=item.EventStart,
                   // Category=item.category,
                    EventEnd=item.EventEnd,
                    Email = item.ContactEmail,
                    Phone=item.ContactPhone,
                    Image=Image1
                });

            }

            return View("Index",model);
        }
    }
}