using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutInhertingSnsButton : ActionButton
	{
		[SerializeField]
		private RawImageEx m_fontImage; // 0x80
		private Action m_callback; // 0x84
		private TexUVListManager m_uvManager; // 0x88
		private AbsoluteLayout m_layoutCoop; // 0x8C

		// RVA: 0x1D50FFC Offset: 0x1D50FFC VA: 0x1D50FFC
		public void SetCallback(Action callback)
		{
			m_callback = callback;
		}

		// RVA: 0x1D51004 Offset: 0x1D51004 VA: 0x1D51004
		public void SetStatus(LayoutPopupSnsSetting.eButtonType buttonType, LayoutPopupSnsSetting.eButtonStatus status)
		{
			if (status == LayoutPopupSnsSetting.eButtonStatus.NotCoop)
			{
				m_layoutCoop.StartChildrenAnimGoStop("02");
				Disable = false;
			}
			else if (status == LayoutPopupSnsSetting.eButtonStatus.Release)
			{
				m_layoutCoop.StartChildrenAnimGoStop("01");
				Disable = false;
			}
			else if (status == LayoutPopupSnsSetting.eButtonStatus.Coop)
			{
				m_layoutCoop.StartChildrenAnimGoStop("02");
				Disable = true;
			}
			if (m_fontImage == null)
			{
				return;
			}
			if (buttonType == LayoutPopupSnsSetting.eButtonType.Facebook)
			{
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					int facebookDisable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("facebook_disable", 0);
					if(facebookDisable > 0)
					{
						Hidden = true;
						m_layoutCoop.StartChildrenAnimGoStop("02");
					}
				}
				m_fontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("sel_inh_btn_fnt_pop_01"));
			}
			else if (buttonType == LayoutPopupSnsSetting.eButtonType.Twitter)
			{
				m_fontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("sel_inh_btn_fnt_pop_02"));
			}
			else if (buttonType == LayoutPopupSnsSetting.eButtonType.Line)
			{
				m_fontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData("sel_inh_btn_fnt_pop_03"));
			}
			else
			{
				m_fontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(null);
			}
		}

		// RVA: 0x1D51358 Offset: 0x1D51358 VA: 0x1D51358 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_uvManager = uvMan;
			LayoutUGUIRuntime runtime = GetComponentInParent<LayoutUGUIRuntime>();
			m_layoutCoop = (runtime.FindViewBase(transform as RectTransform) as AbsoluteLayout).FindViewById("swtbl_sel_inh_link_icon_04") as AbsoluteLayout;
			m_layoutCoop.StartAllAnimGoStop("02");
			AddOnClickCallback(() =>
			{
				//0x1D51584
				if (m_callback != null)
					m_callback();
			});
			Loaded();
			return true;
		}
	}
}
