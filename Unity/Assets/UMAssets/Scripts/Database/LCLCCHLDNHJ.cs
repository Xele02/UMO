using System;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use LCLCCHLDNHJ_Costume", true)]
public class LCLCCHLDNHJ { }
public class LCLCCHLDNHJ_Costume : DIHHCBACKGG_DbSection
{
	[WikiPage(title : "Database/Diva/Diva_{DivaId:D3}/Costume_{ID:D3}", filename : "costume/cs_{ID:D3}", templateName : "Database/Costume/CostumeInfo")]
    public class ILODJKFJJDO
    {
		public class FBKPFMKPMAF
		{
			public int INDDJNMPONH; // 0x8
			public int[] PIBLLGLCJEO; // 0xC
			public int KBOLNIBLIND; // 0x10

			//public bool NECHJGGOPFH { get; }

			//// RVA: 0xD9E084 Offset: 0xD9E084 VA: 0xD9E084
			//public uint CAOGDCBPBAN() { }

			//// RVA: 0xD9ECBC Offset: 0xD9ECBC VA: 0xD9ECBC
			//public bool LMNEDALDGNC() { }

			//// RVA: 0xD9ECD4 Offset: 0xD9ECD4 VA: 0xD9ECD4
			//public int LDHIAOGPINB() { }
		}

		private static int FBGGEFFJJHB = 0x146c5; // 0x0
        private int OIFAFKDMEEJ; // 0x10
        private int GNOPCJKEIIN; // 0x24

		public ILODJKFJJDO.FBKPFMKPMAF[] BJGNGNPHCBA; // 0x2C

		private byte MEDNOBOLCEL; // 0x34
        private static StringBuilder FAEDHJHCEFJ = new StringBuilder(); // 0x4
        private int GEJGMGDAKAM; // 0x38

		[WikiProperty("ID")]
        public int JPIDIENBGKH_CostumeId { get; set; } // 0x8 CPCGNLOMIJL PHLLMIGCPCB BLBNMENMCIF
		[WikiProperty("DivaId")]
        public short AHHJLDLAPAN_PrismDivaId { get; set; } // 0xC AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
		[WikiProperty("PrismCostumeId")]
        public short DAJGPBLEEOB_PrismCostumeModelId { get; set; } // 0xE ABHFCJKBJKD LHPKEPPBKPF OIOEEEDODJA
		[WikiProperty("Enabled", pageValidChecker: new object[] {typeof(WikiValidNotEqual), 0})]
		public int PPEGAKEIEGM { get { return FBGGEFFJJHB ^ OIFAFKDMEEJ; } set { OIFAFKDMEEJ = FBGGEFFJJHB ^ value; } } //KPOEEPIMMJP 0xD9D5B8 NCIEAFEDPBH 0xD9CCEC
		[WikiProperty("SkillId")]
		public int HGHFFJKGNCO_SkillId { get; set; } // 0x14 EJPLGMFLNMN JNGLBKKJFLF DHHJKJFHILD
		[WikiProperty("EODICFLJAKO")]
        public bool EODICFLJAKO { get; set; } // 0x18 LLGHLILPKEE FDPHJPGGGMN KHDBHGJILNO
		[WikiProperty("AGBPBDODKBK")]
        public int AGBPBDODKBK { get; set; } // 0x1C JAGMGICOACE MCPPGDMHLDF HDJEMHFEAIF
		[WikiProperty("HMCOGDICFNB")]
        public int HMCOGDICFNB { get; set; } // 0x20 JGFCPGCGANG IIIBNFKOKFK KBGHKPPMEPD
		[WikiProperty("LevelMax")]
		public int LLLCMHENKKN_LevelMax { get { return FBGGEFFJJHB ^ GNOPCJKEIIN; } set { GNOPCJKEIIN = FBGGEFFJJHB ^ value; } } //NEBKEFLJPDI 0xD9DDD4 AOCHKIMBJPE 0xD9CE34
		[WikiProperty("HGBJODBCJDA")]
		public int HGBJODBCJDA { get; set; } // 0x28 BIOFHCKLKMD EEEJDDFGNGP IBPCBFIDHPH
		[WikiProperty("EGLDFPILJLG")]
        public int EGLDFPILJLG { get; set; } // 0x30 DBDGBOGOJOJ // JACADMEJOAH 0xD9DE74 MMDBFGAFINM 0xD9CED8
		[WikiProperty("GLEEPAFMPLO")]
        public bool GLEEPAFMPLO { get { 
            if(MEDNOBOLCEL == 0)
                ILBDHNHFJHL();
            return MEDNOBOLCEL == 2;
         } } // PFAFGGBOFBG 0xD9DE7C
        // public bool IPJMPBANBPP { get; } // IJMCHOOIMBB 0xD9E064
		[WikiProperty("IIELLEPEEFH")]
        public int IIELLEPEEFH { get { return FBGGEFFJJHB ^ GEJGMGDAKAM; } set { GEJGMGDAKAM = FBGGEFFJJHB ^ value; } } // NCOENDMPNPL 0xD9D88C ADBAAPIBKKL 0xD9CD88

