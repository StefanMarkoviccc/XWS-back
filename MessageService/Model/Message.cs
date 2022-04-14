using System;

namespace MessageService.Model 
{
	public class Message : Entity
	{
		public string Text { get; set; }

		public long IdSender{ get; set; }

		public long IdRecipient{ get; set; }
	}
}

