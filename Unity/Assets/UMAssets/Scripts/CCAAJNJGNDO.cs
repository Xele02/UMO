
using System.Collections.Generic;
using System.Text;
using XeSys;

public class CCAAJNJGNDO
{
	public enum HGIFGFEJLAB
	{
		CCDOBDNDPIL = 0,
		BJOHLHKGNHM = 1,
		EKJGOMKEJLK = 2,
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
		HJNNKCMLGFL = 0,
		EPIBHNAAJGL = 1,
		IAHDGAGKBGJ = 2,
	}

	public enum NIPDOAIGCIB
	{
		JFEDIMKFDNH = 0,
		GBECNPANBEA = 1,
		OEDCONLFLHD = 2,
		MOPAEGFEGCB = 3,
		OOIPBACKOKH = 4,
	}

	public class GALFFONBIJG
	{
		private string ADCMNODJBGJ; // 0x8
		private string HBNEKPHPKII; // 0xC
		private JLFOIPMADEP KKHDIHBHJCD; // 0x10
		private NIPDOAIGCIB EMJFHKHLHDB; // 0x14
		private int PPFNGGCBJKC; // 0x18
		private int MKPJBDFDHOL; // 0x1C
		private int MALFHCHNEFN; // 0x20
		private bool IPJMPBANBPP; // 0x24
		private bool IBJNBJIFPAM; // 0x25
		private bool DJPODCBFDCN; // 0x26
		private CEBFFLDKAEC_SecureInt CHOFDPDFPDC = new CEBFFLDKAEC_SecureInt(); // 0x28
		private CEBFFLDKAEC_SecureInt PFGAKEDKOPD = new CEBFFLDKAEC_SecureInt(); // 0x2C
		private int KDGJBBFKLGI; // 0x30
		private bool CADENLBDAEB; // 0x34
		private bool NPMMHCENABK; // 0x35

		public string FFPANKMKAPD_Title { get { return ADCMNODJBGJ; } } //0x18FDD70 LLDJLCOLINP
		public string OJAKFNNKADK_UnlockText { get { return HBNEKPHPKII; } } //0x18FDD78 ENODEHGLBMB
		public int PBPOLELIPJI_AdventureId { get { return PPFNGGCBJKC; } } //0x18FD6BC AJNJOPJNMHL
		public bool KKLDIKMOACO_IsSNS { get { return EMJFHKHLHDB == NIPDOAIGCIB.GBECNPANBEA/*1*/; } } //0x18FDAD4 KDPOHBICGIG
		public bool GOBAMBLBCOM { get { return EMJFHKHLHDB == NIPDOAIGCIB.OEDCONLFLHD/*2*/ || EMJFHKHLHDB == NIPDOAIGCIB.JFEDIMKFDNH/*0*/; } } //0x18FDD80 LHCGKFGGKHF
		public bool CMEKNACNMCE { get { return EMJFHKHLHDB == NIPDOAIGCIB.MOPAEGFEGCB/*3*/; } } //0x18FDD98 PLLDDFBFOEK
		public bool DHJFHNFFDMG { get { return EMJFHKHLHDB == NIPDOAIGCIB.OOIPBACKOKH/*4*/; } } //0x18FDDAC MMKPJMILKBM 
		public NIPDOAIGCIB BMCJDCOEJFH { get { return EMJFHKHLHDB; } } //0x18FD710 DPDGJDLHLCN
		public bool CDOCOLOKCJK_Unlocked { get { return IPJMPBANBPP; } } //0x18FB9E4 CPLCFJBDCJP
		public bool OKKNPGJAPAO_IsUnlockTextEmpty { get { return string.IsNullOrEmpty(HBNEKPHPKII); } } //0x18FDDC0 NOJBDDDCGIK
		public int HIGLGJBBPAP_ThumbId { get { return MKPJBDFDHOL; } } //0x18FDDCC JGFEIGNOGMH
		public bool OEDKEGEPFKE { get { return IBJNBJIFPAM; } } //0x18FDDD4 NGINCPFOKOI
		public int CLIHPOEBELF_RoomId { get { return MALFHCHNEFN; } } //0x18FDDDC KOJLDOBBFLI
		public bool FICACPOCAPG { get { return DJPODCBFDCN; } } //0x18FDDE4 ENGDEDCEKMH
		//public int DEIJDMPOPJF { get; } 0x18FDDEC OOCJFEMAHJM
		//public int LIPNNILKOLH { get; } 0x18FDB3C JPCNEPAEIBI
		//public int GAGNJGMKPME { get; } 0x18FDB68 HPPBIPOOLJL
		//public CCAAJNJGNDO.JLFOIPMADEP NHKNPHLNHHD { get; } 0x18FDDF4 GJGCBDFLLHE
		public bool IFNIEPPAMBE { get { return CADENLBDAEB; } set { CADENLBDAEB = value; } } //0x18FB9EC DDMKFLKBLLM 0x18FDDFC GDNJIFOJKCJ
		public int DEAKHOJCBDM_Index { get { return KDGJBBFKLGI; } }  //0x18FDE04 NCJIACPIFGD 
		public bool GELLHOIEABC { get { return NPMMHCENABK; } set { NPMMHCENABK = value; } } //0x18FDE0C MHCIBMHLBMN 0x18FD6B4 LAMLNFGBNOF

