using XeSys.Gfx;
using System;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;

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
		private CostumeInfoWindow.CostumeInfo[] m_panel_data; // 0x14
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
		//public void SetCheckButton() { }

		//// RVA: 0x162E6BC Offset: 0x162E6BC VA: 0x162E6BC
		//public void SetCostumeData(FFHPBEPOMAK beforeData, FFHPBEPOMAK afterData) { }

		//// RVA: 0x162FA54 Offset: 0x162FA54 VA: 0x162FA54
		//private void SetStateIcon(int index, int value) { }

		//// RVA: 0x162F8B8 Offset: 0x162F8B8 VA: 0x162F8B8
		//private void SetParamText(Text text, int value, int diff, bool isColorChange) { }

		//[CompilerGeneratedAttribute] // RVA: 0x6CC7EC Offset: 0x6CC7EC VA: 0x6CC7EC
		//// RVA: 0x162FD50 Offset: 0x162FD50 VA: 0x162FD50
		//private void <SetCheckButton>b__15_0() { }
	}
}
