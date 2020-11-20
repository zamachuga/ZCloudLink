using LibInterfaces.Server.Local;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunZCloudLinkWinForms
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		/// <remarks>
		/// По своей сути это приложение является связующим звеном.
		/// Происходит инициализация всех отдельно существующих компонентов, 
		/// связывание между собой и запуск.
		/// </remarks>
		[STAThread]
		static void Main()
		{
			// Настройки.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Главная форма приложения.
			// Инициализация компонентов.
			Form _GeneralForm = InitComponents();

			// Запуск приложения.
			Application.Run(_GeneralForm);
		}

		/// <summary>
		/// Инициализация компонентов.
		/// </summary>
		/// <returns>Форма для старта приложения.</returns>
		private static Form InitComponents()
		{
			// Получим компоненты.
			IServerLocal _ServerLocal = IocController.IocKernel.Get<IServerLocal>();
			IUIServerLocal _UIServerLocal = IocController.IocKernel.Get<IUIServerLocal>();

			// Регистрация взаимодействия сервера и визуальной части.
			_ServerLocal.RegUI(_UIServerLocal);

			return _UIServerLocal.GeneralForm;
		}
	}
}