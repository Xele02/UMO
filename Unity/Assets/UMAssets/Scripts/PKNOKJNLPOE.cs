
using System;
using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use PKNOKJNLPOE_EventRaid", true)]
public class PKNOKJNLPOE { }
public class PKNOKJNLPOE_EventRaid : IKDICBBFBMI_EventBase
{
	public enum PGNNLIJLPFO
	{
		FNGAOJCJFJP = 0,
		AGOIOHHOPFM = 1,
		MOIGPCPOIOO = 2,
		FHCJCJIFKHL = 3,
		PNFCFJLEDEE = 4,
	}

	public class OCBPJEALCPO
	{
		public bool BBIGDCNEFMK; // 0x8
		public NHCDBBBMFFG CMCKNKKCNDK; // 0xC
		public int GKHMIECGPJO_HpAfter; // 0x10
		public int OGHIOGDPFJE_MaxHp; // 0x14
		public int FCIBJNKGMOB_Damage; // 0x18
		public int AEIMNLACMFA; // 0x1C
		public int HMNOKOEJDND; // 0x20
		public int JKLNANHPJLO_ScorePoint; // 0x24
		public int CBKFBBNPIGG_ValkyriePoint; // 0x28
		public int EAOCJMFLBJI_PointBonus; // 0x2C
		public int FOOCMHPJJAP_DivaBonus; // 0x30
		public int CLNPBIJBIIJ_SupportBonus; // 0x34
		public int HACIJLMFDAE_TotalPoint; // 0x38
		public int HALIDDHLNEG_Point; // 0x3C
		public bool PAACIPCHDDE_MissionCompleted; // 0x40
		public RhythmGameConsts.ResultComboType LCOHGOIDMDF; // 0x44
		public int ADHMMMEOJMK; // 0x48
		public int AKNELONELJK; // 0x4C
		public bool GIKLNODJKFK; // 0x50
		public int OIOPCIAGLEK_CannonBaseValue; // 0x54
		public int IHIJGIHNOAL_CannonGaugeAdd; // 0x58
		public int LFOPOHHEODG_ChargeBonus; // 0x5C
		public bool DKKJPLALNFD; // 0x60

		// public int NPPEPJHBPNE { get; } 0xFE79F0 LIBFGNGACKC
		public bool FIMNHOIJBLO { get { return CMCKNKKCNDK == NHCDBBBMFFG.HJNNKCMLGFL_0; } } //0xFE7A80 HDHHANHDMDP

		// // RVA: 0xFE7A94 Offset: 0xFE7A94 VA: 0xFE7A94
		// public void LHPDDGIJKNB() { }

		// // RVA: 0xFE7ACC Offset: 0xFE7ACC VA: 0xFE7ACC
		// public int HJBBJIOOHAI(int FKMPFOHNPPH, int BJLHPJDKBNE) { }

		// // RVA: 0xFE7AE8 Offset: 0xFE7AE8 VA: 0xFE7AE8
		// public void DEHCKHMIENO(int FNAEGLFKDBI) { }
	}

	public class KJJDLBFDGDM
	{
		public class EGMFNKCKOLB
		{
			public int PPFNGGCBJKC; // 0x8
			public int HMFFHLPNMPH_Count; // 0xC
		}
		
		public class DPAGNOHCPPH : EGMFNKCKOLB
		{
			public float ADKDHKMPMHP_Rate; // 0x10
			public bool POACKFONCAH_IsPickup; // 0x14
		}

		public List<EGMFNKCKOLB> NEAPOLIIELG_MvpRewards = new List<EGMFNKCKOLB>(); // 0x8
		public List<EGMFNKCKOLB> JAGJOLBDBDK_FirstRewards = new List<EGMFNKCKOLB>(); // 0xC
		public List<EGMFNKCKOLB> FGNHJFLBMIE_DefeatRewards = new List<EGMFNKCKOLB>(); // 0x10
		private const int CKIBIEKCKOJ = 16;
	}

	public class AAMIMFNBLKP
	{
		public int ILELGGCCGMJ; // 0x8
		public int EJGDHAENIDC; // 0xC
		public int LCJGEMENAFM; // 0x10
		public int LBEGGOOHIFM; // 0x14
		public int NOLBNKAJANK; // 0x18
		public int DFCBKNLAFIM; // 0x1C
		public int GEKJGFHKGEP; // 0x20
		public int PNHCJNAJPEM; // 0x24
	}

	public enum BKKPEJEABJN
	{
		AOFLHCJEDOA_0 = 0,
		LIFLDNIHBAK = 1,
	}

	public class KMFKFGEDPGJ
	{
		public BKKPEJEABJN INDDJNMPONH; // 0x8
		public string LBODHBDOMGK; // 0xC
		public int MLPEHNBNOGD; // 0x10
		public int GBJFCGOBHDO; // 0x14
		public int IOMHJCBMADB; // 0x18

		// public bool DNJGAJPIIPI { get; } 0xFE6B50 GALFPKKIGBH

		// // RVA: 0xFE6B40 Offset: 0xFE6B40 VA: 0xFE6B40
		// public void LHPDDGIJKNB() { }
	}

	public class MOAICCAOMCP
	{
		public class AAALCKPHGNG
		{
			public CKFGMNAIBNG IFGEJDMMAHE; // 0x8
			public bool NFAPNIKALBK; // 0xC
			private int PEBHLFLDIGC; // 0x10

			// public int DJJGNDCMNHF { get; set; } 0xFE7888 GEPCOAPEAJM

			// // RVA: 0xFE7980 Offset: 0xFE7980 VA: 0xFE7980
			// public void MIFJBBAJAJP(int NANNGLGOFKH) { }
		}

		public class LNKNJHEFBCE
		{
			public PNGOLKLFFLH IFGEJDMMAHE; // 0x8
			public bool NFAPNIKALBK; // 0xC
			private int PEBHLFLDIGC; // 0x10

			// public int DJJGNDCMNHF { get; set; } 0xFE79C0 GEPCOAPEAJM 0xFE79D4 MIFJBBAJAJP
		}

		public class JMMIEPDLLEL
		{
			public GCIJNCFDNON_SceneInfo IFGEJDMMAHE; // 0x8
			public bool NFAPNIKALBK; // 0xC
		}

		public class ELAIDDICLCD
		{
			public int PPFNGGCBJKC; // 0x8
			public string OPFGFINHFCE; // 0xC
			private int PEBHLFLDIGC; // 0x10
			public bool COHCODJHJFM; // 0x14

			// public int DJJGNDCMNHF { get; set; } 0xFE789C GEPCOAPEAJM 0xFE799C MIFJBBAJAJP
		}

		public const int CMDHDDPFCIC = 3;
		public const int NEFDMMPNGON = 3;
		public const int PABEAPABKGC = 4;
		public List<AAALCKPHGNG> FABAGMLEKIB = new List<AAALCKPHGNG>(); // 0x8
		public List<LNKNJHEFBCE> CNGNBKNBKGI = new List<LNKNJHEFBCE>(); // 0xC
		public List<ELAIDDICLCD> BBAJKJPKOHD = new List<ELAIDDICLCD>(); // 0x10
		public CIKHPBBNEIM MBPCEBPHOBB = new CIKHPBBNEIM(); // 0x14
		private CEBFFLDKAEC_SecureInt JGAOBPPCFMN = new CEBFFLDKAEC_SecureInt(); // 0x18
		private CEBFFLDKAEC_SecureInt OFKKFNKMGEB = new CEBFFLDKAEC_SecureInt(); // 0x1C
		private CEBFFLDKAEC_SecureInt MNJLHBNAFKA = new CEBFFLDKAEC_SecureInt(); // 0x20
		private CEBFFLDKAEC_SecureInt HDKPOAIAAGP = new CEBFFLDKAEC_SecureInt(); // 0x24

