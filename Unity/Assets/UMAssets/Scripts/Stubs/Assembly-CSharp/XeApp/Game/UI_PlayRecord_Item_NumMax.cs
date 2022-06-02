using UnityEngine;
using TMPro;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class UI_PlayRecord_Item_NumMax : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI m_unit;
		[SerializeField]
		public List<UGUINumController> m_num;
		[SerializeField]
		public List<UGUINumController> m_max;
	}
}
