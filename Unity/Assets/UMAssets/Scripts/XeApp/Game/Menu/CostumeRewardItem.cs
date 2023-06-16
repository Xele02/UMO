using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using mcrs;

namespace XeApp.Game.Menu
{
	public class CostumeRewardItem : LayoutUGUIScriptBase
	{
		private CostumeUpgradeUtility.RewardIconLayoutSetting m_reward_icon; // 0x14
		private RawImageEx m_clear_icon; // 0x28
		private Text m_item_name; // 0x2C
		private Text m_item_num; // 0x30
		private AbsoluteLayout m_rank_num; // 0x34
		private StringBuilder m_work_sb = new StringBuilder(32); // 0x38
		[SerializeField] // RVA: 0x66B4B8 Offset: 0x66B4B8 VA: 0x66B4B8
		private ActionButton m_item_detail_button; // 0x3C
		private int m_diva_id; // 0x40
		private int m_costume_id; // 0x44
		private int m_costume_model_id; // 0x48

		// RVA: 0x1639B44 Offset: 0x1639B44 VA: 0x1639B44 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t1 = transform.Find("sw_reward_list (AbsoluteLayout)");
			m_item_name = t1.Find("item_name_01 (TextView)").GetComponent<Text>();
			m_item_num = t1.Find("item_number_01 (TextView)").GetComponent<Text>();
			m_rank_num = layout.FindViewByExId("sw_reward_list_swtbl_star_num") as AbsoluteLayout;
			Transform t2 = t1.Find("sw_cos_item_anim_03 (AbsoluteLayout)");
			m_reward_icon.item_image = t2.Find("cos_item_02 (AbsoluteLayout)/cmn_ep_item_icon_02 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_reward_icon.item_type = layout.FindViewById("swtbl_item_type") as AbsoluteLayout;
			m_reward_icon.diva_image = t2.Find("cos_item_02 (AbsoluteLayout)/chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_clear_icon = t2.Find("sel_ep_clear_icon (AbsoluteLayout)/sel_ep_clear_icon (ImageView)").GetComponent<RawImageEx>();
			t1.Find("sel_ep_clear_icon (ImageView)").GetComponent<RawImageEx>().enabled = false;
			Loaded();
			return true;
		}

		// RVA: 0x1639F4C Offset: 0x1639F4C VA: 0x1639F4C
		public void SetItem(LFAFJCNKLML data, int rank, bool clear, int divaId, int costumeId, int costumeModelId)
		{
			m_diva_id = divaId;
			m_costume_id = costumeId;
			m_costume_model_id = costumeModelId;
			LFAFJCNKLML.GFIPDFPIKIJ a;
			LFAFJCNKLML.HKKKKFLBFJN(data, rank, out a, LFAFJCNKLML.EJOEMKJOCMH.CCAPCGPIIPF/*0*/);
			m_item_name.text = a.AKNGHELNIHO_ItemName;
			m_item_num.text = a.BONMCBFDMJE_ItemNum;
			m_rank_num.StartChildrenAnimGoStop(rank, rank);
			m_clear_icon.enabled = clear;
			CostumeUpgradeUtility.SettingRewardIcon(data, a.GLCLFMGPMAN_ItemId, rank, a.NANNGLGOFKH_Value, m_reward_icon, null);
			m_item_detail_button.AddOnClickCallback(() =>
			{
				//0x163A2E8
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				CostumeUpgradeUtility.ShowItemDetailWindow(data, rank, transform);
			});
		}
	}
}
