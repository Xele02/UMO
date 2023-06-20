
using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class EpisodeAchievPopupSetting : PopupSetting
	{
		public Action openEvent; // 0x38

		public MFDJIFIIPJD data { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x12751EC
		public override string BundleName { get { return "ly/052.xab"; } } //0x1275248
		public override string AssetName { get { return "PopupEpisodeAchiev"; } } //0x12752A4
		public override bool IsAssetBundle { get { return true; } } //0x1275300
		public override bool IsPreload { get { return true; } } //0x1275308
		public override GameObject Content { get { return m_content; } } //0x1275310

		//// RVA: 0x1275318 Offset: 0x1275318 VA: 0x1275318
		//public void SetContent(GameObject obj) { }
	}
}
