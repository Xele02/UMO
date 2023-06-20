using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EpisodeItemSelect : LayoutUGUIScriptBase
	{
		private struct ItemPanel
		{
			public Text name; // 0x0
			public Text info; // 0x4
			public Text item_num; // 0x8
			public RawImageEx image; // 0xC
			public ActionButton btn; // 0x10
		}

		private AbsoluteLayout m_abs; // 0x14
		private AbsoluteLayout m_item_num_table; // 0x18
		private Action mUpdater; // 0x1C
		private List<ItemPanel> m_list = new List<ItemPanel>(); // 0x20
		private PIGBBNDPPJC m_data; // 0x24
		private int EPISODE_ITEM_NUMBER = 80000; // 0x28
		private int EPISODE_ITEM_TYPE_NUM = 3; // 0x2C
		private List<EEDBNJAEKBI> m_item_list; // 0x30
		private bool m_is_loaded_window; // 0x34

		// RVA: 0xEF6784 Offset: 0xEF6784 VA: 0xEF6784 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sw_sel_list_window3") as AbsoluteLayout;
			m_item_num_table = layout.FindViewById("swtbl_sel_list_item_use") as AbsoluteLayout;
			Transform t = transform.Find("sw_sel_list_window3 (AbsoluteLayout)/sw_sel_list_window3 (AbsoluteLayout)/swtbl_sel_list_item_use (AbsoluteLayout)");
			string[] strs = new string[3]
			{
				"sw_sel_list_item_use_frm_01 (AbsoluteLayout)",
				"sw_sel_list_item_use_frm_02 (AbsoluteLayout)",
				"sw_sel_list_item_use_frm_03 (AbsoluteLayout)"
			};
			for (int i = 0; i < strs.Length; i++)
			{
				Transform t2 = t.Find(strs[i]);
				ItemPanel p = new ItemPanel();
				p.name = t2.Find("name_txt_00 (TextView)").GetComponent<Text>();
				p.info = t2.Find("detail_txt_00 (TextView)").GetComponent<Text>();
				p.item_num = t2.Find("possession_txt_00 (TextView)").GetComponent<Text>();
				p.image = t2.Find("cmn_item_001 (AbsoluteLayout)/swtexc_cmn_item_001 (ImageView)").GetComponent<RawImageEx>();
				p.btn = t2.GetComponent<ActionButton>();
				p.name.raycastTarget = false;
				p.info.raycastTarget = false;
				p.item_num.raycastTarget = false;
				m_list.Add(p);
			}
			mUpdater = UpdateLoad;
			return true;
		}

		// RVA: 0xEF6DEC Offset: 0xEF6DEC VA: 0xEF6DEC
		private void Start()
		{
			return;
		}

		// RVA: 0xEF6DF0 Offset: 0xEF6DF0 VA: 0xEF6DF0
		private void Update()
		{
			if (mUpdater != null)
				mUpdater();
		}

		//// RVA: 0xEF6E04 Offset: 0xEF6E04 VA: 0xEF6E04
		private void UpdateLoad()
		{
			mUpdater = UpdateIdle;
		}

		//// RVA: 0xEF6E8C Offset: 0xEF6E8C VA: 0xEF6E8C
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xEF6E90 Offset: 0xEF6E90 VA: 0xEF6E90
		public void Init(PIGBBNDPPJC data)
		{
			m_data = data;
			m_item_list = EEDBNJAEKBI.FKDIMODKKJD();
			m_item_num_table.StartChildrenAnimGoStop(EPISODE_ITEM_TYPE_NUM - 1, EPISODE_ITEM_TYPE_NUM - 1);
			for(int i = 0; i < EPISODE_ITEM_TYPE_NUM; i++)
			{
				m_list[i].name.text = m_item_list[i].OPFGFINHFCE_Name;
				m_list[i].info.text = m_item_list[i].KLMPFGOCBHC_Desc;
				m_list[i].item_num.text = JpStringLiterals.StringLiteral_15265 + m_item_list[i].HMFFHLPNMPH_Count.ToString() + EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, 0);
				if(m_item_list[i].HMFFHLPNMPH_Count < 1)
				{
					m_list[i].btn.Disable = true;
				}
				else
				{
					m_list[i].btn.Disable = false;
				}
				SetItemImage(i + EPISODE_ITEM_NUMBER + 1, i);
			}
		}

		//// RVA: 0xEF7464 Offset: 0xEF7464 VA: 0xEF7464
		//public void Wait() { }

		//// RVA: 0xEF74E0 Offset: 0xEF74E0 VA: 0xEF74E0
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
		}

		//// RVA: 0xEF756C Offset: 0xEF756C VA: 0xEF756C
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0xEF75F8 Offset: 0xEF75F8 VA: 0xEF75F8
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		//// RVA: 0xEF7304 Offset: 0xEF7304 VA: 0xEF7304
		private void SetItemImage(int index, int image_no)
		{
			MenuScene.Instance.ItemTextureCache.Load(index, (IiconTexture icon) =>
			{
				//0xEF7764
				icon.Set(m_list[image_no].image);
			});
		}

		//// RVA: 0xEF762C Offset: 0xEF762C VA: 0xEF762C
		public ActionButton GetBtn(int index)
		{
			return m_list[index].btn;
		}

		//// RVA: 0xEF76BC Offset: 0xEF76BC VA: 0xEF76BC
		public int GetBtnNum()
		{
			return EPISODE_ITEM_TYPE_NUM;
		}
	}
}
