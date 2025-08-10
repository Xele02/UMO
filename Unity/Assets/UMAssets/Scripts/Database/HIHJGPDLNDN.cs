
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HIHJGPDLNDN_EventScore", true)]
public class HIHJGPDLNDN { }
public class HIHJGPDLNDN_EventScore : DIHHCBACKGG_DbSection
{
	public class DKGDLFPELAB
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_Name; // 0xC
		public string HEDAGCNPHGD_RankingName; // 0x10
		public string OCGFKMHNEOF_NameForApi; // 0x14
		public long BONDDBOFBND_RankingStart; // 0x18
		public long HPNOGLIFJOP_RankingEnd; // 0x20
		public long LNFKGHNHJKE_RankingEnd2; // 0x28
		public long JGMDAOACOJF_RewardStart; // 0x30
		public long IDDBFFBPNGI_RewardEnd; // 0x38
		public long KNLGKBBIBOH_RewardEnd2; // 0x40
		public int KHIKEGLBGAF_RankingRewardScene; // 0x48
		public sbyte POGEFBMBPCB_MonthOdd; // 0x4C
		public sbyte AHKNMANFILO_DayGroup; // 0x4D
		public sbyte MOEKELIIDEO_SaveSlot; // 0x4E
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x50
		public sbyte AHKPNPNOAMO_ExtreamOpen; // 0x54
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x55
		public List<int> CAPAPAABKDP_FreeMusic = new List<int>(); // 0x58
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x5C

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x18373A0 HBAAAKFHDBB 0x1836DF4 NHJLJOIPOFK

		//// RVA: 0x1835DA8 Offset: 0x1835DA8 VA: 0x1835DA8
		public void LHPDDGIJKNB()
		{
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			OBGBAOLONDD_UniqueId = 0;
			OPFGFINHFCE_Name = "";
			HEDAGCNPHGD_RankingName = "";
			OCGFKMHNEOF_NameForApi = "";
			MOEKELIIDEO_SaveSlot = 0;
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
		public int PPFNGGCBJKC; // 0x8
		public int KFCIJBLDHOK; // 0xC
		public int JLEIHOEGMOP; // 0x10
	}

	public DKGDLFPELAB NGHKJOEDLIP_Setting = new DKGDLFPELAB(); // 0x20
	public List<AAAPPIKNOKB> ADPFKHEMNBL = new List<AAAPPIKNOKB>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x18358DC Offset: 0x18358DC VA: 0x18358DC
	public string EFEGBHACJAL(string LJNAKDMILMC, string KKMJBMKHGNH)
	{
		if(FJOEBCMGDMI.ContainsKey(LJNAKDMILMC))
			return FJOEBCMGDMI[LJNAKDMILMC].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	//// RVA: 0x18359C0 Offset: 0x18359C0 VA: 0x18359C0
	public int LPJLEHAJADA(string LJNAKDMILMC, int KKMJBMKHGNH)
	{
		if(OHJFBLFELNK.ContainsKey(LJNAKDMILMC))
			return OHJFBLFELNK[LJNAKDMILMC].DNJEJEANJGL_Value;
		return KKMJBMKHGNH;
	}

	// RVA: 0x1835AA4 Offset: 0x1835AA4 VA: 0x1835AA4
	public HIHJGPDLNDN_EventScore()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 41;
	}

