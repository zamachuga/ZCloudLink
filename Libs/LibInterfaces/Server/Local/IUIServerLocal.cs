using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibInterfaces.Server.Local
{
	/// <summary>
	/// Интерфейс визуальной части локального сервера.
	/// </summary>
	public interface IUIServerLocal
	{
		/// <summary>
		/// Главная форма.
		/// </summary>
		Form GeneralForm { get; }



		/// <summary>
		/// Событие: изменить состояние сервера.
		/// </summary>
		EventHandler<IServerState> EventServerStateShange { get; set; }



		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		/// <param name="ServerState"></param>
		void ViewServerState(IServerState ServerState);
	}
}