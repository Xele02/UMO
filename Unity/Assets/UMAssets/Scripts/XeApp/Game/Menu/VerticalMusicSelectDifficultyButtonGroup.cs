using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private GridLayoutGroup m_layoutGroup;
		[SerializeField]
		private float m_4LineWidth;
		[SerializeField]
		private float m_6LineWidth;
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup;
		[SerializeField]
		private VerticalMusicSelectDifficultyButton[] m_diffityButton;
		[SerializeField]
		private InOutAnime m_inOut;

		// // Fields
		// private static string m_invalidText; // 0x0
		// [HeaderAttribute] // RVA: 0x674634 Offset: 0x674634 VA: 0x674634
		// [SerializeField] // RVA: 0x674634 Offset: 0x674634 VA: 0x674634
		// private GridLayoutGroup m_layoutGroup; // 0xC
		// [SerializeField] // RVA: 0x674684 Offset: 0x674684 VA: 0x674684
		// private float m_4LineWidth; // 0x10
		// [SerializeField] // RVA: 0x674694 Offset: 0x674694 VA: 0x674694
		// private float m_6LineWidth; // 0x14
		// [SerializeField] // RVA: 0x6746A4 Offset: 0x6746A4 VA: 0x6746A4
		// [HeaderAttribute] // RVA: 0x6746A4 Offset: 0x6746A4 VA: 0x6746A4
		// private UGUIToggleButtonGroup m_toggleButtonGroup; // 0x18
		// [HeaderAttribute] // RVA: 0x6746EC Offset: 0x6746EC VA: 0x6746EC
		// [SerializeField] // RVA: 0x6746EC Offset: 0x6746EC VA: 0x6746EC
		// private VerticalMusicSelectDifficultyButton[] m_diffityButton; // 0x1C
		// [HeaderAttribute] // RVA: 0x674734 Offset: 0x674734 VA: 0x674734
		// [SerializeField] // RVA: 0x674734 Offset: 0x674734 VA: 0x674734
		// private InOutAnime m_inOut; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x67477C Offset: 0x67477C VA: 0x67477C
		// private Action<int> <OnButtonClickListener>k__BackingField; // 0x24
		// private Vector2 m_spacingVector; // 0x28

		// // Properties
		// private Action<int> OnButtonClickListener { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F594C Offset: 0x6F594C VA: 0x6F594C
		// // RVA: 0xBDBE3C Offset: 0xBDBE3C VA: 0xBDBE3C
		// private Action<int> get_OnButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F595C Offset: 0x6F595C VA: 0x6F595C
		// // RVA: 0xBDBE44 Offset: 0xBDBE44 VA: 0xBDBE44
		// public void set_OnButtonClickListener(Action<int> value) { }

		// // RVA: 0xBDBE4C Offset: 0xBDBE4C VA: 0xBDBE4C
		// private void Awake() { }

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

		// // RVA: 0xBDCF40 Offset: 0xBDCF40 VA: 0xBDCF40
		// public void .ctor() { }

		// // RVA: 0xBDCFA8 Offset: 0xBDCFA8 VA: 0xBDCFA8
		// private static void .cctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F596C Offset: 0x6F596C VA: 0x6F596C
		// // RVA: 0xBDD01C Offset: 0xBDD01C VA: 0xBDD01C
		// private void <Awake>b__13_0(int index) { }
	}
}
