using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicSelectMusicInfo : LayoutLabelScriptBase
	{
		// private static readonly MusicSelectDiffButton.IconType[] s_diffButtonTypes = new MusicSelectDiffButton.IconType[5] {
		// 	1, 2, 3, 4, 5
		// }; // 0x0
		// private static readonly MusicSelectDiffButton.IconType[] s_diffButtonTypes_line6 = new MusicSelectDiffButton.IconType[3] {
		// 	6, 7, 8
		// }; // 0x4
		[SerializeField]
		private List<MusicSelectDiffButton> m_diffButtons; // 0x18
		[SerializeField]
		private Text m_musicTitle; // 0x1C
		[SerializeField]
		private Text m_singerName; // 0x20
		[SerializeField]
		private Text m_musicLevel; // 0x24
		[SerializeField]
		private Text m_reward; // 0x28
		[SerializeField]
		private Text m_highscore; // 0x2C
		[SerializeField]
		private Text m_comboCount; // 0x30
		[SerializeField]
		private Text m_noInfoText; // 0x34
		[SerializeField]
		private Text m_eventTitle; // 0x38
		[SerializeField]
		private Text m_eventDesc; // 0x3C
		[SerializeField]
		private Text m_eventPeriod; // 0x40
		[SerializeField]
		private Text m_simMusicTitle; // 0x44
		[SerializeField]
		private Text m_simSingerName; // 0x48
		// private LayoutSymbolData m_symbolMain; // 0x4C
		// private LayoutSymbolData m_symbolInfoStyle; // 0x50
		// private LayoutSymbolData m_symbolMusicInfoStyle; // 0x54
		// private LayoutSymbolData m_symbolRank; // 0x58
		// private LayoutSymbolData m_symbolAttr; // 0x5C
		// private LayoutSymbolData m_symbolCombo; // 0x60
		// private LayoutSymbolData m_symbolDiffTabNum; // 0x64
		// private List<LayoutSymbolData> m_symbolDiffStyles; // 0x68
		// private MusicSelectDiffButton m_selectedDiffButton; // 0x6C
		// private List<MusicSelectDiffButton> m_usingDiffButtons = new List<MusicSelectDiffButton>(5); // 0x70
		// private List<LayoutSymbolData> m_usingDiffStyles = new List<LayoutSymbolData>(5); // 0x74
		// private StringBuilder m_stringBuffer = new StringBuilder(); // 0x78
		// private AbsoluteLayout m_normalFrameAnim; // 0x7C
		// private AbsoluteLayout m_simulationFrameAnim; // 0x80
		// private string m_noInfoTextLine4; // 0x84
		// private string m_noInfoTextLine6; // 0x88
		// private bool m_isShow; // 0x90
		// private const char s_fillChar = '\x30';

		public Action<Difficulty.Type> onChangedDifficulty { private get; set; } // 0x8C

		// // RVA: 0x16792E0 Offset: 0x16792E0 VA: 0x16792E0
		// public void TryEnter() { }

		// // RVA: 0x1679374 Offset: 0x1679374 VA: 0x1679374
		public void TryLeave()
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo TryLeave");
		}

		// // RVA: 0x16792F0 Offset: 0x16792F0 VA: 0x16792F0
		public void Enter()
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo Enter");
		}

		// // RVA: 0x1679384 Offset: 0x1679384 VA: 0x1679384
		// public void Leave() { }

		// // RVA: 0x1679408 Offset: 0x1679408 VA: 0x1679408
		// public void Show() { }

		// // RVA: 0x167948C Offset: 0x167948C VA: 0x167948C
		public void Hide()
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo Hide");
		}

		// // RVA: 0x1679510 Offset: 0x1679510 VA: 0x1679510
		public bool IsPlaying()
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo IsPlaying");
			return false;
		}

		// // RVA: 0x167953C Offset: 0x167953C VA: 0x167953C
		public void MakeCache()
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo MakeCache");
		}

		// // RVA: 0x1679614 Offset: 0x1679614 VA: 0x1679614
		// public void ReleaseCache() { }

		// // RVA: 0x16796EC Offset: 0x16796EC VA: 0x16796EC
		// public void SetInfoStyle(MusicSelectMusicInfo.InfoStyle style, bool line6Mode = False) { }

		// // RVA: 0x1679AE8 Offset: 0x1679AE8 VA: 0x1679AE8
		// public void SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle style, bool line6Mode = False, bool simulation = False) { }

		// // RVA: 0x167A644 Offset: 0x167A644 VA: 0x167A644
		// public void ChangeSelectedDiff(Difficulty.Type difficulty) { }

		// // RVA: 0x167A9D4 Offset: 0x167A9D4 VA: 0x167A9D4
		// public void SetDiffLock(Difficulty.Type difficulty, bool isLock, bool withIcon = True) { }

		// // RVA: 0x167AB2C Offset: 0x167AB2C VA: 0x167AB2C
		// public void SetDiffStatus(Difficulty.Type difficulty, bool isNew, bool isClear, RhythmGameConsts.ResultComboType comboRank) { }

		// // RVA: 0x167AE08 Offset: 0x167AE08 VA: 0x167AE08
		// public void SetMusicTitle(string title, string colorCode, bool simulation = False) { }

		// // RVA: 0x167AF04 Offset: 0x167AF04 VA: 0x167AF04
		// public void SetSingerName(string name, bool simulation = False) { }

		// // RVA: 0x167AF48 Offset: 0x167AF48 VA: 0x167AF48
		// public void SetMusicLevel(string level) { }

		// // RVA: 0x167AF84 Offset: 0x167AF84 VA: 0x167AF84
		// public void SetReward(int achieved, int num) { }

		// // RVA: 0x167B094 Offset: 0x167B094 VA: 0x167B094
		// public void SetHighscore(int highscore) { }

		// // RVA: 0x167B2DC Offset: 0x167B2DC VA: 0x167B2DC
		// public void SetMusicScoreRank(ResultScoreRank.Type scoreRank) { }

		// // RVA: 0x167B514 Offset: 0x167B514 VA: 0x167B514
		// public void SetMusicAttr(GameAttribute.Type attr) { }

		// // RVA: 0x167B598 Offset: 0x167B598 VA: 0x167B598
		// public void SetMusicComboRank(RhythmGameConsts.ResultComboType comboRank, int comboCount) { }

		// // RVA: 0x167B6E0 Offset: 0x167B6E0 VA: 0x167B6E0
		public void SetNoInfoMessage(string message4, string message6)
		{
			TodoLogger.LogError(0, "MusicSelectMusicInfo SetNoInfoMessage");
		}

		// // RVA: 0x167B72C Offset: 0x167B72C VA: 0x167B72C
		// public void SetEventTitle(string evTitle) { }

		// // RVA: 0x167B768 Offset: 0x167B768 VA: 0x167B768
		// public void SetEventDesc(string evDesc) { }

		// // RVA: 0x167B7A4 Offset: 0x167B7A4 VA: 0x167B7A4
		// public void SetEventPeriod(string evPeriod) { }

		// // RVA: 0x167A05C Offset: 0x167A05C VA: 0x167A05C
		// private void SetupDiffButton5(bool line6Mode, bool simulation) { }

		// // RVA: 0x1679BA8 Offset: 0x1679BA8 VA: 0x1679BA8
		// private void SetupDiffButton4(bool line6Mode, bool simulation) { }

		// // RVA: 0x167A204 Offset: 0x167A204 VA: 0x167A204
		// private void SetupDiffButton3(bool line6Mode, bool simulation) { }

		// // RVA: 0x1679B50 Offset: 0x1679B50 VA: 0x1679B50
		// private void SetupDiffButtonNone() { }

		// // RVA: 0x167A6F4 Offset: 0x167A6F4 VA: 0x167A6F4
		// private MusicSelectDiffButton FindDiffButton(Difficulty.Type difficulty) { }

		// // RVA: 0x167ACB8 Offset: 0x167ACB8 VA: 0x167ACB8
		// private int IndexOfDiffButton(Difficulty.Type difficulty) { }

		// // RVA: 0x167B7E0 Offset: 0x167B7E0 VA: 0x167B7E0
		// private void SetupDiffButtons(bool line6Mode, bool simulation) { }

		// // RVA: 0x167B990 Offset: 0x167B990 VA: 0x167B990
		// private void OnClickDiffButton(MusicSelectDiffButton clickedButton) { }

		// // RVA: 0x167A844 Offset: 0x167A844 VA: 0x167A844
		// private void ApplySelectedDiffButton() { }

		// // RVA: 0x167B0D8 Offset: 0x167B0D8 VA: 0x167B0D8
		// private string MakeFilledValue(int value, int length) { }

		// // RVA: 0x167BAD0 Offset: 0x167BAD0 VA: 0x167BAD0
		// private int CalcDigitCount(int value) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F36FC Offset: 0x6F36FC VA: 0x6F36FC
		// // RVA: 0x167BB0C Offset: 0x167BB0C VA: 0x167BB0C
		// private IEnumerator Co_Initialize() { }

		// // RVA: 0x167BBB8 Offset: 0x167BBB8 VA: 0x167BBB8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			TodoLogger.LogError(0, "InitializeFromLayout MusicSelectionMusicInfo");
			return true;
		}
	}
}
