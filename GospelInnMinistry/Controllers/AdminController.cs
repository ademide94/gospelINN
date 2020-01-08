using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GospelInnMinistry.DAL;
using GospelInnMinistry.Models;
using GospelInnMinistry.CommonCode;

namespace GospelInnMinistry.Controllers
{
    public class AdminController : Controller
    {
        EventsRepo eventsRepo = new EventsRepo();
        UserRepo userRepo = new UserRepo();
		MediaRepo mediaRepo = new MediaRepo();
		// GET: Admin
		public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult sendNewsletter()
        {
      
            return View();
        }

        [HttpPost]
        public ActionResult sendNewsletter(string message , string subject)
        {
            try
            {
              IEnumerable<User> response =  userRepo.GetAllUsers().ToList();
            foreach(var item in response)
            {
                    User user = new User();
                    user.FirstName = "Admin";
                    user.Roleid = 2;
                    user.Email = "ibrahim.ademide@yahoo.com";
                    ViewBag.Status = item.Id;
                    EmailCode.SendNewsLetter(user,item.Email, message,subject);
                }
                ViewBag.Status = "Done";
                return View();
            }
        catch (Exception e)
            {
                ViewBag.Status = "Error";
                //   ViewBag.Status = e.Message.ToString();

            }
            return View();
        }

        [HttpGet]
        public ActionResult UploadImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImages(HttpPostedFileBase[] files , string Group )
        {
            MediaRepo mediaRepo = new MediaRepo();

            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    Medium medium = new Medium();
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/images/PicGallery/") + InputFileName);
                        medium.ContentLocation = "../images/PicGallery/"+ InputFileName;
                        medium.MediaName = InputFileName;
                        medium.DateCreated = DateTime.Now;
                        medium.groupId = Convert.ToInt32(Group);
                        medium.CreatedBy = 1; // User.Identity.GetUserId();
                        mediaRepo.addIamge(medium);
                        //Save file to server folder  
                         file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }

            }

            return View();
     
        }

        [HttpGet]
        public ActionResult AllEvent()
        {
            
            var result =  eventsRepo.getAllEvents();
            return View(result);
         
        }

        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(EventsViewModel eventsViewModel)
        {
            Event _event = new Event();
            _event.EventName = eventsViewModel.EventName;
            _event.EventDescription = eventsViewModel.EventDescription;
            _event.GroupId = eventsViewModel.GroupId;
            _event.Location = eventsViewModel.Location;
            _event.StartDate = eventsViewModel.StartDate;
            _event.EndDate = eventsViewModel.EndDate;
            _event.UserId = eventsViewModel.UserId;
           
            eventsRepo.AddEvent(_event);
            return View();
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            return View();
        }

		[HttpGet]
		public ActionResult AddYoutubeVedio()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddYoutubeVedio(Medium medium)
		{
			try
			{
Medium data = new Medium();
			data.ContentLocation = medium.ContentLocation;
			//data.CreatedBy = 
			data.DateCreated = DateTime.Now;
			data.groupId = medium.groupId;
			data.isVedio = true;
			data.MediaName = medium.MediaName;
			data.VedioDesciption = medium.VedioDesciption;
			data.VedioPreacher = medium.VedioPreacher;
		 
			bool feedBack = mediaRepo.addIamge(data);

			if(feedBack)
			{
				ViewBag.Status = "Success";
				return View();
			}

			}

			catch
			{
				ViewBag.Status = "Error";
			}
			

			return View();
		}

        
	}
}