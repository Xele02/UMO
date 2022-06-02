using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoMessageControl : MonoBehaviour
	{
		[SerializeField]
		private ColorGroup m_colorGroup;
		[SerializeField]
		private GameObject m_allObject;
		[SerializeField]
		private Text m_messageText;
		[SerializeField]
		private UGUICurveMover.CurveInfo m_inOutCurveInfo;
		[SerializeField]
		private float m_dispTimeLength;
	}
}
