using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicList : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private MusicScrollView m_musicScroll;
		[SerializeField]
		private GameObject m_emptyTextObj;
		[SerializeField]
		private TextMeshProUGUI m_emptyText;
		[SerializeField]
		private Animator m_listUpdateAnim;

		// // Fields
		// [SerializeField] // RVA: 0x675148 Offset: 0x675148 VA: 0x675148
		// [HeaderAttribute] // RVA: 0x675148 Offset: 0x675148 VA: 0x675148
		// private InOutAnime m_inOut; // 0xC
		// [SerializeField] // RVA: 0x675190 Offset: 0x675190 VA: 0x675190
		// [HeaderAttribute] // RVA: 0x675190 Offset: 0x675190 VA: 0x675190
		// private MusicScrollView m_musicScroll; // 0x10
		// [HeaderAttribute] // RVA: 0x6751E8 Offset: 0x6751E8 VA: 0x6751E8
		// [SerializeField] // RVA: 0x6751E8 Offset: 0x6751E8 VA: 0x6751E8
		// private GameObject m_emptyTextObj; // 0x14
		// [SerializeField] // RVA: 0x675250 Offset: 0x675250 VA: 0x675250
		// private TextMeshProUGUI m_emptyText; // 0x18
		// [SerializeField] // RVA: 0x675260 Offset: 0x675260 VA: 0x675260
		// private Animator m_listUpdateAnim; // 0x1C
		// private static readonly int hashStateIn; // 0x0
		// private static readonly int hashStateOut; // 0x4
		// private static readonly int hashStateClip; // 0x8
		// private List<VerticalMusicDataList.MusicListData> m_musicList; // 0x20
		// private int m_difficult; // 0x24
		// private bool m_isSingleMusic; // 0x28
		// [CompilerGeneratedAttribute] // RVA: 0x675270 Offset: 0x675270 VA: 0x675270
		// private Action<int> <OnUpdateCenter>k__BackingField; // 0x2C
		// [CompilerGeneratedAttribute] // RVA: 0x675280 Offset: 0x675280 VA: 0x675280
		// private Action <OnUpdateClip>k__BackingField; // 0x30

		// // Properties
		// public MusicScrollView MusicScrollView { get; }
		// public Action<int> OnUpdateCenter { get; set; }
		// public Action OnUpdateClip { get; set; }

		// // Methods

		// // RVA: 0xBE1ABC Offset: 0xBE1ABC VA: 0xBE1ABC
		// public MusicScrollView get_MusicScrollView() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5C54 Offset: 0x6F5C54 VA: 0x6F5C54
		// // RVA: 0xBE1AC4 Offset: 0xBE1AC4 VA: 0xBE1AC4
		// public Action<int> get_OnUpdateCenter() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5C64 Offset: 0x6F5C64 VA: 0x6F5C64
		// // RVA: 0xBE1ACC Offset: 0xBE1ACC VA: 0xBE1ACC
		// public void set_OnUpdateCenter(Action<int> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5C74 Offset: 0x6F5C74 VA: 0x6F5C74
		// // RVA: 0xBE1AD4 Offset: 0xBE1AD4 VA: 0xBE1AD4
		// public Action get_OnUpdateClip() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5C84 Offset: 0x6F5C84 VA: 0x6F5C84
		// // RVA: 0xBE1ADC Offset: 0xBE1ADC VA: 0xBE1ADC
		// public void set_OnUpdateClip(Action value) { }

		// // RVA: 0xBE1AE4 Offset: 0xBE1AE4 VA: 0xBE1AE4
		// private void Awake() { }

		// // RVA: 0xBE1CB0 Offset: 0xBE1CB0 VA: 0xBE1CB0
		// public void SetMusicListStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style, bool isTabNormal) { }

		// // RVA: 0xBE1F30 Offset: 0xBE1F30 VA: 0xBE1F30
		// public void SetScroll(int listNo) { }

		// // RVA: 0xBE1F34 Offset: 0xBE1F34 VA: 0xBE1F34
		// public void ChangeDifficult(int diff) { }

		// // RVA: 0xBE1F68 Offset: 0xBE1F68 VA: 0xBE1F68
		// public void SetMusicDataList(List<VerticalMusicDataList.MusicListData> musicList, int listNo, int diff) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5C94 Offset: 0x6F5C94 VA: 0x6F5C94
		// // RVA: 0xBE2130 Offset: 0xBE2130 VA: 0xBE2130
		// public IEnumerator Co_UpdateAnim(Action outEndCallback) { }

		// // RVA: 0xBE21F8 Offset: 0xBE21F8 VA: 0xBE21F8
		// public void Enter() { }

		// // RVA: 0xBE2228 Offset: 0xBE2228 VA: 0xBE2228
		// public void Leave() { }

		// // RVA: 0xBE228C Offset: 0xBE228C VA: 0xBE228C
		// public bool IsPlaying() { }

		// // RVA: 0xBE22B8 Offset: 0xBE22B8 VA: 0xBE22B8
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xBE233C Offset: 0xBE233C VA: 0xBE233C
		// private void MusicUpdateCenterItem(int listIndex, MusicScrollCenterItem obj) { }

		// // RVA: 0xBE3850 Offset: 0xBE3850 VA: 0xBE3850
		// private void MusicUpdateListItem(int listIndex, MusicScrollItem obj) { }

		// // RVA: 0xBE4718 Offset: 0xBE4718 VA: 0xBE4718
		// public void .ctor() { }

		// // RVA: 0xBE47A4 Offset: 0xBE47A4 VA: 0xBE47A4
		// private static void .cctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5D0C Offset: 0x6F5D0C VA: 0x6F5D0C
		// // RVA: 0xBE4864 Offset: 0xBE4864 VA: 0xBE4864
		// private void <Awake>b__21_0() { }
	}
}
