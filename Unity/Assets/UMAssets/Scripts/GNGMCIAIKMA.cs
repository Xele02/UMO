using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;

public class GNGMCIAIKMA
{
	public class DFABPMMMIIB
	{
		public static int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x0
		public static long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x8
		public int EHOIENNDEDH; // 0x8
		public int JLCIMGKBDKD; // 0xC
		public long PCLNFCNIECH; // 0x10
		public long HHPIJHADAOB; // 0x18
		public NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x20
		public List<GGJOIEMJPEF> PJNIEFHBGIF = new List<GGJOIEMJPEF>(); // 0x24
		public List<KDGHBAGLKEP> LNHNECFGEPO = new List<KDGHBAGLKEP>(); // 0x28

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1E532B4 DEMEPMAEJOO 0x1E5334C HIGKAIDMOKN
		public int NMMPEIIDBJL { get { return JLCIMGKBDKD ^ FBGGEFFJJHB; } set { JLCIMGKBDKD = value ^ FBGGEFFJJHB; } } //0x1E533E8 FFOPNIECCMB 0x1E53480 ECPBEDDJHAL
		public long PDBPFJJCADD_StartTime { get { return PCLNFCNIECH ^ BBEGLBMOBOF; } set { PCLNFCNIECH = value ^ BBEGLBMOBOF; } } //0x1E5351C FOACOMBHPAC 0x1E535B8 NBACOBCOJCA
		public long FDBNFFNFOND_EndTime { get { return HHPIJHADAOB ^ BBEGLBMOBOF; } set { HHPIJHADAOB = value ^ BBEGLBMOBOF; } } //0x1E5365C BPJOGHJCLDJ 0x1E536F8 NLJKMCHOCBK
		public string OCDMGOGMHGE { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x1E5379C HBAAAKFHDBB 0x1E537C8 NHJLJOIPOFK

		// RVA: 0x1E537FC Offset: 0x1E537FC VA: 0x1E537FC
		public DFABPMMMIIB()
		{
			PPFNGGCBJKC = 0;
			NMMPEIIDBJL = 0;
			PDBPFJJCADD_StartTime = 0;
			FDBNFFNFOND_EndTime = 0;
			OCDMGOGMHGE = "";
			PJNIEFHBGIF.Clear();
			LNHNECFGEPO.Clear();
		}

		//// RVA: 0x1E53990 Offset: 0x1E53990 VA: 0x1E53990
		public bool KHEKNNFCAOI(int APFDNBGMMMM)
		{
			PPFNGGCBJKC = APFDNBGMMMM;
			if(HHCJCDFCLOB != null)
			{
				JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = HHCJCDFCLOB.FJLIDJJAGOM_GetBingoDb().JJAICEAEGKF[HHCJCDFCLOB.NIGPFNIIDII(APFDNBGMMMM)];
				JKICPBIIHNE_Bingo.EHLBDNHLCIN d = bingo.DPGMFEGFCJN[0];
				NMMPEIIDBJL = bingo.OGKBHHLMMID;
				PDBPFJJCADD_StartTime = bingo.PDBPFJJCADD_StartTime;
				FDBNFFNFOND_EndTime = bingo.FDBNFFNFOND_EndTime;
				OCDMGOGMHGE = bingo.OCDMGOGMHGE;
				LNHNECFGEPO.Clear();
				for(int i = 0; i < d.PFEGHILDOGF.Count; i++)
				{
					if(HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(d.PFEGHILDOGF[i].PLALNIIBLOF))
					{
						KDGHBAGLKEP data = new KDGHBAGLKEP();
						data.PPFNGGCBJKC = d.PFEGHILDOGF[i].PPFNGGCBJKC;
						data.FDBOPFEOENF = d.PFEGHILDOGF[i].FDBOPFEOENF;
						data.CPKMLLNADLJ = d.PFEGHILDOGF[i].CPKMLLNADLJ;
						data.GLCLFMGPMAN.Clear();
						for(int j = 0; j < 8; j++)
						{
							CEBFFLDKAEC_SecureInt data2 = new CEBFFLDKAEC_SecureInt();
							data2.DNJEJEANJGL_Value = d.PFEGHILDOGF[i].FKNBLDPIPMC(j);
							data.GLCLFMGPMAN.Add(data2);
						}
						LNHNECFGEPO.Add(data);
					}
				}
				PJNIEFHBGIF.Clear();
				for(int i = 0; i < d.CFHKEJHDGBG.Count; i++)
				{
					if (HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(d.CFHKEJHDGBG[i].PLALNIIBLOF))
					{
						GGJOIEMJPEF data = new GGJOIEMJPEF();
						data.KHEKNNFCAOI(d.CFHKEJHDGBG[i], LNHNECFGEPO.Count);
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
		public static int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x0
		public static long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x8
		private int EHOIENNDEDH; // 0x8
		public List<JCIFAFBDALP> EIOBAIJMNGL = new List<JCIFAFBDALP>(); // 0xC
		public List<JLHGLHJDAGN> KHMNCCCPLLC = new List<JLHGLHJDAGN>(); // 0x10
		public sbyte FGMOPPIODAE; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1E54794 DEMEPMAEJOO 0x1E5482C HIGKAIDMOKN
		public bool EOALGPLPGKB { get { return FGMOPPIODAE == 29; } set { FGMOPPIODAE = (sbyte)(value ? 29 : 63); } } // 0x1E548C8 AINFOGCAHAP 0x1E548DC ONIAGBIHOKN

		// RVA: 0x1E54288 Offset: 0x1E54288 VA: 0x1E54288
		public GGJOIEMJPEF()
		{
			EOALGPLPGKB = false;
			PPFNGGCBJKC = 0;
			EIOBAIJMNGL.Clear();
			KHMNCCCPLLC.Clear();
		}

		//// RVA: 0x1E543C4 Offset: 0x1E543C4 VA: 0x1E543C4
		public bool KHEKNNFCAOI(JKICPBIIHNE_Bingo.CCOCDFGGDBB NDFIEMPPMLF, int IKOLGECGPNM)
		{
			if(HHCJCDFCLOB != null)
			{
				if(HHCJCDFCLOB.DKMLDEDKPBA_IsEnabled(NDFIEMPPMLF.PLALNIIBLOF))
				{
					PPFNGGCBJKC = NDFIEMPPMLF.PPFNGGCBJKC;
					EIOBAIJMNGL.Clear();
					for(int i = 0; i < 8; i++)
					{
						JCIFAFBDALP data = new JCIFAFBDALP();
						data.PPFNGGCBJKC = NDFIEMPPMLF.FKNBLDPIPMC(i);
						data.BFINGCJHOHI = NDFIEMPPMLF.KAINPNMMAEK(i);
						data.MPKBLMCNHOM = NDFIEMPPMLF.BLLCPCGGHJM(i) > 0;
						EIOBAIJMNGL.Add(data);
					}
					if (IKOLGECGPNM < 1)
						EOALGPLPGKB = false;
					else
					{
						EOALGPLPGKB = EIOBAIJMNGL.Find((JCIFAFBDALP JPAEDJJFFOI) =>
						{
							//0x1E54CA0
							if(JPAEDJJFFOI.BFINGCJHOHI > 0)
							{
								if(JPAEDJJFFOI.PPFNGGCBJKC > 0)
								{
									return JPAEDJJFFOI.PPFNGGCBJKC < IKOLGECGPNM;
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
		//public bool KHEKNNFCAOI(int AMCCOGJACPK) { }
	}

	public class JLHGLHJDAGN
	{
		public static int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x0
		public static long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x8
		public int JJHPDDPKBHF; // 0x8
		private int EHOIENNDEDH; // 0xC
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN = new NNJFKLBPBNK_SecureString(); // 0x10
		private NNJFKLBPBNK_SecureString IDCENBCAPBP = new NNJFKLBPBNK_SecureString(); // 0x14
		private int EHLGHDIACCG; // 0x18
		private int FILBJBFDMMN; // 0x1C
		private int KGKIDDDKOGL; // 0x20
		private int AHGCGHAAHOO; // 0x24
		private int GNMMBOFGBCO; // 0x28
		private int AIGOPKGALKA; // 0x2C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1E54F04 DEMEPMAEJOO 0x1E54F9C HIGKAIDMOKN
		public string FEMMDNIELFC { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x1E55038 JDHDMBHNKJD 0x1E55064 FNAJEJLLJOE
		public string JEPGJJJBFLN { get { return IDCENBCAPBP.DNJEJEANJGL_Value; } set { IDCENBCAPBP.DNJEJEANJGL_Value = value; } } //0x1E55098 AKHEBLBJGBP 0x1E550C4 EEJDMJMLKMG
		public int GOKJLBDJOLA { get { return EHLGHDIACCG ^ FBGGEFFJJHB; } set { EHLGHDIACCG = value ^ FBGGEFFJJHB; } } //0x1E550F8 CCEEILBGBOM 0x1E55190 MKNIFMGHJHC
		public int MAPNDFCJFLJ { get { return FILBJBFDMMN ^ FBGGEFFJJHB; } set { FILBJBFDMMN = value ^ FBGGEFFJJHB; } } //0x1E5522C IPFCNEIHNLJ 0x1E552C4 CLNEANLIOFN
		public int JBFLEDKDFCO { get { return KGKIDDDKOGL ^ FBGGEFFJJHB; } set { KGKIDDDKOGL = value ^ FBGGEFFJJHB; } } //0x1E55360 LIJMKJLDHGP 0x1E553F8 NFNCLFPPADP
		public int GLCLFMGPMAN { get { return AHGCGHAAHOO ^ FBGGEFFJJHB; } set { AHGCGHAAHOO = value ^ FBGGEFFJJHB; } } //0x1E55494 LNJAENEGDEL 0x1E5552C JHIDBGCHOKL
		public int GJABBJOJPEE { get { return GNMMBOFGBCO ^ FBGGEFFJJHB; } set { GNMMBOFGBCO = value ^ FBGGEFFJJHB; } } //0x1E555C8 PDMHLKEJELM 0x1E55660 PHGIOONNIOF

		// RVA: 0x1E556FC Offset: 0x1E556FC VA: 0x1E556FC
		public JLHGLHJDAGN()
		{
			PPFNGGCBJKC = 0;
			FEMMDNIELFC = "";
			JEPGJJJBFLN = "";
			GOKJLBDJOLA = 0;
			MAPNDFCJFLJ = 0;
			JBFLEDKDFCO = 0;
			GLCLFMGPMAN = 0;
			GJABBJOJPEE = 0;
			JJHPDDPKBHF = 0;
		}
	}

	public class JCIFAFBDALP
	{
		public static int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x0
		public static long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x8
		private int EHOIENNDEDH; // 0x8
		private int IFEHKNJONPL; // 0xC
		private sbyte AJGFHCKFCHN; // 0x10

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1E54DBC DEMEPMAEJOO 0x1E5495C HIGKAIDMOKN
		public int BFINGCJHOHI { get { return IFEHKNJONPL ^ FBGGEFFJJHB; } set { IFEHKNJONPL = value ^ FBGGEFFJJHB; } } //0x1E54D24 LFMCLIDAPHB 0x1E549F8 EDAEPDGGFJJ
		public bool MPKBLMCNHOM { get { return AJGFHCKFCHN == 29; } set { AJGFHCKFCHN = (sbyte)(value ? 29 : 63); } } //0x1E54E54 BOFCPLOLHCJ 0x1E54A94 FDPPEPOHFNA

		// RVA: 0x1E54914 Offset: 0x1E54914 VA: 0x1E54914
		public JCIFAFBDALP()
		{
			PPFNGGCBJKC = 0;
			BFINGCJHOHI = 0;
			MPKBLMCNHOM = false;
		}
	}

	public class KDGHBAGLKEP
	{
		public static int FBGGEFFJJHB = GNGMCIAIKMA.FBGGEFFJJHB; // 0x0
		public static long BBEGLBMOBOF = GNGMCIAIKMA.BBEGLBMOBOF; // 0x8
		private int EHOIENNDEDH; // 0x8
		private int LLEMDLLGIAH; // 0xC
		private int IPAKEGGICML; // 0x10
		public List<CEBFFLDKAEC_SecureInt> GLCLFMGPMAN = new List<CEBFFLDKAEC_SecureInt>(); // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1E558A0 DEMEPMAEJOO 0x1E540B4 HIGKAIDMOKN
		public int FDBOPFEOENF { get { return LLEMDLLGIAH ^ FBGGEFFJJHB; } set { LLEMDLLGIAH = value ^ FBGGEFFJJHB; } } //0x1E55938 MJPHCAIKKJG 0x1E54150 GHECGDMEBFF
		public int CPKMLLNADLJ { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = value ^ FBGGEFFJJHB; } } //0x1E559D0 BJPJMGHCDNO 0x1E541EC BPKIOJBKNBP

		// RVA: 0x1E53FD8 Offset: 0x1E53FD8 VA: 0x1E53FD8
		public KDGHBAGLKEP()
		{
			PPFNGGCBJKC = 0;
			FDBOPFEOENF = 0;
			CPKMLLNADLJ = 0;
			GLCLFMGPMAN.Clear();
		}
	}

	public const sbyte HKKJGAJPNIL = 29;
	public const sbyte FKHFJOKHNAK = 63;
	private const short EAPCKKPCPII = 90;
	public static int FBGGEFFJJHB; // 0x0
	public static long BBEGLBMOBOF; // 0x8
	private int ILGOKEAIBBA; // 0x8
	private int NPNDCNDCDPC; // 0xC
	private int PFJENHEKCAO; // 0x10
	private int ELNEJEEKOEI; // 0x14
	private int IDKOMEFBCBD; // 0x18
	public int DKFOMHOJBGD; // 0x1C
	public List<long> GEAHCCJPOCN = new List<long>(); // 0x20
	private readonly sbyte[,] LMEHCADEKLN = new sbyte[3, 8] {
		{ 0x5b, 0x58, 0x59, 0x5e, 0x5f, 0x5c, 0x5d, 0x52},
		{ 0x53, 0x5b, 0x5e, 0x5d, 0x58, 0x5f, 0x52, 0x59}, 
		{ 0x5c, 0x53, 0x5b, 0x5f, 0x53, 0x59, 0x5f, 0x5d}
	}; // 0x24
	public List<DFABPMMMIIB> CEHNIJPOEAF = new List<DFABPMMMIIB>(); // 0x28

	public static GNGMCIAIKMA HHCJCDFCLOB { get; private set; } // 0x10 GNGMCIAIKMA OKPMHKNCNAL
	// public int PMPKHBAJAFA { get; set; } // OAKEIKFELFC 0xAB8FE4  MBHILIEPJOO 0xAB9050
	// public int MALACFEDHDE { get; set; } //  KIMKKEOMPDL 0xAB90C0 PGILHFKNKEN 0xAB912C
	// private int HHKAGEAMHOE { get; set; } // DGNHFHGNDOF 0xAB919C  HDADMLNHJMN 0xAB9208
	// private int EEOPPDBICBN { get; set; } // GDODEJOPENB 0xAB9278 JIJIGMCJHBC 0xAB92E4
	// private int CEGHDFHLFPO { get; set; } // CDJABHMPLKM 0xAB9354  EIHJCGDLLPF 0xAB93C0

	// // RVA: 0xAB9430 Offset: 0xAB9430 VA: 0xAB9430
	// public int DDHNADFGKDF(int GJKPJMGPCEJ, int IKPIDCFOFEA) { }

	// // RVA: 0xAB9524 Offset: 0xAB9524 VA: 0xAB9524
	// public int[] EOPMDFOCAKJ(int GJKPJMGPCEJ) { }

	// // RVA: 0xAB9640 Offset: 0xAB9640 VA: 0xAB9640
	public GNGMCIAIKMA() 
	{ 
		FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
		BBEGLBMOBOF = ~FBGGEFFJJHB; // not sure
		ILGOKEAIBBA = FBGGEFFJJHB;
		NPNDCNDCDPC = FBGGEFFJJHB;
		PFJENHEKCAO = FBGGEFFJJHB;
		ELNEJEEKOEI = FBGGEFFJJHB;
		IDKOMEFBCBD = FBGGEFFJJHB;
	}

	// // RVA: 0xAB9974 Offset: 0xAB9974 VA: 0xAB9974
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xAB99D8 Offset: 0xAB99D8 VA: 0xAB99D8
	public bool GBCPDBJEDHL()
	{
		return GBCPDBJEDHL(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
	}

	// // RVA: 0xAB9AD0 Offset: 0xAB9AD0 VA: 0xAB9AD0
	public bool GBCPDBJEDHL(long JHNMKKNEENE)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			int val = bingoDb.LPJLEHAJADA("bingo_enable", 1);
			if(val != 0)
			{
				if(!QuestUtility.IsBeginnerQuest())
				{
					KIAAOBFJCHP(JHNMKKNEENE);
					return CNADOFDDNLO_GetActiveBingos(JHNMKKNEENE).Count > 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0xABA38C Offset: 0xABA38C VA: 0xABA38C
	public bool NJBPNCDPGNO(int APFDNBGMMMM)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			if(APFDNBGMMMM <= bingoDb.JJAICEAEGKF.Count)
			{
				return bingoDb.JJAICEAEGKF[APFDNBGMMMM - 1].FDBNFFNFOND_EndTime == 0;
			}
		}
		return false;
	}

	// // RVA: 0xABA480 Offset: 0xABA480 VA: 0xABA480
	// public int AMIBPGONGFE(long JHNMKKNEENE, bool HLCDBGGEHPD) { }

	// // RVA: 0xABA5FC Offset: 0xABA5FC VA: 0xABA5FC
	// public void KGABKGKGNCA(int APFDNBGMMMM, bool BCGLDMKODLC) { }

	// // RVA: 0xABA788 Offset: 0xABA788 VA: 0xABA788
	// public int MIGJIALJLOF() { }

	// // RVA: 0xABA8C0 Offset: 0xABA8C0 VA: 0xABA8C0
	// public int FIAHJAMFNPD() { }

	// // RVA: 0xABA9F8 Offset: 0xABA9F8 VA: 0xABA9F8
	// public int GEAMLAKKMLI() { }

	// // RVA: 0xABAB30 Offset: 0xABAB30 VA: 0xABAB30
	public bool DKMLDEDKPBA_IsEnabled(int PLALNIIBLOF)
	{
		return PLALNIIBLOF == 2;
	}

	// // RVA: 0xAB9E7C Offset: 0xAB9E7C VA: 0xAB9E7C
	public List<int> CNADOFDDNLO_GetActiveBingos(long JHNMKKNEENE)
	{
		List<int> res = new List<int>();
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb == null)
			return res;
		List<JKICPBIIHNE_Bingo.HNOGDJFJGPM> l = new List<JKICPBIIHNE_Bingo.HNOGDJFJGPM>();
		for(int i = 0; i < bingoDb.JJAICEAEGKF.Count; i++)
		{
			JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = bingoDb.JJAICEAEGKF[i];
			if(bingo.IJEKNCDIIAE_MasterVersion != 0)
			{
				if(bingo.IJEKNCDIIAE_MasterVersion < DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion)
				{
					if(bingo.PLALNIIBLOF_Enabled == 2)
					{
						if(bingo.PDBPFJJCADD_StartTime != 0)
						{
							if(bingo.PDBPFJJCADD_StartTime > JHNMKKNEENE)
								continue;
						}
						if(bingo.FDBNFFNFOND_EndTime != 0)
						{
							if(bingo.FDBNFFNFOND_EndTime < JHNMKKNEENE)
								continue;
						}
						if(MENDFPNPAAO_GetSaveBingo(bingo.PPFNGGCBJKC).JNLKJCDFFMM_Clear != 1)
						{
							l.Add(bingo);
						}
					}
				}
			}
		}
		l.Sort((JKICPBIIHNE_Bingo.HNOGDJFJGPM HKICMNAACDA, JKICPBIIHNE_Bingo.HNOGDJFJGPM BNKHBCBJBKI) => {
			//0x1E52F64
			return HKICMNAACDA.FDBNFFNFOND_EndTime.CompareTo(BNKHBCBJBKI.FDBNFFNFOND_EndTime);
		});
		for(int i = 0; i < l.Count; i++)
		{
			res.Add(l[i].PPFNGGCBJKC);
		}
		return res;
	}

	// // RVA: 0xABAB40 Offset: 0xABAB40 VA: 0xABAB40
	public List<int> CNADOFDDNLO_GetActiveBingos()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return CNADOFDDNLO_GetActiveBingos(time);
	}

	// // RVA: 0xABAC38 Offset: 0xABAC38 VA: 0xABAC38
	// public bool MHNAINBNLHH(int APFDNBGMMMM) { }

	// // RVA: 0xABAD3C Offset: 0xABAD3C VA: 0xABAD3C
	public bool DHPLHALIDHH(int APFDNBGMMMM)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return DHPLHALIDHH(APFDNBGMMMM, time);
	}

	// // RVA: 0xABAE3C Offset: 0xABAE3C VA: 0xABAE3C
	public bool DHPLHALIDHH(int APFDNBGMMMM, long JHNMKKNEENE)
	{
		long t = EBEDAPJFHCE_GetBingo(APFDNBGMMMM).OGKBHHLMMID;
		if(t != 0)
		{
			return JHNMKKNEENE >= GKDBBGIEPLC(APFDNBGMMMM);
		}
		return true;
	}

	// // RVA: 0xABAFF4 Offset: 0xABAFF4 VA: 0xABAFF4
	// public bool KJNFBLAMJOH(int APFDNBGMMMM) { }

	// // RVA: 0xABAFC4 Offset: 0xABAFC4 VA: 0xABAFC4
	public long GKDBBGIEPLC(int APFDNBGMMMM)
	{
		return MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM).EBDKHCLCOFL_Ul;
	}

	// // RVA: 0xABAFFC Offset: 0xABAFFC VA: 0xABAFFC
	// public long DBEDJLOAILN(int APFDNBGMMMM) { }

	// // RVA: 0xABB2F4 Offset: 0xABB2F4 VA: 0xABB2F4
	public int CBMJAPJKBNL(int PPFNGGCBJKC)
	{
		return OHCAABOMEOF.LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP_EventType.DIDJLIPNCKO/*12*/, PPFNGGCBJKC);
	}

	// // RVA: 0xABB300 Offset: 0xABB300 VA: 0xABB300
	// public int LILBEIBCCKF(int EKANGPODCEP) { }

	// // RVA: 0xABB30C Offset: 0xABB30C VA: 0xABB30C
	// public bool DJGFICMNGGP(int APFDNBGMMMM) { }

	// // RVA: 0xABB380 Offset: 0xABB380 VA: 0xABB380
	// public int MGAHOPFMKHB() { }

	// // RVA: 0xABB3EC Offset: 0xABB3EC VA: 0xABB3EC
	// public bool NJELIKPFBEH(int AMCCOGJACPK) { }

	// // RVA: 0xABB460 Offset: 0xABB460 VA: 0xABB460
	// public int EAIJHJPKBFA(int APFDNBGMMMM) { }

	// // RVA: 0xABB4D4 Offset: 0xABB4D4 VA: 0xABB4D4
	// public int EHFLAKIFPOO(int APFDNBGMMMM) { }

	// // RVA: 0xABB674 Offset: 0xABB674 VA: 0xABB674
	// public bool IDKFAMEFCPD(int APFDNBGMMMM) { }

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
	public JKICPBIIHNE_Bingo.HNOGDJFJGPM EBEDAPJFHCE_GetBingo(int APFDNBGMMMM)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			return bingoDb.JJAICEAEGKF.Find((JKICPBIIHNE_Bingo.HNOGDJFJGPM JPAEDJJFFOI) => {
				//0x1E530F4
				return JPAEDJJFFOI.PPFNGGCBJKC == APFDNBGMMMM;
			});
		}
		return null;
	}

	// // RVA: 0xABB868 Offset: 0xABB868 VA: 0xABB868
	public NFMHCLHEMHB_Bingo PDMHKENDJHI_GetSaveBingoBlock()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PEGNNEFHDOP_Bingo;
		}
		return null;
	}

	// // RVA: 0xABA634 Offset: 0xABA634 VA: 0xABA634
	public NFMHCLHEMHB_Bingo.CCGKCGJKADC MENDFPNPAAO_GetSaveBingo(int PPFNGGCBJKC)
	{
		NFMHCLHEMHB_Bingo saveBingo = PDMHKENDJHI_GetSaveBingoBlock();
		if(saveBingo != null)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC res = saveBingo.MPCJGPEBCCD.Find((NFMHCLHEMHB_Bingo.CCGKCGJKADC JPAEDJJFFOI) => {
				//0x1E53140
				return JPAEDJJFFOI.PPFNGGCBJKC_Id == PPFNGGCBJKC;
			});
			if(res == null)
			{
				NFMHCLHEMHB_Bingo.CCGKCGJKADC n = saveBingo.EACEMMDIPFD_GetEmptyBingo();
				if(n != null)
				{
					n.KHEKNNFCAOI(PPFNGGCBJKC);
					res = n;
				}
			}
			return res;
		}
		return null;
	}

	// // RVA: 0xABB91C Offset: 0xABB91C VA: 0xABB91C
	public NFMHCLHEMHB_Bingo.CCGKCGJKADC MENDFPNPAAO_GetSaveBingo(BBHNACPENDM_ServerSaveData AHEFHIMGIBI, int PPFNGGCBJKC)
	{
		if(AHEFHIMGIBI.PEGNNEFHDOP_Bingo != null)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = AHEFHIMGIBI.PEGNNEFHDOP_Bingo.MPCJGPEBCCD.Find((NFMHCLHEMHB_Bingo.CCGKCGJKADC JPAEDJJFFOI) =>
			{
				//0x1E5318C
				return JPAEDJJFFOI.PPFNGGCBJKC_Id == PPFNGGCBJKC;
			});
			if(bingo == null)
			{
				bingo = AHEFHIMGIBI.PEGNNEFHDOP_Bingo.EACEMMDIPFD_GetEmptyBingo();
				if(bingo != null)
				{
					bingo.KHEKNNFCAOI(PPFNGGCBJKC);
				}
			}
			return bingo;
		}
		return null;
	}

	// // RVA: 0xABBA8C Offset: 0xABBA8C VA: 0xABBA8C
	public bool BHFGBNNEMLI(int APFDNBGMMMM)
	{
		if(MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM).AHCFGOGCJKI_St.PPFNGGCBJKC_Id == 0)
		{
			MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM).AHCFGOGCJKI_St.KHEKNNFCAOI(1);
		}
		return true;
	}

