
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAddEpisodeScrollSetting : PopupSetting
	{
		public PopupAddEpisodeContentSetting m_setting; // 0x3C

		public List<int> EpisodeIds { get; set; } // 0x34
		public LayoutPopupAddEpisode.Type Type { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x132F954
		public override string BundleName { get { return "ly/057.xab"; } } //0x132F9B0
		public override string AssetName { get { return "root_pop_ep2_layout_root"; } } //0x132FA0C
		//public virtual string ListItemAssetName { get; } 0x132FA68
		//public virtual string PopupItemAssetName { get; } 0x132FAC4
		public override bool IsAssetBundle { get { return true; } } //0x132FB20
		public override bool IsPreload { get { return true; } } //0x132FB28
		public override GameObject Content { get { return m_content; } } //0x132FB30

		//// RVA: 0x132FB38 Offset: 0x132FB38 VA: 0x132FB38
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x70CE84 Offset: 0x70CE84 VA: 0x70CE84
		//								// RVA: 0x132FB40 Offset: 0x132FB40 VA: 0x132FB40 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			TodoLogger.Log(0, "LoadAssetBundlePrefab");
			yield return base.LoadAssetBundlePrefab(parent);
		}

		//[CompilerGeneratedAttribute] // RVA: 0x70CEFC Offset: 0x70CEFC VA: 0x70CEFC
		//[DebuggerHiddenAttribute] // RVA: 0x70CEFC Offset: 0x70CEFC VA: 0x70CEFC
		//						  // RVA: 0x132FC10 Offset: 0x132FC10 VA: 0x132FC10
		//private IEnumerator<> n__0(Transform parent) { }
	}
}
