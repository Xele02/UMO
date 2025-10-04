
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HIADOIECMFP_EventPresentCampaign", true)]
public class HIADOIECMFP { }
public class HIADOIECMFP_EventPresentCampaign : DIHHCBACKGG_DbSection
{
	public class ABHKBHBKAJH
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public int HFNIHKOAMGC; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public string OCGFKMHNEOF_name_for_api; // 0x14
		public string FEMMDNIELFC_Desc; // 0x18
		public long BONDDBOFBND_RankingStart; // 0x20
		public long HPNOGLIFJOP_RankingEnd; // 0x28
		public long LNFKGHNHJKE_RankingEnd2; // 0x30
		public long JGMDAOACOJF_RewardStart; // 0x38
		public long IDDBFFBPNGI_RewardEnd; // 0x40
		public long KNLGKBBIBOH_RewardEnd2; // 0x48
		public int MJBKGOJBPAD_item_type; // 0x50
		public sbyte POGEFBMBPCB_MonthOdd; // 0x54
		public sbyte AHKNMANFILO_DayGroup; // 0x55
		public sbyte MOEKELIIDEO_SaveIdx; // 0x56
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x57
		public string OMCAOJJGOGG_Lb; // 0x58
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x5C
		public int HIOOGLEJBKM_StartAdventureId; // 0x60
		public int FJCADCDNPMP_EndAdventureId; // 0x64
		public int[] EJBGHLOOLBC_HelpIds; // 0x68

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x1835640 HBAAAKFHDBB_get_KeyPrefix 0x1834888 NHJLJOIPOFK_set_KeyPrefix

		//// RVA: 0x1833DE4 Offset: 0x1833DE4 VA: 0x1833DE4
		public void LHPDDGIJKNB_Reset()
		{
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			OBGBAOLONDD_UniqueId = 0;
			HFNIHKOAMGC = 0;
			OPFGFINHFCE_name = "";
			OCGFKMHNEOF_name_for_api = "";
			FEMMDNIELFC_Desc = "";
			MJBKGOJBPAD_item_type = 1;
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			OCDMGOGMHGE_KeyPrefix = "";
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
		}