        // // RVA: 0xD9D284 Offset: 0xD9D284 VA: 0xD9D284
        // public uint CAOGDCBPBAN() { }

        // // RVA: 0xD9E10C Offset: 0xD9E10C VA: 0xD9E10C
        private void JEJCHECAEBD(int ANAJIAENLNB, Action<int, LCLCCHLDNHJ_Costume.ILODJKFJJDO.FBKPFMKPMAF> ADKIDBJCAJA)
		{
			if(ANAJIAENLNB > 0)
			{
				for(int i = 0; i < ANAJIAENLNB; i++)
				{
					ADKIDBJCAJA(i, BJGNGNPHCBA[i]);
				}
			}
		}

        // // RVA: 0xD9E1E0 Offset: 0xD9E1E0 VA: 0xD9E1E0
        public int DOGKAEAHIMI(int ANAJIAENLNB_Level)
		{
			int DEOBDFOPLHG = 1;
			JEJCHECAEBD(ANAJIAENLNB_Level, (int FGMJJBBDOOI, LCLCCHLDNHJ_Costume.ILODJKFJJDO.FBKPFMKPMAF GMCEJHMOJJD) => {
				//0xD9E83C
				if(GMCEJHMOJJD.INDDJNMPONH != 1)
					return;
				DEOBDFOPLHG = GMCEJHMOJJD.PIBLLGLCJEO[0];
			});
			return DEOBDFOPLHG;
		}

        // // RVA: 0xD9E2D8 Offset: 0xD9E2D8 VA: 0xD9E2D8
        public short[] KKLPLPGBOFD_GetAvaiableColor(int ANAJIAENLNB)
		{
			List<short> result = new List<short>();
			JEJCHECAEBD(ANAJIAENLNB, (int FGMJJBBDOOI, LCLCCHLDNHJ_Costume.ILODJKFJJDO.FBKPFMKPMAF GMCEJHMOJJD) =>
			{
				//0xD9E8A4
				if (GMCEJHMOJJD.INDDJNMPONH != 4)
					return;
				result.Add((short)GMCEJHMOJJD.PIBLLGLCJEO[0]);
			});
			return result.ToArray();
		}

        // // RVA: 0xD9E428 Offset: 0xD9E428 VA: 0xD9E428
        public int LLJPMOIPBAG(int ANAJIAENLNB)
		{
			if(BJGNGNPHCBA[ANAJIAENLNB].INDDJNMPONH != 4)
				return 0;
			return BJGNGNPHCBA[ANAJIAENLNB].PIBLLGLCJEO[0];
		}

        // // RVA: 0xD9E4C4 Offset: 0xD9E4C4 VA: 0xD9E4C4
        // public int MHIKGGMOPOJ(int HEHKNMCDBJJ) { }

