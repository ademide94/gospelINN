using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GospelInnMinistry.Models;

namespace GospelInnMinistry.DAL
{
    public class MessageRepo : iMessageRepo
    {
        GospeLInnEntities _gospeLInnEntities;

		DB_A4877A_gospelInnEntities dB_A4877A_GospelInnEntities;

		public MessageRepo()
        {
			dB_A4877A_GospelInnEntities = new DB_A4877A_gospelInnEntities();
			//_gospeLInnEntities = new GospeLInnEntities();
        }
       public void addMessage(Message message)
        {
			dB_A4877A_GospelInnEntities.Messages.Add(message);     // _gospeLInnEntities.Messages.Add(message);

			dB_A4877A_GospelInnEntities.SaveChanges();    //_gospeLInnEntities.SaveChanges();

		}

        public IEnumerable<Message> getAllMessages()
        {
			return dB_A4877A_GospelInnEntities.Messages.ToList();     // _gospeLInnEntities.Messages.ToList();
		}
    }
}