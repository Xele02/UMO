using UnityEngine;
using System.Collections.Generic;
using System;
using XeSys;
using System.IO;
using System.Collections;

public class SerchGuestNotFoundException : Exception
{
	// RVA: 0xDFF044 Offset: 0xDFF044 VA: 0xDFF044
	public SerchGuestNotFoundException() : base() { return; }

	// RVA: 0xDFF0C8 Offset: 0xDFF0C8 VA: 0xDFF0C8
	public SerchGuestNotFoundException(string message) : base(message) { return; }

	// RVA: 0xDFF154 Offset: 0xDFF154 VA: 0xDFF154
	public SerchGuestNotFoundException(string message, Exception inner) : base(message, inner) { return; }
}

//namespace XeApp.Game.Net
[System.Obsolete("Use PIGBKEIAMPE_NetFriendManager", true)]
public class PIGBKEIAMPE { }
public class PIGBKEIAMPE_NetFriendManager
{
    public enum BEKLBBDMAIJ
    {
        HJNNKCMLGFL_0_None = 0,
        CCAPCGPIIPF_1_Normal = 1,
        MDKMGHFJCNE_2 = 2,
        BJACNBJLCHJ_3 = 3,
        INFDLLGDBAO = 4,
        ANLLGBEIBNF_5 = 5,
        DBDFOJLHOAH_6 = 6,
    }
    
    public class CDDNFEDGCGG
    {
        public int MLPEHNBNOGD_PlayerId; // 0x8
        public long ANDGMDJLDLO_HideTime; // 0x10
    }
	
	public class KIELKOCLIGG
	{
		public delegate IFICNCAHIGI APDMMIENOIK(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data);

		public SakashoPlayerCriteria IPKCADIAAPG_Criteria; // 0x8
		public ulong MCEGJNAABHG; // 0x10
		public APDMMIENOIK IGNHNKJOCKB; // 0x18
		public Func<IFICNCAHIGI, bool> PHCKPOKKBGD; // 0x1C
		public Func<IBIGBMDANNM, bool> BBCOJEPJNMO; // 0x20

		// RVA: 0x92EE90 Offset: 0x92EE90 VA: 0x92EE90
		public KIELKOCLIGG()
		{
			IPKCADIAAPG_Criteria = SakashoPlayerCriteria.NewCriteriaFromTo("plv", null, null);
			MCEGJNAABHG = 5;
			IGNHNKJOCKB = (int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0x92F0DC
				return IBIGBMDANNM.HEGEKFMJNCC<IFICNCAHIGI>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
			};
			PHCKPOKKBGD = null;
			BBCOJEPJNMO = null;
		}
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
	public const string JBIFCINAJAJ_fan_count = "fan_count";
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
	private bool LNHFLJBGGJB_IsRunning; // 0x78
	private uint PMBEODGMMBB_y = 0x15ab17a1; // 0x7C
	private static string[] ANELGKCJBAA = new string[5] {
		JpStringLiterals.StringLiteral_13101,
		JpStringLiterals.StringLiteral_13102,
		JpStringLiterals.StringLiteral_13103,
		JpStringLiterals.StringLiteral_13104,
		JpStringLiterals.StringLiteral_13105
	}; // 0x14
	public static bool DDNKBFMAHIB = false; // 0x18

