
using System;
using System.Collections.Generic;
using XeSys;

public class OLLAFCBLMIJ
{
    public class KAAHBIABMBC
    {
        public int ECDKPAIEFFA_DayId; // 0x8
        public int KLCMKLPIDDJ; // 0xC
        public int BAOFEFFADPD; // 0x10
        public bool CDMGDFLPPHN_HasStamp; // 0x14
        public bool IADNLGMIHDK_IsStarted; // 0x15
        public bool CKJPGFCCPIL_IsEnded; // 0x16

        // // RVA: 0xCAB080 Offset: 0xCAB080 VA: 0xCAB080
        public bool OJDNGPNOMDE()
        {
            return IADNLGMIHDK_IsStarted && !CDMGDFLPPHN_HasStamp;
        }
    }

	public List<KAAHBIABMBC> CKPIHCGOEDP = new List<KAAHBIABMBC>(); // 0x8
	public int EKANGPODCEP_EventId; // 0xC
	public string MLIMPBOKIAM_EntryUrl = ""; // 0x10
	public string MIKNPHMPNII_PrizeTemplate = ""; // 0x14
	public string DLPGGMOLFHA_KiyakuTemplate = ""; // 0x18
	public DateTime HGGFIEELABK_Start; // 0x20
	public DateTime KHNIJBEPHPL_End1; // 0x28
	public DateTime KOHDMPJHOBB; // 0x30
	public DateTime IHPPGMJOJIE; // 0x38
	public bool NDAMKMGINBM_CanEntryToday; // 0x40
	public int KGEKPADNGDM_CurrentDay; // 0x44

