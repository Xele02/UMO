using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System.Collections.Generic;
using System;
using XeSys;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBoxListWindow : LayoutGachaBoxListBase
	{
		[SerializeField]
		private Text m_textRemain; // 0x1C
		[SerializeField]
		private Text m_textRemainNum; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24
		private AbsoluteLayout m_layoutWarning; // 0x28
		private AbsoluteLayout m_layoutMedal; // 0x2C
		private TexUVListManager m_uvMan; // 0x30
		protected Transform m_parent; // 0x34
		protected List<HGFPAFPGIKG.CMEDMHFOFAH> m_list; // 0x38
		protected HGFPAFPGIKG m_view; // 0x3C

		//protected override AbsoluteLayout layoutRoot { get { return m_layoutRoot; } } //0x19A4BBC
		public Text textTitle { get; set; } // 0x40
		public Action<Transform, HGFPAFPGIKG.CMEDMHFOFAH> OnSelectEvent { get; set; } // 0x44

		// RVA: 0x19A4BDC Offset: 0x19A4BDC VA: 0x19A4BDC
		public bool IsListReady()
		{
			for(int i = 0; i < List.ScrollObjectCount; i++)
			{
				if(!(List.ScrollObjects[i] as LayoutGachaBoxListItem).IsIconLoaded())
					return false;
			}
			return true;
		}

		// // RVA: 0x19A29E4 Offset: 0x19A29E4 VA: 0x19A29E4 Slot: 9
		public virtual void SetStatus(Transform parent, HGFPAFPGIKG view)
		{
			m_view = view;
			m_parent = parent;
			SetRemainCount(-1, -1);
			m_list = m_view.GMENOMFADOH();
			SetupList(m_list.Count, true);
		}

		// // RVA: 0x19A4D6C Offset: 0x19A4D6C VA: 0x19A4D6C Slot: 10
		protected virtual void SetRemainCount(int num /*= -1*/, int max/* = -1*/)
		{
			if(num < 0)
				num = m_view.JALHJAPAFLK_BoxCurrent;
			if(max < 0)
				max = m_view.DMPELKEMCCJ_BoxTotal;
			m_textRemain.text = MessageManager.Instance.GetMessage("menu", "popup_event_gacha_box_text_02");
			m_textRemainNum.text = num.ToString() + "/" + max.ToString();
		}

		// // RVA: 0x19A4F2C Offset: 0x19A4F2C VA: 0x19A4F2C Slot: 7
		protected override void OnSelectListItem(int value, SwapScrollListContent content)
		{
			LayoutGachaBoxListItem l = content as LayoutGachaBoxListItem;
			if(l != null)
			{
				if(OnSelectEvent != null)
					OnSelectEvent(m_parent, l.data);
			}
		}

		// // RVA: 0x19A504C Offset: 0x19A504C VA: 0x19A504C Slot: 8
		protected override void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutGachaBoxListItem l = content as LayoutGachaBoxListItem;
			if(l != null)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				bool b = false;
				if(time < m_view.JOFAGCFNKIO_Start)
				{
					b = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_list[index].GLCLFMGPMAN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene && m_list[index].JOPPFEHKNFO_IsPickup;
				}
				l.SetStatus(m_list[index], b);
			}
		}

		// RVA: 0x19A5338 Offset: 0x19A5338 VA: 0x19A5338 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
