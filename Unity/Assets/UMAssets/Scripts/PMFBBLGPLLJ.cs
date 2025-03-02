
using System.Collections.Generic;
using XeSys;

public class IHGLIHBAOII
{
	private const int FBGGEFFJJHB = 625060239; //0x2541a98f
	private const sbyte JFOFMKBJBBE_False = 19; // 0x13
	private const sbyte CNECJGKECHK_True = 87; // 0x57
	public int BHFNCIIKDDO_Crypted = FBGGEFFJJHB; // 0x8
	public int IOIPGANODIC_Crypted = FBGGEFFJJHB; // 0xC
	public string GJILKONKOCI = ""; // 0x10
	public int PCDEGCBOCNM_Crypted = FBGGEFFJJHB; // 0x14
	public int EBPEHCGLLJF_Crypted = FBGGEFFJJHB; // 0x18
	public int PMJDAJHAOEM_Crypted = FBGGEFFJJHB; // 0x1C
	public sbyte HNPAGJCFKMA_Crypted = JFOFMKBJBBE_False; // 0x20

	public int AIMCAJDBNOI { get { return BHFNCIIKDDO_Crypted ^ FBGGEFFJJHB; } set { BHFNCIIKDDO_Crypted = value ^ FBGGEFFJJHB; } } //0x11FC348 DCNBOEMCLPE 0x11FC35C JIEOEFLMDFK
	public int GIDPPGJPOJA { get { return IOIPGANODIC_Crypted ^ FBGGEFFJJHB; } set { IOIPGANODIC_Crypted = value ^ FBGGEFFJJHB; } } //0x11FC370 PEBDJENFIDJ 0x11FC384 JEHNBAKGJHE
	public int JGIJGANFCPG_EmblemId { get { return PCDEGCBOCNM_Crypted ^ FBGGEFFJJHB; } set { PCDEGCBOCNM_Crypted = value ^ FBGGEFFJJHB; } } //0x11FC398 ICCHBANCEBH 0x11FC3AC FLDFMMABAMM
	public int PMNGBEJMECI_Score { get { return EBPEHCGLLJF_Crypted ^ FBGGEFFJJHB; } set { EBPEHCGLLJF_Crypted = value ^ FBGGEFFJJHB; } } //0x11FC3C0 BPDJJDLMOEC 0x11FC3D4 BLEPEPOPHNK
	public int MDPKLNFFDBO_EmblemId { get { return PMJDAJHAOEM_Crypted ^ FBGGEFFJJHB; } set { PMJDAJHAOEM_Crypted = value ^ FBGGEFFJJHB; } } //0x11FC3E8 LBEKGEJLADI 0x11FC3FC MAAHDBCNMBJ
	public bool MNAKKLEJBFG_IsUnlocked { get { return HNPAGJCFKMA_Crypted == CNECJGKECHK_True; } set { HNPAGJCFKMA_Crypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x11FC410 BFLKKAPJAFF 0x11FC424 AIEMFLPLOFI
	public IHGLIHBAOII JFLOBDBGIKL { get; set; }  // 0x24 FCMKIKIACPD OKBILGABBCA OFLOBHDGPIP

	// // RVA: 0x11FC464 Offset: 0x11FC464 VA: 0x11FC464
	public void KHEKNNFCAOI(int PPFNGGCBJKC)
    {
        AIMCAJDBNOI = PPFNGGCBJKC;
        GIDPPGJPOJA = PPFNGGCBJKC;
        GJILKONKOCI = "";
        JGIJGANFCPG_EmblemId = 0;
        MNAKKLEJBFG_IsUnlocked = false;
        PMNGBEJMECI_Score = 0;
        MDPKLNFFDBO_EmblemId = 0;
        JFLOBDBGIKL = null;
    }
}

public class PMFBBLGPLLJ
{
	private const int FBGGEFFJJHB = 625060239; // 0x2541a98f
	private List<IHGLIHBAOII> OEKFKJHGMME; // 0x8
	public int NJAFPPNLEML_Crypted = FBGGEFFJJHB ^ 1; // 0xC

	public int JAKOAOFBPIB { get { return NJAFPPNLEML_Crypted ^ 0x2541a98f; } set { NJAFPPNLEML_Crypted = value ^ 0x2541a98f; } } //0xFEE100 GCKMHNLGBFM 0xFEE114 ENFGFKNDEEG

	// // RVA: 0xFEE128 Offset: 0xFEE128 VA: 0xFEE128
	public void KHEKNNFCAOI()
    {
        OEKFKJHGMME = new List<IHGLIHBAOII>();
        OEKFKJHGMME.Clear();
        HAEDCCLHEMN_EventBattle ev = OEGDCBLNNFF();
        if(ev != null)
        {
            DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI);
            if(db != null)
            {
                ICFLJACCIKF_EventBattle dbSection = db as ICFLJACCIKF_EventBattle;
                if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
                {
                    int v = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu;
                    IHGLIHBAOII p = null;
                    for(int i = 0; i < dbSection.PMJLEPGCAOA_ClassDatas.Count; i++)
                    {
                        if(dbSection.PMJLEPGCAOA_ClassDatas[i].PLALNIIBLOF_Enabled == 2)
                        {
                            IHGLIHBAOII data = new IHGLIHBAOII();
                            data.KHEKNNFCAOI(i + 1);
                            data.JGIJGANFCPG_EmblemId = dbSection.PMJLEPGCAOA_ClassDatas[i].APGKOJKNNGP_EmblemId;
                            data.GJILKONKOCI = JBDBLNJCHPC(dbSection.PMJLEPGCAOA_ClassDatas[i].PPFNGGCBJKC_Id);
                            data.PMNGBEJMECI_Score = dbSection.PMJLEPGCAOA_ClassDatas[i].AFKHNFBOMKI_Sc;
                            data.MNAKKLEJBFG_IsUnlocked = dbSection.PMJLEPGCAOA_ClassDatas[i].PPFNGGCBJKC_Id <= v;
                            data.MDPKLNFFDBO_EmblemId = dbSection.PMJLEPGCAOA_ClassDatas[i].APGKOJKNNGP_EmblemId;
                            data.JFLOBDBGIKL = p;
                            OEKFKJHGMME.Add(data);
                            p = data;
                        }
                    }
                    OEKFKJHGMME.Sort((IHGLIHBAOII HKICMNAACDA, IHGLIHBAOII BNKHBCBJBKI) =>
                    {
                        //0xFEF988
                        return HKICMNAACDA.GIDPPGJPOJA.CompareTo(BNKHBCBJBKI.GIDPPGJPOJA);
                    });
                    NJAFPPNLEML_Crypted = OEKFKJHGMME[OEKFKJHGMME.Count - 1].AIMCAJDBNOI;
                }
            }
        }
    }

	// // RVA: 0xFEE894 Offset: 0xFEE894 VA: 0xFEE894
	private HAEDCCLHEMN_EventBattle OEGDCBLNNFF()
    {
        if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB !=  null)
        {
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9);
            if (ev != null)
            {
                return ev as HAEDCCLHEMN_EventBattle;
            }
        }
        return null;
    }

	// // RVA: 0xFEE12C Offset: 0xFEE12C VA: 0xFEE12C
	// public void FBANBDCOEJL() { }

	// // RVA: 0xFEEB74 Offset: 0xFEEB74 VA: 0xFEEB74
	public List<IHGLIHBAOII> KBHCHFDAHGL()
    {
        List<IHGLIHBAOII> res = new List<IHGLIHBAOII>();
        res.Clear();
        if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
        {
            int v = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CPAGIICKKNN_EvBtlClsu + 1;
            if(JAKOAOFBPIB < v)
                v = JAKOAOFBPIB;
            for(int i = 0; i < OEKFKJHGMME.Count; i++)
            {
                if(OEKFKJHGMME[i].GIDPPGJPOJA <= v)
                {
                    res.Add(OEKFKJHGMME[i]);
                }
            }
            res.Sort((IHGLIHBAOII HKICMNAACDA, IHGLIHBAOII BNKHBCBJBKI) =>
            {
                //0xFEF9F8
                return HKICMNAACDA.GIDPPGJPOJA.CompareTo(BNKHBCBJBKI.GIDPPGJPOJA);
            });
        }
        return res;
    }

	// // RVA: 0xFEEEE8 Offset: 0xFEEEE8 VA: 0xFEEEE8
	public bool KKCEHCKLDCI_HasEmblem(int GIDPPGJPOJA)
    {
        if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
        {
            if(GIDPPGJPOJA > 0 && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
            {
                if(GIDPPGJPOJA <= OEKFKJHGMME.Count )
                {
                    return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, OEKFKJHGMME[GIDPPGJPOJA - 1].JGIJGANFCPG_EmblemId, null) > 0;
                }
            }
        }
        return false;
    }

	// // RVA: 0xFEF0F0 Offset: 0xFEF0F0 VA: 0xFEF0F0
	public List<IHGLIHBAOII> LHDNIHOAMFH(int NEMIKPCPOJJ/* = 0*/, int BEKOEJJIKJF/* = 0*/)
    {
        List<IHGLIHBAOII> res = new List<IHGLIHBAOII>();
        res.Clear();
        HAEDCCLHEMN_EventBattle ev = OEGDCBLNNFF();
        if(ev != null)
        {
            int v = ev.KDDELPFLCEB_GetClsu0();
            if(v == -1)
                return null;
            if(v == 0)
                return res;
            int v2 = ev.DAHNCPDEBDM_GetEvBltClassUnlocked();
            if(v2 == -1)
                return null;
            if(v2 == 0)
                return res;
            int v3 = ev.KDDELPFLCEB_GetClsu0();
            if(v3 == 0)
                return res;
            ev.LFBCNAAKHCK_ResetClsu0();
            v3 = ev.CJOBENJJCLD();
            if(v2 <= v && v2 < v3)
                return res;
            for(int i = 0; i < OEKFKJHGMME.Count; i++)
            {
                int v4 = OEKFKJHGMME[i].GIDPPGJPOJA;
                if(v <= v4 && v4 <= v2)
                {
                    res.Add(OEKFKJHGMME[i]);
                }
            }
            if(v3 <= v2)
            {
                if(v != v2 && ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore < ev.HOJNMALLCME_GetClassMaxScore(3, v2))
                {
                    ;
                }
                else
                {
                    res.Add(OEKFKJHGMME[OEKFKJHGMME.Count - 1]);
                }
            }
            res.Sort((IHGLIHBAOII HKICMNAACDA, IHGLIHBAOII BNKHBCBJBKI) =>
            {
                //0xFEFA68
                return HKICMNAACDA.GIDPPGJPOJA.CompareTo(BNKHBCBJBKI.GIDPPGJPOJA);
            });
            return res;
        }
        return null;
    }

	// // RVA: 0xFEE9D4 Offset: 0xFEE9D4 VA: 0xFEE9D4
	public string JBDBLNJCHPC(int PPFNGGCBJKC)
    {
        HAEDCCLHEMN_EventBattle ev = OEGDCBLNNFF();
        if(ev != null)
        {
            string str = "";
            if(ev.JOPOPMLFINI == "event_battle_a")
            {
                str = "btla_cls_";
            }
            else if(ev.JOPOPMLFINI == "event_battle_b")
            {
                str = "btlb_cls_";
            }
            else if(ev.JOPOPMLFINI == "event_battle_c")
            {
                str = "btlc_cls_";
            }
            return MessageManager.Instance.GetMessage("master", str + PPFNGGCBJKC.ToString("D4"));
        }
        return "";
    }

	// // RVA: 0xFEF564 Offset: 0xFEF564 VA: 0xFEF564
	public bool BKIGJNDEEKI(BBHNACPENDM_ServerSaveData LDEGEHAEALK, int KIJAPOFAGPN, int HMFFHLPNMPH, int BGJDHCEOIDB)
    {
        JKNGJFOBADP data = new JKNGJFOBADP();
        data.JCHLONCMPAJ();
        data.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IOBDJDHJJFK_22, "class : "+"???");
        TodoLogger.LogError(TodoLogger.ToCheck, "string end id ??");
        data.CPIICACGNBH(LDEGEHAEALK, KIJAPOFAGPN, HMFFHLPNMPH, null, 0);
        return false;
    }

	// // RVA: 0xFEF694 Offset: 0xFEF694 VA: 0xFEF694
	public bool EBEKAEJHIJH(int JOJELMJHHEJ, int HAMPAIFPBPK)
    {
        HAEDCCLHEMN_EventBattle ev = OEGDCBLNNFF();
        if(ev != null)
        {
            if(HAMPAIFPBPK != 0 && (HAMPAIFPBPK != -1 && JOJELMJHHEJ != 0) && JOJELMJHHEJ != -1)
            {
                if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
                {
                    for(int i = 0; i < OEKFKJHGMME.Count; i++)
                    {
                        if(JOJELMJHHEJ <= OEKFKJHGMME[i].GIDPPGJPOJA && OEKFKJHGMME[i].GIDPPGJPOJA <= HAMPAIFPBPK)
                        {
                            if(!KKCEHCKLDCI_HasEmblem(OEKFKJHGMME[i].GIDPPGJPOJA))
                            {
                                BKIGJNDEEKI(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, OEKFKJHGMME[i].JGIJGANFCPG_EmblemId), 1, OEKFKJHGMME[i].GIDPPGJPOJA);
                            }
                        }
                    }
                    return true;
                }
            }
        }
        return false;
    }
}
