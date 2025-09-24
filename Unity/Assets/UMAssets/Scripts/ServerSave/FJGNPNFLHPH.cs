
using System.Collections.Generic;
using XeApp.Game.Menu;
using XeSys;

[System.Obsolete("Use FJGNPNFLHPH_EventCollection", true)]
public class FJGNPNFLHPH { }
public class FJGNPNFLHPH_EventCollection : KLFDBFMNLBL_ServerSaveBlock
{
	public class JIALCLGJPKL
	{
		public int ENOBDCFHELD; // 0x8
		public int FCEJCHGLFGN; // 0xC
		public long AADPAJOLEEF_PointCrypted; // 0x10
		public long IOJOBGHPLIE_PointCrypted; // 0x18
		public long NBOLDNMPJFG_scoreCrypted; // 0x20
		public long FONGFOAMHJK_ScoreCrypted2; // 0x28
		public long DLEEMCAPOBP_Crypted; // 0x30
		public long JPNMMOEPAEM_Crypted; // 0x38
		public int FOEHHBMNGNK_TicketCrypted; // 0x40
		public int DGFLFPAMNJO_TicketCrypted; // 0x44
		public sbyte MLLPMIHMMFL_Crypted; // 0x48
		public sbyte PCHFOEIJJMM_Crypted; // 0x49
		public int HFIHMDILNFD_LbCrypted; // 0x4C
		public int IGMFFIKLEHP_LbCrypted2; // 0x50
		public sbyte JBOCIADFMEA_Crypted; // 0x54
		public sbyte PICDFKNKFLG_Crypted; // 0x55
		public List<IKCGAJKCPFN> NNMPGOAGEOL_quests = new List<IKCGAJKCPFN>(50); // 0x58
		public string MPCAGEPEJJJ_Key; // 0x5C
		public long EGBOHDFBAPB_closed_at; // 0x60
		public bool IMFBCJOIJKJ_Entry; // 0x68
		public bool ABBJBPLHFHA_Spurt; // 0x69
		public int INLNJOGHLJE_Show; // 0x6C
		public List<sbyte> LCDIGDMGPGO_TRcv = new List<sbyte>(); // 0x70

