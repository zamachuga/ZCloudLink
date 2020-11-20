using LibInterfaces.Server.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIServer.WinForms;

namespace UIServer
{
	/// <summary>
	/// Контроллер пользовательского интерфейса.
	/// </summary>
	class Controller : IUIServerLocal
	{
		/// <summary>
		/// Инициализировать.
		/// </summary>
		private Controller()
		{
			m_FormStartServer = new FormStartServer();
		}

		/// <summary>
		/// Инициализировать.
		/// </summary>
		private static IUIServerLocal Instance()
		{
			return new Controller();
		}



		public Form GeneralForm => m_UIServerLocal.GeneralForm;

		public EventHandler<IServerState> EventServerStateShange
		{
			get => m_UIServerLocal.EventServerStateShange;
			set => m_UIServerLocal.EventServerStateShange = value;
		}

		/// <summary>
		/// Форма запуска сервера.
		/// </summary>
		private IFormStartServer m_FormStartServer;

		/// <summary>
		/// Интерфейс локального пользователя.
		/// </summary>
		private IUIServerLocal m_UIServerLocal => m_FormStartServer as IUIServerLocal;



		public void ViewServerState(IServerState ServerState)
		{
			m_FormStartServer.ViewServerState(ServerState);
		}
	}
}