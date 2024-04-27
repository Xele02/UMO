
using System.Collections.Generic;
using UnityEngine;

public class PMDLLGNDFCJ
{
	public string LJNAKDMILMC_Key; // 0x8
	public List<long> COGMPENEPBD; // 0xC

	// RVA: 0xFED9B0 Offset: 0xFED9B0 VA: 0xFED9B0
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		LJNAKDMILMC_Key = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.LJNAKDMILMC_key];
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
		{
			EDOHBJAPLPF_JsonData inventory_ids = IDLHJIOMJBK[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
			COGMPENEPBD = new List<long>(inventory_ids.HNBFOAJIIAL_Count);
			for(int i = 0; i < inventory_ids.HNBFOAJIIAL_Count; i++)
			{
				COGMPENEPBD.Add((long)inventory_ids[i]);
			}
		}
	}
}

public class BGKCFBHGNDI
{
	public List<PMDLLGNDFCJ> CEDLLCCONJP; // 0x8

	// RVA: 0xC7CE74 Offset: 0xC7CE74 VA: 0xC7CE74
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData achievement_prizes = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes];
		CEDLLCCONJP = new List<PMDLLGNDFCJ>(achievement_prizes.HNBFOAJIIAL_Count);
		for(int i = 0; i < achievement_prizes.HNBFOAJIIAL_Count; i++)
		{
			PMDLLGNDFCJ data = new PMDLLGNDFCJ();
			data.KHEKNNFCAOI(achievement_prizes[i]);
			CEDLLCCONJP.Add(data);
		}
	}
}

[System.Obsolete("Use FLONELKGABJ_ClaimAchievementPrizes", true)]
public class FLONELKGABJ { }
public class FLONELKGABJ_ClaimAchievementPrizes : CACGCMBKHDI_Request
{
	public bool KMOBDLBKAAA; // 0x7C
	public List<int> MEGNAIJPBFF; // 0x80
	public List<string> MIDAMHNABAJ; // 0x84

	public override bool OIDCBBGLPHL { get { return true; } } //0x1197F0C GINMIBJOABO
	public BGKCFBHGNDI NFEAMMJIMPG { get; private set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1197F24 Offset: 0x1197F24 VA: 0x1197F24
	private bool DEJPNPMHPJD()
	{
		return MEGNAIJPBFF != null && MEGNAIJPBFF.Count > 0;
	}

	// RVA: 0x1197FA8 Offset: 0x1197FA8 VA: 0x1197FA8 Slot: 12
	public override void DHLDNIEELHO()
	{
		if(!KMOBDLBKAAA)
		{
			if(!DEJPNPMHPJD())
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizes(MIDAMHNABAJ.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
			}
			else
			{
				EBGACDGNCAA_CallContext = SakashoAchievement.ClaimAchievementPrizesSetInventoryClosedAt(MIDAMHNABAJ.ToArray(), MEGNAIJPBFF.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
			}
		}
		else if(!DEJPNPMHPJD())
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizes(MIDAMHNABAJ.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		}
		else
		{
			EBGACDGNCAA_CallContext = SakashoRepeatedAchievement.ClaimAchievementPrizesSetInventoryClosedAt(MIDAMHNABAJ.ToArray(), MEGNAIJPBFF.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
		}
	}

	// RVA: 0x11982F0 Offset: 0x11982F0 VA: 0x11982F0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		BGKCFBHGNDI d = new BGKCFBHGNDI();
		d.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG = d;
	}
}
