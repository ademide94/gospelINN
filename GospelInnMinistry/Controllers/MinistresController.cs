using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GospelInnMinistry.DAL;
using GospelInnMinistry.Models;
namespace GospelInnMinistry.Controllers
{
    public class MinistresController : Controller
    {
        GroupEventViewModel groupVM ;
        EventsRepo repo = new EventsRepo();
        MediaRepo mediaRepo = new MediaRepo();
        public enum  groups
        {
            Alabaster = 3 ,
            GospelInnLiterature = 4,
            GospelInnChildren = 5 ,
            LivingVoices = 2 ,
            Strasoda = 1 ,
            TurningPointRadio = 6 ,
            VineDrama = 7

        }
        // GET: Ministres
        public ActionResult Alabaster()
        {
            groupVM = new GroupEventViewModel();

            groupVM._event =  repo.getEventsByGroup(Convert.ToInt32(groups.Alabaster));
            groupVM._grouppictures = mediaRepo.getImagesByGroup(Convert.ToInt32(groups.Alabaster));
            return View(groupVM);
        }



        public ActionResult GospelInnLiterature()
        {
            groupVM = new GroupEventViewModel();

            groupVM._event = repo.getEventsByGroup(Convert.ToInt32(groups.GospelInnChildren));
            groupVM._grouppictures = mediaRepo.getImagesByGroup(Convert.ToInt32(groups.GospelInnChildren));
            return View(groupVM);
        }

     

        public ActionResult LivingVoices()
        {
            groupVM = new GroupEventViewModel();

            groupVM._event = repo.getEventsByGroup(Convert.ToInt32(groups.LivingVoices));
            groupVM._grouppictures = mediaRepo.getImagesByGroup(Convert.ToInt32(groups.LivingVoices));
            return View(groupVM);
        }

        public ActionResult Strasoda()
        {
            groupVM = new GroupEventViewModel();

            groupVM._event = repo.getEventsByGroup(Convert.ToInt32(groups.Strasoda));
            groupVM._grouppictures = mediaRepo.getImagesByGroup(Convert.ToInt32(groups.Strasoda));
            return View(groupVM);
        }

 
        public ActionResult VineDrama()
        {
            groupVM = new GroupEventViewModel();

            groupVM._event = repo.getEventsByGroup(Convert.ToInt32(groups.VineDrama));
            groupVM._grouppictures = mediaRepo.getImagesByGroup(Convert.ToInt32(groups.VineDrama));
            return View(groupVM);
        }

        public ActionResult SolidRock()
        {
            return View();
        }

        public ActionResult HossanaGuest()
        {
            return View();
        }
        public ActionResult CampressProject()
        {
            return View();
        }

    }
}