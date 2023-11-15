
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LGHIPHEDCNC_Offer", true)]
public class LGHIPHEDCNC { }
public class LGHIPHEDCNC_Offer : DIHHCBACKGG_DbSection
{
	public class NONCDAINJLD
	{
		private int EHOIENNDEDH; // 0x8
		private int GNGNIKNNCNH; // 0xC
		private int HNJHPNPFAAN; // 0x10
		private int NOFECLGOLAI; // 0x14
		private int CPOJPDKIEMP; // 0x18
		private int IPAKEGGICML; // 0x1C
		private int EHLGHDIACCG; // 0x20
		private int DHAEKDLFCFK; // 0x24
		private int NIOPNCALFOE; // 0x28
		private int CDDLNKAPCFB; // 0x2C
		private int[] FGNPIJIDIID = new int[3]; // 0x30
		private int[] ABICFGIHNDO = new int[3]; // 0x34
		private int NGNGHGJDNGF; // 0x38
		private int FDJGJGALMBP; // 0x3C
		private int[] EHLBDJELKKG = new int[3]; // 0x40
		private long PCLNFCNIECH; // 0x48
		private long HHPIJHADAOB; // 0x50
		private int MLCELGHBCLK; // 0x58

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD82B94 DEMEPMAEJOO 0xD7AEB8 HIGKAIDMOKN
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xD82C2C KJIMMIBDCIL 0xD7AF54 DMEGNOKIKCD
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xD82CC4 JPCJNLHHIPE 0xD7AFF0 JJFJNEJLBDG
		public int GBJFNGCDKPM { get { return NOFECLGOLAI ^ FBGGEFFJJHB; } set { NOFECLGOLAI = value ^ FBGGEFFJJHB; } } //0xD82D5C CEJJMKODOGK 0xD7BD1C HOHCEBMMACI
		public int CECKOCLEABH { get { return CPOJPDKIEMP ^ FBGGEFFJJHB; } set { CPOJPDKIEMP = value ^ FBGGEFFJJHB; } } //0xD82DF4 PEINKKFMNND 0xD7B08C DFPMBLFKDIO
		public int CPKMLLNADLJ { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = value ^ FBGGEFFJJHB; } } //0xD82E8C BJPJMGHCDNO 0xD7B128 BPKIOJBKNBP
		public int GOKJLBDJOLA { get { return EHLGHDIACCG ^ FBGGEFFJJHB; } set { EHLGHDIACCG = value ^ FBGGEFFJJHB; } } //0xD82F24 CCEEILBGBOM 0xD7B1C4 MKNIFMGHJHC
		public int AIIOIKGMOBD { get { return DHAEKDLFCFK ^ FBGGEFFJJHB; } set { DHAEKDLFCFK = value ^ FBGGEFFJJHB; } } //0xD82FBC LCEOFHMMODO 0xD7B260 IPBGKFAEDLL
		public int FCBJFKGDINH { get { return NIOPNCALFOE ^ FBGGEFFJJHB; } set { NIOPNCALFOE = value ^ FBGGEFFJJHB; } } //0xD83054 APJOLOOEKPM 0xD7B2FC BEFLICOCMHH
		public int NONBCCLGBAO { get { return CDDLNKAPCFB ^ FBGGEFFJJHB; } set { CDDLNKAPCFB = value ^ FBGGEFFJJHB; } } //0xD830EC AEJBEGKBPCO 0xD7B398 JPIBPFANBNG
		public int BBMBLOABEOK { get { return NGNGHGJDNGF ^ FBGGEFFJJHB; } set { NGNGHGJDNGF = value ^ FBGGEFFJJHB; } } //0xD83184 OIEECAGIJBA 0xD7B434 HMGMNKCJGHC
		public int FCDMDDIHMPO { get { return FDJGJGALMBP ^ FBGGEFFJJHB; } set { FDJGJGALMBP = value ^ FBGGEFFJJHB; } } //0xD8321C PANFDHNMNKE 0xD7B4D0 DIHHLFEPLOH
		public long PDBPFJJCADD { get { return PCLNFCNIECH ^ BBEGLBMOBOF; } set { PCLNFCNIECH = value ^ BBEGLBMOBOF; } } //0xD832B4 FOACOMBHPAC 0xD7B6A4 NBACOBCOJCA
		public long FDBNFFNFOND { get { return HHPIJHADAOB ^ BBEGLBMOBOF; } set { HHPIJHADAOB = value ^ BBEGLBMOBOF; } } //0xD83350 BPJOGHJCLDJ 0xD7B748 NLJKMCHOCBK
		public int LJNAKDMILMC { get { return MLCELGHBCLK ^ FBGGEFFJJHB; } set { MLCELGHBCLK = value ^ FBGGEFFJJHB; } } //0xD833EC LIIHHICIBKM 0xD7B7EC OACJGKPBHIK

		//// RVA: 0xD83484 Offset: 0xD83484 VA: 0xD83484
		//public int GNLAKGANAPG(int IOPHIHFOOEP) { }

