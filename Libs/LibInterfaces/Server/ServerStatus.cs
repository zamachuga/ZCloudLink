using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Server
{
	/// <summary>
	/// Статус сервера.
	/// </summary>
	public enum  ServerStatus
	{
		/// <summary>
		/// Остановлен.
		/// </summary>
		Stoped,
		/// <summary>
		/// Прослушивает входящие сообщения.
		/// </summary>
		Listen,
		/// <summary>
		/// Обработка входящего подключения.
		/// </summary>
		Processing
	}
}
