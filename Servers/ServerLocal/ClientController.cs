using LibFunctional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerLocal
{
	/// <summary>
	/// Контроллер взаимодействия с клиентом.
	/// </summary>
	class ClientController
	{
		/// <summary>
		/// Инициализировать контроллер.
		/// </summary>
		private ClientController()
		{
		}

		/// <summary>
		/// Инициализировать контроллер.
		/// </summary>
		/// <param name="TcpClient"></param>
		/// <returns></returns>
		public static ClientController Instance(TcpClient TcpClient)
		{
			ClientController _Controller = new ClientController();
			_Controller.m_TcpClient = TcpClient;

			return _Controller;
		}



		/// <summary>
		/// Клиент.
		/// </summary>
		private TcpClient m_TcpClient;

		/// <summary>
		/// Секундомер ожидания входящего сообщения.
		/// </summary>
		private Stopwatch m_StopWatchWaitIncomingMessage;



		/// <summary>
		/// Обработать подключение клиента.
		/// </summary>
		internal void ConnectionProcess()
		{
			// Подготовить соглашение о подключении.
			var _Pkg = GetPkgConnectionAgreement();
			byte[] _Message = FuncSerialize.Serialize(_Pkg);

			// Отправить соглашение о подключении.
			NetworkStream _NetworkStream = m_TcpClient.GetStream();
			_NetworkStream.Write(_Message, 0, _Message.Length);

			// Запустить ожидание входящего сообщения.
			WaitForIncommingMessage();
		}

		/// <summary>
		/// Ожидать входящее сообщение от клиента.
		/// </summary>
		internal async void WaitForIncommingMessage()
		{
			if (m_StopWatchWaitIncomingMessage.IsRunning)
				m_StopWatchWaitIncomingMessage.Stop();

			m_StopWatchWaitIncomingMessage.Start();
			await Task.Run(() =>
			{

			});
		}

		/// <summary>
		/// Получить пакет согласования подключения.
		/// </summary>
		/// <returns></returns>
		private LibTcpPackages.TcpPkgConnectionAgreement GetPkgConnectionAgreement()
		{
			LibTcpPackages.TcpPkgConnectionAgreement _Pkg = new LibTcpPackages.TcpPkgConnectionAgreement()
			{
				AcceptConnection = true
			};

			return _Pkg;
		}
	}
}
