using LibInterfaces.Server.Local;
using NUnit.Framework;

namespace LibFunctional.Tests
{
	[TestFixture()]
	public class FuncReflectionTests
	{
		[Test()]
		public void GetObjectIServerLocalTest()
		{
			var _Object = FuncReflection
				.GetObject<IServerLocal>(MethodInstance: "Instance", AssemblyName: "ServerLocal", ParametersInvoke: null);

			Assert.NotNull(_Object);
		}

		[Test()]
		public void GetObjectIUIServerLocalTest()
		{
			var _Object = FuncReflection
				.GetObject<IUIServerLocal>(MethodInstance: "Instance", AssemblyName: "UIServer", ParametersInvoke: null);

			Assert.NotNull(_Object);
		}
	}
}