		public int HAAMKDOMDAB { get { return JGAOBPPCFMN.DNJEJEANJGL_Value; } set { JGAOBPPCFMN.DNJEJEANJGL_Value = value; } } //0xFE6FBC PEINACDLIFF 0xFE6FE8 HNFEAMAHDIN
		public int KMEDEGMLEBF { get { return OFKKFNKMGEB.DNJEJEANJGL_Value; } set { OFKKFNKMGEB.DNJEJEANJGL_Value = value; } } //0xFE701C AODNLPBDJDF 0xFE7048 ANLAFIAAGJB
		public int LHPJLNGEFEL { get { return MNJLHBNAFKA.DNJEJEANJGL_Value; } set { MNJLHBNAFKA.DNJEJEANJGL_Value = value; } } //0xFE707C BHKOMDIMFAF 0xFE70A8 JKPMLBAMLMH
		public int HOJAKNJFIFJ_EpisodeBonusPoint { get { return HDKPOAIAAGP.DNJEJEANJGL_Value; } set { HDKPOAIAAGP.DNJEJEANJGL_Value = value; } } //0xFE70DC MNEFIFBALEK 0xFE7108 IFNCEGFBKMP
		// public bool BNKABLIKGHL { get; } 0xFE73F0 DOBKDJONDGO
		// public bool NPKCFPMFJOB { get; } 0xFE74D4 PLOKLEEGOLO

		// RVA: 0xFE713C Offset: 0xFE713C VA: 0xFE713C
		public MOAICCAOMCP()
		{
			int v = (int)Utility.GetCurrentUnixTime() ^ 0x4341672;
			int v2 = (int)Utility.GetCurrentUnixTime() ^ 0x1288931;
			JGAOBPPCFMN.LHPDDGIJKNB_Reset(v, v2);
			OFKKFNKMGEB.LHPDDGIJKNB_Reset(v, v2);
			MNJLHBNAFKA.LHPDDGIJKNB_Reset(v, v2);
			HDKPOAIAAGP.LHPDDGIJKNB_Reset(v, v2);
			HAAMKDOMDAB = 0;
			KMEDEGMLEBF = 0;
			LHPJLNGEFEL = 0;
			HOJAKNJFIFJ_EpisodeBonusPoint = 0;
		}

		// // RVA: 0xFE75B8 Offset: 0xFE75B8 VA: 0xFE75B8
		// public void BMPJJJHAMID() { }

		// // RVA: 0xFE78B0 Offset: 0xFE78B0 VA: 0xFE78B0
		// public void EPPENPBAJPH() { }
	}

	public class FCDIHBGEKOB : IBIGBMDANNM
	{
		public int OFHFGHJEKKL; // 0x48
		public int HIMMCGKKOOL_Rate; // 0x4C

		// public int OMAGKBNHPHK { get; } 0xFE67D4 LCHNGLCHGJI
		// public int AMLMPPMBBOJ { get; } 0xFE6820 CMKEFNLIAOO
		// public int HKNHBBBLFDP { get; } 0xFE686C AMNOOLFLOBH
		// public int BFNFBOOHJCK { get; } 0xFE68B8 BJCKGODILOJ
		// public int HENMLBOMHBN { get; } 0xFE6904 LNKHHCAIOAF
		// public int DLHFIMFILEE { get; } 0xFE6970 ENCEBJOGOMP
		// public int LMJKGGFEFJJ { get; } 0xFE69EC NNGJOAKDEJE
	}

	public class MJFMOPMOFDJ : FCDIHBGEKOB
	{
		public class CALIFIMGGMD : FCDIHBGEKOB
		{
			public int HALIDDHLNEG; // 0x50
			public int FJOLNJLLJEJ; // 0x54
		}

		private const int JFMBNPLPAOB = 5;
		public int PPFNGGCBJKC; // 0x50
		public string MMEBLOIJBKE; // 0x54
		public int BCCOMAODPJI_GaugeValue; // 0x58
		public int PIKKHCGNGNN_GaugeMax; // 0x5C
		public NHCDBBBMFFG CMCKNKKCNDK; // 0x60
		public int MHABJOMJCFI_JoinedMember; // 0x64
		public long AJCCONCCIMF; // 0x68
		public int ANAJIAENLNB; // 0x70
		public int INDDJNMPONH_Type; // 0x74
		public int HPPDFBKEJCG_BgId; // 0x78
		public int FJOLNJLLJEJ_Rank; // 0x7C
		public bool IKICLMGFFPB_MissionIsSpecial; // 0x80
		public bool DLMNFENNCJG_IsEntry; // 0x81
		public bool CAKONDPGDIL; // 0x82
		public bool ICCOOAAJEIN; // 0x83
		private int[] FDAPMJJKNKG; // 0x84
		private int[] HNEPPPIEJAD; // 0x88
		public int OGLLKABGMCP; // 0x8C
		private CEBFFLDKAEC_SecureInt OMAGOLHJBDB = new CEBFFLDKAEC_SecureInt(); // 0x90
		public string BLFHMNHMDHF_Mission; // 0x94
		public string CJLHLKKNMEE_MissionText; // 0x98
		public int NFOOOBMJINC_MissionBonusNum; // 0x9C
		public int JOMGCCBFKEF; // 0xA0
		private List<CALIFIMGGMD> PIGIFFAHFCI = new List<CALIFIMGGMD>(); // 0xA4

		public int CLNPBIJBIIJ { get { return OMAGOLHJBDB.DNJEJEANJGL_Value; } set { OMAGOLHJBDB.DNJEJEANJGL_Value = value; } } //0xFE6B64 BEGALDANEBB 0xFE6B90 ODBEDHFDCCE
		public bool DNJGAJPIIPI { get { return PPFNGGCBJKC > 0; } } //0xFE6BC4 GALFPKKIGBH
		public int GCKGHNBHOPH { get; set; } // 0xA8 MABIMNPOAKL FODAJFNKMBJ BPPKEMEMLFN
		public int AEGFDINOACE_PlayerDamage { get; set; } // 0xAC FHEKPHOCOGA CCDBHBFKPEB FKFKCKOCBGA
		// public bool HIJGICMMECD { get; } 0xFE6D88 GHOEIAKFGIG
		public int IBGEJLJIAFD { get { return PIGIFFAHFCI.Count; } } //0xFE6E10 CJGBMDBLCII
		public CALIFIMGGMD BBMPCFEMDDC { get; set; } // 0xB0 AFEMAONMFDD JINDDLBIHMA ODAOJCBCLPA
		public CALIFIMGGMD NBBMHALJCMK { get; set; } // 0xB4 OKELJHOGFCO CHLPJPOIINJ FGPBGLIAGHF

		// RVA: 0xFD8330 Offset: 0xFD8330 VA: 0xFD8330
		public MJFMOPMOFDJ()
		{
			OMAGOLHJBDB.LHPDDGIJKNB_Reset((int)Utility.GetCurrentUnixTime() ^ 0x8756217, (int)Utility.GetCurrentUnixTime() ^ 0x3115581);
			CLNPBIJBIIJ = 0;
		}

