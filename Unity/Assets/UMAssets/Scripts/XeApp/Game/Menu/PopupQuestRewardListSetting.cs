
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class PopupQuestRewardListSetting : PopupSetting
	{
		public enum Type
		{
			Receive = 0,
			PresentBox = 1,
			Confirm = 2,
			Undefined = 3,
		}

		public Type PopupType { get; set; } // 0x34
		public List<MFDJIFIIPJD> ItemList { get; set; } // 0x38
		public bool IsLimit { get; set; } // 0x3C
		public override string PrefabPath { get { return ""; } } //0x1611DA0
		public override string BundleName { get { return "ly/059.xab"; } } //0x1611DFC
		public override string AssetName { get { return "root_sel_que_pack_pop_layout_root"; } } //0x1611E58
		public override bool IsAssetBundle { get { return true; } } //0x1611EB4
		public override bool IsPreload { get { return false; } } //0x1611EBC
		public override GameObject Content { get { return m_content; } } //0x1611EC4

		//// RVA: 0x1611ECC Offset: 0x1611ECC VA: 0x1611ECC
		//public void SetContent(GameObject obj) { }
	}
}
