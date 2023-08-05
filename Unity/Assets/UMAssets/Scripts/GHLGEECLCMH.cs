
using System.Collections.Generic;
using XeApp.Game.Common;

public class GHLGEECLCMH
{
	private HighScoreRating JPJHBJAHPFP_HsRating; // 0x8
	private HighScoreRating HOHNHJEFCBF_PrevHsRating; // 0xC
	private NGJOPPIGCPM_ResultData.DFJMELLLNLH HBLFKGAKHHN_RankState; // 0x30
	private int MIIAIBIGKOD_RankNum; // 0x34

	public HighScoreRatingRank.Type LLNHMMBFPMA_ScoreRatingRanking { get; private set; } // 0x10 EFILGAFDFOD FBMPLMNOLFC KBAOHMCAJIO
	public HighScoreRatingRank.Type KIPEPDKGCCG_PrevScoreRatingRanking { get; private set; } // 0x14 BIPJDKCFNDG DJGIJDDLPHF DCFMFAIALPI
	public int[] HFEFAGMKPKH_UtaRateAttr { get; private set; } // 0x18 EHFBONAPFCH PMNEAFIPGHP DJJFKLLPCKN
	public int[] OJFCIAJEJCI_PrevUtaRateAttr { get; private set; } // 0x1C BAFGCPMCDKK JLOGGGCCJCF LPFALOBBHNB
	public int ADKDHKMPMHP_UtaRate { get; private set; } // 0x20 HIELAPGGNEJ KCLKBHDMAFH GOLECEILPOI
	public int KNLMOBHBPII_PrevUtaRate { get; private set; } // 0x24 JCAMCJFIIJC PPLCLFCEPOE EBKLGFBLBIM
	public int ECMFBEHEGEH_UtaRateTotal { get; private set; } // 0x28 KJPIHNEFHEI AGKBCAKNDHM MLODJGBOBHB
	public int DEMOACDDPHM_PrevUtaRateTotal { get; private set; } // 0x2C KANPJCGBDMA LKNGGMNKPHD CEJAPKKCLEA

	//// RVA: 0xAA5D24 Offset: 0xAA5D24 VA: 0xAA5D24
	public void KHEKNNFCAOI(IBIGBMDANNM NIMOGBDCMLJ)
	{
		JNMFKOHFAFB_PublicStatus st = NIMOGBDCMLJ.AHEFHIMGIBI_ServerData.MHEAEGMIKIE_PublicStatus;
		JPJHBJAHPFP_HsRating = new HighScoreRating();
		HOHNHJEFCBF_PrevHsRating = new HighScoreRating();
		HBLFKGAKHHN_RankState = 0;
		MIIAIBIGKOD_RankNum = 0;
		JPJHBJAHPFP_HsRating.CalcUtaRate(st.AEIADFODLMC_HsRating);
		HOHNHJEFCBF_PrevHsRating.CalcUtaRate(st.AEIADFODLMC_HsRating);
		HFEFAGMKPKH_UtaRateAttr = new int[1];
		OJFCIAJEJCI_PrevUtaRateAttr = new int[1];
		OJFCIAJEJCI_PrevUtaRateAttr[0] = JPJHBJAHPFP_HsRating.GetUtaRateAttr(0);
		OJFCIAJEJCI_PrevUtaRateAttr[0] = HFEFAGMKPKH_UtaRateAttr[0];
		ECMFBEHEGEH_UtaRateTotal = JPJHBJAHPFP_HsRating.GetUtaRateTotal();
		DEMOACDDPHM_PrevUtaRateTotal = ECMFBEHEGEH_UtaRateTotal;
		LLNHMMBFPMA_ScoreRatingRanking = JPJHBJAHPFP_HsRating.GetUtaGrade();
		KIPEPDKGCCG_PrevScoreRatingRanking = LLNHMMBFPMA_ScoreRatingRanking;
		ADKDHKMPMHP_UtaRate = 0;
		KNLMOBHBPII_PrevUtaRate = 0;
	}

