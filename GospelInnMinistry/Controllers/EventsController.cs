using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GospelInnMinistry.DAL;
using GospelInnMinistry.Models;
namespace GospelInnMinistry.Controllers
{
    public class EventsController : Controller
    {
        EventsRepo eventsRepo = new EventsRepo();

        // GET: Events
        public ActionResult Index()
        {
            IEnumerable<Event> result = eventsRepo.getAllEvents();
            return View(result);
        }

        public ActionResult ViewEvent(int id)
        {
            var result = eventsRepo.getEventsByid(id);
            return View(result);
        }
    }
}