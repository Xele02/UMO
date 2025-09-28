
using System.Collections.Generic;
using XeApp.Game.Menu;
using XeSys;

public class LGMEPLIJLNB
{
	public MFDJIFIIPJD GOOIIPFHOIG; // 0x8
	public int LGADCGFMLLD_step; // 0xC
	public int CCDPNBJMKDI_StartPoint; // 0x10
	public int DNBFMLBNAEE_point; // 0x14
	public int OJELCGDDAOM_MissingPoint; // 0x18
	public bool HMEOAKCLKJE_IsReceived; // 0x1C

	//public bool EGKODECGHNM { get; }

	//// RVA: 0x17F4BC8 Offset: 0x17F4BC8 VA: 0x17F4BC8
	//public bool DGCPCNOFLHP() { }

	//// RVA: 0x17F4BDC Offset: 0x17F4BDC VA: 0x17F4BDC
	public static List<LGMEPLIJLNB> FKDIMODKKJD_GetList(int _KELFCMEOPPM_EpisodeId)
	{
		List<LGMEPLIJLNB> res = new List<LGMEPLIJLNB>();
        HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
        OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
		FMLIFJBPFNA_Step f = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) => {
			//0x17F58C0
			return _GHPLINIACBB_x.IOFHEGJPHKG_StepId == NDFIEMPPMLF_master.IOFHEGJPHKG_StepId;
		});
		int startPoint = 0;
		for(int i = 0; i < NDFIEMPPMLF_master.FGOGPCMHPIN_Count; i++)
		{
            short FCEJJEPFIPH_rwid = NDFIEMPPMLF_master.HHJGBJCIFON_Rewards[i];
			JNIKPOIKFAC_Reward r = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward _GHPLINIACBB_x) => {
				//0x17F590C
				return FCEJJEPFIPH_rwid == _GHPLINIACBB_x.EIHOBHDKCDB_RewardId;
			});
			LGMEPLIJLNB data = new LGMEPLIJLNB();
			data.GOOIIPFHOIG = new MFDJIFIIPJD();
			data.GOOIIPFHOIG.KHEKNNFCAOI_Init(r.KIJAPOFAGPN_ItemId, r.JDLJPNMLFID_ItemCount);
			data.CCDPNBJMKDI_StartPoint = startPoint;
			data.DNBFMLBNAEE_point = f.JENFHJDFFAD_Pt[i];
			startPoint = data.DNBFMLBNAEE_point;
			int c = data.DNBFMLBNAEE_point - saveEp.OGDBKJKIGAJ_CurrentPoint;
			if(c < 1)
				c = 0;
			data.OJELCGDDAOM_MissingPoint = c;
			data.HMEOAKCLKJE_IsReceived = saveEp.MCIHDIBHHBI_IsRewardReceived(i);
			res.Add(data);
        }
		return res;
    }

	//// RVA: 0x17F5250 Offset: 0x17F5250 VA: 0x17F5250
	public static LGMEPLIJLNB BMFKMFNPGPC(int _KELFCMEOPPM_EpisodeId, bool MPCFDBHLOGM)
	{
		if(_KELFCMEOPPM_EpisodeId != 0)
		{
			HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
			FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
			{
				//0x17F5944
				return _GHPLINIACBB_x.IOFHEGJPHKG_StepId == NDFIEMPPMLF_master.IOFHEGJPHKG_StepId;
			});
			int a = 1;
			if (MPCFDBHLOGM)
				a = 2;
			a = NDFIEMPPMLF_master.FGOGPCMHPIN_Count - a;
			int pt = 0;
			for(int i = 0; i < NDFIEMPPMLF_master.FGOGPCMHPIN_Count; i++)
			{
				int rewardId = NDFIEMPPMLF_master.HHJGBJCIFON_Rewards[i];
				JNIKPOIKFAC_Reward reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward _GHPLINIACBB_x) =>
				{
					//0x17F5990
					return rewardId == _GHPLINIACBB_x.EIHOBHDKCDB_RewardId;
				});
				if(a == i)
				{
					LGMEPLIJLNB l = new LGMEPLIJLNB();
					l.GOOIIPFHOIG = new MFDJIFIIPJD();
					l.GOOIIPFHOIG.KHEKNNFCAOI_Init(reward.KIJAPOFAGPN_ItemId, reward.JDLJPNMLFID_ItemCount);
					l.CCDPNBJMKDI_StartPoint = pt;
					l.DNBFMLBNAEE_point = step.JENFHJDFFAD_Pt[a];
					l.OJELCGDDAOM_MissingPoint = 0;
					if (pt - saveInfo.OGDBKJKIGAJ_CurrentPoint > 0)
						l.OJELCGDDAOM_MissingPoint = pt - saveInfo.OGDBKJKIGAJ_CurrentPoint;
					l.HMEOAKCLKJE_IsReceived = saveInfo.MCIHDIBHHBI_IsRewardReceived(a);
					return l;
				}
				pt = step.JENFHJDFFAD_Pt[i];
			}
		}
		return null;
	}
}

