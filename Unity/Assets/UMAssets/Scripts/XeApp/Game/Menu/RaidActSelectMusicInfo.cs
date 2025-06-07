using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Text;
using System;
using XeApp.Game.Common.uGUI;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class RaidActSelectMusicInfo : LayoutLabelScriptBase
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

		public enum InfoStyle
		{
			Music = 0,
			None = 1,
			Event = 2,
			MissionEvent = 3,
			BattleEvent = 4,
			NoReward = 5,
			SimulationLive = 6,
			Raid = 7,
		}

		public enum DiffTabStyle
		{
			None = 0,
			N4 = 1,
			N5 = 2,
			N3 = 3,
		}

		private Style m_style; // 0x18
		private bool m_unitOnly; // 0x1C
		private bool m_notUnitLive; // 0x1D
		private Number m_number; // 0x20
		private static readonly MusicSelectDiffButton.IconType[] s_diffButtonTypes = new MusicSelectDiffButton.IconType[5]
		{
			MusicSelectDiffButton.IconType.EASY, MusicSelectDiffButton.IconType.NORMAL, MusicSelectDiffButton.IconType.HARD, MusicSelectDiffButton.IconType.VERY_HARD, MusicSelectDiffButton.IconType.EXTREME
		}; // 0x0
		private static readonly MusicSelectDiffButton.IconType[] s_diffButtonTypes_line6 = new MusicSelectDiffButton.IconType[3]
		{
			MusicSelectDiffButton.IconType.HARD_PLUS, MusicSelectDiffButton.IconType.VERY_HARD_PLUS, MusicSelectDiffButton.IconType.EXTREME_PLUS
		}; // 0x4
		[SerializeField]
		private List<MusicSelectDiffButton> m_diffButtons; // 0x24
		[SerializeField]
		private Text m_musicTitle; // 0x28
		[SerializeField]
		private Text m_singerName; // 0x2C
		[SerializeField]
		private Text m_musicLevel; // 0x30
		[SerializeField]
		private Text m_reward; // 0x34
		[SerializeField]
		private Text m_highscore; // 0x38
		[SerializeField]
		private Text m_comboCount; // 0x3C
		[SerializeField]
		private Text m_noInfoText; // 0x40
		[SerializeField]
		private Text m_eventTitle; // 0x44
		[SerializeField]
		private Text m_eventDesc; // 0x48
		[SerializeField]
		private Text m_eventPeriod; // 0x4C
		[SerializeField]
		private Text m_simMusicTitle; // 0x50
		[SerializeField]
		private Text m_simSingerName; // 0x54
		[SerializeField]
		private RawImageEx m_cdJacketImage; // 0x58
		[SerializeField]
		private ActionButton m_unitButton; // 0x5C
		[SerializeField]
		private RawImageEx m_imageOnOff; // 0x60
		[SerializeField]
		private RawImageEx m_imageDisable; // 0x64
		[SerializeField]
		private ActionButton m_arrorwLeft; // 0x68
		[SerializeField]
		private ActionButton m_arrorwRight; // 0x6C
		[SerializeField]
		private SwaipTouch m_swipeTouch; // 0x70
		[SerializeField]
		private SwaipTouch m_swipeTouch6; // 0x74
		private LayoutSymbolData m_symbolMain; // 0x78
		private LayoutSymbolData m_symbolInfoStyle; // 0x7C
		private LayoutSymbolData m_symbolMusicInfoStyle; // 0x80
		private LayoutSymbolData m_symbolRank; // 0x84
		private LayoutSymbolData m_symbolAttr; // 0x88
		private LayoutSymbolData m_symbolCombo; // 0x8C
		private LayoutSymbolData m_symbolDiffTabNum; // 0x90
		private List<LayoutSymbolData> m_symbolDiffStyles; // 0x94
		private LayoutSymbolData m_symbolJacketFrameAttr; // 0x98
		private LayoutSymbolData m_symbolUnitliveStyle; // 0x9C
		private MusicSelectDiffButton m_selectedDiffButton; // 0xA0
		private List<MusicSelectDiffButton> m_usingDiffButtons = new List<MusicSelectDiffButton>(5); // 0xA4
		private List<LayoutSymbolData> m_usingDiffStyles = new List<LayoutSymbolData>(5); // 0xA8
		private StringBuilder m_stringBuffer = new StringBuilder(64); // 0xAC
		private AbsoluteLayout m_normalFrameAnim; // 0xB0
		private AbsoluteLayout m_simulationFrameAnim; // 0xB4
		private AbsoluteLayout m_arrowButtonAnim; // 0xB8
		private string m_noInfoTextLine4; // 0xBC
		private string m_noInfoTextLine6; // 0xC0
		private string[,] m_imageNameList = new string[5, 3]
		{
			{ "", "", "" },
			{ "btn_unit_icon_02_01", "btn_unit_icon_02_02", "btn_unit_icon_02_03" },
			{ "btn_unit_icon_03_01", "btn_unit_icon_03_02", "btn_unit_icon_03_03" },
			{ "btn_unit_icon_04_01", "btn_unit_icon_04_02", "btn_unit_icon_04_03" },
			{ "btn_unit_icon_05_01", "btn_unit_icon_05_02", "btn_unit_icon_05_03" }
		}; // 0xC4
		private Rect[,] m_imageRectList = new Rect[5, 3]; // 0xC8
		private IBJAKJJICBC m_musicData; // 0xCC
		private MMOLNAHHDOM m_unitLiveLocalSaveData; // 0xD0
		private const int SWAIP_VALUE = 100;
		private const int FLICK_VALUE = 50;
		private Action<Style> m_onUpdateStyle; // 0xDC
		private bool m_isShow; // 0xE0
		private bool m_swipeTouchEnable = true; // 0xE1
		private const char s_fillChar = '\x30';
		public Action<Difficulty.Type> onChangedDifficulty { private get; set; } // 0xD4
		public Action<int> onChangedMusic { private get; set; } // 0xD8

		// // RVA: 0x144E974 Offset: 0x144E974 VA: 0x144E974
		// public void TryEnter() { }

		// // RVA: 0x144EA08 Offset: 0x144EA08 VA: 0x144EA08
		// public void TryLeave() { }

		// RVA: 0x144E984 Offset: 0x144E984 VA: 0x144E984
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x144EA18 Offset: 0x144EA18 VA: 0x144EA18
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x144EA9C Offset: 0x144EA9C VA: 0x144EA9C
		// public void Show() { }

		// // RVA: 0x144EB20 Offset: 0x144EB20 VA: 0x144EB20
		// public void Hide() { }

		// RVA: 0x144EBA4 Offset: 0x144EBA4 VA: 0x144EBA4
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x144999C Offset: 0x144999C VA: 0x144999C
		public void MakeCache()
		{
			for(int i = 0; i < m_diffButtons.Count; i++)
			{
				m_diffButtons[i].MakeCache();
			}
		}

		// // RVA: 0x144EBD0 Offset: 0x144EBD0 VA: 0x144EBD0
		public void ReleaseCache()
		{
			for(int i = 0; i < m_diffButtons.Count; i++)
			{
				m_diffButtons[i].ReleaseCache();
			}
		}

		// // RVA: 0x144ECAC Offset: 0x144ECAC VA: 0x144ECAC
		// public void SetJacketTexture(int id) { }

		// RVA: 0x144ECB0 Offset: 0x144ECB0 VA: 0x144ECB0
		public void InputEnable()
		{
			m_swipeTouchEnable = true;
			m_swipeTouch.enabled = true;
			m_swipeTouch6.enabled = true;
		}

		// RVA: 0x144ED10 Offset: 0x144ED10 VA: 0x144ED10
		public void InputDisable()
		{
			m_swipeTouchEnable = false;
			m_swipeTouch.enabled = false;
			m_swipeTouch6.enabled = false;
		}

		// RVA: 0x144ED70 Offset: 0x144ED70 VA: 0x144ED70
		private void Update()
		{
			if(IsLoaded())
			{
				if(m_swipeTouch.IsReady())
				{
					if(m_swipeTouch.enabled)
					{
						if(!PopupWindowManager.IsOpenPopupWindow())
						{
							if(m_swipeTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
								OnClickArrowButtonLeft();
							if(m_swipeTouch.IsSwaip(SwaipTouch.Direction.LEFT))
								OnClickArrowButtonRingt();
							if(m_swipeTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
								OnClickArrowButtonLeft();
							if(m_swipeTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
								OnClickArrowButtonRingt();
						}
					}
					if(m_swipeTouch6.enabled)
					{
						if(!PopupWindowManager.IsOpenPopupWindow())
						{
							if(m_swipeTouch6.IsSwaip(SwaipTouch.Direction.RIGHT))
								OnClickArrowButtonLeft();
							if(m_swipeTouch6.IsSwaip(SwaipTouch.Direction.LEFT))
								OnClickArrowButtonRingt();
							if(m_swipeTouch6.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
								OnClickArrowButtonLeft();
							if(m_swipeTouch6.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
								OnClickArrowButtonRingt();
						}
					}
				}

			}
		}

		// RVA: 0x144F128 Offset: 0x144F128 VA: 0x144F128
		public void SetArrow(bool isShow)
		{
			m_arrowButtonAnim.StartChildrenAnimGoStop(isShow ? "01" : "02");
			m_swipeTouch.enabled = isShow && m_swipeTouchEnable;
			m_swipeTouch6.enabled = isShow && m_swipeTouchEnable;
		}

		// RVA: 0x144F22C Offset: 0x144F22C VA: 0x144F22C
		public void SetRaidMusicInfoStyle(bool line6Mode/* = False*/)
		{
			m_symbolInfoStyle.StartAnim("music");
			m_symbolMusicInfoStyle.StartAnim("lv_only");
			m_normalFrameAnim.StartChildrenAnimGoStop(line6Mode ? "02" : "01");
			m_simulationFrameAnim.StartChildrenAnimGoStop(line6Mode ? "02" : "01");
		}

		// RVA: 0x144F348 Offset: 0x144F348 VA: 0x144F348
		public void SetDiffTabStyle(DiffTabStyle style, bool line6Mode/* = False*/, bool simulation/* = False*/)
		{
			switch(style)
			{
				case DiffTabStyle.None:
					SetupDiffButtonNone();
					break;
				case DiffTabStyle.N4:
					SetupDiffButton4(line6Mode, simulation);
					break;
				case DiffTabStyle.N5:
					SetupDiffButton5(line6Mode, simulation);
					break;
				case DiffTabStyle.N3:
					SetupDiffButton3(line6Mode, simulation);
					break;

			}
		}

		// RVA: 0x144FEA4 Offset: 0x144FEA4 VA: 0x144FEA4
		public void ChangeSelectedDiff(Difficulty.Type difficulty)
		{
			MusicSelectDiffButton b = FindDiffButton(difficulty);
			if(b != null)
			{
				m_selectedDiffButton = b;
				ApplySelectedDiffButton();
			}
		}

		// RVA: 0x14501D4 Offset: 0x14501D4 VA: 0x14501D4
		public void SetDiffLock(Difficulty.Type difficulty, bool isLock, bool withIcon/* = True*/)
		{
			MusicSelectDiffButton b = FindDiffButton(difficulty);
			if(b != null)
			{
				b.SetLock(isLock & withIcon);
				if(isLock)
				{
					b.Disable = true;
				}
				else
				{
					b.enabled = m_selectedDiffButton != b;
				}
			}
		}

		// RVA: 0x1450330 Offset: 0x1450330 VA: 0x1450330
		public void SetDiffStatus(Difficulty.Type difficulty, bool isNew, bool isClear, RhythmGameConsts.ResultComboType comboRank)
		{
			int idx = IndexOfDiffButton(difficulty);
			if(idx >= 0)
			{
				m_usingDiffButtons[idx].SetNew(isNew);
				if(isClear)
				{
					if(comboRank == RhythmGameConsts.ResultComboType.PerfectFullCombo)
						m_usingDiffStyles[idx].StartAnim("perfect");
					else if(comboRank == RhythmGameConsts.ResultComboType.FullCombo)
						m_usingDiffStyles[idx].StartAnim("full");
					else
						m_usingDiffStyles[idx].StartAnim("clear");
				}
				else
				{
					m_usingDiffStyles[idx].StartAnim("root");
				}
				m_usingDiffStyles[idx].StartAllDecoLoop();
			}
		}

		// RVA: 0x14505B0 Offset: 0x14505B0 VA: 0x14505B0
		public void SetMusicTitle(string title, string colorCode, bool simulation/* = False*/)
		{
			if(simulation)
			{
				m_simMusicTitle.text = title;
			}
			else
			{
				m_musicTitle.text = RichTextUtility.MakeColorTagString(title, colorCode);
			}
		}

		// RVA: 0x14506AC Offset: 0x14506AC VA: 0x14506AC
		public void SetSingerName(string name, bool simulation /*= False*/)
		{
			if(simulation)
			{
				m_simSingerName.text = name;
			}
			else
			{
				m_singerName.text = name;
			}
		}

		// RVA: 0x14506F0 Offset: 0x14506F0 VA: 0x14506F0
		public void SetMusicLevel(string level)
		{
			m_musicLevel.text = level;
		}

		// // RVA: 0x145072C Offset: 0x145072C VA: 0x145072C
		// public void SetReward(int achieved, int num) { }

		// RVA: 0x145083C Offset: 0x145083C VA: 0x145083C
		public void SetHighscore(int highscore)
		{
			m_highscore.text = MakeFilledValue(highscore, 7) + JpStringLiterals.StringLiteral_381;
		}

		// RVA: 0x1450AE8 Offset: 0x1450AE8 VA: 0x1450AE8
		public void SetMusicScoreRank(ResultScoreRank.Type scoreRank)
		{
			switch(scoreRank)
			{
				case ResultScoreRank.Type.C:
					m_symbolRank.StartAnim("c");
					break;
				case ResultScoreRank.Type.B:
					m_symbolRank.StartAnim("b");
					break;
				case ResultScoreRank.Type.A:
					m_symbolRank.StartAnim("a");
					break;
				case ResultScoreRank.Type.S:
					m_symbolRank.StartAnim("s");
					break;
				case ResultScoreRank.Type.SS:
					m_symbolRank.StartAnim("ss");
					break;
				default:
					break;
				case ResultScoreRank.Type.Illegal:
					m_symbolRank.StartAnim("none");
					break;
			}
		}

		// RVA: 0x1450D20 Offset: 0x1450D20 VA: 0x1450D20
		public void SetMusicAttr(GameAttribute.Type attr)
		{
			m_symbolAttr.GoToFrame("index", (int)attr - 1);
		}

		// // RVA: 0x1450DA4 Offset: 0x1450DA4 VA: 0x1450DA4
		// public void SetMusicComboRank(RhythmGameConsts.ResultComboType comboRank, int comboCount) { }

		// // RVA: 0x1450EEC Offset: 0x1450EEC VA: 0x1450EEC
		// public void SetNoInfoMessage(string message4, string message6) { }

		// // RVA: 0x1450F38 Offset: 0x1450F38 VA: 0x1450F38
		// public void SetEventTitle(string evTitle) { }

		// // RVA: 0x1450F74 Offset: 0x1450F74 VA: 0x1450F74
		// public void SetEventDesc(string evDesc) { }

		// // RVA: 0x1450FB0 Offset: 0x1450FB0 VA: 0x1450FB0
		// public void SetEventPeriod(string evPeriod) { }

		// RVA: 0x1450FEC Offset: 0x1450FEC VA: 0x1450FEC
		public void SetCdJacket(int jacketId, GameAttribute.Type attr)
		{
			GameManager.Instance.MusicJacketTextureCache.Load(jacketId, (IiconTexture image) =>
			{
				//0x1452C70
				m_cdJacketImage.enabled = true;
				image.Set(m_cdJacketImage);
			});
			switch(attr)
			{
				case GameAttribute.Type.Yellow:
					m_symbolJacketFrameAttr.StartAnim("yellow");
					break;
				case GameAttribute.Type.Red:
					m_symbolJacketFrameAttr.StartAnim("red");
					break;
				case GameAttribute.Type.Blue:
					m_symbolJacketFrameAttr.StartAnim("blue");
					break;
				case GameAttribute.Type.All:
					m_symbolJacketFrameAttr.StartAnim("all");
					break;
			}
		}

		// RVA: 0x14511CC Offset: 0x14511CC VA: 0x14511CC
		public void SetupUnitLive(IBJAKJJICBC musicData, MMOLNAHHDOM saveData)
		{
			UnitButtonSetup(musicData, saveData, (Style style) =>
			{
				//0x1452D74
				if(!m_notUnitLive)
				{
					m_symbolUnitliveStyle.StartAnim(style == Style.Unit ? "unit" : "solo");
				}
				else
				{
					m_symbolUnitliveStyle.StartAnim("none");
				}
			});
		}

		// // RVA: 0x144F8BC Offset: 0x144F8BC VA: 0x144F8BC
		private void SetupDiffButton5(bool line6Mode, bool simulation)
		{
			m_symbolDiffTabNum.lyt.enabled = true;
			m_symbolDiffTabNum.StartAnim("n5");
			m_selectedDiffButton = null;
			m_usingDiffButtons.Clear();
			m_usingDiffButtons.AddRange(m_diffButtons);
			m_usingDiffStyles.Clear();
			m_usingDiffStyles.AddRange(m_symbolDiffStyles);
			SetupDiffButtons(line6Mode, simulation);
		}

		// // RVA: 0x144F408 Offset: 0x144F408 VA: 0x144F408
		private void SetupDiffButton4(bool line6Mode, bool simulation)
		{
			m_symbolDiffTabNum.lyt.enabled = true;
			m_symbolDiffTabNum.StartAnim("n4");
			m_selectedDiffButton = null;
			m_usingDiffButtons.Clear();
			m_usingDiffButtons.Add(m_diffButtons[0]);
			m_usingDiffButtons.Add(m_diffButtons[1]);
			m_usingDiffButtons.Add(m_diffButtons[2]);
			m_usingDiffButtons.Add(m_diffButtons[4]);
			m_diffButtons[3].Hidden = true;
			m_usingDiffStyles.Clear();
			m_usingDiffStyles.Add(m_symbolDiffStyles[0]);
			m_usingDiffStyles.Add(m_symbolDiffStyles[1]);
			m_usingDiffStyles.Add(m_symbolDiffStyles[2]);
			m_usingDiffStyles.Add(m_symbolDiffStyles[4]);
			SetupDiffButtons(line6Mode, simulation);
		}

		// // RVA: 0x144FA64 Offset: 0x144FA64 VA: 0x144FA64
		private void SetupDiffButton3(bool line6Mode, bool simulation)
		{
			m_symbolDiffTabNum.lyt.enabled = true;
			m_symbolDiffTabNum.StartAnim("s4");
			m_selectedDiffButton = null;
			m_usingDiffButtons.Clear();
			m_usingDiffButtons.Add(m_diffButtons[0]);
			m_usingDiffButtons.Add(m_diffButtons[1]);
			m_usingDiffButtons.Add(m_diffButtons[4]);
			m_diffButtons[2].Hidden = true;
			m_diffButtons[3].Hidden = true;
			m_usingDiffStyles.Clear();
			m_usingDiffStyles.Add(m_symbolDiffStyles[0]);
			m_usingDiffStyles.Add(m_symbolDiffStyles[1]);
			m_usingDiffStyles.Add(m_symbolDiffStyles[4]);
			SetupDiffButtons(line6Mode, simulation);
		}

		// // RVA: 0x144F3B0 Offset: 0x144F3B0 VA: 0x144F3B0
		private void SetupDiffButtonNone()
		{
			m_symbolDiffTabNum.lyt.enabled = false;
		}

		// // RVA: 0x144FF54 Offset: 0x144FF54 VA: 0x144FF54
		private MusicSelectDiffButton FindDiffButton(Difficulty.Type difficulty)
		{
			for(int i = 0; i < m_usingDiffButtons.Count; i++)
			{
				if(m_usingDiffButtons[i].GetDifficulty() == difficulty)
					return m_usingDiffButtons[i];
			}
			return null;
		}

		// // RVA: 0x14504C0 Offset: 0x14504C0 VA: 0x14504C0
		private int IndexOfDiffButton(Difficulty.Type difficulty)
		{
			for(int i = 0; i < m_usingDiffButtons.Count; i++)
			{
				if(m_usingDiffButtons[i].GetDifficulty() == difficulty)
					return i;
			}
			return -1;
		}

		// // RVA: 0x1451694 Offset: 0x1451694 VA: 0x1451694
		private void SetupDiffButtons(bool line6Mode, bool simulation)
		{
			MusicSelectDiffButton.IconType[] l = line6Mode ? s_diffButtonTypes_line6 : s_diffButtonTypes;
			for(int i = 0; i < m_usingDiffButtons.Count; i++)
			{
				m_usingDiffButtons[i].SetIconType(l[i], simulation);
			}
		}

		// // RVA: 0x1451848 Offset: 0x1451848 VA: 0x1451848
		private void OnClickDiffButton(MusicSelectDiffButton clickedButton)
		{
			if(m_selectedDiffButton == clickedButton)
				return;
			m_selectedDiffButton = clickedButton;
			ApplySelectedDiffButton();
			if(onChangedDifficulty != null)
				onChangedDifficulty(clickedButton.GetDifficulty());
		}

		// // RVA: 0x1450044 Offset: 0x1450044 VA: 0x1450044
		private void ApplySelectedDiffButton()
		{
			for(int i = 0; i < m_usingDiffButtons.Count; i++)
			{
				if(m_usingDiffButtons[i] == m_selectedDiffButton)
				{
					m_usingDiffButtons[i].SetOn();
					m_usingDiffButtons[i].enabled = false;
				}
				else
				{
					m_usingDiffButtons[i].enabled = true;
					m_usingDiffButtons[i].SetOff();
				}
			}
		}

		// // RVA: 0x14508E4 Offset: 0x14508E4 VA: 0x14508E4
		private string MakeFilledValue(int value, int length)
		{
			int n = 0;
			if(value != 0)
			{
				n = 1;
				int d = value;
				while(d > 9)
				{
					d /= 10;
					n++;
				}
			}
			m_stringBuffer.Clear();
			if(length - n > 0)
			{
				m_stringBuffer.Append('0', length - n);
				m_stringBuffer.Set(RichTextUtility.MakeColorTagString(m_stringBuffer.ToString(), SystemTextColor.ConservativeColor));
			}
			if(n > 0)
			{
				m_stringBuffer.Append(value);
			}
			return m_stringBuffer.ToString();
		}

		// // RVA: 0x1451930 Offset: 0x1451930 VA: 0x1451930
		// private int CalcDigitCount(int value) { }

		// // RVA: 0x1451280 Offset: 0x1451280 VA: 0x1451280
		private void UnitButtonSetup(IBJAKJJICBC musicData, MMOLNAHHDOM saveData, Action<Style> onUpdateStyle)
		{
			m_musicData = musicData;
			m_unitLiveLocalSaveData = saveData;
			m_unitOnly = musicData.HAMPEDFMIAD_HasOnlyMultiDivaMode();
			BitArray b = new BitArray(new int[1] { musicData.BNCMJNMIDIN_AvaiableDivaModes });
			for(int i = 4; i >= 0; i--)
			{
				if(b[i])
				{
					m_number = (Number)i;
					break;
				}
			}
			m_style = saveData.NMBAHHJLGPP_IsMultiDiva(musicData.GHBPLHBNMBK_FreeMusicId) ? Style.Unit : Style.Solo;
			if(!musicData.KLOGLLFOAPL_HasMultiDivaMode())
				m_style = Style.Solo;
			m_notUnitLive = !musicData.PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF.ALNCPFNNBLH_0);
			m_imageDisable.uvRect = m_imageRectList[(int)m_number, 2];
			m_imageOnOff.uvRect = m_imageRectList[(int)m_number, (int)m_style];
			if(!m_unitOnly)
			{
				m_unitButton.Disable = false;
				m_unitButton.Hidden = m_notUnitLive;
			}
			else
			{
				m_unitButton.Disable = true;
				m_unitButton.Hidden = false;
			}
			m_onUpdateStyle = onUpdateStyle;
			if(onUpdateStyle != null)
				onUpdateStyle(m_style);
		}

		// // RVA: 0x145196C Offset: 0x145196C VA: 0x145196C
		private void OnClickChangeButton()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_SETTING_001);
			SwhichStyle();
		}

		// // RVA: 0x14519D0 Offset: 0x14519D0 VA: 0x14519D0
		private void SwhichStyle()
		{
			m_style = m_style == Style.Solo ? Style.Unit : Style.Solo;
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(m_musicData.GHBPLHBNMBK_FreeMusicId, m_style == Style.Unit);
			SetupUnitLive(m_musicData, m_unitLiveLocalSaveData);
		}

		// RVA: 0x1451A68 Offset: 0x1451A68 VA: 0x1451A68
		public int GetDivaCount()
		{
			if(m_musicData.DBIGDCOHOIC_IsMultiDanceUnlocked() && m_style == Style.Unit && m_number > Number.Solo && m_number < Number.Num)
				return (int)m_number + 1;
			return 1;
		}

		// // RVA: 0x144F048 Offset: 0x144F048 VA: 0x144F048
		private void OnClickArrowButtonLeft()
		{
			if(onChangedMusic != null)
				onChangedMusic(-1);
		}

		// // RVA: 0x144F0B8 Offset: 0x144F0B8 VA: 0x144F0B8
		private void OnClickArrowButtonRingt()
		{
			if(onChangedMusic != null)
				onChangedMusic(1);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x711AD4 Offset: 0x711AD4 VA: 0x711AD4
		// // RVA: 0x1451AC8 Offset: 0x1451AC8 VA: 0x1451AC8
		private IEnumerator Co_Initialize()
		{
			//0x1452E84
			yield return null;
			SetupDiffButton5(false, false);
			Loaded();			
		}

		// RVA: 0x1451B74 Offset: 0x1451B74 VA: 0x1451B74 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolInfoStyle = CreateSymbol("info_style", layout);
			m_symbolMusicInfoStyle = CreateSymbol("info_music_style", layout);
			m_symbolRank = CreateSymbol("rank", layout);
			m_symbolAttr = CreateSymbol("attr", layout);
			m_symbolCombo = CreateSymbol("combo", layout);
			m_symbolDiffTabNum = CreateSymbol("diff_tab_num", layout);
			m_symbolDiffStyles = new List<LayoutSymbolData>(m_diffButtons.Count);
			for(int i = 0; i < m_diffButtons.Count; i++)
			{
				m_symbolDiffStyles.Add(CreateSymbol(string.Format("diff_n{0}_style", i + 1), layout));
			}
			for(int i = 0; i < m_diffButtons.Count; i++)
			{
				MusicSelectDiffButton button = m_diffButtons[i];
				m_diffButtons[i].ClearOnClickCallback();
				m_diffButtons[i].AddOnClickCallback(() =>
				{
					//0x1452E50
					OnClickDiffButton(button);
				});
			}
			m_normalFrameAnim = layout.FindViewByExId("swtbl_sel_music_info_s_m_fr_non") as AbsoluteLayout;
			m_simulationFrameAnim = layout.FindViewByExId("swtbl_sel_music_info_s_m_fr_non_02") as AbsoluteLayout;
			m_symbolJacketFrameAttr = CreateSymbol("jacket_frame_attr", layout);
			m_symbolUnitliveStyle = CreateSymbol("unitlive_style", layout);
			m_arrowButtonAnim = layout.FindViewByExId("swtbl_sel_music_info_swtbl_arrow_onoff") as AbsoluteLayout;
			for(int i = 0; i < m_imageNameList.GetLength(0); i++)
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
			m_unitButton.AddOnClickCallback(() =>
			{
				//0x1452E44
				OnClickChangeButton();
			});
			m_arrorwRight.AddOnClickCallback(() =>
			{
				//0x1452E48
				OnClickArrowButtonRingt();
			});
			m_arrorwLeft.AddOnClickCallback(() =>
			{
				//0x1452E4C
				OnClickArrowButtonLeft();
			});
			m_swipeTouch.SetAdjustment(true, false, 100, 100, 50, 50, true);
			m_swipeTouch6.SetAdjustment(true, false, 100, 100, 50, 50, true);
			m_swipeTouch.SetMute(true);
			m_swipeTouch6.SetMute(true);
			this.StartCoroutineWatched(Co_Initialize());
			return true;
		}
	}
}