	public bool PLOOEECNHFB_IsDone { get; private set; } // 0x8 MGFBAEDOIDD_bgs JFOKBBLFMLD_bgs EDBGNGILAKA_bgs
	public int AIIOKIHEPDP_FriendCount { get; private set; } // 0xC MOFMDCNBIMC_bgs EDJKOFKFJFB_bgs MPDLGJHEFEI_bgs
	public int JPEIBHJIHPI_FriendLimit { get; private set; } // 0x10 BHDIHHLPFME_bgs FLLNLLNBOEM_bgs LFDFIALJEDB_bgs
	public int LIEOOJCODFH_NumFriendRequest { get; private set; } // 0x14 ALMMJEIPEEG_bgs DFGOBOKMBPK_bgs HAEIMBPACOO_bgs
	public int JCOBBOMCENL_NumNewRequests { get; private set; } // 0x18 PAKABOCDKJD_bgs DJHDCPBHPFB_bgs AFHCLIDDBOK_bgs
	public bool BKEOKNIEHII_HasMoreReceivedRequest { get; private set; } // 0x1C PCBJHOFEIPH_bgs GAOJGOFBFOJ_bgs OCLIONPHBJE_bgs
	public int PPCNLKHHMFK_NumSentRequest { get; private set; } // 0x28 ELCPJCPGLBE_bgs IBNLBJALAGM_bgs BNEBLCHLJGI_bgs
	public bool EMBDPGBMCBF_HasMoreSentRequest { get; private set; } // 0x2C PLBPKJKHLIK_bgs CKILJINALAK_bgs PPKHDDFFMMJ_bgs
	public int NMOJPDCBGMK_NumFriendNoFav { get; private set; } // 0x44 DINIENCLHLC_bgs HLHCEMNIPAA_bgs KJBCNOAFKPF_bgs
	public BEKLBBDMAIJ EMJFHKHLHDB { get; private set; } // 0x48 DBCICDKJFAG_bgs AIAPBFFGEGM_bgs LMDJCGGLPKB_bgs
	public List<IBIGBMDANNM> BFDEHIANFOG { get; private set; } // 0x4C OJLMPOEKAGH_bgs BPLEGOEMMNC_bgs CHJHFOMDIMP_bgs
	public List<int> AONMOEOHFGP_TargetPlayerIds { get; private set; } // 0x50 HAGFPDKGCEO_bgs FFDGLAPBKPI_bgs BGAMDNPFHFE_bgs
	public List<int> JFDPPPBMCBK_BlacklistedUsersId { get; private set; } // 0x54 NGJJFKKFHEE_bgs PBEFGAEJEBH_bgs PCFHMNADHFD_bgs
	public List<CDDNFEDGCGG> KAMNNDELNHG { get; private set; } // 0x60 EGDOIJNLCLC_bgs OOAJNNIHLPH_bgs LGBIBHJJEKL_bgs
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
						data.MLPEHNBNOGD_PlayerId = br.ReadInt32();
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
			bw.Write(KAMNNDELNHG[i].MLPEHNBNOGD_PlayerId);
			bw.Write(0);
			bw.Write(KAMNNDELNHG[i].ANDGMDJLDLO_HideTime);
		}
		bw.Flush();
		bw.Close();
		bw.Dispose();
		fs.Dispose();
	}

	// // RVA: 0x16D463C Offset: 0x16D463C VA: 0x16D463C
	private void NDBHHJGGFDF(int _PPFNGGCBJKC_id)
	{
		IBIGBMDANNM f = BFDEHIANFOG.Find((IBIGBMDANNM _IDLHJIOMJBK_data) =>
		{
			//0x92C220
			return _IDLHJIOMJBK_data.MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id;
		});
		if(f != null)
		{
			BFDEHIANFOG.Remove(f);
		}
	}

	// // RVA: 0x16D4768 Offset: 0x16D4768 VA: 0x16D4768
	public void OCGEPBECHGB()
	{
		BFDEHIANFOG.Clear();
		EMJFHKHLHDB = BEKLBBDMAIJ.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0x16D47E8 Offset: 0x16D47E8 VA: 0x16D47E8
	// public int KKPENKOHLCO() { }

	// // RVA: 0x16D47F8 Offset: 0x16D47F8 VA: 0x16D47F8
	private void IMLMNFGDFPE(CACGCMBKHDI_NetBaseAction _ADKIDBJCAJA_action, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		if(!_ADKIDBJCAJA_action.JONHGMCILHM)
		{
			if(!_ADKIDBJCAJA_action.PDAPLCPOCMA)
			{
				if(_ADKIDBJCAJA_action.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
				{
					if(_MOBEEPPKFLG_OnFail != null)
					{
						_MOBEEPPKFLG_OnFail(_ADKIDBJCAJA_action);
					}
				}
			}
		}
		if(_AOCANKOMKFG_OnError != null)
		{
			_AOCANKOMKFG_OnError(_ADKIDBJCAJA_action);
		}
	}

	// // RVA: 0x16D4920 Offset: 0x16D4920 VA: 0x16D4920
	public PIGBKEIAMPE_NetFriendManager()
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
        EMJFHKHLHDB = BEKLBBDMAIJ.HJNNKCMLGFL_0_None/*0*/;
        BFDEHIANFOG = new List<IBIGBMDANNM>(200);
        JFDPPPBMCBK_BlacklistedUsersId = new List<int>(50);
        KAMNNDELNHG = new List<CDDNFEDGCGG>(20);
        PEHPMOBIOJF_SaveDataPath = Application.persistentDataPath + "/SaveData";
        CCJEGGGJJPO_FcaFile = Application.persistentDataPath + "/fca";
    }

	// // RVA: 0x16D4AAC Offset: 0x16D4AAC VA: 0x16D4AAC
	public void HHDGOABFEPC_GetFriendLimit(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if(!_FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("friend_api_cooling_time", 60);
			if (time - LCCEHNMDILJ_LastUpdateGetFriendLimit < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
		}
		JPEIBHJIHPI_FriendLimit = 0;
		PLOOEECNHFB_IsDone = false;
		NGADDGLEGAP_GetFriendsLimit req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NGADDGLEGAP_GetFriendsLimit());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92C26C
			NGADDGLEGAP_GetFriendsLimit r = KFBCOGJKEJP as NGADDGLEGAP_GetFriendsLimit;
			PLOOEECNHFB_IsDone = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_Result.NHPDJADJNCL_friend_limit;
			LCCEHNMDILJ_LastUpdateGetFriendLimit = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _DOGDHKIEBJA_error) =>
		{
			//0x92C494
			PLOOEECNHFB_IsDone = true;
			_AOCANKOMKFG_OnError(_DOGDHKIEBJA_error);
		};
	}

	// // RVA: 0x16D4E68 Offset: 0x16D4E68 VA: 0x16D4E68
	public void PGPLAOGALHD_SetFriendLimit(int _ELEPHBOKIGK_Limit, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		IDIEAPJLNGL_SetFriendsLimit req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IDIEAPJLNGL_SetFriendsLimit());
		req.APOOBGPBNDG_FriendLimit = _ELEPHBOKIGK_Limit;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92C4EC
			IDIEAPJLNGL_SetFriendsLimit r = KFBCOGJKEJP as IDIEAPJLNGL_SetFriendsLimit;
			PLOOEECNHFB_IsDone = true;
			JPEIBHJIHPI_FriendLimit = r.NFEAMMJIMPG_Result.NHPDJADJNCL_friend_limit;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _DOGDHKIEBJA_error) =>
		{
			//0x92C66C
			PLOOEECNHFB_IsDone = true;
			_AOCANKOMKFG_OnError(_DOGDHKIEBJA_error);
		};
	}

	// // RVA: 0x16D5094 Offset: 0x16D5094 VA: 0x16D5094
	public void PFJBNPIBFMO_GetReceivedRequests(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF AOCANKOMKFG_OnError, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if (!_FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("friend_api_cooling_time", 60);
			if (time - MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
		}
		LIEOOJCODFH_NumFriendRequest = 0;
		PLOOEECNHFB_IsDone = false;
		BKEOKNIEHII_HasMoreReceivedRequest = true;
		JCOBBOMCENL_NumNewRequests = 0;
		long LKGLMCFEDBF = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FFJHJGFKMJB_FriendCheckTime;
		DKEIKBMKKNM_GetReceivedFriendRequests req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKEIKBMKKNM_GetReceivedFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92C6C4
			DKEIKBMKKNM_GetReceivedFriendRequests r = KFBCOGJKEJP as DKEIKBMKKNM_GetReceivedFriendRequests;
			PLOOEECNHFB_IsDone = true;
			int num = 30;
			if (r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count < 31)
			{
				num = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			}
			LIEOOJCODFH_NumFriendRequest = num;
			BKEOKNIEHII_HasMoreReceivedRequest = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count > 30;
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Count; i++)
			{
				if(LKGLMCFEDBF < r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests[i].IFNLEKOILPM_updated_at)
				{
					JCOBBOMCENL_NumNewRequests++;
				}
			}
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _DOGDHKIEBJA_error) =>
		{
			//0x92CAEC
			PLOOEECNHFB_IsDone = true;
			AOCANKOMKFG_OnError(_DOGDHKIEBJA_error);
		};
	}

	// // RVA: 0x16D54F4 Offset: 0x16D54F4 VA: 0x16D54F4
	public void MEJHFCBFPED_GetSentRequests(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if (!_FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int coolTime = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("friend_api_cooling_time", 60);
			if (time - AEGKFFCKLNL_LastUpdateGetSentRequests < coolTime)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
		}
		PPCNLKHHMFK_NumSentRequest = 0;
		PLOOEECNHFB_IsDone = false;
		EMBDPGBMCBF_HasMoreSentRequest = false;
		KCLELFBECJK_GetSentFriendRequests req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KCLELFBECJK_GetSentFriendRequests());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92CB44
			KCLELFBECJK_GetSentFriendRequests r = KFBCOGJKEJP as KCLELFBECJK_GetSentFriendRequests;
			PLOOEECNHFB_IsDone = true;
			int num = 30; 
			if(r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count < 31)
			{
				num = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			}
			PPCNLKHHMFK_NumSentRequest = num;
			EMBDPGBMCBF_HasMoreSentRequest = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count > 30;
			AEGKFFCKLNL_LastUpdateGetSentRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _DOGDHKIEBJA_error) =>
		{
			//0x92CE0C
			PLOOEECNHFB_IsDone = true;
			_AOCANKOMKFG_OnError(_DOGDHKIEBJA_error);
		};
	}

	// // RVA: 0x16D58B4 Offset: 0x16D58B4 VA: 0x16D58B4
	public void BMJANOADDCC_GetFriends(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		NMOJPDCBGMK_NumFriendNoFav = 0;
		PLOOEECNHFB_IsDone = false;
		List<int> FAMHAPONILI_PlayerIds = new List<int>();
		NAOOAJGKILJ_GetFriends COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF s = null;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF f = null;
		f = (CACGCMBKHDI_NetBaseAction _DOGDHKIEBJA_error) =>
		{
			//0x92D344
			PLOOEECNHFB_IsDone = true;
			_AOCANKOMKFG_OnError(_DOGDHKIEBJA_error);
		};
		s = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92CE64
			NAOOAJGKILJ_GetFriends r = KFBCOGJKEJP as NAOOAJGKILJ_GetFriends;
			int friendNoFav = 0;
			for(int i = 0; i < r.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends.Count; i++)
			{
				CHPIKCFKJOA a = r.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i];
				friendNoFav += a.JPFFIBCDCNJ_friend.NEILEPPJKIN_favorite == 0 ? 1 : 0;
				FAMHAPONILI_PlayerIds.Add(a.JPFFIBCDCNJ_friend.NPMIJMFMEKB_target_player_id);
			}
			NMOJPDCBGMK_NumFriendNoFav += friendNoFav;
			if(r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
			{
				PLOOEECNHFB_IsDone = true;
				AONMOEOHFGP_TargetPlayerIds = FAMHAPONILI_PlayerIds;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
				COJNCNGHIJC_Req.IGNIIEBMFIN_Page = r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
				COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
				COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = s;
				COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = f;
			}

		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = s;
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = f;
	}

	// // RVA: 0x16D5B90 Offset: 0x16D5B90 VA: 0x16D5B90
	// public void KIOJKHJNNNJ(SakashoPlayerCriteria _IPKCADIAAPG_Criteria, SakashoPlayerData.SearchOrder _EILKGEADKGH_Order, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError) { }

	// // RVA: 0x16D6084 Offset: 0x16D6084 VA: 0x16D6084
	public int CDOBDJFJLPG_GetRecheckTime()
	{
		int res = 0;
		if(GBLOMHMEMIC_LastSearchTime != 0)
		{
			res = 10;
			if(LNHFLJBGGJB_IsRunning)
			{
				long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				if (time < GBLOMHMEMIC_LastSearchTime + 3)
				{
					res = (int)(GBLOMHMEMIC_LastSearchTime + 3 - time);
				}
			}
		}
		return res;
	}

	// // RVA: 0x16D61B0 Offset: 0x16D61B0 VA: 0x16D61B0
	public void CHAILEPDOPJ(EMOLDNAEDMG JENNNPEFPGF, EMOLDNAEDMG PFDAJGNEBJM, EMOLDNAEDMG PDIMJPKFILN, IMCBBOAFION BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		DPLHEBFFOBA_SelectPlayerHideTime = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("select_player_hide_time", 7200);
		long serverTime = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
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
		PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		GBLOMHMEMIC_LastSearchTime = CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		LNHFLJBGGJB_IsRunning = true;
		LNGMNNNJBJP_SearchForPlayer req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP_SearchForPlayer>(new LNGMNNNJBJP_SearchForPlayer());
		req.IPKCADIAAPG_Criteria = JENNNPEFPGF.IDLHJIOMJBK_data;
		req.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		req.MLPLGFLKKLI_Ipp = JENNNPEFPGF.MLPLGFLKKLI_Ipp;
		req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
		req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x16DC804
			int idx = KAMNNDELNHG.FindIndex((CDDNFEDGCGG _GHPLINIACBB_x) =>
			{
				//0x16DD660
				return _GHPLINIACBB_x.MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id;
			});
			if(idx < 0)
			{
				IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
				if (data == null)
					return false;
				CCMMIECBIOP.Add(data);
			}
			return true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x16DC9AC
			PLOOEECNHFB_IsDone = false;
			LNHFLJBGGJB_IsRunning = false;
			IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x16DCA2C
			LNGMNNNJBJP_SearchForPlayer req2 = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP_SearchForPlayer>(new LNGMNNNJBJP_SearchForPlayer());
			req2.IPKCADIAAPG_Criteria = PFDAJGNEBJM.IDLHJIOMJBK_data;
			req2.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
			req2.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			req2.MLPLGFLKKLI_Ipp = PFDAJGNEBJM.MLPLGFLKKLI_Ipp;
			req2.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
			{
				//0x16DCC9C
				int idx = KAMNNDELNHG.FindIndex((CDDNFEDGCGG _GHPLINIACBB_x) =>
				{
					//0x9235A8
					return _GHPLINIACBB_x.MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id;
				});
				if(idx < 0 && !_MLEHCBKPNGK_IsFriend)
				{
					idx = OGAGAFPCBOC.FindIndex((IBIGBMDANNM _PMBEODGMMBB_y) =>
					{
						//0x9235E0
						return _PMBEODGMMBB_y.MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id;
					});
					if(idx < 0)
					{
						IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
						if (data == null)
							return false;
						OGAGAFPCBOC.Add(data);
					}
				}
				return true;
			};
			req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction OIHMJDCHIIO) =>
			{
				//0x16DD698
				PLOOEECNHFB_IsDone = true;
				LNHFLJBGGJB_IsRunning = false;
				IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
			};
			req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction OIHMJDCHIIO) =>
			{
				//0x16DD798
				int num = CCMMIECBIOP.Count;
				if (JENNNPEFPGF.ADPPAIPFHML_num < CCMMIECBIOP.Count)
				{
					num = JENNNPEFPGF.ADPPAIPFHML_num;
				}
				if(OGAGAFPCBOC.Count < (JENNNPEFPGF.ADPPAIPFHML_num - num) + PFDAJGNEBJM.ADPPAIPFHML_num)
				{
					LNGMNNNJBJP_SearchForPlayer req3 = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest<LNGMNNNJBJP_SearchForPlayer>(new LNGMNNNJBJP_SearchForPlayer());
					req3.IPKCADIAAPG_Criteria = PDIMJPKFILN.IDLHJIOMJBK_data;
					req3.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
					req3.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
					req3.MLPLGFLKKLI_Ipp = PDIMJPKFILN.MLPLGFLKKLI_Ipp;
					req3.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
					{
						//0x16DCEC4
						if(!_MLEHCBKPNGK_IsFriend)
						{
							int idx = OGAGAFPCBOC.FindIndex((IBIGBMDANNM _PMBEODGMMBB_y) =>
							{
								//0x92362C
								return _PMBEODGMMBB_y.MLPEHNBNOGD_PlayerId == _PPFNGGCBJKC_id;
							});
							if(idx < 0)
							{
								IBIGBMDANNM data = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
								if (data == null)
									return false;
								OGFBMMOGFLJ.Add(data);
							}
						}
						return true;
					};
					req3.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction AMGHBMDOOEH) =>
					{
						//0x16DDDE4
						PLOOEECNHFB_IsDone = true;
						LNHFLJBGGJB_IsRunning = false;
						IMLMNFGDFPE(NHECPMNKEFK, MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
					};
					req3.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction AMGHBMDOOEH) =>
					{
						//0x16DD058
						NPGOGNGOBOE(CCMMIECBIOP, OGAGAFPCBOC, OGFBMMOGFLJ, JENNNPEFPGF.ADPPAIPFHML_num, PFDAJGNEBJM.ADPPAIPFHML_num);
						if(BFDEHIANFOG.Count == 0)
						{
							BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
							data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
							IBIGBMDANNM data2 = new IBIGBMDANNM();
							data2.AHEFHIMGIBI_PlayerData = data;
							data2.MLPEHNBNOGD_PlayerId = -1;
							data2.LBODHBDOMGK_PlayerName = JpStringLiterals.StringLiteral_9806;
							data2.LFKJNMFFCLH_LastLoginString = JpStringLiterals.StringLiteral_13106;
							data2.PDJEMLMOEPF_CenterDivaId = 1;
							data2.FCKJJGIMPPI_Level = 1;
							throw new SerchGuestNotFoundException("from=" + PFDAJGNEBJM.IDLHJIOMJBK_data.NumberFrom + ",to=" + PFDAJGNEBJM.IDLHJIOMJBK_data.NumberTo);
						}
						EMJFHKHLHDB = /*4*/BEKLBBDMAIJ.INFDLLGDBAO;
						LNHFLJBGGJB_IsRunning = false;
						PLOOEECNHFB_IsDone = true;
						if (BHFHGFKBOHH_OnSuccess != null)
						{
							BHFHGFKBOHH_OnSuccess();
						}
					};
					return;
				}
				NPGOGNGOBOE(CCMMIECBIOP, OGAGAFPCBOC, OGFBMMOGFLJ, JENNNPEFPGF.ADPPAIPFHML_num, PFDAJGNEBJM.ADPPAIPFHML_num);
				EMJFHKHLHDB = BEKLBBDMAIJ.INFDLLGDBAO/*4*/;
				LNHFLJBGGJB_IsRunning = false;
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
		PMBEODGMMBB_y = (uint)(Utility.GetCurrentUnixTime() ^ 0x15ab17a1);
	}

	// // RVA: 0x16D69D4 Offset: 0x16D69D4 VA: 0x16D69D4
	// private int HEPEDNJMCFA(int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) { }

	// // RVA: 0x16D6A08 Offset: 0x16D6A08 VA: 0x16D6A08
	private void DLPHPGJCAAF_RandomizeList(List<IBIGBMDANNM> NNDGIAEFMOG)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 0xd);
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y >> 0x11);
				PMBEODGMMBB_y = PMBEODGMMBB_y ^ (PMBEODGMMBB_y << 5);
				int a = (int)(PMBEODGMMBB_y % NNDGIAEFMOG.Count);
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
	public void POEDEMPINCH(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		NMOJPDCBGMK_NumFriendNoFav = 0;
		PLOOEECNHFB_IsDone = false;
        PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		NAOOAJGKILJ_GetFriends COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		List<int> FAMHAPONILI_PlayerIds = new List<int>();
		COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF ICFBPFMLNCD = null;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF PDGBAAFHIBP = null;
		List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
		BFDEHIANFOG.Clear();
		PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x923678
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x9236F0
			NAOOAJGKILJ_GetFriends r = KFBCOGJKEJP as NAOOAJGKILJ_GetFriends;
			AIIOKIHEPDP_FriendCount = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			if(AIIOKIHEPDP_FriendCount == 0)
			{
				PLOOEECNHFB_IsDone = true;
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				int a = 0;
				for(int i = 0; i < r.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends.Count; i++)
				{
					a += r.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i].JPFFIBCDCNJ_friend.NEILEPPJKIN_favorite == 0 ? 1 : 0;
					FAMHAPONILI_PlayerIds.Add(r.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i].JPFFIBCDCNJ_friend.NPMIJMFMEKB_target_player_id);
				}
				NMOJPDCBGMK_NumFriendNoFav += a;
				if(r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
				{
					NJNCAHLIHNI_GetPlayerData LBHGPLCOCHD_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
					int GOHNHANPPEJ = 50;
					LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds.GetRange(0, Mathf.Min(FAMHAPONILI_PlayerIds.Count, 50));
					BBHNACPENDM_ServerSaveData EHDDJFNOBFN = new BBHNACPENDM_ServerSaveData();
					EHDDJFNOBFN.EBKCPELHDKN_InitWithBaseAndPublicStatus();
					LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
					ICFBPFMLNCD = null;
					PDGBAAFHIBP = null;
					MEIEDGPOMOO CMJMGEFNBDK = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
					{
						//0x923FCC
						IBIGBMDANNM d = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, true, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
						if(d != null)
						{
							IODPMHILFDI.Add(d);
							return true;
						}
						return false;
					}; // PINPBOCDKLI_OnPlayerCb
					PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) =>
					{
						//0x9240AC
						PLOOEECNHFB_IsDone = true;
						IMLMNFGDFPE(DLMLKJACBPM, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
					};
					ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction MLBCPDDFCMN) =>
					{
						//0x924124
						for(int i = 0; i < IODPMHILFDI.Count; i++)
						{
							BFDEHIANFOG.Add(IODPMHILFDI[i]);
						}
						EMJFHKHLHDB = BEKLBBDMAIJ.CCAPCGPIIPF_1_Normal;
						if(FAMHAPONILI_PlayerIds.Count - GOHNHANPPEJ < 1)
						{
							if(_BHFHGFKBOHH_OnSuccess != null)
								_BHFHGFKBOHH_OnSuccess();
							PLOOEECNHFB_IsDone = true;
						}
						else
						{
							LBHGPLCOCHD_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
							LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds.GetRange(GOHNHANPPEJ, Mathf.Min(FAMHAPONILI_PlayerIds.Count - GOHNHANPPEJ, 50));
							LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
							LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = CMJMGEFNBDK;
							LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
							LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
							GOHNHANPPEJ += 50;
							IODPMHILFDI.Clear();
						}
					};
					LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
					LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
					LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = CMJMGEFNBDK;
				}
				else
				{
					COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
					COJNCNGHIJC_Req.IGNIIEBMFIN_Page = r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
					COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
					COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
					COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
				}
			}
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;

    }

	// // RVA: 0x16D7244 Offset: 0x16D7244 VA: 0x16D7244
	public void CKJHFFHFPLH_GetFriends(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
        PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		NAOOAJGKILJ_GetFriends COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
		List<int> FAMHAPONILI_PlayerIds = new List<int>(200);
		COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
		COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF ICFBPFMLNCD = null;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF PDGBAAFHIBP = null;
		PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x92458C
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x924604
			NAOOAJGKILJ_GetFriends req = KFBCOGJKEJP as NAOOAJGKILJ_GetFriends;
			for(int i = 0; i < req.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends.Count; i++)
			{
				FAMHAPONILI_PlayerIds.Add(req.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i].JPFFIBCDCNJ_friend.NPMIJMFMEKB_target_player_id);
			}
			if(req.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
			{
				AONMOEOHFGP_TargetPlayerIds = FAMHAPONILI_PlayerIds;
				_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
				COJNCNGHIJC_Req.IGNIIEBMFIN_Page = req.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
				COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 100;
				COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
				COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
			}
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
    }

	// // RVA: 0x16D74F4 Offset: 0x16D74F4 VA: 0x16D74F4
	public bool PDEACDHIJJJ_IsFriend(int _MLPEHNBNOGD_PlayerId)
	{
		if(AONMOEOHFGP_TargetPlayerIds != null)
			return AONMOEOHFGP_TargetPlayerIds.Contains(_MLPEHNBNOGD_PlayerId); 
		Debug.LogError("friendListIds is null");
		return false;
	}

	// // RVA: 0x16D75B4 Offset: 0x16D75B4 VA: 0x16D75B4
	public void GJODIMMDJHJ(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		BFDEHIANFOG.Clear();
		PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		KCLELFBECJK_GetSentFriendRequests COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new KCLELFBECJK_GetSentFriendRequests());
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x9249A0
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x924A18
			KCLELFBECJK_GetSentFriendRequests r = KFBCOGJKEJP as KCLELFBECJK_GetSentFriendRequests;
			int cnt = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			if (cnt > 30)
				cnt = 30;
			PPCNLKHHMFK_NumSentRequest = cnt;
			EMBDPGBMCBF_HasMoreSentRequest = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count > 30;
			AEGKFFCKLNL_LastUpdateGetSentRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count == 0)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				List<int> l = new List<int>(r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Count);
				for(int i = 0; i < r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Count; i++)
				{
					l.Add(r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests[i].NMICBJDPLOH_player.PPFNGGCBJKC_id);
				}
				List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
				NJNCAHLIHNI_GetPlayerData req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
				req.FAMHAPONILI_PlayerIds = l;
				BBHNACPENDM_ServerSaveData s = new BBHNACPENDM_ServerSaveData();
				s.EBKCPELHDKN_InitWithBaseAndPublicStatus();
				req.HHIHCJKLJFF_Names = s.KPIDBPEKMFD_GetNames();
				req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
				{
					//0x9250F4
					IBIGBMDANNM d = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
					if(d != null)
					{
						d.LHMDABPNDDH_state = IBIGBMDANNM.LJJOIIAEICI_FriendStatus.BGHNFBANAMN_2_Requested;
						KCLELFBECJK_GetSentFriendRequests.OOOBEMOGJAC f = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Find((KCLELFBECJK_GetSentFriendRequests.OOOBEMOGJAC _GHPLINIACBB_x) =>
						{
							//0x925520
							return _GHPLINIACBB_x.NMICBJDPLOH_player.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
						});
						if(f != null)
						{
							d.DHIFKMEFABP = f.BIOGKIEECGN_created_at;
						}
						IODPMHILFDI.Add(d);
						return true;
					}
					return false;
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction MLBCPDDFCMN) =>
				{
					//0x9252F8
					BFDEHIANFOG.Clear();
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						BFDEHIANFOG.Add(IODPMHILFDI[i]);
					}
					EMJFHKHLHDB = BEKLBBDMAIJ.BJACNBJLCHJ_3;
					if(_BHFHGFKBOHH_OnSuccess != null)
						_BHFHGFKBOHH_OnSuccess();
					PLOOEECNHFB_IsDone = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) =>
				{
					//0x92507C
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(DLMLKJACBPM, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				};
			}
		};
	}

	// // RVA: 0x16D7814 Offset: 0x16D7814 VA: 0x16D7814
	public void IJGADKKPAGJ(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		long LKGLMCFEDBF = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FFJHJGFKMJB_FriendCheckTime;
		JCOBBOMCENL_NumNewRequests = 0;
		BFDEHIANFOG.Clear();
		PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		DKEIKBMKKNM_GetReceivedFriendRequests COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DKEIKBMKKNM_GetReceivedFriendRequests());
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x925574
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x9255EC
			DKEIKBMKKNM_GetReceivedFriendRequests r = KFBCOGJKEJP as DKEIKBMKKNM_GetReceivedFriendRequests;
			int resCount = 30;
			if (r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count < 31)
				resCount = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			LIEOOJCODFH_NumFriendRequest = resCount;
			BKEOKNIEHII_HasMoreReceivedRequest = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count > 30;
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count == 0)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				List<int> l = new List<int>(r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Count);
				for(int i = 0; i < r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Count; i++)
				{
					l.Add(r.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests[i].NMICBJDPLOH_player.PPFNGGCBJKC_id);
				}
				List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
				BBHNACPENDM_ServerSaveData s = new BBHNACPENDM_ServerSaveData();
				s.EBKCPELHDKN_InitWithBaseAndPublicStatus();
				NJNCAHLIHNI_GetPlayerData req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
				req.FAMHAPONILI_PlayerIds = l;
				req.HHIHCJKLJFF_Names = s.KPIDBPEKMFD_GetNames();
				req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
				{
					//0x925D0C
					IBIGBMDANNM d = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
					if(d != null)
					{
						d.LHMDABPNDDH_state = IBIGBMDANNM.LJJOIIAEICI_FriendStatus.FCDDHHKAGEP_3_Request;
						DKEIKBMKKNM_GetReceivedFriendRequests.PODLAHEGOPG_RequestsInfo f = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.PBHBFBNFPJI_friend_requests.Find((DKEIKBMKKNM_GetReceivedFriendRequests.PODLAHEGOPG_RequestsInfo _GHPLINIACBB_x) =>
						{
							//0x926264
							return _GHPLINIACBB_x.NMICBJDPLOH_player.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
						});
						if(f != null)
						{
							d.DHIFKMEFABP = f.BIOGKIEECGN_created_at;
							d.NEILEPPJKIN_favorite = LKGLMCFEDBF >= f.IFNLEKOILPM_updated_at ? 1 : 0;
						}
						IODPMHILFDI.Add(d);
						return true;
					}
					return false;
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction MLBCPDDFCMN) =>
				{
					//0x925F4C
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FFJHJGFKMJB_FriendCheckTime = CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					BFDEHIANFOG.Clear();
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						BFDEHIANFOG.Add(IODPMHILFDI[i]);
					}
					EMJFHKHLHDB = BEKLBBDMAIJ.MDKMGHFJCNE_2;
					if (_BHFHGFKBOHH_OnSuccess != null)
						_BHFHGFKBOHH_OnSuccess();
					PLOOEECNHFB_IsDone = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _CNAIDEAFAAM_Error) =>
				{
					//0x925CBC
					PLOOEECNHFB_IsDone = true;
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(_CNAIDEAFAAM_Error);
				};
			}
		};
	}

	// // RVA: 0x16D7B14 Offset: 0x16D7B14 VA: 0x16D7B14
	public void LJMOBJNEHPM(int FBNPCFPONBN, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		BFDEHIANFOG.Clear();
		List<int> l = new List<int>();
		l.Add(FBNPCFPONBN);
		List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_PlayerIds = l;
		req.HHIHCJKLJFF_Names = data.KPIDBPEKMFD_GetNames();
		req.NBFDEFGFLPJ = (SakashoErrorId _CPILGOCFBNM_ErrorId) =>
		{
			//0x16DC7F4
			return _CPILGOCFBNM_ErrorId == SakashoErrorId.PLAYER_ID_NOT_FOUND;
		};
		req.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x9262B8
			IBIGBMDANNM item = IBIGBMDANNM.HEGEKFMJNCC<IBIGBMDANNM>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
			if(item != null)
			{
				if(item.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_tutorial_end != 0)
				{
					IODPMHILFDI.Add(item);
				}
				return true;
			}
			return false;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction MLBCPDDFCMN) =>
		{
			//0x9263DC
			BFDEHIANFOG.Clear();
			for(int i = 0; i < IODPMHILFDI.Count; i++)
			{
				BFDEHIANFOG.Add(IODPMHILFDI[i]);
			}
			EMJFHKHLHDB = BEKLBBDMAIJ.CCAPCGPIIPF_1_Normal;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			PLOOEECNHFB_IsDone = true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _CNAIDEAFAAM_Error) =>
		{
			//0x926588
			IMLMNFGDFPE(_CNAIDEAFAAM_Error, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
			PLOOEECNHFB_IsDone = true;
		};
	}

	// // RVA: 0x16D7F54 Offset: 0x16D7F54 VA: 0x16D7F54
	private bool LBIDNNNIFBD(SakashoErrorId KLCMLLLIANB)
	{
		if (KLCMLLLIANB >= SakashoErrorId.FRIEND_NOT_FOUND && KLCMLLLIANB < SakashoErrorId.REQUEST_BODY_NOT_ALLOWED)
			return ((969 >> ((int)KLCMLLLIANB - 45)) & 1) != 0;
		return false;
	}

	// // RVA: 0x16D7F78 Offset: 0x16D7F78 VA: 0x16D7F78
	private bool DENFAJIBOOO(string LIDBGALGECP, SakashoErrorId KLCMLLLIANB, IMCBBOAFION _HIDFAIBOHCC_OnSuccess)
	{
		MessageBank bk = MessageManager.Instance.GetBank("common");
		switch(KLCMLLLIANB)
		{
			case SakashoErrorId.ALREADY_BECOME_FRIEND:
				JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.JNFBLHKMMBI(bk.GetMessageByLabel("popup_already_friend_title"), string.Format(bk.GetMessageByLabel("popup_already_friend_01"), LIDBGALGECP), _HIDFAIBOHCC_OnSuccess);
				return true;
			case SakashoErrorId.ALREADY_SENT_FRIEND_REQUEST:
				JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.JNFBLHKMMBI(bk.GetMessageByLabel("popup_friend_limit_title"), string.Format(bk.GetMessageByLabel("popup_friend_limit_02"), LIDBGALGECP), _HIDFAIBOHCC_OnSuccess);
				return true;
			case SakashoErrorId.FRIEND_LIMIT_EXCEEDED:
				JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.JNFBLHKMMBI(bk.GetMessageByLabel("popup_friend_limit_title"), string.Format(bk.GetMessageByLabel("popup_friend_limit_01"), LIDBGALGECP), _HIDFAIBOHCC_OnSuccess);
				return true;
			default:
				break;
		}
		return false;
	}

	// // RVA: 0x16D82AC Offset: 0x16D82AC VA: 0x16D82AC
	public void AOHLMBKILED(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		if(HPFDEEDLBOA == -1)
		{
			if(_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			ILLPDLODANB.HECOAKHIAKP(ILLPDLODANB.LOEGALDKHPL_ValueType.OKEIMJEMKKJ_27_MissionSendFriendRequest, 2, false);
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			PLOOEECNHFB_IsDone = false;
			JGBGKCDCBJN_SendFriendRequest COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGBGKCDCBJN_SendFriendRequest());
			COJNCNGHIJC_Req.NBFDEFGFLPJ = LBIDNNNIFBD;
			COJNCNGHIJC_Req.HPFDEEDLBOA = HPFDEEDLBOA;
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x926608
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
				AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
				if(!DENFAJIBOOO(LIDBGALGECP, NHECPMNKEFK.CJMFJOMECKI_ErrorId, () =>
				{
					//0x926BFC
					PLOOEECNHFB_IsDone = true;
					if(_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(NHECPMNKEFK);
				}))
				{
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				}
			};
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x9267E8
				int a1 = 0;
				if(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.HasValue)
				{
					a1 = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.Value;
				}
				int a2 = a1;
				if(a2 > 30)
					a2 = 30;
				PPCNLKHHMFK_NumSentRequest = a1;
				EMBDPGBMCBF_HasMoreSentRequest = a1 > 30;
				AEGKFFCKLNL_LastUpdateGetSentRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
				AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
				a1 = AIIOKIHEPDP_FriendCount;
				if(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.HasValue)
				{
					a1 = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
				}
				ILCCJNDFFOB.HHCJCDFCLOB_Instance.MNFOJMBPHEN_Friend(HPFDEEDLBOA, OCJLKGDPOMH, 0, a1, JPEIBHJIHPI_FriendLimit);
				ILLPDLODANB.HECOAKHIAKP(ILLPDLODANB.LOEGALDKHPL_ValueType.OKEIMJEMKKJ_27_MissionSendFriendRequest, 2, false);
				PLOOEECNHFB_IsDone = true;
			};
		}
	}

	// // RVA: 0x16D86DC Offset: 0x16D86DC VA: 0x16D86DC
	public void ADOIKCJALGM(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		OPGJOOCPIPE req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OPGJOOCPIPE());
		req.NBFDEFGFLPJ = LBIDNNNIFBD;
		req.HPFDEEDLBOA = HPFDEEDLBOA;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x926CA8
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.FRIEND_REQUEST_NOT_FOUND)
			{
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
				AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
				MessageBank bk = MessageManager.Instance.GetBank("common");
				JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.JNFBLHKMMBI(bk.GetMessageByLabel("popup_accept_fail_title"), string.Format(bk.GetMessageByLabel("popup_accept_fail_01"), LIDBGALGECP), () =>
				{
					//0x9275E8
					PLOOEECNHFB_IsDone = true;
					if(_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(NHECPMNKEFK);
				});
			}
			else
			{
				if(!DENFAJIBOOO(LIDBGALGECP, NHECPMNKEFK.CJMFJOMECKI_ErrorId, () =>
				{
					//0x92768C
					PLOOEECNHFB_IsDone = true;
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(NHECPMNKEFK);
				}))
				{
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				}
			}
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x927064
			OPGJOOCPIPE r = NHECPMNKEFK as OPGJOOCPIPE;
			if (r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count != null)
			{
				AIIOKIHEPDP_FriendCount = r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
			}
			if(r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count != null)
			{
				int cnt = r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.Value;
				if (cnt > 30)
					cnt = 30;
				LIEOOJCODFH_NumFriendRequest = cnt;
				BKEOKNIEHII_HasMoreReceivedRequest = r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.Value > 30;
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			int fCnt = AIIOKIHEPDP_FriendCount;
			if (r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count != null)
			{
				fCnt = r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
			}
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.MNFOJMBPHEN_Friend(HPFDEEDLBOA, OCJLKGDPOMH, 1, fCnt, JPEIBHJIHPI_FriendLimit);
			if(EMJFHKHLHDB == BEKLBBDMAIJ.MDKMGHFJCNE_2)
			{
				NDBHHJGGFDF(HPFDEEDLBOA);
			}
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			PLOOEECNHFB_IsDone = true;
		};
	}

	// // RVA: 0x16D89C8 Offset: 0x16D89C8 VA: 0x16D89C8
	public void CCBALBLFNDN(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		OEKFOBHFBNK req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OEKFOBHFBNK());
		req.NBFDEFGFLPJ = LBIDNNNIFBD;
		req.HPFDEEDLBOA = HPFDEEDLBOA;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x927738
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if(NHECPMNKEFK.CJMFJOMECKI_ErrorId != SakashoErrorId.FRIEND_REQUEST_NOT_FOUND)
			{
				if(!DENFAJIBOOO(LIDBGALGECP, NHECPMNKEFK.CJMFJOMECKI_ErrorId, () =>
				{
					//0x927EC4
					PLOOEECNHFB_IsDone = true;
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(NHECPMNKEFK);
				}))
				{
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				}
			}
			else
			{
				if(EMJFHKHLHDB == BEKLBBDMAIJ.MDKMGHFJCNE_2)
				{
					NDBHHJGGFDF(HPFDEEDLBOA);
				}
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
				AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				PLOOEECNHFB_IsDone = true;
			}
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x927A08
			OEKFOBHFBNK r = NHECPMNKEFK as OEKFOBHFBNK;
			if(r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count != null)
			{
				int cnt = r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.Value;
				if (cnt > 30)
					cnt = 30;
				LIEOOJCODFH_NumFriendRequest = cnt;
				BKEOKNIEHII_HasMoreReceivedRequest = r.NFEAMMJIMPG_Result.LCAJFJMHHLG_friend_request_count.Value > 30;
				MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
			if(EMJFHKHLHDB == BEKLBBDMAIJ.MDKMGHFJCNE_2)
			{
				NDBHHJGGFDF(HPFDEEDLBOA);
			}
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			int fCnt = AIIOKIHEPDP_FriendCount;
			if (r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count != null)
			{
				fCnt = r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
			}
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.MNFOJMBPHEN_Friend(HPFDEEDLBOA, OCJLKGDPOMH, 3, fCnt, JPEIBHJIHPI_FriendLimit);
			PLOOEECNHFB_IsDone = true;
		};
	}

	// // RVA: 0x16D8CC4 Offset: 0x16D8CC4 VA: 0x16D8CC4
	// public void FFIBIAEJBNC(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError) { }

	// // RVA: 0x16D8FC8 Offset: 0x16D8FC8 VA: 0x16D8FC8
	public void PBEDDFMFDKB(int HPFDEEDLBOA, string LIDBGALGECP, int OCJLKGDPOMH, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		IPFFNIHDFPO_DeleteFriend COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IPFFNIHDFPO_DeleteFriend());
		COJNCNGHIJC_Req.HPFDEEDLBOA = HPFDEEDLBOA;
		COJNCNGHIJC_Req.NBFDEFGFLPJ = LBIDNNNIFBD;
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x928890
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId == SakashoErrorId.FRIEND_NOT_FOUND)
			{
				if(!DENFAJIBOOO(LIDBGALGECP, COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId, () =>
				{
					//0x928FA4
					PLOOEECNHFB_IsDone = true;
					if(_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail(NHECPMNKEFK);
				}))
				{
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				}
			}
			else
			{
				if(EMJFHKHLHDB == BEKLBBDMAIJ.CCAPCGPIIPF_1_Normal)
				{
					NDBHHJGGFDF(HPFDEEDLBOA);
				}
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				ILCCJNDFFOB.HHCJCDFCLOB_Instance.MNFOJMBPHEN_Friend(HPFDEEDLBOA, OCJLKGDPOMH, 2, AIIOKIHEPDP_FriendCount, JPEIBHJIHPI_FriendLimit);
				PLOOEECNHFB_IsDone = true;
			}
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x928BD8
			IPFFNIHDFPO_DeleteFriend r = NHECPMNKEFK as IPFFNIHDFPO_DeleteFriend;
			if(r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.HasValue)
			{
				AIIOKIHEPDP_FriendCount = r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
			}
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if(EMJFHKHLHDB == BEKLBBDMAIJ.CCAPCGPIIPF_1_Normal)
			{
				NDBHHJGGFDF(HPFDEEDLBOA);
			}
			if(_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			int friendCount = AIIOKIHEPDP_FriendCount;
			if(r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.HasValue)
			{
				friendCount = r.NFEAMMJIMPG_Result.IAFEEMCLNMC_friend_count.Value;
			}
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.MNFOJMBPHEN_Friend(HPFDEEDLBOA, OCJLKGDPOMH, 2, friendCount, JPEIBHJIHPI_FriendLimit);
			PLOOEECNHFB_IsDone = true;
		};
	}

	// // RVA: 0x16D92D0 Offset: 0x16D92D0 VA: 0x16D92D0
	public void EICNBEKECJG(List<int> _FAMHAPONILI_PlayerIds, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		if(_FAMHAPONILI_PlayerIds == null)
		{
			NMOJPDCBGMK_NumFriendNoFav = 0;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			return;
		}
		BABKNDMOIJA req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new BABKNDMOIJA());
		req.FAMHAPONILI_PlayerIds = _FAMHAPONILI_PlayerIds;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x929050
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x929104
			NMOJPDCBGMK_NumFriendNoFav = 0;
			MBPPBKAKIBM_LastUpdateGetReceivedFriendsRequests = 0;
			AEGKFFCKLNL_LastUpdateGetSentRequests = 0;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			PLOOEECNHFB_IsDone = true;
		};
	}

	// // RVA: 0x16D9538 Offset: 0x16D9538 VA: 0x16D9538
	// public void EICNBEKECJG(List<IBIGBMDANNM> _AHEFHIMGIBI_PlayerData, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError) { }

	// // RVA: 0x16D9714 Offset: 0x16D9714 VA: 0x16D9714
	public static string MKILKPFAOIC_GetLastLoginString(long _BEBJKJKBOGH_date, long EABMEFOJHOJ_ServerTime)
	{
		if(300 >= EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date)
		{
			return ANELGKCJBAA[0];
		}
		else
		{
			if((EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date) <= 3600)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date) % 60);
				return "" + val + ANELGKCJBAA[1];
			}
			else if(EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date <= 86400)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date) % 3600);
				return "" + val + ANELGKCJBAA[2];
			}
			else if(EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date <= 31536000)
			{
				int val = (int)((EABMEFOJHOJ_ServerTime - _BEBJKJKBOGH_date) % 86400);
				return "" + val + ANELGKCJBAA[3];
			}
			else
			{
				return ANELGKCJBAA[4];
			}
		}
	}

	// // RVA: 0x16D9AB8 Offset: 0x16D9AB8 VA: 0x16D9AB8
	// public static SakashoPlayerCriteria NKNOLNNPGAC(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData) { }

	// // RVA: 0x16D9C04 Offset: 0x16D9C04 VA: 0x16D9C04
	// public static SakashoPlayerCriteria NKNOLNNPGAC(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x16D9D54 Offset: 0x16D9D54 VA: 0x16D9D54
	public static int DJHFILDBOFG_GetMaxFanPossible()
	{
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("favorite_player_max", 50);
	}

	// // RVA: 0x16D9E44 Offset: 0x16D9E44 VA: 0x16D9E44
	public static int GKDGOGCOGBK()
	{
		return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.EFNAAHDHCEL();
	}

	// // RVA: 0x16D9F20 Offset: 0x16D9F20 VA: 0x16D9F20
	public void EGLFECJOPPP_SearchFriendAndFavoritePlayer(KIELKOCLIGG _PIBLLGLCJEO_Param, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(PJHEJPKCHHE_Coroutine_SearchFriendAndFavoritePlayer(_PIBLLGLCJEO_Param, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6E98 Offset: 0x6B6E98 VA: 0x6B6E98
	// // RVA: 0x16D9F88 Offset: 0x16D9F88 VA: 0x16D9F88
	private IEnumerator PJHEJPKCHHE_Coroutine_SearchFriendAndFavoritePlayer(KIELKOCLIGG _PIBLLGLCJEO_Param, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LBKPFADGHPK PGPFBCAFOCO; // 0x24
		DPDMNBGAONP OANEIPHEOGA; // 0x28
		NJNCAHLIHNI_GetPlayerData BPOJOBICBAC; // 0x2C

		//0x92D6BC
		PLOOEECNHFB_IsDone = false;
		BFDEHIANFOG.Clear();
		List<IFICNCAHIGI> IODPMHILFDI = new List<IFICNCAHIGI>();
		List<int> FAMHAPONILI_PlayerIds = new List<int>();
		PGPFBCAFOCO = new LBKPFADGHPK();
		PGPFBCAFOCO.IPKCADIAAPG_Criteria = _PIBLLGLCJEO_Param.IPKCADIAAPG_Criteria;
		PGPFBCAFOCO.IPKCADIAAPG_Criteria.OnlyFriends = true;
		PGPFBCAFOCO.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		PGPFBCAFOCO.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(_PIBLLGLCJEO_Param.MCEGJNAABHG);
		PGPFBCAFOCO.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x9291B8
			IFICNCAHIGI data = _PIBLLGLCJEO_Param.IGNHNKJOCKB(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
			if (data == null)
				return false;
			else
			{
				if(_PIBLLGLCJEO_Param.BBCOJEPJNMO != null)
				{
					if (!_PIBLLGLCJEO_Param.BBCOJEPJNMO(data))
						return true;
				}
				IODPMHILFDI.Add(data);
				FAMHAPONILI_PlayerIds.Add(_PPFNGGCBJKC_id);
				return true;
			}
		};
		yield return Co.R(PGPFBCAFOCO.MEGIEMBDGBE_Coroutine(null, null));
		if (PGPFBCAFOCO.NPNNPNAIONN_IsError)
		{
			//LAB_0092dbc4
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail();
			yield break;
		}
		int a = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.EFNAAHDHCEL();
		if(a > 0)
		{
			List<int> l = new List<int>();
			for(int i = 0; i < a; i++)
			{
				int id = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.OKAOABMKPGP(i);
				if (!FAMHAPONILI_PlayerIds.Contains(id))
				{
					l.Add(id);
				}
			}
			if(l.Count > 0)
			{
				BPOJOBICBAC = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
				BPOJOBICBAC.FAMHAPONILI_PlayerIds = l;
				BPOJOBICBAC.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(_PIBLLGLCJEO_Param.MCEGJNAABHG);
				BPOJOBICBAC.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
				{
					//0x929960
					IFICNCAHIGI data = _PIBLLGLCJEO_Param.IGNHNKJOCKB(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
					if(data != null)
					{
						if(_PIBLLGLCJEO_Param.PHCKPOKKBGD != null)
						{
							if (!_PIBLLGLCJEO_Param.PHCKPOKKBGD(data))
								return true;
						}
						IODPMHILFDI.Add(data);
						FAMHAPONILI_PlayerIds.Add(_PPFNGGCBJKC_id);
						return true;
					}
					return false;
				};
				while (!BPOJOBICBAC.PLOOEECNHFB_IsDone)
					yield return null;
				if(BPOJOBICBAC.NPNNPNAIONN_IsError)
				{
					//LAB_0092dbc4
					PLOOEECNHFB_IsDone = true;
					_MOBEEPPKFLG_OnFail();
					yield break;
				}
				if(FAMHAPONILI_PlayerIds.Count > 0)
				{
					OANEIPHEOGA = new DPDMNBGAONP();
					OANEIPHEOGA.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = "fan_count";
					OANEIPHEOGA.BIHCCEHLAOD.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds;
					yield return OANEIPHEOGA.MEGIEMBDGBE_Coroutine(null, null);
					if(OANEIPHEOGA.NPNNPNAIONN_IsError)
					{
						//LAB_0092dbc4
						PLOOEECNHFB_IsDone = true;
						_MOBEEPPKFLG_OnFail();
						yield break;
					}
					Dictionary<int, int> d = OANEIPHEOGA.NFEAMMJIMPG_Result.OJCNJFLJCLA_player_counters;
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						int c;
						if(d.TryGetValue(IODPMHILFDI[i].MLPEHNBNOGD_PlayerId, out c))
						{
							IODPMHILFDI[i].AGDBNNEAIIC_FanNum = c;
						}
					}
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						BFDEHIANFOG.Add(IODPMHILFDI[i]);
					}
					EMJFHKHLHDB = BEKLBBDMAIJ.ANLLGBEIBNF_5;
				}
				//LAB_0092e230
				PLOOEECNHFB_IsDone = true;
				_BHFHGFKBOHH_OnSuccess();
				yield break;
			}
		}
		PLOOEECNHFB_IsDone = true;
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x16DA05C Offset: 0x16DA05C VA: 0x16DA05C
	public void CPEHDILBIJA_SearchPlayerWithoutFriendAndFavorite(int FGHNNFGJKJE, SakashoPlayerCriteria _IPKCADIAAPG_Criteria, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		N.a.StartCoroutineWatched(DAEDHMHBPCI_Coroutine_SearchPlayerWithoutFriendAndFavorite(FGHNNFGJKJE, _IPKCADIAAPG_Criteria, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6F10 Offset: 0x6B6F10 VA: 0x6B6F10
	// // RVA: 0x16DA0CC Offset: 0x16DA0CC VA: 0x16DA0CC
	private IEnumerator DAEDHMHBPCI_Coroutine_SearchPlayerWithoutFriendAndFavorite(int FGHNNFGJKJE, SakashoPlayerCriteria _IPKCADIAAPG_Criteria, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		DPDMNBGAONP HDNENJFAADA;

		//0x92E3D0
		LNHFLJBGGJB_IsRunning = true;
		GBLOMHMEMIC_LastSearchTime = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		BFDEHIANFOG.Clear();
		List<IFICNCAHIGI> IODPMHILFDI = new List<IFICNCAHIGI>(FGHNNFGJKJE);
		List<int> FAMHAPONILI_PlayerIds = new List<int>(FGHNNFGJKJE);
		LFHGFLJLGFB_FavoritePlayer LIFAJNCAJHM = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer;
		LBKPFADGHPK HMNIOFADNAJ = new LBKPFADGHPK();
		HMNIOFADNAJ.IPKCADIAAPG_Criteria = _IPKCADIAAPG_Criteria;
		HMNIOFADNAJ.IPKCADIAAPG_Criteria.OnlyFriends = false;
		HMNIOFADNAJ.EILKGEADKGH_Order = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		HMNIOFADNAJ.HHIHCJKLJFF_Names = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetNames(5);
		HMNIOFADNAJ.PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x929AFC
			if(_OHNJJIMGKGK_Names == null)
			{
				if(!LIFAJNCAJHM.FFKIDMKHIOE(_PPFNGGCBJKC_id))
				{
					IFICNCAHIGI data = IBIGBMDANNM.HEGEKFMJNCC<IFICNCAHIGI>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, false, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
					if (data == null)
						return false;
					IODPMHILFDI.Add(data);
					FAMHAPONILI_PlayerIds.Add(_PPFNGGCBJKC_id);
					HMNIOFADNAJ.NELEMPLILIO = FGHNNFGJKJE <= IODPMHILFDI.Count;
				}
			}
			return true;
		};
		yield return Co.R(HMNIOFADNAJ.MEGIEMBDGBE_Coroutine(null, null));
		if(!HMNIOFADNAJ.NPNNPNAIONN_IsError)
		{
			if(FAMHAPONILI_PlayerIds.Count > 0)
			{
				HDNENJFAADA = new DPDMNBGAONP();
				HDNENJFAADA.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = "fan_count";
				HDNENJFAADA.BIHCCEHLAOD.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds;
				yield return Co.R(HDNENJFAADA.MEGIEMBDGBE_Coroutine(null, null));
				if(!HDNENJFAADA.NPNNPNAIONN_IsError)
				{
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						int a;
						if(HDNENJFAADA.NFEAMMJIMPG_Result.OJCNJFLJCLA_player_counters.TryGetValue(IODPMHILFDI[i].MLPEHNBNOGD_PlayerId, out a))
						{
							IODPMHILFDI[i].AGDBNNEAIIC_FanNum = a;
						}
					}
					for(int i = 0; i < IODPMHILFDI.Count; i++)
					{
						BFDEHIANFOG.Add(IODPMHILFDI[i]);
					}
					EMJFHKHLHDB = BEKLBBDMAIJ.DBDFOJLHOAH_6;
				}
				else
				{
					PLOOEECNHFB_IsDone = true;
					LNHFLJBGGJB_IsRunning = false;
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail();
					yield break;
				}
			}
			PLOOEECNHFB_IsDone = true;
			LNHFLJBGGJB_IsRunning = false;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
			yield break;
		}
		PLOOEECNHFB_IsDone = true;
		LNHFLJBGGJB_IsRunning = false;
		if (_MOBEEPPKFLG_OnFail != null)
			_MOBEEPPKFLG_OnFail();
	}

	// // RVA: 0x16DA1B8 Offset: 0x16DA1B8 VA: 0x16DA1B8
	public void EPKOLKBGOGA(List<int> FNLNHGBGHKF, List<int> EDPCFGCDEFE, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK DDMLOBICBHI)
	{
		for(int i = 0; i < FNLNHGBGHKF.Count; i++)
		{
			if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(FNLNHGBGHKF[i]))
			{
				FNLNHGBGHKF.RemoveAt(i);
				i--;
			}
		}
		for(int i = 0; i < EDPCFGCDEFE.Count; i++)
		{
			if(!CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(EDPCFGCDEFE[i]))
			{
				EDPCFGCDEFE.RemoveAt(i);
				i--;
			}
		}
		if(EDPCFGCDEFE.Count == 0 && FNLNHGBGHKF.Count == 0)
		{
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			int a1 = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.EFNAAHDHCEL();
			if(a1 + FNLNHGBGHKF.Count - EDPCFGCDEFE.Count > DJHFILDBOFG_GetMaxFanPossible())
			{
				PLOOEECNHFB_IsDone = true;
				if(DDMLOBICBHI != null)
					DDMLOBICBHI();
			}
			else
			{
				for(int i = 0; i < FNLNHGBGHKF.Count; i++)
				{
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.BNFBKGHBHHN(FNLNHGBGHKF[i]);
				}
				for(int i = 0; i < EDPCFGCDEFE.Count; i++)
				{
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.LJBFHCDHOHP(EDPCFGCDEFE[i]);
				}
				AJMCNLILIFG_UpdatePlayerCounters req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AJMCNLILIFG_UpdatePlayerCounters());
				req.KAPNGHDIGPD = new List<SakashoPlayerCounterInfo>(EDPCFGCDEFE.Count + FNLNHGBGHKF.Count);
				for(int i = 0; i < EDPCFGCDEFE.Count; i++)
				{
					SakashoPlayerCounterInfo s = new SakashoPlayerCounterInfo();
					s.PlayerCounterMasterName = "fan_count";
					s.CountDelta = -1;
					s.PlayerId = EDPCFGCDEFE[i];
					req.KAPNGHDIGPD.Add(s);
				}
				for(int i = 0; i < FNLNHGBGHKF.Count; i++)
				{
					SakashoPlayerCounterInfo s = new SakashoPlayerCounterInfo();
					s.PlayerCounterMasterName = "fan_count";
					s.CountDelta = 1;
					s.PlayerId = FNLNHGBGHKF[i];
					req.KAPNGHDIGPD.Add(s);
				}
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
				{
					//0x929CA4
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x929DEC
						PLOOEECNHFB_IsDone = true;
						_BHFHGFKBOHH_OnSuccess();
					}, () =>
					{
						//0x929E40
						PLOOEECNHFB_IsDone = true;
						_MOBEEPPKFLG_OnFail();
					}, null);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
				{
					//0x929E94
					PLOOEECNHFB_IsDone = true;
					_MOBEEPPKFLG_OnFail();
				};
			}
		}
	}

	// // RVA: 0x16DABA4 Offset: 0x16DABA4 VA: 0x16DABA4
	public void NDDIOKIKCNA_GetFanCount(int _MLPEHNBNOGD_PlayerId, Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		DKFCEGODKFJ_GetPlayerCounters req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DKFCEGODKFJ_GetPlayerCounters());
		req.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = "fan_count";
		req.BIHCCEHLAOD.FAMHAPONILI_PlayerIds = new List<int>() { _MLPEHNBNOGD_PlayerId };
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x929EF0
			DKFCEGODKFJ_GetPlayerCounters r = _HKICMNAACDA_a as DKFCEGODKFJ_GetPlayerCounters;
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess(r.NFEAMMJIMPG_Result.OJCNJFLJCLA_player_counters[_MLPEHNBNOGD_PlayerId]);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92A058
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail();
		};
	}

	// // RVA: 0x16DAE5C Offset: 0x16DAE5C VA: 0x16DAE5C
	public void CCAOOIMEPAL_GetPlayerFanCount(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NDDIOKIKCNA_GetFanCount(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.MDAMJIGBOLD_PlayerId, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x16DAF20 Offset: 0x16DAF20 VA: 0x16DAF20
	public void BCEAAAOLGEB_Reset()
	{
		JFDPPPBMCBK_BlacklistedUsersId.Clear();
		GJHIHNBANEC = false;
	}

	// // RVA: 0x16DAFA0 Offset: 0x16DAFA0 VA: 0x16DAFA0
	public int OKDGKAHNBPP()
	{
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("blacklist_max", 100);
	}

	// // RVA: 0x16DB090 Offset: 0x16DB090 VA: 0x16DB090
	public void HMANIPMKKFK(int _EHGBICNIBKE_player_id, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP JEMKODBAOEP, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		int GABLLIAOGDB = OKDGKAHNBPP();
		PLOOEECNHFB_IsDone = false;
		List<int> HMDAFLDJLIK = new List<int>();
		HMDAFLDJLIK.Add(_EHGBICNIBKE_player_id);
		ONIGGMCFHAL_IsBlacklisted MABMFHCDJNA = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ONIGGMCFHAL_IsBlacklisted());
		MABMFHCDJNA.MLPEHNBNOGD_PlayerId = _EHGBICNIBKE_player_id;
		MABMFHCDJNA.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92A0B4
			PLOOEECNHFB_IsDone = true;
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.HEKBPBPLPJL(_EHGBICNIBKE_player_id, 1);
			if(MABMFHCDJNA.ELCCCJDLLAJ_Blacklisted)
			{
				_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				DPMKJDMNDNN_GetBlackList LBHGPLCOCHD_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
				LBHGPLCOCHD_Req.IGNIIEBMFIN_Page = 1;
				LBHGPLCOCHD_Req.MLPLGFLKKLI_Ipp = 1;
				LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction BHGCOECCPCO) =>
				{
					//0x92A6B4
					if(LBHGPLCOCHD_Req.NFEAMMJIMPG_Result.HMFFHLPNMPH_count < GABLLIAOGDB)
					{
						CAMEBHNILKA_AddToBlacklist req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CAMEBHNILKA_AddToBlacklist());
						req.FAMHAPONILI_PlayerIds = HMDAFLDJLIK;
						CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_NetBaseAction MEOKEBAMPLA) =>
						{
							//0x92A3A8
							PLOOEECNHFB_IsDone = true;
							int idx = JFDPPPBMCBK_BlacklistedUsersId.FindIndex((int _GHPLINIACBB_x) =>
							{
								//0x92A538
								return _EHGBICNIBKE_player_id == _GHPLINIACBB_x;
							});
							if(idx < 0)
							{
								JFDPPPBMCBK_BlacklistedUsersId.Add(idx);
							}
							_BHFHGFKBOHH_OnSuccess();
						};
						req.BHFHGFKBOHH_OnSuccess = EEIFDMNADPA;
						CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF NDBKOPGCPHJ = (CACGCMBKHDI_NetBaseAction MEOKEBAMPLA) =>
						{
							//0x92A54C
							PLOOEECNHFB_IsDone = true;
							IMLMNFGDFPE(MEOKEBAMPLA, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
						};
						req.MOBEEPPKFLG_OnFail = NDBKOPGCPHJ;
					}
					else
					{
						PLOOEECNHFB_IsDone = true;
						JEMKODBAOEP();
					}
				};
				LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction BHGCOECCPCO) =>
				{
					//0x92A5C4
					PLOOEECNHFB_IsDone = true;
					IMLMNFGDFPE(BHGCOECCPCO, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
				};
			}
		};
		MABMFHCDJNA.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92A63C
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(_HKICMNAACDA_a, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
	}

	// // RVA: 0x16DB434 Offset: 0x16DB434 VA: 0x16DB434
	public void CIBLHBAMIJO(int _EHGBICNIBKE_player_id, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		List<int> l = new List<int>();
		l.Add(_EHGBICNIBKE_player_id);
		PGAHJECLGBB_RemoveFromBlacklist req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PGAHJECLGBB_RemoveFromBlacklist());
		req.FAMHAPONILI_PlayerIds = l;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92A998
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.HEKBPBPLPJL(_EHGBICNIBKE_player_id, 0);
			int idx = JFDPPPBMCBK_BlacklistedUsersId.FindIndex((int _GHPLINIACBB_x) =>
			{
				//0x92AB88
				return _EHGBICNIBKE_player_id == _GHPLINIACBB_x;
			});
			if(idx > -1)
			{
				JFDPPPBMCBK_BlacklistedUsersId.RemoveAt(idx);
			}
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92AB9C
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(_HKICMNAACDA_a, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
	}

	// // RVA: 0x16DB6FC Offset: 0x16DB6FC VA: 0x16DB6FC
	public bool DIGEHCDEAON_IsBlacklisted(int _MLPEHNBNOGD_PlayerId)
	{
		return JFDPPPBMCBK_BlacklistedUsersId.FindIndex((int _GHPLINIACBB_x) =>
		{
			//0x92AC1C
			return _MLPEHNBNOGD_PlayerId == _GHPLINIACBB_x;
		}) > -1;
	}

	// // RVA: 0x16DB804 Offset: 0x16DB804 VA: 0x16DB804
	// public void DIGEHCDEAON_IsBlacklisted(int _MLPEHNBNOGD_PlayerId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError) { }

	// // RVA: 0x16DBA70 Offset: 0x16DBA70 VA: 0x16DBA70
	public void LJLKGPDFEAD_IsBlacklisted(int HPFDEEDLBOA, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP ADNFKFINOBO, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		PLOOEECNHFB_IsDone = false;
		KOOKOIOOEAC_IsOnBlacklistOf COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KOOKOIOOEAC_IsOnBlacklistOf());
		COJNCNGHIJC_Req.MLPEHNBNOGD_PlayerId = HPFDEEDLBOA;
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92AD50
			PLOOEECNHFB_IsDone = true;
			if (!COJNCNGHIJC_Req.ELCCCJDLLAJ_Blacklisted)
				_BHFHGFKBOHH_OnSuccess();
			else
				ADNFKFINOBO();
		};
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction _HKICMNAACDA_a) =>
		{
			//0x92ADE8
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(_HKICMNAACDA_a, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
	}

	// // RVA: 0x16DBCDC Offset: 0x16DBCDC VA: 0x16DBCDC
	public void EKIJICIBGOG_GetBlacklist(bool _FBBNPFFEJBN_Force, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		if(GJHIHNBANEC && !_FBBNPFFEJBN_Force)
		{
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			NKLACAPLMHI_Count = 0;
			PLOOEECNHFB_IsDone = false;
			PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
			DPMKJDMNDNN_GetBlackList COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
			List<int> l = new List<int>();
			List<IBIGBMDANNM> l2 = new List<IBIGBMDANNM>();
			JFDPPPBMCBK_BlacklistedUsersId.Clear();
			CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x92AE68
				PLOOEECNHFB_IsDone = true;
				IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
			};
			CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF ICFBPFMLNCD = null;
			ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
			{
				//0x92AEE0
				DPMKJDMNDNN_GetBlackList r = KFBCOGJKEJP as DPMKJDMNDNN_GetBlackList;
				NKLACAPLMHI_Count = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
				if(r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count == 0)
				{
					GJHIHNBANEC = true;
					PLOOEECNHFB_IsDone = true;
					if (_BHFHGFKBOHH_OnSuccess != null)
						_BHFHGFKBOHH_OnSuccess();
				}
				else
				{
					for(int i = 0; i < r.NFEAMMJIMPG_Result.FOCOFKEFHIO_BlackList.Count; i++)
					{
						JFDPPPBMCBK_BlacklistedUsersId.Add(r.NFEAMMJIMPG_Result.FOCOFKEFHIO_BlackList[i].EHGBICNIBKE_player_id);
					}
					if(r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
					{
						GJHIHNBANEC = true;
						if (_BHFHGFKBOHH_OnSuccess != null)
							_BHFHGFKBOHH_OnSuccess();
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						//JPEIBHJIHPI_FriendLimit
						DPMKJDMNDNN_GetBlackList r2 = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
						r2.IGNIIEBMFIN_Page = r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
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
	public void EGFNFKJOMIM(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		NKLACAPLMHI_Count = 0;
		PLOOEECNHFB_IsDone = false;
		CKJHFFHFPLH_GetFriends(() =>
		{
			//0x92B338
			JPALOIENDOP(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		}, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
	}

	// // RVA: 0x16DC14C Offset: 0x16DC14C VA: 0x16DC14C
	private void JPALOIENDOP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF _AOCANKOMKFG_OnError)
	{
		DPMKJDMNDNN_GetBlackList COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
		List<int> FAMHAPONILI_PlayerIds = new List<int>();
		COJNCNGHIJC_Req.IGNIIEBMFIN_Page = 1;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF ICFBPFMLNCD = null;
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF PDGBAAFHIBP = null;
		List<IFICNCAHIGI> IODPMHILFDI = new List<IFICNCAHIGI>();
		BFDEHIANFOG.Clear();
		JFDPPPBMCBK_BlacklistedUsersId.Clear();
		PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x92B388
			PLOOEECNHFB_IsDone = true;
			IMLMNFGDFPE(NHECPMNKEFK, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
		};
		ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction KFBCOGJKEJP) =>
		{
			//0x92B400
			DPMKJDMNDNN_GetBlackList r = KFBCOGJKEJP as DPMKJDMNDNN_GetBlackList;
			NKLACAPLMHI_Count = r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count;
			if(r.NFEAMMJIMPG_Result.HMFFHLPNMPH_count == 0)
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			}
			else
			{
				for(int i = 0; i < r.NFEAMMJIMPG_Result.FOCOFKEFHIO_BlackList.Count; i++)
				{
					FAMHAPONILI_PlayerIds.Add(r.NFEAMMJIMPG_Result.FOCOFKEFHIO_BlackList[i].EHGBICNIBKE_player_id);
					JFDPPPBMCBK_BlacklistedUsersId.Add(r.NFEAMMJIMPG_Result.FOCOFKEFHIO_BlackList[i].EHGBICNIBKE_player_id);
				}
				if(r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
				{
					NJNCAHLIHNI_GetPlayerData LBHGPLCOCHD_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
					int GOHNHANPPEJ = 50;
					int cnt = Mathf.Min(FAMHAPONILI_PlayerIds.Count, 50);
					LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds.GetRange(0, cnt);
					BBHNACPENDM_ServerSaveData EHDDJFNOBFN = new BBHNACPENDM_ServerSaveData();
					EHDDJFNOBFN.EBKCPELHDKN_InitWithBaseAndPublicStatus();
					LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
					MEIEDGPOMOO PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int _PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
					{
						//0x92BC48
						IFICNCAHIGI d = IBIGBMDANNM.HEGEKFMJNCC<IFICNCAHIGI>(_PPFNGGCBJKC_id, _IFNLEKOILPM_updated_at, PDEACDHIJJJ_IsFriend(_PPFNGGCBJKC_id), _OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
						if (d != null)
						{
							IODPMHILFDI.Add(d);
							return true;
						}
						return false;
					};
					ICFBPFMLNCD = (CACGCMBKHDI_NetBaseAction MLBCPDDFCMN) =>
					{
						//0x92BDB8
						for(int i = 0; i < IODPMHILFDI.Count; i++)
						{
							BFDEHIANFOG.Add(IODPMHILFDI[i]);
						}
						EMJFHKHLHDB = BEKLBBDMAIJ.CCAPCGPIIPF_1_Normal;
						if(GOHNHANPPEJ < 1)
						{
							if(_BHFHGFKBOHH_OnSuccess != null)
								_BHFHGFKBOHH_OnSuccess();
							PLOOEECNHFB_IsDone = true;
						}
						else
						{
							LBHGPLCOCHD_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
							cnt = Mathf.Min(GOHNHANPPEJ, 50);
							LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = FAMHAPONILI_PlayerIds.GetRange(GOHNHANPPEJ, cnt);
							LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
							LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = PINPBOCDKLI_OnPlayerCb;
							LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
							LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
							GOHNHANPPEJ += 50;
							IODPMHILFDI.Clear();
						}
					};
					LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
					PDGBAAFHIBP = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) =>
					{
						//0x92BD40
						PLOOEECNHFB_IsDone = true;
						IMLMNFGDFPE(DLMLKJACBPM, _MOBEEPPKFLG_OnFail, _AOCANKOMKFG_OnError);
					};//PDGBAAFHIBP
					LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
					LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = PINPBOCDKLI_OnPlayerCb;
				}
				else
				{
					//JPEIBHJIHPI_FriendLimit
					COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DPMKJDMNDNN_GetBlackList());
					COJNCNGHIJC_Req.IGNIIEBMFIN_Page = r.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
					COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = 30;
					COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
					COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
				}
			}
		};
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
	}
}
