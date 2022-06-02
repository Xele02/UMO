using UnityEngine;
using XeSys.uGUI;

namespace XeApp.Game.MiniGame
{
	public class MiniGameShootingEdit : MonoBehaviour
	{
		[SerializeField]
		private int m_stageNum;
		[SerializeField]
		private float m_elapsedTime;
		[SerializeField]
		private VirtualPad virtualPad;
		[SerializeField]
		private GameObject titileObject;
		[SerializeField]
		private UGUIFader fadePlane;
		[SerializeField]
		private RectTransform m_mainSceenSize;
	}
}
