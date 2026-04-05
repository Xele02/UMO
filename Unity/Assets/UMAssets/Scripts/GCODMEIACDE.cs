
using System.Collections.Generic;
using UnityEngine;

public class GCODMEIACDE
{
    public class PKJINGDIFNG
    {
        public int KIJAPOFAGPN_ItemId; // 0x8
        public int DNBFMLBNAEE_point; // 0xC
        public int HMFFHLPNMPH_count; // 0x10
        public int AHOKAPCGJMA_TotalPoint; // 0x14
    }

	public int PLKMAOGKFPP; // 0x8
	public int FPEOGFMKMKJ_Point; // 0xC
	public int ANOCILKJGOJ_EpisodeCnt; // 0x10
	public int ODCLHPGHDHA_EpisodeBonus; // 0x14
	public int OKBEOCOKGEI; // 0x18
	public int PHPANNCGOKC_GetPoint; // 0x1C
	public int HNNAJJNMCKE_PrevPoint; // 0x20
	public int AHOKAPCGJMA_TotalPoint; // 0x24
	public int BEOKMNIPFBA_MedalItemId; // 0x28
	public int ODOOKDGCKMF_MedalNum; // 0x2C
	public int[] BKKPKIGLMCN_Ranks = new int[2]; // 0x30
	public int KHHPEIBPDAB; // 0x34
	public int BFPBEAIBEDJ; // 0x38
	public int IJPAKGFADJB_HiScore; // 0x3C
	public bool GIIKOMPJOHA_IsHiScore; // 0x40
	public int OENBOLPDBAB_FreeMusicId; // 0x44
	public List<PKJINGDIFNG> HBHMAKNGKFK_items = new List<PKJINGDIFNG>(); // 0x48

	// RVA: 0x16B4404 Offset: 0x16B4404 VA: 0x16B4404
	public void KHEKNNFCAOI_Init()
    {
        HJNNLPIGHLM_NetEventCollectionController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OIKOHACJPCB_GetEventById(JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.JKEPHFPCKMD_EventId) as HJNNLPIGHLM_NetEventCollectionController;
        if(ev == null)
        {
            OKBEOCOKGEI = 1;
            return;
        }
        FPEOGFMKMKJ_Point = ev.EELENPNCGLM.FPEOGFMKMKJ_Point;
        ANOCILKJGOJ_EpisodeCnt = ev.EELENPNCGLM.ANOCILKJGOJ_EpisodeCnt;
        ODCLHPGHDHA_EpisodeBonus = ev.EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus;
        PHPANNCGOKC_GetPoint = ev.EELENPNCGLM.PIIEGNPOPJI_GetPoint;
        OKBEOCOKGEI = ev.EELENPNCGLM.FCLGIPFPIPH_DashBonus;
        HNNAJJNMCKE_PrevPoint = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.FFDBCEDKMGN_PrevPoint;
        AHOKAPCGJMA_TotalPoint = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.MMLPAMGJEOD_NewPoint;
        OENBOLPDBAB_FreeMusicId = ev.EELENPNCGLM.OENBOLPDBAB_FreeMusicId;
        KHHPEIBPDAB = ev.EELENPNCGLM.GCAPLLEIAAI_LastScore;
        BFPBEAIBEDJ = ev.EELENPNCGLM.IDCFOMMKGIK;
        IJPAKGFADJB_HiScore = ev.EELENPNCGLM.LPGNCOFHOPK_SaveScore;
        GIIKOMPJOHA_IsHiScore = ev.EELENPNCGLM.GIIKOMPJOHA_IsHiScore;
        if(BKKPKIGLMCN_Ranks == null)
            BKKPKIGLMCN_Ranks = new int[2];
        BKKPKIGLMCN_Ranks[0] = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.NEFFKLNAAJI_ScoreRankByDiva[0];
        BKKPKIGLMCN_Ranks[1] = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.NEFFKLNAAJI_ScoreRankByDiva[1];
        PLKMAOGKFPP = 0;
        HBHMAKNGKFK_items.Clear();
        for(int i = 0; i < 3; i++)
        {
            if(JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.JCDPLILNKDG[i] != 0)
            {
                HGLPLKKBBOL_EventItem.JMCDEDCMCJE it = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.JCDPLILNKDG[i] - 1];
                PKJINGDIFNG d = new PKJINGDIFNG();
                d.KIJAPOFAGPN_ItemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem, JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.JCDPLILNKDG[i]);
                d.DNBFMLBNAEE_point = it.JBGEEPFKIGG_val;
                d.HMFFHLPNMPH_count = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.CMCDIOOEHMI[i];
                d.AHOKAPCGJMA_TotalPoint = d.DNBFMLBNAEE_point * d.HMFFHLPNMPH_count;
                Debug.Log(string.Concat(new object[8]
                {
                    "StringLiteral_10444",
                    d.KIJAPOFAGPN_ItemId,
                    ",",
                    it.JBGEEPFKIGG_val,
                    " x ",
                    d.HMFFHLPNMPH_count,
                    "=",
                    d.AHOKAPCGJMA_TotalPoint
                }));
                HBHMAKNGKFK_items.Add(d);
                PLKMAOGKFPP += d.HMFFHLPNMPH_count;
            }
        }
        BEOKMNIPFBA_MedalItemId = JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.BEOKMNIPFBA_MedalItemId;
        ODOOKDGCKMF_MedalNum = OKBEOCOKGEI * JGEOBNENMAH_NetGameManager.HHCJCDFCLOB_Instance.ODOOKDGCKMF_MedalNum;
    }

	// // RVA: 0x16B4F58 Offset: 0x16B4F58 VA: 0x16B4F58
	// public void NFOHOGAJGHB() { }
}