	// RVA: 0x1835CE8 Offset: 0x1835CE8 VA: 0x1835CE8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		NGHKJOEDLIP_Setting.LHPDDGIJKNB();
		OHJFBLFELNK.Clear();
		FJOEBCMGDMI.Clear();
	}

	// RVA: 0x1835E9C Offset: 0x1835E9C VA: 0x1835E9C Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		PMPDPNDJBLB data = PMPDPNDJBLB.HEGEKFMJNCC(DBBGALAPFGC);
		DGKKMKLCEDF_DeserializeSetting(data);
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

		UnityEngine.Debug.LogError(NGHKJOEDLIP_Setting.OPFGFINHFCE_Name+" "+NGHKJOEDLIP_Setting.OBGBAOLONDD_UniqueId);

		// Update dates
		UMOEventList.EventData CurrenEvent = UMOEventList.GetCurrentEvent();
		if (CurrenEvent != null && CurrenEvent.EnableBlock(JIKKNHIAEKG_BlockName))
		{
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Setting.BONDDBOFBND_RankingStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Setting.BONDDBOFBND_RankingStart;
			if (NGHKJOEDLIP_Setting.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Setting.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Setting.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Setting.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Setting.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Setting.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Setting.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Setting.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Setting.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Setting.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Setting.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Setting.KNLGKBBIBOH_RewardEnd2 += offset;
		}

		return true;
	}

	// RVA: 0x1836754 Offset: 0x1836754 VA: 0x1836754 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "HIHJGPDLNDN_EventScore.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1836170 Offset: 0x1836170 VA: 0x1836170
	private bool DGKKMKLCEDF_DeserializeSetting(PMPDPNDJBLB JMHECKKKMLK)
	{
		NGHKJOEDLIP_Setting.OBGBAOLONDD_UniqueId = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD;
		NGHKJOEDLIP_Setting.OPFGFINHFCE_Name = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE;
		NGHKJOEDLIP_Setting.HEDAGCNPHGD_RankingName = JMHECKKKMLK.HMBHNLCFDIH.HEDAGCNPHGD;
		NGHKJOEDLIP_Setting.OCGFKMHNEOF_NameForApi = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF;
		NGHKJOEDLIP_Setting.BONDDBOFBND_RankingStart = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND;
		NGHKJOEDLIP_Setting.HPNOGLIFJOP_RankingEnd = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP;
		NGHKJOEDLIP_Setting.LNFKGHNHJKE_RankingEnd2 = JMHECKKKMLK.HMBHNLCFDIH.LNFKGHNHJKE;
		NGHKJOEDLIP_Setting.JGMDAOACOJF_RewardStart = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF;
		NGHKJOEDLIP_Setting.IDDBFFBPNGI_RewardEnd = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI;
		NGHKJOEDLIP_Setting.KNLGKBBIBOH_RewardEnd2 = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH;
		NGHKJOEDLIP_Setting.KHIKEGLBGAF_RankingRewardScene = (int)JMHECKKKMLK.HMBHNLCFDIH.KHIKEGLBGAF;
		NGHKJOEDLIP_Setting.POGEFBMBPCB_MonthOdd = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Setting.AHKNMANFILO_DayGroup = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO;
		NGHKJOEDLIP_Setting.MOEKELIIDEO_SaveSlot = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO;
		NGHKJOEDLIP_Setting.OCDMGOGMHGE_KeyPrefix = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE;
		NGHKJOEDLIP_Setting.AHKPNPNOAMO_ExtreamOpen = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKPNPNOAMO;
		NGHKJOEDLIP_Setting.HKKNEAGCIEB_RankingSupport = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.HKKNEAGCIEB;
		bool b = true;
		EEEKPHDPJHG(NGHKJOEDLIP_Setting.CAPAPAABKDP_FreeMusic, JMHECKKKMLK.HMBHNLCFDIH.KOHMHBGOFFI);
		for(int i = 0; i < JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI.Length; i++)
		{
			if(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i] < 1001)
			{
				NGHKJOEDLIP_Setting.JHPCPNJJHLI_RankingThreshold.Add(JMHECKKKMLK.HMBHNLCFDIH.JHPCPNJJHLI[i]);
			}
		}
		return true;
	}

	//// RVA: 0x18367DC Offset: 0x18367DC VA: 0x18367DC
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF IDLHJIOMJBK, int KAPMOPMDHJE) { }

	//// RVA: 0x1836FC4 Offset: 0x1836FC4 VA: 0x1836FC4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF OBHAFLMHAKG, string OPFGFINHFCE, ref bool NGJDHLGMHMH) { }

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
	//private void <DeserializeSetting>b__19_0(int OIPCCBHIKIA, int JBGEEPFKIGG) { }
}
