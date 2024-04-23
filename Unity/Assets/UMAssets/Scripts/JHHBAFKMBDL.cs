using System;
using System.Collections;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class JHHBAFKMBDL
{
	private static readonly string LGNLCJIKOEO = "common"; // 0x0
	private static bool KKOBJLMKOJH = false; // 0x4
	public static JHHBAFKMBDL HHCJCDFCLOB; // 0x8
	private Func<bool> HDGDDJDCNGE; // 0x8
	private static string[] ECLAOLBGCDD = new string[6] {"<color=red>\n(", ")</color>", "saka_error", "0000", "update_error", JpStringLiterals.StringLiteral_11992}; // 0xC

	// // RVA: 0xB1DEA0 Offset: 0xB1DEA0 VA: 0xB1DEA0
	public void IJBGPAENLJA_Start(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xB1DF30 Offset: 0xB1DF30 VA: 0xB1DF30
	public void NIGGABHIFEE_ShowTransmissionIcon(bool JKDJCFEBDHC)
	{
		if(GameManager.Instance.transmissionIcon != null)
		{
			GameManager.Instance.transmissionIcon.SetActive(JKDJCFEBDHC);
		}
	}

	// // RVA: 0xB1E078 Offset: 0xB1E078 VA: 0xB1E078
	// private static string LNPJBOPAJGP(int PPFNGGCBJKC) { }

	// // RVA: 0xB1E208 Offset: 0xB1E208 VA: 0xB1E208
	private string HPPMBEDJGKB(SakashoErrorId PPFNGGCBJKC, int MJACIGCPNDA, bool CJGBOBNOHNG)
	{
		if(MessageManager.Instance.IsExistBank(LGNLCJIKOEO))
		{
			return JGJFFKPFMDB.NCDHNMILIOJ(PPFNGGCBJKC, CJGBOBNOHNG);
		}
		return "";
	}

	// // RVA: 0xB1E330 Offset: 0xB1E330 VA: 0xB1E330
	public static string MLCPIKEMFBK_GetErrorText(int CMCKNKKCNDK)
	{
		if(MessageManager.Instance.IsExistBank(LGNLCJIKOEO))
		{
			return MessageManager.Instance.GetBank(LGNLCJIKOEO).GetMessageByLabel(ECLAOLBGCDD[4] + CMCKNKKCNDK.ToString(ECLAOLBGCDD[3]));
		}
		else
		{
			return ECLAOLBGCDD[5] + CMCKNKKCNDK;
		}
	}

	// // RVA: 0xB1E5F4 Offset: 0xB1E5F4 VA: 0xB1E5F4
	public void AJIJCMKMAMA(SakashoErrorId PPFNGGCBJKC, CACGCMBKHDI_Request ADKIDBJCAJA, int MJACIGCPNDA, IMCBBOAFION EDIIEFHAOGP)
	{
		TextPopupSetting t = new TextPopupSetting();
		t.TitleText = JGJFFKPFMDB.HHAEOPHPCEF(PPFNGGCBJKC);
		bool b = PPFNGGCBJKC >= SakashoErrorId.EXPIRED_PASSPHRASE && PPFNGGCBJKC < SakashoErrorId.UNSUPPORTED_ITEM_SET_TYPE;
		PopupButton.ButtonLabel label = PopupButton.ButtonLabel.Ok;
		PopupButton.ButtonType type = PopupButton.ButtonType.Positive;
		if(PPFNGGCBJKC == SakashoErrorId.INVALID_PASSPHRASE || b)
		{
			label = PopupButton.ButtonLabel.Close;
			type = PopupButton.ButtonType.Negative;
		}
		t.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = label, Type = type }
		};
		t.Text = HPPMBEDJGKB(PPFNGGCBJKC, 0, false);
		PopupWindowManager.Show(t, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13470F8
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1E8C4 Offset: 0xB1E8C4 VA: 0xB1E8C4
	public void ICELKJMJJJH(SakashoErrorId PPFNGGCBJKC, CACGCMBKHDI_Request ADKIDBJCAJA, int MJACIGCPNDA, IMCBBOAFION EDIIEFHAOGP, JFDNPFFOACP NEFKBBNKNPP)
	{
		GameManager.Instance.CloseSnsNotice();
		GameManager.Instance.CloseOfferNotice();
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = JGJFFKPFMDB.HHAEOPHPCEF(PPFNGGCBJKC);
		s.Buttons = new ButtonInfo[2]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = HPPMBEDJGKB(PPFNGGCBJKC, 0, true);
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134712C
			if(LHFGEOAJAAL != PopupButton.ButtonLabel.Retry)
			{
				NEFKBBNKNPP();
			}
			else
			{
				EDIIEFHAOGP();
			}
		}, null, null, null);
	}

	// // RVA: 0xB1EC54 Offset: 0xB1EC54 VA: 0xB1EC54
	public void CIKMDHMMCIL(CACGCMBKHDI_Request ADKIDBJCAJA, int CMCKNKKCNDK, IMCBBOAFION EDIIEFHAOGP)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = JpStringLiterals.StringLiteral_11776;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MLCPIKEMFBK_GetErrorText(CMCKNKKCNDK);
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134718C
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1EEEC Offset: 0xB1EEEC VA: 0xB1EEEC
	public void CIKMDHMMCIL_ShowErrorPopup(int CMCKNKKCNDK, IMCBBOAFION EDIIEFHAOGP)
	{
		TextPopupSetting setting = new TextPopupSetting();
		setting.TitleText = JpStringLiterals.StringLiteral_11921;
		setting.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		setting.Text = MLCPIKEMFBK_GetErrorText(CMCKNKKCNDK);
		PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) => {
			//0x13471C0
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1F184 Offset: 0xB1F184 VA: 0xB1F184
	public void PNIJEKOHEII(IMCBBOAFION EDIIEFHAOGP)
	{
		TextPopupSetting setting = new TextPopupSetting();
		setting.TitleText = JpStringLiterals.StringLiteral_11922;
		setting.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		setting.Text = JpStringLiterals.StringLiteral_11923;
		PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) => {
			//0x13471F4
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1F3F8 Offset: 0xB1F3F8 VA: 0xB1F3F8
	public void NCBLFMHKAFL(SakashoErrorId PPFNGGCBJKC, CACGCMBKHDI_Request ADKIDBJCAJA, string LJGOOOMOMMA, IMCBBOAFION EDIIEFHAOGP)
	{
		PopupStopAccountSetting s = new PopupStopAccountSetting();
		MessageBank bk = MessageManager.Instance.GetBank("common");
		s.TitleText = bk.GetMessageByLabel("popup_ban_title");
		s.Buttons = new ButtonInfo[2]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Contact, Type = PopupButton.ButtonType.Positive },
		};
		s.WindowSize = SizeType.Middle;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1347228
			if(LHFGEOAJAAL == PopupButton.ButtonLabel.Contact)
			{
				MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry, () =>
				{
					//0x13470D4
					return;
				}, () =>
				{
					//0x13470D8
					return;
				});
			}
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1F758 Offset: 0xB1F758 VA: 0xB1F758
	public void NNOBHCCINEN(SakashoErrorId PPFNGGCBJKC, CACGCMBKHDI_Request ADKIDBJCAJA, string LJGOOOMOMMA, IMCBBOAFION EDIIEFHAOGP)
	{
		if(string.IsNullOrEmpty(LJGOOOMOMMA))
		{
			LJGOOOMOMMA = HPPMBEDJGKB(PPFNGGCBJKC, 0, false);
		}
		string msg = MessageManager.Instance.GetMessage("common", "popup_maintenance_title");
		ButtonInfo[] btns;
		SizeType ws;
		if(PPFNGGCBJKC == SakashoErrorId.PLAYER_ACCOUNT_STATUS_IS_SERVER_ACCESS_DENY)
		{
			msg = MessageManager.Instance.GetMessage("common", "popup_ban_title");
			btns = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Contact, Type = PopupButton.ButtonType.Positive }
			};
			ws = SizeType.Large;
		}
		else
		{
			btns = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Information, Type = PopupButton.ButtonType.Positive }
			};
			ws = SizeType.Small;
		}
		int cpid = UMO_PlayerPrefs.GetInt("cpid", 0);
		if(PPFNGGCBJKC != SakashoErrorId.PLAYER_ACCOUNT_STATUS_IS_SERVER_ACCESS_DENY && cpid == 0)
		{
			btns = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
		}
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = msg;
		s.Buttons = btns;
		s.WindowSize = ws;
		s.Text = LJGOOOMOMMA;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13474A4
			if(LHFGEOAJAAL == PopupButton.ButtonLabel.Contact)
			{
				MBCPNPNMFHB.HHCJCDFCLOB.MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry, () =>
				{
					//0x13470E0
					return;
				}, () =>
				{
					//0x13470E4
					return;
				});
			}
			else if(LHFGEOAJAAL == PopupButton.ButtonLabel.Information)
			{
				DOLBEIECMFO(() =>
				{
					//0x13470DC
					return;
				});
			}
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB1FC18 Offset: 0xB1FC18 VA: 0xB1FC18
	public void DOHNKJKOGFJ(string LJPMEHDDBGP, IMCBBOAFION EDIIEFHAOGP, JFDNPFFOACP NEFKBBNKNPP)
	{
		TextPopupSetting s = new TextPopupSetting();
		if(LJPMEHDDBGP == "storage")
		{
			s.TitleText = JpStringLiterals.StringLiteral_11927;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = JpStringLiterals.StringLiteral_11928;
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x1347820
				EDIIEFHAOGP();
			}, null, null, null);
		}
		else
		{
			s.TitleText = JpStringLiterals.StringLiteral_11929;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = JpStringLiterals.StringLiteral_11930;
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x134784C
				EDIIEFHAOGP();
			}, null, null, null);
		}
	}

	// // RVA: 0xB2000C Offset: 0xB2000C VA: 0xB2000C
	public void JDIDDHBIGIO(string LJPMEHDDBGP, IMCBBOAFION EDIIEFHAOGP, JFDNPFFOACP NEFKBBNKNPP)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		TextPopupSetting s = new TextPopupSetting();
		if(LJPMEHDDBGP == "storage")
		{
			s.TitleText = bk.GetMessageByLabel("popup_bunchinstall_error_storage_title");
			s.Text = bk.GetMessageByLabel("popup_bunchinstall_error_storage_desc");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x1347880
				if(LHFGEOAJAAL != PopupButton.ButtonLabel.Retry)
				{
					NEFKBBNKNPP();
				}
				else
				{
					EDIIEFHAOGP();
				}
			}, null, null, null);
		}
		else
		{
			s.TitleText = bk.GetMessageByLabel("popup_bunchinstall_error_other_title");
			s.Text = bk.GetMessageByLabel("popup_bunchinstall_error_other_desc");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x13478D8
				if(LHFGEOAJAAL != PopupButton.ButtonLabel.Retry)
				{
					NEFKBBNKNPP();
				}
				else
				{
					EDIIEFHAOGP();
				}
			}, null, null, null);
		}
	}

	// // RVA: 0xB20594 Offset: 0xB20594 VA: 0xB20594
	public void APEODCECEON(SakashoErrorId PPFNGGCBJKC, CACGCMBKHDI_Request ADKIDBJCAJA, string LJGOOOMOMMA, IMCBBOAFION EDIIEFHAOGP)
	{
		PopupVersionUpCautionSetting s = new PopupVersionUpCautionSetting();
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Update, Type = PopupButton.ButtonType.Positive }
		};
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_app_update_title");
		s.Message = MessageManager.Instance.GetMessage("common", "popup_app_update_an");
		s.WindowSize = SizeType.Middle;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1347938
			EDIIEFHAOGP();
		}, null, null, null);
	}

	// // RVA: 0xB208BC Offset: 0xB208BC VA: 0xB208BC
	public void GLJAPKKLIJJ_ShowUpdatePopup(IMCBBOAFION EDIIEFHAOGP, JFDNPFFOACP NIMPEHIECJH)
	{
		PopupVersionUpCautionSetting setting = new PopupVersionUpCautionSetting();
		setting.Buttons = new ButtonInfo[2]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Update, Type = PopupButton.ButtonType.Positive }
		};
		setting.TitleText = MessageManager.Instance.GetMessage("menu", "popup_rcmd_app_update_title");
		setting.Message = MessageManager.Instance.GetMessage("menu", "popup_rcmd_app_update_an");
		setting.WindowSize = SizeType.Middle;
		PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134796C
			if(LHFGEOAJAAL != PopupButton.ButtonLabel.Update)
			{
				NIMPEHIECJH();
			}
			else
			{
				EDIIEFHAOGP();
			}
		}, null, null, null);
	}

	// // RVA: 0xB20C60 Offset: 0xB20C60 VA: 0xB20C60
	// public void PFFJELDODOP(AMOCLPHDGBP PKLPKMLGFGK, ELBOJBBIBFM EDMKFIJKJLB, JFDNPFFOACP NIMPEHIECJH) { }

	// // RVA: 0xB20F64 Offset: 0xB20F64 VA: 0xB20F64
	// public void APFEADLBCCD(PJHHCHAKGKI KFFBDNMNBMM, JFDNPFFOACP NIMPEHIECJH) { }

	// // RVA: 0xB21250 Offset: 0xB21250 VA: 0xB21250
	// public void KGJHKKACPLM(int LBEBFEIHPOO, int KLCMKLPIDDJ, IMCBBOAFION BHEOPIPFEFJ, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xB21710 Offset: 0xB21710 VA: 0xB21710
	public void LIBDGGBAINI(IMCBBOAFION BHEOPIPFEFJ)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_title_data_error");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType. Negative }
		};
		s.Text = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_data_error");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1347BB0
			BHEOPIPFEFJ();
		}, null ,null, null);
	}

	// // RVA: 0xB21A54 Offset: 0xB21A54 VA: 0xB21A54
	// public void NFKDNLCKONC(IMCBBOAFION BHEOPIPFEFJ) { }

	// // RVA: 0xB21D98 Offset: 0xB21D98 VA: 0xB21D98
	// public void BAGANBPCGMD(IMCBBOAFION BHEOPIPFEFJ) { }

	// // RVA: 0xB151D8 Offset: 0xB151D8 VA: 0xB151D8
	public void AHEMKCHEHMM(IMCBBOAFION BHEOPIPFEFJ)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_title_data_error");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_playerdata_error");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1347C4C
			if(BHEOPIPFEFJ != null)
				BHEOPIPFEFJ();
		}, null, null, null);
	}

	// // RVA: 0xB2200C Offset: 0xB2200C VA: 0xB2200C
	public bool EAADBLJMIPP()
	{
		if (HDGDDJDCNGE != null)
			return HDGDDJDCNGE();
		return false;
	}

	// // RVA: 0xB22080 Offset: 0xB22080 VA: 0xB22080
	public void INCAHPACGAF_ShowWebView(string HJLDBEJOMIO, IMCBBOAFION HIDFAIBOHCC, bool EFDMHILHFPJ, bool OPEDAAIEOGN)
	{
		N.a.StartCoroutineWatched(LDGPIGGPKMG_Coroutine_ShowWebView(HJLDBEJOMIO, HIDFAIBOHCC, EFDMHILHFPJ, OPEDAAIEOGN));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B88F0 Offset: 0x6B88F0 VA: 0x6B88F0
	// // RVA: 0xB220F0 Offset: 0xB220F0 VA: 0xB220F0
	private IEnumerator LDGPIGGPKMG_Coroutine_ShowWebView(string HJLDBEJOMIO, IMCBBOAFION HIDFAIBOHCC, bool EFDMHILHFPJ, bool OPEDAAIEOGN)
	{
        //0x1348FFC
        PopupWindowControl crtrl = TodoLogger.LogNotImplemented("Web URL not avaiable in Utamacross Offline");
		yield return crtrl.IsOpenPopupWindow();
		HIDFAIBOHCC();
	}

	// // RVA: 0xB221DC Offset: 0xB221DC VA: 0xB221DC
	// public void EEBIICOLLIC(IMCBBOAFION BHEOPIPFEFJ) { }

	// // RVA: 0xB0C15C Offset: 0xB0C15C VA: 0xB0C15C
	public void GKMAHMLNMEK(IMCBBOAFION BHEOPIPFEFJ, string LJPMEHDDBGP) // Error popup
    {
        TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_title_app_error");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage(LGNLCJIKOEO, "popup_app_error");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1347EA8
			BHEOPIPFEFJ();
		}, null, null, null);
    }

	// // RVA: 0xB22450 Offset: 0xB22450 VA: 0xB22450
	// public void EOKNIAMKJFB(IMCBBOAFION BHEOPIPFEFJ) { }

	// // RVA: 0xB22794 Offset: 0xB22794 VA: 0xB22794
	public void DOLBEIECMFO(Action HIDFAIBOHCC)
	{
		GameManager.Instance.StartCoroutineWatched(PPOKAOCKCPL_ShowInformationCoroutine(HIDFAIBOHCC));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8968 Offset: 0x6B8968 VA: 0x6B8968
	// // RVA: 0xB22844 Offset: 0xB22844 VA: 0xB22844
	private IEnumerator PPOKAOCKCPL_ShowInformationCoroutine(Action HIDFAIBOHCC)
	{
		KNOINKGFINE_GetInformationURL PNLGHFCFPPK; // 0x18

		//0x134943C
		PNLGHFCFPPK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KNOINKGFINE_GetInformationURL());
		while(!PNLGHFCFPPK.PLOOEECNHFB_IsDone)
			yield return null;
		if(PNLGHFCFPPK.NPNNPNAIONN_IsError)
		{
			if(HIDFAIBOHCC != null)
				HIDFAIBOHCC();
		}
		else
		{
			WebContent HAOAIJOJEFI = null;
			ResourcesManager.Instance.Load("Menu/Prefab/PopupWindow/WebViewRoot", (FileResultObject MIMGPBHAJCO) =>
			{
				//0x1347F10
				GameObject obj = UnityEngine.Object.Instantiate(MIMGPBHAJCO.unityObject) as GameObject;
				obj.transform.SetParent(GameManager.Instance.gameObject.transform, false);
				HAOAIJOJEFI = obj.GetComponentInChildren<WebContent>();
				return true;
			});
			while(HAOAIJOJEFI == null)
				yield return null;
			HAOAIJOJEFI.onClosed = HIDFAIBOHCC;
			yield return HAOAIJOJEFI.Show(PNLGHFCFPPK.NFEAMMJIMPG_Result.MCHAINJKMEB_UrlWithToken, true, false);
		}
	}

	// // RVA: 0xB228CC Offset: 0xB228CC VA: 0xB228CC
	public void BJMLDGKHFLJ(IMCBBOAFION BHEOPIPFEFJ, JFDNPFFOACP NIMPEHIECJH, bool PEOPMAIEDNJ)
	{
        TextPopupSetting s = new TextPopupSetting();
		s.TitleText = JpStringLiterals.StringLiteral_11918;
		if(PEOPMAIEDNJ)
		{
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = JpStringLiterals.StringLiteral_11955;
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x13480DC
				if(LHFGEOAJAAL != PopupButton.ButtonLabel.Retry)
				{
					NIMPEHIECJH();
				}
				else
				{
					BHEOPIPFEFJ();
				}
			}, null, null, null);
		}
		else
		{
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			};
			s.Text = JpStringLiterals.StringLiteral_11956;
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x1348134
				NIMPEHIECJH();
			}, null, null, null);
		}
	}

	// // RVA: 0xB22CE8 Offset: 0xB22CE8 VA: 0xB22CE8
	// public void LGHIIMNFGKN(LGKMIBDPFNC CMJBMHCLNBA, IMCBBOAFION BHEOPIPFEFJ) { }

	// // RVA: 0xB100D0 Offset: 0xB100D0 VA: 0xB100D0
	public void DNABPEOICIJ(DJBHIFLHJLK HIDFAIBOHCC, bool CINOHLCJLJF)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = "";
		s.IsCaption = false;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", CINOHLCJLJF ? "popup_event_end_text_1" : "popup_event_end_text_2");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134819C
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB2312C Offset: 0xB2312C VA: 0xB2312C
	public void HEMIGMPCFFM(DJBHIFLHJLK HIDFAIBOHCC)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = JpStringLiterals.StringLiteral_11962;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_store_server_error_an");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13481D0
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB233E0 Offset: 0xB233E0 VA: 0xB233E0
	public void HNGIOFBLLDA(DJBHIFLHJLK HIDFAIBOHCC)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_ngword_error_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_ngword_error_message");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1348204
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB236E0 Offset: 0xB236E0 VA: 0xB236E0
	public void JNFBLHKMMBI(string ADCMNODJBGJ, string LJGOOOMOMMA, IMCBBOAFION HIDFAIBOHCC)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = ADCMNODJBGJ;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
		};
		s.Text = LJGOOOMOMMA;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1348238
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB23944 Offset: 0xB23944 VA: 0xB23944
	public void ACJOEBNHBMF_DisplayExpiredPopup(DJBHIFLHJLK JGKOLBLPMPG, bool MBJKHOOMAFE)
	{
		MessageBank bk = MessageManager.Instance.GetBank(LGNLCJIKOEO);
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = bk.GetMessageByLabel("popup_present_expire_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = bk.GetMessageByLabel(MBJKHOOMAFE ? "popup_present_expire_01" : "popup_present_expire_02");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134826C
			JGKOLBLPMPG();
		}, null, null, null);
	}

	// // RVA: 0xB23C98 Offset: 0xB23C98 VA: 0xB23C98
	public void HMIHFLGLHBA(DJBHIFLHJLK JGKOLBLPMPG)
	{
		MessageBank bk = MessageManager.Instance.GetBank(LGNLCJIKOEO);
		TextPopupSetting s = new TextPopupSetting();
		s.IsCaption = false;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = bk.GetMessageByLabel("popup_gacha_expire_01");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13482A0
			JGKOLBLPMPG();
		}, null, null, null);
	}

	// // RVA: 0xB23F80 Offset: 0xB23F80 VA: 0xB23F80
	public void LHHMCNLONCI(IMCBBOAFION HIDFAIBOHCC, string HJLDBEJOMIO)
	{
		GameManager.Instance.CbtWindow.Show(() =>
		{
			//0x13482D4
			NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(HJLDBEJOMIO);
			HIDFAIBOHCC();
		});
	}

	// // RVA: 0xB240CC Offset: 0xB240CC VA: 0xB240CC
	// public void PGBDJBGIPKN(IMCBBOAFION HIDFAIBOHCC) { }

	// // RVA: 0xB24408 Offset: 0xB24408 VA: 0xB24408
	public void PHDFLIFNEKC(IMCBBOAFION HIDFAIBOHCC)
	{
		MessageBank bk = MessageManager.Instance.GetBank(LGNLCJIKOEO);
		TextPopupSetting s = new TextPopupSetting();
		s.IsCaption = false;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = bk.GetMessageByLabel("popup_lb_already_received");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13483D8
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB246EC Offset: 0xB246EC VA: 0xB246EC
	public void OODNEKINHLO_ShowError(IMCBBOAFION HIDFAIBOHCC)
	{
		MessageBank bk = MessageManager.Instance.GetBank(LGNLCJIKOEO);
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = JpStringLiterals.StringLiteral_11972;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = JpStringLiterals.StringLiteral_11973;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134840C
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB249DC Offset: 0xB249DC VA: 0xB249DC
	// public void PEIONAKEPCN(DJBHIFLHJLK HIDFAIBOHCC) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B89E0 Offset: 0x6B89E0 VA: 0x6B89E0
	// // RVA: 0xB24D14 Offset: 0xB24D14 VA: 0xB24D14
	// private IEnumerator IJJADJCHHIG_ShowRankingDropErrorLoop(DJBHIFLHJLK HIDFAIBOHCC) { }

	// // RVA: 0xB24D9C Offset: 0xB24D9C VA: 0xB24D9C
	public void NELJJPGFGOA(IMCBBOAFION HIDFAIBOHCC)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_inf_line_api_update_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_inf_line_api_update_content");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x134871C
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB2509C Offset: 0xB2509C VA: 0xB2509C
	public void LOMNLGIDLKO(DJBHIFLHJLK AOCANKOMKFG)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_error_purchase_multi_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", "popup_error_purchase_multi_text_00");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1348750
			AOCANKOMKFG();
		}, null, null, null);
	}

	// // RVA: 0xB2539C Offset: 0xB2539C VA: 0xB2539C
	public void MDKADDJMLHA(DJBHIFLHJLK AOCANKOMKFG)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_s_mas_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_s_mas_text");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1348784
			AOCANKOMKFG();
		}, null, null, null);
	}

	// // RVA: 0xB2569C Offset: 0xB2569C VA: 0xB2569C
	public void EAGBOKEIAOC(JFDNPFFOACP NIMPEHIECJH)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.IsCaption = false;
		s.TitleText = "";
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", "pop_pass_store_error");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13487B8
			NIMPEHIECJH();
		}, null, null, null);
	}

	// // RVA: 0xB25948 Offset: 0xB25948 VA: 0xB25948
	public void PHAMJCBBBDB(JFDNPFFOACP NIMPEHIECJH)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.IsCaption = false;
		s.TitleText = "";
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", "pop_pass_goto_home_2");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x13487EC
			NIMPEHIECJH();
		}, null, null, null);
	}

	// // RVA: 0xB25BF4 Offset: 0xB25BF4 VA: 0xB25BF4
	public void KJJLCKFLIML_ShowDteLineErrorPopup(IMCBBOAFION MBIKIBHLAGE)
	{
		TextPopupSetting popup = new TextPopupSetting();
		popup.TitleText = MessageManager.Instance.GetMessage("menu", "popup_dateline_error_title");
		popup.Buttons = new ButtonInfo[1] {
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		popup.Text = MessageManager.Instance.GetMessage("menu", "popup_dateline_error_text");
		PopupWindowManager.Show(popup, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) => {
			//0x1348820
			MBIKIBHLAGE();
		}, null, null, null);
	}

	// // RVA: 0xB1551C Offset: 0xB1551C VA: 0xB1551C
	public void EKEGGMIHFIP(IMCBBOAFION MBIKIBHLAGE)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_recover_done_title");
		s.Buttons = new ButtonInfo[1] {
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", "popup_recover_done_text");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0x1348854
			MBIKIBHLAGE();
		}, null, null, null);
	}

	// // RVA: 0xB25EF4 Offset: 0xB25EF4 VA: 0xB25EF4
	public void NKIKBOJOCNN_ShowDldSizePopup(IMCBBOAFION HIDFAIBOHCC, JFDNPFFOACP NIMPEHIECJH, string EHKMFNJBLOL_Size)
	{
		TextPopupSetting popup = new TextPopupSetting();
		popup.TitleText = MessageManager.Instance.GetMessage("menu", "popup_download_size_title");
		popup.Text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_download_size_text"), EHKMFNJBLOL_Size);
		popup.Buttons = new ButtonInfo[2] {
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		PopupWindowManager.Show(popup, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) => {
			//0x1348888
			if(INDDJNMPONH != PopupButton.ButtonType.Negative)
			{
				HIDFAIBOHCC();
				return;
			}
			NIMPEHIECJH();
			return;
		}, null, null, null);
	}

	// // RVA: 0xB2627C Offset: 0xB2627C VA: 0xB2627C
	public void AINKKHHAKLK_ShowDldSizeErrorPopup(IMCBBOAFION HIDFAIBOHCC)
	{
		TextPopupSetting popup = new TextPopupSetting();
		popup.TitleText = MessageManager.Instance.GetMessage("menu", "popup_download_size_title");
		popup.Text = MessageManager.Instance.GetMessage("menu", "popup_download_size_error");
		popup.Buttons = new ButtonInfo[1] {
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Retry, Type = PopupButton.ButtonType.Positive }
		};
		PopupWindowManager.Show(popup, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) => {
			//0x13488E8
			HIDFAIBOHCC();
		}, null, null, null);
	}

	// // RVA: 0xB2657C Offset: 0xB2657C VA: 0xB2657C
	// public void AEGFNBHBJEM(IMCBBOAFION HIDFAIBOHCC) { }
}
