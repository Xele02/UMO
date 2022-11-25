using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

public class EAJCBFGKKFA
{
	public FFHPBEPOMAK JIGONEMPPNP; // 0x8
	public GCIJNCFDNON AFBMEMCHJCL; // 0xC
	public EEMGHIINEHN.OPANFJDIEGH MGMFOJPNDGA; // 0x10
	public List<GCIJNCFDNON> HDJOHAJPGBA; // 0x14
	public IBIGBMDANNM PCEGKKLKFNO; // 0x18
	public IAPDFOPPGND NDOLELKAJNL; // 0x1C
	public IBIGBMDANNM.LJJOIIAEICI PDIPANKOKOL; // 0x20
	public string LBODHBDOMGK; // 0x24
	public string FGMPKKOOGCM; // 0x28
	public string FAABJIHJKEM; // 0x2C
	public int ILOJAJNCPEC_Rank; // 0x30
	public int MLPEHNBNOGD; // 0x34
	public int KDHCKDHIHIP; // 0x38
	public int LNFMPMEIMPH; // 0x3C
	public int BJGOPOEAAIC_MusicRatio; // 0x40
	public bool BHJLNGEDEGN; // 0x44
	public HighScoreRatingRank.Type AGJIIKKOKFJ_ScoreRatingRank = HighScoreRatingRank.Type.Be; // 0x48
	public GHLGEECLCMH PPMGIDEHHDI; // 0x4C
	public List<CKFGMNAIBNG> ODNHGAJPEOM; // 0x50
	public List<PNGOLKLFFLH> EDEPBHCOHNF; // 0x54
	public List<IAPDFOPPGND> ALJGLDBFFGJ; // 0x58

	// RVA: 0x14F0834 Offset: 0x14F0834 VA: 0x14F0834
	public EAJCBFGKKFA()
	{
		HDJOHAJPGBA = new List<GCIJNCFDNON>();
	}

	// RVA: 0x14F08C8 Offset: 0x14F08C8 VA: 0x14F08C8
	public void KHEKNNFCAOI(IBIGBMDANNM NIMOGBDCMLJ)
	{
		TodoLogger.Log(0, "KHEKNNFCAOI");
	}

	// RVA: 0x14F153C Offset: 0x14F153C VA: 0x14F153C
	//public void KLJNFJJMJMC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, bool OJEBNBLHPNP = False) { }

	//// RVA: 0x14F1970 Offset: 0x14F1970 VA: 0x14F1970
	public GCIJNCFDNON KHGKPKDBMOH()
	{
		int a = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GDMIGCCMEEF_GuestSelect.NPEEPPCPEPE_assistItem;
		if (a < 4)
		{
			if (MGMFOJPNDGA.JOHLGBDOLNO[a].BCCHOBPJJKE_SceneId < 1)
				return AFBMEMCHJCL;
			else
				return MGMFOJPNDGA.JOHLGBDOLNO[a];
		}
		else
		{
			return AFBMEMCHJCL;
		}
	}
}
