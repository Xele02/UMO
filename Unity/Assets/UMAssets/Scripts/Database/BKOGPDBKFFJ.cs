
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeSys;

[System.Obsolete("Use BKOGPDBKFFJ_EventRaid", true)]
public class BKOGPDBKFFJ { }
public class BKOGPDBKFFJ_EventRaid : DIHHCBACKGG_DbSection
{
	public class FODAKGKGJEL
	{
		public int OBGBAOLONDD_EventId; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public string HEDAGCNPHGD; // 0x10
		public string OCGFKMHNEOF; // 0x14
		public string FEMMDNIELFC_MusicSelectDesc; // 0x18
		public long BONDDBOFBND_Start; // 0x20
		public long HPNOGLIFJOP_End1; // 0x28
		public long EHHFFKAFOMC; // 0x30
		public long LNFKGHNHJKE; // 0x38
		public long JGMDAOACOJF; // 0x40
		public long IDDBFFBPNGI; // 0x48
		public long KNLGKBBIBOH_End; // 0x50
		public int MJBKGOJBPAD_TicketType; // 0x58
		public sbyte POGEFBMBPCB; // 0x5C
		public sbyte AHKNMANFILO; // 0x5D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x5E
		public sbyte HKKNEAGCIEB; // 0x5F
		public sbyte AHKPNPNOAMO; // 0x60
		public string OMCAOJJGOGG; // 0x64
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO = new NNJFKLBPBNK_SecureString(); // 0x68
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x6C
		public List<int> JHPCPNJJHLI = new List<int>(); // 0x70
		public int HIOOGLEJBKM_StartAdventureId; // 0x74
		public int FJCADCDNPMP_EndAdventureId; // 0x78
		public int[] EJBGHLOOLBC; // 0x7C

		public string OCDMGOGMHGE_AchievementIdPrefix { get { return EBGIDCIIGDO.DNJEJEANJGL_Value; } set { EBGIDCIIGDO.DNJEJEANJGL_Value = value; } } //0x19B1B0C HBAAAKFHDBB 0x19B1B38 NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x19B1B6C NOEFEAIFHCL 0x19B1B98 GJIJFGNONEL

		//// RVA: 0x19B1BCC Offset: 0x19B1BCC VA: 0x19B1BCC
		public void LHPDDGIJKNB()
		{
			OBGBAOLONDD_EventId = 0;
			BONDDBOFBND_Start = 0;
			HPNOGLIFJOP_End1 = 0;
			JGMDAOACOJF = 0;
			IDDBFFBPNGI = 0;
			EHHFFKAFOMC = 0;
			MJBKGOJBPAD_TicketType = 1;
			POGEFBMBPCB = 0;
			AHKNMANFILO = 0;
			OPFGFINHFCE_Name = null;
			HEDAGCNPHGD = null;
			OCGFKMHNEOF = null;
			FEMMDNIELFC_MusicSelectDesc = null;
			OCDMGOGMHGE_AchievementIdPrefix = "";
			PJBILOFOCIC = "";
			JHPCPNJJHLI.Clear();
			OMCAOJJGOGG = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC = null;
			AHKPNPNOAMO = 0;
		}

		//// RVA: 0x19B1CC4 Offset: 0x19B1CC4 VA: 0x19B1CC4
		//public uint CAOGDCBPBAN() { }
	}

