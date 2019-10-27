using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GospelInnMinistry.DAL;


namespace GospelInnMinistry.Controllers
{
    public class MediaController : Controller
    {

        MediaRepo mediaRepo = new MediaRepo();
		string vedioUrl = "";
		int vedioId = 0;
        // GET: Media
        public ActionResult Index()
        {


            return View();
        }
		[HttpGet]
        public ActionResult Vedios( int id = 0,string url = "")
        {
            var data = mediaRepo.getAllVedios();
		 
          

			if(id != 0  && !String.IsNullOrWhiteSpace(url) )
		    {
				ViewBag.AData = id;
				ViewBag.AUrl = url;
			}
			else
			{
				ViewBag.AData = 0;
			}
			
			   
				
			return View(data);

		
        
        }


		[HttpGet]
		public ActionResult  PlayVedio(int Id)
        {
            
            var data = mediaRepo.getVedioById(Id);
			vedioId = Id;
			vedioUrl = data.ContentLocation;
 
			return RedirectToAction("Vedios", new {id = vedioId, url = vedioUrl });
        }

        [HttpGet]
        public ActionResult Gallery()
        {
            var data =  mediaRepo.geAllImages(); 
            return View(data);
        }

        [HttpPost]
        public ActionResult Gallery(int Group)
        {
            var data = mediaRepo.getImagesByGroup(Group);
            return View(data);
        }
    }
}