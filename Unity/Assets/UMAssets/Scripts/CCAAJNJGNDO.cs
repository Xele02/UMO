
using System;
using System.Collections.Generic;
using System.Text;
using XeSys;

public class CCAAJNJGNDO
{
	public enum HGIFGFEJLAB_StoryType
	{
		CCDOBDNDPIL_0_Event = 0,
		BJOHLHKGNHM_1_EventStory = 1,
		EKJGOMKEJLK_2_Scene = 2,
	}

	public enum BMFMICNKKJF
	{
		HJNNKCMLGFL_1_None = 1,
		INIMBLOHIEF_2_set_Item = 2,
		ONDONJLJMJO = 3,
		NJHIAFHJIMD = 4,
	}

	public enum JLFOIPMADEP_UnlockError
	{
		HJNNKCMLGFL_0_None = 0,
		EPIBHNAAJGL_1_UnlockNotEnoughItems = 1,
		IAHDGAGKBGJ_2_PreviousNotViewed = 2,
	}

	public enum NIPDOAIGCIB_StoryType
	{
		JFEDIMKFDNH_0_Prologue = 0,
		GBECNPANBEA_1_Sns = 1,
		OEDCONLFLHD_2_Epilogue = 2,
		MOPAEGFEGCB_3_EpisodeStory = 3,
		OOIPBACKOKH_4 = 4,
	}

	public class GALFFONBIJG
	{
		private string ADCMNODJBGJ_title; // 0x8
		private string HBNEKPHPKII_UnlockText_; // 0xC
		private JLFOIPMADEP_UnlockError KKHDIHBHJCD_UnlockError; // 0x10
		private NIPDOAIGCIB_StoryType EMJFHKHLHDB; // 0x14
		private int PPFNGGCBJKC_id; // 0x18
		private int MKPJBDFDHOL_ThumbId; // 0x1C
		private int MALFHCHNEFN_RoomId; // 0x20
		private bool IPJMPBANBPP_Enabled; // 0x24
		private bool IBJNBJIFPAM_NeedUnlock; // 0x25
		private bool DJPODCBFDCN_NeedRelease; // 0x26
		private CEBFFLDKAEC_SecureInt CHOFDPDFPDC_ConfigValue = new CEBFFLDKAEC_SecureInt(); // 0x28
		private CEBFFLDKAEC_SecureInt PFGAKEDKOPD_UnlockCost = new CEBFFLDKAEC_SecureInt(); // 0x2C
		private int KDGJBBFKLGI_Chapter; // 0x30
		private bool CADENLBDAEB_IsNew; // 0x34
		private bool NPMMHCENABK_PreviousViewed; // 0x35

