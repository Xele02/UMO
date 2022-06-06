using UnityEngine;

namespace XeSys
{
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : UnityEngine.Object
	{
		private static T mInstance; // 0x0
		private static bool mApplicationIsQuitting; // 0x0

		public static T Instance { get
		{
			if(mInstance == null)
			{
				T exist = FindObjectOfType(typeof(T)) as T;
				if(exist != null)
					mInstance = exist;
			}
			if(mInstance == null)
			{
				GameObject go = new GameObject();
				mInstance = go.AddComponent(typeof(T)) as T;
				go.name = "(singleton)"+typeof(T).ToString();
			}
			return mInstance;
		} }

		// RVA: -1 Offset: -1
		/* GenericInstMethod :
		|
		|-RVA: 0x30A75B0 Offset: 0x30A75B0 VA: 0x30A75B0
		|-SingletonMonoBehaviour<ManaAdAPIHelper>.get_Instance
		|-SingletonMonoBehaviour<object>.get_Instance
		|-SingletonMonoBehaviour<TipsControl>.get_Instance
		|-SingletonMonoBehaviour<IdleProcessManager>.get_Instance
		|-SingletonMonoBehaviour<ResourcesManager>.get_Instance
		*/

		// RVA: -1 Offset: -1
		public static void Release()
		{
			UnityEngine.Debug.LogError("TODO");
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x30A80C4 Offset: 0x30A80C4 VA: 0x30A80C4
		|-SingletonMonoBehaviour<object>.Release
		*/

		// RVA: -1 Offset: -1
		private void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO");
		}
		/* GenericInstMethod :
		|
		|-RVA: 0x30A8260 Offset: 0x30A8260 VA: 0x30A8260
		|-SingletonMonoBehaviour<object>.OnDestroy
		*/

		// RVA: -1 Offset: -1
		/* GenericInstMethod :
		|
		|-RVA: 0x30A831C Offset: 0x30A831C VA: 0x30A831C
		|-SingletonMonoBehaviour<ManaAdAPIHelper>..ctor
		|-SingletonMonoBehaviour<object>..ctor
		|-SingletonMonoBehaviour<TipsControl>..ctor
		|-SingletonMonoBehaviour<IdleProcessManager>..ctor
		|-SingletonMonoBehaviour<ResourcesManager>..ctor
		*/

		// RVA: -1 Offset: -1
		/* GenericInstMethod :
		|
		|-RVA: 0x30A8348 Offset: 0x30A8348 VA: 0x30A8348
		|-SingletonMonoBehaviour<object>..cctor
		*/
	}
}