	//// RVA: 0xAA5FC4 Offset: 0xAA5FC4 VA: 0xAA5FC4
	public void KHEKNNFCAOI(int KBPEBJHBIPP_FreeMusicId, JDDGGJCGOPA_RecordMusic AIMLPJOGPID_RecordMusic, JDDGGJCGOPA_RecordMusic JMODMCLMIJL_PrevRecordMusic)
	{
		KHEKNNFCAOI(AIMLPJOGPID_RecordMusic, JMODMCLMIJL_PrevRecordMusic);
		ADKDHKMPMHP_UtaRate = HighScoreRating.GetUtaRate(AIMLPJOGPID_RecordMusic, KBPEBJHBIPP_FreeMusicId);
		KNLMOBHBPII_PrevUtaRate = HighScoreRating.GetUtaRate(JMODMCLMIJL_PrevRecordMusic, KBPEBJHBIPP_FreeMusicId);
	}

	//// RVA: 0xAA6014 Offset: 0xAA6014 VA: 0xAA6014
	public void KHEKNNFCAOI(JDDGGJCGOPA_RecordMusic AIMLPJOGPID_RecordMusic, JDDGGJCGOPA_RecordMusic JMODMCLMIJL_PrevRecordMusic)
	{
		JPJHBJAHPFP_HsRating = new HighScoreRating();
		HOHNHJEFCBF_PrevHsRating = new HighScoreRating();
		HBLFKGAKHHN_RankState = 0;
		MIIAIBIGKOD_RankNum = 0;
		HFEFAGMKPKH_UtaRateAttr = new int[1];
		OJFCIAJEJCI_PrevUtaRateAttr = new int[1];
		if(AIMLPJOGPID_RecordMusic == null)
		{
			AIMLPJOGPID_RecordMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic;
		}
		JPJHBJAHPFP_HsRating.CalcUtaRate(AIMLPJOGPID_RecordMusic, true);
		if(JMODMCLMIJL_PrevRecordMusic == null)
		{
			JMODMCLMIJL_PrevRecordMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic;
		}
		HOHNHJEFCBF_PrevHsRating.CalcUtaRate(JMODMCLMIJL_PrevRecordMusic, false);
		HFEFAGMKPKH_UtaRateAttr[0] = JPJHBJAHPFP_HsRating.GetUtaRateAttr(0);
		OJFCIAJEJCI_PrevUtaRateAttr[0] = HOHNHJEFCBF_PrevHsRating.GetUtaRateAttr(0);
		ECMFBEHEGEH_UtaRateTotal = JPJHBJAHPFP_HsRating.GetUtaRateTotal();
		DEMOACDDPHM_PrevUtaRateTotal = HOHNHJEFCBF_PrevHsRating.GetUtaRateTotal();
		LLNHMMBFPMA_ScoreRatingRanking = JPJHBJAHPFP_HsRating.GetUtaGrade();
		KIPEPDKGCCG_PrevScoreRatingRanking = HOHNHJEFCBF_PrevHsRating.GetUtaGrade();
		ADKDHKMPMHP_UtaRate = 0;
		KNLMOBHBPII_PrevUtaRate = 0;
	}

	//// RVA: 0xAA63B8 Offset: 0xAA63B8 VA: 0xAA63B8
	public NGJOPPIGCPM_ResultData.DFJMELLLNLH AGKAOEEFAAH_GetRankState()
	{
		return HBLFKGAKHHN_RankState;
	}

	//// RVA: 0xAA63C0 Offset: 0xAA63C0 VA: 0xAA63C0
	public int LGPGIGPHJJB_GetRankNum()
	{
		return MIIAIBIGKOD_RankNum;
	}

	//// RVA: 0xAA63C8 Offset: 0xAA63C8 VA: 0xAA63C8
	public List<HighScoreRating.UtaGradeData> IEPGAGBLHBN_GetMusicGradeList()
	{
		return JPJHBJAHPFP_HsRating.GetUtaGradeList();
	}

