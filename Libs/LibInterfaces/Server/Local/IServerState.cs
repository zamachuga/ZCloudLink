using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Server.Local
{
	/// <summary>
	/// Информация по серверу.
	/// </summary>
	public interface IServerState
	{
		string Ip { get; }
		string Port { get; }
		ServerStatus ServerStatus { get; }
	}
}