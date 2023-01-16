using XeSys.Gfx;
using System;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public class CostumeInfoWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class CostumeInfo
		{
			public Text name; // 0x8
			public Text total; // 0xC
			public Text soul; // 0x10
			public Text voice; // 0x14
			public Text charm; // 0x18
			public Text life; // 0x1C
			public Text support; // 0x20
			public Text fold; // 0x24
			public Text effect1; // 0x28
			public Text effect2; // 0x2C
			public RawImageEx costume; // 0x30
		}
		
		private enum Stage
		{
			TOTAL = 0,
			SOUL = 1,
			VOICE = 2,
			CHARM = 3,
			LIFE = 4,
			SUPPORT = 5,
			FOLD = 6,
			MAX = 7,
		}
 
		private enum StateIcon
		{
			NONE = 0,
			UP = 1,
			DOWN = 2,
		}

		private const int PANEL_NUM = 2;
		private const int AFFTER_PANEL_INDEX = 1;
		[SerializeField] // RVA: 0x66B0C8 Offset: 0x66B0C8 VA: 0x66B0C8
		private CostumeInfo[] m_panel_data; // 0x14
		[SerializeField] // RVA: 0x66B0D8 Offset: 0x66B0D8 VA: 0x66B0D8
		private RawImageEx[] m_state_icon; // 0x18
		[SerializeField] // RVA: 0x66B0E8 Offset: 0x66B0E8 VA: 0x66B0E8
		private CheckboxButton m_homeCostumeCheckBox; // 0x1C
		[SerializeField] // RVA: 0x66B0F8 Offset: 0x66B0F8 VA: 0x66B0F8
		private Text m_homeCostumeCheckText; // 0x20
		private List<Rect> m_icon_uv = new List<Rect>(); // 0x24

		public bool IsHomeCostumeReflect { get; set; } // 0x11

		// RVA: 0x162E39C Offset: 0x162E39C VA: 0x162E39C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_homeCostumeCheckText.text = MessageManager.Instance.GetMessage("menu", "popup_costumeselect_home");
			m_icon_uv.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_status_icon_up")));
			m_icon_uv.Add(LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("cmn_status_icon_down")));
			Loaded();
			return true;
		}

		//// RVA: 0x162E5A8 Offset: 0x162E5A8 VA: 0x162E5A8
		public void SetCheckButton()
		{
			m_homeCostumeCheckBox.SetOff();
			IsHomeCostumeReflect = m_homeCostumeCheckBox.IsChecked;
			m_homeCostumeCheckBox.ClearOnClickCallback();
			m_homeCostumeCheckBox.AddOnClickCallback(() => {
				//0x162FD50
				if(!m_homeCostumeCheckBox.IsChecked)
				{
					m_homeCostumeCheckBox.SetOff();
				}
				else
				{
					m_homeCostumeCheckBox.SetOn();
				}
				IsHomeCostumeReflect = m_homeCostumeCheckBox;
			});
		}

		//// RVA: 0x162E6BC Offset: 0x162E6BC VA: 0x162E6BC
		public void SetCostumeData(FFHPBEPOMAK_DivaInfo beforeData, FFHPBEPOMAK_DivaInfo afterData)
		{
			FFHPBEPOMAK_DivaInfo[] list = new FFHPBEPOMAK_DivaInfo[2];
			list[0] = beforeData;
			list[1] = afterData;
			StatusData stB = new StatusData();
			StatusData stA = new StatusData();
			stB.Clear();
			stA.Clear();
			EDMIONMCICN eB = new EDMIONMCICN();
			EDMIONMCICN eA = new EDMIONMCICN();
			eB.OBKGEDCKHHE_Reset();
			eA.OBKGEDCKHHE_Reset();
			CMMKCEPBIHI.AECDJDIJJKD_ApplySkills(ref eB, beforeData, null, GameManager.Instance.ViewPlayerData, null, null, null);
			CMMKCEPBIHI.AECDJDIJJKD_ApplySkills(ref eA, afterData, null, GameManager.Instance.ViewPlayerData, null, null, null);
			eB.IMLOCECFHGK(ref stB);
			eA.IMLOCECFHGK(ref stA);
			StatusData[] sts = new StatusData[2];
			sts[0] = stB;
			sts[1] = stA;
			for(int i = 0; i < 2; i++)
			{
				sts[i].Add(list[i].CMCKNKKCNDK_EquippedStatus);
			}
			for(int i = 0; i < 2; i++)
			{
				m_panel_data[i].name.text = list[i].FFKMJNHFFFL_Costume.HCPCHEPCFEA_GetCostumeName(list[i].EKFONBFDAAP_ColorId);
				SetParamText(m_panel_data[i].total, sts[i].Total, stA.Total - stB.Total, i == 1);
				SetParamText(m_panel_data[i].soul, sts[i].soul, stA.soul - stB.soul, i == 1);
				SetParamText(m_panel_data[i].voice, sts[i].vocal, stA.vocal - stB.vocal, i == 1);
				SetParamText(m_panel_data[i].charm, sts[i].charm, stA.charm - stB.charm, i == 1);
				SetParamText(m_panel_data[i].life, sts[i].life, stA.life - stB.life, i == 1);
				SetParamText(m_panel_data[i].support, sts[i].support, stA.support - stB.support, i == 1);
				SetParamText(m_panel_data[i].fold, sts[i].fold, stA.fold - stB.fold, i == 1);
				m_panel_data[i].effect1.text = "";
				m_panel_data[i].effect2.alignment = list[i].FFKMJNHFFFL_Costume.ENMAEBJGEKL_SkillId == 0 ? TextAnchor.UpperCenter : TextAnchor.UpperLeft;
				m_panel_data[i].effect2.text = list[i].FFKMJNHFFFL_Costume.FCEGELPJAMH_SkillDesc;
				int index = i;
				GameManager.Instance.CostumeIconCache.Load(list[i].AHHJLDLAPAN_DivaId, list[i].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, list[i].EKFONBFDAAP_ColorId, (IiconTexture icon) => {
					//0x162FDD4
					icon.Set(m_panel_data[index].costume);
				});
			}
			SetStateIcon(0, stA.Total - stB.Total);
			SetStateIcon(1, stA.soul - stB.soul);
			SetStateIcon(2, stA.vocal - stB.vocal);
			SetStateIcon(3, stA.charm - stB.charm);
			SetStateIcon(4, stA.life - stB.life);
			SetStateIcon(5, stA.support - stB.support);
			SetStateIcon(6, stA.fold - stB.fold);
		}

		//// RVA: 0x162FA54 Offset: 0x162FA54 VA: 0x162FA54
		private void SetStateIcon(int index, int value)
		{
			m_state_icon[index].enabled = true;
			if(value < 0)
			{
				m_state_icon[index].uvRect = m_icon_uv[1];
			}
			else if(value == 0)
			{
				m_state_icon[index].enabled = false;
			}
			else
			{
				m_state_icon[index].uvRect = m_icon_uv[0];
			}
		}

		//// RVA: 0x162F8B8 Offset: 0x162F8B8 VA: 0x162F8B8
		private void SetParamText(Text text, int value, int diff, bool isColorChange)
		{
			text.text = value.ToString();
			if(isColorChange)
			{
				RichTextUtility.ChangeColor(text, diff < 0 ? StatusTextColor.DownColor : (diff == 0 ? StatusTextColor.NormalColor : StatusTextColor.UpColor));
			}
		}
	}
}
