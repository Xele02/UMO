using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class GNGMCIAIKMA
{
	public class DFABPMMMIIB
	{
		public static int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x0
		public static long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int JLCIMGKBDKD; // 0xC
		public long PCLNFCNIECH_OpenAtCrypted; // 0x10
		public long HHPIJHADAOB_CloseAtCrypted; // 0x18
		public NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x20
		public List<GGJOIEMJPEF> PJNIEFHBGIF = new List<GGJOIEMJPEF>(); // 0x24
		public List<KDGHBAGLKEP> LNHNECFGEPO = new List<KDGHBAGLKEP>(); // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E532B4 DEMEPMAEJOO 0x1E5334C HIGKAIDMOKN
		public int NMMPEIIDBJL { get { return JLCIMGKBDKD ^ FBGGEFFJJHB_xor; } set { JLCIMGKBDKD = value ^ FBGGEFFJJHB_xor; } } //0x1E533E8 FFOPNIECCMB 0x1E53480 ECPBEDDJHAL
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ BBEGLBMOBOF_xorl; } set { PCLNFCNIECH_OpenAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1E5351C FOACOMBHPAC 0x1E535B8 NBACOBCOJCA
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ BBEGLBMOBOF_xorl; } set { HHPIJHADAOB_CloseAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x1E5365C BPJOGHJCLDJ 0x1E536F8 NLJKMCHOCBK
		public string OCDMGOGMHGE { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x1E5379C HBAAAKFHDBB 0x1E537C8 NHJLJOIPOFK

		// RVA: 0x1E537FC Offset: 0x1E537FC VA: 0x1E537FC
		public DFABPMMMIIB()
		{
			PPFNGGCBJKC_id = 0;
			NMMPEIIDBJL = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			OCDMGOGMHGE = "";
			PJNIEFHBGIF.Clear();
			LNHNECFGEPO.Clear();
		}

		//// RVA: 0x1E53990 Offset: 0x1E53990 VA: 0x1E53990
		public bool KHEKNNFCAOI_Init(int _APFDNBGMMMM_BingoId)
		{
			PPFNGGCBJKC_id = _APFDNBGMMMM_BingoId;
			if(HHCJCDFCLOB != null)
			{
				JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = HHCJCDFCLOB.FJLIDJJAGOM_GetBingoDb().JJAICEAEGKF[HHCJCDFCLOB.NIGPFNIIDII(_APFDNBGMMMM_BingoId)];
				JKICPBIIHNE_Bingo.EHLBDNHLCIN d = bingo.DPGMFEGFCJN[0];
				NMMPEIIDBJL = bingo.OGKBHHLMMID;
				PDBPFJJCADD_open_at = bingo.PDBPFJJCADD_open_at;
				FDBNFFNFOND_close_at = bingo.FDBNFFNFOND_close_at;
				OCDMGOGMHGE = bingo.OCDMGOGMHGE;
				LNHNECFGEPO.Clear();
				for(int i = 0; i < d.PFEGHILDOGF.Count; i++)
				{
					if(HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(d.PFEGHILDOGF[i].PLALNIIBLOF_en))
					{
						KDGHBAGLKEP data = new KDGHBAGLKEP();
						data.PPFNGGCBJKC_id = d.PFEGHILDOGF[i].PPFNGGCBJKC_id;
						data.FDBOPFEOENF_diva = d.PFEGHILDOGF[i].FDBOPFEOENF_diva;
						data.CPKMLLNADLJ_Serie = d.PFEGHILDOGF[i].CPKMLLNADLJ_Serie;
						data.GLCLFMGPMAN_ItemId.Clear();
						for(int j = 0; j < 8; j++)
						{
							CEBFFLDKAEC_SecureInt data2 = new CEBFFLDKAEC_SecureInt();
							data2.DNJEJEANJGL_Value = d.PFEGHILDOGF[i].FKNBLDPIPMC(j);
							data.GLCLFMGPMAN_ItemId.Add(data2);
						}
						LNHNECFGEPO.Add(data);
					}
				}
				PJNIEFHBGIF.Clear();
				for(int i = 0; i < d.CFHKEJHDGBG.Count; i++)
				{
					if (HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(d.CFHKEJHDGBG[i].PLALNIIBLOF_en))
					{
						GGJOIEMJPEF data = new GGJOIEMJPEF();
						data.KHEKNNFCAOI_Init(d.CFHKEJHDGBG[i], LNHNECFGEPO.Count);
						PJNIEFHBGIF.Add(data);
					}
				}
				return true;
			}
			return false;
		}
	}

	public class GGJOIEMJPEF
	{
		public static int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x0
		public static long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0x8
		public List<JCIFAFBDALP> EIOBAIJMNGL = new List<JCIFAFBDALP>(); // 0xC
		public List<JLHGLHJDAGN> KHMNCCCPLLC = new List<JLHGLHJDAGN>(); // 0x10
		public sbyte FGMOPPIODAE; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E54794 DEMEPMAEJOO 0x1E5482C HIGKAIDMOKN
		public bool EOALGPLPGKB { get { return FGMOPPIODAE == 29; } set { FGMOPPIODAE = (sbyte)(value ? 29 : 63); } } // 0x1E548C8 AINFOGCAHAP 0x1E548DC ONIAGBIHOKN

		// RVA: 0x1E54288 Offset: 0x1E54288 VA: 0x1E54288
		public GGJOIEMJPEF()
		{
			EOALGPLPGKB = false;
			PPFNGGCBJKC_id = 0;
			EIOBAIJMNGL.Clear();
			KHMNCCCPLLC.Clear();
		}

		//// RVA: 0x1E543C4 Offset: 0x1E543C4 VA: 0x1E543C4
		public bool KHEKNNFCAOI_Init(JKICPBIIHNE_Bingo.CCOCDFGGDBB _NDFIEMPPMLF_master, int IKOLGECGPNM)
		{
			if(HHCJCDFCLOB != null)
			{
				if(HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(_NDFIEMPPMLF_master.PLALNIIBLOF_en))
				{
					PPFNGGCBJKC_id = _NDFIEMPPMLF_master.PPFNGGCBJKC_id;
					EIOBAIJMNGL.Clear();
					for(int i = 0; i < 8; i++)
					{
						JCIFAFBDALP data = new JCIFAFBDALP();
						data.PPFNGGCBJKC_id = _NDFIEMPPMLF_master.FKNBLDPIPMC(i);
						data.BFINGCJHOHI_cnt = _NDFIEMPPMLF_master.KAINPNMMAEK(i);
						data.MPKBLMCNHOM = _NDFIEMPPMLF_master.BLLCPCGGHJM(i) > 0;
						EIOBAIJMNGL.Add(data);
					}
					if (IKOLGECGPNM < 1)
						EOALGPLPGKB = false;
					else
					{
						EOALGPLPGKB = EIOBAIJMNGL.Find((JCIFAFBDALP JPAEDJJFFOI) =>
						{
							//0x1E54CA0
							if(JPAEDJJFFOI.BFINGCJHOHI_cnt > 0)
							{
								if(JPAEDJJFFOI.PPFNGGCBJKC_id > 0)
								{
									return JPAEDJJFFOI.PPFNGGCBJKC_id < IKOLGECGPNM;
								}
							}
							return false;
						}) != null;
					}
					KHMNCCCPLLC.Clear();
					return true;
				}
			}
			return false;
		}

		//// RVA: 0x1E54AC4 Offset: 0x1E54AC4 VA: 0x1E54AC4
		//public bool KHEKNNFCAOI_Init(int _AMCCOGJACPK_CardId) { }
	}

	public class JLHGLHJDAGN
	{
		public static int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x0
		public static long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x8
		public int JJHPDDPKBHF; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN = new NNJFKLBPBNK_SecureString(); // 0x10
		private NNJFKLBPBNK_SecureString IDCENBCAPBP = new NNJFKLBPBNK_SecureString(); // 0x14
		private int EHLGHDIACCG_MusicDifficultyCrypted; // 0x18
		private int FILBJBFDMMN_Crypted; // 0x1C
		private int KGKIDDDKOGL_cidCrypted; // 0x20
		private int AHGCGHAAHOO_ItemIdCrypted; // 0x24
		private int GNMMBOFGBCO_Crypted; // 0x28
		private int AIGOPKGALKA_Crypted; // 0x2C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E54F04 DEMEPMAEJOO 0x1E54F9C HIGKAIDMOKN
		public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x1E55038 JDHDMBHNKJD 0x1E55064 FNAJEJLLJOE
		public string JEPGJJJBFLN { get { return IDCENBCAPBP.DNJEJEANJGL_Value; } set { IDCENBCAPBP.DNJEJEANJGL_Value = value; } } //0x1E55098 AKHEBLBJGBP 0x1E550C4 EEJDMJMLKMG
		public int GOKJLBDJOLA_df { get { return EHLGHDIACCG_MusicDifficultyCrypted ^ FBGGEFFJJHB_xor; } set { EHLGHDIACCG_MusicDifficultyCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E550F8 CCEEILBGBOM 0x1E55190 MKNIFMGHJHC
		public int MAPNDFCJFLJ { get { return FILBJBFDMMN_Crypted ^ FBGGEFFJJHB_xor; } set { FILBJBFDMMN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1E5522C IPFCNEIHNLJ 0x1E552C4 CLNEANLIOFN
		public int JBFLEDKDFCO_cid { get { return KGKIDDDKOGL_cidCrypted ^ FBGGEFFJJHB_xor; } set { KGKIDDDKOGL_cidCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E55360 LIJMKJLDHGP 0x1E553F8 NFNCLFPPADP
		public int GLCLFMGPMAN_ItemId { get { return AHGCGHAAHOO_ItemIdCrypted ^ FBGGEFFJJHB_xor; } set { AHGCGHAAHOO_ItemIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E55494 LNJAENEGDEL 0x1E5552C JHIDBGCHOKL
		public int GJABBJOJPEE { get { return GNMMBOFGBCO_Crypted ^ FBGGEFFJJHB_xor; } set { GNMMBOFGBCO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1E555C8 PDMHLKEJELM 0x1E55660 PHGIOONNIOF

		// RVA: 0x1E556FC Offset: 0x1E556FC VA: 0x1E556FC
		public JLHGLHJDAGN()
		{
			PPFNGGCBJKC_id = 0;
			FEMMDNIELFC_Desc = "";
			JEPGJJJBFLN = "";
			GOKJLBDJOLA_df = 0;
			MAPNDFCJFLJ = 0;
			JBFLEDKDFCO_cid = 0;
			GLCLFMGPMAN_ItemId = 0;
			GJABBJOJPEE = 0;
			JJHPDDPKBHF = 0;
		}
	}

	public class JCIFAFBDALP
	{
		public static int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x0
		public static long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int IFEHKNJONPL_CountCrypted; // 0xC
		private sbyte AJGFHCKFCHN_Crypted; // 0x10

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E54DBC DEMEPMAEJOO 0x1E5495C HIGKAIDMOKN
		public int BFINGCJHOHI_cnt { get { return IFEHKNJONPL_CountCrypted ^ FBGGEFFJJHB_xor; } set { IFEHKNJONPL_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E54D24 LFMCLIDAPHB 0x1E549F8 EDAEPDGGFJJ
		public bool MPKBLMCNHOM { get { return AJGFHCKFCHN_Crypted == 29; } set { AJGFHCKFCHN_Crypted = (sbyte)(value ? 29 : 63); } } //0x1E54E54 BOFCPLOLHCJ 0x1E54A94 FDPPEPOHFNA

		// RVA: 0x1E54914 Offset: 0x1E54914 VA: 0x1E54914
		public JCIFAFBDALP()
		{
			PPFNGGCBJKC_id = 0;
			BFINGCJHOHI_cnt = 0;
			MPKBLMCNHOM = false;
		}
	}

	public class KDGHBAGLKEP
	{
		public static int FBGGEFFJJHB_xor = GNGMCIAIKMA.FBGGEFFJJHB_xor; // 0x0
		public static long BBEGLBMOBOF_xorl = GNGMCIAIKMA.BBEGLBMOBOF_xorl; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0x8
		private int LLEMDLLGIAH_divaCrypted; // 0xC
		private int IPAKEGGICML_SerieCrypted; // 0x10
		public List<CEBFFLDKAEC_SecureInt> GLCLFMGPMAN_ItemId = new List<CEBFFLDKAEC_SecureInt>(); // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E558A0 DEMEPMAEJOO 0x1E540B4 HIGKAIDMOKN
		public int FDBOPFEOENF_diva { get { return LLEMDLLGIAH_divaCrypted ^ FBGGEFFJJHB_xor; } set { LLEMDLLGIAH_divaCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E55938 MJPHCAIKKJG 0x1E54150 GHECGDMEBFF
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1E559D0 BJPJMGHCDNO 0x1E541EC BPKIOJBKNBP

		// RVA: 0x1E53FD8 Offset: 0x1E53FD8 VA: 0x1E53FD8
		public KDGHBAGLKEP()
		{
			PPFNGGCBJKC_id = 0;
			FDBOPFEOENF_diva = 0;
			CPKMLLNADLJ_Serie = 0;
			GLCLFMGPMAN_ItemId.Clear();
		}
	}

	public const sbyte HKKJGAJPNIL = 29;
	public const sbyte FKHFJOKHNAK = 63;
	private const short EAPCKKPCPII = 90;
	public static int FBGGEFFJJHB_xor; // 0x0
	public static long BBEGLBMOBOF_xorl; // 0x8
	private int ILGOKEAIBBA; // 0x8
	private int NPNDCNDCDPC; // 0xC
	private int PFJENHEKCAO; // 0x10
	private int ELNEJEEKOEI_TutoIdCrypted; // 0x14
	private int IDKOMEFBCBD; // 0x18
	public int DKFOMHOJBGD; // 0x1C
	public List<long> GEAHCCJPOCN = new List<long>(); // 0x20
	private readonly sbyte[,] LMEHCADEKLN = new sbyte[8, 3] {
		{ 0x5b, 0x58, 0x59 }, // 1, 2, 3
		{ 0x5e, 0x5f, 0x5c }, // 4, 5, 6
		{ 0x5d, 0x52, 0x53 }, // 7, 8, 9
		{ 0x5b, 0x5e, 0x5d }, // 1, 4, 7
		{ 0x58, 0x5f, 0x52 }, // 2, 5, 8
		{ 0x59, 0x5c, 0x53 }, // 3, 6, 9
		{ 0x5b, 0x5f, 0x53 }, // 1, 5, 9
		{ 0x59, 0x5f, 0x5d }  // 3, 5, 7
	}; // 0x24
	public List<DFABPMMMIIB> CEHNIJPOEAF = new List<DFABPMMMIIB>(); // 0x28

	public static GNGMCIAIKMA HHCJCDFCLOB { get; private set; } // 0x10 GNGMCIAIKMA OKPMHKNCNAL
	public int PMPKHBAJAFA_BingoId { get { return ILGOKEAIBBA ^ FBGGEFFJJHB_xor; } set { ILGOKEAIBBA = value ^ FBGGEFFJJHB_xor; } } // OAKEIKFELFC 0xAB8FE4  MBHILIEPJOO 0xAB9050
	public int MALACFEDHDE { get { return NPNDCNDCDPC ^ FBGGEFFJJHB_xor; } set { NPNDCNDCDPC = value ^ FBGGEFFJJHB_xor; } } //  KIMKKEOMPDL 0xAB90C0 PGILHFKNKEN 0xAB912C
	private int HHKAGEAMHOE { get { return PFJENHEKCAO ^ FBGGEFFJJHB_xor; } set { PFJENHEKCAO = value ^ FBGGEFFJJHB_xor; } } // DGNHFHGNDOF 0xAB919C  HDADMLNHJMN 0xAB9208
	private int EEOPPDBICBN_TutoId { get { return ELNEJEEKOEI_TutoIdCrypted ^ FBGGEFFJJHB_xor; } set { ELNEJEEKOEI_TutoIdCrypted = value ^ FBGGEFFJJHB_xor; } } // GDODEJOPENB 0xAB9278 JIJIGMCJHBC 0xAB92E4
	private int CEGHDFHLFPO { get { return IDKOMEFBCBD ^ FBGGEFFJJHB_xor; } set { IDKOMEFBCBD = value ^ FBGGEFFJJHB_xor; } } // CDJABHMPLKM 0xAB9354  EIHJCGDLLPF 0xAB93C0

	// // RVA: 0xAB9430 Offset: 0xAB9430 VA: 0xAB9430
	public int DDHNADFGKDF(int GJKPJMGPCEJ, int _IKPIDCFOFEA_no)
	{
		if(GJKPJMGPCEJ >= 0)
		{
			if(_IKPIDCFOFEA_no >= 0 && LMEHCADEKLN.GetLength(0) > GJKPJMGPCEJ)
			{
				if(_IKPIDCFOFEA_no < LMEHCADEKLN.GetLength(1))
				{
					return LMEHCADEKLN[GJKPJMGPCEJ, _IKPIDCFOFEA_no] ^ 0x5a;
				}
			}
		}
		return 0;
	}

	// // RVA: 0xAB9524 Offset: 0xAB9524 VA: 0xAB9524
	public int[] EOPMDFOCAKJ(int GJKPJMGPCEJ)
	{
		int[] res = new int[3];
		res[0] = DDHNADFGKDF(GJKPJMGPCEJ, 0);
		res[1] = DDHNADFGKDF(GJKPJMGPCEJ, 1);
		res[2] = DDHNADFGKDF(GJKPJMGPCEJ, 2);
		return res;
	}

	// // RVA: 0xAB9640 Offset: 0xAB9640 VA: 0xAB9640
	public GNGMCIAIKMA() 
	{ 
		FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
		BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor; // not sure
		PMPKHBAJAFA_BingoId = 0;
		MALACFEDHDE = 0;
		HHKAGEAMHOE = 0;
		EEOPPDBICBN_TutoId = 0;
		CEGHDFHLFPO = 0;
	}

	// // RVA: 0xAB9974 Offset: 0xAB9974 VA: 0xAB9974
	public void IJBGPAENLJA(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xAB99D8 Offset: 0xAB99D8 VA: 0xAB99D8
	public bool GBCPDBJEDHL()
	{
		return GBCPDBJEDHL(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
	}

	// // RVA: 0xAB9AD0 Offset: 0xAB9AD0 VA: 0xAB9AD0
	public bool GBCPDBJEDHL(long _JHNMKKNEENE_Time)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			int val = bingoDb.LPJLEHAJADA_GetIntParam("bingo_enable", 1);
			if(val != 0)
			{
				if(!QuestUtility.IsBeginnerQuest())
				{
					KIAAOBFJCHP(_JHNMKKNEENE_Time);
					return CNADOFDDNLO_GetActiveBingos(_JHNMKKNEENE_Time).Count > 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0xABA38C Offset: 0xABA38C VA: 0xABA38C
	public bool NJBPNCDPGNO(int _APFDNBGMMMM_BingoId)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			if(_APFDNBGMMMM_BingoId <= bingoDb.JJAICEAEGKF.Count)
			{
				return bingoDb.JJAICEAEGKF[_APFDNBGMMMM_BingoId - 1].FDBNFFNFOND_close_at == 0;
			}
		}
		return false;
	}

	// // RVA: 0xABA480 Offset: 0xABA480 VA: 0xABA480
	public int AMIBPGONGFE(long _JHNMKKNEENE_Time, bool HLCDBGGEHPD)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			List<int> l = CNADOFDDNLO_GetActiveBingos(_JHNMKKNEENE_Time);
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i] > 0)
				{
					JKICPBIIHNE_Bingo.HNOGDJFJGPM b = bingoDb.JJAICEAEGKF[l[i] - 1];
					if(!HLCDBGGEHPD)
					{
						if(b.FDBNFFNFOND_close_at != 0)
							return l[i];
					}
					else
					{
						if(b.FDBNFFNFOND_close_at == 0)
							return l[i];
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xABA5FC Offset: 0xABA5FC VA: 0xABA5FC
	public void KGABKGKGNCA_SetBingoClear(int _APFDNBGMMMM_BingoId, bool _BCGLDMKODLC_IsClear)
	{
		MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).JNLKJCDFFMM_clear = _BCGLDMKODLC_IsClear ? 1 : 0;
	}

	// // RVA: 0xABA788 Offset: 0xABA788 VA: 0xABA788
	// public int MIGJIALJLOF() { }

	// // RVA: 0xABA8C0 Offset: 0xABA8C0 VA: 0xABA8C0
	public int FIAHJAMFNPD_GetTutorialId()
	{
		JKICPBIIHNE_Bingo db = FJLIDJJAGOM_GetBingoDb();
		if (db == null)
			return -1;
		EEOPPDBICBN_TutoId = db.LPJLEHAJADA_GetIntParam("bingo_help_pictId_2", 115);
		return EEOPPDBICBN_TutoId;
	}

	// // RVA: 0xABA9F8 Offset: 0xABA9F8 VA: 0xABA9F8
	public int GEAMLAKKMLI()
	{
		JKICPBIIHNE_Bingo db = FJLIDJJAGOM_GetBingoDb();
		if (db == null)
			return -1;
		CEGHDFHLFPO = db.LPJLEHAJADA_GetIntParam("bingo_help_pictId_3", 116);
		return CEGHDFHLFPO;
	}

	// // RVA: 0xABAB30 Offset: 0xABAB30 VA: 0xABAB30
	public bool DKMLDEDKPBA_IsEnabled(int _PLALNIIBLOF_en)
	{
		return _PLALNIIBLOF_en == 2;
	}

	// // RVA: 0xAB9E7C Offset: 0xAB9E7C VA: 0xAB9E7C
	public List<int> CNADOFDDNLO_GetActiveBingos(long _JHNMKKNEENE_Time)
	{
		List<int> res = new List<int>();
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb == null)
			return res;
		List<JKICPBIIHNE_Bingo.HNOGDJFJGPM> l = new List<JKICPBIIHNE_Bingo.HNOGDJFJGPM>();
		for(int i = 0; i < bingoDb.JJAICEAEGKF.Count; i++)
		{
			JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = bingoDb.JJAICEAEGKF[i];
			if(bingo.IJEKNCDIIAE_mver != 0)
			{
				if(bingo.IJEKNCDIIAE_mver < DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion)
				{
					if(bingo.PLALNIIBLOF_en == 2)
					{
						if(bingo.PDBPFJJCADD_open_at != 0)
						{
							if(bingo.PDBPFJJCADD_open_at > _JHNMKKNEENE_Time)
								continue;
						}
						if(bingo.FDBNFFNFOND_close_at != 0)
						{
							if(bingo.FDBNFFNFOND_close_at < _JHNMKKNEENE_Time)
								continue;
						}
						if(MENDFPNPAAO_GetSaveBingo(bingo.PPFNGGCBJKC_id).JNLKJCDFFMM_clear != 1)
						{
							l.Add(bingo);
						}
					}
				}
			}
		}
		l.Sort((JKICPBIIHNE_Bingo.HNOGDJFJGPM _HKICMNAACDA_a, JKICPBIIHNE_Bingo.HNOGDJFJGPM _BNKHBCBJBKI_b) => {
			//0x1E52F64
			return _HKICMNAACDA_a.FDBNFFNFOND_close_at.CompareTo(_BNKHBCBJBKI_b.FDBNFFNFOND_close_at);
		});
		for(int i = 0; i < l.Count; i++)
		{
			res.Add(l[i].PPFNGGCBJKC_id);
		}
		return res;
	}

	// // RVA: 0xABAB40 Offset: 0xABAB40 VA: 0xABAB40
	public List<int> CNADOFDDNLO_GetActiveBingos()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return CNADOFDDNLO_GetActiveBingos(time);
	}

	// // RVA: 0xABAC38 Offset: 0xABAC38 VA: 0xABAC38
	// public bool MHNAINBNLHH(int _APFDNBGMMMM_BingoId) { }

	// // RVA: 0xABAD3C Offset: 0xABAD3C VA: 0xABAD3C
	public bool DHPLHALIDHH(int _APFDNBGMMMM_BingoId)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return DHPLHALIDHH(_APFDNBGMMMM_BingoId, time);
	}

	// // RVA: 0xABAE3C Offset: 0xABAE3C VA: 0xABAE3C
	public bool DHPLHALIDHH(int _APFDNBGMMMM_BingoId, long _JHNMKKNEENE_Time)
	{
		long t = EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId).OGKBHHLMMID;
		if(t != 0)
		{
			return _JHNMKKNEENE_Time >= GKDBBGIEPLC(_APFDNBGMMMM_BingoId);
		}
		return true;
	}

	// // RVA: 0xABAFF4 Offset: 0xABAFF4 VA: 0xABAFF4
	public bool KJNFBLAMJOH(int _APFDNBGMMMM_BingoId)
	{
		return true;
	}

	// // RVA: 0xABAFC4 Offset: 0xABAFC4 VA: 0xABAFC4
	public long GKDBBGIEPLC(int _APFDNBGMMMM_BingoId)
	{
		return MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).EBDKHCLCOFL_Ul;
	}

	// // RVA: 0xABAFFC Offset: 0xABAFFC VA: 0xABAFFC
	public long DBEDJLOAILN(int _APFDNBGMMMM_BingoId)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		if(saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id > 0)
		{
			JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId);
			int a2 = bingo.DPGMFEGFCJN[0].CFHKEJHDGBG[saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id - 1].BGKHDJOGEAL;
			if(a2 > 0)
			{
				DateTime date = Utility.GetLocalDateTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() + a2 * 86400);
				saveBingo.EBDKHCLCOFL_Ul = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
				return saveBingo.EBDKHCLCOFL_Ul;
			}
		}
		return 0;
	}

	// // RVA: 0xABB2F4 Offset: 0xABB2F4 VA: 0xABB2F4
	public int CBMJAPJKBNL(int _PPFNGGCBJKC_id)
	{
		return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO_12/*12*/, _PPFNGGCBJKC_id);
	}

	// // RVA: 0xABB300 Offset: 0xABB300 VA: 0xABB300
	// public int LILBEIBCCKF(int _EKANGPODCEP_EventId) { }

	// // RVA: 0xABB30C Offset: 0xABB30C VA: 0xABB30C
	public bool DJGFICMNGGP_SetBingoId(int _APFDNBGMMMM_BingoId)
	{
		PMPKHBAJAFA_BingoId = _APFDNBGMMMM_BingoId;
		return true;
	}

	// // RVA: 0xABB380 Offset: 0xABB380 VA: 0xABB380
	public int MGAHOPFMKHB_GetBingoId()
	{
		return PMPKHBAJAFA_BingoId;
	}

	// // RVA: 0xABB3EC Offset: 0xABB3EC VA: 0xABB3EC
	// public bool NJELIKPFBEH(int _AMCCOGJACPK_CardId) { }

	// // RVA: 0xABB460 Offset: 0xABB460 VA: 0xABB460
	public int EAIJHJPKBFA(int _APFDNBGMMMM_BingoId)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC b = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		if (b.AHCFGOGCJKI_St.PPFNGGCBJKC_id < 1)
			return 1;
		return b.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
	}

	// // RVA: 0xABB4D4 Offset: 0xABB4D4 VA: 0xABB4D4
	public int EHFLAKIFPOO(int _APFDNBGMMMM_BingoId)
	{
		JKICPBIIHNE_Bingo.HNOGDJFJGPM b = EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId);
		int res = 0;
		for(int i = 0; i < b.DPGMFEGFCJN[0].CFHKEJHDGBG.Count; i++)
		{
			if (b.DPGMFEGFCJN[0].CFHKEJHDGBG[i].PLALNIIBLOF_en == 2)
				res++;
		}
		return res;
	}

	// // RVA: 0xABB674 Offset: 0xABB674 VA: 0xABB674
	public bool IDKFAMEFCPD(int _APFDNBGMMMM_BingoId)
	{
		DFABPMMMIIB b = GLJKKGFPEPA(_APFDNBGMMMM_BingoId);
		if(b.LNHNECFGEPO.Count > 0)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC b2 = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
			return b2.AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId > 0;
		}
		return false;
	}

	// // RVA: 0xAB9C00 Offset: 0xAB9C00 VA: 0xAB9C00
	public JKICPBIIHNE_Bingo FJLIDJJAGOM_GetBingoDb()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo;
		}
		return null;
	}

	// // RVA: 0xABAEB8 Offset: 0xABAEB8 VA: 0xABAEB8
	public JKICPBIIHNE_Bingo.HNOGDJFJGPM EBEDAPJFHCE_GetBingo(int _APFDNBGMMMM_BingoId)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			return bingoDb.JJAICEAEGKF.Find((JKICPBIIHNE_Bingo.HNOGDJFJGPM JPAEDJJFFOI) => {
				//0x1E530F4
				return JPAEDJJFFOI.PPFNGGCBJKC_id == _APFDNBGMMMM_BingoId;
			});
		}
		return null;
	}

	// // RVA: 0xABB868 Offset: 0xABB868 VA: 0xABB868
	public NFMHCLHEMHB_Bingo PDMHKENDJHI_GetSaveBingoBlock()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PEGNNEFHDOP_Bingo;
		}
		return null;
	}

	// // RVA: 0xABA634 Offset: 0xABA634 VA: 0xABA634
	public NFMHCLHEMHB_Bingo.CCGKCGJKADC MENDFPNPAAO_GetSaveBingo(int _PPFNGGCBJKC_id)
	{
		NFMHCLHEMHB_Bingo saveBingo = PDMHKENDJHI_GetSaveBingoBlock();
		if(saveBingo != null)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC res = saveBingo.MPCJGPEBCCD.Find((NFMHCLHEMHB_Bingo.CCGKCGJKADC JPAEDJJFFOI) => {
				//0x1E53140
				return JPAEDJJFFOI.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
			});
			if(res == null)
			{
				NFMHCLHEMHB_Bingo.CCGKCGJKADC n = saveBingo.EACEMMDIPFD_GetEmptyBingo();
				if(n != null)
				{
					n.KHEKNNFCAOI_Init(_PPFNGGCBJKC_id);
					res = n;
				}
			}
			return res;
		}
		return null;
	}

	// // RVA: 0xABB91C Offset: 0xABB91C VA: 0xABB91C
	public NFMHCLHEMHB_Bingo.CCGKCGJKADC MENDFPNPAAO_GetSaveBingo(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, int _PPFNGGCBJKC_id)
	{
		if(_AHEFHIMGIBI_PlayerData.PEGNNEFHDOP_Bingo != null)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = _AHEFHIMGIBI_PlayerData.PEGNNEFHDOP_Bingo.MPCJGPEBCCD.Find((NFMHCLHEMHB_Bingo.CCGKCGJKADC JPAEDJJFFOI) =>
			{
				//0x1E5318C
				return JPAEDJJFFOI.PPFNGGCBJKC_id == _PPFNGGCBJKC_id;
			});
			if(bingo == null)
			{
				bingo = _AHEFHIMGIBI_PlayerData.PEGNNEFHDOP_Bingo.EACEMMDIPFD_GetEmptyBingo();
				if(bingo != null)
				{
					bingo.KHEKNNFCAOI_Init(_PPFNGGCBJKC_id);
				}
			}
			return bingo;
		}
		return null;
	}

	// // RVA: 0xABBA8C Offset: 0xABBA8C VA: 0xABBA8C
	public bool BHFGBNNEMLI(int _APFDNBGMMMM_BingoId)
	{
		if(MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).AHCFGOGCJKI_St.PPFNGGCBJKC_id == 0)
		{
			MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).AHCFGOGCJKI_St.KHEKNNFCAOI_Init(1);
		}
		return true;
	}

	// // RVA: 0xABBB00 Offset: 0xABBB00 VA: 0xABBB00
	public int CGOIJPBINCF_GetNextBingoStepId(int _APFDNBGMMMM_BingoId, bool BAFFAONJPCE)
	{
        DFABPMMMIIB d1 = GLJKKGFPEPA(_APFDNBGMMMM_BingoId);
        NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		int a = saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
		if(a < 0)
			a = 1;
		else
		{
			a++;
			if(d1.PJNIEFHBGIF.Count < a)
				a = 0;
		}
		if(a > 0 && BAFFAONJPCE)
		{
			saveBingo.AHCFGOGCJKI_St.KHEKNNFCAOI_Init(a);
		}
		return a;
    }

	// // RVA: 0xABBC58 Offset: 0xABBC58 VA: 0xABBC58
	public int JBEDFJHAAFP(int _APFDNBGMMMM_BingoId, bool BAFFAONJPCE)
	{
		DFABPMMMIIB d = GLJKKGFPEPA(_APFDNBGMMMM_BingoId);
		if(d != null)
		{
            NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
			int a = saveBingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
			if(a < 1)
				a = 1;
			else
			{
				if(d.PJNIEFHBGIF.Count < a)
					a = 0;
			}
			if(a > 0 && BAFFAONJPCE)
			{
				saveBingo.AHCFGOGCJKI_St.KHEKNNFCAOI_Init(a);
			}
			return a;
        }
		return -1;
	}

	// // RVA: 0xABBDB0 Offset: 0xABBDB0 VA: 0xABBDB0
	public int NIGPFNIIDII(int _APFDNBGMMMM_BingoId)
	{
		if (_APFDNBGMMMM_BingoId < 1 || FJLIDJJAGOM_GetBingoDb() == null)
			return - 1;
		return FJLIDJJAGOM_GetBingoDb().JJAICEAEGKF[_APFDNBGMMMM_BingoId - 1].PLALNIIBLOF_en == 2 ? _APFDNBGMMMM_BingoId - 1 : -1;
	}

	// // RVA: 0xABBE78 Offset: 0xABBE78 VA: 0xABBE78
	// public JKICPBIIHNE_Bingo.MKOCCBABHAH LAIDKMDLOPA(int _APFDNBGMMMM_BingoId, int _EIHOBHDKCDB_RewardId) { }

	// // RVA: 0xABBFE8 Offset: 0xABBFE8 VA: 0xABBFE8
	// public int DAIDHMMOGEI(int _APFDNBGMMMM_BingoId, int _EIHOBHDKCDB_RewardId) { }

	// // RVA: 0xABC00C Offset: 0xABC00C VA: 0xABC00C
	// public int KBIIEPNCLAD(int _APFDNBGMMMM_BingoId, int _EIHOBHDKCDB_RewardId) { }

	// // RVA: 0xABC030 Offset: 0xABC030 VA: 0xABC030
	// public List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> LABNDEFMAHI(int _APFDNBGMMMM_BingoId, int _AMCCOGJACPK_CardId) { }

	// // RVA: 0xABC254 Offset: 0xABC254 VA: 0xABC254
	// public bool OIEBCNPOMIB(int _APFDNBGMMMM_BingoId, int _AMCCOGJACPK_CardId, int _EIHOBHDKCDB_RewardId) { }

	// // RVA: 0xABC3B8 Offset: 0xABC3B8 VA: 0xABC3B8
	// public bool JJMANIALKBF(int _APFDNBGMMMM_BingoId, int _EIHOBHDKCDB_RewardId) { }

	// // RVA: 0xABC480 Offset: 0xABC480 VA: 0xABC480
	// public bool JIKFDBMMAIE(int _APFDNBGMMMM_BingoId) { }

	// // RVA: 0xABC520 Offset: 0xABC520 VA: 0xABC520
	public List<int> ICNOKENCCJK(int _APFDNBGMMMM_BingoId, bool _CADENLBDAEB_IsNew, bool _GNKMHCKFADN_stamp)
	{
		List<int> res = new List<int>();
        NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		for(int i = 0; i < 9; i++)
		{
			NFMHCLHEMHB_Bingo.HKMBGGGMEKA d = saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i];
			if(d.CMCKNKKCNDK_status > 1)
			{
				d.CMCKNKKCNDK_status = 3;
				if(_CADENLBDAEB_IsNew && d.CCKELABMHIO_MsAc == 1)
					continue;
				res.Add(i);
				if(_GNKMHCKFADN_stamp)
					d.CCKELABMHIO_MsAc = 1;
			}
		}
		return res;
    }

	// // RVA: 0xABC6F0 Offset: 0xABC6F0 VA: 0xABC6F0
	public List<int> OAHPJJCHIPF(int _APFDNBGMMMM_BingoId)
	{
		List<int> res = new List<int>();
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		for(int i = 0; i < 9; i++)
		{
			if (saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i].CCKELABMHIO_MsAc == 1)
				res.Add(i);
		}
		return res;
	}

	// // RVA: 0xABC83C Offset: 0xABC83C VA: 0xABC83C
	public List<int> NCCCEBGHCOL(int _APFDNBGMMMM_BingoId)
	{
		List<int> res = new List<int>();
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		for(int i = 0; i < 8; i++)
		{
			if(saveBingo.AHCFGOGCJKI_St.CPLKJBCBPNM(i) != 0)
			{
				for (int j = 0; j < 3; j++)
					res.Add(DDHNADFGKDF(i, j));
			}
		}
		return res;
	}

	// // RVA: 0xABC978 Offset: 0xABC978 VA: 0xABC978
	public List<int> BPGMPJHPKND(int _APFDNBGMMMM_BingoId)
	{
		List<int> res = new List<int>();
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		GEAHCCJPOCN.Clear();
		for(int i = 0; i < 8; i++)
		{
			long id = saveBingo.AHCFGOGCJKI_St.CPLKJBCBPNM(i);
			GEAHCCJPOCN.Add(id);
			if(id != 0)
			{
				res.Add(i);
			}
		}
		return res;
	}

	// // RVA: 0xABCB0C Offset: 0xABCB0C VA: 0xABCB0C
	public List<int> PFDGKPCCGMG(int _APFDNBGMMMM_BingoId, bool _CADENLBDAEB_IsNew, bool JFPPDKHEEHN)
	{
		List<int> res = new List<int>();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
        NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		for(int i = 0; i < 8; i++)
		{
			int cnt = 0;
			for(int j = 0; j < 3; j++)
			{
				int a = DDHNADFGKDF(i, j);
				if(a > 0)
				{
					if(saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[a - 1].CMCKNKKCNDK_status > 1)
						cnt++;
				}
			}
			if(cnt == 3)
			{
				if(saveBingo.AHCFGOGCJKI_St.CPLKJBCBPNM(i) == 0 || !_CADENLBDAEB_IsNew)
				{
					res.Add(i);
					if(JFPPDKHEEHN)
					{
						saveBingo.AHCFGOGCJKI_St.BMJGIEJPDLM(i, time);
					}
				}
			}
		}
		return res;
    }

	// // RVA: 0xABCDE0 Offset: 0xABCDE0 VA: 0xABCDE0
	// public void DKKLLHMHBEA(int _APFDNBGMMMM_BingoId, List<int> GJKPJMGPCEJ, long _JHNMKKNEENE_Time) { }

	// // RVA: 0xABCEF8 Offset: 0xABCEF8 VA: 0xABCEF8
	// public List<int> OJPMBMOAFHM(int _APFDNBGMMMM_BingoId) { }

	// // RVA: 0xABD0A0 Offset: 0xABD0A0 VA: 0xABD0A0
	public List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> AOIADBHHJAJ_GetValidBingoCells(int _APFDNBGMMMM_BingoId, int _AMCCOGJACPK_CardId, int _CPKMLLNADLJ_Serie, int _AHHJLDLAPAN_DivaId)
	{
		List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> res = new List<JKICPBIIHNE_Bingo.IEGCPLCLOHF>();
		JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId);
		res.Clear();
		for(int i = 0; i < 9; i++)
		{
			res.Add(new JKICPBIIHNE_Bingo.IEGCPLCLOHF());
		}
		for(int i = 0; i < bingo.DPGMFEGFCJN[0].MFMGDFACBON.Count; i++)
		{
			JKICPBIIHNE_Bingo.IEGCPLCLOHF data = bingo.DPGMFEGFCJN[0].MFMGDFACBON[i];
			if(data.PLALNIIBLOF_en == 2)
			{
				if(data.PBEEPMLJGJC == _AMCCOGJACPK_CardId)
				{
					if(data.NDFOAINJPIN_pos < 10)
					{
						if(data.FDBOPFEOENF_diva > 0)
						{
							if (data.FDBOPFEOENF_diva != _AHHJLDLAPAN_DivaId)
								continue;
						}
						if(data.CPKMLLNADLJ_Serie > 0)
						{
							if (data.CPKMLLNADLJ_Serie != _CPKMLLNADLJ_Serie)
								continue;
						}
						res[data.NDFOAINJPIN_pos - 1].PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
						res[data.NDFOAINJPIN_pos - 1].PBEEPMLJGJC = data.PBEEPMLJGJC;
						res[data.NDFOAINJPIN_pos - 1].PLALNIIBLOF_en = data.PLALNIIBLOF_en;
						res[data.NDFOAINJPIN_pos - 1].NDFOAINJPIN_pos = data.NDFOAINJPIN_pos;
						res[data.NDFOAINJPIN_pos - 1].CPKMLLNADLJ_Serie = data.CPKMLLNADLJ_Serie;
						res[data.NDFOAINJPIN_pos - 1].FDBOPFEOENF_diva = data.FDBOPFEOENF_diva;
						res[data.NDFOAINJPIN_pos - 1].FEMMDNIELFC_Desc = data.FEMMDNIELFC_Desc;
						res[data.NDFOAINJPIN_pos - 1].JEPGJJJBFLN = data.JEPGJJJBFLN;
						res[data.NDFOAINJPIN_pos - 1].GOKJLBDJOLA_df = data.GOKJLBDJOLA_df;
						res[data.NDFOAINJPIN_pos - 1].GPNPBHLLHDI_srnk = data.GPNPBHLLHDI_srnk;
						res[data.NDFOAINJPIN_pos - 1].IMEPEOAFIIB_cbrnk = data.IMEPEOAFIIB_cbrnk;
						res[data.NDFOAINJPIN_pos - 1].MAPNDFCJFLJ_ConditionType = data.MAPNDFCJFLJ_ConditionType;
						res[data.NDFOAINJPIN_pos - 1].JBFLEDKDFCO_cid = data.JBFLEDKDFCO_cid;
						res[data.NDFOAINJPIN_pos - 1].PMDLBHLNIDP_Target = data.PMDLBHLNIDP_Target;
						res[data.NDFOAINJPIN_pos - 1].GLCLFMGPMAN_ItemId = data.GLCLFMGPMAN_ItemId;
						res[data.NDFOAINJPIN_pos - 1].LJKMKCOAICL_ItemCount = data.LJKMKCOAICL_ItemCount;
						res[data.NDFOAINJPIN_pos - 1].JJHPDDPKBHF = data.JJHPDDPKBHF;
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xABDC04 Offset: 0xABDC04 VA: 0xABDC04
	// public List<int> PDLKHLJFLHJ(int _APFDNBGMMMM_BingoId) { }

	// // RVA: 0xABDD84 Offset: 0xABDD84 VA: 0xABDD84
	// public List<int> OHDKDNGIFJC(int _APFDNBGMMMM_BingoId, int _AMCCOGJACPK_CardId, int _CPKMLLNADLJ_Serie, int _AHHJLDLAPAN_DivaId) { }

	// // RVA: 0xABDF74 Offset: 0xABDF74 VA: 0xABDF74
	public int MLCGJAJCFDP(int _APFDNBGMMMM_BingoId, int PGGAIDEJGEC, int _AMCCOGJACPK_CardId/* = 0*/)
	{
		DFABPMMMIIB d = GLJKKGFPEPA(_APFDNBGMMMM_BingoId);
		if(d != null)
		{
			if(d.LNHNECFGEPO.Count > 0)
			{
				if(_AMCCOGJACPK_CardId < 1)
				{
					NFMHCLHEMHB_Bingo.CCGKCGJKADC b = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
					if (b.AHCFGOGCJKI_St.PPFNGGCBJKC_id < 1)
						return 0;
					_AMCCOGJACPK_CardId = b.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
				}
				int cnt = d.PJNIEFHBGIF[_AMCCOGJACPK_CardId - 1].EIOBAIJMNGL.Count;
				if (cnt <= PGGAIDEJGEC)
					PGGAIDEJGEC = cnt - 1;
				for(; PGGAIDEJGEC < cnt; PGGAIDEJGEC++)
				{
					JCIFAFBDALP data = d.PJNIEFHBGIF[_AMCCOGJACPK_CardId - 1].EIOBAIJMNGL[PGGAIDEJGEC];
					if (data.BFINGCJHOHI_cnt > 0)
					{
						if(data.PPFNGGCBJKC_id > 0)
						{
							if (data.PPFNGGCBJKC_id < d.LNHNECFGEPO.Count)
								return PGGAIDEJGEC + 1;
						}
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xAB9CB4 Offset: 0xAB9CB4 VA: 0xAB9CB4
	public bool KIAAOBFJCHP(long _JHNMKKNEENE_Time)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		CEHNIJPOEAF.Clear();
		for(int i = 0; i < l.Count; i++)
		{
			DFABPMMMIIB data = new DFABPMMMIIB();
			data.KHEKNNFCAOI_Init(l[i]);
			CEHNIJPOEAF.Add(data);
		}
		return CEHNIJPOEAF.Count > 0;
	}

	// // RVA: 0xABE1E8 Offset: 0xABE1E8 VA: 0xABE1E8
	// public bool HLNJABHOBKL() { }

	// // RVA: 0xABB770 Offset: 0xABB770 VA: 0xABB770
	public DFABPMMMIIB GLJKKGFPEPA(int _APFDNBGMMMM_BingoId)
	{
		return CEHNIJPOEAF.Find((DFABPMMMIIB JPAEDJJFFOI) =>
		{
			//0x1E53274
			return JPAEDJJFFOI.PPFNGGCBJKC_id == _APFDNBGMMMM_BingoId;
		});
	}

	// // RVA: 0xABE2E0 Offset: 0xABE2E0 VA: 0xABE2E0
	public void GJENEJOANEL(int _APFDNBGMMMM_BingoId, DKFJADMCNPI.NLKCMNHOBAI _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _HMFFHLPNMPH_count, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		if(saveBingo != null)
		{
			if(saveBingo.BJOHOIAKKFM_Bst != 0)
			{
				if(_INDDJNMPONH_type > 0 && _INDDJNMPONH_type <= DKFJADMCNPI.NLKCMNHOBAI.GJPEANBALKF/*15*/)
				{
					switch(_INDDJNMPONH_type)
					{
						case DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1/*1*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AGNDGJOPIDL_AddShop(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.IBGNFEOLKDP/*2*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.JLKOBAAEDAM_AddLogin(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.KENMCJCIGIB_3/*3*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KKHPAHICACE_AddVOpCValue(_PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							if(_PPFNGGCBJKC_id > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KKHPAHICACE_AddVOpCValue(0, _HMFFHLPNMPH_count);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.LFLMBPJJEEG_4/*4*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NKOPNPPGPCD_AddDOpcValue(_PPFNGGCBJKC_id + -1, _HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.BCMLFJPLKAM_5/*5*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.APEIECMCGGH_AddDOoCValue(_PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							if (_PPFNGGCBJKC_id > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.APEIECMCGGH_AddDOoCValue(0, _HMFFHLPNMPH_count);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.EGFEFGJLKLA_6/*6*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PDHLABPHFNB_AddDopuValue(_PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							if (_PPFNGGCBJKC_id > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PDHLABPHFNB_AddDopuValue(0, _HMFFHLPNMPH_count);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.HOOJOFACOEK/*7*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PCLBKGHNJPN_AddChgcValue(_PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							if (_PPFNGGCBJKC_id > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PCLBKGHNJPN_AddChgcValue(0, _HMFFHLPNMPH_count);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.DAOKJMHHKGP_8/*8*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CCIDPHJEONL_AddGiftValue(_PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							if (_PPFNGGCBJKC_id > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CCIDPHJEONL_AddGiftValue(0, _HMFFHLPNMPH_count);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.NGDJIJOIPIB/*9*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CNEMNJOLIBE_AddScene(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.EHEDFAMGLDP_10/*10*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJDEINMOHOP_AddMedal(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.KJAFDMGNBPO_11/*11*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.OAEMBFCMCHL_DailyMission(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.CLJHDIKFECG_12/*12*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HFOCJMOOMBB_EventMission(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/:
							GJENEJOANEL(saveBingo, DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/, _PPFNGGCBJKC_id, _HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.DOEHLCLBCNN_14/*14*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BFAJMALBALG_Gacha(_HMFFHLPNMPH_count);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.GJPEANBALKF/*15*/:
							if(OMNOFMEBLAD != null && !OMNOFMEBLAD.OBOPMHBPCFE_MvMode && OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0)
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PJPHOMJFDEH_EventPlay(_HMFFHLPNMPH_count);
							return;
					}
				}
			}
		}
	}

	// // RVA: 0xABE998 Offset: 0xABE998 VA: 0xABE998
	public void GJENEJOANEL(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, int _APFDNBGMMMM_BingoId, DKFJADMCNPI.NLKCMNHOBAI _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _HMFFHLPNMPH_count)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(_AHEFHIMGIBI_PlayerData, _APFDNBGMMMM_BingoId);
		if(bingo != null)
		{
			if(bingo.BJOHOIAKKFM_Bst != 0)
			{
				if(_INDDJNMPONH_type != DKFJADMCNPI.NLKCMNHOBAI.NGDJIJOIPIB/*9*/)
					return;
				bingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CNEMNJOLIBE_AddScene(_HMFFHLPNMPH_count);
			}
		}
	}

	// // RVA: 0xABE6F4 Offset: 0xABE6F4 VA: 0xABE6F4
	private void GJENEJOANEL(NFMHCLHEMHB_Bingo.CCGKCGJKADC NHLBKJCPLBL, DKFJADMCNPI.NLKCMNHOBAI _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _HMFFHLPNMPH_count)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(NHLBKJCPLBL.AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId);
			List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ_GetValidBingoCells(NHLBKJCPLBL.PPFNGGCBJKC_id, NHLBKJCPLBL.AHCFGOGCJKI_St.PPFNGGCBJKC_id, divaInfo != null ? divaInfo.AIHCEGFANAM_SerieAttr : 0, NHLBKJCPLBL.AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId);
			for(int i = 0; i < l.Count; i++)
			{
				if(_INDDJNMPONH_type == DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/)
				{
					if(l[i].MAPNDFCJFLJ_ConditionType == 87)
					{
						if(_PPFNGGCBJKC_id != l[i].JBFLEDKDFCO_cid)
						{
							if (l[i].JBFLEDKDFCO_cid != 0)
								continue;
						}
						NHLBKJCPLBL.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MPOEJLFDAGJ_AddMedalShopValue(i, _HMFFHLPNMPH_count);
					}
				}
			}
		}
	}

	// // RVA: 0xABEA14 Offset: 0xABEA14 VA: 0xABEA14
	public void GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI _INDDJNMPONH_type, int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		for(int i = 0; i < l.Count; i++)
		{
			GJENEJOANEL(l[i], _INDDJNMPONH_type, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count, OMNOFMEBLAD);
		}
	}

	// // RVA: 0xABEB0C Offset: 0xABEB0C VA: 0xABEB0C
	public void GJENEJOANEL(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, DKFJADMCNPI.NLKCMNHOBAI _INDDJNMPONH_type, int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		for(int i = 0; i < l.Count; i++)
		{
			GJENEJOANEL(_AHEFHIMGIBI_PlayerData, l[i], _INDDJNMPONH_type, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}
	}

	// // RVA: 0xABEBF4 Offset: 0xABEBF4 VA: 0xABEBF4
	public int GOIAHBFBKPF(int _APFDNBGMMMM_BingoId, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF _KOGBMDOONFA_Info, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _HMFFHLPNMPH_count)
	{
		int CHOFDPDFPDC_ConfigValue = _KOGBMDOONFA_Info.JBFLEDKDFCO_cid;
		int type = _KOGBMDOONFA_Info.MAPNDFCJFLJ_ConditionType;
		int a = _KOGBMDOONFA_Info.NDFOAINJPIN_pos;
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		if(type < 18)
		{
			if(type < 15)
			{
				if(type == 7)
				{
					for(int i = 0; i < _LKMHPJKIFDN_md.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
					{
						LAEGMENIEDB_Story.ALGOILKGAAH dbData = _LKMHPJKIFDN_md.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
						if (dbData.KLCIIHKFPPO_StoryMusicId == CHOFDPDFPDC_ConfigValue)
						{
							return _LDEGEHAEALK_ServerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbData.LFLLLOPAKCO_StoryId - 1].HALOKFOJMLA_IsCompleted ? 1 : 0;
						}
					}
					return 0;
				}
				if(type == 14)
				{
					return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				}
			}
			else
			{
				if(type == 15)
				{
					if(CHOFDPDFPDC_ConfigValue > 0)
					{
						if (_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count < CHOFDPDFPDC_ConfigValue)
							return 0;
						return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[CHOFDPDFPDC_ConfigValue - 1].HEBKEJBDCBH_diva_lv;
					}
					if (_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count > 0)
					{
						int res = 0;
						for (int i = 0; i < _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
						{
							if (_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_have != 0 &&
								_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_diva_lv > res)
								res = _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_diva_lv;
						}
						return res;
					}
					return 0;
				}
				if(type == 17)
				{
					return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.MPFLFKBNFEI_GetNumSceneAtLevelOrMore(_LKMHPJKIFDN_md.HNMMJINNHII_Game, _LKMHPJKIFDN_md.ECNHDEHADGL_Scene, CHOFDPDFPDC_ConfigValue);
				}
			}
			return _HMFFHLPNMPH_count + 1;
		}
		if(type < 34)
		{
			if(type == 23)
			{
				if (OMNOFMEBLAD == null)
					return _HMFFHLPNMPH_count;
				if (OMNOFMEBLAD.KNIFCANOHOC_score > _HMFFHLPNMPH_count)
					return OMNOFMEBLAD.KNIFCANOHOC_score;
				return _HMFFHLPNMPH_count;
			}
			if(type == 31)
			{
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BOLCACJFJGG_Shop;
			}
			if(type == 33)
			{
				int cnt = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count;
				if (cnt < 1)
					return 0;
				int res = 0;
				for(int i = 0; i < cnt; i++)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
					if(dbScene.PPEGAKEIEGM_Enabled == 2)
					{
						res += _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i].DMNIMMGGJJJ_Leaf;
					}
				}
				return res;
			}
			return _HMFFHLPNMPH_count + 1;
		}
		switch(type)
		{
			case 54:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(CHOFDPDFPDC_ConfigValue);
			case 55:
				if(CHOFDPDFPDC_ConfigValue > 0)
				{
					if (CHOFDPDFPDC_ConfigValue > 10)
						return 0;
					return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJNFMAAKCMH_GetDOpCValue(CHOFDPDFPDC_ConfigValue - 1);
				}
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(3);
			case 59:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.ODJEADMLGFB_Lgin;
			case 61:
				if(CHOFDPDFPDC_ConfigValue < 1)
				{
					int res = 0;
					for(int i = 0; i < 10; i++)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1);
						if (divaInfo.CPGFPEDMDEH_have == 1 && divaInfo.KCCONFODCPN_IntimacyLevel > res)
							res = divaInfo.KCCONFODCPN_IntimacyLevel;
					}
					return res;
				}
				else
				{
					if(CHOFDPDFPDC_ConfigValue < 11)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(CHOFDPDFPDC_ConfigValue);
						if (divaInfo.CPGFPEDMDEH_have == 1)
							return divaInfo.KCCONFODCPN_IntimacyLevel;
					}
				}
				return 0;
			case 62:
				{
					int cnt = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count;
					int cnt2 = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count;
					if (cnt2 < cnt)
					{
						cnt = cnt2;
					}
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
							if (dbScene.PPEGAKEIEGM_Enabled == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG scene = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i];
								res += dbScene.AGOEDLNOHND(_LKMHPJKIFDN_md.JEMMMJEJLNL_Board, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_NumBoard, _LKMHPJKIFDN_md.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed));
							}
						}
						return res;
					}
					return 0;
				}
			case 65:
				if(CHOFDPDFPDC_ConfigValue < 1)
				{
					int b = _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(_LKMHPJKIFDN_md.MFPNGNMFEAL_Costume, _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva, true);
					List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> l = _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.FindAll((DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo JPAEDJJFFOI) =>
					{
						//0x1E52FE4
						return JPAEDJJFFOI.CPGFPEDMDEH_have == 1;
					});
					int c = 0;
					if(b > 0)
					{
						c = _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(2).CGKAEMGLHNK_Possessed() ? 1 : 0;
					}
					return (b - c) - l.Count;
				}
				else
				{
					int res = 0;
					List<LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo> l = _LKMHPJKIFDN_md.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.FindAll((LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo JPAEDJJFFOI) =>
					{
						//0x1E53018
						if(JPAEDJJFFOI.PPEGAKEIEGM_Enabled == 2)
						{
							return CHOFDPDFPDC_ConfigValue == JPAEDJJFFOI.AHHJLDLAPAN_DivaId;
						}
						return false;
					});
					for(int i = 0; i < l.Count; i++)
					{
						LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = l[i];
						if(c.JPIDIENBGKH_CostumeId != 2)
						{
							if(c.DAJGPBLEEOB_ModelId != 1)
							{
								res += _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(c.JPIDIENBGKH_CostumeId).CGKAEMGLHNK_Possessed() ? 1 : 0;
							}
						}
					}
					return res;
				}
			case 66:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KGFLHCHAIGO_GetChgcValue(CHOFDPDFPDC_ConfigValue);
			case 67:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKKOANOJHLB_GetGiftValue(CHOFDPDFPDC_ConfigValue);
			case 68:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MLBJKMLMLEG_GetDOocValue(CHOFDPDFPDC_ConfigValue);
			case 69:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FGGFDPFMKAF_GetDopuValue(CHOFDPDFPDC_ConfigValue);
			case 70:
				if(CHOFDPDFPDC_ConfigValue < 1)
				{
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList.Count; i++)
					{
						if(_LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[i].CGKAEMGLHNK_Possessed())
						{
							if(res < _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[i].ANAJIAENLNB_lv)
							{
								res = _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[i].ANAJIAENLNB_lv;
							}
						}
					}
					return res;
				}
				else
				{
					int res = 0;
					if (CHOFDPDFPDC_ConfigValue < 11)
					{
						for(int i = 0; i < _LKMHPJKIFDN_md.MFPNGNMFEAL_Costume.CDENCMNHNGA_table.Count; i++)
						{
							if(_LKMHPJKIFDN_md.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[i].AHHJLDLAPAN_DivaId == CHOFDPDFPDC_ConfigValue)
							{
								EBFLJMOCLNA_Costume.ILFJDCICIKN cos = _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(_LKMHPJKIFDN_md.MFPNGNMFEAL_Costume.CDENCMNHNGA_table[i].JPIDIENBGKH_CostumeId);
								if (cos.CGKAEMGLHNK_Possessed())
								{
									if(res < cos.ANAJIAENLNB_lv)
									{
										res = cos.ANAJIAENLNB_lv;
									}
								}
							}
						}
					}
					return res;
				}
			case 71:
				{
					int cnt = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count;
					int cnt2 = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count;
					if (cnt2 < cnt)
						cnt = cnt2;
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
							if (dbScene.PPEGAKEIEGM_Enabled == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i];
								if (saveScene.JPIPENJGGDD_NumBoard > 1)
								{
									res += (saveScene.JPIPENJGGDD_NumBoard - 1);
								}
							}
						}
						return res;
					}
					//LAB_00ac00c8
					return 0;
				}
			case 82:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FFMHGGHFNPJ_Scene;
			case 83:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNNKOAILFOL_Medal;
			case 84:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GCEKFPECEAI_DailyMission;
			case 85:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HJNEMKGIBGE_EventMission;
			case 86:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AIPKHFKODAH_EventPlay;
			case 87:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CDNJPNFGHOG_GetMedalShopValue(a - 1);
			case 88:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NHPNPIBOHFB_Gacha;
			case 89:
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.NEAGFIEMLIL_GetSceneLevel(_LKMHPJKIFDN_md.HNMMJINNHII_Game, _LKMHPJKIFDN_md.ECNHDEHADGL_Scene, CHOFDPDFPDC_ConfigValue);
			case 34:
				HighScoreRating hs = new HighScoreRating();
				hs.CalcUtaRate(null, false);
				return hs.GetUtaRateTotal();
			case 56:
			case 57:
			case 58:
			case 60:
			case 63:
			case 64:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
			case 81:
			default:
				return _HMFFHLPNMPH_count + 1;
		}
	}

	// // RVA: 0xAC0900 Offset: 0xAC0900 VA: 0xAC0900
	public bool FGHOILFCCKC(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF _KOGBMDOONFA_Info, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, long _JHNMKKNEENE_Time)
	{
		int val = _KOGBMDOONFA_Info.JBFLEDKDFCO_cid;
		//_KOGBMDOONFA_Info.FDBOPFEOENF_diva
		KEODKEGFDLD_FreeMusicInfo fminfo = null;
		EONOEHOKBEB_Music minfo = null;
		if(OMNOFMEBLAD != null)
		{
			fminfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			minfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
			if(OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
			{
				if (_KOGBMDOONFA_Info.MAPNDFCJFLJ_ConditionType == 0)
					return true;
				return _KOGBMDOONFA_Info.MAPNDFCJFLJ_ConditionType == 29;
			}
		}
		int a = _KOGBMDOONFA_Info.MAPNDFCJFLJ_ConditionType;
		if(a < 32)
		{
			switch (a)
			{
				case 0:
				case 7:
				case 14:
				case 15:
				case 17:
				case 23:
				case 31:
					return true;
				case 8:
					return OMNOFMEBLAD != null;
				case 9:
					if (fminfo == null || OMNOFMEBLAD == null)
						return false;
					if (_KOGBMDOONFA_Info.CPKMLLNADLJ_Serie == 0)
					{
						if (val != 0)
						{
							return minfo.AIHCEGFANAM_SerieAttr == val - 1;
						}
					}
					return _KOGBMDOONFA_Info.CPKMLLNADLJ_Serie == minfo.AIHCEGFANAM_SerieAttr;
				case 10:
					if (OMNOFMEBLAD != null)
					{
						return _KOGBMDOONFA_Info.GOKJLBDJOLA_df == OMNOFMEBLAD.AKNELONELJK_difficulty;
					}
					break;
				case 12:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
					}
					break;
				case 13:
					if (OMNOFMEBLAD != null)
					{
						return fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score) == 4;
					}
					break;
				case 21:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.KNCBNGCDMII_HadValkyrieMode;
					}
					break;
				case 22:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.HGEKDNNJAAC_AwakenDivaMode;
					}
					break;
			}
			return false;
		}
		if (a >= 33 & a <= 34)
			return true;
		switch(a)
		{
			case 54:
			case 55:
			case 59:
			case 61:
			case 62:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
				return true;
			case 60:
				if (OMNOFMEBLAD != null)
					return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == val;
				break;
			case 63:
				if(OMNOFMEBLAD != null)
				{
					for(int i = 0; i < OMNOFMEBLAD.CPNOKMINILL_SkillDataList.Count; i++)
					{
						if (OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].isActive && (int)OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].skillType == val)
							return true;
					}
				}
				break;
			case 64:
				if(OMNOFMEBLAD != null)
				{
					for (int i = 0; i < OMNOFMEBLAD.CPNOKMINILL_SkillDataList.Count; i++)
					{
						if (!OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].isActive && (int)OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].skillType == val)
							return true;
					}
				}
				break;
			case 72:
				if(OMNOFMEBLAD != null)
				{
					List<IBJAKJJICBC> list = IBJAKJJICBC.FKDIMODKKJD(5, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime, true, false, false, false);
					for(int i = 0; i < list.Count; i++)
					{
						if(list[i].LHONOILACFL_IsWeeklyEvent)
						{
							if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == list[i].GHBPLHBNMBK_FreeMusicId)
								return true;
						}
					}
				}
				break;
			case 73:
				if(fminfo != null && OMNOFMEBLAD != null)
				{
					return fminfo.DLAEJOBELBH_MusicId == val;
				}
				break;
		}
		return false;
	}

	// // RVA: 0xAC108C Offset: 0xAC108C VA: 0xAC108C
	public bool HEFIKPAHCIA_UpdateMission(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE_Time/* = -1*/)
    {
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		if(JHNMKKNEENE_Time < 0)
		{
			JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}
		bool res = false;
		for(int i = 0; i < l.Count; i++)
		{
			res |= HEFIKPAHCIA_UpdateMission(l[i], OMNOFMEBLAD, JHNMKKNEENE_Time);
		}
		return res;
    }

	// // RVA: 0xAC1228 Offset: 0xAC1228 VA: 0xAC1228
	public bool HEFIKPAHCIA_UpdateMission(int _APFDNBGMMMM_BingoId, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long _JHNMKKNEENE_Time/* = -1*/)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
		{
            NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
            if (bingo.BJOHOIAKKFM_Bst != 0)
			{
				int id = bingo.AHCFGOGCJKI_St.PPFNGGCBJKC_id;
				int scoreRank = 0;
				EONOEHOKBEB_Music minfo = null;
				int rankCombo = 0;
				if(OMNOFMEBLAD != null)
				{
					KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
					minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
					ADDHLABEFKH a = fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty);
					scoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
					rankCombo = a.CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_combo);
				}
				int diva = bingo.AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId;
                BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(diva);
				int attr = 0;
				if(divaInfo != null)
				{
					attr = divaInfo.AIHCEGFANAM_SerieAttr;
				}
				JKICPBIIHNE_Bingo.HNOGDJFJGPM dbBinfo = EBEDAPJFHCE_GetBingo(_APFDNBGMMMM_BingoId);
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ_GetValidBingoCells(_APFDNBGMMMM_BingoId, id, attr, diva);
				if(_JHNMKKNEENE_Time < 0)
				{
					_JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				}
				for(int i = 0; i < l.Count; i++)
				{
					bool b = false;
					if(OMNOFMEBLAD == null)
					{
						b = true;
					}
					else
					{
						if(l[i].CPKMLLNADLJ_Serie < 1 || (l[i].CPKMLLNADLJ_Serie == minfo.AIHCEGFANAM_SerieAttr))
						{
							//LAB_00ac1720
							if(l[i].GOKJLBDJOLA_df > 0)
							{
								if(OMNOFMEBLAD.AKNELONELJK_difficulty < (l[i].GOKJLBDJOLA_df - 1))
									continue;
							}
							if(l[i].GPNPBHLLHDI_srnk <= scoreRank)
							{
								if(l[i].IMEPEOAFIIB_cbrnk <= rankCombo)
									b = true;
							}
						}
					}
					if(b)
					{
						//LAB_00ac17c0
						if(l[i].FDBOPFEOENF_diva > 0 && l[i].FDBOPFEOENF_diva != diva)
						{
							continue;
						}
						if(FGHOILFCCKC(OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, 0))
						{
							int a = GOIAHBFBKPF(_APFDNBGMMMM_BingoId, OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[l[i].NDFOAINJPIN_pos - 1].HMFFHLPNMPH_count);
							if(l[i].PMDLBHLNIDP_Target <= a)
							{
								if(bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[l[i].NDFOAINJPIN_pos - 1].CMCKNKKCNDK_status < 2)
								{
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[l[i].NDFOAINJPIN_pos - 1].CMCKNKKCNDK_status = 2;
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[l[i].NDFOAINJPIN_pos - 1].OPGPHAEMIDO_Dt = _JHNMKKNEENE_Time;
								}
								a = l[i].PMDLBHLNIDP_Target;
							}
							bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[l[i].NDFOAINJPIN_pos - 1].HMFFHLPNMPH_count = a;
						}
					}
				}
				return true;
            }
		}
		return false;
	}

	// // RVA: 0xAC1BB8 Offset: 0xAC1BB8 VA: 0xAC1BB8
	public void FBHHEBDDIMO(int _APFDNBGMMMM_BingoId, bool NLNNKIKIPBJ)
	{
		MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).BJOHOIAKKFM_Bst = NLNNKIKIPBJ ? 1 : 0;
	}

	// // RVA: 0xAC1BF0 Offset: 0xAC1BF0 VA: 0xAC1BF0
	public List<JJPEIELNEJB.JLHHGLANHGE> HNBJHJENFGL(JJPEIELNEJB.OMMBBPKFLNH _KOGBMDOONFA_Info, List<int> FFLGNFIAFFE)
	{
		List<JJPEIELNEJB.JLHHGLANHGE> res = new List<JJPEIELNEJB.JLHHGLANHGE>();
		CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
        NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_KOGBMDOONFA_Info.APFDNBGMMMM_BingoId);
		for(int i = 0; i < FFLGNFIAFFE.Count; i++)
		{
			JJPEIELNEJB.JLHHGLANHGE data = new JJPEIELNEJB.JLHHGLANHGE();
			data.PPFNGGCBJKC_id = _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].PPFNGGCBJKC_id;
			data.GLCLFMGPMAN_ItemId = _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].GLCLFMGPMAN_ItemId;
			data.MJBKGOJBPAD_item_type = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(data.GLCLFMGPMAN_ItemId);
			data.OCNINMIMHGC_item_value = EKLNMHFCAOI.DEACAHNLMNI_getItemId(data.GLCLFMGPMAN_ItemId);
			data.HAAJGNCFNJM_item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.GLCLFMGPMAN_ItemId);
			data.LJKMKCOAICL_ItemCount = _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].LJKMKCOAICL_ItemCount;
			data.FLGEGLADKHC_MissionText = _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].FEMMDNIELFC_Desc;
			res.Add(data);
			CPIICACGNBH(CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL_InventoryUtil, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, data.GLCLFMGPMAN_ItemId, data.LJKMKCOAICL_ItemCount, _KOGBMDOONFA_Info.APFDNBGMMMM_BingoId);
			saveBingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[FFLGNFIAFFE[i]].CMCKNKKCNDK_status = 3;
			ILCCJNDFFOB.HHCJCDFCLOB.JHAPELNFEOM(_KOGBMDOONFA_Info.APFDNBGMMMM_BingoId, _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].PPFNGGCBJKC_id, _KOGBMDOONFA_Info.BECEJMHDBBP[FFLGNFIAFFE[i]].JEPGJJJBFLN_ConditionText);
		}
		return res;
    }

	// // RVA: 0xAC21E4 Offset: 0xAC21E4 VA: 0xAC21E4
	public void CPIICACGNBH(JKNGJFOBADP _JANMJPOKLFL_InventoryUtil, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_count, int _APFDNBGMMMM_BingoId)
	{
		StringBuilder str = new StringBuilder();
		str.Append(_APFDNBGMMMM_BingoId);
		str.Append(':');
		_JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.DIDJLIPNCKO_29, str.ToString());
		_JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(_LDEGEHAEALK_ServerData, _KIJAPOFAGPN_ItemId, _HMFFHLPNMPH_count, null, 0);
	}

	// // RVA: 0xAC234C Offset: 0xAC234C VA: 0xAC234C
	public bool NJJLNPOCKFO(int _APFDNBGMMMM_BingoId)
	{
        NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		int EIHOBHDKCDB_RewardId = saveBingo.AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId;
		if(EIHOBHDKCDB_RewardId < 1)
			return false;
		else
		{
			NFMHCLHEMHB_Bingo.OCLGCNPBNHE d = saveBingo.AHJNPEAMCCH_rewards.Find((NFMHCLHEMHB_Bingo.OCLGCNPBNHE JPAEDJJFFOI) =>
			{
				//0x1E5308C
				return EIHOBHDKCDB_RewardId == JPAEDJJFFOI.PPFNGGCBJKC_id;
			});
			if(d != null)
			{
				d.MIKCFEHGNJB_dt = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				return true;
			}
		}
		return false;
    }

	// // RVA: 0xAC257C Offset: 0xAC257C VA: 0xAC257C
	public int OBOGIOGEBPK(int _APFDNBGMMMM_BingoId, FKMOKDCJFEN.ADCPCCNCOMD_Status _CMCKNKKCNDK_status)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId);
		int res = 0;
		for(int i = 0; i < bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions.Count; i++)
		{
			if (bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[i].CMCKNKKCNDK_status == (int)_CMCKNKKCNDK_status)
				res++;
		}
		return res;
	}

	// // RVA: 0xAC26A8 Offset: 0xAC26A8 VA: 0xAC26A8
	// public int OBOGIOGEBPK(FKMOKDCJFEN.ADCPCCNCOMD _CMCKNKKCNDK_status) { }

	// // RVA: 0xAC2790 Offset: 0xAC2790 VA: 0xAC2790
	public void MNMCNPLIEFM(int _APFDNBGMMMM_BingoId, bool NLNNKIKIPBJ)
	{
		MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).AHCFGOGCJKI_St.JBMGFNHBECN_Sst = NLNNKIKIPBJ ? 1 : 0;
	}

	// // RVA: 0xAC27DC Offset: 0xAC27DC VA: 0xAC27DC
	public bool DOEGBMNNFKH(int _APFDNBGMMMM_BingoId)
	{
		return MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).AHCFGOGCJKI_St.JBMGFNHBECN_Sst != 0;
	}

	// // RVA: 0xAC2828 Offset: 0xAC2828 VA: 0xAC2828
	public bool EAJLHMIMAPE(int _APFDNBGMMMM_BingoId)
	{
		return MENDFPNPAAO_GetSaveBingo(_APFDNBGMMMM_BingoId).JNLKJCDFFMM_clear == 1;
	}
}
