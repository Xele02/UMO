using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class MusicSelectUnitButton : ActionButton
	{
		public enum Style
		{
			Solo = 0,
			Unit = 1,
			Only = 2,
			Num = 3,
		}

		private enum Number
		{
			Solo = 0,
			Duet = 1,
			Trio = 2,
			Quartet = 3,
			Quintet = 4,
			Num = 5,
		}

		private Style m_style; // 0x80
		private bool m_unitOnly; // 0x84
		private Number m_number; // 0x88
		[SerializeField]
		private RawImageEx m_imageOnOff; // 0x8C
		[SerializeField]
		private RawImageEx m_imageDisable; // 0x90
		private string[,] m_imageNameList = new string[5, 3]
		{
			{"", "", ""},
			{"btn_unit_icon_02_01", "btn_unit_icon_02_02", "btn_unit_icon_02_03"},
			{"btn_unit_icon_03_01", "btn_unit_icon_03_02", "btn_unit_icon_03_03"},
			{"btn_unit_icon_04_01", "btn_unit_icon_04_02", "btn_unit_icon_04_03"},
			{"btn_unit_icon_05_01", "btn_unit_icon_05_02", "btn_unit_icon_05_03"}
		}; // 0x94
		private Rect[,] m_imageRectList = new Rect[5, 3]; // 0x98
		private IBJAKJJICBC m_musicData; // 0x9C
		private MMOLNAHHDOM m_unitLiveLocalSaveData; // 0xA0
		private Action<Style> m_onUpdateStyle; // 0xA4

		// public bool Hidden { get; set; } 0x1511B40 0x1511B48

		// // RVA: 0x1511B90 Offset: 0x1511B90 VA: 0x1511B90
		public int GetDivaCount()
		{
			if(m_musicData.DBIGDCOHOIC_IsMultiDanceUnlocked() && m_style == Style.Unit && m_number > Number.Solo && m_number <= Number.Quintet)
			{
				return (int)m_number + 1;
			}
			return 1;
		}

		// RVA: 0x1511BF0 Offset: 0x1511BF0 VA: 0x1511BF0
		public void Setup(IBJAKJJICBC musicData, MMOLNAHHDOM saveData, Action<Style> onUpdateStyle)
		{
			if(musicData == null || musicData.AJGCPCMLGKO_IsEvent || musicData.POEGGBGOKGI_IsInfoLiveEntrance)
			{
				Disable = false;
				Hidden = true;
			}
			else
			{
				m_musicData = musicData;
				m_unitLiveLocalSaveData = saveData;
				m_unitOnly = musicData.HAMPEDFMIAD_HasOnlyMultiDivaMode();
				BitArray b = new BitArray(new int[1]
				{
					musicData.BNCMJNMIDIN_AvaiableDivaModes
				});
				for(int i = (int)Number.Quintet; i >= (int)Number.Solo; i--)
				{
					if(b[i])
					{
						m_number = (Number)i;
						break;
					}
				}
				m_style = m_unitLiveLocalSaveData.NMBAHHJLGPP_IsMultiDiva(musicData.GHBPLHBNMBK_FreeMusicId) ? Style.Unit : Style.Solo;
				if(!musicData.KLOGLLFOAPL_HasMultiDivaMode())
					m_style = Style.Solo;
				m_imageDisable.uvRect = m_imageRectList[(int)m_number, 2];
				m_imageOnOff.uvRect = m_imageRectList[(int)m_number, (int)m_style];
				Hidden = !musicData.PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF.ALNCPFNNBLH_0);
			}
			m_onUpdateStyle = onUpdateStyle;
			if(onUpdateStyle != null)
				onUpdateStyle(m_style);
		}

		// // RVA: 0x1511F78 Offset: 0x1511F78 VA: 0x1511F78
		private void OnClickChangeButton()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_BTN_006);
			SwhichStyle();
		}

		// // RVA: 0x1511FDC Offset: 0x1511FDC VA: 0x1511FDC
		private void SwhichStyle()
		{
			m_style = m_style == Style.Solo ? Style.Unit : Style.Solo;
			m_imageOnOff.uvRect = m_imageRectList[(int)m_number, (int)m_style];
			if(m_onUpdateStyle != null)
				m_onUpdateStyle(m_style);
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(m_musicData.GHBPLHBNMBK_FreeMusicId, m_style == Style.Unit);
		}

		// RVA: 0x1512170 Offset: 0x1512170 VA: 0x1512170 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			for(int i = 1; i < m_imageNameList.GetLength(0); i++)
			{
				for(int j = 0; j < m_imageNameList.GetLength(1); j++)
				{
					TexUVData uvData = uvMan.GetUVData(m_imageNameList[i, j]);
					if(uvData != null)
					{
						m_imageRectList[i, j] = LayoutUGUIUtility.MakeUnityUVRect(uvData);
					}
				}
			}
			AddOnClickCallback(OnClickChangeButton);
			Loaded();
			return true;
		}
	}
}
