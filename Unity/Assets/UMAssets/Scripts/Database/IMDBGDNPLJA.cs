
using System.Collections.Generic;
using UnityEngine;
using XeSys;

[System.Obsolete("Use IMDBGDNPLJA_EventBoxGacha", true)]
public class IMDBGDNPLJA { }
public class IMDBGDNPLJA_EventBoxGacha : DIHHCBACKGG_DbSection
{
	public class NFDDNDNBIHB
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public int HFNIHKOAMGC; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public string HEDAGCNPHGD_RankingName; // 0x14
		public string OCGFKMHNEOF_name_for_api; // 0x18
		public string FEMMDNIELFC_Desc; // 0x1C
		public long BONDDBOFBND_RankingStart; // 0x20
		public long HPNOGLIFJOP_RankingEnd; // 0x28
		public long FCNKIKOOFKE; // 0x30
		public long LNFKGHNHJKE_RankingEnd2; // 0x38
		public long JGMDAOACOJF_RewardStart; // 0x40
		public long IDDBFFBPNGI_RewardEnd; // 0x48
		public long KNLGKBBIBOH_RewardEnd2; // 0x50
		public int MJBKGOJBPAD_item_type; // 0x58 TicketType
		public sbyte POGEFBMBPCB_MonthOdd; // 0x5C
		public sbyte AHKNMANFILO_DayGroup; // 0x5D
		public sbyte MOEKELIIDEO_SaveIdx; // 0x5E
		public sbyte HKKNEAGCIEB_RankingSupport; // 0x5F
		public string OMCAOJJGOGG_Lb; // 0x60
		public int GMFNMNOIJHI; // 0x64
		public long OHGDNJLFDFF_Start; // 0x68
		public long PHKLJGNMFBL_End; // 0x70
		private NNJFKLBPBNK_SecureString EBGIDCIIGDO_KeyPrefix = new NNJFKLBPBNK_SecureString(); // 0x78
		public int HIOOGLEJBKM_StartAdventureId; // 0x7C
		public int FJCADCDNPMP_EndAdventureId; // 0x80
		public int[] EJBGHLOOLBC_HelpIds; // 0x84

		public string OCDMGOGMHGE_KeyPrefix { get { return EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value; } set { EBGIDCIIGDO_KeyPrefix.DNJEJEANJGL_Value = value; } } //0x9FA5E8 HBAAAKFHDBB 0x9F8F08 NHJLJOIPOFK

		//// RVA: 0x9F7C84 Offset: 0x9F7C84 VA: 0x9F7C84
		public void LHPDDGIJKNB_Reset()
		{
			OBGBAOLONDD_UniqueId = 0;
			HFNIHKOAMGC = 0;
			BONDDBOFBND_RankingStart = 0;
			HPNOGLIFJOP_RankingEnd = 0;
			JGMDAOACOJF_RewardStart = 0;
			IDDBFFBPNGI_RewardEnd = 0;
			FCNKIKOOFKE = 0;
			MJBKGOJBPAD_item_type = 1;
			POGEFBMBPCB_MonthOdd = 0;
			AHKNMANFILO_DayGroup = 0;
			OPFGFINHFCE_name = null;
			HEDAGCNPHGD_RankingName = null;
			OCGFKMHNEOF_name_for_api = null;
			FEMMDNIELFC_Desc = null;
			OCDMGOGMHGE_KeyPrefix = "";
			GMFNMNOIJHI = 0;
			OHGDNJLFDFF_Start = 0;
			OMCAOJJGOGG_Lb = "";
			HIOOGLEJBKM_StartAdventureId = 0;
			FJCADCDNPMP_EndAdventureId = 0;
			EJBGHLOOLBC_HelpIds = null;
			PHKLJGNMFBL_End = 0;
		}

