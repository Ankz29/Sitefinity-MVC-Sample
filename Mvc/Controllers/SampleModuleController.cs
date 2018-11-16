//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Telerik.Sitefinity.DynamicModules;
//using Telerik.Sitefinity.Mvc;
//using SitefinityWebApp.Mvc.Models;
//using Telerik.Sitefinity.Utilities.TypeConverters;
//using System.Linq.Dynamic;
//using Telerik.Sitefinity.Model;
//using Telerik.Sitefinity.RelatedData;
//using Telerik.Sitefinity.Lifecycle;
//using Telerik.Sitefinity.Taxonomies;
//using Telerik.Sitefinity.Taxonomies.Model;

//namespace SitefinityWebApp.Mvc.Controllers
//{
//    [ControllerToolboxItem(Name="SampleModule",Title="SampleModule",SectionName="MVCWidget")]
//    public class SampleModuleController : Controller
//    {
//        // GET: SampleModule
//        public ActionResult Index()
//        {
//            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager();
//            Type sampleType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Samplemodule.Sample");
//            var showcases = dynamicModuleManager.GetDataItems(sampleType).Where(s => s.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live);
          
//            TaxonomyManager taxonomyManager = TaxonomyManager.GetManager();            
//            List<SampleModule> list = new List<SampleModule>();

//            foreach(var item in showcases)
//            {
//                var Category = taxonomyManager.GetTaxonomies<HierarchicalTaxonomy>().Where(t => t.Name == "Categories").FirstOrDefault();//back-end category name should be provided//
//                var CategoryDetails = item.GetValue("Categories");
//                string Category1 = "";
//                if(CategoryDetails != null)
//                {
//                    var prodcat = Category.Taxa.Where(m => m.Id == CategoryDetails);
//                    Category1 = prodcat.Title;
//                }
//                else
//                {
//                    Category1 = "";
//                }
//                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault(); 
//                var image1 = "";
//                if (image!= null)
//                {
//                    image1 = image.MediaUrl.ToString();
//                }
//                list.Add(new SampleModule()
//                {
//                    Title = item.Title.ToString(),
//                    Description = item.GetValue("Description").ToString(),
//                    Image = image1
//                 });
//            }
//            return View("Index",list);
//        }
//    }
//}