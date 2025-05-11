
using System.Collections.Generic;
using UnityEngine;

public class MFKPFMCLOIB : EBHIMFFJBIJ
{
	public EDOHBJAPLPF_JsonData DAOPLDNLCBF_LastUpdatedPlayerData; // 0x2C

	// RVA: 0x13156A4 Offset: 0x13156A4 VA: 0x13156A4
	public MFKPFMCLOIB(GIINMFDIIMD CDGMPGLAING)
        : base(CDGMPGLAING)
    {
        DAOPLDNLCBF_LastUpdatedPlayerData = CDGMPGLAING.DLENPPIJNPA.LBDOLHGDIEB("last_updated_player_data", null);
    }
}

[System.Obsolete("Use JKCDLPOPCGC_GetRaidboss", true)]
public class JKCDLPOPCGC {}
public class JKCDLPOPCGC_GetRaidboss : CACGCMBKHDI_Request
{
    public class GDMIBMKBLDJ
    {
        public int KJPDHNJGEAH_EntityId; // 0x8
        public int KAPGBMNCDDC_PlayerCount; // 0xC
        public List<string> GACJGEENCKM_Namespaces; // 0x10
    }

    public class CEHKLJKGJPI
    {
        public class BJIJAEOEHBJ
        {
            public int MLPEHNBNOGD_PlayerId; // 0x8
            public int HALIDDHLNEG_Damage; // 0xC
            public EDOHBJAPLPF_JsonData AHEFHIMGIBI; // 0x10

            // RVA: 0x135C44C Offset: 0x135C44C VA: 0x135C44C
            public BJIJAEOEHBJ(EDOHBJAPLPF_JsonData DLENPPIJNPA)
            {
                MLPEHNBNOGD_PlayerId = (int)DLENPPIJNPA["player_id"];
                HALIDDHLNEG_Damage = (int)DLENPPIJNPA["damage"];
                AHEFHIMGIBI = DLENPPIJNPA.LBDOLHGDIEB("player_data", null);
            }
        }
        
        public NCMFOICNJEB<MFKPFMCLOIB> GJFJLEOGFLD_RaidBoss; // 0x8
        public List<BJIJAEOEHBJ> CFFDADAKJPB_AttackPlayers = new List<BJIJAEOEHBJ>(); // 0xC
        public BJIJAEOEHBJ COGCGJLFDKG_FirstAttackPlayer; // 0x10
        public BJIJAEOEHBJ MIOBFBAJDHJ_FinishPlayer; // 0x14

        // RVA: 0x135BCFC Offset: 0x135BCFC VA: 0x135BCFC
        public CEHKLJKGJPI(EDOHBJAPLPF_JsonData DLENPPIJNPA)
        {
            GJFJLEOGFLD_RaidBoss = new NCMFOICNJEB<MFKPFMCLOIB>(DLENPPIJNPA.PFBEBCDEIND("raidboss"), (GIINMFDIIMD IDLHJIOMJBK) =>
            {
                //0x135C358
                return new MFKPFMCLOIB(IDLHJIOMJBK);
            });
            CFFDADAKJPB_AttackPlayers.MAECPJAJNBO<BJIJAEOEHBJ>(DLENPPIJNPA.PFBEBCDEIND("attack_players"), (GIINMFDIIMD IDLHJIOMJBK) =>
            {
                //0x135C3CC
                return new BJIJAEOEHBJ(GIINMFDIIMD.JNEJKMKNIJJ(IDLHJIOMJBK));
            });
            COGCGJLFDKG_FirstAttackPlayer = DLENPPIJNPA.LBDOLHGDIEB("first_attack_player", null).DOHALJMPAAN<BJIJAEOEHBJ>((EDOHBJAPLPF_JsonData CMKPEDGJJPL) =>
            {
                //0x135C570
                return new BJIJAEOEHBJ(CMKPEDGJJPL);
            }, null);
            MIOBFBAJDHJ_FinishPlayer = DLENPPIJNPA.LBDOLHGDIEB("finish_player", null).DOHALJMPAAN<BJIJAEOEHBJ>((EDOHBJAPLPF_JsonData CMKPEDGJJPL) =>
            {
                //0x135C5E0
                return new BJIJAEOEHBJ(CMKPEDGJJPL);
            }, null);
        }
    }

	public const int ALFJFNDOBJA = 50;
	public GDMIBMKBLDJ BIHCCEHLAOD = new GDMIBMKBLDJ(); // 0x7C
	public CEHKLJKGJPI NFEAMMJIMPG; // 0x80

	// RVA: 0x135BACC Offset: 0x135BACC VA: 0x135BACC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRaidboss.GetRaidboss(BIHCCEHLAOD.KJPDHNJGEAH_EntityId, BIHCCEHLAOD.KAPGBMNCDDC_PlayerCount, BIHCCEHLAOD.GACJGEENCKM_Namespaces.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x135BC40 Offset: 0x135BC40 VA: 0x135BC40 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new CEHKLJKGJPI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
