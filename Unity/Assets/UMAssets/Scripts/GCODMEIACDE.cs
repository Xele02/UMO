
using System.Collections.Generic;
using UnityEngine;

public class GCODMEIACDE
{
    public class PKJINGDIFNG
    {
        public int KIJAPOFAGPN_ItemId; // 0x8
        public int DNBFMLBNAEE_Point; // 0xC
        public int HMFFHLPNMPH_Cnt; // 0x10
        public int AHOKAPCGJMA_TargetNum; // 0x14
    }

	public int PLKMAOGKFPP; // 0x8
	public int FPEOGFMKMKJ; // 0xC
	public int ANOCILKJGOJ_EpBonus; // 0x10
	public int ODCLHPGHDHA_EpBonusMulti; // 0x14
	public int OKBEOCOKGEI; // 0x18
	public int PHPANNCGOKC_GetPoint; // 0x1C
	public int HNNAJJNMCKE_PrevPoint; // 0x20
	public int AHOKAPCGJMA_NewPoint; // 0x24
	public int BEOKMNIPFBA_MedalItemId; // 0x28
	public int ODOOKDGCKMF_MedalNum; // 0x2C
	public int[] BKKPKIGLMCN_Ranks = new int[2]; // 0x30
	public int KHHPEIBPDAB; // 0x34
	public int BFPBEAIBEDJ; // 0x38
	public int IJPAKGFADJB_HiScore; // 0x3C
	public bool GIIKOMPJOHA_IsHiScore; // 0x40
	public int OENBOLPDBAB_FreeMusicId; // 0x44
	public List<PKJINGDIFNG> HBHMAKNGKFK = new List<PKJINGDIFNG>(); // 0x48

	// RVA: 0x16B4404 Offset: 0x16B4404 VA: 0x16B4404
	public void KHEKNNFCAOI()
    {
        HJNNLPIGHLM_EventCollection ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(JGEOBNENMAH.HHCJCDFCLOB.JKEPHFPCKMD_EventId) as HJNNLPIGHLM_EventCollection;
        if(ev == null)
        {
            OKBEOCOKGEI = 1;
            return;
        }
        FPEOGFMKMKJ = ev.EELENPNCGLM.FPEOGFMKMKJ;
        ANOCILKJGOJ_EpBonus = ev.EELENPNCGLM.ANOCILKJGOJ;
        ODCLHPGHDHA_EpBonusMulti = ev.EELENPNCGLM.ODCLHPGHDHA;
        PHPANNCGOKC_GetPoint = ev.EELENPNCGLM.PIIEGNPOPJI_GetPoint;
        OKBEOCOKGEI = ev.EELENPNCGLM.FCLGIPFPIPH;
        HNNAJJNMCKE_PrevPoint = JGEOBNENMAH.HHCJCDFCLOB.FFDBCEDKMGN_PrevPoint;
        AHOKAPCGJMA_NewPoint = JGEOBNENMAH.HHCJCDFCLOB.MMLPAMGJEOD_NewPoint;
        OENBOLPDBAB_FreeMusicId = ev.EELENPNCGLM.OENBOLPDBAB;
        KHHPEIBPDAB = ev.EELENPNCGLM.GCAPLLEIAAI_NewScore;
        BFPBEAIBEDJ = ev.EELENPNCGLM.IDCFOMMKGIK;
        IJPAKGFADJB_HiScore = ev.EELENPNCGLM.LPGNCOFHOPK_SaveScore;
        GIIKOMPJOHA_IsHiScore = ev.EELENPNCGLM.GIIKOMPJOHA;
        if(BKKPKIGLMCN_Ranks == null)
            BKKPKIGLMCN_Ranks = new int[2];
        BKKPKIGLMCN_Ranks[0] = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[0];
        BKKPKIGLMCN_Ranks[1] = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[1];
        PLKMAOGKFPP = 0;
        HBHMAKNGKFK.Clear();
        for(int i = 0; i < 3; i++)
        {
            if(JGEOBNENMAH.HHCJCDFCLOB.JCDPLILNKDG[i] != 0)
            {
                HGLPLKKBBOL_EventItem.JMCDEDCMCJE it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA[JGEOBNENMAH.HHCJCDFCLOB.JCDPLILNKDG[i] - 1];
                PKJINGDIFNG d = new PKJINGDIFNG();
                d.KIJAPOFAGPN_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem, JGEOBNENMAH.HHCJCDFCLOB.JCDPLILNKDG[i]);
                d.DNBFMLBNAEE_Point = it.JBGEEPFKIGG_Val;
                d.HMFFHLPNMPH_Cnt = JGEOBNENMAH.HHCJCDFCLOB.CMCDIOOEHMI[i];
                d.AHOKAPCGJMA_TargetNum = d.DNBFMLBNAEE_Point * d.HMFFHLPNMPH_Cnt;
                Debug.Log(string.Concat(new object[8]
                {
                    "StringLiteral_10444",
                    d.KIJAPOFAGPN_ItemId,
                    ",",
                    it.JBGEEPFKIGG_Val,
                    " x ",
                    d.HMFFHLPNMPH_Cnt,
                    "=",
                    d.AHOKAPCGJMA_TargetNum
                }));
                HBHMAKNGKFK.Add(d);
                PLKMAOGKFPP += d.HMFFHLPNMPH_Cnt;
            }
        }
        BEOKMNIPFBA_MedalItemId = JGEOBNENMAH.HHCJCDFCLOB.BEOKMNIPFBA_MedalItemId;
        ODOOKDGCKMF_MedalNum = OKBEOCOKGEI * JGEOBNENMAH.HHCJCDFCLOB.ODOOKDGCKMF_MedalNum;
    }

	// // RVA: 0x16B4F58 Offset: 0x16B4F58 VA: 0x16B4F58
	// public void NFOHOGAJGHB() { }
}
