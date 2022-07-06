using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;
using TMPro;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicList : MonoBehaviour
	{
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675148 Offset: 0x675148 VA: 0x675148
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675190 Offset: 0x675190 VA: 0x675190
		private MusicScrollView m_musicScroll; // 0x10
		// [HeaderAttribute] // RVA: 0x6751E8 Offset: 0x6751E8 VA: 0x6751E8
		[SerializeField]
		private GameObject m_emptyTextObj; // 0x14
		[SerializeField]
		private TextMeshProUGUI m_emptyText; // 0x18
		[SerializeField]
		private Animator m_listUpdateAnim; // 0x1C
		// private static readonly int hashStateIn = Animator.StringToHash("Base Layer.In"); // 0x0
		// private static readonly int hashStateOut = Animator.StringToHash("Base Layer.Out"); // 0x4
		// private static readonly int hashStateClip = Animator.StringToHash("Base Layer.Clip"); // 0x8
		 private List<VerticalMusicDataList.MusicListData> m_musicList = new List<VerticalMusicDataList.MusicListData>(); // 0x20
		private int m_difficult; // 0x24
		private bool m_isSingleMusic; // 0x28

		public MusicScrollView MusicScrollView { get { return m_musicScroll; } } //0xBE1ABC
		public Action<int> OnUpdateCenter { get; set; } // 0x2C
		public Action OnUpdateClip { get; set; } // 0x30

		// // RVA: 0xBE1AE4 Offset: 0xBE1AE4 VA: 0xBE1AE4
		private void Awake()
		{
			m_musicScroll.OnUpdateCenter.AddListener(this.MusicUpdateCenterItem);
			m_musicScroll.OnUpdateListItem.AddListener(this.MusicUpdateListItem);
			m_musicScroll.OnUpdateClipItem.AddListener(() => {
				//0xBE4864
				UnityEngine.Debug.LogError("TODO OnUpdateClipItem");
			});
		}

		// // RVA: 0xBE1CB0 Offset: 0xBE1CB0 VA: 0xBE1CB0
		// public void SetMusicListStyle(VerticalMusicSelectUISapporter.MusicInfoStyle style, bool isTabNormal) { }

		// // RVA: 0xBE1F30 Offset: 0xBE1F30 VA: 0xBE1F30
		// public void SetScroll(int listNo) { }

		// // RVA: 0xBE1F34 Offset: 0xBE1F34 VA: 0xBE1F34
		// public void ChangeDifficult(int diff) { }

		// // RVA: 0xBE1F68 Offset: 0xBE1F68 VA: 0xBE1F68
		public void SetMusicDataList(List<VerticalMusicDataList.MusicListData> musicList, int listNo, int diff)
		{
			UnityEngine.Debug.Log("SetMusicDataList "+musicList.Count);
			m_isSingleMusic = false;
			m_musicList = musicList;
			m_difficult = diff;
			if(m_musicList.Count == 1)
			{
				m_musicList = new List<VerticalMusicDataList.MusicListData>(musicList);
				m_musicList.Add(m_musicList[0]);
				m_isSingleMusic = true;
			}
			m_musicScroll.ItemCount = m_musicList.Count;
			m_musicScroll.SetPosition(listNo);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F5C94 Offset: 0x6F5C94 VA: 0x6F5C94
		// // RVA: 0xBE2130 Offset: 0xBE2130 VA: 0xBE2130
		// public IEnumerator Co_UpdateAnim(Action outEndCallback) { }

		// // RVA: 0xBE21F8 Offset: 0xBE21F8 VA: 0xBE21F8
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xBE2228 Offset: 0xBE2228 VA: 0xBE2228
		// public void Leave() { }

		// // RVA: 0xBE228C Offset: 0xBE228C VA: 0xBE228C
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}

		// // RVA: 0xBE22B8 Offset: 0xBE22B8 VA: 0xBE22B8
		// public void SetEnable(bool isEneble) { }

		// // RVA: 0xBE233C Offset: 0xBE233C VA: 0xBE233C
		private void MusicUpdateCenterItem(int listIndex, MusicScrollCenterItem obj)
		{
			if(m_musicList.Count == 0)
				return;
			if(m_musicList.Count <= listIndex)
				return;
			UnityEngine.Debug.LogError("TODO MusicUpdateCenterItem");
			obj.SetTitle(m_musicList[listIndex].MusicName);
		}

		// // RVA: 0xBE3850 Offset: 0xBE3850 VA: 0xBE3850
		private void MusicUpdateListItem(int listIndex, MusicScrollItem obj)
		{
			UnityEngine.Debug.LogError("TODO MusicUpdateCenterItem");
		}
	}
}