public class PIGBBNDPPJC
{
	public string OPFGFINHFCE_name; // 0x8
	public string KLMPFGOCBHC_description; // 0xC
	public int KELFCMEOPPM_EpisodeId; // 0x10
	public int EAHPLCJMPHD_PId; // 0x14
	public bool CADENLBDAEB_IsNew; // 0x18
	public int FKMAEKNOLJB_EpisodeNo; // 0x1C
	public int FGOGPCMHPIN_Count; // 0x20
	public int JJJNKGBCFMI_CurrentStep; // 0x24
	public int ABLHIAEDJAI_CurrentValue; // 0x28
	public int DMHDNKILKGI_MaxPoint; // 0x2C
	public int LEGAKDFPPHA_AvaiablePoint; // 0x30
	public int KIJAPOFAGPN_ItemId; // 0x34
	public bool CCBKMCLDGAD_HasReward; // 0x38
	public bool JBCIDDKDJMM; // 0x39
	public long BEBJKJKBOGH_date; // 0x40
	public LGMEPLIJLNB JBFLCHFEIGL; // 0x48

	//public bool OJOLGGKILFL { get; } 0x16D0300 KKEOAGANMNA
	public bool DKMLDEDKPBA_IsEnabled { get { return KELFCMEOPPM_EpisodeId > 0; } } //0x16D0314 PCIINKJELKK
	public bool IIEAILCOPDB { get { return DMHDNKILKGI_MaxPoint <= LEGAKDFPPHA_AvaiablePoint; } } //0x16D0328 EMKGOLJAJBG