        // // RVA: 0xD9D6EC Offset: 0xD9D6EC VA: 0xD9D6EC
        public short[] CHDBGFLFPNC_GetAllAvaiableColors()
		{
			return KKLPLPGBOFD_GetAvaiableColor(LLLCMHENKKN_LevelMax);
		}

        // // RVA: 0xD9E5E0 Offset: 0xD9E5E0 VA: 0xD9E5E0
        // public void NNIKNCGNDHK(int ANAJIAENLNB, StatusData CMCKNKKCNDK) { }

        // // RVA: 0xD9E6C4 Offset: 0xD9E6C4 VA: 0xD9E6C4
        // public void LEFFFKJFCFH(int ANAJIAENLNB, int[,] LAEAKOHKNHO) { }

        // // RVA: 0xD9DEB0 Offset: 0xD9DEB0 VA: 0xD9DEB0
        private void ILBDHNHFJHL()
        {
			FAEDHJHCEFJ.SetFormat("dv/cs/{0:D3}_{1:D3}_00.xab", AHHJLDLAPAN_PrismDivaId, DAJGPBLEEOB_PrismCostumeModelId);
			MEDNOBOLCEL = (byte)(KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH(FAEDHJHCEFJ.ToString()) ? 2 : 1);
		}
    }
	
	public class JMEHNBGDEBD
	{
		public class PGGEBICEDGH
		{
			public int INDDJNMPONH; // 0x8
			public int[] PIBLLGLCJEO; // 0xC

			//// RVA: 0xD9EDD4 Offset: 0xD9EDD4 VA: 0xD9EDD4
			//public bool OHIADCDNJPB(LCLCCHLDNHJ.JMEHNBGDEBD.PGGEBICEDGH GJLFANGDGCL) { }
		}

		public int PPFNGGCBJKC; // 0x8
		public PGGEBICEDGH[] NKNBKLHCAFD; // 0xC

		// RVA: 0xD9D39C Offset: 0xD9D39C VA: 0xD9D39C
		//public uint CAOGDCBPBAN() { }

		// RVA: 0xD9ED2C Offset: 0xD9ED2C VA: 0xD9ED2C
		//public LCLCCHLDNHJ.LKLGPLFNJBA IJPCKNNNFHI() { }
	}


	public const int DJGNIDBKLCE = 500;
	public const int KHHGMLNMHBN = 3;
	public static readonly int GFIKOEEBIJP = GameAttribute.ArrayNum - 1; // 0x0
	public string HDIDJNCGICK = ""; // 0x34

	public List<LCLCCHLDNHJ_Costume.ILODJKFJJDO> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB
	public Dictionary<int, int[]> MBLNIECELNK { get; private set; } // 0x24 GHJIJLGHBLA EHAONDMIOFL CAJNIOACOCP
	public Dictionary<int, int[]> AKKDOIJNMBH { get; private set; } // 0x28 MJPHOOLJKJE HJMAIPELMAH JJOIDPBEEOH
	public Dictionary<int, JMEHNBGDEBD> FDNBEPCEHBH { get; private set; } // 0x2C AMDEGDEHAAL HJLBICBIFAP FIOPFDLGEAE
	public int[] OLNFADCCMIG { get; private set; } // 0x30 AIHLNOAOMGE NBCHJDPDEIM CEENFNLIAPI

	// // RVA: 0xD9AE14 Offset: 0xD9AE14 VA: 0xD9AE14
	// public LCLCCHLDNHJ.ILODJKFJJDO EEOADCECNOM(int PPFNGGCBJKC_Id) { }

