using UnityEngine;
using UnityEngine.UI;

namespace XeSys.Gfx
{
	public class LayoutUGUIScrollSupport : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect m_scrollRect; // 0xC
		[SerializeField]
		private RectTransform m_scrollRange; // 0x10
		private LayoutUGUIRuntime m_parentLUR; // 0x14
		private ScrollView m_scrollView; // 0x18
		private Vector2 m_range; // 0x1C
		private Vector2 m_defaultRange; // 0x24
		private Vector2 m_contentSize; // 0x2C
		private LayoutElement m_contentLayout; // 0x34

		public ScrollRect scrollRect { get { return m_scrollRect; } private set { return; } } //0x1F04E58 0x1F04E60
		public Vector2 ContentSize { get { return m_contentSize; } set { m_contentSize = value; UpdateContent(); } } //0x1F0543C 0x1F05450
		//public float ContentWidth { get; set; } 0x1F05CB0 0x1F05CB8
		public float ContentHeight { get { return m_contentSize.y; } set { m_contentSize.y = value; UpdateContent(); } } //0x1F05CC0 0x1F05CC8
		public Vector2 RangeSize { get { return m_range; } } //0x1F05CD0
		public float RangeHeight { get { return m_range.y; } set { m_range.y = value; m_defaultRange = m_range; } } //0x1F05CE4 0x1F05CEC

		// RVA: 0x1F04E64 Offset: 0x1F04E64 VA: 0x1F04E64
		private void Awake()
		{
			m_contentLayout = m_scrollRange.gameObject.GetComponent<LayoutElement>();
			Initialize();
			m_defaultRange = m_range;
		}

		// RVA: 0x1EFE928 Offset: 0x1EFE928 VA: 0x1EFE928
		public void Initialize()
		{
			m_range = (m_scrollRect.transform as RectTransform).sizeDelta;
		}

		// RVA: 0x1F04F18 Offset: 0x1F04F18 VA: 0x1F04F18
		private void Start()
		{
			m_parentLUR = LayoutUGUIUtility.GetParentRuntime(transform);
			if(m_scrollRect.verticalScrollbar != null)
			{
				RectTransform r = m_scrollRect.verticalScrollbar.transform.GetChild(0).transform as RectTransform;
				r.sizeDelta = new Vector2(0, -8);
				r.pivot = new Vector2(0.5f, 0.5f);
				m_scrollRect.verticalScrollbar.handleRect.sizeDelta = new Vector2(-4, 4);
				m_scrollRect.verticalScrollbar.handleRect.pivot = new Vector2(0.5f, 0.5f);
			}
			if (m_scrollRect.horizontalScrollbar != null)
			{
				RectTransform r = m_scrollRect.horizontalScrollbar.transform.GetChild(0).transform as RectTransform;
				r.sizeDelta = new Vector2(-8, 0);
				r.pivot = new Vector2(0.5f, 0.5f);
				m_scrollRect.horizontalScrollbar.handleRect.sizeDelta = new Vector2(4, -4);
				m_scrollRect.horizontalScrollbar.handleRect.pivot = new Vector2(0.5f, 0.5f);
			}
		}

