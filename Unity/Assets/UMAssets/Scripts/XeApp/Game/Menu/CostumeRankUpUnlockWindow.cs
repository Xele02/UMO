using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys;
using System.Collections.Generic;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	internal class CostumeRankUpUnlockWindow : LayoutUGUIScriptBase
	{
		private enum ConditionTableType
		{
			Item = 0,
			Condition = 1,
			ItemAndCondition = 2,
		}

		private AbsoluteLayout m_condition; // 0x14
		private Text m_item_text; // 0x18
		private Text m_item_text2; // 0x1C
		private Text m_item_have_num; // 0x20
		private RawImageEx m_item_image; // 0x24
		private NumberBase m_item_need_num; // 0x28
		[SerializeField] // RVA: 0x66B478 Offset: 0x66B478 VA: 0x66B478
		private ActionButton m_item_button; // 0x2C
		private int m_itemId; // 0x30
		private int m_itemCount; // 0x34
		private Text m_condition_text; // 0x38
		private Text m_condition_text2; // 0x3C
		private AbsoluteLayout m_rank_up_anim; // 0x40
		private int m_rank; // 0x48
		private CostumeUpgradeUtility.CostumeData m_costume = new CostumeUpgradeUtility.CostumeData(); // 0x4C

		public bool m_isPlayingRankUnlockAnimation { get; private set; } // 0x44

		// RVA: 0x1634A84 Offset: 0x1634A84 VA: 0x1634A84 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Transform t = transform.Find("swtbl_condition_pop (AbsoluteLayout)");
			m_condition = layout.FindViewById("swtbl_condition_pop") as AbsoluteLayout;
			m_costume.image = t.Find("sw_c_b_terms_anim (AbsoluteLayout)/swtbl_cos_01 (AbsoluteLayout)/cos_01_001 (AbsoluteLayout)/cos_01_001 (ImageView)").GetComponent<RawImageEx>();
			m_costume.rank.num = layout.FindViewById("swtbl_star_num_02") as AbsoluteLayout;
			m_costume.rank.enable = new List<AbsoluteLayout>();
			m_costume.rank.rank_unlock_num = layout.FindViewById("swtbl_star_num_03") as AbsoluteLayout;
			m_costume.rank.rank_unlock_anim = new List<AbsoluteLayout>();
			for(int i = 0; i < 6; i++)
			{
				m_costume.rank.enable.Add(layout.FindViewByExId("swtbl_star_num_02_swbtl_star_on_off_0" + (i + 1).ToString()) as AbsoluteLayout);
				m_costume.rank.rank_unlock_anim.Add(layout.FindViewByExId("swtbl_star_num_03_swbtl_star_on_off_0" + (i + 1).ToString()) as AbsoluteLayout);
			}
			m_item_image = t.Find("sw_pop_useitem (AbsoluteLayout)/sw_btn_item_anim (AbsoluteLayout)/sw_item_frm_anim (AbsoluteLayout)/cmn_item (AbsoluteLayout)/swtexc_cmn_item (ImageView)").GetComponent<RawImageEx>();
			m_item_need_num = t.Find("sw_pop_useitem (AbsoluteLayout)/sw_btn_item_anim (AbsoluteLayout)/swnum_pop_item (AbsoluteLayout)").GetComponent<NumberBase>();
			m_item_have_num = t.Find("sw_pop_useitem (AbsoluteLayout)/shoji (TextView)").GetComponent<Text>();
			m_item_text = t.Find("sw_pop_useitem (AbsoluteLayout)/txt_00 (TextView)").GetComponent<Text>();
			m_item_text2 = t.Find("sw_pop_useitem (AbsoluteLayout)/txt_01 (TextView)").GetComponent<Text>();
			m_condition_text = t.Find("condition (AbsoluteLayout)/txt_00 (TextView)").GetComponent<Text>();
			m_condition_text2 = t.Find("condition (AbsoluteLayout)/txt_01 (TextView)").GetComponent<Text>();
			m_rank_up_anim = layout.FindViewById("sw_c_b_terms_anim") as AbsoluteLayout;
			m_item_button.AddOnClickCallback(OnClickItem);
			return true;
		}

		// // RVA: 0x1635328 Offset: 0x1635328 VA: 0x1635328
		public void OnClickItem()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowItemDetail(m_itemId, m_itemCount, null);
		}

		// RVA: 0x1635434 Offset: 0x1635434 VA: 0x1635434
		public void Initialize(LFAFJCNKLML data, MOEALEGLGCH upgrade)
		{
			int a = upgrade.GJFJBGNCBAP(data);
			string s1 = "";
			string s2 = "";
			bool b = false;
			for(int i = 0; i < a; i++)
			{
				if(upgrade.HEOGHOIOHGI(data, i, out m_itemId, out m_itemCount))
				{
					b = true;
					s2 = upgrade.EGFDDHPPFNE(data, i);
				}
				else
				{
					s1 = upgrade.EGFDDHPPFNE(data, i);
				}
			}
			m_costume.SetCostumeIcon(new CostumeUpgradeUtility.CostumeData.Setting()
			{
				divaId = data.AHHJLDLAPAN_DivaId,
				costumeModelId = data.DAJGPBLEEOB_PrismCostumeId,
				colorId = null,
				isHave = data.FJODMPGPDDD_Possessed,
				rankMax = data.LLLCMHENKKN_LevelMax,
				rankNum = data.GKIKAABHAAD_Level
			}, null);
			if(!upgrade.KFJHILDJCCB(data))
			{
				PopupButton[] btns = transform.parent.parent.parent.GetComponentsInChildren<PopupButton>();
				for(int i = 0; i < btns.Length; i++)
				{
					if(btns[i].Label == PopupButton.ButtonLabel.Release)
					{
						btns[i].Disable = true;
					}
				}
			}
			int a2 = 2;
			if(a == 1)
				a2 = 0;
			if(!b)
				a2 = 1;
			m_condition.StartChildrenAnimGoStop(a2, a2);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_condition_text.text = bk.GetMessageByLabel("costume_upgrade_rank_up_unlock_condition_text");
			m_condition_text2.text = s1;
			if(m_itemId > 0)
			{
				string[] strs = new string[1]
				{
					"\n"
				};
				strs = s2.Split(strs, System.StringSplitOptions.None);
				m_item_text.text = strs[0];
				m_item_text2.text = strs[1];
				m_item_need_num.SetNumber(m_itemCount, 0);
				PLPBJOFICEJ_CosItem.IBEMFIAFIKH cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LBDOLHGDIEB(data.AHHJLDLAPAN_DivaId, PLPBJOFICEJ_CosItem.DPNGHIDJCHA.GLHANCMGNDM_2);
                EGOLBAPFHHD_Common.PGENIOHDCDI saveCos = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EFBKCNNFIPJ(cos.PPFNGGCBJKC);
				m_item_have_num.text = saveCos.BFINGCJHOHI_Cnt.ToString();
				SetItemIcon(m_itemId);
            }
			m_rank = data.GKIKAABHAAD_Level;
		}

		// // RVA: 0x1635CF4 Offset: 0x1635CF4 VA: 0x1635CF4
		public void SetItemIcon(int item_id)
		{
			m_item_image.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(item_id, (IiconTexture texture) =>
			{
				//0x1635F50
				texture.Set(m_item_image);
				m_item_image.enabled = true;
			});
		}

		// // RVA: 0x16349A0 Offset: 0x16349A0 VA: 0x16349A0
		public void StartRankUnlockAnimation()
		{
			if(m_isPlayingRankUnlockAnimation)
				return;
			m_isPlayingRankUnlockAnimation = true;
			this.StartCoroutineWatched(Co_StartRankUnlockAnimation());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CE324 Offset: 0x6CE324 VA: 0x6CE324
		// // RVA: 0x1635E28 Offset: 0x1635E28 VA: 0x1635E28
		private IEnumerator Co_StartRankUnlockAnimation()
		{
			//0x1636084
			m_rank_up_anim.StartChildrenAnimGoStop("go_in", "st_in");
			m_costume.StartRankUnlockAnimation(m_rank);
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_SETTING_007);
			yield return new WaitWhile(() =>
			{
				//0x1636054
				return m_rank_up_anim.IsPlayingChildren();
			});
			m_isPlayingRankUnlockAnimation = false;
		}
	}
}
