using UnityEngine;
using System.Collections.Generic;
using System;
using XeSys;
using System.IO;

public class SerchGuestNotFoundException : Exception
{
	// RVA: 0xDFF044 Offset: 0xDFF044 VA: 0xDFF044
	public SerchGuestNotFoundException() : base() { }

	// RVA: 0xDFF0C8 Offset: 0xDFF0C8 VA: 0xDFF0C8
	public SerchGuestNotFoundException(string message) : base(message) { }

	// RVA: 0xDFF154 Offset: 0xDFF154 VA: 0xDFF154
	public SerchGuestNotFoundException(string message, Exception inner) : base(message, inner) { }
}

[System.Obsolete("Use PIGBKEIAMPE_FriendManager", true)]
public class PIGBKEIAMPE { }
public class PIGBKEIAMPE_FriendManager
{
    public enum BEKLBBDMAIJ
    {
        HJNNKCMLGFL = 0,
        CCAPCGPIIPF = 1,
        MDKMGHFJCNE = 2,
        BJACNBJLCHJ = 3,
        INFDLLGDBAO = 4,
        ANLLGBEIBNF = 5,
        DBDFOJLHOAH = 6,
    }
    
    public class CDDNFEDGCGG
    {
        public int MLPEHNBNOGD_Id; // 0x8
        public long ANDGMDJLDLO; // 0x10
    }

	public static bool AGBLJGDGMGH = false; // 0x0
	public static bool CBHJOLOBEOM = false; // 0x1
	public static bool LAGJJJEJKAM = false; // 0x2
	public static int AAPDNPBGOHN = 1; // 0x4
	public static int KDCAJOMCENG = 1; // 0x8
	public static int KHCFABMANLC = 10; // 0xC
	public const int MAAAHDFNPHC = 200;
	public const int DCBJGIMHMMJ = 30;
	public const int GKFANOADIEA = 50;
	public const int NDADCONKKJH = 30;
	public const int LJEAGBPNMDE = 30;
	public const int KCJEDOLEAOI = 1;
	public const int DBPCPFOFIHF = 6;
	public const int CCJOIDHGOKG = -1;
	public const int NCEBCHHHEIH = 50;
	public const string JBIFCINAJAJ = "fan_count";
	private long MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests; // 0x20
	private long AEGKFFCKLNL_LastUpdateGetSentRequests; // 0x30
	private long LCCEHNMDILJ_LastUpdateGetFriendLimit; // 0x38
	private int DPLHEBFFOBA_SelectPlayerHideTime = 600; // 0x40
	private string PEHPMOBIOJF_SaveDataPath; // 0x58
	private string CCJEGGGJJPO_FcaFile; // 0x5C
	public static bool HPAFJEGOFHI = false; // 0x10
	public int NKLACAPLMHI; // 0x64
	public bool GJHIHNBANEC; // 0x68
	private long GBLOMHMEMIC; // 0x70
	private bool LNHFLJBGGJB_IsSearching; // 0x78
	private uint PMBEODGMMBB = 0x15ab17a1; // 0x7C
	private static string[] ANELGKCJBAA = new string[5] {
		JpStringLiterals.StringLiteral_13101,
		JpStringLiterals.StringLiteral_13102,
		JpStringLiterals.StringLiteral_13103,
		JpStringLiterals.StringLiteral_13104,
		JpStringLiterals.StringLiteral_13105
	}; // 0x14
	public static bool DDNKBFMAHIB = false; // 0x18