		public string FFPANKMKAPD_Title { get { return ADCMNODJBGJ_title; } } //0x18FDD70 LLDJLCOLINP_bgs
		public string OJAKFNNKADK_UnlockText { get { return HBNEKPHPKII_UnlockText_; } } //0x18FDD78 ENODEHGLBMB_bgs
		public int PBPOLELIPJI_Id { get { return PPFNGGCBJKC_id; } } //0x18FD6BC AJNJOPJNMHL_bgs AdventureId
		public bool KKLDIKMOACO_IsSNS { get { return EMJFHKHLHDB == NIPDOAIGCIB_StoryType.GBECNPANBEA_1_Sns/*1*/; } } //0x18FDAD4 KDPOHBICGIG_bgs
		public bool GOBAMBLBCOM_IsPrologueOrEpilogue { get { return EMJFHKHLHDB == NIPDOAIGCIB_StoryType.OEDCONLFLHD_2_Epilogue/*2*/ || EMJFHKHLHDB == NIPDOAIGCIB_StoryType.JFEDIMKFDNH_0_Prologue/*0*/; } } //0x18FDD80 LHCGKFGGKHF_bgs
		public bool CMEKNACNMCE_IsEpisodeStory { get { return EMJFHKHLHDB == NIPDOAIGCIB_StoryType.MOPAEGFEGCB_3_EpisodeStory/*3*/; } } //0x18FDD98 PLLDDFBFOEK_bgs
		public bool DHJFHNFFDMG_IsUnknown4 { get { return EMJFHKHLHDB == NIPDOAIGCIB_StoryType.OOIPBACKOKH_4/*4*/; } } //0x18FDDAC MMKPJMILKBM_bgs 
		public NIPDOAIGCIB_StoryType BMCJDCOEJFH { get { return EMJFHKHLHDB; } } //0x18FD710 DPDGJDLHLCN_bgs
		public bool CDOCOLOKCJK_Avaiable { get { return IPJMPBANBPP_Enabled; } } //0x18FB9E4 CPLCFJBDCJP_bgs
		public bool OKKNPGJAPAO_IsUnlockTextEmpty { get { return string.IsNullOrEmpty(HBNEKPHPKII_UnlockText_); } } //0x18FDDC0 NOJBDDDCGIK_bgs
		public int HIGLGJBBPAP_ThumbId { get { return MKPJBDFDHOL_ThumbId; } } //0x18FDDCC JGFEIGNOGMH_bgs
		public bool OEDKEGEPFKE_NeedUnlock { get { return IBJNBJIFPAM_NeedUnlock; } } //0x18FDDD4 NGINCPFOKOI_bgs
		public int CLIHPOEBELF_RoomId { get { return MALFHCHNEFN_RoomId; } } //0x18FDDDC KOJLDOBBFLI_bgs
		public bool FICACPOCAPG_NeedRelease { get { return DJPODCBFDCN_NeedRelease; } } //0x18FDDE4 ENGDEDCEKMH_bgs
		public int DEIJDMPOPJF { get { return MKPJBDFDHOL_ThumbId; } } //0x18FDDEC OOCJFEMAHJM_bgs
		public int LIPNNILKOLH { get { return CHOFDPDFPDC_ConfigValue.DNJEJEANJGL_Value; } } //0x18FDB3C JPCNEPAEIBI_bgs
		public int GAGNJGMKPME_UnlockCost { get { return PFGAKEDKOPD_UnlockCost.DNJEJEANJGL_Value; } } //0x18FDB68 HPPBIPOOLJL_bgs
		public JLFOIPMADEP_UnlockError NHKNPHLNHHD_UnlockError { get { return KKHDIHBHJCD_UnlockError; } } //0x18FDDF4 GJGCBDFLLHE_bgs
		public bool IFNIEPPAMBE_IsNew { get { return CADENLBDAEB_IsNew; } set { CADENLBDAEB_IsNew = value; } } //0x18FB9EC DDMKFLKBLLM_bgs 0x18FDDFC GDNJIFOJKCJ_bgs
		public int DEAKHOJCBDM_Index { get { return KDGJBBFKLGI_Chapter; } }  //0x18FDE04 NCJIACPIFGD_bgs 
		public bool GELLHOIEABC_PreviousViewed { get { return NPMMHCENABK_PreviousViewed; } set { NPMMHCENABK_PreviousViewed = value; } } //0x18FDE0C MHCIBMHLBMN_bgs 0x18FD6B4 LAMLNFGBNOF_bgs

		//// RVA: 0x18FDAE4 Offset: 0x18FDAE4 VA: 0x18FDAE4
		public FENCAJJBLBH KPOCKNCJBPN()
		{
			FENCAJJBLBH f = CHOFDPDFPDC_ConfigValue.KPOCKNCJBPN_CheckSecure();
			if(f != null)
				return f;
			return PFGAKEDKOPD_UnlockCost.KPOCKNCJBPN_CheckSecure();
		}

		//// RVA: 0x18FAB44 Offset: 0x18FAB44 VA: 0x18FAB44
		public void KHEKNNFCAOI_Init(string _ADCMNODJBGJ_title, string _HBNEKPHPKII_UnlockText_, NIPDOAIGCIB_StoryType _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _OAFJONPIFGM_EventId, int _MALFHCHNEFN_RoomId, bool _IBJNBJIFPAM_NeedUnlock, bool _IPJMPBANBPP_Enabled)
		{
			this.ADCMNODJBGJ_title = _ADCMNODJBGJ_title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText_;
			EMJFHKHLHDB = _INDDJNMPONH_type;
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			MKPJBDFDHOL_ThumbId = _OAFJONPIFGM_EventId;
			this.MALFHCHNEFN_RoomId = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Enabled = _IPJMPBANBPP_Enabled;
			this.IBJNBJIFPAM_NeedUnlock = _IBJNBJIFPAM_NeedUnlock;
			DJPODCBFDCN_NeedRelease = false;
			KDGJBBFKLGI_Chapter = 0;
			CADENLBDAEB_IsNew = false;
			NPMMHCENABK_PreviousViewed = false;
		}