	//// RVA: 0xAA63F4 Offset: 0xAA63F4 VA: 0xAA63F4
	public HighScoreRating.UtaGradeData CMANMLGFJMM_GetNextUtaGradeInfo()
	{
		return JPJHBJAHPFP_HsRating.GetNextUtaGradeInfo();
	}

	//// RVA: 0xAA6420 Offset: 0xAA6420 VA: 0xAA6420
	public List<ECEPJHGMGBJ> BGMPAMNAKHN_GetMusicRateList(int FJFCNGNGIBN = 0)
	{
		List<ECEPJHGMGBJ> res = new List<ECEPJHGMGBJ>();
		for(int i = 0; i < 10; i++)
		{
			if(JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].FreeMusicId > 0)
			{
				ECEPJHGMGBJ data = new ECEPJHGMGBJ();
				data.KHEKNNFCAOI(JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].FreeMusicId);
				data.LPALNMHPDKK_Score = JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].Score;
				data.FJOLNJLLJEJ_RankNum = JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].RankNum;
				data.AKNELONELJK_Difficulty = (Difficulty.Type)(JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].Difficulty > 4 ? 0 : JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].Difficulty);
				data.LFGNLKKFOCD_IsLine6 = JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].isLine6 != 0;
				if(HOHNHJEFCBF_PrevHsRating != null)
				{
					data.HKIAHOEEMLC_PrevScore = data.LPALNMHPDKK_Score;
					for (int j = 0; j < 9; j++)
					{
						if(HOHNHJEFCBF_PrevHsRating.hsRatingMusicData[j, FJFCNGNGIBN].FreeMusicId == JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].FreeMusicId)
						{
							data.HKIAHOEEMLC_PrevScore = HOHNHJEFCBF_PrevHsRating.hsRatingMusicData[j, FJFCNGNGIBN].Score;
						}
					}
				}
				res.Add(data);
			}
		}
		return res;
	}

	//// RVA: 0xAA6C20 Offset: 0xAA6C20 VA: 0xAA6C20
	public void GLAHMLIFAPB(int KIMIHIBGONK_FreeMusicId, int FJFCNGNGIBN = 0)
	{
		HBLFKGAKHHN_RankState = 0;
		MIIAIBIGKOD_RankNum = 0;
		int idx = 0;
		for(int i = 0; i < JPJHBJAHPFP_HsRating.hsRatingMusicData.Length; i++)
		{
			if(JPJHBJAHPFP_HsRating.hsRatingMusicData[i, FJFCNGNGIBN].FreeMusicId == KIMIHIBGONK_FreeMusicId)
			{
				idx = i;
				break;
			}
		}
		bool f = false;
		NGJOPPIGCPM_ResultData.DFJMELLLNLH val = NGJOPPIGCPM_ResultData.DFJMELLLNLH.HJNNKCMLGFL;
		for(int i = 0; i < HOHNHJEFCBF_PrevHsRating.hsRatingMusicData.Length; i++)
		{
			if (HOHNHJEFCBF_PrevHsRating.hsRatingMusicData[i, FJFCNGNGIBN].FreeMusicId == KIMIHIBGONK_FreeMusicId)
			{
				f = true;
				if (JPJHBJAHPFP_HsRating.hsRatingMusicData[idx, FJFCNGNGIBN].RankNum < HOHNHJEFCBF_PrevHsRating.hsRatingMusicData[i, FJFCNGNGIBN].RankNum)
				{
					val = NGJOPPIGCPM_ResultData.DFJMELLLNLH.COHKBMDEMMN;
				}
			}
		}
		if(!f)
		{
			if (JPJHBJAHPFP_HsRating.hsRatingMusicData[9, FJFCNGNGIBN].Score < ADKDHKMPMHP_UtaRate)
				val = NGJOPPIGCPM_ResultData.DFJMELLLNLH.HHLBGKEDNGH;
		}
		HBLFKGAKHHN_RankState = val;
		MIIAIBIGKOD_RankNum = JPJHBJAHPFP_HsRating.hsRatingMusicData[idx, FJFCNGNGIBN].RankNum;
	}
}
