using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LobbyCoopMissionWindow : LayoutUGUIScriptBase
	{
		public enum eButtonType
		{
			None = 0,
			Challenge = 1,
			Receive = 2,
			GeIcont = 3,
		}

		public enum QuestPositino
		{
			Up = 0,
			Middle = 1,
			Down = 2,
			NUM = 3,
		}

		private const int PROGRESS_ANIM_COUNT = 100;
		private const int ItemNum = 3;
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671DDC Offset: 0x671DDC VA: 0x671DDC
		private ActionButton[] m_iconButtonList = new ActionButton[ItemNum]; // 0x14
		//[HeaderAttribute] // RVA: 0x671E48 Offset: 0x671E48 VA: 0x671E48
		[SerializeField]
		private ActionButton[] m_buttonChallenge = new ActionButton[ItemNum]; // 0x18
		//[HeaderAttribute] // RVA: 0x671E98 Offset: 0x671E98 VA: 0x671E98
		[SerializeField]
		private ActionButton[] m_buttonReceive = new ActionButton[ItemNum]; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671EF0 Offset: 0x671EF0 VA: 0x671EF0
		private Text[] m_desc = new Text[ItemNum]; // 0x20
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671F44 Offset: 0x671F44 VA: 0x671F44
		private Text[] m_timeCount = new Text[ItemNum]; // 0x24
		//[HeaderAttribute] // RVA: 0x671F94 Offset: 0x671F94 VA: 0x671F94
		[SerializeField]
		private RawImageEx[] m_icon = new RawImageEx[ItemNum]; // 0x28
		//[HeaderAttribute] // RVA: 0x671FF0 Offset: 0x671FF0 VA: 0x671FF0
		[SerializeField]
		private NumberBase[] m_denominator = new NumberBase[ItemNum]; // 0x2C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x672044 Offset: 0x672044 VA: 0x672044
		private NumberBase[] m_molecule = new NumberBase[ItemNum]; // 0x30
		//[HeaderAttribute] // RVA: 0x672098 Offset: 0x672098 VA: 0x672098
		[SerializeField]
		private NumberBase[] m_itemCountList = new NumberBase[ItemNum]; // 0x34
		private AbsoluteLayout m_windowBase; // 0x38
		private AbsoluteLayout m_missionButtonAnim; // 0x3C
		private AbsoluteLayout[] m_gauge = new AbsoluteLayout[ItemNum]; // 0x40
		private Text m_period; // 0x44
		private List<FKMOKDCJFEN> m_paramList = new List<FKMOKDCJFEN>(); // 0x48
		public int[] ItemIdList = new int[ItemNum]; // 0x58
		public int[] ItemCountList = new int[ItemNum]; // 0x5C
		private AbsoluteLayout[] m_buttonAnimList = new AbsoluteLayout[ItemNum]; // 0x60
		private AbsoluteLayout[] m_ribbonEnable = new AbsoluteLayout[ItemNum]; // 0x64
		private LimitTimeWatcher[] m_timeWatcher = new LimitTimeWatcher[ItemNum]; // 0x68

		public Action<int> OnClickMissionReceive { get; set; } // 0x4C
		public Action<int> OnClickMissionChallenge { get; set; } // 0x50
		public Action<int> OnClickItemIcon { get; set; } // 0x54

		// RVA: 0x154D0AC Offset: 0x154D0AC VA: 0x154D0AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowBase = layout.FindViewById("sw_sel_que_ev_list_anim") as AbsoluteLayout;
			m_missionButtonAnim = layout.FindViewById("swtbl_sel_que_btn") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_period = txts.Where((Text _) =>
			{
				//0x154FA04
				return _.name == "period_01 (TextView)";
			}).First();
			for(int i = 0; i < ItemNum; i++)
			{
				AbsoluteLayout l = layout.FindViewByExId(string.Format("sw_sel_que_ev_list_sw_sel_que_items_list_0{0}", i + 1)) as AbsoluteLayout;
				m_gauge[i] = l.FindViewByExId("sw_sel_que_items_list_sw_sel_que_progress_anim") as AbsoluteLayout;
				m_buttonAnimList[i] = l.FindViewByExId("sw_sel_que_items_list_swtbl_sel_que_btn") as AbsoluteLayout;
				m_ribbonEnable[i] = l.FindViewByExId("sw_sel_que_items_list_swtbl_sel_que_badge_anim") as AbsoluteLayout;
			}
			Hide();
			return true;
		}

		// RVA: 0x154D830 Offset: 0x154D830 VA: 0x154D830
		public void Awake()
		{
			for(int i = 0; i < m_timeWatcher.Length; i++)
			{
				m_timeWatcher[i] = new LimitTimeWatcher();
			}
		}

		// RVA: 0x154D930 Offset: 0x154D930 VA: 0x154D930
		public void Update()
		{
			for(int i = 0; i < m_timeWatcher.Length; i++)
			{
				if(m_timeWatcher[i] != null)
				{
					m_timeWatcher[i].Update();
				}
			}
		}

		// // RVA: 0x154D9F8 Offset: 0x154D9F8 VA: 0x154D9F8
		public void SetActionButton()
		{
			for(int i = 0; i < ItemNum; i++)
			{
				int index = i;
				m_iconButtonList[i].ClearOnClickCallback();
				m_buttonChallenge[i].ClearOnClickCallback();
				m_buttonReceive[i].ClearOnClickCallback();
				m_iconButtonList[i].AddOnClickCallback(() =>
				{
					//0x154FA84
					OnClickItemIcon(index);
				});
				m_buttonChallenge[i].AddOnClickCallback(() =>
				{
					//0x154FB18
					OnClickMissionChallenge(index);
				});
				m_buttonReceive[i].AddOnClickCallback(() =>
				{
					//0x154FBAC
					OnClickMissionReceive(index);
				});
			}
		}

		// // RVA: 0x154DD80 Offset: 0x154DD80 VA: 0x154DD80
		public void MissionButtonAnimaitonType(int _btnType)
		{
			if(_btnType == 3)
			{
				m_missionButtonAnim.StartAllAnimGoStop("03");
			}
			else if(_btnType == 2)
			{
				m_missionButtonAnim.StartAllAnimGoStop("02");
			}
			else if(_btnType == 1)
			{
				m_missionButtonAnim.StartAllAnimGoStop("01");
			}
		}

		// // RVA: 0x154DE60 Offset: 0x154DE60 VA: 0x154DE60
		public void SetGauge(int index, int _num, int _dec)
		{
			if(m_gauge[index] != null)
			{
				if(_dec < _num)
					_num = _dec;
				int s = (int)(_num * 100.0f / _dec);
				m_gauge[index].StartAllAnimGoStop(s, s);
			}
		}

		// // RVA: 0x154DF58 Offset: 0x154DF58 VA: 0x154DF58
		public void SetPeriod(string _text)
		{
			if(m_period != null)
				m_period.text = _text;
		}

		// // RVA: 0x154E01C Offset: 0x154E01C VA: 0x154E01C
		public void SetLimitTime(long _start, long _end)
		{
			SetPeriod(GetStringDay("quest_tiemr_e001", _start, _end));
		}

		// // RVA: 0x154E7F0 Offset: 0x154E7F0 VA: 0x154E7F0
		public void SetDesc(int index, string _text)
		{
			if(m_desc[index] == null)
				return;
			m_desc[index].text = _text;
		}

		// // RVA: 0x154E920 Offset: 0x154E920 VA: 0x154E920
		public void SettingTimer(long remainTime, int index)
		{
			if(remainTime == 0)
				return;
			m_timeWatcher[index].onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x154FC40
				ApplyRemainTime(remain, index);
			};
			m_timeWatcher[index].onEndCallback = null;
			m_timeWatcher[index].WatchStart(remainTime, true);
		}

		// // RVA: 0x154EB30 Offset: 0x154EB30 VA: 0x154EB30
		private void ApplyRemainTime(long remainSec, int index)
		{
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out d, out h, out m, out s);
			m_timeCount[index].text = MessageManager.Instance.GetMessage("menu", "music_event_remain_prefix") + MusicSelectSceneBase.MakeRemainTime(d, h, m, s);
		}

		// // RVA: 0x154ECC4 Offset: 0x154ECC4 VA: 0x154ECC4
		// public void SetTimeCount(int index, long _time) { }

		// // RVA: 0x154EEE0 Offset: 0x154EEE0 VA: 0x154EEE0
		private void TimeTextEnable(int index, bool _enable)
		{
			m_timeCount[index].enabled = _enable;
		}

		// // RVA: 0x154EF4C Offset: 0x154EF4C VA: 0x154EF4C
		// public void SetTimeCountEnable(bool _enable) { }

		// // RVA: 0x154EFF0 Offset: 0x154EFF0 VA: 0x154EFF0
		public void SetItemIcon(int _index, int _iconId)
		{
			if(m_icon == null)
				return;
			MenuScene.Instance.ItemTextureCache.Load(_iconId, (IiconTexture texture) =>
			{
				//0x154FC88
				if(texture != null)
				{
					texture.Set(m_icon[_index]);
				}
			});
		}

		// // RVA: 0x154F164 Offset: 0x154F164 VA: 0x154F164
		public void SetQuentConpCont(int index, int conpNum, int maxNum)
		{
			if(maxNum < conpNum)
				conpNum = maxNum;
			m_denominator[index].SetNumber(maxNum, 0);
			m_molecule[index].SetNumber(conpNum, 0);
		}

		// // RVA: 0x154F250 Offset: 0x154F250 VA: 0x154F250
		public void SetButtonState(int index, int state)
		{
			switch(state)
			{
				case 0:
					m_buttonAnimList[index].StartChildrenAnimGoStop("04");
					m_ribbonEnable[index].StartChildrenAnimGoStop("02");
					TimeTextEnable(index, false);
					break;
				case 1:
					m_buttonAnimList[index].StartChildrenAnimGoStop("01");
					m_ribbonEnable[index].StartChildrenAnimGoStop("01");
					TimeTextEnable(index, true);
					break;
				case 2:
					m_buttonAnimList[index].StartChildrenAnimGoStop("02");
					m_ribbonEnable[index].StartChildrenAnimGoStop("01");
					TimeTextEnable(index, true);
					break;
				case 3:
					m_buttonAnimList[index].StartChildrenAnimGoStop("03");
					m_ribbonEnable[index].StartChildrenAnimGoStop("02");
					TimeTextEnable(index, false);
					break;
				default:
					break;
			}
		}

		// // RVA: 0x154F5FC Offset: 0x154F5FC VA: 0x154F5FC
		public void SetItemCount(int index, int count)
		{
			m_itemCountList[index].SetNumber(count, 0);
		}

		// // RVA: 0x154E0AC Offset: 0x154E0AC VA: 0x154E0AC
		private string GetStringDay(string label, long startTime, long endTime)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			DateTime t = Utility.GetLocalDateTime(startTime);
			string s = string.Format(bk.GetMessageByLabel("quest_tiemr_e003"), new object[5]{ t.Year, t.Month, t.Day, t.Hour, t.Minute });
			DateTime t2 = Utility.GetLocalDateTime(endTime);
			string s2 = string.Format(bk.GetMessageByLabel("quest_tiemr_e003"), new object[5]{ t2.Year, t2.Month, t2.Day, t2.Hour, t2.Minute });
			return string.Format(bk.GetMessageByLabel(label), s, s2);
		}

		// // RVA: 0x154F674 Offset: 0x154F674 VA: 0x154F674
		public void Enter()
		{
			m_windowBase.StartAllAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x154D7B0 Offset: 0x154D7B0 VA: 0x154D7B0
		public void Hide()
		{
			m_windowBase.StartAllAnimGoStop("st_wait", "st_wait");
		}

		// // RVA: 0x154F700 Offset: 0x154F700 VA: 0x154F700
		public void Leave()
		{
			m_windowBase.StartAllAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x154F78C Offset: 0x154F78C VA: 0x154F78C
		public bool IsPlaying()
		{
			return m_windowBase.IsPlaying();
		}
	}
}
