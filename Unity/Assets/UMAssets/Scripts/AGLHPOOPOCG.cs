
using System.Collections.Generic;
using XeApp.Game.Common;

public delegate void MOCLMLOPBLK(List<KLNBIIPKNIB> DIJHMJBOAHI);

public struct KLNBIIPKNIB
{
	public int MLPEHNBNOGD_PlayerId; // 0x0
	public long KNIFCANOHOC_score; // 0x8
	public int FJOLNJLLJEJ_rank; // 0x10
}

public class OFGCBEPEFOH
{
	public static string LMPCPCAIEHH { get { return "ranking_uta_rate"; } } //0x1DCD70C AJAHDNPMPHA
}

public class AGLHPOOPOCG
{
	public static AGLHPOOPOCG HHCJCDFCLOB; // 0x0
	public bool BFILINGKCFK; // 0x8
	private int OAKDPFFGCLJ_TopPlayerScore; // 0xC

	// RVA: 0x15C41EC Offset: 0x15C41EC VA: 0x15C41EC
	public AGLHPOOPOCG()
	{
		if (HHCJCDFCLOB != null)
			return;
		HHCJCDFCLOB = this;
	}

	//// RVA: 0x15C42C4 Offset: 0x15C42C4 VA: 0x15C42C4
	public void OAGGKCHJBEO(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		BFILINGKCFK = false;
		BJKCAKJHMPC_GetTopRank(OFGCBEPEFOH.LMPCPCAIEHH, 1, (List<KLNBIIPKNIB> NNDGIAEFMOG) =>
		{
			//0x15C4BE8
			LCJJHEHDKFJ(NNDGIAEFMOG);
			_KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0x15C4C3C
			HKMNKGFJLEA();
			_IDAEHNGOKAE_OnRankingError();
		}, _JGKOLBLPMPG_OnFail);
	}

	//// RVA: 0x15C4718 Offset: 0x15C4718 VA: 0x15C4718
	private void LCJJHEHDKFJ(List<KLNBIIPKNIB> NNDGIAEFMOG)
	{
		BFILINGKCFK = true;
		if(NNDGIAEFMOG != null && NNDGIAEFMOG.Count > 0)
		{
			OAKDPFFGCLJ_TopPlayerScore = (int)NNDGIAEFMOG[0].KNIFCANOHOC_score;
		}
	}

	//// RVA: 0x15C47E0 Offset: 0x15C47E0 VA: 0x15C47E0
	private void HKMNKGFJLEA()
	{
		BFILINGKCFK = true;
		OAKDPFFGCLJ_TopPlayerScore = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EAHPKPADCPL_total_uta_rate;
	}

	//// RVA: 0x15C48CC Offset: 0x15C48CC VA: 0x15C48CC
	//private int EKHBHNAGEJF() { }

	//// RVA: 0x15C49B4 Offset: 0x15C49B4 VA: 0x15C49B4
	public int EIFNIBPAGFF_GetTopPlayerUtaGrade()
	{
		return (int)HighScoreRating.GetUtaGrade(OAKDPFFGCLJ_TopPlayerScore);
	}

	//// RVA: 0x15C4428 Offset: 0x15C4428 VA: 0x15C4428
	private void BJKCAKJHMPC_GetTopRank(string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target, MOCLMLOPBLK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PFDPLFOGMNF_GetRegularRankingTopRank req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PFDPLFOGMNF_GetRegularRankingTopRank());
		req.DEPGBBJMFED_CategoryId = _DEPGBBJMFED_CategoryId;
		req.HHNFHJCAPJO_Target = _HHNFHJCAPJO_Target.ToString();
		req.NBFDEFGFLPJ = JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError;
		req.CJMFJOMECKI_ErrorId = SakashoErrorId.RANKING_NOT_GENERATED;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x15C4C88
			if (JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
				_IDAEHNGOKAE_OnRankingError();
			else
				_JGKOLBLPMPG_OnFail();
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x15C4D58
			PFDPLFOGMNF_GetRegularRankingTopRank r = NHECPMNKEFK as PFDPLFOGMNF_GetRegularRankingTopRank;
			if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
			{
				_KLMFJJCNBIP_OnSuccess(null);
			}
			else
			{
				List<int> l = new List<int>();
				for(int i = 0; i < r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count; i++)
				{
					l.Add(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[i].EHGBICNIBKE_player_id);
				}
				FGEIGGNCGGD(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess);
			}
		};
	}

	//// RVA: 0x15C49C8 Offset: 0x15C49C8 VA: 0x15C49C8
	private void FGEIGGNCGGD(List<OBGBKHKMDNF> NFMMAELFANG, MOCLMLOPBLK _KLMFJJCNBIP_OnSuccess)
	{
		List<KLNBIIPKNIB> l = new List<KLNBIIPKNIB>();
		for(int i = 0; i < NFMMAELFANG.Count; i++)
		{
			l.Add(new KLNBIIPKNIB() { MLPEHNBNOGD_PlayerId = NFMMAELFANG[i].EHGBICNIBKE_player_id, KNIFCANOHOC_score = NFMMAELFANG[i].KNIFCANOHOC_score, FJOLNJLLJEJ_rank = NFMMAELFANG[i].FJOLNJLLJEJ_rank });
		}
		_KLMFJJCNBIP_OnSuccess(l);
	}
}
