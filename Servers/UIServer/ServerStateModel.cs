using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibInterfaces.Server;
using LibInterfaces.Server.Local;

namespace UIServer
{
	class ServerStateModel : IServerState
	{
		public string Ip { get; set; }

		public string Port { get; set; }

		public ServerStatus ServerStatus { get; set; }
	}
}
