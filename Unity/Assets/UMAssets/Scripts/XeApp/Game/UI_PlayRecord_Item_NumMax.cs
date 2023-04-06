using UnityEngine;
using TMPro;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class UI_PlayRecord_Item_NumMax : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI m_unit; // 0xC
		[SerializeField]
		public List<UGUINumController> m_num; // 0x10
		[SerializeField]
		public List<UGUINumController> m_max; // 0x14

		//// RVA: 0x1922FB4 Offset: 0x1922FB4 VA: 0x1922FB4
		public void Set(int a_num, int a_max)
		{
			for(int i = 0; i < m_num.Count; i++)
			{
				m_num[i].SetNum(a_num);
			}
			for (int i = 0; i < m_max.Count; i++)
			{
				m_max[i].SetNum(a_max);
			}
		}
	}
}
