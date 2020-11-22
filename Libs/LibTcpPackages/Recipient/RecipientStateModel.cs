using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibInterfaces.Recipient;

namespace LibTcpPackages.Recipient
{
	class RecipientStateModel : IRecipientState
	{
		public string Ip { get; internal set; }

		public string Port { get; internal  set; }

		public RecipientStatus ServerStatus { get; internal set; }
	}
}