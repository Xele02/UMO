using UnityEngine;
using System.Collections.Generic;
using System;
using XeSys;
using System.IO;
using UnityEditor.Experimental.UIElements.GraphView;

public class SerchGuestNotFoundException : Exception
{
	// RVA: 0xDFF044 Offset: 0xDFF044 VA: 0xDFF044
	public SerchGuestNotFoundException() : base() { return; }

	// RVA: 0xDFF0C8 Offset: 0xDFF0C8 VA: 0xDFF0C8
	public SerchGuestNotFoundException(string message) : base(message) { return; }

	// RVA: 0xDFF154 Offset: 0xDFF154 VA: 0xDFF154
	public SerchGuestNotFoundException(string message, Exception inner) : base(message, inner) { return; }
}

[System.Obsolete("Use PIGBKEIAMPE_FriendManager", true)]
public class PIGBKEIAMPE { }
public class PIGBKEIAMPE_FriendManager
{
    public enum BEKLBBDMAIJ
    {
        HJNNKCMLGFL = 0,
        CCAPCGPIIPF_1 = 1,
        MDKMGHFJCNE = 2,
        BJACNBJLCHJ = 3,
        INFDLLGDBAO = 4,
        ANLLGBEIBNF = 5,
        DBDFOJLHOAH = 6,
    }
    
    public class CDDNFEDGCGG
    {
        public int MLPEHNBNOGD_Id; // 0x8
        public long ANDGMDJLDLO_HideTime; // 0x10
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
	public int NKLACAPLMHI_Count; // 0x64
	public bool GJHIHNBANEC; // 0x68
	private long GBLOMHMEMIC_LastSearchTime; // 0x70
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

