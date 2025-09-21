
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HIHJGPDLNDN_EventScore", true)]
public class HIHJGPDLNDN { }
public class HIHJGPDLNDN_EventScore : DIHHCBACKGG_DbSection
{
	public class DKGDLFPELAB
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
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x50
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x54
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x55
		public List<int> CAPAPAABKDP_FreeMusic = new List<int>(); // 0x58
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x5C

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x18373A0 HBAAAKFHDBB 0x1836DF4 NHJLJOIPOFK

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
		public int PPFNGGCBJKC_id; // 0x8
		public int KFCIJBLDHOK_v1; // 0xC
		public int JLEIHOEGMOP_v2; // 0x10
	}

	public DKGDLFPELAB NGHKJOEDLIP_Settings = new DKGDLFPELAB(); // 0x20
	public List<AAAPPIKNOKB> ADPFKHEMNBL = new List<AAAPPIKNOKB>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_String { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_IntArray { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x18358DC Offset: 0x18358DC VA: 0x18358DC
	public string EFEGBHACJAL(string _LJNAKDMILMC_key, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI_String.ContainsKey(_LJNAKDMILMC_key))
			return FJOEBCMGDMI_String[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	//// RVA: 0x18359C0 Offset: 0x18359C0 VA: 0x18359C0
	public int LPJLEHAJADA(string _LJNAKDMILMC_key, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK_IntArray.ContainsKey(_LJNAKDMILMC_key))
			return OHJFBLFELNK_IntArray[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	// RVA: 0x1835AA4 Offset: 0x1835AA4 VA: 0x1835AA4
	public HIHJGPDLNDN_EventScore()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_IntArray = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_String = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 41;
	}

	// RVA: 0x1835CE8 Offset: 0x1835CE8 VA: 0x1835CE8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		OHJFBLFELNK_IntArray.Clear();
		FJOEBCMGDMI_String.Clear();
	}

	// RVA: 0x1835E9C Offset: 0x1835E9C VA: 0x1835E9C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		PMPDPNDJBLB data = PMPDPNDJBLB.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		DGKKMKLCEDF_DeserializeSetting(data);
		for(int i = 0; i < data.BHGDNGHDDAC.Length; i++)
		{
			CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
			d.DNJEJEANJGL_Value = data.BHGDNGHDDAC[i].JBGEEPFKIGG;
			OHJFBLFELNK_IntArray.Add(data.BHGDNGHDDAC[i].LJNAKDMILMC, d);
		}
		for(int i = 0; i < data.MHGMDJNOLMI.Length; i++)
		{
			NNJFKLBPBNK_SecureString d = new NNJFKLBPBNK_SecureString();
			d.DNJEJEANJGL_Value = data.MHGMDJNOLMI[i].JBGEEPFKIGG;
			FJOEBCMGDMI_String.Add(data.MHGMDJNOLMI[i].LJNAKDMILMC, d);
		}

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Settings.OPFGFINHFCE_name+" "+NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
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
		}

		return true;
	}

	// RVA: 0x1836754 Offset: 0x1836754 VA: 0x1836754 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "HIHJGPDLNDN_EventScore.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1836170 Offset: 0x1836170 VA: 0x1836170
	private bool DGKKMKLCEDF_DeserializeSetting(PMPDPNDJBLB JMHECKKKMLK)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = JMHECKKKMLK.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = JMHECKKKMLK.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP_Settings.KHIKEGLBGAF_RankingRewardScene = (int)JMHECKKKMLK.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.HKKNEAGCIEB;
		EEEKPHDPJHG(NGHKJOEDLIP_Settings.CAPAPAABKDP_FreeMusic, JMHECKKKMLK.HMBHNLCFDIH.KOHMHBGOFFI);
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		return true;
	}

	//// RVA: 0x18367DC Offset: 0x18367DC VA: 0x18367DC
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF _IDLHJIOMJBK_Data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x1836FC4 Offset: 0x1836FC4 VA: 0x1836FC4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

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
