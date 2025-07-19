
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use NILOACEHJKJ_EventSP", true)]
public class NILOACEHJKJ { }
public class NILOACEHJKJ_EventSP : KLFDBFMNLBL_ServerSaveBlock
{
	public enum AKLOCALEDJH
	{
		LHPDDGIJKNB = 0,
		LABMNHNPFOM = 1,
		KMFICPOJMEA = 2,
		CHFLIKMLDPF = 4,
		GAKNNFOFJEK = 8,
	}

	public class MDCMFPENCEK
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public long AADPAJOLEEF_Crypted; // 0x10
		public long IOJOBGHPLIE_Crypted; // 0x18
		public long DLEEMCAPOBP_Crypted; // 0x20
		public long JPNMMOEPAEM_Crypted; // 0x28
		public int FOEHHBMNGNK; // 0x30
		public int DGFLFPAMNJO; // 0x34
		public int AFGHJEJKDHN_Crypted; // 0x38
		public int FBDJBMDEENG_Crypted; // 0x3C
		public sbyte MLLPMIHMMFL_Crypted; // 0x40
		public string MDADLCOCEBN_SessionId = ""; // 0x44
		public int HFIHMDILNFD_Crypted; // 0x48
		public int IGMFFIKLEHP_Crypted; // 0x4C
		public int NOOCBEMKDDG_Crypted; // 0x50
		public int HPMDPMFNAAO_Crypted; // 0x54
		public int AIONCABLDOC_Crypted; // 0x58
		public int OAACFDNGGDI_Crypted; // 0x5C
		public int HJDDHKOMADA_Crypted; // 0x60
		public int LPMDBMGPCFE_Crypted; // 0x64
		public int KEOIOOONAPE_Crypted; // 0x68
		public int MMNBJIJFOGI_Crypted; // 0x6C
		public int JEHBIJBEAMA_Crypted; // 0x70
		public int IHFLDDNELGL_Crypted; // 0x74
		public int MLAHEIEEKBL_Crypted; // 0x78
		public int IOCGPIKNNNO_Crypted; // 0x7C
		public int PFGPGEGKDJE_Crypted; // 0x80
		public int FONJDDLBEOI_Crypted; // 0x84
		public int NGEJNCDBJID_Crypted; // 0x88
		public int PEPGHOEFCNP_Crypted; // 0x8C
		public long BEBJKJKBOGH_Date; // 0x90
		public int IJKJKAMLDMF_Crypted; // 0x98
		public int ICHOLIKNAIB_Crypted; // 0x9C
		public byte[] AKBDBIGGADH_NewFlags = new byte[8]; // 0xA0
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(180); // 0xA4
		public string MPCAGEPEJJJ_Key; // 0xA8
		public long EGBOHDFBAPB_End; // 0xB0
		public bool IMFBCJOIJKJ_Entry; // 0xB8
		public bool ABBJBPLHFHA_Spurt; // 0xB9
		public int INLNJOGHLJE_Show; // 0xBC
		public int MHKICPIMFEI_PlayCount; // 0xC0
		public int PIEBOKFJKKH_RTodayCount; // 0xC4
		public long OOBBAGJNDIH_LstHpTime; // 0xC8
		private int OGDIHNMDHML_Crypted; // 0xD0
		public int CCABNCGIHNI_Rslt; // 0xD4
		public int PPHEALAJAKD_MiSet; // 0xD8
		public int LIEKIBHAPKC_FId; // 0xDC
		public bool KGGPBOEPKCE_PrevSel; // 0xE0
		public List<sbyte> LCDIGDMGPGO = new List<sbyte>(); // 0xE4

