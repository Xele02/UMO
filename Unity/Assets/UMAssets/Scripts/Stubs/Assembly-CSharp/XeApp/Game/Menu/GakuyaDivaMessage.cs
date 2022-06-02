using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class GakuyaDivaMessage : MonoBehaviour
	{
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl;
		[SerializeField]
		private Image m_imageDivaNameBase;
		[SerializeField]
		private Text m_textDivaName;
		[SerializeField]
		private Text m_textMessage;
		[SerializeField]
		private Animator m_animatorPosition;
		[SerializeField]
		private List<Color> m_divaColor;
	}
}
