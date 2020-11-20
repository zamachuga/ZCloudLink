using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibInterfaces.Server;
using LibInterfaces.Server.Local;

namespace ServerLocal
{
	class ServerStateModel : IServerState
	{
		public string Ip { get; internal set; }

		public string Port { get; internal  set; }

		public ServerStatus ServerStatus { get; internal set; }
	}
}
