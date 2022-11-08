using UnityEngine;
using UnityEngine.UI;

namespace XeSys.Gfx
{
	public class LayoutUGUIScrollSupport : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private RectTransform m_scrollRange;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
