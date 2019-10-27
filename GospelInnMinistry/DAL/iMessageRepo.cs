using GospelInnMinistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospelInnMinistry.DAL
{
    interface iMessageRepo
    {
        void addMessage(Message message);

        IEnumerable<Message> getAllMessages();
    }
}
