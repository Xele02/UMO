using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class SpriteAnime : KeyFrameAnime
	{
		private Image m_imageObject; // 0x30

		// RVA: 0x139CB38 Offset: 0x139CB38 VA: 0x139CB38 Slot: 4
		protected override void Init()
		{
			m_imageObject = m_image.GetComponent<Image>();
		}

		// // RVA: 0x139CBB4 Offset: 0x139CBB4 VA: 0x139CBB4 Slot: 5
		protected override void SetSprite(Sprite sprite)
		{
			if(m_imageObject != null)
			{
				m_imageObject.sprite = sprite;
			}
		}

		// // RVA: 0x139CC70 Offset: 0x139CC70 VA: 0x139CC70 Slot: 6
		// protected override Vector3 GetPosition() { }

		// // RVA: 0x139CE08 Offset: 0x139CE08 VA: 0x139CE08 Slot: 7
		protected override void SetPosition(Vector3 pos)
		{
			if(m_imageObject != null)
			{
				m_imageObject.rectTransform.anchoredPosition = pos;
			}
		}

		// // RVA: 0x139CF40 Offset: 0x139CF40 VA: 0x139CF40 Slot: 8
		// protected override Vector3 GetScale() { }

		// // RVA: 0x139D09C Offset: 0x139D09C VA: 0x139D09C Slot: 9
		protected override void SetScale(Vector3 scale)
		{
			if(m_imageObject != null)
			{
				m_imageObject.rectTransform.localScale = scale;
			}
		}

		// // RVA: 0x139D194 Offset: 0x139D194 VA: 0x139D194 Slot: 10
		protected override Vector3 GetEulerAngles()
		{
			if(m_imageObject != null)
			{
				return m_imageObject.rectTransform.eulerAngles;
			}
			return Vector3.zero;
		}

		// // RVA: 0x139D2F0 Offset: 0x139D2F0 VA: 0x139D2F0 Slot: 11
		protected override void SetEulerAngles(Vector3 eangle)
		{
			if(m_imageObject != null)
			{
				m_imageObject.rectTransform.eulerAngles = eangle;
			}
		}

		// // RVA: 0x139D3E8 Offset: 0x139D3E8 VA: 0x139D3E8 Slot: 12
		// protected override Color GetColor() { }

		// // RVA: 0x139D4E8 Offset: 0x139D4E8 VA: 0x139D4E8 Slot: 13
		protected override void SetColor(Color color)
		{
			if(m_imageObject != null)
			{
				m_imageObject.color = color;
			}
		}
	}
}