		//// RVA: 0x18FDAE4 Offset: 0x18FDAE4 VA: 0x18FDAE4
		//public FENCAJJBLBH KPOCKNCJBPN() { }

		//// RVA: 0x18FAB44 Offset: 0x18FAB44 VA: 0x18FAB44
		public void KHEKNNFCAOI(string ADCMNODJBGJ, string HBNEKPHPKII, NIPDOAIGCIB INDDJNMPONH, int PPFNGGCBJKC, int OAFJONPIFGM, int MALFHCHNEFN, bool IBJNBJIFPAM, bool IPJMPBANBPP)
		{
			this.ADCMNODJBGJ = ADCMNODJBGJ;
			this.HBNEKPHPKII = HBNEKPHPKII;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC = PPFNGGCBJKC;
			MKPJBDFDHOL = OAFJONPIFGM;
			this.MALFHCHNEFN = MALFHCHNEFN;
			this.IPJMPBANBPP = IPJMPBANBPP;
			this.IBJNBJIFPAM = IBJNBJIFPAM;
			DJPODCBFDCN = false;
			KDGJBBFKLGI = 0;
			CADENLBDAEB = false;
			NPMMHCENABK = false;
		}

		//// RVA: 0x18FCF48 Offset: 0x18FCF48 VA: 0x18FCF48
		public void KHEKNNFCAOI(string ADCMNODJBGJ, string HBNEKPHPKII, NIPDOAIGCIB INDDJNMPONH, int PPFNGGCBJKC, int OAFJONPIFGM, int MALFHCHNEFN, bool IBJNBJIFPAM, bool IPJMPBANBPP, bool DJPODCBFDCN, int CHOFDPDFPDC, int PFGAKEDKOPD, JLFOIPMADEP LJPMEHDDBGP)
		{
			this.ADCMNODJBGJ = ADCMNODJBGJ;
			this.HBNEKPHPKII = HBNEKPHPKII;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC = PPFNGGCBJKC;
			MKPJBDFDHOL = OAFJONPIFGM;
			this.MALFHCHNEFN = MALFHCHNEFN;
			this.IPJMPBANBPP = IPJMPBANBPP;
			this.IBJNBJIFPAM = IBJNBJIFPAM;
			KDGJBBFKLGI = 0;
			CADENLBDAEB = false;
			NPMMHCENABK = false;
			this.DJPODCBFDCN = DJPODCBFDCN;
			this.CHOFDPDFPDC.DNJEJEANJGL_Value = CHOFDPDFPDC;
			this.PFGAKEDKOPD.DNJEJEANJGL_Value = PFGAKEDKOPD;
			KKHDIHBHJCD = LJPMEHDDBGP;
		}

