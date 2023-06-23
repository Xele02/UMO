
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenListPopupSetting : PopupSetting
	{
		//private CCAAJNJGNDO m_storyData; // 0x38
		private int m_unlockStoryCount; // 0x3C

		public override string PrefabPath { get { return ""; } } //0xB944FC
		public override string BundleName { get { return "ly/117.xab"; } } //0xB94560
		public override string AssetName { get { return "root_sel_event_story_ul_pop_layout_root"; } } //0xB945BC
		public override bool IsAssetBundle { get { return true; } } //0xB94618
		public override bool IsPreload { get { return false; } } //0xB94620
		public override GameObject Content { get { return m_content; } } //0xB94628
		public bool IsShowStoryIcon { get; set; } // 0x34
		//public CCAAJNJGNDO StoryData { get; } 0xB94354
		//public int UnlockStoryCount { get; } 0xB9435C

		//// RVA: 0xB94638 Offset: 0xB94638 VA: 0xB94638
		//public void Set(CCAAJNJGNDO viewStoryData, int unlockStoryCount, bool isShowStoryIcon) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DBE54 Offset: 0x6DBE54 VA: 0x6DBE54
		//// RVA: 0xB94648 Offset: 0xB94648 VA: 0xB94648 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return null;
		}

		//[CompilerGeneratedAttribute] // RVA: 0x6DBECC Offset: 0x6DBECC VA: 0x6DBECC
		//[DebuggerHiddenAttribute] // RVA: 0x6DBECC Offset: 0x6DBECC VA: 0x6DBECC
		//// RVA: 0xB94718 Offset: 0xB94718 VA: 0xB94718
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
