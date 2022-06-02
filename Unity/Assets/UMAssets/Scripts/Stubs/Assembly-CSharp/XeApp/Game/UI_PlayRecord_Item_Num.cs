using UnityEngine;
using TMPro;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class UI_PlayRecord_Item_Num : MonoBehaviour
	{
		[SerializeField]
		public TextMeshProUGUI m_unit;
		[SerializeField]
		public List<UGUINumController> m_num;
	}
}