	// // RVA: 0xABBB00 Offset: 0xABBB00 VA: 0xABBB00
	// public int CGOIJPBINCF(int APFDNBGMMMM, bool BAFFAONJPCE) { }

	// // RVA: 0xABBC58 Offset: 0xABBC58 VA: 0xABBC58
	// public int JBEDFJHAAFP(int APFDNBGMMMM, bool BAFFAONJPCE) { }

	// // RVA: 0xABBDB0 Offset: 0xABBDB0 VA: 0xABBDB0
	public int NIGPFNIIDII(int APFDNBGMMMM)
	{
		if (APFDNBGMMMM < 1 || FJLIDJJAGOM_GetBingoDb() == null)
			return - 1;
		return FJLIDJJAGOM_GetBingoDb().JJAICEAEGKF[APFDNBGMMMM - 1].PLALNIIBLOF_Enabled == 2 ? APFDNBGMMMM - 1 : -1;
	}

	// // RVA: 0xABBE78 Offset: 0xABBE78 VA: 0xABBE78
	// public JKICPBIIHNE.MKOCCBABHAH LAIDKMDLOPA(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABBFE8 Offset: 0xABBFE8 VA: 0xABBFE8
	// public int DAIDHMMOGEI(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC00C Offset: 0xABC00C VA: 0xABC00C
	// public int KBIIEPNCLAD(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC030 Offset: 0xABC030 VA: 0xABC030
	// public List<JKICPBIIHNE.IEGCPLCLOHF> LABNDEFMAHI(int APFDNBGMMMM, int AMCCOGJACPK) { }