		//// RVA: 0x9F9598 Offset: 0x9F9598 VA: 0x9F9598
		//public uint CAOGDCBPBAN() { }
	}

	public class NEFJBPECLKJ
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int IJEKNCDIIAE_mver; // 0xC
		public int PLALNIIBLOF_en; // 0x10
		public int HLOBFDBFINJ_Link; // 0x14
		public int IHGDLBBPKFI_Next; // 0x18
		public string OPFGFINHFCE_name; // 0x1C
		public int GLCLFMGPMAN_ItemId; // 0x20
		public int NDNHKMJPBCM_Cost; // 0x24
		public long PDBPFJJCADD_open_at; // 0x28
		public long FDBNFFNFOND_close_at; // 0x30

		//// RVA: 0x9F9F30 Offset: 0x9F9F30 VA: 0x9F9F30
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x9F9FB8 Offset: 0x9F9FB8 VA: 0x9F9FB8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//IJEKNCDIIAE_mver = mver
		//PLALNIIBLOF_en = en
		//HLOBFDBFINJ_Link = link
		//IHGDLBBPKFI_Next = next
		//OPFGFINHFCE_name = name
		//GLCLFMGPMAN_ItemId = item_id
		//NDNHKMJPBCM_Cost = cost
		//PDBPFJJCADD_open_at = open_at
		//FDBNFFNFOND_close_at = close_at

		//// RVA: 0x9FA374 Offset: 0x9FA374 VA: 0x9FA374
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, KBFIJHDHOGA JMHECKKKMLK) { }

		//// RVA: 0x9F95A0 Offset: 0x9F95A0 VA: 0x9F95A0
		//public uint CAOGDCBPBAN() { }
	}
 
	public class BKGONBEMGED
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public int IMMDGJAOPCD_BoxId; // 0x10
		public int AEDMJLGNDHN_IsSp; // 0x14
		public int GLCLFMGPMAN_ItemId; // 0x18
		public int JBGEEPFKIGG_val; // 0x1C
		public int ADPPAIPFHML_num; // 0x20

		//// RVA: 0x9F9AD8 Offset: 0x9F9AD8 VA: 0x9F9AD8
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x9F9AF8 Offset: 0x9F9AF8 VA: 0x9F9AF8
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//IMMDGJAOPCD_BoxId = box_id
		//AEDMJLGNDHN_IsSp = is_sp
		//GLCLFMGPMAN_ItemId = item_id
		//JBGEEPFKIGG_val = val
		//ADPPAIPFHML_num = num

		//// RVA: 0x9F9D90 Offset: 0x9F9D90 VA: 0x9F9D90
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, KBFIJHDHOGA JMHECKKKMLK) { }

		//// RVA: 0x9F95F0 Offset: 0x9F95F0 VA: 0x9F95F0
		//public uint CAOGDCBPBAN() { }
	}

	public class BKEFFIMGDNH
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC*
		// Order
		public int FPOMEEJFBIG_odr; // 0x10
		public int GPJKJCBPBIP_Tim; // 0x14
		public int OAFPGJLCNFM_cond; // 0x18
		public int GBJFNGCDKPM_typ; // 0x1C Type
		public int NKNAECHNACI_GroupId; // 0x20

		//// RVA: 0x9F9680 Offset: 0x9F9680 VA: 0x9F9680
		//public void LHPDDGIJKNB_Reset(int _PPFNGGCBJKC_id) { }

		//// RVA: 0x9F96A0 Offset: 0x9F96A0 VA: 0x9F96A0
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//PPFNGGCBJKC_id = id
		//PLALNIIBLOF_en = en
		//FPOMEEJFBIG_odr = odr
		//GPJKJCBPBIP_Tim = tim
		//OAFPGJLCNFM_cond = cond
		//GBJFNGCDKPM_typ = typ
		//NKNAECHNACI_GroupId = grp_id

		//// RVA: 0x9F9938 Offset: 0x9F9938 VA: 0x9F9938
		//public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id, KBFIJHDHOGA JMHECKKKMLK) { }

		//// RVA: 0x9F9634 Offset: 0x9F9634 VA: 0x9F9634
		//public uint CAOGDCBPBAN() { }
	}

	public NFDDNDNBIHB NGHKJOEDLIP_Settings = new NFDDNDNBIHB(); // 0x20
	public List<NEFJBPECLKJ> KGDBEMPMAIJ_Boxes = new List<NEFJBPECLKJ>(); // 0x24
	public List<BKGONBEMGED> PKPLOGBIDIG_Prizes = new List<BKGONBEMGED>(); // 0x28
	public List<BKEFFIMGDNH> FICLPLNOKOP = new List<BKEFFIMGDNH>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x9F7718 Offset: 0x9F7718 VA: 0x9F7718
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	//// RVA: 0x9F77FC Offset: 0x9F77FC VA: 0x9F77FC
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
		{
			return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
		}
		return _KKMJBMKHGNH_noval;
	}

	// RVA: 0x9F78E0 Offset: 0x9F78E0 VA: 0x9F78E0
	public IMDBGDNPLJA_EventBoxGacha()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 29;
	}

	// RVA: 0x9F7B40 Offset: 0x9F7B40 VA: 0x9F7B40 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		KGDBEMPMAIJ_Boxes.Clear();
		PKPLOGBIDIG_Prizes.Clear();
		FICLPLNOKOP.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0x9F7D50 Offset: 0x9F7D50 VA: 0x9F7D50 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		KBFIJHDHOGA data = KBFIJHDHOGA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		GMILHDEGFDE(data);
		HMGBIBOJDBA(data);
		BJEKIGFCNGJ(data);
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
			long rDate = /*NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start > NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart ? NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start : */NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			System.DateTime date2 = Utility.GetLocalDateTime(rDate);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - rDate;
			if (NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart != 0) NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart += offset;
			if (NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd != 0) NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd += offset;
			if (NGHKJOEDLIP_Settings.FCNKIKOOFKE != 0) NGHKJOEDLIP_Settings.FCNKIKOOFKE += offset;
			if (NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 != 0) NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 += offset;
			if (NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart != 0) NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart += offset;
			if (NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd != 0) NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd += offset;
			if (NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 != 0) NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 += offset;
			if (NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start != 0) NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start += offset;
			if (NGHKJOEDLIP_Settings.PHKLJGNMFBL_End != 0) NGHKJOEDLIP_Settings.PHKLJGNMFBL_End += offset;
			/*UnityEngine.Debug.LogError(Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart).ToLongDateString()+" "+
				Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd).ToLongDateString()+" "+
				Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start).ToLongDateString()+" "+
				Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.PHKLJGNMFBL_End).ToLongDateString());*/
			// Tmp, move NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start & NGHKJOEDLIP_Settings.PHKLJGNMFBL_End to start & end
			NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			NGHKJOEDLIP_Settings.PHKLJGNMFBL_End = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;

			for(int i = 0; i < KGDBEMPMAIJ_Boxes.Count; i++)
			{
				if (KGDBEMPMAIJ_Boxes[i].PDBPFJJCADD_open_at != 0) KGDBEMPMAIJ_Boxes[i].PDBPFJJCADD_open_at = NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				if (KGDBEMPMAIJ_Boxes[i].FDBNFFNFOND_close_at != 0) KGDBEMPMAIJ_Boxes[i].FDBNFFNFOND_close_at = NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			}
		}
		return true;
	}

	// RVA: 0x9F8DF0 Offset: 0x9F8DF0 VA: 0x9F8DF0 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//NGHKJOEDLIP_Settings = setting
		//KGDBEMPMAIJ_Boxes = gacha_box
		//PKPLOGBIDIG_Prizes = prize
		TodoLogger.LogError(TodoLogger.DbJson, "IMDBGDNPLJA_EventBoxGacha.IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x9F8048 Offset: 0x9F8048 VA: 0x9F8048
	private bool DGKKMKLCEDF_DeserializeSetting(KBFIJHDHOGA FGBHBEPCPFI)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)FGBHBEPCPFI.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = FGBHBEPCPFI.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = FGBHBEPCPFI.HMBHNLCFDIH.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = FGBHBEPCPFI.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = FGBHBEPCPFI.HMBHNLCFDIH.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = FGBHBEPCPFI.HMBHNLCFDIH.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.FCNKIKOOFKE = FGBHBEPCPFI.HMBHNLCFDIH.FCNKIKOOFKE;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = FGBHBEPCPFI.HMBHNLCFDIH.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = FGBHBEPCPFI.HMBHNLCFDIH.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = FGBHBEPCPFI.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.POGEFBMBPCB_MonthOdd = (sbyte)FGBHBEPCPFI.HMBHNLCFDIH.JMJDLDEIFKE;
		NGHKJOEDLIP_Settings.AHKNMANFILO_DayGroup = (sbyte)FGBHBEPCPFI.HMBHNLCFDIH.AHKNMANFILO_DayGroup;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)FGBHBEPCPFI.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix = FGBHBEPCPFI.HMBHNLCFDIH.OCDMGOGMHGE_KeyPrefix;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = FGBHBEPCPFI.HMBHNLCFDIH.MJBKGOJBPAD_item_type;
		NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc = FGBHBEPCPFI.HMBHNLCFDIH.FEMMDNIELFC_Desc;
		NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport = (sbyte)FGBHBEPCPFI.HMBHNLCFDIH.HKKNEAGCIEB_RankingSupport;
		NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId = FGBHBEPCPFI.HMBHNLCFDIH.HIOOGLEJBKM_StartAdventureId;
		NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId = FGBHBEPCPFI.HMBHNLCFDIH.FJCADCDNPMP_EndAdventureId;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = FGBHBEPCPFI.HMBHNLCFDIH.EJBGHLOOLBC_HelpIds;
		NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb = FGBHBEPCPFI.HMBHNLCFDIH.OMCAOJJGOGG_Lb;
		NGHKJOEDLIP_Settings.GMFNMNOIJHI = FGBHBEPCPFI.HMBHNLCFDIH.GMFNMNOIJHI;
		NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start = FGBHBEPCPFI.HMBHNLCFDIH.OHGDNJLFDFF_Start;
		NGHKJOEDLIP_Settings.PHKLJGNMFBL_End = FGBHBEPCPFI.HMBHNLCFDIH.PHKLJGNMFBL_End;
		return true;
	}

	//// RVA: 0x9F8EF0 Offset: 0x9F8EF0 VA: 0x9F8EF0
	//private bool DGKKMKLCEDF_DeserializeSetting(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x9F8F3C Offset: 0x9F8F3C VA: 0x9F8F3C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, EDOHBJAPLPF_JsonData OBHAFLMHAKG, string _OPFGFINHFCE_name, ref bool _NGJDHLGMHMH_IsInvalid) { }

	//// RVA: 0x9F911C Offset: 0x9F911C VA: 0x9F911C
	//private void EEEKPHDPJHG(List<int> NNDGIAEFMOG, string OAIBJJHGCNM) { }

	//// RVA: 0x9F860C Offset: 0x9F860C VA: 0x9F860C
	private bool GMILHDEGFDE(KBFIJHDHOGA FGBHBEPCPFI)
	{
		for(int i = 0; i < FGBHBEPCPFI.GCMONMILNMH.Length; i++)
		{
			NEFJBPECLKJ d = new NEFJBPECLKJ();
			d.PPFNGGCBJKC_id = (int)FGBHBEPCPFI.GCMONMILNMH[i].PPFNGGCBJKC_id;
			d.IJEKNCDIIAE_mver = FGBHBEPCPFI.GCMONMILNMH[i].IJEKNCDIIAE_mver;
			d.PLALNIIBLOF_en = (int)FGBHBEPCPFI.GCMONMILNMH[i].PLALNIIBLOF_en;
			d.HLOBFDBFINJ_Link = (int)FGBHBEPCPFI.GCMONMILNMH[i].HLOBFDBFINJ_Link;
			d.IHGDLBBPKFI_Next = (int)FGBHBEPCPFI.GCMONMILNMH[i].IHGDLBBPKFI_Next;
			d.OPFGFINHFCE_name = FGBHBEPCPFI.GCMONMILNMH[i].OPFGFINHFCE_name;
			d.GLCLFMGPMAN_ItemId = FGBHBEPCPFI.GCMONMILNMH[i].GLCLFMGPMAN_ItemId;
			d.NDNHKMJPBCM_Cost = FGBHBEPCPFI.GCMONMILNMH[i].NDNHKMJPBCM_Cost;
			d.PDBPFJJCADD_open_at = FGBHBEPCPFI.GCMONMILNMH[i].PDBPFJJCADD_open_at;
			d.FDBNFFNFOND_close_at = FGBHBEPCPFI.GCMONMILNMH[i].FDBNFFNFOND_close_at;
			KGDBEMPMAIJ_Boxes.Add(d);
		}
		return true;
	}

	//// RVA: 0x9F8EF8 Offset: 0x9F8EF8 VA: 0x9F8EF8
	//private bool GMILHDEGFDE(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x9F8900 Offset: 0x9F8900 VA: 0x9F8900
	private bool HMGBIBOJDBA(KBFIJHDHOGA FGBHBEPCPFI)
	{
		for(int i = 0; i < FGBHBEPCPFI.BNHMOENHDFB.Length; i++)
		{
			BKGONBEMGED d = new BKGONBEMGED();
			d.PPFNGGCBJKC_id = (int)FGBHBEPCPFI.BNHMOENHDFB[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)FGBHBEPCPFI.BNHMOENHDFB[i].PLALNIIBLOF_en;
			d.IMMDGJAOPCD_BoxId = (int)FGBHBEPCPFI.BNHMOENHDFB[i].IMMDGJAOPCD_BoxId;
			d.AEDMJLGNDHN_IsSp = FGBHBEPCPFI.BNHMOENHDFB[i].AEDMJLGNDHN_IsSp;
			d.GLCLFMGPMAN_ItemId = FGBHBEPCPFI.BNHMOENHDFB[i].GLCLFMGPMAN_ItemId;
			d.JBGEEPFKIGG_val = FGBHBEPCPFI.BNHMOENHDFB[i].JBGEEPFKIGG_val;
			d.ADPPAIPFHML_num = (int)FGBHBEPCPFI.BNHMOENHDFB[i].ADPPAIPFHML_num;
			PKPLOGBIDIG_Prizes.Add(d);
		}
		return true;
	}

	//// RVA: 0x9F8F00 Offset: 0x9F8F00 VA: 0x9F8F00
	//private bool HMGBIBOJDBA(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	//// RVA: 0x9F8B78 Offset: 0x9F8B78 VA: 0x9F8B78
	private bool BJEKIGFCNGJ(KBFIJHDHOGA FGBHBEPCPFI)
	{
		for(int i = 0; i < FGBHBEPCPFI.EBJIGPIKKNB.Length; i++)
		{
			BKEFFIMGDNH d = new BKEFFIMGDNH();
			d.PPFNGGCBJKC_id = (int)FGBHBEPCPFI.EBJIGPIKKNB[i].PPFNGGCBJKC_id;
			d.PLALNIIBLOF_en = (int)FGBHBEPCPFI.EBJIGPIKKNB[i].PLALNIIBLOF_en;
			d.FPOMEEJFBIG_odr = (int)FGBHBEPCPFI.EBJIGPIKKNB[i].FPOMEEJFBIG_odr;
			d.GPJKJCBPBIP_Tim = FGBHBEPCPFI.EBJIGPIKKNB[i].GPJKJCBPBIP_Tim;
			d.OAFPGJLCNFM_cond = FGBHBEPCPFI.EBJIGPIKKNB[i].OAFPGJLCNFM_cond;
			d.GBJFNGCDKPM_typ = FGBHBEPCPFI.EBJIGPIKKNB[i].GBJFNGCDKPM_typ;
			d.NKNAECHNACI_GroupId = (int)FGBHBEPCPFI.EBJIGPIKKNB[i].NKNAECHNACI_GroupId;
			FICLPLNOKOP.Add(d);
		}
		return true;
	}

	//// RVA: 0x9F92D0 Offset: 0x9F92D0 VA: 0x9F92D0
	//private bool BJEKIGFCNGJ(EDOHBJAPLPF_JsonData OBHAFLMHAKG, int _KAPMOPMDHJE_label) { }

	// RVA: 0x9F92D8 Offset: 0x9F92D8 VA: 0x9F92D8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "IMDBGDNPLJA_EventBoxGacha.CAOGDCBPBAN");
		return 0;
	}
}
