
using System;
using System.Collections.Generic;
using System.Text;
using XeSys;

public class CCAAJNJGNDO
{
	public enum HGIFGFEJLAB
	{
		CCDOBDNDPIL_0 = 0,
		BJOHLHKGNHM_Event = 1,
		EKJGOMKEJLK_Scene = 2,
	}

	public enum BMFMICNKKJF
	{
		HJNNKCMLGFL = 1,
		INIMBLOHIEF = 2,
		ONDONJLJMJO = 3,
		NJHIAFHJIMD = 4,
	}

	public enum JLFOIPMADEP
	{
		HJNNKCMLGFL_0 = 0,
		EPIBHNAAJGL_1_UnlockNotEnoughItems = 1,
		IAHDGAGKBGJ_2_PreviousNotViewed = 2,
	}

	public enum NIPDOAIGCIB
	{
		JFEDIMKFDNH_0_Prologue = 0,
		GBECNPANBEA_1_Sns = 1,
		OEDCONLFLHD_2_Epilogue = 2,
		MOPAEGFEGCB_3 = 3,
		OOIPBACKOKH_4 = 4,
	}

	public class GALFFONBIJG
	{
		private string ADCMNODJBGJ_Title; // 0x8
		private string HBNEKPHPKII_UnlockText_; // 0xC
		private JLFOIPMADEP KKHDIHBHJCD_UnlockError; // 0x10
		private NIPDOAIGCIB EMJFHKHLHDB; // 0x14
		private int PPFNGGCBJKC_Id; // 0x18
		private int MKPJBDFDHOL_ThumbId_; // 0x1C
		private int MALFHCHNEFN_RoomId_; // 0x20
		private bool IPJMPBANBPP_Unlocked_; // 0x24
		private bool IBJNBJIFPAM_NeedUnlock; // 0x25
		private bool DJPODCBFDCN_NeedRelease; // 0x26
		private CEBFFLDKAEC_SecureInt CHOFDPDFPDC = new CEBFFLDKAEC_SecureInt(); // 0x28
		private CEBFFLDKAEC_SecureInt PFGAKEDKOPD_UnlockCost = new CEBFFLDKAEC_SecureInt(); // 0x2C
		private int KDGJBBFKLGI_Index; // 0x30
		private bool CADENLBDAEB_IsNew; // 0x34
		private bool NPMMHCENABK_PreviousViewed; // 0x35

