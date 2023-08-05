
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DegreeSetPopupSetting : PopupSetting
	{
		public IAPDFOPPGND data { get; set; } // 0x34
		public override string PrefabPath { get { return ""; } } //0x17CEC58
		public override string BundleName { get { return "ly/076.xab"; } } //0x17CECB4
		public override string AssetName { get { return "PopupDegreeSet"; } } //0x17CED10
		public override bool IsAssetBundle { get { return true; } } //0x17CED6C
		public override bool IsPreload { get { return true; } } //0x17CED74
		public override GameObject Content { get { return m_content; } } //0x17CED7C

		// RVA: 0x17CED84 Offset: 0x17CED84 VA: 0x17CED84
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}
	}
}