	// // RVA: 0xD9AF18 Offset: 0xD9AF18 VA: 0xD9AF18
	public ILODJKFJJDO LBDOLHGDIEB(int AHHJLDLAPAN_DivaId, int JPIDIENBGKH_CostumeId)
	{
		ILODJKFJJDO found = null;
		if(JPIDIENBGKH_CostumeId > 0)
		{
			found = CDENCMNHNGA.Find((ILODJKFJJDO PKLPKMLGFGK) => {
				//0xD9DC10
				if(PKLPKMLGFGK.PPEGAKEIEGM != 2)
					return false;
				return JPIDIENBGKH_CostumeId == PKLPKMLGFGK.JPIDIENBGKH_CostumeId;
			});
			if(found.AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN_DivaId)
				return found;
		}
		found = CDENCMNHNGA.Find((ILODJKFJJDO PKLPKMLGFGK) => {
			//0xD9DC70
			if(AHHJLDLAPAN_DivaId != PKLPKMLGFGK.AHHJLDLAPAN_PrismDivaId)
				return false;
			return PKLPKMLGFGK.DAJGPBLEEOB_PrismCostumeModelId != 1 ? false: true;
		});
		return found;
	}

	// // RVA: 0xD9B104 Offset: 0xD9B104 VA: 0xD9B104
	public ILODJKFJJDO NLIBHNJNJAN(int AHHJLDLAPAN_DivaId, int DAJGPBLEEOB_PrismCostumeModelId)
    {
        LCLCCHLDNHJ_Costume.ILODJKFJJDO cosInfo = CDENCMNHNGA.Find((LCLCCHLDNHJ_Costume.ILODJKFJJDO PKLPKMLGFGK) => {
			//0xD9DCBC
			if(PKLPKMLGFGK.PPEGAKEIEGM == 2)
			{
				return AHHJLDLAPAN_DivaId == PKLPKMLGFGK.AHHJLDLAPAN_PrismDivaId && DAJGPBLEEOB_PrismCostumeModelId == PKLPKMLGFGK.DAJGPBLEEOB_PrismCostumeModelId;
			}
			return false;
		});
		if(cosInfo != null)
			return cosInfo;
		cosInfo = CDENCMNHNGA.Find((LCLCCHLDNHJ_Costume.ILODJKFJJDO PKLPKMLGFGK) => {
			//0xD9DD2C
			return AHHJLDLAPAN_DivaId == PKLPKMLGFGK.AHHJLDLAPAN_PrismDivaId && PKLPKMLGFGK.DAJGPBLEEOB_PrismCostumeModelId == 1;
		});
        return cosInfo;
    }

	// // RVA: 0xD9B29C Offset: 0xD9B29C VA: 0xD9B29C
	// public LCLCCHLDNHJ.ILODJKFJJDO MGENBBDAONJ(int AHHJLDLAPAN) { }

	// // RVA: 0xD9B39C Offset: 0xD9B39C VA: 0xD9B39C
	public LCLCCHLDNHJ_Costume()
    {
        JIKKNHIAEKG_BlockName = "";
        LNIMEIMBCMF = false;
        LMHMIIKCGPE = 11;
        CDENCMNHNGA = new List<LCLCCHLDNHJ_Costume.ILODJKFJJDO>();
    }

	// // RVA: 0xD9B4A8 Offset: 0xD9B4A8 VA: 0xD9B4A8 Slot: 8
	protected override void KMBPACJNEOF()
    {
        CDENCMNHNGA.Clear();
        for(int i = 1; i < 501; i++)
        {
            LCLCCHLDNHJ_Costume.ILODJKFJJDO data = new LCLCCHLDNHJ_Costume.ILODJKFJJDO();
            data.JPIDIENBGKH_CostumeId = i;
            CDENCMNHNGA.Add(data);
        }
    }

