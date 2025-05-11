
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class KAMKMOKMPAN
{
	public enum GGPEAOAOEPH
	{
		HJNNKCMLGFL = 0,
		LAOEGNLOJHC = 1,
		CNLOFIHPBMP = 2,
		OLDDILMKJND_3 = 3,
		BFIOFNKPOFB_4 = 4,
		OLCLJKOKJCD = 5,
	}

}

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
		public int HALIDDHLNEG_GetPoint; // 0x3C
		public bool PAACIPCHDDE_MissionCompleted; // 0x40
		public RhythmGameConsts.ResultComboType LCOHGOIDMDF; // 0x44
		public int ADHMMMEOJMK; // 0x48
		public int AKNELONELJK; // 0x4C
		public bool GIKLNODJKFK; // 0x50
		public int OIOPCIAGLEK_CannonBaseValue; // 0x54
		public int IHIJGIHNOAL_CannonGaugeAdd; // 0x58
		public int LFOPOHHEODG_ChargeBonus; // 0x5C
		public bool DKKJPLALNFD; // 0x60

		public int NPPEPJHBPNE_CannonGauge { get { return Mathf.Min(IHIJGIHNOAL_CannonGaugeAdd + OIOPCIAGLEK_CannonBaseValue, 100); } } //0xFE79F0 LIBFGNGACKC
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
		LIFLDNIHBAK_1 = 1,
	}

	public class KMFKFGEDPGJ
	{
		public BKKPEJEABJN INDDJNMPONH; // 0x8
		public string LBODHBDOMGK_PlayerName; // 0xC
		public int MLPEHNBNOGD_PlayerId; // 0x10
		public int GBJFCGOBHDO_RawAddedDamage; // 0x14
		public int IOMHJCBMADB_AddedDamage; // 0x18

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
			private int PEBHLFLDIGC_Crypted; // 0x10

			public int DJJGNDCMNHF { get { return PEBHLFLDIGC_Crypted ^ 0x147bae1; } set { PEBHLFLDIGC_Crypted = value ^ PEBHLFLDIGC_Crypted; } } //0xFE7888 GEPCOAPEAJM 0xFE7980 MIFJBBAJAJP
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
			public int HALIDDHLNEG_Damage; // 0x50
			public int FJOLNJLLJEJ_Rank; // 0x54
		}

		private const int JFMBNPLPAOB = 5;
		public int PPFNGGCBJKC_Id; // 0x50
		public string MMEBLOIJBKE_UniqueKey; // 0x54
		public int BCCOMAODPJI_HpCurrent; // 0x58
		public int PIKKHCGNGNN_HpMax; // 0x5C
		public NHCDBBBMFFG CMCKNKKCNDK_Status; // 0x60
		public int MHABJOMJCFI_JoinedMember; // 0x64
		public long AJCCONCCIMF_EscapeAt; // 0x68
		public int ANAJIAENLNB_Level; // 0x70
		public int INDDJNMPONH_Type; // 0x74
		public int HPPDFBKEJCG_BgId; // 0x78
		public int FJOLNJLLJEJ_Rank; // 0x7C
		public bool IKICLMGFFPB_IsSpecial; // 0x80
		public bool DLMNFENNCJG_IsEntry; // 0x81
		public bool CAKONDPGDIL_CanRequestHelp; // 0x82
		public bool ICCOOAAJEIN_CanReceiveReward; // 0x83
		private int[] FDAPMJJKNKG_MyAttackCountByType; // 0x84
		private int[] HNEPPPIEJAD_OtherAttackCountByType; // 0x88
		public int OGLLKABGMCP_LastUpdatedPlayerId; // 0x8C
		private CEBFFLDKAEC_SecureInt OMAGOLHJBDB = new CEBFFLDKAEC_SecureInt(); // 0x90
		public string BLFHMNHMDHF_Mission; // 0x94
		public string CJLHLKKNMEE_MissionText; // 0x98
		public int NFOOOBMJINC_MissionBonusNum; // 0x9C
		public int JOMGCCBFKEF_MissionId; // 0xA0
		private List<CALIFIMGGMD> PIGIFFAHFCI = new List<CALIFIMGGMD>(); // 0xA4

		public int CLNPBIJBIIJ_CoopBonus { get { return OMAGOLHJBDB.DNJEJEANJGL_Value; } set { OMAGOLHJBDB.DNJEJEANJGL_Value = value; } } //0xFE6B64 BEGALDANEBB 0xFE6B90 ODBEDHFDCCE
		public bool DNJGAJPIIPI { get { return PPFNGGCBJKC_Id > 0; } } //0xFE6BC4 GALFPKKIGBH
		public int GCKGHNBHOPH_Rank { get; set; } // 0xA8 MABIMNPOAKL FODAJFNKMBJ BPPKEMEMLFN
		public int AEGFDINOACE_PlayerDamage { get; set; } // 0xAC FHEKPHOCOGA CCDBHBFKPEB FKFKCKOCBGA
		// public bool HIJGICMMECD { get; } 0xFE6D88 GHOEIAKFGIG
		public int IBGEJLJIAFD { get { return PIGIFFAHFCI.Count; } } //0xFE6E10 CJGBMDBLCII
		public CALIFIMGGMD BBMPCFEMDDC { get; set; } // 0xB0 AFEMAONMFDD JINDDLBIHMA ODAOJCBCLPA
		public CALIFIMGGMD NBBMHALJCMK_FirstAttackPlayer { get; set; } // 0xB4 OKELJHOGFCO CHLPJPOIINJ FGPBGLIAGHF

		// RVA: 0xFD8330 Offset: 0xFD8330 VA: 0xFD8330
		public MJFMOPMOFDJ()
		{
			OMAGOLHJBDB.LHPDDGIJKNB_Reset((int)Utility.GetCurrentUnixTime() ^ 0x8756217, (int)Utility.GetCurrentUnixTime() ^ 0x3115581);
			CLNPBIJBIIJ_CoopBonus = 0;
		}

		// // RVA: 0xFD6A90 Offset: 0xFD6A90 VA: 0xFD6A90
		public void LHPDDGIJKNB()
		{
			ANAJIAENLNB_Level = 0;
			INDDJNMPONH_Type = 1;
			HPPDFBKEJCG_BgId = 1;
			FJOLNJLLJEJ_Rank = 0;
			IKICLMGFFPB_IsSpecial = false;
			DLMNFENNCJG_IsEntry = false;
			CAKONDPGDIL_CanRequestHelp = false;
			ICCOOAAJEIN_CanReceiveReward = false;
			CMCKNKKCNDK_Status = NHCDBBBMFFG.HJNNKCMLGFL_0;
			MHABJOMJCFI_JoinedMember = 0;
			AJCCONCCIMF_EscapeAt = 0;
			PPFNGGCBJKC_Id = 0;
			MMEBLOIJBKE_UniqueKey = null;
			BCCOMAODPJI_HpCurrent = 0;
			PIKKHCGNGNN_HpMax = 0;
			MLPEHNBNOGD_Id = 0;
			PIPOJJGBGLB();
			OMAGOLHJBDB.DNBGDMBCLMI();
		}

		// // RVA: 0xFE6BD8 Offset: 0xFE6BD8 VA: 0xFE6BD8
		public long OCFJGNPMJBA_GetTime()
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			return AJCCONCCIMF_EscapeAt - t;
		}

		// // RVA: -1 Offset: -1
		public void EMHHJNDOCMB<EffectInfoClass>(List<EffectInfoClass> OEDHCKELBJK) where EffectInfoClass : EBHIMFFJBIJ
		{
			FDAPMJJKNKG_MyAttackCountByType = new int[4];
			HNEPPPIEJAD_OtherAttackCountByType = new int[4];
			long v = 0;
			for(int i= 0; i < OEDHCKELBJK.Count; i++)
			{
				if(OEDHCKELBJK[i].MCJEIDPDMLF_EffectId < 5)
				{
					FDAPMJJKNKG_MyAttackCountByType[OEDHCKELBJK[i].MCJEIDPDMLF_EffectId - 1] = OEDHCKELBJK[i].LHJMEJOJGKL_NumberOfTimes;
				}
				else
				{
					HNEPPPIEJAD_OtherAttackCountByType[OEDHCKELBJK[i].MCJEIDPDMLF_EffectId - 6] = OEDHCKELBJK[i].LHJMEJOJGKL_NumberOfTimes;
					if(OEDHCKELBJK[i].MCJEIDPDMLF_EffectId != 9)
					{
						if(v < OEDHCKELBJK[i].LPJIIDJJKOE_UpdatedAt)
						{
							OGLLKABGMCP_LastUpdatedPlayerId = OEDHCKELBJK[i].NMEGALKLMKH_LastUpdatedPlayerId;
							v = OEDHCKELBJK[i].LPJIIDJJKOE_UpdatedAt;
						}
					}
				}
			}
		}
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
		public int NKIIJMFIIAK_GetTotalAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
		{
			return DOJHNCMHNEI_GetMyAttackCount(INDDJNMPONH) + LGKOMGPLKDK_GetOtherAttackCount(INDDJNMPONH);
		}

		// // RVA: 0xFE6CF0 Offset: 0xFE6CF0 VA: 0xFE6CF0
		public int DOJHNCMHNEI_GetMyAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
		{
			return FDAPMJJKNKG_MyAttackCountByType[(int)INDDJNMPONH - 1];
		}

		// // RVA: 0xFE6D3C Offset: 0xFE6D3C VA: 0xFE6D3C
		public int LGKOMGPLKDK_GetOtherAttackCount(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
		{
			return HNEPPPIEJAD_OtherAttackCountByType[(int)INDDJNMPONH];
		}

		// // RVA: 0xFE6E88 Offset: 0xFE6E88 VA: 0xFE6E88
		public CALIFIMGGMD PMPMADPEGDE(int OIPCCBHIKIA)
		{
			return PIGIFFAHFCI[OIPCCBHIKIA];
		}

		// // RVA: 0xFE6F08 Offset: 0xFE6F08 VA: 0xFE6F08
		// public PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD JFODGOKHOEA() { }

		// // RVA: 0xFD98F0 Offset: 0xFD98F0 VA: 0xFD98F0
		internal void PIPOJJGBGLB()
		{
			PIGIFFAHFCI.Clear();
			GCKGHNBHOPH_Rank = 0;
			AEGFDINOACE_PlayerDamage = 0;
			BBMPCFEMDDC = null;
			NBBMHALJCMK_FirstAttackPlayer = null;
		}

		// // RVA: 0xFD9984 Offset: 0xFD9984 VA: 0xFD9984
		internal void IDALEDJHEMF(CALIFIMGGMD GPNOEFHGOJG)
		{
			PIGIFFAHFCI.Add(GPNOEFHGOJG);
		}

		// // RVA: 0xFD9A04 Offset: 0xFD9A04 VA: 0xFD9A04
		// internal void PHBGAAHPKPO(PKNOKJNLPOE.MJFMOPMOFDJ.CALIFIMGGMD GPNOEFHGOJG) { }

		// // RVA: 0xFD9A0C Offset: 0xFD9A0C VA: 0xFD9A0C
		internal void KGPKFAFHEFP(CALIFIMGGMD GPNOEFHGOJG)
		{
			BBMPCFEMDDC = GPNOEFHGOJG;
			GCKGHNBHOPH_Rank = GPNOEFHGOJG.FJOLNJLLJEJ_Rank;
			AEGFDINOACE_PlayerDamage = GPNOEFHGOJG.HALIDDHLNEG_Damage;
		}
	}

	private enum MALKHIMMLDI
	{
		HJNNKCMLGFL_0 = 0,
		NPGGGMACPLD_1 = 1,
		OOEHFFBHCIC_2 = 2,
	}

	public class ECICDAPCMJG
	{
		public string LBODHBDOMGK_PlayerName; // 0x8
		public int MLPEHNBNOGD_PlayerId; // 0xC
		public bool HKAIJKGODHC; // 0x10
		public int GFDDPMCEJCI_ClusterId; // 0x14
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

	private const int GHJHJDIDCFA = 3;
	public const int EGJPAEHGDEL = 40;
	private const int EBPEOLODPNN = 1000;
	private EECOJKDJIFG KBACNOCOANM; // 0xE8
	private BBHNACPENDM_ServerSaveData FPPNANIIODA = new BBHNACPENDM_ServerSaveData(); // 0xEC
	private KAFHAKBBJEI JIMJHIDEHNM; // 0xF0
	private GameAttribute.Type IEDBMNIBDPD_MCannonPlateAttr; // 0xF8
	public int HENFOBHBABA_MCannonPlateAttrBonus; // 0xFC
	public int AKHNDMEHHLF_MCannonPlateSeriesBonus; // 0x100
	private List<KMFKFGEDPGJ> CBPJPNIFJOI = new List<KMFKFGEDPGJ>(8); // 0x10C
	public bool EGOJLOEFMOH; // 0x114
	public int BCBCODAKIDN; // 0x118
	public bool KIBBLLADDPO; // 0x11C
	public MJFMOPMOFDJ MCEJJBANCDA; // 0x120
	public int NENNACLBKJJ; // 0x124
	private MJFMOPMOFDJ PBJBHONLMKF_MyBoss = new MJFMOPMOFDJ(); // 0x128
	private List<MJFMOPMOFDJ> ECPHFLNMECN = new List<MJFMOPMOFDJ>(); // 0x12C
	private HighScoreRating JJGJJALILHC = new HighScoreRating(); // 0x138
	private uint PMBEODGMMBB = 0x15ab17a1; // 0x140

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid; } } // DKHCGLCNKCD  Slot: 4
	public JKIJLMMLNPL GGDBEANLCPC { get; private set; } // 0xF4 KOEMHFFCFBI MBNLPELOLBJ PFNPAAKMGJF
	public OCBPJEALCPO PLFBKEPLAAA { get; private set; } // 0x104 KPJIFMDECLG NAMEFMANAKG NPIFONLKBLN
	public KJJDLBFDGDM KONJMFICNJJ { get; private set; } // 0x108 BJFFFIBNLLH KLDMMPJKHEO PKGMFMELDEN
	// public List<PKNOKJNLPOE.KMFKFGEDPGJ> FKLEEMCDKNF { get; }
	public MOAICCAOMCP ANMBIEIFKFF { get; private set; } // 0x110 BFEMMFOALFE PDPEPHAMKEB JNEELMEBJFI
	// public bool NNNMHHHBIIB { get; }
	// public int CALECMAEBIH { get; }
	// public int HIGDPLMLING { get; }
	// public int OKEGPFAIOCF { get; }
	public JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH CFLEMFADGLG { get; private set; } // 0x130 GEJKDKKDHBI KAHCHHILDEM MDOJKNFKJGE
	public MJFMOPMOFDJ JIBMOEHKMGB { get; set; } // 0x134 FKHECGJBFAD KACFOENGHIK ILADGLDGCLL
	public int HKMFDIEOKNM { get; private set; } // 0x13C FKCJFJMCNJA EFKMGOOLCKO LAGMLHCALKF
	// public bool NKNJACLMNDG { get; }
	// public bool KLOEKHMPJDJ { get; }
	// public bool CHMMBIEFFHB { get; }
	// public bool JHLLDEFENMP { get; }

	// // RVA: 0x9400AC Offset: 0x9400AC VA: 0x9400AC
	public List<KMFKFGEDPGJ> DIFIHMCHDJF()
	{
		return CBPJPNIFJOI;
	}

	// // RVA: 0x9400C4 Offset: 0x9400C4 VA: 0x9400C4
	public bool NMDNCFGEJGJ()
	{
		return KONJMFICNJJ != null;
	}

	// // RVA: 0x9400D4 Offset: 0x9400D4 VA: 0x9400D4 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO = 0)
	{
		return KBACNOCOANM;
	}

	// RVA: 0x9400DC Offset: 0x9400DC VA: 0x9400DC
	public PKNOKJNLPOE_EventRaid(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			FPPNANIIODA.KHEKNNFCAOI_Init(0x8000000005);
			IEDBMNIBDPD_MCannonPlateAttr = (GameAttribute.Type) ev.LPJLEHAJADA("mcannon_plate_attr", 0);
			HENFOBHBABA_MCannonPlateAttrBonus = ev.LPJLEHAJADA("mcannon_plate_attr_bonus", 50);
			AKHNDMEHHLF_MCannonPlateSeriesBonus = ev.LPJLEHAJADA("mcannon_plate_series_bonus", 50);
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
	private JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM KNKJHNJFONJ_GetSave()
	{
		return KNKJHNJFONJ_GetSave(FJLIDJJAGOM());
	}

	// // RVA: 0x940430 Offset: 0x940430 VA: 0x940430
	private JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM KNKJHNJFONJ_GetSave(BKOGPDBKFFJ_EventRaid NDFIEMPPMLF)
	{
		if(NDFIEMPPMLF != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0x94055C Offset: 0x94055C VA: 0x94055C Slot: 5
	public override string IFKKBHPMALH()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.OCDMGOGMHGE;
		}
        return null;
	}

	// // RVA: 0x9406A4 Offset: 0x9406A4 VA: 0x9406A4
	private void BLNLNMLJIKO()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			for(int i = 0; i < ev.IJJHFGOIDOK_BossBattleList.Count; i++)
			{
				JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo m = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.GCINIJEMHFK(ev.IJJHFGOIDOK_BossBattleList[i].MPLGPBNJDJB_FreeMusicId);
				if(m != null)
				{
					m.EINIOBAIDCP();
				}
			}
		}
    }

	// // RVA: 0x940834 Offset: 0x940834 VA: 0x940834 Slot: 6
	public override string DCODGEOEDPG()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.PJBILOFOCIC;
		}
		return null;
	}

	// // RVA: 0x94097C Offset: 0x94097C VA: 0x94097C Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		return HEACCHAKMFG_GetMusicsList(0);
	}

	// // RVA: 0x940984 Offset: 0x940984 VA: 0x940984
	public List<int> HEACCHAKMFG_GetMusicsList(int MFMPCHIJINJ)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			BKOGPDBKFFJ_EventRaid.HAGIHCECBGH h = null;
			if(MFMPCHIJINJ != 0)
			{
				h = ev.POCOCNENCOE_GetBossInfo(MFMPCHIJINJ);
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<int> l = new List<int>(ev.IJJHFGOIDOK_BossBattleList.Count);
			for(int i = 0; i < ev.IJJHFGOIDOK_BossBattleList.Count; i++)
			{
				if(ev.IJJHFGOIDOK_BossBattleList[i].PLALNIIBLOF_Enabled == 2)
				{
					if((ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt == 0 && ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt == 0) || 
						(t >= ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt && t <= ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt))
					{
						if(h == null || ev.IJJHFGOIDOK_BossBattleList[i].HMHHNHEPAPP_BossId == h.PPFNGGCBJKC)
						{
							if(!l.Contains(ev.IJJHFGOIDOK_BossBattleList[i].MPLGPBNJDJB_FreeMusicId))
								l.Add(ev.IJJHFGOIDOK_BossBattleList[i].MPLGPBNJDJB_FreeMusicId);
						}
					}
				}
			}
			return l;
		}
		return null;
	}

	// // RVA: 0x940D44 Offset: 0x940D44 VA: 0x940D44
	public int KFBDBBCCPBB(int MFMPCHIJINJ)
	{
		List<int> l = HEACCHAKMFG_GetMusicsList(MFMPCHIJINJ);
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
	}

	// // RVA: 0x940ED0 Offset: 0x940ED0 VA: 0x940ED0 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_BossBattleList.Count; i++)
			{
				if(ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt != 0 && 
					ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt != 0 && 
					t >= ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt && 
					t <= ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt && 
					ev.IJJHFGOIDOK_BossBattleList[i].MPLGPBNJDJB_FreeMusicId == GHBPLHBNMBK)
				{
					return ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(GHBPLHBNMBK);
	}

	// // RVA: 0x9412E0 Offset: 0x9412E0 VA: 0x9412E0 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_BossBattleList.Count; i++)
			{
				if(ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt != 0 && 
					ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt != 0 && 
					ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt < DPJCPDKALGI_End1 &&
					t >= ev.IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt && 
					t <= ev.IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt && 
					ev.IJJHFGOIDOK_BossBattleList[i].MPLGPBNJDJB_FreeMusicId == GHBPLHBNMBK)
				{
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x941710 Offset: 0x941710 VA: 0x941710 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.EJBGHLOOLBC[OIPCCBHIKIA];
		}
		return 0;
	}

	// // RVA: 0x94188C Offset: 0x94188C VA: 0x94188C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0x941AA8 Offset: 0x941AA8 VA: 0x941AA8 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && GPHEKCNDDIK)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
			if(FBBNPFFEJBN || (t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time))
			{
				//LAB_00941de4
				KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP.OCGFKMHNEOF, () =>
				{
					//0xFDE8A0
					CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					PLOOEECNHFB = true;
				}, () =>
				{
					//0xFDEA64
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB = true;
				}, () =>
				{
					//0xFDEC0C
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
				}, () =>
				{
					//0xFDECA4
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
				});
				return;
			}
		}
		else
		{
			CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0x941F28 Offset: 0x941F28 VA: 0x941F28 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		BKOGPDBKFFJ_EventRaid LKOLAGLKIDA = FJLIDJJAGOM();
		if(LKOLAGLKIDA != null)
		{
            GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(LKOLAGLKIDA.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g == null)
				return false;
			if(JHNMKKNEENE < LKOLAGLKIDA.NGHKJOEDLIP.BONDDBOFBND_Start)
				return false;
			if(LKOLAGLKIDA.NGHKJOEDLIP.KNLGKBBIBOH_End < JHNMKKNEENE)
				return false;
			if(LKOLAGLKIDA.NGHKJOEDLIP.HKKNEAGCIEB != 0)
			{
				if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0xFDED44
					return LKOLAGLKIDA.NGHKJOEDLIP.OCGFKMHNEOF == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
				}) == null)
				{
					Debug.LogError(LKOLAGLKIDA.NGHKJOEDLIP.OCGFKMHNEOF+" not foud to enable event");
					return false;
				}
			}
			return true;
        }
		return false;
	}

	// // RVA: 0x9421F0 Offset: 0x9421F0 VA: 0x9421F0 Slot: 31
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_Missions;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_Quests;
			if(save.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP.OCGFKMHNEOF || (save.EGBOHDFBAPB_End < ev.NGHKJOEDLIP.BONDDBOFBND_Start && !RuntimeSettings.CurrentSettings.UnlimitedEvent))
			{
				save.LHPDDGIJKNB();
				save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP.OCGFKMHNEOF;
				save.EGBOHDFBAPB_End = ev.NGHKJOEDLIP.IDDBFFBPNGI;
				KOMAHOAEMEK(true);
				BLNLNMLJIKO();
			}
			KOMAHOAEMEK(false);
			JIMJHIDEHNM = new KAFHAKBBJEI();
			JIMJHIDEHNM.NEPIPMPAFIE_Stamina = save.NOKPCBEIJHJ_ApVal;
			JIMJHIDEHNM.DLPEEDCCNMJ_StaminaSaveTime = save.CKLPPIIKAKD_ApSaveTime;
			JIMJHIDEHNM.DCBENCMNOGO_MaxStamina = ev.LPJLEHAJADA("ap_max", 3);
			JIMJHIDEHNM.FLJGHBLEDDB_HealSec = ev.LPJLEHAJADA("ap_second", 2400);
			return true;
		}
		return false;
	}

	// // RVA: 0x942614 Offset: 0x942614 VA: 0x942614 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		BKOGPDBKFFJ_EventRaid LKOLAGLKIDA = FJLIDJJAGOM();
		if(LKOLAGLKIDA != null)
		{
			IBNKPMPFLGI_IsRankReward = LKOLAGLKIDA.NGHKJOEDLIP.HKKNEAGCIEB != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0xFDEDAC
					return LKOLAGLKIDA.NGHKJOEDLIP.OCGFKMHNEOF == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
				});
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = LKOLAGLKIDA.NGHKJOEDLIP.OPFGFINHFCE_Name;
			DOLJEDAAKNN = LKOLAGLKIDA.NGHKJOEDLIP.HEDAGCNPHGD;
			GLIMIGNNGGB_Start = LKOLAGLKIDA.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_End1 = LKOLAGLKIDA.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO = LKOLAGLKIDA.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH = LKOLAGLKIDA.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC = LKOLAGLKIDA.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_End = LKOLAGLKIDA.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = LKOLAGLKIDA.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			NHGPCLGPEHH_TicketType = LKOLAGLKIDA.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			FBHONHONKGD_MusicSelectDesc = LKOLAGLKIDA.NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc;
			HGLAFGHHFKP = LKOLAGLKIDA.NGHKJOEDLIP.JHPCPNJJHLI;
			GFIBLLLHMPD_StartAdventureId = LKOLAGLKIDA.NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = LKOLAGLKIDA.NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			PJLNJJIBFBN = LKOLAGLKIDA.NGHKJOEDLIP.AHKPNPNOAMO != 0;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(LKOLAGLKIDA.NGHKJOEDLIP.OMCAOJJGOGG))
			{
				string[] strs = LKOLAGLKIDA.NGHKJOEDLIP.OMCAOJJGOGG.Split(new char[] { ',' });
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = m;
			}
			LHAKGDAGEMM.Clear();
			for(int i = 0; i < LKOLAGLKIDA.LHAKGDAGEMM_Episodes.Count; i++)
			{
				CEGDBNNIDIG c = new CEGDBNNIDIG();
				c.KELFCMEOPPM_EpId = LKOLAGLKIDA.LHAKGDAGEMM_Episodes[i].KHPHAAMGMJP_Id;
				c.MIHNKIHNBBL = LKOLAGLKIDA.LHAKGDAGEMM_Episodes[i].OFIAENKCJME / 100.0f;
				c.MLLPMJFOKEC.AddRange(LKOLAGLKIDA.LHAKGDAGEMM_Episodes[i].KDNMBOBEGJM);
				LHAKGDAGEMM.Add(c);
			}
			PGDAMNENGDA.Clear();
			for(int i = 0; i < LKOLAGLKIDA.OGMHMAGDNAM.Count; i++)
			{
				NJJDBBCHBNP n = new NJJDBBCHBNP();
				n.GJEADBKFAPA = LKOLAGLKIDA.OGMHMAGDNAM[i].PPFNGGCBJKC;
				n.IJKFFIKGLJM = LKOLAGLKIDA.OGMHMAGDNAM[i].GNFBMCGMCFO;
				n.DCBMFNOIENM = LKOLAGLKIDA.OGMHMAGDNAM[i].BFFGFAMJAIG;
				PGDAMNENGDA.Add(n);
			}
			DHOMAEOEFMJ.Clear();
			for(int i = 0; i < LKOLAGLKIDA.GEGAEDDGNMA.Count; i++)
			{
				MEBJJBHPMEO m = new MEBJJBHPMEO();
				m.PPFNGGCBJKC = LKOLAGLKIDA.GEGAEDDGNMA[i].PPFNGGCBJKC;
				m.GNFBMCGMCFO = LKOLAGLKIDA.GEGAEDDGNMA[i].GNFBMCGMCFO;
				m.BFFGFAMJAIG = LKOLAGLKIDA.GEGAEDDGNMA[i].BFFGFAMJAIG;
				m.CNKFPJCGNFE = LKOLAGLKIDA.GEGAEDDGNMA[i].CNKFPJCGNFE;
				DHOMAEOEFMJ.Add(m);
			}
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x943284 Offset: 0x943284 VA: 0x943284 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			PIMFJALCIGK();
		}
		PLOOEECNHFB = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD31C Offset: 0x6BD31C VA: 0x6BD31C
	// // RVA: 0x9433E8 Offset: 0x9433E8 VA: 0x9433E8 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xFE64DC
		KGBCKPKLKHM_RewardItems.Clear();
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> l = new List<string>();
				l.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(l, AOCANKOMKFG));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD394 Offset: 0x6BD394 VA: 0x6BD394
	// // RVA: 0x94348C Offset: 0x94348C VA: 0x94348C Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xFE61C8
		KGBCKPKLKHM_RewardItems.Clear();
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> l = new List<string>();
				l.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(l, AOCANKOMKFG));
			}
		}
	}

	// // RVA: 0x943530 Offset: 0x943530 VA: 0x943530 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			KIBBLLADDPO = false;
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(JHNMKKNEENE >= ev.NGHKJOEDLIP.BONDDBOFBND_Start)
			{
				if(DPJCPDKALGI_End1 >= JHNMKKNEENE)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG == 0)
							{
								IBLPKJJNNIG = true;
								break;
							}
						}
					}
					if(!save.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
						if(JHNMKKNEENE < ev.NGHKJOEDLIP.EHHFFKAFOMC)
							return;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL == null)
							return;
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
							{
								BELBNINIOIE = true;
								break;
							}
						}
						return;
					}
					if(!save.ABBJBPLHFHA_Spurt)
					{
						if(JHNMKKNEENE >= ev.NGHKJOEDLIP.EHHFFKAFOMC)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
							KIBBLLADDPO = true;
							if(MBHDIJJEOFL == null)
								return;
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
							return;
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
					}
					else
					{
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
					}
				}
				else
				{
					if(JHNMKKNEENE >= ev.NGHKJOEDLIP.JGMDAOACOJF)
					{
						if(JHNMKKNEENE >= ev.NGHKJOEDLIP.IDDBFFBPNGI)
						{
							if(JHNMKKNEENE >= ev.NGHKJOEDLIP.KNLGKBBIBOH_End)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							}
							else
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
							}
						}
						else
						{
							if(!save.HPLMECLKFID_RRcv)
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
							else
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						}
					}
					else
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
					}
				}
			}
			else
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			}
			return;
		}
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
		KIBBLLADDPO = false;
	}

	// // RVA: 0x943B38 Offset: 0x943B38 VA: 0x943B38 Slot: 48
	public override void AMKJFGLEJGE(int KPIILHGOGJD)
	{
        EECOJKDJIFG LONLNGJAEEK = DAKMIKNKHMF_GetRankingInfoForIndex(KPIILHGOGJD);
		if(LONLNGJAEEK != null)
		{
            BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null && FBHONHONKGD_MusicSelectDesc != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				PJDGDNJNCNM_UpdateStatusImpl(t);
				if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7 && ((1 << (int)NGOFCFJHOMI_Status) & 0x6c) != 0) // 2 3 5 6
				{
					EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG GHPLINIACBB) =>
					{
						//0xFDEE14
						return LONLNGJAEEK.OCGFKMHNEOF_NameForApi == GHPLINIACBB.OCGFKMHNEOF_NameForApi;
					});
					if(e != null)
					{
						PKECIDPBEFL.DDBKLMKKCDL p = new PKECIDPBEFL.DDBKLMKKCDL();
						p.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_Start, LOLAANGCGDO, save.NFIOKIBPJCJ_Uptime, save.DNBFMLBNAEE_Point);
						p.BLJIJENHBPM_Id = e.PPFNGGCBJKC_Id;
						p.OBGBAOLONDD_Unq = PGIIDPEGGPI_EventId;
						p.NOBCHBHEPNC_Idx = KPIILHGOGJD;
						JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(p);
					}
				}
			}
        }
    }

	// // RVA: 0x943F40 Offset: 0x943F40 VA: 0x943F40 Slot: 49
	// protected override void ODPJGHOJIOH(int LHJCOPMMIGO) { }

	// // RVA: 0x944290 Offset: 0x944290 VA: 0x944290 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && IBNKPMPFLGI_IsRankReward)
		{
			KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM.OCGFKMHNEOF_NameForApi, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xFDF114
				PLOOEECNHFB = true;
				KLMFJJCNBIP(NEFEFHBHFFF, MAGKKPOFJIM);
			}, () =>
			{
				//0xFDF170
				PLOOEECNHFB = true;
				IDAEHNGOKAE();
			}, () =>
			{
				//0xFDF1BC
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				JGKOLBLPMPG();
			}, false);
			return;
		}
		IDAEHNGOKAE();
		PLOOEECNHFB = true;
	}

	// // RVA: 0x944574 Offset: 0x944574 VA: 0x944574 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			IDAEHNGOKAE();
			PLOOEECNHFB = false;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int JGNBPFCJLKI, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xFDF228
				PLOOEECNHFB = true;
				KLMFJJCNBIP(JGNBPFCJLKI, MAGKKPOFJIM);
			}, () =>
			{
				//0xFDF284
				PLOOEECNHFB = true;
				IDAEHNGOKAE();
			}, () =>
			{
				//0xFDF2D0
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				JGKOLBLPMPG();
			}, false);
		}
	}

	// // RVA: 0x944770 Offset: 0x944770 VA: 0x944770
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC) { }

	// // RVA: 0x943398 Offset: 0x943398 VA: 0x943398
	private void PIMFJALCIGK()
	{
		int a = NGIHFKHOJOK_GetRankingMax(true);
		if(a < 1)
			return;
		for(int i = 0; i < a; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0x944868 Offset: 0x944868 VA: 0x944868
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
			if(KBACNOCOANM != null)
			{
				for(int i = 0; i < KBACNOCOANM.AHJNPEAMCCH_Rewards.Count; i++)
				{
					MAOCCKFAOPC m = new MAOCCKFAOPC();
					m.JBDGBPAAAEF_HighRank = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].JPHDGGNAKMO_HighRank;
					m.GHANKNIBALB_LowRank = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].FGCAJEAIABA_LowRank;
					m.MJGAMDBOMHD_InventoryMessage = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].IPFEKNMBEBI_InventoryMessage;
					m.HBHMAKNGKFK_Items = KBACNOCOANM.AHJNPEAMCCH_Rewards[i].HBHMAKNGKFK_Items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
				}
			}
		}
	}

	// // RVA: 0x944C94 Offset: 0x944C94 VA: 0x944C94 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		BKOGPDBKFFJ_EventRaid NDFIEMPPMLF = FJLIDJJAGOM();
		if(NDFIEMPPMLF != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				HLFHJIDHJMP = null;
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf());
				req.EMPNJPMAKBF_Id = KBACNOCOANM.PPFNGGCBJKC_Id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_From = 0;
				req.PJFKNNNDMIA_To = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xFDF33C
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI = true;
						}
						JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
					}
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xFDF668
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG.EJDEDOJFOOK.Count == 0)
					{
						JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_CurrentPoint = r.NFEAMMJIMPG.EJDEDOJFOOK[0].KNIFCANOHOC_Score;
						HLFHJIDHJMP.FJOLNJLLJEJ_Rank = r.NFEAMMJIMPG.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM.OCGFKMHNEOF_NameForApi, () =>
						{
							//0xFDFD3C
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD m = new MFDJIFIIPJD();
								m.KHEKNNFCAOI(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemFullId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_ItemCount);
								HLFHJIDHJMP.HBHMAKNGKFK.Add(m);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB = true;
						}, () =>
						{
							//0xFE00B8
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB = true;
						}, () =>
						{
							//0xFE02A0
							JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xFE042C
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xFE0474
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
						}, 0, -1);
					}
				};
				return;
			}
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0x944FD0 Offset: 0x944FD0 VA: 0x944FD0
	// public KAMKMOKMPAN.GGPEAOAOEPH BPOCKIHHJKH() { }

	// // RVA: 0x9451E8 Offset: 0x9451E8 VA: 0x9451E8
	public void JMEPDDLGPJF_SetStep(KAMKMOKMPAN.GGPEAOAOEPH LGADCGFMLLD)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			save.LGADCGFMLLD_Step = (int)LGADCGFMLLD;
		}
	}

	// // RVA: 0x945404 Offset: 0x945404 VA: 0x945404 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
			if(GFIBLLLHMPD_StartAdventureId != 0)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					return (save.INLNJOGHLJE_Show & 1) == 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0x9456FC Offset: 0x9456FC VA: 0x9456FC Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		if(JKDJCFEBDHC)
		{
			BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					save.INLNJOGHLJE_Show |= 1;
				}
			}
		}
	}

	// // RVA: 0x94593C Offset: 0x94593C VA: 0x94593C Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD40C Offset: 0x6BD40C VA: 0x6BD40C
	// // RVA: 0x945994 Offset: 0x945994 VA: 0x945994
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		long IBCGNDADAEE; // 0x28
		BKOGPDBKFFJ_EventRaid KEHCNBNPJHB; // 0x30
		JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM AIPLGDHHAJI; // 0x34
		int JEKGKAPLIHO; // 0x38

		//0xFE0678
		IBCGNDADAEE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		PLFBKEPLAAA = null;
		KONJMFICNJJ = null;
		EGOJLOEFMOH = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN = 0;
		KEHCNBNPJHB = FJLIDJJAGOM();
		if(KEHCNBNPJHB != null)
		{
			NPNNPNAIONN = false;
			PLOOEECNHFB = false;
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB)
				yield return null;
			if(!NPNNPNAIONN)
			{
				AIPLGDHHAJI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(FKKDIDMGLMI)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
					yield break;
				}
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
				{
					AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
					LPFJADHHLHG = true;
					PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
				}
				CFLEMFADGLG = JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1;
				JEKGKAPLIHO = (int)NGOFCFJHOMI_Status;
                int step = AIPLGDHHAJI.LGADCGFMLLD_Step;
				if(JEKGKAPLIHO < 6)
				{
					switch(step)
					{
						case 0:
						case 1:
							CMPEJEHCOEI = true;
							AIPLGDHHAJI.LGADCGFMLLD_Step = 2;
							AIPLGDHHAJI.IMFBCJOIJKJ_Entry = true;
							if(KIBBLLADDPO)
							{
								AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
								LPFJADHHLHG = true;
							}
							CPOAJKMPPMF_SetSaveFMId(HEACCHAKMFG_GetMusicsList()[0]);
							FGDDBFHGCGP_SetStartAdventureShown(true, 0);
							break;
						case 2:
							BCBCODAKIDN = JKPDCKDMKBN();
							if(BCBCODAKIDN != 0)
							{
								CPOAJKMPPMF_SetSaveFMId(HEACCHAKMFG_GetMusicsList()[0]);
								EGOJLOEFMOH = true;
							}
							break;
						case 3:
						case 4:
							AIPLGDHHAJI.MHKICPIMFEI_PlayCnt++;
							AIPLGDHHAJI.LGADCGFMLLD_Step = 2;
							break;
					}
				}
				else
				{
					AIPLGDHHAJI.LGADCGFMLLD_Step = 5;
				}
				if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
				{
					if(GFIBLLLHMPD_StartAdventureId > 0)
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
						{
							if(!AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv)
							{
								bool KPIGMCJMFAN = false;
								yield return Co.R(JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
								{
									//0xFE0634
									KPIGMCJMFAN = true;
								}));
								if(!KPIGMCJMFAN)
								{
									if(JBPPMMMFGCA_HasRewardItems())
									{
										AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv = true;
									}
									//LAB_00fe10c8
								}
								else
								{
									AOCANKOMKFG();
									yield break;
								}
							}
						}
					}
				}
				else if(NGOFCFJHOMI_Status >= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive && CAKEOPLJDAF_EndAdventureId > 0)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
					{
						if(!AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
							{
								//0xFE0648
								KPIGMCJMFAN = true;
							}));
							if(!KPIGMCJMFAN)
							{
								if(JBPPMMMFGCA_HasRewardItems())
								{
									AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv = true;
								}
								//LAB_00fe10c8
							}
							else
							{
								AOCANKOMKFG();
								yield break;
							}
						}
					}
				}
				//LAB_00fe10c8
				OIMGJLOLPHK = false;
				if(JEKGKAPLIHO < 6)
				{
					CEBFFLDKAEC_SecureInt a;
					if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(HOEKCEJINNA, out a))
					{
						bool b = DLHEEOIELBA(a.DNJEJEANJGL_Value);
						if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
						{
							if(!b)
							{
								AIPLGDHHAJI.INLNJOGHLJE_Show |= 4;
							}
						}
						else
						{
							if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(FOKNMOMNHHD, out a) && b)
							{
								if((AIPLGDHHAJI.INLNJOGHLJE_Show & 4) != 0)
								{
									GFHKFKHBIGM = true;
									OGPMLMDPGJA = a.DNJEJEANJGL_Value;
								}
							}
						}
						OIMGJLOLPHK = b;
					}
				}
				bool BEKAMBBOLBO = false;
				bool CNAIDEAFAAM = false;
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CKJHFFHFPLH_GetFriends(() =>
				{
					//0xFE04C0
					BEKAMBBOLBO = true;
				}, (CACGCMBKHDI_Request ADKIDBJCAJA) =>
				{
					//0xFE04CC
					CNAIDEAFAAM = true;
				}, (CACGCMBKHDI_Request ADKIDBJCAJA) =>
				{
					//0xFE04D8
					CNAIDEAFAAM = true;
				});
				//LAB_00fe143c
				while(!BEKAMBBOLBO && !CNAIDEAFAAM)
					yield return null;
				if(!CNAIDEAFAAM)
				{
					if(!AIPLGDHHAJI.KILJKLIHMAE_SboRcv)
					{
						int a, b;
						if(!PPPEFGFIGMH(out a, out b))
						{
							AIPLGDHHAJI.KILJKLIHMAE_SboRcv = true;
						}
					}
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xFE04E4
						ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
						PLOOEECNHFB = true;
						BHFHGFKBOHH();
					}, () =>
					{
						//0xFE05C8
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						AOCANKOMKFG();
					}, null);
					yield break;
				}
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
            }
			//break;
			AOCANKOMKFG();
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
		}
	}

	// // RVA: 0x945A4C Offset: 0x945A4C VA: 0x945A4C Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x945C68 Offset: 0x945C68 VA: 0x945C68 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x945D90 Offset: 0x945D90 VA: 0x945D90 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x945ED4 Offset: 0x945ED4 VA: 0x945ED4 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x946018 Offset: 0x946018 VA: 0x946018 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && BHABCGJCGNO != null && LPEKHFOMCAH < DPJCPDKALGI_End1)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
			{
				save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
				{
					EGOLBAPFHHD_Common.FKLHGOGJOHH enIt = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId) - 1];
					enIt.BFINGCJHOHI_Cnt += BHABCGJCGNO.MBJIFDBEDAC_Cnt;
					enIt.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, enIt.BFINGCJHOHI_Cnt, 1);
				}
				return true;
            }
		}
		return false;
	}

	// // RVA: 0x9467BC Offset: 0x9467BC VA: 0x9467BC
	public int JCBDKEPCLKG_GetRaidBossHelpMaxCount()
	{
		return BAEPGOAMBDK("raid_boss_help_max_num", 15);
	}

	// // RVA: 0x946830 Offset: 0x946830 VA: 0x946830
	public void HEOFEABCBCC(out int GEJGMBBCFEE, out int CCIHMCAPHCB)
	{
		GEJGMBBCFEE = 0;
		CCIHMCAPHCB = 0;
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			GEJGMBBCFEE = evLobby.DKNNNOIMMFN_GetClusterId();
			int t = BAEPGOAMBDK("raid_zentai_help_range_time", 21600);
			CCIHMCAPHCB = GEJGMBBCFEE - t;
			if(GEJGMBBCFEE < t)
				CCIHMCAPHCB = 0;
		}
	}

	// // RVA: 0x946A94 Offset: 0x946A94 VA: 0x946A94 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.MDADLCOCEBN_SessionId;
		}
		return "";
	}

	// // RVA: 0x946CBC Offset: 0x946CBC VA: 0x946CBC Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && MNNNLDFNNCD(JHNMKKNEENE))
		{
			return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.IJJHFGOIDOK_BossBattleList[0].MPLGPBNJDJB_FreeMusicId).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
		}
		return null;
	}

	// // RVA: 0x946F98 Offset: 0x946F98 VA: 0x946F98 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.IJJHFGOIDOK_BossBattleList[0].MPLGPBNJDJB_FreeMusicId).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
		}
		return 0;
	}

	// // RVA: 0x94720C Offset: 0x94720C VA: 0x94720C
	private void CPOAJKMPPMF_SetSaveFMId(int GHBPLHBNMBK)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			save.LIEKIBHAPKC_FId = GHBPLHBNMBK;
		}
	}

	// // RVA: 0x947418 Offset: 0x947418 VA: 0x947418
	public int EOAMLLMMCPD_GetSaveFMId()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.LIEKIBHAPKC_FId;
		}
		return 23;
	}

	// // RVA: 0x947624 Offset: 0x947624 VA: 0x947624
	public void EHADIPOAOEA_SelectNextSong()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			List<int> l = HEACCHAKMFG_GetMusicsList();
			if(save.LIEKIBHAPKC_FId > 0 && l.Count > 1)
			{
				l.Remove(save.LIEKIBHAPKC_FId);
			}
			int v = UnityEngine.Random.Range(0, l.Count);
			CPOAJKMPPMF_SetSaveFMId(l[v]);
		}
	}

	// // RVA: 0x947920 Offset: 0x947920 VA: 0x947920
	private int JKPDCKDMKBN()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			int a = 0;
			int b = 0;
			IBJAKJJICBC ib = IBJAKJJICBC.MLMMPFACEKI_FindMusicInLists(EOAMLLMMCPD_GetSaveFMId(), 
				IBJAKJJICBC.DHFHJBMKEHN(1, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(2, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(3, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(4, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(5, t, false),
				IBJAKJJICBC.DHFHJBMKEHN(6, t, false),
				ref a, ref b);
			if(ib != null)
			{
				if(ib.LHONOILACFL_IsWeeklyEvent)
				{
					if(ib.BELHFPMBAPJ_WeekPlay < ib.JOJNGDPHOKG_WeeklyMax)
					{
						return 0;
					}
					return 2;
				}
				else
				{
					return 0;
				}
			}
			return 1;
		}
		return 0;
	}

	// // RVA: 0x947C94 Offset: 0x947C94 VA: 0x947C94 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
			if(ev != null)
			{
				JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DMDOCAPGOEE_EventRaid.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				save.INLNJOGHLJE_Show &= ~4;
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0x947ECC Offset: 0x947ECC VA: 0x947ECC Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt && 
					t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_BannerText;
				}
			}
		}
		return "";
	}

	// // RVA: 0x9481F0 Offset: 0x9481F0 VA: 0x9481F0
	// public int NMLIONILBMC() { }

	// // RVA: 0x948238 Offset: 0x948238 VA: 0x948238
	public string AGEJGHGEGFF_GetBossName(int MFMPCHIJINJ)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.POCOCNENCOE_GetBossInfo(MFMPCHIJINJ).OPFGFINHFCE_Name;
		}
		return "";
	}

	// // RVA: 0x9482D8 Offset: 0x9482D8 VA: 0x9482D8
	public SeriesAttr.Type NNDFMCHDJOH_GetBossSerie(int MFMPCHIJINJ)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return (SeriesAttr.Type) ev.POCOCNENCOE_GetBossInfo(MFMPCHIJINJ).CPKMLLNADLJ_Serie;
		}
		return 0;
	}

	// // RVA: 0x948320 Offset: 0x948320 VA: 0x948320
	// public bool BMDEELGBBOI(int MFMPCHIJINJ) { }

	// // RVA: 0x948370 Offset: 0x948370 VA: 0x948370
	public int KNNHGJFJAEN_GetNumBosses()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.GJFJLEOGFLD_BossInfo.Count;
		}
		return 0;
	}

	// // RVA: 0x948400 Offset: 0x948400 VA: 0x948400
	private static bool MFAFEBNEEHE_IsMyself(int MLPEHNBNOGD)
	{
		return NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId == MLPEHNBNOGD;
	}

	// // RVA: 0x9484B0 Offset: 0x9484B0 VA: 0x9484B0
	public string ICCEILFHKEL_GetUtaGradeMoreText()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.EFEGBHACJAL("uta_grade_more_text", "");
		}
		return "";
	}

	// // RVA: 0x948548 Offset: 0x948548 VA: 0x948548
	public MJFMOPMOFDJ PMIIMELDPAJ_GetMyBoss()
	{
		return PBJBHONLMKF_MyBoss;
	}

	// // RVA: 0x948550 Offset: 0x948550 VA: 0x948550
	public MJFMOPMOFDJ HCFDHLNNDAN(int OIPCCBHIKIA)
	{
		return ECPHFLNMECN[OIPCCBHIKIA];
	}

	// // RVA: 0x9485D0 Offset: 0x9485D0 VA: 0x9485D0
	public int EHJOBALDPBG()
	{
		return ECPHFLNMECN.Count;
	}

	// // RVA: 0x948670 Offset: 0x948670 VA: 0x948670
	private BKOGPDBKFFJ_EventRaid.MNFPNLMPOEB CMMDPDMNNKP(BKOGPDBKFFJ_EventRaid NDFIEMPPMLF, JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		return NDFIEMPPMLF.NFOECEGILLC[(int)INDDJNMPONH - 1];
	}

	// // RVA: 0x948700 Offset: 0x948700 VA: 0x948700
	public int EMJEBMMMDBE(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CMMDPDMNNKP(ev, INDDJNMPONH).KMHIOCCFPEM;
		}
		return 0;
	}

	// // RVA: 0x948748 Offset: 0x948748 VA: 0x948748
	public int AFODCOIFHKO(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return CMMDPDMNNKP(ev, INDDJNMPONH).PIABNPEFLEJ;
		}
		return 0;
	}

	// // RVA: 0x948790 Offset: 0x948790 VA: 0x948790
	public int MCBGNPBECCI_SupportBonusMax()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			return ev.LPJLEHAJADA("coop_bonus_max", 100);
		}
		return 0;
	}

	// // RVA: 0x948810 Offset: 0x948810 VA: 0x948810
	public bool APGPNCKBADI_GetEncounterStartEndTime(out DateTime FKPEAGGKNLC, out DateTime KOMKKBDABJP)
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev == null || !ev.GNKACELEIAC("encounter_start_time"))
		{
			FKPEAGGKNLC = new DateTime();
			KOMKKBDABJP = new DateTime();
			return false;
		}
		else
		{
			string s = ev.EFEGBHACJAL("encounter_start_time", "10:00");
			FKPEAGGKNLC = DateTime.Parse(s);
			s = ev.EFEGBHACJAL("encounter_end_time", "23:59");
			KOMKKBDABJP = DateTime.Parse(s);
			return true;
		}
	}

	// // RVA: 0x948984 Offset: 0x948984 VA: 0x948984
	public bool FJBIJAGCGKC_IsEncounterTimeOk()
	{
		DateTime a, b;
		if(APGPNCKBADI_GetEncounterStartEndTime(out a, out b))
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			DateTime dt = Utility.GetLocalDateTime(t);
			long t1 = Utility.GetTargetUnixTime(dt.Year, dt.Month, dt.Day, a.Hour, a.Minute, a.Second);
			long t2 = Utility.GetTargetUnixTime(dt.Year, dt.Month, dt.Day, b.Hour, b.Minute, b.Second);
			return t >= t1 && t2 >= t;
		}
		return true;
	}

	// // RVA: 0x948C30 Offset: 0x948C30 VA: 0x948C30
	public int NPICFLFAIJK_GetNumTicket()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			return evLobby.ONKKHPKHCIA_GetNumTicket();
		}
		return 0;
	}

	// // RVA: 0x948D40 Offset: 0x948D40 VA: 0x948D40
	public bool KBFCALJDLPH()
	{
		if(!PBJBHONLMKF_MyBoss.DNJGAJPIIPI && NPICFLFAIJK_GetNumTicket() > 0)
		{
			return FJBIJAGCGKC_IsEncounterTimeOk();
		}
		return false;
	}

	// // RVA: 0x948D94 Offset: 0x948D94 VA: 0x948D94
	private bool IBGMIDDJECI()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			evLobby.OMNKLDDHNNE();
			return true;
		}
		return false;
	}

	// // RVA: 0x948EAC Offset: 0x948EAC VA: 0x948EAC
	private void KHPCBKAEGBC()
	{
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(evLobby != null)
		{
			evLobby.IMBLLJAEMAI_UseTicket(1);
		}
	}

	// // RVA: 0x948FBC Offset: 0x948FBC VA: 0x948FBC
	public void KECLCFBKMOA_EncounterBoss(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK IILBGCMIEDJ)
	{
		N.a.StartCoroutineWatched(IDNENICNGHO_Coroutine_EncounterBoss(BHFHGFKBOHH, AOCANKOMKFG, IILBGCMIEDJ));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD4E4 Offset: 0x6BD4E4 VA: 0x6BD4E4
	// // RVA: 0x949024 Offset: 0x949024 VA: 0x949024
	private IEnumerator IDNENICNGHO_Coroutine_EncounterBoss(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK IILBGCMIEDJ)
	{
		//0xFE37E4
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true) == null)
		{
			if(IBGMIDDJECI())
			{
				bool BEKAMBBOLBO = false;
				bool CNAIDEAFAAM = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xFD6394
					BEKAMBBOLBO = true;
				}, () =>
				{
					//0xFD63A0
					CNAIDEAFAAM = true;
				}, null);
				while(!BEKAMBBOLBO && !CNAIDEAFAAM)
					yield return null;
				if(!CNAIDEAFAAM)
				{
					KDMINIMGGLI_EncounterRaidboss BIHCCEHLAOD = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KDMINIMGGLI_EncounterRaidboss());
					BIHCCEHLAOD.BIHCCEHLAOD.MMEBLOIJBKE_UniqueKey = JLIICBOHICB_GetBossUniqueKey();
					if(IILBGCMIEDJ != null)
						BIHCCEHLAOD.NBFDEFGFLPJ = JGJFFKPFMDB.IOGGLELGHLO;
					PLOOEECNHFB = false;
					NPNNPNAIONN = false;
					BIHCCEHLAOD.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
					{
						//0xFD63AC
						KDMINIMGGLI_EncounterRaidboss r = HKICMNAACDA as KDMINIMGGLI_EncounterRaidboss;
						PBJBHONLMKF_MyBoss.LHPDDGIJKNB();
						PBJBHONLMKF_MyBoss.MLPEHNBNOGD_Id = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
						OFAHKDKDGAN(PBJBHONLMKF_MyBoss, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
						NBPANDOEDJH(PBJBHONLMKF_MyBoss, r.NFEAMMJIMPG);
						PBJBHONLMKF_MyBoss.CMCKNKKCNDK_Status = NHCDBBBMFFG.MBFHILFLPJL_1_Alive;
						PBJBHONLMKF_MyBoss.DLMNFENNCJG_IsEntry = false;
						PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = true;
						PBJBHONLMKF_MyBoss.ICCOOAAJEIN_CanReceiveReward = false;
						PBJBHONLMKF_MyBoss.EMHHJNDOCMB(r.NFEAMMJIMPG.MGPCMCNFFIM);
						FMGJILBBNBJ_UpdateCoopBonus(PBJBHONLMKF_MyBoss);
						KHPCBKAEGBC();
                        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM ev = KNKJHNJFONJ_GetSave();
						if(ev != null)
						{
							ev.HBHCCLGECOC_MyBossId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id;
							ev.CPPNJFGEBNM_ResetMyBossAttacksCount();
						}
						IPEIKLJLCJL(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id, PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial);
						HCKEDINDNAP(PBJBHONLMKF_MyBoss);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.KMHJDFJHMEP_35);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
						ILCCJNDFFOB.HHCJCDFCLOB.KCCMKAEPGPE(this, NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId(), 1, NPICFLFAIJK_GetNumTicket());
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
						{
							//0xFD6B08
							PLOOEECNHFB = true;
							BHFHGFKBOHH();
						}, () =>
						{
							//0xFD6B54
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							AOCANKOMKFG();
						}, null);
                    };
					BIHCCEHLAOD.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
					{
						//0xFD6BB8
						if(!JGJFFKPFMDB.IOGGLELGHLO(HKICMNAACDA.CJMFJOMECKI_ErrorId))
							return;
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.KMHJDFJHMEP_35);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
						NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
						if(evLobby != null)
						{
							evLobby.DOCCMMJMJMP();
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0xFD6EE8
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
								if(IILBGCMIEDJ != null)
									IILBGCMIEDJ();
							}, () =>
							{
								//0xFD6F40
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
								AOCANKOMKFG();
							}, null);
							return;
						}
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						AOCANKOMKFG();
					};
					yield break;
				}
			}
		}
		//LAB_00fe3c7c
		PLOOEECNHFB = true;
		NPNNPNAIONN = true;
		AOCANKOMKFG();
	}

	// // RVA: 0x9490F8 Offset: 0x9490F8 VA: 0x9490F8
	private string JLIICBOHICB_GetBossUniqueKey()
	{
		BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			BKOGPDBKFFJ_EventRaid.PIDMOGPJNNA boss = null;
			for(int i = 0; i < ev.BFKJBHMHKAH.Count; i++)
			{
				boss = ev.BFKJBHMHKAH[i];
				if(ev.BFKJBHMHKAH[i].ICLFADEFBIH <= GameManager.Instance.ViewPlayerData.BJGOPOEAAIC)
					break;
			}
			int boss_level_random_p = ev.LPJLEHAJADA("boss_level_random_+", 2);
			int boss_level_random_m = ev.LPJLEHAJADA("boss_level_random_-+", 2);
			int v = UnityEngine.Random.Range(-boss_level_random_m, boss_level_random_p + 1);
			int s = Mathf.Clamp(v + boss.PPFNGGCBJKC, 1, ev.BFKJBHMHKAH.Count);
			int t = 0;
			for(int i = 0; i < ev.GJFJLEOGFLD_BossInfo.Count; i++)
			{
				t += ev.GJFJLEOGFLD_BossInfo[i].AKBHPFBDDOL;
			}
			int v2 = UnityEngine.Random.Range(0, t);
			BKOGPDBKFFJ_EventRaid.HAGIHCECBGH b = null;
			int idx = 0;
			for(int i = 0; i < ev.GJFJLEOGFLD_BossInfo.Count; i++)
			{
				v2 -= ev.GJFJLEOGFLD_BossInfo[i].AKBHPFBDDOL;
				if(v2 <= 0)
				{
					idx = i;
					b = ev.GJFJLEOGFLD_BossInfo[i];
					break;
				}
			}
            BKOGPDBKFFJ_EventRaid.PIDMOGPJNNA d = ev.ODMCAHDEEBK(s);
            StringBuilder str = new StringBuilder(32);
			str.SetFormat("boss_{0}_{1}_{2}{3}", new object[4]
			{
				idx, s, b.PIPCIMIALOO == 1 ? d.OMIEMNDOPKA : d.LLNDMKBBNIJ, b.PIPCIMIALOO == 1 ? "_sp" : ""
			});
			return str.ToString();
		}
		return null;
	}

	// // RVA: 0x9497EC Offset: 0x9497EC VA: 0x9497EC
	public void CFKCMIBJOIA_GetBossLevelRandMinMax(out int LCIIDGAPDCN, out int OGOHJAFOEPG)
	{
		LCIIDGAPDCN = 0;
		OGOHJAFOEPG = 0;
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			LCIIDGAPDCN = ev.LPJLEHAJADA("boss_level_random_+", 2);
			OGOHJAFOEPG = ev.LPJLEHAJADA("boss_level_random_-", 2);
		}
    }

	// // RVA: 0x9498A8 Offset: 0x9498A8 VA: 0x9498A8
	public void FGIHOCHKKMD(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		NKOBMDPHNGP_EventRaidLobby LLDNJABJNFH = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		if(LLDNJABJNFH != null)
		{
			if(LLDNJABJNFH.LDEPDKGNAPK())
			{
				IEFFGONGBCD_GetMyRaidBosses((List<NCMFOICNJEB<EBHIMFFJBIJ>> DIDOEKOBNNJ) =>
				{
					//0xFD6FAC
					bool b = false;
					for(int i = 0; i < DIDOEKOBNNJ.Count; i++)
					{
						if(NKGJPJPHLIF.HHCJCDFCLOB.KKMCBNKDDPN(DIDOEKOBNNJ[i].MBEMFKGBIEO_EncounterPlayerId))
						{
							b = true;
							KHPCBKAEGBC();
							break;
						}
					}
					if(!b)
					{
						LLDNJABJNFH.DOCCMMJMJMP();
					}
					PLOOEECNHFB = true;
					BHFHGFKBOHH();
				}, MOBEEPPKFLG);
				return;
			}
		}
		NPNNPNAIONN = false;
		PLOOEECNHFB = true;
		BHFHGFKBOHH();
	}

	// // RVA: 0x949CE0 Offset: 0x949CE0 VA: 0x949CE0
	private void OFAHKDKDGAN(FCDIHBGEKOB BCGAOHJKPIG, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		BCGAOHJKPIG.AHEFHIMGIBI_ServerData = AHEFHIMGIBI;
		BCGAOHJKPIG.LHMDABPNDDH_Type = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(BCGAOHJKPIG.MLPEHNBNOGD_Id) ? IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend : IBIGBMDANNM.LJJOIIAEICI.CCAPCGPIIPF_Guest;
		JJGJJALILHC.CalcUtaRate(AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.AEIADFODLMC_HsRating);
		BCGAOHJKPIG.OFHFGHJEKKL = JJGJJALILHC.GetUtaRateTotal();
		BCGAOHJKPIG.HIMMCGKKOOL_Rate = (int) JJGJJALILHC.GetUtaGrade();
	}

	// // RVA: 0x949E80 Offset: 0x949E80 VA: 0x949E80
	private void NBPANDOEDJH(MJFMOPMOFDJ DACHLLPBFPI, LBICPMOLOKD CHCEIJOJDHL)
	{
		DACHLLPBFPI.PPFNGGCBJKC_Id = CHCEIJOJDHL.PPFNGGCBJKC_Id;
		DACHLLPBFPI.MMEBLOIJBKE_UniqueKey = CHCEIJOJDHL.MMEBLOIJBKE_UniqueKey;
		DACHLLPBFPI.BCCOMAODPJI_HpCurrent = CHCEIJOJDHL.BCCOMAODPJI_Hp;
		DACHLLPBFPI.PIKKHCGNGNN_HpMax = CHCEIJOJDHL.FFBHEHAIHMA_MaxHp;
		DACHLLPBFPI.MHABJOMJCFI_JoinedMember = CHCEIJOJDHL.MHABJOMJCFI_AttackPlayerCount;
		DACHLLPBFPI.AJCCONCCIMF_EscapeAt = CHCEIJOJDHL.PPLAPJDENND_EscapedAt;
		string[] strs = DACHLLPBFPI.MMEBLOIJBKE_UniqueKey.Split(new char[] { '_' });
		DACHLLPBFPI.INDDJNMPONH_Type = int.Parse(strs[1]);
		DACHLLPBFPI.ANAJIAENLNB_Level = int.Parse(strs[2]);
		DACHLLPBFPI.IKICLMGFFPB_IsSpecial = strs.Length > 4;
		DACHLLPBFPI.FJOLNJLLJEJ_Rank = FJLIDJJAGOM().ODMCAHDEEBK(DACHLLPBFPI.ANAJIAENLNB_Level).FJOLNJLLJEJ;
		DACHLLPBFPI.HPPDFBKEJCG_BgId = FJLIDJJAGOM().POCOCNENCOE_GetBossInfo(DACHLLPBFPI.INDDJNMPONH_Type).PPFNGGCBJKC;
	}

	// // RVA: 0x94A118 Offset: 0x94A118 VA: 0x94A118
	private void FMGJILBBNBJ_UpdateCoopBonus(MJFMOPMOFDJ DACHLLPBFPI)
	{
		DACHLLPBFPI.CLNPBIJBIIJ_CoopBonus = 0;
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int a = 0;
			for(int i = 1; i < 5; i++)
			{
				int b = DACHLLPBFPI.NKIIJMFIIAK_GetTotalAttackCount( (JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH) i);
				a += CMMDPDMNNKP(ev, (JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH) i).PIABNPEFLEJ * b;
			}
			DACHLLPBFPI.CLNPBIJBIIJ_CoopBonus = Mathf.Min(a, ev.LPJLEHAJADA("coop_bonus_max", 100));
		}
    }

	// // RVA: 0x94A284 Offset: 0x94A284 VA: 0x94A284
	private void HCKEDINDNAP(MJFMOPMOFDJ DACHLLPBFPI)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
			int FCBDGLEPGFJ = 1;
			if(!save.LDJPDEHJFOC(DACHLLPBFPI.PPFNGGCBJKC_Id, out FCBDGLEPGFJ))
			{
				FCBDGLEPGFJ = BCDFFKCOOFB(DACHLLPBFPI.PPFNGGCBJKC_Id, DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
			}
			BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK d = ev.HDMADAHNLDN.Find((BKOGPDBKFFJ_EventRaid.NJLOJAKKGFK MABBBOEAPAA) =>
			{
				//0xFD7178
				return MABBBOEAPAA.PPFNGGCBJKC_Id == FCBDGLEPGFJ;
			});
			if(d != null)
			{
				DACHLLPBFPI.BLFHMNHMDHF_Mission = d.FEMMDNIELFC_Desc;
				DACHLLPBFPI.CJLHLKKNMEE_MissionText = d.FEMMDNIELFC_Desc.Replace(JpStringLiterals.StringLiteral_5812, "");
				DACHLLPBFPI.NFOOOBMJINC_MissionBonusNum = d.ECEKNKIDING(DACHLLPBFPI.IKICLMGFFPB_IsSpecial);
				DACHLLPBFPI.JOMGCCBFKEF_MissionId = d.PPFNGGCBJKC_Id;
			}
        }
    }

	// // RVA: 0x94A698 Offset: 0x94A698 VA: 0x94A698
	public void AIMIFGFHBCE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM NHLBKJCPLBL = KNKJHNJFONJ_GetSave(FJLIDJJAGOM());
    	if(NHLBKJCPLBL != null)
		{
			EAOJEDAEIJN_GetMyRaidbosses req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EAOJEDAEIJN_GetMyRaidbosses());
			PLOOEECNHFB = false;
			NPNNPNAIONN = false;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
			{
				//0xFD71C4
				PBJBHONLMKF_MyBoss.LHPDDGIJKNB();
				KMFKFGEDPGJ d = new KMFKFGEDPGJ();
				d.INDDJNMPONH = BKKPEJEABJN.LIFLDNIHBAK_1;
				List<int> l = new List<int>(40);
				ECPHFLNMECN.Clear();
				EAOJEDAEIJN_GetMyRaidbosses r = HKICMNAACDA as EAOJEDAEIJN_GetMyRaidbosses;
				HKMFDIEOKNM = r.NFEAMMJIMPG.DKNENAKHNAP.Count;
				long t = 0;
				for(int i = 0 ; i < r.NFEAMMJIMPG.DKNENAKHNAP.Count; i++)
				{
					MJFMOPMOFDJ m = null;
					if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId))
					{
						if(NHLBKJCPLBL.HBHCCLGECOC_MyBossId == r.NFEAMMJIMPG.DKNENAKHNAP[i].PPFNGGCBJKC_Id || 
							r.NFEAMMJIMPG.DKNENAKHNAP[i].CMCKNKKCNDK_Status == NHCDBBBMFFG.MBFHILFLPJL_1_Alive || 
							r.NFEAMMJIMPG.DKNENAKHNAP[i].ICCOOAAJEIN_CanReceiveReward)
						{
							m = PBJBHONLMKF_MyBoss;
							PBJBHONLMKF_MyBoss.MLPEHNBNOGD_Id = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
							OFAHKDKDGAN(PBJBHONLMKF_MyBoss, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
							NBPANDOEDJH(PBJBHONLMKF_MyBoss, r.NFEAMMJIMPG.DKNENAKHNAP[i]);
							if(NHLBKJCPLBL.NHGJFJBEIBL_GetNumMissions() < 1 || !NHLBKJCPLBL.MPOLPHDMBKA(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id))
							{
								//LAB_00fd7868
								Debug.LogWarning("StringLiteral_13184");
								IPEIKLJLCJL(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id, PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial);
							}
							if(NHLBKJCPLBL.HBHCCLGECOC_MyBossId == 0)
							{
								NHLBKJCPLBL.HBHCCLGECOC_MyBossId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id;
							}
							PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = r.NFEAMMJIMPG.DKNENAKHNAP[i].CAKONDPGDIL_CanRequestHelp;
							//LAB_00fd79a4
						}
						else
							continue;
					}
					else
					{
						m = new MJFMOPMOFDJ();
						ECPHFLNMECN.Add(m);
						if(!l.Contains(r.NFEAMMJIMPG.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId))
						{
							l.Add(r.NFEAMMJIMPG.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId);
						}
						m.MLPEHNBNOGD_Id = r.NFEAMMJIMPG.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId;
						NBPANDOEDJH(m, r.NFEAMMJIMPG.DKNENAKHNAP[i]);
						m.CAKONDPGDIL_CanRequestHelp = false;
						IPEIKLJLCJL(m.PPFNGGCBJKC_Id, m.IKICLMGFFPB_IsSpecial);
						if(!NHLBKJCPLBL.OFJNLMIHMDE(r.NFEAMMJIMPG.DKNENAKHNAP[i].PPFNGGCBJKC_Id))
						{
							d.GBJFCGOBHDO_RawAddedDamage++;
							if(t < r.NFEAMMJIMPG.DKNENAKHNAP[i].OJCCKOICMJK_CreatedAt)
							{
								d.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG.DKNENAKHNAP[i].MBEMFKGBIEO_EncounterPlayerId;
								t = r.NFEAMMJIMPG.DKNENAKHNAP[i].OJCCKOICMJK_CreatedAt;
							}
						}
					}
					//LAB_00fd79a4
					HCKEDINDNAP(m);
					m.CMCKNKKCNDK_Status = r.NFEAMMJIMPG.DKNENAKHNAP[i].CMCKNKKCNDK_Status;
					m.DLMNFENNCJG_IsEntry = r.NFEAMMJIMPG.DKNENAKHNAP[i].DLMNFENNCJG_HasAttacked;
					m.ICCOOAAJEIN_CanReceiveReward = r.NFEAMMJIMPG.DKNENAKHNAP[i].ICCOOAAJEIN_CanReceiveReward;
					m.EMHHJNDOCMB(r.NFEAMMJIMPG.DKNENAKHNAP[i].MGPCMCNFFIM);
					FMGJILBBNBJ_UpdateCoopBonus(m);
					ILCCJNDFFOB.HHCJCDFCLOB.ONMOONKHHLO(this, m);
				}
				for(int i = 0; i < NHLBKJCPLBL.HBBNJHLHPDH().Count; i++)
				{
					int JFJFMFNMPPF = NHLBKJCPLBL.HBBNJHLHPDH()[i];
					if(JFJFMFNMPPF != NHLBKJCPLBL.HBHCCLGECOC_MyBossId)
					{
						MJFMOPMOFDJ m = ECPHFLNMECN.Find((MJFMOPMOFDJ BFPPAPMNEHA) =>
						{
							//0xFD8790
							return JFJFMFNMPPF == BFPPAPMNEHA.PPFNGGCBJKC_Id;
						});
						if(m == null)
						{
							NHLBKJCPLBL.PJCGNAKDOKH(JFJFMFNMPPF);
						}
					}
				}
				for(int i = 0; i < NHLBKJCPLBL.HEMPBHOBAPE().Count; i++)
				{
					int JFJFMFNMPPF = NHLBKJCPLBL.HEMPBHOBAPE()[i];
					if(JFJFMFNMPPF != NHLBKJCPLBL.HBHCCLGECOC_MyBossId)
					{
						MJFMOPMOFDJ m = ECPHFLNMECN.Find((MJFMOPMOFDJ BFPPAPMNEHA) =>
						{
							//0xFD87C4
							return JFJFMFNMPPF == BFPPAPMNEHA.PPFNGGCBJKC_Id;
						});
						if(m == null)
						{
							NHLBKJCPLBL.IDBJMCBHJJJ(JFJFMFNMPPF);
						}
					}
				}
				NHLBKJCPLBL.BADLOIKHGLK();
				ECPHFLNMECN.ForEach((MJFMOPMOFDJ BFPPAPMNEHA) =>
				{
					//0xFD847C
					NHLBKJCPLBL.NBCJGLLLFOH(BFPPAPMNEHA.PPFNGGCBJKC_Id);
				});
				if(d.GBJFCGOBHDO_RawAddedDamage > 0)
				{
					CBPJPNIFJOI.Add(d);
				}
				if(l.Count < 1)
				{
					KDBBGILHMNL(BHFHGFKBOHH, AOCANKOMKFG);
				}
				else
				{
					NJNCAHLIHNI_GetPlayerData req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
					req2.FAMHAPONILI_Ids = l;
					req2.HHIHCJKLJFF_BlockNames = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(5);
					req2.PINPBOCDKLI = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
					{
						//0xFD84C4
						BBHNACPENDM_ServerSaveData sData = new BBHNACPENDM_ServerSaveData();
						sData.EBKCPELHDKN_InitWithBaseAndPublicStatus();
						if(sData.IIEMACPEEBJ_Load(OHNJJIMGKGK, IDLHJIOMJBK))
						{
							for(int i = 0; i < ECPHFLNMECN.Count; i++)
							{
								if(ECPHFLNMECN[i].MLPEHNBNOGD_Id == PPFNGGCBJKC)
								{
									OFAHKDKDGAN(ECPHFLNMECN[i], sData);
								}
							}
							return true;
						}
						return false;
					};
					req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
					{
						//0xFD868C
						KDBBGILHMNL(BHFHGFKBOHH, AOCANKOMKFG);
					};
					req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request MEOKEBAMPLA) =>
					{
						//0xFD86C8
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						AOCANKOMKFG();
					};
				}
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
			{
				//0xFD872C
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				AOCANKOMKFG();
			};
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			AOCANKOMKFG();
		}
	}

	// // RVA: 0x94A938 Offset: 0x94A938 VA: 0x94A938
	private void KDBBGILHMNL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
		if(save != null && !PBJBHONLMKF_MyBoss.DNJGAJPIIPI && save.HBHCCLGECOC_MyBossId != 0)
		{
			PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id = save.HBHCCLGECOC_MyBossId;
			DOECBDLGILJ(PBJBHONLMKF_MyBoss, 0, () =>
			{
				//0xFD8800
				IHMDJENFJIG(BHFHGFKBOHH, AOCANKOMKFG);
			}, () =>
			{
				//0xFD8838
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				AOCANKOMKFG();
			});
		}
		else
		{
			IHMDJENFJIG(BHFHGFKBOHH, AOCANKOMKFG);
		}
    }

	// // RVA: 0x94AE74 Offset: 0x94AE74 VA: 0x94AE74
	private void IHMDJENFJIG(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		if(PBJBHONLMKF_MyBoss.DNJGAJPIIPI)
		{
			IHPJMEKNJLP();
			if((PBJBHONLMKF_MyBoss.CMCKNKKCNDK_Status == NHCDBBBMFFG.OPNEOJEGDJB_2_Dead || PBJBHONLMKF_MyBoss.CMCKNKKCNDK_Status == NHCDBBBMFFG.NFDONDKDHPK_3_Escaped) && 
				!PBJBHONLMKF_MyBoss.ICCOOAAJEIN_CanReceiveReward)
			{
                JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(FJLIDJJAGOM());
				if(save != null)
				{
					save.BGOJNJLNLKE();
				}
            }
		}
		CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
		{
			//0xFD88A4
			EGBLOJJIKKJ(BHFHGFKBOHH, AOCANKOMKFG);
		}, () =>
		{
			//0xFD88DC
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			AOCANKOMKFG();
		}, null);
	}

	// // RVA: 0x94B58C Offset: 0x94B58C VA: 0x94B58C
	private void EGBLOJJIKKJ(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		if(NLEFCEBIGGO_HasMissingPlayersInfo())
		{
			PLOOEECNHFB = false;
			NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
			req.FAMHAPONILI_Ids = new List<int>(CBPJPNIFJOI.Count);
			for(int i = 0; i < CBPJPNIFJOI.Count; i++)
			{
				if(string.IsNullOrEmpty(CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName))
				{
					if(!req.FAMHAPONILI_Ids.Contains(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId))
					{
						req.FAMHAPONILI_Ids.Add(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId);
					}
				}
			}
			req.HHIHCJKLJFF_BlockNames = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(1);
			req.PINPBOCDKLI = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
			{
				//0xFD8948
				if(FPPNANIIODA.IIEMACPEEBJ_Load(OHNJJIMGKGK, IDLHJIOMJBK))
				{
					for(int i = 0; i < CBPJPNIFJOI.Count; i++)
					{
						if(CBPJPNIFJOI[i].MLPEHNBNOGD_PlayerId == PPFNGGCBJKC)
						{
							CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
						}
					}
					return true;
				}
				return false;
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request BHGCOECCPCO) =>
			{
				//0xFD8B08
				PLOOEECNHFB = true;
				BHFHGFKBOHH();
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request MEOKEBAMPLA) =>
			{
				//0xFD8B54
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				AOCANKOMKFG();
			};
		}
		else
		{
			PLOOEECNHFB = true;
			BHFHGFKBOHH();
		}
	}

	// // RVA: 0x94BA5C Offset: 0x94BA5C VA: 0x94BA5C
	private bool NLEFCEBIGGO_HasMissingPlayersInfo()
	{
		for(int i = 0; i < CBPJPNIFJOI.Count; i++)
		{
			if(string.IsNullOrEmpty(CBPJPNIFJOI[i].LBODHBDOMGK_PlayerName))
				return true;
		}
		return false;
	}

	// // RVA: 0x94BB48 Offset: 0x94BB48 VA: 0x94BB48
	// public void EPLLCEFGKBH(Action<bool> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94BC24 Offset: 0x94BC24 VA: 0x94BC24
	// public void GMIPFKHCDCA(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x94BD00 Offset: 0x94BD00 VA: 0x94BD00
	public void AMBHKLLAJID(Action<int, int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		IEFFGONGBCD_GetMyRaidBosses((List<NCMFOICNJEB<EBHIMFFJBIJ>> DIDOEKOBNNJ) =>
		{
			//0xFD8D04
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave();
			int res = 0;
			for(int i = 0; i < DIDOEKOBNNJ.Count; i++)
			{
				res += save.HBHCCLGECOC_MyBossId != DIDOEKOBNNJ[i].PPFNGGCBJKC_Id && !save.OFJNLMIHMDE(DIDOEKOBNNJ[i].PPFNGGCBJKC_Id) ? 1 : 0;
			}
			BHFHGFKBOHH(DIDOEKOBNNJ.Count, res);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x949A88 Offset: 0x949A88 VA: 0x949A88
	private void IEFFGONGBCD_GetMyRaidBosses(Action<List<NCMFOICNJEB<EBHIMFFJBIJ>>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			EAOJEDAEIJN_GetMyRaidbosses req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EAOJEDAEIJN_GetMyRaidbosses());
			PLOOEECNHFB = false;
			NPNNPNAIONN = false;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
			{
				//0xFD8EF8
				EAOJEDAEIJN_GetMyRaidbosses r = HKICMNAACDA as EAOJEDAEIJN_GetMyRaidbosses;
				BHFHGFKBOHH(r.NFEAMMJIMPG.DKNENAKHNAP);
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
			{
				//0xFD8FDC
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
				MOBEEPPKFLG();
			};
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			MOBEEPPKFLG();
		}
    }

	// // RVA: 0x94BDF4 Offset: 0x94BDF4 VA: 0x94BDF4
	// public void ENBNOMKDLFC(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x94BE20 Offset: 0x94BE20 VA: 0x94BE20
	public void PDPFNKCIJOP(MJFMOPMOFDJ DACHLLPBFPI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		DOECBDLGILJ(DACHLLPBFPI, MALKHIMMLDI.OOEHFFBHCIC_2, BHFHGFKBOHH, AOCANKOMKFG);
	}

	// // RVA: 0x94BE48 Offset: 0x94BE48 VA: 0x94BE48
	public void GKCEHODEPMJ(bool EKPADKHKCKO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		DOECBDLGILJ(JIBMOEHKMGB, EKPADKHKCKO ? MALKHIMMLDI.NPGGGMACPLD_1 : MALKHIMMLDI.HJNNKCMLGFL_0, BHFHGFKBOHH, AOCANKOMKFG);
	}

	// // RVA: 0x94AB1C Offset: 0x94AB1C VA: 0x94AB1C
	private void DOECBDLGILJ(MJFMOPMOFDJ DACHLLPBFPI, MALKHIMMLDI CNDDKMJAIBG, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		JKCDLPOPCGC_GetRaidboss req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JKCDLPOPCGC_GetRaidboss());
		req.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = DACHLLPBFPI.PPFNGGCBJKC_Id;
		if(CNDDKMJAIBG == MALKHIMMLDI.OOEHFFBHCIC_2)
		{
			req.BIHCCEHLAOD.KAPGBMNCDDC_PlayerCount = 50;
			req.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(0x8000000005);
		}
		else
		{
			req.BIHCCEHLAOD.KAPGBMNCDDC_PlayerCount = CNDDKMJAIBG == MALKHIMMLDI.NPGGGMACPLD_1 ? 50 : 0;
			req.BIHCCEHLAOD.GACJGEENCKM_Namespaces = new List<string>();
		}
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0xFD9048
			JKCDLPOPCGC_GetRaidboss r = HKICMNAACDA as JKCDLPOPCGC_GetRaidboss;
			NBPANDOEDJH(DACHLLPBFPI, r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss);
			DACHLLPBFPI.CAKONDPGDIL_CanRequestHelp = r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss.CAKONDPGDIL_CanRequestHelp;
			DACHLLPBFPI.CMCKNKKCNDK_Status = r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss.CMCKNKKCNDK_Status;
			DACHLLPBFPI.DLMNFENNCJG_IsEntry = r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss.DLMNFENNCJG_HasAttacked;
			DACHLLPBFPI.ICCOOAAJEIN_CanReceiveReward = r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss.ICCOOAAJEIN_CanReceiveReward;
			DACHLLPBFPI.EMHHJNDOCMB(r.NFEAMMJIMPG.GJFJLEOGFLD_RaidBoss.MGPCMCNFFIM);
			FMGJILBBNBJ_UpdateCoopBonus(DACHLLPBFPI);
			DACHLLPBFPI.PIPOJJGBGLB();
			if(CNDDKMJAIBG == MALKHIMMLDI.NPGGGMACPLD_1)
			{
				int dam = int.MaxValue;
				int b = 0;
				int c = 1;
				for(int i = 0; i < r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers.Count; i++)
				{
					int a = 0;
					if(r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId != DACHLLPBFPI.MLPEHNBNOGD_Id)
					{
						if(r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage < dam)
						{
							dam = r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
							b = c;
						}
						a = c;
						c++;
					}
					if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId))
					{
						DACHLLPBFPI.GCKGHNBHOPH_Rank = a;
						DACHLLPBFPI.AEGFDINOACE_PlayerDamage = r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
						break;
					}
				}
				if(r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer != null)
				{
					MJFMOPMOFDJ.CALIFIMGGMD pData = new MJFMOPMOFDJ.CALIFIMGGMD();
					pData.MLPEHNBNOGD_Id = r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
					DACHLLPBFPI.NBBMHALJCMK_FirstAttackPlayer = pData;
				}
			}
			else if(CNDDKMJAIBG == MALKHIMMLDI.OOEHFFBHCIC_2)
			{
				int pId = 0;
				if(r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer != null)
				{
					pId = r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
				}
				int dam = int.MaxValue;
				int rank = 1;
				int c = 1;
				for(int i = 0; i < r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers.Count; i++)
				{
					int a = 0;
					if(r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId == DACHLLPBFPI.MLPEHNBNOGD_Id)
					{
						if(MFAFEBNEEHE_IsMyself(r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].MLPEHNBNOGD_PlayerId))
						{
							DACHLLPBFPI.AEGFDINOACE_PlayerDamage = r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].HALIDDHLNEG_Damage;
						}
					}
					else
					{
						BBHNACPENDM_ServerSaveData sData = new BBHNACPENDM_ServerSaveData();
						sData.EBKCPELHDKN_InitWithBaseAndPublicStatus();
						if(!sData.IIEMACPEEBJ_Load(r.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG.CFFDADAKJPB_AttackPlayers[i].AHEFHIMGIBI))
						{
							break;
						}
						MJFMOPMOFDJ.CALIFIMGGMD pData = new MJFMOPMOFDJ.CALIFIMGGMD();
						pData.MLPEHNBNOGD_Id = r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer.MLPEHNBNOGD_PlayerId;
						OFAHKDKDGAN(pData, sData);
						pData.HALIDDHLNEG_Damage = r.NFEAMMJIMPG.COGCGJLFDKG_FirstAttackPlayer.HALIDDHLNEG_Damage;
						if(pData.HALIDDHLNEG_Damage < dam)
						{
							pData.FJOLNJLLJEJ_Rank = rank;
							c = rank;
							dam = pData.HALIDDHLNEG_Damage;
						}
						else
						{
							pData.FJOLNJLLJEJ_Rank = c;
						}
						DACHLLPBFPI.IDALEDJHEMF(pData);
						if(pData.MLPEHNBNOGD_Id == pId)
						{
							DACHLLPBFPI.NBBMHALJCMK_FirstAttackPlayer = pData;
						}
						rank++;
						if(MFAFEBNEEHE_IsMyself(pData.MLPEHNBNOGD_Id))
						{
							DACHLLPBFPI.KGPKFAFHEFP(pData);
						}
					}
				}
			}
			PLOOEECNHFB = true;
			BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0xFD9A64
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			AOCANKOMKFG();
		};
	}

	// // RVA: 0x94BE74 Offset: 0x94BE74 VA: 0x94BE74
	public bool LMIFOCDCNAI()
	{
		return HEMEDMMBIBH_GetBossHelpCount(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id) > 0 && !KIHAEAEEFJE(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id) && PBJBHONLMKF_MyBoss.DNJGAJPIIPI && NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() >= GCDHLLHHIHA(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
	}

	// // RVA: 0x94C404 Offset: 0x94C404 VA: 0x94C404
	public void MCKDAPPELKJ_RequestBossHelp(bool PJJLOFMLOMN, bool MCMPOEHAIHP, OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		if(BAEPGOAMBDK("request_help_ver", 1) < 2)
		{
			N.a.StartCoroutineWatched(BBMJANLENGH_Coroutine_RequestBossHelp(PJJLOFMLOMN, MCMPOEHAIHP, BHFHGFKBOHH, AOCANKOMKFG, KLNFKFKNBHC, OEJDHFBAMEO, GKLMHPLFLHJ, CCFPBMOJBNK, OPGIFOEKHPF));
		}
		else
		{
			N.a.StartCoroutineWatched(FMLIOLJNADH_Coroutine_RequestBossHelp_V2(PJJLOFMLOMN, MCMPOEHAIHP, BHFHGFKBOHH, AOCANKOMKFG, KLNFKFKNBHC, OEJDHFBAMEO, GKLMHPLFLHJ, CCFPBMOJBNK, OPGIFOEKHPF));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD55C Offset: 0x6BD55C VA: 0x6BD55C
	// // RVA: 0x94C54C Offset: 0x94C54C VA: 0x94C54C
	private IEnumerator FMLIOLJNADH_Coroutine_RequestBossHelp_V2(bool PJJLOFMLOMN, bool MCMPOEHAIHP, OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		PJKLMCGEJMK OKDOIAEGADK; // 0x3C
		string MOONABDCPDD; // 0x40
		string FKGJIBCFJED; // 0x44
		int DOLLGOFIMAE; // 0x48
		int NHODLNIICHK; // 0x4C
		int FCLOLNNNAGL; // 0x50
		int OGBDIKJGKKF; // 0x54
		int DJJAMHHLOPD; // 0x58
		LNGMNNNJBJP_SearchForPlayer LILFADBFJDN; // 0x5C
		LNGMNNNJBJP_SearchForPlayer DPHDPGDCBCE; // 0x60

		//0xFE4EDC
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		StringBuilder str = new StringBuilder(64);
		str.Set("lobby_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		MOONABDCPDD = str.ToString();
		str = new StringBuilder(64);
		str.Set("lobby_cluster_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		FKGJIBCFJED = str.ToString();
		DJJAMHHLOPD = 0;
		DOLLGOFIMAE = 0;
		NHODLNIICHK = 0;
		FCLOLNNNAGL = 0;
		OGBDIKJGKKF = 0;
		KLOJEBGOGPO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, out DJJAMHHLOPD, out OGBDIKJGKKF);
		HEOFEABCBCC(out FCLOLNNNAGL, out NHODLNIICHK);
		int EKADNPHNIHN = 0;
		LILFADBFJDN = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		if(!PJJLOFMLOMN)
		{
			LILFADBFJDN.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(FKGJIBCFJED, NHODLNIICHK, FCLOLNNNAGL);
			DOLLGOFIMAE = BAEPGOAMBDK("zentai_help_friend_max_num", 5);
		}
		else
		{
			LILFADBFJDN.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(MOONABDCPDD, OGBDIKJGKKF, DJJAMHHLOPD);
			if(!MCMPOEHAIHP)
				DOLLGOFIMAE = BAEPGOAMBDK("lobby_help_friend_max_num2", 2);
			else
				DOLLGOFIMAE = BAEPGOAMBDK("lobby_help_friend_max_num", 7);
		}
		LILFADBFJDN.IPKCADIAAPG_SakashoCrit.OnlyFriends = true;
		LILFADBFJDN.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		LILFADBFJDN.HHIHCJKLJFF_ServerInfoBlockList = new List<string>();
		LILFADBFJDN.MLPLGFLKKLI_Ipp = DOLLGOFIMAE;
		LILFADBFJDN.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0xFD9AD0
			if(MLEHCBKPNGK)
				EKADNPHNIHN++;
			return true;
		};
		while(!LILFADBFJDN.PLOOEECNHFB_IsDone)
			yield return null;
		if(!LILFADBFJDN.NPNNPNAIONN_IsError)
		{
			int CAKBAKJCCFM = 0;
			DPHDPGDCBCE = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
			if(!PJJLOFMLOMN)
			{
				LILFADBFJDN.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(FKGJIBCFJED, NHODLNIICHK, FCLOLNNNAGL);
			}
			else
			{
				LILFADBFJDN.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(MOONABDCPDD, OGBDIKJGKKF, DJJAMHHLOPD);
			}
			LILFADBFJDN.IPKCADIAAPG_SakashoCrit.OnlyFriends = false;
			LILFADBFJDN.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
			LILFADBFJDN.HHIHCJKLJFF_ServerInfoBlockList = new List<string>();
			LILFADBFJDN.MLPLGFLKKLI_Ipp = JCBDKEPCLKG_GetRaidBossHelpMaxCount();
			LILFADBFJDN.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
			{
				//0xFD9AEC
				CAKBAKJCCFM++;
				return true;
			};
			while(!LILFADBFJDN.PLOOEECNHFB_IsDone)
				yield return null;
			if(!LILFADBFJDN.NPNNPNAIONN_IsError)
			{
				if(CAKBAKJCCFM > 0)
				{
					if(EKADNPHNIHN < 0)
					{
						EKADNPHNIHN = 0;
					}
					if(DOLLGOFIMAE < EKADNPHNIHN)
					{
						EKADNPHNIHN = DOLLGOFIMAE;
					}
					ENBPNDFOOCK_RequestRaidbossHelp KCLPLDHANEA = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ENBPNDFOOCK_RequestRaidbossHelp());
					KCLPLDHANEA.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
					{
						//0xFD62FC
						if(LJJGBICGLLF != SakashoErrorId.RAIDBOSS_ESCAPED)
						{
							return LJJGBICGLLF >= SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED && LJJGBICGLLF < SakashoErrorId.RAIDBOSS_REWARD_ALREADY_RECEIVED;
						}
						return true;
					};
					KCLPLDHANEA.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id;
					KCLPLDHANEA.BIHCCEHLAOD.IHIANEHALAD_FriendPlayerCount = EKADNPHNIHN;
					KCLPLDHANEA.BIHCCEHLAOD.NIKGBLBENGD_OtherPlayerCount = JCBDKEPCLKG_GetRaidBossHelpMaxCount() - EKADNPHNIHN;
					KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(0x8000000005);
					if(!PJJLOFMLOMN)
					{
						KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = NHODLNIICHK;
						KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = FCLOLNNNAGL;
						KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = FKGJIBCFJED;
					}
					else
					{
						KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = OGBDIKJGKKF;
						KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = DJJAMHHLOPD;
						KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = MOONABDCPDD;
					}
					KCLPLDHANEA.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
					{
						//0xFD9B00
						ENBPNDFOOCK_RequestRaidbossHelp r = HKICMNAACDA as ENBPNDFOOCK_RequestRaidbossHelp;
						int c = r.NFEAMMJIMPG.LBMEJEDJJFM.Count;
						int c2 = r.NFEAMMJIMPG.ENDAPLAFFAI.Count;
						List<ECICDAPCMJG> MOCDACANBIG = new List<ECICDAPCMJG>(c + c2);
						List<int> EJIBHPFHDKC = new List<int>(c + c2);
						int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.AHJDJACMFMN_GetPushTimeSlotIndex(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						for(int i = 0; i < r.NFEAMMJIMPG.LBMEJEDJJFM.Count; i++)
						{
							if(!FPPNANIIODA.IIEMACPEEBJ_Load(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG.LBMEJEDJJFM[i].AHEFHIMGIBI_PlayerData))
							{
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
								AOCANKOMKFG();
								return;
							}
							ECICDAPCMJG e = new ECICDAPCMJG();
							e.HKAIJKGODHC = true;
							e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
							e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG.LBMEJEDJJFM[i].MLPEHNBNOGD_PlayerId;
							e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
							MOCDACANBIG.Add(e);
							if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
							{
								EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
							}
						}
						for(int i = 0; i < r.NFEAMMJIMPG.ENDAPLAFFAI.Count; i++)
						{
							if(!FPPNANIIODA.IIEMACPEEBJ_Load(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG.ENDAPLAFFAI[i].AHEFHIMGIBI_PlayerData))
							{
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
								AOCANKOMKFG();
								return;
							}
							ECICDAPCMJG e = new ECICDAPCMJG();
							e.HKAIJKGODHC = false;
							e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
							e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG.ENDAPLAFFAI[i].MLPEHNBNOGD_PlayerId;
							e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
							MOCDACANBIG.Add(e);
							if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
							{
								EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
							}
						}
						PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = false;
						MCEJJBANCDA = PBJBHONLMKF_MyBoss;
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.BEKIJHOCDFE_28);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
						if(EJIBHPFHDKC.Count > 0)
						{
							KIGJMPILEFC(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
						}
						JIOEILLGDCG(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
						ILCCJNDFFOB.HHCJCDFCLOB.BACAKFPEMAF(this, true, MCMPOEHAIHP, MOCDACANBIG);
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
						{
							//0xFDAAD8
							PLOOEECNHFB = true;
							if(!PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial || EJIBHPFHDKC.Count == 0)
							{
								PLOOEECNHFB = true;
								BHFHGFKBOHH(MOCDACANBIG);
							}
							else
							{
								LKDGDNOOGND(EJIBHPFHDKC, () =>
								{
									//0xFDB568
									PLOOEECNHFB = true;
									BHFHGFKBOHH(MOCDACANBIG);
								}, () =>
								{
									//0xFDA8A4
									PLOOEECNHFB = true;
									NPNNPNAIONN = true;
									AOCANKOMKFG();
								});
							}
						}, () =>
						{
							//0xFDA908
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							AOCANKOMKFG();
						}, null);
						return;
					};
					KCLPLDHANEA.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
					{
						//0xFDA96C
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_ESCAPED)
						{
							OEJDHFBAMEO();
						}
						else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_HELP_ALREADY_REQUESTED)
						{
							GKLMHPLFLHJ();
						}
						else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_KILLED)
						{
							CCFPBMOJBNK();
						}
						else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED)
						{
							OPGIFOEKHPF();
							JDDCHPCBKLM(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
						}
						else
						{
							AOCANKOMKFG();
						}
					};
					yield break;
				}
				else
				{
					KLNFKFKNBHC();
				}
			}
		}
		PLOOEECNHFB = true;
		NPNNPNAIONN = true;
		AOCANKOMKFG();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD5D4 Offset: 0x6BD5D4 VA: 0x6BD5D4
	// // RVA: 0x94C6C4 Offset: 0x94C6C4 VA: 0x94C6C4
	private IEnumerator BBMJANLENGH_Coroutine_RequestBossHelp(bool PJJLOFMLOMN, bool MCMPOEHAIHP, OGFPKBBOFFH BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG, DJBHIFLHJLK KLNFKFKNBHC, DJBHIFLHJLK OEJDHFBAMEO, DJBHIFLHJLK GKLMHPLFLHJ, DJBHIFLHJLK CCFPBMOJBNK, DJBHIFLHJLK OPGIFOEKHPF)
	{
		StringBuilder ABMADBCLLHH; // 0x38
		StringBuilder IFCAJOKCFGI; // 0x3C
		int MIEHDOMFBNH; // 0x40
		int LIEFBJJIDOC; // 0x44
		int MICBFIOOCOL; // 0x48
		int KBCCFLDOFFN; // 0x4C
		LNGMNNNJBJP_SearchForPlayer GFCGNLCDNNG; // 0x50

		//0xFE3EB8
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
		ABMADBCLLHH = new StringBuilder(64);
		ABMADBCLLHH.Set("lobby_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		IFCAJOKCFGI = new StringBuilder(64);
		IFCAJOKCFGI.Set("lobby_cluster_id_" + evLobby.PGIIDPEGGPI_EventId.ToString());
		MIEHDOMFBNH = 0;
		LIEFBJJIDOC = 0;
		MICBFIOOCOL = 0;
		KBCCFLDOFFN = 0;
		KLOJEBGOGPO(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LLBECHBNIJG_EventRaidPlayer.MEBHCFJCKFE_LobbyId, out KBCCFLDOFFN, out MICBFIOOCOL);
		HEOFEABCBCC(out LIEFBJJIDOC, out MIEHDOMFBNH);
		GFCGNLCDNNG = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LNGMNNNJBJP_SearchForPlayer());
		if(!PJJLOFMLOMN)
		{
			GFCGNLCDNNG.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(IFCAJOKCFGI.ToString(), MIEHDOMFBNH, LIEFBJJIDOC);
		}
		else
		{
			GFCGNLCDNNG.IPKCADIAAPG_SakashoCrit = SakashoPlayerCriteria.NewCriteriaFromTo(ABMADBCLLHH.ToString(), MIEHDOMFBNH, LIEFBJJIDOC);
		}
		GFCGNLCDNNG.IPKCADIAAPG_SakashoCrit.OnlyFriends = false;
		GFCGNLCDNNG.EILKGEADKGH_SearchOrder = SakashoPlayerData.SearchOrder.UPDATED_AT_DESC;
		GFCGNLCDNNG.HHIHCJKLJFF_ServerInfoBlockList = new List<string>();
		GFCGNLCDNNG.MLPLGFLKKLI_Ipp = JCBDKEPCLKG_GetRaidBossHelpMaxCount();
		int EKADNPHNIHN = 0;
		int GPBOOEHCCNC = 0;
		GFCGNLCDNNG.PINPBOCDKLI_OnFriendCb = (int OIPCCBHIKIA, int PPFNGGCBJKC, long IFNLEKOILPM, bool MLEHCBKPNGK, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0xFDB5E8
			if(MLEHCBKPNGK)
				EKADNPHNIHN++;
			GPBOOEHCCNC++;
			return true;
		};
		GFCGNLCDNNG.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
		{
			//0xFDB610
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			AOCANKOMKFG();
		};
		while(!GFCGNLCDNNG.PLOOEECNHFB_IsDone)
			yield return null;
		if(!GFCGNLCDNNG.NPNNPNAIONN_IsError)
		{
			if(GPBOOEHCCNC < 1)
			{
				KLNFKFKNBHC();
			}
			else
			{
				int c = Mathf.Min(EKADNPHNIHN, JCBDKEPCLKG_GetRaidBossHelpMaxCount());
				if(!MCMPOEHAIHP)
					c = UnityEngine.Random.Range(0, c + 1);
				ENBPNDFOOCK_RequestRaidbossHelp KCLPLDHANEA = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new ENBPNDFOOCK_RequestRaidbossHelp());
				KCLPLDHANEA.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
				{
					//0xFD631C
					if(LJJGBICGLLF != SakashoErrorId.RAIDBOSS_ESCAPED)
					{
						return LJJGBICGLLF >= SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED && LJJGBICGLLF < SakashoErrorId.RAIDBOSS_REWARD_ALREADY_RECEIVED;
					}
					return true;
				};
				KCLPLDHANEA.BIHCCEHLAOD.KJPDHNJGEAH_EntityId = PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id;
				KCLPLDHANEA.BIHCCEHLAOD.IHIANEHALAD_FriendPlayerCount = c;
				KCLPLDHANEA.BIHCCEHLAOD.NIKGBLBENGD_OtherPlayerCount = JCBDKEPCLKG_GetRaidBossHelpMaxCount() - c;
				KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces = BBHNACPENDM_ServerSaveData.KPIDBPEKMFD_GetBlockList(0x8000000005);
				if(!PJJLOFMLOMN)
				{
					KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = MIEHDOMFBNH;
					KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = LIEFBJJIDOC;
					KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = IFCAJOKCFGI.ToString();
				}
				else
				{
					KCLPLDHANEA.BIHCCEHLAOD.ANOJACPGGNO_SearchNumberFrom = MICBFIOOCOL;
					KCLPLDHANEA.BIHCCEHLAOD.FOGLBBANMAP_SearchNumberTo = KBCCFLDOFFN;
					KCLPLDHANEA.BIHCCEHLAOD.ILABNPMBCAK_SearchKey = ABMADBCLLHH.ToString();
				}
				KCLPLDHANEA.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
				{
					//0xFDB674	
					ENBPNDFOOCK_RequestRaidbossHelp r = HKICMNAACDA as ENBPNDFOOCK_RequestRaidbossHelp;
					int c = r.NFEAMMJIMPG.LBMEJEDJJFM.Count;
					int c2 = r.NFEAMMJIMPG.ENDAPLAFFAI.Count;
					List<ECICDAPCMJG> MOCDACANBIG = new List<ECICDAPCMJG>(c + c2);
					List<int> EJIBHPFHDKC = new List<int>(c + c2);
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.AHJDJACMFMN_GetPushTimeSlotIndex(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
					for(int i = 0; i < r.NFEAMMJIMPG.LBMEJEDJJFM.Count; i++)
					{
						if(!FPPNANIIODA.IIEMACPEEBJ_Load(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG.LBMEJEDJJFM[i].AHEFHIMGIBI_PlayerData))
						{
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							AOCANKOMKFG();
							return;
						}
						ECICDAPCMJG e = new ECICDAPCMJG();
						e.HKAIJKGODHC = true;
						e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
						e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG.LBMEJEDJJFM[i].MLPEHNBNOGD_PlayerId;
						e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
						MOCDACANBIG.Add(e);
						if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
						{
							EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
						}
					}
					for(int i = 0; i < r.NFEAMMJIMPG.ENDAPLAFFAI.Count; i++)
					{
						if(!FPPNANIIODA.IIEMACPEEBJ_Load(KCLPLDHANEA.BIHCCEHLAOD.GACJGEENCKM_Namespaces, r.NFEAMMJIMPG.ENDAPLAFFAI[i].AHEFHIMGIBI_PlayerData))
						{
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							AOCANKOMKFG();
							return;
						}
						ECICDAPCMJG e = new ECICDAPCMJG();
						e.HKAIJKGODHC = false;
						e.LBODHBDOMGK_PlayerName = FPPNANIIODA.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
						e.MLPEHNBNOGD_PlayerId = r.NFEAMMJIMPG.ENDAPLAFFAI[i].MLPEHNBNOGD_PlayerId;
						e.GFDDPMCEJCI_ClusterId = FPPNANIIODA.LLBECHBNIJG_EventRaidPlayer.KDMPHHFADMC_ClusterId;
						MOCDACANBIG.Add(e);
						if(FPPNANIIODA.MHEAEGMIKIE_PublicStatus.LJLLNLKBEJE(a))
						{
							EJIBHPFHDKC.Add(e.MLPEHNBNOGD_PlayerId);
						}
					}
					PBJBHONLMKF_MyBoss.CAKONDPGDIL_CanRequestHelp = false;
					MCEJJBANCDA = PBJBHONLMKF_MyBoss;
					HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.BEKIJHOCDFE_28);
					HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
					HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
					ILCCJNDFFOB.HHCJCDFCLOB.BACAKFPEMAF(this, PJJLOFMLOMN, MCMPOEHAIHP, MOCDACANBIG);
					if(EJIBHPFHDKC.Count > 0)
					{
						KIGJMPILEFC(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
					}
					JIOEILLGDCG(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0xFDC650
						PLOOEECNHFB = true;
						if(!PBJBHONLMKF_MyBoss.IKICLMGFFPB_IsSpecial || EJIBHPFHDKC.Count == 0)
						{
							PLOOEECNHFB = true;
							BHFHGFKBOHH(MOCDACANBIG);
						}
						else
						{
							LKDGDNOOGND(EJIBHPFHDKC, () =>
							{
								//0xFDC8B8
								PLOOEECNHFB = true;
								BHFHGFKBOHH(MOCDACANBIG);
							}, () =>
							{
								//0xFDC41C
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
								AOCANKOMKFG();
							});
						}
					}, () =>
					{
						//0xFDC480
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
						AOCANKOMKFG();
					}, null);
					return;
				};
				KCLPLDHANEA.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
				{
					//0xFDC4E4
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
					if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_ESCAPED)
					{
						OEJDHFBAMEO();
					}
					else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_HELP_ALREADY_REQUESTED)
					{
						GKLMHPLFLHJ();
					}
					else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_KILLED)
					{
						CCFPBMOJBNK();
					}
					else if(HKICMNAACDA.CJMFJOMECKI_ErrorId == SakashoErrorId.RAIDBOSS_MAX_JOIN_PLAYER_COUNT_EXCEEDED)
					{
						OPGIFOEKHPF();
						JDDCHPCBKLM(PBJBHONLMKF_MyBoss.PPFNGGCBJKC_Id);
					}
					else
					{
						AOCANKOMKFG();
					}
				};
			}
		}
	}

	// // RVA: 0x94C838 Offset: 0x94C838 VA: 0x94C838
	private void LKDGDNOOGND(List<int> EJIBHPFHDKC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			if(EJIBHPFHDKC.Count > 0)
			{
				KLABCICOJJN_SendPushNotification req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KLABCICOJJN_SendPushNotification());
				req.DBBNIEHJGHH = KLABCICOJJN_SendPushNotification.FMMLHEIOFBO();
				req.DBBNIEHJGHH.AndroidMessageTitle = ev.EFEGBHACJAL("push_ex_help_title_text", JpStringLiterals.StringLiteral_13160);
				req.DBBNIEHJGHH.Message = ev.EFEGBHACJAL("push_ex_help_main_text", JpStringLiterals.StringLiteral_13162);
				req.NBFDEFGFLPJ = (SakashoErrorId FMEMECBIDIB) =>
				{
					//0xFD633C
					return true;
				};
				req.IFMENOJDKBF = EJIBHPFHDKC;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request HKICMNAACDA) =>
				{
					//0xFDC938
					BHFHGFKBOHH();
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request HKICMNAACDA) =>
				{
					//0xFDC964
					BHFHGFKBOHH();
				};
				return;
			}
		}
		BHFHGFKBOHH();
    }

	// // RVA: 0x94CC78 Offset: 0x94CC78 VA: 0x94CC78
	public int CBDMCDKKFBE_GetNeedAp(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null && !ACDLEBPMEIH(JIBMOEHKMGB))
		{
			return CMMDPDMNNKP(ev, INDDJNMPONH).JIMJHIDEHNM;
		}
		return 0;
	}

	// // RVA: 0x94D014 Offset: 0x94D014 VA: 0x94D014
	public int CBDMCDKKFBE_GetNeedAp()
	{
		return CBDMCDKKFBE_GetNeedAp(CFLEMFADGLG);
	}

	// // RVA: 0x94D01C Offset: 0x94D01C VA: 0x94D01C
	public void FDNIODNLDAI(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH INDDJNMPONH)
	{
		CFLEMFADGLG = INDDJNMPONH;
	}

	// // RVA: 0x94D024 Offset: 0x94D024 VA: 0x94D024
	public void KMDELKHBDNN(MJFMOPMOFDJ DACHLLPBFPI)
	{
		JIBMOEHKMGB = DACHLLPBFPI;
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
	public void GNANMKPFDFE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int BMMPAHHEOJC, string MDADLCOCEBN, DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GNANMKPFDFE");
	}

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
	private int BCDFFKCOOFB(int KCNAEONFIBP, bool MPKBLMCNHOM)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			int a = 0;
			for(int i = 0; i < ev.HDMADAHNLDN.Count; i++)
			{
				a += ev.HDMADAHNLDN[i].JKMDPGCCAJP(MPKBLMCNHOM);
			}
			PMBEODGMMBB = (uint)(KCNAEONFIBP ^ 0x15ab17a1);
			for(int i = 14; i > 0; i--)
			{
				PMBEODGMMBB ^= PMBEODGMMBB << 0xd;
				PMBEODGMMBB ^= PMBEODGMMBB >> 0x11;
				PMBEODGMMBB ^= PMBEODGMMBB << 5;
			}
			int b = (int)(PMBEODGMMBB & 0x7fffffff) % a;
			for(int i = 0; i < ev.HDMADAHNLDN.Count; i++)
			{
				b -= ev.HDMADAHNLDN[i].JKMDPGCCAJP(MPKBLMCNHOM);
				if(b < 0)
				{
					return ev.HDMADAHNLDN[i].PPFNGGCBJKC_Id;
				}
			}
		}
		return 1;
    }

	// // RVA: 0x94E1A8 Offset: 0x94E1A8 VA: 0x94E1A8
	private void IPEIKLJLCJL(int KCNAEONFIBP, bool MPKBLMCNHOM)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
			{
				save.BEDGDKOCGEE(KCNAEONFIBP, BCDFFKCOOFB(KCNAEONFIBP, MPKBLMCNHOM), 0, 0, 0, 0, 0);
			}
        }
    }

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
		PBOHJPIBILI.GLEPHGKFFLL(out GGNOGNOBJLP, out HLANCDFJFIA, out ANKEMCJFFIO);
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
	private KMFKFGEDPGJ IHPJMEKNJLP()
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
        JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
		if(save != null)
		{
			StringBuilder str = new StringBuilder();
			bool b = false;
			int raw_damage = 0;
			int added_damage = 0;
			for(int i = 1; i < 5; i++)
			{
				int savedDamage = save.KAHKFBKIMBE_GetMyDamage((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH)i);
				int currentDamage = PBJBHONLMKF_MyBoss.LGKOMGPLKDK_GetOtherAttackCount((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH) i);
				if(savedDamage < currentDamage )
				{
					if(b)
					{
						str.Append(',');
					}
					str.Append(OAGBCBBHMPF.GNIPLCBMPEG[i - 1]);
					str.Append(':');
					str.Append(currentDamage - savedDamage);
					str.Append(':');
					int v3 = CMMDPDMNNKP(ev,(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH)i).DHGAILOFNIP;
					str.Append(v3);
					str.Append(':');
					str.Append(v3 * (currentDamage - savedDamage));
					raw_damage += currentDamage - savedDamage;
					added_damage += v3 * (currentDamage - savedDamage);
					save.GNDJFKNNMHD((JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH)i, currentDamage);
					b = true;
				}
			}
			if(added_damage > 0)
			{
				PBOHJPIBILI.PGAGKCDGOIN_AddMcGauge(added_damage);
				ILCCJNDFFOB.HHCJCDFCLOB.MINOEGPNBIH(added_damage, PBOHJPIBILI.JMJOBHFFBGC_GetMcGauge(), 0, 0, "StringLiteral_13166", str.ToString());
				KMFKFGEDPGJ k = new KMFKFGEDPGJ();
				k.MLPEHNBNOGD_PlayerId = PBJBHONLMKF_MyBoss.OGLLKABGMCP_LastUpdatedPlayerId;
				k.GBJFCGOBHDO_RawAddedDamage = raw_damage;
				k.IOMHJCBMADB_AddedDamage = added_damage;
				CBPJPNIFJOI.Add(k);
				return k;
			}
		}
		return null;
    }

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
	public bool DBNGGBFOAPG()
	{
		return JIMJHIDEHNM != null;
	}

	// // RVA: 0x951320 Offset: 0x951320 VA: 0x951320
	public void LHEPBBADNIH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.LHEPBBADNIH");
	}

	// // RVA: 0x951424 Offset: 0x951424 VA: 0x951424
	public int HGJAGDPPALF_GetApNum()
	{
		return JIMJHIDEHNM.DCLKMNGMIKC_GetCurrent();
	}

	// // RVA: 0x951458 Offset: 0x951458 VA: 0x951458
	public long DMNDFBJODBA_GetApLoadTimeLeft()
	{
		return JIMJHIDEHNM.MLLGPBGFLFI_GetRemainingTime();
	}

	// // RVA: 0x95148C Offset: 0x95148C VA: 0x95148C
	public long EIEDIDECECD()
	{
		return JIMJHIDEHNM.LEHHIGOOIJJ();
	}

	// // RVA: 0x9514B8 Offset: 0x9514B8 VA: 0x9514B8
	public void IBMOHKFJDDH()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IBMOHKFJDDH");
	}

	// // RVA: 0x951568 Offset: 0x951568 VA: 0x951568
	public void IBMOHKFJDDH(MCGNOFMAPBJ OBFMBNJEOEC)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "PKNOKJNLPOE_EventRaid.IBMOHKFJDDH");
	}

	// // RVA: 0x9514C0 Offset: 0x9514C0 VA: 0x9514C0
	// private void FNHJDCGHNCF(MCGNOFMAPBJ OBFMBNJEOEC) { }

	// // RVA: 0x95156C Offset: 0x95156C VA: 0x95156C
	// public bool MACJBPDFCAI(int CHIHFGDIBJM, bool DDGFCOPPBBN = True) { }

	// // RVA: 0x9515A8 Offset: 0x9515A8 VA: 0x9515A8
	public bool MGIKKAGFGCF(bool DDGFCOPPBBN/* = True*/, MJFMOPMOFDJ DACHLLPBFPI)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "MGIKKAGFGCF");
		return false;
	}

	// // RVA: 0x9515D4 Offset: 0x9515D4 VA: 0x9515D4
	public void DFNENEFLKPO()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "DFNENEFLKPO");
	}

	// // RVA: 0x951664 Offset: 0x951664 VA: 0x951664
	public void BBLIJFBIACE()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "BBLIJFBIACE");
	}

	// // RVA: 0x9516F4 Offset: 0x9516F4 VA: 0x9516F4
	// public bool LIAJFGCJJIM() { }

	// // RVA: 0x951724 Offset: 0x951724 VA: 0x951724
	public bool LIAJFGCJJIM(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "LIAJFGCJJIM");
		return false;
	}

	// // RVA: 0x9517B0 Offset: 0x9517B0 VA: 0x9517B0
	public void KIGJMPILEFC(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
			if(!save.MPOLPHDMBKA(KCNAEONFIBP))
				return;
			save.EEPAJLBMEII(KCNAEONFIBP, 1);
        }
    }

	// // RVA: 0x94C198 Offset: 0x94C198 VA: 0x94C198
	public int HEMEDMMBIBH_GetBossHelpCount(int KCNAEONFIBP)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "HEMEDMMBIBH");
		return 0;
	}

	// // RVA: 0x951828 Offset: 0x951828 VA: 0x951828
	public void JIOEILLGDCG(long IEHACMMICFI, int KAIMDDPJEON/* = 0*/)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
    	if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
            if (KAIMDDPJEON < 1)
			{
				KAIMDDPJEON = JIBMOEHKMGB.PPFNGGCBJKC_Id;
			}
			if(save.MPOLPHDMBKA(KAIMDDPJEON))
			{
				save.FIBJPHMKGFL(KAIMDDPJEON, IEHACMMICFI);
			}
		}
	}

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
	public void JDDCHPCBKLM(int KCNAEONFIBP)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
			KNKJHNJFONJ_GetSave(ev).HCJHKDOANKK(KCNAEONFIBP);
		}
    }

	// // RVA: 0x94CDD0 Offset: 0x94CDD0 VA: 0x94CDD0
	public bool ACDLEBPMEIH(MJFMOPMOFDJ OFLJBDDKMII)
	{
        BKOGPDBKFFJ_EventRaid ev = FJLIDJJAGOM();
		if(ev != null)
		{
            JLOGEHCIBEJ_EventRaid.PMJBKKNNNEM save = KNKJHNJFONJ_GetSave(ev);
			if(save.MPOLPHDMBKA(OFLJBDDKMII.PPFNGGCBJKC_Id))
			{
				bool b = true;
				int a = ev.LPJLEHAJADA("raid_boss_ap_out_boss_pattern", 3);
				int c = ev.LPJLEHAJADA("raid_boss_ap_out_locate_pattern", 3);
				bool isSp = OFLJBDDKMII.MMEBLOIJBKE_UniqueKey.Contains("sp");
				return save.OEENOAGJKJK_GetPlayCount(OFLJBDDKMII.PPFNGGCBJKC_Id) < 1 && 
					((isSp && (a >> 1) != 0) || 
					(!isSp && a != 0))
				 && 
					((OFLJBDDKMII.MLPEHNBNOGD_Id == NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId && c != 0) || 
					(OFLJBDDKMII.MLPEHNBNOGD_Id != NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId && (c >> 1) != 0 ));
			}
        }
		return false;
    }

	// // RVA: 0x9519EC Offset: 0x9519EC VA: 0x9519EC
	public int BFPIHPBKEGK_GetApMax()
	{
		return JIMJHIDEHNM.DCBENCMNOGO_MaxStamina;
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
	public void FEFCBFNLDEP(MCGNOFMAPBJ OBFMBNJEOEC)
	{
		OBFMBNJEOEC.ODDIHGPONFL(JIMJHIDEHNM);
	}

	// // RVA: 0x951D14 Offset: 0x951D14 VA: 0x951D14
	public void JIHGDCFBGCK(MCGNOFMAPBJ OBFMBNJEOEC)
	{
		JIMJHIDEHNM.ODDIHGPONFL(OBFMBNJEOEC);
	}

	// // RVA: 0x951D48 Offset: 0x951D48 VA: 0x951D48
	public void NLHLDMGDAFN(int KIJAPOFAGPN)
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "NLHLDMGDAFN");
	}

	// // RVA: 0x951EAC Offset: 0x951EAC VA: 0x951EAC
	public void GOPAABMHDOA()
	{
		TodoLogger.LogError(TodoLogger.EventRaid_11_13, "GOPAABMHDOA");
	}

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
	public void KLOJEBGOGPO(int PPFNGGCBJKC, out int DOOGFEGEKLG, out int NNDBJGDFEEM)
	{
		int a = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(PPFNGGCBJKC, 1);
		DOOGFEGEKLG = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(a + 1, -1) - 1;
		NNDBJGDFEEM = NKOBMDPHNGP_EventRaidLobby.FAKHCOJIOBD(a, -1);
	}

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