		public int JJMIEHHIKJE_RplQuest { get { return OGDIHNMDHML_Crypted ^ ENOBDCFHELD; } set { OGDIHNMDHML_Crypted = value ^ ENOBDCFHELD; } } // 0x18A3228 JLJEEPEHOPF 0x18A487C NNGOLJDAHEP
		public bool HPLMECLKFID_R_Rcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } // 0x18A3164 DCHHABKOMFP 0x18A47AC EGGIBMLGCOJ
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3134 JKHIIAEMMDE 0x18A46C4 PFFKLBLEPKB
		public long NFIOKIBPJCJ_Uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A314C NGIDBCKCAMO 0x18A4748 AEHIIPBDNGE
		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_Crypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_Crypted = value ^ ENOBDCFHELD; FBDJBMDEENG_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3178 MAFBDLKFHGJ 0x18A4770 EPEFBOIALDI
		public int NKCCNNNJGJF_SelCard { get { return NOOCBEMKDDG_Crypted ^ ENOBDCFHELD; } set { NOOCBEMKDDG_Crypted = value ^ ENOBDCFHELD; HPMDPMFNAAO_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3188 AOMJCKPMOAI 0x18A4784 KLMJNGAGDHO
		public int PFKHDMGPGKL_SelDf { get { return AIONCABLDOC_Crypted ^ ENOBDCFHELD; } set { AIONCABLDOC_Crypted = value ^ ENOBDCFHELD; OAACFDNGGDI_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3198 BKNGCMPPAAI 0x18A4798 CIGDNLKIFEM
		public int POENMEGPHCG_Reset { get { return HJDDHKOMADA_Crypted ^ ENOBDCFHELD; } set { HJDDHKOMADA_Crypted = value ^ ENOBDCFHELD; LPMDBMGPCFE_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31A8 NBIINAFIJEN 0x18A47DC FKNEOBLFDIM
		public int KNOINFOHCAL_DivaTouchCount { get { return MLAHEIEEKBL_Crypted ^ ENOBDCFHELD; } set { MLAHEIEEKBL_Crypted = value ^ ENOBDCFHELD; IOCGPIKNNNO_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31B8 HCMGKCGCLIF 0x18A47F0 DCONACCLAED
		public int CDAHMFBNOFA_DivaIntimacyCount { get { return PFGPGEGKDJE_Crypted ^ ENOBDCFHELD; } set { PFGPGEGKDJE_Crypted = value ^ ENOBDCFHELD; FONJDDLBEOI_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31C8 BHGPEFNDMJH 0x18A4804 DCINANHOILH
		public int ECABPJAIIOM_DivaPresentCount { get { return NGEJNCDBJID_Crypted ^ ENOBDCFHELD; } set { NGEJNCDBJID_Crypted = value ^ ENOBDCFHELD; PEPGHOEFCNP_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31D8 DJCADKFGHPB 0x18A4818 KOCLDKDFOPE
		public int BLPJMHLJGKK_AdvIsShowBits { get { return IJKJKAMLDMF_Crypted ^ ENOBDCFHELD; } set { IJKJKAMLDMF_Crypted = value ^ ENOBDCFHELD; ICHOLIKNAIB_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31E8 CCFOPOBNKDE 0x18A482C PCMNHIPAKBG
		public int JNAHAJFKKCB_EpiCount { get { return JEHBIJBEAMA_Crypted ^ ENOBDCFHELD; } set { JEHBIJBEAMA_Crypted = value ^ ENOBDCFHELD; IHFLDDNELGL_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A31F8 DHIOKCLDFIE 0x18A4840 AMKBAJJLMGF
		public int NBNFHHLCMDH_EpiBo { get { return KEOIOOONAPE_Crypted ^ ENOBDCFHELD; } set { KEOIOOONAPE_Crypted = value ^ ENOBDCFHELD; MMNBJIJFOGI_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3208 LJGJCGBMGPN 0x18A4854 CBEODBCPDOJ
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } // 0x18A3218 PBEMPHPDDDB 0x18A4868 MCADMIEOCCF

		// // RVA: 0x18AB260 Offset: 0x18AB260 VA: 0x18AB260
		public void DHHNKEIBCOK(int OIPCCBHIKIA, bool JKDJCFEBDHC)
		{
			if((OIPCCBHIKIA >> 3) > 7)
				return;
			if(JKDJCFEBDHC)
				AKBDBIGGADH_NewFlags[OIPCCBHIKIA >> 3] &= (byte)~(1 << (OIPCCBHIKIA & 7));
			else
				AKBDBIGGADH_NewFlags[OIPCCBHIKIA >> 3] |= (byte)(1 << (OIPCCBHIKIA & 7));
		}

		// // RVA: 0x18AB2D0 Offset: 0x18AB2D0 VA: 0x18AB2D0
		public bool IHPAMMBNOPC(int OIPCCBHIKIA)
		{
			if((OIPCCBHIKIA >> 3) > 7)
				return true;
			return ((1 << (OIPCCBHIKIA & 7)) & AKBDBIGGADH_NewFlags[OIPCCBHIKIA >> 3]) == 0;
		}

		// // RVA: g Offset: 0x18AB340 VA: 0x18AB340
		public bool BHIAKGKHKGD(int BMBBDIAEOMP)
		{
			return LCDIGDMGPGO[BMBBDIAEOMP] != 20;
		}

		// // RVA: 0x18AB1CC Offset: 0x18AB1CC VA: 0x18AB1CC
		public void IPNLHCLFIDB(int BMBBDIAEOMP, bool JKDJCFEBDHC)
		{
			LCDIGDMGPGO[BMBBDIAEOMP] = (sbyte)(JKDJCFEBDHC ? 40 : 20);
		}

		// // RVA: 0x18A1DA4 Offset: 0x18A1DA4 VA: 0x18A1DA4
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_End = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			HPLMECLKFID_R_Rcv = false;
			LGADCGFMLLD_Step = 0;
			INLNJOGHLJE_Show = 0;
			OMCAOJJGOGG_Lb = 0;
			NKCCNNNJGJF_SelCard = 0;
			PFKHDMGPGKL_SelDf = 0;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_Uptime = 0;
			LCDIGDMGPGO.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO.Add(20);
			}
			NNMPGOAGEOL_Quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 180; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			CDAHMFBNOFA_DivaIntimacyCount = 0;
			ECABPJAIIOM_DivaPresentCount = 0;
			BEBJKJKBOGH_Date = 0;
			BLPJMHLJGKK_AdvIsShowBits = 0;
			POENMEGPHCG_Reset = 0;
			NBNFHHLCMDH_EpiBo = 0;
			JNAHAJFKKCB_EpiCount = 0;
			KNOINFOHCAL_DivaTouchCount = 0;
			PIEBOKFJKKH_RTodayCount = 0;
			MHKICPIMFEI_PlayCount = 0;
			MDADLCOCEBN_SessionId = "";
			LIEKIBHAPKC_FId = 0;
			KGGPBOEPKCE_PrevSel = false;
			PPHEALAJAKD_MiSet = 0;
			JJMIEHHIKJE_RplQuest = 0;
			OOBBAGJNDIH_LstHpTime = 0;
			PPHEALAJAKD_MiSet = 0;
			CCABNCGIHNI_Rslt = 0;
			for(int i = 0; i < 8; i++)
			{
				AKBDBIGGADH_NewFlags[i] = 0;
			}
		}

		// // RVA: 0x18A4A5C Offset: 0x18A4A5C VA: 0x18A4A5C
		public void ODDIHGPONFL(MDCMFPENCEK GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_R_Rcv = GPBJHKLFCEP.HPLMECLKFID_R_Rcv;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			NKCCNNNJGJF_SelCard = GPBJHKLFCEP.NKCCNNNJGJF_SelCard;
			PFKHDMGPGKL_SelDf = GPBJHKLFCEP.PFKHDMGPGKL_SelDf;
			POENMEGPHCG_Reset = GPBJHKLFCEP.POENMEGPHCG_Reset;
			KNOINFOHCAL_DivaTouchCount = GPBJHKLFCEP.KNOINFOHCAL_DivaTouchCount;
			CDAHMFBNOFA_DivaIntimacyCount = GPBJHKLFCEP.CDAHMFBNOFA_DivaIntimacyCount;
			ECABPJAIIOM_DivaPresentCount = GPBJHKLFCEP.ECABPJAIIOM_DivaPresentCount;
			BLPJMHLJGKK_AdvIsShowBits = GPBJHKLFCEP.BLPJMHLJGKK_AdvIsShowBits;
			JNAHAJFKKCB_EpiCount = GPBJHKLFCEP.JNAHAJFKKCB_EpiCount;
			NBNFHHLCMDH_EpiBo = GPBJHKLFCEP.NBNFHHLCMDH_EpiBo;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			NFIOKIBPJCJ_Uptime = GPBJHKLFCEP.NFIOKIBPJCJ_Uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO[i] = GPBJHKLFCEP.LCDIGDMGPGO[i];
			}
			for(int i = 0; i < 180; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			MDADLCOCEBN_SessionId = GPBJHKLFCEP.MDADLCOCEBN_SessionId;
			CCABNCGIHNI_Rslt = GPBJHKLFCEP.CCABNCGIHNI_Rslt;
			PPHEALAJAKD_MiSet = GPBJHKLFCEP.PPHEALAJAKD_MiSet;
			LIEKIBHAPKC_FId = GPBJHKLFCEP.LIEKIBHAPKC_FId;
			KGGPBOEPKCE_PrevSel = GPBJHKLFCEP.KGGPBOEPKCE_PrevSel;
			MHKICPIMFEI_PlayCount = GPBJHKLFCEP.MHKICPIMFEI_PlayCount;
			PIEBOKFJKKH_RTodayCount = GPBJHKLFCEP.PIEBOKFJKKH_RTodayCount;
			JJMIEHHIKJE_RplQuest = GPBJHKLFCEP.JJMIEHHIKJE_RplQuest;
			OOBBAGJNDIH_LstHpTime = GPBJHKLFCEP.OOBBAGJNDIH_LstHpTime;
			for(int i = 0; i < AKBDBIGGADH_NewFlags.Length; i++)
			{
				AKBDBIGGADH_NewFlags[i] = GPBJHKLFCEP.AKBDBIGGADH_NewFlags[i];
			}
		}

		// // RVA: 0x18A526C Offset: 0x18A526C VA: 0x18A526C
		public bool AGBOGBEOFME(MDCMFPENCEK OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(HPLMECLKFID_R_Rcv != OIKJFMGEICL.HPLMECLKFID_R_Rcv)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(LCDIGDMGPGO.Count != OIKJFMGEICL.LCDIGDMGPGO.Count)
				return false;
			if(KGGPBOEPKCE_PrevSel != OIKJFMGEICL.KGGPBOEPKCE_PrevSel)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step)
				return false;
			if(NKCCNNNJGJF_SelCard != OIKJFMGEICL.NKCCNNNJGJF_SelCard)
				return false;
			if(PFKHDMGPGKL_SelDf != OIKJFMGEICL.PFKHDMGPGKL_SelDf)
				return false;
			if(POENMEGPHCG_Reset != OIKJFMGEICL.POENMEGPHCG_Reset)
				return false;
			if(KNOINFOHCAL_DivaTouchCount != OIKJFMGEICL.KNOINFOHCAL_DivaTouchCount)
				return false;
			if(CDAHMFBNOFA_DivaIntimacyCount != OIKJFMGEICL.CDAHMFBNOFA_DivaIntimacyCount)
				return false;
			if(ECABPJAIIOM_DivaPresentCount != OIKJFMGEICL.ECABPJAIIOM_DivaPresentCount)
				return false;
			if(BLPJMHLJGKK_AdvIsShowBits != OIKJFMGEICL.BLPJMHLJGKK_AdvIsShowBits)
				return false;
			if(JNAHAJFKKCB_EpiCount != OIKJFMGEICL.JNAHAJFKKCB_EpiCount)
				return false;
			if(NBNFHHLCMDH_EpiBo != OIKJFMGEICL.NBNFHHLCMDH_EpiBo)
				return false;
			if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
				return false;
			if(NFIOKIBPJCJ_Uptime != OIKJFMGEICL.NFIOKIBPJCJ_Uptime)
				return false;
			if(CCABNCGIHNI_Rslt != OIKJFMGEICL.CCABNCGIHNI_Rslt)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(PPHEALAJAKD_MiSet != OIKJFMGEICL.PPHEALAJAKD_MiSet)
				return false;
			if(MHKICPIMFEI_PlayCount != OIKJFMGEICL.MHKICPIMFEI_PlayCount)
				return false;
			if(PIEBOKFJKKH_RTodayCount != OIKJFMGEICL.PIEBOKFJKKH_RTodayCount)
				return false;
			if(JJMIEHHIKJE_RplQuest != OIKJFMGEICL.JJMIEHHIKJE_RplQuest)
				return false;
			if(OOBBAGJNDIH_LstHpTime != OIKJFMGEICL.OOBBAGJNDIH_LstHpTime)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO[i] != OIKJFMGEICL.LCDIGDMGPGO[i])
					return false;
			}
			for(int i = 0; i < 180; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			for(int i = 0; i < AKBDBIGGADH_NewFlags.Length; i++)
			{
				if(AKBDBIGGADH_NewFlags[i] != OIKJFMGEICL.AKBDBIGGADH_NewFlags[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x18A5CB8 Offset: 0x18A5CB8 VA: 0x18A5CB8
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NILOACEHJKJ.MDCMFPENCEK OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 1;
	public const int BJEPEBMLKOL = 180;
	public const int AJCLDHGLJPD = 3;
	public const int DDCDBOAAOAE = 15;
	public const long EGHFCEBIGEE = 99999999;
	public const int KKBHHBGCNJO = 5;
	public const int DOONPLKIOGD = 10;
	public const int DMEGFNFACCM = 64;
	public const int GHLGOJKGOMA = 8;
	public List<MDCMFPENCEK> FBCJICEPLED = new List<MDCMFPENCEK>(); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0x18AB184 NFKFOODCJJB

	// // RVA: 0x18A1B38 Offset: 0x18A1B38 VA: 0x18A1B38
	public NILOACEHJKJ_EventSP()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x18A1BD4 Offset: 0x18A1BD4 VA: 0x18A1BD4 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		MDCMFPENCEK data = new MDCMFPENCEK();
		data.LHPDDGIJKNB();
		FBCJICEPLED.Add(data);
	}

	// // RVA: 0x18A20D0 Offset: 0x18A20D0 VA: 0x18A20D0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

		EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
		data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < FBCJICEPLED[0].LCDIGDMGPGO.Count; i++)
		{
			data4.Add(FBCJICEPLED[0].BHIAKGKHKGD(i));
		}
		EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
		data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 180; i++)
		{
			data5.Add(FBCJICEPLED[0].NNMPGOAGEOL_Quests[i].NOJCMGAFAAC());
		}
		EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
		data3[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[0].MPCAGEPEJJJ_Key;
		data3[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[0].EGBOHDFBAPB_End;
		data3[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[0].IMFBCJOIJKJ_Entry ? 1 : 0;
		data3[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[0].ABBJBPLHFHA_Spurt ? 1 : 0;
		data3[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[0].DNBFMLBNAEE_Point;
		data3[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[0].NFIOKIBPJCJ_Uptime;
		data3[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[0].HPLMECLKFID_R_Rcv ? 1 : 0;
		data3[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data4;
		data3[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[0].LGADCGFMLLD_Step;
		data3[AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card] = FBCJICEPLED[0].NKCCNNNJGJF_SelCard;
		data3[AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df] = FBCJICEPLED[0].PFKHDMGPGKL_SelDf;
		data3[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data5;
		data3[AFEHLCGHAEE_Strings.POENMEGPHCG_reset] = FBCJICEPLED[0].POENMEGPHCG_Reset;
		data3["diva_touch_cnt"] = FBCJICEPLED[0].KNOINFOHCAL_DivaTouchCount;
		data3["diva_intimacy_cnt"] = FBCJICEPLED[0].CDAHMFBNOFA_DivaIntimacyCount;
		data3["diva_present_cnt"] = FBCJICEPLED[0].ECABPJAIIOM_DivaPresentCount;
		data3["adv_is_show_bits"] = FBCJICEPLED[0].BLPJMHLJGKK_AdvIsShowBits;
		data3["epi_cnt"] = FBCJICEPLED[0].JNAHAJFKKCB_EpiCount;
		data3["epi_bo"] = FBCJICEPLED[0].NBNFHHLCMDH_EpiBo;
		data3[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = FBCJICEPLED[0].BEBJKJKBOGH_Date;
		data3["show"] = FBCJICEPLED[0].INLNJOGHLJE_Show;
		data3[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[0].MDADLCOCEBN_SessionId;
		data3["rslt"] = FBCJICEPLED[0].CCABNCGIHNI_Rslt;
		data3["lb"] = FBCJICEPLED[0].OMCAOJJGOGG_Lb;
		data3["f_id"] = FBCJICEPLED[0].LIEKIBHAPKC_FId;
		data3["mi_set"] = FBCJICEPLED[0].PPHEALAJAKD_MiSet;
		data3["prev_sel"] = FBCJICEPLED[0].KGGPBOEPKCE_PrevSel ? 1 : 0;
		data3["play_cnt"] = FBCJICEPLED[0].MHKICPIMFEI_PlayCount;
		data3["r_today_cnt"] = FBCJICEPLED[0].PIEBOKFJKKH_RTodayCount;
		data3["lst_hp_time"] = FBCJICEPLED[0].OOBBAGJNDIH_LstHpTime;
		data3["rpl_quest"] = FBCJICEPLED[0].JJMIEHHIKJE_RplQuest;
		data3[AFEHLCGHAEE_Strings.COJJHFBKGML_new_flag] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(FBCJICEPLED[0].AKBDBIGGADH_NewFlags);
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			data6[JIKKNHIAEKG_BlockName] = data3;
			data6[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data6;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
			OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data3;
		}
	}

	// // RVA: 0x18A3238 Offset: 0x18A3238 VA: 0x18A3238 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null || !block.EPNGJLOKGIF_IsArray)
			{
				isInvalid = true;
			}
			else
			{
				if(block.HNBFOAJIIAL_Count > 0)
				{
					if(block.HNBFOAJIIAL_Count != 1)
						isInvalid = true;
					for(int i = 0; i < 1; i++)
					{
						EDOHBJAPLPF_JsonData d = block[i];
						FGCNMLBACGO_ReadString(d, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						MDCMFPENCEK CCBEKGNDDBE = FBCJICEPLED[i];
						CCBEKGNDDBE.MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(d, AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						CCBEKGNDDBE.EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						CCBEKGNDDBE.IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						CCBEKGNDDBE.ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						CCBEKGNDDBE.DNBFMLBNAEE_Point = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						CCBEKGNDDBE.NFIOKIBPJCJ_Uptime = DKMPHAPBDLH_ReadLong(d, AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						CCBEKGNDDBE.LGADCGFMLLD_Step = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						CCBEKGNDDBE.NKCCNNNJGJF_SelCard = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card, 0, ref isInvalid);
						CCBEKGNDDBE.PFKHDMGPGKL_SelDf = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df, 0, ref isInvalid);
						CCBEKGNDDBE.HPLMECLKFID_R_Rcv = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						CCBEKGNDDBE.POENMEGPHCG_Reset = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.POENMEGPHCG_reset, 0, ref isInvalid);
						CCBEKGNDDBE.KNOINFOHCAL_DivaTouchCount = CJAENOMGPDA_ReadInt(d, "diva_touch_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.CDAHMFBNOFA_DivaIntimacyCount = CJAENOMGPDA_ReadInt(d, "diva_intimacy_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.ECABPJAIIOM_DivaPresentCount = CJAENOMGPDA_ReadInt(d, "diva_present_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.BLPJMHLJGKK_AdvIsShowBits = CJAENOMGPDA_ReadInt(d, "adv_is_show_bits", 0, ref isInvalid);
						CCBEKGNDDBE.JNAHAJFKKCB_EpiCount = CJAENOMGPDA_ReadInt(d, "epi_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.NBNFHHLCMDH_EpiBo = CJAENOMGPDA_ReadInt(d, "epi_bo", 0, ref isInvalid);
						CCBEKGNDDBE.BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(d, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
						CCBEKGNDDBE.INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(d, "show", 0, ref isInvalid);
						CCBEKGNDDBE.MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(d, AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						CCBEKGNDDBE.CCABNCGIHNI_Rslt = CJAENOMGPDA_ReadInt(d, "rslt", 0, ref isInvalid);
						CCBEKGNDDBE.OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(d, "lb", 0, ref isInvalid);
						CCBEKGNDDBE.LIEKIBHAPKC_FId = CJAENOMGPDA_ReadInt(d, "f_id", 0, ref isInvalid);
						CCBEKGNDDBE.PPHEALAJAKD_MiSet = CJAENOMGPDA_ReadInt(d, "mi_set", 0, ref isInvalid);
						CCBEKGNDDBE.KGGPBOEPKCE_PrevSel = CJAENOMGPDA_ReadInt(d, "prev_sel", 0, ref isInvalid) != 0;
						CCBEKGNDDBE.MHKICPIMFEI_PlayCount = CJAENOMGPDA_ReadInt(d, "play_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.PIEBOKFJKKH_RTodayCount = CJAENOMGPDA_ReadInt(d, "r_today_cnt", 0, ref isInvalid);
						CCBEKGNDDBE.OOBBAGJNDIH_LstHpTime = DKMPHAPBDLH_ReadLong(d, "lst_hp_time", 0, ref isInvalid);
						CCBEKGNDDBE.JJMIEHHIKJE_RplQuest = CJAENOMGPDA_ReadInt(d, "rpl_quest", 0, ref isInvalid);
						CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(CCBEKGNDDBE.AKBDBIGGADH_NewFlags, FGCNMLBACGO_ReadString(d, AFEHLCGHAEE_Strings.COJJHFBKGML_new_flag, "", ref isInvalid));
						IBCGPBOGOGP_ReadIntArray(d, AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x18AB18C
							CCBEKGNDDBE.IPNLHCLFIDB(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
						if(d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests))
						{
							EDOHBJAPLPF_JsonData d2 = d[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests];
							int cnt = d2.HNBFOAJIIAL_Count;
							if(cnt > 180)
								cnt = 180;
							for(int j = 0; j < cnt; j++)
							{
								IKCGAJKCPFN ik = CCBEKGNDDBE.NNMPGOAGEOL_Quests[j];
								ik.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(d2[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
								ik.EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(d2[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								ik.HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(d2[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								ik.BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(d2[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
								ik.CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(d2[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x18A488C Offset: 0x18A488C VA: 0x18A488C Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NILOACEHJKJ_EventSP other = GPBJHKLFCEP as NILOACEHJKJ_EventSP;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x18A508C Offset: 0x18A508C VA: 0x18A508C Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NILOACEHJKJ_EventSP other = GPBJHKLFCEP as NILOACEHJKJ_EventSP;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x18A58AC Offset: 0x18A58AC VA: 0x18A58AC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x18AAF08 Offset: 0x18AAF08 VA: 0x18AAF08 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
