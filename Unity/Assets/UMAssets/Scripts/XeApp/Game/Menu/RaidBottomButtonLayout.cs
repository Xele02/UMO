using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBottomButtonLayout : LayoutUGUIScriptBase
	{
		public enum RaidBottomBtn
		{
			EncounterBoss = 0,
			RequestHelp = 1,
			RequestHelpDone = 2,
			EventEnd = 3,
		}

		[SerializeField]
		private ActionButton m_requestHelpButton; // 0x14
		[SerializeField]
		private ActionButton m_encounterBossButton; // 0x18
		[SerializeField]
		private ActionButton m_itemButton; // 0x1C
		[SerializeField]
		private RawImageEx m_itemImage; // 0x20
		[SerializeField]
		private NumberBase m_itemNum; // 0x24
		[SerializeField]
		private NumberBase m_helpNum; // 0x28
		[SerializeField]
		private Text m_remainCount; // 0x2C
		private AbsoluteLayout m_bottomButtonAnim; // 0x30
		private AbsoluteLayout m_switchButton; // 0x34
		private AbsoluteLayout m_remainCountTbl; // 0x38
		private AbsoluteLayout m_helpNumAnim; // 0x3C
		private bool m_isShow; // 0x40
		public UnityAction PushRequestHelpButtonListner; // 0x44
		public UnityAction PushEncounterBossButtonListner; // 0x48
		public UnityAction PushItemButtonListner; // 0x4C
		private LimitTimeWatcher m_bossHelpWatcher = new LimitTimeWatcher(); // 0x50

		// RVA: 0x1BCCC7C Offset: 0x1BCCC7C VA: 0x1BCCC7C
		private void Update()
		{
			m_bossHelpWatcher.Update();
		}

		// RVA: 0x1BCCCA8 Offset: 0x1BCCCA8 VA: 0x1BCCCA8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = true;
			m_bottomButtonAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_bl_anim_sw_sel_music_raid_boss_menu") as AbsoluteLayout;
			m_switchButton = layout.FindViewByExId("sw_sel_music_raid_boss_menu_sw_sel_music_raid_boss_menu_01") as AbsoluteLayout;
			m_remainCountTbl = layout.FindViewByExId("swtbl_raid_frm_limit_onoff_anim_raid_frm_limit") as AbsoluteLayout;
			m_helpNumAnim = layout.FindViewByExId("sw_sel_music_raid_boss_menu_01_raid_boss_menu_fr") as AbsoluteLayout;
			m_requestHelpButton.AddOnClickCallback(OnPushRequestHelpButton);
			m_encounterBossButton.AddOnClickCallback(OnPushEncounterBossButton);
			m_itemButton.AddOnClickCallback(OnPushItemButton);
			m_remainCount.text = "--:--";
			return true;
		}

		// // RVA: 0x1BCD030 Offset: 0x1BCD030 VA: 0x1BCD030
		public void SetButtonType(RaidBottomBtn type)
		{
			switch(type)
			{
				case RaidBottomBtn.EncounterBoss:
					m_switchButton.StartSiblingAnimGoStop("02");
					m_remainCountTbl.StartAllAnimGoStop("02");
					break;
				case RaidBottomBtn.RequestHelp:
					m_switchButton.StartSiblingAnimGoStop("01");
					m_remainCountTbl.StartAllAnimGoStop("02");
					m_requestHelpButton.Disable = false;
					break;
				case RaidBottomBtn.RequestHelpDone:
					m_switchButton.StartSiblingAnimGoStop("01");
					m_remainCountTbl.StartAllAnimGoStop("01");
					m_requestHelpButton.Disable = true;
					break;
				case RaidBottomBtn.EventEnd:
					m_switchButton.StartSiblingAnimGoStop("02");
					m_remainCountTbl.StartAllAnimGoStop("02");
					m_encounterBossButton.Disable = true;
					break;
				default:
					break;
			}
		}

		// // RVA: 0x1BCD278 Offset: 0x1BCD278 VA: 0x1BCD278
		public void SetItemNum(int num)
		{
			m_itemNum.SetNumber(num, 0);
		}

		// // RVA: 0x1BCD2B8 Offset: 0x1BCD2B8 VA: 0x1BCD2B8
		public void SetBossHelpCount(int count)
		{
			m_helpNum.SetNumber(count, 0);
			m_helpNumAnim.StartSiblingAnimGoStop("01");
		}

		// // RVA: 0x1BCD368 Offset: 0x1BCD368 VA: 0x1BCD368
		public void HiddenBossHelpCount()
		{
			m_helpNumAnim.StartSiblingAnimGoStop("02");
		}

		// // RVA: 0x1BCD3E4 Offset: 0x1BCD3E4 VA: 0x1BCD3E4
		public void SetBossHelpWatcher(long remainTime, bool isHelpCount, bool IsBossOverLimit)
		{
			if(!isHelpCount)
			{
				HiddenBossHelpWatcher();
				m_bossHelpWatcher.onElapsedCallback = null;
				m_bossHelpWatcher.onEndCallback = null;
			}
			else
			{
				if(remainTime > -1 && !IsBossOverLimit)
				{
					m_bossHelpWatcher.onElapsedCallback = (long current, long limit, long remain) =>
					{
						//0x1BCDC04
						SetRemainBossHelpTimer(remain);
					};
					m_bossHelpWatcher.onEndCallback = (long remain) =>
					{
						//0x1BCDC24
						SetButtonType(RaidBottomBtn.RequestHelp);
					};
					m_bossHelpWatcher.WatchStart(remainTime, false);
				}
			}
		}

		// // RVA: 0x1BCD5A0 Offset: 0x1BCD5A0 VA: 0x1BCD5A0
		public void HiddenBossHelpWatcher()
		{
			m_remainCountTbl.StartAllAnimGoStop("02");
			m_bossHelpWatcher.onElapsedCallback = null;
			m_bossHelpWatcher.onEndCallback = null;
		}

		// // RVA: 0x1BCD664 Offset: 0x1BCD664 VA: 0x1BCD664
		public void SetRemainBossHelpTimer(long remainSec)
		{
			int h, m, s;
			OfferSelectScene.GetMiddleTime((int)remainSec, out h, out m, out s, true);
			m_remainCount.text = string.Format(MessageManager.Instance.GetMessage("menu", "raid_bossselect_rescue_time"), m, s);
		}

		// // RVA: 0x1BCD7C0 Offset: 0x1BCD7C0 VA: 0x1BCD7C0
		public void SetItemImage(int itemId)
		{
			MenuScene.Instance.ItemTextureCache.Load(itemId, (IiconTexture texture) =>
			{
				//0x1BCDC2C
				texture.Set(m_itemImage);
			});
		}

		// // RVA: 0x1BCD8D0 Offset: 0x1BCD8D0 VA: 0x1BCD8D0
		private void OnPushRequestHelpButton()
		{
			if(PushRequestHelpButtonListner != null)
				PushRequestHelpButtonListner();
		}

		// // RVA: 0x1BCD8E4 Offset: 0x1BCD8E4 VA: 0x1BCD8E4
		private void OnPushEncounterBossButton()
		{
			if(PushEncounterBossButtonListner != null)
				PushEncounterBossButtonListner();
		}

		// // RVA: 0x1BCD8F8 Offset: 0x1BCD8F8 VA: 0x1BCD8F8
		private void OnPushItemButton()
		{
			if(PushItemButtonListner != null)
				PushItemButtonListner();
		}

		// // RVA: 0x1BCD90C Offset: 0x1BCD90C VA: 0x1BCD90C
		// public void Show() { }

		// // RVA: 0x1BCD994 Offset: 0x1BCD994 VA: 0x1BCD994
		public void Hide()
		{
			m_isShow = false;
			m_bottomButtonAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x1BCDA1C Offset: 0x1BCDA1C VA: 0x1BCDA1C
		public void Enter()
		{
			if(!m_isShow)
			{
				m_bottomButtonAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x1BCDABC Offset: 0x1BCDABC VA: 0x1BCDABC
		public void Leave()
		{
			if(m_isShow)
			{
				m_bottomButtonAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x1BCDB5C Offset: 0x1BCDB5C VA: 0x1BCDB5C
		public bool IsPlaying()
		{
			return m_bottomButtonAnim.IsPlayingSibling();
		}
	}
}
