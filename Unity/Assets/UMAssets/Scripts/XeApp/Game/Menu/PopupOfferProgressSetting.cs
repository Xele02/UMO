
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOfferProgressSetting : PopupSetting
	{
		public HEFCLPGPMLK.AAOPGOGGMID m_view; // 0x34

		public override string PrefabPath { get { return ""; } } //0x169E454
		public override string BundleName { get { return "ly/143.xab"; } } //0x169E4B0
		public override string AssetName { get { return "root_sel_vfo_hsp_pop_layout_root"; } } //0x169E50C
		public override bool IsAssetBundle { get { return true; } } //0x169E568
		public override bool IsPreload { get { return false; } } //0x169E570
		public override GameObject Content { get { return m_content; } } //0x169E578

		//// RVA: 0x169E580 Offset: 0x169E580 VA: 0x169E580
		//public void SetContent(GameObject obj) { }
	}
}