	// // RVA: 0xABC254 Offset: 0xABC254 VA: 0xABC254
	// public bool OIEBCNPOMIB(int APFDNBGMMMM, int AMCCOGJACPK, int EIHOBHDKCDB) { }

	// // RVA: 0xABC3B8 Offset: 0xABC3B8 VA: 0xABC3B8
	// public bool JJMANIALKBF(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC480 Offset: 0xABC480 VA: 0xABC480
	// public bool JIKFDBMMAIE(int APFDNBGMMMM) { }

	// // RVA: 0xABC520 Offset: 0xABC520 VA: 0xABC520
	// public List<int> ICNOKENCCJK(int APFDNBGMMMM, bool CADENLBDAEB, bool GNKMHCKFADN) { }

	// // RVA: 0xABC6F0 Offset: 0xABC6F0 VA: 0xABC6F0
	// public List<int> OAHPJJCHIPF(int APFDNBGMMMM) { }

	// // RVA: 0xABC83C Offset: 0xABC83C VA: 0xABC83C
	// public List<int> NCCCEBGHCOL(int APFDNBGMMMM) { }

	// // RVA: 0xABC978 Offset: 0xABC978 VA: 0xABC978
	// public List<int> BPGMPJHPKND(int APFDNBGMMMM) { }

	// // RVA: 0xABCB0C Offset: 0xABCB0C VA: 0xABCB0C
	// public List<int> PFDGKPCCGMG(int APFDNBGMMMM, bool CADENLBDAEB, bool JFPPDKHEEHN) { }

