
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class EpisodeRewardPopupSetting : PopupSetting
	{
		public int episodeId { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0xF02B24
		public override string BundleName { get { return "ly/052.xab"; } } //0xF02B80
		public override string AssetName { get { return "PopupEpisodeReward"; } } //0xF02BDC
		public override bool IsAssetBundle { get { return true; } } //0xF02C38
		public override bool IsPreload { get { return true; } } //0xF02C40
		public override GameObject Content { get { return m_content; } } //0xF02C48

		//// RVA: 0xF02C50 Offset: 0xF02C50 VA: 0xF02C50
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6DBB0C Offset: 0x6DBB0C VA: 0x6DBB0C
		//// RVA: 0xF02C58 Offset: 0xF02C58 VA: 0xF02C58 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0xF02D2C
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<EpisodeRewardWindow>().CreateItemIcon());
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6DBB84 Offset: 0x6DBB84 VA: 0x6DBB84
		//[CompilerGeneratedAttribute] // RVA: 0x6DBB84 Offset: 0x6DBB84 VA: 0x6DBB84
		//// RVA: 0xF02D20 Offset: 0xF02D20 VA: 0xF02D20
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
