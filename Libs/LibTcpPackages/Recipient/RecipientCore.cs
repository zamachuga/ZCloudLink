using LibInterfaces.Recipient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LibTcpPackages.Recipient
{
	/// <summary>
	/// Контроллер получателя пакетов.
	/// </summary>
	/// <remarks>
	/// Прослушивание и прием входящих пакетов.
	/// </remarks>
	class RecipientCore : IRecipient
	{
		/// <summary>
		/// Инициализировать ядро.
		/// </summary>
		private RecipientCore()
		{
			m_ListClients = new List<ConnectionManagement>();
			m_RecipientState = new RecipientStateModel()
			{
				Ip = "127.0.0.1",
				Port = "50000",
				ServerStatus = RecipientStatus.Stoped
			};
		}

		/// <summary>
		/// Инициализировать ядро
		/// </summary>
		/// <returns></returns>
		private static IRecipient Instance()
		{
			return new RecipientCore();
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
		private readonly List<ConnectionManagement> m_ListClients;

		/// <summary>
		/// Интерфейс сервера.
		/// </summary>
		private IUIRecipient m_UIRecipient;

		/// <summary>
		/// Состояние сервера.
		/// </summary>
		private readonly RecipientStateModel m_RecipientState;

		/// <summary>
		/// Статус сервера.
		/// </summary>
		public RecipientStatus Status => m_RecipientState.ServerStatus;



		/// <summary>
		/// Запустить сервер.
		/// </summary>
		private void Start(IRecipientState ServerState)
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
			m_RecipientState.Ip = IPEndPoint.Address.ToString();
			m_RecipientState.Port = IPEndPoint.Port.ToString();
			m_RecipientState.ServerStatus = RecipientStatus.Listen;

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
			m_RecipientState.ServerStatus = RecipientStatus.Stoped;

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
				catch (SocketException)
				{
					continue;
				}

				// Создаем контроллер взаимодействия с клиентом.
				ConnectionManagement _ClientController = ConnectionManagement.Instance(_Client);
				m_ListClients.Add(_ClientController);

				// Запустить взаимодействие с клиентом.
				// В отдельном потоке для быстрого приема нового клиента.
				new Thread(new ThreadStart(delegate () { _ClientController.ConnectionProcess(); })).Start();
			}
		}

		/// <summary>
		/// Событие: изменилось состояние сервера.
		/// </summary>
		private void EventServerStateShanged(object Sender, IRecipientState ServerState)
		{
			switch (Status)
			{
				case RecipientStatus.Stoped:
					Start(ServerState);
					break;
				case RecipientStatus.Listen:
					Stop();
					break;
				case RecipientStatus.Processing:
					break;
				default:
					throw
						new ArgumentException(
							"Необработанное состяние сервера для события {Изменить состояние сервера}.",
							"ServerStatus"
							);
			}
		}

		/// <summary>
		/// Отобразить состояние сервера.
		/// </summary>
		private void ViewServerState()
		{
			m_UIRecipient.ViewServerState(m_RecipientState);
		}

		/// <summary>
		/// Зарегистрировать визуальный интерфейс для взаимодействия.
		/// </summary>
		/// <param name="UIServerLocal">Визуальный интерфейс.</param>
		public void RegUI(IUIRecipient UIServerLocal)
		{
			m_UIRecipient = UIServerLocal;
			m_UIRecipient.EventServerStateShange += EventServerStateShanged;
			m_UIRecipient.ViewServerState(m_RecipientState);
		}
	}
}