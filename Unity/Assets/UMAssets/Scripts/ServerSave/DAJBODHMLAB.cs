
using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use DAJBODHMLAB_DecoPublicSet", true)]
public class DAJBODHMLAB { }
public class DAJBODHMLAB_DecoPublicSet : KLFDBFMNLBL_ServerSaveBlock
{
	public class MMLACIFMNBN
	{
		public enum FDEMAPBAFGN
		{
			HGJCDIEALPL = 0,
		}

		public static class EKDCIMLMDNO
		{
			public const string HBHMAKNGKFK = "itmes";
			public const string GHPLINIACBB = "x";
			public const string PMBEODGMMBB = "y";
			public const string HAJKNHNAIKL = "rsc";
			public const string BDEEIPPDCLE = "rvs";
			public const string BNHOEFJAAKK = "prio";
			public const string BEJGNPAAKNB = "word";
			public const string PMIPFEJFIHA = "stat";
			public const string KMCOOAEHILH = "name";
			public const string LEGFLDLNKOG = "l_w_rsc";
			public const string PFGBIBEENPP = "r_w_rsc";
			public const string LFBBMFHILON = "f_rsc";
		}
 
		public class MHODOAJPNHD
		{
			private int ENOBDCFHELD; // 0x8
			private int FCEJCHGLFGN; // 0xC
			private int LJEEMGKEDNJ; // 0x10
			private int GAKIJIFHEJN; // 0x14
			private int LGIMNGEIJGK; // 0x18
			private int CGMGJNDGPPM; // 0x1C
			private int PJALGHAOGCE; // 0x20
			private int ADICEMPDBAE; // 0x24
			private sbyte PCJHFAAMGAH; // 0x28
			private int JIBCHJDMAFA; // 0x2C
			private int AFNPBPGEDLB; // 0x30
			private int MJDLLJGJKEI; // 0x34
			private int JAKAGBCBFLO; // 0x38
			private int EAPDICKFGNM; // 0x3C
			private int JBHCPDGLCOO; // 0x40

			//public float GHPLINIACBB { get; set; } 0x176D60C GOJKHPHOOEE 0x176D8C8 IPKNCHLGHFD
			internal int GJNKFOGMIMI { get { return LJEEMGKEDNJ ^ ENOBDCFHELD; } set { int val = Mathf.RoundToInt(value * 0.001f * 1000); LJEEMGKEDNJ = val ^ ENOBDCFHELD; GAKIJIFHEJN = val ^ FCEJCHGLFGN; } } //0x176BFD8 DNLHFDJILLD 0x176C04C AIIJFIDBLFK
			//public float PMBEODGMMBB { get; set; } 0x176D634 AGPLCEEFJLA 0x176D8FC LFCJDENJMLB
			internal int NKMDIBLJJOP { get { return LGIMNGEIJGK ^ ENOBDCFHELD; } set { int val = Mathf.RoundToInt(value * 0.001f * 1000); LGIMNGEIJGK = val ^ ENOBDCFHELD; CGMGJNDGPPM = val ^ FCEJCHGLFGN; } } //0x176BFE8 COCMHOFBCCK 0x176C090 MNCEODGPKMH
			public int HAJKNHNAIKL { get { return PJALGHAOGCE ^ ENOBDCFHELD; } set { PJALGHAOGCE = value ^ ENOBDCFHELD; ADICEMPDBAE = value ^ FCEJCHGLFGN; } } //0x176BFF8 CHDEEDLPLAA 0x176C0D4 NHADJDKFFIG
			public bool BDEEIPPDCLE { get { return PCJHFAAMGAH == 0x38; } set { PCJHFAAMGAH = (sbyte)(value ? 0x38 : 0x53); } } //0x176C008 EFBIEBOEHOJ 0x176C0F0 PENHPNOFDKB
			public int BNHOEFJAAKK { get { return JIBCHJDMAFA ^ ENOBDCFHELD; } set { JIBCHJDMAFA = value ^ ENOBDCFHELD; AFNPBPGEDLB = value ^ FCEJCHGLFGN; } } //0x176C01C NNDJHLOPFJB 0x176C120 EKMPDECBDOB
			public int BEJGNPAAKNB { get { return MJDLLJGJKEI ^ ENOBDCFHELD; } set { MJDLLJGJKEI = value ^ ENOBDCFHELD; JAKAGBCBFLO = value ^ FCEJCHGLFGN; } } //0x176C02C PPHPHCADCLJ 0x176C13C BPMLEPPPCKP
			public int PMIPFEJFIHA { get { return EAPDICKFGNM ^ ENOBDCFHELD; } set { EAPDICKFGNM = value ^ ENOBDCFHELD; JBHCPDGLCOO = value ^ FCEJCHGLFGN; } } //0x176C03C BNGHLGAOGNG 0x176C158 JEPICLOKDAG
			//public bool IEDNAKOJNDE { get; } 0x176D7F8 JCIMBGHEMOK

