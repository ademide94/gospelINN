using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GospelInnMinistry.Models;




namespace GospelInnMinistry.DAL
{
    interface iEventsRepo 
    {

        bool AddEvent(Event Gevent);

        Event getCountDownEvent();

        IEnumerable<Event> getEventsByGroup(int id);

        IEnumerable<Event> getAllEvents();

        IEnumerable<Event> getAllUpcomingEvents();

        Event getEventsByid(int id);

    }
}
