using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HPBPIOPPDCB_Diva", true)]
public class HPBPIOPPDCB { }
[UMOClass(ReaderClass = "MHKHMCAPDKK")]
public class HPBPIOPPDCB_Diva : DIHHCBACKGG_DbSection
{
	public static bool DINNDBNPNFK; // 0x0
	public const int NLPCOAKLBAN = 0;
	public const int AGBLDFIFLBJ = 10;
	public const int DNLFNEFLNED = 200;
	[UMOMember(Desc = "Maximum levels for the divas", Name = "Maximum levels")]
	public int AGNCAAFGLBE_MaxLevels; // 0x20
	[UMOMember(ReaderMember = "INPCGKFIMIG")]
	public List<BJPLLEBHAGO_DivaInfo> CDENCMNHNGA_table = new List<BJPLLEBHAGO_DivaInfo>(10); // 0x24

	// // RVA: 0x160846C Offset: 0x160846C VA: 0x160846C
	public bool BEEGJHCDHJB_IsDivaAvaiable(int _AHHJLDLAPAN_DivaId)
	{
		if(_AHHJLDLAPAN_DivaId > 0 && _AHHJLDLAPAN_DivaId <= CDENCMNHNGA_table.Count)
		{
			return CDENCMNHNGA_table[_AHHJLDLAPAN_DivaId - 1].PPEGAKEIEGM_Enabled == 2;
		}
		return false;
	}

	// // RVA: 0x1608560 Offset: 0x1608560 VA: 0x1608560
	public BJPLLEBHAGO_DivaInfo GCINIJEMHFK_GetInfo(int _AHHJLDLAPAN_DivaId)
    {
        if(_AHHJLDLAPAN_DivaId != 0)
		{
			return CDENCMNHNGA_table[_AHHJLDLAPAN_DivaId - 1];
		}
		return null;
    }

