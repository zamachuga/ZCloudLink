using LibInterfaces.Server;
using LibInterfaces.Server.Local;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerLocal
{
	/// <summary>
	/// Контроллер сервера.
	/// </summary>
	class ServerController : IServerLocal
	{
		/// <summary>
		/// Инициализировать ядро.
		/// </summary>
		private ServerController()
		{
			m_ListClients = new List<ClientController>();
			m_ServerState = new ServerStateModel()
			{
				Ip = "127.0.0.1",
				Port = "50000",
				ServerStatus = ServerStatus.Stoped
			};
		}

		/// <summary>
		/// Инициализировать ядро
		/// </summary>
		/// <returns></returns>
		private static IServerLocal Instance()
		{
			return new ServerController();
		}



		/// <summary>
		/// Прослушиватель входящих подключений.
		/// </summary>
		private TcpListener m_Listener;

		/// <summary>
		/// Ресурса управления токеном параллельного выполнения задач.
		/// </summary>
		/// <remarks>
		/// https://metanit.com/sharp/tutorial/12.5.php
		/// </remarks>
		private CancellationTokenSource m_CancellationTokenSource;
		/// <summary>
		/// Токен параллельного выполнения задачи.
		/// </summary>
		/// <remarks>
		/// https://metanit.com/sharp/tutorial/12.5.php
		/// </remarks>
		private CancellationToken m_CancellationToken;

		/// <summary>
		/// Список подключенных клиентов.
		/// </summary>
		private List<ClientController> m_ListClients;

		/// <summary>
		/// Интерфейс сервера.
		/// </summary>
		private IUIServerLocal m_UIServerLocal;

		/// <summary>
		/// Состояние сервера.
		/// </summary>
		private ServerStateModel m_ServerState;

		/// <summary>
		/// Статус сервера.
		/// </summary>
		public ServerStatus Status => m_ServerState.ServerStatus;



		/// <summary>
		/// Запустить сервер.
		/// </summary>
		private void Start(IServerState ServerState)
		{
			IPAddress _IPAddress = IPAddress.Parse(ServerState.Ip);
			int _Port = int.Parse(ServerState.Port);
			IPEndPoint _IPEndPoint = new IPEndPoint(_IPAddress, _Port);

			Start(_IPEndPoint);
		}
		/// <summary>
		/// Запустить сервер.
		/// </summary>
		/// <param name="IPEndPoint"></param>
		private void Start(IPEndPoint IPEndPoint)
		{
			// Токен управления параллельным выполненим задач.
			m_CancellationTokenSource = new CancellationTokenSource();
			m_CancellationToken = m_CancellationTokenSource.Token;

			// Запуск прослушивателя.
			m_Listener = new TcpListener(IPEndPoint);
			m_Listener.Start();

			// Параллельная обработка входящих подключений.
			//new Task(() => Listen()).Start();
			new Thread(new ThreadStart(delegate () { Listen(); })).Start();

			// Сохранить параметры запуска сервера.
			m_ServerState.Ip = IPEndPoint.Address.ToString();
			m_ServerState.Port = IPEndPoint.Port.ToString();
			m_ServerState.ServerStatus = ServerStatus.Listen;

			// Отобразить состояние сервера.
			ViewServerState();
		}

		/// <summary>
		/// Остановить сервер.
		/// </summary>
		private void Stop()
		{
			m_CancellationTokenSource?.Cancel();
			m_Listener?.Stop();
			m_ServerState.ServerStatus = ServerStatus.Stoped;

			// Отобразить состояние сервера.
			ViewServerState();
		}

		/// <summary>
		/// Слушать входящие подключения.
		/// </summary>
		private void Listen()
		{
			while (!m_CancellationToken.IsCancellationRequested)
			{
				TcpClient _Client;
				try
				{
					// Принять подключение клиента (через ожидание подключения).
					_Client = m_Listener.AcceptTcpClient();
				}
				catch (SocketException Ex)
				{
					if (!m_CancellationToken.IsCancellationRequested)
						ServiceExceptions.RegException(Ex);
					continue;
				}

				// Создаем контроллер взаимодействия с клиентом.
				ClientController _ClientController = ClientController.Instance(_Client);
				m_ListClients.Add(_ClientController);

				// Запустить взаимодействие с клиентом.
				// В отдельном потоке для быстрого приема нового клиента.
				new Thread(new ThreadStart(delegate () { _ClientController.ConnectionProcess(); })).Start();
			}
		}

		/// <summary>
		/// Событие: изменилось состояние сервера.
		/// </summary>
		private void EventServerStateShanged(object Sender, IServerState ServerState)
		{
			switch (Status)
			{
				case ServerStatus.Stoped:
					Start(ServerState);
					break;
				case ServerStatus.Listen:
					Stop();
					break;
				case ServerStatus.Processing:
					break;
				default:
					ServiceExceptions.RegException(
						new ArgumentException(
							"Необработанное состяние сервера для события {Изменить состояние сервера}.",
							"ServerStatus"
							)
						);
					break;
			}
		}

		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		private void ViewServerState()
		{
			m_UIServerLocal.ViewServerState(m_ServerState);
		}

		/// <summary>
		/// Зарегистрировать визуальный интерфейс для взаимодействия.
		/// </summary>
		/// <param name="UIServerLocal">Визуальный интерфейс.</param>
		/// TODO: NotImplementedException.
		public void RegUI(IUIServerLocal UIServerLocal)
		{
			m_UIServerLocal = UIServerLocal;
			m_UIServerLocal.EventServerStateShange += EventServerStateShanged;
			m_UIServerLocal.ViewServerState(m_ServerState);
		}
	}
}