	// RVA: 0x14AE2D8 Offset: 0x14AE2D8 VA: 0x14AE2D8
	public void KHEKNNFCAOI()
    {
        CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase GHPLINIACBB) =>
        {
            //0xCAAECC
            return GHPLINIACBB.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign;
        }) as CANAFALMGLI_EventPresentCampaign;
        CKPIHCGOEDP.Clear();
        KGEKPADNGDM_CurrentDay = 0;
        if(ev == null)
        {
            for(int i = 0; i < 7; i++)
            {
                KAAHBIABMBC d = new KAAHBIABMBC();
                d.ECDKPAIEFFA_DayId = i + 1;
                d.KLCMKLPIDDJ = 1;
                d.BAOFEFFADPD = i + 19;
                d.CDMGDFLPPHN_HasStamp = false;
                d.IADNLGMIHDK_IsStarted = false;
                CKPIHCGOEDP.Add(d);
            }
            EKANGPODCEP_EventId = 9001;
            MLIMPBOKIAM_EntryUrl = "";
            MIKNPHMPNII_PrizeTemplate = "";
            HGGFIEELABK_Start = Utility.GetLocalDateTime(0);
            KHNIJBEPHPL_End1 = Utility.GetLocalDateTime(0);
            KOHDMPJHOBB = Utility.GetLocalDateTime(0);
            IHPPGMJOJIE = Utility.GetLocalDateTime(0);
        }
        else
        {
            HIADOIECMFP_EventPresentCampaign h = ev.PFNALBDHBLE();
            for(int i = 0; i < h.EENHCEEKBBD.Count; i++)
            {
                KAAHBIABMBC d = new KAAHBIABMBC();
                d.ECDKPAIEFFA_DayId = i + 1;
                d.KLCMKLPIDDJ = h.EENHCEEKBBD[i].KLCMKLPIDDJ;
                d.BAOFEFFADPD = h.EENHCEEKBBD[i].BAOFEFFADPD;
                d.CDMGDFLPPHN_HasStamp = ev.CKFNILGAOBK(d.ECDKPAIEFFA_DayId);
                int a = ev.PLDDGDNLCAA(d.ECDKPAIEFFA_DayId);
                d.CKJPGFCCPIL_IsEnded = (a & 8) != 0;
                d.IADNLGMIHDK_IsStarted = (a & 4) != 0;
                if(d.IADNLGMIHDK_IsStarted)
                    KGEKPADNGDM_CurrentDay = d.ECDKPAIEFFA_DayId;
                CKPIHCGOEDP.Add(d);
            }
            EKANGPODCEP_EventId = ev.PGIIDPEGGPI_EventId;
            MLIMPBOKIAM_EntryUrl = ev.MAICAKMIBEM("entry_url", "");
            MIKNPHMPNII_PrizeTemplate = ev.MAICAKMIBEM("prize_template", "");
            DLPGGMOLFHA_KiyakuTemplate = ev.MAICAKMIBEM("kiyaku_template", "");
            HGGFIEELABK_Start = Utility.GetLocalDateTime(ev.GLIMIGNNGGB_Start);
            KHNIJBEPHPL_End1 = Utility.GetLocalDateTime(ev.DPJCPDKALGI_End1);
            KOHDMPJHOBB = Utility.GetLocalDateTime(ev.JDDFILGNGFH);
            IHPPGMJOJIE = Utility.GetLocalDateTime(ev.LJOHLEGGGMC);
            long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
            NDAMKMGINBM_CanEntryToday = false;
            if(t >= ev.GLIMIGNNGGB_Start && ev.DPJCPDKALGI_End1 >= t && KGEKPADNGDM_CurrentDay != 0)
            {
                if(!CKPIHCGOEDP[KGEKPADNGDM_CurrentDay - 1].CDMGDFLPPHN_HasStamp)
                    NDAMKMGINBM_CanEntryToday = true;
            }
        }
    }

	// // RVA: 0x14AEC7C Offset: 0x14AEC7C VA: 0x14AEC7C
	public KAAHBIABMBC DHNCPKGDEFL()
    {
        return CKPIHCGOEDP.Find((KAAHBIABMBC GHPLINIACBB) =>
        {
            //0xCAAF10
            return GHPLINIACBB.IADNLGMIHDK_IsStarted;
        });
    }

	// // RVA: 0x14AEDD4 Offset: 0x14AEDD4 VA: 0x14AEDD4
	public void MFEGLKEAPLA(int ECDKPAIEFFA, IMCBBOAFION CFHALLLJAOP, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
    {
        if(ECDKPAIEFFA > 0)
        {
            if(ECDKPAIEFFA <= CKPIHCGOEDP.Count)
            {
                if(CKPIHCGOEDP[ECDKPAIEFFA - 1].OJDNGPNOMDE())
                {
                    CANAFALMGLI_EventPresentCampaign ev/*MOHDLLIJELH*/ = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase GHPLINIACBB) =>
                    {
                        //0xCAAF34
                        return GHPLINIACBB.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign;
                    }) as CANAFALMGLI_EventPresentCampaign;
                    if(ev != null)
                    {
                        if((ev.PLDDGDNLCAA(ECDKPAIEFFA) & 4) == 0)
                        {
                            NIMPEHIECJH();
                        }
                        else
                        {
                            if(!ev.CKFNILGAOBK(ECDKPAIEFFA))
                            {
                                ev.KJLFPCHDFAD(ECDKPAIEFFA);
                                CKPIHCGOEDP[ECDKPAIEFFA - 1].CDMGDFLPPHN_HasStamp = true;
                                CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
                                {
                                    //0xCAAF88
                                    ILCCJNDFFOB.HHCJCDFCLOB.CDNFJBAJAMM(ev, ECDKPAIEFFA);
                                    CFHALLLJAOP();
                                }, AOCANKOMKFG, null);
                            }
                        }
                        return;
                    }
                }
            }
        }
        NIMPEHIECJH();
    }

	// // RVA: 0x14AF414 Offset: 0x14AF414 VA: 0x14AF414
	// public int HPABGDEINHO() { }

	// // RVA: 0x14AF4F4 Offset: 0x14AF4F4 VA: 0x14AF4F4
	// public int JDOIEMPHABL() { }
}
