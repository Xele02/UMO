
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HIHJGPDLNDN_EventScore", true)]
public class HIHJGPDLNDN { }
[UMOClass(ReaderClass = "PMPDPNDJBLB")]
public class HIHJGPDLNDN_EventScore : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "HNGLACEEHKJ")]
	public class DKGDLFPELAB
	{
		[UMOMember(ReaderMember = "OBGBAOLONDD", Desc = "Event unique id")]
		public int OBGBAOLONDD_UniqueId; // 0x8
		[UMOMember(ReaderMember = "OPFGFINHFCE", Desc = "Name of the event")]
		public string OPFGFINHFCE_name; // 0xC
		[UMOMember(ReaderMember = "HEDAGCNPHGD", Desc = "Unused")]
		public string HEDAGCNPHGD_RankingName; // 0x10
		[UMOMember(ReaderMember = "OCGFKMHNEOF", Desc = "Ranking id")]
		public string OCGFKMHNEOF_name_for_api; // 0x14
		[UMOMember(ReaderMember = "BONDDBOFBND", ReaderDisplay = "Date", Display = "Date")]
		public long BONDDBOFBND_RankingStart; // 0x18
		[UMOMember(ReaderMember = "HPNOGLIFJOP", ReaderDisplay = "Date", Display = "Date")]
		public long HPNOGLIFJOP_RankingEnd; // 0x20
		[UMOMember(ReaderMember = "LNFKGHNHJKE", ReaderDisplay = "Date", Display = "Date")]
		public long LNFKGHNHJKE_RankingEnd2; // 0x28
		[UMOMember(ReaderMember = "JGMDAOACOJF", ReaderDisplay = "Date", Display = "Date")]
		public long JGMDAOACOJF_RewardStart; // 0x30
		[UMOMember(ReaderMember = "IDDBFFBPNGI", ReaderDisplay = "Date", Display = "Date")]
		public long IDDBFFBPNGI_RewardEnd; // 0x38
		[UMOMember(ReaderMember = "KNLGKBBIBOH", ReaderDisplay = "Date", Display = "Date")]
		public long KNLGKBBIBOH_RewardEnd2; // 0x40
		[UMOMember(ReaderMember = "KHIKEGLBGAF", Desc = "Unused")]
		public int KHIKEGLBGAF_RankingRewardScene; // 0x48
		[UMOMember(ReaderMember = "JMJDLDEIFKE", Desc = "Unused")]
		public sbyte POGEFBMBPCB_MonthOdd; // 0x4C
		[UMOMember(ReaderMember = "AHKNMANFILO", Desc = "Unused")]
		public sbyte AHKNMANFILO_DayGroup; // 0x4D
		[UMOMember(ReaderMember = "MOEKELIIDEO", Desc = "Index in the player save (3 slot inoriginal game)")]
		public sbyte MOEKELIIDEO_SaveIdx; // 0x4E
		[UMOMember(ReaderMember = "OCDMGOGMHGE", CryptedInMemory = true, Desc = "Prefix id for gift box reward")]
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x50
		[UMOMember(ReaderMember = "AHKPNPNOAMO", Desc = "Allow the extreme difficulty")]
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x54
		[UMOMember(ReaderMember = "HKKNEAGCIEB", Desc = "True if it has ranking")]
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x55
		[UMOMember(ReaderMember = "KOHMHBGOFFI", ReaderDisplay = "ListString|,", Desc = "List of event songs")]
		public List<int> CAPAPAABKDP_FreeMusic = new List<int>(); // 0x58
		[UMOMember(ReaderMember = "JHPCPNJJHLI", Desc = "List of ranking threshold for the popup filter")]
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x5C

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x18373A0 HBAAAKFHDBB_get_KeyPrefix 0x1836DF4 NHJLJOIPOFK_set_KeyPrefix

		//// RVA: 0x1835DA8 Offset: 0x1835DA8 VA: 0x1835DA8
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
			OCDMGOGMHGE_KeyPrefix = "";
			CAPAPAABKDP_FreeMusic.Clear();
			JHPCPNJJHLI_RankingThreshold.Clear();
			HKKNEAGCIEB_RankingSupport = 0;
		}

		//// RVA: 0x18371D4 Offset: 0x18371D4 VA: 0x18371D4
		//public uint CAOGDCBPBAN() { }
	}

	public class AAAPPIKNOKB
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC")]
		public int PPFNGGCBJKC_id; // 0x8
		[UMOMember(ReaderMember = "KFCIJBLDHOK")]
		public int KFCIJBLDHOK_v1; // 0xC
		[UMOMember(ReaderMember = "JLEIHOEGMOP")]
		public int JLEIHOEGMOP_v2; // 0x10
	}

	[UMOMember(ReaderMember = "HMBHNLCFDIH")]
	public DKGDLFPELAB NGHKJOEDLIP_Settings = new DKGDLFPELAB(); // 0x20
	[UMOMember(ReaderMember = "KIEKMCKCMGD", Desc = "Unused and unread")]
	public List<AAAPPIKNOKB> ADPFKHEMNBL = new List<AAAPPIKNOKB>(); // 0x2C

	[UMOMember(ReaderMember = "MHGMDJNOLMI/[IDX]/LJNAKDMILMC|MHGMDJNOLMI/[IDX]/JBGEEPFKIGG", CryptedInMemory = true, Name = "String Params")]
	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	[UMOMember(ReaderMember = "BHGDNGHDDAC/[IDX]/LJNAKDMILMC|BHGDNGHDDAC/[IDX]/JBGEEPFKIGG", CryptedInMemory = true, Name = "Int Params")]
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	//// RVA: 0x18358DC Offset: 0x18358DC VA: 0x18358DC
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x18359C0 Offset: 0x18359C0 VA: 0x18359C0
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x1835AA4 Offset: 0x1835AA4 VA: 0x1835AA4
	public HIHJGPDLNDN_EventScore()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 41;
	}

	// RVA: 0x1835CE8 Offset: 0x1835CE8 VA: 0x1835CE8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0x1835E9C Offset: 0x1835E9C VA: 0x1835E9C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		PMPDPNDJBLB data = PMPDPNDJBLB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG_val;
			OHJFBLFELNK_m_intParam.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC_key, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG_val;
			FJOEBCMGDMI_m_stringParam.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC_key, d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		// Update dates
		/*UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
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
		}*/

		return true;
	}

	// RVA: 0x1836754 Offset: 0x1836754 VA: 0x1836754 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//NGHKJOEDLIP_Settings = setting
		TodoLogger.LogError(TodoLogger.DbJson, "HIHJGPDLNDN_EventScore.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x1836170 Offset: 0x1836170 VA: 0x1836170
	private bool DGKKMKLCEDF_DeserializeSetting(PMPDPNDJBLB JMHECKKKMLK)
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
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE_KeyPrefix;
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

	//// RVA: 0x18367DC Offset: 0x18367DC VA: 0x18367DC
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }
	//OBGBAOLONDD_UniqueId = unique_id
	//OPFGFINHFCE_name = OPFGFINHFCE_name
	//HEDAGCNPHGD_RankingName = ranking_name
	//OCGFKMHNEOF_name_for_api = OCGFKMHNEOF_name_for_api
	//BONDDBOFBND_RankingStart = ranking_start
	//HPNOGLIFJOP_RankingEnd = ranking_end
	//LNFKGHNHJKE_RankingEnd2 = ranking_end2
	//JGMDAOACOJF_RewardStart = reward_start
	//IDDBFFBPNGI_RewardEnd = reward_end
	//KNLGKBBIBOH_RewardEnd2 = reward_end2
	//KHIKEGLBGAF_RankingRewardScene = ranking_reward_scene
	//POGEFBMBPCB_MonthOdd = month_odd
	//AHKNMANFILO_DayGroup = day_group
	//MOEKELIIDEO_SaveIdx = save_slot
	//OCDMGOGMHGE_KeyPrefix = key_prefix
	//AHKPNPNOAMO_ExtreamOpen = extream_open
	//HKKNEAGCIEB_RankingSupport = ranking_support
	//CAPAPAABKDP_FreeMusic = free_music
	//JHPCPNJJHLI_RankingThreshold = ranking_threshold

	//// RVA: 0x1836FC4 Offset: 0x1836FC4 VA: 0x1836FC4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x1836E28 Offset: 0x1836E28 VA: 0x1836E28
	private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM)
	{
		string[] strs = OAIBJJHGCNM.Split(new char[]{','});
		NNDGIAEFMOG.Clear();
		for(int i = 0; i < strs.Length; i++)
		{
			if(!string.IsNullOrEmpty(strs[i]))
			{
				NNDGIAEFMOG.Add(int.Parse(strs[i]));
			}
		}
	}

	// RVA: 0x18371A4 Offset: 0x18371A4 VA: 0x18371A4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HIHJGPDLNDN_EventScore.CAOGDCBPBAN");
		return 0;
	}

	//[CompilerGeneratedAttribute] // RVA: 0x6C0400 Offset: 0x6C0400 VA: 0x6C0400
	//// RVA: 0x1837304 Offset: 0x1837304 VA: 0x1837304
	//private void <DeserializeSetting>b__19_0(int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) { }
}
