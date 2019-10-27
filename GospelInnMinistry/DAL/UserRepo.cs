using GospelInnMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelInnMinistry.DAL
{
    public class UserRepo : iUserRole
    {
 
		GospeLInnEntities gospeLInnEntities;
		DB_A4877A_gospelInnEntities dB_A4877A_GospelInnEntities;

		public UserRepo ()
        {
			dB_A4877A_GospelInnEntities = new DB_A4877A_gospelInnEntities();

		//	gospeLInnEntities = new GospeLInnEntities();
        }
        public IEnumerable<User> GetAllUsers()
        {
			var result = dB_A4877A_GospelInnEntities.Users.ToList();   //  gospeLInnEntities.Users.ToList();


			return result;
        }
    }
}