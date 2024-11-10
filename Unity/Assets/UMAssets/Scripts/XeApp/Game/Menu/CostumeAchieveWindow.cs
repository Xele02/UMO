using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	internal class CostumeAchieveWindow : LayoutUGUIScriptBase
	{
		private LFAFJCNKLML m_data; // 0x14
		private AbsoluteLayout m_rewardType; // 0x18
		private CostumeUpgradeUtility.RewardIconLayoutSetting m_rewardIcon; // 0x1C
		private Text m_rewardText; // 0x30
		public SimpleVoicePlayer m_voicePlayer; // 0x34

		// RVA: 0x1B65D9C Offset: 0x1B65D9C VA: 0x1B65D9C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_rewardType = layout.FindViewById("swtbl_reward_pop") as AbsoluteLayout;
			Transform t = transform.Find("swtbl_reward_pop (AbsoluteLayout)");
			m_rewardIcon.item_image = t.Find("item_icon_01 (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_rewardIcon.diva_image = t.Find("chara_icon_01 (AbsoluteLayout)/swtexc_cmn_chara_icon (ImageView)").GetComponent<RawImageEx>();
			m_rewardIcon.item_type = layout.FindViewById("swtbl_item_type") as AbsoluteLayout;
			m_rewardIcon.get_num = null;
			m_rewardText = t.Find("item_name (AbsoluteLayout)/item_name_01 (TextView)").GetComponent<Text>();
			return true;
		}

		// RVA: 0x1B66058 Offset: 0x1B66058 VA: 0x1B66058
		public void Initialize(LFAFJCNKLML data, SimpleVoicePlayer voicePlayer)
		{
			int[] array = new int[7] { -1, 2, 0, 0, 1, 3, 4 };
			CostumeUpgradeVoiceDataTable.VoiceType[] array2 = new CostumeUpgradeVoiceDataTable.VoiceType[7] 
			{
				CostumeUpgradeVoiceDataTable.VoiceType.Num,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetCostumeLvUp,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetItem,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetItem,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetCostumeColor,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetStatusUp_SubPlate,
				CostumeUpgradeVoiceDataTable.VoiceType.RewardGetStatusUp_SubPlate
			};
			m_data = data;
			int start = array[(int)m_data.JHLKLPEHHCD_GetCurrentLevelInfo().PEEAGFNOFFO_UnlockType];
			if(m_data.JHLKLPEHHCD_GetCurrentLevelInfo().PEEAGFNOFFO_UnlockType == LCLCCHLDNHJ_Costume.FPDJGDGEBNG_UnlockType.NKKIKONDGPF_1_CostumeEffect)
			{
				string s = "";
				string s2 = "";
				m_data.OHGOPFEOJOG_GetSkillInfo(m_data.GKIKAABHAAD_Level - 1, ref s, ref s2);
				if(s == TextConstant.InvalidText)
				{
					start = 5;
				}
			}
			m_rewardType.StartChildrenAnimGoStop(start, start);
			LFAFJCNKLML.GFIPDFPIKIJ g;
			LFAFJCNKLML.HKKKKFLBFJN(m_data, data.GKIKAABHAAD_Level, out g, LFAFJCNKLML.EJOEMKJOCMH.HHJFDNIPODD_1);
			CostumeUpgradeUtility.SettingRewardIcon(m_data, g.GLCLFMGPMAN_ItemId, m_data.GKIKAABHAAD_Level, g.NANNGLGOFKH_Value, m_rewardIcon, null);
			m_rewardText.text = g.AKNGHELNIHO_ItemName + g.BONMCBFDMJE_ItemNum;
			voicePlayer.PlayVoiceRandom(CostumeUpgradeVoiceDataTable.VoiceSetting(array2[(int)m_data.JHLKLPEHHCD_GetCurrentLevelInfo().PEEAGFNOFFO_UnlockType], 1), -1);
		}
	}
}
