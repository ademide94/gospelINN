using GospelInnMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospelInnMinistry.DAL
{
    public class MediaRepo : iMediaRepo
    {
        GospeLInnEntities _gospeLInnEntities;
		DB_A4877A_gospelInnEntities dB_A4877A_GospelInnEntities;

		public MediaRepo()
		{
			dB_A4877A_GospelInnEntities = new DB_A4877A_gospelInnEntities();
			//_gospeLInnEntities = new GospeLInnEntities();
		}
	 

        public bool addIamge(Medium data)
        {

			dB_A4877A_GospelInnEntities.Media.Add(data);  // _gospeLInnEntities.Media.Add(data);

			dB_A4877A_GospelInnEntities.SaveChanges();       //_gospeLInnEntities.SaveChanges();

			return true;
        }


        public IEnumerable<Medium> getImagesByGroup(int GroupId)
        {
            var result = from s in dB_A4877A_GospelInnEntities.Media
                         where s.groupId == GroupId
                         select s;
            return result.Take(5);
        }

        public IEnumerable<Medium> geAllImages()
        {
            var result = from s in dB_A4877A_GospelInnEntities.Media
                         select s;
            return result;
        }

         public   IEnumerable<Medium> getAllVedios()
        {
            var result = from s in dB_A4877A_GospelInnEntities.Media
                         where s.isVedio == true
                         orderby s.DateCreated descending
                         select s;
            return result;
        }
        public Medium getVedioById(int id)
        {
            var result = from s in dB_A4877A_GospelInnEntities.Media
                         where s.Id == id && s.isVedio == true
                         select s;
            return result.FirstOrDefault();
        }

	 
	}
}