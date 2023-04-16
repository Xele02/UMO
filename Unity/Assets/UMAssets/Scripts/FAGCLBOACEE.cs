
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
	public bool GIKLNODJKFK; // 0x14

	// // RVA: 0xFC1A40 Offset: 0xFC1A40 VA: 0xFC1A40
	public void KHEKNNFCAOI(FAGCLBOACEE.BEFPBAIONFK DEPGBBJMFED, int PPFNGGCBJKC, int AKNELONELJK = 0, bool GIKLNODJKFK = false)
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
                TodoLogger.Log(0, "KHEKNNFCAOI 2");
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
        PPFNGGCBJKC = id;
        this.AKNELONELJK = AKNELONELJK;
        this.GIKLNODJKFK = GIKLNODJKFK;
    }

	// // RVA: 0xFC1EE8 Offset: 0xFC1EE8 VA: 0xFC1EE8
	// public static List<FAGCLBOACEE> ECKKHOCALEE() { }

	// // RVA: 0xFC2314 Offset: 0xFC2314 VA: 0xFC2314
	// public static List<FAGCLBOACEE> ICBFAFNOHIB(int IJEKNCDIIAE) { }

	// // RVA: 0xFC293C Offset: 0xFC293C VA: 0xFC293C
	// public static List<FAGCLBOACEE> GGGOIINDGMI() { }

	// // RVA: 0xFC2FB8 Offset: 0xFC2FB8 VA: 0xFC2FB8
	public static List<FAGCLBOACEE> OGGDOPACJOB()
    {
        List<FAGCLBOACEE> res = new List<FAGCLBOACEE>();
        List<LAEGMENIEDB_Story.ALGOILKGAAH> dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA;
        List<NEKDCJKANAH_StoryRecord.HKDNILFKCFC> saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH;
        LPPGENBEECK_MusicMaster dbMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music;
        List<LIEJFHMGNIA> l = LIEJFHMGNIA.FKDIMODKKJD(LIEJFHMGNIA.PJIJLMFBBCJ() + 1, true, true, false);
        for(int i = 0; i < l.Count; i++)
        {
            TodoLogger.Log(0, "OGGDOPACJOB");
        }
        res.AddRange(KJDIPIAFNEN());
        return res;
    }

	// // RVA: 0xFC3D68 Offset: 0xFC3D68 VA: 0xFC3D68
	// public static List<FAGCLBOACEE> JODDIFOOIOJ() { }

	// // RVA: 0xFC46A4 Offset: 0xFC46A4 VA: 0xFC46A4
	// public static List<FAGCLBOACEE> MLHMCCLKALG() { }

	// // RVA: 0xFC451C Offset: 0xFC451C VA: 0xFC451C
	// public static KEODKEGFDLD BMBELGEDKEG(int DLAEJOBELBH) { }

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
