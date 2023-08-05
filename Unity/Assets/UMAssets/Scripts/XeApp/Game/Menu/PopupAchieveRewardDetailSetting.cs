
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupAchieveRewardDetailSetting : PopupSetting
	{
		public List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> clearList; // 0x34
		public List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> scoreList; // 0x38
		public List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> comboList; // 0x3C
		public List<FPGEMAIAMBF_RewardData.LOIJICNJMKA> allList; // 0x40

		public override string PrefabPath { get { return ""; } } //0x132DC64
		public override string BundleName { get { return "ly/043.xab"; } } //0x132DCC0
		public override string AssetName { get { return "root_pop_reward_item_list_layout_root"; } } //0x132DD1C
		public override bool IsAssetBundle { get { return true; } } //0x132DD78
		public override bool IsPreload { get { return false; } } //0x132DD80
		public override GameObject Content { get { return m_content; } } //0x132DD88

		//// RVA: 0x132DD90 Offset: 0x132DD90 VA: 0x132DD90
		//public void SetContent(GameObject obj) { }
	}
}
