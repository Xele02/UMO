
using System.Collections.Generic;
using UnityEngine;

public class OBGBKHKMDNF
{
	public int EHGBICNIBKE_player_id; // 0x8
	public int FJOLNJLLJEJ_rank; // 0xC
	public long KNIFCANOHOC_score; // 0x10
	public double HOCPLDLAIGL_Score; // 0x18
	public string KACECFNECON_extra; // 0x20

	//// RVA: 0x1B2A520 Offset: 0x1B2A520 VA: 0x1B2A520
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		EHGBICNIBKE_player_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EHGBICNIBKE_player_id];
		FJOLNJLLJEJ_rank = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FJOLNJLLJEJ_rank];
		BOAGCEOHJEO.IIEMACPEEBJ_Deserialize(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KNIFCANOHOC_score], out HOCPLDLAIGL_Score, out KNIFCANOHOC_score);
		KACECFNECON_extra = null;
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KACECFNECON_extra))
		{
			if (_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KACECFNECON_extra] == null)
				return;
			KACECFNECON_extra = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KACECFNECON_extra];
		}
	}
}

public class NJNCENEFCEI
{
	public List<OBGBKHKMDNF> EJDEDOJFOOK_Ranks = new List<OBGBKHKMDNF>(); // 0x8

	// RVA: 0x18AC538 Offset: 0x18AC538 VA: 0x18AC538
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data["ranks"];
		EJDEDOJFOOK_Ranks = new List<OBGBKHKMDNF>(b.HNBFOAJIIAL_Count);
		for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
		{
			OBGBKHKMDNF data = new OBGBKHKMDNF();
			data.KHEKNNFCAOI_Init(b[i]);
			EJDEDOJFOOK_Ranks.Add(data);
		}
	}
}

[System.Obsolete("Use OKPEFAPPFDH_GetRanksAroundSelf", true)]
public class OKPEFAPPFDH { }
public class OKPEFAPPFDH_GetRanksAroundSelf : CACGCMBKHDI_Request
{
	// Fields
	public int EMPNJPMAKBF_Id; // 0x7C
	public int MJGOBEGONON_Type; // 0x80
	public int NHPCKCOPKAM_from; // 0x84
	public int PJFKNNNDMIA_to; // 0x88

	public NJNCENEFCEI NFEAMMJIMPG_Result { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool OIDCBBGLPHL { get { return true; } } //0x14ACBE4 GINMIBJOABO

	// RVA: 0x14ACB08 Offset: 0x14ACB08 VA: 0x14ACB08
	public OKPEFAPPFDH_GetRanksAroundSelf(bool KCOEDBOCPIK/* = false*/)
	{
		if (KCOEDBOCPIK)
			return;
		NBFDEFGFLPJ = JGJFFKPFMDB.NBDHKIGADLF_IsRankingError2;
	}

	// RVA: 0x14ACBEC Offset: 0x14ACBEC VA: 0x14ACBEC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRanking.GetRanksAroundSelf(EMPNJPMAKBF_Id, MJGOBEGONON_Type, NHPCKCOPKAM_from, PJFKNNNDMIA_to, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x14ACCF0 Offset: 0x14ACCF0 VA: 0x14ACCF0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new NJNCENEFCEI();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
