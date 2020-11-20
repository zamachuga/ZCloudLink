using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibFunctional
{
	/// <summary>
	/// Функционал работы с рефлексией.
	/// </summary>
	public static class FuncReflection
	{
		/// <summary>
		/// Получить объект из сборки.
		/// </summary>
		/// TODO: метод с большой ответственностью.
		public static T GetObject<T>(string MethodInstance, string AssemblyName, object[] ParametersInvoke)
		{
			// Что нам надо из сборки.
			string _MethodInstance = MethodInstance;
			string _AssemblyName = AssemblyName;
			T _Object = default;

			// Загружаем сборку (если еще не загружена) и получаем сборку.
			AppDomain.CurrentDomain.Load(_AssemblyName);

			Assembly _Assembly = AppDomain.CurrentDomain.GetAssemblies()
				.Where(x => x.GetName().Name == _AssemblyName)
				.FirstOrDefault()
			;

			if (_Assembly == null)
				throw new ArgumentException($"Не загружена сборка {{{_AssemblyName}}}.", "AssemblyName");

			// Ищем реализацию нашего метода.
			Type _CurrentType = _Assembly.GetTypes().
				Where(x => x.GetInterface(typeof(T).Name) != null)
				.FirstOrDefault()
			;

			if (_CurrentType != null)
			{
				MethodInfo _MethodInfo = _CurrentType.GetMethod(_MethodInstance, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

				if (_MethodInfo == null)
					throw new ArgumentException($"Не обнаружен метод для инициализации объекта.", "MethodInstance");

				_Object = (T)_MethodInfo.Invoke(null, ParametersInvoke);
			}

			return _Object;
		}
	}
}