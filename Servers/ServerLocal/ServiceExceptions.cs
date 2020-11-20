using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLocal
{
	/// <summary>
	/// Сервис регистрации исключений возникающих в приложении.
	/// </summary>
	/// <remarks>
	/// Основное назначение - исключить необходимость искать по коду 
	/// места где разработчик натыкал собственных исключений.
	/// Позволяет централизованно обрабатывать собственные исключения.
	/// </remarks>
	class ServiceExceptions
	{
		internal static void RegException(Exception Ex) => throw Ex;
	}
}
