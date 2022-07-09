using System;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeSys;

public class LCLCCHLDNHJ { }
public class LCLCCHLDNHJ_Costume : DIHHCBACKGG
{

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

        public int JPIDIENBGKH_PrismDivaID { get; set; } // 0x8 CPCGNLOMIJL PHLLMIGCPCB BLBNMENMCIF
        public short AHHJLDLAPAN_PrismCostumeId { get; set; } // 0xC AMALMGIALDF IPKDLMIDMHH IENNENMKEFO
        public short DAJGPBLEEOB_PrismCostumeModelId { get; set; } // 0xE ABHFCJKBJKD LHPKEPPBKPF OIOEEEDODJA
		public int PPEGAKEIEGM { get { return FBGGEFFJJHB ^ OIFAFKDMEEJ; } set { OIFAFKDMEEJ = FBGGEFFJJHB ^ value; } } //KPOEEPIMMJP 0xD9D5B8 NCIEAFEDPBH 0xD9CCEC
		public int HGHFFJKGNCO { get; set; } // 0x14 EJPLGMFLNMN JNGLBKKJFLF DHHJKJFHILD
        public bool EODICFLJAKO { get; set; } // 0x18 LLGHLILPKEE FDPHJPGGGMN KHDBHGJILNO
        public int AGBPBDODKBK { get; set; } // 0x1C JAGMGICOACE MCPPGDMHLDF HDJEMHFEAIF
        public int HMCOGDICFNB { get; set; } // 0x20 JGFCPGCGANG IIIBNFKOKFK KBGHKPPMEPD
		public int LLLCMHENKKN { get { return FBGGEFFJJHB ^ GNOPCJKEIIN; } set { GNOPCJKEIIN = FBGGEFFJJHB ^ value; } } //NEBKEFLJPDI 0xD9DDD4 AOCHKIMBJPE 0xD9CE34
		public int HGBJODBCJDA { get; set; } // 0x28 BIOFHCKLKMD EEEJDDFGNGP IBPCBFIDHPH
        public int EGLDFPILJLG { get; set; } // 0x30 DBDGBOGOJOJ // JACADMEJOAH 0xD9DE74 MMDBFGAFINM 0xD9CED8
        public bool GLEEPAFMPLO { get { 
            if(MEDNOBOLCEL == 0)
                ILBDHNHFJHL();
            return MEDNOBOLCEL == 2;
         } } // PFAFGGBOFBG 0xD9DE7C
        // public bool IPJMPBANBPP { get; } // IJMCHOOIMBB 0xD9E064
        public int IIELLEPEEFH { get { return FBGGEFFJJHB ^ GEJGMGDAKAM; } set { GEJGMGDAKAM = FBGGEFFJJHB ^ value; } } // NCOENDMPNPL 0xD9D88C ADBAAPIBKKL 0xD9CD88

        // // RVA: 0xD9D284 Offset: 0xD9D284 VA: 0xD9D284
        // public uint CAOGDCBPBAN() { }

        // // RVA: 0xD9E10C Offset: 0xD9E10C VA: 0xD9E10C
        // private void JEJCHECAEBD(int ANAJIAENLNB, Action<int, LCLCCHLDNHJ.ILODJKFJJDO.FBKPFMKPMAF> ADKIDBJCAJA) { }

        // // RVA: 0xD9E1E0 Offset: 0xD9E1E0 VA: 0xD9E1E0
        // public int DOGKAEAHIMI(int ANAJIAENLNB) { }

        // // RVA: 0xD9E2D8 Offset: 0xD9E2D8 VA: 0xD9E2D8
        // public short[] KKLPLPGBOFD(int ANAJIAENLNB) { }

        // // RVA: 0xD9E428 Offset: 0xD9E428 VA: 0xD9E428
        // public int LLJPMOIPBAG(int ANAJIAENLNB) { }

        // // RVA: 0xD9E4C4 Offset: 0xD9E4C4 VA: 0xD9E4C4
        // public int MHIKGGMOPOJ(int HEHKNMCDBJJ) { }

        // // RVA: 0xD9D6EC Offset: 0xD9D6EC VA: 0xD9D6EC
        // public short[] CHDBGFLFPNC() { }

        // // RVA: 0xD9E5E0 Offset: 0xD9E5E0 VA: 0xD9E5E0
        // public void NNIKNCGNDHK(int ANAJIAENLNB, StatusData CMCKNKKCNDK) { }

        // // RVA: 0xD9E6C4 Offset: 0xD9E6C4 VA: 0xD9E6C4
        // public void LEFFFKJFCFH(int ANAJIAENLNB, int[,] LAEAKOHKNHO) { }

