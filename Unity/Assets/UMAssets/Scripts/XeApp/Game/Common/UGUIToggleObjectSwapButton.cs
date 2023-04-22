using UnityEngine;

namespace XeApp.Game.Common
{
	public class UGUIToggleObjectSwapButton : UGUIToggleButton
	{
		[SerializeField]
		private GameObject m_checkObj; // 0x60
		[SerializeField]
		private GameObject m_nonCheckObj; // 0x64
		[SerializeField]
		private Color m_normalColor = Color.white; // 0x68
		[SerializeField]
		private Color m_disableColor = Color.gray; // 0x78
		[SerializeField]
		private ColorGroup m_colorGroup; // 0x88

		// // RVA: 0x1CDD05C Offset: 0x1CDD05C VA: 0x1CDD05C Slot: 21
		public override void SetOff()
		{
			if(Hidden || Disable)
				return;
			base.SetOff();
			m_nonCheckObj.SetActive(true);
			m_checkObj.SetActive(false);
			m_colorGroup.color = m_normalColor;
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1CDD158 Offset: 0x1CDD158 VA: 0x1CDD158 Slot: 20
		public override void SetOn()
		{
			if(Hidden || Disable)
				return;
			base.SetOn();
			m_nonCheckObj.SetActive(false);
			m_checkObj.SetActive(true);
			m_colorGroup.color = m_normalColor;
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1CDD254 Offset: 0x1CDD254 VA: 0x1CDD254 Slot: 23
		protected override void PlayNormal()
		{
			base.PlayNormal();
			m_colorGroup.color = m_normalColor;
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1CDD2D8 Offset: 0x1CDD2D8 VA: 0x1CDD2D8 Slot: 24
		protected override void PlayEnter()
		{
			base.PlayEnter();
			m_colorGroup.color = m_normalColor;
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1CDD360 Offset: 0x1CDD360 VA: 0x1CDD360 Slot: 25
		protected override void PlayDisable()
		{
			base.PlayDisable();
			m_nonCheckObj.SetActive(true);
			m_checkObj.SetActive(false);
			m_colorGroup.color = m_disableColor;
			m_colorGroup.OnUpdateColor();
		}

		// // RVA: 0x1CDD430 Offset: 0x1CDD430 VA: 0x1CDD430 Slot: 26
		protected override void PlayHidden()
		{
			base.PlayHidden();
			m_colorGroup.color = m_normalColor;
			m_colorGroup.OnUpdateColor();
		}
	}
}