		//// RVA: 0x18FCF48 Offset: 0x18FCF48 VA: 0x18FCF48
		public void KHEKNNFCAOI_Init(string _ADCMNODJBGJ_title, string _HBNEKPHPKII_UnlockText_, NIPDOAIGCIB_StoryType _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _OAFJONPIFGM_EventId, int _MALFHCHNEFN_RoomId, bool _IBJNBJIFPAM_NeedUnlock, bool _IPJMPBANBPP_Enabled, bool _DJPODCBFDCN_NeedRelease, int _CHOFDPDFPDC_ConfigValue, int _PFGAKEDKOPD_UnlockCost, JLFOIPMADEP_UnlockError _LJPMEHDDBGP_UnlockError)
		{
			this.ADCMNODJBGJ_title = _ADCMNODJBGJ_title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText_;
			EMJFHKHLHDB = _INDDJNMPONH_type;
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			MKPJBDFDHOL_ThumbId = _OAFJONPIFGM_EventId;
			this.MALFHCHNEFN_RoomId = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Enabled = _IPJMPBANBPP_Enabled;
			this.IBJNBJIFPAM_NeedUnlock = _IBJNBJIFPAM_NeedUnlock;
			KDGJBBFKLGI_Chapter = 0;
			CADENLBDAEB_IsNew = false;
			NPMMHCENABK_PreviousViewed = false;
			this.DJPODCBFDCN_NeedRelease = _DJPODCBFDCN_NeedRelease;
			this.CHOFDPDFPDC_ConfigValue.DNJEJEANJGL_Value = _CHOFDPDFPDC_ConfigValue;
			this.PFGAKEDKOPD_UnlockCost.DNJEJEANJGL_Value = _PFGAKEDKOPD_UnlockCost;
			KKHDIHBHJCD_UnlockError = _LJPMEHDDBGP_UnlockError;
		}

		//// RVA: 0x18FB9F4 Offset: 0x18FB9F4 VA: 0x18FB9F4
		public void KHEKNNFCAOI_Init(string _ADCMNODJBGJ_title, string _HBNEKPHPKII_UnlockText_, NIPDOAIGCIB_StoryType _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _OAFJONPIFGM_EventId, int _MALFHCHNEFN_RoomId, bool _IBJNBJIFPAM_NeedUnlock, bool _IPJMPBANBPP_Enabled, int _KDGJBBFKLGI_Chapter, bool _CADENLBDAEB_IsNew, bool _NPMMHCENABK_PreviousViewed)
		{
			this.ADCMNODJBGJ_title = _ADCMNODJBGJ_title;
			this.HBNEKPHPKII_UnlockText_ = _HBNEKPHPKII_UnlockText_;
			EMJFHKHLHDB = _INDDJNMPONH_type;
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			MKPJBDFDHOL_ThumbId = _OAFJONPIFGM_EventId;
			this.MALFHCHNEFN_RoomId = _MALFHCHNEFN_RoomId;
			this.IPJMPBANBPP_Enabled = _IPJMPBANBPP_Enabled;
			this.IBJNBJIFPAM_NeedUnlock = _IBJNBJIFPAM_NeedUnlock;
			DJPODCBFDCN_NeedRelease = false;
			this.KDGJBBFKLGI_Chapter = _KDGJBBFKLGI_Chapter;
			this.CADENLBDAEB_IsNew = _CADENLBDAEB_IsNew;
			this.NPMMHCENABK_PreviousViewed = _NPMMHCENABK_PreviousViewed;
		}
	}

