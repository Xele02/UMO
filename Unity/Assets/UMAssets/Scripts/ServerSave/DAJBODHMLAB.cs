
using System;
using System.Collections.Concurrent;
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
			HGJCDIEALPL_IsKira = 0,
		}

		public static class EKDCIMLMDNO
		{
			public const string HBHMAKNGKFK_items = "itmes";
			public const string GHPLINIACBB_x = "x";
			public const string PMBEODGMMBB_y = "y";
			public const string HAJKNHNAIKL_rsc = "rsc";
			public const string BDEEIPPDCLE_rvs = "rvs";
			public const string BNHOEFJAAKK_prio = "prio";
			public const string BEJGNPAAKNB_word = "word";
			public const string PMIPFEJFIHA_stat = "stat";
			public const string KMCOOAEHILH_name = "name";
			public const string LEGFLDLNKOG_l_w_rsc = "l_w_rsc";
			public const string PFGBIBEENPP_r_w_rsc = "r_w_rsc";
			public const string LFBBMFHILON_f_rsc = "f_rsc";
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
			private int MJDLLJGJKEI_WordCrypted; // 0x34
			private int JAKAGBCBFLO; // 0x38
			private int EAPDICKFGNM; // 0x3C
			private int JBHCPDGLCOO; // 0x40

			public float GHPLINIACBB_x { get { return (ENOBDCFHELD ^ LJEEMGKEDNJ) * 0.001f; } set { LJEEMGKEDNJ = ENOBDCFHELD ^ (int)(value * 1000); GAKIJIFHEJN = FCEJCHGLFGN ^ (int)(value * 1000); } } //0x176D60C GOJKHPHOOEE 0x176D8C8 IPKNCHLGHFD
			internal int GJNKFOGMIMI_PosXSerialize { get { return LJEEMGKEDNJ ^ ENOBDCFHELD; } set { int val = (int)(value * 0.001f * 1000); LJEEMGKEDNJ = val ^ ENOBDCFHELD; GAKIJIFHEJN = val ^ FCEJCHGLFGN; } } //0x176BFD8 DNLHFDJILLD 0x176C04C AIIJFIDBLFK
			public float PMBEODGMMBB_y { get { return (ENOBDCFHELD ^ LGIMNGEIJGK) * 0.001f; } set { LGIMNGEIJGK = ENOBDCFHELD ^ (int)(value * 1000); CGMGJNDGPPM = FCEJCHGLFGN ^ (int)(value * 1000); } } //0x176D634 AGPLCEEFJLA 0x176D8FC LFCJDENJMLB
			internal int NKMDIBLJJOP_PosYSerialize { get { return LGIMNGEIJGK ^ ENOBDCFHELD; } set { int val = (int)(value * 0.001f * 1000); LGIMNGEIJGK = val ^ ENOBDCFHELD; CGMGJNDGPPM = val ^ FCEJCHGLFGN; } } //0x176BFE8 COCMHOFBCCK 0x176C090 MNCEODGPKMH
			// ItemId (Ressource)
			public int HAJKNHNAIKL_rsc { get { return PJALGHAOGCE ^ ENOBDCFHELD; } set { PJALGHAOGCE = value ^ ENOBDCFHELD; ADICEMPDBAE = value ^ FCEJCHGLFGN; } } //0x176BFF8 CHDEEDLPLAA 0x176C0D4 NHADJDKFFIG
			public bool BDEEIPPDCLE_rvs { get { return PCJHFAAMGAH == 0x38; } set { PCJHFAAMGAH = (sbyte)(value ? 0x38 : 0x53); } } //0x176C008 EFBIEBOEHOJ 0x176C0F0 PENHPNOFDKB
			public int BNHOEFJAAKK_prio { get { return JIBCHJDMAFA ^ ENOBDCFHELD; } set { JIBCHJDMAFA = value ^ ENOBDCFHELD; AFNPBPGEDLB = value ^ FCEJCHGLFGN; } } //0x176C01C NNDJHLOPFJB 0x176C120 EKMPDECBDOB
			public int BEJGNPAAKNB_word { get { return MJDLLJGJKEI_WordCrypted ^ ENOBDCFHELD; } set { MJDLLJGJKEI_WordCrypted = value ^ ENOBDCFHELD; JAKAGBCBFLO = value ^ FCEJCHGLFGN; } } //0x176C02C PPHPHCADCLJ 0x176C13C BPMLEPPPCKP
			// Statusflag
			public int PMIPFEJFIHA_stat { get { return EAPDICKFGNM ^ ENOBDCFHELD; } set { EAPDICKFGNM = value ^ ENOBDCFHELD; JBHCPDGLCOO = value ^ FCEJCHGLFGN; } } //0x176C03C BNGHLGAOGNG 0x176C158 JEPICLOKDAG
			public bool IEDNAKOJNDE_IsValid { get { return HAJKNHNAIKL_rsc > 0; } } //0x176D7F8 JCIMBGHEMOK

			// RVA: 0x176D930 Offset: 0x176D930 VA: 0x176D930
			//public bool ELECOLNGHDP(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN _CMCKNKKCNDK_status) { }

			//// RVA: 0x176D954 Offset: 0x176D954 VA: 0x176D954
			//public void LFFJMAMIOLM(DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.FDEMAPBAFGN _CMCKNKKCNDK_status, bool _JKDJCFEBDHC_Enabled) { }

			// RVA: 0x176BFB8 Offset: 0x176BFB8 VA: 0x176BFB8
			public MHODOAJPNHD()
			{
				LHPDDGIJKNB_Reset();
			}

			//// RVA: 0x176D994 Offset: 0x176D994 VA: 0x176D994
			public void LHPDDGIJKNB_Reset()
			{
				ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0xd1c493);
				FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0xf25fb34);
				GJNKFOGMIMI_PosXSerialize = 0;
				NKMDIBLJJOP_PosYSerialize = 0;
				HAJKNHNAIKL_rsc = 0;
				BDEEIPPDCLE_rvs = false;
				BNHOEFJAAKK_prio = 0;
				BEJGNPAAKNB_word = 0;
				PMIPFEJFIHA_stat = 0;
			}

			//// RVA: 0x176C174 Offset: 0x176C174 VA: 0x176C174
			public MHODOAJPNHD ODDIHGPONFL_Copy(MHODOAJPNHD GPBJHKLFCEP)
			{
				GJNKFOGMIMI_PosXSerialize = GPBJHKLFCEP.GJNKFOGMIMI_PosXSerialize;
				NKMDIBLJJOP_PosYSerialize = GPBJHKLFCEP.NKMDIBLJJOP_PosYSerialize;
				HAJKNHNAIKL_rsc = GPBJHKLFCEP.HAJKNHNAIKL_rsc;
				BDEEIPPDCLE_rvs = GPBJHKLFCEP.BDEEIPPDCLE_rvs;
				BNHOEFJAAKK_prio = GPBJHKLFCEP.BNHOEFJAAKK_prio;
				BEJGNPAAKNB_word = GPBJHKLFCEP.BEJGNPAAKNB_word;
				PMIPFEJFIHA_stat = GPBJHKLFCEP.PMIPFEJFIHA_stat;
				return this;
			}

			//// RVA: 0x176C33C Offset: 0x176C33C VA: 0x176C33C
			public bool AGBOGBEOFME(MHODOAJPNHD OIKJFMGEICL)
			{
				return GJNKFOGMIMI_PosXSerialize == OIKJFMGEICL.GJNKFOGMIMI_PosXSerialize && 
					NKMDIBLJJOP_PosYSerialize == OIKJFMGEICL.NKMDIBLJJOP_PosYSerialize && 
					HAJKNHNAIKL_rsc == OIKJFMGEICL.HAJKNHNAIKL_rsc && 
					BDEEIPPDCLE_rvs == OIKJFMGEICL.BDEEIPPDCLE_rvs && 
					BNHOEFJAAKK_prio == OIKJFMGEICL.BNHOEFJAAKK_prio && 
					BEJGNPAAKNB_word == OIKJFMGEICL.BEJGNPAAKNB_word && 
					PMIPFEJFIHA_stat == OIKJFMGEICL.PMIPFEJFIHA_stat;
			}

			//// RVA: 0x176C47C Offset: 0x176C47C VA: 0x176C47C
			//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN.MHODOAJPNHD _GJLFANGDGCL_Target, bool EFOEPDLNLJG) { }

			//// RVA: 0x176CC74 Offset: 0x176CC74 VA: 0x176CC74
			//public FENCAJJBLBH PFAKPFKJJKA(ulong FJKGJFJLCGL, int _IOPHIHFOOEP_idx, string EFPAOCOMAEA) { }

			//[ConditionalAttribute] // RVA: 0x6BEEFC Offset: 0x6BEEFC VA: 0x6BEEFC
			//// RVA: 0x176DA84 Offset: 0x176DA84 VA: 0x176DA84
			//public void KLCNFEKLJDH() { }
		}

		public const int JDICNBJHMFD = 100;
		public const int JNLNHPNNKAN = 1000;
		public const float GJIJNCNKKDM = 0.001f;
		public List<MHODOAJPNHD> HBHMAKNGKFK_items = new List<MHODOAJPNHD>(100); // 0x8
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
		public int DJCJMCHMIMA_WallLId { get { return LJAADOFBMAJ ^ ENOBDCFHELD; } set { LJAADOFBMAJ = value ^ ENOBDCFHELD; JELNKIBKKIJ = value ^ FCEJCHGLFGN; } } //0x176BF34 LLMDHOMKOHB 0x176BF44 FHCEBEENCFG
		public int KCMEAABOIOA_WallRId { get { return JDDKKOAHKPO ^ ENOBDCFHELD; } set { JDDKKOAHKPO = value ^ ENOBDCFHELD; KPJJLKDGEJF = value ^ FCEJCHGLFGN; } } //0x176BF60 LHKGNNDOKLN 0x176BF70 FGOAMABINND
		public int KIDHLCNFCKN_FloorId { get { return GIMNIBICIAI ^ ENOBDCFHELD; } set { GIMNIBICIAI = value ^ ENOBDCFHELD; JEBMJANJBFC = value ^ FCEJCHGLFGN; } } //0x176BF8C LFMALKBBENB 0x176BF9C LJJNNNPDPDM

		// RVA: 0x1769784 Offset: 0x1769784 VA: 0x1769784
		public MMLACIFMNBN()
		{
			KMBPACJNEOF_Reset();
		}

		//// RVA: 0x17698C8 Offset: 0x17698C8 VA: 0x17698C8
		public void KMBPACJNEOF_Reset()
		{
			ENOBDCFHELD = (int)(Utility.GetCurrentUnixTime() ^ 0x5ac46d);
			FCEJCHGLFGN = (int)(Utility.GetCurrentUnixTime() ^ 0x2b30ef79);
			HBHMAKNGKFK_items.Clear();
			for (int i = 0; i < 100; i++)
			{
				MHODOAJPNHD data = new MHODOAJPNHD();
				data.LHPDDGIJKNB_Reset();
				HBHMAKNGKFK_items.Add(data);
			}
			KAENAEHCLMP_DecoRoomName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_init_room_name", JpStringLiterals.StringLiteral_9829);
			DJCJMCHMIMA_WallLId = 0;
			KCMEAABOIOA_WallRId = 0;
			KIDHLCNFCKN_FloorId = 0;
		}

		//// RVA: 0x1769D78 Offset: 0x1769D78 VA: 0x1769D78
		public EDOHBJAPLPF_JsonData OKJPIBHMKMJ()
		{
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data["name"] = KAENAEHCLMP_DecoRoomName;
			data["l_w_rsc"] = DJCJMCHMIMA_WallLId;
			data["r_w_rsc"] = KCMEAABOIOA_WallRId;
			data["f_rsc"] = KIDHLCNFCKN_FloorId;
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < HBHMAKNGKFK_items.Count; i++)
				{
					EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
					data3["x"] = HBHMAKNGKFK_items[i].GJNKFOGMIMI_PosXSerialize;
					data3["y"] = HBHMAKNGKFK_items[i].NKMDIBLJJOP_PosYSerialize;
					data3["rsc"] = HBHMAKNGKFK_items[i].HAJKNHNAIKL_rsc;
					data3["rvs"] = HBHMAKNGKFK_items[i].BDEEIPPDCLE_rvs ? 1 : 0;
					data3["prio"] = HBHMAKNGKFK_items[i].BNHOEFJAAKK_prio;
					data3["word"] = HBHMAKNGKFK_items[i].BEJGNPAAKNB_word;
					data3["stat"] = HBHMAKNGKFK_items[i].PMIPFEJFIHA_stat;
					data2.Add(data3);
				}
				data["itmes"] = data2;
			}
			return data;
		}

		//// RVA: 0x176A560 Offset: 0x176A560 VA: 0x176A560
		public bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, Func<EDOHBJAPLPF_JsonData, string, int, int> PBBOFACBCCL, Func<EDOHBJAPLPF_JsonData, string, string, string> GAFBJENPDJH)
		{
			KAENAEHCLMP_DecoRoomName = GAFBJENPDJH(_IDLHJIOMJBK_data, "name", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_init_room_name", JpStringLiterals.StringLiteral_9829));
			DJCJMCHMIMA_WallLId = PBBOFACBCCL(_IDLHJIOMJBK_data, "l_w_rsc", 0);
			KCMEAABOIOA_WallRId = PBBOFACBCCL(_IDLHJIOMJBK_data, "r_w_rsc", 0);
			KIDHLCNFCKN_FloorId = PBBOFACBCCL(_IDLHJIOMJBK_data, "f_rsc", 0);
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KOPLBMLHKCD_IsValidBgItem(DJCJMCHMIMA_WallLId))
				DJCJMCHMIMA_WallLId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, 1);
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KOPLBMLHKCD_IsValidBgItem(KCMEAABOIOA_WallRId))
				KCMEAABOIOA_WallRId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, 1);
			if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KOPLBMLHKCD_IsValidBgItem(KIDHLCNFCKN_FloorId))
				KIDHLCNFCKN_FloorId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, 1);
			int cnt = _IDLHJIOMJBK_data["itmes"].HNBFOAJIIAL_Count;
			if(cnt > 100)
				cnt = 100;
			for(int i = 0; i < cnt; i++)
			{
				EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data["itmes"][i];
				int id = PBBOFACBCCL(data, "rsc", 0);
				MHODOAJPNHD item = HBHMAKNGKFK_items[i];
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.FMGPOKFKPIJ_IsValidItem(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, id))
				{
					item.GJNKFOGMIMI_PosXSerialize = PBBOFACBCCL(data, "x", 0);
					item.HAJKNHNAIKL_rsc = id;
					item.NKMDIBLJJOP_PosYSerialize = PBBOFACBCCL(data, "y", 0);
					item.BDEEIPPDCLE_rvs = PBBOFACBCCL(data, "rvs", 0) != 0;
					item.BNHOEFJAAKK_prio = PBBOFACBCCL(data, "prio", 0);
					item.BEJGNPAAKNB_word = PBBOFACBCCL(data, "word", 0);
					item.PMIPFEJFIHA_stat = PBBOFACBCCL(data, "stat", 0);
				}
				else
				{
					item.GJNKFOGMIMI_PosXSerialize = 0;
					item.HAJKNHNAIKL_rsc = 0;
					item.NKMDIBLJJOP_PosYSerialize = 0;
					item.BDEEIPPDCLE_rvs = false;
					item.BNHOEFJAAKK_prio = 0;
					item.BEJGNPAAKNB_word = 0;
					item.PMIPFEJFIHA_stat = 0;
				}
			}
			return _IDLHJIOMJBK_data["itmes"].HNBFOAJIIAL_Count > 100;
		}

		//// RVA: 0x176B024 Offset: 0x176B024 VA: 0x176B024
		public void BMGGKONLFIC_Copy(MMLACIFMNBN GPBJHKLFCEP)
		{
			for(int i = 0; i < HBHMAKNGKFK_items.Count; i++)
			{
				HBHMAKNGKFK_items[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.HBHMAKNGKFK_items[i]);
			}
			KAENAEHCLMP_DecoRoomName = GPBJHKLFCEP.CPOONLHIMKC_DecoRoomName;
			DJCJMCHMIMA_WallLId = GPBJHKLFCEP.DJCJMCHMIMA_WallLId;
			KCMEAABOIOA_WallRId = GPBJHKLFCEP.KCMEAABOIOA_WallRId;
			KIDHLCNFCKN_FloorId = GPBJHKLFCEP.KIDHLCNFCKN_FloorId;
		}

		//// RVA: 0x176B328 Offset: 0x176B328 VA: 0x176B328
		public bool AGBOGBEOFME(MMLACIFMNBN OIKJFMGEICL)
		{
			if(KAENAEHCLMP_DecoRoomName != OIKJFMGEICL.CPOONLHIMKC_DecoRoomName)
				return false;
			if(DJCJMCHMIMA_WallLId != OIKJFMGEICL.DJCJMCHMIMA_WallLId)
				return false;
			if(KCMEAABOIOA_WallRId != OIKJFMGEICL.KCMEAABOIOA_WallRId)
				return false;
			if(KIDHLCNFCKN_FloorId != OIKJFMGEICL.KIDHLCNFCKN_FloorId)
				return false;
			if(HBHMAKNGKFK_items.Count != OIKJFMGEICL.HBHMAKNGKFK_items.Count)
				return false;
			for(int i = 0; i < HBHMAKNGKFK_items.Count; i++)
			{
				if(!HBHMAKNGKFK_items[i].AGBOGBEOFME(OIKJFMGEICL.HBHMAKNGKFK_items[i]))
					return false;
			}
			return true;
		}

		//// RVA: 0x176B878 Offset: 0x176B878 VA: 0x176B878
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, DAJBODHMLAB_DecoPublicSet.MMLACIFMNBN _GJLFANGDGCL_Target, bool EFOEPDLNLJG) { }

		//// RVA: 0x176BC50 Offset: 0x176BC50 VA: 0x176BC50
		//public FENCAJJBLBH PFAKPFKJJKA(ulong FJKGJFJLCGL, int _IOPHIHFOOEP_idx, string EFPAOCOMAEA) { }

		//[ConditionalAttribute] // RVA: 0x6BEE94 Offset: 0x6BEE94 VA: 0x6BEE94
		//// RVA: 0x176CEB4 Offset: 0x176CEB4 VA: 0x176CEB4
		//public void KLCNFEKLJDH() { }

		//[ConditionalAttribute] // RVA: 0x6BEEC8 Offset: 0x6BEEC8 VA: 0x6BEEC8
		//// RVA: 0x176D050 Offset: 0x176D050 VA: 0x176D050
		//public void MFILDLFMGDC(StringBuilder JBBHNIACMFJ) { }

		//// RVA: 0x176D65C Offset: 0x176D65C VA: 0x176D65C
		public bool CIKOPIFGLGA()
		{
			if(KIDHLCNFCKN_FloorId == 0 && DJCJMCHMIMA_WallLId == 0)
			{
				foreach(var c in HBHMAKNGKFK_items)
				{
					if (c.HAJKNHNAIKL_rsc > 0)
						return true;
				}
				return false;
			}
			return true;
		}
	}

	private const int ECFEMKGFDCE_CurrentVersion = 1;
	public MMLACIFMNBN LJMCPFACDGJ = new MMLACIFMNBN(); // 0x24
	private int FBGGEFFJJHB_xor; // 0x28

	//[Obsolete] // RVA: 0x74987C Offset: 0x74987C VA: 0x74987C
	//public bool KCMEDJHEGGM { get; set; } //0x1769500  KPMHCNNEOLK 0x17695FC HGHNELFKMJF 
	public override bool DMICHEJIAJL { get { return true; } } // 0x176BBB4 NFKFOODCJJB

	// // RVA: 0x1769700 Offset: 0x1769700 VA: 0x1769700
	public DAJBODHMLAB_DecoPublicSet()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x176981C Offset: 0x176981C VA: 0x176981C Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FBGGEFFJJHB_xor = (int)(Utility.GetCurrentUnixTime() ^ 0x46872);
		LJMCPFACDGJ.KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1769AD4 Offset: 0x1769AD4 VA: 0x1769AD4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = LJMCPFACDGJ.OKJPIBHMKMJ();
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = ECFEMKGFDCE_CurrentVersion;
			data2[JIKKNHIAEKG_BlockName] = data;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x176A330 Offset: 0x176A330 VA: 0x176A330 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				LJMCPFACDGJ.IIEMACPEEBJ_Deserialize(block, (EDOHBJAPLPF_JsonData _JGNBPFCJLKI_d, string _LJNAKDMILMC_key, int BAAPMIKMLPP) =>
				{
					//0x176BE74
					return CJAENOMGPDA_GetInt(_JGNBPFCJLKI_d, _LJNAKDMILMC_key, BAAPMIKMLPP, ref isInvalid);
				}, (EDOHBJAPLPF_JsonData _JGNBPFCJLKI_d, string _LJNAKDMILMC_key, string EMOLDMOBKLM) =>
				{
					//0x176BECC
					return FGCNMLBACGO_GetString(_JGNBPFCJLKI_d, _LJNAKDMILMC_key, EMOLDMOBKLM, ref isInvalid);
				});
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x176AF10 Offset: 0x176AF10 VA: 0x176AF10 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		DAJBODHMLAB_DecoPublicSet other = GPBJHKLFCEP as DAJBODHMLAB_DecoPublicSet;
		LJMCPFACDGJ.BMGGKONLFIC_Copy(other.LJMCPFACDGJ);
	}

	// // RVA: 0x176B214 Offset: 0x176B214 VA: 0x176B214 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		DAJBODHMLAB_DecoPublicSet other = GPBJHKLFCEP as DAJBODHMLAB_DecoPublicSet;
		return LJMCPFACDGJ.AGBOGBEOFME(other.LJMCPFACDGJ);
	}

	// // RVA: 0x176B544 Offset: 0x176B544 VA: 0x176B544 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x176BBBC Offset: 0x176BBBC VA: 0x176BBBC Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