		public string FFPANKMKAPD_Title { get { return ADCMNODJBGJ_Title; } } //0x18FDD70 LLDJLCOLINP
		public string OJAKFNNKADK_UnlockText { get { return HBNEKPHPKII_UnlockText_; } } //0x18FDD78 ENODEHGLBMB
		public int PBPOLELIPJI_AdventureId { get { return PPFNGGCBJKC_Id; } } //0x18FD6BC AJNJOPJNMHL
		public bool KKLDIKMOACO_IsSNS { get { return EMJFHKHLHDB == NIPDOAIGCIB.GBECNPANBEA_1_Sns/*1*/; } } //0x18FDAD4 KDPOHBICGIG
		public bool GOBAMBLBCOM_IsPrologueOrEpilogue { get { return EMJFHKHLHDB == NIPDOAIGCIB.OEDCONLFLHD_2_Epilogue/*2*/ || EMJFHKHLHDB == NIPDOAIGCIB.JFEDIMKFDNH_0_Prologue/*0*/; } } //0x18FDD80 LHCGKFGGKHF
		public bool CMEKNACNMCE_IsUnknown3 { get { return EMJFHKHLHDB == NIPDOAIGCIB.MOPAEGFEGCB_3/*3*/; } } //0x18FDD98 PLLDDFBFOEK
		public bool DHJFHNFFDMG_IsUnknown4 { get { return EMJFHKHLHDB == NIPDOAIGCIB.OOIPBACKOKH_4/*4*/; } } //0x18FDDAC MMKPJMILKBM 
		public NIPDOAIGCIB BMCJDCOEJFH { get { return EMJFHKHLHDB; } } //0x18FD710 DPDGJDLHLCN
		public bool CDOCOLOKCJK_Unlocked { get { return IPJMPBANBPP_Unlocked_; } } //0x18FB9E4 CPLCFJBDCJP
		public bool OKKNPGJAPAO_IsUnlockTextEmpty { get { return string.IsNullOrEmpty(HBNEKPHPKII_UnlockText_); } } //0x18FDDC0 NOJBDDDCGIK
		public int HIGLGJBBPAP_ThumbId { get { return MKPJBDFDHOL_ThumbId_; } } //0x18FDDCC JGFEIGNOGMH
		public bool OEDKEGEPFKE_NeedUnlock { get { return IBJNBJIFPAM_NeedUnlock; } } //0x18FDDD4 NGINCPFOKOI
		public int CLIHPOEBELF_RoomId { get { return MALFHCHNEFN_RoomId_; } } //0x18FDDDC KOJLDOBBFLI
		public bool FICACPOCAPG_NeedRelease { get { return DJPODCBFDCN_NeedRelease; } } //0x18FDDE4 ENGDEDCEKMH
		public int DEIJDMPOPJF { get { return MKPJBDFDHOL_ThumbId_; } } //0x18FDDEC OOCJFEMAHJM
		public int LIPNNILKOLH { get { return CHOFDPDFPDC.DNJEJEANJGL_Value; } } //0x18FDB3C JPCNEPAEIBI
		public int GAGNJGMKPME_UnlockCost { get { return PFGAKEDKOPD_UnlockCost.DNJEJEANJGL_Value; } } //0x18FDB68 HPPBIPOOLJL
		public JLFOIPMADEP NHKNPHLNHHD_UnlockError { get { return KKHDIHBHJCD_UnlockError; } } //0x18FDDF4 GJGCBDFLLHE
		public bool IFNIEPPAMBE_IsNew { get { return CADENLBDAEB_IsNew; } set { CADENLBDAEB_IsNew = value; } } //0x18FB9EC DDMKFLKBLLM 0x18FDDFC GDNJIFOJKCJ
		public int DEAKHOJCBDM_Index { get { return KDGJBBFKLGI_Index; } }  //0x18FDE04 NCJIACPIFGD 
		public bool GELLHOIEABC_PreviousViewed { get { return NPMMHCENABK_PreviousViewed; } set { NPMMHCENABK_PreviousViewed = value; } } //0x18FDE0C MHCIBMHLBMN 0x18FD6B4 LAMLNFGBNOF

		//// RVA: 0x18FDAE4 Offset: 0x18FDAE4 VA: 0x18FDAE4
		public FENCAJJBLBH KPOCKNCJBPN()
		{
			FENCAJJBLBH f = CHOFDPDFPDC.KPOCKNCJBPN_CheckSecure();
			if(f != null)
				return f;
			return PFGAKEDKOPD_UnlockCost.KPOCKNCJBPN_CheckSecure();
		}

		//// RVA: 0x18FAB44 Offset: 0x18FAB44 VA: 0x18FAB44
		public void KHEKNNFCAOI(string _ADCMNODJBGJ_Title, string _HBNEKPHPKII_UnlockText, NIPDOAIGCIB INDDJNMPONH, int _PPFNGGCBJKC_AdvId, int _OAFJONPIFGM_ThumbId, int _MALFHCHNEFN_RoomId, bool _IBJNBJIFPAM_NeedUnlock, bool _IPJMPBANBPP_Unlocked)
		{
			this.ADCMNODJBGJ_Title = _ADCMNODJBGJ_Title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC_Id = _PPFNGGCBJKC_AdvId;
			MKPJBDFDHOL_ThumbId_ = _OAFJONPIFGM_ThumbId;
			this.MALFHCHNEFN_RoomId_ = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Unlocked_ = _IPJMPBANBPP_Unlocked;
			this.IBJNBJIFPAM_NeedUnlock = _IBJNBJIFPAM_NeedUnlock;
			DJPODCBFDCN_NeedRelease = false;
			KDGJBBFKLGI_Index = 0;
			CADENLBDAEB_IsNew = false;
			NPMMHCENABK_PreviousViewed = false;
		}

