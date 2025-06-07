
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using XeSys;

public static class BDLAFAPDOJE
{
	// RVA: 0xC71178 Offset: 0xC71178 VA: 0xC71178
	public static EDOHBJAPLPF_JsonData LBDOLHGDIEB(this EDOHBJAPLPF_JsonData DLENPPIJNPA, string OPFGFINHFCE, EDOHBJAPLPF_JsonData PBHLLLGOGKA)
    {
        if(DLENPPIJNPA.BBAJPINMOEP_Contains(OPFGFINHFCE))
        {
            return DLENPPIJNPA[OPFGFINHFCE];
        }
        return PBHLLLGOGKA;
    }

	// [ExtensionAttribute] // RVA: 0x6C4548 Offset: 0x6C4548 VA: 0x6C4548
	// // RVA: -1 Offset: -1
	public static T DOHALJMPAAN<T>(this EDOHBJAPLPF_JsonData DLENPPIJNPA, Func<EDOHBJAPLPF_JsonData, T> NHBHDPIIMBO, T PBHLLLGOGKA)
    {
        if(DLENPPIJNPA == null)
            return PBHLLLGOGKA;
        return NHBHDPIIMBO(DLENPPIJNPA);
    }
	// /* GenericInstMethod :
	// |
	// |-RVA: 0x1AB556C Offset: 0x1AB556C VA: 0x1AB556C
	// |-BDLAFAPDOJE.DOHALJMPAAN<JKCDLPOPCGC.CEHKLJKGJPI.BJIJAEOEHBJ>
	// |-BDLAFAPDOJE.DOHALJMPAAN<object>
	// |
	// |-RVA: 0x1AB551C Offset: 0x1AB551C VA: 0x1AB551C
	// |-BDLAFAPDOJE.DOHALJMPAAN<int>
	// */

	// [ExtensionAttribute] // RVA: 0x6C4558 Offset: 0x6C4558 VA: 0x6C4558
	// // RVA: 0xC711E0 Offset: 0xC711E0 VA: 0xC711E0
	public static GIINMFDIIMD PFBEBCDEIND(this EDOHBJAPLPF_JsonData DLENPPIJNPA, string LJNAKDMILMC)
    {
        GIINMFDIIMD g = new GIINMFDIIMD(DLENPPIJNPA, LJNAKDMILMC);
        if(g.DLENPPIJNPA == null)
            return null;
        return g;
    }

	// [ExtensionAttribute] // RVA: 0x6C4568 Offset: 0x6C4568 VA: 0x6C4568
	// // RVA: 0xC71278 Offset: 0xC71278 VA: 0xC71278
	public static GIINMFDIIMD PFBEBCDEIND(EDOHBJAPLPF_JsonData DLENPPIJNPA, int BMBBDIAEOMP)
	{
        GIINMFDIIMD g = new GIINMFDIIMD(DLENPPIJNPA, BMBBDIAEOMP);
        if(g.DLENPPIJNPA == null)
            return null;
        return g;
	}
}

public class GIINMFDIIMD
{
	public EDOHBJAPLPF_JsonData DLENPPIJNPA; // 0x8

	// // RVA: 0xAA7BC8 Offset: 0xAA7BC8 VA: 0xAA7BC8
	public GIINMFDIIMD(EDOHBJAPLPF_JsonData DLENPPIJNPA)
    {
        this.DLENPPIJNPA = DLENPPIJNPA;
    }

	// // RVA: 0xAA7BE8 Offset: 0xAA7BE8 VA: 0xAA7BE8
	public GIINMFDIIMD(EDOHBJAPLPF_JsonData DLENPPIJNPA, string LJNAKDMILMC)
    {
        this.DLENPPIJNPA = DLENPPIJNPA[LJNAKDMILMC];
    }

	// // RVA: 0xAA7C2C Offset: 0xAA7C2C VA: 0xAA7C2C
	public GIINMFDIIMD(EDOHBJAPLPF_JsonData DLENPPIJNPA, int BMBBDIAEOMP)
	{
        this.DLENPPIJNPA = DLENPPIJNPA[BMBBDIAEOMP];
	}

	// // RVA: 0xAA7C70 Offset: 0xAA7C70 VA: 0xAA7C70
	public static EDOHBJAPLPF_JsonData JNEJKMKNIJJ(GIINMFDIIMD IDLHJIOMJBK)
	{
		return IDLHJIOMJBK.DLENPPIJNPA;
	}
}

public class LBICPMOLOKD
{
	public int PPFNGGCBJKC_Id; // 0x8
	public string MMEBLOIJBKE_UniqueKey; // 0xC
	public int BCCOMAODPJI_Hp; // 0x10
	public int FFBHEHAIHMA_MaxHp; // 0x14
	public int CKFNNECHOGG_ComboCount; // 0x18
	public int MHABJOMJCFI_AttackPlayerCount; // 0x1C
	public int MBEMFKGBIEO_EncounterPlayerId; // 0x20
	public long OJCCKOICMJK_CreatedAt; // 0x28
	public long PPLAPJDENND_EscapedAt; // 0x30

