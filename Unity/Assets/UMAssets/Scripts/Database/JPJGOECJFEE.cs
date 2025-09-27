
using System.Collections.Generic;

[System.Obsolete("Use JPJGOECJFEE_EventGoDivaRanking", true)]
public class JPJGOECJFEE { }
public class JPJGOECJFEE_EventGoDivaRanking : DIHHCBACKGG_DbSection
{
	public class IKHDAADBIAL
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
		public List<string> MPCAGEPEJJJ_Key = new List<string>(); // 0x48
		public List<int> JHPCPNJJHLI_RankingThreshold = new List<int>(); // 0x4C

		//// RVA: 0x1BA7B7C Offset: 0x1BA7B7C VA: 0x1BA7B7C
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
			MPCAGEPEJJJ_Key.Clear();
			JHPCPNJJHLI_RankingThreshold.Clear();
		}

		//// RVA: 0x1BA84F4 Offset: 0x1BA84F4 VA: 0x1BA84F4
		//public uint CAOGDCBPBAN() { }
	}

	public IKHDAADBIAL NGHKJOEDLIP_Settings = new IKHDAADBIAL(); // 0x20
	private List<NNJFKLBPBNK_SecureString> IFBBNEGGCIH; // 0x2C
	private List<CEBFFLDKAEC_SecureInt> JNJAOACIGOC; // 0x30

	public Dictionary<string, NNJFKLBPBNK_SecureString> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x24 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x28 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x1BA762C Offset: 0x1BA762C VA: 0x1BA762C
	//public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval) { }

	//// RVA: 0x1BA7710 Offset: 0x1BA7710 VA: 0x1BA7710
	//public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval) { }

	// RVA: 0x1BA77F4 Offset: 0x1BA77F4 VA: 0x1BA77F4
	public JPJGOECJFEE_EventGoDivaRanking()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		JNJAOACIGOC = new List<CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, NNJFKLBPBNK_SecureString>();
		IFBBNEGGCIH = new List<NNJFKLBPBNK_SecureString>();
		LMHMIIKCGPE = 33;
	}

	// RVA: 0x1BA7A64 Offset: 0x1BA7A64 VA: 0x1BA7A64 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		NGHKJOEDLIP_Settings.LHPDDGIJKNB_Reset();
		FJOEBCMGDMI_m_stringParam.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		JNJAOACIGOC.Clear();
		IFBBNEGGCIH.Clear();
	}

	// RVA: 0x1BA7C58 Offset: 0x1BA7C58 VA: 0x1BA7C58 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		CEGLELHPKBO parser = CEGLELHPKBO.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DGKKMKLCEDF(parser);
		{
			KAGMCEBLHAI[] array = parser.BHGDNGHDDAC;
			for(int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
				JNJAOACIGOC.Add(data);
			}
		}
		{
			KBHIGPCGLKH[] array = parser.MHGMDJNOLMI;
			for(int i = 0; i < array.Length; i++)
			{
				NNJFKLBPBNK_SecureString data = new NNJFKLBPBNK_SecureString();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC_key, data);
				IFBBNEGGCIH.Add(data);
			}
		}
		return true;
	}

	// RVA: 0x1BA84BC Offset: 0x1BA84BC VA: 0x1BA84BC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0x1BA7F78 Offset: 0x1BA7F78 VA: 0x1BA7F78
	private bool DGKKMKLCEDF(CEGLELHPKBO JMHECKKKMLK)
	{
		HMNCNMGCIMM pData = JMHECKKKMLK.HMBHNLCFDIH;
		NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId = (int)pData.OBGBAOLONDD_UniqueId;
		NGHKJOEDLIP_Settings.OPFGFINHFCE_name = pData.OPFGFINHFCE_name;
		NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName = pData.HEDAGCNPHGD_RankingName;
		NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api = pData.OCGFKMHNEOF_name_for_api;
		NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart = pData.BONDDBOFBND_RankingStart;
		NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd = pData.HPNOGLIFJOP_RankingEnd;
		NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2 = pData.LNFKGHNHJKE_RankingEnd2;
		NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart = pData.JGMDAOACOJF_RewardStart;
		NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd = pData.IDDBFFBPNGI_RewardEnd;
		NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 = pData.KNLGKBBIBOH_RewardEnd2;
		NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Clear();
		for(int i = 0; i < pData.MPCAGEPEJJJ_Key.Length; i++)
		{
			NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Add(pData.MPCAGEPEJJJ_Key[i]);
		}
		for(int i = 0; i < pData.JHPCPNJJHLI_RankingThreshold.Length; i++)
		{
			if(pData.JHPCPNJJHLI_RankingThreshold[i] < 1001)
			{
				NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold.Add(pData.JHPCPNJJHLI_RankingThreshold[i]);
			}
		}
		return true;
	}

	// RVA: 0x1BA84C4 Offset: 0x1BA84C4 VA: 0x1BA84C4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JPJGOECJFEE_EventGoDivaRanking.CAOGDCBPBAN");
		return 0;
	}
}
