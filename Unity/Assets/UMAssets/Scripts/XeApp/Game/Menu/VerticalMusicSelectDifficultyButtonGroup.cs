using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButtonGroup : MonoBehaviour
	{
		// private static string m_invalidText = "-"; // 0x0
		// [HeaderAttribute] // RVA: 0x674634 Offset: 0x674634 VA: 0x674634
		[SerializeField]
		private GridLayoutGroup m_layoutGroup; // 0xC
		[SerializeField]
		private float m_4LineWidth = 23.0f; // 0x10
		[SerializeField]
		private float m_6LineWidth = 28.0f; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6746A4 Offset: 0x6746A4 VA: 0x6746A4
		private UGUIToggleButtonGroup m_toggleButtonGroup; // 0x18
		// [HeaderAttribute] // RVA: 0x6746EC Offset: 0x6746EC VA: 0x6746EC
		[SerializeField]
		private VerticalMusicSelectDifficultyButton[] m_diffityButton; // 0x1C
		// [HeaderAttribute] // RVA: 0x674734 Offset: 0x674734 VA: 0x674734
		[SerializeField]
		private InOutAnime m_inOut; // 0x20
		// private Vector2 m_spacingVector = new Vector2(0, 0); // 0x28

		// public Action<int> OnButtonClickListener { private get; set; } // 0x24

		// // RVA: 0xBDBE4C Offset: 0xBDBE4C VA: 0xBDBE4C
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xBDBF2C Offset: 0xBDBF2C VA: 0xBDBF2C
		// public void SetInputEnable(bool isEnable) { }

		// // RVA: 0xBDBFC0 Offset: 0xBDBFC0 VA: 0xBDBFC0
		// public void SetDifficultStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style) { }

		// // RVA: 0xBDC448 Offset: 0xBDC448 VA: 0xBDC448
		// public void SetDifficultyButton(Difficulty.Type difficulty) { }

		// // RVA: 0xBDC580 Offset: 0xBDC580 VA: 0xBDC580
		// public void SetDifficultyButtonStyle(VerticalMusicSelectDifficultyButtonGroup.ButtonStyle style) { }

		// // RVA: 0xBDC3CC Offset: 0xBDC3CC VA: 0xBDC3CC
		// public void SetDifficultyStatus(int index, bool isNew, bool isClear, RhythmGameConsts.ResultComboType comboRank) { }

		// // RVA: 0xBDCD20 Offset: 0xBDCD20 VA: 0xBDCD20
		// public void SetMusicLevel(int index, int musicLevel, VerticalMusicSelectDifficultyButtonGroup.ButtonStyle style) { }

		// // RVA: 0xBDCE0C Offset: 0xBDCE0C VA: 0xBDCE0C
		// public void Enter() { }

		// // RVA: 0xBDCE3C Offset: 0xBDCE3C VA: 0xBDCE3C
		// public void Leave() { }

		// // RVA: 0xBDCEA0 Offset: 0xBDCEA0 VA: 0xBDCEA0
		// public bool IsPlaying() { }

		// // RVA: 0xBDCECC Offset: 0xBDCECC VA: 0xBDCECC
		// public void SetEnable(bool isEneble) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F596C Offset: 0x6F596C VA: 0x6F596C
		// // RVA: 0xBDD01C Offset: 0xBDD01C VA: 0xBDD01C
		// private void <Awake>b__13_0(int index) { }
	}
}
