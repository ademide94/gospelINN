using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GospelInnMinistry.Models;

namespace GospelInnMinistry.DAL
{
	public class GroupRepo : iGroupRepo
	{
		//GospeLInnEntities gospeLInnEntities;

		DB_A4877A_gospelInnEntities dB_A4877A_GospelInnEntities;

		public GroupRepo()
		{
			dB_A4877A_GospelInnEntities = new DB_A4877A_gospelInnEntities();

			//	gospeLInnEntities = new GospeLInnEntities();
		}
		public List<Group> GetAllgroups()
		{
			var result = dB_A4877A_GospelInnEntities.Groups.ToList();   //  gospeLInnEntities.Users.ToList();


			return result;
		}
	}
}