	//// RVA: 0x16D0340 Offset: 0x16D0340 VA: 0x16D0340
	public void LEHDLBJJBNC_SetNotNew()
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1].LHMOAJAIJCO_is_new = false;
	}

	//// RVA: 0x16D0470 Offset: 0x16D0470 VA: 0x16D0470
	public void KHEKNNFCAOI_Init(int _KELFCMEOPPM_EpisodeId)
	{
		this.KELFCMEOPPM_EpisodeId = _KELFCMEOPPM_EpisodeId;
		if(_KELFCMEOPPM_EpisodeId == 0)
		{
			ABLHIAEDJAI_CurrentValue = 0;
			DMHDNKILKGI_MaxPoint = 0;
			LEGAKDFPPHA_AvaiablePoint = 0;
			KIJAPOFAGPN_ItemId = 0;
			FKMAEKNOLJB_EpisodeNo = 0;
			FGOGPCMHPIN_Count = 0;
			JJJNKGBCFMI_CurrentStep = 0;
			OPFGFINHFCE_name = "";
			KLMPFGOCBHC_description = "";
			EAHPLCJMPHD_PId = 0;
			CADENLBDAEB_IsNew = false;
			BEBJKJKBOGH_date = 0;
			JBFLCHFEIGL = null;
			JBCIDDKDJMM = false;
		}
		else
		{
			HMGPODKEFBA_EpisodeInfo NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo serverEpInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
			ABLHIAEDJAI_CurrentValue = serverEpInfo.OGDBKJKIGAJ_CurrentPoint;
			JJJNKGBCFMI_CurrentStep = serverEpInfo.EBIIIAELNAA_Step;
			BEBJKJKBOGH_date = serverEpInfo.BEBJKJKBOGH_date;
			FGOGPCMHPIN_Count = NDFIEMPPMLF_master.FGOGPCMHPIN_Count;
			FKMAEKNOLJB_EpisodeNo = NDFIEMPPMLF_master.EILKGEADKGH_Order;
			CADENLBDAEB_IsNew = serverEpInfo.LHMOAJAIJCO_is_new;
			OPFGFINHFCE_name = EJOJNFDHDHN_GetName(_KELFCMEOPPM_EpisodeId);
			KLMPFGOCBHC_description = FKKHNDDGKJB_GetEpDesc(_KELFCMEOPPM_EpisodeId);
			JBFLCHFEIGL = new LGMEPLIJLNB();
			if(JJJNKGBCFMI_CurrentStep < FGOGPCMHPIN_Count)
			{
				short EIHOBHDKCDB_RewardId = NDFIEMPPMLF_master.HHJGBJCIFON_Rewards[JJJNKGBCFMI_CurrentStep];
				FMLIFJBPFNA_Step st = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
				{
					//0x16D369C
					return NDFIEMPPMLF_master.IOFHEGJPHKG_StepId == _GHPLINIACBB_x.IOFHEGJPHKG_StepId;
				});
				JNIKPOIKFAC_Reward rw = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward _GHPLINIACBB_x) =>
				{
					//0x16D3734
					return EIHOBHDKCDB_RewardId == _GHPLINIACBB_x.EIHOBHDKCDB_RewardId;
				});
				if(st != null && rw != null)
				{
					JBFLCHFEIGL = new LGMEPLIJLNB();
					JBFLCHFEIGL.GOOIIPFHOIG = new MFDJIFIIPJD();
					JBFLCHFEIGL.GOOIIPFHOIG.KHEKNNFCAOI_Init(rw.KIJAPOFAGPN_ItemId, rw.JDLJPNMLFID_ItemCount);
					JBFLCHFEIGL.DNBFMLBNAEE_point = st.JENFHJDFFAD_Pt[JJJNKGBCFMI_CurrentStep];
					JBFLCHFEIGL.OJELCGDDAOM_MissingPoint = JBFLCHFEIGL.DNBFMLBNAEE_point - ABLHIAEDJAI_CurrentValue;
					if (JBFLCHFEIGL.OJELCGDDAOM_MissingPoint < 0)
						JBFLCHFEIGL.OJELCGDDAOM_MissingPoint = 0;
					JBFLCHFEIGL.HMEOAKCLKJE_IsReceived = serverEpInfo.MCIHDIBHHBI_IsRewardReceived(JJJNKGBCFMI_CurrentStep);
				}
			}
			int cosItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume, 0);
			int valkItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PFIOMNHDHCO_6_Valkyrie, 0);
			int homeBgItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HGDPIAFBCGA_HomeBg, 0);
			foreach (var GKJBHCKCKIA in NDFIEMPPMLF_master.HHJGBJCIFON_Rewards)
			{
				JNIKPOIKFAC_Reward rw = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward _GHPLINIACBB_x) =>
				{
					//0x16D376C
					return GKJBHCKCKIA == _GHPLINIACBB_x.EIHOBHDKCDB_RewardId;
				});
				if((rw.KIJAPOFAGPN_ItemId >= cosItemId && rw.KIJAPOFAGPN_ItemId < cosItemId + 10000) ||
					(rw.KIJAPOFAGPN_ItemId >= valkItemId && rw.KIJAPOFAGPN_ItemId < valkItemId + 10000) ||
					(rw.KIJAPOFAGPN_ItemId >= homeBgItemId && rw.KIJAPOFAGPN_ItemId < homeBgItemId + 10000))
				{
					KIJAPOFAGPN_ItemId = rw.KIJAPOFAGPN_ItemId;
				}
			}
			FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
			{
				//0x16D36E8
				return NDFIEMPPMLF_master.IOFHEGJPHKG_StepId == _GHPLINIACBB_x.IOFHEGJPHKG_StepId;
			});
			DMHDNKILKGI_MaxPoint = step.JENFHJDFFAD_Pt[FGOGPCMHPIN_Count - 2];
			CCBKMCLDGAD_HasReward = true;
			for(int i = 0; i < FGOGPCMHPIN_Count - 1; i++)
			{
				if(!serverEpInfo.MCIHDIBHHBI_IsRewardReceived(i))
				{
					CCBKMCLDGAD_HasReward = false;
				}
			}
			if(_KELFCMEOPPM_EpisodeId > 0)
			{
				LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(_KELFCMEOPPM_EpisodeId);
			}
			JBCIDDKDJMM = FIBLGPNEKEM(_KELFCMEOPPM_EpisodeId);
		}
	}

	//// RVA: 0x16D18D4 Offset: 0x16D18D4 VA: 0x16D18D4
	public void FBANBDCOEJL_Update()
	{
		if(KELFCMEOPPM_EpisodeId > 0)
		{
			HMGPODKEFBA_EpisodeInfo epInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEpInfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1];
			ABLHIAEDJAI_CurrentValue = saveEpInfo.OGDBKJKIGAJ_CurrentPoint;
			JJJNKGBCFMI_CurrentStep = saveEpInfo.EBIIIAELNAA_Step;
			BEBJKJKBOGH_date = saveEpInfo.BEBJKJKBOGH_date;
			FGOGPCMHPIN_Count = epInfo.FGOGPCMHPIN_Count;
			FKMAEKNOLJB_EpisodeNo = epInfo.EILKGEADKGH_Order;
			CADENLBDAEB_IsNew = saveEpInfo.LHMOAJAIJCO_is_new;
			JBFLCHFEIGL = new LGMEPLIJLNB();
			if(JJJNKGBCFMI_CurrentStep < FGOGPCMHPIN_Count)
			{
				int EIHOBHDKCDB_RewardId = epInfo.HHJGBJCIFON_Rewards[JJJNKGBCFMI_CurrentStep];
				FMLIFJBPFNA_Step step = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
				{
					//0x16D37A4
					return _GHPLINIACBB_x.IOFHEGJPHKG_StepId == epInfo.IOFHEGJPHKG_StepId;
				});
				JNIKPOIKFAC_Reward reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards.Find((JNIKPOIKFAC_Reward _GHPLINIACBB_x) =>
				{
					//0x16D383C
					return EIHOBHDKCDB_RewardId == _GHPLINIACBB_x.EIHOBHDKCDB_RewardId;
				});
				if(step != null && reward != null)
				{
					LGMEPLIJLNB data = new LGMEPLIJLNB();
					data.GOOIIPFHOIG = new MFDJIFIIPJD();
					data.GOOIIPFHOIG.KHEKNNFCAOI_Init(reward.KIJAPOFAGPN_ItemId, reward.JDLJPNMLFID_ItemCount);
					data.DNBFMLBNAEE_point = step.JENFHJDFFAD_Pt[JJJNKGBCFMI_CurrentStep];
					data.OJELCGDDAOM_MissingPoint = data.DNBFMLBNAEE_point - ABLHIAEDJAI_CurrentValue;
					data.HMEOAKCLKJE_IsReceived = saveEpInfo.MCIHDIBHHBI_IsRewardReceived(JJJNKGBCFMI_CurrentStep);
					JBFLCHFEIGL = data;
				}
			}
			FMLIFJBPFNA_Step step2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps.Find((FMLIFJBPFNA_Step _GHPLINIACBB_x) =>
			{
				//0x16D37F0
				return _GHPLINIACBB_x.IOFHEGJPHKG_StepId == epInfo.IOFHEGJPHKG_StepId;
			});
			DMHDNKILKGI_MaxPoint = step2.JENFHJDFFAD_Pt[epInfo.FGOGPCMHPIN_Count - 2];
			CCBKMCLDGAD_HasReward = true;
			for(int i = 0; i < FGOGPCMHPIN_Count - 1; i++)
			{
				if (!saveEpInfo.MCIHDIBHHBI_IsRewardReceived(i))
					CCBKMCLDGAD_HasReward = false;
			}
			if(KELFCMEOPPM_EpisodeId > 0)
			{
				LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(KELFCMEOPPM_EpisodeId);
			}
			JBCIDDKDJMM = FIBLGPNEKEM(KELFCMEOPPM_EpisodeId);
		}
	}

	//// RVA: 0x16D11AC Offset: 0x16D11AC VA: 0x16D11AC
	public void AFGOBPPKFBF()
	{
		if (KELFCMEOPPM_EpisodeId < 1)
			return;
		LEGAKDFPPHA_AvaiablePoint = GMDHJBGLBEI(KELFCMEOPPM_EpisodeId);
	}

	//// RVA: 0x16D2190 Offset: 0x16D2190 VA: 0x16D2190
	public static List<PIGBBNDPPJC> FKDIMODKKJD_GetList(bool DHFLBNAHGDF/* = false*/)
	{
		List<PIGBBNDPPJC> res = new List<PIGBBNDPPJC>(500);
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList.Count; i++)
		{
			HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[i];
			OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[i];
			if(dbEp.PPEGAKEIEGM_Enabled == 2)
			{
				if(!DHFLBNAHGDF)
				{
					if (saveEp.BEBJKJKBOGH_date == 0)
						continue;
				}
				PIGBBNDPPJC data = new PIGBBNDPPJC();
				data.KHEKNNFCAOI_Init(i + 1);
				res.Add(data);
			}
		}
		CEAIGKOGLIN(res);
		return res;
	}

	//// RVA: 0x16D24CC Offset: 0x16D24CC VA: 0x16D24CC
	public static void CEAIGKOGLIN(List<PIGBBNDPPJC> NNDGIAEFMOG)
	{
		NNDGIAEFMOG.Sort((PIGBBNDPPJC _HKICMNAACDA_a, PIGBBNDPPJC _BNKHBCBJBKI_b) =>
		{
			//0x16D365C
			return _HKICMNAACDA_a.FKMAEKNOLJB_EpisodeNo - _BNKHBCBJBKI_b.FKMAEKNOLJB_EpisodeNo;
		});
	}

	//// RVA: 0x16D2620 Offset: 0x16D2620 VA: 0x16D2620
	public int HADPDBAGEIB(int BNGHLLCONJM, int _HMFFHLPNMPH_count)
	{
		OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo info = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1];
		if(info.HPLMMKHBKIG_Id == KELFCMEOPPM_EpisodeId)
		{
			KIICLPJJBNL_EpiItem.NKGPGMOHAFM info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA_table[BNGHLLCONJM - 1];
			EGOLBAPFHHD_Common.AMCANGCIBEG info3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GJODJNIHKKF_epi_item[BNGHLLCONJM - 1];
			if(_HMFFHLPNMPH_count != 0 && BNGHLLCONJM == info2.PPFNGGCBJKC_id)
			{
				return _HMFFHLPNMPH_count <= info3.BFINGCJHOHI_cnt ? 1 : 0;
			}
		}
		return -1;
	}

	//// RVA: 0x16D2950 Offset: 0x16D2950 VA: 0x16D2950
	public int PFMLAOPEAMJ(int BNGHLLCONJM, int _HMFFHLPNMPH_count, IMCBBOAFION _BHFHGFKBOHH_OnSuccess)
	{
		int res = HADPDBAGEIB(BNGHLLCONJM, _HMFFHLPNMPH_count);
		if (res > 0)
		{
			FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
			if(f == null)
			{
				JDDGPJDKHNE.HHCJCDFCLOB.BGDOBGFECOB();
				OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo ep = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[KELFCMEOPPM_EpisodeId - 1];
				KIICLPJJBNL_EpiItem.NKGPGMOHAFM info2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGGMILDEEF_EpiItem.CDENCMNHNGA_table[BNGHLLCONJM - 1];
				EGOLBAPFHHD_Common.AMCANGCIBEG info3 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GJODJNIHKKF_epi_item[BNGHLLCONJM - 1];
				info3.BFINGCJHOHI_cnt -= _HMFFHLPNMPH_count;
				if(info3.BFINGCJHOHI_cnt < 0)
					info3.BFINGCJHOHI_cnt = 0;
				int a = ep.OGDBKJKIGAJ_CurrentPoint;
				ep.MOACIBEKLEN(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode, _HMFFHLPNMPH_count * info2.JBGEEPFKIGG_val, false);
				int a2 = ep.OGDBKJKIGAJ_CurrentPoint;
				ILCCJNDFFOB.HHCJCDFCLOB.BBDKHAMANCB_Episode(KELFCMEOPPM_EpisodeId, a, a2, ep.EBIIIAELNAA_Step, JpStringLiterals.StringLiteral_13085, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, BNGHLLCONJM), _HMFFHLPNMPH_count);
			}
			MenuScene.SaveWithAchievement(2, () =>
			{
				//0x16D3874
				_BHFHGFKBOHH_OnSuccess();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			}, null);
			return 1;
		}
		return res;
	}

	//// RVA: 0x16D20E4 Offset: 0x16D20E4 VA: 0x16D20E4
	private int GMDHJBGLBEI(int _KELFCMEOPPM_EpisodeId)
	{
		return GMDHJBGLBEI(_KELFCMEOPPM_EpisodeId, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
	}

	//// RVA: 0x16D11D0 Offset: 0x16D11D0 VA: 0x16D11D0
	private bool FIBLGPNEKEM(int _KELFCMEOPPM_EpisodeId)
	{
		for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count; i++)
		{
			MMPBPOIFDAF_Scene.PMKOFEIONEG serverScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i];
			if (serverScene.IHIAFIHAAPO_Unlocked)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[serverScene.PPFNGGCBJKC_id - 1];
				if (dbScene.KELFCMEOPPM_EpisodeId == _KELFCMEOPPM_EpisodeId)
				{
					if(dbScene.MCCIFLKCNKO_Feed)
					{
						if(GCIJNCFDNON_SceneInfo.CGJCEHGFHMA(serverScene.PPFNGGCBJKC_id) <
							GCIJNCFDNON_SceneInfo.JLNGOOGHCNA(serverScene.PPFNGGCBJKC_id, dbScene.EKLIPGELKCL_Rarity, serverScene.JPIPENJGGDD_NumBoard > 0, serverScene.JPIPENJGGDD_NumBoard))
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	//// RVA: 0x16D2FD4 Offset: 0x16D2FD4 VA: 0x16D2FD4
	public static int GMDHJBGLBEI(int _KELFCMEOPPM_EpisodeId, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo saveEp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[_KELFCMEOPPM_EpisodeId - 1];
		MLIBEPGADJH_Scene sceneDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
		List<MMPBPOIFDAF_Scene.PMKOFEIONEG> sceneList = _AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes;
		int l30 = 0;
		int l2c = 0;
		for(int i = 0; i < sceneList.Count; i++)
		{
			MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = sceneList[i];
			if(saveScene.IHIAFIHAAPO_Unlocked)
			{
				if(sceneDb.CDENCMNHNGA_table[saveScene.PPFNGGCBJKC_id - 1].KELFCMEOPPM_EpisodeId == _KELFCMEOPPM_EpisodeId)
				{
					int rar = sceneDb.CDENCMNHNGA_table[saveScene.PPFNGGCBJKC_id - 1].EKLIPGELKCL_Rarity;
					l30 += GCIJNCFDNON_SceneInfo.JLNGOOGHCNA(saveScene.PPFNGGCBJKC_id, rar, saveScene.JPIPENJGGDD_NumBoard > 0, saveScene.JPIPENJGGDD_NumBoard);
					l2c += GCIJNCFDNON_SceneInfo.CGJCEHGFHMA(saveScene.PPFNGGCBJKC_id);
				}
			}
		}
		return l30 - l2c + saveEp.OGDBKJKIGAJ_CurrentPoint;
	}

	//// RVA: 0x16D0FEC Offset: 0x16D0FEC VA: 0x16D0FEC
	public static string EJOJNFDHDHN_GetName(int _KELFCMEOPPM_EpisodeId)
	{
		return MessageManager.Instance.GetMessage("master", "ep_nm_" + _KELFCMEOPPM_EpisodeId.ToString("D4"));
	}

	//// RVA: 0x16D10C4 Offset: 0x16D10C4 VA: 0x16D10C4
	public static string FKKHNDDGKJB_GetEpDesc(int _KELFCMEOPPM_EpisodeId)
	{
		return MessageManager.Instance.GetMessage("master", "ep_dsc_" + _KELFCMEOPPM_EpisodeId.ToString("D4"));
	}
}
