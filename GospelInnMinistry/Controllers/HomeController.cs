using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GospelInnMinistry.Models;
using GospelInnMinistry.DAL;
using GospelInnMinistry.CommonCode;


namespace GospelInnMinistry.Controllers
{
    
    
    public class HomeController : Controller
    {
        GroupEventViewModel groupVM;
        EventsRepo repo = new EventsRepo();
        MessageRepo messageRepo = new MessageRepo();
		MediaRepo mediaRepo = new MediaRepo();
		GroupRepo groupRepo = new GroupRepo();
		

		public ActionResult Index()
        {
            groupVM = new GroupEventViewModel();
			 

            groupVM._event = repo.getAllUpcomingEvents();

			groupVM._LatestVedio = mediaRepo.getAllVedios().FirstOrDefault();
			groupVM._groups = groupRepo.GetAllgroups();

			var ev = repo.getCountDownEvent();
            groupVM._eventSingle = ev;
			
            ViewBag.Datestring = $"{@System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(ev.StartDate.Value.Month)} {ev.StartDate.Value.Day}, {ev.StartDate.Value.Year} {ev.StartDate.Value.TimeOfDay}".Split(new char[] { '.' })[0];
            return View(groupVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [HttpGet]
        public ActionResult Contact()
        {
            User user = new User();
            user.FirstName = "Fred";
            user.LastName = "Fred";
            user.PhoneNumber = "09014671017";
            user.Email = "i.i@yahoo.com";

            SendEmailViewModel sendEmailViewModel;
            sendEmailViewModel = new SendEmailViewModel();
            sendEmailViewModel.LoggedInUser = user ;
            // pass current user data
    
            return View(sendEmailViewModel);
        }



        [HttpPost]
        public ActionResult Contact(SendEmailViewModel vm)
        {
            User user = new User();
                    user.FirstName = "Fred";
                    user.LastName = "Fred";
                    user.PhoneNumber = "09014671017";
                    user.Email = "i.i@yahoo.com";

                    SendEmailViewModel sendEmailViewModel;
                    sendEmailViewModel = new SendEmailViewModel();
                    sendEmailViewModel.LoggedInUser = user;
            if (ModelState.IsValid)
            {
                //User user = new User();
                //user.FirstName = vm.FirstName;
                //user.LastName = vm.LastName;
                //user.Email = vm.Email;
                //user.PhoneNumber = vm.PhoneNumber;
                //if (user.Roleid == null)
                //{
                //    user.Roleid = 2;
                //}

                Message message = new Message();
                //   message.userId = 
                message.FirstName = vm.FirstName;
                message.LastName = vm.LastName;
                message.Message1 = vm.Message;
                message.PhoneNumber = vm.PhoneNumber;
                message.Email = vm.Email;
                message.DateSent = DateTime.Now;
                try
                {
                    messageRepo.addMessage(message);
                //  EmailCode.UserSendEmail(user, vm.Message);
                    ViewBag.Status = "Done!";

                
                    return View(sendEmailViewModel);
                }
                catch (Exception e)
                {
                    ViewBag.Status = e.Message.ToString();
                    return View(sendEmailViewModel);
                }
              
            }
            return View(sendEmailViewModel);
        }


        [HttpPost]
        public JsonResult NewsLetter(NewsLetterViewModel newsLetterViewModel)
        {
            // save email 
            User user = new User();
            user.Email = newsLetterViewModel.Email;
            
            ViewBag.Message = "Your application description page.";

            return Json("");
        }


        public ActionResult AmehAmana ()
        {
            return View();
        }


    }
}