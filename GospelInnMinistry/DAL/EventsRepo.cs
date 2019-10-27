using GospelInnMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace GospelInnMinistry.DAL
{
    public class EventsRepo  : iEventsRepo
    {
        GospeLInnEntities _gospeLInnEntities;

		DB_A4877A_gospelInnEntities dB_A4877A_GospelInnEntities;

		public EventsRepo()
		{
			dB_A4877A_GospelInnEntities = new DB_A4877A_gospelInnEntities();
			//_gospeLInnEntities = new GospeLInnEntities();
		}
		 

        public bool AddEvent(Event Gevent)
        {
			dB_A4877A_GospelInnEntities.Events.Add(Gevent);
			dB_A4877A_GospelInnEntities.SaveChanges();
            return true;
        }

        public  Event getCountDownEvent()
        {
            
            var e = from s in dB_A4877A_GospelInnEntities.Events
                    where s.StartDate > DateTime.Now
                    orderby  s.StartDate ascending
                    select s;


            return (e).FirstOrDefault();
        }

      public IEnumerable<Event> getEventsByGroup (int id)
        {
            var e = from s in dB_A4877A_GospelInnEntities.Events
                    where s.GroupId == id && s.EndDate > DateTime.Now
                    orderby s.StartDate ascending
                    select s;
            return e;
        }

        public Event getEventsByid(int id)
        {
            var e = from s in dB_A4877A_GospelInnEntities.Events
                    where s.Id == id  
                    select s;
            return e.FirstOrDefault();
        }

        public  IEnumerable<Event> getAllEvents()
        {
            var e = from s in dB_A4877A_GospelInnEntities.Events
                 
                    orderby s.StartDate descending
                    select s;

            return e.ToList();
        }

        public IEnumerable<Event> getAllUpcomingEvents()
        {
            var e = from s in dB_A4877A_GospelInnEntities.Events
                    where s.StartDate > DateTime.Now
                    orderby s.StartDate ascending
                    select s;

           return  e.ToList();
        }

    }
}