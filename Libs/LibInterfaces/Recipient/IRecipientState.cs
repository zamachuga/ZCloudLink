using LibInterfaces.Recipient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Recipient
{
	/// <summary>
	/// Состояние получателя.
	/// </summary>
	public interface IRecipientState
	{
		// *
		string Ip { get; }

		// *
		string Port { get; }

		// *
		RecipientStatus ServerStatus { get; }
	}
}