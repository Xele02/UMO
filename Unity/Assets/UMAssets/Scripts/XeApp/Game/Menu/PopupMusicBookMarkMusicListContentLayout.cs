using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkMusicListContentLayout : MonoBehaviour
	{
		[SerializeField]
		private UGUISwapScrollList m_scrollList; // 0xC
		[SerializeField]
		private GameObject m_scrollObjet; // 0x10
		[SerializeField]
		private Text m_musicNoneText; // 0x14
		private List<IBJAKJJICBC> m_muiscList = new List<IBJAKJJICBC>(); // 0x18

		public UGUISwapScrollList ScrollList { get { return m_scrollList; } } //0x16920E8

		// // RVA: 0x1691E88 Offset: 0x1691E88 VA: 0x1691E88
		// public void Initialized(List<IBJAKJJICBC> musicList) { }

		// // RVA: 0x16922F8 Offset: 0x16922F8 VA: 0x16922F8
		// private void UpdateList(int index, SwapScrollListContent content) { }

		// // RVA: 0x16920F0 Offset: 0x16920F0 VA: 0x16920F0
		// private void SetupList(int count) { }
	}
}
