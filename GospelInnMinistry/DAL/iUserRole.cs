using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GospelInnMinistry.Models;

namespace GospelInnMinistry.DAL
{
    interface iUserRole
    {
       IEnumerable<User> GetAllUsers();
    }
}
