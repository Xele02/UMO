using System;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSortOrder : MonoBehaviour
	{
		public enum SortOrder
		{
			Small = 0,
			Big = 1,
		}

		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675A70 Offset: 0x675A70 VA: 0x675A70
		private UGUIButton m_button; // 0xC
		// [HeaderAttribute] // RVA: 0x675AB8 Offset: 0x675AB8 VA: 0x675AB8
		[SerializeField]
		private InOutAnime m_inOut; // 0x10
		// [HeaderAttribute] // RVA: 0x675B00 Offset: 0x675B00 VA: 0x675B00
		[SerializeField]
		private GameObject m_smallOrder; // 0x14
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x675B48 Offset: 0x675B48 VA: 0x675B48
		private GameObject m_bigOrder; // 0x18
		
		public Action OnClickButtonListener { private get; set; } // 0x1C

		// // RVA: 0xAD9D78 Offset: 0xAD9D78 VA: 0xAD9D78
		private void Awake()
		{
			m_button.AddOnClickCallback(() =>
			{
				//0xAD9F70
				if (OnClickButtonListener != null)
					OnClickButtonListener();
			});
		}

		// // RVA: 0xAD9E20 Offset: 0xAD9E20 VA: 0xAD9E20
		public void SetOrder(VerticalMusicSelectSortOrder.SortOrder sortOrder)
		{
			m_smallOrder.SetActive(false);
			m_bigOrder.SetActive(false);
			if(sortOrder == SortOrder.Small)
				m_smallOrder.SetActive(true);
			else
				m_bigOrder.SetActive(true);
		}

		// // RVA: 0xAD9EA8 Offset: 0xAD9EA8 VA: 0xAD9EA8
		public void SetButtonEnable(bool isEnable)
		{
			m_button.Disable = !isEnable;
		}

		// // RVA: 0xAD9EDC Offset: 0xAD9EDC VA: 0xAD9EDC
		public void Enter()
		{
			m_inOut.ForceEnter(null);
		}

		// // RVA: 0xAD9F0C Offset: 0xAD9F0C VA: 0xAD9F0C
		public void Leave()
		{
			m_inOut.ForceLeave(null);
		}

		// // RVA: 0xAD9F3C Offset: 0xAD9F3C VA: 0xAD9F3C
		public bool IsPlaying()
		{
			return m_inOut.IsPlaying();
		}
	}
}
