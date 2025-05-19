
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class SakashoRaidbossEffectData
{
	public int EffectId { get; set; } // 0x8
	public int NumberOfTimes { get; set; } // 0xC
	public int DurationSeconds { get; set; } // 0x10
}

public class LMJHOAHBDKN : CMPLGKFJCIC<MFKPFMCLOIB> // TypeDefIndex: 10435
{
	public NHCDBBBMFFG CMCKNKKCNDK_Status; // 0x3C
	public int OKIEOLAAJNM_LastAttackPlayerId; // 0x40

	// RVA: 0x10BBAB4 Offset: 0x10BBAB4 VA: 0x10BBAB4
	public LMJHOAHBDKN(GIINMFDIIMD CDGMPGLAING)
        : base(CDGMPGLAING, (GIINMFDIIMD IDLHJIOMJBK) =>
        {
            //0x10BBD44
            return new MFKPFMCLOIB(IDLHJIOMJBK);
        })
    {
        CMCKNKKCNDK_Status = (NHCDBBBMFFG)(int)CDGMPGLAING.DLENPPIJNPA["status"];
        OKIEOLAAJNM_LastAttackPlayerId = (int)CDGMPGLAING.DLENPPIJNPA["last_attack_player_id"];
    }
}

[System.Obsolete("Use JPPCMHKHAGC_AttackRaidbossAndSave", true)]
public class JPPCMHKHAGC {}
public class JPPCMHKHAGC_AttackRaidbossAndSave : CACGCMBKHDI_Request, CJIKLGPIPBA
{
    public class PGAOPHPLLOG // TypeDefIndex: 10439
    {
        public int KJPDHNJGEAH_EntityId; // 0x8
        public int HALIDDHLNEG_Damage; // 0xC
        public int MHABJOMJCFI_AttackPlayerCount; // 0x10
        public SakashoRaidbossEffectData NKDGDKKEPOO_EffectData; // 0x14
        public List<string> HOLACOMBPJH_NamespaceForResponse; // 0x18
        public List<string> FDDIKJOMBIO_NamespaceForSave; // 0x1C
        public string AHEFHIMGIBI_PlayerData; // 0x20
        public bool CHDDDCCHJJH_Replace; // 0x24
        public long MCKEOKFMLAH; // 0x28

