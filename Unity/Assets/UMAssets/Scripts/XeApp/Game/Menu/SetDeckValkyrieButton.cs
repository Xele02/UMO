using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckValkyrieButton : MonoBehaviour
	{
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x685534 Offset: 0x685534 VA: 0x685534
		private InOutAnime m_inOut; // 0xC
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x68557C Offset: 0x68557C VA: 0x68557C
		private Image m_abilityImage; // 0x10
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6855D8 Offset: 0x6855D8 VA: 0x6855D8
		private Image m_emptyImage; // 0x14
		// [TooltipAttribute] // RVA: 0x685620 Offset: 0x685620 VA: 0x685620
		[SerializeField]
		private RawImage m_valkyrieImage; // 0x18
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x685678 Offset: 0x685678 VA: 0x685678
		private UGUIStayButton m_valkyrieButton; // 0x1C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x6856D4 Offset: 0x6856D4 VA: 0x6856D4
		private GameObject m_tapGuardObject; // 0x20
		public Action OnClickValkyrieButton; // 0x24
		public Action OnStayValkyrieButton; // 0x28
		private NHDJHOPLMDE m_viewValkyrieAbilityData; // 0x2C
		private int m_valkyrieImageLoadingCount; // 0x30

		public InOutAnime InOut { get { return m_inOut; } } //0xC3A87C
		public bool IsUpdatingContent { get { return m_valkyrieImageLoadingCount > 0; } } //0xC3A884

		// // RVA: 0xC3A898 Offset: 0xC3A898 VA: 0xC3A898
		private void Awake()
		{
			SetTapGuard(false);
			if (m_valkyrieButton == null)
				return;
			m_valkyrieButton.AddOnClickCallback(() =>
			{
				//0xC3AF60
				if (OnClickValkyrieButton != null)
					OnClickValkyrieButton();
			});
			m_valkyrieButton.AddOnStayCallback(() =>
			{
				//0xC3AF74
				if (OnStayValkyrieButton != null)
					OnStayValkyrieButton();
			});
		}

		// // RVA: 0xC3AAAC Offset: 0xC3AAAC VA: 0xC3AAAC
		// public void UpdateContent(JLKEOGLJNOD viewUnitData, EEDKAACNBBG viewMusicData) { }

		// // RVA: 0xC3AEE8 Offset: 0xC3AEE8 VA: 0xC3AEE8
		// public void UpdateContent(JLKEOGLJNOD viewUnitData) { }

		// // RVA: 0xC3AEF0 Offset: 0xC3AEF0 VA: 0xC3AEF0
		public void UpdateContent(AOJGDNFAIJL_PrismData.AMIECPBIALP prismData)
		{
			m_viewValkyrieAbilityData = null;
			m_abilityImage.enabled = false;
			SetValkyrieImage(prismData.PNDKNFBLKDP_GetPrismValkyrieId());
		}

		// // RVA: 0xC3A9F0 Offset: 0xC3A9F0 VA: 0xC3A9F0
		public void SetTapGuard(bool isEnable)
		{
			if (m_tapGuardObject != null)
				m_tapGuardObject.SetActive(isEnable);
		}

		// // RVA: 0xC3ADBC Offset: 0xC3ADBC VA: 0xC3ADBC
		private void SetValkyrieImage(int id)
		{
			m_valkyrieImageLoadingCount++;
			GameManager.Instance.ValkyrieIconCache.Load(id, 0, (IiconTexture texture) =>
			{
				//0xC3AF88
				texture.Set(m_valkyrieImage);
				m_valkyrieImageLoadingCount--;
			});
		}
	}
}