		public bool HPLMECLKFID_RRcv { get { return MLLPMIHMMFL_Crypted == 113; } set { MLLPMIHMMFL_Crypted = (sbyte)(value ? 113 : 50); } } // 0x14EAE54 DCHHABKOMFP 0x14EBE30 EGGIBMLGCOJ
		public bool CIIBINABMPE_RRcv2 { get { return PCHFOEIJJMM_Crypted == 65; } set { PCHFOEIJJMM_Crypted = (sbyte)(value ? 65 : 126); } } // 0x14EAE68 GOIFOCEJNAB 0x14EBE60 PHOFJDEOLAF
		public bool OKEJGGCMAAI_PlaRcv { get { return JBOCIADFMEA_Crypted == 80; } set { JBOCIADFMEA_Crypted = (sbyte)(value ? 80 : 145); } } // 0x14EAE7C CLGCKBAEJHF 0x14EBE90 AHFMKDDCFAM
		public bool CGMMMJCIDFE_EpaRcv { get { return PICDFKNKFLG_Crypted == 98; } set { PICDFKNKFLG_Crypted = (sbyte)(value ? 98 : 66); } } // 0x14EAE90 AIBENAPCPJI 0x14EBEC0 FKKHHKCJEII
		public long DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; AADPAJOLEEF_PointCrypted = value ^ ENOBDCFHELD; IOJOBGHPLIE_PointCrypted = value ^ FCEJCHGLFGN; } } // 0x14EADEC JKHIIAEMMDE 0x14EBCCC PFFKLBLEPKB
		public long KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ ENOBDCFHELD; } set { value = value >= 100000000 ? 99999999 : value; NBOLDNMPJFG_scoreCrypted = value ^ ENOBDCFHELD; FONGFOAMHJK_ScoreCrypted2 = value ^ FCEJCHGLFGN; } } // 0x14EAE04 EOJEPLIPOMJ 0x14EBD50 AEEMBPAEAAI
		public long NFIOKIBPJCJ_uptime { get { return DLEEMCAPOBP_Crypted ^ ENOBDCFHELD; } set { DLEEMCAPOBP_Crypted = value ^ ENOBDCFHELD; JPNMMOEPAEM_Crypted = value ^ FCEJCHGLFGN; } } // 0x14EAE2C NGIDBCKCAMO 0x14EBE08 AEHIIPBDNGE
		public int KCGJGPOFOCD_ticket { get { return FOEHHBMNGNK_TicketCrypted ^ ENOBDCFHELD; } set { value = value < 1 ? 0 : value; value = value >= 9999 ? 9999 : value; FOEHHBMNGNK_TicketCrypted = value ^ ENOBDCFHELD; DGFLFPAMNJO_TicketCrypted = value ^ FCEJCHGLFGN; } } // 0x14EAE1C CKFBDDKHAJO 0x14EBDD4 IPOBANBJJHB
		public int OMCAOJJGOGG_Lb { get { return HFIHMDILNFD_LbCrypted ^ ENOBDCFHELD; } set { HFIHMDILNFD_LbCrypted = value ^ ENOBDCFHELD; IGMFFIKLEHP_LbCrypted2 = value ^ FCEJCHGLFGN; } } // 0x14EAE44 PBEMPHPDDDB 0x14EBEF0 MCADMIEOCCF

		// // RVA: 0x14F0200 Offset: 0x14F0200 VA: 0x14F0200
		// public bool AAIKMLIKIEB(int LHJCOPMMIGO) { }

		// // RVA: 0x14F023C Offset: 0x14F023C VA: 0x14F023C
		public void LHAEPPFACOB_SetRewardReceived(bool _OAFPGJLCNFM_cond, int LHJCOPMMIGO)
		{
			if(LHJCOPMMIGO == 1)
			{
				CIIBINABMPE_RRcv2 = _OAFPGJLCNFM_cond;
			}
			else if(LHJCOPMMIGO == 0)
			{
				HPLMECLKFID_RRcv = _OAFPGJLCNFM_cond;
			}
		}

		// // RVA: 0x14F02A0 Offset: 0x14F02A0 VA: 0x14F02A0
		public bool BHIAKGKHKGD(int _BMBBDIAEOMP_i)
		{
			return LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] != 20;
		}

		// // RVA: 0x14F016C Offset: 0x14F016C VA: 0x14F016C
		public void IPNLHCLFIDB(int _BMBBDIAEOMP_i, bool _JKDJCFEBDHC_Enabled)
		{
			LCDIGDMGPGO_TRcv[_BMBBDIAEOMP_i] = (sbyte)(_JKDJCFEBDHC_Enabled ? 40 : 20);
		}

		// // RVA: 0x14E9D8C Offset: 0x14E9D8C VA: 0x14E9D8C
		public void LHPDDGIJKNB_Reset()
		{
			ENOBDCFHELD = (int)Utility.GetCurrentUnixTime();
			FCEJCHGLFGN = ENOBDCFHELD ^ 0x7411141;
			MPCAGEPEJJJ_Key = "";
			EGBOHDFBAPB_closed_at = 0;
			IMFBCJOIJKJ_Entry = false;
			ABBJBPLHFHA_Spurt = false;
			OKEJGGCMAAI_PlaRcv = false;
			HPLMECLKFID_RRcv = false;
			CIIBINABMPE_RRcv2 = false;
			CGMMMJCIDFE_EpaRcv = false;
			INLNJOGHLJE_Show = 0;
			OMCAOJJGOGG_Lb = 0;
			DNBFMLBNAEE_point = 0;
			KNIFCANOHOC_score = 0;
			NFIOKIBPJCJ_uptime = 0;
			KCGJGPOFOCD_ticket = 0;
			LCDIGDMGPGO_TRcv.Clear();
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv.Add(20);
			}
			NNMPGOAGEOL_quests.Clear();
			int k = ENOBDCFHELD + 5;
			for(int i = 0; i < 50; i++)
			{
				IKCGAJKCPFN ik = new IKCGAJKCPFN();
				ik.LHPDDGIJKNB_Reset(i + 1, k);
				NNMPGOAGEOL_quests.Add(ik);
				k *= 13;
			}
		}

		// // RVA: 0x14EC0F0 Offset: 0x14EC0F0 VA: 0x14EC0F0
		public void ODDIHGPONFL_Copy(JIALCLGJPKL GPBJHKLFCEP)
		{
			MPCAGEPEJJJ_Key = GPBJHKLFCEP.MPCAGEPEJJJ_Key;
			EGBOHDFBAPB_closed_at = GPBJHKLFCEP.EGBOHDFBAPB_closed_at;
			IMFBCJOIJKJ_Entry = GPBJHKLFCEP.IMFBCJOIJKJ_Entry;
			ABBJBPLHFHA_Spurt = GPBJHKLFCEP.ABBJBPLHFHA_Spurt;
			HPLMECLKFID_RRcv = GPBJHKLFCEP.HPLMECLKFID_RRcv;
			CIIBINABMPE_RRcv2 = GPBJHKLFCEP.CIIBINABMPE_RRcv2;
			OKEJGGCMAAI_PlaRcv = GPBJHKLFCEP.OKEJGGCMAAI_PlaRcv;
			CGMMMJCIDFE_EpaRcv = GPBJHKLFCEP.CGMMMJCIDFE_EpaRcv;
			DNBFMLBNAEE_point = GPBJHKLFCEP.DNBFMLBNAEE_point;
			KNIFCANOHOC_score = GPBJHKLFCEP.KNIFCANOHOC_score;
			KCGJGPOFOCD_ticket = GPBJHKLFCEP.KCGJGPOFOCD_ticket;
			OMCAOJJGOGG_Lb = GPBJHKLFCEP.OMCAOJJGOGG_Lb;
			NFIOKIBPJCJ_uptime = GPBJHKLFCEP.NFIOKIBPJCJ_uptime;
			INLNJOGHLJE_Show = GPBJHKLFCEP.INLNJOGHLJE_Show;
			for(int i = 0; i < 100; i++)
			{
				LCDIGDMGPGO_TRcv[i] = GPBJHKLFCEP.LCDIGDMGPGO_TRcv[i];
			}
			for(int i = 0; i < 50; i++)
			{
				NNMPGOAGEOL_quests[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.NNMPGOAGEOL_quests[i]);
			}
		}

		// // RVA: 0x14EC7A0 Offset: 0x14EC7A0 VA: 0x14EC7A0
		public bool AGBOGBEOFME(JIALCLGJPKL OIKJFMGEICL)
		{
			if(EGBOHDFBAPB_closed_at != OIKJFMGEICL.EGBOHDFBAPB_closed_at)
				return false;
			if(CIIBINABMPE_RRcv2 != OIKJFMGEICL.CIIBINABMPE_RRcv2)
				return false;
			if(HPLMECLKFID_RRcv != OIKJFMGEICL.HPLMECLKFID_RRcv)
				return false;
			if(OKEJGGCMAAI_PlaRcv != OIKJFMGEICL.OKEJGGCMAAI_PlaRcv)
				return false;
			if(ABBJBPLHFHA_Spurt != OIKJFMGEICL.ABBJBPLHFHA_Spurt)
				return false;
			if(IMFBCJOIJKJ_Entry != OIKJFMGEICL.IMFBCJOIJKJ_Entry)
				return false;
			if(CGMMMJCIDFE_EpaRcv != OIKJFMGEICL.CGMMMJCIDFE_EpaRcv)
				return false;
			if(DNBFMLBNAEE_point != OIKJFMGEICL.DNBFMLBNAEE_point)
				return false;
			if(KNIFCANOHOC_score != OIKJFMGEICL.KNIFCANOHOC_score)
				return false;
			if(KCGJGPOFOCD_ticket != OIKJFMGEICL.KCGJGPOFOCD_ticket)
				return false;
			if(OMCAOJJGOGG_Lb != OIKJFMGEICL.OMCAOJJGOGG_Lb)
				return false;
			if(LCDIGDMGPGO_TRcv.Count != OIKJFMGEICL.LCDIGDMGPGO_TRcv.Count)
				return false;
			if(INLNJOGHLJE_Show != OIKJFMGEICL.INLNJOGHLJE_Show)
				return false;
			if(NFIOKIBPJCJ_uptime != OIKJFMGEICL.NFIOKIBPJCJ_uptime)
				return false;
			if(MPCAGEPEJJJ_Key != OIKJFMGEICL.MPCAGEPEJJJ_Key)
				return false;
			for(int i = 0; i < 100; i++)
			{
				if(LCDIGDMGPGO_TRcv[i] != OIKJFMGEICL.LCDIGDMGPGO_TRcv[i])
					return false;
			}
			for(int i = 0; i < 50; i++)
			{
				if(!NNMPGOAGEOL_quests[i].AGBOGBEOFME(OIKJFMGEICL.NNMPGOAGEOL_quests[i]))
					return false;
			}
			return true;
		}

		// // RVA: 0x14ED278 Offset: 0x14ED278 VA: 0x14ED278
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, FJGNPNFLHPH.JIALCLGJPKL _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int IIPMADOHGAD = 100;
	public const int ICHFGGBPCBJ = 3;
	public const int BJEPEBMLKOL = 50;
	public const long EGHFCEBIGEE = 99999999;
	public const long FIDFLGIOIMA = 99999999;
	public const int HLFODAFJJPK = 9999;
	public long AFNJCFEKFDD_Dirty; // 0x28
	public List<JIALCLGJPKL> FBCJICEPLED = new List<JIALCLGJPKL>(); // 0x30
	public List<IKCGAJKCPFN> NNMPGOAGEOL = new List<IKCGAJKCPFN>(); // 0x34

	public override bool DMICHEJIAJL { get { return true; } } // 0x14F0124 NFKFOODCJJB

	// // RVA: 0x14E9B00 Offset: 0x14E9B00 VA: 0x14E9B00
	public FJGNPNFLHPH_EventCollection()
	{
		LHPDDGIJKNB_Reset();
	}

	// // RVA: 0x14E9BD4 Offset: 0x14E9BD4 VA: 0x14E9BD4 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		FBCJICEPLED.Clear();
		for(int i = 0; i < 3; i++)
		{
			JIALCLGJPKL data = new JIALCLGJPKL();
			data.LHPDDGIJKNB_Reset();
			FBCJICEPLED.Add(data);
		}
		AFNJCFEKFDD_Dirty = 0;
	}

	// // RVA: 0x14EA048 Offset: 0x14EA048 VA: 0x14EA048 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
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
				data3.Add(FBCJICEPLED[i].NNMPGOAGEOL_quests[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = FBCJICEPLED[i].MPCAGEPEJJJ_Key;
			data4[AFEHLCGHAEE_Strings.KOMKKBDABJP_end] = FBCJICEPLED[i].EGBOHDFBAPB_closed_at;
			data4[AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry] = FBCJICEPLED[i].IMFBCJOIJKJ_Entry ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt] = FBCJICEPLED[i].ABBJBPLHFHA_Spurt ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.DNBFMLBNAEE_point] = FBCJICEPLED[i].DNBFMLBNAEE_point;
			data4[AFEHLCGHAEE_Strings.KNIFCANOHOC_score] = FBCJICEPLED[i].KNIFCANOHOC_score;
			data4[AFEHLCGHAEE_Strings.KCGJGPOFOCD_ticket] = FBCJICEPLED[i].KCGJGPOFOCD_ticket;
			data4[AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime] = FBCJICEPLED[i].NFIOKIBPJCJ_uptime;
			data4["show"] = FBCJICEPLED[i].INLNJOGHLJE_Show;
			data4["lb"] = FBCJICEPLED[i].OMCAOJJGOGG_Lb;
			data4[AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv] = FBCJICEPLED[i].HPLMECLKFID_RRcv ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv] = data2;
			data4["r_rcv2"] = FBCJICEPLED[i].CIIBINABMPE_RRcv2 ? 1 : 0;
			data4[AFEHLCGHAEE_Strings.NNMPGOAGEOL_quests] = data3;
			data4["pla_rcv"] = FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv ? 1 : 0;
			data4["epa_rcv"] = FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv ? 1 : 0;
			data.Add(data4);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData tmp = new EDOHBJAPLPF_JsonData();
			tmp[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			tmp[JIKKNHIAEKG_BlockName] = data;
			tmp[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			tmp["dirty"] = AFNJCFEKFDD_Dirty;
			data = tmp;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x14EAEA4 Offset: 0x14EAEA4 VA: 0x14EAEA4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 1);
		if (!blockMissing)
		{
			AFNJCFEKFDD_Dirty = DKMPHAPBDLH_ReadLong(OILEIIEIBHP, "dirty", 0, ref isInvalid);
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
						FBCJICEPLED[i].MPCAGEPEJJJ_Key = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.LJNAKDMILMC_key, "", ref isInvalid);
						FBCJICEPLED[i].EGBOHDFBAPB_closed_at = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KOMKKBDABJP_end, 0, ref isInvalid);
						FBCJICEPLED[i].IMFBCJOIJKJ_Entry = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.CDMGDFLPPHN_entry, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].ABBJBPLHFHA_Spurt = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.MAFAIIHJAFG_spurt, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].DNBFMLBNAEE_point = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.DNBFMLBNAEE_point, 0, ref isInvalid);
						FBCJICEPLED[i].KNIFCANOHOC_score = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.KNIFCANOHOC_score, 0, ref isInvalid);
						FBCJICEPLED[i].KCGJGPOFOCD_ticket = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.KCGJGPOFOCD_ticket, 0, ref isInvalid);
						FBCJICEPLED[i].NFIOKIBPJCJ_uptime = DKMPHAPBDLH_ReadLong(block[i], AFEHLCGHAEE_Strings.NFIOKIBPJCJ_uptime, 0, ref isInvalid);
						FBCJICEPLED[i].HPLMECLKFID_RRcv = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.LDALACBKEJN_r_rcv, 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CIIBINABMPE_RRcv2 = CJAENOMGPDA_ReadInt(block[i], "r_rcv2", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].OKEJGGCMAAI_PlaRcv = CJAENOMGPDA_ReadInt(block[i], "pla_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].CGMMMJCIDFE_EpaRcv = CJAENOMGPDA_ReadInt(block[i], "epa_rcv", 0, ref isInvalid) != 0;
						FBCJICEPLED[i].INLNJOGHLJE_Show = CJAENOMGPDA_ReadInt(block[i], "show", 0, ref isInvalid);
						FBCJICEPLED[i].OMCAOJJGOGG_Lb = CJAENOMGPDA_ReadInt(block[i], "lb", 0, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(block[i], AFEHLCGHAEE_Strings.CJCJBKIMLOB_t_rcv, 0, 100, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
						{
							//0x14F012C
							FBCJICEPLED[i].IPNLHCLFIDB(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val != 0);
						}, ref isInvalid);
						if(block[i].BBAJPINMOEP_Contains("quests"))
						{
							EDOHBJAPLPF_JsonData data = block[i]["quests"];
							int cnt2 = data.HNBFOAJIIAL_Count;
							if(cnt2 > 0)
							{
								if(cnt2 >= 51)
								{
									cnt2 = 50;
									isInvalid = true;
								}
								for(int j = 0; j < cnt2; j++)
								{
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, j + 1, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].EALOBDHOCHP_stat = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].HMFFHLPNMPH_count = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.HMFFHLPNMPH_count, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].BEBJKJKBOGH_date = DKMPHAPBDLH_ReadLong(data[j], AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
									FBCJICEPLED[i].NNMPGOAGEOL_quests[j].CADENLBDAEB_IsNew = CJAENOMGPDA_ReadInt(data[j], AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) == 1;
								}
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

	// // RVA: 0x14EBF08 Offset: 0x14EBF08 VA: 0x14EBF08 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FJGNPNFLHPH_EventCollection other = GPBJHKLFCEP as FJGNPNFLHPH_EventCollection;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			FBCJICEPLED[i].ODDIHGPONFL_Copy(other.FBCJICEPLED[i]);
		}
		AFNJCFEKFDD_Dirty = other.AFNJCFEKFDD_Dirty;
	}

	// // RVA: 0x14EC594 Offset: 0x14EC594 VA: 0x14EC594 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FJGNPNFLHPH_EventCollection other = GPBJHKLFCEP as FJGNPNFLHPH_EventCollection;
		for(int i = 0; i < FBCJICEPLED.Count; i++)
		{
			if(!FBCJICEPLED[i].AGBOGBEOFME(other.FBCJICEPLED[i]))
				return false;
		}
		if(AFNJCFEKFDD_Dirty != other.AFNJCFEKFDD_Dirty)
			return false;
		return true;
	}

	// // RVA: 0x14ECDF0 Offset: 0x14ECDF0 VA: 0x14ECDF0 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x14EFE80 Offset: 0x14EFE80 VA: 0x14EFE80 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
