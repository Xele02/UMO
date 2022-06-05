using UnityEngine;

namespace XeSys
{
	public class SingletonBehaviour<T> : MonoBehaviour where T : class
	{
		// Fields
		private static T mInstance; // 0x0

		// Properties
		public static T Instance { get
		{
			if(mInstance == null)
			{
				mInstance = Object.FindObjectOfType(typeof(T)) as T;
			}
			return mInstance;
		} }
		// // RVA: -1 Offset: -1
		// public static T get_Instance() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A6E60 Offset: 0x30A6E60 VA: 0x30A6E60
		// |-SingletonBehaviour<object>.get_Instance
		// |-SingletonBehaviour<SoundController>.get_Instance
		// |-SingletonBehaviour<Database>.get_Instance
		// |-SingletonBehaviour<CheatFunction>.get_Instance
		// |-SingletonBehaviour<BasicTutorialManager>.get_Instance
		// |-SingletonBehaviour<TutorialManager>.get_Instance
		// */

		public static bool HasInstanced{ get{
			return mInstance != null;
		} }
		// // RVA: -1 Offset: -1
		// public static bool get_HasInstanced() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A7140 Offset: 0x30A7140 VA: 0x30A7140
		// |-SingletonBehaviour<object>.get_HasInstanced
		// |-SingletonBehaviour<BasicTutorialManager>.get_HasInstanced
		// |-SingletonBehaviour<TutorialManager>.get_HasInstanced
		// */

		// // RVA: -1 Offset: -1 Slot: 4
		protected virtual void Awake()
		{
			CheckInstance();
		}
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A7204 Offset: 0x30A7204 VA: 0x30A7204
		// |-SingletonBehaviour<object>.Awake
		// |-SingletonBehaviour<AssetBundleManager>.Awake
		// |-SingletonBehaviour<SoundController>.Awake
		// |-SingletonBehaviour<Database>.Awake
		// |-SingletonBehaviour<DebugCheatMenu>.Awake
		// |-SingletonBehaviour<DebugTouchScreenArea>.Awake
		// |-SingletonBehaviour<CheatFunction>.Awake
		// |-SingletonBehaviour<BasicTutorialManager>.Awake
		// |-SingletonBehaviour<TutorialManager>.Awake
		// |-SingletonBehaviour<RenderManager>.Awake
		// */

		// // RVA: -1 Offset: -1
		protected bool CheckInstance()
		{
			if(mInstance != this)
			{
				if(mInstance == null)
				{
					mInstance = this as T;
				}
				else
				{
					Destroy(gameObject);
					return false;
				}
			}
			return true;
		}
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A7240 Offset: 0x30A7240 VA: 0x30A7240
		// |-SingletonBehaviour<object>.CheckInstance
		// */

		// // RVA: -1 Offset: -1 Slot: 5
		protected virtual void OnDestroy()
		{
			if(mInstance != null)
				mInstance = null;
		}
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A74A0 Offset: 0x30A74A0 VA: 0x30A74A0
		// |-SingletonBehaviour<object>.OnDestroy
		// |-SingletonBehaviour<AssetBundleManager>.OnDestroy
		// |-SingletonBehaviour<SoundController>.OnDestroy
		// |-SingletonBehaviour<Database>.OnDestroy
		// |-SingletonBehaviour<DebugCheatMenu>.OnDestroy
		// |-SingletonBehaviour<DebugTouchScreenArea>.OnDestroy
		// |-SingletonBehaviour<CheatFunction>.OnDestroy
		// |-SingletonBehaviour<BasicTutorialManager>.OnDestroy
		// |-SingletonBehaviour<TutorialManager>.OnDestroy
		// |-SingletonBehaviour<RenderManager>.OnDestroy
		// */

	}
}
