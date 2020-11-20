using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTcpPackages
{
	/// <summary>
	/// Информация TCP сообщения.
	/// </summary>
	public class TcpMessageContainer
	{
		/// <summary>
		/// Создать контейнер сообщения.
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="Size"></param>
		/// <param name="Content"></param>
		public TcpMessageContainer(string Type, int Size, byte[] Content)
		{
			this.Type = Type;
			this.Size = Size;
			this.Content = Content;
		}



		/// <summary>
		/// Тип сообщения.
		/// </summary>
		public string Type { get; }

		/// <summary>
		/// Размер сообщения.
		/// </summary>
		public int Size { get; }

		/// <summary>
		/// Содержимое сообщения.
		/// </summary>
		public byte[] Content { get; }
	}
}