using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class IntimacyCounter : MonoBehaviour
	{
		[SerializeField]
		private UGUINumController m_numCount;
		[SerializeField]
		private ColorGroup m_colorGroup;
		[SerializeField]
		private Text m_textTime;
		[SerializeField]
		private InOutAnime m_inOutCount;
	}
}
