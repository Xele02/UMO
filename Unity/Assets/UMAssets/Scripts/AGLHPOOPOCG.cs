
using System.Collections.Generic;
using XeApp.Game.Common;

public delegate void MOCLMLOPBLK(List<KLNBIIPKNIB> DIJHMJBOAHI);

public struct KLNBIIPKNIB
{
	public int MLPEHNBNOGD_PlayerId; // 0x0
	public long KNIFCANOHOC_Score; // 0x8
	public int FJOLNJLLJEJ_Rank; // 0x10
}

public class OFGCBEPEFOH
{
	public static string LMPCPCAIEHH { get { return "ranking_uta_rate"; } } //0x1DCD70C AJAHDNPMPHA
}

public class AGLHPOOPOCG
{
	public static AGLHPOOPOCG HHCJCDFCLOB; // 0x0
	public bool BFILINGKCFK; // 0x8
	private int OAKDPFFGCLJ_TopPlayerId; // 0xC

	// RVA: 0x15C41EC Offset: 0x15C41EC VA: 0x15C41EC
	public AGLHPOOPOCG()
	{
		if (HHCJCDFCLOB != null)
			return;
		HHCJCDFCLOB = this;
	}

	//// RVA: 0x15C42C4 Offset: 0x15C42C4 VA: 0x15C42C4
	public void OAGGKCHJBEO(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		BFILINGKCFK = false;
		BJKCAKJHMPC_GetTopRank(OFGCBEPEFOH.LMPCPCAIEHH, 1, (List<KLNBIIPKNIB> NNDGIAEFMOG) =>
		{
			//0x15C4BE8
			LCJJHEHDKFJ(NNDGIAEFMOG);
			KLMFJJCNBIP();
		}, () =>
		{
			//0x15C4C3C
			HKMNKGFJLEA();
			IDAEHNGOKAE();
		}, JGKOLBLPMPG);
	}

	//// RVA: 0x15C4718 Offset: 0x15C4718 VA: 0x15C4718
	private void LCJJHEHDKFJ(List<KLNBIIPKNIB> NNDGIAEFMOG)
	{
		BFILINGKCFK = true;
		if(NNDGIAEFMOG.Count > 0)
		{
			OAKDPFFGCLJ_TopPlayerId = NNDGIAEFMOG[0].MLPEHNBNOGD_PlayerId;
		}
	}

	//// RVA: 0x15C47E0 Offset: 0x15C47E0 VA: 0x15C47E0
	private void HKMNKGFJLEA()
	{
		TodoLogger.Log(0, "HKMNKGFJLEA");
	}

	//// RVA: 0x15C48CC Offset: 0x15C48CC VA: 0x15C48CC
	//private int EKHBHNAGEJF() { }

	//// RVA: 0x15C49B4 Offset: 0x15C49B4 VA: 0x15C49B4
	public int EIFNIBPAGFF()
	{
		return (int)HighScoreRating.GetUtaGrade(OAKDPFFGCLJ_TopPlayerId);
	}

	//// RVA: 0x15C4428 Offset: 0x15C4428 VA: 0x15C4428
	private void BJKCAKJHMPC_GetTopRank(string DEPGBBJMFED, int HHNFHJCAPJO, MOCLMLOPBLK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		PFDPLFOGMNF_GetRegularRankingTopRank req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PFDPLFOGMNF_GetRegularRankingTopRank());
		req.DEPGBBJMFED_Category = DEPGBBJMFED;
		req.HHNFHJCAPJO_Target = HHNFHJCAPJO.ToString();
		req.NBFDEFGFLPJ = JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError;
		req.CJMFJOMECKI_ErrorId = SakashoErrorId.RANKING_NOT_GENERATED;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x15C4C88
			if (JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
				IDAEHNGOKAE();
			else
				JGKOLBLPMPG();
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x15C4D58
			PFDPLFOGMNF_GetRegularRankingTopRank r = NHECPMNKEFK as PFDPLFOGMNF_GetRegularRankingTopRank;
			if(r.NFEAMMJIMPG.EJDEDOJFOOK.Count == 0)
			{
				KLMFJJCNBIP(null);
			}
			else
			{
				List<int> l = new List<int>();
				for(int i = 0; i < r.NFEAMMJIMPG.EJDEDOJFOOK.Count; i++)
				{
					l.Add(r.NFEAMMJIMPG.EJDEDOJFOOK[i].EHGBICNIBKE_PlayerId);
				}
				FGEIGGNCGGD(r.NFEAMMJIMPG.EJDEDOJFOOK, KLMFJJCNBIP);
			}
		};
	}

	//// RVA: 0x15C49C8 Offset: 0x15C49C8 VA: 0x15C49C8
	private void FGEIGGNCGGD(List<OBGBKHKMDNF> NFMMAELFANG, MOCLMLOPBLK KLMFJJCNBIP)
	{
		List<KLNBIIPKNIB> l = new List<KLNBIIPKNIB>();
		for(int i = 0; i < NFMMAELFANG.Count; i++)
		{
			l.Add(new KLNBIIPKNIB() { MLPEHNBNOGD_PlayerId = NFMMAELFANG[i].EHGBICNIBKE_PlayerId, KNIFCANOHOC_Score = NFMMAELFANG[i].KNIFCANOHOC_Score, FJOLNJLLJEJ_Rank = NFMMAELFANG[i].FJOLNJLLJEJ_Rank });
		}
		KLMFJJCNBIP(l);
	}
}
