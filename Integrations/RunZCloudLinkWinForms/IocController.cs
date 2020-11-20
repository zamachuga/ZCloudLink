using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibInterfaces.Server.Local;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using LibFunctional;

namespace RunZCloudLinkWinForms
{
	/// <summary>
	/// Контроллер взаимодействия с IoC.
	/// </summary>
	class IocController : NinjectModule
	{
		/// <summary>
		/// Инициализировать контроллер IoC.
		/// </summary>
		private IocController()
		{
			new StandardKernel(this);
		}

		/// <summary>
		/// Инициализировать контроллер IoC.
		/// </summary>
		private static IocController Instance()
		{
			if (m_Controller != null)
				return m_Controller;

			m_Controller = new IocController();
			return m_Controller;
		}

		private static IocController m_Controller;



		internal static IKernel IocKernel => Instance().KernelInstance;



		public override void Load()
		{
			Bind<IServerLocal>()
				.ToMethod(Context => FuncReflection.GetObject<IServerLocal>(MethodInstance: "Instance", AssemblyName: "ServerLocal", ParametersInvoke: null))
				.InSingletonScope();

			Bind<IUIServerLocal>()
				.ToMethod(Context => FuncReflection.GetObject<IUIServerLocal>(MethodInstance: "Instance", AssemblyName: "UIServer", ParametersInvoke: null))
				.InSingletonScope();
		}
	}
}