		//// RVA: 0xD7B888 Offset: 0xD7B888 VA: 0xD7B888
		public bool PGBPLOHNAOC(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (FGNPIJIDIID.Length <= IOPHIHFOOEP)
				return false;
			FGNPIJIDIID[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD83578 Offset: 0xD83578 VA: 0xD83578
		//public int AGMPIKBJPPB() { }

		//// RVA: 0xD835D0 Offset: 0xD835D0 VA: 0xD835D0
		//public int FALLJIODMBC(int IOPHIHFOOEP) { }

		//// RVA: 0xD7B984 Offset: 0xD7B984 VA: 0xD7B984
		public bool HHIOOFDNPFF(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (ABICFGIHNDO.Length <= IOPHIHFOOEP)
				return false;
			ABICFGIHNDO[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD836C4 Offset: 0xD836C4 VA: 0xD836C4
		//public int FFCJEOLDKGN(int IOPHIHFOOEP) { }

		//// RVA: 0xD7BA80 Offset: 0xD7BA80 VA: 0xD7BA80
		public bool LILKNMJPLLN(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (EHLBDJELKKG.Length <= IOPHIHFOOEP)
				return false;
			EHLBDJELKKG[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD7F978 Offset: 0xD7F978 VA: 0xD7F978
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7FAB4 Offset: 0xD7FAB4 VA: 0xD7FAB4
		//public uint CAOGDCBPBAN() { }
	}

	public class LHDLCLNBPLB : NONCDAINJLD
	{
		private int[] EAHEGFMLPJJ = new int[3]; // 0x5C
		private long HMDBEHOHPGN; // 0x60
		private int DIHEJBGOOHM; // 0x68
		private int OHHMNGLKHIP; // 0x6C

		public long KOOEOKEDJDO { get { return HMDBEHOHPGN ^ BBEGLBMOBOF; } set { HMDBEHOHPGN = value ^ BBEGLBMOBOF; } } //0xD81B5C BABHKIGIOPO 0xD7BC78 PCOFGPBACAM
		public int JBHBGOIMALD { get { return DIHEJBGOOHM ^ FBGGEFFJJHB; } set { DIHEJBGOOHM = value ^ FBGGEFFJJHB; } } //0xD81BF8 JMKPGPCDONN 0xD7B56C FMLIGECHCCB
		public int PPMBFJJDCPP { get { return OHHMNGLKHIP ^ FBGGEFFJJHB; } set { OHHMNGLKHIP = value ^ FBGGEFFJJHB; } } //0xD81C90 KDMMNFBHMPB 0xD7B608 DKDFCLALNGI

		//// RVA: 0xD81D28 Offset: 0xD81D28 VA: 0xD81D28
		public int DNEDEGCHFGH(int IOPHIHFOOEP)
		{
			if (EAHEGFMLPJJ.Length < IOPHIHFOOEP)
				return 0;
			return EAHEGFMLPJJ[IOPHIHFOOEP] ^ FBGGEFFJJHB;
		}

		//// RVA: 0xD7BB7C Offset: 0xD7BB7C VA: 0xD7BB7C
		public bool MKGIKKJCPBL(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (EAHEGFMLPJJ.Length <= IOPHIHFOOEP)
				return false;
			EAHEGFMLPJJ[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD81E1C Offset: 0xD81E1C VA: 0xD81E1C
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7EEBC Offset: 0xD7EEBC VA: 0xD7EEBC
		//public uint CAOGDCBPBAN() { }
	}

	public class BFEIHCJHHAJ : NONCDAINJLD
	{
		private int JMHNONPGHFF; // 0x5C

		public int HAHMHBNPGFM { get { return JMHNONPGHFF ^ FBGGEFFJJHB; } set { JMHNONPGHFF = value ^ FBGGEFFJJHB; } } //0xD7F8C0 MEKIBKHOPEH 0xD7BDBC BNFMFOJPJGH

		//// RVA: 0xD7F958 Offset: 0xD7F958 VA: 0xD7F958
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7EF38 Offset: 0xD7EF38 VA: 0xD7EF38
		//public uint CAOGDCBPBAN() { }
	}

	public class PDLENIHAMBC : NONCDAINJLD
	{
		private int ADJAPOBCIGG; // 0x5C
		private int DLNJKNGICHI; // 0x60

		public int OCAMDLMPBGA { get { return ADJAPOBCIGG ^ FBGGEFFJJHB; } set { ADJAPOBCIGG = value ^ FBGGEFFJJHB; } } //0xD83EE0 DHOGDENEIOI 0xD7BE5C DBDFNFLGDFN
		public int PFJJFCPPNIN { get { return DLNJKNGICHI ^ FBGGEFFJJHB; } set { DLNJKNGICHI = value ^ FBGGEFFJJHB; } } //0xD83F78 DPIIPBMNHOI 0xD7BEF8 LAKMHLJFOAL

		//// RVA: 0xD84010 Offset: 0xD84010 VA: 0xD84010
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7EF5C Offset: 0xD7EF5C VA: 0xD7EF5C
		//public uint CAOGDCBPBAN() { }
	}

	public class FCOBCHHKMOA : NONCDAINJLD
	{
		private int HNNLOMMFHEN; // 0x5C

		public int DMEDKJPOLCH { get { return HNNLOMMFHEN ^ FBGGEFFJJHB; } set { HNNLOMMFHEN = value ^ FBGGEFFJJHB; } } //0xD7FC80 IPKCKAAEEOE 0xD7BF98 JOGLLINFLJN

		//// RVA: 0xD7FD18 Offset: 0xD7FD18 VA: 0xD7FD18
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7EF8C Offset: 0xD7EF8C VA: 0xD7EF8C
		//public uint CAOGDCBPBAN() { }
	}

	public class JFJCGPNKCEL
	{
		private int EHLGHDIACCG; // 0x8
		private int ICACDGNKEKC; // 0xC
		private int OJLLNPOBDOI; // 0x10
		private int MLIEIDPNFOE; // 0x14
		private int KGODGENEHOL; // 0x18
		private int CHCPFPELFIH; // 0x1C

		public int GOKJLBDJOLA { get { return EHLGHDIACCG ^ FBGGEFFJJHB; } set { EHLGHDIACCG = value ^ FBGGEFFJJHB; } } //0xD80E90 CCEEILBGBOM 0xD7C03C MKNIFMGHJHC
		public int PANOFCFJBPN { get { return ICACDGNKEKC ^ FBGGEFFJJHB; } set { ICACDGNKEKC = value ^ FBGGEFFJJHB; } } //0xD80F28 NCDEILGICIF 0xD80FC0 ANDGPNAJFGG
		public int PONECEJICJC { get { return OJLLNPOBDOI ^ FBGGEFFJJHB; } set { OJLLNPOBDOI = value ^ FBGGEFFJJHB; } } //0xD8105C NOHPJIDLDNB 0xD7C0D8 MECPJDCMOPK
		public int NDGBHPJJPAB { get { return MLIEIDPNFOE ^ FBGGEFFJJHB; } set { MLIEIDPNFOE = value ^ FBGGEFFJJHB; } } //0xD810F4 JKICLLNMAHP 0xD7C174 JHCEPDAGHPC
		public int PLMOFDENJOL { get { return KGODGENEHOL ^ FBGGEFFJJHB; } set { KGODGENEHOL = value ^ FBGGEFFJJHB; } } //0xD8118C DMIDBBKLHNH 0xD7C210 APDIHFHIMOK
		public int HLFHGEJKAAE { get { return CHCPFPELFIH ^ FBGGEFFJJHB; } set { CHCPFPELFIH = value ^ FBGGEFFJJHB; } } //0xD81224 FOKAOFFHJEL 0xD7C2AC GEOANDADHID

		//// RVA: 0xD812BC Offset: 0xD812BC VA: 0xD812BC
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7EFB0 Offset: 0xD7EFB0 VA: 0xD7EFB0
		//public uint CAOGDCBPBAN() { }
	}

	public class NACBCEDKEPF
	{
		private int EHOIENNDEDH; // 0x8
		public int[] JKLOKAKFJKP; // 0xC
		public int[] IFEHKNJONPL; // 0x10
		public int[] JPHGMBLDFOM; // 0x14
		public int[] LCGJKAGIFGO; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD81E9C DEMEPMAEJOO 0xD7C350 HIGKAIDMOKN

		//// RVA: 0xD81F34 Offset: 0xD81F34 VA: 0xD81F34
		//public int PMDIMEDKGJF(int IOPHIHFOOEP) { }

		//// RVA: 0xD7C3EC Offset: 0xD7C3EC VA: 0xD7C3EC
		public bool OLPACJAMDIP(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (JKLOKAKFJKP.Length <= IOPHIHFOOEP)
				return false;
			JKLOKAKFJKP[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD82028 Offset: 0xD82028 VA: 0xD82028
		//public int GMLLLODBHDB(int IOPHIHFOOEP) { }

		//// RVA: 0xD7C4E8 Offset: 0xD7C4E8 VA: 0xD7C4E8
		public bool PAKEIOIDMEJ(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (IFEHKNJONPL.Length <= IOPHIHFOOEP)
				return false;
			IFEHKNJONPL[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD8211C Offset: 0xD8211C VA: 0xD8211C
		//public int MEKEPNAMIKL(int IOPHIHFOOEP) { }

		//// RVA: 0xD7C5E4 Offset: 0xD7C5E4 VA: 0xD7C5E4
		public bool OPFJDAHPGHI(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (JPHGMBLDFOM.Length <= IOPHIHFOOEP)
				return false;
			JPHGMBLDFOM[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD82210 Offset: 0xD82210 VA: 0xD82210
		//public int IJFPFIOIJPB(int IOPHIHFOOEP) { }

		//// RVA: 0xD7C6E0 Offset: 0xD7C6E0 VA: 0xD7C6E0
		public bool CJEGGLPCIOD(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (LCGJKAGIFGO.Length <= IOPHIHFOOEP)
				return false;
			LCGJKAGIFGO[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD82304 Offset: 0xD82304 VA: 0xD82304
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD82404 Offset: 0xD82404 VA: 0xD82404
		//public void ODDIHGPONFL(LGHIPHEDCNC.NACBCEDKEPF OHMCIEMIKCE) { }

		//// RVA: 0xD7F00C Offset: 0xD7F00C VA: 0xD7F00C
		//public uint CAOGDCBPBAN() { }
	}

	public class ADLCPEOHOMP
	{
		private int EHOIENNDEDH; // 0x8
		private int GNGNIKNNCNH; // 0xC
		private int HNJHPNPFAAN; // 0x10
		private long PCLNFCNIECH; // 0x18
		private long HHPIJHADAOB; // 0x20
		private int NOFECLGOLAI; // 0x28
		private int KPICCPDEPPL; // 0x2C
		private int IPAKEGGICML; // 0x30
		private int[] GFBIBNABAHB = new int[7]; // 0x34

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD7F198 DEMEPMAEJOO 0xD7C850 HIGKAIDMOKN
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xD7F230 KJIMMIBDCIL 0xD7C8EC DMEGNOKIKCD
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xD7F2C8 JPCJNLHHIPE 0xD7C988 JJFJNEJLBDG
		public long PDBPFJJCADD { get { return PCLNFCNIECH ^ BBEGLBMOBOF; } set { PCLNFCNIECH = value ^ BBEGLBMOBOF; } } //0xD7F360 FOACOMBHPAC 0xD7CA24 NBACOBCOJCA
		public long FDBNFFNFOND { get { return HHPIJHADAOB ^ BBEGLBMOBOF; } set { HHPIJHADAOB = value ^ BBEGLBMOBOF; } } //0xD7F3FC BPJOGHJCLDJ 0xD7CAC8 NLJKMCHOCBK
		public int GBJFNGCDKPM { get { return NOFECLGOLAI ^ FBGGEFFJJHB; } set { NOFECLGOLAI = value ^ FBGGEFFJJHB; } } //0xD7F498 CEJJMKODOGK 0xD7CB6C HOHCEBMMACI
		public int JPDCHPDMDDG { get { return KPICCPDEPPL ^ FBGGEFFJJHB; } set { KPICCPDEPPL = value ^ FBGGEFFJJHB; } } //0xD7F530 IHHDEBMPGCE 0xD7CC08 FAKDHLEPHBA
		public int CPKMLLNADLJ { get { return IPAKEGGICML ^ FBGGEFFJJHB; } set { IPAKEGGICML = value ^ FBGGEFFJJHB; } } //0xD7F5C8 BJPJMGHCDNO 0xD7CCA4 BPKIOJBKNBP

		//// RVA: 0xD7F660 Offset: 0xD7F660 VA: 0xD7F660
		public int CEKFBFIOBGO(int IOPHIHFOOEP)
		{
			if (GFBIBNABAHB.Length <= IOPHIHFOOEP)
				return 0;
			return GFBIBNABAHB[IOPHIHFOOEP] ^ FBGGEFFJJHB;
		}

		//// RVA: 0xD7CD40 Offset: 0xD7CD40 VA: 0xD7CD40
		public bool OMKABGNMOCN(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			if (GFBIBNABAHB.Length <= IOPHIHFOOEP)
				return false;
			GFBIBNABAHB[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD7F754 Offset: 0xD7F754 VA: 0xD7F754
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD7F80C Offset: 0xD7F80C VA: 0xD7F80C
		//public uint CAOGDCBPBAN() { }
	}

	public class HEECIKHJOBM
	{
		private int EHOIENNDEDH; // 0x8
		private int GNGNIKNNCNH; // 0xC
		private int HNJHPNPFAAN; // 0x10
		private int MOCCPJMBNOD; // 0x14
		private int ACJLNJEPKMA; // 0x18
		private int LBFINAPGAFK; // 0x1C
		private int EFJPDILFMDG; // 0x20
		private int AFFJHFBDIII; // 0x24
		private int ELPLKHDCEEH; // 0x28
		private int IBINEIGDMMA; // 0x2C
		private int GGBBANEKCMI; // 0x30
		private int HICPHKEKLMK; // 0x34
		private int DIHEJBGOOHM; // 0x38
		private int MLFCHMNOILK; // 0x3C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD748C4 DEMEPMAEJOO 0xD7CE44 HIGKAIDMOKN
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0xD805B0 KJIMMIBDCIL 0xD7CEE0 DMEGNOKIKCD
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0xD74794 JPCJNLHHIPE 0xD7CF7C JJFJNEJLBDG
		public int LJHNOBJJBJA { get { return MOCCPJMBNOD ^ FBGGEFFJJHB; } set { MOCCPJMBNOD = value ^ FBGGEFFJJHB; } } //0xD80648 CJDBJIDPKHB 0xD7D018 CMMGLEJAPKE
		public int BJHAMGNNGBC { get { return ACJLNJEPKMA ^ FBGGEFFJJHB; } set { ACJLNJEPKMA = value ^ FBGGEFFJJHB; } } //0xD7482C EPMFOHNLCIL 0xD7D0B4 EMFIMCOEEJP
		public int KDMIJCOJNGO { get { return LBFINAPGAFK ^ FBGGEFFJJHB; } set { LBFINAPGAFK = value ^ FBGGEFFJJHB; } } //0xD74B7C IGIMJJKCKKD 0xD7D150 FFHGADEMHPB
		public int OHJEJDEMGIH { get { return EFJPDILFMDG ^ FBGGEFFJJHB; } set { EFJPDILFMDG = value ^ FBGGEFFJJHB; } } //0xD806E0 HOLGNGADCHD 0xD7D1EC HFMDLMNNFFH
		public int HICPFMHEMPN { get { return AFFJHFBDIII ^ FBGGEFFJJHB; } set { AFFJHFBDIII = value ^ FBGGEFFJJHB; } } //0xD80778 EAEMLGPGAMH 0xD7D288 DECHNCKIPCL
		public int HLDAPDPGDME { get { return ELPLKHDCEEH ^ FBGGEFFJJHB; } set { ELPLKHDCEEH = value ^ FBGGEFFJJHB; } } //0xD80810 JBOKDIIMHDH 0xD7D324 HBBBAGMIHJL
		public int NAHPAJGLDAF { get { return IBINEIGDMMA ^ FBGGEFFJJHB; } set { IBINEIGDMMA = value ^ FBGGEFFJJHB; } } //0xD808A8 FNKMCEDLONO 0xD7D3C0 OPOMPMEKPKB
		public int LIJHGLLNMLG { get { return GGBBANEKCMI ^ FBGGEFFJJHB; } set { GGBBANEKCMI = value ^ FBGGEFFJJHB; } } //0xD80940 PHCABCNBKMO 0xD7D45C NELHLHIIAJD
		public int EJFAEKPGKNJ { get { return HICPHKEKLMK ^ FBGGEFFJJHB; } set { HICPHKEKLMK = value ^ FBGGEFFJJHB; } } //0xD809D8 GDEHEBKFALC 0xD7D4F8 JHBKBAKBALB
		public int JBHBGOIMALD { get { return DIHEJBGOOHM ^ FBGGEFFJJHB; } set { DIHEJBGOOHM = value ^ FBGGEFFJJHB; } } //0xD80A70 JMKPGPCDONN 0xD7D594 FMLIGECHCCB
		public int DIDNHGHIAFO { get { return MLFCHMNOILK ^ FBGGEFFJJHB; } set { MLFCHMNOILK = value ^ FBGGEFFJJHB; } } //0xD80B08 FDFHHDFFLGK 0xD7D630 IDMBCDKAMCI

		//// RVA: 0xD80BA0 Offset: 0xD80BA0 VA: 0xD80BA0
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD80C54 Offset: 0xD80C54 VA: 0xD80C54
		//public uint CAOGDCBPBAN() { }
	}

	public class NEINKEIIICC
	{
		private int EHOIENNDEDH; // 0x8
		private int MBCPMFPKNBA; // 0xC
		private int CFJKCBOBOOK; // 0x10
		private int MLLNBKFGLAM; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD828B4 DEMEPMAEJOO 0xD7D6D4 HIGKAIDMOKN
		public int ANAJIAENLNB { get { return MBCPMFPKNBA ^ FBGGEFFJJHB; } set { MBCPMFPKNBA = value ^ FBGGEFFJJHB; } } //0xD8294C MMOMNMBKHJF 0xD7D770 FEHNFGPFINK
		public int DEMGMKOLNOI { get { return CFJKCBOBOOK ^ FBGGEFFJJHB; } set { CFJKCBOBOOK = value ^ FBGGEFFJJHB; } } //0xD829E4 KKKKFBPFCCJ 0xD7D80C HCCDFJFMMBK
		public int OANKLPBCKGN { get { return MLLNBKFGLAM ^ FBGGEFFJJHB; } set { MLLNBKFGLAM = value ^ FBGGEFFJJHB; } } //0xD82A7C EMDDAKAHEBP 0xD7D8A8 BLBMLPDJNBN

		//// RVA: 0xD82B14 Offset: 0xD82B14 VA: 0xD82B14
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD82B50 Offset: 0xD82B50 VA: 0xD82B50
		//public uint CAOGDCBPBAN() { }
	}

	public class JBJNIKCEBOE
	{
		private int EHLGHDIACCG; // 0x8
		private int MBCPMFPKNBA; // 0xC

		public int GOKJLBDJOLA { get { return EHLGHDIACCG ^ FBGGEFFJJHB; } set { EHLGHDIACCG = value ^ FBGGEFFJJHB; } } //0xD80D10 CCEEILBGBOM 0xD7D94C MKNIFMGHJHC
		public int ANAJIAENLNB { get { return MBCPMFPKNBA ^ FBGGEFFJJHB; } set { MBCPMFPKNBA = value ^ FBGGEFFJJHB; } } //0xD80DA8 MMOMNMBKHJF 0xD7D9E8 FEHNFGPFINK

		//// RVA: 0xD80E40 Offset: 0xD80E40 VA: 0xD80E40
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD80E64 Offset: 0xD80E64 VA: 0xD80E64
		//public uint CAOGDCBPBAN() { }
	}

	public class PCOENHPINEI
	{
		private int EHLGHDIACCG; // 0x8
		private int CFJKCBOBOOK; // 0xC

		public int GOKJLBDJOLA { get { return EHLGHDIACCG ^ FBGGEFFJJHB; } set { EHLGHDIACCG = value ^ FBGGEFFJJHB; } } //0xD83D60 CCEEILBGBOM 0xD7DA8C MKNIFMGHJHC
		public int DEMGMKOLNOI { get { return CFJKCBOBOOK ^ FBGGEFFJJHB; } set { CFJKCBOBOOK = value ^ FBGGEFFJJHB; } } //0xD83DF8 KKKKFBPFCCJ 0xD7DB28 HCCDFJFMMBK

		//// RVA: 0xD83E90 Offset: 0xD83E90 VA: 0xD83E90
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD83EB4 Offset: 0xD83EB4 VA: 0xD83EB4
		//public uint CAOGDCBPBAN() { }
	}

	public class NBOFLLJFGOA
	{
		private int EHOIENNDEDH; // 0x8
		private int NOPBNLJELKI; // 0xC
		private int LCGJKAGIFGO; // 0x10

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } }// 0xD82684 DEMEPMAEJOO 0xD7DBCC HIGKAIDMOKN
		public int ACGMHCKDHOO { get { return NOPBNLJELKI ^ FBGGEFFJJHB; } set { NOPBNLJELKI = value ^ FBGGEFFJJHB; } }// 0xD8271C MJBIIDKMCOE 0xD7DC68 KIAOHNNJNFP
		public int DOOGFEGEKLG { get { return LCGJKAGIFGO ^ FBGGEFFJJHB; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB; } }// 0xD827B4 AECMFIOFFJN 0xD7DD04 NGOJJDOCIDG

		//// RVA: 0xD8284C Offset: 0xD8284C VA: 0xD8284C
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD8287C Offset: 0xD8287C VA: 0xD8287C
		//public uint CAOGDCBPBAN() { }
	}

	public class GHLIDOPMMDB
	{
		private int EHOIENNDEDH; // 0x8
		private int FPOLAPKKDMG; // 0xC
		private int ICKOHEDLEFP; // 0x10
		private int MMEINLBEOMK; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD802D0 DEMEPMAEJOO 0xD7DDA8 HIGKAIDMOKN
		public int OAFPGJLCNFM { get { return FPOLAPKKDMG ^ FBGGEFFJJHB; } set { FPOLAPKKDMG = value ^ FBGGEFFJJHB; } } //0xD80368 PMJFANGPJIE 0xD7DE44 HEECOBEHHPJ
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0xD80400 OLOCMINKGON 0xD7DEE0 ABAFHIBFKCE
		public int ADPPAIPFHML { get { return MMEINLBEOMK ^ FBGGEFFJJHB; } set { MMEINLBEOMK = value ^ FBGGEFFJJHB; } } //0xD80498 LJMLHOOPGEM 0xD7DF7C PHNIOCPOBGO

		//// RVA: 0xD80530 Offset: 0xD80530 VA: 0xD80530
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD8056C Offset: 0xD8056C VA: 0xD8056C
		//public uint CAOGDCBPBAN() { }
	}

	public class OKNFCMGANNF
	{
		private int EHOIENNDEDH; // 0x8
		private int MEGEAIJENLP; // 0xC
		public int[] NIOPNCALFOE = new int[4]; // 0x10
		public int[] CDDLNKAPCFB = new int[4]; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD837B8 DEMEPMAEJOO 0xD7E09C HIGKAIDMOKN
		public int PGOJILPILNG { get { return MEGEAIJENLP ^ FBGGEFFJJHB; } set { MEGEAIJENLP = value ^ FBGGEFFJJHB; } } //0xD83850 EFOHDAAKOIO 0xD7E138 NHEEMKHLFJB

		//// RVA: 0xD838E8 Offset: 0xD838E8 VA: 0xD838E8
		//public int EFHJBBKONGA(int CMBFEFIJFBK) { }

		//// RVA: 0xD7E1D4 Offset: 0xD7E1D4 VA: 0xD7E1D4
		public bool IFIEMNCGJBB(int CMBFEFIJFBK, int JBGEEPFKIGG)
		{
			if (NIOPNCALFOE.Length <= CMBFEFIJFBK)
				return false;
			NIOPNCALFOE[CMBFEFIJFBK] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD839DC Offset: 0xD839DC VA: 0xD839DC
		//public int MCOHMGONPAF(int CMBFEFIJFBK) { }

		//// RVA: 0xD7E2D0 Offset: 0xD7E2D0 VA: 0xD7E2D0
		public bool MPBCJDOBKJD(int CMBFEFIJFBK, int JBGEEPFKIGG)
		{
			if (CDDLNKAPCFB.Length <= CMBFEFIJFBK)
				return false;
			CDDLNKAPCFB[CMBFEFIJFBK] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD83AD0 Offset: 0xD83AD0 VA: 0xD83AD0
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD83B58 Offset: 0xD83B58 VA: 0xD83B58
		//public void ODDIHGPONFL(LGHIPHEDCNC.OKNFCMGANNF OHMCIEMIKCE) { }

		//// RVA: 0xD83CC8 Offset: 0xD83CC8 VA: 0xD83CC8
		//public uint CAOGDCBPBAN() { }
	}

	public class KPPFMKLEKLE
	{
		private int EHOIENNDEDH; // 0x8
		private int MEGEAIJENLP; // 0xC
		public int[] JPDONOHOEPD = new int[2]; // 0x10
		public int[] MDHDCMOKNFN = new int[2]; // 0x14
		public int[] BLONJEJPPAC = new int[2]; // 0x18
		public int[] DNDFHJJCEAO = new int[2]; // 0x1C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD80174 DEMEPMAEJOO 0xD7E470 HIGKAIDMOKN
		public int PGOJILPILNG { get { return MEGEAIJENLP ^ FBGGEFFJJHB; } set { MEGEAIJENLP = value ^ FBGGEFFJJHB; } } //0xD8020C EFOHDAAKOIO 0xD7E50C NHEEMKHLFJB

		//// RVA: 0xD81310 Offset: 0xD81310 VA: 0xD81310
		//public int GKBNNGPIELM(int IOPHIHFOOEP) { }

		//// RVA: 0xD7E5A8 Offset: 0xD7E5A8 VA: 0xD7E5A8
		public bool CDEEPLNNAIA(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			JPDONOHOEPD[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD813E0 Offset: 0xD813E0 VA: 0xD813E0
		//public int EICKLOBPHKD(int IOPHIHFOOEP) { }

		//// RVA: 0xD7E680 Offset: 0xD7E680 VA: 0xD7E680
		public bool AELPPMPGMKL(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			MDHDCMOKNFN[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD814B0 Offset: 0xD814B0 VA: 0xD814B0
		//public int LPEBGOAFGNG(int IOPHIHFOOEP) { }

		//// RVA: 0xD7E758 Offset: 0xD7E758 VA: 0xD7E758
		public bool MMIGDOAKGMN(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			BLONJEJPPAC[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD81580 Offset: 0xD81580 VA: 0xD81580
		//public int DLKPKENAECK(int IOPHIHFOOEP) { }

		//// RVA: 0xD7E830 Offset: 0xD7E830 VA: 0xD7E830
		public bool PFGPMBCGEKC(int IOPHIHFOOEP, int JBGEEPFKIGG)
		{
			DNDFHJJCEAO[IOPHIHFOOEP] = JBGEEPFKIGG ^ FBGGEFFJJHB;
			return true;
		}

		//// RVA: 0xD81650 Offset: 0xD81650 VA: 0xD81650
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD81764 Offset: 0xD81764 VA: 0xD81764
		//public void ODDIHGPONFL(LGHIPHEDCNC.KPPFMKLEKLE OHMCIEMIKCE) { }

		//// RVA: 0xD81A3C Offset: 0xD81A3C VA: 0xD81A3C
		//public uint CAOGDCBPBAN() { }
	}

	public class GGKANMNMPBB
	{
		private int EHOIENNDEDH; // 0x8
		private int BOCMGOHDKDK; // 0xC

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD7FFB4 DEMEPMAEJOO 0xD7E910 HIGKAIDMOKN
		public int MKPJBDFDHOL { get { return BOCMGOHDKDK ^ FBGGEFFJJHB; } set { BOCMGOHDKDK = value ^ FBGGEFFJJHB; } } //0xD8004C MIDKFOPDBEJ 0xD7E9AC IBBBHHLGEPJ

		//// RVA: 0xD800E4 Offset: 0xD800E4 VA: 0xD800E4
		//public void LHPDDGIJKNB() { }

		//// RVA: 0xD80108 Offset: 0xD80108 VA: 0xD80108
		//public void ODDIHGPONFL(LGHIPHEDCNC.KPPFMKLEKLE OHMCIEMIKCE) { }

		//// RVA: 0xD802A4 Offset: 0xD802A4 VA: 0xD802A4
		//public uint CAOGDCBPBAN() { }
	}

	public class FFNEKFPAGDO
	{
		private int EHOIENNDEDH; // 0x8
		private long NJELFCGIKHP; // 0x10
		private long PMPAFLLFAGO; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0xD7FD38 DEMEPMAEJOO 0xD7FDD0 HIGKAIDMOKN
		public long NHPCKCOPKAM { get { return NJELFCGIKHP ^ BBEGLBMOBOF; } set { NJELFCGIKHP = value ^ BBEGLBMOBOF; } } //0xD7AD10 GKJBCKDHCOE 0xD7FE6C JJCALPLDOON
		public long PJFKNNNDMIA { get { return PMPAFLLFAGO ^ BBEGLBMOBOF; } set { PMPAFLLFAGO = value ^ BBEGLBMOBOF; } } //0xD7ADAC HLKDJMHLHNL 0xD7FF10 APDEHBODBOO

		// RVA: 0xD7AA44 Offset: 0xD7AA44 VA: 0xD7AA44
		public FFNEKFPAGDO()
		{
			PPFNGGCBJKC = 0;
			NHPCKCOPKAM = 0;
			PJFKNNNDMIA = 0;
		}

		//// RVA: 0xD7AA90 Offset: 0xD7AA90 VA: 0xD7AA90
		public void KHEKNNFCAOI(int KIJAPOFAGPN)
		{
			PPFNGGCBJKC = KIJAPOFAGPN;
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN) == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
			{
				HHFFOACILKG_Medal medalDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal;
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal == null)
					return;
				int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN);
				if (itemId < 1)
					return;
				if (medalDb.CDENCMNHNGA.Count < itemId)
					return;
				HHFFOACILKG_Medal.HCFJGDFMHOJ medalInfo = medalDb.CDENCMNHNGA[itemId - 1];
				NHPCKCOPKAM = medalInfo.AHILKBKLFJM;
				PJFKNNNDMIA = medalInfo.ODPMNBBBBIM;
			}
			else
			{
				NHPCKCOPKAM = 0;
				PJFKNNNDMIA = 0;
			}
		}
	}

	public static int FBGGEFFJJHB = 0x58a84126; // 0x0
	public static long BBEGLBMOBOF = 0x58a8412658a84126; // 0x8
	public List<LHDLCLNBPLB> HOJPJAFDIAD = new List<LHDLCLNBPLB>(); // 0x20
	public List<BFEIHCJHHAJ> FFKIBJKEBNP = new List<BFEIHCJHHAJ>(); // 0x24
	public List<PDLENIHAMBC> PMCDKBBHCJK = new List<PDLENIHAMBC>(); // 0x28
	public List<FCOBCHHKMOA> OICGEEKOLOG = new List<FCOBCHHKMOA>(); // 0x2C
	public List<JFJCGPNKCEL> ODNHHBHCEDO = new List<JFJCGPNKCEL>(); // 0x30
	public List<NACBCEDKEPF> IGIBGGIACBC = new List<NACBCEDKEPF>(); // 0x34
	public List<NACBCEDKEPF> CIMLFGFMFCH = new List<NACBCEDKEPF>(); // 0x38
	public List<ADLCPEOHOMP> CDCCOJKCHIG = new List<ADLCPEOHOMP>(); // 0x3C
	public List<HEECIKHJOBM> JGNEADEJDOF = new List<HEECIKHJOBM>(); // 0x40
	public List<NEINKEIIICC> KGHEHEDBPFL = new List<NEINKEIIICC>(); // 0x44
	public List<JBJNIKCEBOE> DMOLOCBIDBD = new List<JBJNIKCEBOE>(); // 0x48
	public List<PCOENHPINEI> JNIGHEHKAHG = new List<PCOENHPINEI>(); // 0x4C
	public List<NBOFLLJFGOA> CNBFDHBNCBD = new List<NBOFLLJFGOA>(); // 0x50
	public List<GHLIDOPMMDB> GLOOEBIBCOC = new List<GHLIDOPMMDB>(); // 0x54
	public List<OKNFCMGANNF> KJEKILELBAB = new List<OKNFCMGANNF>(); // 0x58
	public List<KPPFMKLEKLE> BJKKBBPFBOL = new List<KPPFMKLEKLE>(); // 0x5C
	public List<GGKANMNMPBB> FOIEHFEINKI = new List<GGKANMNMPBB>(); // 0x60
	public List<FFNEKFPAGDO> DDKAFBFPIEA = new List<FFNEKFPAGDO>(); // 0x64

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x68 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x6C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xD7449C Offset: 0xD7449C VA: 0xD7449C
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if (!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0xD74580 Offset: 0xD74580 VA: 0xD74580
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if (!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0xD74664 Offset: 0xD74664 VA: 0xD74664
	public int LDBKGMIKJJM(int BJHAMGNNGBC)
	{
		int res = 0;
		for(int i = 0; i < JGNEADEJDOF.Count; i++)
		{
			if(JGNEADEJDOF[i].PLALNIIBLOF == 2)
			{
				if (JGNEADEJDOF[i].BJHAMGNNGBC == BJHAMGNNGBC)
					res = JGNEADEJDOF[i].PPFNGGCBJKC;
			}
		}
		return res;
	}

	//// RVA: 0xD7495C Offset: 0xD7495C VA: 0xD7495C
	//public int IFGENACNEND(long LLONEBLOPKJ) { }

	//// RVA: 0xD74A5C Offset: 0xD74A5C VA: 0xD74A5C
	public int KGHLJBEJOIG()
	{
		for(int i = 0; i < JGNEADEJDOF.Count; i++)
		{
			if(JGNEADEJDOF[i].PLALNIIBLOF == 2)
			{
				if(JGNEADEJDOF[i].KDMIJCOJNGO == 2)
				{
					return JGNEADEJDOF[i].PPFNGGCBJKC;
				}
			}
		}
		return 0;
	}

	//// RVA: 0xD74C14 Offset: 0xD74C14 VA: 0xD74C14
	public List<int> FMFMLGHLELN(long KGIBHAGPCGE, long JHNMKKNEENE)
	{
		List<int> res = new List<int>();
		res.Clear();
		DateTime d1 = Utility.GetLocalDateTime(KGIBHAGPCGE);
		DateTime d2 = Utility.GetLocalDateTime(JHNMKKNEENE);
		int a1 = 0;
		if(KGHLJBEJOIG() > 0)
		{
			a1 = JGNEADEJDOF[KGHLJBEJOIG() - 1].BJHAMGNNGBC;
		}
		int k = d2.Minute * 100 + d2.Hour * 10000 + d2.Second;
		int a2 = a1;
		if(d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day)
		{
			int k2 = d1.Minute * 100 + d1.Hour * 10000 + d1.Second;
			if(a1 != k2 && LDBKGMIKJJM(k2) > 0)
			{
				return res;
			}
			if (a1 <= k2)
				a2 = k2;
			if (k < a1)
				a2 = k2;
		}
		for(int i = 0; i < JGNEADEJDOF.Count; i++)
		{
			if(JGNEADEJDOF[i].PLALNIIBLOF == 2)
			{
				if(a2 <= JGNEADEJDOF[i].BJHAMGNNGBC)
				{
					if(JGNEADEJDOF[i].BJHAMGNNGBC <= k)
					{
						res.Add(JGNEADEJDOF[i].PPFNGGCBJKC);
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0xD75018 Offset: 0xD75018 VA: 0xD75018
	public long IILNIBNFOLG(long JHNMKKNEENE)
	{
		long a1 = 0;
		for(int i = 0; i < JGNEADEJDOF.Count; i++)
		{
			HEECIKHJOBM d = JGNEADEJDOF[i];
			if(d.PLALNIIBLOF == 2)
			{
				if(d.KDMIJCOJNGO == 2)
				{
					a1 = d.BJHAMGNNGBC;
				}
			}
		}
		DateTime date = Utility.GetLocalDateTime(JHNMKKNEENE);
		int h = (int)(a1 / 10000);
		return Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, h, (int)(a1 / 100 - 100 * h), (int)(a1 % 100)) + 86400;
	}

	//// RVA: 0xD752CC Offset: 0xD752CC VA: 0xD752CC
	public long JMFOBCHBCCB(long JHNMKKNEENE)
	{
		DateTime date = Utility.GetLocalDateTime(JHNMKKNEENE);
		long a1 = 0;
		for(int i = 0; i < JGNEADEJDOF.Count; i++)
		{
			HEECIKHJOBM d = JGNEADEJDOF[i];
			if (d.PLALNIIBLOF == 2)
			{
				if (date.Minute * 100 + date.Hour * 10000 + date.Second < d.BJHAMGNNGBC)
				{
					a1 = d.BJHAMGNNGBC;
					break;
				}
			}
		}
		int h = (int)(a1 / 10000);
		return Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, h, (int)(a1 / 100 - 100 * h), (int)(a1 % 100)) + 86400;
	}

	// RVA: 0xD75588 Offset: 0xD75588 VA: 0xD75588
	public LGHIPHEDCNC_Offer()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 64;
	}

	// RVA: 0xD75A3C Offset: 0xD75A3C VA: 0xD75A3C Slot: 8
	protected override void KMBPACJNEOF()
	{
		HOJPJAFDIAD.Clear();
		FFKIBJKEBNP.Clear();
		PMCDKBBHCJK.Clear();
		OICGEEKOLOG.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	// RVA: 0xD75B90 Offset: 0xD75B90 VA: 0xD75B90 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		FELHBHFOHPO parser = FELHBHFOHPO.HEGEKFMJNCC(DBBGALAPFGC);
		PGHFHOFANBO(parser);
		AMHJHMHALDH(parser);
		HMKCCJDPHMN(parser);
		JLAKIDPNMMO(parser);
		DANOHHFCKAH(parser);
		BAMEEOPODBD(parser);
		BBLMINIGJAN(parser);
		IFDPHGBNGDF(parser);
		MAGKEIMKBAI(parser);
		EKCGLFHICHJ(parser);
		LGBNCHCFNMP(parser);
		NMPBKEDNOFJ(parser);
		BGFBCNMCMKD(parser);
		MOECJEEAFNK(parser);
		NJBPPHNJDEP(parser);
		BBFMJMIOKAN(parser);
		FCKLNKLLLDJ(parser);
		{
			PKHOBCBNBIJ[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK.Add(array[i].LJNAKDMILMC, data);
			}
		}
		{
			BFIOHOEGDAA[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				FJOEBCMGDMI.Add(array[i].LJNAKDMILMC, data);
			}
		}
		DDKAFBFPIEA = new List<FFNEKFPAGDO>();
		if(FJOEBCMGDMI.ContainsKey("expired_check_item_id_list"))
		{
			string str = FJOEBCMGDMI["expired_check_item_id_list"].DNJEJEANJGL_Value;
			string[] strs = str.Split(new char[1] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				FFNEKFPAGDO data = new FFNEKFPAGDO();
				data.KHEKNNFCAOI(Int32.Parse(strs[i]));
				if(data.NHPCKCOPKAM != 0 && data.PJFKNNNDMIA != 0)
				{
					DDKAFBFPIEA.Add(data);
				}
			}
		}
		return true;
	}

	//// RVA: 0xD7618C Offset: 0xD7618C VA: 0xD7618C
	private bool PGHFHOFANBO(FELHBHFOHPO POGDAGEEDPN)
	{
		JIMMPLNKNAL[] array = POGDAGEEDPN.EPOIDPEPBGH;
		for(int i = 0; i < array.Length; i++)
		{
			LHDLCLNBPLB data = new LHDLCLNBPLB();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.CECKOCLEABH = array[i].CECKOCLEABH;
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.AIIOIKGMOBD = (int)array[i].AIIOIKGMOBD;
			data.FCBJFKGDINH = array[i].FCBJFKGDINH;
			data.NONBCCLGBAO = array[i].NONBCCLGBAO;
			data.BBMBLOABEOK = array[i].BBMBLOABEOK;
			data.FCDMDDIHMPO = array[i].FCDMDDIHMPO;
			data.JBHBGOIMALD = array[i].JBHBGOIMALD;
			data.PPMBFJJDCPP = array[i].PPMBFJJDCPP;
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.LJNAKDMILMC = array[i].LJNAKDMILMC;
			for(int j = 0; j < array[i].AAABDBKGGNC.Length; j++)
			{
				data.PGBPLOHNAOC(j, array[i].AAABDBKGGNC[j]);
			}
			for (int j = 0; j < array[i].OPDAPCNDKJJ.Length; j++)
			{
				data.HHIOOFDNPFF(j, array[i].OPDAPCNDKJJ[j]);
			}
			for (int j = 0; j < array[i].HODLNPFFOBI.Length; j++)
			{
				data.LILKNMJPLLN(j, array[i].HODLNPFFOBI[j]);
			}
			int b = 0;
			for (int j = 0; j < array[i].BNIKPDMJILB.Length; j++)
			{
				data.MKGIKKJCPBL(j, array[i].BNIKPDMJILB[j]);
				if(array[i].BNIKPDMJILB[j] > 1)
				{
					b = 1;
				}
			}
			data.KOOEOKEDJDO = b;
			data.GBJFNGCDKPM = 1;
			HOJPJAFDIAD.Add(data);
		}
		return true;
	}

	//// RVA: 0xD76A90 Offset: 0xD76A90 VA: 0xD76A90
	private bool AMHJHMHALDH(FELHBHFOHPO POGDAGEEDPN)
	{
		NLMBHIHCOKJ[] array = POGDAGEEDPN.HJENJPAKCIC;
		for(int i = 0; i < array.Length; i++)
		{
			BFEIHCJHHAJ data = new BFEIHCJHHAJ();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.HAHMHBNPGFM = array[i].HAHMHBNPGFM;
			data.CECKOCLEABH = array[i].CECKOCLEABH;
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.AIIOIKGMOBD = (int)array[i].AIIOIKGMOBD;
			data.FCBJFKGDINH = array[i].FCBJFKGDINH;
			data.NONBCCLGBAO = array[i].NONBCCLGBAO;
			data.BBMBLOABEOK = array[i].BBMBLOABEOK;
			data.FCDMDDIHMPO = array[i].FCDMDDIHMPO;
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.LJNAKDMILMC = array[i].LJNAKDMILMC;
			for (int j = 0; j < array[i].AAABDBKGGNC.Length; j++)
			{
				data.PGBPLOHNAOC(j, array[i].AAABDBKGGNC[j]);
			}
			for (int j = 0; j < array[i].OPDAPCNDKJJ.Length; j++)
			{
				data.HHIOOFDNPFF(j, array[i].OPDAPCNDKJJ[j]);
			}
			for (int j = 0; j < array[i].HODLNPFFOBI.Length; j++)
			{
				data.LILKNMJPLLN(j, array[i].HODLNPFFOBI[j]);
			}
			data.GBJFNGCDKPM = 2;
			FFKIBJKEBNP.Add(data);
		}
		return true;
	}

	//// RVA: 0xD771C8 Offset: 0xD771C8 VA: 0xD771C8
	private bool HMKCCJDPHMN(FELHBHFOHPO POGDAGEEDPN)
	{
		CNMOAOBIKHP[] array = POGDAGEEDPN.OKAPEKMNOCM;
		for (int i = 0; i < array.Length; i++)
		{
			PDLENIHAMBC data = new PDLENIHAMBC();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.CECKOCLEABH = array[i].CECKOCLEABH;
			data.OCAMDLMPBGA = array[i].OCAMDLMPBGA;
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			data.PFJJFCPPNIN = array[i].PFJJFCPPNIN;
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.AIIOIKGMOBD = (int)array[i].AIIOIKGMOBD;
			data.FCBJFKGDINH = array[i].FCBJFKGDINH;
			data.NONBCCLGBAO = array[i].NONBCCLGBAO;
			data.BBMBLOABEOK = array[i].BBMBLOABEOK;
			data.FCDMDDIHMPO = array[i].FCDMDDIHMPO;
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.LJNAKDMILMC = array[i].LJNAKDMILMC;
			for (int j = 0; j < array[i].AAABDBKGGNC.Length; j++)
			{
				data.PGBPLOHNAOC(j, array[i].AAABDBKGGNC[j]);
			}
			for (int j = 0; j < array[i].OPDAPCNDKJJ.Length; j++)
			{
				data.HHIOOFDNPFF(j, array[i].OPDAPCNDKJJ[j]);
			}
			for (int j = 0; j < array[i].HODLNPFFOBI.Length; j++)
			{
				data.LILKNMJPLLN(j, array[i].HODLNPFFOBI[j]);
			}
			data.GBJFNGCDKPM = 3;
			PMCDKBBHCJK.Add(data);
		}
		return true;
	}

	//// RVA: 0xD7793C Offset: 0xD7793C VA: 0xD7793C
	private bool JLAKIDPNMMO(FELHBHFOHPO POGDAGEEDPN)
	{
		IEMDICEGDFB[] array = POGDAGEEDPN.IIDHHEHBAHJ;
		for (int i = 0; i < array.Length; i++)
		{
			FCOBCHHKMOA data = new FCOBCHHKMOA();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.CECKOCLEABH = array[i].CECKOCLEABH;
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.AIIOIKGMOBD = (int)array[i].AIIOIKGMOBD;
			data.FCBJFKGDINH = array[i].FCBJFKGDINH;
			data.NONBCCLGBAO = array[i].NONBCCLGBAO;
			data.BBMBLOABEOK = array[i].BBMBLOABEOK;
			data.FCDMDDIHMPO = array[i].FCDMDDIHMPO;
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.LJNAKDMILMC = array[i].LJNAKDMILMC;
			data.DMEDKJPOLCH = array[i].DMEDKJPOLCH;
			for (int j = 0; j < array[i].AAABDBKGGNC.Length; j++)
			{
				data.PGBPLOHNAOC(j, array[i].AAABDBKGGNC[j]);
			}
			for (int j = 0; j < array[i].OPDAPCNDKJJ.Length; j++)
			{
				data.HHIOOFDNPFF(j, array[i].OPDAPCNDKJJ[j]);
			}
			for (int j = 0; j < array[i].HODLNPFFOBI.Length; j++)
			{
				data.LILKNMJPLLN(j, array[i].HODLNPFFOBI[j]);
			}
			data.GBJFNGCDKPM = 4;
			OICGEEKOLOG.Add(data);
		}
		return true;
	}

	//// RVA: 0xD78074 Offset: 0xD78074 VA: 0xD78074
	private bool DANOHHFCKAH(FELHBHFOHPO POGDAGEEDPN)
	{
		MINJCOMKBIB[] array = POGDAGEEDPN.HCDPNCNAMHA;
		for (int i = 0; i < array.Length; i++)
		{
			JFJCGPNKCEL data = new JFJCGPNKCEL();
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.PONECEJICJC = array[i].PONECEJICJC;
			data.NDGBHPJJPAB = array[i].NDGBHPJJPAB;
			data.PLMOFDENJOL = array[i].PLMOFDENJOL;
			data.HLFHGEJKAAE = array[i].HLFHGEJKAAE;
			ODNHHBHCEDO.Add(data);
		}
		return true;
	}

	//// RVA: 0xD782F8 Offset: 0xD782F8 VA: 0xD782F8
	private bool BAMEEOPODBD(FELHBHFOHPO POGDAGEEDPN)
	{
		GFJAJMPJMCO[] array = POGDAGEEDPN.GGGOGNPBBAH;
		for (int i = 0; i < array.Length; i++)
		{
			NACBCEDKEPF data = new NACBCEDKEPF();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			{
				int s = array[i].AIHOJKFNEEN.Length;
				if (s > 19)
					s = 20;
				data.JKLOKAKFJKP = new int[s];
				for(int j = 0; j < s; j++)
				{
					data.OLPACJAMDIP(j, array[i].AIHOJKFNEEN[j]);
				}
				data.IFEHKNJONPL = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.PAKEIOIDMEJ(j, array[i].BFINGCJHOHI[j]);
				}
				data.JPHGMBLDFOM = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.OPFJDAHPGHI(j, array[i].EHKJFNAABMC[j]);
				}
				data.LCGJKAGIFGO = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.CJEGGLPCIOD(j, array[i].DOOGFEGEKLG[j]);
				}
			}
			IGIBGGIACBC.Add(data);
		}
		return true;
	}

	//// RVA: 0xD787F4 Offset: 0xD787F4 VA: 0xD787F4
	private bool BBLMINIGJAN(FELHBHFOHPO POGDAGEEDPN)
	{
		FGCINBNCECC[] array = POGDAGEEDPN.OHIKEAFGKHD;
		for (int i = 0; i < array.Length; i++)
		{
			NACBCEDKEPF data = new NACBCEDKEPF();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			{
				int s = array[i].AIHOJKFNEEN.Length;
				if (s > 19)
					s = 20;
				data.JKLOKAKFJKP = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.OLPACJAMDIP(j, array[i].AIHOJKFNEEN[j]);
				}
				data.IFEHKNJONPL = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.PAKEIOIDMEJ(j, array[i].BFINGCJHOHI[j]);
				}
				data.JPHGMBLDFOM = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.OPFJDAHPGHI(j, array[i].EHKJFNAABMC[j]);
				}
				data.LCGJKAGIFGO = new int[s];
				for (int j = 0; j < s; j++)
				{
					data.CJEGGLPCIOD(j, array[i].DOOGFEGEKLG[j]);
				}
			}
			CIMLFGFMFCH.Add(data);
		}
		return true;
	}

	//// RVA: 0xD78CF0 Offset: 0xD78CF0 VA: 0xD78CF0
	private bool IFDPHGBNGDF(FELHBHFOHPO POGDAGEEDPN)
	{
		JPAGMGAFCAJ[] array = POGDAGEEDPN.DJEBGHFEOKG;
		for(int i = 0; i < array.Length; i++)
		{
			ADLCPEOHOMP data = new ADLCPEOHOMP();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.PDBPFJJCADD = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND = array[i].FDBNFFNFOND;
			data.GBJFNGCDKPM = (int)array[i].GBJFNGCDKPM;
			data.JPDCHPDMDDG = array[i].JPDCHPDMDDG;
			data.CPKMLLNADLJ = array[i].CPKMLLNADLJ;
			for(int j = 0; j < array[i].BAOFEFFADPD.Length; j++)
			{
				data.OMKABGNMOCN(j, (int)array[i].BAOFEFFADPD[j]);
			}
			CDCCOJKCHIG.Add(data);
		}
		return true;
	}

	//// RVA: 0xD790F0 Offset: 0xD790F0 VA: 0xD790F0
	private bool MAGKEIMKBAI(FELHBHFOHPO POGDAGEEDPN)
	{
		FCFPLIAALIN[] array = POGDAGEEDPN.NLLDBABOENI;
		for(int i = 0; i < array.Length; i++)
		{
			HEECIKHJOBM data = new HEECIKHJOBM();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.LJHNOBJJBJA = (int)array[i].LJHNOBJJBJA;
			data.BJHAMGNNGBC = (int)array[i].BJHAMGNNGBC;
			data.KDMIJCOJNGO = array[i].KDMIJCOJNGO;
			data.OHJEJDEMGIH = array[i].OBNLLKACKCE;
			data.HICPFMHEMPN = array[i].MBBJDDIKINH;
			data.HLDAPDPGDME = array[i].BINGBPHEJFE;
			data.NAHPAJGLDAF = array[i].BIJBCPAAKIB;
			data.LIJHGLLNMLG = array[i].NOPKBGGKLLM;
			data.EJFAEKPGKNJ = array[i].EJFAEKPGKNJ;
			data.JBHBGOIMALD = array[i].JBHBGOIMALD;
			data.DIDNHGHIAFO = array[i].DIDNHGHIAFO;
			JGNEADEJDOF.Add(data);
		}
		return true;
	}

	//// RVA: 0xD79590 Offset: 0xD79590 VA: 0xD79590
	private bool EKCGLFHICHJ(FELHBHFOHPO POGDAGEEDPN)
	{
		MMEAEFEFGNG[] array = POGDAGEEDPN.MCNPDAHDFPM;
		for(int i = 0; i < array.Length; i++)
		{
			NEINKEIIICC data = new NEINKEIIICC();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.ANAJIAENLNB = array[i].ANAJIAENLNB;
			data.DEMGMKOLNOI = array[i].DEMGMKOLNOI;
			data.OANKLPBCKGN = (int)array[i].OANKLPBCKGN;
			KGHEHEDBPFL.Add(data);
		}
		return true;
	}

	//// RVA: 0xD797D8 Offset: 0xD797D8 VA: 0xD797D8
	private bool LGBNCHCFNMP(FELHBHFOHPO POGDAGEEDPN)
	{
		ILMFKENHBKJ[] array = POGDAGEEDPN.ADAAMJDAPKH;
		for(int i = 0; i < array.Length; i++)
		{
			JBJNIKCEBOE data = new JBJNIKCEBOE();
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.ANAJIAENLNB = array[i].ANAJIAENLNB;
			DMOLOCBIDBD.Add(data);
		}
		return true;
	}

	//// RVA: 0xD799A8 Offset: 0xD799A8 VA: 0xD799A8
	private bool NMPBKEDNOFJ(FELHBHFOHPO POGDAGEEDPN)
	{
		ODIBMCKOPAF[] array = POGDAGEEDPN.LIKDGDFECPP;
		for(int i = 0; i < array.Length; i++)
		{
			PCOENHPINEI data = new PCOENHPINEI();
			data.GOKJLBDJOLA = array[i].GOKJLBDJOLA;
			data.DEMGMKOLNOI = array[i].DEMGMKOLNOI;
			JNIGHEHKAHG.Add(data);
		}
		return true;
	}

	//// RVA: 0xD79B78 Offset: 0xD79B78 VA: 0xD79B78
	private bool BGFBCNMCMKD(FELHBHFOHPO POGDAGEEDPN)
	{
		KMACMCPIAMC[] array = POGDAGEEDPN.NIODMOCNEBC;
		for(int i = 0; i < array.Length; i++)
		{
			NBOFLLJFGOA data = new NBOFLLJFGOA();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.ACGMHCKDHOO = array[i].ACGMHCKDHOO;
			data.DOOGFEGEKLG = array[i].DOOGFEGEKLG;
			CNBFDHBNCBD.Add(data);
		}
		return true;
	}

	//// RVA: 0xD79D84 Offset: 0xD79D84 VA: 0xD79D84
	private bool MOECJEEAFNK(FELHBHFOHPO POGDAGEEDPN)
	{
		OAPCBAPHBCA[] array = POGDAGEEDPN.NPJFJCJNPON;
		for(int i = 0; i < array.Length; i++)
		{
			GHLIDOPMMDB data = new GHLIDOPMMDB();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.OAFPGJLCNFM = array[i].OAFPGJLCNFM;
			data.JBGEEPFKIGG = array[i].JBGEEPFKIGG;
			data.ADPPAIPFHML = array[i].ADPPAIPFHML;
			GLOOEBIBCOC.Add(data);
		}
		return true;
	}

	//// RVA: 0xD79FCC Offset: 0xD79FCC VA: 0xD79FCC
	private bool NJBPPHNJDEP(FELHBHFOHPO POGDAGEEDPN)
	{
		GKHBFALLJIE[] array = POGDAGEEDPN.ELMNCEIJOKN;
		for(int i = 0; i < array.Length; i++)
		{
			OKNFCMGANNF data = new OKNFCMGANNF();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.PGOJILPILNG = array[i].PGOJILPILNG;
			int s = array[i].FCBJFKGDINH.Length;
			if (s > 3)
				s = 4;
			data.NIOPNCALFOE = new int[s];
			for(int j = 0; j < s; j++)
			{
				data.IFIEMNCGJBB(j, array[i].FCBJFKGDINH[j]);
			}
			for(int j = 0; j < s; j++)
			{
				data.MPBCJDOBKJD(j, array[i].NONBCCLGBAO[j]);
			}
			KJEKILELBAB.Add(data);
		}
		return true;
	}

	//// RVA: 0xD7A340 Offset: 0xD7A340 VA: 0xD7A340
	private bool BBFMJMIOKAN(FELHBHFOHPO POGDAGEEDPN)
	{
		BNGIGEDACFO[] array = POGDAGEEDPN.HECMHILCJME;
		for(int i = 0; i < array.Length; i++)
		{
			KPPFMKLEKLE data = new KPPFMKLEKLE();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.PGOJILPILNG = array[i].PGOJILPILNG;
			int s = array[i].ICGDOOJFHMI.Length;
			if (s > 1)
				s = 2;
			data.JPDONOHOEPD = new int[s];
			for (int j = 0; j < s; j++)
			{
				data.CDEEPLNNAIA(j, array[i].ICGDOOJFHMI[j]);
			}
			data.MDHDCMOKNFN = new int[s];
			for (int j = 0; j < s; j++)
			{
				data.AELPPMPGMKL(j, array[i].FGEBDJHJMAM[j]);
			}
			data.BLONJEJPPAC = new int[s];
			for (int j = 0; j < s; j++)
			{
				data.MMIGDOAKGMN(j, array[i].JMNDJFAOFOB[j]);
			}
			data.DNDFHJJCEAO = new int[s];
			for (int j = 0; j < s; j++)
			{
				data.PFGPMBCGEKC(j, array[i].NKLLMKMIDMH[j]);
			}
			BJKKBBPFBOL.Add(data);
		}
		return true;
	}

	//// RVA: 0xD7A874 Offset: 0xD7A874 VA: 0xD7A874
	private bool FCKLNKLLLDJ(FELHBHFOHPO POGDAGEEDPN)
	{
		DHHPKBAMAFB[] array = POGDAGEEDPN.FGMDJICNAEJ;
		for(int i = 0; i < array.Length; i++)
		{
			GGKANMNMPBB data = new GGKANMNMPBB();
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.MKPJBDFDHOL = array[i].MBNNPJBECIF;
			FOIEHFEINKI.Add(data);
		}
		return true;
	}

	// RVA: 0xD7EA48 Offset: 0xD7EA48 VA: 0xD7EA48 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0xD7EA50 Offset: 0xD7EA50 VA: 0xD7EA50 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LGHIPHEDCNC_Offer.CAOGDCBPBAN");
		return 0;
	}
}
