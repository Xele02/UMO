using UnityEngine;
using TMPro;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class UI_PlayRecord_Item_Num : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI m_unit; // 0xC
		[SerializeField]
		public List<UGUINumController> m_num; // 0x10

		//// RVA: 0x1922EC8 Offset: 0x1922EC8 VA: 0x1922EC8
		public void Set(int a_num)
		{
			for(int i = 0; i < m_num.Count; i++)
			{
				m_num[i].SetNum(a_num);
			}
		}
	}
}
