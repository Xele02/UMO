using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIRangeSliders : MonoBehaviour
	{
		[SerializeField]
		private Slider m_sliderMin;
		[SerializeField]
		private Slider m_sliderMax;
		[SerializeField]
		private RectTransform m_fillTransMinLeft;
		[SerializeField]
		private RectTransform m_fillTransMinRight;
		[SerializeField]
		private RectTransform m_fillTransCenter;
		[SerializeField]
		private RectTransform m_fillTransMaxLeft;
		[SerializeField]
		private RectTransform m_fillTransMaxRight;
	}
}
