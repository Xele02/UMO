
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class RankRangePopupSetting : PopupSetting
	{
		public List<string> itemLabels { get; set; } // 0x34
		public int initialLabelIndex { get; set; } // 0x38
		public Action<int> onDecideIndex { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0xCF249C
		public override string BundleName { get { return "ly/039.xab"; } } //0xCF24F8
		public override string AssetName { get { return "PopupRankRange"; } } //0xCF2554
		public override bool IsAssetBundle { get { return true; } } //0xCF25B0
		public override bool IsPreload { get { return true; } } //0xCF25B8

		//// RVA: 0xCF25C0 Offset: 0xCF25C0 VA: 0xCF25C0
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
