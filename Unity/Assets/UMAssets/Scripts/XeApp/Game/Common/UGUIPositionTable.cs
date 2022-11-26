using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class UGUIPositionTable : MonoBehaviour
	{
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68CA70 Offset: 0x68CA70 VA: 0x68CA70
		private List<Vector2> m_positionTable = new List<Vector2>(); // 0xC
		private RectTransform m_myRectTrans; // 0x10

		public int PositionCount { get { return m_positionTable.Count; } } //0x1CD9DA0
		private RectTransform myRectTrans { get {
			if(m_myRectTrans == null)
				m_myRectTrans = GetComponent<RectTransform>();
			return m_myRectTrans;
		} } //0x1CD9E18

		// RVA: 0x1CD9ECC Offset: 0x1CD9ECC VA: 0x1CD9ECC
		public void SetPosition(int index)
		{
			if(myRectTrans != null)
			{
				myRectTrans.anchoredPosition = m_positionTable[Mathf.Clamp(index, 0, PositionCount)];
			}
		}

	}
}
