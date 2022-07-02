using UnityEngine;

namespace XeApp.Game.Common
{
	public class FindCanvasCamera : MonoBehaviour
	{
		[SerializeField]
		private Canvas m_canvas; // 0xC
		[SerializeField]
		private bool m_isOverride = true; // 0x10
		[SerializeField]
		private float m_near; // 0x14
		[SerializeField]
		private float m_far; // 0x18
		[SerializeField]
		private float m_size; // 0x1C
		[SerializeField]
		private float m_depth; // 0x20

		// RVA: 0x1C137E4 Offset: 0x1C137E4 VA: 0x1C137E4
		private void Awake()
		{
			m_canvas.worldCamera = GameManager.Instance.PopupCanvas.worldCamera;
			m_canvas.renderMode = RenderMode.ScreenSpaceCamera;
			if(m_isOverride)
			{
				m_canvas.worldCamera.nearClipPlane = m_near;
				m_canvas.worldCamera.farClipPlane = m_far;
				m_canvas.worldCamera.orthographicSize = m_size;
				m_canvas.worldCamera.depth = m_depth;
			}
			Transform root = transform.Find("Root");
			root.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
			for(int i = 0; i < root.childCount; i++)
			{
				if(root.GetChild(i).GetComponent<RectTransform>().anchorMax == root.GetChild(i).GetComponent<RectTransform>().anchorMin)
				{
					root.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
				}
				else
				{
					root.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
					root.GetChild(i).GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, 0.0f);
				}
			}
		}
	}
}
