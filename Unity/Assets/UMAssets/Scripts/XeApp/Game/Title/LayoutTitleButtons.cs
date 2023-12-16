using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections;
using mcrs;

namespace XeApp.Game.Title
{
	public class LayoutTitleButtons : LayoutUGUIScriptBase
	{
		public enum eButtonType
		{
			Support = 0,
			Inheriting = 1,
		}

		[SerializeField]
		private ActionButton m_Inheriting; // 0x14
		[SerializeField]
		private ActionButton m_Support; // 0x18
		private AbsoluteLayout m_root; // 0x24
		private AbsoluteLayout[] m_buttonTbl = new AbsoluteLayout[2]; // 0x28

		public Action ButtonCallbackInheriting { get; set; } // 0x1C
		public Action ButtonCallbackSupport { get; set; } // 0x20

		// // RVA: 0xE35834 Offset: 0xE35834 VA: 0xE35834
		public void SwitchButtonLabel(LayoutTitleButtons.eButtonType type)
		{
			if(m_buttonTbl[(int)type] != null)
			{
				m_buttonTbl[(int)type].StartAllAnimGoStop(((int)type).ToString("D2"));
			}
		}

		// // RVA: 0xE35950 Offset: 0xE35950 VA: 0xE35950
		public void CallbackClear()
		{
			m_Inheriting.ClearOnClickCallback();
			m_Support.ClearOnClickCallback();
		}

		// // RVA: 0xE359A0 Offset: 0xE359A0 VA: 0xE359A0
		public void SetCallback()
		{
			if(m_Inheriting != null)
			{
				if(!AppEnv.IsCBT())
				{
					m_Inheriting.AddOnClickCallback(() => {
						//0xE3612C
						TodoLogger.LogNotImplemented("MenuBarPrefab Inheriting");
					});
				}
			}
			if(m_Support != null)
			{
				m_Support.AddOnClickCallback(() => {
					//0xE36198
					if (ButtonCallbackSupport != null)
						ButtonCallbackSupport();
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
		}

		// // RVA: 0xE35B70 Offset: 0xE35B70 VA: 0xE35B70
		// public void Reset() { }

		// // RVA: 0xE35B74 Offset: 0xE35B74 VA: 0xE35B74
		public void Show()
		{
			m_root.StartAllAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0xE35BF4 Offset: 0xE35BF4 VA: 0xE35BF4
		// public void Hide() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6B2EF8 Offset: 0x6B2EF8 VA: 0x6B2EF8
		// // RVA: 0xE35C74 Offset: 0xE35C74 VA: 0xE35C74
		private IEnumerator InheritingDark()
		{
			//0xE36208
			yield return null;
			m_Inheriting.Dark = true;
		}

		// // RVA: 0xE35D20 Offset: 0xE35D20 VA: 0xE35D20 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_buttonTbl[0] = layout.FindViewByExId("sw_title_btn_all_anim_sw_title_btn_anim_support") as AbsoluteLayout;
			m_buttonTbl[1] = layout.FindViewByExId("sw_title_btn_all_anim_sw_title_btn_anim_inheritance") as AbsoluteLayout;
			SetCallback();
			SwitchButtonLabel(eButtonType.Support);
			SwitchButtonLabel(eButtonType.Inheriting);
			m_Inheriting.ClearOnClickCallback();
			this.StartCoroutineWatched(InheritingDark());
			Loaded();
			return true;
		}
	}
}
