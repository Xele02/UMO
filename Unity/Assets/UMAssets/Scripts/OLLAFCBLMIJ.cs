
using System;
using System.Collections.Generic;
using XeSys;

public class OLLAFCBLMIJ
{
    public class KAAHBIABMBC
    {
        public int ECDKPAIEFFA_DayId; // 0x8
        public int KLCMKLPIDDJ_Month; // 0xC
        public int BAOFEFFADPD_day; // 0x10
        public bool CDMGDFLPPHN_entry; // 0x14
        public bool IADNLGMIHDK_IsStarted; // 0x15
        public bool CKJPGFCCPIL_IsEnded; // 0x16

        // // RVA: 0xCAB080 Offset: 0xCAB080 VA: 0xCAB080
        public bool OJDNGPNOMDE()
        {
            return IADNLGMIHDK_IsStarted && !CDMGDFLPPHN_entry;
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
	public void KHEKNNFCAOI_Init()
    {
        CANAFALMGLI_EventPresentCampaign ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase _GHPLINIACBB_x) =>
        {
            //0xCAAECC
            return _GHPLINIACBB_x.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign;
        }) as CANAFALMGLI_EventPresentCampaign;
        CKPIHCGOEDP.Clear();
        KGEKPADNGDM_CurrentDay = 0;
        if(ev == null)
        {
            for(int i = 0; i < 7; i++)
            {
                KAAHBIABMBC d = new KAAHBIABMBC();
                d.ECDKPAIEFFA_DayId = i + 1;
                d.KLCMKLPIDDJ_Month = 1;
                d.BAOFEFFADPD_day = i + 19;
                d.CDMGDFLPPHN_entry = false;
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
                d.KLCMKLPIDDJ_Month = h.EENHCEEKBBD[i].KLCMKLPIDDJ_Month;
                d.BAOFEFFADPD_day = h.EENHCEEKBBD[i].BAOFEFFADPD_day;
                d.CDMGDFLPPHN_entry = ev.CKFNILGAOBK(d.ECDKPAIEFFA_DayId);
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
            HGGFIEELABK_Start = Utility.GetLocalDateTime(ev.GLIMIGNNGGB_RankingStart);
            KHNIJBEPHPL_End1 = Utility.GetLocalDateTime(ev.DPJCPDKALGI_RankingEnd);
            KOHDMPJHOBB = Utility.GetLocalDateTime(ev.JDDFILGNGFH_RewardStart);
            IHPPGMJOJIE = Utility.GetLocalDateTime(ev.LJOHLEGGGMC_RewardEnd);
            long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
            NDAMKMGINBM_CanEntryToday = false;
            if(t >= ev.GLIMIGNNGGB_RankingStart && ev.DPJCPDKALGI_RankingEnd >= t && KGEKPADNGDM_CurrentDay != 0)
            {
                if(!CKPIHCGOEDP[KGEKPADNGDM_CurrentDay - 1].CDMGDFLPPHN_entry)
                    NDAMKMGINBM_CanEntryToday = true;
            }
        }
    }

	// // RVA: 0x14AEC7C Offset: 0x14AEC7C VA: 0x14AEC7C
	public KAAHBIABMBC DHNCPKGDEFL()
    {
        return CKPIHCGOEDP.Find((KAAHBIABMBC _GHPLINIACBB_x) =>
        {
            //0xCAAF10
            return _GHPLINIACBB_x.IADNLGMIHDK_IsStarted;
        });
    }

	// // RVA: 0x14AEDD4 Offset: 0x14AEDD4 VA: 0x14AEDD4
	public void MFEGLKEAPLA(int _ECDKPAIEFFA_DayId, IMCBBOAFION CFHALLLJAOP, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
    {
        if(_ECDKPAIEFFA_DayId > 0)
        {
            if(_ECDKPAIEFFA_DayId <= CKPIHCGOEDP.Count)
            {
                if(CKPIHCGOEDP[_ECDKPAIEFFA_DayId - 1].OJDNGPNOMDE())
                {
                    CANAFALMGLI_EventPresentCampaign ev/*MOHDLLIJELH_cont*/ = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase _GHPLINIACBB_x) =>
                    {
                        //0xCAAF34
                        return _GHPLINIACBB_x.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign;
                    }) as CANAFALMGLI_EventPresentCampaign;
                    if(ev != null)
                    {
                        if((ev.PLDDGDNLCAA(_ECDKPAIEFFA_DayId) & 4) == 0)
                        {
                            NIMPEHIECJH();
                        }
                        else
                        {
                            if(!ev.CKFNILGAOBK(_ECDKPAIEFFA_DayId))
                            {
                                ev.KJLFPCHDFAD(_ECDKPAIEFFA_DayId);
                                CKPIHCGOEDP[_ECDKPAIEFFA_DayId - 1].CDMGDFLPPHN_entry = true;
                                CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
                                {
                                    //0xCAAF88
                                    ILCCJNDFFOB.HHCJCDFCLOB.CDNFJBAJAMM(ev, _ECDKPAIEFFA_DayId);
                                    CFHALLLJAOP();
                                }, _AOCANKOMKFG_OnError, null);
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
