using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicListDetail : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675290 Offset: 0x675290 VA: 0x675290
		private Text m_musicName; // 0xC
		// [HeaderAttribute] // RVA: 0x6752D8 Offset: 0x6752D8 VA: 0x6752D8
		[SerializeField]
		private Text m_musicLevel; // 0x10
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675320 Offset: 0x675320 VA: 0x675320
		private UGUIButton m_rewardButton; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675368 Offset: 0x675368 VA: 0x675368
		private UGUIButton m_rankingButton; // 0x18
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x6753B0 Offset: 0x6753B0 VA: 0x6753B0
		private UGUIButton m_specialPerformButton; // 0x1C
		// [TooltipAttribute] // RVA: 0x675408 Offset: 0x675408 VA: 0x675408
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675408 Offset: 0x675408 VA: 0x675408
		private Image m_rewardScore; // 0x20
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x675480 Offset: 0x675480 VA: 0x675480
		private Image m_rewardConbo; // 0x24
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6754CC Offset: 0x6754CC VA: 0x6754CC
		private Image m_rewardClear; // 0x28
		// [HeaderAttribute] // RVA: 0x675518 Offset: 0x675518 VA: 0x675518
		[SerializeField]
		private InOutAnime m_inOut; // 0x2C

		// public Action OnRewardButtonClickListener { private get; set; } // 0x30
		// public Action OnRankingButtonClickListener { private get; set; } // 0x34
		// public Action OnSpecialPerformButtonClickListener { private get; set; } // 0x38

		// // RVA: 0xBE4DC0 Offset: 0xBE4DC0 VA: 0xBE4DC0
		private void Awake()
		{
			TodoLogger.Log(0, "!!!");
		}

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
