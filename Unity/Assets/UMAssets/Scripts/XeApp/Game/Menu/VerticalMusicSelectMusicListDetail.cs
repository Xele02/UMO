using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicListDetail : MonoBehaviour
	{
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_musicLevel;
		[SerializeField]
		private UGUIButton m_rewardButton;
		[SerializeField]
		private UGUIButton m_rankingButton;
		[SerializeField]
		private UGUIButton m_specialPerformButton;
		[SerializeField]
		private Image m_rewardScore;
		[SerializeField]
		private Image m_rewardConbo;
		[SerializeField]
		private Image m_rewardClear;
		[SerializeField]
		private InOutAnime m_inOut;

		// // Fields
		// [SerializeField] // RVA: 0x675290 Offset: 0x675290 VA: 0x675290
		// [HeaderAttribute] // RVA: 0x675290 Offset: 0x675290 VA: 0x675290
		// private Text m_musicName; // 0xC
		// [HeaderAttribute] // RVA: 0x6752D8 Offset: 0x6752D8 VA: 0x6752D8
		// [SerializeField] // RVA: 0x6752D8 Offset: 0x6752D8 VA: 0x6752D8
		// private Text m_musicLevel; // 0x10
		// [SerializeField] // RVA: 0x675320 Offset: 0x675320 VA: 0x675320
		// [HeaderAttribute] // RVA: 0x675320 Offset: 0x675320 VA: 0x675320
		// private UGUIButton m_rewardButton; // 0x14
		// [SerializeField] // RVA: 0x675368 Offset: 0x675368 VA: 0x675368
		// [HeaderAttribute] // RVA: 0x675368 Offset: 0x675368 VA: 0x675368
		// private UGUIButton m_rankingButton; // 0x18
		// [SerializeField] // RVA: 0x6753B0 Offset: 0x6753B0 VA: 0x6753B0
		// [HeaderAttribute] // RVA: 0x6753B0 Offset: 0x6753B0 VA: 0x6753B0
		// private UGUIButton m_specialPerformButton; // 0x1C
		// [TooltipAttribute] // RVA: 0x675408 Offset: 0x675408 VA: 0x675408
		// [SerializeField] // RVA: 0x675408 Offset: 0x675408 VA: 0x675408
		// [HeaderAttribute] // RVA: 0x675408 Offset: 0x675408 VA: 0x675408
		// private Image m_rewardScore; // 0x20
		// [SerializeField] // RVA: 0x675480 Offset: 0x675480 VA: 0x675480
		// [TooltipAttribute] // RVA: 0x675480 Offset: 0x675480 VA: 0x675480
		// private Image m_rewardConbo; // 0x24
		// [SerializeField] // RVA: 0x6754CC Offset: 0x6754CC VA: 0x6754CC
		// [TooltipAttribute] // RVA: 0x6754CC Offset: 0x6754CC VA: 0x6754CC
		// private Image m_rewardClear; // 0x28
		// [HeaderAttribute] // RVA: 0x675518 Offset: 0x675518 VA: 0x675518
		// [SerializeField] // RVA: 0x675518 Offset: 0x675518 VA: 0x675518
		// private InOutAnime m_inOut; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x675560 Offset: 0x675560 VA: 0x675560
		// private Action <OnRewardButtonClickListener>k__BackingField; // 0x30
		// [CompilerGeneratedAttribute] // RVA: 0x675570 Offset: 0x675570 VA: 0x675570
		// private Action <OnRankingButtonClickListener>k__BackingField; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x675580 Offset: 0x675580 VA: 0x675580
		// private Action <OnSpecialPerformButtonClickListener>k__BackingField; // 0x38

		// // Properties
		// private Action OnRewardButtonClickListener { get; set; }
		// private Action OnRankingButtonClickListener { get; set; }
		// private Action OnSpecialPerformButtonClickListener { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F5D6C Offset: 0x6F5D6C VA: 0x6F5D6C
		// // RVA: 0xBE4D90 Offset: 0xBE4D90 VA: 0xBE4D90
		// private Action get_OnRewardButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5D7C Offset: 0x6F5D7C VA: 0x6F5D7C
		// // RVA: 0xBE4D98 Offset: 0xBE4D98 VA: 0xBE4D98
		// public void set_OnRewardButtonClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5D8C Offset: 0x6F5D8C VA: 0x6F5D8C
		// // RVA: 0xBE4DA0 Offset: 0xBE4DA0 VA: 0xBE4DA0
		// private Action get_OnRankingButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5D9C Offset: 0x6F5D9C VA: 0x6F5D9C
		// // RVA: 0xBE4DA8 Offset: 0xBE4DA8 VA: 0xBE4DA8
		// public void set_OnRankingButtonClickListener(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5DAC Offset: 0x6F5DAC VA: 0x6F5DAC
		// // RVA: 0xBE4DB0 Offset: 0xBE4DB0 VA: 0xBE4DB0
		// private Action get_OnSpecialPerformButtonClickListener() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5DBC Offset: 0x6F5DBC VA: 0x6F5DBC
		// // RVA: 0xBE4DB8 Offset: 0xBE4DB8 VA: 0xBE4DB8
		// public void set_OnSpecialPerformButtonClickListener(Action value) { }

		// // RVA: 0xBE4DC0 Offset: 0xBE4DC0 VA: 0xBE4DC0
		// private void Awake() { }

		// // RVA: 0xBE4F80 Offset: 0xBE4F80 VA: 0xBE4F80
		// public void SetMusicTitleName(string name, int index) { }

		// // RVA: 0xBE4FE4 Offset: 0xBE4FE4 VA: 0xBE4FE4
		// public void SetMusicLevel(int level, bool isLine6Mode) { }

		// // RVA: 0xBE5108 Offset: 0xBE5108 VA: 0xBE5108
		// public void SetRewardMark(bool isScore, bool isCombo, bool isClear) { }

		// // RVA: 0xBE5190 Offset: 0xBE5190 VA: 0xBE5190
		// public void Enter() { }

		// // RVA: 0xBE51C4 Offset: 0xBE51C4 VA: 0xBE51C4
		// public void Leave() { }

		// // RVA: 0xBE51F8 Offset: 0xBE51F8 VA: 0xBE51F8
		// public bool IsPlaying() { }

		// // RVA: 0xBE5224 Offset: 0xBE5224 VA: 0xBE5224
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5DCC Offset: 0x6F5DCC VA: 0x6F5DCC
		// // RVA: 0xBE522C Offset: 0xBE522C VA: 0xBE522C
		// private void <Awake>b__21_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5DDC Offset: 0x6F5DDC VA: 0x6F5DDC
		// // RVA: 0xBE5240 Offset: 0xBE5240 VA: 0xBE5240
		// private void <Awake>b__21_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5DEC Offset: 0x6F5DEC VA: 0x6F5DEC
		// // RVA: 0xBE5254 Offset: 0xBE5254 VA: 0xBE5254
		// private void <Awake>b__21_2() { }
	}
}