		//// RVA: 0x18FB9F4 Offset: 0x18FB9F4 VA: 0x18FB9F4
		public void KHEKNNFCAOI(string ADCMNODJBGJ, string HBNEKPHPKII, NIPDOAIGCIB INDDJNMPONH, int PPFNGGCBJKC, int OAFJONPIFGM, int MALFHCHNEFN, bool IBJNBJIFPAM, bool IPJMPBANBPP, int KDGJBBFKLGI, bool CADENLBDAEB, bool NPMMHCENABK)
		{
			this.ADCMNODJBGJ = ADCMNODJBGJ;
			this.HBNEKPHPKII = HBNEKPHPKII;
			EMJFHKHLHDB = INDDJNMPONH;
			this.PPFNGGCBJKC = PPFNGGCBJKC;
			MKPJBDFDHOL = OAFJONPIFGM;
			this.MALFHCHNEFN = MALFHCHNEFN;
			this.IPJMPBANBPP = IPJMPBANBPP;
			this.IBJNBJIFPAM = IBJNBJIFPAM;
			DJPODCBFDCN = false;
			this.KDGJBBFKLGI = KDGJBBFKLGI;
			this.CADENLBDAEB = CADENLBDAEB;
			this.NPMMHCENABK = NPMMHCENABK;
		}
	}

	private List<GALFFONBIJG> DHPMDOCLBGD = new List<GALFFONBIJG>(); // 0x8
	private StringBuilder EIIFHEMIAIJ = new StringBuilder(); // 0xC
	private FDDIIKBJNNA JCMHPMLKBHI = new FDDIIKBJNNA(); // 0x10
	private GCIJNCFDNON_SceneInfo KODEHLPFHEG = new GCIJNCFDNON_SceneInfo(); // 0x14
	private int MAIJBDCJPNJ; // 0x18
	private int FLHNEKAHINP; // 0x1C
	private HGIFGFEJLAB KDJHLBCMMAG; // 0x20
	private StringBuilder FAEDHJHCEFJ = new StringBuilder(); // 0x24
	public int IPCPFJJPIII; // 0x28

	public List<GALFFONBIJG> FFPCLEONGHE { get { return DHPMDOCLBGD; } } //0x18F9AB0 IHPMEHJGHIP
	public int PPMNNKKFJNM { get { return MAIJBDCJPNJ; } } //0x18F9AB8 KOGGPFOFOBL
	public HGIFGFEJLAB IMAGLAKEMIE { get { return KDJHLBCMMAG; } } //0x18F9AC0 EFMJDECNOLP

	//// RVA: 0x18F9AC8 Offset: 0x18F9AC8 VA: 0x18F9AC8
	//public static int FCMFPPALLOM(int OAFJONPIFGM) { }

	//// RVA: 0x18F9AEC Offset: 0x18F9AEC VA: 0x18F9AEC
	public static int NNDBMLNMDJM(int BCCHOBPJJKE)
	{
		return BCCHOBPJJKE + 1000000;
	}

	//// RVA: 0x18F9AF8 Offset: 0x18F9AF8 VA: 0x18F9AF8
	public void KHEKNNFCAOI(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		TodoLogger.LogError(0, "Event");
	}

	//// RVA: 0x18FAE64 Offset: 0x18FAE64 VA: 0x18FAE64
	public void MFCPHGNMMFA(KNKDBNFMAKF_EventSp LIKDEHHKFEH)
	{
		TodoLogger.LogError(0, "Event");
	}

