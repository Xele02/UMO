using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class DFHCLGPLJCP { }
public class DFHCLGPLJCP_Rules
{
	public Regex FPEEJDLMOJB_FileRegex { get; private set; } // 0x8 KGCPPEAFJFC JNDAHPAODAB EAFPHJKJHPD
	public string IOMHINDAFOH_File { get; private set; } // 0xC HFKJBIDDJHL EIAEEOGCIMA MMFKGDDAIDG
	public int KPNKPGLPDHI_Op { get; private set; } // 0x10 OLDMILDBDME EDAJJEJELHN HLIEKAOJIGI
	public int PAAPNEMBHGN_Day { get; private set; } // 0x14 BFBNPHPDOCP LGLMKGLDFME BGNMBMCHOCF
	// public bool EGELJDAGHPP { get; } 0x197E46C ELPABIFMEMH
	// public bool AKHBHEFFNJC { get; } 0x197E478 BMDCOINKDMC
	// public bool OHIOIDCLIEO { get; } 0x197E484 BIGDBDKMGED
	// public bool BMEHOMDBEIH { get; } 0x197E490 IMICNGNNIME
	// public bool OEACGDAKMMB { get; } 0x197E49C NFPLGHKIAFI
	// public bool BEIECJDELHK { get; } 0x197E4A8 JNAPPKBMEHJ
	public bool PEOIMDCECDL { get { return ((KPNKPGLPDHI_Op >> 6) & 1) != 0; } } //0x197E4B4 ANNFICFGPIK
	// public bool EELHAIGHFAC { get; } 0x197E4C0 MBPJOOPLGBK
	// public bool NGPLFEMNNPP { get; } 0x197E4CC NHIFINDFAJF
	// public bool NIPNNJBPBFL { get; } 0x197E4D8 NNECCEFDGMB
	// public bool ALKDIKCBKDC { get; } 0x197E4E4 IAHFHFALMDB
	// public bool ABKMOFPEHEF { get; } 0x197E4F0 DHMLEGIECEC
	// public bool PNKPHBHMLNM { get; } 0x197E4FC COJEDBKBBHK

	// // RVA: 0x197E508 Offset: 0x197E508 VA: 0x197E508
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0x197E550 Offset: 0x197E550 VA: 0x197E550
	// public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }

	// // RVA: 0x197E6FC Offset: 0x197E6FC VA: 0x197E6FC
	public void KHEKNNFCAOI(BJALOLHCBKC NKGJOAEDCPH)
	{
		IOMHINDAFOH_File = NKGJOAEDCPH.MIMGPBHAJCO;
		PAAPNEMBHGN_Day = (int)NKGJOAEDCPH.BAOFEFFADPD;
		KPNKPGLPDHI_Op = (int)NKGJOAEDCPH.BEPIOAIFCEC;
		FPEEJDLMOJB_FileRegex = new Regex(IOMHINDAFOH_File);
	}
}

public class NLEFIGMHGCO { }
public class NLEFIGMHGCO_MVerList
{
	public string MIMGPBHAJCO_File { get; private set; } // 0x8 ICEMDJBNGJA JPMHJMDLFPI NLHKGLABKDI
	public int IJEKNCDIIAE_MVer { get; private set; } // 0xC FAHNCMHNFCG KJIMMIBDCIL DMEGNOKIKCD

	// // RVA: 0xC2E2D8 Offset: 0xC2E2D8 VA: 0xC2E2D8
	// public uint CAOGDCBPBAN() { }

	// // RVA: 0xC2E318 Offset: 0xC2E318 VA: 0xC2E318
	// public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }

	// // RVA: 0xC2E454 Offset: 0xC2E454 VA: 0xC2E454
	public void KHEKNNFCAOI(PFCNGLGHLJA IDLHJIOMJBK)
	{
		MIMGPBHAJCO_File = IDLHJIOMJBK.MIMGPBHAJCO;
		IJEKNCDIIAE_MVer = IDLHJIOMJBK.IJEKNCDIIAE;
	}
}