	private List<GALFFONBIJG> DHPMDOCLBGD = new List<GALFFONBIJG>(); // 0x8
	private StringBuilder EIIFHEMIAIJ = new StringBuilder(); // 0xC
	private FDDIIKBJNNA JCMHPMLKBHI = new FDDIIKBJNNA(); // 0x10
	private GCIJNCFDNON_SceneInfo KODEHLPFHEG = new GCIJNCFDNON_SceneInfo(); // 0x14
	private int MAIJBDCJPNJ__UniqueId; // 0x18 EventId
	private int FLHNEKAHINP; // 0x1C
	private HGIFGFEJLAB_StoryType KDJHLBCMMAG; // 0x20
	private StringBuilder FAEDHJHCEFJ = new StringBuilder(); // 0x24
	public int IPCPFJJPIII; // 0x28

	public List<GALFFONBIJG> FFPCLEONGHE { get { return DHPMDOCLBGD; } } //0x18F9AB0 IHPMEHJGHIP_bgs
	public int PPMNNKKFJNM_EventId { get { return MAIJBDCJPNJ__UniqueId; } } //0x18F9AB8 KOGGPFOFOBL_bgs
	public HGIFGFEJLAB_StoryType IMAGLAKEMIE_StoryType { get { return KDJHLBCMMAG; } } //0x18F9AC0 EFMJDECNOLP_bgs

	//// RVA: 0x18F9AC8 Offset: 0x18F9AC8 VA: 0x18F9AC8
	public static int FCMFPPALLOM(int _OAFJONPIFGM_EventId)
	{
		return _OAFJONPIFGM_EventId % 1000000;
	}

	//// RVA: 0x18F9AEC Offset: 0x18F9AEC VA: 0x18F9AEC
	public static int NNDBMLNMDJM(int _BCCHOBPJJKE_SceneId)
	{
		return _BCCHOBPJJKE_SceneId + 1000000;
	}

