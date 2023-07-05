using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDetailValkyrie : MonoBehaviour, IPopupContent
	{
		private ValkyrieStatusParam m_param; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF80D0C Offset: 0xF80D0C VA: 0xF80D0C Slot: 4
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDetailValkyrieSetting s = setting as PopupDetailValkyrieSetting;
			m_param = GetComponent<ValkyrieStatusParam>();
			Parent = setting.m_parent;
			m_param.UpdateContent(s.ViewValkyrieData, s.ViewValkyrieAbilityData);
		}

		// RVA: 0xF80E9C Offset: 0xF80E9C VA: 0xF80E9C Slot: 5
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF80EA4 Offset: 0xF80EA4 VA: 0xF80EA4 Slot: 6
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF80EDC Offset: 0xF80EDC VA: 0xF80EDC Slot: 7
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF80F14 Offset: 0xF80F14 VA: 0xF80F14 Slot: 8
		public bool IsReady()
		{
			if (m_param != null)
				return m_param.IsReady();
			return false;
		}

		// RVA: 0xF80FCC Offset: 0xF80FCC VA: 0xF80FCC Slot: 9
		public void CallOpenEnd()
		{
			return;
		}
	}
}