	public bool PLOOEECNHFB_IsSuccess { get; private set; } // 0x8 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA
	public int AIIOKIHEPDP { get; private set; } // 0xC MOFMDCNBIMC EDJKOFKFJFB MPDLGJHEFEI
	public int JPEIBHJIHPI_FriendLimit { get; private set; } // 0x10 BHDIHHLPFME FLLNLLNBOEM LFDFIALJEDB
	public int LIEOOJCODFH_NumFriendRequest { get; private set; } // 0x14 ALMMJEIPEEG DFGOBOKMBPK HAEIMBPACOO
	public int JCOBBOMCENL_NumNewRequests { get; private set; } // 0x18 PAKABOCDKJD DJHDCPBHPFB AFHCLIDDBOK
	public bool BKEOKNIEHII_HasMoreReceivedRequest { get; private set; } // 0x1C PCBJHOFEIPH GAOJGOFBFOJ OCLIONPHBJE
	public int PPCNLKHHMFK_NumSentRequest { get; private set; } // 0x28 ELCPJCPGLBE IBNLBJALAGM BNEBLCHLJGI
	public bool EMBDPGBMCBF_HasMoreSentRequest { get; private set; } // 0x2C PLBPKJKHLIK CKILJINALAK PPKHDDFFMMJ
	public int NMOJPDCBGMK_NumFriendNoFav { get; private set; } // 0x44 DINIENCLHLC HLHCEMNIPAA KJBCNOAFKPF
	public BEKLBBDMAIJ EMJFHKHLHDB { get; private set; } // 0x48 DBCICDKJFAG AIAPBFFGEGM LMDJCGGLPKB
	public List<IBIGBMDANNM> BFDEHIANFOG { get; private set; } // 0x4C OJLMPOEKAGH BPLEGOEMMNC CHJHFOMDIMP
	public List<int> AONMOEOHFGP_TargetPlayerIds { get; private set; } // 0x50 HAGFPDKGCEO FFDGLAPBKPI BGAMDNPFHFE
	public List<int> JFDPPPBMCBK { get; private set; } // 0x54 NGJJFKKFHEE PBEFGAEJEBH PCFHMNADHFD
	public List<CDDNFEDGCGG> KAMNNDELNHG { get; private set; } // 0x60 EGDOIJNLCLC OOAJNNIHLPH LGBIBHJJEKL
	// public int LMCNBGMCOCI { get; } ??

