using MessageService.Model;
using MessageService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Service
{
    public class MessageService : BaseService<Message>, IMessageService
    {
        public MessageService() { }
        public IEnumerable<Message> GetAllByRecipient(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new MessageContext());

                return unitOfWork.Messages.GetAllByRecipient(id);
            }
            catch (Exception e) 
            {
                return new List<Message>();
            }
        }

        public IEnumerable<Message> GetAllBySender(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new MessageContext());

                return unitOfWork.Messages.GetAllBySender(id);
            }
            catch (Exception e)
            {
                return new List<Message>();
            }
        }
    }
}