		//// RVA: 0x1F0545C Offset: 0x1F0545C VA: 0x1F0545C
		private void UpdateContent()
		{
			m_contentLayout.minWidth = m_contentSize.x;
			m_contentLayout.minHeight = m_contentSize.y;
			m_scrollRect.vertical = m_range.y < m_contentSize.y;
			m_scrollRect.horizontal = m_range.x < m_contentSize.x;
			float h = 0;
			if (m_scrollRect.verticalScrollbar != null)
			{
				m_scrollRect.verticalScrollbar.gameObject.SetActive(m_scrollRect.vertical);
				m_scrollRect.verticalScrollbar.gameObject.GetComponent<Scrollbar>().enabled = m_scrollRect.vertical;
				h = (m_scrollRect.verticalScrollbar.transform as RectTransform).sizeDelta.x;
				(m_scrollRect.verticalScrollbar.transform as RectTransform).sizeDelta = new Vector2(h, m_range.y);
			}
			if (m_scrollRect.horizontalScrollbar != null)
			{
				m_scrollRect.horizontalScrollbar.gameObject.SetActive(m_scrollRect.horizontal);
				m_scrollRect.horizontalScrollbar.gameObject.GetComponent<Scrollbar>().enabled = m_scrollRect.horizontal;
				float v = (m_scrollRect.horizontalScrollbar.transform as RectTransform).sizeDelta.y;
				h = (m_scrollRect.horizontalScrollbar.transform as RectTransform).sizeDelta.y;
				(m_scrollRect.horizontalScrollbar.transform as RectTransform).sizeDelta = new Vector2(m_range.x, v);
				if (m_scrollRect.horizontal && m_scrollRect.vertical)
				{
					h = (m_scrollRect.verticalScrollbar.transform as RectTransform).sizeDelta.x;
					(m_scrollRect.verticalScrollbar.transform as RectTransform).sizeDelta = new Vector2(h, m_range.y - h);
					(m_scrollRect.horizontalScrollbar.transform as RectTransform).sizeDelta = new Vector2(m_range.x - h, h);
				}
			}
			(m_scrollRect.transform as RectTransform).sizeDelta = new Vector2(m_range.x < m_contentSize.x ? m_defaultRange.x - h : m_defaultRange.x, m_range.y < m_contentSize.y ? m_defaultRange.y - h : m_defaultRange.y);
		}

		//// RVA: 0x1F05D00 Offset: 0x1F05D00 VA: 0x1F05D00
		public void AddView(GameObject obj, float offsetX, float offsetY)
		{
			LayoutUGUIUtility.AddView(m_scrollRange.gameObject, m_scrollView, obj);
			RectTransform r = obj.transform as RectTransform;
			r.anchorMin = new Vector2(0, 1);
			r.anchorMax = r.anchorMin;
			r.pivot = r.anchorMin;
			r.anchoredPosition += new Vector2(offsetX, -offsetY);
		}

		//// RVA: 0x1F05F9C Offset: 0x1F05F9C VA: 0x1F05F9C
		public void BeginAddView()
		{
			m_contentLayout = m_scrollRange.gameObject.GetComponent<LayoutElement>();
			Initialize();
			if(m_parentLUR == null)
			{
				m_parentLUR = LayoutUGUIUtility.GetParentRuntime(transform);
			}
			if(m_scrollView == null)
			{
				m_scrollView = m_parentLUR.FindViewBase(m_scrollRect.transform as RectTransform) as ScrollView;
			}
		}

		//// RVA: 0x1F061F4 Offset: 0x1F061F4 VA: 0x1F061F4
		//public void AddViewV(GameObject obj, float sizeX, float sizeY) { }

		//// RVA: 0x1F062C4 Offset: 0x1F062C4 VA: 0x1F062C4
		//public void AddViewH(GameObject obj, float sizeX, float sizeY) { }

		//// RVA: 0x1F06390 Offset: 0x1F06390 VA: 0x1F06390
		public void EndAddView()
		{
			UpdateContent();
		}

		//// RVA: 0x1F06394 Offset: 0x1F06394 VA: 0x1F06394
		public void EndAddView(Vector2 size)
		{
			m_contentSize = size;
			UpdateContent();
			UpdateContent();
		}

		//// RVA: 0x1F063B8 Offset: 0x1F063B8 VA: 0x1F063B8
		//public int GetChildCount() { }

		//// RVA: 0x1F06404 Offset: 0x1F06404 VA: 0x1F06404
		//public void RemoveView(int childIndex) { }

		//// RVA: 0x1F0640C Offset: 0x1F0640C VA: 0x1F0640C
		//public void RemoveView(int childIndex, bool isDestroy) { }

		//// RVA: 0x1F065DC Offset: 0x1F065DC VA: 0x1F065DC
		//public void RemoveAllView() { }

		//// RVA: 0x1F065E4 Offset: 0x1F065E4 VA: 0x1F065E4
		//public void RemoveAllView(bool isDestroy) { }
	}
}
