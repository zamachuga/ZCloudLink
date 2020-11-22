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
	class Controller : IUIRecipient
	{
		/// <summary>
		/// Инициализировать.
		/// </summary>
		private Controller()
		{
			m_FormStart = new FormStart();
		}

		/// <summary>
		/// Инициализировать.
		/// </summary>
		private static IUIRecipient Instance()
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
		private readonly FormStart m_FormStart;

		/// <summary>
		/// Интерфейс локального пользователя.
		/// </summary>
		private IUIRecipient m_UIRecipient => m_FormStart;



		// *
		public void ViewServerState(IRecipientState RecipientState)
		{
			m_FormStart.ViewServerState(RecipientState);
		}
	}
}