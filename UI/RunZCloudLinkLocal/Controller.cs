using LibInterfaces.Recipient;
using RunZCloudLinkLocal.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIServer
{
	/// <summary>
	/// Контроллер пользовательского интерфейса.
	/// </summary>
	class Controller : IUIController
	{
		/// <summary>
		/// Инициализировать.
		/// </summary>
		private Controller()
		{
			m_FormStartServer = new FormStart();
		}

		/// <summary>
		/// Инициализировать.
		/// </summary>
		private static IUIController Instance()
		{
			return new Controller();
		}



		// *
		public Form GeneralForm => m_UIRecipient.GeneralForm;

		// *
		public EventHandler<IRecipientState> EventServerStateShange
		{
			get => m_UIRecipient.EventServerStateShange;
			set => m_UIRecipient.EventServerStateShange = value;
		}

		/// <summary>
		/// Форма запуска сервера.
		/// </summary>
		private readonly IFormStart m_FormStartServer;

		/// <summary>
		/// Интерфейс локального пользователя.
		/// </summary>
		private IUIController m_UIRecipient => m_FormStartServer as IUIController;



		public void ViewServerState(IRecipientState RecipientState)
		{
			m_FormStartServer.ViewServerState(RecipientState);
		}
	}
}