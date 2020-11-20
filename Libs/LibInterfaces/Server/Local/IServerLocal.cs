using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Server.Local
{
	/// <summary>
	/// Локальный сервер.
	/// </summary>
	public interface IServerLocal
	{
		/// <summary>
		/// Регистрация визуального компонента для взаимодействия с сервером.
		/// </summary>
		/// <param name="uIServerLocal"></param>
		/// <remarks>
		/// Сохранение ссылки, подписка событий.
		/// </remarks>
		void RegUI(IUIServerLocal uIServerLocal);
	}
}