		//// RVA: 0x183561C Offset: 0x183561C VA: 0x183561C
		//public uint CAOGDCBPBAN() { }
	}

	public class KEOBDBGPGPC
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public string FEMMDNIELFC_Desc; // 0x10
		public string MCNPILDHLEE; // 0x14
		public string OJHJLJLCKAC; // 0x18
		public int PNFGDBDNODC; // 0x1C
		public int KCGJGPOFOCD_ticket; // 0x20
		public List<int> GLCLFMGPMAN_ItemId = new List<int>(); // 0x24
		public List<int> MBJIFDBEDAC_item_count = new List<int>(); // 0x28

		//// RVA: 0x18356EC Offset: 0x18356EC VA: 0x18356EC
		public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id)
		{
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			HMFFHLPNMPH_count = 0;
			FEMMDNIELFC_Desc = "";
			MCNPILDHLEE = "";
			OJHJLJLCKAC = "";
			PNFGDBDNODC = 0;
			KCGJGPOFOCD_ticket = 0;
			GLCLFMGPMAN_ItemId.Clear();
			MBJIFDBEDAC_item_count.Clear();
		}

		//// RVA: 0x1834CE4 Offset: 0x1834CE4 VA: 0x1834CE4
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, CEGMAIDIKLC JMHECKKKMLK)
		{
			LHPDDGIJKNB_Reset(_PPFNGGCBJKC_id);
			PDDHLCIJPOK data = JMHECKKKMLK.BNHMOENHDFB[_PPFNGGCBJKC_id - 1];
			this.PPFNGGCBJKC_id = data.PPFNGGCBJKC_id;
			FEMMDNIELFC_Desc = data.FEMMDNIELFC_Desc;
			HMFFHLPNMPH_count = data.HMFFHLPNMPH_count;
			MCNPILDHLEE = data.MCNPILDHLEE;
			OJHJLJLCKAC = data.OJHJLJLCKAC;
			PNFGDBDNODC = data.PNFGDBDNODC;
			KCGJGPOFOCD_ticket = data.KCGJGPOFOCD_ticket;
			for(int i = 0; i < data.COCEIPAKJKF_item.Length; i++)
			{
				if(data.COCEIPAKJKF_item[i] != 0)
				{
					GLCLFMGPMAN_ItemId.Add(data.COCEIPAKJKF_item[i]);
					MBJIFDBEDAC_item_count.Add(data.BFINGCJHOHI_cnt[i]);
				}
			}
		}

		//// RVA: 0x1835624 Offset: 0x1835624 VA: 0x1835624
		//public uint CAOGDCBPBAN() { }
	}

	public class DFPGOAOKPBI
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int KLCMKLPIDDJ_Month; // 0xC
		public int BAOFEFFADPD_day; // 0x10
		public long FKPEAGGKNLC_Start; // 0x18
		public long KOMKKBDABJP_end; // 0x20
		public string LJNAKDMILMC_key; // 0x28

		//// RVA: 0x183566C Offset: 0x183566C VA: 0x183566C
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x1835034 Offset: 0x1835034 VA: 0x1835034
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, CEGMAIDIKLC JMHECKKKMLK)
		{
			KLCMKLPIDDJ_Month = 0;
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			FKPEAGGKNLC_Start = 0;
			BAOFEFFADPD_day = 0;
			LJNAKDMILMC_key = "";
			this.PPFNGGCBJKC_id = JMHECKKKMLK.MAHEBNDELHE[_PPFNGGCBJKC_id - 1].PPFNGGCBJKC_id;
			KLCMKLPIDDJ_Month = JMHECKKKMLK.MAHEBNDELHE[_PPFNGGCBJKC_id - 1].KLCMKLPIDDJ_Month;
			BAOFEFFADPD_day = JMHECKKKMLK.MAHEBNDELHE[_PPFNGGCBJKC_id - 1].BAOFEFFADPD_day;
			FKPEAGGKNLC_Start = JMHECKKKMLK.MAHEBNDELHE[_PPFNGGCBJKC_id - 1].FKPEAGGKNLC_Start;
			KOMKKBDABJP_end = JMHECKKKMLK.MAHEBNDELHE[_PPFNGGCBJKC_id - 1].KOMKKBDABJP_end;
			DateTime t = Utility.GetLocalDateTime(FKPEAGGKNLC_Start);
			LJNAKDMILMC_key = string.Concat(new object[5]
			{
				t.Year, "-", t.Month, "-", t.Day
			});
		}
	}

	public ABHKBHBKAJH NGHKJOEDLIP_Settings = new ABHKBHBKAJH(); // 0x20
	public List<DFPGOAOKPBI> EENHCEEKBBD = new List<DFPGOAOKPBI>(); // 0x24
	public List<KEOBDBGPGPC> OBPOHDENMHH = new List<KEOBDBGPGPC>(); // 0x28

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x2C IHKPIFIBECO GAMGELHIHHI_get_m_stringParam DDDEJIJGGBJ_set_m_stringParam
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x30 KLDCHOIPJGB AEMNOGNEBOJ_get_m_intParam DGKDBOAMNBB_set_m_intParam

	//// RVA: 0x18338D8 Offset: 0x18338D8 VA: 0x18338D8
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x18339BC Offset: 0x18339BC VA: 0x18339BC
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x1833AA0 Offset: 0x1833AA0 VA: 0x1833AA0
	public HIADOIECMFP_EventPresentCampaign()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 36;
	}

	// RVA: 0x1833CCC Offset: 0x1833CCC VA: 0x1833CCC Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		OBPOHDENMHH.Clear();
		EENHCEEKBBD.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0x1833E94 Offset: 0x1833E94 VA: 0x1833E94 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		CEGMAIDIKLC data = CEGMAIDIKLC.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		HMGBIBOJDBA(data);
		AFLBFOPMIME(data);
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

			for(int i = 0; i < EENHCEEKBBD.Count; i++)
			{
				if (EENHCEEKBBD[i].FKPEAGGKNLC_Start != 0) EENHCEEKBBD[i].FKPEAGGKNLC_Start += offset;
				if (EENHCEEKBBD[i].KOMKKBDABJP_end != 0) EENHCEEKBBD[i].KOMKKBDABJP_end += offset;
				DateTime t = Utility.GetLocalDateTime(EENHCEEKBBD[i].FKPEAGGKNLC_Start);
				EENHCEEKBBD[i].LJNAKDMILMC_key = string.Concat(new object[5]
				{
					t.Year, "-", t.Month, "-", t.Day
				});
			}
		}
		return true;
	}

	// RVA: 0x1834880 Offset: 0x1834880 VA: 0x1834880 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "HIADOIECMFP_EventPresentCampaign.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x1834180 Offset: 0x1834180 VA: 0x1834180
	private bool DGKKMKLCEDF_DeserializeSetting(CEGMAIDIKLC JMHECKKKMLK)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)JMHECKKKMLK.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = JMHECKKKMLK.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = JMHECKKKMLK.HMBHNLCFDIH.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = JMHECKKKMLK.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = JMHECKKKMLK.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = JMHECKKKMLK.HMBHNLCFDIH.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = JMHECKKKMLK.HMBHNLCFDIH.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = JMHECKKKMLK.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)JMHECKKKMLK.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = JMHECKKKMLK.HMBHNLCFDIH.OCDMGOGMHGE_KeyPrefix;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = 0;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = 0;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = 0;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = JMHECKKKMLK.HMBHNLCFDIH.EJBGHLOOLBC_HelpIds;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = "";
		return true;
	}

	//// RVA: 0x18348BC Offset: 0x18348BC VA: 0x18348BC
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x18348C4 Offset: 0x18348C4 VA: 0x18348C4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x1834AA4 Offset: 0x1834AA4 VA: 0x1834AA4
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x18345B4 Offset: 0x18345B4 VA: 0x18345B4
	private bool HMGBIBOJDBA(CEGMAIDIKLC JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.BNHMOENHDFB.Length; i++)
		{
			KEOBDBGPGPC d = new KEOBDBGPGPC();
			d.KHEKNNFCAOI_Init(i + 1, JMHECKKKMLK);
			OBPOHDENMHH.Add(d);
		}
		return true;
	}

	//// RVA: 0x1834718 Offset: 0x1834718 VA: 0x1834718
	private bool AFLBFOPMIME(CEGMAIDIKLC JMHECKKKMLK)
	{
		for(int i = 0; i < JMHECKKKMLK.MAHEBNDELHE.Length; i++)
		{
			DFPGOAOKPBI d = new DFPGOAOKPBI();
			d.KHEKNNFCAOI_Init(i + 1, JMHECKKKMLK);
			EENHCEEKBBD.Add(d);
		}
		return true;
	}

	// RVA: 0x1835510 Offset: 0x1835510 VA: 0x1835510 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HIADOIECMFP_EventPresentCampaign.CAOGDCBPBAN");
		return 0;
	}
}
