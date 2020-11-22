using LibInterfaces.Recipient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunZCloudLinkLocal.WinForms
{
	/// <summary>
	/// Интерфейс визуальной части отображающей состояние сервера.
	/// </summary>
	internal interface IFormStart
	{
		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		/// <param name="ServerState"></param>
		void ViewServerState(IRecipientState ServerState);
	}
}