		//// RVA: 0x18FCF48 Offset: 0x18FCF48 VA: 0x18FCF48
		public void KHEKNNFCAOI(string _ADCMNODJBGJ_Title, string _HBNEKPHPKII_UnlockText, NIPDOAIGCIB INDDJNMPONH, int _PPFNGGCBJKC_AdvId, int _OAFJONPIFGM_ThumbId, int _MALFHCHNEFN_RoomId, bool IBJNBJIFPAM, bool _IPJMPBANBPP_Unlocked, bool _DJPODCBFDCN_NeedRelease, int CHOFDPDFPDC, int _PFGAKEDKOPD_UnlockCost, JLFOIPMADEP _LJPMEHDDBGP_UnlockError)
		{
			this.ADCMNODJBGJ_Title = _ADCMNODJBGJ_Title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC_Id = _PPFNGGCBJKC_AdvId;
			MKPJBDFDHOL_ThumbId_ = _OAFJONPIFGM_ThumbId;
			this.MALFHCHNEFN_RoomId_ = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Unlocked_ = _IPJMPBANBPP_Unlocked;
			this.IBJNBJIFPAM_NeedUnlock = IBJNBJIFPAM;
			KDGJBBFKLGI_Index = 0;
			CADENLBDAEB_IsNew = false;
			NPMMHCENABK_PreviousViewed = false;
			this.DJPODCBFDCN_NeedRelease = _DJPODCBFDCN_NeedRelease;
			this.CHOFDPDFPDC.DNJEJEANJGL_Value = CHOFDPDFPDC;
			this.PFGAKEDKOPD_UnlockCost.DNJEJEANJGL_Value = _PFGAKEDKOPD_UnlockCost;
			KKHDIHBHJCD_UnlockError = _LJPMEHDDBGP_UnlockError;
		}

		//// RVA: 0x18FB9F4 Offset: 0x18FB9F4 VA: 0x18FB9F4
		public void KHEKNNFCAOI(string _ADCMNODJBGJ_Title, string _HBNEKPHPKII_UnlockText, NIPDOAIGCIB INDDJNMPONH, int _PPFNGGCBJKC_AdvId, int _OAFJONPIFGM_ThumbId, int _MALFHCHNEFN_RoomId, bool IBJNBJIFPAM, bool _IPJMPBANBPP_Unlocked, int _KDGJBBFKLGI_Index, bool _CADENLBDAEB_IsNew, bool _NPMMHCENABK_PreviousViewed)
		{
			this.ADCMNODJBGJ_Title = _ADCMNODJBGJ_Title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC_Id = _PPFNGGCBJKC_AdvId;
			MKPJBDFDHOL_ThumbId_ = _OAFJONPIFGM_ThumbId;
			this.MALFHCHNEFN_RoomId_ = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Unlocked_ = _IPJMPBANBPP_Unlocked;
			this.IBJNBJIFPAM_NeedUnlock = IBJNBJIFPAM;
			DJPODCBFDCN_NeedRelease = false;
			this.KDGJBBFKLGI_Index = _KDGJBBFKLGI_Index;
			this.CADENLBDAEB_IsNew = _CADENLBDAEB_IsNew;
			this.NPMMHCENABK_PreviousViewed = _NPMMHCENABK_PreviousViewed;
		}
	}

	private List<GALFFONBIJG> DHPMDOCLBGD = new List<GALFFONBIJG>(); // 0x8
	private StringBuilder EIIFHEMIAIJ = new StringBuilder(); // 0xC
	private FDDIIKBJNNA JCMHPMLKBHI = new FDDIIKBJNNA(); // 0x10
	private GCIJNCFDNON_SceneInfo KODEHLPFHEG = new GCIJNCFDNON_SceneInfo(); // 0x14
	private int MAIJBDCJPNJ_EventId; // 0x18
	private int FLHNEKAHINP; // 0x1C
	private HGIFGFEJLAB KDJHLBCMMAG; // 0x20
	private StringBuilder FAEDHJHCEFJ = new StringBuilder(); // 0x24
	public int IPCPFJJPIII; // 0x28

	public List<GALFFONBIJG> FFPCLEONGHE { get { return DHPMDOCLBGD; } } //0x18F9AB0 IHPMEHJGHIP
	public int PPMNNKKFJNM { get { return MAIJBDCJPNJ_EventId; } } //0x18F9AB8 KOGGPFOFOBL
	public HGIFGFEJLAB IMAGLAKEMIE_StoryType { get { return KDJHLBCMMAG; } } //0x18F9AC0 EFMJDECNOLP

