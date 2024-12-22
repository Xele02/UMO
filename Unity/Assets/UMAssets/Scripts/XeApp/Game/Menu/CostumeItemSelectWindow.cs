using XeSys.Gfx;
using System;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class CostumeItemSelectWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class ItemPanel
		{
			public Text name; // 0x8
			public Text info; // 0xC
			public Text item_num; // 0x10
			public RawImageEx image; // 0x14
			public ActionButton btn; // 0x18
			public ActionButton detail_btn; // 0x1C
		}

		private struct MakinaWipe
		{
			public AbsoluteLayout message_loop_anim; // 0x0
			public Text message; // 0x4
			public Text message2; // 0x8
		}

		private string[] list_name = new string[3]
		{
			"item_list_01 (AbsoluteLayout)",
			"item_list_02 (AbsoluteLayout)",
			"item_list_03 (AbsoluteLayout)"
		}; // 0x14
		private const int MakinaId = 4;
		[SerializeField] // RVA: 0x66B448 Offset: 0x66B448 VA: 0x66B448
		private List<ItemPanel> m_list = new List<ItemPanel>(); // 0x18
		private MakinaWipe m_makinaWipe; // 0x1C
		private AbsoluteLayout m_base; // 0x28
		private List<NIHHKCDHLNH> m_item_list; // 0x2C
		private const int ITEM_NUM = 3;
		private bool m_is_loaded_window; // 0x30

		// RVA: 0x1630434 Offset: 0x1630434 VA: 0x1630434 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_item_list_anim") as AbsoluteLayout;
			Transform t = transform.Find("sw_item_list_anim (AbsoluteLayout)/sw_item_list_all (AbsoluteLayout)");
			for(int i = 0; i < list_name.Length; i++)
			{
				ItemPanel item = m_list[i];
				Transform t2 = t.Find(list_name[i]);
				item.name = t2.Find("name_txt_00 (TextView)").GetComponent<Text>();
				item.info = t2.Find("detail_txt_00 (TextView)").GetComponent<Text>();
				item.item_num = t2.Find("possession_txt_00 (TextView)").GetComponent<Text>();
				item.image = t2.Find("sw_cos_item_anim_02 (AbsoluteLayout)/cmn_item_001 (AbsoluteLayout)/swtexc_cmn_item_001 (ImageView)").GetComponent<RawImageEx>();
				item.name.raycastTarget = false;
				item.info.raycastTarget = false;
				item.item_num.raycastTarget = false;
			}
			t = transform.Find("sw_item_list_anim (AbsoluteLayout)/s_c_b_balloon_01 (AbsoluteLayout)/s_c_b_balloon_01 (AbsoluteLayout)/sw_balloon_txt_anim_lo (AbsoluteLayout)");
			m_base = layout.FindViewById("sw_item_list_anim") as AbsoluteLayout;
			m_makinaWipe.message_loop_anim = layout.FindViewById("sw_balloon_txt_anim_lo") as AbsoluteLayout;
			m_makinaWipe.message = t.Find("balloon_txt_02 (AbsoluteLayout)/txt_00 (TextView)").GetComponent<Text>();
			m_makinaWipe.message2 = t.Find("balloon_txt_01 (AbsoluteLayout)/txt_00 (TextView)").GetComponent<Text>();
			return true;
		}

		// RVA: 0x1630A3C Offset: 0x1630A3C VA: 0x1630A3C
		public void Init(int divaId = 1)
		{
			m_item_list = NIHHKCDHLNH.FKDIMODKKJD(divaId);
			for(int i = 0; i < 3; i++)
			{
				m_list[i].name.text = m_item_list[i].OPFGFINHFCE_Name;
				m_list[i].info.text = m_item_list[i].KHLMJCJAOCC_DescShort;
				m_list[i].item_num.text = JpStringLiterals.StringLiteral_15265 + m_item_list[i].HMFFHLPNMPH_Cnt.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem, 0);
				m_list[i].btn.Disable = m_item_list[i].HMFFHLPNMPH_Cnt < 1;
				SetItemImage(m_item_list[i].INFIBMLIHLO_ItemFullId, i);
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_makinaWipe.message_loop_anim.StartChildrenAnimLoop("lo_");
			m_makinaWipe.message.text = bk.GetMessageByLabel("costume_upgrade_item_select_makina_serif");
			m_makinaWipe.message2.text = bk.GetMessageByLabel("costume_upgrade_item_select_makina_serif2");
		}

		// // RVA: 0x16311D0 Offset: 0x16311D0 VA: 0x16311D0
		// public void Wait() { }

		// RVA: 0x163124C Offset: 0x163124C VA: 0x163124C
		public void Enter()
		{
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x16312D8 Offset: 0x16312D8 VA: 0x16312D8
		public void Leave()
		{
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x1631364 Offset: 0x1631364 VA: 0x1631364
		public bool IsPlaying()
		{
			return m_base.IsPlayingChildren();
		}

		// RVA: 0x1631390 Offset: 0x1631390 VA: 0x1631390
		public int GetButtonNum()
		{
			return 3;
		}

		// RVA: 0x1631398 Offset: 0x1631398 VA: 0x1631398
		public ActionButton GetButton(int index)
		{
			return m_list[index].btn;
		}

		// RVA: 0x1631430 Offset: 0x1631430 VA: 0x1631430
		public ActionButton GetDetailButton(int index)
		{
			return m_list[index].detail_btn;
		}

		// RVA: 0x16314C8 Offset: 0x16314C8 VA: 0x16314C8
		public void ShowItemDetailWindow(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowItemDetail(m_item_list[index].INFIBMLIHLO_ItemFullId, m_item_list[index].HMFFHLPNMPH_Cnt, null);
		}

		// // RVA: 0x1630FF0 Offset: 0x1630FF0 VA: 0x1630FF0
		private void SetItemImage(int index, int image_no)
		{
			m_list[image_no].image.enabled = false;
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0x1631880
				m_list[image_no].image.enabled = true;
				icon.Set(m_list[image_no].image);
			});
		}
	}
}