public class PKKHIEAEDPC
{
	public DFHCLGPLJCP_Rules NKGJOAEDCPH; // 0x8
	public Match MABBBOEAPAA_Match; // 0xC
	public int KKPAHLMJKIH_WavId; // 0x10
	public int EKANGPODCEP_EventId; // 0x14
	public int HHGMPEEGFMA_GachaId; // 0x18
	public int DIDOFBIHPMB_PickupId; // 0x1C
	public int INFIBMLIHLO_ItemId; // 0x20
	public string CJEKGLGBIHF; // 0x24
}


public class LFPJCEMANCK { }
public class LFPJCEMANCK_Asset : DIHHCBACKGG_DbSection
{
	public int[] OEEJIIIICCP; // 0x28
	public Dictionary<string, int> AJHAKFLPNHF = new Dictionary<string, int>(); // 0x2C
	public Dictionary<string, int> ALMGDPAGHMJ = new Dictionary<string, int>(); // 0x30

	public List<DFHCLGPLJCP_Rules> KCMFDGNNPIL_Rules { get; private set; } // 0x20 LOJMMLKKEEP JGCLPBFPPHI OBABGCHHDDH
	public List<NLEFIGMHGCO_MVerList> OAOOIDNBOGA_MVer_List { get; private set; } // 0x24 NPFKICOMNGC LKMOIDPNAPB JHMPDPDLAIN

	// // RVA: 0xD6D49C Offset: 0xD6D49C VA: 0xD6D49C
	public PKKHIEAEDPC NBHDIKJMLEN(string CJEKGLGBIHF_Filename)
    {
		if(KCMFDGNNPIL_Rules != null && KCMFDGNNPIL_Rules.Count > 0)
		{
			for(int i = 0; i < KCMFDGNNPIL_Rules.Count; i++)
			{
				Match match = KCMFDGNNPIL_Rules[i].FPEEJDLMOJB_FileRegex.Match(CJEKGLGBIHF_Filename);
				if (match.Success)
				{
					PKKHIEAEDPC data = new PKKHIEAEDPC();
					data.NKGJOAEDCPH = KCMFDGNNPIL_Rules[i];
					data.CJEKGLGBIHF = CJEKGLGBIHF_Filename;
					data.MABBBOEAPAA_Match = match;
					if(match.Groups.Count > 0)
					{
						if(match.Groups[AFEHLCGHAEE_Strings.IKOFFIOMOME_wav/*wav*/].Value != "")
						{
							int wavId = 0;
							if(Int32.TryParse(match.Groups[AFEHLCGHAEE_Strings.IKOFFIOMOME_wav/*wav*/].Value, out wavId))
							{
								data.KKPAHLMJKIH_WavId = wavId;
							}
						}
						if(match.Groups[AFEHLCGHAEE_Strings.JJCJCOANHBL_event/*event*/].Value != "")
						{
							int eventId = 0;
							if(Int32.TryParse(match.Groups[AFEHLCGHAEE_Strings.JJCJCOANHBL_event/*event*/].Value, out eventId))
							{
								data.EKANGPODCEP_EventId = eventId;
							}
						}
						if(match.Groups["gacha"].Value != "")
						{
							int gachaId = 0;
							if(Int32.TryParse(match.Groups["gacha"].Value, out gachaId))
							{
								data.HHGMPEEGFMA_GachaId = gachaId;
							}
						}
						if(match.Groups["pickup"].Value != "")
						{
							int pickupId = 0;
							if (Int32.TryParse(match.Groups["pickup"].Value, out pickupId))
							{
								data.DIDOFBIHPMB_PickupId = pickupId;
							}
						}
						if (match.Groups["itemid"].Value != "")
						{
							int itemId = 0;
							if (match.Groups["itemid"].Value.Contains("40000_"))
								data.INFIBMLIHLO_ItemId = 40000;
							else if (Int32.TryParse(match.Groups["itemid"].Value, out itemId))
							{
								data.INFIBMLIHLO_ItemId = itemId;
							}
						}
					}
					if (!data.NKGJOAEDCPH.PEOIMDCECDL)
						return data;
					if (OEEJIIIICCP == null)
						return data;
					for(int j = 0; j < OEEJIIIICCP.Length; j++)
					{
						if (OEEJIIIICCP[j] == data.KKPAHLMJKIH_WavId)
							return data;
					}
				}
			}
		}
        return null;
    }