	//// RVA: 0x18F9AC8 Offset: 0x18F9AC8 VA: 0x18F9AC8
	public static int FCMFPPALLOM(int OAFJONPIFGM)
	{
		return OAFJONPIFGM % 1000000;
	}

	//// RVA: 0x18F9AEC Offset: 0x18F9AEC VA: 0x18F9AEC
	public static int NNDBMLNMDJM(int BCCHOBPJJKE)
	{
		return BCCHOBPJJKE + 1000000;
	}

	//// RVA: 0x18F9AF8 Offset: 0x18F9AF8 VA: 0x18F9AF8
	public void KHEKNNFCAOI_InitFromCurrentEvent(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		MAIJBDCJPNJ_EventId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		DHPMDOCLBGD.Clear();
		if(LIKDEHHKFEH.GFIBLLLHMPD_StartAdventureId > 0)
		{
			GALFFONBIJG g = new GALFFONBIJG();
			g.KHEKNNFCAOI(bk.GetMessageByLabel("event_story_text_001"), "", NIPDOAIGCIB.JFEDIMKFDNH_0_Prologue, LIKDEHHKFEH.GFIBLLLHMPD_StartAdventureId, LIKDEHHKFEH.PGIIDPEGGPI_EventId, 0, false, true);
			DHPMDOCLBGD.Add(g);
		}
		if(LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId > 0)
		{
			bool isAdvNew = true;
			if(LIKDEHHKFEH.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				isAdvNew = !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId);
			}
			GALFFONBIJG g = new GALFFONBIJG();
			EIIFHEMIAIJ.Clear();
			if(isAdvNew)
			{
				DateTime dt = Utility.GetLocalDateTime(LIKDEHHKFEH.JDDFILGNGFH);
				EIIFHEMIAIJ.AppendFormat(bk.GetMessageByLabel("event_story_text_004"), new object[5]
				{
					dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute
				});
			}
			g.KHEKNNFCAOI(bk.GetMessageByLabel("event_story_text_002"), EIIFHEMIAIJ.ToString(), NIPDOAIGCIB.OEDCONLFLHD_2_Epilogue, LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId, LIKDEHHKFEH.PGIIDPEGGPI_EventId, 0, false, !isAdvNew);
			DHPMDOCLBGD.Add(g);
		}
		JCMHPMLKBHI.KHEKNNFCAOI(true, false, -1);
		for(int i = 0; i < LIKDEHHKFEH.PFPJHJJAGAG_Rewards.Count; i++)
		{
			for(int j = 0; j < LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items.Count; j++)
			{
				if(LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
				{
					for(int k = 0; k < JCMHPMLKBHI.NPKPBDIDBBG_RoomData.Count; k++)
					{
						for(int kk = 0; kk < JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA.Count; kk++)
						{
							if(JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[kk].AIPLIEMLHGC == LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId)
							{
								GALFFONBIJG g = new GALFFONBIJG();
								EIIFHEMIAIJ.Clear();
								bool hasItem = KAOFEDMLMLI(LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId);
								if(LIKDEHHKFEH.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
								{
									if(!hasItem)
									{
										EIIFHEMIAIJ.Append(bk.GetMessageByLabel("event_story_text_003"));
									}
								}
								int idx = DHPMDOCLBGD.FindIndex((GALFFONBIJG GHPLINIACBB) =>
								{
									//0x18FDD44
									return GHPLINIACBB.KKLDIKMOACO_IsSNS;
								});
								string name;
								bool AlreadyUnlocked;
								if(idx < 0 || !DLJOPILDKBI_IsNew(JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k], LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId - 1))
								{
									name = JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[kk].OPFGFINHFCE_Name;
									AlreadyUnlocked = true;
								}
								else
								{
									name = bk.GetMessageByLabel("event_story_text_005");
									AlreadyUnlocked = false;
								}
								g.KHEKNNFCAOI(name, EIIFHEMIAIJ.ToString(), NIPDOAIGCIB.GBECNPANBEA_1_Sns, LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId, 0, JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k].MALFHCHNEFN_Id, !AlreadyUnlocked, AlreadyUnlocked && hasItem);
								DHPMDOCLBGD.Add(g);
								JCMHPMLKBHI.NPKPBDIDBBG_RoomData[k].MCGDHHHFBMO_GetUnreadIndex(t, false);
								break;
							}
						}
					}
				}
			}
		}
		DHPMDOCLBGD.Sort(CEAIGKOGLIN);
		IPCPFJJPIII = 1;
		KDJHLBCMMAG = HGIFGFEJLAB.CCDOBDNDPIL_0;
	}

	//// RVA: 0x18FAE64 Offset: 0x18FAE64 VA: 0x18FAE64
	public void MFCPHGNMMFA(KNKDBNFMAKF_EventSp LIKDEHHKFEH)
	{
		TodoLogger.LogError(TodoLogger.EventSp_7, "Event SP");
	}

	//// RVA: 0x18FBA50 Offset: 0x18FBA50 VA: 0x18FBA50
	public void KHEKNNFCAOI_InitFromEventId(int _OAFJONPIFGM_EventId)
	{
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		DHPMDOCLBGD.Clear();
		MAIJBDCJPNJ_EventId = _OAFJONPIFGM_EventId;
		bool previousSeen = true;
		bool allReleased = true;
		int index = 1;
		int g = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON_StoryPartsList.Count; i++)
		{
			FBIOJHECAHB_EventStory.ENDMMNNOAIL_StoryPartInfo dbEventStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON_StoryPartsList[i];
			if(dbEventStory.PPEGAKEIEGM_Enabled == 2)
			{
				if(dbEventStory.OAFJONPIFGM_EventId == _OAFJONPIFGM_EventId)
				{
					GALFFONBIJG d = new GALFFONBIJG();
					switch(dbEventStory.JDJNNJEJDAJ_Type)
					{
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.JFEDIMKFDNH_Prologue/*1*/:
							string str2 = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if(str2 == "")
							{
								str2 = menuBk.GetMessageByLabel("event_story_text_001");
							}
							d.KHEKNNFCAOI(str2, "", NIPDOAIGCIB.JFEDIMKFDNH_0_Prologue/*0*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.GBECNPANBEA_2_Sns/*2*/:
							for(int j = 0; j < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG.Count; j++)
							{
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[j];
								bool prevReleased = allReleased;
								if(saveSns.HBNIMMAEKHJ_Id == dbEventStory.LOHMKCPKBON_AdvId)
								{
									BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_Talks[dbEventStory.LOHMKCPKBON_AdvId - 1];
									JLFOIPMADEP unlockErrorType = JLFOIPMADEP.HJNNKCMLGFL_0/*0*/;
									if (saveSns.BEBJKJKBOGH_Date == 0)
									{
										if(dbEventStory.CHOFDPDFPDC == 2)
										{
											FAEDHJHCEFJ.SetFormat(menuBk.GetMessageByLabel("event_story_text_006"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1), dbEventStory.PFGAKEDKOPD_UnlockSpCost, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
											int ownedSpItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(1);
											unlockErrorType = JLFOIPMADEP.HJNNKCMLGFL_0/*0*/;
											if (dbEventStory.PFGAKEDKOPD_UnlockSpCost <= ownedSpItem)
												unlockErrorType = JLFOIPMADEP.EPIBHNAAJGL_1_UnlockNotEnoughItems/*1*/;
										}
										if (previousSeen)
											unlockErrorType = unlockErrorType == JLFOIPMADEP.HJNNKCMLGFL_0/*0*/ ? JLFOIPMADEP.EPIBHNAAJGL_1_UnlockNotEnoughItems/*1*/ : JLFOIPMADEP.HJNNKCMLGFL_0/*0*/;
										else
											unlockErrorType = JLFOIPMADEP.IAHDGAGKBGJ_2_PreviousNotViewed/*2*/;
										prevReleased = false;
									}
									else
									{
										FAEDHJHCEFJ.Set("");
									}
									string s1, s2;
									if(!allReleased)
									{
										s1 = menuBk.GetMessageByLabel("event_story_text_005");
										s2 = "";
									}
									else
									{
										s1 = masterBk.GetMessageByLabel("sns_nm_" + dbSns.AIPLIEMLHGC_SnsId.ToString("D4"));
										s2 = FAEDHJHCEFJ.ToString();
									}
									d.KHEKNNFCAOI(s1, s2, NIPDOAIGCIB.GBECNPANBEA_1_Sns/*1*/, dbSns.AIPLIEMLHGC_SnsId, _OAFJONPIFGM_EventId, dbSns.MALFHCHNEFN_RoomId, prevReleased, true, saveSns.BEBJKJKBOGH_Date == 0, dbEventStory.CHOFDPDFPDC, dbEventStory.PFGAKEDKOPD_UnlockSpCost, unlockErrorType);
									previousSeen = saveSns.LDJIMGPHFPA_Cnt > 0;
								}
								allReleased = prevReleased;
							}
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.OEDCONLFLHD_Epilogue/*3*/:
							string str = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if (str == "")
							{
								str = menuBk.GetMessageByLabel("event_story_text_002");
							}
							d.KHEKNNFCAOI(str, "", NIPDOAIGCIB.OEDCONLFLHD_2_Epilogue/*2*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.DCDEBCIMEMM_Opening/*4*/:
							d.KHEKNNFCAOI(string.Format(menuBk.GetMessageByLabel("event_story_text_007"), g + 1),
								"", g != 0 ? NIPDOAIGCIB.OEDCONLFLHD_2_Epilogue/*2*/ : NIPDOAIGCIB.JFEDIMKFDNH_0_Prologue/*0*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							g++;
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.MOPAEGFEGCB_5_EpisodeStory/*5*/:
							string title = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if (title == "")
								title = JpStringLiterals.StringLiteral_9714 + index.ToString() + JpStringLiterals.StringLiteral_9715;
							string unlockText = "";
							NIPDOAIGCIB type;
							bool unlocked, previousViewed;
							if (dbEventStory.CHOFDPDFPDC == 4)
							{
								unlocked = true;
								if (!NLKEJAFBDGC(dbEventStory.OAFJONPIFGM_EventId, dbEventStory.PFGAKEDKOPD_UnlockSpCost))
								{
									title = menuBk.GetMessageByLabel("event_story_text_005");
									unlockText = menuBk.GetMessageByLabel("event_story_text_015");
									unlocked = false;
								}
								type = NIPDOAIGCIB.OOIPBACKOKH_4/*4*/;
								previousViewed = allReleased;
								allReleased &= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(dbEventStory.LOHMKCPKBON_AdvId);
							}
							else
							{
								type = NIPDOAIGCIB.MOPAEGFEGCB_3/*3*/;
								if(dbEventStory.CHOFDPDFPDC == 3)
								{
									unlocked = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(dbEventStory.LOHMKCPKBON_AdvId); ;
									previousViewed = false;
								}
								else
								{
									unlocked = true;
									previousViewed = false;
								}
							}
							d.KHEKNNFCAOI(title, unlockText, type, dbEventStory.LOHMKCPKBON_AdvId, dbEventStory.OAFJONPIFGM_EventId, 
								0, false, unlocked, index, false, previousViewed);
							index++;
							break;
					}
					DHPMDOCLBGD.Add(d);
				}
			}
		}
		DHPMDOCLBGD.Sort(CEAIGKOGLIN);
		IPCPFJJPIII = 3;
		KDJHLBCMMAG = HGIFGFEJLAB.BJOHLHKGNHM_Event/*1*/;
	}

	//// RVA: 0x18FD4A0 Offset: 0x18FD4A0 VA: 0x18FD4A0
	public void MFMBGODNFGG_InitFromScene(int _BCCHOBPJJKE_SceneId)
	{
		KHEKNNFCAOI_InitFromEventId(_BCCHOBPJJKE_SceneId + 1000000);
		IPCPFJJPIII = 4;
		KDJHLBCMMAG = HGIFGFEJLAB.EKJGOMKEJLK_Scene/*2*/;
	}

	//// RVA: 0x18FACBC Offset: 0x18FACBC VA: 0x18FACBC
	private bool DLJOPILDKBI_IsNew(GAKAAIHLFKI GCBDNOPCGNP, int AIPLIEMLHGC)
	{
		for(int i = GCBDNOPCGNP.CNEOPOINCBA.Count - 1; i >= 0; i--)
		{
			if(GCBDNOPCGNP.CNEOPOINCBA[i].EDCBHGECEBE_Read)
			{
				if(GCBDNOPCGNP.CNEOPOINCBA[i].AIPLIEMLHGC == AIPLIEMLHGC)
				{
					if(GCBDNOPCGNP.CNEOPOINCBA[i].GAIEHFCHAOK_New)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x18FAB8C Offset: 0x18FAB8C VA: 0x18FAB8C
	private bool KAOFEDMLMLI(int AAMKOMBOCNL)
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[AAMKOMBOCNL - 1].PMKJFKJFDOC_Itm != 0;
	}

	//// RVA: 0x18FD4D0 Offset: 0x18FD4D0 VA: 0x18FD4D0
	public void HFLNCEOIBJI()
	{
		if(KDJHLBCMMAG == HGIFGFEJLAB.EKJGOMKEJLK_Scene/*2*/)
		{
			bool previousViewed = true;
			for(int i = 0; i < DHPMDOCLBGD.Count; i++)
			{
				DHPMDOCLBGD[i].GELLHOIEABC_PreviousViewed = previousViewed;
				previousViewed &= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(DHPMDOCLBGD[i].PBPOLELIPJI_AdventureId);
			}
		}
	}

	//// RVA: 0x18FD6C4 Offset: 0x18FD6C4 VA: 0x18FD6C4
	private int CEAIGKOGLIN(GALFFONBIJG KCADLFGPNKH, GALFFONBIJG NEKKJMFOEDA)
	{
		int res = KCADLFGPNKH.BMCJDCOEJFH - NEKKJMFOEDA.BMCJDCOEJFH;
		if (res == 0)
			res = KCADLFGPNKH.PBPOLELIPJI_AdventureId - NEKKJMFOEDA.PBPOLELIPJI_AdventureId;
		return res;
	}

	//// RVA: 0x18FD718 Offset: 0x18FD718 VA: 0x18FD718
	public void IIOBBJFCHGH(int GGBHHDLHKEP)
	{
		GALFFONBIJG c = DHPMDOCLBGD[GGBHHDLHKEP];
		if(!c.KKLDIKMOACO_IsSNS)
			return;
		if(c.KPOCKNCJBPN() != null)
		{
			CIOECGOMILE.HHCJCDFCLOB.BLCDJDJJBHC = true;
		}
		else
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			DDEMMEPBOIA_Sns.EFIFBJGKPJF sns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[c.PBPOLELIPJI_AdventureId - 1];
			sns.BEBJKJKBOGH_Date = t;
			KHEKNNFCAOI_InitFromEventId(MAIJBDCJPNJ_EventId);
			if(c.LIPNNILKOLH == 2)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NLOGLGKPMNI_ConsumeItem(1, c.GAGNJGMKPME_UnlockCost);
			}
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}
	}

	//// RVA: 0x18FCFF4 Offset: 0x18FCFF4 VA: 0x18FCFF4
	public bool NLKEJAFBDGC(int PGIIDPEGGPI, int PFGAKEDKOPD)
	{
		int index = (PGIIDPEGGPI % 1000000) - 1;
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[index];
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[index];
		KODEHLPFHEG.KHEKNNFCAOI(scene.PPFNGGCBJKC_Id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_Mlt, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_Luck, scene.LHMOAJAIJCO_New, scene.BEBJKJKBOGH_Date, scene.DMNIMMGGJJJ_Leaf);
		if(KODEHLPFHEG.CGKAEMGLHNK_IsUnlocked())
		{
			if(dbScene.PPEGAKEIEGM_En > 1)
			{
				if(KODEHLPFHEG.JKGFBFPIMGA_Rarity > 5)
				{
					if(KODEHLPFHEG.FGMPFHOEPEL_GetNumUnlockedStory() != 0)
					{
						if (PFGAKEDKOPD <= KODEHLPFHEG.FGMPFHOEPEL_GetNumUnlockedStory())
							return true;
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x18FDB94 Offset: 0x18FDB94 VA: 0x18FDB94
	//public void JFNJCPBONBN(KNKDBNFMAKF LIKDEHHKFEH, int KDGJBBFKLGI, bool OAFPGJLCNFM) { }
}
