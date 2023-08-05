
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupConfigDetailSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0x133FBC0
		public override string BundleName { get { return "ly/072.xab"; } } //0x133FC1C
		public override string AssetName { get { return "root_cmn_con_detail_pop_layout_root"; } } //0x133FC78
		public override bool IsAssetBundle { get { return true; } } //0x133FCD4
		public override bool IsPreload { get { return false; } } //0x133FCDC
		public override GameObject Content { get { return m_content; } } //0x133FCE4

		//// RVA: 0x133FCEC Offset: 0x133FCEC VA: 0x133FCEC
		//public void SetContent(GameObject obj) { }
	}
}