	public bool PLOOEECNHFB_IsDone { get; private set; } // 0x8 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA
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
	public List<int> JFDPPPBMCBK_BlacklistedUsersId { get; private set; } // 0x54 NGJJFKKFHEE PBEFGAEJEBH PCFHMNADHFD
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
						data.ANDGMDJLDLO_HideTime = br.ReadInt64();
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
	public void OKJJBFBDPDI()
	{
		if (!Directory.Exists(PEHPMOBIOJF_SaveDataPath))
			Directory.CreateDirectory(PEHPMOBIOJF_SaveDataPath);
		FileStream fs = new FileStream(CCJEGGGJJPO_FcaFile, FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		bw.Write(1);
		bw.Write(KAMNNDELNHG.Count);
		for(int i = 0; i < KAMNNDELNHG.Count; i++)
		{
			bw.Write(KAMNNDELNHG[i].MLPEHNBNOGD_Id);
			bw.Write(0);
			bw.Write(KAMNNDELNHG[i].ANDGMDJLDLO_HideTime);
		}
		bw.Flush();
		bw.Close();
		bw.Dispose();
		fs.Dispose();
	}

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
        PLOOEECNHFB_IsDone = false;
        MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
        PPCNLKHHMFK_NumSentRequest = 0;
        EMBDPGBMCBF_HasMoreSentRequest = false;
        NMOJPDCBGMK_NumFriendNoFav = 0;
        EMJFHKHLHDB = BEKLBBDMAIJ.HJNNKCMLGFL/*0*/;
        BFDEHIANFOG = new List<IBIGBMDANNM>(200);
        JFDPPPBMCBK_BlacklistedUsersId = new List<int>(50);
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
			if (time - LCCEHNMDILJ_LastUpdateGetFriendLimit < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		JPEIBHJIHPI_FriendLimit = 0;
		PLOOEECNHFB_IsDone = false;
		NGADDGLEGAP_GetFriendsLimit req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NGADDGLEGAP_GetFriendsLimit());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C26C
			NGADDGLEGAP_GetFriendsLimit r = KFBCOGJKEJP as NGADDGLEGAP_GetFriendsLimit;
			PLOOEECNHFB_IsDone = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_ResultData.NHPDJADJNCL_FriendLimit;
			LCCEHNMDILJ_LastUpdateGetFriendLimit = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92C494
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D4E68 Offset: 0x16D4E68 VA: 0x16D4E68
	public void PGPLAOGALHD_SetFriendLimit(int ELEPHBOKIGK_FriendLimit, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		PLOOEECNHFB_IsDone = false;
		IDIEAPJLNGL_SetFriendsLimit req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IDIEAPJLNGL_SetFriendsLimit());
		req.APOOBGPBNDG_FriendLimit = ELEPHBOKIGK_FriendLimit;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C4EC
			IDIEAPJLNGL_SetFriendsLimit r = KFBCOGJKEJP as IDIEAPJLNGL_SetFriendsLimit;
			PLOOEECNHFB_IsDone = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_ResultData.NHPDJADJNCL_FriendLimit;
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92C66C
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D5094 Offset: 0x16D5094 VA: 0x16D5094
	public void PFJBNPIBFMO_GetReceivedRequests(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG_OnError, bool FBBNPFFEJBN_Force = false)
	{
		if (!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("friend_api_cooling_time", 60);
			if (time - MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		LIEOOJCODFH_NumFriendRequest = 0;
		PLOOEECNHFB_IsDone = false;
		BKEOKNIEHII_HasMoreReceivedRequest = true;
		JCOBBOMCENL_NumNewRequests = 0;
		long LKGLMCFEDBF = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FFJHJGFKMJB_FriendCheckTime;
		DKEIKBMKKNM_GetReceivedFriendRequests req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKEIKBMKKNM_GetReceivedFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92C6C4
			DKEIKBMKKNM_GetReceivedFriendRequests r = KFBCOGJKEJP as DKEIKBMKKNM_GetReceivedFriendRequests;
			PLOOEECNHFB_IsDone = true;
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
				if(LKGLMCFEDBF < r.NFEAMMJIMPG_ResultData.PBHBFBNFPJI_Requests[i].IFNLEKOILPM_UpdatedAt)
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
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D54F4 Offset: 0x16D54F4 VA: 0x16D54F4
	public void MEJHFCBFPED_GetSentRequests(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG, bool FBBNPFFEJBN_Force = false)
	{
		if (!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("friend_api_cooling_time", 60);
			if (time - AEGKFFCKLNL_LastUpdateGetSentRequests < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			}
		}
		PPCNLKHHMFK_NumSentRequest = 0;
		PLOOEECNHFB_IsDone = false;
		EMBDPGBMCBF_HasMoreSentRequest = false;
		KCLELFBECJK_GetSentFriendRequests req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KCLELFBECJK_GetSentFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x92CB44
			KCLELFBECJK_GetSentFriendRequests r = KFBCOGJKEJP as KCLELFBECJK_GetSentFriendRequests;
			PLOOEECNHFB_IsDone = true;
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
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x16D58B4 Offset: 0x16D58B4 VA: 0x16D58B4
	public void BMJANOADDCC_GetFriends(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG, bool FBBNPFFEJBN = false)
	{
		NMOJPDCBGMK_NumFriendNoFav = 0;
		PLOOEECNHFB_IsDone = false;
		List<int> FAMHAPONILI = new List<int>();
		NAOOAJGKILJ_GetFriends COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		COJNCNGHIJC.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_Request.HDHIKGLMOGF s = null;
		CACGCMBKHDI_Request.HDHIKGLMOGF f = null;
		f = (CACGCMBKHDI_Request DOGDHKIEBJA) =>
		{
			//0x92D344
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
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
				PLOOEECNHFB_IsDone = true;
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
	public int CDOBDJFJLPG_GetRecheckTime()
	{
		int res = 0;
		if(GBLOMHMEMIC_LastSearchTime != 0)
		{
			res = 10;
			if(LNHFLJBGGJB_IsSearching)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if (time < GBLOMHMEMIC_LastSearchTime + 3)
				{
					res = (int)(GBLOMHMEMIC_LastSearchTime + 3 - time);
				}
			}
		}
		return res;
	}

	// // RVA: 0x16D61B0 Offset: 0x16D61B0 VA: 0x16D61B0
	public void CHAILEPDOPJ(EMOLDNAEDMG JENNNPEFPGF, EMOLDNAEDMG PFDAJGNEBJM, EMOLDNAEDMG PDIMJPKFILN, IMCBBOAFION BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG_OnFail, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		DPLHEBFFOBA_SelectPlayerHideTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("select_player_hide_time", 7200);
		long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for (int i = 0; i < KAMNNDELNHG.Count; i++)
		{
			if (serverTime >= KAMNNDELNHG[i].ANDGMDJLDLO_HideTime)
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
		GBLOMHMEMIC_LastSearchTime = CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
			PLOOEECNHFB_IsDone = false;
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
				PLOOEECNHFB_IsDone = true;
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
						PLOOEECNHFB_IsDone = true;
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
						PLOOEECNHFB_IsDone = true;
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
				PLOOEECNHFB_IsDone = true;
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
	public void CKJHFFHFPLH_GetFriends(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		PLOOEECNHFB_IsDone = false;
        PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		NAOOAJGKILJ_GetFriends COJNCNGHIJC = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		List<int> FAMHAPONILI = new List<int>(200);
		COJNCNGHIJC.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_Request.HDHIKGLMOGF ICFBPFMLNCD = null;
		CACGCMBKHDI_Request.HDHIKGLMOGF PDGBAAFHIBP = null;
		PDGBAAFHIBP = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x92458C
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG, AOCANKOMKFG);
		};
		ICFBPFMLNCD = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
		{
			//0x924604
			NAOOAJGKILJ_GetFriends req = KFBCOGJKEJP as NAOOAJGKILJ_GetFriends;
			for(int i = 0; i < req.NFEAMMJIMPG.HBOIBKJEIAP_Friends.Count; i++)
			{
				FAMHAPONILI.Add(req.NFEAMMJIMPG.HBOIBKJEIAP_Friends[i].JPFFIBCDCNJ_Friend.NPMIJMFMEKB_TargetPlayerId);
			}
			if(req.NFEAMMJIMPG.MDIBIIHAAPN_NextPage < 1)
			{
				AONMOEOHFGP_TargetPlayerIds = FAMHAPONILI;
				BHFHGFKBOHH();
			}
			else
			{
				COJNCNGHIJC = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
				COJNCNGHIJC.IGNIIEBMFIN_Page = req.NFEAMMJIMPG.MDIBIIHAAPN_NextPage;
				COJNCNGHIJC.MLPLGFLKKLI_Ipp = 100;
				COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
				COJNCNGHIJC.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
			}
		};
		COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
		COJNCNGHIJC.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
    }

	// // RVA: 0x16D74F4 Offset: 0x16D74F4 VA: 0x16D74F4
	public bool PDEACDHIJJJ_IsFriend(int MLPEHNBNOGD)
	{
		if(AONMOEOHFGP_TargetPlayerIds != null)
			return AONMOEOHFGP_TargetPlayerIds.Contains(MLPEHNBNOGD); 
		Debug.LogError("friendListIds is null");
		return false;
	}

	// // RVA: 0x16D75B4 Offset: 0x16D75B4 VA: 0x16D75B4
	// public void GJODIMMDJHJ(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7814 Offset: 0x16D7814 VA: 0x16D7814
	// public void IJGADKKPAGJ(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16D7B14 Offset: 0x16D7B14 VA: 0x16D7B14
	public void LJMOBJNEHPM(int FBNPCFPONBN, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		PLOOEECNHFB_IsDone = false;
		BFDEHIANFOG.Clear();
		List<int> l = new List<int>();
		l.Add(FBNPCFPONBN);
		List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_Ids = l;
		req.HHIHCJKLJFF_BlockNames = data.KPIDBPEKMFD_GetBlockList();
		req.NBFDEFGFLPJ = (SakashoErrorId CPILGOCFBNM) =>
		{
			//0x16DC7F4
			return CPILGOCFBNM == SakashoErrorId.PLAYER_ID_NOT_FOUND;
		};
		req.PINPBOCDKLI = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0x9262B8
			IBIGBMDANNM item = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(PPFNGGCBJKC, IFNLEKOILPM, false, OHNJJIMGKGK, IDLHJIOMJBK);
			if(item != null)
			{
				if(item.AHEFHIMGIBI_ServerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 0)
				{
					IODPMHILFDI.Add(item);
				}
				return true;
			}
			return false;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request MLBCPDDFCMN) =>
		{
			//0x9263DC
			BFDEHIANFOG.Clear();
			for(int i = 0; i < IODPMHILFDI.Count; i++)
			{
				BFDEHIANFOG.Add(IODPMHILFDI[i]);
			}
			EMJFHKHLHDB = BEKLBBDMAIJ.CCAPCGPIIPF_1;
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
			PLOOEECNHFB_IsDone = true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request CNAIDEAFAAM) =>
		{
			//0x926588
			IMLMNFGDFPE(CNAIDEAFAAM, MOBEEPPKFLG, AOCANKOMKFG);
			PLOOEECNHFB_IsDone = true;
		};
	}

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
		if(300 >= EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate)
		{
			return ANELGKCJBAA[0];
		}
		else
		{
			if((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) <= 3600)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) % 60);
				return "" + val + ANELGKCJBAA[1];
			}
			else if(EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate <= 86400)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate) % 3600);
				return "" + val + ANELGKCJBAA[2];
			}
			else if(EABMEFOJHOJ_ServerTime - BEBJKJKBOGH_LoginDate <= 31536000)
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
	public void NDDIOKIKCNA_GetFanCount(int MLPEHNBNOGD, Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		PLOOEECNHFB_IsDone = false;
		DKFCEGODKFJ_GetPlayerCounters req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKFCEGODKFJ_GetPlayerCounters());
		req.BIHCCEHLAOD.IHALNOJAMLE_CounterName = "fan_count";
		req.BIHCCEHLAOD.FAMHAPONILI_PlayerList = new List<int>() { MLPEHNBNOGD };
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0x929EF0
			DKFCEGODKFJ_GetPlayerCounters r = HKICMNAACDA as DKFCEGODKFJ_GetPlayerCounters;
			PLOOEECNHFB_IsDone = true;
			BHFHGFKBOHH(r.NFEAMMJIMPG.OJCNJFLJCLA[MLPEHNBNOGD]);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0x92A058
			PLOOEECNHFB_IsDone = true;
			MOBEEPPKFLG();
		};
	}

	// // RVA: 0x16DAE5C Offset: 0x16DAE5C VA: 0x16DAE5C
	public void CCAOOIMEPAL_GetPlayerFanCount(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NDDIOKIKCNA_GetFanCount(NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId, BHFHGFKBOHH, MOBEEPPKFLG);
	}

	// // RVA: 0x16DAF20 Offset: 0x16DAF20 VA: 0x16DAF20
	public void BCEAAAOLGEB_Reset()
	{
		JFDPPPBMCBK_BlacklistedUsersId.Clear();
		GJHIHNBANEC = false;
	}

	// // RVA: 0x16DAFA0 Offset: 0x16DAFA0 VA: 0x16DAFA0
	// public int OKDGKAHNBPP() { }

	// // RVA: 0x16DB090 Offset: 0x16DB090 VA: 0x16DB090
	// public void HMANIPMKKFK(int EHGBICNIBKE, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP JEMKODBAOEP, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DB434 Offset: 0x16DB434 VA: 0x16DB434
	// public void CIBLHBAMIJO(int EHGBICNIBKE, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DB6FC Offset: 0x16DB6FC VA: 0x16DB6FC
	public bool DIGEHCDEAON_IsBlacklisted(int MLPEHNBNOGD)
	{
		return JFDPPPBMCBK_BlacklistedUsersId.FindIndex((int GHPLINIACBB) =>
		{
			//0x92AC1C
			return MLPEHNBNOGD == GHPLINIACBB;
		}) > -1;
	}

	// // RVA: 0x16DB804 Offset: 0x16DB804 VA: 0x16DB804
	// public void DIGEHCDEAON(int MLPEHNBNOGD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DBA70 Offset: 0x16DBA70 VA: 0x16DBA70
	// public void LJLKGPDFEAD(int HPFDEEDLBOA, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DBCDC Offset: 0x16DBCDC VA: 0x16DBCDC
	public void EKIJICIBGOG_GetBlacklist(bool FBBNPFFEJBN, IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI_Request.HDHIKGLMOGF AOCANKOMKFG)
	{
		if(GJHIHNBANEC && !FBBNPFFEJBN)
		{
			PLOOEECNHFB_IsDone = true;
			BHFHGFKBOHH();
		}
		else
		{
			NKLACAPLMHI_Count = 0;
			PLOOEECNHFB_IsDone = false;
			PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
			DPMKJDMNDNN_GetBlackList COJNCNGHIJC_Req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
			List<int> l = new List<int>();
			List<IBIGBMDANNM> l2 = new List<IBIGBMDANNM>();
			JFDPPPBMCBK_BlacklistedUsersId.Clear();
			CACGCMBKHDI_Request.HDHIKGLMOGF PDGBAAFHIBP = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x92AE68
				PLOOEECNHFB_IsDone = true;
				IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG, AOCANKOMKFG);
			};
			CACGCMBKHDI_Request.HDHIKGLMOGF ICFBPFMLNCD = null;
			ICFBPFMLNCD = (CACGCMBKHDI_Request KFBCOGJKEJP) =>
			{
				//0x92AEE0
				DPMKJDMNDNN_GetBlackList r = KFBCOGJKEJP as DPMKJDMNDNN_GetBlackList;
				NKLACAPLMHI_Count = r.NFEAMMJIMPG.HMFFHLPNMPH_Count;
				if(r.NFEAMMJIMPG.HMFFHLPNMPH_Count == 0)
				{
					GJHIHNBANEC = true;
					PLOOEECNHFB_IsDone = true;
					if (BHFHGFKBOHH != null)
						BHFHGFKBOHH();
				}
				else
				{
					for(int i = 0; i < r.NFEAMMJIMPG.FOCOFKEFHIO_BlackList.Count; i++)
					{
						JFDPPPBMCBK_BlacklistedUsersId.Add(r.NFEAMMJIMPG.FOCOFKEFHIO_BlackList[i].EHGBICNIBKE_PlayerId);
					}
					if(r.NFEAMMJIMPG.MDIBIIHAAPN_NextPage < 1)
					{
						GJHIHNBANEC = true;
						if (BHFHGFKBOHH != null)
							BHFHGFKBOHH();
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						//JPEIBHJIHPI_FriendLimit
						DPMKJDMNDNN_GetBlackList r2 = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
						r2.IGNIIEBMFIN_Page = r.NFEAMMJIMPG.MDIBIIHAAPN_NextPage;
						r2.MLPLGFLKKLI_Ipp = 30;
						r2.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
						r2.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
					}
				}
			};
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
		}
	}

	// // RVA: 0x16DBFFC Offset: 0x16DBFFC VA: 0x16DBFFC
	// public void EGFNFKJOMIM(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }

	// // RVA: 0x16DC14C Offset: 0x16DC14C VA: 0x16DC14C
	// private void JPALOIENDOP(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG, CACGCMBKHDI.HDHIKGLMOGF AOCANKOMKFG) { }
}
