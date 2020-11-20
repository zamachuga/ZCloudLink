using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTcpPackages
{
	/// <summary>
	/// Соглашение подключения между клиентом и сервером.
	/// </summary>
	public class TcpPkgConnectionAgreement
	{
		/// <summary>
		/// Принять подключение.
		/// </summary>
		public bool AcceptConnection { get; set; }

		/// <summary>
		/// Текст сообщения.
		/// </summary>
		/// <remarks>
		/// Опционально для пояснения.
		/// </remarks>
		public string MessageText { get; set; }
	}
}