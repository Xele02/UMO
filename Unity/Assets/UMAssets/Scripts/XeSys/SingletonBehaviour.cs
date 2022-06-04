using UnityEngine;

namespace XeSys
{
	public class SingletonBehaviour<T> : MonoBehaviour
	{
		// Fields
		private static T mInstance; // 0x0

		// Properties
		public static T Instance { get; }
		public static bool HasInstanced { get; }

		// // Methods

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
		// protected virtual void Awake() { }
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
		// protected bool CheckInstance() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A7240 Offset: 0x30A7240 VA: 0x30A7240
		// |-SingletonBehaviour<object>.CheckInstance
		// */

		// // RVA: -1 Offset: -1 Slot: 5
		// protected virtual void OnDestroy() { }
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

		// // RVA: -1 Offset: -1
		// protected void .ctor() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x30A7584 Offset: 0x30A7584 VA: 0x30A7584
		// |-SingletonBehaviour<object>..ctor
		// |-SingletonBehaviour<AssetBundleManager>..ctor
		// |-SingletonBehaviour<SoundController>..ctor
		// |-SingletonBehaviour<Database>..ctor
		// |-SingletonBehaviour<DebugCheatMenu>..ctor
		// |-SingletonBehaviour<DebugTouchScreenArea>..ctor
		// |-SingletonBehaviour<CheatFunction>..ctor
		// |-SingletonBehaviour<BasicTutorialManager>..ctor
		// |-SingletonBehaviour<TutorialManager>..ctor
		// |-SingletonBehaviour<RenderManager>..ctor
		// */
	}
}