        // // RVA: 0x1BA93BC Offset: 0x1BA93BC VA: 0x1BA93BC
        public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, string JCJDPGMKJAJ_PlayerData)
        {
            AHEFHIMGIBI_PlayerData = JCJDPGMKJAJ_PlayerData;
            CHDDDCCHJJH_Replace = !IDLHJIOMJBK.BLOCFLFHCFJ_Keep;
            FDDIKJOMBIO_NamespaceForSave = IDLHJIOMJBK.KFGDPMNCCFO_NaespaceForSave;
            MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
        }
    }

    public class ODNJNIICCLB
    {
        public class GKIJMGEBIDG
        {
            public int MLPEHNBNOGD_PlayerId; // 0x8
            public EDOHBJAPLPF_JsonData AHEFHIMGIBI_PlayerData; // 0xC

            // RVA: 0x1BA92C4 Offset: 0x1BA92C4 VA: 0x1BA92C4
            public GKIJMGEBIDG(EDOHBJAPLPF_JsonData DLENPPIJNPA)
            {
                MLPEHNBNOGD_PlayerId = (int)DLENPPIJNPA["player_id"];
                AHEFHIMGIBI_PlayerData = DLENPPIJNPA["player_data"];
            }
        }

        public int HALIDDHLNEG_Damage; // 0x8
        public LMJHOAHBDKN AKLNMPMLDAJ_RaidBoss; // 0xC
        public List<GKIJMGEBIDG> CDEFBMLKLCM_RecentAttackPlayers = new List<GKIJMGEBIDG>(); // 0x10
        public long OJCCKOICMJK_CreatedAt; // 0x18
        public long LPJIIDJJKOE_UpdatedAt; // 0x20
        public int ICEMJDBBDMG_DataStatus; // 0x28

        // RVA: 0x1BA8F30 Offset: 0x1BA8F30 VA: 0x1BA8F30
        public ODNJNIICCLB(EDOHBJAPLPF_JsonData DLENPPIJNPA)
        {
            HALIDDHLNEG_Damage = (int)DLENPPIJNPA["damage"];
            AKLNMPMLDAJ_RaidBoss = new LMJHOAHBDKN(DLENPPIJNPA.PFBEBCDEIND("raidboss"));
            CDEFBMLKLCM_RecentAttackPlayers.MAECPJAJNBO(DLENPPIJNPA.PFBEBCDEIND("recent_attack_players"), (GIINMFDIIMD IDLHJIOMJBK) =>
            {
                //0x1BA9250
                return new GKIJMGEBIDG(DLENPPIJNPA);
            });
            OJCCKOICMJK_CreatedAt = JsonUtil.GetLong(DLENPPIJNPA, "created_at");
            LPJIIDJJKOE_UpdatedAt = JsonUtil.GetLong(DLENPPIJNPA, "updated_at");
            ICEMJDBBDMG_DataStatus = (int)DLENPPIJNPA["data_status"];
        }
    }

	public PGAOPHPLLOG BIHCCEHLAOD = new PGAOPHPLLOG(); // 0x7C
	public ODNJNIICCLB NFEAMMJIMPG; // 0x80

	public override bool BNCFONNOHFO { get { return true; } } //0x1BA8A9C NPLNAJFJPEE

	// RVA: 0x1BA8AA4 Offset: 0x1BA8AA4 VA: 0x1BA8AA4
	public JPPCMHKHAGC_AttackRaidbossAndSave(bool NFHDKELECKO/* = False*/)
    {
        if(NFHDKELECKO)
        {
            NBFDEFGFLPJ = JGJFFKPFMDB.PLMJFNPGOCD;
        }
    }

	// RVA: 0x1BA8B9C Offset: 0x1BA8B9C VA: 0x1BA8B9C Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoRaidboss.AttackRaidbossAndSave(BIHCCEHLAOD.KJPDHNJGEAH_EntityId,
            Mathf.Max(BIHCCEHLAOD.HALIDDHLNEG_Damage, 0), Mathf.Clamp(BIHCCEHLAOD.MHABJOMJCFI_AttackPlayerCount, 0, 10), 
            BIHCCEHLAOD.NKDGDKKEPOO_EffectData, BIHCCEHLAOD.HOLACOMBPJH_NamespaceForResponse.ToArray(), BIHCCEHLAOD.FDDIKJOMBIO_NamespaceForSave.ToArray(), 
            BIHCCEHLAOD.AHEFHIMGIBI_PlayerData, BIHCCEHLAOD.CHDDDCCHJJH_Replace, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1BA8E18 Offset: 0x1BA8E18 VA: 0x1BA8E18 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        PJKLMCGEJMK.DALFMJFKCGJ = BIHCCEHLAOD.MCKEOKFMLAH;
        NFEAMMJIMPG = new ODNJNIICCLB(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }

	// RVA: 0x1BA91DC Offset: 0x1BA91DC VA: 0x1BA91DC Slot: 17
	public List<string> KPIDBPEKMFD_GetNamespaceForSave()
    {
        return BIHCCEHLAOD.FDDIKJOMBIO_NamespaceForSave;
    }

	// RVA: 0x1BA9200 Offset: 0x1BA9200 VA: 0x1BA9200 Slot: 18
	public long DPKGNBIAFDO_GetUpdatedAt()
    {
        return NFEAMMJIMPG.LPJIIDJJKOE_UpdatedAt;
    }

	// RVA: 0x1BA9224 Offset: 0x1BA9224 VA: 0x1BA9224 Slot: 19
	public int JNFCOPCBHAP_GetDataStatus()
    {
        return NFEAMMJIMPG.ICEMJDBBDMG_DataStatus;
    }
}