	// // RVA: 0xD6E12C Offset: 0xD6E12C VA: 0xD6E12C
	public int MCHKDCGEAOB()
	{
		for(int i = 0; i < KCMFDGNNPIL_Rules.Count; i++)
		{
			if(KCMFDGNNPIL_Rules[i].PEOIMDCECDL)
			{
				return KCMFDGNNPIL_Rules[i].PAAPNEMBHGN_Day;
			}
		}
		return 1;
	}

	// RVA: 0xD6E270 Offset: 0xD6E270 VA: 0xD6E270
	public LFPJCEMANCK_Asset()
    {
        JIKKNHIAEKG_BlockName = "";
        LNIMEIMBCMF = false;
        KCMFDGNNPIL_Rules = new List<DFHCLGPLJCP_Rules>(100);
        LMHMIIKCGPE = 5;
        OAOOIDNBOGA_MVer_List = new List<NLEFIGMHGCO_MVerList>();
    }

	// // RVA: 0xD6E3E8 Offset: 0xD6E3E8 VA: 0xD6E3E8 Slot: 8
	protected override void KMBPACJNEOF()
    {
		KCMFDGNNPIL_Rules.Clear();
		OAOOIDNBOGA_MVer_List.Clear();
		AJHAKFLPNHF.Clear();
		ALMGDPAGHMJ.Clear();
	}

	// // RVA: 0xD6E4E4 Offset: 0xD6E4E4 VA: 0xD6E4E4 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		CPHIOGHFPKN parser = CPHIOGHFPKN.HEGEKFMJNCC(DBBGALAPFGC);
		NNDMLKDMALA(parser);
		MCIFBBDDPID(parser);
		OEEJIIIICCP = parser.KLDHBJPDAFG;
		{
			string[] array = parser.DNGKHGLIGKJ;
			for(int i = 0; i < array.Length; i++)
			{
				if(array[i][0] == '/')
				{
					AJHAKFLPNHF.Add("/android"+ array[i], i);
				}
				else
				{
					AJHAKFLPNHF.Add("/android" + "/" + array[i], i);
				}
			}
		}
		{
			string[] array = parser.AMBODKHPHFH;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i][0] == '/')
				{
					ALMGDPAGHMJ.Add("/android" + array[i], i);
				}
				else
				{
					ALMGDPAGHMJ.Add("/android" + "/" + array[i], i);
				}
			}
		}
        return true;
    }

	// // RVA: 0xD6EB28 Offset: 0xD6EB28 VA: 0xD6EB28 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
    {
        TodoLogger.Log(100, "TODO");
        return true;
    }

	// // RVA: 0xD6EB58 Offset: 0xD6EB58 VA: 0xD6EB58
	// private bool NNDMLKDMALA(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0xD6E848 Offset: 0xD6E848 VA: 0xD6E848
	private bool NNDMLKDMALA(CPHIOGHFPKN COBJEGDKDJA)
	{
		{
			BJALOLHCBKC[] array = COBJEGDKDJA.IPHMDEOOFAI;
			for(int i = 0; i < array.Length; i++)
			{
				DFHCLGPLJCP_Rules data = new DFHCLGPLJCP_Rules();
				data.KHEKNNFCAOI(array[i]);
				KCMFDGNNPIL_Rules.Add(data);
			}
		}
		return true;
	}

	// // RVA: 0xD6ED84 Offset: 0xD6ED84 VA: 0xD6ED84
	// private bool MCIFBBDDPID(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0xD6E9B8 Offset: 0xD6E9B8 VA: 0xD6E9B8
	private bool MCIFBBDDPID(CPHIOGHFPKN COBJEGDKDJA)
	{
		PFCNGLGHLJA[] array = COBJEGDKDJA.DOGNLEPGCIK;
		for(int i = 0; i < array.Length; i++)
		{
			NLEFIGMHGCO_MVerList data = new NLEFIGMHGCO_MVerList();
			data.KHEKNNFCAOI(array[i]);
			OAOOIDNBOGA_MVer_List.Add(data);
		}
		return true;
	}

	// // RVA: 0xD6EFB0 Offset: 0xD6EFB0 VA: 0xD6EFB0 Slot: 11
	public override uint CAOGDCBPBAN()
    {
        TodoLogger.Log(100, "TODO");
        return 0;
    }
}
