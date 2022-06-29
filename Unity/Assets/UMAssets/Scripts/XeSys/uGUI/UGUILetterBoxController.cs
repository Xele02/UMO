using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeSys.uGUI
{
	public class UGUILetterBoxController : MonoBehaviour
	{
		[SerializeField]
		private Image m_image1; // 0xC
		[SerializeField]
		private Image m_image2; // 0x10
		private bool m_need = true; // 0x15
		private Vector2 mAnchorLC; // 0x18
		private Vector2 mAnchorRC; // 0x20
		private Vector2 mAnchorCT; // 0x28
		private Vector2 mAnchorCB; // 0x30
		private Vector2 mPivotLeft; // 0x38
		private Vector2 mPivotRight; // 0x40
		private Vector2 mPivotTop; // 0x48
		private Vector2 mPivotBottom; // 0x50

		public bool visible { get; private set; } // 0x14

		// RVA: 0x274B548 Offset: 0x274B548 VA: 0x274B548
		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
		}

		// RVA: 0x274B5CC Offset: 0x274B5CC VA: 0x274B5CC
		private void Start()
		{
			UpdateLetterbox();
			mAnchorLC = new Vector2(0.0f, 0.5f);
			mAnchorRC = new Vector2(1.0f, 0.5f);
			mAnchorCT = new Vector2(0.5f, 0.0f);
			mAnchorCB = new Vector2(0.5f, 1.0f);
			mPivotLeft = new Vector2(0.0f, 0.5f);
			mPivotRight = new Vector2(1.0f, 0.5f);
			mPivotTop = new Vector2(0.5f, 0.0f);
			mPivotBottom = new Vector2(0.5f, 1.0f);
			SetVisible(true);
		}

		// RVA: 0x274C5B4 Offset: 0x274C5B4 VA: 0x274C5B4
		private void Update()
		{
			UpdateLetterbox();
		}

		// // RVA: 0x274B754 Offset: 0x274B754 VA: 0x274B754
		private void UpdateLetterbox()
		{
			int  type = 0;
			m_need = false;
			if(SystemManager.ScreenAspect <= SystemManager.BaseAspect)
			{
				type = 1;
				m_need = true;
			}
			else
			{
				type = 2;
				m_need = true;
			}

			bool display = m_need && visible;
			m_image1.gameObject.SetActive(display);
			m_image2.gameObject.SetActive(display);

			
			if(!display)
			{
				return;
			}
			if(type == 1)
			{
				m_image1.rectTransform.anchoredPosition = Vector2.zero;
				m_image1.rectTransform.anchorMin = mAnchorCT;
				m_image1.rectTransform.anchorMax = mAnchorCT;
				m_image1.rectTransform.pivot = mPivotTop;
				m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SystemManager.BaseScreenSize.x);
				m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (SystemManager.ScreenSize.y - SystemManager.BaseScreenSize.y * SystemManager.AdjustScale.x) * 0.5f * SystemManager.AdjustInvScale.x);

				m_image2.rectTransform.anchoredPosition = Vector2.zero;
				m_image2.rectTransform.anchorMin = mAnchorCB;
				m_image2.rectTransform.anchorMax = mAnchorCB;
				m_image2.rectTransform.pivot = mPivotBottom;
				m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SystemManager.BaseScreenSize.x);
				m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (SystemManager.ScreenSize.y - SystemManager.BaseScreenSize.y * SystemManager.AdjustScale.x) * 0.5f * SystemManager.AdjustInvScale.x);
			}
			else if(type == 2)
			{
				if(!SystemManager.isLongScreenDevice)
				{
					m_image1.rectTransform.anchoredPosition = Vector2.zero;
					m_image1.rectTransform.anchorMin = mAnchorLC;
					m_image1.rectTransform.anchorMax = mAnchorLC;
					m_image1.rectTransform.pivot = mPivotLeft;
					m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (SystemManager.ScreenSize.x - SystemManager.BaseScreenSize.x * SystemManager.AdjustScale.y) * 0.5f * SystemManager.AdjustInvScale.y);
					m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SystemManager.BaseScreenSize.y);

					m_image2.rectTransform.anchoredPosition = Vector2.zero;
					m_image2.rectTransform.anchorMin = mAnchorRC;
					m_image2.rectTransform.anchorMax = mAnchorRC;
					m_image2.rectTransform.pivot = mPivotRight;
					m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (SystemManager.ScreenSize.x - SystemManager.BaseScreenSize.x * SystemManager.AdjustScale.y) * 0.5f * SystemManager.AdjustInvScale.y);
					m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SystemManager.BaseScreenSize.y);
				}
				else
				{
					m_image1.rectTransform.anchoredPosition = Vector2.zero;
					m_image1.rectTransform.anchorMin = mAnchorLC;
					m_image1.rectTransform.anchorMax = mAnchorLC;
					m_image1.rectTransform.pivot = mPivotLeft;
					m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (SystemManager.rawSafeAreaRect.height / SystemManager.rawScreenAreaRect.height) * (SystemManager.longScreenSizeWithSafeArea.x - SystemManager.longScreenReferenceResolution.x) * 0.5f);
					m_image1.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SystemManager.BaseScreenSize.y);

					m_image2.rectTransform.anchoredPosition = Vector2.zero;
					m_image2.rectTransform.anchorMin = mAnchorRC;
					m_image2.rectTransform.anchorMax = mAnchorRC;
					m_image2.rectTransform.pivot = mPivotRight;
					m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (SystemManager.rawSafeAreaRect.height / SystemManager.rawScreenAreaRect.height) * (SystemManager.longScreenSizeWithSafeArea.x - SystemManager.longScreenReferenceResolution.x) * 0.5f);
					m_image2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SystemManager.BaseScreenSize.y);
				}
			}
		}

		// // RVA: 0x274C4E8 Offset: 0x274C4E8 VA: 0x274C4E8
		public void SetVisible(bool visible_)
		{
			visible = visible_;
			m_image1.gameObject.SetActive(m_need && visible);
			m_image2.gameObject.SetActive(m_need && visible);
		}

		// // RVA: 0x274C5B8 Offset: 0x274C5B8 VA: 0x274C5B8
		// public void SetColor(Color color) { }

		// // RVA: 0x274C658 Offset: 0x274C658 VA: 0x274C658
		// public void ChangeAlpha(float alpha) { }

		// // RVA: 0x274C75C Offset: 0x274C75C VA: 0x274C75C
		// public bool IsTransp() { }
	}
}