	// RVA: 0xD99104 Offset: 0xD99104 VA: 0xD99104
	public LBICPMOLOKD(GIINMFDIIMD CDGMPGLAING)
    {
        PPFNGGCBJKC_Id = (int)CDGMPGLAING.DLENPPIJNPA["id"];
        MMEBLOIJBKE_UniqueKey = (string)CDGMPGLAING.DLENPPIJNPA["unique_key"];
        BCCOMAODPJI_Hp = (int)CDGMPGLAING.DLENPPIJNPA["hp"];
        FFBHEHAIHMA_MaxHp = (int)CDGMPGLAING.DLENPPIJNPA["max_hp"];
        CKFNNECHOGG_ComboCount = (int)CDGMPGLAING.DLENPPIJNPA["combo_count"];
        MHABJOMJCFI_AttackPlayerCount = (int)CDGMPGLAING.DLENPPIJNPA["attack_player_count"];
        MBEMFKGBIEO_EncounterPlayerId = CDGMPGLAING.DLENPPIJNPA.LBDOLHGDIEB("encounter_player_id", null).DOHALJMPAAN<int>((EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
        {
            //0xD9953C
            return (int)IDLHJIOMJBK;
        }, 0);
        OJCCKOICMJK_CreatedAt = JsonUtil.GetLong(CDGMPGLAING.DLENPPIJNPA, "created_at", 0);
        PPLAPJDENND_EscapedAt = JsonUtil.GetLong(CDGMPGLAING.DLENPPIJNPA, "escaped_at", 0);
    }
}

public class CMPLGKFJCIC<EffectInfoClass> : LBICPMOLOKD
{
	public List<EffectInfoClass> MGPCMCNFFIM_Effects = new List<EffectInfoClass>(); // 0x0

	// RVA: -1 Offset: -1
	public CMPLGKFJCIC(GIINMFDIIMD CDGMPGLAING, Func<GIINMFDIIMD, EffectInfoClass> KACGHAKGAGH)
        : base(CDGMPGLAING)
    {
        MGPCMCNFFIM_Effects.MAECPJAJNBO(CDGMPGLAING.DLENPPIJNPA.PFBEBCDEIND("effects"), (GIINMFDIIMD IDLHJIOMJBK) =>
		{
			return KACGHAKGAGH(IDLHJIOMJBK);
		});
    }
	/* GenericInstMethod :
	|
	|-RVA: 0x26B831C Offset: 0x26B831C VA: 0x26B831C
	|-CMPLGKFJCIC<EBHIMFFJBIJ>..ctor
	|-CMPLGKFJCIC<MFKPFMCLOIB>..ctor
	|-CMPLGKFJCIC<object>..ctor
	*/
}

public class NCMFOICNJEB<EffectInfoClass> : CMPLGKFJCIC<EffectInfoClass>
{
	public NHCDBBBMFFG CMCKNKKCNDK_Status; // 0x3c
	public int OKIEOLAAJNM_LastAttackPlayerId; // 0x40
	public bool DLMNFENNCJG_HasAttacked; // 0x44
	public bool ICCOOAAJEIN_CanReceiveReward; // 0x45
	public bool CAKONDPGDIL_CanRequestHelp; // 0x46
	public int CNGBMPCDFFE_RequestPlayerId; // 0x48

	// Methods

	// RVA: -1 Offset: -1
	public NCMFOICNJEB(GIINMFDIIMD CDGMPGLAING, Func<GIINMFDIIMD, EffectInfoClass> KACGHAKGAGH)
		: base(CDGMPGLAING, KACGHAKGAGH)
	{
		CMCKNKKCNDK_Status = (NHCDBBBMFFG) (int)CDGMPGLAING.DLENPPIJNPA["status"];
		OKIEOLAAJNM_LastAttackPlayerId = CDGMPGLAING.DLENPPIJNPA["last_attack_player_id"].DOHALJMPAAN<int>((EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0x26C2814
			return (int)IDLHJIOMJBK;
		}, 0);
		DLMNFENNCJG_HasAttacked = (bool)CDGMPGLAING.DLENPPIJNPA["has_attacked"];
		ICCOOAAJEIN_CanReceiveReward = (bool)CDGMPGLAING.DLENPPIJNPA["can_receive_rewards"];
		CAKONDPGDIL_CanRequestHelp = (bool)CDGMPGLAING.DLENPPIJNPA["can_request_help"];
		CNGBMPCDFFE_RequestPlayerId = CDGMPGLAING.DLENPPIJNPA.LBDOLHGDIEB("request_player_id", null).DOHALJMPAAN<int>((EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0x26C2898
			return (int)IDLHJIOMJBK;
		}, 0);
	}
	/* GenericInstMethod :
	|
	|-RVA: 0x26C291C Offset: 0x26C291C VA: 0x26C291C
	|-NCMFOICNJEB<EBHIMFFJBIJ>..ctor
	|-NCMFOICNJEB<MFKPFMCLOIB>..ctor
	|-NCMFOICNJEB<object>..ctor
	*/
}