	// // RVA: 0xD9B5B0 Offset: 0xD9B5B0 VA: 0xD9B5B0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		IBCDCBLBJKE reader = IBCDCBLBJKE.HEGEKFMJNCC(DBBGALAPFGC);
		return EEIKAAONMPO(reader);
	}

	// // RVA: 0xD9CCBC Offset: 0xD9CCBC VA: 0xD9CCBC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// // RVA: 0xD9CCC4 Offset: 0xD9CCC4 VA: 0xD9CCC4
	// private bool EEIKAAONMPO(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE) { }

	// // RVA: 0xD9B5D8 Offset: 0xD9B5D8 VA: 0xD9B5D8
	private bool EEIKAAONMPO(IBCDCBLBJKE BGMLCPNJPMD)
	{
		FGABLOBFLHC[] array = BGMLCPNJPMD.MDFBOCBCGGE;
		if(CDENCMNHNGA.Count >= array.Length)
		{
			for(int i = 0; i < array.Length; i++)
			{
				ILODJKFJJDO data = CDENCMNHNGA[i];
				data.JPIDIENBGKH_CostumeId = (int)array[i].PPFNGGCBJKC;
				data.AHHJLDLAPAN_PrismDivaId = (short)array[i].OCAMDLMPBGA;
				data.DAJGPBLEEOB_PrismCostumeModelId = (short)array[i].LKMHPJKIFDN;
				data.HGHFFJKGNCO_SkillId = (int)array[i].DLAIGBEOGNN;
				data.EODICFLJAKO = array[i].DBHPPMPNCKF > 0;
				data.PPEGAKEIEGM = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, array[i].DBHPPMPNCKF);
				data.IIELLEPEEFH = array[i].MDEBEGADHOH;
				data.AGBPBDODKBK = array[i].GMOOKMONMMD;
				data.HMCOGDICFNB = array[i].DOJAMIPOKBD;
				data.LLLCMHENKKN_LevelMax = array[i].GOFFPLJKIIB;
				data.HGBJODBCJDA = array[i].NFEJAAOAFPG;
				data.BJGNGNPHCBA = new ILODJKFJJDO.FBKPFMKPMAF[array[i].BFIFIDKOJGD.Length];
				data.EGLDFPILJLG = array[i].JBPJAGOJMFA;
				int val = array[i].AJNPNDIDJLD.Length / array[i].BFIFIDKOJGD.Length;
				for(int j = 0; j < array[i].BFIFIDKOJGD.Length; j++)
				{
					ILODJKFJJDO.FBKPFMKPMAF data2 = new ILODJKFJJDO.FBKPFMKPMAF();
					data2.INDDJNMPONH = array[i].BFIFIDKOJGD[j];
					data2.PIBLLGLCJEO = new int[val];
					for(int k = 0; k < val; k++)
					{
						data2.PIBLLGLCJEO[k] = array[i].AJNPNDIDJLD[k + val * j];
					}
					data2.KBOLNIBLIND = array[i].GMKDHMPGLFL[j];
					data.BJGNGNPHCBA[j] = data2;
				}
				if(JKAECBCNHAN_IsEnabled(array[i].JILNNPKFKEK, 2, 0) < 2)
				{
					data.LLLCMHENKKN_LevelMax = 0;
				}
			}
			ECFLPFIJGGC[] array2 = BGMLCPNJPMD.EIDOFLACDGH;
			MBLNIECELNK = new Dictionary<int, int[]>();
			for(int i = 0; i < array2.Length; i++)
			{
				int[] dataarray = new int[array2[i].KIONHNAPIOM.Length];
				for(int j = 0; j < dataarray.Length; j++)
				{
					dataarray[j] = array2[i].KIONHNAPIOM[j];
				}
				MBLNIECELNK.Add(array2[i].MJMPANIBFED, dataarray);
			}
			AKKDOIJNMBH = new Dictionary<int, int[]>();
			GPBHHNACMOP[] array3 = BGMLCPNJPMD.HJPKLNPDDHN;
			for (int i = 0; i < array3.Length; i++)
			{
				int[] intarray = new int[array3[i].GNKAPBFMIDE.Length];
				Array.Copy(array3[i].GNKAPBFMIDE, intarray, array3[i].GNKAPBFMIDE.Length);
				AKKDOIJNMBH.Add(array3[i].PGPGPJNBIOH, intarray);
			}
			OJHOANCOJIK[] array4 = BGMLCPNJPMD.MMCDFGKCEPO;
			FDNBEPCEHBH = new Dictionary<int, JMEHNBGDEBD>();
			for (int i = 0; i < array4.Length; i++)
			{
				JMEHNBGDEBD data = new JMEHNBGDEBD();
				data.PPFNGGCBJKC = array4[i].CHOIMHCMAHG;
				data.NKNBKLHCAFD = new JMEHNBGDEBD.PGGEBICEDGH[array4[i].IKKKOBGCPGN.Length];
				int val = array4[i].CHIFFONJIAD.Length / array4[i].IKKKOBGCPGN.Length;
				for(int j = 0; j < array4[i].IKKKOBGCPGN.Length; j++)
				{
					JMEHNBGDEBD.PGGEBICEDGH data2 = new JMEHNBGDEBD.PGGEBICEDGH();
					data2.INDDJNMPONH = array4[i].IKKKOBGCPGN[j];
					data2.PIBLLGLCJEO = new int[val];
					for(int k = 0; k < val; k++)
					{
						data2.PIBLLGLCJEO[k] = array4[i].CHIFFONJIAD[k + val * j];
					}
					data.NKNBKLHCAFD[j] = data2;
				}
				FDNBEPCEHBH.Add(array4[i].CHOIMHCMAHG, data);
			}
			JAELFHFCDDH[] array5 = BGMLCPNJPMD.ODKFBJEOCGB;
			OLNFADCCMIG = new int[array5.Length];
			for(int i = 0; i < array5.Length; i++)
			{
				OLNFADCCMIG[i] = array5[i].HFIFHDCJFPM;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0xD9CEF8 Offset: 0xD9CEF8 VA: 0xD9CEF8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0xD9D4A0 Offset: 0xD9D4A0 VA: 0xD9D4A0
	public bool OEMKAFGPOCE_IsCostumeAvaiable(int JPIDIENBGKH_CostumeId, int AHHJLDLAPAN_PrismDivaId)
    {
		if (JPIDIENBGKH_CostumeId > 0 && JPIDIENBGKH_CostumeId <= CDENCMNHNGA.Count)
		{
			if(CDENCMNHNGA[JPIDIENBGKH_CostumeId - 1].PPEGAKEIEGM == 2)
			{
				return CDENCMNHNGA[JPIDIENBGKH_CostumeId - 1].JPIDIENBGKH_CostumeId == JPIDIENBGKH_CostumeId && CDENCMNHNGA[JPIDIENBGKH_CostumeId - 1].AHHJLDLAPAN_PrismDivaId == AHHJLDLAPAN_PrismDivaId;
			}
		}
		return false;
    }

	// // RVA: 0xD9D658 Offset: 0xD9D658 VA: 0xD9D658
	public bool KPHOIIKOEOG_IsColorAvaiable(int PPKEBOEJAKH_ColorId, int JPIDIENBGKH_CostumeId, int AHHJLDLAPAN_DivaId)
	{
		ILODJKFJJDO cos = LBDOLHGDIEB(AHHJLDLAPAN_DivaId, JPIDIENBGKH_CostumeId);
		if(cos != null)
		{
			short[] data = cos.KKLPLPGBOFD_GetAvaiableColor(cos.LLLCMHENKKN_LevelMax);
			for(int i = 0; i < data.Length; i++)
			{
				if (data[i] == PPKEBOEJAKH_ColorId)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0xD9D70C Offset: 0xD9D70C VA: 0xD9D70C
	// public bool JAHFLLONDCN(int JPIDIENBGKH, int HEHKNMCDBJJ = 0) { }

	// // RVA: 0xD9D924 Offset: 0xD9D924 VA: 0xD9D924
	// public int FLFLMHDEBOL(int JPIDIENBGKH) { }

	// // RVA: 0xD9DA24 Offset: 0xD9DA24 VA: 0xD9DA24
	// public bool OOOPJNKBDIL(int NDFMGKNELHO, int KBCFCCBDDBI) { }
}
