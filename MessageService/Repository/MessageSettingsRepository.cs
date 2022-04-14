using MessageService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Repository
{
    public class MessageSettingsRepository : BaseRepository<MessageSettings>, IMessageSettingsRepository
    {
        public MessageSettingsRepository(MessageContext context) : base(context) { }
    }
}
