
using System.Collections.Generic;
using XeApp.Game.Common;

public class FAGCLBOACEE
{
    public enum BEFPBAIONFK
    {
        HJNNKCMLGFL = 0,
        KDGLIKDMGCN = 1,
        CELONIBHMBA = 2,
        EOBDILOCCHO = 3,
        FCHMGAHKMLG = 4,
        OPPDJDDHHFM = 5,
        AJPJOJNIHKH = 6,
        KHBEKPMMALI = 7,
    }

    public class MFHPNBOLPAO
    {
        public BEFPBAIONFK DEPGBBJMFED; // 0x8
        public Difficulty.Type AKNELONELJK; // 0xC
        public bool GIKLNODJKFK; // 0x10
    }

	public BEFPBAIONFK DEPGBBJMFED; // 0x8
	public int PPFNGGCBJKC; // 0xC
	public int AKNELONELJK; // 0x10
	public bool GIKLNODJKFK_6Line; // 0x14

	// // RVA: 0xFC1A40 Offset: 0xFC1A40 VA: 0xFC1A40
	public void KHEKNNFCAOI(BEFPBAIONFK DEPGBBJMFED, int PPFNGGCBJKC, int AKNELONELJK = 0, bool GIKLNODJKFK = false)
    {
        this.DEPGBBJMFED = DEPGBBJMFED;
        int id = 0;
        switch(DEPGBBJMFED)
        {
            case BEFPBAIONFK.KDGLIKDMGCN/*1*/:
                TodoLogger.Log(0, "KHEKNNFCAOI 1");
                break;
            case BEFPBAIONFK.CELONIBHMBA/*2*/:
            case BEFPBAIONFK.FCHMGAHKMLG/*4*/:
            case BEFPBAIONFK.OPPDJDDHHFM/*5*/:
				id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(PPFNGGCBJKC).DLAEJOBELBH_MusicId;
				break;
            case BEFPBAIONFK.EOBDILOCCHO/*3*/:
                TodoLogger.Log(0, "KHEKNNFCAOI 3");
                break;
            case BEFPBAIONFK.AJPJOJNIHKH/*6*/:
                TodoLogger.Log(0, "KHEKNNFCAOI 6");
                break;
            case BEFPBAIONFK.KHBEKPMMALI/*7*/:
                TodoLogger.Log(0, "KHEKNNFCAOI 7");
                break;
            default:
                return;
        }
        this.PPFNGGCBJKC = id;
        this.AKNELONELJK = AKNELONELJK;
        this.GIKLNODJKFK_6Line = GIKLNODJKFK;
    }

	// // RVA: 0xFC1EE8 Offset: 0xFC1EE8 VA: 0xFC1EE8
	// public static List<FAGCLBOACEE> ECKKHOCALEE() { }

