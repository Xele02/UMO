using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OptionMenuLayout : LayoutUGUIScriptBase
	{
		public enum ButtonLabel
		{
			SHOP = 0,
			ITEM = 1,
			PROFILE = 2,
			HONORARY = 3,
			EVENT_REVIEW = 4,
			CONFIG = 5,
			HELP = 6,
			RANKING = 7,
			CACHE_CLEAR = 8,
			TAKEOVER_DATA = 9,
			LINK = 10,
			BALANCE = 11,
			OPINION = 12,
			CONTACT = 13,
			TITLE = 14,
			BLOCKLIST = 15,
			_MAX = 16,
		}
		
		public const int ButtonLabelNum = 16;
		private readonly string[] buttonPathList = new string[16]
		{
			"btn_01 (AbsoluteLayout)/sw_opt_fnt_icon_01 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_01 (ImageView)",
			"btn_02 (AbsoluteLayout)/sw_opt_fnt_icon_01 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_01 (ImageView)",
			"btn_03 (AbsoluteLayout)/sel_opt_btn_fnt_icon_01s (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon (ImageView)",
			"btn_04 (AbsoluteLayout)/sel_opt_btn_fnt_icon_01s (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon (ImageView)",
			"btn_15 (AbsoluteLayout)/sel_opt_btn_fnt_icon_01s (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon (ImageView)",
			"btn_05 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (ImageView)",
			"btn_06 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (ImageView)",
			"btn_07 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (AbsoluteLayout)/sel_opt_btn_fnt_icon_05 (ImageView)",
			"btn_08 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_09 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_10 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_11 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_12 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_13 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_14 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)",
			"btn_16 (AbsoluteLayout)/sel_opt_btn_fnt_icon_08 (AbsoluteLayout)/swtexf_sel_opt_btn_fnt_icon_08 (ImageView)"
		}; // 0x14
		private readonly string[] buttonUvList = new string[16]
		{
			"sel_opt_btn_fnt_icon_06",
			"sel_opt_btn_fnt_icon_02",
			"sel_opt_btn_fnt_icon_01",
			"sel_opt_btn_fnt_icon_04",
			"sel_opt_btn_fnt_icon_16",
			"sel_opt_btn_fnt_icon_05",
			"sel_opt_btn_fnt_icon_15",
			"sel_opt_btn_fnt_icon_03",
			"sel_opt_btn_fnt_icon_09",
			"sel_opt_btn_fnt_icon_10",
			"sel_opt_btn_fnt_icon_13",
			"sel_opt_btn_fnt_icon_08",
			"sel_opt_btn_fnt_icon_11",
			"sel_opt_btn_fnt_icon_12",
			"sel_opt_btn_fnt_icon_14",
			"sel_opt_btn_fnt_icon_17"
		}; // 0x18
		private AbsoluteLayout m_abs; // 0x1C
		private List<ActionButton> m_btn = new List<ActionButton>(); // 0x20
		private List<Rect> m_btn_uv = new List<Rect>(); // 0x24
		private List<RawImageEx> m_btn_font = new List<RawImageEx>(); // 0x28
		private Action m_updater; // 0x2C
		private List<AbsoluteLayout> m_buttonLayout = new List<AbsoluteLayout>(); // 0x30
		private List<AbsoluteLayout> m_badgeParentLayoutList = new List<AbsoluteLayout>(); // 0x34
		private List<GameObject> m_badgeParentObjectList = new List<GameObject>(); // 0x38
		private List<BadgeIcon> m_badge = new List<BadgeIcon>(); // 0x3C

		// RVA: 0xDD43B8 Offset: 0xDD43B8 VA: 0xDD43B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewById("sel_btn_all") as AbsoluteLayout;
			Transform t = transform.Find("sel_btn_all (AbsoluteLayout)/sw_sel_btn_all (AbsoluteLayout)");
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < t.childCount; i++)
			{
				str.Clear();
				str.Append(buttonPathList[i]);
				m_btn_font.Add(t.Find(str.ToString()).GetComponent<RawImageEx>());
			}
			for(int i = 0; i < 16; i++)
			{
				m_buttonLayout.Add(layout.FindViewByExId(string.Format("sw_sel_btn_all_btn_{0:D2}", i + 1)) as AbsoluteLayout);
			}
			for(int i = 0; i < 16; i++)
			{
				str.Clear();
				str.Append(buttonUvList[i]);
				TexUVData data = uvMan.GetUVData(str.ToString());
				if(data != null)
				{
					m_btn_uv.Add(LayoutUGUIUtility.MakeUnityUVRect(data));
				}
			}
			LayoutUGUIRuntime parentRuntime = GetComponentInParent<LayoutUGUIRuntime>();
			for(int i = 0; i < t.childCount; i++)
			{
				AbsoluteLayout abs = layout.FindViewByExId(string.Format("sw_sel_btn_all_btn_{0:D2}", i + 1)) as AbsoluteLayout;
				if(abs != null)
				{
					bool found = false;
					for (int j = 0; j < 3; j++)
					{
						AbsoluteLayout abs2 = abs.FindViewById(string.Format("badge_{0}", j + 1)) as AbsoluteLayout;
						if(abs2 != null)
						{
							m_badge.Add(new BadgeIcon());
							m_badgeParentLayoutList.Add(abs2);
							m_badgeParentObjectList.Add(parentRuntime.FindRectTransform(abs2).gameObject);
							found = true;
						}
					}
					if(!found)
					{
						m_badge.Add(null);
						m_badgeParentLayoutList.Add(null);
						m_badgeParentObjectList.Add(null);
					}
				}
			}
			m_btn.AddRange(GetComponentsInChildren<ActionButton>(true));
			m_btn.Sort((ActionButton x, ActionButton y) =>
			{
				//0xDD6B94
				return x.name.CompareTo(y.name);
			});
			m_updater = UpdateLoad;
			return true;
		}

		// RVA: 0xDD4E00 Offset: 0xDD4E00 VA: 0xDD4E00
		public void InitializeBadge()
		{
			for(int i = 0; i < m_badge.Count; i++)
			{
				if(m_badge[i] != null)
				{
					m_badge[i].Initialize(m_badgeParentObjectList[i], m_badgeParentLayoutList[i]);
				}
			}
		}

		// RVA: 0xDD4FA4 Offset: 0xDD4FA4 VA: 0xDD4FA4
		public void ReleaseBadge()
		{
			for(int i = 0; i < m_badge.Count; i++)
			{
				if(m_badge[i] != null)
				{
					m_badge[i].Release();
				}
			}
		}

		// RVA: 0xDD50B8 Offset: 0xDD50B8 VA: 0xDD50B8
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		//// RVA: 0xDD50CC Offset: 0xDD50CC VA: 0xDD50CC
		private void UpdateLoad()
		{
			for(int i = 0; i < m_btn.Count; i++)
			{
				if (!m_btn[i].IsLoaded())
					return;
			}
			Loaded();
			m_updater = UpdateIdle;
		}

		//// RVA: 0xDD51F8 Offset: 0xDD51F8 VA: 0xDD51F8
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0xDD51FC Offset: 0xDD51FC VA: 0xDD51FC
		private void WaitEnterLeave()
		{
			if (m_abs.IsPlayingChildren())
				return;
			m_updater = UpdateIdle;
		}

		//// RVA: 0xDD52AC Offset: 0xDD52AC VA: 0xDD52AC
		//public void Out() { }

		// RVA: 0xDD532C Offset: 0xDD532C VA: 0xDD532C
		public void Enter()
		{
			m_abs.StartChildrenAnimGoStop("go_in", "st_in");
			m_updater = WaitEnterLeave;
		}

		// RVA: 0xDD53F4 Offset: 0xDD53F4 VA: 0xDD53F4
		public void Leave()
		{
			m_abs.StartChildrenAnimGoStop("go_out", "st_out");
			m_updater = WaitEnterLeave;
		}

		// RVA: 0xDD54BC Offset: 0xDD54BC VA: 0xDD54BC
		public bool IsPlaying()
		{
			return m_abs.IsPlayingChildren();
		}

		// RVA: 0xDD54E8 Offset: 0xDD54E8 VA: 0xDD54E8
		public void SetButtonLabel(int index, ButtonLabel label)
		{
			m_btn_font[index].uvRect = m_btn_uv[(int)label];
		}

		// RVA: 0xDD55D8 Offset: 0xDD55D8 VA: 0xDD55D8
		public void AddButtonClickEvent(int index, ButtonBase.OnClickCallback onClick)
		{
			if(index > -1 && index < m_btn.Count)
			{
				if(m_btn[index] != null)
				{
					m_btn[index].AddOnClickCallback(onClick);
				}
			}
		}

		// RVA: 0xDD5738 Offset: 0xDD5738 VA: 0xDD5738
		public void RemoveButtonClickEvent(int index)
		{
			if(index > -1 && index < m_btn.Count)
			{
				if(m_btn[index] != null)
				{
					m_btn[index].ClearOnClickCallback();
				}
			}
		}

		// RVA: 0xDD5890 Offset: 0xDD5890 VA: 0xDD5890
		public void ButtonDarkEnable(int index, bool enable)
		{
			if (index > -1 && index < m_btn.Count)
			{
				if (m_btn[index] != null)
				{
					m_btn[index].Dark = enable;
				}
			}
		}

		// RVA: 0xDD59F0 Offset: 0xDD59F0 VA: 0xDD59F0
		public void SetBadge(int index, BadgeConstant.ID id)
		{
			if(m_badge[index] != null)
			{
				m_badge[index].Set(id, "");
			}
		}

		// RVA: 0xDD5AE0 Offset: 0xDD5AE0 VA: 0xDD5AE0
		public void SetButtonEnable(int index, bool enable)
		{
			m_buttonLayout[index].enabled = enable;
		}
	}
}
