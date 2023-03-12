
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Gacha;
using XeSys;

public class HBCPJANGOLB
{
	private static List<HGBOODNMNFM> MNJNCKPELGE = new List<HGBOODNMNFM>(); // 0x0
	private static ELFECIBLHGM KKEFACGGKOD = new ELFECIBLHGM(); // 0x4

	// // RVA: 0x173D674 Offset: 0x173D674 VA: 0x173D674
	public void OBKGEDCKHHE()
    {
        KKEFACGGKOD.PCODDPDFLHK();
        MNJNCKPELGE.Clear();
        long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
        long t2 = JPAICCMDGHD_GetMaxLastShowDate(time);
        List<LOBDIAABMKG> l = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.MHKCPJDNJKI_GatchaProducts;
        long date = -1;
        for(int i = 0; i < l.Count; i++)
        {
            long t = GachaUtility.GetGachaProductOpenTime(l[i]);
            TodoLogger.Log(TodoLogger.ToCheck, "int64 check");
            if(t2 >= time)
            {
                for(int j = 0; j < l[i].KACECFNECON.NNDMIOEKKMM.Count; j++)
                {
                    MNJNCKPELGE.Add(l[i].KACECFNECON.NNDMIOEKKMM[j]);
                }
                TodoLogger.Log(TodoLogger.ToCheck, "int64 check");
                if(t < date && MNJNCKPELGE.Count > 0)
                    date = t;
            }
        }
        if(date >= 0)
        {
            KKEFACGGKOD.JKHNJBFAFBL_SetLastShowDate(date);
        }
        if(MNJNCKPELGE.Count < 2)
        {
            return;
        }
        MNJNCKPELGE.Sort((HGBOODNMNFM HKICMNAACDA, HGBOODNMNFM BNKHBCBJBKI) => {
            //0x173EEC0
            return HKICMNAACDA.KELFCMEOPPM_EpisodeId.CompareTo(BNKHBCBJBKI.KELFCMEOPPM_EpisodeId);
        });
    }

	// // RVA: 0x173DF38 Offset: 0x173DF38 VA: 0x173DF38
	public List<HGBOODNMNFM> DJOMLJELOLM()
    {
        return MNJNCKPELGE;
    }

	// // RVA: 0x173DD7C Offset: 0x173DD7C VA: 0x173DD7C
	public long JPAICCMDGHD_GetMaxLastShowDate(long JHNMKKNEENE)
    {
        long lastEpTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MOBHLLDIMMN_EpisodeLastShowTime;
        long t2 = KKEFACGGKOD.HFPEDBCGFOJ_GetLastShowDate();
        long m = System.Math.Max(lastEpTime, t2);
        TodoLogger.Log(TodoLogger.ToCheck, "Int64 check");
        if(JHNMKKNEENE > m)
            return 0;
        return m;
    }

	// // RVA: 0x173DFC4 Offset: 0x173DFC4 VA: 0x173DFC4
	// public bool HJMKBCFJOOH() { }

	// // RVA: 0x173E200 Offset: 0x173E200 VA: 0x173E200
	public static List<string> LMFHAGHJIEM_GetAssetsList(HBCPJANGOLB IDLHJIOMJBK)
    {
        StringBuilder str = new StringBuilder(64);
        MLIBEPGADJH_Scene dbScenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
        List<string> res = new List<string>();
        List<HGBOODNMNFM> l = IDLHJIOMJBK.DJOMLJELOLM();
        for(int i = 0; i < l.Count; i++)
        {
            KBNDEEFOGMO_FillEpisodeAssetsFile(res, l[i].KELFCMEOPPM_EpisodeId);
            for(int j = 0; j < l[i].ADDCEJNOJLG_Scenes.Count; j++)
            {
                str.SetFormat("ct/sc/me/02_2/{0:D6}_{1:D2}.xab", l[i].ADDCEJNOJLG_Scenes[j].DNJEJEANJGL_Value, 1);
                res.Add(str.ToString());
                if(dbScenes.CDENCMNHNGA_SceneList[l[i].ADDCEJNOJLG_Scenes[j].DNJEJEANJGL_Value - 1].EKLIPGELKCL_Rarity > 3)
                {
                    str.SetFormat("ct/sc/me/02_2/{0:D6}_{1:D2}.xab", l[i].ADDCEJNOJLG_Scenes[j].DNJEJEANJGL_Value, 2);
                    res.Add(str.ToString());
                }
            }
        }
        return res;
    }

	// // RVA: 0x173E7A8 Offset: 0x173E7A8 VA: 0x173E7A8
	private static void KBNDEEFOGMO_FillEpisodeAssetsFile(List<string> PHCEFKKOECA, int KELFCMEOPPM)
    {
        List<LGMEPLIJLNB> l = LGMEPLIJLNB.FKDIMODKKJD_GetEpisodeRewards(KELFCMEOPPM);
        LCLCCHLDNHJ_Costume dbCostumes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
        for(int i = 0; i < l.Count; i++)
        {
            if(l[i].GOOIIPFHOIG.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume)
            {
                if(l[i].GOOIIPFHOIG != null)
                {
                    for(int j = 0; j < dbCostumes.CDENCMNHNGA_Costumes.Count; j++)
                    {
                        if(dbCostumes.CDENCMNHNGA_Costumes[j].JPIDIENBGKH_CostumeId == l[i].GOOIIPFHOIG.NNFNGLJOKKF_ItemId)
                        {
                            int id = dbCostumes.CDENCMNHNGA_Costumes[j].AHHJLDLAPAN_PrismDivaId;
                            int id2 = dbCostumes.CDENCMNHNGA_Costumes[j].DAJGPBLEEOB_PrismCostumeModelId;
                            PHCEFKKOECA.Add(string.Format("dv/cs/{0:D3}_{1:D3}.xab", id, id2));
                            PHCEFKKOECA.Add(string.Format("ct/dv/co/{0:D2}_{1:D3}.xab", id, id2));
                            PHCEFKKOECA.Add(string.Format("ct/dv/me/01/{0:D2}_{1:D2}.xab", id, id2));
                            PHCEFKKOECA.Add(string.Format("snd/vo/diva/cs_apl_diva_{0:D3}" + ".awb", id));
                            PHCEFKKOECA.Add(string.Format("snd/vo/diva/cs_apl_diva_{0:D3}" + ".acb", id));
                        }
                    }
                    return;
                }
            }
        }
    }
}
