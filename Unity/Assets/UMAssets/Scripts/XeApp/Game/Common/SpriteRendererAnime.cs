using UnityEngine;

namespace XeApp.Game.Common
{
	public class SpriteRendererAnime : KeyFrameAnime
	{
		private SpriteRenderer m_spriteRenderer; // 0x30

		// RVA: 0x139D5D8 Offset: 0x139D5D8 VA: 0x139D5D8 Slot: 4
		protected override void Init()
		{
			m_spriteRenderer = m_image.GetComponent<SpriteRenderer>();
		}

		// RVA: 0x139D654 Offset: 0x139D654 VA: 0x139D654 Slot: 5
		protected override void SetSprite(Sprite sprite)
		{
			if (m_spriteRenderer != null)
				m_spriteRenderer.sprite = sprite;
		}

		// RVA: 0x139D710 Offset: 0x139D710 VA: 0x139D710 Slot: 6
		//protected override Vector3 GetPosition() { }

		// RVA: 0x139D86C Offset: 0x139D86C VA: 0x139D86C Slot: 7
		protected override void SetPosition(Vector3 pos)
		{
			if (m_spriteRenderer != null)
				m_spriteRenderer.transform.localPosition = pos;
		}

		// RVA: 0x139D964 Offset: 0x139D964 VA: 0x139D964 Slot: 8
		//protected override Vector3 GetScale() { }

		// RVA: 0x139DAC0 Offset: 0x139DAC0 VA: 0x139DAC0 Slot: 9
		protected override void SetScale(Vector3 scale)
		{
			if (m_spriteRenderer != null)
				m_spriteRenderer.transform.localScale = scale;
		}

		// RVA: 0x139DBB8 Offset: 0x139DBB8 VA: 0x139DBB8 Slot: 10
		protected override Vector3 GetEulerAngles()
		{
			Vector3 res = Vector3.zero;
			if (m_spriteRenderer != null)
				res = m_spriteRenderer.transform.localEulerAngles;
			return res;
		}

		// RVA: 0x139DD14 Offset: 0x139DD14 VA: 0x139DD14 Slot: 11
		protected override void SetEulerAngles(Vector3 eangle)
		{
			if (m_spriteRenderer != null)
				m_spriteRenderer.transform.localEulerAngles = eangle;
		}

		// RVA: 0x139DE0C Offset: 0x139DE0C VA: 0x139DE0C Slot: 12
		//protected override Color GetColor() { }

		// RVA: 0x139DF04 Offset: 0x139DF04 VA: 0x139DF04 Slot: 13
		protected override void SetColor(Color color)
		{
			if (m_spriteRenderer != null)
				m_spriteRenderer.color = color;
		}
	}
}
