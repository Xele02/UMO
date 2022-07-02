using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;
using System.Text;
using UnityEngine.EventSystems;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MenuButtonAnim : ActionButton
	{
		public enum ButtonType
		{
			NONE = -1,
			HOME = 0,
			SETTING = 1,
			VOP = 2,
			LIVE = 3,
			GACHA = 4,
			QUEST = 5,
			MENU = 6,
			BUTTON_TYPE_MAX = 7,
		}

		private enum BaseType
		{
			Default = 0,
			Selected = 1,
		}


		private static readonly string s_buttonFontUVFormat = "cmn_menu_btn_font_off_{0:D2}"; // 0x0
		private static readonly string s_selectedButtonFontUVFormat = "cmn_menu_btn_font_on_{0:D2}"; // 0x4
		private static readonly int[] s_buttonIdToExidNumber = new int[7] {1, 2, 2, 4, 2, 2, 7}; // 0x8
		private static readonly string[] s_buttonBaseExidFormat = new string[3] { "sw_menu_btn_{0:D2}_anim_cmn_menu_btn_off_{1:D2}",
																					"sw_menu_btn_{0:D2}_anim_swtbl_menu_fnt_02",
																					"sw_menu_btn_{0:D2}_anim_font_01_eff"}; // 0xC
		private static readonly int[] s_buttonIdToBaseExidNumber = new int[7] { 1, 2, 2, 2, 2, 2, 1 }; // 0x10
		[SerializeField]
		private int m_buttonId; // 0x80
		[SerializeField]
		private MenuButtonAnim.ButtonType m_buttonType; // 0x84
		[SerializeField]
		private MenuBarPrefab m_menu; // 0x88
		[SerializeField]
		private List<RawImageEx> m_typeImages; // 0x8C
		[SerializeField]
		private List<RawImageEx> m_selectedTypeImages; // 0x90
		private List<AbsoluteLayout> m_base_layout; // 0x94
		private MenuButtonAnim.BaseType m_base_type; // 0x98
		private StringBuilder m_type_exid = new StringBuilder(); // 0x9C
		private bool m_is_decide_anim; // 0xA0

		// public int buttonId { get; } 0xEC6EE8
		public bool buttonAnimeDisable { get; set; } // 0xA1

		// RVA: 0xEC6EF8 Offset: 0xEC6EF8 VA: 0xEC6EF8
		private void Update()
		{
			if(m_is_decide_anim)
			{
				if(IsPlaying())
					return;
				m_abs.StartAllAnimGoStop("st_wait");
				m_is_decide_anim = false;
				m_menu.SetButtonClick(true);
			}
		}

		// RVA: 0xEC6FBC Offset: 0xEC6FBC VA: 0xEC6FBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			ChangeButtonTypeImage(m_buttonType, uvMan);
			m_base_layout = new List<AbsoluteLayout>(s_buttonBaseExidFormat.Length);
			for(int i = 0; i < s_buttonBaseExidFormat.Length; i++)
			{
				AbsoluteLayout v = null;
				if(i == 0)
				{
					v = m_abs.FindViewByExId(string.Format(s_buttonBaseExidFormat[i], s_buttonIdToExidNumber[m_buttonId - 1], s_buttonIdToBaseExidNumber[m_buttonId - 1])) as AbsoluteLayout;
				}
				else
				{
					v = m_abs.FindViewByExId(string.Format(s_buttonBaseExidFormat[i], s_buttonIdToExidNumber[m_buttonId - 1])) as AbsoluteLayout;
				}
				if(v != null)
				{
					AbsoluteLayout childLayout = GetChildAbsoluteLayout(v);
					if(childLayout == null)
					{
						object[] obj = new object[2];
						obj[0] = name;
						obj[1] = v.EXID;
						UnityEngine.Debug.LogWarningFormat("Unable to find child layout in object {0}, EXID : {1}", obj);
					}
					else
					{
						m_base_layout.Add(childLayout);
					}
				}
			}
			AddOnClickCallback(this.PushButtonCallback);
			return true;
		}

		// // RVA: 0xEC7B14 Offset: 0xEC7B14 VA: 0xEC7B14
		private void PushButtonCallback()
		{
			UnityEngine.Debug.LogError("TOTO button Push callback");
		}

		// RVA: 0xEC7BE8 Offset: 0xEC7BE8 VA: 0xEC7BE8 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		// // RVA: 0xEC3ED0 Offset: 0xEC3ED0 VA: 0xEC3ED0
		// public void OnButtonNone() { }

		// // RVA: 0xEC3DEC Offset: 0xEC3DEC VA: 0xEC3DEC
		public void ChangeSelectBaseButton()
		{
			if(buttonAnimeDisable)
				return;
			if(Disable)
				return;
			m_base_type = BaseType.Selected;
			ChangeButtonBase(BaseType.Selected);
		}

		// // RVA: 0xEC3F4C Offset: 0xEC3F4C VA: 0xEC3F4C
		public void ChangeNotSelectBaseButton()
		{
			if(buttonAnimeDisable)
				return;
			if(Disable)
				return;
			m_base_type = BaseType.Default;
			ChangeButtonBase(BaseType.Default);
			SetOff();
		}

		// // RVA: 0xEC7D80 Offset: 0xEC7D80 VA: 0xEC7D80
		// public void SetButtonType(MenuButtonAnim.ButtonType type) { }

		// // RVA: 0xEC7608 Offset: 0xEC7608 VA: 0xEC7608
		private void ChangeButtonTypeImage(MenuButtonAnim.ButtonType type, TexUVListManager uvMan)
		{
			if(IsLoaded())
			{
				m_type_exid.SetFormat(s_buttonFontUVFormat, (int)type + 1);
				TexUVData data = uvMan.GetUVData(m_type_exid.ToString());
				Rect r  = LayoutUGUIUtility.MakeUnityUVRect(data);
				for(int i = 0; i < m_typeImages.Count; i++)
				{
					m_typeImages[i].uvRect = r;
				}
				m_type_exid.SetFormat(s_selectedButtonFontUVFormat, (int)type + 1);
				r = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(m_type_exid.ToString()));
				for(int i = 0; i < m_selectedTypeImages.Count; i++)
				{
					m_selectedTypeImages[i].uvRect = r;
				}
				
			}
		}

		// // RVA: 0xEC7BF0 Offset: 0xEC7BF0 VA: 0xEC7BF0
		private void ChangeButtonBase(MenuButtonAnim.BaseType type)
		{
			UnityEngine.Debug.LogError("TODO ChangeButtonBase");
		}

		// // RVA: 0xEC7D88 Offset: 0xEC7D88 VA: 0xEC7D88
		// public void SetMenuPrefab(MenuBarPrefab menu) { }

		// // RVA: 0xEC7D90 Offset: 0xEC7D90 VA: 0xEC7D90
		// public bool IsPlayAnim() { }

		// // RVA: 0xEC6EFC Offset: 0xEC6EFC VA: 0xEC6EFC
		// private void UpdateAnime() { }

		// // RVA: 0xEC7D98 Offset: 0xEC7D98 VA: 0xEC7D98
		// private AbsoluteLayout FindAbsoluteLayout(AbsoluteLayout root, MenuButtonAnim.ExidPaths exids, int idToNumber) { }

		// // RVA: 0xEC7A2C Offset: 0xEC7A2C VA: 0xEC7A2C
		private AbsoluteLayout GetChildAbsoluteLayout(AbsoluteLayout parent)
		{
			for(int i = 0; i < parent.viewCount; i++)
			{
				if(parent[i] is AbsoluteLayout)
					return parent[i] as AbsoluteLayout;
			}
			return null;
		}
	}
}
