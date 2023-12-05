using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupVariousInfoContents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private LayoutPopupVariousInfo m_variousInfo; // 0x14
		private PopupWindowControl m_popupControl; // 0x18
		private bool m_isTwitter; // 0x1C
		private bool m_isWiki; // 0x1D
		private bool m_isFAQ; // 0x1E
		private bool m_isOfficialSite; // 0x1F
		private bool m_isPortalSite; // 0x20

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x11626EC Offset: 0x11626EC VA: 0x11626EC
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0x1162774 Offset: 0x1162774 VA: 0x1162774 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupVariousInfoSetting s = setting as PopupVariousInfoSetting;
			m_popupControl = control;
			Parent = setting.m_parent;
			m_variousInfo = GetComponent<LayoutPopupVariousInfo>();
			if(m_variousInfo != null)
			{
				m_variousInfo.CallbackOfficialSite = () =>
				{
					//0x1163158
					if (m_isOfficialSite)
						return;
					m_isOfficialSite = true;
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					OtherUtility.OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["official_site"], () =>
					{
						//0x1163340
						CallbackSupportSiteClose();
						m_isOfficialSite = false;
					});
				};
				m_variousInfo.CallbackPortalSite = () =>
				{
					//0x116335C
					if (m_isPortalSite)
						return;
					m_isPortalSite = true;
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					OtherUtility.OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["portal_site"], () =>
					{
						//0x1163544
						CallbackSupportSiteClose();
						m_isPortalSite = false;
					});
				};
				m_variousInfo.CallbackWiki = () =>
				{
					//0x1163560
					if (m_isWiki)
						return;
					m_isWiki = true;
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					OtherUtility.OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["official_wiki"], () =>
					{
						//0x1163748
						CallbackSupportSiteClose();
						m_isWiki = false;
					});
				};
				m_variousInfo.CallbackPolicy = () =>
				{
					//0x1163764
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.EMAOPPMGKBD_7, () =>
					{
						//0x1163978
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				m_variousInfo.CallbackTransaction = () =>
				{
					//0x116397C
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_6, () =>
					{
						//0x1163B90
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				m_variousInfo.CallbackByelaw = () =>
				{
					//0x1163B94
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.GHDACOGLNLJ_Contract, () =>
					{
						//0x1163DA8
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				m_variousInfo.CallbackSettlement = () =>
				{
					//0x1163DAC
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.BFKFPEDCFCL_5, () =>
					{
						//0x1163FC0
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				m_variousInfo.CallbackCopyRight = () =>
				{
					//0x1163FC4
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.EHDHJCGOGGN_4, () =>
					{
						//0x11641D8
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				m_variousInfo.CallbackFAQ = () =>
				{
					//0x11641DC
					if (m_isFAQ)
						return;
					m_isFAQ = true;
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					OtherUtility.OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["official_wiki_faq"], () =>
					{
						//0x11643C4
						CallbackSupportSiteClose();
						m_isFAQ = false;
					});
				};
				m_variousInfo.CallbackTwitter = () =>
				{
					//0x11643E0
					if (m_isTwitter)
						return;
					m_isTwitter = true;
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					OtherUtility.OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["official_twitter"], () =>
					{
						//0x11645C8
						CallbackSupportSiteClose();
						m_isTwitter = false;
					});
				};
				m_variousInfo.CallbackCredit = () =>
				{
					//0x11645E4
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					if (m_popupControl != null)
						m_popupControl.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.JMIDCMFKPOE_10, () =>
					{
						//0x11647F8
						CallbackSupportSiteClose();
					}, MenuScene.Instance.GotoTitle);
				};
				int a = m_variousInfo.SetStatus();
				Vector2 winSize = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
				if(a < 9)
				{
					m_rectTransform.anchoredPosition = Vector2.zero;
					m_rectTransform.sizeDelta = winSize;
				}
				else
				{
					m_rectTransform.sizeDelta = new Vector2(winSize.x, (a - 7) / 2 * 80 + winSize.y);
					m_rectTransform.anchoredPosition = Vector2.zero;
				}
				control.StartCoroutineWatched(m_variousInfo.CreditDark());
			}
			gameObject.SetActive(true);
		}

		//// RVA: 0x1162EC0 Offset: 0x1162EC0 VA: 0x1162EC0
		private void CallbackSupportSiteClose()
		{
			if (m_popupControl != null)
				m_popupControl.InputEnable();
		}

		// RVA: 0x1162F74 Offset: 0x1162F74 VA: 0x1162F74 Slot: 18
		public bool IsScrollable()
		{
			return true;
		}

		// RVA: 0x1162F7C Offset: 0x1162F7C VA: 0x1162F7C Slot: 19
		public void Show()
		{
			if (m_variousInfo != null)
				m_variousInfo.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1163060 Offset: 0x1163060 VA: 0x1163060 Slot: 20
		public void Hide()
		{
			if (m_variousInfo != null)
				m_variousInfo.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1163144 Offset: 0x1163144 VA: 0x1163144 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x116314C Offset: 0x116314C VA: 0x116314C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
