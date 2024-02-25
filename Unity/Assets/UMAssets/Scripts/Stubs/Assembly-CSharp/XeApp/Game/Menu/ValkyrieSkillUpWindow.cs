using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ValkyrieSkillUpWindow : LayoutUGUIScriptBase
	{
		private class AbilityLayout
		{
			public Text abiltiy_category; // 0x8
			public Text abiltiy_level; // 0xC
			public Text abiltiy_description; // 0x10
		}

		private const int ITEM_MAX = 2;
		private AbilityLayout[] m_abilityLayout = new AbilityLayout[2]; // 0x14
		private ActionButton[] m_detailNeedItemButton = new ActionButton[2]; // 0x18
		private RawImageEx[] m_itemTex = new RawImageEx[2]; // 0x1C
		private Text[] m_haveItemText = new Text[2]; // 0x20
		private Text[] m_needItemText = new Text[2]; // 0x24
		private readonly string LVTEXT = "Lv"; // 0x28
		private Text m_ViewDescriptionText; // 0x2C
		private Text m_needItemDescText; // 0x30
		private AbsoluteLayout m_ViewAbilityLayout_l; // 0x34
		private Text m_NoTextLayout; // 0x38
		private TexUVList m_valkyrie_03_pack; // 0x3C

		// // RVA: 0x16637E4 Offset: 0x16637E4 VA: 0x16637E4
		public void IsNoAbilityDisable(bool isDisable)
		{
			m_ViewAbilityLayout_l.enabled = isDisable;
			m_NoTextLayout.enabled = !isDisable;
		}

		// RVA: 0x1663848 Offset: 0x1663848 VA: 0x1663848 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_val_ability_all (AbsoluteLayout)");
			Text[] txts = t.GetComponentsInChildren<Text>();
			m_ViewDescriptionText = txts.Where((Text _) =>
			{
				//0x1666004
				return _.name == "abi_txt_00 (TextView)";
			}).First();
			m_needItemDescText = txts.Where((Text _) =>
			{
				//0x1666084
				return _.name == "abi_txt_01 (TextView)";
			}).First();
			ActionButton[] btns = t.GetComponentsInChildren<ActionButton>();
			m_detailNeedItemButton[0] = btns.Where((ActionButton _) =>
			{
				//0x1666104
				return _.name == "sw_sel_val_btn_item_anim_01 (AbsoluteLayout)";
			}).First();
			m_detailNeedItemButton[1] = btns.Where((ActionButton _) =>
			{
				//0x1666184
				return _.name == "sw_sel_val_btn_item_anim_02 (AbsoluteLayout)";
			}).First();
			for(int i = 0; i < 2; i++)
			{
				Transform t2 = t.Find("sw_ad_shoji_item_text_" + (i + 1) + " (AbsoluteLayout)");
				txts = t2.GetComponentsInChildren<Text>();
				m_haveItemText[i] = txts.Where((Text _) =>
				{
					//0x1666204
					return _.name == "neceitem_01 (TextView)";
				}).First();
			}
			for(int i = 0; i < 2; i++)
			{
				Transform t2 = t.Find("sw_ad_nece_item_text_" + (i + 1) + " (AbsoluteLayout)");
				m_needItemText[i] = t2.GetComponentsInChildren<Text>().Where((Text _) =>
				{
					//0x1666284
					return _.name == "shojiitem_01 (TextView)";
				}).First();
			}
			for(int i = 0; i < 2; i++)
			{
				Transform t2 = t.Find("sw_sel_val_btn_item_anim_0" + (i + 1) + " (AbsoluteLayout)");
				m_itemTex[i] = t2.GetComponentsInChildren<RawImageEx>().Where((RawImageEx _) =>
				{
					//0x1666304
					return _.name == "swtexc_cmn_item_1 (ImageView)";
				}).First();
			}
			m_ViewAbilityLayout_l = layout.FindViewByExId("sw_val_ability_l_sw_val_abilityset") as AbsoluteLayout;
			for(int i = 0; i < 2; i++)
			{
				m_abilityLayout[i] = new AbilityLayout();
				Transform t2 = transform.Find("sw_val_ability_all (AbsoluteLayout)/" + "sw_val_ability_" + (i == 0 ? "l" : "r") + " (AbsoluteLayout)");
				txts = t2.GetComponentsInChildren<Text>();
				m_abilityLayout[i].abiltiy_category = txts.Where((Text _) =>
				{
					//0x1666384
					return _.name == "abi_txt_name (TextView)";
				}).First();
				m_abilityLayout[i].abiltiy_level = txts.Where((Text _) =>
				{
					//0x1666404
					return _.name == "abi_txt_lv (TextView)";
				}).First();
				m_abilityLayout[i].abiltiy_description = txts.Where((Text _) =>
				{
					//0x1666484
					return _.name == "abi_txt (TextView)";
				}).First();
				if(i == 0)
				{
					m_NoTextLayout = txts.Where((Text _) =>
					{
						//0x1666504
						return _.name == "abi_txt_not (TextView)";
					}).First();
				}
			}
			AbsoluteLayout abs = layout.FindViewByExId("sw_val_ability_r_sw_val_abilityset_not") as AbsoluteLayout;
			abs.enabled = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_ViewDescriptionText.text = bk.GetMessageByLabel("pop_valkyrietuneup_desc");
			m_NoTextLayout.text = bk.GetMessageByLabel("valkyrie_tuneup_skill_not");
			RichTextUtility.ChangeColor(m_NoTextLayout, SystemTextColor.NormalColor);
			m_NoTextLayout.enabled = false;
			m_valkyrie_03_pack = uvMan.GetTexUVList("sel_valkyrie_03_pack");
			Loaded();
			return true;
		}

		// RVA: 0x1665160 Offset: 0x1665160 VA: 0x1665160
		public void SetAbilityData(bool isAbility, ALEKLHIANJN before, ALEKLHIANJN after)
		{
			IsNoAbilityDisable(isAbility);
			for(int i = 0; i < 2; i++)
			{
				ALEKLHIANJN d = i == 0 ? before : after;
				m_abilityLayout[i].abiltiy_category.text = d.OPFGFINHFCE_SkillName;
				m_abilityLayout[i].abiltiy_level.text = LVTEXT + d.CHHADJECKNL_GetLevel();
				m_abilityLayout[i].abiltiy_description.text = d.DMBDNIEEMCB_GetDesc(i != 0);
			}
			SetItemSetting(after.PFIFFGHLCJJ());
		}

		// // RVA: 0x1665414 Offset: 0x1665414 VA: 0x1665414
		private void SetItemSetting(List<ALEKLHIANJN.HJBLCFPOFPO> list)
		{
            OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
            BBHNACPENDM_ServerSaveData save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
            StringBuilder str = new StringBuilder();
			string[] strs = new string[2];
			for(int i = 0; i < list.Count; i++)
			{
				int num = i;
				MenuScene.Instance.ItemTextureCache.Load(list[i].PPFNGGCBJKC, (IiconTexture texture) =>
				{
					//0x1666584
					texture.Set(m_itemTex[num]);
				});
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(list[i].PPFNGGCBJKC);
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(list[i].PPFNGGCBJKC);
				strs[i] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(list[i].PPFNGGCBJKC);
				int haveCurrent = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(db, save, cat, id, null);
				m_detailNeedItemButton[i].ClearOnClickCallback();
				m_detailNeedItemButton[i].AddOnClickCallback(() =>
				{
					//0x16666C4
					MenuScene.Instance.ShowItemDetail(list[num].PPFNGGCBJKC, haveCurrent, null);
				});
				m_haveItemText[i].text = haveCurrent.ToString();
				m_needItemText[i].text = list[i].NANNGLGOFKH.ToString();
				if(haveCurrent < list[i].NANNGLGOFKH)
				{
					RichTextUtility.ChangeColor(m_haveItemText[i], StatusTextColor.NormalColor);
				}
            }
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_needItemDescText.text = string.Format(bk.GetMessageByLabel("pop_valyrietuneup_needitemdesc"), strs[0], strs[1]);
		}
	}
}