        // // RVA: 0xD9DEB0 Offset: 0xD9DEB0 VA: 0xD9DEB0
        private void ILBDHNHFJHL()
        {
			FAEDHJHCEFJ.SetFormat("dv/cs/{0:D3}_{1:D3}_00.xab", AHHJLDLAPAN_PrismCostumeId, DAJGPBLEEOB_PrismCostumeModelId);
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
	public ILODJKFJJDO LBDOLHGDIEB(int AHHJLDLAPAN, int JPIDIENBGKH)
	{
		ILODJKFJJDO found = null;
		if(JPIDIENBGKH > 0)
		{
			found = CDENCMNHNGA.Find((ILODJKFJJDO PKLPKMLGFGK) => {
				//0xD9DC10
				if(PKLPKMLGFGK.PPEGAKEIEGM != 2)
					return false;
				return JPIDIENBGKH == PKLPKMLGFGK.JPIDIENBGKH_PrismDivaID;
			});
			if(found.AHHJLDLAPAN_PrismCostumeId == AHHJLDLAPAN)
				return found;
		}
		found = CDENCMNHNGA.Find((ILODJKFJJDO PKLPKMLGFGK) => {
			//0xD9DC70
			if(AHHJLDLAPAN != PKLPKMLGFGK.AHHJLDLAPAN_PrismCostumeId)
				return false;
			return PKLPKMLGFGK.DAJGPBLEEOB_PrismCostumeModelId != 1 ? false: true;
		});
		return found;
	}

	// // RVA: 0xD9B104 Offset: 0xD9B104 VA: 0xD9B104
	public ILODJKFJJDO NLIBHNJNJAN(int AHHJLDLAPAN, int DAJGPBLEEOB)
    {
        UnityEngine.Debug.LogError("TODO");
        return null;
    }

	// // RVA: 0xD9B29C Offset: 0xD9B29C VA: 0xD9B29C
	// public LCLCCHLDNHJ.ILODJKFJJDO MGENBBDAONJ(int AHHJLDLAPAN) { }

	// // RVA: 0xD9B39C Offset: 0xD9B39C VA: 0xD9B39C
	public LCLCCHLDNHJ_Costume()
    {
        JIKKNHIAEKG = "";
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
            data.JPIDIENBGKH_PrismDivaID = i;
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
				data.JPIDIENBGKH_PrismDivaID = (int)array[i].PPFNGGCBJKC;
				data.AHHJLDLAPAN_PrismCostumeId = (short)array[i].OCAMDLMPBGA;
				data.DAJGPBLEEOB_PrismCostumeModelId = (short)array[i].LKMHPJKIFDN;
				data.HGHFFJKGNCO = (int)array[i].DLAIGBEOGNN;
				data.EODICFLJAKO = array[i].DBHPPMPNCKF > 0;
				data.PPEGAKEIEGM = JKAECBCNHAN(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, array[i].DBHPPMPNCKF);
				data.IIELLEPEEFH = array[i].MDEBEGADHOH;
				data.AGBPBDODKBK = array[i].GMOOKMONMMD;
				data.HMCOGDICFNB = array[i].DOJAMIPOKBD;
				data.LLLCMHENKKN = array[i].GOFFPLJKIIB;
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
				if(JKAECBCNHAN(array[i].JILNNPKFKEK, 2, 0) < 2)
				{
					data.LLLCMHENKKN = 0;
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
		UnityEngine.Debug.LogError("TODO CAOGDCBPBAN");
		return 0;
	}

	// // RVA: 0xD9D4A0 Offset: 0xD9D4A0 VA: 0xD9D4A0
	public bool OEMKAFGPOCE(int JPIDIENBGKH, int AHHJLDLAPAN)
    {
		UnityEngine.Debug.LogError("TODO CAOGDCBPBAN");
		return false;
    }

	// // RVA: 0xD9D658 Offset: 0xD9D658 VA: 0xD9D658
	// public bool KPHOIIKOEOG(int PPKEBOEJAKH, int JPIDIENBGKH, int AHHJLDLAPAN) { }

	// // RVA: 0xD9D70C Offset: 0xD9D70C VA: 0xD9D70C
	// public bool JAHFLLONDCN(int JPIDIENBGKH, int HEHKNMCDBJJ = 0) { }

	// // RVA: 0xD9D924 Offset: 0xD9D924 VA: 0xD9D924
	// public int FLFLMHDEBOL(int JPIDIENBGKH) { }

	// // RVA: 0xD9DA24 Offset: 0xD9DA24 VA: 0xD9DA24
	// public bool OOOPJNKBDIL(int NDFMGKNELHO, int KBCFCCBDDBI) { }
}
