using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutUGUIScriptBase : MonoBehaviour
	{
		// [CompilerGeneratedAttribute] // RVA: 0x653D74 Offset: 0x653D74 VA: 0x653D74
		// private LayoutUGUIScriptBase.LoadedCallback loadedEvent; // 0xC
		private bool isLoaded; // 0x10

		// // RVA: 0x1F045B0 Offset: 0x1F045B0 VA: 0x1F045B0 Slot: 5
		// public virtual bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		// [CompilerGeneratedAttribute] // RVA: 0x692868 Offset: 0x692868 VA: 0x692868
		// // RVA: 0x1F046F4 Offset: 0x1F046F4 VA: 0x1F046F4
		// private void add_loadedEvent(LayoutUGUIScriptBase.LoadedCallback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x692878 Offset: 0x692878 VA: 0x692878
		// // RVA: 0x1F04800 Offset: 0x1F04800 VA: 0x1F04800
		// private void remove_loadedEvent(LayoutUGUIScriptBase.LoadedCallback value) { }

		// // RVA: 0x1F045C4 Offset: 0x1F045C4 VA: 0x1F045C4
		// public void ClearLoadedCallback() { }

		// // RVA: 0x1F04920 Offset: 0x1F04920 VA: 0x1F04920
		// public void AddLoadedCallback(LayoutUGUIScriptBase.LoadedCallback loadedEvent) { }

		// // RVA: 0x1F04924 Offset: 0x1F04924 VA: 0x1F04924
		// public void RemoveLoadedCallback(LayoutUGUIScriptBase.LoadedCallback loadedEvent) { }

		// // RVA: 0x1F04928 Offset: 0x1F04928 VA: 0x1F04928
		public bool IsLoaded()
		{
			return isLoaded;
		}

		// // RVA: 0x1F04930 Offset: 0x1F04930 VA: 0x1F04930
		// protected void Loaded() { }

		// // RVA: 0x1EF8B3C Offset: 0x1EF8B3C VA: 0x1EF8B3C
		public LayoutUGUIScriptBase()
		{
			UnityEngine.Debug.LogWarning("TODO LayoutUGUIScriptBase");
		}
	}
}
