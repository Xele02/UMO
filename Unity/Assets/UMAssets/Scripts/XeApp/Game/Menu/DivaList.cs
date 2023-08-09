using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;
using XeApp.Game.Common;
using System.Text;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class DivaList : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SelectDivaEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private RawImageEx[] m_divaIconImage; // 0x14
		[SerializeField]
		private RawImageEx[] m_centerIconImage; // 0x18
		[SerializeField]
		private RawImageEx[] m_unitIconImage; // 0x1C
		[SerializeField]
		private StayButton[] m_stayButton; // 0x20
		[SerializeField]
		private SelectDivaEvent m_onPushIconEvent; // 0x24
		[SerializeField]
		private SelectDivaEvent m_onStayIconEvent; // 0x28
		private DivaIconDecoration[] m_divaIconDecoration; // 0x2C
		private AbsoluteLayout m_windowLayout; // 0x30
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0x34

		public SelectDivaEvent OnPushIconEvent { get { return m_onPushIconEvent; } } //0x17E5698
		public SelectDivaEvent OnStayIconEvent { get { return m_onStayIconEvent; } } //0x17E56A0
		
		// RVA: 0x17E56A8 Offset: 0x17E56A8 VA: 0x17E56A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_divaIconDecoration = new DivaIconDecoration[m_stayButton.Length];
			for(int i = 0; i < m_stayButton.Length; i++)
			{
				int index = i;
				m_stayButton[i].AddOnClickCallback(() =>
				{
					//0x17E68C4
					OnPushIcon(index);
				});
				m_stayButton[i].AddOnStayCallback(() =>
				{
					//0x17E68F4
					OnStayIcon(index);
				});
				m_divaIconDecoration[i] = new DivaIconDecoration();
			}
			m_windowLayout = layout.FindViewByExId("sw_sel_chara_window02_all_sw_sel_charalist_anim") as AbsoluteLayout;
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x17E5A04 Offset: 0x17E5A04 VA: 0x17E5A04
		public void InitializeDecoration()
		{
			for(int i = 0; i < m_divaIconDecoration.Length; i++)
			{
				m_divaIconDecoration[i].Initialize(m_divaIconImage[i].gameObject, DivaIconDecoration.Size.M, true, false, null, null);
			}
		}

		//// RVA: 0x17E5B08 Offset: 0x17E5B08 VA: 0x17E5B08
		public void ReleaseDecoration()
		{
			for(int i = 0; i < m_divaIconDecoration.Length; i++)
			{
				m_divaIconDecoration[i].Release();
			}
		}

		//// RVA: 0x17E5B94 Offset: 0x17E5B94 VA: 0x17E5B94
		public void UpdateContent(DFKGGBMFFGB_PlayerInfo playerData, List<int> sortIndexList)
		{
			int i;
			for (i = 0; i < sortIndexList.Count; i++)
			{
				int index = i;
				FFHPBEPOMAK_DivaInfo d = playerData.NBIGLBMHEDC_Divas[sortIndexList[i]];
				int divaId = d.AHHJLDLAPAN_DivaId;
				int modelId = d.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
				int colorId = d.EKFONBFDAAP_ColorId;
				MenuScene.Instance.DivaIconCache.LoadStateIcon(divaId, modelId, colorId, (IiconTexture texture) =>
				{
					//0x17E6924
					texture.Set(m_divaIconImage[index]);
					m_divaIconImage[index].enabled = true;
				});
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("{0:D2}", divaId);
				m_unitIconImage[i].enabled = IsUnitDiva(playerData, divaId);
				m_centerIconImage[i].enabled = playerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId == divaId;
				m_stayButton[i].enabled = true;
			}
			for(; i < m_stayButton.Length; i++)
			{
				m_divaIconImage[i].enabled = false;
				m_unitIconImage[i].enabled = false;
				m_centerIconImage[i].enabled = false;
				m_stayButton[i].enabled = false;
			}
		}

		//// RVA: 0x17E6480 Offset: 0x17E6480 VA: 0x17E6480
		public void ChangeIcon(DFKGGBMFFGB_PlayerInfo playerData, List<int> sortIndexList, DisplayType type)
		{
			for(int i = 0; i < sortIndexList.Count; i++)
			{
				m_divaIconDecoration[i].Change(playerData.NBIGLBMHEDC_Divas[sortIndexList[i]], playerData, type);
			}
		}

		//// RVA: 0x17E628C Offset: 0x17E628C VA: 0x17E628C
		private bool IsUnitDiva(DFKGGBMFFGB_PlayerInfo playerData, int divaId)
		{
			for(int i = 0; i < playerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				if (playerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] != null && playerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].AHHJLDLAPAN_DivaId == divaId)
					return true;
			}
			for(int i = 0; i < playerData.NPFCMHCCDDH.CMOPCCAJAAO_AddDivas.Count; i++)
			{
				if (playerData.NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i] != null && playerData.NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i].AHHJLDLAPAN_DivaId == divaId)
					return true;
			}
			return false;
		}

		//// RVA: 0x17E6600 Offset: 0x17E6600 VA: 0x17E6600
		private void OnPushIcon(int index)
		{
			m_onPushIconEvent.Invoke(index);
		}

		//// RVA: 0x17E6680 Offset: 0x17E6680 VA: 0x17E6680
		private void OnStayIcon(int index)
		{
			m_onStayIconEvent.Invoke(index);
		}

		//// RVA: 0x17E6700 Offset: 0x17E6700 VA: 0x17E6700
		public void Show()
		{
			m_windowLayout.StartChildrenAnimGoStop("st_wait", "st_in");
		}

		//// RVA: 0x17E678C Offset: 0x17E678C VA: 0x17E678C
		public void Hide()
		{
			m_windowLayout.StartChildrenAnimGoStop("st_in", "st_out");
		}

		//// RVA: 0x17E6818 Offset: 0x17E6818 VA: 0x17E6818
		public bool IsPlaying()
		{
			return m_windowLayout.IsPlayingChildren();
		}
	}
}
