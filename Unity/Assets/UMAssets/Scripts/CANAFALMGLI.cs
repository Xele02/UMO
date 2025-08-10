
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Obsolete("Use CANAFALMGLI_EventPresentCampaign", true)]
public class CANAFALMGLI { }
public class CANAFALMGLI_EventPresentCampaign : IKDICBBFBMI_EventBase
{
	public static bool BIMJBABOKDN = false; // 0x0
	public static bool NNJBFKKDLBC = false; // 0x1
	public static bool EEKLHDFELLB = false; // 0x2
	public static bool LBLLNABBEPI = false; // 0x3
	public static string INBEMNCFEJP = ""; // 0x4
	public List<int> AILDCKKOLJG = new List<int>(); // 0xE8

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign; } }// 0x18F4084 DKHCGLCNKCD  Slot: 4

	// RVA: 0x18F408C Offset: 0x18F408C VA: 0x18F408C
	public CANAFALMGLI_EventPresentCampaign(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// RVA: 0x18F414C Offset: 0x18F414C VA: 0x18F414C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0x18F4158 Offset: 0x18F4158 VA: 0x18F4158
	public HIADOIECMFP_EventPresentCampaign PFNALBDHBLE()
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
	}

	// // RVA: 0x18F42C8 Offset: 0x18F42C8 VA: 0x18F42C8 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		HIADOIECMFP_EventPresentCampaign db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(db != null)
		{
            GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(db.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				return JHNMKKNEENE >= db.NGHKJOEDLIP.BONDDBOFBND_Start && db.NGHKJOEDLIP.KNLGKBBIBOH_End >= JHNMKKNEENE;
			}
        }
		return false;
	}

	// // RVA: 0x18F44D4 Offset: 0x18F44D4 VA: 0x18F44D4 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(evDb.NGHKJOEDLIP.OCGFKMHNEOF != CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.LJNAKDMILMC_key)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.KMBPACJNEOF();
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.LJNAKDMILMC_key = evDb.NGHKJOEDLIP.OCGFKMHNEOF;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x18F471C Offset: 0x18F471C VA: 0x18F471C Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			IBNKPMPFLGI_IsRankReward = false;
			DGCOMDILAKM_EventName = evDb.NGHKJOEDLIP.OPFGFINHFCE_Name;
			DOLJEDAAKNN_RankingName = "";
			GLIMIGNNGGB_RankingStart = evDb.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_RankingEnd = evDb.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO_RankingEnd2 = evDb.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH_RewardStart = evDb.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC_RewardEnd = evDb.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_RewardEnd2 = evDb.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = evDb.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			PBHNFNIHDJJ = evDb.NGHKJOEDLIP.HFNIHKOAMGC;
			NHGPCLGPEHH_TicketType = evDb.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			GFIBLLLHMPD_StartAdventureId = evDb.NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			CAKEOPLJDAF_EndAdventureId = evDb.NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			GPHEKCNDDIK = false;
		}
	}

	// // RVA: 0x18F4AE0 Offset: 0x18F4AE0 VA: 0x18F4AE0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		KGCNCBOKCBA.GNENJEHKMHD_EventStatus st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			if(JHNMKKNEENE >= evDb.NGHKJOEDLIP.BONDDBOFBND_Start)
			{
				st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
				if(evDb.NGHKJOEDLIP.HPNOGLIFJOP_End1 < JHNMKKNEENE)
				{
					st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
					if(evDb.NGHKJOEDLIP.JGMDAOACOJF < JHNMKKNEENE)
					{
						if(evDb.NGHKJOEDLIP.IDDBFFBPNGI < JHNMKKNEENE)
						{
							return;
						}
						st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.LNACKEBEMOB_Received == 0)
							st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
					}
				}
			}
		}
		NGOFCFJHOMI_Status = st;
	}

	// // RVA: 0x18F4D50 Offset: 0x18F4D50 VA: 0x18F4D50 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			return evDb.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x18F4ED0 Offset: 0x18F4ED0 VA: 0x18F4ED0 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			return evDb.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x18F5050 Offset: 0x18F5050 VA: 0x18F5050
	public int PLDDGDNLCAA(int DCALLPABDAI)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(DCALLPABDAI == 0)
				return 0;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			/*int a = 0;
			for(int i = 0; i < evDb.EENHCEEKBBD.Count; i++)
			{
				a = i;
				if(t >= evDb.EENHCEEKBBD[i].FKPEAGGKNLC || evDb.EENHCEEKBBD[i].KOMKKBDABJP >= t)
				{
					break;
				}
			}*/
			HIADOIECMFP_EventPresentCampaign.DFPGOAOKPBI BAOFEFFADPD = evDb.EENHCEEKBBD[DCALLPABDAI - 1];
			int c = 0;
			if(t >= BAOFEFFADPD.FKPEAGGKNLC)
				c = 4;
			if(BAOFEFFADPD.KOMKKBDABJP < t)
				c = 8;
			//LAB_018f5450
			int idx = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.HOFACDIBDLM().FindIndex((string GHPLINIACBB) =>
			{
				//0x18F6204
				return GHPLINIACBB == BAOFEFFADPD.LJNAKDMILMC;
			});
			if(idx > -1)
			{
				c |= 2;
			}
			return c;
		}
		return 0;
	}

	// // RVA: 0x18F554C Offset: 0x18F554C VA: 0x18F554C
	public bool CKFNILGAOBK(int DCALLPABDAI)
	{
		return (PLDDGDNLCAA(DCALLPABDAI) & 2) != 0;
	}

	// // RVA: 0x18F5560 Offset: 0x18F5560 VA: 0x18F5560
	public void KJLFPCHDFAD(int DCALLPABDAI)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(DCALLPABDAI != 0)
			{
                HIADOIECMFP_EventPresentCampaign.DFPGOAOKPBI BAOFEFFADPD = evDb.EENHCEEKBBD[DCALLPABDAI - 1];
                List<string> ls = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.HOFACDIBDLM();
				int idx = ls.FindIndex((string GHPLINIACBB) =>
				{
					//0x18F6238
					return GHPLINIACBB == BAOFEFFADPD.LJNAKDMILMC;
				});
				if(idx < 0)
				{
					ls.Add(BAOFEFFADPD.LJNAKDMILMC);
					ls.Sort((string HKICMNAACDA, string BNKHBCBJBKI) =>
					{
						//0x18F61B4
						return HKICMNAACDA.CompareTo(BNKHBCBJBKI);
					});
					StringBuilder str = new StringBuilder();
					bool b = false;
					for(int i = 0; i < ls.Count; i++)
					{
						if(ls[i] != "")
						{
							if(b)
								str.Append(",");
							str.Append(ls[i]);
							b = true;
						}
					}
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.EBAMGNMELPO_EntryDate = str.ToString();
				}
			}
		}
	}

	// // RVA: 0x18F5B20 Offset: 0x18F5B20 VA: 0x18F5B20
	public void EAFPHEGFODB(IMCBBOAFION DFPIPMPJOEB, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK AOCANKOMKFG) 
	{
		N.a.StartCoroutineWatched(AOAGAPFDLBJ_Co_ReceivePresent(DFPIPMPJOEB, ECOPDHBJEEK, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCFE4 Offset: 0x6BCFE4 VA: 0x6BCFE4
	// // RVA: 0x18F5B88 Offset: 0x18F5B88 VA: 0x18F5B88
	private IEnumerator AOAGAPFDLBJ_Co_ReceivePresent(IMCBBOAFION DFPIPMPJOEB, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK AOCANKOMKFG)
	{
		HIADOIECMFP_EventPresentCampaign KHGBJCFJGMA; // 0x28
		FLONELKGABJ_ClaimAchievementPrizes DLOIHKKKNBB; // 0x2C

		//0x18F6B4C
		KHGBJCFJGMA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as HIADOIECMFP_EventPresentCampaign;
		if(KHGBJCFJGMA != null)
		{
            GGHPEFNADEN_Ticket NHLBKJCPLBL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket;
			if(NHLBKJCPLBL.LNACKEBEMOB_Received == 1)
			{
				Debug.Log("StringLiteral_9701");
			}
			else
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if((RuntimeSettings.CurrentSettings.UnlimitedEvent && NHLBKJCPLBL.EBAMGNMELPO_EntryDate != "") || (t >= JDDFILGNGFH_RewardStart && LJOHLEGGGMC_RewardEnd >= t))
				{
					if(string.IsNullOrEmpty(NHLBKJCPLBL.OEDIICBDNKG_Pending))
					{
						int NMOLAEAFDNK = 0;
						N.a.StartCoroutineWatched(CIEMBLDFAIE_Co_ReceiveInventory(() =>
						{
							//0x18F63A0
							NMOLAEAFDNK = 1;
						}, () =>
						{
							//0x18F63AC
							NMOLAEAFDNK = 2;
						}, () =>
						{
							//0x18F63B8
							NMOLAEAFDNK = 3;
						}));
						//LAB_018f6e08
						while(NMOLAEAFDNK == 0)
						{
							yield return null;
						}
						if(NMOLAEAFDNK == 2)
						{
							ECOPDHBJEEK();
							yield break;
						}
						if(NMOLAEAFDNK == 3)
						{
							AOCANKOMKFG();
							yield break;
						}
					}
					//LAB_018f75b8
					AILDCKKOLJG = FKCNKNOEMLK(NHLBKJCPLBL.OEDIICBDNKG_Pending);
					List<int> l = new List<int>(KHGBJCFJGMA.OBPOHDENMHH.Count);
					for(int i = 0; i < KHGBJCFJGMA.OBPOHDENMHH.Count; i++)
					{
						l.Add(0);
					}
					List<string> ls = new List<string>();
					for(int i = 0; i < AILDCKKOLJG.Count; i++)
					{
						if(AILDCKKOLJG[i] > 0)
						{
							if(AILDCKKOLJG[i] <= KHGBJCFJGMA.OBPOHDENMHH.Count)
							{
								string s = KHGBJCFJGMA.OBPOHDENMHH[AILDCKKOLJG[i] - 1].MCNPILDHLEE;
								if(!string.IsNullOrEmpty(s))
								{
									ls.Add(s + l[AILDCKKOLJG[i] - 1].ToString());
								}
								s = KHGBJCFJGMA.OBPOHDENMHH[AILDCKKOLJG[i] - 1].OJHJLJLCKAC;
								if(!string.IsNullOrEmpty(s))
								{
									ls.Add(s + l[AILDCKKOLJG[i] - 1].ToString());
								}
								l[AILDCKKOLJG[i] - 1]++;
							}
						}
					}
					if(ls.Count != 0)
					{
						DLOIHKKKNBB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						DLOIHKKKNBB.MIDAMHNABAJ_Keys = ls;
						DLOIHKKKNBB.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
						{
							//0x18F61E8
							return LJJGBICGLLF == SakashoErrorId.KEYS_NOT_FOUND || LJJGBICGLLF == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED;
						};
						//LAB_018f6e70
						while(!DLOIHKKKNBB.PLOOEECNHFB_IsDone)
							yield return null;
						if(DLOIHKKKNBB.NPNNPNAIONN_IsError)
						{
							if(DLOIHKKKNBB.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								NHLBKJCPLBL.LNACKEBEMOB_Received = 1;
								NHLBKJCPLBL.HBODCMLFDOB_Result = NHLBKJCPLBL.OEDIICBDNKG_Pending;
								Debug.Log("StringLiteral_9704");
								CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(DFPIPMPJOEB, AOCANKOMKFG, null);
								yield break;
							}
						}
						if(DLOIHKKKNBB.NPNNPNAIONN_IsError)
						{
							if(DLOIHKKKNBB.CJMFJOMECKI_ErrorId == SakashoErrorId.KEYS_NOT_FOUND)
							{
								Debug.Log("StringLiteral_9703");
								ECOPDHBJEEK();
								yield break;
							}
						}
						if(!DLOIHKKKNBB.NPNNPNAIONN_IsError)
						{
							Debug.Log("StringLiteral_9706" + NHLBKJCPLBL.OEDIICBDNKG_Pending);
							NHLBKJCPLBL.LNACKEBEMOB_Received = 1;
							NHLBKJCPLBL.HBODCMLFDOB_Result = NHLBKJCPLBL.OEDIICBDNKG_Pending;
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x18F6274
								ILCCJNDFFOB.HHCJCDFCLOB.BLDDKDNOCFA(this, NHLBKJCPLBL.EBAMGNMELPO_EntryDate, NHLBKJCPLBL.HBODCMLFDOB_Result);
								DFPIPMPJOEB();
							}, AOCANKOMKFG, null);
							yield break;
						}
						Debug.Log("StringLiteral_9705");
						AOCANKOMKFG();
						yield break;
					}
					else
						Debug.Log("StringLiteral_9703");
				}
				else
					Debug.Log("StringLiteral_9702");
			}
			//LAB_018f7c90
			ECOPDHBJEEK();
        }
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD05C Offset: 0x6BD05C VA: 0x6BD05C
	// // RVA: 0x18F5C80 Offset: 0x18F5C80 VA: 0x18F5C80
	private IEnumerator CIEMBLDFAIE_Co_ReceiveInventory(IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK AOCANKOMKFG)
	{
		GGHPEFNADEN_Ticket NGHLIKFIIGI; // 0x20
		ELNKLCNHDEE NPMOILPJMMP; // 0x24

		//0x18F63C8
		NGHLIKFIIGI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket;
		NPMOILPJMMP = new ELNKLCNHDEE();
		NPMOILPJMMP.HBOKJNECOPA(MAICAKMIBEM("trigger_item_name", "trigger_item"));
		while(!NPMOILPJMMP.PLOOEECNHFB)
			yield return null;
		if(NPMOILPJMMP.NPNNPNAIONN)
		{
			Debug.Log("StringLiteral_9697");
			AOCANKOMKFG();
		}
		else
		{
			if(!NPMOILPJMMP.GBCOABCAJHG)
			{
				if(NPMOILPJMMP.AILDCKKOLJG == null)
				{
					Debug.Log("StringLiteral_9700");
					//LAB_018f6a1c
					ECOPDHBJEEK();
				}
				else
				{
					StringBuilder str = new StringBuilder();
					bool b = false;
					for(int i = 0; i < NPMOILPJMMP.AILDCKKOLJG.Count; i++)
					{
						if(b)
							str.Append(',');
						str.Append(NPMOILPJMMP.AILDCKKOLJG[i].DNJEJEANJGL_Value);
						b = true;
					}
					NGHLIKFIIGI.OEDIICBDNKG_Pending = str.ToString();
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(BHFHGFKBOHH, AOCANKOMKFG, NPMOILPJMMP.HBINEKIILJL);
				}
			}
			else
			{
				if(!string.IsNullOrEmpty(NGHLIKFIIGI.EBAMGNMELPO_EntryDate))
				{
					Debug.Log("StringLiteral_9699");
					ECOPDHBJEEK();
				}
				else
				{
					NGHLIKFIIGI.LNACKEBEMOB_Received = 1;
					NGHLIKFIIGI.HBODCMLFDOB_Result = "";
					Debug.Log("StringLiteral_9698");
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(ECOPDHBJEEK, AOCANKOMKFG, null);
				}
			}
		}
	}

	// // RVA: 0x18F5D78 Offset: 0x18F5D78 VA: 0x18F5D78
	private static List<int> FKCNKNOEMLK(string IDLHJIOMJBK)
	{
		List<int> res = new List<int>();
		string[] strs = IDLHJIOMJBK.Split(new char[]{','});
		for(int i = 0; i < strs.Length; i++)
		{
			int v;
			if(int.TryParse(strs[i], out v))
			{
				res.Add(v);
			}
		}
		return res;
	}

	// // RVA: 0x18F5FB4 Offset: 0x18F5FB4 VA: 0x18F5FB4
	public string JFHOMINJHJK()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.CNCBDLFALLD_Ticket.EBAMGNMELPO_EntryDate;
	}
}
