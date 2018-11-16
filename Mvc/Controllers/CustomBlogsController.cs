using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Modules.Blogs;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Blogs", Title = "Blogs", SectionName = "CustomWidget")]
    public class CustomBlogsController : Controller
    {  
        // GET: CustomBlogs
        public ActionResult Index()
        {
            BlogsManager blogsManager = BlogsManager.GetManager();
            Blog blog = blogsManager.GetBlogs().Where(m => m.Title == "Blogs List").FirstOrDefault();
            var blogPosts = blogsManager.GetBlogPosts().Where(b => b.Status == ContentLifecycleStatus.Live).ToList();
            List<CustomBlogs> list = new List<CustomBlogs>();

            foreach (var item in blogPosts)
            {

                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();
                var image1 = "";
                if (image != null)
                {
                    image1 = image.MediaUrl.ToString();
                }


                var Title = item.Title;
                var Description = item.Content;


                list.Add(new CustomBlogs
                {
                    Title = item.Title,
                    Description = item.Content,
                    Image = image1


                });

            }
            return View("Index",list);
        }
    }
}