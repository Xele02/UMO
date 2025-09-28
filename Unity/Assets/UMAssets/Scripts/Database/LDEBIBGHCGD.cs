
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use LDEBIBGHCGD_EventRaidLobby", true)]
public class LDEBIBGHCGD { }
public class LDEBIBGHCGD_EventRaidLobby : DIHHCBACKGG_DbSection
{
	public class NBGDKOACGLM
	{
		public int OBGBAOLONDD_UniqueId; // 0x8
		public string OPFGFINHFCE_name; // 0xC
		public long CJPMLAIFCDL_LobbyStart; // 0x10
		public long COIHIAKHFNF_End; // 0x18
		public long NIMLIMFPNJP_RaidStart; // 0x20
		public long KCBGBFMGHPA_End; // 0x28
		public int MJBKGOJBPAD_item_type; // 0x30
		public sbyte MOEKELIIDEO_SaveIdx; // 0x34
		public int[] EJBGHLOOLBC_HelpIds; // 0x38

		//// RVA: 0xD65AB4 Offset: 0xD65AB4 VA: 0xD65AB4
		public void LHPDDGIJKNB_Reset()
		{
			NIMLIMFPNJP_RaidStart = 0;
			KCBGBFMGHPA_End = 0;
			CJPMLAIFCDL_LobbyStart = 0;
			COIHIAKHFNF_End = 0;
			MOEKELIIDEO_SaveIdx = 0;
			OBGBAOLONDD_UniqueId = 0;
			OPFGFINHFCE_name = "";
			MJBKGOJBPAD_item_type = 1;
			EJBGHLOOLBC_HelpIds = null;
		}

		//// RVA: 0xD66A20 Offset: 0xD66A20 VA: 0xD66A20
		//public uint CAOGDCBPBAN() { }
	}

	public class HDFAGGBJGAA
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int AACHOBAAALA_ImageId; // 0xC
		public string OPFGFINHFCE_name; // 0x10
		public string HEDAGCNPHGD_RankingName; // 0x14
		public List<int> OCDBMHBNLEF; // 0x18

		// RVA: 0xD664B0 Offset: 0xD664B0 VA: 0xD664B0
		public HDFAGGBJGAA(string BlockName, int _OIPCCBHIKIA_index, BFOKFIJNCJJ _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = _OIPCCBHIKIA_index + 1;
			AACHOBAAALA_ImageId = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			OPFGFINHFCE_name = DatabaseTextConverter.TranslateLobbyGroupName(BlockName, PPFNGGCBJKC_id, _IDLHJIOMJBK_data.OPFGFINHFCE_name);
			HEDAGCNPHGD_RankingName = _IDLHJIOMJBK_data.HEDAGCNPHGD_RankingName;
			OCDBMHBNLEF = new List<int>(_IDLHJIOMJBK_data.OCDBMHBNLEF.Length);
			for(int i = 0; i < _IDLHJIOMJBK_data.OCDBMHBNLEF.Length; i++)
			{
				OCDBMHBNLEF.Add((int)_IDLHJIOMJBK_data.OCDBMHBNLEF[i]);
			}
		}