		// // RVA: 0xFD6A90 Offset: 0xFD6A90 VA: 0xFD6A90
		public void LHPDDGIJKNB()
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LHPDDGIJKNB");
		}

		// // RVA: 0xFE6BD8 Offset: 0xFE6BD8 VA: 0xFE6BD8
		public long OCFJGNPMJBA_GetTime()
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OCFJGNPMJBA");
			return 0;
		}

		// // RVA: -1 Offset: -1
		// public void EMHHJNDOCMB<EffectInfoClass>(List<EffectInfoClass> OEDHCKELBJK) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1C79DD0 Offset: 0x1C79DD0 VA: 0x1C79DD0
		// |-PKNOKJNLPOE.MJFMOPMOFDJ.EMHHJNDOCMB<EBHIMFFJBIJ>
		// |-PKNOKJNLPOE.MJFMOPMOFDJ.EMHHJNDOCMB<MFKPFMCLOIB>
		// |-PKNOKJNLPOE.MJFMOPMOFDJ.EMHHJNDOCMB<object>
		// */

		// // RVA: 0xFDCD2C Offset: 0xFDCD2C VA: 0xFDCD2C
		// public static int CKHGLECNCAG(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

		// // RVA: 0xFDCD30 Offset: 0xFDCD30 VA: 0xFDCD30
		// public static int OHPCPAGKKCF(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

		// // RVA: 0xFE6CC4 Offset: 0xFE6CC4 VA: 0xFE6CC4
		// public int NKIIJMFIIAK(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

		// // RVA: 0xFE6CF0 Offset: 0xFE6CF0 VA: 0xFE6CF0
		// public int DOJHNCMHNEI(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

		// // RVA: 0xFE6D3C Offset: 0xFE6D3C VA: 0xFE6D3C
		// public int LGKOMGPLKDK(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

		// // RVA: 0xFE6E88 Offset: 0xFE6E88 VA: 0xFE6E88
		public CALIFIMGGMD PMPMADPEGDE(int OIPCCBHIKIA)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PMPMADPEGDE");
			return null;
		}

		// // RVA: 0xFE6F08 Offset: 0xFE6F08 VA: 0xFE6F08
		// public PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD JFODGOKHOEA() { }

		// // RVA: 0xFD98F0 Offset: 0xFD98F0 VA: 0xFD98F0
		// internal void PIPOJJGBGLB() { }

		// // RVA: 0xFD9984 Offset: 0xFD9984 VA: 0xFD9984
		// internal void IDALEDJHEMF(PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD GPNOEFHGOJG) { }

		// // RVA: 0xFD9A04 Offset: 0xFD9A04 VA: 0xFD9A04
		// internal void PHBGAAHPKPO(PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD GPNOEFHGOJG) { }

		// // RVA: 0xFD9A0C Offset: 0xFD9A0C VA: 0xFD9A0C
		// internal void KGPKFAFHEFP(PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD GPNOEFHGOJG) { }
	}

	private enum MALKHIMMLDI
	{
		HJNNKCMLGFL = 0,
		NPGGGMACPLD = 1,
		OOEHFFBHCIC = 2,
	}

	public class ECICDAPCMJG
	{
		public string LBODHBDOMGK; // 0x8
		public int MLPEHNBNOGD; // 0xC
		public bool HKAIJKGODHC; // 0x10
		public int GFDDPMCEJCI; // 0x14
	}

	public delegate void OGFPKBBOFFH(List<ECICDAPCMJG> GOOOMIHPBPM);

	public enum IEJAFPGDGNP
	{
		NIHKBNNICFB_0 = 0,
		DBPDLIPKFAL_1 = 1,
		FGPLEPGICPO_2 = 2,
	}

	private class GAPINAADMPJ
	{
		public BKOGPDBKFFJ_EventRaid.LDCCKEPPFMG.NEGFCJPAPLC IDLHJIOMJBK; // 0x8
		public int HMFFHLPNMPH; // 0xC
	}

	// private const int GHJHJDIDCFA = 3;
	// public const int EGJPAEHGDEL = 40;
	// private const int EBPEOLODPNN = 1000;
	// private EECOJKDJIFG KBACNOCOANM; // 0xE8
	// private BBHNACPENDM FPPNANIIODA = new BBHNACPENDM(); // 0xEC
	// private KAFHAKBBJEI JIMJHIDEHNM; // 0xF0
	// private GameAttribute.Type IEDBMNIBDPD; // 0xF8
	// public int HENFOBHBABA; // 0xFC
	// public int AKHNDMEHHLF; // 0x100
	// private List<PKNOKJNLPOE.KMFKFGEDPGJ> CBPJPNIFJOI = new List<PKNOKJNLPOE.KMFKFGEDPGJ>(8); // 0x10C
	// public bool EGOJLOEFMOH; // 0x114
	// public int BCBCODAKIDN; // 0x118
	// public bool KIBBLLADDPO; // 0x11C
	// public PKNOKJNLPOE.MJFMOPMOFDJ MCEJJBANCDA; // 0x120
	public int NENNACLBKJJ; // 0x124
	// private PKNOKJNLPOE.MJFMOPMOFDJ PBJBHONLMKF = new PKNOKJNLPOE.MJFMOPMOFDJ(); // 0x128
	// private List<PKNOKJNLPOE.MJFMOPMOFDJ> ECPHFLNMECN = new List<PKNOKJNLPOE.MJFMOPMOFDJ>(); // 0x12C
	// private HighScoreRating JJGJJALILHC = new HighScoreRating(); // 0x138
	// private uint PMBEODGMMBB = 0x15ab17a1; // 0x140

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid; } } // DKHCGLCNKCD  Slot: 4
	// public JKIJLMMLNPL GGDBEANLCPC { get; set; } // 0xF4 KOEMHFFCFBI
	// public PKNOKJNLPOE.OCBPJEALCPO PLFBKEPLAAA { get; set; } // 0x104 KPJIFMDECLG
	// public PKNOKJNLPOE.KJJDLBFDGDM KONJMFICNJJ { get; set; } // 0x108 BJFFFIBNLLH
	// public List<PKNOKJNLPOE.KMFKFGEDPGJ> FKLEEMCDKNF { get; }
	// public PKNOKJNLPOE.MOAICCAOMCP ANMBIEIFKFF { get; set; } // 0x110 BFEMMFOALFE
	// public bool NNNMHHHBIIB { get; }
	// public int CALECMAEBIH { get; }
	// public int HIGDPLMLING { get; }
	// public int OKEGPFAIOCF { get; }
	// public JLOGEHCIBEJ.JJAFLOEBLDH CFLEMFADGLG { get; set; } // 0x130 GEJKDKKDHBI
	// public PKNOKJNLPOE.MJFMOPMOFDJ JIBMOEHKMGB { get; set; } // 0x134 FKHECGJBFAD
	// public int HKMFDIEOKNM { get; set; } // 0x13C FKCJFJMCNJA
	// public bool NKNJACLMNDG { get; }
	// public bool KLOEKHMPJDJ { get; }
	// public bool CHMMBIEFFHB { get; }
	// public bool JHLLDEFENMP { get; }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD29C Offset: 0x6BD29C VA: 0x6BD29C
	// // RVA: 0x94007C Offset: 0x94007C VA: 0x94007C
	public JKIJLMMLNPL MBNLPELOLBJ()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MBNLPELOLBJ");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2AC Offset: 0x6BD2AC VA: 0x6BD2AC
	// // RVA: 0x940084 Offset: 0x940084 VA: 0x940084
	// private void PFNPAAKMGJF(JKIJLMMLNPL NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2BC Offset: 0x6BD2BC VA: 0x6BD2BC
	// // RVA: 0x94008C Offset: 0x94008C VA: 0x94008C
	public OCBPJEALCPO NAMEFMANAKG()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NAMEFMANAKG");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2CC Offset: 0x6BD2CC VA: 0x6BD2CC
	// // RVA: 0x940094 Offset: 0x940094 VA: 0x940094
	// private void NPIFONLKBLN(PKNOKJNLPOE.OCBPJEALCPO NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2DC Offset: 0x6BD2DC VA: 0x6BD2DC
	// // RVA: 0x94009C Offset: 0x94009C VA: 0x94009C
	public KJJDLBFDGDM KLDMMPJKHEO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KLDMMPJKHEO");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2EC Offset: 0x6BD2EC VA: 0x6BD2EC
	// // RVA: 0x9400A4 Offset: 0x9400A4 VA: 0x9400A4
	// private void PKGMFMELDEN(PKNOKJNLPOE.KJJDLBFDGDM NANNGLGOFKH) { }

	// // RVA: 0x9400AC Offset: 0x9400AC VA: 0x9400AC
	public List<KMFKFGEDPGJ> DIFIHMCHDJF()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DIFIHMCHDJF");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD2FC Offset: 0x6BD2FC VA: 0x6BD2FC
	// // RVA: 0x9400B4 Offset: 0x9400B4 VA: 0x9400B4
	public MOAICCAOMCP PDPEPHAMKEB()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PDPEPHAMKEB");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD30C Offset: 0x6BD30C VA: 0x6BD30C
	// // RVA: 0x9400BC Offset: 0x9400BC VA: 0x9400BC
	// private void JNEELMEBJFI(PKNOKJNLPOE.MOAICCAOMCP NANNGLGOFKH) { }

	// // RVA: 0x9400C4 Offset: 0x9400C4 VA: 0x9400C4
	// public bool NMDNCFGEJGJ() { }

	// // RVA: 0x9400D4 Offset: 0x9400D4 VA: 0x9400D4 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DAKMIKNKHMF");
		return null;
	}

	// RVA: 0x9400DC Offset: 0x9400DC VA: 0x9400DC
	public PKNOKJNLPOE_EventRaid(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
		if(FJLIDJJAGOM() != null)
		{
        	TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid()");
		}
    }

	// // RVA: 0x940304 Offset: 0x940304 VA: 0x940304
	private BKOGPDBKFFJ_EventRaid FJLIDJJAGOM()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(db != null)
		{
			return db as BKOGPDBKFFJ_EventRaid;
		}
		return null;
	}

	// // RVA: 0x940418 Offset: 0x940418 VA: 0x940418
	// private JLOGEHCIBEJ.PMJBKKNNNEM KNKJHNJFONJ() { }

	// // RVA: 0x940430 Offset: 0x940430 VA: 0x940430
	// private JLOGEHCIBEJ.PMJBKKNNNEM KNKJHNJFONJ(BKOGPDBKFFJ NDFIEMPPMLF) { }

	// // RVA: 0x94055C Offset: 0x94055C VA: 0x94055C Slot: 5
	public override string IFKKBHPMALH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "IFKKBHPMALH");
		return null;
	}

	// // RVA: 0x9406A4 Offset: 0x9406A4 VA: 0x9406A4
	// private void BLNLNMLJIKO() { }

	// // RVA: 0x940834 Offset: 0x940834 VA: 0x940834 Slot: 6
	public override string DCODGEOEDPG()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DCODGEOEDPG");
		return null;
	}

	// // RVA: 0x94097C Offset: 0x94097C VA: 0x94097C Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HEACCHAKMFG");
		return base.HEACCHAKMFG_GetMusicsList();
	}

	// // RVA: 0x940984 Offset: 0x940984 VA: 0x940984
	// public List<int> HEACCHAKMFG(int MFMPCHIJINJ) { }

	// // RVA: 0x940D44 Offset: 0x940D44 VA: 0x940D44
	public int KFBDBBCCPBB(int MFMPCHIJINJ)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KFBDBBCCPBB");
		return 0;
	}

	// // RVA: 0x940ED0 Offset: 0x940ED0 VA: 0x940ED0 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HOOBCIIOCJD");
		return 0;
	}

	// // RVA: 0x9412E0 Offset: 0x9412E0 VA: 0x9412E0 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GIDDKGMPIOK");
		return false;
	}

	// // RVA: 0x941710 Offset: 0x941710 VA: 0x941710 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HLOGNJNGDJO");
		return 0;
	}

	// // RVA: 0x94188C Offset: 0x94188C VA: 0x94188C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FBGDBGKNKOD");
		return 0;
	}

	// // RVA: 0x941AA8 Offset: 0x941AA8 VA: 0x941AA8 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MJFKJHJJLMN");
	}

	// // RVA: 0x941F28 Offset: 0x941F28 VA: 0x941F28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(db != null)
		{
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.JIHMLILFOPG");
		}
		return false;
	}

	// // RVA: 0x9421F0 Offset: 0x9421F0 VA: 0x9421F0 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IMCMNOPNGHO");
		return false;
	}

	// // RVA: 0x942614 Offset: 0x942614 VA: 0x942614 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KKFLDCBHFJA");
	}

	// // RVA: 0x943284 Offset: 0x943284 VA: 0x943284 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FCHGHAAPIBH");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD31C Offset: 0x6BD31C VA: 0x6BD31C
	// // RVA: 0x9433E8 Offset: 0x9433E8 VA: 0x9433E8 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JEIJKLPOAHP_ReceivePrologueRepeatedAchievement");
		yield break;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD394 Offset: 0x6BD394 VA: 0x6BD394
	// // RVA: 0x94348C Offset: 0x94348C VA: 0x94348C Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement");
		yield break;
	}

	// // RVA: 0x943530 Offset: 0x943530 VA: 0x943530 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PJDGDNJNCNM");
	}

	// // RVA: 0x943B38 Offset: 0x943B38 VA: 0x943B38 Slot: 48
	public override void AMKJFGLEJGE(int KPIILHGOGJD)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "AMKJFGLEJGE");
	}

	// // RVA: 0x943F40 Offset: 0x943F40 VA: 0x943F40 Slot: 49
	// protected override void ODPJGHOJIOH(int LHJCOPMMIGO) { }

	// // RVA: 0x944290 Offset: 0x944290 VA: 0x944290 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FAMFKPBPIAA");
	}

	// // RVA: 0x944574 Offset: 0x944574 VA: 0x944574 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JPNACOLKHLB");
	}

	// // RVA: 0x944770 Offset: 0x944770 VA: 0x944770
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC) { }

	// // RVA: 0x943398 Offset: 0x943398 VA: 0x943398
	// private void PIMFJALCIGK() { }

	// // RVA: 0x944868 Offset: 0x944868 VA: 0x944868
	// private void BJEOAOACMGG(int LHJCOPMMIGO) { }

	// // RVA: 0x944C94 Offset: 0x944C94 VA: 0x944C94 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LMGMELPOGMH");
	}

	// // RVA: 0x944FD0 Offset: 0x944FD0 VA: 0x944FD0
	// public KAMKMOKMPAN.GGPEAOAOEPH BPOCKIHHJKH() { }

	// // RVA: 0x9451E8 Offset: 0x9451E8 VA: 0x9451E8
	// public void JMEPDDLGPJF(KAMKMOKMPAN.GGPEAOAOEPH LGADCGFMLLD) { }

	// // RVA: 0x945404 Offset: 0x945404 VA: 0x945404 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JLPDECMHLIM");
		return false;
	}

	// // RVA: 0x9456FC Offset: 0x9456FC VA: 0x9456FC Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FGDDBFHGCGP");
	}

	// // RVA: 0x94593C Offset: 0x94593C VA: 0x94593C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ADACMHAHHKC");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD40C Offset: 0x6BD40C VA: 0x6BD40C
	// // RVA: 0x945994 Offset: 0x945994 VA: 0x945994
	// private IEnumerator NJIEIJJMAHK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x945A4C Offset: 0x945A4C VA: 0x945A4C Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MPMKJNJGFEF");
		return false;
	}

	// // RVA: 0x945C68 Offset: 0x945C68 VA: 0x945C68 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x945D90 Offset: 0x945D90 VA: 0x945D90 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BAEPGOAMBDK");
		return 0;
	}

	// // RVA: 0x945ED4 Offset: 0x945ED4 VA: 0x945ED4 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MAICAKMIBEM");
		return MNCOAGOKNAO;
	}

	// // RVA: 0x946018 Offset: 0x946018 VA: 0x946018 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GJMGKBDGMOP");
		return false;
	}

	// // RVA: 0x9467BC Offset: 0x9467BC VA: 0x9467BC
	// public int JCBDKEPCLKG() { }

	// // RVA: 0x946830 Offset: 0x946830 VA: 0x946830
	// public void HEOFEABCBCC(out int GEJGMBBCFEE, out int CCIHMCAPHCB) { }

	// // RVA: 0x946A94 Offset: 0x946A94 VA: 0x946A94 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FEKEBPKINIM");
		return "";
	}

	// // RVA: 0x946CBC Offset: 0x946CBC VA: 0x946CBC Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId);
		if(dbSection == null)
			return null;
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IJCPBPFEGDM");
		return null;
	}

	// // RVA: 0x946F98 Offset: 0x946F98 VA: 0x946F98 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EDNMFMBLCGF");
		return 0;
	}

	// // RVA: 0x94720C Offset: 0x94720C VA: 0x94720C
	// private void CPOAJKMPPMF(int GHBPLHBNMBK) { }

	// // RVA: 0x947418 Offset: 0x947418 VA: 0x947418
	// public int EOAMLLMMCPD() { }

	// // RVA: 0x947624 Offset: 0x947624 VA: 0x947624
	// public void EHADIPOAOEA() { }

	// // RVA: 0x947920 Offset: 0x947920 VA: 0x947920
	// private int JKPDCKDMKBN() { }

	// // RVA: 0x947C94 Offset: 0x947C94 VA: 0x947C94 Slot: 76
	public override void MMIMJPNLKBK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MMIMJPNLKBK");
	}

	// // RVA: 0x947ECC Offset: 0x947ECC VA: 0x947ECC Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DBEMCLMPCFA");
		return "";
	}

	// // RVA: 0x9481F0 Offset: 0x9481F0 VA: 0x9481F0
	// public int NMLIONILBMC() { }

	// // RVA: 0x948238 Offset: 0x948238 VA: 0x948238
	public string AGEJGHGEGFF_GetBossName(int MFMPCHIJINJ)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "AGEJGHGEGFF");
		return "";
	}

	// // RVA: 0x9482D8 Offset: 0x9482D8 VA: 0x9482D8
	public SeriesAttr.Type NNDFMCHDJOH_GetBossSerie(int MFMPCHIJINJ)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NNDFMCHDJOH");
		return 0;
	}

	// // RVA: 0x948320 Offset: 0x948320 VA: 0x948320
	// public bool BMDEELGBBOI(int MFMPCHIJINJ) { }

	// // RVA: 0x948370 Offset: 0x948370 VA: 0x948370
	public int KNNHGJFJAEN_GetNumBosses()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KNNHGJFJAEN");
		return 0;
	}

	// // RVA: 0x948400 Offset: 0x948400 VA: 0x948400
	// private static bool MFAFEBNEEHE(int MLPEHNBNOGD) { }

	// // RVA: 0x9484B0 Offset: 0x9484B0 VA: 0x9484B0
	public string ICCEILFHKEL()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "ICCEILFHKEL");
		return "";
	}

	// // RVA: 0x948548 Offset: 0x948548 VA: 0x948548
	public MJFMOPMOFDJ PMIIMELDPAJ_GetMyBoss()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PMIIMELDPAJ");
		return null;
	}

	// // RVA: 0x948550 Offset: 0x948550 VA: 0x948550
	public MJFMOPMOFDJ HCFDHLNNDAN(int OIPCCBHIKIA)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HCFDHLNNDAN");
		return null;
	}

	// // RVA: 0x9485D0 Offset: 0x9485D0 VA: 0x9485D0
	public int EHJOBALDPBG()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EHJOBALDPBG");
		return 0;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD484 Offset: 0x6BD484 VA: 0x6BD484
	// // RVA: 0x948648 Offset: 0x948648 VA: 0x948648
	public JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH KAHCHHILDEM()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KAHCHHILDEM");
		return JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD494 Offset: 0x6BD494 VA: 0x6BD494
	// // RVA: 0x948650 Offset: 0x948650 VA: 0x948650
	// private void MDOJKNFKJGE(JLOGEHCIBEJ.JJAFLOEBLDH NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD4A4 Offset: 0x6BD4A4 VA: 0x6BD4A4
	// // RVA: 0x948230 Offset: 0x948230 VA: 0x948230
	public MJFMOPMOFDJ KACFOENGHIK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KACFOENGHIK");
		return null;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD4B4 Offset: 0x6BD4B4 VA: 0x6BD4B4
	// // RVA: 0x948658 Offset: 0x948658 VA: 0x948658
	// private void ILADGLDGCLL(PKNOKJNLPOE.MJFMOPMOFDJ NANNGLGOFKH) { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD4C4 Offset: 0x6BD4C4 VA: 0x6BD4C4
	// // RVA: 0x948660 Offset: 0x948660 VA: 0x948660
	// public int EFKMGOOLCKO() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD4D4 Offset: 0x6BD4D4 VA: 0x6BD4D4
	// // RVA: 0x948668 Offset: 0x948668 VA: 0x948668
	// private void LAGMLHCALKF(int NANNGLGOFKH) { }

	// // RVA: 0x948670 Offset: 0x948670 VA: 0x948670
	// private BKOGPDBKFFJ.MNFPNLMPOEB CMMDPDMNNKP(BKOGPDBKFFJ NDFIEMPPMLF, JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

	// // RVA: 0x948700 Offset: 0x948700 VA: 0x948700
	public int EMJEBMMMDBE(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "EMJEBMMMDBE");
		return 0;
	}

	// // RVA: 0x948748 Offset: 0x948748 VA: 0x948748
	public int AFODCOIFHKO(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "AFODCOIFHKO");
		return 0;
	}

	// // RVA: 0x948790 Offset: 0x948790 VA: 0x948790
	public int MCBGNPBECCI_SupportBonusMax()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MCBGNPBECCI");
		return 0;
	}

	// // RVA: 0x948810 Offset: 0x948810 VA: 0x948810
	// public bool APGPNCKBADI(out DateTime FKPEAGGKNLC, out DateTime KOMKKBDABJP) { }

	// // RVA: 0x948984 Offset: 0x948984 VA: 0x948984
	public bool FJBIJAGCGKC()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "FJBIJAGCGKC");
		return false;
	}

	// // RVA: 0x948C30 Offset: 0x948C30 VA: 0x948C30
	public int NPICFLFAIJK()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NPICFLFAIJK");
		return 0;
	}

	// // RVA: 0x948D40 Offset: 0x948D40 VA: 0x948D40
	public bool KBFCALJDLPH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KBFCALJDLPH");
		return false;
	}

	// // RVA: 0x948D94 Offset: 0x948D94 VA: 0x948D94
	// private bool IBGMIDDJECI() { }

	// // RVA: 0x948EAC Offset: 0x948EAC VA: 0x948EAC
	// private void KHPCBKAEGBC() { }

	// // RVA: 0x948FBC Offset: 0x948FBC VA: 0x948FBC
	public void KECLCFBKMOA(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK IILBGCMIEDJ)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KECLCFBKMOA");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD4E4 Offset: 0x6BD4E4 VA: 0x6BD4E4
	// // RVA: 0x949024 Offset: 0x949024 VA: 0x949024
	// private IEnumerator IDNENICNGHO(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK IILBGCMIEDJ) { }

	// // RVA: 0x9490F8 Offset: 0x9490F8 VA: 0x9490F8
	// private string JLIICBOHICB() { }

	// // RVA: 0x9497EC Offset: 0x9497EC VA: 0x9497EC
	public void CFKCMIBJOIA(out int LCIIDGAPDCN, out int OGOHJAFOEPG)
	{
		LCIIDGAPDCN = 0;
		OGOHJAFOEPG = 0;
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.CFKCMIBJOIA");
	}

	// // RVA: 0x9498A8 Offset: 0x9498A8 VA: 0x9498A8
	public void FGIHOCHKKMD(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.FGIHOCHKKMD");
	}

	// // RVA: 0x949CE0 Offset: 0x949CE0 VA: 0x949CE0
	// private void OFAHKDKDGAN(PKNOKJNLPOE.FCDIHBGEKOB BCGAOHJKPIG, BBHNACPENDM AHEFHIMGIBI) { }

	// // RVA: 0x949E80 Offset: 0x949E80 VA: 0x949E80
	// private void NBPANDOEDJH(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI, LBICPMOLOKD CHCEIJOJDHL) { }

	// // RVA: 0x94A118 Offset: 0x94A118 VA: 0x94A118
	// private void FMGJILBBNBJ(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI) { }

	// // RVA: 0x94A284 Offset: 0x94A284 VA: 0x94A284
	// private void HCKEDINDNAP(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI) { }

	// // RVA: 0x94A698 Offset: 0x94A698 VA: 0x94A698
	public void AIMIFGFHBCE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.AIMIFGFHBCE");
	}

	// // RVA: 0x94A938 Offset: 0x94A938 VA: 0x94A938
	// private void KDBBGILHMNL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94AE74 Offset: 0x94AE74 VA: 0x94AE74
	// private void IHMDJENFJIG(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94B58C Offset: 0x94B58C VA: 0x94B58C
	// private void EGBLOJJIKKJ(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94BA5C Offset: 0x94BA5C VA: 0x94BA5C
	// private bool NLEFCEBIGGO() { }

	// // RVA: 0x94BB48 Offset: 0x94BB48 VA: 0x94BB48
	// public void EPLLCEFGKBH(Action<bool> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94BC24 Offset: 0x94BC24 VA: 0x94BC24
	// public void GMIPFKHCDCA(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94BD00 Offset: 0x94BD00 VA: 0x94BD00
	public void AMBHKLLAJID(Action<int, int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.AMBHKLLAJID");
	}

	// // RVA: 0x949A88 Offset: 0x949A88 VA: 0x949A88
	// private void IEFFGONGBCD(Action<List<NCMFOICNJEB<EBHIMFFJBIJ>>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94BDF4 Offset: 0x94BDF4 VA: 0x94BDF4
	// public void ENBNOMKDLFC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94BE20 Offset: 0x94BE20 VA: 0x94BE20
	public void PDPFNKCIJOP(MJFMOPMOFDJ DACHLLPBFPI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{

		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PDPFNKCIJOP");
	}

	// // RVA: 0x94BE48 Offset: 0x94BE48 VA: 0x94BE48
	public void GKCEHODEPMJ(bool EKPADKHKCKO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GKCEHODEPMJ");
	}

	// // RVA: 0x94AB1C Offset: 0x94AB1C VA: 0x94AB1C
	// private void DOECBDLGILJ(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI, PKNOKJNLPOE.MALKHIMMLDI CNDDKMJAIBG, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94BE74 Offset: 0x94BE74 VA: 0x94BE74
	public bool LMIFOCDCNAI()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.LMIFOCDCNAI");
		return true;
	}

	// // RVA: 0x94C404 Offset: 0x94C404 VA: 0x94C404
	public void MCKDAPPELKJ(bool PJJLOFMLOMN, bool MCMPOEHAIHP, OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.MCKDAPPELKJ");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD55C Offset: 0x6BD55C VA: 0x6BD55C
	// // RVA: 0x94C54C Offset: 0x94C54C VA: 0x94C54C
	// private IEnumerator FMLIOLJNADH(bool PJJLOFMLOMN, bool MCMPOEHAIHP, PKNOKJNLPOE.OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD5D4 Offset: 0x6BD5D4 VA: 0x6BD5D4
	// // RVA: 0x94C6C4 Offset: 0x94C6C4 VA: 0x94C6C4
	// private IEnumerator BBMJANLENGH(bool PJJLOFMLOMN, bool MCMPOEHAIHP, PKNOKJNLPOE.OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF) { }

	// // RVA: 0x94C838 Offset: 0x94C838 VA: 0x94C838
	// private void LKDGDNOOGND(List<int> EJIBHPFHDKC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94CC78 Offset: 0x94CC78 VA: 0x94CC78
	// public int CBDMCDKKFBE(JLOGEHCIBEJ.JJAFLOEBLDH INDDJNMPONH) { }

	// // RVA: 0x94D014 Offset: 0x94D014 VA: 0x94D014
	public int CBDMCDKKFBE_GetNeedAp()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.CBDMCDKKFBE");
		return 0;
	}

	// // RVA: 0x94D01C Offset: 0x94D01C VA: 0x94D01C
	public void FDNIODNLDAI(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.FDNIODNLDAI");
	}

	// // RVA: 0x94D024 Offset: 0x94D024 VA: 0x94D024
	public void KMDELKHBDNN(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ DACHLLPBFPI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KMDELKHBDNN");
	}

	// // RVA: 0x94D02C Offset: 0x94D02C VA: 0x94D02C
	// public void LGJNILBEIKA(JLOGEHCIBEJ.JJAFLOEBLDH CFLEMFADGLG, int HALIDDHLNEG, bool NFHDKELECKO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK AOCANKOMKFG, string MDADLCOCEBN) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD64C Offset: 0x6BD64C VA: 0x6BD64C
	// // RVA: 0x94D0A8 Offset: 0x94D0A8 VA: 0x94D0A8
	// private IEnumerator ICBALAJFBND(JLOGEHCIBEJ.JJAFLOEBLDH CFLEMFADGLG, int HALIDDHLNEG, bool NFHDKELECKO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK AOCANKOMKFG, string MDADLCOCEBN) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BD6C4 Offset: 0x6BD6C4 VA: 0x6BD6C4
	// // RVA: 0x94D1E4 Offset: 0x94D1E4 VA: 0x94D1E4
	// private IEnumerator NEADNOHFNJH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94D288 Offset: 0x94D288 VA: 0x94D288
	// public void GNANMKPFDFE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int BMMPAHHEOJC, string MDADLCOCEBN, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94D38C Offset: 0x94D38C VA: 0x94D38C
	// private int ADNLNFMJHLM(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int BMMPAHHEOJC) { }

	// // RVA: 0x94DC5C Offset: 0x94DC5C VA: 0x94DC5C
	public void JKBOOMAPOBL(MJFMOPMOFDJ DACHLLPBFPI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "JKBOOMAPOBL");
	}

	// // RVA: 0x94DDB0 Offset: 0x94DDB0 VA: 0x94DDB0
	// private void HPBDHJCICPA(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI, bool MCBICECCNGO, bool KHJPDCEFKMJ, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94DF34 Offset: 0x94DF34 VA: 0x94DF34
	// private NKOBMDPHNGP.PEDPKDBKGIN HBJDIGBFNMP(PKNOKJNLPOE.OCBPJEALCPO LGHNGDCBDKI, PKNOKJNLPOE.MJFMOPMOFDJ BFPPAPMNEHA, bool KHJPDCEFKMJ) { }

	// // RVA: 0x94E18C Offset: 0x94E18C VA: 0x94E18C
	// private uint FBGGEFFJJHB() { }

	// // RVA: 0x94A47C Offset: 0x94A47C VA: 0x94A47C
	// private int BCDFFKCOOFB(int KCNAEONFIBP, bool MPKBLMCNHOM) { }

	// // RVA: 0x94E1A8 Offset: 0x94E1A8 VA: 0x94E1A8
	// private void IPEIKLJLCJL(int KCNAEONFIBP, bool MPKBLMCNHOM) { }

	// // RVA: 0x94D978 Offset: 0x94D978 VA: 0x94D978
	// private int OIPALKMEJCA(int KCNAEONFIBP, bool MPKBLMCNHOM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0x94E25C Offset: 0x94E25C VA: 0x94E25C
	// private int DPJFFBMCAAL(BKOGPDBKFFJ NDFIEMPPMLF, int MFMPCHIJINJ, PKNOKJNLPOE.IEJAFPGDGNP KDIGPMIABEI) { }

	// // RVA: 0x94E2F0 Offset: 0x94E2F0 VA: 0x94E2F0
	// private void DKBAOFGBPHO(PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI) { }

	// // RVA: 0x94EC44 Offset: 0x94EC44 VA: 0x94EC44
	// private List<PKNOKJNLPOE.KJJDLBFDGDM.EGMFNKCKOLB> NLDMEJLFFHD(BKOGPDBKFFJ NDFIEMPPMLF, int IBPFNNADAKM, int KPIHBPMOGKL) { }

	// // RVA: 0x94F478 Offset: 0x94F478 VA: 0x94F478
	public List<KJJDLBFDGDM.DPAGNOHCPPH> CMDOFKLCFEB_GetBossRewards(int MFMPCHIJINJ, IEJAFPGDGNP KDIGPMIABEI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.CMDOFKLCFEB");
		return null;
	}

	// // RVA: 0x94F7FC Offset: 0x94F7FC VA: 0x94F7FC
	public List<AAMIMFNBLKP> PNHPJDMNEPH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.PNHPJDMNEPH");
		return null;
	}

	// // RVA: 0x94FAA8 Offset: 0x94FAA8 VA: 0x94FAA8
	public void HAPDLPAKMLF(out int GGNOGNOBJLP, out int HLANCDFJFIA, out bool ANKEMCJFFIO)
	{
		GGNOGNOBJLP = 0;
		HLANCDFJFIA = 0;
		ANKEMCJFFIO = false;
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.HAPDLPAKMLF");
	}

	// // RVA: 0x94FABC Offset: 0x94FABC VA: 0x94FABC
	// public void HOOENJBGDGM(int OEOIHIIIMCK) { }

	// // RVA: 0x94FAC8 Offset: 0x94FAC8 VA: 0x94FAC8
	public bool IOGPHNLODAF(bool DDGFCOPPBBN/* = True*/)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IOGPHNLODAF");
		return true;
	}

	// // RVA: 0x94B0D4 Offset: 0x94B0D4 VA: 0x94B0D4
	// private PKNOKJNLPOE.KMFKFGEDPGJ IHPJMEKNJLP() { }

	// // RVA: 0x94FAD4 Offset: 0x94FAD4 VA: 0x94FAD4
	public void EMEAEENFOOM()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.EMEAEENFOOM");
	}

	// // RVA: 0x94FCB4 Offset: 0x94FCB4 VA: 0x94FCB4
	public void JDGCABLBFLH(IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION HJBGFEANGMJ, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.JDGCABLBFLH");
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD73C Offset: 0x6BD73C VA: 0x6BD73C
	// // RVA: 0x94FD1C Offset: 0x94FD1C VA: 0x94FD1C
	// private IEnumerator FCCGJKNALLC(IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION HJBGFEANGMJ, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94FDF0 Offset: 0x94FDF0 VA: 0x94FDF0
	public void JFJDHJNNMON()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.JFJDHJNNMON");
	}

	// // RVA: 0x9504A4 Offset: 0x9504A4 VA: 0x9504A4
	// public void OPJCFOHGPPE() { }

	// // RVA: 0x9506D4 Offset: 0x9506D4 VA: 0x9506D4
	// public void PAIFGFONEMJ(int CEHNJCIIKDN) { }

	// // RVA: 0x95090C Offset: 0x95090C VA: 0x95090C
	public void CCJKIDIFDKO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.CCJKIDIFDKO");
	}

	// // RVA: 0x950938 Offset: 0x950938 VA: 0x950938
	public void IMAHHNBOCGG_UpdateUnitBonus()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IMAHHNBOCGG");
	}

	// // RVA: 0x951234 Offset: 0x951234 VA: 0x951234
	public void NDCKGHGLHKN_UpdateUnitBonus(int CEHNJCIIKDN)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.NDCKGHGLHKN");
	}

	// // RVA: 0x9509FC Offset: 0x9509FC VA: 0x9509FC
	// private void IMAHHNBOCGG(JLKEOGLJNOD MLAFAACKKBG, int CEHNJCIIKDN = -1) { }

	// // RVA: 0x951310 Offset: 0x951310 VA: 0x951310
	// public bool DBNGGBFOAPG() { }

	// // RVA: 0x951320 Offset: 0x951320 VA: 0x951320
	public void LHEPBBADNIH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.LHEPBBADNIH");
	}

	// // RVA: 0x951424 Offset: 0x951424 VA: 0x951424
	public int HGJAGDPPALF_GetApNum()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.HGJAGDPPALF");
		return 0;
	}

	// // RVA: 0x951458 Offset: 0x951458 VA: 0x951458
	public long DMNDFBJODBA()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.DMNDFBJODBA");
		return 0;
	}

	// // RVA: 0x95148C Offset: 0x95148C VA: 0x95148C
	public long EIEDIDECECD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.EIEDIDECECD");
		return 0;
	}

	// // RVA: 0x9514B8 Offset: 0x9514B8 VA: 0x9514B8
	// public void IBMOHKFJDDH() { }

	// // RVA: 0x951568 Offset: 0x951568 VA: 0x951568
	// public void IBMOHKFJDDH(MCGNOFMAPBJ OBFMBNJEOEC) { }

	// // RVA: 0x9514C0 Offset: 0x9514C0 VA: 0x9514C0
	// private void FNHJDCGHNCF(MCGNOFMAPBJ OBFMBNJEOEC) { }

	// // RVA: 0x95156C Offset: 0x95156C VA: 0x95156C
	// public bool MACJBPDFCAI(int CHIHFGDIBJM, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x9515A8 Offset: 0x9515A8 VA: 0x9515A8
	// public bool MGIKKAGFGCF(bool DDGFCOPPBBN = True, PKNOKJNLPOE.MJFMOPMOFDJ DACHLLPBFPI) { }

	// // RVA: 0x9515D4 Offset: 0x9515D4 VA: 0x9515D4
	// public void DFNENEFLKPO() { }

	// // RVA: 0x951664 Offset: 0x951664 VA: 0x951664
	// public void BBLIJFBIACE() { }

	// // RVA: 0x9516F4 Offset: 0x9516F4 VA: 0x9516F4
	// public bool LIAJFGCJJIM() { }

	// // RVA: 0x951724 Offset: 0x951724 VA: 0x951724
	public bool LIAJFGCJJIM(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LIAJFGCJJIM");
		return false;
	}

	// // RVA: 0x9517B0 Offset: 0x9517B0 VA: 0x9517B0
	// public void KIGJMPILEFC(int KCNAEONFIBP) { }

	// // RVA: 0x94C198 Offset: 0x94C198 VA: 0x94C198
	public int HEMEDMMBIBH_GetBossHelpCount(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HEMEDMMBIBH");
		return 0;
	}

	// // RVA: 0x951828 Offset: 0x951828 VA: 0x951828
	// public void JIOEILLGDCG(long IEHACMMICFI, int KAIMDDPJEON = 0) { }

	// // RVA: 0x94C00C Offset: 0x94C00C VA: 0x94C00C
	public long GCDHLLHHIHA(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GCDHLLHHIHA");
		return 0;
	}

	// // RVA: 0x94C2C0 Offset: 0x94C2C0 VA: 0x94C2C0
	public bool KIHAEAEEFJE(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "KIHAEAEEFJE");
		return false;
	}

	// // RVA: 0x9518D8 Offset: 0x9518D8 VA: 0x9518D8
	// public void JDDCHPCBKLM(int KCNAEONFIBP) { }

	// // RVA: 0x94CDD0 Offset: 0x94CDD0 VA: 0x94CDD0
	// public bool ACDLEBPMEIH(PKNOKJNLPOE.MJFMOPMOFDJ OFLJBDDKMII) { }

	// // RVA: 0x9519EC Offset: 0x9519EC VA: 0x9519EC
	public int BFPIHPBKEGK_GetApMax()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BFPIHPBKEGK");
		return 0;
	}

	// // RVA: 0x951A18 Offset: 0x951A18 VA: 0x951A18
	public int COEIAHBIFBN(int KIJAPOFAGPN, CIOECGOMILE.LIILJGHKIDL DCIBKKDLNCI/* = 0*/)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "COEIAHBIFBN");
		return 0;
	}

	// // RVA: 0x951B80 Offset: 0x951B80 VA: 0x951B80
	// public bool DOOGIEBPLDE() { }

	// // RVA: 0x951BB4 Offset: 0x951BB4 VA: 0x951BB4
	// public static bool BPDABBKNFOI(RaidItemConstants.Type INDDJNMPONH) { }

	// // RVA: 0x951CE0 Offset: 0x951CE0 VA: 0x951CE0
	// public void FEFCBFNLDEP(MCGNOFMAPBJ OBFMBNJEOEC) { }

	// // RVA: 0x951D14 Offset: 0x951D14 VA: 0x951D14
	// public void JIHGDCFBGCK(MCGNOFMAPBJ OBFMBNJEOEC) { }

	// // RVA: 0x951D48 Offset: 0x951D48 VA: 0x951D48
	// public void NLHLDMGDAFN(int KIJAPOFAGPN) { }

	// // RVA: 0x951EAC Offset: 0x951EAC VA: 0x951EAC
	// public void GOPAABMHDOA() { }

	// // RVA: 0x951E08 Offset: 0x951E08 VA: 0x951E08
	// private void IFBFAOFBNLE(BKOGPDBKFFJ NDFIEMPPMLF, JLOGEHCIBEJ.PMJBKKNNNEM NHLBKJCPLBL) { }

	// // RVA: 0x951EEC Offset: 0x951EEC VA: 0x951EEC
	// private void KNFBJBGHGNL(BKOGPDBKFFJ NDFIEMPPMLF) { }

	// // RVA: 0x95200C Offset: 0x95200C VA: 0x95200C
	// private int AMDHBADOKNM(BKOGPDBKFFJ NDFIEMPPMLF) { }

	// // RVA: 0x952088 Offset: 0x952088 VA: 0x952088
	public int GDMLCKMCMBG()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GDMLCKMCMBG");
		return 0;
	}

	// // RVA: 0x9520AC Offset: 0x9520AC VA: 0x9520AC
	public bool LDMOBKMEKMD()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LDMOBKMEKMD");
		return false;
	}

	// // RVA: 0x9520D8 Offset: 0x9520D8 VA: 0x9520D8
	public bool PPPEFGFIGMH(out int KIJAPOFAGPN, out int HMFFHLPNMPH)
	{
		KIJAPOFAGPN = 0;
		HMFFHLPNMPH = 0;
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PPPEFGFIGMH");
		return false;
	}

	// // RVA: 0x9521BC Offset: 0x9521BC VA: 0x9521BC
	public void PMAMHBOGPNJ(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PMAMHBOGPNJ");
	}

	// // RVA: 0x9524C0 Offset: 0x9524C0 VA: 0x9524C0
	// public void KLOJEBGOGPO(int PPFNGGCBJKC, out int DOOGFEGEKLG, out int NNDBJGDFEEM) { }

	// // RVA: 0x952580 Offset: 0x952580 VA: 0x952580 Slot: 80
	public override bool PDDKJENPOBL()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PDDKJENPOBL");
		return false;
	}

	// [CompilerGeneratedAttribute] // RVA: 0x6BD7B4 Offset: 0x6BD7B4 VA: 0x6BD7B4
	// // RVA: 0x952690 Offset: 0x952690 VA: 0x952690
	// private void <AttackBossGameResult>b__176_0() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD7C4 Offset: 0x6BD7C4 VA: 0x6BD7C4
	// // RVA: 0x952844 Offset: 0x952844 VA: 0x952844
	// private void <AttackBossGameResult>b__176_3() { }

	// [CompilerGeneratedAttribute] // RVA: 0x6BD7D4 Offset: 0x6BD7D4 VA: 0x6BD7D4
	// // RVA: 0x95286C Offset: 0x95286C VA: 0x95286C
	// private void <AttackBossGameResult>b__176_1() { }
}
