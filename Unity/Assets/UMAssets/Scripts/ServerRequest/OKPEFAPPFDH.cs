
using System.Collections.Generic;
using UnityEngine;

public class OBGBKHKMDNF
{
	public int EHGBICNIBKE_PlayerId; // 0x8
	public int FJOLNJLLJEJ_Rank; // 0xC
	public long KNIFCANOHOC_Score; // 0x10
	public double HOCPLDLAIGL_Score; // 0x18
	public string KACECFNECON_Extra; // 0x20

	//// RVA: 0x1B2A520 Offset: 0x1B2A520 VA: 0x1B2A520
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EHGBICNIBKE_PlayerId = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.EHGBICNIBKE_player_id];
		FJOLNJLLJEJ_Rank = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.FJOLNJLLJEJ_rank];
		BOAGCEOHJEO.IIEMACPEEBJ(IDLHJIOMJBK[AFEHLCGHAEE_Strings.KNIFCANOHOC_score], out HOCPLDLAIGL_Score, out KNIFCANOHOC_Score);
		KACECFNECON_Extra = null;
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KACECFNECON_extra))
		{
			if (IDLHJIOMJBK[AFEHLCGHAEE_Strings.KACECFNECON_extra] == null)
				return;
			KACECFNECON_Extra = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KACECFNECON_extra];
		}
	}
}

public class NJNCENEFCEI
{
	public List<OBGBKHKMDNF> EJDEDOJFOOK = new List<OBGBKHKMDNF>(); // 0x8

	// RVA: 0x18AC538 Offset: 0x18AC538 VA: 0x18AC538
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData b = IDLHJIOMJBK["ranks"];
		EJDEDOJFOOK = new List<OBGBKHKMDNF>(b.HNBFOAJIIAL_Count);
		for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
		{
			OBGBKHKMDNF data = new OBGBKHKMDNF();
			data.KHEKNNFCAOI(b[i]);
			EJDEDOJFOOK.Add(data);
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
	public int NHPCKCOPKAM_From; // 0x84
	public int PJFKNNNDMIA_To; // 0x88

	public NJNCENEFCEI NFEAMMJIMPG { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	//public override bool OIDCBBGLPHL { get; }

	// RVA: 0x14ACB08 Offset: 0x14ACB08 VA: 0x14ACB08
	public OKPEFAPPFDH_GetRanksAroundSelf(bool KCOEDBOCPIK = false)
	{
		if (KCOEDBOCPIK)
			return;
		NBFDEFGFLPJ = JGJFFKPFMDB.NBDHKIGADLF;
	}

	// RVA: 0x14ACBE4 Offset: 0x14ACBE4 VA: 0x14ACBE4 Slot: 7
	//public override bool GINMIBJOABO() { }

	// RVA: 0x14ACBEC Offset: 0x14ACBEC VA: 0x14ACBEC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoRanking.GetRanksAroundSelf(EMPNJPMAKBF_Id, MJGOBEGONON_Type, NHPCKCOPKAM_From, PJFKNNNDMIA_To, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x14ACCF0 Offset: 0x14ACCF0 VA: 0x14ACCF0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NJNCENEFCEI();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
