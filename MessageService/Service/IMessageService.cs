using MessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Service
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAllByRecipient(long id);
        IEnumerable<Message> GetAllBySender(long id);
    }
}
