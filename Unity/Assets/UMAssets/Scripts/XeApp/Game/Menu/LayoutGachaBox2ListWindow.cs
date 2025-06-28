using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutGachaBox2ListWindow : LayoutGachaBoxListWindow
	{
		[SerializeField]
		private Text m_textContent; // 0x48
		[SerializeField]
		private RawImageEx[] m_imageButton; // 0x4C
		[SerializeField]
		private ActionButton m_buttonPrev; // 0x50
		[SerializeField]
		private ActionButton m_buttonNext; // 0x54
		private TexUVListManager m_uvMan; // 0x58
		private int m_boxIndex; // 0x5C
		public Action<int> OnChangeList; // 0x60

		// // RVA: 0x19A29AC Offset: 0x19A29AC VA: 0x19A29AC Slot: 9
		public override void SetStatus(Transform parent, HGFPAFPGIKG view)
		{
			base.SetStatus(parent, view);
			m_boxIndex = view.NNCCGILOOIE_ListIdx;
			UpdateList();
		}

		// // RVA: 0x19A2E50 Offset: 0x19A2E50 VA: 0x19A2E50
		protected void SetRemainCount(int cost, bool visible)
		{
			if(!visible)
			{
				m_textContent.text = "";
			}
			else
			{
				m_textContent.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_gacha_box_text_06"), cost);
			}
		}

		// // RVA: 0x19A2FC8 Offset: 0x19A2FC8 VA: 0x19A2FC8
		protected void ChangeList(int dir)
		{
			m_boxIndex += dir;
			UpdateList();
			if(OnChangeList != null)
				OnChangeList(m_boxIndex);
		}

		// // RVA: 0x19A2ABC Offset: 0x19A2ABC VA: 0x19A2ABC
		protected void UpdateList()
		{
			int a = m_view.EDILCJAICBE(m_boxIndex - 1);
			int b = m_view.EDILCJAICBE(m_boxIndex);
			int c = m_view.EDILCJAICBE(m_boxIndex + 1);
			m_buttonPrev.Disable = a == 0 ? true : m_view.IMMDGJAOPCD == b;
			m_buttonNext.Disable = c == 0;
			m_list = m_view.NHOBNJOLBPO(b, true);
			SetupList(m_list.Count, true);
			textTitle.text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_gacha_box_text_08"), m_boxIndex + 1);
			int d = m_view.IMMDGJAOPCD == b ? -1 : m_view.EDKNOJBCIJO(b);
			SetRemainCount(d, d);
			SetRemainCount(m_view.EPLMGDEGLKG(b), m_view.KMNNDEFMEKH());
		}

		// RVA: 0x19A33EC Offset: 0x19A33EC VA: 0x19A33EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_imageButton[0].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("g_b_btn_fnt_a_02"));
			m_imageButton[1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("g_b_btn_fnt_a_03"));
			m_buttonPrev.AddOnClickCallback(() =>
			{
				//0x19A3688
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				ChangeList(-1);
			});
			m_buttonNext.AddOnClickCallback(() =>
			{
				//0x19A36F0
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				ChangeList(1);
			});
			Loaded();
			return true;
		}
	}
}
