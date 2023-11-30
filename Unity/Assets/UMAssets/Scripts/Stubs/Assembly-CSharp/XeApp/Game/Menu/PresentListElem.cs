using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PresentListElem : GeneralListElemBase
	{
		public enum ButtonType
		{
			Select = 0,
			Accept = 1,
			Request = 2,
			Receive = 3,
			Use = 4,
		}

		public const int InvokeId_Select = 0;
		[SerializeField]
		private RawImageEx m_itemIconImage; // 0x18
		[SerializeField]
		private RawImageEx m_dateLabelImage; // 0x1C
		[SerializeField]
		private Text m_titleText; // 0x20
		[SerializeField]
		private Text m_limitText; // 0x24
		[SerializeField]
		private Text m_conditionText; // 0x28
		[SerializeField]
		private Text m_dateText; // 0x2C
		[SerializeField]
		private ScrollListButton m_button; // 0x30
		private LayoutSymbolData m_symbolButtonType; // 0x34
		private Rect m_obtainDateUvRect; // 0x38
		private Rect m_receiveDateUvRect; // 0x48

		private Func<IiconTexture> itemIconDelegate { get; set; } // 0x58

		// RVA: 0x1164D04 Offset: 0x1164D04 VA: 0x1164D04
		private void Update()
		{
			if(itemIconDelegate != null)
			{
				IiconTexture tex = itemIconDelegate();
				if (tex == null)
					return;
				SetItemIcon(tex);
				itemIconDelegate = null;
			}
		}

		//// RVA: 0x1164E90 Offset: 0x1164E90 VA: 0x1164E90
		//public void SetupButton(ScrollRect scrollRect, Action onClick) { }

		//// RVA: 0x1164E94 Offset: 0x1164E94 VA: 0x1164E94
		public void SetItemIconDelegate(Func<IiconTexture> iconDelegate)
		{
			itemIconDelegate = iconDelegate;
			m_itemIconImage.enabled = false;
		}

		//// RVA: 0x1164D8C Offset: 0x1164D8C VA: 0x1164D8C
		public void SetItemIcon(IiconTexture iconTex)
		{
			m_itemIconImage.enabled = true;
			iconTex.Set(m_itemIconImage);
		}

		//// RVA: 0x1164EC8 Offset: 0x1164EC8 VA: 0x1164EC8
		public void SetTitle(string title)
		{
			m_titleText.text = title;
		}

		//// RVA: 0x1164F04 Offset: 0x1164F04 VA: 0x1164F04
		public void SetLimit(string limit)
		{
			m_limitText.text = limit;
		}

		//// RVA: 0x1164F40 Offset: 0x1164F40 VA: 0x1164F40
		public void SetCondition(string cond)
		{
			m_conditionText.text = cond;
		}

		//// RVA: 0x1164F7C Offset: 0x1164F7C VA: 0x1164F7C
		public void SetDate(string date)
		{
			m_dateText.text = date;
		}

		//// RVA: 0x1164FB8 Offset: 0x1164FB8 VA: 0x1164FB8
		public void SetButtonVisible(bool isVisible)
		{
			m_button.Hidden = !isVisible;
		}

		//// RVA: 0x1164FEC Offset: 0x1164FEC VA: 0x1164FEC
		public void SetButtonType(ButtonType type)
		{
			switch(type)
			{
				case ButtonType.Select:
					m_symbolButtonType.StartAnim("select");
					break;
				case ButtonType.Accept:
					m_symbolButtonType.StartAnim("accept");
					break;
				case ButtonType.Request:
					m_symbolButtonType.StartAnim("request");
					break;
				case ButtonType.Receive:
					m_symbolButtonType.StartAnim("receive");
					break;
				case ButtonType.Use:
					m_symbolButtonType.StartAnim("use");
					break;
			}
		}

		// RVA: 0x1165128 Offset: 0x1165128 VA: 0x1165128
		public void SetDateLabel(bool isReceive)
		{
			m_dateLabelImage.uvRect = isReceive ? m_receiveDateUvRect : m_obtainDateUvRect;
		}

		//// RVA: 0x116519C Offset: 0x116519C VA: 0x116519C
		private void OnClickCallback()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
			InvokeSelectItem(0);
		}

		// RVA: 0x1165208 Offset: 0x1165208 VA: 0x1165208 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(OnClickCallback);
			m_symbolButtonType = CreateSymbol("btn_type", layout);
			m_obtainDateUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("sel_list_contents_font_1"));
			m_receiveDateUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("sel_list_contents_font_6"));
			Loaded();
			return true;
		}
	}
}