		//// RVA: 0xD66ADC Offset: 0xD66ADC VA: 0xD66ADC
		//public uint CAOGDCBPBAN() { }
	}

	public class LNECBHIKKHK
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int GJNIPHMPMIC_Phase; // 0xC
		public int INDDJNMPONH_type; // 0x10
		public int FDBOPFEOENF_diva; // 0x14
		public int MJMPANIBFED_pid; // 0x18 Pic
		public string LICPCDCLOIO_Message; // 0x1C

		//// RVA: 0xD666C8 Offset: 0xD666C8 VA: 0xD666C8
		public LNECBHIKKHK(string BlockName, PALCPDPGOPC _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data.PPFNGGCBJKC_id;
			GJNIPHMPMIC_Phase = (int)_IDLHJIOMJBK_data.GJNIPHMPMIC_Phase;
			INDDJNMPONH_type = (int)_IDLHJIOMJBK_data.GBJFNGCDKPM_typ;
			FDBOPFEOENF_diva = (int)_IDLHJIOMJBK_data.FDBOPFEOENF_diva;
			MJMPANIBFED_pid = (int)_IDLHJIOMJBK_data.MJMPANIBFED_pid;
			LICPCDCLOIO_Message = DatabaseTextConverter.TranslateLobbyGuideText( BlockName, PPFNGGCBJKC_id, _IDLHJIOMJBK_data.LICPCDCLOIO_Message );
		}

		//// RVA: 0xD66BB8 Offset: 0xD66BB8 VA: 0xD66BB8
		//public uint CAOGDCBPBAN() { }
	}

	public NBGDKOACGLM NGHKJOEDLIP_Settings = new NBGDKOACGLM(); // 0x20
	public List<HDFAGGBJGAA> OJGPPOKENLG_Groups = new List<HDFAGGBJGAA>(); // 0x24
	public List<LNECBHIKKHK> OIIMJFCBFFG_LobbyGuide = new List<LNECBHIKKHK>(); // 0x28
	public List<AKIIJBEJOEP> NNMPGOAGEOL_quests = new List<AKIIJBEJOEP>(); // 0x2C

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0xD65550 Offset: 0xD65550 VA: 0xD65550
	public HDFAGGBJGAA HMHGPIEBKPO_GetGroup(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id > 0 && _PPFNGGCBJKC_id <= OJGPPOKENLG_Groups.Count)
			return OJGPPOKENLG_Groups[_PPFNGGCBJKC_id - 1];
		return null;
	}

	//// RVA: 0xD65610 Offset: 0xD65610 VA: 0xD65610
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if(!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0xD656F4 Offset: 0xD656F4 VA: 0xD656F4
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if(!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	// RVA: 0xD657D8 Offset: 0xD657D8 VA: 0xD657D8
	public LDEBIBGHCGD_EventRaidLobby()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 39;
	}

	// RVA: 0xD659C8 Offset: 0xD659C8 VA: 0xD659C8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		NNMPGOAGEOL_quests.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
	}

	// RVA: 0xD65B3C Offset: 0xD65B3C VA: 0xD65B3C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MAGFOKIIPPD data = MAGFOKIIPPD.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF_DeserializeSetting(data);
		FOPPFILCLDJ(data);
		JIBKOEFOAPG(data);
		CFOFJPLEDEA(data);
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
			UnityEngine.Debug.LogError("Lobby : "+NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart+" "+NGHKJOEDLIP_Settings.COIHIAKHFNF_End+" "+NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart+" "+NGHKJOEDLIP_Settings.KCBGBFMGHPA_End);
			System.DateTime date = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
			System.DateTime date2 = Utility.GetLocalDateTime(NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart);
			date = date.AddDays(-1);
			long offset = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, date2.Hour, date2.Minute, date2.Second) - NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart;
			if (NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart != 0) NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart += offset;
			if (NGHKJOEDLIP_Settings.COIHIAKHFNF_End != 0) NGHKJOEDLIP_Settings.COIHIAKHFNF_End += offset;
			if (NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart != 0) NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart += offset;
			if (NGHKJOEDLIP_Settings.KCBGBFMGHPA_End != 0) NGHKJOEDLIP_Settings.KCBGBFMGHPA_End += offset;

			for(int i = 0; i < NNMPGOAGEOL_quests.Count; i++)
			{
				if( NNMPGOAGEOL_quests[i].PPEGAKEIEGM_Enabled == 2)
				{
					if (NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt != 0) NNMPGOAGEOL_quests[i].KJBGCLPMLCG_OpenedAt = NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart;
					if (NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt != 0) NNMPGOAGEOL_quests[i].GJFPFFBAKGK_CloseAt = NGHKJOEDLIP_Settings.COIHIAKHFNF_End;
				}
			}
		}

		return true;
	}

	//// RVA: 0xD65E34 Offset: 0xD65E34 VA: 0xD65E34
	private bool DGKKMKLCEDF_DeserializeSetting(MAGFOKIIPPD KNOEHKKNIJA)
	{
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)KNOEHKKNIJA.HMBHNLCFDIH.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = KNOEHKKNIJA.HMBHNLCFDIH.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.CJPMLAIFCDL_LobbyStart = KNOEHKKNIJA.HMBHNLCFDIH.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.COIHIAKHFNF_End = KNOEHKKNIJA.HMBHNLCFDIH.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.NIMLIMFPNJP_RaidStart = KNOEHKKNIJA.HMBHNLCFDIH.NIMLIMFPNJP_RaidStart;
		NGHKJOEDLIP_Settings.KCBGBFMGHPA_End = KNOEHKKNIJA.HMBHNLCFDIH.KCBGBFMGHPA_End;
		NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx = (sbyte)KNOEHKKNIJA.HMBHNLCFDIH.MOEKELIIDEO_SaveIdx;
		NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type = KNOEHKKNIJA.HMBHNLCFDIH.MJBKGOJBPAD_item_type;
		NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds = KNOEHKKNIJA.HMBHNLCFDIH.EJBGHLOOLBC_HelpIds;
		return true;
	}

	//// RVA: 0xD66084 Offset: 0xD66084 VA: 0xD66084
	private bool FOPPFILCLDJ(MAGFOKIIPPD KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.KBFEMKJBHBL.Length; i++)
		{
			HDFAGGBJGAA data = new HDFAGGBJGAA(JIKKNHIAEKG_BlockName, i, KNOEHKKNIJA.KBFEMKJBHBL[i]);
			OJGPPOKENLG_Groups.Add(data);
		}
		return true;
	}

	//// RVA: 0xD661D0 Offset: 0xD661D0 VA: 0xD661D0
	private bool JIBKOEFOAPG(MAGFOKIIPPD KNOEHKKNIJA)
	{
		for(int i = 0; i < KNOEHKKNIJA.CEPBAOMAHNH.Length; i++)
		{
			LNECBHIKKHK data = new LNECBHIKKHK(JIKKNHIAEKG_BlockName, KNOEHKKNIJA.CEPBAOMAHNH[i]);
			OIIMJFCBFFG_LobbyGuide.Add(data);
		}
		return true;
	}

	//// RVA: 0xD66318 Offset: 0xD66318 VA: 0xD66318
	private bool CFOFJPLEDEA(MAGFOKIIPPD KNOEHKKNIJA)
	{
		int xor = (int)Utility.GetCurrentUnixTime() * 11 + 1;
		for(int i = 0; i < KNOEHKKNIJA.MDDOGIAFDEI.Length; i++)
		{
			AKIIJBEJOEP data = new AKIIJBEJOEP();
			data.KHEKNNFCAOI_Init(JIKKNHIAEKG_BlockName, i + 1, xor, KNOEHKKNIJA);
			NNMPGOAGEOL_quests.Add(data);
			xor += 13;
		}
		return true;
	}

	// RVA: 0xD667D0 Offset: 0xD667D0 VA: 0xD667D0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "LDEBIBGHCGD_EventRaidLobby.CAOGDCBPBAN");
		return 0;
	}
}
