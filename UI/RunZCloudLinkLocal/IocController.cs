using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibInterfaces.Recipient;
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

		// *
		private static IocController m_Controller;



		// *
		internal static IKernel IocKernel => Instance().KernelInstance;



		// *
		public override void Load()
		{
			Bind<IRecipient>()
				.ToMethod(Context => FuncReflection.GetObject<IRecipient>(MethodInstance: "Instance", AssemblyName: "LibTcpPackages", ParametersInvoke: null))
				.InSingletonScope();

			Bind<IUIRecipient>()
				.ToMethod(Context => FuncReflection.GetObject<IUIRecipient>(MethodInstance: "Instance", AssemblyName: "UIServer", ParametersInvoke: null))
				.InSingletonScope();
		}
	}
}