	//// RVA: 0x18F9AF8 Offset: 0x18F9AF8 VA: 0x18F9AF8
	public void KHEKNNFCAOI_Init(IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		MAIJBDCJPNJ__UniqueId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
		DHPMDOCLBGD.Clear();
		if(LIKDEHHKFEH.GFIBLLLHMPD_StartAdventureId > 0)
		{
			GALFFONBIJG g = new GALFFONBIJG();
			g.KHEKNNFCAOI_Init(bk.GetMessageByLabel("event_story_text_001"), "", NIPDOAIGCIB_StoryType.JFEDIMKFDNH_0_Prologue, LIKDEHHKFEH.GFIBLLLHMPD_StartAdventureId, LIKDEHHKFEH.PGIIDPEGGPI_EventId, 0, false, true);
			DHPMDOCLBGD.Add(g);
		}
		if(LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId > 0)
		{
			bool isAdvNew = true;
			if(LIKDEHHKFEH.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
			{
				isAdvNew = !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId);
			}
			GALFFONBIJG g = new GALFFONBIJG();
			EIIFHEMIAIJ.Clear();
			if(isAdvNew)
			{
				DateTime dt = Utility.GetLocalDateTime(LIKDEHHKFEH.JDDFILGNGFH_RewardStart);
				EIIFHEMIAIJ.AppendFormat(bk.GetMessageByLabel("event_story_text_004"), new object[5]
				{
					dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute
				});
			}
			g.KHEKNNFCAOI_Init(bk.GetMessageByLabel("event_story_text_002"), EIIFHEMIAIJ.ToString(), NIPDOAIGCIB_StoryType.OEDCONLFLHD_2_Epilogue, LIKDEHHKFEH.CAKEOPLJDAF_EndAdventureId, LIKDEHHKFEH.PGIIDPEGGPI_EventId, 0, false, !isAdvNew);
			DHPMDOCLBGD.Add(g);
		}
		JCMHPMLKBHI.KHEKNNFCAOI_Init(true, false, -1);
		for(int i = 0; i < LIKDEHHKFEH.PFPJHJJAGAG_Rewards.Count; i++)
		{
			for(int j = 0; j < LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items.Count; j++)
			{
				if(LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items[j].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
				{
					for(int k = 0; k < JCMHPMLKBHI.NPKPBDIDBBG_Room.Count; k++)
					{
						for(int kk = 0; kk < JCMHPMLKBHI.NPKPBDIDBBG_Room[k].CNEOPOINCBA.Count; kk++)
						{
							if(JCMHPMLKBHI.NPKPBDIDBBG_Room[k].CNEOPOINCBA[kk].AIPLIEMLHGC_SnsId == LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId)
							{
								GALFFONBIJG g = new GALFFONBIJG();
								EIIFHEMIAIJ.Clear();
								bool hasItem = KAOFEDMLMLI(LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId);
								if(LIKDEHHKFEH.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
								{
									if(!hasItem)
									{
										EIIFHEMIAIJ.Append(bk.GetMessageByLabel("event_story_text_003"));
									}
								}
								int idx = DHPMDOCLBGD.FindIndex((GALFFONBIJG _GHPLINIACBB_x) =>
								{
									//0x18FDD44
									return _GHPLINIACBB_x.KKLDIKMOACO_IsSNS;
								});
								string name;
								bool AlreadyUnlocked;
								if(idx < 0 || !DLJOPILDKBI_IsNew(JCMHPMLKBHI.NPKPBDIDBBG_Room[k], LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId - 1))
								{
									name = JCMHPMLKBHI.NPKPBDIDBBG_Room[k].CNEOPOINCBA[kk].OPFGFINHFCE_name;
									AlreadyUnlocked = true;
								}
								else
								{
									name = bk.GetMessageByLabel("event_story_text_005");
									AlreadyUnlocked = false;
								}
								g.KHEKNNFCAOI_Init(name, EIIFHEMIAIJ.ToString(), NIPDOAIGCIB_StoryType.GBECNPANBEA_1_Sns, LIKDEHHKFEH.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_items[j].NNFNGLJOKKF_ItemId, 0, JCMHPMLKBHI.NPKPBDIDBBG_Room[k].MALFHCHNEFN_RoomId, !AlreadyUnlocked, AlreadyUnlocked && hasItem);
								DHPMDOCLBGD.Add(g);
								JCMHPMLKBHI.NPKPBDIDBBG_Room[k].MCGDHHHFBMO_GetUnreadIndex(t, false);
								break;
							}
						}
					}
				}
			}
		}
		DHPMDOCLBGD.Sort(CEAIGKOGLIN);
		IPCPFJJPIII = 1;
		KDJHLBCMMAG = HGIFGFEJLAB_StoryType.CCDOBDNDPIL_0_Event;
	}

	//// RVA: 0x18FAE64 Offset: 0x18FAE64 VA: 0x18FAE64
	public void MFCPHGNMMFA(KNKDBNFMAKF_EventSp LIKDEHHKFEH)
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(LIKDEHHKFEH.JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		DHPMDOCLBGD.Clear();
		for(int i = 0; i < ev.JIEIOFMJEBI.Count; i++)
		{
			GALFFONBIJG g = new GALFFONBIJG();
			if(ev.JIEIOFMJEBI[i].KDGJBBFKLGI_Chapter == 0 && ev.JIEIOFMJEBI[i].PLALNIIBLOF_en == 2)
			{
				MAIJBDCJPNJ__UniqueId = LIKDEHHKFEH.PGIIDPEGGPI_EventId;
				bool b_isNew = false;
				bool b3_unlocked = ev.JIEIOFMJEBI[i].PDBPFJJCADD_open_at < t;
				if(b3_unlocked)
				{
					b_isNew = !LIKDEHHKFEH.EIACOAMGEPB_GetAdvShown(ev.JIEIOFMJEBI[i].KDGJBBFKLGI_Chapter);
				}
				bool b2_previousViewed;
				string s_Title;
				if(i < 1 || (DHPMDOCLBGD[i - 1].CDOCOLOKCJK_Avaiable && !DHPMDOCLBGD[i - 1].IFNIEPPAMBE_IsNew))
				{
					//LAB_018fb3b4
					s_Title = masterBk.GetMessageByLabel("adv_nm_" + ev.JIEIOFMJEBI[i].OIAAFFHGBBD_AdvId.ToString("D4"));
					b2_previousViewed = true;
					if(s_Title == "")
					{
						s_Title = JpStringLiterals.StringLiteral_9714 + (i + 1).ToString() + JpStringLiterals.StringLiteral_9715;
					}
				}
				else
				{
					s_Title = menuBk.GetMessageByLabel("event_story_text_005");
					b_isNew = false;
					b2_previousViewed = false;
					b3_unlocked = false;
				}
				string s2_UnlockText = "";
				if(ev.JIEIOFMJEBI[i].PDBPFJJCADD_open_at >= t)
				{
					DateTime dt = Utility.GetLocalDateTime(ev.JIEIOFMJEBI[i].PDBPFJJCADD_open_at);
					EIIFHEMIAIJ.Clear();
					EIIFHEMIAIJ.AppendFormat(menuBk.GetMessageByLabel("event_story_text_004"), new object[5]
					{
						dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute
					});
					s2_UnlockText = EIIFHEMIAIJ.ToString();
				}
				g.KHEKNNFCAOI_Init(s_Title, s2_UnlockText, NIPDOAIGCIB_StoryType.MOPAEGFEGCB_3_EpisodeStory, ev.JIEIOFMJEBI[i].OIAAFFHGBBD_AdvId, MAIJBDCJPNJ__UniqueId, 0, false, b3_unlocked, ev.JIEIOFMJEBI[i].KDGJBBFKLGI_Chapter, b_isNew, b2_previousViewed);
				DHPMDOCLBGD.Add(g);
			}
		}
		IPCPFJJPIII = 2;
	}

	//// RVA: 0x18FBA50 Offset: 0x18FBA50 VA: 0x18FBA50
	public void KHEKNNFCAOI_Init(int _OAFJONPIFGM_EventId)
	{
		MessageBank menuBk = MessageManager.Instance.GetBank("menu");
		MessageBank masterBk = MessageManager.Instance.GetBank("master");
		DHPMDOCLBGD.Clear();
		MAIJBDCJPNJ__UniqueId = _OAFJONPIFGM_EventId;
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
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE_StoryPartType.JFEDIMKFDNH_1_Prologue/*1*/:
							string str2 = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if(str2 == "")
							{
								str2 = menuBk.GetMessageByLabel("event_story_text_001");
							}
							d.KHEKNNFCAOI_Init(str2, "", NIPDOAIGCIB_StoryType.JFEDIMKFDNH_0_Prologue/*0*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE_StoryPartType.GBECNPANBEA_2_Sns/*2*/:
							for(int j = 0; j < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG.Count; j++)
							{
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG[j];
								bool prevReleased = allReleased;
								if(saveSns.HBNIMMAEKHJ_Id == dbEventStory.LOHMKCPKBON_AdvId)
								{
									BOKMNHAFJHF_Sns.KEIGMAOCJHK_Talk dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA_table[dbEventStory.LOHMKCPKBON_AdvId - 1];
									JLFOIPMADEP_UnlockError unlockErrorType = JLFOIPMADEP_UnlockError.HJNNKCMLGFL_0_None/*0*/;
									if (saveSns.BEBJKJKBOGH_date == 0)
									{
										if(dbEventStory.CHOFDPDFPDC_ConfigValue == 2)
										{
											FAEDHJHCEFJ.SetFormat(menuBk.GetMessageByLabel("event_story_text_006"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1), dbEventStory.PFGAKEDKOPD_UnlockCost, EKLNMHFCAOI.NDBLEADIDLA(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 1));
											int ownedSpItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(1);
											unlockErrorType = JLFOIPMADEP_UnlockError.HJNNKCMLGFL_0_None/*0*/;
											if (dbEventStory.PFGAKEDKOPD_UnlockCost <= ownedSpItem)
												unlockErrorType = JLFOIPMADEP_UnlockError.EPIBHNAAJGL_1_UnlockNotEnoughItems/*1*/;
										}
										if (previousSeen)
											unlockErrorType = unlockErrorType == JLFOIPMADEP_UnlockError.HJNNKCMLGFL_0_None/*0*/ ? JLFOIPMADEP_UnlockError.EPIBHNAAJGL_1_UnlockNotEnoughItems/*1*/ : JLFOIPMADEP_UnlockError.HJNNKCMLGFL_0_None/*0*/;
										else
											unlockErrorType = JLFOIPMADEP_UnlockError.IAHDGAGKBGJ_2_PreviousNotViewed/*2*/;
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
									d.KHEKNNFCAOI_Init(s1, s2, NIPDOAIGCIB_StoryType.GBECNPANBEA_1_Sns/*1*/, dbSns.AIPLIEMLHGC_SnsId, _OAFJONPIFGM_EventId, dbSns.MALFHCHNEFN_RoomId, prevReleased, true, saveSns.BEBJKJKBOGH_date == 0, dbEventStory.CHOFDPDFPDC_ConfigValue, dbEventStory.PFGAKEDKOPD_UnlockCost, unlockErrorType);
									previousSeen = saveSns.LDJIMGPHFPA_Cnt > 0;
								}
								allReleased = prevReleased;
							}
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE_StoryPartType.OEDCONLFLHD_3_Epilogue/*3*/:
							string str = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if (str == "")
							{
								str = menuBk.GetMessageByLabel("event_story_text_002");
							}
							d.KHEKNNFCAOI_Init(str, "", NIPDOAIGCIB_StoryType.OEDCONLFLHD_2_Epilogue/*2*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE_StoryPartType.DCDEBCIMEMM_4_Opening/*4*/:
							d.KHEKNNFCAOI_Init(string.Format(menuBk.GetMessageByLabel("event_story_text_007"), g + 1),
								"", g != 0 ? NIPDOAIGCIB_StoryType.OEDCONLFLHD_2_Epilogue/*2*/ : NIPDOAIGCIB_StoryType.JFEDIMKFDNH_0_Prologue/*0*/, dbEventStory.LOHMKCPKBON_AdvId, _OAFJONPIFGM_EventId, 0, false, true);
							g++;
							break;
						case FBIOJHECAHB_EventStory.NMIGMCJHAIE_StoryPartType.MOPAEGFEGCB_5_EpisodeStory/*5*/:
							string title = masterBk.GetMessageByLabel("adv_nm_" + dbEventStory.LOHMKCPKBON_AdvId.ToString("D4"));
							if (title == "")
								title = JpStringLiterals.StringLiteral_9714 + index.ToString() + JpStringLiterals.StringLiteral_9715;
							string unlockText = "";
							NIPDOAIGCIB_StoryType type;
							bool unlocked, previousViewed;
							if (dbEventStory.CHOFDPDFPDC_ConfigValue == 4)
							{
								unlocked = true;
								if (!NLKEJAFBDGC(dbEventStory.OAFJONPIFGM_EventId, dbEventStory.PFGAKEDKOPD_UnlockCost))
								{
									title = menuBk.GetMessageByLabel("event_story_text_005");
									unlockText = menuBk.GetMessageByLabel("event_story_text_015");
									unlocked = false;
								}
								type = NIPDOAIGCIB_StoryType.OOIPBACKOKH_4/*4*/;
								previousViewed = allReleased;
								allReleased &= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(dbEventStory.LOHMKCPKBON_AdvId);
							}
							else
							{
								type = NIPDOAIGCIB_StoryType.MOPAEGFEGCB_3_EpisodeStory/*3*/;
								if(dbEventStory.CHOFDPDFPDC_ConfigValue == 3)
								{
									unlocked = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(dbEventStory.LOHMKCPKBON_AdvId); ;
									previousViewed = false;
								}
								else
								{
									unlocked = true;
									previousViewed = false;
								}
							}
							d.KHEKNNFCAOI_Init(title, unlockText, type, dbEventStory.LOHMKCPKBON_AdvId, dbEventStory.OAFJONPIFGM_EventId, 
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
		KDJHLBCMMAG = HGIFGFEJLAB_StoryType.BJOHLHKGNHM_1_EventStory/*1*/;
	}

	//// RVA: 0x18FD4A0 Offset: 0x18FD4A0 VA: 0x18FD4A0
	public void MFMBGODNFGG_InitFromScene(int _BCCHOBPJJKE_SceneId)
	{
		KHEKNNFCAOI_Init(_BCCHOBPJJKE_SceneId + 1000000);
		IPCPFJJPIII = 4;
		KDJHLBCMMAG = HGIFGFEJLAB_StoryType.EKJGOMKEJLK_2_Scene/*2*/;
	}

	//// RVA: 0x18FACBC Offset: 0x18FACBC VA: 0x18FACBC
	private bool DLJOPILDKBI_IsNew(GAKAAIHLFKI GCBDNOPCGNP, int _AIPLIEMLHGC_SnsId)
	{
		for(int i = GCBDNOPCGNP.CNEOPOINCBA.Count - 1; i >= 0; i--)
		{
			if(GCBDNOPCGNP.CNEOPOINCBA[i].EDCBHGECEBE_Read)
			{
				if(GCBDNOPCGNP.CNEOPOINCBA[i].AIPLIEMLHGC_SnsId == _AIPLIEMLHGC_SnsId)
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
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG[AAMKOMBOCNL - 1].PMKJFKJFDOC_Itm != 0;
	}

	//// RVA: 0x18FD4D0 Offset: 0x18FD4D0 VA: 0x18FD4D0
	public void HFLNCEOIBJI()
	{
		if(KDJHLBCMMAG == HGIFGFEJLAB_StoryType.EKJGOMKEJLK_2_Scene/*2*/)
		{
			bool previousViewed = true;
			for(int i = 0; i < DHPMDOCLBGD.Count; i++)
			{
				DHPMDOCLBGD[i].GELLHOIEABC_PreviousViewed = previousViewed;
				previousViewed &= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(DHPMDOCLBGD[i].PBPOLELIPJI_Id);
			}
		}
	}

	//// RVA: 0x18FD6C4 Offset: 0x18FD6C4 VA: 0x18FD6C4
	private int CEAIGKOGLIN(GALFFONBIJG KCADLFGPNKH, GALFFONBIJG NEKKJMFOEDA)
	{
		int res = KCADLFGPNKH.BMCJDCOEJFH - NEKKJMFOEDA.BMCJDCOEJFH;
		if (res == 0)
			res = KCADLFGPNKH.PBPOLELIPJI_Id - NEKKJMFOEDA.PBPOLELIPJI_Id;
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
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DDEMMEPBOIA_Sns.EFIFBJGKPJF sns = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLHMJHBOBEA_Sns.HAJEJPFGILG[c.PBPOLELIPJI_Id - 1];
			sns.BEBJKJKBOGH_date = t;
			KHEKNNFCAOI_Init(MAIJBDCJPNJ__UniqueId);
			if(c.LIPNNILKOLH == 2)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NLOGLGKPMNI_ConsumeItem(1, c.GAGNJGMKPME_UnlockCost);
			}
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}
	}

	//// RVA: 0x18FCFF4 Offset: 0x18FCFF4 VA: 0x18FCFF4
	public bool NLKEJAFBDGC(int _PGIIDPEGGPI_EventId, int _PFGAKEDKOPD_UnlockCost)
	{
		int index = (_PGIIDPEGGPI_EventId % 1000000) - 1;
		MMPBPOIFDAF_Scene.PMKOFEIONEG scene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[index];
		MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[index];
		KODEHLPFHEG.KHEKNNFCAOI_Init(scene.PPFNGGCBJKC_id, scene.PDNIFBEGMHC_Mb, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_NumBoard, scene.IELENGDJPHF_Ulk, scene.MJBODMOLOBC_luck, scene.LHMOAJAIJCO_is_new, scene.BEBJKJKBOGH_date, scene.DMNIMMGGJJJ_Leaf);
		if(KODEHLPFHEG.FJODMPGPDDD_Unlocked)
		{
			if(dbScene.PPEGAKEIEGM_Enabled > 1)
			{
				if(KODEHLPFHEG.JKGFBFPIMGA_Rarity > 5)
				{
					if(KODEHLPFHEG.FGMPFHOEPEL_GetNumUnlockedStory() != 0)
					{
						if (_PFGAKEDKOPD_UnlockCost <= KODEHLPFHEG.FGMPFHOEPEL_GetNumUnlockedStory())
							return true;
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x18FDB94 Offset: 0x18FDB94 VA: 0x18FDB94
	//public void JFNJCPBONBN(KNKDBNFMAKF_EventSp LIKDEHHKFEH, int _KDGJBBFKLGI_Chapter, bool _OAFPGJLCNFM_cond) { }
}
