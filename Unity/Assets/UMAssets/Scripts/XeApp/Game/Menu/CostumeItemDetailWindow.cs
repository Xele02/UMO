using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CostumeItemDetailWindow : LayoutUGUIScriptBase
	{
		private Text m_itemNameText; // 0x14
		private Text m_explanationText; // 0x18
		private CostumeUpgradeUtility.RewardIconLayoutSetting m_rewardIcon; // 0x1C

		// RVA: 0x1630058 Offset: 0x1630058 VA: 0x1630058 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t1 = transform.Find("sw_item_detail (AbsoluteLayout)");
			m_itemNameText = t1.Find("itemname (TextView)").GetComponent<Text>();
			m_explanationText = t1.Find("explanation (TextView)").GetComponent<Text>();
			m_rewardIcon.item_image = t1.Find("swtexc_cmn_item_1 (ImageView)").GetComponent<RawImageEx>();
			m_rewardIcon.diva_image = t1.Find("chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_rewardIcon.item_type = layout.FindViewById("swtbl_item_type") as AbsoluteLayout;
			m_rewardIcon.get_num = t1.Find("swtbl_item_type (AbsoluteLayout)/swnum_item_num01 (AbsoluteLayout)").GetComponent<NumberBase>();
			m_rewardIcon.item_rank = null;
			return true;
		}

		// RVA: 0x1630338 Offset: 0x1630338 VA: 0x1630338
		public void Initialize(LFAFJCNKLML data, int lv)
		{
			LFAFJCNKLML.GFIPDFPIKIJ a;
			LFAFJCNKLML.HKKKKFLBFJN(data, lv, out a, LFAFJCNKLML.EJOEMKJOCMH.LLCLFAACPLH/*2*/);
			CostumeUpgradeUtility.SettingRewardIcon(data, a.GLCLFMGPMAN_ItemId, lv, a.NANNGLGOFKH_Value, m_rewardIcon, null);
			m_itemNameText.text = a.AKNGHELNIHO_ItemName;
			m_explanationText.text = a.IDCPALBPNFB_Explanation;
		}
	}
}
