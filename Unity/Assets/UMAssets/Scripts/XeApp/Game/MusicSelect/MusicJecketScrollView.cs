using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MusicSelect
{
	public class MusicJecketScrollView : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x6658E8 Offset: 0x6658E8 VA: 0x6658E8
		[SerializeField]
		private UGUISwapScrollList m_scrollList; // 0xC
		//[HeaderAttribute] // RVA: 0x665938 Offset: 0x665938 VA: 0x665938
		[SerializeField]
		private MusicJacketScrollItem m_prefabContentItem; // 0x10
		//[HeaderAttribute] // RVA: 0x665998 Offset: 0x665998 VA: 0x665998
		[SerializeField]
		private UGUIButton m_buttonClose; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6659E0 Offset: 0x6659E0 VA: 0x6659E0
		private InOutAnime m_animeInOut; // 0x18
		private List<VerticalMusicDataList.MusicListData> m_musicList; // 0x1C

		public UGUISwapScrollList scrollList { get { return m_scrollList; } } //0xC9B9AC
		public Action OnClickCloseButtonListener { private get; set; } // 0x20
		public Action<int> OnClickJacketButtonListener { get; set; } // 0x24

		//// RVA: 0xC9B9D4 Offset: 0xC9B9D4 VA: 0xC9B9D4
		//public void PerformClickClose() { }

		//// RVA: 0xC9BA2C Offset: 0xC9BA2C VA: 0xC9BA2C
		//public void SetMusicList(List<VerticalMusicDataList.MusicListData> list) { }

		//// RVA: 0xC9BC10 Offset: 0xC9BC10 VA: 0xC9BC10
		public VerticalMusicDataList.MusicListData GetMusicList(int index)
		{
			if(m_musicList.Count <= index)
				return null;
			return m_musicList[index];
		}

		//// RVA: 0xC9BCCC Offset: 0xC9BCCC VA: 0xC9BCCC
		//public void Enter(Action endCallback) { }

		//// RVA: 0xC9BFA0 Offset: 0xC9BFA0 VA: 0xC9BFA0
		//public void Leave(Action endCallback) { }

		//// RVA: 0xC9C0B0 Offset: 0xC9C0B0 VA: 0xC9C0B0
		public void Initialize()
		{
			m_buttonClose.ClearOnClickCallback();
			m_buttonClose.AddOnClickCallback(() => {
				//0xC9C4A4
				if(OnClickCloseButtonListener != null)
					OnClickCloseButtonListener();
			});
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as MusicJacketScrollItem).SetVisible(true);
				(m_scrollList.ScrollObjects[i] as MusicJacketScrollItem).OnClickButtonListener = (int index) => {
					//0xC9C4B8
					if(OnClickJacketButtonListener != null)
					{
						OnClickJacketButtonListener(GetMusicList(index).ViewMusic.GHBPLHBNMBK_FreeMusicId);
					}
				};
			}
		}

		//// RVA: 0xC9C310 Offset: 0xC9C310 VA: 0xC9C310
		//public void ResetIndex() { }

		//// RVA: 0xC9BDDC Offset: 0xC9BDDC VA: 0xC9BDDC
		//public void SetInputOff(bool inputOff) { }
	}
}