	// // RVA: 0xABCDE0 Offset: 0xABCDE0 VA: 0xABCDE0
	// public void DKKLLHMHBEA(int APFDNBGMMMM, List<int> GJKPJMGPCEJ, long JHNMKKNEENE) { }

	// // RVA: 0xABCEF8 Offset: 0xABCEF8 VA: 0xABCEF8
	// public List<int> OJPMBMOAFHM(int APFDNBGMMMM) { }

	// // RVA: 0xABD0A0 Offset: 0xABD0A0 VA: 0xABD0A0
	public List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> AOIADBHHJAJ_GetValidBingoCells(int APFDNBGMMMM, int AMCCOGJACPK, int CPKMLLNADLJ, int AHHJLDLAPAN)
	{
		List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> res = new List<JKICPBIIHNE_Bingo.IEGCPLCLOHF>();
		JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = EBEDAPJFHCE_GetBingo(APFDNBGMMMM);
		res.Clear();
		for(int i = 0; i < 9; i++)
		{
			res.Add(new JKICPBIIHNE_Bingo.IEGCPLCLOHF());
		}
		for(int i = 0; i < bingo.DPGMFEGFCJN[0].MFMGDFACBON.Count; i++)
		{
			JKICPBIIHNE_Bingo.IEGCPLCLOHF data = bingo.DPGMFEGFCJN[0].MFMGDFACBON[i];
			if(data.PLALNIIBLOF_Enabled == 2)
			{
				if(data.PBEEPMLJGJC == AMCCOGJACPK)
				{
					if(data.NDFOAINJPIN < 10)
					{
						if(data.FDBOPFEOENF > 0)
						{
							if (data.FDBOPFEOENF != AHHJLDLAPAN)
								continue;
						}
						if(data.CPKMLLNADLJ_MusicSerieAttr > 0)
						{
							if (data.CPKMLLNADLJ_MusicSerieAttr != CPKMLLNADLJ)
								continue;
						}
						res[data.NDFOAINJPIN - 1].PPFNGGCBJKC = data.PPFNGGCBJKC;
						res[data.NDFOAINJPIN - 1].PBEEPMLJGJC = data.PBEEPMLJGJC;
						res[data.NDFOAINJPIN - 1].PLALNIIBLOF_Enabled = data.PLALNIIBLOF_Enabled;
						res[data.NDFOAINJPIN - 1].NDFOAINJPIN = data.NDFOAINJPIN;
						res[data.NDFOAINJPIN - 1].CPKMLLNADLJ_MusicSerieAttr = data.CPKMLLNADLJ_MusicSerieAttr;
						res[data.NDFOAINJPIN - 1].FDBOPFEOENF = data.FDBOPFEOENF;
						res[data.NDFOAINJPIN - 1].FEMMDNIELFC = data.FEMMDNIELFC;
						res[data.NDFOAINJPIN - 1].JEPGJJJBFLN = data.JEPGJJJBFLN;
						res[data.NDFOAINJPIN - 1].GOKJLBDJOLA_MusicDifficulty = data.GOKJLBDJOLA_MusicDifficulty;
						res[data.NDFOAINJPIN - 1].GPNPBHLLHDI = data.GPNPBHLLHDI;
						res[data.NDFOAINJPIN - 1].IMEPEOAFIIB = data.IMEPEOAFIIB;
						res[data.NDFOAINJPIN - 1].MAPNDFCJFLJ_ConditionType = data.MAPNDFCJFLJ_ConditionType;
						res[data.NDFOAINJPIN - 1].JBFLEDKDFCO_ConditionValue = data.JBFLEDKDFCO_ConditionValue;
						res[data.NDFOAINJPIN - 1].PMDLBHLNIDP = data.PMDLBHLNIDP;
						res[data.NDFOAINJPIN - 1].GLCLFMGPMAN = data.GLCLFMGPMAN;
						res[data.NDFOAINJPIN - 1].LJKMKCOAICL = data.LJKMKCOAICL;
						res[data.NDFOAINJPIN - 1].JJHPDDPKBHF = data.JJHPDDPKBHF;
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xABDC04 Offset: 0xABDC04 VA: 0xABDC04
	// public List<int> PDLKHLJFLHJ(int APFDNBGMMMM) { }

	// // RVA: 0xABDD84 Offset: 0xABDD84 VA: 0xABDD84
	// public List<int> OHDKDNGIFJC(int APFDNBGMMMM, int AMCCOGJACPK, int CPKMLLNADLJ, int AHHJLDLAPAN) { }

	// // RVA: 0xABDF74 Offset: 0xABDF74 VA: 0xABDF74
	// public int MLCGJAJCFDP(int APFDNBGMMMM, int PGGAIDEJGEC, int AMCCOGJACPK = 0) { }

	// // RVA: 0xAB9CB4 Offset: 0xAB9CB4 VA: 0xAB9CB4
	public bool KIAAOBFJCHP(long JHNMKKNEENE)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		CEHNIJPOEAF.Clear();
		for(int i = 0; i < l.Count; i++)
		{
			DFABPMMMIIB data = new DFABPMMMIIB();
			data.KHEKNNFCAOI(l[i]);
			CEHNIJPOEAF.Add(data);
		}
		return CEHNIJPOEAF.Count > 0;
	}

	// // RVA: 0xABE1E8 Offset: 0xABE1E8 VA: 0xABE1E8
	// public bool HLNJABHOBKL() { }

	// // RVA: 0xABB770 Offset: 0xABB770 VA: 0xABB770
	// public GNGMCIAIKMA.DFABPMMMIIB GLJKKGFPEPA(int APFDNBGMMMM) { }

	// // RVA: 0xABE2E0 Offset: 0xABE2E0 VA: 0xABE2E0
	public void GJENEJOANEL(int APFDNBGMMMM, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
		if(saveBingo != null)
		{
			if(saveBingo.BJOHOIAKKFM_Bst != 0)
			{
				if(INDDJNMPONH > 0 && INDDJNMPONH <= DKFJADMCNPI.NLKCMNHOBAI.GJPEANBALKF/*15*/)
				{
					switch(INDDJNMPONH)
					{
						case DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1/*1*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AGNDGJOPIDL_AddShop(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.IBGNFEOLKDP/*2*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.JLKOBAAEDAM_AddLogin(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.KENMCJCIGIB/*3*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KKHPAHICACE_AddVOpCValue(PPFNGGCBJKC, HMFFHLPNMPH);
							if(PPFNGGCBJKC > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KKHPAHICACE_AddVOpCValue(0, HMFFHLPNMPH);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.LFLMBPJJEEG/*4*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NKOPNPPGPCD_AddDOpcValue(PPFNGGCBJKC + -1, HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.BCMLFJPLKAM/*5*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.APEIECMCGGH_AddDOoCValue(PPFNGGCBJKC, HMFFHLPNMPH);
							if (PPFNGGCBJKC > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.APEIECMCGGH_AddDOoCValue(0, HMFFHLPNMPH);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.EGFEFGJLKLA/*6*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PDHLABPHFNB_AddDopuValue(PPFNGGCBJKC, HMFFHLPNMPH);
							if (PPFNGGCBJKC > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PDHLABPHFNB_AddDopuValue(0, HMFFHLPNMPH);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.HOOJOFACOEK/*7*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PCLBKGHNJPN_AddChgcValue(PPFNGGCBJKC, HMFFHLPNMPH);
							if (PPFNGGCBJKC > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PCLBKGHNJPN_AddChgcValue(0, HMFFHLPNMPH);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.DAOKJMHHKGP/*8*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CCIDPHJEONL_AddGiftValue(PPFNGGCBJKC, HMFFHLPNMPH);
							if (PPFNGGCBJKC > 0)
							{
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CCIDPHJEONL_AddGiftValue(0, HMFFHLPNMPH);
							}
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.NGDJIJOIPIB/*9*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CNEMNJOLIBE_AddScene(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.EHEDFAMGLDP_10/*10*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJDEINMOHOP_AddMedal(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.KJAFDMGNBPO/*11*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.OAEMBFCMCHL_DailyMission(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.CLJHDIKFECG/*12*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HFOCJMOOMBB_EventMission(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/:
							GJENEJOANEL(saveBingo, DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/, PPFNGGCBJKC, HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.DOEHLCLBCNN_14/*14*/:
							saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BFAJMALBALG_Gacha(HMFFHLPNMPH);
							return;
						case DKFJADMCNPI.NLKCMNHOBAI.GJPEANBALKF/*15*/:
							if(OMNOFMEBLAD != null && !OMNOFMEBLAD.OBOPMHBPCFE_MvMode && OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0)
								saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PJPHOMJFDEH_EventPlay(HMFFHLPNMPH);
							return;
					}
				}
			}
		}
	}

	// // RVA: 0xABE998 Offset: 0xABE998 VA: 0xABE998
	public void GJENEJOANEL(BBHNACPENDM_ServerSaveData AHEFHIMGIBI, int APFDNBGMMMM, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(AHEFHIMGIBI, APFDNBGMMMM);
		if(bingo != null)
		{
			if(bingo.BJOHOIAKKFM_Bst != 0)
			{
				if(INDDJNMPONH != DKFJADMCNPI.NLKCMNHOBAI.NGDJIJOIPIB/*9*/)
					return;
				bingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CNEMNJOLIBE_AddScene(HMFFHLPNMPH);
			}
		}
	}

	// // RVA: 0xABE6F4 Offset: 0xABE6F4 VA: 0xABE6F4
	private void GJENEJOANEL(NFMHCLHEMHB_Bingo.CCGKCGJKADC NHLBKJCPLBL, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(NHLBKJCPLBL.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv);
			List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ_GetValidBingoCells(NHLBKJCPLBL.PPFNGGCBJKC_Id, NHLBKJCPLBL.AHCFGOGCJKI_St.PPFNGGCBJKC_Id, divaInfo != null ? divaInfo.AIHCEGFANAM_Attr : 0, NHLBKJCPLBL.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv);
			for(int i = 0; i < l.Count; i++)
			{
				if(INDDJNMPONH == DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13/*13*/)
				{
					if(l[i].MAPNDFCJFLJ_ConditionType == 87)
					{
						if(PPFNGGCBJKC != l[i].JBFLEDKDFCO_ConditionValue)
						{
							if (l[i].JBFLEDKDFCO_ConditionValue != 0)
								continue;
						}
						NHLBKJCPLBL.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MPOEJLFDAGJ_AddMedalShopValue(i, HMFFHLPNMPH);
					}
				}
			}
		}
	}

	// // RVA: 0xABEA14 Offset: 0xABEA14 VA: 0xABEA14
	public void GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int OIPCCBHIKIA, int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		for(int i = 0; i < l.Count; i++)
		{
			GJENEJOANEL(l[i], INDDJNMPONH, OIPCCBHIKIA, HMFFHLPNMPH, OMNOFMEBLAD);
		}
	}

	// // RVA: 0xABEB0C Offset: 0xABEB0C VA: 0xABEB0C
	public void GJENEJOANEL(BBHNACPENDM_ServerSaveData AHEFHIMGIBI, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int OIPCCBHIKIA, int HMFFHLPNMPH)
	{
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		for(int i = 0; i < l.Count; i++)
		{
			GJENEJOANEL(AHEFHIMGIBI, l[i], INDDJNMPONH, OIPCCBHIKIA, HMFFHLPNMPH);
		}
	}

	// // RVA: 0xABEBF4 Offset: 0xABEBF4 VA: 0xABEBF4
	public int GOIAHBFBKPF(int APFDNBGMMMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF KOGBMDOONFA, OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, int HMFFHLPNMPH)
	{
		int CHOFDPDFPDC = KOGBMDOONFA.JBFLEDKDFCO_ConditionValue;
		int type = KOGBMDOONFA.MAPNDFCJFLJ_ConditionType;
		int a = KOGBMDOONFA.NDFOAINJPIN;
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
		if(type < 18)
		{
			if(type < 15)
			{
				if(type == 7)
				{
					for(int i = 0; i < LKMHPJKIFDN.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
					{
						LAEGMENIEDB_Story.ALGOILKGAAH dbData = LKMHPJKIFDN.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
						if (dbData.KLCIIHKFPPO == CHOFDPDFPDC)
						{
							return LDEGEHAEALK.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbData.LFLLLOPAKCO - 1].HALOKFOJMLA ? 1 : 0;
						}
					}
					return 0;
				}
				if(type == 14)
				{
					return LDEGEHAEALK.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				}
			}
			else
			{
				if(type == 15)
				{
					if(CHOFDPDFPDC > 0)
					{
						if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count < CHOFDPDFPDC)
							return 0;
						return LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[CHOFDPDFPDC - 1].HEBKEJBDCBH_DivaLevel;
					}
					if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count > 0)
					{
						int res = 0;
						for (int i = 0; i < LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
						{
							if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have != 0 &&
								LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_DivaLevel > res)
								res = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_DivaLevel;
						}
						return res;
					}
					return 0;
				}
				if(type == 17)
				{
					return LDEGEHAEALK.PNLOINMCCKH_Scene.MPFLFKBNFEI_GetNumSceneAtLevelOrMore(LKMHPJKIFDN.HNMMJINNHII_Game, LKMHPJKIFDN.ECNHDEHADGL_Scene, CHOFDPDFPDC);
				}
			}
			return HMFFHLPNMPH + 1;
		}
		if(type < 34)
		{
			if(type == 23)
			{
				if (OMNOFMEBLAD == null)
					return HMFFHLPNMPH;
				if (OMNOFMEBLAD.KNIFCANOHOC_Score > HMFFHLPNMPH)
					return OMNOFMEBLAD.KNIFCANOHOC_Score;
				return HMFFHLPNMPH;
			}
			if(type == 31)
			{
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BOLCACJFJGG_Shop;
			}
			if(type == 33)
			{
				int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
				if (cnt < 1)
					return 0;
				int res = 0;
				for(int i = 0; i < cnt; i++)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
					if(dbScene.PPEGAKEIEGM_En == 2)
					{
						res += LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i].DMNIMMGGJJJ_Leaf;
					}
				}
				return res;
			}
			return HMFFHLPNMPH + 1;
		}
		switch(type)
		{
			case 54:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(CHOFDPDFPDC);
			case 55:
				if(CHOFDPDFPDC > 0)
				{
					if (CHOFDPDFPDC > 10)
						return 0;
					return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJNFMAAKCMH_GetDOpCValue(CHOFDPDFPDC - 1);
				}
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(CHOFDPDFPDC);
			case 59:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.ODJEADMLGFB_Lgin;
			case 61:
				if(CHOFDPDFPDC < 1)
				{
					int res = 0;
					for(int i = 0; i < 10; i++)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = LDEGEHAEALK.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1);
						if (divaInfo.CPGFPEDMDEH_Have == 1 && divaInfo.KCCONFODCPN_IntimacyLevel > res)
							res = divaInfo.KCCONFODCPN_IntimacyLevel;
					}
					return res;
				}
				else
				{
					if(CHOFDPDFPDC < 11)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = LDEGEHAEALK.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(CHOFDPDFPDC);
						if (divaInfo.CPGFPEDMDEH_Have == 1)
							return divaInfo.KCCONFODCPN_IntimacyLevel;
					}
				}
				return 0;
			case 62:
				{
					int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
					int cnt2 = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
					if (cnt2 < cnt)
					{
						cnt = cnt2;
					}
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
							if (dbScene.PPEGAKEIEGM_En == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG scene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
								res += dbScene.AGOEDLNOHND(LKMHPJKIFDN.JEMMMJEJLNL_Board, scene.EMOJHJGHJLN_Sb, scene.JPIPENJGGDD_Mlt, LKMHPJKIFDN.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed));
							}
						}
						return res;
					}
					return 0;
				}
			case 65:
				if(CHOFDPDFPDC < 1)
				{
					int b = LDEGEHAEALK.BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(LKMHPJKIFDN.MFPNGNMFEAL_Costume, LDEGEHAEALK.DGCJCAHIAPP_Diva, true);
					List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> l = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.FindAll((DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo JPAEDJJFFOI) =>
					{
						//0x1E52FE4
						return JPAEDJJFFOI.CPGFPEDMDEH_Have == 1;
					});
					int c = 0;
					if(b > 0)
					{
						c = LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(2).CGKAEMGLHNK_Possessed() ? 1 : 0;
					}
					return (b - c) - l.Count;
				}
				else
				{
					int res = 0;
					List<LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo> l = LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.FindAll((LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo JPAEDJJFFOI) =>
					{
						//0x1E53018
						if(JPAEDJJFFOI.PPEGAKEIEGM_Enabled == 2)
						{
							return CHOFDPDFPDC == JPAEDJJFFOI.AHHJLDLAPAN_PrismDivaId;
						}
						return false;
					});
					for(int i = 0; i < l.Count; i++)
					{
						LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = l[i];
						if(c.JPIDIENBGKH_CostumeId != 2)
						{
							if(c.DAJGPBLEEOB_PrismCostumeModelId != 1)
							{
								res += LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(c.JPIDIENBGKH_CostumeId).CGKAEMGLHNK_Possessed() ? 1 : 0;
							}
						}
					}
					return res;
				}
			case 66:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KGFLHCHAIGO_GetChgcValue(CHOFDPDFPDC);
			case 67:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKKOANOJHLB_GetGiftValue(CHOFDPDFPDC);
			case 68:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MLBJKMLMLEG_GetDOocValue(CHOFDPDFPDC);
			case 69:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FGGFDPFMKAF_GetDopuValue(CHOFDPDFPDC);
			case 70:
				if(CHOFDPDFPDC < 1)
				{
					int res = 0;
					for (int i = 0; i < LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List.Count; i++)
					{
						if(LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].CGKAEMGLHNK_Possessed())
						{
							if(res < LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].ANAJIAENLNB_Level)
							{
								res = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].ANAJIAENLNB_Level;
							}
						}
					}
					return res;
				}
				else
				{
					int res = 0;
					if (CHOFDPDFPDC < 11)
					{
						for(int i = 0; i < LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
						{
							if(LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i].AHHJLDLAPAN_PrismDivaId == CHOFDPDFPDC)
							{
								EBFLJMOCLNA_Costume.ILFJDCICIKN cos = LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i].JPIDIENBGKH_CostumeId);
								if (cos.CGKAEMGLHNK_Possessed())
								{
									if(res < cos.ANAJIAENLNB_Level)
									{
										res = cos.ANAJIAENLNB_Level;
									}
								}
							}
						}
					}
					return res;
				}
			case 71:
				{
					int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
					int cnt2 = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
					if (cnt2 < cnt)
						cnt = cnt2;
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
							if (dbScene.PPEGAKEIEGM_En == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
								if (saveScene.JPIPENJGGDD_Mlt > 1)
								{
									res += (saveScene.JPIPENJGGDD_Mlt - 1);
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
				return LDEGEHAEALK.PNLOINMCCKH_Scene.NEAGFIEMLIL_GetSceneLevel(LKMHPJKIFDN.HNMMJINNHII_Game, LKMHPJKIFDN.ECNHDEHADGL_Scene, CHOFDPDFPDC);
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
				return HMFFHLPNMPH + 1;
		}
	}

	// // RVA: 0xAC0900 Offset: 0xAC0900 VA: 0xAC0900
	public bool FGHOILFCCKC(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF KOGBMDOONFA, OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, long JHNMKKNEENE)
	{
		int val = KOGBMDOONFA.JBFLEDKDFCO_ConditionValue;
		//KOGBMDOONFA.FDBOPFEOENF
		KEODKEGFDLD_FreeMusicInfo fminfo = null;
		EONOEHOKBEB_Music minfo = null;
		if(OMNOFMEBLAD != null)
		{
			fminfo = LKMHPJKIFDN.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			minfo = LKMHPJKIFDN.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
			if(OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
			{
				if (KOGBMDOONFA.MAPNDFCJFLJ_ConditionType == 0)
					return true;
				return KOGBMDOONFA.MAPNDFCJFLJ_ConditionType == 29;
			}
		}
		int a = KOGBMDOONFA.MAPNDFCJFLJ_ConditionType;
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
					if (KOGBMDOONFA.CPKMLLNADLJ_MusicSerieAttr == 0)
					{
						if (val != 0)
						{
							return minfo.AIHCEGFANAM_SerieAttr == val - 1;
						}
					}
					return KOGBMDOONFA.CPKMLLNADLJ_MusicSerieAttr == minfo.AIHCEGFANAM_SerieAttr;
				case 10:
					if (OMNOFMEBLAD != null)
					{
						return KOGBMDOONFA.GOKJLBDJOLA_MusicDifficulty == OMNOFMEBLAD.AKNELONELJK_Difficulty;
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
						return fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score) == 4;
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
						return OMNOFMEBLAD.HGEKDNNJAAC_HadAwakenDivaMode;
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
	public bool HEFIKPAHCIA_IsBingoValid(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE_Time = -1)
    {
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		if(JHNMKKNEENE_Time < 0)
		{
			JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		bool res = false;
		for(int i = 0; i < l.Count; i++)
		{
			res |= HEFIKPAHCIA_IsBingoValid(l[i], OMNOFMEBLAD, JHNMKKNEENE_Time);
		}
		return res;
    }

	// // RVA: 0xAC1228 Offset: 0xAC1228 VA: 0xAC1228
	public bool HEFIKPAHCIA_IsBingoValid(int APFDNBGMMMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE = -1)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
            NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
            if (bingo.BJOHOIAKKFM_Bst != 0)
			{
				int id = bingo.AHCFGOGCJKI_St.PPFNGGCBJKC_Id;
				int scoreRank = 0;
				EONOEHOKBEB_Music minfo = null;
				int rankCombo = 0;
				if(OMNOFMEBLAD != null)
				{
					KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
					minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
					ADDHLABEFKH a = fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty);
					scoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
					rankCombo = a.CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_MaxCombo);
				}
				int diva = bingo.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv;
                BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(diva);
				int attr = 0;
				if(divaInfo != null)
				{
					attr = divaInfo.AIHCEGFANAM_Attr;
				}
				JKICPBIIHNE_Bingo.HNOGDJFJGPM dbBinfo = EBEDAPJFHCE_GetBingo(APFDNBGMMMM);
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ_GetValidBingoCells(APFDNBGMMMM, bingo.BJOHOIAKKFM_Bst, attr, diva);
				if(JHNMKKNEENE < 0)
				{
					JHNMKKNEENE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
						if(l[i].CPKMLLNADLJ_MusicSerieAttr < 1 || (l[i].CPKMLLNADLJ_MusicSerieAttr == minfo.AIHCEGFANAM_SerieAttr))
						{
							//LAB_00ac1720
							if(l[i].GOKJLBDJOLA_MusicDifficulty > 0)
							{
								if(OMNOFMEBLAD.AKNELONELJK_Difficulty < (l[i].GOKJLBDJOLA_MusicDifficulty - 1))
									continue;
							}
							if(l[i].GPNPBHLLHDI <= scoreRank)
							{
								if(l[i].IMEPEOAFIIB <= rankCombo)
									b = true;
							}
						}
					}
					if(b)
					{
						//LAB_00ac17c0
						if(l[i].FDBOPFEOENF > 0 && l[i].FDBOPFEOENF != diva)
						{
							continue;
						}
						TodoLogger.LogError(TodoLogger.ToCheck,"Last value ?");
						if(FGHOILFCCKC(OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, 0))
						{
							int a = GOIAHBFBKPF(APFDNBGMMMM, OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].HMFFHLPNMPH_Cnt);
							if(l[i].PMDLBHLNIDP <= a)
							{
								if(bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].CMCKNKKCNDK_Stat < 2)
								{
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].CMCKNKKCNDK_Stat = 2;
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].OPGPHAEMIDO_Dt = JHNMKKNEENE;
								}
								a = l[i].PMDLBHLNIDP;
							}
							bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].HMFFHLPNMPH_Cnt = a;
						}
					}
				}
				return true;
            }
		}
		return false;
	}

	// // RVA: 0xAC1BB8 Offset: 0xAC1BB8 VA: 0xAC1BB8
	public void FBHHEBDDIMO(int APFDNBGMMMM, bool NLNNKIKIPBJ)
	{
		MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM).BJOHOIAKKFM_Bst = NLNNKIKIPBJ ? 1 : 0;
	}

	// // RVA: 0xAC1BF0 Offset: 0xAC1BF0 VA: 0xAC1BF0
	// public List<JJPEIELNEJB.JLHHGLANHGE> HNBJHJENFGL(JJPEIELNEJB.OMMBBPKFLNH KOGBMDOONFA, List<int> FFLGNFIAFFE) { }

	// // RVA: 0xAC21E4 Offset: 0xAC21E4 VA: 0xAC21E4
	// public void CPIICACGNBH(JKNGJFOBADP JANMJPOKLFL, BBHNACPENDM LDEGEHAEALK, int KIJAPOFAGPN, int HMFFHLPNMPH, int APFDNBGMMMM) { }

	// // RVA: 0xAC234C Offset: 0xAC234C VA: 0xAC234C
	// public bool NJJLNPOCKFO(int APFDNBGMMMM) { }

	// // RVA: 0xAC257C Offset: 0xAC257C VA: 0xAC257C
	public int OBOGIOGEBPK(int APFDNBGMMMM, FKMOKDCJFEN.ADCPCCNCOMD_Status CMCKNKKCNDK)
	{
		NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
		int res = 0;
		for(int i = 0; i < bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms.Count; i++)
		{
			if (bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[i].CMCKNKKCNDK_Stat == (int)CMCKNKKCNDK)
				res++;
		}
		return res;
	}

	// // RVA: 0xAC26A8 Offset: 0xAC26A8 VA: 0xAC26A8
	// public int OBOGIOGEBPK(FKMOKDCJFEN.ADCPCCNCOMD CMCKNKKCNDK) { }

	// // RVA: 0xAC2790 Offset: 0xAC2790 VA: 0xAC2790
	// public void MNMCNPLIEFM(int APFDNBGMMMM, bool NLNNKIKIPBJ) { }

	// // RVA: 0xAC27DC Offset: 0xAC27DC VA: 0xAC27DC
	public bool DOEGBMNNFKH(int APFDNBGMMMM)
	{
		return MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM).AHCFGOGCJKI_St.JBMGFNHBECN_Sst != 0;
	}

	// // RVA: 0xAC2828 Offset: 0xAC2828 VA: 0xAC2828
	// public bool EAJLHMIMAPE(int APFDNBGMMMM) { }
}
