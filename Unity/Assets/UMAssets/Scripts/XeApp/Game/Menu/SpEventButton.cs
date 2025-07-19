using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SpEventButton : ActionButton
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x80
		[SerializeField]
		private RawImageEx m_imageButton; // 0x84
		[SerializeField]
		private Text m_textLimit; // 0x88
		[SerializeField]
		private Text m_textMessage; // 0x8C
		[SerializeField]
		private NumberBase m_numberUnlock; // 0x90
		[SerializeField]
		private RectTransform m_rectNewRoot; // 0x94
		[SerializeField]
		private bool m_isLargeSize; // 0x98
		private TexUVListManager m_uvManager; // 0x9C
		private AbsoluteLayout m_layoutNewTable; // 0xA0
		private AbsoluteLayout m_layoutDisable; // 0xA4
		private AbsoluteLayout m_layoutMessage; // 0xA8
		private AbsoluteLayout m_layoutLimit; // 0xAC
		private NewMarkIcon m_newMarkIcon; // 0xB0
		private OHKECKAPJJL m_viewData; // 0xB4
		private bool m_isDownloaded; // 0xB8
		public Action<OHKECKAPJJL> OnPushButton; // 0xBC

		public bool IsDownloaded { get { return m_isDownloaded || m_viewData == null; } } //0x12DD3B0

		// RVA: 0x12DD3D8 Offset: 0x12DD3D8 VA: 0x12DD3D8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			AbsoluteLayout v = m_runtime.FindViewBase(transform as RectTransform) as AbsoluteLayout;
			m_layoutNewTable = v.FindViewById("new") as AbsoluteLayout;
			m_layoutDisable = v.FindViewById("fnt_01") as AbsoluteLayout;
			m_layoutMessage = v.FindViewById("fnt_02") as AbsoluteLayout;
			m_layoutLimit = v.FindViewById("limit") as AbsoluteLayout;
			m_layoutDisable.StartChildrenAnimGoStop("06");
			m_layoutMessage.StartChildrenAnimGoStop("00");
			m_newMarkIcon = new NewMarkIcon(m_rectNewRoot.gameObject);
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x12DD780 Offset: 0x12DD780 VA: 0x12DD780
		public void Release()
		{
			m_newMarkIcon.Release();
		}

		// // RVA: 0x12DD7AC Offset: 0x12DD7AC VA: 0x12DD7AC
		public void Apply(int eventId, OHKECKAPJJL viewData, SpEventButtonTextureCache texCache)
		{
			m_viewData = viewData;
			Disable = !viewData.FICHDKOOOOB_Enabled;
			ApplyLimitDate(viewData);
			ApplyButtonImage(eventId, viewData, texCache);
			m_newMarkIcon.Initialize(m_rectNewRoot.gameObject);
			m_newMarkIcon.SetActive(viewData.LHMOAJAIJCO_IsNew);
			switch(viewData.PNDEAHGLJIC_BtnType)
			{
				case OHKECKAPJJL.GPNHNIGPGCL.PDCBCIGDPHL_1_Gacha1:
				case OHKECKAPJJL.GPNHNIGPGCL.ILBPPODCPPP_9_Gacha2:
				case OHKECKAPJJL.GPNHNIGPGCL.LAJAJEMJBFC_12_Gacha3:
					ApplyGachaButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.DLNKBNOECAG_2_Mission1:
				case OHKECKAPJJL.GPNHNIGPGCL.MLDKHMADOAD_13_Mission2:
				case OHKECKAPJJL.GPNHNIGPGCL.OCHMPNOEELL_14_Mission3:
				case OHKECKAPJJL.GPNHNIGPGCL.NKCLBKDFOCM_15_Mission4:
					ApplyMissionButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.NOBPFBOJLJD_3_Campaign:
					ApplyCampaignButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.LKPNOOKDFHH_4_StoneSale:
					ApplyStoneSaleButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.PEEBEIHMLIO_5_NyanCuzi:
					ApplyNyanCuziButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.GLLGHGMHCKF_6_Event1:
				case OHKECKAPJJL.GPNHNIGPGCL.CKPLJKICBKB_7_Event2:
					ApplyEventButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.ODPGFIPCFEF_8_DailyAdv:
					ApplyDailyAdv(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.NNJBAJMNBCM_10_Offer:
					ApplyOfferButton(viewData);
					break;
				case OHKECKAPJJL.GPNHNIGPGCL.DIDJLIPNCKO_18_Bingo:
					ApplyBingoButton(viewData);
					break;
			}
			ClearOnClickCallback();
			AddOnClickCallback(() =>
			{
				//0x12DF868
				if(OnPushButton != null)
					OnPushButton(m_viewData);
			});
		}

		// // RVA: 0x12DDA48 Offset: 0x12DDA48 VA: 0x12DDA48
		private void ApplyLimitDate(OHKECKAPJJL viewData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutLimit.StartChildrenAnimGoStop("01");
				DateTime dt = Utility.GetLocalDateTime(viewData.PDBPFJJCADD_Start);
				m_textLimit.text = string.Format(bk.GetMessageByLabel("event_sp_open_at"), new object[5]
				{
					dt.Year, dt.Month, dt.Day, dt.Minute, dt.Second
				});
			}
			else
			{
				if(viewData.OAAKAAFFFLE >= OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended && viewData.OAAKAAFFFLE < OHKECKAPJJL.ONKLMFNGCHJ.IOPLLOIHMJC_7)
					m_layoutLimit.StartChildrenAnimGoStop("00");
				else
					m_layoutLimit.StartChildrenAnimGoStop("02");
				DateTime dt = Utility.GetLocalDateTime(viewData.FDBNFFNFOND_End);
				m_textLimit.text = string.Format(bk.GetMessageByLabel("event_sp_close_at"), new object[5]
				{
					dt.Year, dt.Month, dt.Day, dt.Minute, dt.Second
				});
			}
		}

		// // RVA: 0x12DE22C Offset: 0x12DE22C VA: 0x12DE22C
		private void ApplyButtonImage(int eventId, OHKECKAPJJL viewData, SpEventButtonTextureCache texCache)
		{
			m_isDownloaded = false;
			texCache.Load(eventId, viewData.GNOFNIOLPPC_ImgId, (IiconTexture texture) =>
			{
				//0x12DF8D8
				texture.Set(m_imageButton);
				m_isDownloaded = true;
			});
			m_imageButton.uvRect = m_isLargeSize ? new Rect(0, 0.5f, 1, 0.5f) : new Rect(0, 0, 1, 0.5f);
		}

		// // RVA: 0x12DE3A0 Offset: 0x12DE3A0 VA: 0x12DE3A0
		private void ApplyGachaButton(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.FBFBGLONIME_6)
			{
				if(viewData.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.LAJAJEMJBFC_12_Gacha3)
				{
					m_layoutDisable.StartChildrenAnimGoStop("03");
					m_layoutLimit.StartChildrenAnimGoStop("02");
					DateTime dt = Utility.GetLocalDateTime(viewData.FDBNFFNFOND_End);
					m_textLimit.text = string.Format(MessageManager.Instance.GetMessage("menu", "event_sp_close_at"), new object[5]
					{
						dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute
					});
					//LAB_012de8e0
				}
				else
				{
					m_layoutDisable.StartChildrenAnimGoStop("00");
					m_layoutLimit.StartChildrenAnimGoStop("00");
				}
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
			}
			//LAB_012de8e0
			m_layoutMessage.StartChildrenAnimGoStop("00");
		}

		// // RVA: 0x12DE964 Offset: 0x12DE964 VA: 0x12DE964
		private void ApplyMissionButton(OHKECKAPJJL viewData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(viewData.MMJHAMFEHCH == OHKECKAPJJL.NBADGBJMBMM.IIBKMHIDNPM_1)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("02");
				m_textMessage.text = bk.GetMessageByLabel("event_sp_reward");
			}
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DEBBC Offset: 0x12DEBBC VA: 0x12DEBBC
		private void ApplyCampaignButton(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DECEC Offset: 0x12DECEC VA: 0x12DECEC
		private void ApplyStoneSaleButton(OHKECKAPJJL viewData)
		{
			if(viewData.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.GPDBJKNHHGM_4 || viewData.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.OFBEAEHFHOG_2)
			{
				m_layoutDisable.StartChildrenAnimGoStop("02");
			}
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DEE74 Offset: 0x12DEE74 VA: 0x12DEE74
		private void ApplyNyanCuziButton(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DEFA4 Offset: 0x12DEFA4 VA: 0x12DEFA4
		private void ApplyEventButton(OHKECKAPJJL viewData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.FKHAJADPBJK_4_Epilogue)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("02");
				m_textMessage.text = bk.GetMessageByLabel("event_sp_epilogue");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.EMAMLLFAOJI_3_Counting)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("01");
				m_textMessage.text = bk.GetMessageByLabel("event_sp_end_attain");
			}
			else
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DF268 Offset: 0x12DF268 VA: 0x12DF268
		private void ApplyDailyAdv(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
			}
			else if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
			}
			if(viewData.GGHDEDJFFOM < 1)
				m_textMessage.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel( "event_sp_daily_adv_all_title");
			else
				m_textMessage.text = string.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel( "event_sp_daily_adv_num_title"), viewData.GGHDEDJFFOM);
			m_layoutMessage.StartChildrenAnimGoStop("02");
		}

		// // RVA: 0x12DF4B0 Offset: 0x12DF4B0 VA: 0x12DF4B0
		private void ApplyOfferButton(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			if(KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				if(KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk())
				{
					m_numberUnlock.SetNumber(KDHGBOOECKC.HHCJCDFCLOB.EJBPEBIIMPG_GetVfoPlayerLevelUnlock(), 0);
					m_layoutDisable.StartChildrenAnimGoStop("05");
					m_newMarkIcon.SetActive(false);
					Disable = true;
				}
			}
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}

		// // RVA: 0x12DF6D4 Offset: 0x12DF6D4 VA: 0x12DF6D4
		private void ApplyBingoButton(OHKECKAPJJL viewData)
		{
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted)
			{
				m_layoutDisable.StartChildrenAnimGoStop("06");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
			if(viewData.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended)
			{
				m_layoutDisable.StartChildrenAnimGoStop("04");
				m_layoutMessage.StartChildrenAnimGoStop("00");
			}
		}
	}
}
