using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Recipient
{
	/// <summary>
	/// Получатель пакетов.
	/// </summary>
	public interface IRecipient
	{
		/// <summary>
		/// Регистрация визуального компонента для взаимодействия с сервером.
		/// </summary>
		/// <param name="UIController"></param>
		/// <remarks>
		/// Сохранение ссылки, подписка событий.
		/// </remarks>
		void RegUI(IUIRecipient UIController);
	}
}