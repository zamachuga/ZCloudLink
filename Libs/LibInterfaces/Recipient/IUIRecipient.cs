using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibInterfaces.Recipient
{
	/// <summary>
	/// Интерфейс визуальной части отправителя.
	/// </summary>
	public interface IUIRecipient
	{
		/// <summary>
		/// Главная форма.
		/// </summary>
		Form GeneralForm { get; }



		/// <summary>
		/// Событие: изменить состояние сервера.
		/// </summary>
		EventHandler<IRecipientState> EventServerStateShange { get; set; }



		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		/// <param name="ServerState"></param>
		void ViewServerState(IRecipientState ServerState);
	}
}