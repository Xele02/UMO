using XeSys.Gfx;
using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

public class LayoutDecorationBottomButtons : LayoutUGUIScriptBase
{
	public enum BottomButtonsType
	{
		NewPost = 0,
		Replace = 1,
		ReplaceSave = 2,
		BgSave = 3,
		OneButton = 4,
		ChangeStorage = 5,
		Num = 6,
	}

	public struct BottomButtonsData
	{
		public int num; // 0x0
		public int[] textureId; // 0x4
		public string attentionText; // 0x8
	}

	[Serializable]
	public class BottomButtons
	{
		public List<ActionButton> m_buttons = new List<ActionButton>(); // 0x8
		public List<RawImageEx> m_font = new List<RawImageEx>(); // 0xC
		public List<Action> m_callback = new List<Action>(); // 0x10
	}

	public static readonly string AssetName = "root_deco_item_pos_01_layout_root"; // 0x0
	private readonly BottomButtonsData[] ButtonData = new BottomButtonsData[6]
		{
			new BottomButtonsData() { textureId = new int[2] { 3, 2 }, num = 2 },
			new BottomButtonsData() { textureId = new int[3] { 8, 3, 2 }, num = 3 },
			new BottomButtonsData() { textureId = new int[2] { 8, 1 }, num = 2 },
			new BottomButtonsData() { textureId = new int[2] { 5, 6 }, num = 2 },
			new BottomButtonsData() { textureId = new int[1] { 1 }, num = 1 },
			new BottomButtonsData() { textureId = new int[2] { 8, 10 }, num = 2 , attentionText = "deco_change_storage_attention_text" }
		}; // 0x14
	private readonly int[] numToIndexList = new int[4]
		{
			0, 2, 0, 1
		}; // 0x18
	[SerializeField]
	private List<BottomButtons> m_bottomButtons = new List<BottomButtons>(); // 0x1C
	[SerializeField]
	private Text m_text; // 0x20
	private AbsoluteLayout m_buttonTable; // 0x24
	private AbsoluteLayout m_textTable; // 0x28
	private List<AbsoluteLayout> m_buttonBase = new List<AbsoluteLayout>(); // 0x2C
	private TexUVListManager m_uvManager; // 0x30
	private BottomButtonsType m_type; // 0x34

	public bool IsEnter { get; private set; } // 0x38

	// RVA: 0xA1124C Offset: 0xA1124C VA: 0xA1124C Slot: 5
	public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
	{
		m_buttonTable = layout.FindViewById("swtbl_deco_item_pos_01") as AbsoluteLayout;
		m_buttonBase.Add(layout.FindViewById("sw_deco_item_pos_01_anim") as AbsoluteLayout);
		m_buttonBase.Add(layout.FindViewById("sw_deco_item_pos_02_anim") as AbsoluteLayout);
		m_buttonBase.Add(layout.FindViewById("sw_deco_item_pos_03_anim") as AbsoluteLayout);
		m_textTable = layout.FindViewById("sw_bnr_mask") as AbsoluteLayout;
		m_uvManager = uvMan;
		Hide();
		return base.InitializeFromLayout(layout, uvMan);
	}

	//// RVA: 0xA1159C Offset: 0xA1159C VA: 0xA1159C
	public void Hide()
	{
		foreach(var b in m_buttonBase)
		{
			b.StartChildrenAnimGoStop("st_wait", "st_wait");
		}
		IsEnter = false;
	}

	//// RVA: 0xA11714 Offset: 0xA11714 VA: 0xA11714
	//public bool IsPlaying() { }

	// RVA: 0xA11828 Offset: 0xA11828 VA: 0xA11828
	public bool IsPlayingEnd()
	{
		return !m_buttonBase[numToIndexList[ButtonData[(int)m_type].num]].IsPlaying();
	}

	//// RVA: 0xA11940 Offset: 0xA11940 VA: 0xA11940
	public void Enter(BottomButtonsType type, Action onClickButton1, Action onClickButton2, Action onClickButton3)
	{
		if(!IsEnter || m_type != type)
		{
			m_type = type;
			IsEnter = true;
			int idx = ButtonData[(int)type].num;
			m_text.text = MessageManager.Instance.GetMessage("menu", ButtonData[(int)type].attentionText);
			m_textTable.StartChildrenAnimGoStop(m_text.text != "" ? 0 : 1, m_text.text != "" ? 0 : 1);
			m_buttonBase[idx].StartChildrenAnimGoStop("go_in", "st_in");
			m_buttonTable.StartChildrenAnimGoStop(idx, idx);
			SettingTexture();
			SettingCallBack(onClickButton1, onClickButton2, onClickButton3);
		}
	}

	// RVA: 0xA12384 Offset: 0xA12384 VA: 0xA12384
	public void Leave()
	{
		if (!IsEnter)
			return;
		IsEnter = false;
		m_buttonBase[numToIndexList[ButtonData[(int)m_type].num]].StartChildrenAnimGoStop("go_out", "st_out");
	}

	//// RVA: 0xA124CC Offset: 0xA124CC VA: 0xA124CC
	//public void SettingPostPossible(bool isPosssible) { }

	//// RVA: 0xA11C20 Offset: 0xA11C20 VA: 0xA11C20
	private void SettingTexture()
	{
		BottomButtons b = m_bottomButtons[numToIndexList[ButtonData[(int)m_type].num]];
		for(int i = 0; i < b.m_font.Count; i++)
		{
			b.m_font[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(string.Format("deco_fnt_{0:D2}", ButtonData[(int)m_type].textureId[i])));
		}
	}

	//// RVA: 0xA11F00 Offset: 0xA11F00 VA: 0xA11F00
	private void SettingCallBack(Action onClickButton1, Action onClickButton2, Action onClickButton3)
	{
		BottomButtons b = m_bottomButtons[numToIndexList[ButtonData[(int)m_type].num]];
		for (int i = 0; i < b.m_font.Count; i++)
		{
			b.m_buttons[i].ClearOnClickCallback();
		}
		b.m_callback.Clear();
		b.m_callback.Add(onClickButton1);
		b.m_callback.Add(onClickButton2);
		b.m_callback.Add(onClickButton3);
		for (int i = 0; i < b.m_font.Count; i++)
		{
			int index = i;
			b.m_buttons[i].AddOnClickCallback(() =>
			{
				//0xA12BD4
				b.m_callback[index]();
			});
		}
	}
}
