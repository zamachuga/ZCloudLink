using LibInterfaces.Server.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIServer.WinForms
{
	/// <summary>
	/// Интерфейс визуальной части отображающей состояние сервера.
	/// </summary>
	internal interface IFormStartServer
	{
		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		/// <param name="ServerState"></param>
		void ViewServerState(IServerState ServerState);
	}
}