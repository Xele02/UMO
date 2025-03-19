using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys.Gfx;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigBattleEvent : LayoutPopupConfigBase
	{
		[SerializeField]
		private Text m_classDesc; // 0x38
		[SerializeField]
		private Text m_classCaution; // 0x3C
		[SerializeField]
		private Text m_battleInfoDesc; // 0x40
		[SerializeField]
		private Text m_battleInfoCaution; // 0x44
		[SerializeField]
		private ActionButton m_buttonReSelect; // 0x48
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupBattleInfo; // 0x4C
		public Action OnClickClassSelect; // 0x50
		public Action<bool> OnClickBattleInfo; // 0x54

		// RVA: 0x1EC0224 Offset: 0x1EC0224 VA: 0x1EC0224 Slot: 6
		public override int GetContentsHeight()
		{
			return 250;
		}

		// RVA: 0x1EC022C Offset: 0x1EC022C VA: 0x1EC022C Slot: 7
		public override bool IsShow()
		{
			return true;
		}

		// // RVA: 0x1EC0234 Offset: 0x1EC0234 VA: 0x1EC0234 Slot: 8
		public override void SetStatus(ScrollRect scroll)
		{
			base.SetStatus(scroll);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextClassDesc(bk.GetMessageByLabel("set_battle_event_text_01"));
			SetTextClassCaution(bk.GetMessageByLabel("set_battle_event_text_02"));
			SetTextBattleInfoDesc(bk.GetMessageByLabel("set_battle_event_text_03"));
			SetTextBattleInfoCaution(bk.GetMessageByLabel("set_battle_event_text_04"));
			SetSelectToggleButton(m_toggleGroupBattleInfo, ConfigManager.Instance.Option.KPFAFLBICLA_IsNotBattleEventInfo ? 0 : 1);
			m_buttonReSelect.AddOnClickCallback(() =>
			{
				//0x1EC0880
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
				if(OnClickClassSelect != null)
					OnClickClassSelect();
			});
		}

		// // RVA: 0x1EC04CC Offset: 0x1EC04CC VA: 0x1EC04CC
		private void SetTextClassDesc(string text)
		{
			if(m_classDesc != null)
				m_classDesc.text = text;
		}

		// // RVA: 0x1EC058C Offset: 0x1EC058C VA: 0x1EC058C
		private void SetTextClassCaution(string text)
		{
			if(m_classCaution != null)
				m_classCaution.text = text;
		}

		// // RVA: 0x1EC064C Offset: 0x1EC064C VA: 0x1EC064C
		private void SetTextBattleInfoDesc(string text)
		{
			if(m_battleInfoDesc != null)
				m_battleInfoDesc.text = text;
		}

		// // RVA: 0x1EC070C Offset: 0x1EC070C VA: 0x1EC070C
		private void SetTextBattleInfoCaution(string text)
		{
			if(m_battleInfoCaution != null)
				m_battleInfoCaution.text = text;
		}

		// RVA: 0x1EC07CC Offset: 0x1EC07CC VA: 0x1EC07CC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			SetCallbackToggleButton(m_toggleGroupBattleInfo, (int value) =>
			{
				//0x1EC08F0
				ConfigUtility.PlaySeToggleButton();
				ConfigManager.Instance.Option.KPFAFLBICLA_IsNotBattleEventInfo = value != 1;
				if(OnClickBattleInfo != null)
					OnClickBattleInfo(value == 0);
			});
			Loaded();
			return true;
		}
	}
}