	public class NEOBLDCCPFI
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int FMDDJNKEBBB_Crypted; // 0x10
		private int MDKGAAMBJDJ_Crypted; // 0x14
		private int GGEBNMPPEID_Crypted; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2FF0 DEMEPMAEJOO 0x19B3000 HIGKAIDMOKN
		public int CNKFPJCGNFE { get { return FMDDJNKEBBB_Crypted ^ FBGGEFFJJHB; } set { FMDDJNKEBBB_Crypted = value ^ FBGGEFFJJHB; } } //0x19B3010 GJBOGOFHGNP 0x19B3020 GJDGIDCMJMH
		public int GNFBMCGMCFO { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x19B3030 NCIMMDJLPLJ 0x19B3040 HNAJAFBHOLM
		public int BFFGFAMJAIG { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x19B3050 PKMNOMELPMN 0x19B3060 IABBJBAHKCE

		//// RVA: 0x19B3070 Offset: 0x19B3070 VA: 0x19B3070
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B309C Offset: 0x19B309C VA: 0x19B309C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			BFFGFAMJAIG = 0;
			FBGGEFFJJHB = KNEFBLHBDBG;
			PPFNGGCBJKC = 0;
			CNKFPJCGNFE = 0;
			GNFBMCGMCFO = 0;
            ALFLHDKBNIB data = JMHECKKKMLK.OLACFKILCFD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			CNKFPJCGNFE = data.CNKFPJCGNFE;
			GNFBMCGMCFO = data.GNFBMCGMCFO;
			BFFGFAMJAIG = data.BFFGFAMJAIG;
        }

		//// RVA: 0x19B31E0 Offset: 0x19B31E0 VA: 0x19B31E0
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class LOJCDFAHECI
	{
		public int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int MDKGAAMBJDJ_Crypted; // 0x10
		private int GGEBNMPPEID_Crypted; // 0x14

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2D08 DEMEPMAEJOO 0x19B2D18 HIGKAIDMOKN
		public int GNFBMCGMCFO { get { return MDKGAAMBJDJ_Crypted ^ FBGGEFFJJHB; } set { MDKGAAMBJDJ_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2D28 NCIMMDJLPLJ 0x19B2D38 HNAJAFBHOLM
		public int BFFGFAMJAIG { get { return GGEBNMPPEID_Crypted ^ FBGGEFFJJHB; } set { GGEBNMPPEID_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2D48 PKMNOMELPMN 0x19B2D58 IABBJBAHKCE

		//// RVA: 0x19B2D68 Offset: 0x19B2D68 VA: 0x19B2D68
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B2D8C Offset: 0x19B2D8C VA: 0x19B2D8C
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			PPFNGGCBJKC = 0;
			GNFBMCGMCFO = 0;
			BFFGFAMJAIG = 0;
            CNDLLOPINDF data = JMHECKKKMLK.MIOCOKLMLBD[JBGJDEELLOP];
			PPFNGGCBJKC = data.PPFNGGCBJKC;
			GNFBMCGMCFO = data.GNFBMCGMCFO;
			BFFGFAMJAIG = data.BFFGFAMJAIG;
        }

		//// RVA: 0x19B2E90 Offset: 0x19B2E90 VA: 0x19B2E90
		//public void LHPDDGIJKNB(int KNEFBLHBDBG) { }
	}

	public class LIPNCAJACFG
	{
		public int FBGGEFFJJHB; // 0x8
		private int HHEEHHHLKHC_Crypted; // 0xC
		private int LGAIHLFAPDC_Crypted; // 0x10
		public List<int> KDNMBOBEGJM = new List<int>(); // 0x14

		public int KHPHAAMGMJP_Id { get { return HHEEHHHLKHC_Crypted ^ FBGGEFFJJHB; } set { HHEEHHHLKHC_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2908 ABFDDKBBPCH 0x19B2918 MHDOIIEMDEH
		public int OFIAENKCJME { get { return LGAIHLFAPDC_Crypted ^ FBGGEFFJJHB; } set { LGAIHLFAPDC_Crypted = value ^ FBGGEFFJJHB; } } //0x19B2928 KADLAKFANGA 0x19B2938 AIDAPNCEPOB

		//// RVA: 0x19B2948 Offset: 0x19B2948 VA: 0x19B2948
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B2A20 Offset: 0x19B2A20 VA: 0x19B2A20
		public void BAFFAONJPCE(int JBGJDEELLOP, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			LHPDDGIJKNB(KNEFBLHBDBG);
            MDDFBKANJDJ data = JMHECKKKMLK.IEJLJIHIDJC[JBGJDEELLOP];
			KHPHAAMGMJP_Id = data.KHPHAAMGMJP;
			OFIAENKCJME = data.OFIAENKCJME;
			for(int i = 0; i < data.JMLCLHHLJHM.Length; i++)
			{
				KDNMBOBEGJM.Add(data.JMLCLHHLJHM[i]);
			}
        }

		//// RVA: 0x19B2BF4 Offset: 0x19B2BF4 VA: 0x19B2BF4
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			KHPHAAMGMJP_Id = 0;
			OFIAENKCJME = 0;
			KDNMBOBEGJM.Clear();
		}
	}

	public class LEFPDKNJDBF
	{
		public int GLCLFMGPMAN; // 0x8
		public int HMFFHLPNMPH; // 0xC
		public int NMKEOMCMIPP; // 0x10
	}

	public class BKKPDFFANHE
	{
		public int PPFNGGCBJKC; // 0x8
		public int DNBFMLBNAEE; // 0xC
		public List<LEFPDKNJDBF> AHJNPEAMCCH = new List<LEFPDKNJDBF>(); // 0x10
		public bool JOPPFEHKNFO; // 0x14

		//// RVA: 0x19B1938 Offset: 0x19B1938 VA: 0x19B1938
		//public uint CAOGDCBPBAN() { }
	}

	public class HECLALNLPEC
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int PLALNIIBLOF_Enabled; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int HMHHNHEPAPP_BossId; // 0x14
		public long PDBPFJJCADD_OpenAt; // 0x18
		public long FDBNFFNFOND_CloseAt; // 0x20

		//// RVA: 0x19B1FF4 Offset: 0x19B1FF4 VA: 0x19B1FF4
		//public void LHPDDGIJKNB(int PPFNGGCBJKC) { }

		//// RVA: 0x19B2010 Offset: 0x19B2010 VA: 0x19B2010
		//public void KHEKNNFCAOI(int PPFNGGCBJKC, EDOHBJAPLPF IDLHJIOMJBK) { }

		//// RVA: 0x19B2250 Offset: 0x19B2250 VA: 0x19B2250
		public void KHEKNNFCAOI(int PPFNGGCBJKC, NPAJGBIFLHB JMHECKKKMLK)
		{
			PPFNGGCBJKC_Id = PPFNGGCBJKC;
			PDBPFJJCADD_OpenAt = 0;
			FDBNFFNFOND_CloseAt = 0;
			PLALNIIBLOF_Enabled = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			HMHHNHEPAPP_BossId = 0;
            CJHLABKGKAA data = JMHECKKKMLK.GHIHAGAOPNC[PPFNGGCBJKC - 1];
			PPFNGGCBJKC_Id = (int)data.PPFNGGCBJKC;
			PLALNIIBLOF_Enabled = (int)data.PLALNIIBLOF;
			MPLGPBNJDJB_FreeMusicId = (int)data.MPLGPBNJDJB;
			HMHHNHEPAPP_BossId = (int)data.HMHHNHEPAPP;
			PDBPFJJCADD_OpenAt = data.PDBPFJJCADD;
			FDBNFFNFOND_CloseAt = data.FDBNFFNFOND;
        }

		//// RVA: 0x19B23C4 Offset: 0x19B23C4 VA: 0x19B23C4
		//public uint CAOGDCBPBAN() { }
	}

	public class HAGIHCECBGH
	{
		public int PPFNGGCBJKC; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public int CPKMLLNADLJ_Serie; // 0x10
		public int PIPCIMIALOO_IsSp; // 0x14
		public int NNLAMKCDMEL_RewardDefeat; // 0x18
		public int FCDNMBBPBKI_RewardFirst; // 0x1C
		public int EPMCPGDIBHI_RewardMvp; // 0x20
		public int AKBHPFBDDOL_Rate; // 0x24

		//// RVA: 0x19B1E54 Offset: 0x19B1E54 VA: 0x19B1E54
		public void KHEKNNFCAOI(string blockName, KCFGJMAMFCH IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			OPFGFINHFCE_Name = DatabaseTextConverter.TranslateRaidBossName(blockName, PPFNGGCBJKC, IDLHJIOMJBK.OPFGFINHFCE);
			CPKMLLNADLJ_Serie = IDLHJIOMJBK.CPKMLLNADLJ;
			PIPCIMIALOO_IsSp = IDLHJIOMJBK.PIPCIMIALOO;
			NNLAMKCDMEL_RewardDefeat = IDLHJIOMJBK.NNLAMKCDMEL;
			FCDNMBBPBKI_RewardFirst = IDLHJIOMJBK.FCDNMBBPBKI;
			EPMCPGDIBHI_RewardMvp = IDLHJIOMJBK.EPMCPGDIBHI;
			AKBHPFBDDOL_Rate = IDLHJIOMJBK.AKBHPFBDDOL;
		}

		//// RVA: 0x19B1FA4 Offset: 0x19B1FA4 VA: 0x19B1FA4
		//public uint CAOGDCBPBAN() { }
	}

	public class PIDMOGPJNNA
	{
		public int PPFNGGCBJKC; // 0x8
		public int LLNDMKBBNIJ; // 0xC
		public int OMIEMNDOPKA; // 0x10
		public int ICLFADEFBIH_UtaGrade; // 0x14
		public int FJOLNJLLJEJ_Rank; // 0x18
		public int OJLDNEGBFFG_DefeatRewardCount; // 0x1C
		public int DIDNBKKKEDK_FirstRewardCount; // 0x20
		public int CAFDIAFJDKP_MvpSpRewardCount; // 0x24
		public int EHOBDMHPMHB_DefeatSpRewardCount; // 0x28
		public int DIGJFGFKEJC_FirstSpRewardCount; // 0x2C
		public int JJELLPDAAEI_MvpRewardCount; // 0x30

		//// RVA: 0x19B33D4 Offset: 0x19B33D4 VA: 0x19B33D4
		public void KHEKNNFCAOI(LJIJADDCDBE IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			LLNDMKBBNIJ = IDLHJIOMJBK.LLNDMKBBNIJ;
			OMIEMNDOPKA = IDLHJIOMJBK.OMIEMNDOPKA;
			ICLFADEFBIH_UtaGrade = (int)IDLHJIOMJBK.ICLFADEFBIH;
			FJOLNJLLJEJ_Rank = (int)IDLHJIOMJBK.FJOLNJLLJEJ;
			OJLDNEGBFFG_DefeatRewardCount = (int)IDLHJIOMJBK.OJLDNEGBFFG;
			DIDNBKKKEDK_FirstRewardCount = (int)IDLHJIOMJBK.DIDNBKKKEDK;
			CAFDIAFJDKP_MvpSpRewardCount = (int)IDLHJIOMJBK.CAFDIAFJDKP;
			EHOBDMHPMHB_DefeatSpRewardCount = (int)IDLHJIOMJBK.EHOBDMHPMHB;
			DIGJFGFKEJC_FirstSpRewardCount = (int)IDLHJIOMJBK.DIGJFGFKEJC;
			JJELLPDAAEI_MvpRewardCount = (int)IDLHJIOMJBK.JJELLPDAAEI;
		}

		//// RVA: 0x19B359C Offset: 0x19B359C VA: 0x19B359C
		//public uint CAOGDCBPBAN() { }
	}

	public class MNFPNLMPOEB
	{
		public int PPFNGGCBJKC; // 0x8
		public int JIMJHIDEHNM_ApCost; // 0xC
		public int KMHIOCCFPEM_PointBonus; // 0x10
		public int PIABNPEFLEJ_SupportBonus; // 0x14
		public int BMAHHKLNOGA_CanonBaseChargeValue; // 0x18
		public int DHGAILOFNIP_McCannonAdd; // 0x1C

		//// RVA: 0x19B2EA8 Offset: 0x19B2EA8 VA: 0x19B2EA8
		public void KHEKNNFCAOI(KLBFLPLFPNF IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			JIMJHIDEHNM_ApCost = (int)IDLHJIOMJBK.JIMJHIDEHNM;
			KMHIOCCFPEM_PointBonus = (int)IDLHJIOMJBK.KMHIOCCFPEM;
			PIABNPEFLEJ_SupportBonus = (int)IDLHJIOMJBK.PIABNPEFLEJ;
			BMAHHKLNOGA_CanonBaseChargeValue = (int)IDLHJIOMJBK.BMAHHKLNOGA;
			DHGAILOFNIP_McCannonAdd = (int)IDLHJIOMJBK.DHGAILOFNIP;
		}

		//// RVA: 0x19B2FA8 Offset: 0x19B2FA8 VA: 0x19B2FA8
		//public uint CAOGDCBPBAN() { }
	}

	public class KHPDKADKOCP
	{
		public enum GMHNAPBHMMA
		{
			KBHGPMNGALJ = 1,
			PFIOMNHDHCO = 2,
			EKHDECEEFFJ = 3,
			LMIDAHNABGK = 11,
			ALMFFEOGPDN = 12,
			AHKGJELHFKN = 13,
		}

		public int PPFNGGCBJKC; // 0x8
		public int INDDJNMPONH_Cat; // 0xC
		public int GLCLFMGPMAN_FullItemId; // 0x10

		//// RVA: 0x19B2408 Offset: 0x19B2408 VA: 0x19B2408
		public void KHEKNNFCAOI(JHBMNFIHGBI IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			INDDJNMPONH_Cat = (int)IDLHJIOMJBK.GBJFNGCDKPM;
			GLCLFMGPMAN_FullItemId = (int)IDLHJIOMJBK.GLCLFMGPMAN;
		}

		//// RVA: 0x19B2490 Offset: 0x19B2490 VA: 0x19B2490
		//public uint CAOGDCBPBAN() { }
	}

	public class LDCCKEPPFMG
	{
		public class NEGFCJPAPLC
		{
			public int AIHOJKFNEEN_Id; // 0x8
			public int BFINGCJHOHI_Count; // 0xC
			public int EHKJFNAABMC_Rate; // 0x10
			public int DOOGFEGEKLG_Max; // 0x14
			public int DCFAPPHINAO_IsPickup; // 0x18

			//// RVA: 0x19B28D0 Offset: 0x19B28D0 VA: 0x19B28D0
			//public uint CAOGDCBPBAN() { }
		}

		public int PPFNGGCBJKC; // 0x8
		public NEGFCJPAPLC[] CMIGGBMMBKK_ItemRewards; // 0xC

		//// RVA: 0x19B24BC Offset: 0x19B24BC VA: 0x19B24BC
		public void KHEKNNFCAOI(KGNNHHFGLBG IDLHJIOMJBK)
		{
			PPFNGGCBJKC = (int)IDLHJIOMJBK.PPFNGGCBJKC;
			CMIGGBMMBKK_ItemRewards = new NEGFCJPAPLC[IDLHJIOMJBK.AIHOJKFNEEN.Length];
			for(int i = 0; i < IDLHJIOMJBK.AIHOJKFNEEN.Length; i++)
			{
				CMIGGBMMBKK_ItemRewards[i] = new NEGFCJPAPLC();
				CMIGGBMMBKK_ItemRewards[i].AIHOJKFNEEN_Id = (int)IDLHJIOMJBK.AIHOJKFNEEN[i];
				CMIGGBMMBKK_ItemRewards[i].BFINGCJHOHI_Count = (int)IDLHJIOMJBK.BFINGCJHOHI[i];
				CMIGGBMMBKK_ItemRewards[i].EHKJFNAABMC_Rate = (int)IDLHJIOMJBK.EHKJFNAABMC[i];
				CMIGGBMMBKK_ItemRewards[i].DOOGFEGEKLG_Max = (int)IDLHJIOMJBK.DOOGFEGEKLG[i];
				CMIGGBMMBKK_ItemRewards[i].DCFAPPHINAO_IsPickup = (int)IDLHJIOMJBK.DCFAPPHINAO[i];
			}
		}

		//// RVA: 0x19B2820 Offset: 0x19B2820 VA: 0x19B2820
		//public uint CAOGDCBPBAN() { }
	}

	public class NJLOJAKKGFK : AKIIJBEJOEP
	{
		public int DJJGNDCMNHF_BonusNormal; // 0x94
		public int MCNEIJAOLNO_RateNormal; // 0x98
		public int PENMGPNPHHG_BonusSp; // 0x9C
		public int PDJJELPFMJB_RateSp; // 0xA0

		//// RVA: 0x19B31FC Offset: 0x19B31FC VA: 0x19B31FC
		//public void LHPDDGIJKNB(string JOPOPMLFINI, int PPFNGGCBJKC, int KNEFBLHBDBG) { }

		//// RVA: 0x19B321C Offset: 0x19B321C VA: 0x19B321C
		public void BKEJPFLCLFC(string JOPOPMLFINI, int PPFNGGCBJKC, int KNEFBLHBDBG, NPAJGBIFLHB JMHECKKKMLK)
		{
			FDKFKPGFHNE(JOPOPMLFINI, PPFNGGCBJKC, KNEFBLHBDBG, JMHECKKKMLK);
            DFPOGOFGFBN data = JMHECKKKMLK.HBMGNHBFPHC[PPFNGGCBJKC - 1];
			DJJGNDCMNHF_BonusNormal = (int)data.DJJGNDCMNHF;
			MCNEIJAOLNO_RateNormal = (int)data.MCNEIJAOLNO;
			PENMGPNPHHG_BonusSp = (int)data.PENMGPNPHHG;
			PDJJELPFMJB_RateSp = (int)data.PDJJELPFMJB;
			FEMMDNIELFC_Desc = DatabaseTextConverter.TranslateEventMissionDesc(JOPOPMLFINI, 10000 + PPFNGGCBJKC, data.FEMMDNIELFC);
        }

		//// RVA: 0x19B336C Offset: 0x19B336C VA: 0x19B336C
		//public uint CAOGDCBPBAN() { }

		//// RVA: 0x19B33A4 Offset: 0x19B33A4 VA: 0x19B33A4
		public int ECEKNKIDING(bool MPKBLMCNHOM)
		{
			return MPKBLMCNHOM ? PENMGPNPHHG_BonusSp : DJJGNDCMNHF_BonusNormal;
		}

		//// RVA: 0x19B33B8 Offset: 0x19B33B8 VA: 0x19B33B8
		public int JKMDPGCCAJP(bool MPKBLMCNHOM)
		{
			return MPKBLMCNHOM ? PDJJELPFMJB_RateSp : MCNEIJAOLNO_RateNormal;
		}
	}

	public FODAKGKGJEL NGHKJOEDLIP = new FODAKGKGJEL(); // 0x20
	public List<AKIIJBEJOEP> NNMPGOAGEOL_Missions = new List<AKIIJBEJOEP>(); // 0x24
	public List<HECLALNLPEC> IJJHFGOIDOK_BossBattleList = new List<HECLALNLPEC>(); // 0x28
	public List<HAGIHCECBGH> GJFJLEOGFLD_BossInfo = new List<HAGIHCECBGH>(); // 0x2C
	public List<PIDMOGPJNNA> BFKJBHMHKAH_BossLevelsInfo = new List<PIDMOGPJNNA>(); // 0x30
	public List<MNFPNLMPOEB> NFOECEGILLC_AttacksInfo = new List<MNFPNLMPOEB>(); // 0x34
	public List<KHPDKADKOCP> HKLGCBKONJG_ValkCosBonusList = new List<KHPDKADKOCP>(); // 0x38
	public List<LDCCKEPPFMG> FNHDKHBNBBN_Rewards = new List<LDCCKEPPFMG>(); // 0x3C
	public List<NJLOJAKKGFK> HDMADAHNLDN_BossMissions = new List<NJLOJAKKGFK>(); // 0x40
	public List<NEOBLDCCPFI> GEGAEDDGNMA = new List<NEOBLDCCPFI>(); // 0x44
	public List<LOJCDFAHECI> OGMHMAGDNAM = new List<LOJCDFAHECI>(); // 0x48
	public List<LIPNCAJACFG> LHAKGDAGEMM_Episodes = new List<LIPNCAJACFG>(); // 0x4C
	public List<IJNOIMLNBGN> LLCLJBEJOPM_BannerInfo = new List<IJNOIMLNBGN>(); // 0x58

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x50 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x54 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xC8A760 Offset: 0xC8A760 VA: 0xC8A760
	public PIDMOGPJNNA ODMCAHDEEBK(int ANAJIAENLNB)
	{
		if(ANAJIAENLNB > 0 && ANAJIAENLNB <= BFKJBHMHKAH_BossLevelsInfo.Count)
		{
			return BFKJBHMHKAH_BossLevelsInfo[ANAJIAENLNB - 1];
		}
		return null;
	}

	//// RVA: 0xC8A820 Offset: 0xC8A820 VA: 0xC8A820
	public HAGIHCECBGH POCOCNENCOE_GetBossInfo(int MFMPCHIJINJ)
	{
		if(MFMPCHIJINJ > 0 && MFMPCHIJINJ - 1 < GJFJLEOGFLD_BossInfo.Count)
		{
			return GJFJLEOGFLD_BossInfo[MFMPCHIJINJ - 1];
		}
		return null;
	}

	//// RVA: 0xC8A8E0 Offset: 0xC8A8E0 VA: 0xC8A8E0
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(!FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	//// RVA: 0xC8A9C4 Offset: 0xC8A9C4 VA: 0xC8A9C4
	public bool GNKACELEIAC(string LJNAKDMILMC)
	{
		return FJOEBCMGDMI.ContainsKey(LJNAKDMILMC);
	}

	//// RVA: 0xC8AA44 Offset: 0xC8AA44 VA: 0xC8AA44
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(!OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return KKMJBMKHGNH;
		return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
	}

	// RVA: 0xC8AB28 Offset: 0xC8AB28 VA: 0xC8AB28
	public BKOGPDBKFFJ_EventRaid()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 38;
	}

	// RVA: 0xC8AEE4 Offset: 0xC8AEE4 VA: 0xC8AEE4 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP.LHPDDGIJKNB();
		NNMPGOAGEOL_Missions.Clear();
		IJJHFGOIDOK_BossBattleList.Clear();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
		GJFJLEOGFLD_BossInfo.Clear();
		BFKJBHMHKAH_BossLevelsInfo.Clear();
		NFOECEGILLC_AttacksInfo.Clear();
		HKLGCBKONJG_ValkCosBonusList.Clear();
		FNHDKHBNBBN_Rewards.Clear();
		GEGAEDDGNMA.Clear();
		OGMHMAGDNAM.Clear();
		LHAKGDAGEMM_Episodes.Clear();
	}

	// RVA: 0xC8B160 Offset: 0xC8B160 VA: 0xC8B160 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		NPAJGBIFLHB data = NPAJGBIFLHB.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF(data);
		CFOFJPLEDEA(data);
		GJEHPJJBCDE(data);
		JFIFGGCOJHN(data);
		EPGINHNJKGL(data);
		ONOPGNAJBPH(data);
		HFLMDOKCAAP(data);
		DOJBHOBIMCG(data);
		PCKILNACEKE(data);
		ABICOINNGEK(data);
		EGLHCMDNFOE(data);
		JBNBGGDDEGG(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP.OPFGFINHFCE_Name+" "+NGHKJOEDLIP.OBGBAOLONDD_EventId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			UnityEngine.Debug.LogError("Raid : "+NGHKJOEDLIP.BONDDBOFBND_Start+" "+NGHKJOEDLIP.HPNOGLIFJOP_End1+" "+NGHKJOEDLIP.EHHFFKAFOMC+" "+NGHKJOEDLIP.LNFKGHNHJKE+" "+NGHKJOEDLIP.JGMDAOACOJF+" "+NGHKJOEDLIP.IDDBFFBPNGI+" "+NGHKJOEDLIP.KNLGKBBIBOH_End);
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP.BONDDBOFBND_Start);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP.BONDDBOFBND_Start;
			if (NGHKJOEDLIP.BONDDBOFBND_Start != 0) NGHKJOEDLIP.BONDDBOFBND_Start += offset;
			if (NGHKJOEDLIP.HPNOGLIFJOP_End1 != 0) NGHKJOEDLIP.HPNOGLIFJOP_End1 += offset;
			if (NGHKJOEDLIP.EHHFFKAFOMC != 0) NGHKJOEDLIP.EHHFFKAFOMC += offset;
			if (NGHKJOEDLIP.LNFKGHNHJKE != 0) NGHKJOEDLIP.LNFKGHNHJKE += offset;
			if (NGHKJOEDLIP.JGMDAOACOJF != 0) NGHKJOEDLIP.JGMDAOACOJF += offset;
			if (NGHKJOEDLIP.IDDBFFBPNGI != 0) NGHKJOEDLIP.IDDBFFBPNGI += offset;
			if (NGHKJOEDLIP.KNLGKBBIBOH_End != 0) NGHKJOEDLIP.KNLGKBBIBOH_End += offset;

			for(int i = 0; i < IJJHFGOIDOK_BossBattleList.Count; i++)
			{
				if (IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt != 0) IJJHFGOIDOK_BossBattleList[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt != 0) IJJHFGOIDOK_BossBattleList[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for(int i = 0; i < NNMPGOAGEOL_Missions.Count; i++)
			{
				if (NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start != 0) NNMPGOAGEOL_Missions[i].KJBGCLPMLCG_Start = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End != 0) NNMPGOAGEOL_Missions[i].GJFPFFBAKGK_End = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
			for(int i = 0; i < LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if (LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt != 0) LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt = NGHKJOEDLIP.BONDDBOFBND_Start;
				if (LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt != 0) LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt = NGHKJOEDLIP.HPNOGLIFJOP_End1;
			}
		}

		return true;
	}

	// RVA: 0xC8CC78 Offset: 0xC8CC78 VA: 0xC8CC78 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	//// RVA: 0xC8B4B8 Offset: 0xC8B4B8 VA: 0xC8B4B8
	private bool DGKKMKLCEDF(NPAJGBIFLHB KNOEHKKNIJA)
	{
		DGALLBPNAMN data = KNOEHKKNIJA.HMBHNLCFDIH;
		NGHKJOEDLIP.OBGBAOLONDD_EventId = (int)data.OBGBAOLONDD;
		NGHKJOEDLIP.OPFGFINHFCE_Name = data.OPFGFINHFCE;
		NGHKJOEDLIP.HEDAGCNPHGD = data.HEDAGCNPHGD;
		NGHKJOEDLIP.OCGFKMHNEOF = data.OCGFKMHNEOF;
		NGHKJOEDLIP.BONDDBOFBND_Start = data.BONDDBOFBND;
		NGHKJOEDLIP.HPNOGLIFJOP_End1 = data.HPNOGLIFJOP;
		NGHKJOEDLIP.EHHFFKAFOMC = data.EHHFFKAFOMC;
		NGHKJOEDLIP.LNFKGHNHJKE = data.LNFKGHNHJKE;
		NGHKJOEDLIP.JGMDAOACOJF = data.JGMDAOACOJF;
		NGHKJOEDLIP.IDDBFFBPNGI = data.IDDBFFBPNGI;
		NGHKJOEDLIP.KNLGKBBIBOH_End = data.KNLGKBBIBOH;
		NGHKJOEDLIP.POGEFBMBPCB = (sbyte)data.JMJDLDEIFKE;
		NGHKJOEDLIP.AHKNMANFILO = (sbyte)data.AHKNMANFILO;
		NGHKJOEDLIP.MOEKELIIDEO_SaveIdx = (sbyte)data.MOEKELIIDEO;
		NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix = data.OCDMGOGMHGE;
		NGHKJOEDLIP.PJBILOFOCIC = data.PJBILOFOCIC;
		NGHKJOEDLIP.MJBKGOJBPAD_TicketType = data.MJBKGOJBPAD;
		NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc = data.FEMMDNIELFC;
		NGHKJOEDLIP.HKKNEAGCIEB = (sbyte)data.HKKNEAGCIEB;
		NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId = data.HIOOGLEJBKM;
		NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId = data.FJCADCDNPMP;
		NGHKJOEDLIP.EJBGHLOOLBC = data.EJBGHLOOLBC;
		NGHKJOEDLIP.AHKPNPNOAMO = (sbyte)data.AHKPNPNOAMO;
		NGHKJOEDLIP.OMCAOJJGOGG = data.OMCAOJJGOGG;
		for(int i = 0; i < data.JHPCPNJJHLI.Length; i++)
		{
			if(data.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP.JHPCPNJJHLI.Add(data.JHPCPNJJHLI[i]);
			}
		}
		IJNOIMLNBGN.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, LLCLJBEJOPM_BannerInfo, KNOEHKKNIJA);
		return true;
	}

	//// RVA: 0xC8BC10 Offset: 0xC8BC10 VA: 0xC8BC10
	private bool CFOFJPLEDEA(NPAJGBIFLHB KNOEHKKNIJA)
	{
		MJDMKEIPOLH[] array = KNOEHKKNIJA.MDDOGIAFDEI;
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < array.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			NNMPGOAGEOL_Missions.Add(data);
			xor += 13;
		}
		return true;
	}

	//// RVA: 0xC8BDA8 Offset: 0xC8BDA8 VA: 0xC8BDA8
	private bool GJEHPJJBCDE(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.GHIHAGAOPNC.Length; i++)
		{
			HECLALNLPEC data = new HECLALNLPEC();
			data.KHEKNNFCAOI(i + 1, KNOEHKKNIJA);
			IJJHFGOIDOK_BossBattleList.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8BEC8 Offset: 0xC8BEC8 VA: 0xC8BEC8
	private bool JFIFGGCOJHN(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.EENBPAPDNBP.Length; i++)
		{
			HAGIHCECBGH data = new HAGIHCECBGH();
			data.KHEKNNFCAOI(JIKKNHIAEKG_BlockName, KNOEHKKNIJA.EENBPAPDNBP[i]);
			GJFJLEOGFLD_BossInfo.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C038 Offset: 0xC8C038 VA: 0xC8C038
	private bool EPGINHNJKGL(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.JLKPDLCFEIM.Length; i++)
		{
			PIDMOGPJNNA data = new PIDMOGPJNNA();
			data.KHEKNNFCAOI(KNOEHKKNIJA.JLKPDLCFEIM[i]);
			BFKJBHMHKAH_BossLevelsInfo.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C1A8 Offset: 0xC8C1A8 VA: 0xC8C1A8
	private bool ONOPGNAJBPH(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.JFLFHONDDNM.Length; i++)
		{
			MNFPNLMPOEB data = new MNFPNLMPOEB();
			data.KHEKNNFCAOI(KNOEHKKNIJA.JFLFHONDDNM[i]);
			NFOECEGILLC_AttacksInfo.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C318 Offset: 0xC8C318 VA: 0xC8C318
	private bool HFLMDOKCAAP(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.PNMLJIPOOPO.Length; i++)
		{
			KHPDKADKOCP data = new KHPDKADKOCP();
			data.KHEKNNFCAOI(KNOEHKKNIJA.PNMLJIPOOPO[i]);
			HKLGCBKONJG_ValkCosBonusList.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C488 Offset: 0xC8C488 VA: 0xC8C488
	private bool DOJBHOBIMCG(NPAJGBIFLHB KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.DOKBJLFIGDM.Length; i++)
		{
			LDCCKEPPFMG data = new LDCCKEPPFMG();
			data.KHEKNNFCAOI(KNOEHKKNIJA.DOKBJLFIGDM[i]);
			FNHDKHBNBBN_Rewards.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8C5F8 Offset: 0xC8C5F8 VA: 0xC8C5F8
	private bool PCKILNACEKE(NPAJGBIFLHB KNOEHKKNIJA)
	{
		int xor = (int)NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		xor *= 18;
		for(int i = 0; i < KNOEHKKNIJA.HBMGNHBFPHC.Length; i++)
		{
			NJLOJAKKGFK data = new NJLOJAKKGFK();
			data.BKEJPFLCLFC(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			HDMADAHNLDN_BossMissions.Add(data);
		}
		return true;
	}

	//// RVA: 0xC8CAF4 Offset: 0xC8CAF4 VA: 0xC8CAF4
	private bool JBNBGGDDEGG(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.OLACFKILCFD.Length; i++)
		{
			NEOBLDCCPFI data = new NEOBLDCCPFI();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			GEGAEDDGNMA.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0xC8C7EC Offset: 0xC8C7EC VA: 0xC8C7EC
	private bool ABICOINNGEK(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MIOCOKLMLBD.Length; i++)
		{
			LOJCDFAHECI data = new LOJCDFAHECI();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			OGMHMAGDNAM.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	//// RVA: 0xC8C970 Offset: 0xC8C970 VA: 0xC8C970
	private bool EGLHCMDNFOE(NPAJGBIFLHB JMHECKKKMLK)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.IEJLJIHIDJC.Length; i++)
		{
			LIPNCAJACFG data = new LIPNCAJACFG();
			data.BAFFAONJPCE(i, xor, JMHECKKKMLK);
			LHAKGDAGEMM_Episodes.Add(data);
			xor = xor * 3 + 13;
		}
		return true;
	}

	// RVA: 0xC8CC80 Offset: 0xC8CC80 VA: 0xC8CC80 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BKOGPDBKFFJ_EventRaid.CAOGDCBPBAN");
		return 0;
	}
}
