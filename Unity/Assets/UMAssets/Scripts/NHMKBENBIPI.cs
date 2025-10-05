
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class NHMKBENBIPI
{
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x10
	private JEHIAIPJNJF_FileDownloader JKJCKIMGJLM; // 0x14
	private string EHBEPOAMOFC; // 0x18
	private bool LIHOHDBDGMK; // 0x1C
	private bool IGHEMOPCHEA; // 0x1D
	private string JCMJBMBMJAK_PersistentDataPath; // 0x20
	private static List<GCGNICILKLD_AssetFileInfo> ICCMKHKNAMJ_ToDldList; // 0x0

	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x8 KPEKONPJHCL_bgs LKCDOGAFPNM_bgs NPJJMDFAIII_bgs
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0xC EAIFOAGPGGH_bgs KCLBNOKEPIG_bgs OCIMGEFKKLM_bgs
	public bool HIGBANIDIFK { get; set; } // 0x1E JOPAIHDCPFD_bgs POGACHHNMMA_bgs AHHDPJJKAJA_bgs
	//private static string FPCIBJLJOFI_Type { get; } 0x1891348 NOJDHDJNPAL_bgs
	//private static string LBEPLOJBFCM_PlatformPrefix { get; } 0x18913A4 KHCOOFHPKGE_bgs

	// RVA: 0x1891400 Offset: 0x1891400 VA: 0x1891400 Slot: 1
	~NHMKBENBIPI()
	{
		if(JKJCKIMGJLM != null)
		{
			JKJCKIMGJLM.Dispose();
			JKJCKIMGJLM = null;
		}
	}

	// RVA: 0x189147C Offset: 0x189147C VA: 0x189147C
	public void OFLDICKPNFD(bool CJPFICKPJPP, DJBHIFLHJLK FGGJNGCAFGK)
	{
		if(CJPFICKPJPP)
		{
			MAIHLKPEHJN = JHHBAFKMBDL.HHCJCDFCLOB.JDIDDHBIGIO;
		}
		else
		{
			MAIHLKPEHJN = EEHMGCMAOAB;
		}
		this.FGGJNGCAFGK = FGGJNGCAFGK;
	}

	//// RVA: 0x1891588 Offset: 0x1891588 VA: 0x1891588
	//public void DOEFFEHKKGC(Action AGPNLAKFKCN, Action NIMPEHIECJH, Action _MOBEEPPKFLG_OnFail) { }

	//// RVA: 0x18917BC Offset: 0x18917BC VA: 0x18917BC
	//public void BEOMIIOBGOJ(bool HGEJBINBHIC, Action OHBJNCLNKMG, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// RVA: 0x18919E8 Offset: 0x18919E8 VA: 0x18919E8
	public void PAHGEEOFEPM_Install(bool HGEJBINBHIC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if(!HIGBANIDIFK)
		{
			HIGBANIDIFK = true;
			JCMJBMBMJAK_PersistentDataPath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/data";
			LIHOHDBDGMK = false;
			N.a.StartCoroutineWatched(EOFJPNPFGDM_Coroutine_Install(HGEJBINBHIC, _BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, _MOBEEPPKFLG_OnFail));
		}
	}

	// RVA: 0x1891BFC Offset: 0x1891BFC VA: 0x1891BFC
	public void CEDCKHPBKLL(bool HGEJBINBHIC)
	{
		if(!LIHOHDBDGMK)
		{
			IGHEMOPCHEA = HGEJBINBHIC;
			LIHOHDBDGMK = true;
		}
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BAD8C Offset: 0x6BAD8C VA: 0x6BAD8C
	//// RVA: 0x18916E4 Offset: 0x18916E4 VA: 0x18916E4
	//private IEnumerator FCIDKNPDBIN_Co_ConfirmationInstall(Action AGPNLAKFKCN, Action NIMPEHIECJH, Action _MOBEEPPKFLG_OnFail) { }

	//[IteratorStateMachineAttribute] // RVA: 0x6BAE04 Offset: 0x6BAE04 VA: 0x6BAE04
	//// RVA: 0x18918D8 Offset: 0x18918D8 VA: 0x18918D8
	//private IEnumerator FENMAPOLNOC_Co_InstallSimple(bool HGEJBINBHIC, Action OHBJNCLNKMG, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	//[IteratorStateMachineAttribute] // RVA: 0x6BAE7C Offset: 0x6BAE7C VA: 0x6BAE7C
	//// RVA: 0x1891B04 Offset: 0x1891B04 VA: 0x1891B04
	private IEnumerator EOFJPNPFGDM_Coroutine_Install(bool HGEJBINBHIC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PopupWindowControl FPHDNEOEMEJ; // 0x34
		int NNHHACPMPPO; // 0x38
		float OFDNPDCLMGA; // 0x3C
		float BNNHBBCCPDD; // 0x40

		//0x1895D34
		bool LOBGHGIBFMM = false;
		OEPPEGHGNNO = ALDMHFCFECK;
		MAIHLKPEHJN = EEHMGCMAOAB;
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_download_size_title");
		s.Text = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_data_check");
		s.Buttons = new ButtonInfo[0];
		bool PMCGMCDEMGO = true;
		FPHDNEOEMEJ = PopupWindowManager.Show(s, null, null, null, () =>
		{
			//0x18931D0
			PMCGMCDEMGO = false;
		}, true, true, false, null, null, null, null, null);
		bool NPNNPNAIONN_IsError = false;
		yield return Co.R(DNBCFNBBCIP_Co_CreateInstallFiles(() =>
		{
			//0x18931DC
			NPNNPNAIONN_IsError = true;
		}));
		yield return new WaitWhile(() =>
		{
			return PMCGMCDEMGO;
		});
		bool APAHEOMCPNH = true;
		FPHDNEOEMEJ.Close(() =>
		{
			//0x18931F0
			APAHEOMCPNH = false;
		}, null);
		yield return new WaitWhile(() =>
		{
			//0x18931FC
			return APAHEOMCPNH;
		});
		if(NPNNPNAIONN_IsError)
		{
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
			HIGBANIDIFK = false;
			yield break;
		}
		GameManager.Instance.SetNeverSleep(true);
		if (HGEJBINBHIC)
		{
			bool ALNCNJMEFHM = false;
			yield return Co.R(HKBHCEBAACH_Co_Popup(() =>
			{
				//0x18930B0
				return;
			}, () =>
			{
				//0x1893594
				ALNCNJMEFHM = true;
			}));
			if (ALNCNJMEFHM)
			{
				DCGHGLMJEOK(LOBGHGIBFMM);
				if (NIMPEHIECJH != null)
					NIMPEHIECJH();
				yield break;
			}
		}
		else
		{
			if (ICCMKHKNAMJ_ToDldList.Count == 0)
			{
				DCGHGLMJEOK(LOBGHGIBFMM);
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				yield break;
			}
		}
		//LAB_01896740
		OEPPEGHGNNO(1, 0);
		while(!OEPPEGHGNNO(4, 0))
			yield return null;

		if (JKJCKIMGJLM != null)
			JKJCKIMGJLM.Dispose();
		PJKLMCGEJMK CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		JKJCKIMGJLM = new JEHIAIPJNJF_FileDownloader(3);
		JKJCKIMGJLM.DOMFHDPMCCO_Init(ICCMKHKNAMJ_ToDldList, EHBEPOAMOFC, JCMJBMBMJAK_PersistentDataPath);
		JEHIAIPJNJF_FileDownloader.FMOECHMCHPE LBGNKOJFOFC = (JEHIAIPJNJF_FileDownloader.HCJPJKCIBDL_DldFileInfo JGBPLIGAILE) =>
		{
			//0x1893204
			LOBGHGIBFMM = true;
			KEHOJEJMGLJ.GFOMKMANCPP(JGBPLIGAILE.ADHHKEMDOIK_LocalPath, JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.CALJIGKCAAH_last_updated_at, JGBPLIGAILE.LAPFOLJGJMB_AssetFileInfo.HHPEMFKDHLK_Hash, true);
			KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.OJCJPCHFPGO_Delete(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
			PKKHIEAEDPC d = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName);
			if(d != null)
			{
				if(d.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day > 0)
				{
					FECDBKKBAHO.FHOPNIJCFKA_FileInfo f = KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.ANIJHEBLMGB_SetValue(JGBPLIGAILE.AJPIGKBIDDL_LocalFileName, CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), d.KKPAHLMJKIH_WavId);
					f.FNALNKKMKDC_ExpireTime = CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() + d.NKGJOAEDCPH_rule.PAAPNEMBHGN_Day * 86400;
					f.GEJJEDDEPMI = d.NKGJOAEDCPH_rule.PEOIMDCECDL;
				}
			}
		};
		NNHHACPMPPO = 60;
		JKJCKIMGJLM.LAOEGNLOJHC_Start();
		bool HMHHNJGEOPC = false;
		OFDNPDCLMGA = 0;
		BNNHBBCCPDD = 0;
		while(true)
		{
			//LAB_018970f8
			yield return null;
			JKJCKIMGJLM.FBANBDCOEJL_Update();
			if(LIHOHDBDGMK)
			{
				if(!IGHEMOPCHEA)
				{
					yield return N.a.StartCoroutineWatched(LOLGOEKFGGH_Co_Cancel(() =>
					{
						//0x1893580
						HMHHNJGEOPC = true;
					}));
				}
				else
				{
					yield return N.a.StartCoroutineWatched(ECKPOFGNBFI_Co_CancelPopup(() =>
					{
						//0x1893574
						HMHHNJGEOPC = true;
					}));
				}
			}
			//LAB_01895de0
			if(HMHHNJGEOPC)
			{
				//LAB_018969b8
				OEPPEGHGNNO(2, OFDNPDCLMGA);
				GC.Collect();
				if(!HMHHNJGEOPC)
				{
					if (_BHFHGFKBOHH_OnSuccess != null)
						_BHFHGFKBOHH_OnSuccess();
				}
				else
				{
					if (NIMPEHIECJH != null)
						NIMPEHIECJH();
				}
				DCGHGLMJEOK(LOBGHGIBFMM);
				yield break;
			}
			LIHOHDBDGMK = false;
			if(JKJCKIMGJLM.CMCKNKKCNDK_status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2_Success)
			{
				OFDNPDCLMGA = 100;
				OEPPEGHGNNO(3, 100);
				//>LAB_018969b8;
				OEPPEGHGNNO(2, OFDNPDCLMGA);
				GC.Collect();
				if (!HMHHNJGEOPC)
				{
					if (_BHFHGFKBOHH_OnSuccess != null)
						_BHFHGFKBOHH_OnSuccess();
				}
				else
				{
					if (NIMPEHIECJH != null)
						NIMPEHIECJH();
				}
				DCGHGLMJEOK(LOBGHGIBFMM);
				yield break;
			}
			if (JKJCKIMGJLM.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.LPLEIJIFOKN_4_AllError)
			{
				OFDNPDCLMGA = JKJCKIMGJLM.HCAJCKCOCHC();
				OEPPEGHGNNO(3, OFDNPDCLMGA);
				if (!JKJCKIMGJLM.MNFGKBAEFFL_IsTimeout())
				{
					if (JKJCKIMGJLM.KAMPHNKAHAB_IsDiskFull)
					{
						//>LAB_01896cf4;
					}
					else
					{
						NNHHACPMPPO--;
						if (NNHHACPMPPO < 0)
						{
							GC.Collect();
							NNHHACPMPPO = 60;
						}
						//LAB_018970f8;
						continue;
					}
				}
				//LAB_01896cf4
				float prev = BNNHBBCCPDD;
				BNNHBBCCPDD = JKJCKIMGJLM.HCAJCKCOCHC();
				if (prev != BNNHBBCCPDD)
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH_Save();
					KEHOJEJMGLJ.JKIBGMKGMCK(true);
				}
				JKJCKIMGJLM.PBIMGBKLDPP_Reset();
				//LAB_01896ddc
				while (JKJCKIMGJLM.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset)
				{
					JKJCKIMGJLM.FBANBDCOEJL_Update();
					yield return null;
					//LAB_01896ddc
				}
				int APGOAMNGFFF = 0;
				int size = StorageSupport.GetAvailableStorageSizeMB();
				string str = "network";
				if (JKJCKIMGJLM.KAMPHNKAHAB_IsDiskFull)
					str = "storage";
				if (size > -1 && size < 50)
				{
					str = "storage";
				}
				MAIHLKPEHJN(str, () =>
				{
					//0x18935C8
					APGOAMNGFFF = 1;
				}, () =>
				{
					//0x18935D4
					APGOAMNGFFF = -1;
				});
				//LAB_01896fac
				while (APGOAMNGFFF == 0)
					yield return null;
				if (APGOAMNGFFF != 1)
				{
					//LAB_0189705c
					OEPPEGHGNNO(2, OFDNPDCLMGA);
					DCGHGLMJEOK(LOBGHGIBFMM);
					if (FGGJNGCAFGK != null)
						FGGJNGCAFGK();
					yield break;
				}
				JKJCKIMGJLM.PBIMGBKLDPP_Reset();
				//LAB_0189701c
				while(JKJCKIMGJLM.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset)
				{
					JKJCKIMGJLM.FBANBDCOEJL_Update();
					yield return null;
				}
				//>LAB_018970ec;
				JKJCKIMGJLM.LAOEGNLOJHC_Start();
				//>LAB_018970f8;
			}
			else
			{
				float prev = BNNHBBCCPDD;
				BNNHBBCCPDD = JKJCKIMGJLM.HCAJCKCOCHC();
				if (prev != BNNHBBCCPDD)
				{
					KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH_Save();
					KEHOJEJMGLJ.JKIBGMKGMCK(true);
				}
				int APGOAMNGFFF = 0;
				string str = "network";
				if (JKJCKIMGJLM.BHICPONFJKM_SpaceError)
					str = "storage";
				int size = StorageSupport.GetAvailableStorageSizeMB();
				if (size > -1 && size < 50)
				{
					str = "storage";
				}
				MAIHLKPEHJN(str, () =>
				{
					//0x18935A8
					APGOAMNGFFF = 1;
				}, () =>
				{
					//0x18935B4
					APGOAMNGFFF = -1;
				});
				//LAB_01896460
				while (APGOAMNGFFF == 0)
					yield return null;
				if(APGOAMNGFFF != 1)
				{
					//LAB_0189705c;
					OEPPEGHGNNO(2, OFDNPDCLMGA);
					DCGHGLMJEOK(LOBGHGIBFMM);
					if (FGGJNGCAFGK != null)
						FGGJNGCAFGK();
					yield break;
				}
				JKJCKIMGJLM.PBIMGBKLDPP_Reset();
				//LAB_018964ec
				while(JKJCKIMGJLM.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset)
				{
					JKJCKIMGJLM.FBANBDCOEJL_Update();
					yield return null;
				}
				//LAB_018970ec
				JKJCKIMGJLM.LAOEGNLOJHC_Start();
				//>LAB_018970f8;
			}
		}
	}

	//// RVA: 0x1891C74 Offset: 0x1891C74 VA: 0x1891C74
	private void DCGHGLMJEOK(bool EFGBODACPJF)
	{
		if (JKJCKIMGJLM != null)
		{
			JKJCKIMGJLM.Dispose();
			JKJCKIMGJLM = null;
		}
		if(EFGBODACPJF)
		{
			KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH_Save();
			KEHOJEJMGLJ.JKIBGMKGMCK(true);
		}
		if(ICCMKHKNAMJ_ToDldList != null)
			ICCMKHKNAMJ_ToDldList.Clear();
		GC.Collect();
		GameManager.Instance.SetNeverSleep(false);
		HIGBANIDIFK = false;
	}

	//// RVA: 0x1891E40 Offset: 0x1891E40 VA: 0x1891E40
	private bool ALDMHFCFECK(int _INDDJNMPONH_type, float LNAHJANMJNM)
	{
		return true;
	}

	//// RVA: 0x1891E48 Offset: 0x1891E48 VA: 0x1891E48
	private void EEHMGCMAOAB(string _DOGDHKIEBJA_error, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, JFDNPFFOACP NEFKBBNKNPP)
	{
		NEFKBBNKNPP();
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BAEF4 Offset: 0x6BAEF4 VA: 0x6BAEF4
	//// RVA: 0x1891E74 Offset: 0x1891E74 VA: 0x1891E74
	private IEnumerator ECKPOFGNBFI_Co_CancelPopup(Action NIMPEHIECJH)
	{
		//0x1893B28
		Debug.Log("StringLiteral_12597");
		bool HMHHNJGEOPC = false;
		yield return N.a.StartCoroutineWatched(LOLGOEKFGGH_Co_Cancel(() =>
		{
			//0x18935E8
			HMHHNJGEOPC = true;
		}));
		if(HMHHNJGEOPC)
		{
			Debug.Log("StringLiteral_12598");
			bool NDGCIEKAIIL = true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_cancel_title");
			s.Text = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_cancel");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x18935F4
			}, null, null, null, true, true, false, null, null, null, null, null);
			yield return new WaitWhile(() =>
			{
				//0x189365C
				return NDGCIEKAIIL;
			});
		}

	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BAF6C Offset: 0x6BAF6C VA: 0x6BAF6C
	//// RVA: 0x1891F3C Offset: 0x1891F3C VA: 0x1891F3C
	private IEnumerator LOLGOEKFGGH_Co_Cancel(Action NIMPEHIECJH)
	{
		//0x1893868
		Debug.Log("StringLiteral_12594");
		if(JKJCKIMGJLM.CMCKNKKCNDK_status == JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.FEJIMBDPMKI_2_Success)
		{
			Debug.Log("StringLiteral_12595");
			yield break;
		}
		JKJCKIMGJLM.PBIMGBKLDPP_Reset();
		while(JKJCKIMGJLM.CMCKNKKCNDK_status != JEHIAIPJNJF_FileDownloader.NKLKJEOKIFO_Status.PBIMGBKLDPP_0_Reset)
		{
			JKJCKIMGJLM.FBANBDCOEJL_Update();
			yield return null;
		}
		Debug.Log("StringLiteral_12596");
		if (NIMPEHIECJH != null)
			NIMPEHIECJH();
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BAFE4 Offset: 0x6BAFE4 VA: 0x6BAFE4
	//// RVA: 0x1892004 Offset: 0x1892004 VA: 0x1892004
	private IEnumerator DNBCFNBBCIP_Co_CreateInstallFiles(Action _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server;

		//0x1894464
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		JPAPJLIPNOK_RequestAssetList COJNCNGHIJC_Req = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new JPAPJLIPNOK_RequestAssetList());
		COJNCNGHIJC_Req.FPCIBJLJOFI_Type = "android";
		yield return COJNCNGHIJC_Req.GDPDELLNOBO_WaitDone(N.a);
		if(COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
		{
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
		else
		{
			EHBEPOAMOFC = string.Copy(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.GLMGHMCOMEC_base_url);
			if(ICCMKHKNAMJ_ToDldList == null)
			{
				List<string> JOJMBFBGMGN_DldQueue = new List<string>(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.KGHAJGGMPKL_files.Count);
				bool KOMKKBDABJP_end = false;
				OKDOIAEGADK_Server.BNJPAKLNOPA_WorkerThreadQueue.Add(() =>
				{
					//0x189366C
					MABKDNHNDAL(ref JOJMBFBGMGN_DldQueue, JCMJBMBMJAK_PersistentDataPath);
					ICCMKHKNAMJ_ToDldList = IAPEABPJPOE(JCMJBMBMJAK_PersistentDataPath, COJNCNGHIJC_Req.NFEAMMJIMPG_Result, JOJMBFBGMGN_DldQueue);
					KOMKKBDABJP_end = true;
				});
				yield return new WaitUntil(() =>
				{
					//0x1893760
					return KOMKKBDABJP_end;
				});
			}
		}
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BB05C Offset: 0x6BB05C VA: 0x6BB05C
	//// RVA: 0x18920CC Offset: 0x18920CC VA: 0x18920CC
	private IEnumerator HKBHCEBAACH_Co_Popup(Action AGPNLAKFKCN, Action NIMPEHIECJH)
	{
		//0x18952E8
		if(ICCMKHKNAMJ_ToDldList.Count > 0)
		{
			LFPOMKLKHPB AODHFMGKPNJ = new LFPOMKLKHPB();
			AODHFMGKPNJ.LKLCOEJLBGG();
			yield return new WaitUntil(() =>
			{
				//0x1893770
				return AODHFMGKPNJ.PLOOEECNHFB_IsDone;
			});
			bool NDGCIEKAIIL = true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_download_size_title");
			s.Text = string.Format(MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_size_text"), AODHFMGKPNJ.OBDBAEOPJPL_GetDownloadSizeString(ICCMKHKNAMJ_ToDldList));
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x18937B8
				NDGCIEKAIIL = false;
				if (_INDDJNMPONH_type == PopupButton.ButtonType.Negative)
				{
					if (NIMPEHIECJH != null)
						NIMPEHIECJH();
				}
				else if (AGPNLAKFKCN != null)
					AGPNLAKFKCN();
			}, null, null, null, true, true, false, null, null, null, null, null);
			yield return new WaitWhile(() =>
			{
				//0x189385C
				return NDGCIEKAIIL;
			});
		}
		else
		{
			bool NDGCIEKAIIL = true;
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = MessageManager.Instance.GetMessage("menu", "popup_download_size_title");
			s.Text = MessageManager.Instance.GetMessage("menu", "popup_bunchdownload_size_zero");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0x189379C
				NDGCIEKAIIL = false;
			}, null, null, null, true, true, false, null, null, null, null, null);
			yield return new WaitWhile(() =>
			{
				//0x18937A8
				return NDGCIEKAIIL;
			});
			if (NIMPEHIECJH != null)
				NIMPEHIECJH();
		}
	}

	//// RVA: 0x1892194 Offset: 0x1892194 VA: 0x1892194
	private void MABKDNHNDAL(ref List<string> _JOJMBFBGMGN_DldQueue, string CJJJPKJHOGM)
	{
		if(Directory.Exists(CJJJPKJHOGM))
		{
			string[] files = Directory.GetFiles(CJJJPKJHOGM, "*", SearchOption.AllDirectories);
			StringBuilder str = new StringBuilder();
			for(int i = 0; i < files.Length; i++)
			{
				str.Set(files[i]);
				str.Remove(0, JCMJBMBMJAK_PersistentDataPath.Length);
				str.Replace('\\', '/');
				_JOJMBFBGMGN_DldQueue.Add(str.ToString());
			}
		}
	}

	//// RVA: 0x18923A0 Offset: 0x18923A0 VA: 0x18923A0
	public static List<GCGNICILKLD_AssetFileInfo> IAPEABPJPOE(string _OGCDNCDMLCA_LocalPath, IKAHKDKIGNA CBLEBKOJJDB, List<string> _JOJMBFBGMGN_DldQueue)
	{
		List<GCGNICILKLD_AssetFileInfo> res = new List<GCGNICILKLD_AssetFileInfo>();
		List<string> l = new List<string>();
		List<int> l2 = new List<int>();
		EPGFLLGCKGA_GetValidFileListForMasterVersion(l, l2);
		List<int> l3 = new List<int>();
		foreach(var k in _JOJMBFBGMGN_DldQueue)
		{
			l3.Add(k.GetHashCode());
		}
		for(int i = 0; i < CBLEBKOJJDB.KGHAJGGMPKL_files.Count; i++)
		{
			PKKHIEAEDPC dbFile = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.NBHDIKJMLEN(CBLEBKOJJDB.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName);
			bool b = false;
			if (dbFile.NKGJOAEDCPH_rule.ABKMOFPEHEF)
			{
				string path = CBLEBKOJJDB.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName.Substring("android".Length + 2);
				int hash = path.GetHashCode();
				for(int j = 0; j < l2.Count; )
				{
					int idx = l2.IndexOf(hash, j);
					if (idx < 0)
						break;
					if(l[idx] == path)
					{
						l.RemoveAt(idx);
						l2.RemoveAt(idx);
						b = true;
						//>LAB_018929d0
					}
					else
						j = idx + 1;
				}
			}
			else
			{
				if (dbFile.NKGJOAEDCPH_rule.PNKPHBHMLNM)
					b = true;
			}
			if(b)
			{
				//LAB_018929d0
				string s = _OGCDNCDMLCA_LocalPath + CBLEBKOJJDB.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName;
				int hash2 = CBLEBKOJJDB.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName.GetHashCode();
				bool b2 = false;
				for (int k = 0; k < l3.Count; k++)
				{
					int idx2 = l3.IndexOf(hash2, k);
					if (idx2 < 0)
						break;
					if (_JOJMBFBGMGN_DldQueue[idx2] == CBLEBKOJJDB.KGHAJGGMPKL_files[i].OIEAICNAMNB_LocalFileName)
					{
						if (KEHOJEJMGLJ.NHIIAHGHOMH(s, CBLEBKOJJDB.KGHAJGGMPKL_files[i].CALJIGKCAAH_last_updated_at, CBLEBKOJJDB.KGHAJGGMPKL_files[i].HHPEMFKDHLK_Hash))
						{
							res.Add(CBLEBKOJJDB.KGHAJGGMPKL_files[i]);
						}
						b2 = true;
						break;
					}
				}
				//LAB_01892b34
				//> LAB_01892b4c;
				if(!b2)
					res.Add(CBLEBKOJJDB.KGHAJGGMPKL_files[i]);
			}
		}
		return res;
	}

	//// RVA: 0x1892CD4 Offset: 0x1892CD4 VA: 0x1892CD4
	private static void EPGFLLGCKGA_GetValidFileListForMasterVersion(List<string> EKHOLFOKEGN, List<int> NIPOOEMMMNK)
	{
		foreach (var k in IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IELDDHJMFKN_Asset.OAOOIDNBOGA_MVer_List)
		{
			if(k.IJEKNCDIIAE_mver >= 1)
			{
				if(DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion >= k.IJEKNCDIIAE_mver)
				{
					EKHOLFOKEGN.Add(k.MIMGPBHAJCO_file);
					NIPOOEMMMNK.Add(k.MIMGPBHAJCO_file.GetHashCode());
				}
			}
		}
	}
}
