using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GospelInnMinistry.Models;

namespace GospelInnMinistry.DAL
{
    interface iMediaRepo
    {
     
       bool addIamge(Medium data);
       IEnumerable<Medium> getImagesByGroup(int GroupId);

       IEnumerable<Medium> geAllImages();

        IEnumerable<Medium> getAllVedios();
        Medium getVedioById(int id);

		 
	}
}
