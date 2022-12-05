using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SetDeckStatusValueControl : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x683634 Offset: 0x683634 VA: 0x683634
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x683634 Offset: 0x683634 VA: 0x683634
		private Text m_valueText; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6836A4 Offset: 0x6836A4 VA: 0x6836A4
		private Image m_arrowImage; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6836F4 Offset: 0x6836F4 VA: 0x6836F4
		private Image m_enemyImage; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68374C Offset: 0x68374C VA: 0x68374C
		//[TooltipAttribute] // RVA: 0x68374C Offset: 0x68374C VA: 0x68374C
		private Color m_enemyTextColor = new Color(0.6078432f, 0.0627451f, 0.6352941f); // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6837D0 Offset: 0x6837D0 VA: 0x6837D0
		private AnimeCurveScriptableObject m_animeCurve; // 0x28
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x683818 Offset: 0x683818 VA: 0x683818
		private float m_animeLengthSec = 2; // 0x2C
		private static readonly Color IconColorOn = Color.white; // 0x0
		private static readonly Color IconColorOff = new Color(1, 1, 1, 0); // 0x10
		private StringBuilder strBuilder = new StringBuilder(); // 0x30
		private bool m_isCrossFade; // 0x34
		private float m_crossFadeTime; // 0x38
		private Color m_baseTextColor; // 0x3C

		// RVA: 0xA76784 Offset: 0xA76784 VA: 0xA76784
		private void Update()
		{
			UpdateCrossFade(Time.deltaTime);
		}

		//// RVA: 0xA76B38 Offset: 0xA76B38 VA: 0xA76B38
		public void Set(int baseValue, int adjustValue, bool isSign, bool isBuffTarget, bool isDebuffTarget, string normalColorCode, int maxNum = 0)
		{

		}

		//// RVA: 0xA770B8 Offset: 0xA770B8 VA: 0xA770B8
		//public void Set(string baseValue, bool isDown, bool isBuffTarget, bool isDebuffTarget, string normalColorCode) { }

		//// RVA: 0xA767A8 Offset: 0xA767A8 VA: 0xA767A8
		private void UpdateCrossFade(float deltaTime)
		{
			if(m_isCrossFade)
			{
				m_crossFadeTime += deltaTime;
				if (m_animeLengthSec <= m_crossFadeTime)
				{
					do
					{
						m_crossFadeTime -= m_animeLengthSec;
					} while (m_animeLengthSec <= m_crossFadeTime);
				}
				float f = m_animeCurve[0].Evaluate(m_crossFadeTime / m_animeLengthSec * m_animeCurve[0].keys[m_animeCurve[0].length - 1].time);
				m_valueText.color = Color.Lerp(m_baseTextColor, m_enemyTextColor, f);
				m_arrowImage.color = Color.Lerp(IconColorOn, IconColorOff, f);
				m_enemyImage.color = Color.Lerp(IconColorOn, IconColorOff, f);
			}
		}
	}
}
