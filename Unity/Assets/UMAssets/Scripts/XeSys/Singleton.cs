using System;

namespace XeSys
{
	public abstract class Singleton<T> where T : IDisposable
	{
		protected static T instance; // 0x0

		public static T Instance { get { return instance; } } // get_Instance

		// RVA: -1 Offset: -1
		/* GenericInstMethod :
		|
		|-RVA: 0x30A834C Offset: 0x30A834C VA: 0x30A834C
		|-Singleton<PBJPACKDIIB>.get_Instance
		|-Singleton<object>.get_Instance
		|-Singleton<MessageLoader>.get_Instance
		|-Singleton<DebugParam>.get_Instance
		|-Singleton<ConfigManager>.get_Instance
		|-Singleton<FileLoader>.get_Instance
		|-Singleton<MessageManager>.get_Instance
		*/

		// RVA: -1 Offset: -1
		public static T Create()
		{
			if(instance == null)
			{
				instance = Activator.CreateInstance<T>();
			}
			return instance;
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x30A8394 Offset: 0x30A8394 VA: 0x30A8394
		|-Singleton<PBJPACKDIIB>.Create
		|-Singleton<object>.Create
		|-Singleton<MessageLoader>.Create
		|-Singleton<ConfigManager>.Create
		|-Singleton<FileLoader>.Create
		|-Singleton<MessageManager>.Create
		*/

		// RVA: -1 Offset: -1
		public static void Release()
		{
			instance.Dispose();
			instance = default(T);
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x30A84B0 Offset: 0x30A84B0 VA: 0x30A84B0
		|-Singleton<object>.Release
		|-Singleton<ConfigManager>.Release
		*/
	}

}
