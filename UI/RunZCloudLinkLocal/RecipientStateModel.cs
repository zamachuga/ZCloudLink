using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibInterfaces.Recipient;

namespace RunZCloudLinkLocal
{
	class RecipientStateModel : IRecipientState
	{
		// *
		public string Ip { get; set; }

		// *
		public string Port { get; set; }

		// *
		public RecipientStatus ServerStatus { get; set; }
	}
}