			// RVA: 0x176D930 Offset: 0x176D930 VA: 0x176D930
			//public bool ELECOLNGHDP(DAJBODHMLAB.MMLACIFMNBN.FDEMAPBAFGN CMCKNKKCNDK) { }

			//// RVA: 0x176D954 Offset: 0x176D954 VA: 0x176D954
			//public void LFFJMAMIOLM(DAJBODHMLAB.MMLACIFMNBN.FDEMAPBAFGN CMCKNKKCNDK, bool JKDJCFEBDHC) { }

			// RVA: 0x176BFB8 Offset: 0x176BFB8 VA: 0x176BFB8
			public MHODOAJPNHD()
			{
				LHPDDGIJKNB();
			}

			//// RVA: 0x176D994 Offset: 0x176D994 VA: 0x176D994
			public void LHPDDGIJKNB()
			{
				ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0xd1c493);
				FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0xf25fb34);
				GJNKFOGMIMI = 0;
				NKMDIBLJJOP = 0;
				HAJKNHNAIKL = 0;
				BDEEIPPDCLE = false;
				BNHOEFJAAKK = 0;
				BEJGNPAAKNB = 0;
				PMIPFEJFIHA = 0;
			}

			//// RVA: 0x176C174 Offset: 0x176C174 VA: 0x176C174
			//public DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD ODDIHGPONFL(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD GPBJHKLFCEP) { }

			//// RVA: 0x176C33C Offset: 0x176C33C VA: 0x176C33C
			//public bool AGBOGBEOFME(DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD OIKJFMGEICL) { }

