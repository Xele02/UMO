using UnityEngine;
using UnityEngine.UI;

namespace XeSys
{
	public class DebugFPS : MonoBehaviour
	{
		[SerializeField]
		private Text m_Label;
		[SerializeField]
		private RectTransform m_baseRect;
		public double avgFPS;
		public double minFPS;
	}
}