	// // RVA: 0x16D39A4 Offset: 0x16D39A4 VA: 0x16D39A4
	public void MFKOGDNNKLP()
	{
		if(!Directory.Exists(PEHPMOBIOJF_SaveDataPath))
		{
			Directory.CreateDirectory(PEHPMOBIOJF_SaveDataPath);
		}
		KAMNNDELNHG.Clear();
		if(File.Exists(CCJEGGGJJPO_FcaFile))
		{
			FileStream fs = new FileStream(CCJEGGGJJPO_FcaFile, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			int a = br.ReadInt32();
			if(a == 1)
			{
				a = br.ReadInt32();
				if (a > 0)
				{
					for (int i = 0; i < a; i++)
					{
						CDDNFEDGCGG data = new CDDNFEDGCGG();
						data.MLPEHNBNOGD_Id = br.ReadInt32();
						br.ReadInt32();
						data.ANDGMDJLDLO = br.ReadInt64();
						KAMNNDELNHG.Add(data);
					}
				}
			}
			br.Close();
			br.Dispose();
			fs.Dispose();
		}
	}

	// // RVA: 0x16D3FC0 Offset: 0x16D3FC0 VA: 0x16D3FC0
	// public void OKJJBFBDPDI() { }

	// // RVA: 0x16D463C Offset: 0x16D463C VA: 0x16D463C
	// private void NDBHHJGGFDF(int PPFNGGCBJKC) { }

	// // RVA: 0x16D4768 Offset: 0x16D4768 VA: 0x16D4768
	// public void OCGEPBECHGB() { }

	// // RVA: 0x16D47E8 Offset: 0x16D47E8 VA: 0x16D47E8
	// public int KKPENKOHLCO() { }

	// // RVA: 0x16D47F8 Offset: 0x16D47F8 VA: 0x16D47F8
	private void IMLMNFGDFPE(CACGCMBKHDI_Request ADKIDBJCAJA, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		if(!ADKIDBJCAJA.JONHGMCILHM)
		{
			if(!ADKIDBJCAJA.PDAPLCPOCMA)
			{
				if(ADKIDBJCAJA.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
				{
					if(MOBEEPPKFLG != null)
					{
						MOBEEPPKFLG(ADKIDBJCAJA);
					}
				}
			}
		}
		if(AOCANKOMKFG != null)
		{
			AOCANKOMKFG(ADKIDBJCAJA);
		}
	}

	// // RVA: 0x16D4920 Offset: 0x16D4920 VA: 0x16D4920
	public PIGBKEIAMPE_FriendManager()
    {
        JCOBBOMCENL_NumNewRequests = 0;
        LIEOOJCODFH_NumFriendRequest = 0;
        JPEIBHJIHPI_FriendLimit = 0;
        LIEOOJCODFH_NumFriendRequest = 0;
        AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
        PLOOEECNHFB_IsSuccess = false;
        MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
        PPCNLKHHMFK_NumSentRequest = 0;
        EMBDPGBMCBF_HasMoreSentRequest = false;
        NMOJPDCBGMK_NumFriendNoFav = 0;
        EMJFHKHLHDB = BEKLBBDMAIJ.HJNNKCMLGFL/*0*/;
        BFDEHIANFOG = new List<IBIGBMDANNM>(200);
        JFDPPPBMCBK = new List<int>(50);
        KAMNNDELNHG = new List<CDDNFEDGCGG>(20);
        PEHPMOBIOJF_SaveDataPath = Application.persistentDataPath + "/SaveData";
        CCJEGGGJJPO_FcaFile = Application.persistentDataPath + "/fca";
    }

	// // RVA: 0x16D4AAC Offset: 0x16D4AAC VA: 0x16D4AAC
	public void HHDGOABFEPC_GetFriendLimit(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG, bool FBBNPFFEJBN_Force = false)
	{
		if(!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("friend_api_cooling_time", 60);
			if (LCCEHNMDILJ_LastUpdateGetFriendLimit + coolTime > time)
			{
				PLOOEECNHFB_IsSuccess = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		JPEIBHJIHPI_FriendLimit = 0;
		PLOOEECNHFB_IsSuccess = false;
		NGADDGLEGAP_GetFriendsLimit req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NGADDGLEGAP_GetFriendsLimit());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C26C
			NGADDGLEGAP_GetFriendsLimit r = KFBCOGJKEJP as NGADDGLEGAP_GetFriendsLimit;
			PLOOEECNHFB_IsSuccess = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_ResultData.NHPDJADJNCL_FriendLimit;
			LCCEHNMDILJ_LastUpdateGetFriendLimit = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92C494
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D4E68 Offset: 0x16D4E68 VA: 0x16D4E68
	public void PGPLAOGALHD_SetFriendLimit(int ELEPHBOKIGK_FriendLimit, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		PLOOEECNHFB_IsSuccess = false;
		IDIEAPJLNGL_SetFriendsLimit req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IDIEAPJLNGL_SetFriendsLimit());
		req.APOOBGPBNDG_FriendLimit = ELEPHBOKIGK_FriendLimit;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C4EC
			IDIEAPJLNGL_SetFriendsLimit r = KFBCOGJKEJP as IDIEAPJLNGL_SetFriendsLimit;
			PLOOEECNHFB_IsSuccess = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_ResultData.NHPDJADJNCL_FriendLimit;
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92C66C
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D5094 Offset: 0x16D5094 VA: 0x16D5094
	public void PFJBNPIBFMO_GetReceivedRequests(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG_OnError, bool FBBNPFFEJBN_Force = false)
	{
		if (!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("friend_api_cooling_time", 60);
			if (MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests + coolTime > time)
			{
				PLOOEECNHFB_IsSuccess = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		LIEOOJCODFH_NumFriendRequest = 0;
		PLOOEECNHFB_IsSuccess = false;
		BKEOKNIEHII_HasMoreReceivedRequest = true;
		JCOBBOMCENL_NumNewRequests = 0;
		long LKGLMCFEDBF = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FFJHJGFKMJB_FriendCheckTime;
		DKEIKBMKKNM_GetReceivedFriendRequests req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKEIKBMKKNM_GetReceivedFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C6C4
			DKEIKBMKKNM_GetReceivedFriendRequests r = KFBCOGJKEJP as DKEIKBMKKNM_GetReceivedFriendRequests;
			PLOOEECNHFB_IsSuccess = true;
			int num = 30;
			if (r.NFEAMMJIMPG_ResultData.HMFFHLPNMPH_Count < 31)
			{
				num = r.NFEAMMJIMPG_ResultData.HMFFHLPNMPH_Count;
			}
			LIEOOJCODFH_NumFriendRequest = num;
			BKEOKNIEHII_HasMoreReceivedRequest = r.NFEAMMJIMPG_ResultData.HMFFHLPNMPH_Count > 30;
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < r.NFEAMMJIMPG_ResultData.PBHBFBNFPJI_Requests.Count; i++)
			{
				if(r.NFEAMMJIMPG_ResultData.PBHBFBNFPJI_Requests[i].IFNLEKOILPM_UpdatedAt > LKGLMCFEDBF)
				{
					JCOBBOMCENL_NumNewRequests++;
				}
			}
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92CAEC
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D54F4 Offset: 0x16D54F4 VA: 0x16D54F4
	public void MEJHFCBFPED_GetSentRequests(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG, bool FBBNPFFEJBN_Force = false)
	{
		if (!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("friend_api_cooling_time", 60);
			if (AEGKFFCKLNL_LastUpdateGetSentRequests + coolTime > time)
			{
				PLOOEECNHFB_IsSuccess = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		PPCNLKHHMFK_NumSentRequest = 0;
		PLOOEECNHFB_IsSuccess = false;
		EMBDPGBMCBF_HasMoreSentRequest = false;
		KCLELFBECJK_GetSentFriendRequests req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KCLELFBECJK_GetSentFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92CB44
			KCLELFBECJK_GetSentFriendRequests r = KFBCOGJKEJP as KCLELFBECJK_GetSentFriendRequests;
			PLOOEECNHFB_IsSuccess = true;
			int num = 30; 
			if(r.NFEAMMJIMPG.HMFFHLPNMPH_Count < 31)
			{
				num = r.NFEAMMJIMPG.HMFFHLPNMPH_Count;
			}
			PPCNLKHHMFK_NumSentRequest = num;
			EMBDPGBMCBF_HasMoreSentRequest = r.NFEAMMJIMPG.HMFFHLPNMPH_Count > 30;
			AEGKFFCKLNL_LastUpdateGetSentRequests = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92CE0C
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D58B4 Offset: 0x16D58B4 VA: 0x16D58B4
	public void BMJANOADDCC_GetFriends(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG, bool FBBNPFFEJBN = false)
	{
		NMOJPDCBGMK_NumFriendNoFav = 0;
		PLOOEECNHFB_IsSuccess = false;
		List<int> FAMHAPONILI = new List<int>();
		NAOOAJGKILJ_GetFriends COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		COJNCNGHIJC.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_Request.HDHIKGLMOGF s = null;
		CACGCMBKHDI_Request.HDHIKGLMOGF f = null;
		f = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92D344
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
		s = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92CE64
			NAOOAJGKILJ_GetFriends r = KFBCOGJKEJP as NAOOAJGKILJ_GetFriends;
			int friendNoFav = 0;
			for(int i = 0; i < r.NFEAMMJIMPG.HBOIBKJEIAP_Friends.Count; i++)
			{
				CHPIKCFKJOA a = r.NFEAMMJIMPG.HBOIBKJEIAP_Friends[i];
				friendNoFav += a.JPFFIBCDCNJ_Friend.NEILEPPJKIN_Favorite == 0 ? 1 : 0;
				FAMHAPONILI.Add(a.JPFFIBCDCNJ_Friend.NPMIJMFMEKB_TargetPlayerId);
			}
			NMOJPDCBGMK_NumFriendNoFav += friendNoFav;
			if(r.NFEAMMJIMPG.MDIBIIHAAPN_NextPage < 1)
			{
				PLOOEECNHFB_IsSuccess = true;
				AONMOEOHFGP_TargetPlayerIds = FAMHAPONILI;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
			else
			{
				COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
				COJNCNGHIJC.IGNIIEBMFIN_Page = r.NFEAMMJIMPG.MDIBIIHAAPN_NextPage;
				COJNCNGHIJC.MLPLGFLKKLI_Ipp = 100;
				COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = s;
				COJNCNGHIJC.MOBEEPPKFLG_OnFail = f;
			}

		};
		COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = s;
		COJNCNGHIJC.MOBEEPPKFLG_OnFail = f;
	}

	// // RVA: 0x16D5B90 Offset: 0x16D5B90 VA: 0x16D5B90
	// public void KIOJKHJNNNJ(SakashoPlayerCriteria IPKCADIAAPG, SakashoPlayerData.SearchOrder EILKGEADKGH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D6084 Offset: 0x16D6084 VA: 0x16D6084
	public int CDOBDJFJLPG()
	{
		TodoLogger.Log(0, "CDOBDJFJLPG");
		return 0;
	}

	// // RVA: 0x16D61B0 Offset: 0x16D61B0 VA: 0x16D61B0
	public void CHAILEPDOPJ(EMOLDNAEDMG JENNNPEFPGF, EMOLDNAEDMG PFDAJGNEBJM, EMOLDNAEDMG PDIMJPKFILN, IMCBBOAFION BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG_OnFail, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		DPLHEBFFOBA_SelectPlayerHideTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("select_player_hide_time", 7200);
		long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for (int i = 0; i < KAMNNDELNHG.Count; i++)
		{
			if (KAMNNDELNHG[i].ANDGMDJLDLO < serverTime) // check long test
			{
				KAMNNDELNHG.RemoveAt(i);
				i = 0;
			}
		}
		BFDEHIANFOG.Clear();
		List<IBIGBMDANNM> CCMMIECBIOP = new List<IBIGBMDANNM>();
		List<IBIGBMDANNM> OGAGAFPCBOC = new List<IBIGBMDANNM>();
		List<IBIGBMDANNM> OGFBMMOGFLJ = new List<IBIGBMDANNM>();
		BBHNACPENDM_ServerSaveData EHDDJFNOBFN = new BBHNACPENDM_ServerSaveData();
		EHDDJFNOBFN.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		long GBLOMHMEMIC_ServerTime = CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		LNHFLJBGGJB_IsSearching = true;
		LNGMNNNJBJP req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP>(new LNGMNNNJBJP());
		req.IPKCADIAAPG_SakashoCrit = JENNNPEFPGF.IDLHJIOMJBK_SakashoCriteria;
		req.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		req.MLPLGFLKKLI_Ipp = JENNNPEFPGF.MLPLGFLKKLI_Ipp;
		req.HHIHCJKLJFF_ServerInfoBlockList = EHDDJFNOBFN.KPIDBPEKMFD_GetBlockList();
		req.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA_Idx, int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData) =>
		{
			//0x16DC804
			int idx = KAMNNDELNHG.FindIndex((CDDNFEDGCGG GHPLINIACBB) =>
			{
				//0x16DD660
				return GHPLINIACBB.MLPEHNBNOGD_Id == PPFNGGCBJKC_Id;
			});
			if(idx < 0)
			{
				IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(PPFNGGCBJKC_Id, IFNLEKOILPM_LastLogin, MLEHCBKPNGK_IsFriend, OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData);
				if (data == null)
					return false;
				CCMMIECBIOP.Add(data);
			}
			return true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x16DC9AC
			PLOOEECNHFB_IsSuccess = false;
			LNHFLJBGGJB_IsSearching = false;
			IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, AOCANKOMKFG);
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x16DCA2C
			LNGMNNNJBJP req2 = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP>(new LNGMNNNJBJP());
			req2.IPKCADIAAPG_SakashoCrit = PFDAJGNEBJM.IDLHJIOMJBK_SakashoCriteria;
			req2.HHIHCJKLJFF_ServerInfoBlockList = EHDDJFNOBFN.KPIDBPEKMFD_GetBlockList();
			req2.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			req2.MLPLGFLKKLI_Ipp = PFDAJGNEBJM.MLPLGFLKKLI_Ipp;
			req2.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA_Idx, int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData) =>
			{
				//0x16DCC9C
				int idx = KAMNNDELNHG.FindIndex((CDDNFEDGCGG GHPLINIACBB) =>
				{
					//0x9235A8
					return GHPLINIACBB.MLPEHNBNOGD_Id == PPFNGGCBJKC_Id;
				});
				if(idx < 0 && !MLEHCBKPNGK_IsFriend)
				{
					idx = OGAGAFPCBOC.FindIndex((IBIGBMDANNM PMBEODGMMBB) =>
					{
						//0x9235E0
						return PMBEODGMMBB.MLPEHNBNOGD_Id == PPFNGGCBJKC_Id;
					});
					if(idx < 0)
					{
						IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(PPFNGGCBJKC_Id, IFNLEKOILPM_LastLogin, MLEHCBKPNGK_IsFriend, OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData);
						if (data == null)
							return false;
						OGAGAFPCBOC.Add(data);
					}
				}
				return true;
			};
			req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request OIHMJDCHIIO) =>
			{
				//0x16DD698
				PLOOEECNHFB_IsSuccess = true;
				LNHFLJBGGJB_IsSearching = false;
				IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, AOCANKOMKFG);
			};
			req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request OIHMJDCHIIO) =>
			{
				//0x16DD798
				int num = CCMMIECBIOP.Count;
				if (JENNNPEFPGF.ADPPAIPFHML_Num < CCMMIECBIOP.Count)
				{
					num = JENNNPEFPGF.ADPPAIPFHML_Num;
				}
				if(OGAGAFPCBOC.Count < (JENNNPEFPGF.ADPPAIPFHML_Num - num) + PFDAJGNEBJM.ADPPAIPFHML_Num)
				{
					LNGMNNNJBJP req3 = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP>(new LNGMNNNJBJP());
					req3.IPKCADIAAPG_SakashoCrit = PDIMJPKFILN.IDLHJIOMJBK_SakashoCriteria;
					req3.HHIHCJKLJFF_ServerInfoBlockList = EHDDJFNOBFN.KPIDBPEKMFD_GetBlockList();
					req3.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
					req3.MLPLGFLKKLI_Ipp = PDIMJPKFILN.MLPLGFLKKLI_Ipp;
					req3.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA_Idx, int PPFNGGCBJKC_Id, long IFNLEKOILPM_LastLogin, bool MLEHCBKPNGK_IsFriend, List<string> OHNJJIMGKGK_BlockList, EDOHBJAPLPF_JsonData IDLHJIOMJBK_PlayerData) =>
					{
						//0x16DCEC4
						if(!MLEHCBKPNGK_IsFriend)
						{
							int idx = OGAGAFPCBOC.FindIndex((IBIGBMDANNM PMBEODGMMBB) =>
							{
								//0x92362C
								return PMBEODGMMBB.MLPEHNBNOGD_Id == PPFNGGCBJKC_Id;
							});
							if(idx < 0)
							{
								IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(PPFNGGCBJKC_Id, IFNLEKOILPM_LastLogin, false, OHNJJIMGKGK_BlockList, IDLHJIOMJBK_PlayerData);
								if (data == null)
									return false;
								OGFBMMOGFLJ.Add(data);
							}
						}
						return true;
					};
					req3.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request AMGHBMDOOEH) =>
					{
						//0x16DDDE4
						PLOOEECNHFB_IsSuccess = true;
						LNHFLJBGGJB_IsSearching = false;
						IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, AOCANKOMKFG);
					};
					req3.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request AMGHBMDOOEH) =>
					{
						//0x16DD058
						NPGOGNGOBOE(CCMMIECBIOP, OGAGAFPCBOC, OGFBMMOGFLJ, JENNNPEFPGF.ADPPAIPFHML_Num, PFDAJGNEBJM.ADPPAIPFHML_Num);
						if(BFDEHIANFOG.Count == 0)
						{
							BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
							data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
							IBIGBMDANNM data2 = new IBIGBMDANNM();
							data2.AHEFHIMGIBI_ServerData = data;
							data2.MLPEHNBNOGD_Id = -1;
							data2.LBODHBDOMGK = JpStringLiterals.StringLiteral_9806;
							data2.LFKJNMFFCLH_LastLoginString = JpStringLiterals.StringLiteral_13106;
							data2.PDJEMLMOEPF_DivaId = 1;
							data2.FCKJJGIMPPI = 1;
							throw new SerchGuestNotFoundException("from=" + PFDAJGNEBJM.IDLHJIOMJBK_SakashoCriteria.NumberFrom + ",to=" + PFDAJGNEBJM.IDLHJIOMJBK_SakashoCriteria.NumberTo);
						}
						EMJFHKHLHDB = /*4*/BEKLBBDMAIJ.INFDLLGDBAO;
						LNHFLJBGGJB_IsSearching = false;
						PLOOEECNHFB_IsSuccess = true;
						if (BHFHGFKBOHH_OnSuccess != null)
						{
							BHFHGFKBOHH_OnSuccess();
						}
					};
					return;
				}
				NPGOGNGOBOE(CCMMIECBIOP, OGAGAFPCBOC, OGFBMMOGFLJ, JENNNPEFPGF.ADPPAIPFHML_Num, PFDAJGNEBJM.ADPPAIPFHML_Num);
				EMJFHKHLHDB = BEKLBBDMAIJ.INFDLLGDBAO/*4*/;
				LNHFLJBGGJB_IsSearching = false;
				PLOOEECNHFB_IsSuccess = true;
				if (BHFHGFKBOHH_OnSuccess != null)
				{
					BHFHGFKBOHH_OnSuccess();
				}
			};
		};
	}

	// // RVA: 0x16D6944 Offset: 0x16D6944 VA: 0x16D6944
	public void NCEJOLLKDDF_InitRandList()
	{
		PMBEODGMMBB = (uint)(Utility.GetCurrentUnixTime() ^ 0x15ab17a1);
	}

	// // RVA: 0x16D69D4 Offset: 0x16D69D4 VA: 0x16D69D4
	// private int HEPEDNJMCFA(int HKICMNAACDA, int BNKHBCBJBKI) { }

	// // RVA: 0x16D6A08 Offset: 0x16D6A08 VA: 0x16D6A08
	private void DLPHPGJCAAF_RandomizeList(List<IBIGBMDANNM> NNDGIAEFMOG)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB << 0xd);
				PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB >> 0x11);
				PMBEODGMMBB = PMBEODGMMBB ^ (PMBEODGMMBB << 5);
				int a = (int)(PMBEODGMMBB % NNDGIAEFMOG.Count);
				IBIGBMDANNM a1 = NNDGIAEFMOG[i];
				IBIGBMDANNM a2 = NNDGIAEFMOG[a];
				NNDGIAEFMOG[i] = a2;
				NNDGIAEFMOG[a] = a1;
			}
		}
	}

	// // RVA: 0x16D6B60 Offset: 0x16D6B60 VA: 0x16D6B60
	private void NPGOGNGOBOE(List<IBIGBMDANNM> DMKCJODMFDH, List<IBIGBMDANNM> PDKNONEKLPL, List<IBIGBMDANNM> NDBOEFNFOBC, int FDNKMHGFBDJ, int LJBEDHNNMAO)
	{
		BFDEHIANFOG.Clear();
		NCEJOLLKDDF_InitRandList();
		DLPHPGJCAAF_RandomizeList(DMKCJODMFDH);
		DLPHPGJCAAF_RandomizeList(PDKNONEKLPL);
		DLPHPGJCAAF_RandomizeList(NDBOEFNFOBC);
		int total = LJBEDHNNMAO + FDNKMHGFBDJ;
		if(FDNKMHGFBDJ > 0)
		{
			for(int i = 0; i < FDNKMHGFBDJ && i < DMKCJODMFDH.Count && BFDEHIANFOG.Count < total; i++)
			{
				BFDEHIANFOG.Add(DMKCJODMFDH[i]);
			}
		}
		int missing = total - BFDEHIANFOG.Count;
		if (missing > 0)
		{
			for(int i = 0; i < missing && i < PDKNONEKLPL.Count && BFDEHIANFOG.Count < total; i++)
			{
				BFDEHIANFOG.Add(PDKNONEKLPL[i]);
			}
			if(NDBOEFNFOBC != null && missing > 0)
			{
				for(int i = 0; i < NDBOEFNFOBC.Count && BFDEHIANFOG.Count < total; i++)
				{
					BFDEHIANFOG.Add(NDBOEFNFOBC[i]);
				}
			}
		}
	}

	// // RVA: 0x16D6F30 Offset: 0x16D6F30 VA: 0x16D6F30
	// public void POEDEMPINCH(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7244 Offset: 0x16D7244 VA: 0x16D7244
	// public void CKJHFFHFPLH(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D74F4 Offset: 0x16D74F4 VA: 0x16D74F4
	// public bool PDEACDHIJJJ(int MLPEHNBNOGD) { }

	// // RVA: 0x16D75B4 Offset: 0x16D75B4 VA: 0x16D75B4
	// public void GJODIMMDJHJ(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7814 Offset: 0x16D7814 VA: 0x16D7814
	// public void IJGADKKPAGJ(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7B14 Offset: 0x16D7B14 VA: 0x16D7B14
	// public void LJMOBJNEHPM(int FBNPCFPONBN, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7F54 Offset: 0x16D7F54 VA: 0x16D7F54
	// private bool LBIDNNNIFBD(SakashoErrorId KLCMLLLIANB) { }

	// // RVA: 0x16D7F78 Offset: 0x16D7F78 VA: 0x16D7F78
	// private bool DENFAJIBOOO(string LIDBGALGECP, SakashoErrorId KLCMLLLIANB, IMCBBOAFION HIDFAIBOHCC) { }

	// // RVA: 0x16D82AC Offset: 0x16D82AC VA: 0x16D82AC
	// public void AOHLMBKILED(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D86DC Offset: 0x16D86DC VA: 0x16D86DC
	// public void ADOIKCJALGM(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D89C8 Offset: 0x16D89C8 VA: 0x16D89C8
	// public void CCBALBLFNDN(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D8CC4 Offset: 0x16D8CC4 VA: 0x16D8CC4
	// public void FFIBIAEJBNC(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D8FC8 Offset: 0x16D8FC8 VA: 0x16D8FC8
	// public void PBEDDFMFDKB(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D92D0 Offset: 0x16D92D0 VA: 0x16D92D0
	// public void EICNBEKECJG(List<int> FAMHAPONILI, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D9538 Offset: 0x16D9538 VA: 0x16D9538
	// public void EICNBEKECJG(List<IBIGBMDANNM> AHEFHIMGIBI, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D9714 Offset: 0x16D9714 VA: 0x16D9714
	public static string MKILKPFAOIC_GetLastLoginString(long BEBJKJKBOGH_LoginDate, long EABMEFOJHOJ_ServerTime)
	{
		if(BEBJKJKBOGH_LoginDate > EABMEFOJHOJ_ServerTime)
		{
			return ANELGKCJBAA[0];
		}
		else
		{
			if((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) < 3600)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) % 60);
				return "" + val + ANELGKCJBAA[1];
			}
			else if(EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate < 86400)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) % 3600);
				return "" + val + ANELGKCJBAA[2];
			}
			else if(EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate < 31536000)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) % 86400);
				return "" + val + ANELGKCJBAA[3];
			}
			else
			{
				return ANELGKCJBAA[4];
			}
		}
	}

	// // RVA: 0x16D9AB8 Offset: 0x16D9AB8 VA: 0x16D9AB8
	// public static SakashoPlayerCriteria NKNOLNNPGAC(BBHNACPENDM AHEFHIMGIBI) { }

	// // RVA: 0x16D9C04 Offset: 0x16D9C04 VA: 0x16D9C04
	// public static SakashoPlayerCriteria NKNOLNNPGAC(BBHNACPENDM AHEFHIMGIBI, int PPFNGGCBJKC) { }

	// // RVA: 0x16D9D54 Offset: 0x16D9D54 VA: 0x16D9D54
	// public static int DJHFILDBOFG() { }

	// // RVA: 0x16D9E44 Offset: 0x16D9E44 VA: 0x16D9E44
	// public static int GKDGOGCOGBK() { }

	// // RVA: 0x16D9F20 Offset: 0x16D9F20 VA: 0x16D9F20
	// public void EGLFECJOPPP(PIGBKEIAMPE.KIELKOCLIGG PIBLLGLCJEO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B6E98 Offset: 0x6B6E98 VA: 0x6B6E98
	// // RVA: 0x16D9F88 Offset: 0x16D9F88 VA: 0x16D9F88
	// private IEnumerator PJHEJPKCHHE(PIGBKEIAMPE.KIELKOCLIGG PIBLLGLCJEO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x16DA05C Offset: 0x16DA05C VA: 0x16DA05C
	// public void CPEHDILBIJA(int FGHNNFGJKJE, SakashoPlayerCriteria IPKCADIAAPG, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B6F10 Offset: 0x6B6F10 VA: 0x6B6F10
	// // RVA: 0x16DA0CC Offset: 0x16DA0CC VA: 0x16DA0CC
	// private IEnumerator DAEDHMHBPCI(int FGHNNFGJKJE, SakashoPlayerCriteria IPKCADIAAPG, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x16DA1B8 Offset: 0x16DA1B8 VA: 0x16DA1B8
	// public void EPKOLKBGOGA(List<int> FNLNHGBGHKF, List<int> EDPCFGCDEFE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK DDMLOBICBHI) { }

	// // RVA: 0x16DABA4 Offset: 0x16DABA4 VA: 0x16DABA4
	// public void NDDIOKIKCNA(int MLPEHNBNOGD, Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x16DAE5C Offset: 0x16DAE5C VA: 0x16DAE5C
	// public void CCAOOIMEPAL(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x16DAF20 Offset: 0x16DAF20 VA: 0x16DAF20
	public void BCEAAAOLGEB()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0x16DAFA0 Offset: 0x16DAFA0 VA: 0x16DAFA0
	// public int OKDGKAHNBPP() { }

	// // RVA: 0x16DB090 Offset: 0x16DB090 VA: 0x16DB090
	// public void HMANIPMKKFK(int EHGBICNIBKE, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP JEMKODBAOEP, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DB434 Offset: 0x16DB434 VA: 0x16DB434
	// public void CIBLHBAMIJO(int EHGBICNIBKE, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DB6FC Offset: 0x16DB6FC VA: 0x16DB6FC
	// public bool DIGEHCDEAON(int MLPEHNBNOGD) { }

	// // RVA: 0x16DB804 Offset: 0x16DB804 VA: 0x16DB804
	// public void DIGEHCDEAON(int MLPEHNBNOGD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DBA70 Offset: 0x16DBA70 VA: 0x16DBA70
	// public void LJLKGPDFEAD(int HPFDEEDLBOA, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DBCDC Offset: 0x16DBCDC VA: 0x16DBCDC
	// public void EKIJICIBGOG(bool FBBNPFFEJBN, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DBFFC Offset: 0x16DBFFC VA: 0x16DBFFC
	// public void EGFNFKJOMIM(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DC14C Offset: 0x16DC14C VA: 0x16DC14C
	// private void JPALOIENDOP(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }
}
