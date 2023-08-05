using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIScrollRectAnimationSupport : MonoBehaviour
	{
		//[TooltipAttribute] // RVA: 0x68CDB0 Offset: 0x68CDB0 VA: 0x68CDB0
		[SerializeField]
		private ScrollRect m_scroll; // 0xC
		//[TooltipAttribute] // RVA: 0x68CE1C Offset: 0x68CE1C VA: 0x68CE1C
		public float m_rate_v; // 0x10
		public float m_rate_h; // 0x14
		//[TooltipAttribute] // RVA: 0x68CE6C Offset: 0x68CE6C VA: 0x68CE6C
		public bool m_enable_v; // 0x18
		public bool m_enable_h; // 0x19

		// RVA: 0x1CDB5CC Offset: 0x1CDB5CC VA: 0x1CDB5CC
		public void LateUpdate()
		{
			if (m_enable_v)
				m_scroll.verticalNormalizedPosition = m_rate_v;
			if (m_enable_h)
				m_scroll.horizontalNormalizedPosition = m_rate_h;
		}
	}
}