			//// RVA: 0x176C47C Offset: 0x176C47C VA: 0x176C47C
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, DAJBODHMLAB.MMLACIFMNBN.MHODOAJPNHD GJLFANGDGCL, bool EFOEPDLNLJG) { }

			//// RVA: 0x176CC74 Offset: 0x176CC74 VA: 0x176CC74
			//public FENCAJJBLBH PFAKPFKJJKA(ulong FJKGJFJLCGL, int IOPHIHFOOEP, string EFPAOCOMAEA) { }

			//[ConditionalAttribute] // RVA: 0x6BEEFC Offset: 0x6BEEFC VA: 0x6BEEFC
			//// RVA: 0x176DA84 Offset: 0x176DA84 VA: 0x176DA84
			//public void KLCNFEKLJDH() { }
		}

		public const int JDICNBJHMFD = 100;
		public const int JNLNHPNNKAN = 1000;
		public const float GJIJNCNKKDM = 0.001f;
		public List<MHODOAJPNHD> HBHMAKNGKFK = new List<MHODOAJPNHD>(100); // 0x8
		private string KAENAEHCLMP_DecoRoomName; // 0xC
		private int LJAADOFBMAJ; // 0x10
		private int JELNKIBKKIJ; // 0x14
		private int JDDKKOAHKPO; // 0x18
		private int KPJJLKDGEJF; // 0x1C
		private int GIMNIBICIAI; // 0x20
		private int JEBMJANJBFC; // 0x24
		private int ENOBDCFHELD; // 0x28
		private int FCEJCHGLFGN; // 0x2C

		public string CPOONLHIMKC_DecoRoomName { get { return KAENAEHCLMP_DecoRoomName; } set { KAENAEHCLMP_DecoRoomName = value; } } //0x176BF24 EGFOKPACAHL 0x176BF2C NKDCIFIDHDL
		public int DJCJMCHMIMA { get { return LJAADOFBMAJ ^ ENOBDCFHELD; } set { LJAADOFBMAJ = value ^ ENOBDCFHELD; JELNKIBKKIJ = value ^ FCEJCHGLFGN; } } //0x176BF34 LLMDHOMKOHB 0x176BF44 FHCEBEENCFG
		public int KCMEAABOIOA { get { return JDDKKOAHKPO ^ ENOBDCFHELD; } set { JDDKKOAHKPO = value ^ ENOBDCFHELD; KPJJLKDGEJF = value ^ FCEJCHGLFGN; } } //0x176BF60 LHKGNNDOKLN 0x176BF70 FGOAMABINND
		public int KIDHLCNFCKN { get { return GIMNIBICIAI ^ ENOBDCFHELD; } set { GIMNIBICIAI = value ^ ENOBDCFHELD; JEBMJANJBFC = value ^ FCEJCHGLFGN; } } //0x176BF8C LFMALKBBENB 0x176BF9C LJJNNNPDPDM

		// RVA: 0x1769784 Offset: 0x1769784 VA: 0x1769784
		public MMLACIFMNBN()
		{
			KMBPACJNEOF();
		}

		//// RVA: 0x17698C8 Offset: 0x17698C8 VA: 0x17698C8
		public void KMBPACJNEOF()
		{
			ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0x5ac46d);
			FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0x2b30ef79);
			HBHMAKNGKFK.Clear();
			for (int i = 0; i < 100; i++)
			{
				MHODOAJPNHD data = new MHODOAJPNHD();
				data.LHPDDGIJKNB();
				HBHMAKNGKFK.Add(data);
			}
			KAENAEHCLMP_DecoRoomName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_init_room_name", JpStringLiterals.StringLiteral_9829);
			DJCJMCHMIMA = 0;
			KCMEAABOIOA = 0;
			KIDHLCNFCKN = 0;
		}

		//// RVA: 0x1769D78 Offset: 0x1769D78 VA: 0x1769D78
		//public EDOHBJAPLPF OKJPIBHMKMJ() { }

		//// RVA: 0x176A560 Offset: 0x176A560 VA: 0x176A560
		//public bool IIEMACPEEBJ(EDOHBJAPLPF IDLHJIOMJBK, Func<EDOHBJAPLPF, string, int, int> PBBOFACBCCL, Func<EDOHBJAPLPF, string, string, string> GAFBJENPDJH) { }

		//// RVA: 0x176B024 Offset: 0x176B024 VA: 0x176B024
		//public void BMGGKONLFIC(DAJBODHMLAB.MMLACIFMNBN GPBJHKLFCEP) { }

		//// RVA: 0x176B328 Offset: 0x176B328 VA: 0x176B328
		//public bool AGBOGBEOFME(DAJBODHMLAB.MMLACIFMNBN OIKJFMGEICL) { }

		//// RVA: 0x176B878 Offset: 0x176B878 VA: 0x176B878
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, DAJBODHMLAB.MMLACIFMNBN GJLFANGDGCL, bool EFOEPDLNLJG) { }

		//// RVA: 0x176BC50 Offset: 0x176BC50 VA: 0x176BC50
		//public FENCAJJBLBH PFAKPFKJJKA(ulong FJKGJFJLCGL, int IOPHIHFOOEP, string EFPAOCOMAEA) { }

		//[ConditionalAttribute] // RVA: 0x6BEE94 Offset: 0x6BEE94 VA: 0x6BEE94
		//// RVA: 0x176CEB4 Offset: 0x176CEB4 VA: 0x176CEB4
		//public void KLCNFEKLJDH() { }

		//[ConditionalAttribute] // RVA: 0x6BEEC8 Offset: 0x6BEEC8 VA: 0x6BEEC8
		//// RVA: 0x176D050 Offset: 0x176D050 VA: 0x176D050
		//public void MFILDLFMGDC(StringBuilder JBBHNIACMFJ) { }

		//// RVA: 0x176D65C Offset: 0x176D65C VA: 0x176D65C
		//public bool CIKOPIFGLGA() { }
	}

	private const int ECFEMKGFDCE = 1;
	public MMLACIFMNBN LJMCPFACDGJ = new MMLACIFMNBN(); // 0x24
	private int FBGGEFFJJHB; // 0x28

	//[Obsolete] // RVA: 0x74987C Offset: 0x74987C VA: 0x74987C
	//public bool KCMEDJHEGGM { get; set; } //0x1769500  KPMHCNNEOLK 0x17695FC HGHNELFKMJF 
	public override bool DMICHEJIAJL { get { return true; } } // 0x176BBB4 NFKFOODCJJB

	// // RVA: 0x1769700 Offset: 0x1769700 VA: 0x1769700
	public DAJBODHMLAB_DecoPublicSet()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x176981C Offset: 0x176981C VA: 0x176981C Slot: 4
	public override void KMBPACJNEOF()
	{
		FBGGEFFJJHB = (int)(Utility.GetCurrentUnixTime() ^ 0x46872);
		LJMCPFACDGJ.KMBPACJNEOF();
	}

	// // RVA: 0x1769AD4 Offset: 0x1769AD4 VA: 0x1769AD4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(TodoLogger.SaveLoad, "OKJPIBHMKMJ");
	}

	// // RVA: 0x176A330 Offset: 0x176A330 VA: 0x176A330 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x176AF10 Offset: 0x176AF10 VA: 0x176AF10 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "DAJBODHMLAB_DecoPublicSet.BMGGKONLFIC");
	}

	// // RVA: 0x176B214 Offset: 0x176B214 VA: 0x176B214 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0x176B544 Offset: 0x176B544 VA: 0x176B544 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0x176BBBC Offset: 0x176BBBC VA: 0x176BBBC Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.Log(0, "TODO");
		return null;
	}
}
