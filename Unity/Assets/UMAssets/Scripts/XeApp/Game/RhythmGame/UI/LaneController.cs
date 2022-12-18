using UnityEngine;
using System;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame.UI
{
	public class LaneController : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_linePrefab; // 0xC
		[SerializeField]
		private GameObject m_linePrefabWide; // 0x10
		private LaneList m_laneList; // 0x14
		private GameObject[] m_lineObject; // 0x18
		private Action<int, float> m_setActive; // 0x1C
		private Func<int, bool> m_isActive; // 0x20
		private MaterialPropertyBlock m_propertyBlock; // 0x24
		private int m_propertyID; // 0x28

		// // RVA: 0x15617B8 Offset: 0x15617B8 VA: 0x15617B8
		public void Instantiate(bool isWide)
		{
			GameObject line = null;
			if(!isWide)
			{
				line = Instantiate<GameObject>(m_linePrefab);
				m_setActive = SetLineAlphaNormal;
				m_isActive = IsActiveLineNormal;
			}
			else
			{
				line = Instantiate<GameObject>(m_linePrefabWide);
				m_setActive = SetLineAlphaWide;
				m_isActive = IsActiveLineWide;
				m_lineObject = new GameObject[line.transform.childCount];
				for(int i = 0; i < m_lineObject.Length; i++)
				{
					m_lineObject[i] = line.transform.GetChild(i).gameObject;
					m_lineObject[i].SetActive(!RhythmGameConsts.IsWingLine(i));
				}
			}
			line.transform.SetParent(transform, false);
			m_laneList = line.GetComponent<LaneList>();
			GetComponent<TouchCircleController>().SetAnimator(line.GetComponent<Animator>());
			m_propertyBlock = new MaterialPropertyBlock();
			m_propertyID = Shader.PropertyToID("_Alpha");
		}

		// // RVA: 0x1561CF4 Offset: 0x1561CF4 VA: 0x1561CF4
		public void SetVisibility(bool isVisible)
		{
			for(int i = 0; i < m_laneList.notesLineList.Length; i++)
			{
				m_laneList.notesLineList[i].enabled = isVisible;
			}
		}

		// // RVA: 0x1561DB4 Offset: 0x1561DB4 VA: 0x1561DB4
		private void SetLineAlphaNormal(int lineNo, float alpha)
		{
			return;
		}

		// // RVA: 0x1561DB8 Offset: 0x1561DB8 VA: 0x1561DB8
		private void SetLineAlphaWide(int lineNo, float alpha)
		{
			m_lineObject[lineNo].SetActive(alpha < 0);
			if(alpha < 0)
				return;
			m_propertyBlock.SetFloat(m_propertyID, alpha);
			m_laneList.buttonModelList[lineNo].SetPropertyBlock(m_propertyBlock);
			m_laneList.notesLineList[lineNo].SetPropertyBlock(m_propertyBlock);
		}

		// // RVA: 0x1561F60 Offset: 0x1561F60 VA: 0x1561F60
		// public void SetLineAlpha(int lineNo, float alpha) { }

		// // RVA: 0x1561FE8 Offset: 0x1561FE8 VA: 0x1561FE8
		private bool IsActiveLineNormal(int lineNo)
		{
			return true;
		}

		// // RVA: 0x1561FF0 Offset: 0x1561FF0 VA: 0x1561FF0
		private bool IsActiveLineWide(int lineNo)
		{
			return true;
		}

		// // RVA: 0x1561FF8 Offset: 0x1561FF8 VA: 0x1561FF8
		// public bool IsActiveLine(int lineNo) { }
	}
}
