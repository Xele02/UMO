
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use OFNLIBDEIFA_EventQuest", true)]
public class OFNLIBDEIFA { }
public class OFNLIBDEIFA_EventQuest : KLFDBFMNLBL_ServerSaveBlock
{
	public class AGFEALDEJOL
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public int OHPLLHANLHO_Crypted; // 0x10
		public int EIDBKDNIPKG_Crypted; // 0x14
		public int ABIOPCGMJKM_Crypted; // 0x18
		public int PMGBDFIPCHM_Crypted; // 0x1C
		public int ADHOKBPLFKO_Crypted; // 0x20
		public int KBIAAFAAGHB_Crypted; // 0x24
		public int LEJDLLOAHEK_Crypted; // 0x28
		public int IOFAOIHPCAO_Crypted; // 0x2C

		public int PBEEPMLJGJC_Cid { get { return OHPLLHANLHO_Crypted ^ ENOBDCFHELD; } set { OHPLLHANLHO_Crypted = value ^ ENOBDCFHELD; ABIOPCGMJKM_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DDB680 JGJMCAHJFFE 0x1DD5930 FJPAJAAPBEN
		public int OLDAGCNLJOI_Prog { get { return EIDBKDNIPKG_Crypted ^ ENOBDCFHELD; } set { EIDBKDNIPKG_Crypted = value ^ ENOBDCFHELD; LEJDLLOAHEK_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DDB690 MGKGIPKJODF 0x1DD594C HGHEAJAMMIA
		public int DELDCIMOBCE_FId { get { return PMGBDFIPCHM_Crypted ^ ENOBDCFHELD; } set { PMGBDFIPCHM_Crypted = value ^ ENOBDCFHELD; ADHOKBPLFKO_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DDB6A0 AJFCCPIKAEM 0x1DD5968 HCNJOOKAEMG
		public int KIFJKGDBDBH_Lucky { get { return KBIAAFAAGHB_Crypted ^ ENOBDCFHELD; } set { KBIAAFAAGHB_Crypted = value ^ ENOBDCFHELD; IOFAOIHPCAO_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DDB6B0 ECABILHPODF 0x1DD5984 FGMMGHEIIDN

		// // RVA: 0x1DD58FC Offset: 0x1DD58FC VA: 0x1DD58FC
		public void LHPDDGIJKNB(int KNEFBLHBDBG)
		{ 
			ENOBDCFHELD = KNEFBLHBDBG;
			FCEJCHGLFGN = ENOBDCFHELD * 0x166;
			PBEEPMLJGJC_Cid = 0;
			OLDAGCNLJOI_Prog = 0;
			DELDCIMOBCE_FId = 0;
			KIFJKGDBDBH_Lucky = 0;
		}

		// // RVA: 0x1DDB6C0 Offset: 0x1DDB6C0 VA: 0x1DDB6C0
		public void ODDIHGPONFL(AGFEALDEJOL GPBJHKLFCEP)
		{
			PBEEPMLJGJC_Cid = GPBJHKLFCEP.PBEEPMLJGJC_Cid;
			OLDAGCNLJOI_Prog = GPBJHKLFCEP.OLDAGCNLJOI_Prog;
			DELDCIMOBCE_FId = GPBJHKLFCEP.DELDCIMOBCE_FId;
			KIFJKGDBDBH_Lucky = GPBJHKLFCEP.KIFJKGDBDBH_Lucky;
		}

		// // RVA: 0x1DDB7A4 Offset: 0x1DDB7A4 VA: 0x1DDB7A4
		public bool AGBOGBEOFME(AGFEALDEJOL OIKJFMGEICL)
		{
			return PBEEPMLJGJC_Cid == OIKJFMGEICL.PBEEPMLJGJC_Cid && 
			OLDAGCNLJOI_Prog == OIKJFMGEICL.OLDAGCNLJOI_Prog && 
			DELDCIMOBCE_FId == OIKJFMGEICL.DELDCIMOBCE_FId && 
			KIFJKGDBDBH_Lucky == OIKJFMGEICL.KIFJKGDBDBH_Lucky;
		}

		// // RVA: 0x1DD3A64 Offset: 0x1DD3A64 VA: 0x1DD3A64
		public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.JBFLEDKDFCO_cid] = PBEEPMLJGJC_Cid;
			res[AFEHLCGHAEE_Strings.KAHOBGNOJDP_prog] = OLDAGCNLJOI_Prog;
			res[AFEHLCGHAEE_Strings.EHDDADDKMFI_f_id] = DELDCIMOBCE_FId;
			res[AFEHLCGHAEE_Strings.KIFJKGDBDBH_lucky] = KIFJKGDBDBH_Lucky;
			return res;
		}
	}

	public class HGCEGAAJFBC
	{
		public List<int> KNIFCANOHOC_Score = new List<int>(); // 0x8
		public List<int> NLKEBAOBJCM_Combo = new List<int>(); // 0xC
		public List<sbyte> LAMCCNAKIOJ_ComboRank = new List<sbyte>(); // 0x10
		public List<int> JNLKJCDFFMM_Clear = new List<int>(); // 0x14
		public int GOIKCKHMBDL_FId; // 0x18

		// // RVA: 0x1DDBA64 Offset: 0x1DDBA64 VA: 0x1DDBA64
		public void LHPDDGIJKNB()
		{
			KNIFCANOHOC_Score.Clear();
			NLKEBAOBJCM_Combo.Clear();
			LAMCCNAKIOJ_ComboRank.Clear();
			JNLKJCDFFMM_Clear.Clear();
			for(int i = 0; i < 5; i++)
			{
				KNIFCANOHOC_Score.Add(0);
				NLKEBAOBJCM_Combo.Add(0);
				LAMCCNAKIOJ_ComboRank.Add(0);
				JNLKJCDFFMM_Clear.Add(0);
			}
			GOIKCKHMBDL_FId = 0;
		}

		// // RVA: 0x1DDBC3C Offset: 0x1DDBC3C VA: 0x1DDBC3C
		public void ODDIHGPONFL(HGCEGAAJFBC GPBJHKLFCEP)
		{
			for(int i = 0; i < 5; i++)
			{
				KNIFCANOHOC_Score[i] = GPBJHKLFCEP.KNIFCANOHOC_Score[i];
				NLKEBAOBJCM_Combo[i] = GPBJHKLFCEP.NLKEBAOBJCM_Combo[i];
				LAMCCNAKIOJ_ComboRank[i] = GPBJHKLFCEP.LAMCCNAKIOJ_ComboRank[i];
				JNLKJCDFFMM_Clear[i] = GPBJHKLFCEP.JNLKJCDFFMM_Clear[i];
			}
			GOIKCKHMBDL_FId = GPBJHKLFCEP.GOIKCKHMBDL_FId;
		}

		// // RVA: 0x1DDBE8C Offset: 0x1DDBE8C VA: 0x1DDBE8C
		public bool AGBOGBEOFME(HGCEGAAJFBC OIKJFMGEICL)
		{
			if(GOIKCKHMBDL_FId != OIKJFMGEICL.GOIKCKHMBDL_FId)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(KNIFCANOHOC_Score[i] != OIKJFMGEICL.KNIFCANOHOC_Score[i])
					return false;
				if(NLKEBAOBJCM_Combo[i] != OIKJFMGEICL.NLKEBAOBJCM_Combo[i])
					return false;
				if(LAMCCNAKIOJ_ComboRank[i] != OIKJFMGEICL.LAMCCNAKIOJ_ComboRank[i])
					return false;
				if(JNLKJCDFFMM_Clear[i] != OIKJFMGEICL.JNLKJCDFFMM_Clear[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1DDC10C Offset: 0x1DDC10C VA: 0x1DDC10C
		// public JDDGGJCGOPA.EHFMCGGNPIJ KJAFPNIFPGP() { }

		// // RVA: 0x1DDC3B0 Offset: 0x1DDC3B0 VA: 0x1DDC3B0
		// public void IOONPJENLOJ(JDDGGJCGOPA.EHFMCGGNPIJ GPBJHKLFCEP) { }

		// // RVA: 0x1DD3D34 Offset: 0x1DD3D34 VA: 0x1DD3D34
		public EDOHBJAPLPF_JsonData OKJPIBHMKMJ()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < 5; i++)
			{
				data.Add(KNIFCANOHOC_Score[i]);
				data2.Add(NLKEBAOBJCM_Combo[i]);
				data3.Add((int)LAMCCNAKIOJ_ComboRank[i]);
				data4.Add(JNLKJCDFFMM_Clear[i]);
			}
			res[AFEHLCGHAEE_Strings.KNIFCANOHOC_score] = data;
			res[AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo] = data2;
			res[AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk] = data3;
			res[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear] = data4;
			res["f_id"] = GOIKCKHMBDL_FId;
			return res;
		}

		// // RVA: 0x1DD59A0 Offset: 0x1DD59A0 VA: 0x1DD59A0
		public void IIEMACPEEBJ(EDOHBJAPLPF_JsonData IDLHJIOMJBK, ref bool NGJDHLGMHMH)
		{
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KNIFCANOHOC_score))
			{
				EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.KNIFCANOHOC_score];
				int cnt = data.HNBFOAJIIAL_Count;
				if(cnt > 0)
				{
					if(cnt >= 6)
					{
						NGJDHLGMHMH = true;
						cnt = 5;
					}
					for(int i = 0; i < cnt; i++)
					{
						KNIFCANOHOC_Score[i] = (int)data[i];
					}
				}
			}
			else
				NGJDHLGMHMH = true;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo))
			{
				EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo];
				int cnt = data.HNBFOAJIIAL_Count;
				if(cnt > 0)
				{
					if(cnt >= 6)
					{
						NGJDHLGMHMH = true;
						cnt = 5;
					}
					for(int i = 0; i < cnt; i++)
					{
						NLKEBAOBJCM_Combo[i] = (int)data[i];
					}
				}
			}
			else
				NGJDHLGMHMH = true;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk))
			{
				EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk];
				int cnt = data.HNBFOAJIIAL_Count;
				if(cnt > 0)
				{
					if(cnt >= 6)
					{
						NGJDHLGMHMH = true;
						cnt = 5;
					}
					for(int i = 0; i < cnt; i++)
					{
						LAMCCNAKIOJ_ComboRank[i] = (sbyte)(int)data[i];
					}
				}
			}
			else
				NGJDHLGMHMH = true;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear))
			{
				EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear];
				int cnt = data.HNBFOAJIIAL_Count;
				if(cnt > 0)
				{
					if(cnt >= 6)
					{
						NGJDHLGMHMH = true;
						cnt = 5;
					}
					for(int i = 0; i < cnt; i++)
					{
						JNLKJCDFFMM_Clear[i] = (int)data[i];
					}
				}
			}
			else
				NGJDHLGMHMH = true;
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("f_id"))
			{
				GOIKCKHMBDL_FId = (int)IDLHJIOMJBK["f_id"];
			}
			else
			{
				GOIKCKHMBDL_FId = 0;
				NGJDHLGMHMH = true;
			}
		}
	}

	public class GCCDGBBDICM
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
		public List<AGFEALDEJOL> HKODBHPMLCP_Cards = new List<AGFEALDEJOL>(); // 0x50
		public int ABNDPBAELND_Crypted; // 0x54
		public int ABCJBCEOKGA_Crypted; // 0x58
		public int AIONCABLDOC_Crypted; // 0x5C
		public int OAACFDNGGDI_Crypted; // 0x60
		public int HJDDHKOMADA_Crypted; // 0x64
		public int LPMDBMGPCFE_Crypted; // 0x68
		public int KEOIOOONAPE_Crypted; // 0x6C
		public int MMNBJIJFOGI_Crypted; // 0x70
		public int JEHBIJBEAMA_Crypted; // 0x74
		public int IHFLDDNELGL_Crypted; // 0x78
		public long BEBJKJKBOGH_Date; // 0x80
		public List<IKCGAJKCPFN> NNMPGOAGEOL_Quests = new List<IKCGAJKCPFN>(); // 0x88
		public List<HGCEGAAJFBC> FFMHJIJBKEN_Musics = new List<HGCEGAAJFBC>(); // 0x8C
		public string MPCAGEPEJJJ_Key; // 0x90
		public long EGBOHDFBAPB_End; // 0x98
		public bool IMFBCJOIJKJ_Entry; // 0xA0
		public bool ABBJBPLHFHA_Spurt; // 0xA1
		public int INLNJOGHLJE_Show; // 0xA4
		public int CCABNCGIHNI_Rslt; // 0xA8
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0xAC

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113/*0x71*/ : 50/*0x32*/); } } //0x1DD3CB0 DCHHABKOMFP 0x1DD5870 EGGIBMLGCOJ
		public long DNBFMLBNAEE_Point { get { return AADPAJOLEEF_Crypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_Crypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_Crypted = value ^ FCEJCHGLFGN; } } //0x1DD3C80 JKHIIAEMMDE 0x1DD5780 PFFKLBLEPKB
		public long NFIOKIBPJCJ_Uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } //0x1DD3C98 NGIDBCKCAMO 0x1DD5804 AEHIIPBDNGE
		public int LGADCGFMLLD_Step { get { return AFGHJEJKDHN_Crypted ^ ENOBDCFHELD; } set { AFGHJEJKDHN_Crypted = value ^ ENOBDCFHELD; FBDJBMDEENG_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3CC4 MAFBDLKFHGJ 0x1DD582C EPEFBOIALDI
		public int BACCOJIDFJE_SelCard { get { return ABNDPBAELND_Crypted ^ ENOBDCFHELD; } set { ABNDPBAELND_Crypted = value ^ ENOBDCFHELD; ABCJBCEOKGA_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3CD4 DBFGLOBHAEH 0x1DD5840 BFFLFKDOFNO
		public int PFKHDMGPGKL_SelDf { get { return AIONCABLDOC_Crypted ^ ENOBDCFHELD; } set { AIONCABLDOC_Crypted = value ^ ENOBDCFHELD; OAACFDNGGDI_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3CE4 BKNGCMPPAAI 0x1DD5858 CIGDNLKIFEM
		public int POENMEGPHCG_Reset { get { return HJDDHKOMADA_Crypted ^ ENOBDCFHELD; } set { HJDDHKOMADA_Crypted = value ^ ENOBDCFHELD; LPMDBMGPCFE_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3CF4 NBIINAFIJEN 0x1DD58A0 FKNEOBLFDIM
		public int JNAHAJFKKCB_EpiCnt { get { return JEHBIJBEAMA_Crypted ^ ENOBDCFHELD; } set { JEHBIJBEAMA_Crypted = value ^ ENOBDCFHELD; IHFLDDNELGL_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3D04 DHIOKCLDFIE 0x1DD58B8 AMKBAJJLMGF
		public int NBNFHHLCMDH_EpiBo { get { return KEOIOOONAPE_Crypted ^ ENOBDCFHELD; } set { KEOIOOONAPE_Crypted = value ^ ENOBDCFHELD; MMNBJIJFOGI_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3D14 LJGJCGBMGPN 0x1DD58D0 CBEODBCPDOJ
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_Crypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_Crypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_Crypted = value ^ FCEJCHGLFGN; } } // 0x1DD3D24 PBEMPHPDDDB 0x1DD58E8 MCADMIEOCCF

		// // RVA: 0x1DDB8D4 Offset: 0x1DDB8D4 VA: 0x1DDB8D4
		public bool BHIAKGKHKGD(int BMBBDIAEOMP)
		{
			return LCDIGDMGPGO_TRcv[BMBBDIAEOMP] != 20;
		}

		// // RVA: 0x1DDB5EC Offset: 0x1DDB5EC VA: 0x1DDB5EC
		public void IPNLHCLFIDB(int BMBBDIAEOMP, bool JKDJCFEBDHC)
		{
			LCDIGDMGPGO_TRcv[BMBBDIAEOMP] = (sbyte)(JKDJCFEBDHC ? 40 : 20);
		}

		// // RVA: 0x1DD2678 Offset: 0x1DD2678 VA: 0x1DD2678
		public void LHPDDGIJKNB()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			EGBOHDFBAPB_End = 0;
			MPCAGEPEJJJ_Key = "";
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			HPLMECLKFID_RRcv = false;
			LGADCGFMLLD_Step = 0;
			INLNJOGHLJE_Show = 0;
			OMCAOJJGOGG_Lb = 0;
			BACCOJIDFJE_SelCard = 0;
			PFKHDMGPGKL_SelDf = 0;
			DNBFMLBNAEE_Point = 0;
			NFIOKIBPJCJ_Uptime = 0;
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv.Add(20);
			}
			NNMPGOAGEOL_Quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB(i + 1, k);
				NNMPGOAGEOL_Quests.Add(ik);
				k *= 13;
			}
			HKODBHPMLCP_Cards.Clear();
			for(int i = 0; i < 15; i++)
			{
				AGFEALDEJOL data = new AGFEALDEJOL();
				data.PBEEPMLJGJC_Cid = 0;
				data.OLDAGCNLJOI_Prog = 0;
				HKODBHPMLCP_Cards.Add(data);
			}
			BEBJKJKBOGH_Date = 0;
			POENMEGPHCG_Reset = 0;
			NBNFHHLCMDH_EpiBo = 0;
			JNAHAJFKKCB_EpiCnt = 0;
			CCABNCGIHNI_Rslt = 0;
			MDADLCOCEBN_SessionId = "";
			FFMHJIJBKEN_Musics.Clear();
			for(int i = 0; i < 10; i++)
			{
				HGCEGAAJFBC data = new HGCEGAAJFBC();
				data.LHPDDGIJKNB();
				FFMHJIJBKEN_Musics.Add(data);
			}
		}

		// // RVA: 0x1DD63E8 Offset: 0x1DD63E8 VA: 0x1DD63E8
		public void ODDIHGPONFL(GCCDGBBDICM GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_End = GPBJHKLFCEP.EGBOHDFBAPB_End;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			DNBFMLBNAEE_Point = GPBJHKLFCEP.DNBFMLBNAEE_Point;
			LGADCGFMLLD_Step = GPBJHKLFCEP.LGADCGFMLLD_Step;
			BACCOJIDFJE_SelCard = GPBJHKLFCEP.BACCOJIDFJE_SelCard;
			PFKHDMGPGKL_SelDf = GPBJHKLFCEP.PFKHDMGPGKL_SelDf;
			POENMEGPHCG_Reset = GPBJHKLFCEP.POENMEGPHCG_Reset;
			JNAHAJFKKCB_EpiCnt = GPBJHKLFCEP.JNAHAJFKKCB_EpiCnt;
			NBNFHHLCMDH_EpiBo = GPBJHKLFCEP.NBNFHHLCMDH_EpiBo;
			BEBJKJKBOGH_Date = GPBJHKLFCEP.BEBJKJKBOGH_Date;
			NFIOKIBPJCJ_Uptime = GPBJHKLFCEP.NFIOKIBPJCJ_Uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_Quests[i].ODDIHGPONFL(GPBJHKLFCEP.NNMPGOAGEOL_Quests[i]);
			}
			for(int i = 0; i < 15; i++)
			{
				HKODBHPMLCP_Cards[i].ODDIHGPONFL(GPBJHKLFCEP.HKODBHPMLCP_Cards[i]);
			}
			for(int i = 0; i < 10; i++)
			{
				FFMHJIJBKEN_Musics[i].ODDIHGPONFL(GPBJHKLFCEP.FFMHJIJBKEN_Musics[i]);
			}
			MDADLCOCEBN_SessionId = GPBJHKLFCEP.MDADLCOCEBN_SessionId;
			CCABNCGIHNI_Rslt = GPBJHKLFCEP.CCABNCGIHNI_Rslt;
		}

		// // RVA: 0x1DD6B9C Offset: 0x1DD6B9C VA: 0x1DD6B9C
		public bool AGBOGBEOFME(GCCDGBBDICM OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_End != OIKJFMGEICL.EGBOHDFBAPB_End)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(DNBFMLBNAEE_Point != OIKJFMGEICL.DNBFMLBNAEE_Point)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(LGADCGFMLLD_Step != OIKJFMGEICL.LGADCGFMLLD_Step)
				return false;
			if(BACCOJIDFJE_SelCard != OIKJFMGEICL.BACCOJIDFJE_SelCard)
				return false;
			if(PFKHDMGPGKL_SelDf != OIKJFMGEICL.PFKHDMGPGKL_SelDf)
				return false;
			if(POENMEGPHCG_Reset != OIKJFMGEICL.POENMEGPHCG_Reset)
				return false;
			if(JNAHAJFKKCB_EpiCnt != OIKJFMGEICL.JNAHAJFKKCB_EpiCnt)
				return false;
			if(NBNFHHLCMDH_EpiBo != OIKJFMGEICL.NBNFHHLCMDH_EpiBo)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(BEBJKJKBOGH_Date != OIKJFMGEICL.BEBJKJKBOGH_Date)
				return false;
			if(NFIOKIBPJCJ_Uptime != OIKJFMGEICL.NFIOKIBPJCJ_Uptime)
				return false;
			if(CCABNCGIHNI_Rslt != OIKJFMGEICL.CCABNCGIHNI_Rslt)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			if(MDADLCOCEBN_SessionId != OIKJFMGEICL.MDADLCOCEBN_SessionId)
				return false;
			for(int i = 0; i < 15; i++)
			{
				if(!HKODBHPMLCP_Cards[i].AGBOGBEOFME(OIKJFMGEICL.HKODBHPMLCP_Cards[i]))
					return false;
			}
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_Quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_Quests[i]))
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(!FFMHJIJBKEN_Musics[i].AGBOGBEOFME(OIKJFMGEICL.FFMHJIJBKEN_Musics[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0x1DD75AC Offset: 0x1DD75AC VA: 0x1DD75AC
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, OFNLIBDEIFA.GCCDGBBDICM OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int BJEPEBMLKOL = 50;
	public const int AJCLDHGLJPD = 3;
	public const int DDCDBOAAOAE = 15;
	public const long EGHFCEBIGEE = 99999999;
	public const int KKBHHBGCNJO = 5;
	public const int DOONPLKIOGD = 10;
	public List<GCCDGBBDICM> FBCJICEPLED = new List<GCCDGBBDICM>(); // 0x24

	public override bool DMICHEJIAJL { get { return true; } } // 0x1DDB5A4 NFKFOODCJJB

	// // RVA: 0x1DD23AC Offset: 0x1DD23AC VA: 0x1DD23AC
	public OFNLIBDEIFA_EventQuest()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x1DD2448 Offset: 0x1DD2448 VA: 0x1DD2448 Slot: 4
	public override void KMBPACJNEOF()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			GCCDGBBDICM data = new GCCDGBBDICM();
			data.LHPDDGIJKNB();
			FBCJICEPLED.Add(data);
		}
	}

	// // RVA: 0x1DD2A84 Offset: 0x1DD2A84 VA: 0x1DD2A84 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < 3; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < FBCJICEPLED[i].LCDIGDMGPGO_TRcv.Count; j++)
			{
				data2.Add(FBCJICEPLED[i].BHIAKGKHKGD(j) ? 1 : 0);
			}
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 50; j++)
			{
				data3.Add(FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 15; j++)
			{
				data3.Add(FBCJICEPLED[i].HKODBHPMLCP_Cards[j].NOJCMGAFAAC());
			}
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			data5[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data5[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_End;
			data5[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data5[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data5[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_Point;
			data5[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_Uptime;
			data5[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv ? 1 : 0;
			data5[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data2;
			data5[AFEHLCGHAEE_Strings.LGADCGFMLLD_step] = FBCJICEPLED[i].LGADCGFMLLD_Step;
			data5[AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card] = FBCJICEPLED[i].BACCOJIDFJE_SelCard;
			data5[AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df] = FBCJICEPLED[i].PFKHDMGPGKL_SelDf;
			data5[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data3;
			data5[AFEHLCGHAEE_Strings.HKODBHPMLCP_cards] = data4;
			data5[AFEHLCGHAEE_Strings.POENMEGPHCG_reset] = FBCJICEPLED[i].POENMEGPHCG_Reset;
			data5["epi_cnt"] = FBCJICEPLED[i].JNAHAJFKKCB_EpiCnt;
			data5["epi_bo"] = FBCJICEPLED[i].NBNFHHLCMDH_EpiBo;
			data5[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = FBCJICEPLED[i].BEBJKJKBOGH_Date;
			data5["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data5[AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id] = FBCJICEPLED[i].MDADLCOCEBN_SessionId;
			data5["rslt"] = FBCJICEPLED[i].CCABNCGIHNI_Rslt;
			data5["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
			data6.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < 10; j++)
			{
				data6.Add(FBCJICEPLED[i].FFMHJIJBKEN_Musics[j].OKJPIBHMKMJ());
			}
			data5["music"] = data6;
			data.Add(data5);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = MCKEOKFMLAH;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1DD4258 Offset: 0x1DD4258 VA: 0x1DD4258 Slot: 6
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
					int cnt = block.HNBFOAJIIAL_Count;
					if(cnt >= 4)
					{
						isInvalid = true;
						cnt = 3;
					}
					for(int i = 0; i < cnt; i++)
					{
						FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_End = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_Point = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_Uptime = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].LGADCGFMLLD_Step = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LGADCGFMLLD_step, 0, ref isInvalid);
						FBCJICEPLED[i].BACCOJIDFJE_SelCard = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.AJACFHJACGK_sel_card, 0, ref isInvalid);
						FBCJICEPLED[i].PFKHDMGPGKL_SelDf = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LOJCJMGPMIG_sel_df, 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].POENMEGPHCG_Reset = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.POENMEGPHCG_reset, 0, ref isInvalid);
						FBCJICEPLED[i].JNAHAJFKKCB_EpiCnt = CJAENOMGPDA_ReadInt(block[i], "epi_cnt", 0, ref isInvalid);
						FBCJICEPLED[i].NBNFHHLCMDH_EpiBo = CJAENOMGPDA_ReadInt(block[i], "epi_bo", 0, ref isInvalid);
						FBCJICEPLED[i].BEBJKJKBOGH_Date = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].MDADLCOCEBN_SessionId = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.MDADLCOCEBN_session_id, "", ref isInvalid);
						FBCJICEPLED[i].CCABNCGIHNI_Rslt = CJAENOMGPDA_ReadInt(block[i], "rslt", 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(block[i], "lb", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
						{
							//0x1DDB5AC
							FBCJICEPLED[i].IPNLHCLFIDB(OIPCCBHIKIA, JBGEEPFKIGG != 0);
						}, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.LEJHEGIMCCL_rmin))
						{
							EDOHBJAPLPF_JsonData data = block[i][AFEHLCGHAEE_Strings.LEJHEGIMCCL_rmin];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 50)
								cnt2 = 50;
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, j + 1, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].EALOBDHOCHP_Stat = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].HMFFHLPNMPH_Count = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].BEBJKJKBOGH_Date = DKMPHAPBDLH_ReadLong(data[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0, ref isInvalid);
								FBCJICEPLED[i].NNMPGOAGEOL_Quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
							}
						}
						if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.HKODBHPMLCP_cards))
						{
							EDOHBJAPLPF_JsonData data = block[i][AFEHLCGHAEE_Strings.HKODBHPMLCP_cards];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 15)
								cnt2 = 15;
							int k = (int)Utility.GetCurrentUnixTime() * 0x309;
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].HKODBHPMLCP_Cards[j].LHPDDGIJKNB(k);
								FBCJICEPLED[i].HKODBHPMLCP_Cards[j].PBEEPMLJGJC_Cid = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.JBFLEDKDFCO_cid, 0, ref isInvalid);
								FBCJICEPLED[i].HKODBHPMLCP_Cards[j].OLDAGCNLJOI_Prog = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.KAHOBGNOJDP_prog, 0, ref isInvalid);
								FBCJICEPLED[i].HKODBHPMLCP_Cards[j].DELDCIMOBCE_FId = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.EHDDADDKMFI_f_id, 0, ref isInvalid);
								FBCJICEPLED[i].HKODBHPMLCP_Cards[j].KIFJKGDBDBH_Lucky = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.KIFJKGDBDBH_lucky, 0, ref isInvalid);
								k += 0x1ea4;
							}
						}
						if(block[i].BBAJPINMOEP_Contains("music"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["music"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 10)
								cnt2 = 10;
							for(int j = 0; j < cnt2; j++)
							{
								FBCJICEPLED[i].FFMHJIJBKEN_Musics[j].IIEMACPEEBJ(data[j], ref isInvalid);
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

	// // RVA: 0x1DD6218 Offset: 0x1DD6218 VA: 0x1DD6218 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OFNLIBDEIFA_EventQuest other = new OFNLIBDEIFA_EventQuest();
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL(other.FBCJICEPLED[i]);
		}
	}

	// // RVA: 0x1DD69BC Offset: 0x1DD69BC VA: 0x1DD69BC Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		OFNLIBDEIFA_EventQuest other = new OFNLIBDEIFA_EventQuest();
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1DD71A0 Offset: 0x1DD71A0 VA: 0x1DD71A0 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH);

	// // RVA: 0x1DDB320 Offset: 0x1DDB320 VA: 0x1DDB320 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
