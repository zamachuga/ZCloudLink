using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInterfaces.Sender
{
	/// <summary>
	/// Отправитель пакетов.
	/// </summary>
	public interface ISender
	{
		/// <summary>
		/// Регистрация визуальной части.
		/// </summary>
		/// <param name="UI"></param>
		void RegUI(IUISender UI);
	}
}
