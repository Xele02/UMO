using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class PopupMvModeLackDivaLayout : MonoBehaviour
{
	[SerializeField]
	private UGUISwapScrollList m_scrollList; // 0xC

	public UGUISwapScrollList ScrollList { get { return m_scrollList; } } //0xDFB69C
	public List<int> DivaIds { get; set; } // 0x10

	// // RVA: 0xDFB6B4 Offset: 0xDFB6B4 VA: 0xDFB6B4
	// public void DivaIconLoad(List<int> divaIds) { }

	// // RVA: 0xDFB7F0 Offset: 0xDFB7F0 VA: 0xDFB7F0
	// public void Setup(int count) { }

	// // RVA: 0xDFB9FC Offset: 0xDFB9FC VA: 0xDFB9FC
	// private void UpdateList(int index, SwapScrollListContent content) { }

	// // RVA: 0xDFB7F4 Offset: 0xDFB7F4 VA: 0xDFB7F4
	// private void SetupList(int count) { }
}