	// // RVA: 0x16085F0 Offset: 0x16085F0 VA: 0x16085F0
	public HPBPIOPPDCB_Diva()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 19;
    }

	// // RVA: 0x16086E8 Offset: 0x16086E8 VA: 0x16086E8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CDENCMNHNGA_table.Clear();
		for(int i = 0; i < 10; i++)
		{
			BJPLLEBHAGO_DivaInfo data = new BJPLLEBHAGO_DivaInfo();
			data.AHHJLDLAPAN_DivaId = (sbyte)i;
			for(int j = 0; j < 200; j++)
			{
				EPPOHFLMDBC_DivaStats data2 = new EPPOHFLMDBC_DivaStats();
				data2.DOMFHDPMCCO_Init(j, 0x7517748f, 0, 0, 0, 0, 0, 0);
				data.CMCKNKKCNDK_status.Add(data2);
			}
			CDENCMNHNGA_table.Add(data);
		}
    }

	private static int[] oldDivaLevels = new int[10]
	{
		60, 55, 50, 50, 50, 60, 50, 50, 50, 60
	};

	// // RVA: 0x16088BC Offset: 0x16088BC VA: 0x16088BC Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		long time = Utility.GetCurrentUnixTime();
		MHKHMCAPDKK reader = MHKHMCAPDKK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MALFJMBMCLG[] array = reader.INPCGKFIMIG;
		if (array.Length < 11)
		{
			for(int i = 0; i != array.Length; i++)
			{
				long val2 = time * 0x96a + 2;
				BJPLLEBHAGO_DivaInfo data = CDENCMNHNGA_table[i];
				data.AHHJLDLAPAN_DivaId = (sbyte)array[i].PPFNGGCBJKC_id;
				data.AIHCEGFANAM_SerieAttr = (sbyte)array[i].JPFMJHLCMJL_sa;
				data.IDDHKOEFJFB_BodyId = (sbyte)array[i].JIBNPJCIALH_body;
				data.FPMGHDKACOF_PersonalityId = (sbyte)array[i].OKADDOIJGNB_ps;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
				data.DOAJJALOKLI_Month = (sbyte)array[i].KLCMKLPIDDJ_Month;
				data.PKNONBBKCCP_Day = (sbyte)array[i].BAOFEFFADPD_day;
				data.LIOGKHIGJKN_FreeMusicId = (ushort)array[i].LIOGKHIGJKN;
				data.CMBCBNEODPD_HomeBgId = (ushort)array[i].CMBCBNEODPD;

				EPPOHFLMDBC_DivaStats data2 = new EPPOHFLMDBC_DivaStats();
				// UMO, Restore old diva life stat (not end game 9999)
				data2.DOMFHDPMCCO_Init(0, (int)val2, (short)/*array[i].DFEDIAPLFHN.BCCOMAODPJI_hp*/oldDivaLevels[i], (short)array[i].DFEDIAPLFHN.LJELGFAFGAB_so, (short)array[i].DFEDIAPLFHN.KNEDJFLCCLN_vo,
						(short)array[i].DFEDIAPLFHN.MBAMIOJNGBD_ch, (short)array[i].DFEDIAPLFHN.ADLGKMBIPCA_fd, (short)array[i].DFEDIAPLFHN.PIPCIMIALOO_sp);
				data.CMCKNKKCNDK_status[0].ODDIHGPONFL_Copy(data2);
				val2 = val2 * 0xb + 3;
				AGNCAAFGLBE_MaxLevels = array[i].DFEDIAPLFHN.OEOIHIIIMCK_add.Length / 2;
				for(int k = 0, j = 1; j <= AGNCAAFGLBE_MaxLevels; j++, k+=2)
				{
					data2.ANAJIAENLNB_lv = j;
					data2.ANIJHEBLMGB_AddStat((int)array[i].DFEDIAPLFHN.OEOIHIIIMCK_add[k], (short)array[i].DFEDIAPLFHN.OEOIHIIIMCK_add[k+1]);
					data.CMCKNKKCNDK_status[j].FBGGEFFJJHB_xor = (int)val2;
					data.CMCKNKKCNDK_status[j].ODDIHGPONFL_Copy(data2);
					val2 = val2 * 0xb;
				}
			}
			return true;
		}
		HDIDJNCGICK_LoadError = "\"diva\" table overflow";
		return false;
    }

	// // RVA: 0x16093A0 Offset: 0x16093A0 VA: 0x16093A0 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	// // RVA: 0x16093A8 Offset: 0x16093A8 VA: 0x16093A8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HPBPIOPPDCB_Diva.CAOGDCBPBAN");
		return 0;
	}

	public EDOHBJAPLPF_JsonData Serialize()
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			BJPLLEBHAGO_DivaInfo data = CDENCMNHNGA_table[i];
			EDOHBJAPLPF_JsonData jsonData = new EDOHBJAPLPF_JsonData();
			jsonData["divaId"] = data.AHHJLDLAPAN_DivaId;
			jsonData["attr"] = data.AIHCEGFANAM_SerieAttr;
			jsonData["bodyId"] = data.IDDHKOEFJFB_BodyId;
			jsonData["personalityId"] = data.FPMGHDKACOF_PersonalityId;
			jsonData["enabled"] = data.PPEGAKEIEGM_Enabled;
			jsonData["month"] = data.DOAJJALOKLI_Month;
			jsonData["day"] = data.PKNONBBKCCP_Day;
			jsonData["freeMusicId"] = data.LIOGKHIGJKN_FreeMusicId;
			jsonData["HomeBgId"] = data.CMBCBNEODPD_HomeBgId;

			jsonData["statsByLevels"] = new EDOHBJAPLPF_JsonData();
			jsonData["statsByLevels"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < AGNCAAFGLBE_MaxLevels; j++)
			{
				EDOHBJAPLPF_JsonData jsonData2 = new EDOHBJAPLPF_JsonData();
				jsonData2["level"] = data.CMCKNKKCNDK_status[j].ANAJIAENLNB_lv;
				jsonData2["life"] = data.CMCKNKKCNDK_status[j].HFIDCMNFBJG_Life;
				jsonData2["soul"] = data.CMCKNKKCNDK_status[j].PFJCOCPKABN_Soul;
				jsonData2["vocal"] = data.CMCKNKKCNDK_status[j].JFJDLEMNKFE_Vocal;
				jsonData2["charm"] = data.CMCKNKKCNDK_status[j].GDOLPGBLMEA_Charm;
				jsonData2["fold"] = data.CMCKNKKCNDK_status[j].ONDFNOOICLE_Fold;
				jsonData2["support"] = data.CMCKNKKCNDK_status[j].HCFOMFDPGEC_Support;
				jsonData["statsByLevels"].Add(jsonData2);
			}
			res.Add(jsonData);
		}

		return res;
	}
}
