using UnityEngine;

namespace XeSys
{
	public class SceneAsyncLoader : MonoBehaviour
	{
		// Fields
		// [CompilerGeneratedAttribute] // RVA: 0x653164 Offset: 0x653164 VA: 0x653164
		// private string <sceneName>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x653174 Offset: 0x653174 VA: 0x653174
		// private bool <isLoaded>k__BackingField; // 0x10

		// Properties
		private string sceneName { get; set; }
		public bool isLoaded { get; set; }

		// Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6918AC Offset: 0x6918AC VA: 0x6918AC
		// // RVA: 0x239F224 Offset: 0x239F224 VA: 0x239F224
		// private string get_sceneName() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6918BC Offset: 0x6918BC VA: 0x6918BC
		// // RVA: 0x239F22C Offset: 0x239F22C VA: 0x239F22C
		// private void set_sceneName(string value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6918CC Offset: 0x6918CC VA: 0x6918CC
		// // RVA: 0x239F234 Offset: 0x239F234 VA: 0x239F234
		// public bool get_isLoaded() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6918DC Offset: 0x6918DC VA: 0x6918DC
		// // RVA: 0x239F23C Offset: 0x239F23C VA: 0x239F23C
		// private void set_isLoaded(bool value) { }

		// // RVA: 0x239F244 Offset: 0x239F244 VA: 0x239F244
		public static SceneAsyncLoader Create(string sceneName)
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0x239F308 Offset: 0x239F308 VA: 0x239F308
		// private void Awake() { }

		// // RVA: 0x239F314 Offset: 0x239F314 VA: 0x239F314
		// private void Start() { }

		// // RVA: 0x239F37C Offset: 0x239F37C VA: 0x239F37C
		// private void Update() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6918EC Offset: 0x6918EC VA: 0x6918EC
		// // RVA: 0x239F380 Offset: 0x239F380 VA: 0x239F380
		// private IEnumerator LoadLevel() { }

		// // RVA: 0x239F42C Offset: 0x239F42C VA: 0x239F42C
		// public void .ctor() { }
	}
}
