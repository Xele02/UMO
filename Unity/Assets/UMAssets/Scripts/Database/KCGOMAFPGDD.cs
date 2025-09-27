
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use KCGOMAFPGDD_EventAprilFool", true)]
public class KCGOMAFPGDD { }
public class KCGOMAFPGDD_EventAprilFool : DIHHCBACKGG_DbSection
{
	public class OEHCHEEEBDC
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string OCGFKMHNEOF_name_for_api; // 0x14
		public long BONDDBOFBND_RankingStart; // 0x18
		public long HPNOGLIFJOP_RankingEnd; // 0x20
		public long LNFKGHNHJKE_RankingEnd2; // 0x28
		public long JGMDAOACOJF_RewardStart; // 0x30
		public long IDDBFFBPNGI_RewardEnd; // 0x38
		public long KNLGKBBIBOH_RewardEnd2; // 0x40
		public int KHIKEGLBGAF_RankingRewardScene; // 0x48
		public sbyte POGEFBMBPCB_MonthOdd; // 0x4C
		public sbyte AHKNMANFILO_DayGroup; // 0x4D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x4E
		public int OILIKPOBBGD; // 0x50
		public int AMCPINEGNPG; // 0x54
		public int HBACKHIOIBG; // 0x58
		public int BMKDEHFGHFG; // 0x5C
		public int OFGDLGBFOOA; // 0x60
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x64
		private NNJFKLBPBNK_SecureString NJKIMJAFCPC = new NNJFKLBPBNK_SecureString(); // 0x68
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x6C
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x6D
		public List<int> CAPAPAABKDP_FreeMusic = new List<int>(); // 0x70
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x74

		public string OCDMGOGMHGE { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x1021EE8 HBAAAKFHDBB 0x102138C NHJLJOIPOFK
		public string PJBILOFOCIC { get { return NJKIMJAFCPC.DNJEJEANJGL_Value; } set { NJKIMJAFCPC.DNJEJEANJGL_Value = value; } } //0x1021F14 NOEFEAIFHCL 0x10213C0 GJIJFGNONEL

		//// RVA: 0x102041C Offset: 0x102041C VA: 0x102041C
		public void LHPDDGIJKNB_Reset()
		{
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			OBGBAOLONDD_UniqueId = 0;
			OPFGFINHFCE_name = "";
			HEDAGCNPHGD_RankingName = "";
			OCGFKMHNEOF_name_for_api = "";
			MOEKELIIDEO_SaveIdx = 0;
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			KHIKEGLBGAF_RankingRewardScene = 0;
			OCDMGOGMHGE = "";
			PJBILOFOCIC = "";
			CAPAPAABKDP_FreeMusic.Clear();
			OILIKPOBBGD = 0;
			AMCPINEGNPG = 0;
			HBACKHIOIBG = 0;
			BMKDEHFGHFG = 0;
			OFGDLGBFOOA = 0;
			HKKNEAGCIEB_RankingSupport = 0;
			JHPCPNJJHLI_RankingThreshold.Clear();
		}

		//// RVA: 0x1021A64 Offset: 0x1021A64 VA: 0x1021A64
		//public uint CAOGDCBPBAN() { }
	}

	public class EIEGCBJHGCP
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int MPLGPBNJDJB_FreeMusicId; // 0x10
		public int LGADCGFMLLD_step; // 0x14
		public int MLKFDMFDFCE_enemy_c_skill; // 0x18
		public int DKOPDNHDLIA_enemy_l_skill; // 0x1C
		public long PDBPFJJCADD_open_at; // 0x20
		public long FDBNFFNFOND_close_at; // 0x28

