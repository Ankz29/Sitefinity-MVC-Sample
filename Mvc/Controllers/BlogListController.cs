//using System.Web.Mvc;
//using SitefinityWebApp.Mvc.Models;
//using Telerik.Sitefinity.Modules.Blogs;
////using System.Linq;
//using Telerik.Sitefinity.Blogs.Model;
//using System.Linq;
//using Telerik.Sitefinity.Data.Linq.Dynamic;
//using Telerik.Sitefinity.GenericContent.Model;
//using Telerik.Sitefinity.Taxonomies;
//using System.Collections.Generic;
//using Telerik.Sitefinity.Taxonomies.Model;
//using Telerik.Sitefinity.Model;
//using System;
//using Telerik.Sitefinity.RelatedData;
//using Telerik.Sitefinity.Mvc;
//using Telerik.Sitefinity.Modules.News;
//using Telerik.Sitefinity.News.Model;

//namespace SitefinityWebApp.Mvc.Controllers
//{
//    [ControllerToolboxItem(Name = "BlogList", Title = "Blog List", SectionName = "CustomWidget")]
//    public class BlogListController : Controller
//    {
//        // GET: BlogList
//        //public ActionResult Index()
//        //{
//        //    BlogsManager blogsManager = BlogsManager.GetManager();

//        //    //Get the master version. 
//        //    Blog blog = blogsManager.GetBlogs().Where(m => m.Title == "Blogs List").FirstOrDefault();//<----parent-Blog name----->//
//        //    var blogPosts = blogsManager.GetBlogPosts().Where(b => b.Status == ContentLifecycleStatus.Live).ToList(); //<----child-blog name----->//

//        //    TaxonomyManager manager = TaxonomyManager.GetManager();
//        //    List<BlogList> model = new List<BlogList>();

//        //    foreach(var item in blogPosts)
//        //    {
//        //        var ParentCategory = manager.GetTaxa<HierarchicalTaxon>().Where(t => t.Taxonomy.Name == "Categories").FirstOrDefault();//<------Parent-category----->//
//        //        var ChildCategory = item.GetValue("Categories") as List<Guid>;
//        // string Category1 = "";
//        //if(ChildCategory != null)
//        //{
//        //  if(ParentCategory != null)
//        //    {
//        //      // var data= ParentCategory.Taxa.Where(t => t.Name == "Language Groups").FirstOrDefault();

//        //        var data = ParentCategory.taxa.Where(K => K.id == ChildCategory.FirstOrDefault());
//        //        Category1 = data.FirstOrDefault().Title.ToString(); 
//        //    }
//        //}
//        //else
//        //{
//        //    Category1 = ""; 
//        //}

//        //        var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();
//        //        var image1 = "";
//        //        if(image !=null)
//        //        {
//        //            image1 = image.MediaUrl.ToString();
//        //        }

//        //        model.Add(new BlogList()
//        //        {
//        //            Title = item.Title,
//        //            Description = item.Description,
//        //            Image=image1
//        //        });

//        //    }

//        //    return View("Index",model);
//        //}

//        public Taxon GetCategoryByTitle(string title)
//        {

//            var taxonomyMgr = TaxonomyManager.GetManager();

//            HierarchicalTaxonomy category = taxonomyMgr.GetTaxonomies<HierarchicalTaxonomy>().Where(x => x.Name == "Categories").SingleOrDefault();

//            if (category == null)

//                return null;


//            return category.Taxa.Where(x => x.Title == title).SingleOrDefault();




//        public List<NewsItem> GetContentByCategory(Guid categoryId)


//          Taxon catTaxon = GetCategoryByTitle("TestCategory1");
//        List<NewsItem> newsItemsList = GetContentByCategory(catTaxon.Id);


//        var taxonomyMgr = TaxonomyManager.GetManager();
//        var newsMgr = NewsManager.GetManager();

//        // Get the Id of the category
//        var taxonId = taxonomyMgr.GetTaxa<HierarchicalTaxon>()
//                                 .Where(t => t.Id == categoryId)
//                                 .SingleOrDefault()
//                                 .Id;

//        // Get all news items that are assigned to this category
//        var NewsItemsInCategory = newsMgr.GetNewsItems().Where(p => p.Status == ContentLifecycleStatus.Live && p.GetValue<TrackedList<Guid>>("Category").Contains(taxonId));
//          return NewsItemsInCategory.ToList();
//            }
//    }
//}