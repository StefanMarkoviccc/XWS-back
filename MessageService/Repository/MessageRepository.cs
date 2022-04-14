using MessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(MessageContext context) : base(context) { }

        public IEnumerable<Message> GetAllByRecipient(long id)
        {
            return MessageContext.Messages.Where(x => !x.Deleted && x.IdRecipient == id).ToList();
        }

        public IEnumerable<Message> GetAllBySender(long id)
        {
            return MessageContext.Messages.Where(x => !x.Deleted && x.IdSender == id).ToList();
        }
    }
}