		//// RVA: 0x1021B9C Offset: 0x1021B9C VA: 0x1021B9C
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1021BC0 Offset: 0x1021BC0 VA: 0x1021BC0
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//MPLGPBNJDJB_FreeMusicId = f_music_id
		//LGADCGFMLLD_step = step
		//MLKFDMFDFCE_enemy_c_skill = enemy_c_skill
		//DKOPDNHDLIA_enemy_l_skill = enemy_l_skill
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x10215A0 Offset: 0x10215A0 VA: 0x10215A0
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, OLLJFONKEKO JMHECKKKMLK)
		{
			PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			FDBNFFNFOND_close_at = 0;
			DKOPDNHDLIA_enemy_l_skill = 0;
			PDBPFJJCADD_open_at = 0;
			PLALNIIBLOF_en = 0;
			MPLGPBNJDJB_FreeMusicId = 0;
			LGADCGFMLLD_step = 0;
			MLKFDMFDFCE_enemy_c_skill = 0;

			PPFNGGCBJKC_id = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id;
			PLALNIIBLOF_en = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].PLALNIIBLOF_en;
			MPLGPBNJDJB_FreeMusicId = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].MPLGPBNJDJB_FreeMusicId;
			LGADCGFMLLD_step = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].LGADCGFMLLD_step;
			MLKFDMFDFCE_enemy_c_skill = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].MLKFDMFDFCE_enemy_c_skill;
			DKOPDNHDLIA_enemy_l_skill = (int)JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].DKOPDNHDLIA_enemy_l_skill;
			PDBPFJJCADD_open_at = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].PDBPFJJCADD_open_at;
			FDBNFFNFOND_close_at = JMHECKKKMLK.GHIHAGAOPNC[_PPFNGGCBJKC_id - 1].FDBNFFNFOND_close_at;
		}

		//// RVA: 0x1021E9C Offset: 0x1021E9C VA: 0x1021E9C
		//public uint CAOGDCBPBAN() { }
	}

	public class BMLAHOGDIAK
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public OEHCHEEEBDC NGHKJOEDLIP_Settings = new OEHCHEEEBDC(); // 0x20
	public List<EIEGCBJHGCP> IJJHFGOIDOK_EventMusic = new List<EIEGCBJHGCP>(); // 0x24
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x28
	public List<BMLAHOGDIAK> ADPFKHEMNBL = new List<BMLAHOGDIAK>(); // 0x34
	public List<int> IHKIFGPICLG_HelpIds = new List<int>(); // 0x38

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x2C IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x30 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x101FE9C Offset: 0x101FE9C VA: 0x101FE9C
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if (!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x101FF80 Offset: 0x101FF80 VA: 0x101FF80
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0x1020064 Offset: 0x1020064 VA: 0x1020064
	public KCGOMAFPGDD_EventAprilFool()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 27;
	}

	// RVA: 0x102035C Offset: 0x102035C VA: 0x102035C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0x1020530 Offset: 0x1020530 VA: 0x1020530 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		OLLJFONKEKO reader = OLLJFONKEKO.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF(reader);
		GJEHPJJBCDE(reader);
		CFOFJPLEDEA(reader);
		for (int i = 0; i < reader.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
			v.DNJEJEANJGL_Value = reader.BHGDNGHDDAC[i].JBGEEPFKIGG_val;
			OHJFBLFELNK_m_intParam.Add(reader.BHGDNGHDDAC[i].LJNAKDMILMC_key, v);
		}
		for (int i = 0; i < reader.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString v = new NNJFKLBPBNK_SecureString();
			v.DNJEJEANJGL_Value = reader.MHGMDJNOLMI[i].JBGEEPFKIGG_val;
			FJOEBCMGDMI_m_stringParam.Add(reader.MHGMDJNOLMI[i].LJNAKDMILMC_key, v);
		}
		string s = EFEGBHACJAL_GetStringParam("help_id", "0");
		string[] strs = s.Split(new char[] { ',' });
		IHKIFGPICLG_HelpIds.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			int v = 0;
			if (!int.TryParse(strs[i], out v))
				v = 0;
			IHKIFGPICLG_HelpIds.Add(v);
		}
		//UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName);
		//UnityEngine.Debug.LogError(JIKKNHIAEKG_BlockName);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OCGFKMHNEOF_Key);
		//UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.HBACKHIOIBG);
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			/*TodoLogger.LogError(TodoLogger.Event, "Switch to the real event enable");
			UnityEngine.Debug.LogError("Date : \n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.HPNOGLIFJOP_End1).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.HPNOGLIFJOP_End1).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd).ToShortTimeString() + "\n"
				+ Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2).ToShortDateString() + " " + Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2).ToShortTimeString() + "\n"
			);*/
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;
			for (int i = 0; i < IJJHFGOIDOK_EventMusic.Count; i++)
			{
				//UnityEngine.Debug.LogError("Date2 " + i + " : \n"
				//+ Utility.GetLocalDateTime(IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at).ToShortDateString() + " " + Utility.GetLocalDateTime(IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at).ToShortTimeString() + "\n"
				//+ Utility.GetLocalDateTime(IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at).ToShortDateString() + " " + Utility.GetLocalDateTime(IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at).ToShortTimeString() + "\n"
				//);
				if (IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0) IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at != 0) IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
			for (int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
			{
				//UnityEngine.Debug.LogError("Date3 " + i + " : \n"
				//+ Utility.GetLocalDateTime(NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt).ToShortDateString() + " " + Utility.GetLocalDateTime(NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt).ToShortTimeString() + "\n"
				//+ Utility.GetLocalDateTime(NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt).ToShortDateString() + " " + Utility.GetLocalDateTime(NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt).ToShortTimeString() + "\n"
				//);
				if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}
		return true;
	}

	// RVA: 0x1021384 Offset: 0x1021384 VA: 0x1021384 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0x1020994 Offset: 0x1020994 VA: 0x1020994
	private bool DGKKMKLCEDF(OLLJFONKEKO JMHECKKKMLK)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = JMHECKKKMLK.HMBHNLCFDIH.HEDAGCNPHGD_RankingName;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = JMHECKKKMLK.HMBHNLCFDIH.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)JMHECKKKMLK.HMBHNLCFDIH.KHIKEGLBGAF_RankingRewardScene;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OILIKPOBBGD = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.OILIKPOBBGD;
		NGHKJOEDLIP_Settings.AMCPINEGNPG = JMHECKKKMLK.HMBHNLCFDIH.AMCPINEGNPG;
		NGHKJOEDLIP_Settings.HBACKHIOIBG = JMHECKKKMLK.HMBHNLCFDIH.AGGLDFOKCLJ;
		NGHKJOEDLIP_Settings.BMKDEHFGHFG = JMHECKKKMLK.HMBHNLCFDIH.EODIMCFIMMP;
		NGHKJOEDLIP_Settings.OFGDLGBFOOA = JMHECKKKMLK.HMBHNLCFDIH.GLFPABNKHHA;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.PJBILOFOCIC = JMHECKKKMLK.HMBHNLCFDIH.PJBILOFOCIC;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKPNPNOAMO_ExtreamOpen;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.HKKNEAGCIEB_RankingSupport;
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.CAPAPAABKDP_FreeMusic, JMHECKKKMLK.HMBHNLCFDIH.KOHMHBGOFFI_free_music);
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold.Length; i++)
		{
			if(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI_RankingThreshold[i]);
			}
		}
		return true;
	}

	//// RVA: 0x1021590 Offset: 0x1021590 VA: 0x1021590
	//private bool DGKKMKLCEDF(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x10210D0 Offset: 0x10210D0 VA: 0x10210D0
	private bool GJEHPJJBCDE(OLLJFONKEKO JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.GHIHAGAOPNC.Length; i++)
		{
			EIEGCBJHGCP data = new EIEGCBJHGCP();
			data.KHEKNNFCAOI_Init(i + 1, JMHECKKKMLK);
			IJJHFGOIDOK_EventMusic.Add(data);
		}
		return true;
	}

	//// RVA: 0x102176C Offset: 0x102176C VA: 0x102176C
	//private bool GJEHPJJBCDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x10211EC Offset: 0x10211EC VA: 0x10211EC
	private bool CFOFJPLEDEA(OLLJFONKEKO JMHECKKKMLK)
	{
		long time = Utility.GetCurrentUnixTime();
		int key = (int)time * 11 + 1;
		for(int i = 0; i < JMHECKKKMLK.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, key, JMHECKKKMLK);
			NNMPGOAGEOL_quests.Add(data);
			key += 13;
		}
		return true;
	}

	//// RVA: 0x1021774 Offset: 0x1021774 VA: 0x1021774
	//private bool CFOFJPLEDEA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x102177C Offset: 0x102177C VA: 0x102177C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x10213F4 Offset: 0x10213F4 VA: 0x10213F4
	private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM)
	{
		string[] strs = OAIBJJHGCNM.Split(new char[] { ',' });
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			if (!string.IsNullOrEmpty(strs[i]))
			{
				NNDGIAEFMOG.Add(int.Parse(strs[i]));
			}
		}
	}

	// RVA: 0x102195C Offset: 0x102195C VA: 0x102195C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KCGOMAFPGDD_EventAprilFool.CAOGDCBPBAN");
		return 0;
	}
}