	// // RVA: 0xFC2314 Offset: 0xFC2314 VA: 0xFC2314
	public static List<FAGCLBOACEE> ICBFAFNOHIB(int IJEKNCDIIAE)
	{
		List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
		LPPGENBEECK_MusicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		List<LAEGMENIEDB_Story.ALGOILKGAAH> mList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA;
		for(int i = 0; i < dbMusic.GEAANLPDJBP_FreeMusicDatas.Count; i++)
		{
			KEODKEGFDLD_FreeMusicInfo fData = dbMusic.GEAANLPDJBP_FreeMusicDatas[i];
			if(fData.PPEGAKEIEGM_Enabled == 2)
			{
				if(fData.DEPGBBJMFED_CategoryId != 5)
				{
					if(fData.IJEKNCDIIAE > 1)
					{
						if(IJEKNCDIIAE < fData.IJEKNCDIIAE)
						{
							int BPFBEOEFKMA = fData.GHBPLHBNMBK_FreeMusicId;
							int idx = mList.FindIndex((LAEGMENIEDB_Story.ALGOILKGAAH GHPLINIACBB) =>
							{
								//0xFC5950
								return GHPLINIACBB.OMMEPCGNHFM == BPFBEOEFKMA;
							});
							if(idx < 0)
							{
								JPCKBFBCJKD mData = dbMusic.LLJOPJMIGPD(BPFBEOEFKMA);
								if(mData == null)
								{
									FAGCLBOACEE data = new FAGCLBOACEE();
									data.KHEKNNFCAOI(BEFPBAIONFK.CELONIBHMBA/*2*/, fData.GHBPLHBNMBK_FreeMusicId, 0, false);
									res.Add(data);
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xFC293C Offset: 0xFC293C VA: 0xFC293C
	public static List<FAGCLBOACEE> GGGOIINDGMI()
	{
		List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
		LPPGENBEECK_MusicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
		List<LAEGMENIEDB_Story.ALGOILKGAAH> dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA;
		for(int i = 0; i < dbMusic.GEAANLPDJBP_FreeMusicDatas.Count; i++)
		{
			KEODKEGFDLD_FreeMusicInfo fData = dbMusic.GEAANLPDJBP_FreeMusicDatas[i];
			if (fData.PPEGAKEIEGM_Enabled == 2)
			{
				int BPFBEOEFKMA = fData.GHBPLHBNMBK_FreeMusicId;
				int idx = dbStory.FindIndex((LAEGMENIEDB_Story.ALGOILKGAAH GHPLINIACBB) =>
				{
					//0xFC5994
					return GHPLINIACBB.OMMEPCGNHFM == BPFBEOEFKMA;
				});
				if(idx > 0)
				{
					JPCKBFBCJKD mData = dbMusic.LLJOPJMIGPD(BPFBEOEFKMA);
					if(mData != null)
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.EOHHFADHHBL)
						{
							if(dbMusic.IAAMKEJKPPL(mData, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level))
							{
								if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[BPFBEOEFKMA - 1].DMANHOPOBMP_IsShowUnlock)
								{
									CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[BPFBEOEFKMA - 1].DMANHOPOBMP_IsShowUnlock = true;
									FAGCLBOACEE data = new FAGCLBOACEE();
									data.KHEKNNFCAOI(BEFPBAIONFK.CELONIBHMBA/*2*/, BPFBEOEFKMA, 0, false);
									res.Add(data);
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xFC2FB8 Offset: 0xFC2FB8 VA: 0xFC2FB8
	public static List<FAGCLBOACEE> OGGDOPACJOB()
    {
        List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
        List<LAEGMENIEDB_Story.ALGOILKGAAH> dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA;
        List<NEKDCJKANAH_StoryRecord.HKDNILFKCFC> saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH;
        LPPGENBEECK_MusicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
        List<LIEJFHMGNIA> l = LIEJFHMGNIA.FKDIMODKKJD(LIEJFHMGNIA.PJIJLMFBBCJ() - 1, true, true, false);
        for(int i = 0; i < l.Count; i++)
        {
			if (!l[i].BCGLDMKODLC)
			{
				if(l[i].DHPNLACAGPG)
				{
					if((saveStory[l[i].LFLLLOPAKCO - 1].OKJMIFELDMD_Opn & 4) == 0 || saveStory[l[i].LFLLLOPAKCO - 1].HCENOJKNCMK)
					{
						FAGCLBOACEE data = new FAGCLBOACEE();
						int divaId = l[i].AHHJLDLAPAN;
						data.KHEKNNFCAOI(divaId < 1 ? BEFPBAIONFK.KDGLIKDMGCN/*1*/ : BEFPBAIONFK.EOBDILOCCHO/*3*/, divaId < 1 ? l[i].KLCIIHKFPPO : l[i].LFLLLOPAKCO, 0, false);
						res.Add(data);
						saveStory[l[i].LFLLLOPAKCO].HCENOJKNCMK = false;
						saveStory[l[i].LFLLLOPAKCO].OKJMIFELDMD_Opn |= 4;
						break;
					}
				}
			}
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ENIPGFLGJHH_LastStory > 0)
				{
					LAEGMENIEDB_Story.ALGOILKGAAH dbS = dbStory[i];
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ENIPGFLGJHH_LastStory == dbS.KLCIIHKFPPO)
					{
						FAGCLBOACEE data = new FAGCLBOACEE();
						data.KHEKNNFCAOI(BEFPBAIONFK.CELONIBHMBA/*2*/, dbMusic.NOBCLJIAMLC_GetFreeMusicData(dbS.OMMEPCGNHFM).GHBPLHBNMBK_FreeMusicId, 0, false);
						res.Add(data);
					}
				}
			}
        }
        res.AddRange(KJDIPIAFNEN());
        return res;
    }

	// // RVA: 0xFC3D68 Offset: 0xFC3D68 VA: 0xFC3D68
	public static List<FAGCLBOACEE> JODDIFOOIOJ()
	{
		List<FAGCLBOACEE> res = OGGDOPACJOB();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		List<IBJAKJJICBC> l = new List<IBJAKJJICBC>();
		for(int i = 0; i < 6; i++)
		{
			List<IBJAKJJICBC> list = IBJAKJJICBC.FKDIMODKKJD(i + 1, time, false, false, false, false);
			for(int j = 0; j < list.Count; j++)
			{
				l.Add(list[j]);
			}
		}
		int multi_dance_player_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("multi_dance_player_level", 3);
		int level = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		if(level >= multi_dance_player_level)
		{
			for(int i = 0; i < l.Count; i++)
			{
				KEODKEGFDLD_FreeMusicInfo fInfo = BMBELGEDKEG(l[i].DLAEJOBELBH_MusicId);
				if(fInfo != null && fInfo.BHJNFBDNFEJ)
				{
					if(l[i].EKANGPODCEP_EventId == 0)
					{
						EONOEHOKBEB_Music mData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[l[i].DLAEJOBELBH_MusicId - 1];
						if(mData.PECMGDOMLAF_DivaMulti > 1)
						{
							if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMGKPCIOHHC_AddMusic.CGEPJMFFLLJ(l[i].DLAEJOBELBH_MusicId, mData.PECMGDOMLAF_DivaMulti))
							{
								CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MMGKPCIOHHC_AddMusic.DDCBGCODHHN(l[i].DLAEJOBELBH_MusicId, mData.PECMGDOMLAF_DivaMulti);
								FAGCLBOACEE data = new FAGCLBOACEE();
								data.KHEKNNFCAOI(BEFPBAIONFK.OPPDJDDHHFM/*5*/, l[i].GHBPLHBNMBK_FreeMusicId, 0, false);
								res.Add(data);
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xFC46A4 Offset: 0xFC46A4 VA: 0xFC46A4
	public static List<FAGCLBOACEE> MLHMCCLKALG()
	{
		List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(IBJAKJJICBC.KGJJCAKCMLO())
		{
			List<IBJAKJJICBC> l = new List<IBJAKJJICBC>();
			for (int i = 0; i < 9; i++)
			{
				List<IBJAKJJICBC> l2 = IBJAKJJICBC.FKDIMODKKJD(i + 1, time, false, false, false, true);
				for(int j = 0; j < l2.Count; j++)
				{
					l.Add(l2[j]);
				}
			}
			if(l.Count > 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].EKANGPODCEP_EventId == 0)
					{
						if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NHKPKOPAMNB(l[i].DLAEJOBELBH_MusicId))
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.LIPHECJKIDD(l[i].DLAEJOBELBH_MusicId, true);
							FAGCLBOACEE data = new FAGCLBOACEE();
							data.KHEKNNFCAOI(BEFPBAIONFK.AJPJOJNIHKH/*6*/, l[i].GHBPLHBNMBK_FreeMusicId, 2, true);
							res.Add(data);
							data = new FAGCLBOACEE();
							data.KHEKNNFCAOI(BEFPBAIONFK.AJPJOJNIHKH/*6*/, l[i].GHBPLHBNMBK_FreeMusicId, 3, true);
							res.Add(data);
							data = new FAGCLBOACEE();
							data.KHEKNNFCAOI(BEFPBAIONFK.AJPJOJNIHKH/*6*/, l[i].GHBPLHBNMBK_FreeMusicId, 4, true);
							res.Add(data);
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xFC451C Offset: 0xFC451C VA: 0xFC451C
	public static KEODKEGFDLD_FreeMusicInfo BMBELGEDKEG(int DLAEJOBELBH)
	{
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas.Find((KEODKEGFDLD_FreeMusicInfo GHPLINIACBB) =>
		{
			//0xFC585C
			if(GHPLINIACBB.DLAEJOBELBH_MusicId == DLAEJOBELBH)
			{
				return GHPLINIACBB.DEPGBBJMFED_CategoryId != 5;
			}
			return false;
		});
	}

	// // RVA: 0xFC4CE4 Offset: 0xFC4CE4 VA: 0xFC4CE4
	// private static List<FAGCLBOACEE.MFHPNBOLPAO> OBIJCNGEBOM(EGOLBAPFHHD ENIDMGPGGLI) { }

	// // RVA: 0xFC3720 Offset: 0xFC3720 VA: 0xFC3720
	public static List<FAGCLBOACEE> KJDIPIAFNEN()
    {
        List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
        res.Clear();
        if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KJDDGIMIEDO(LastGameUnlockStatus.LIVE_SKIP_ALL))
            {
                int GHBPLHBNMBK_freeMusicId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.LFCCCLPFJMB_LastFm;
                int diff = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KMIJDPFIFII_LastDf;
                bool is6Line = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KJDDGIMIEDO(LastGameUnlockStatus.TypeBit.LIVE_SKIP_First_6);
                if(GHBPLHBNMBK_freeMusicId > 0)
                {
                    long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                    List<IBJAKJJICBC> d = IBJAKJJICBC.FKDIMODKKJD(-1, time, true, false, false, false);
                    List<IBJAKJJICBC> e = IBJAKJJICBC.FKDIMODKKJD(5, time, true, false, false, false);
                    IBJAKJJICBC d_ = d.Find((IBJAKJJICBC JPAEDJJFFOI) => {
                        //0xFC58C8
                        return JPAEDJJFFOI.GHBPLHBNMBK_FreeMusicId == GHBPLHBNMBK_freeMusicId;
                    });
                    IBJAKJJICBC e_ = e.Find((IBJAKJJICBC JPAEDJJFFOI) => {
                        //0xFC590C
                        return JPAEDJJFFOI.GHBPLHBNMBK_FreeMusicId == GHBPLHBNMBK_freeMusicId;
                    });
                    if(d_ != null || e_ != null)
                    {
                        KEODKEGFDLD_FreeMusicInfo freeMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_freeMusicId);
                        JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo saveMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_freeMusicId - 1];
                        int f = freeMusicInfo.EMJCHPDJHEI(is6Line, diff).DLPBHJALHCK_GetScoreRank(is6Line ? saveMusic.AHDKMPFDKPE_GetScoreL6_ForDiff(diff) : saveMusic.BDCAICINCKK_GetScoreForDiff(diff) );
                        if(f == 4)
                        {
                            FAGCLBOACEE data = new FAGCLBOACEE();
                            data.KHEKNNFCAOI(BEFPBAIONFK.KHBEKPMMALI/*7*/, GHBPLHBNMBK_freeMusicId, diff, is6Line);
                            res.Add(data);
                        }
                    }
                }
            }
            if(res.Count == 0)
            {
                CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EMHMCOBNMLI();
            }
        }
        return res;
    }
}