	//// RVA: 0x18FBA50 Offset: 0x18FBA50 VA: 0x18FBA50
	public void KHEKNNFCAOI(int OAFJONPIFGM)
	{
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		DHPMDOCLBGD.Clear();
		MAIJBDCJPNJ = OAFJONPIFGM;
		bool b1 = true;
		bool b2 = true;
		int e = 1;
		int g = 0;
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON.Count; i++)
		{
			FBIOJHECAHB_EventStory.ENDMMNNOAIL dbEventStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBEMLGADAGK_EventStory.JPIGOBGOMON[i];
			if(dbEventStory.PPEGAKEIEGM == 2)
			{
				if(dbEventStory.OAFJONPIFGM == OAFJONPIFGM)
				{
					GALFFONBIJG d = new GALFFONBIJG();
					switch(dbEventStory.JDJNNJEJDAJ)
					{
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.JFEDIMKFDNH/*1*/:
							string str2 = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON.ToString("D4"));
							if(str2 == "")
							{
								str2 = menuBk.GetMessageByLabel("event_story_text_001");
							}
							d.KHEKNNFCAOI(str2, "", NIPDOAIGCIB.JFEDIMKFDNH/*0*/, dbEventStory.LOHMKCPKBON, OAFJONPIFGM, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.GBECNPANBEA/*2*/:
							for(int j = 0; j < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG.Count; j++)
							{
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FLHMJHBOBEA_Sns.HAJEJPFGILG[j];
								bool b = b2;
								if(saveSns.HBNIMMAEKHJ_Id == dbEventStory.LOHMKCPKBON)
								{
									BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[dbEventStory.LOHMKCPKBON - 1];
									JLFOIPMADEP l = JLFOIPMADEP.HJNNKCMLGFL/*0*/;
									if (saveSns.BEBJKJKBOGH_Date == 0)
									{
										if(dbEventStory.CHOFDPDFPDC == 2)
										{
											FAEDHJHCEFJ.SetFormat(menuBk.GetMessageByLabel("event_story_text_006"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1), dbEventStory.PFGAKEDKOPD, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
											int a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(1);
											l = JLFOIPMADEP.HJNNKCMLGFL/*0*/;
											if (dbEventStory.PFGAKEDKOPD <= a)
												l = JLFOIPMADEP.EPIBHNAAJGL/*1*/;
										}
										if (b1)
											l = l == JLFOIPMADEP.HJNNKCMLGFL/*0*/ ? JLFOIPMADEP.EPIBHNAAJGL/*1*/ : JLFOIPMADEP.HJNNKCMLGFL/*0*/;
										else
											l = JLFOIPMADEP.IAHDGAGKBGJ/*2*/;
										b = false;
									}
									else
									{
										FAEDHJHCEFJ.Set("");
									}
									string s1, s2;
									if(!b2)
									{
										s1 = menuBk.GetMessageByLabel("event_story_text_005");
										s2 = "";
									}
									else
									{
										s1 = masterBk.GetMessageByLabel("sns_nm_" + dbSns.AIPLIEMLHGC.ToString("D4"));
										s2 = FAEDHJHCEFJ.ToString();
									}
									d.KHEKNNFCAOI(s1, s2, NIPDOAIGCIB.GBECNPANBEA/*1*/, dbSns.AIPLIEMLHGC, OAFJONPIFGM, dbSns.MALFHCHNEFN, b, true, saveSns.BEBJKJKBOGH_Date == 0, dbEventStory.CHOFDPDFPDC, dbEventStory.PFGAKEDKOPD, l);
									b1 = saveSns.LDJIMGPHFPA_Cnt > 0;
								}
								b2 = b;
							}
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.OEDCONLFLHD/*3*/:
							string str = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON.ToString("D4"));
							if (str == "")
							{
								str = menuBk.GetMessageByLabel("event_story_text_002");
							}
							d.KHEKNNFCAOI(str, "", NIPDOAIGCIB.OEDCONLFLHD/*2*/, dbEventStory.LOHMKCPKBON, OAFJONPIFGM, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.DCDEBCIMEMM/*4*/:
							d.KHEKNNFCAOI(string.Format(menuBk.GetMessageByLabel("event_story_text_007"), g + 1),
								"", g != 0 ? NIPDOAIGCIB.OEDCONLFLHD/*2*/ : NIPDOAIGCIB.JFEDIMKFDNH/*0*/, dbEventStory.LOHMKCPKBON, OAFJONPIFGM, 0, false, true);
							g++;
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE.MOPAEGFEGCB/*5*/:
							string str3 = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON.ToString("D4"));
							if (str3 == "")
								str3 = JpStringLiterals.StringLiteral_9714 + e.ToString() + JpStringLiterals.StringLiteral_9715;
							string str4 = "";
							NIPDOAIGCIB h;
							bool b5, b6;
							if (dbEventStory.CHOFDPDFPDC == 4)
							{
								b5 = true;
								if (!NLKEJAFBDGC(dbEventStory.OAFJONPIFGM, dbEventStory.PFGAKEDKOPD))
								{
									str3 = menuBk.GetMessageByLabel("event_story_text_005");
									str4 = menuBk.GetMessageByLabel("event_story_text_015");
									b5 = false;
								}
								h = NIPDOAIGCIB.OOIPBACKOKH/*4*/;
								b6 = b2;
								b2 &= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN(dbEventStory.LOHMKCPKBON);
							}
							else
							{
								h = NIPDOAIGCIB.MOPAEGFEGCB/*3*/;
								if(dbEventStory.CHOFDPDFPDC == 3)
								{
									b5 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN(dbEventStory.LOHMKCPKBON); ;
									b6 = false;
								}
								else
								{
									b5 = true;
									b6 = false;
								}
							}
							e++;
							d.KHEKNNFCAOI(str3, str4, h, dbEventStory.LOHMKCPKBON, dbEventStory.OAFJONPIFGM, 
								0, false, b5, e, false, b6);
							break;
					}
					DHPMDOCLBGD.Add(d);
				}
			}
		}
		DHPMDOCLBGD.Sort(CEAIGKOGLIN);
		IPCPFJJPIII = 3;
		KDJHLBCMMAG = HGIFGFEJLAB.BJOHLHKGNHM/*1*/;
	}

	//// RVA: 0x18FD4A0 Offset: 0x18FD4A0 VA: 0x18FD4A0
	public void MFMBGODNFGG(int BCCHOBPJJKE)
	{
		KHEKNNFCAOI(BCCHOBPJJKE + 1000000);
		IPCPFJJPIII = 4;
		KDJHLBCMMAG = HGIFGFEJLAB.EKJGOMKEJLK/*2*/;
	}

	//// RVA: 0x18FACBC Offset: 0x18FACBC VA: 0x18FACBC
	//private bool DLJOPILDKBI(GAKAAIHLFKI GCBDNOPCGNP, int AIPLIEMLHGC) { }

	//// RVA: 0x18FAB8C Offset: 0x18FAB8C VA: 0x18FAB8C
	//private bool KAOFEDMLMLI(int AAMKOMBOCNL) { }

	//// RVA: 0x18FD4D0 Offset: 0x18FD4D0 VA: 0x18FD4D0
	//public void HFLNCEOIBJI() { }

	//// RVA: 0x18FD6C4 Offset: 0x18FD6C4 VA: 0x18FD6C4
	private int CEAIGKOGLIN(GALFFONBIJG KCADLFGPNKH, GALFFONBIJG NEKKJMFOEDA)
	{
		int res = KCADLFGPNKH.BMCJDCOEJFH - NEKKJMFOEDA.BMCJDCOEJFH;
		if (res == 0)
			res = KCADLFGPNKH.PBPOLELIPJI_AdventureId - NEKKJMFOEDA.PBPOLELIPJI_AdventureId;
		return res;
	}

	//// RVA: 0x18FD718 Offset: 0x18FD718 VA: 0x18FD718
	//public void IIOBBJFCHGH(int GGBHHDLHKEP) { }

	//// RVA: 0x18FCFF4 Offset: 0x18FCFF4 VA: 0x18FCFF4
	public bool NLKEJAFBDGC(int PGIIDPEGGPI, int PFGAKEDKOPD)
	{
		TodoLogger.LogError(TodoLogger.ToCheck, "Check value");
		int index = (PGIIDPEGGPI - 1000000) - 1;
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[index];
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[index];
		KODEHLPFHEG.KHEKNNFCAOI(scene.PPFNGGCBJKC_Id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_Mlt, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_Luck, scene.LHMOAJAIJCO_New, scene.BEBJKJKBOGH_Date, scene.DMNIMMGGJJJ_Leaf);
		if(KODEHLPFHEG.CGKAEMGLHNK_IsUnlocked())
		{
			if(dbScene.PPEGAKEIEGM_En > 1)
			{
				if(KODEHLPFHEG.JKGFBFPIMGA_Rarity > 5)
				{
					if(KODEHLPFHEG.FGMPFHOEPEL() != 0)
					{
						if (PFGAKEDKOPD <= KODEHLPFHEG.FGMPFHOEPEL())
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
