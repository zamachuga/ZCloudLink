using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LibFunctional
{
	/// <summary>
	/// Функционал сериализации.
	/// </summary>
	public static class FuncSerialize
	{
		/// <summary>
		/// Сериализовать объект в байты.
		/// </summary>
		/// <remarks>
		/// Режим сериализации подбирается автоматически.
		/// </remarks>
		public static byte[] Serialize<T>(T Object) where T : class
		{
			/// Может в будущем будет какой-то конфиг в библиотеки, 
			/// для локальных настроек и т.п..
			/// 
			return SerializeJB64ObjToByte(Object);
		}

		/// <summary>
		/// Сериализовать объект в байты.
		/// </summary>
		/// <remarks>
		/// MB - MemoryStream & BinaryFormatter.
		/// </remarks>
		public static byte[] SerializeMBObjToByte<T>(T Object) where T : class
		{
			MemoryStream _MemoryStream = new MemoryStream();

			BinaryFormatter _BinaryFormatter = new BinaryFormatter();
			_BinaryFormatter.Serialize(_MemoryStream, Object);

			byte[] _Byte = _MemoryStream.ToArray();
			_MemoryStream.Close();

			return _Byte;
		}

		/// <summary>
		/// Сериализовать объект в байты.
		/// </summary>
		/// <remarks>
		/// JB64 - JsonConvert & Base64.
		/// </remarks>
		public static byte[] SerializeJB64ObjToByte<T>(T Object) where T : class
		{
			string _DataString = JsonConvert.SerializeObject(Object);
			byte[] _DataBytes = Convert.FromBase64String(_DataString);

			return _DataBytes;
		}

		/// <summary>
		/// Десериализовать массив байт в объект.
		/// </summary>
		/// <remarks>
		/// Режим десериализации подбирается автоматически.
		/// </remarks>
		public static T Deserialize<T>(byte[] Byte) where T : class
		{
			/// Может в будущем будет какой-то конфиг в библиотеки, 
			/// для локальных настроек и т.п..
			/// 
			return DeserializeJB64ObjToByte<T>(Byte);
		}

		/// <summary>
		/// Десериализовать массив байт в объект.
		/// </summary>
		/// <remarks>
		/// MB - MemoryStream & BinaryFormatter.
		/// </remarks>
		public static T DeserializeMBObjToByte<T>(byte[] Byte) where T : class
		{
			MemoryStream _MemoryStream = new MemoryStream(Byte);

			BinaryFormatter _BinaryFormatter = new BinaryFormatter();
			T _Object = _BinaryFormatter.Deserialize(_MemoryStream) as T;

			return _Object;
		}

		/// <summary>
		/// Десериализовать массив байт в объект.
		/// </summary>
		/// <remarks>
		/// JB64 - JsonConvert & Base64.
		/// </remarks>
		public static T DeserializeJB64ObjToByte<T>(byte[] Byte) where T : class
		{
			string _DataString = Convert.ToBase64String(Byte);
			T _DataObject = JsonConvert.DeserializeObject<T>(_DataString);

			return _DataObject;
		}
	}
}