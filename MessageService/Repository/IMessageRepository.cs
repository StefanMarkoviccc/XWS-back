using MessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllBySender(long id);
        IEnumerable<Message> GetAllByRecipient(long id);
    }
}
