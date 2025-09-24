
using System.Collections.Generic;

[System.Obsolete("Use GBEFGAIGGHA_Shop", true)]
public class GBEFGAIGGHA { }
public class GBEFGAIGGHA_Shop : KLFDBFMNLBL_ServerSaveBlock
{
	public class DPGGLKKBNBJ
	{
		public long KLAPHOKNEDG_DateCrypted; // 0x8
		public int IBLOAFJJBOA; // 0x10
		public int IPINEGKBNLK; // 0x14
		public int FBGGEFFJJHB_xor; // 0x18

		public int DJJGPACGEMM_product_id { get { return IBLOAFJJBOA ^ FBGGEFFJJHB_xor; } set { IBLOAFJJBOA = value ^ FBGGEFFJJHB_xor; } } //0x1402898 LNKIAOKJIPL 0x1402C38 EOEFCENJMJG
		public int KMFLNILNPJD_Cnt { get { return IPINEGKBNLK ^ FBGGEFFJJHB_xor; } set { IPINEGKBNLK = value ^ FBGGEFFJJHB_xor; } } //0x14028A8 EJNACGPGJAI 0x1401DC8 PGAECLKCFEL
		public long BEBJKJKBOGH_date { get { return KLAPHOKNEDG_DateCrypted ^ FBGGEFFJJHB_xor; } set { KLAPHOKNEDG_DateCrypted = value ^ FBGGEFFJJHB_xor; } } //0x140200C DIAPHCJBPFD 0x1401DB4 IHAIKPNEEJE

		//// RVA: 0x14021D8 Offset: 0x14021D8 VA: 0x14021D8
		//public void LHPDDGIJKNB_Reset() { }

		//// RVA: 0x1403108 Offset: 0x1403108 VA: 0x1403108
		public bool AGBOGBEOFME(DPGGLKKBNBJ GPBJHKLFCEP)
		{
			if(DJJGPACGEMM_product_id != GPBJHKLFCEP.DJJGPACGEMM_product_id ||
				KMFLNILNPJD_Cnt != GPBJHKLFCEP.KMFLNILNPJD_Cnt ||
				BEBJKJKBOGH_date != GPBJHKLFCEP.BEBJKJKBOGH_date)
				return false;
			return true;
		}

		//// RVA: 0x1402E18 Offset: 0x1402E18 VA: 0x1402E18
		public void ODDIHGPONFL_Copy(DPGGLKKBNBJ GPBJHKLFCEP)
		{
			DJJGPACGEMM_product_id = GPBJHKLFCEP.DJJGPACGEMM_product_id;
			KMFLNILNPJD_Cnt = GPBJHKLFCEP.KMFLNILNPJD_Cnt;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
		}

		//// RVA: 0x14035F0 Offset: 0x14035F0 VA: 0x14035F0
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, GBEFGAIGGHA.DPGGLKKBNBJ _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }
	}

	private const int ECFEMKGFDCE = 2;
	public const int EPAOCPMNLNC = 6000;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<DPGGLKKBNBJ> ECMLOMPGMLC { get; private set; } // 0x24 ICOECAFDDGE OCJOHJOFLJH IGPAHLBHIMN
	public override bool DMICHEJIAJL { get { return true; } } // 0x1404394 NFKFOODCJJB

	// // RVA: 0x1401CB0 Offset: 0x1401CB0 VA: 0x1401CB0
	// public void HJDIPJKGCID() { }

	// // RVA: 0x1401DE0 Offset: 0x1401DE0 VA: 0x1401DE0
	public void LBLNLMGHLAG_UpdateTimedItems(BKPAPCMJKHE_Shop IFLGCDGOLOP_DbShop, long _JHNMKKNEENE_Time)
	{
		int num = 6000;
		if (IFLGCDGOLOP_DbShop.MHKCPJDNJKI_products.Count < 6000)
			num = IFLGCDGOLOP_DbShop.MHKCPJDNJKI_products.Count;
		for(int i = 0; i < num; i++)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbItem = IFLGCDGOLOP_DbShop.MHKCPJDNJKI_products[i];
			DPGGLKKBNBJ serverItem = ECMLOMPGMLC[i];
			if(dbItem.PPEGAKEIEGM_Enabled == 2)
			{
				if(serverItem.BEBJKJKBOGH_date < dbItem.KJBGCLPMLCG_OpenedAt || serverItem.BEBJKJKBOGH_date > dbItem.GJFPFFBAKGK_CloseAt)
				{
					serverItem.BEBJKJKBOGH_date = 0;
					serverItem.KMFLNILNPJD_Cnt = 0;
				}
			}
		}
	}

	// // RVA: 0x1402020 Offset: 0x1402020 VA: 0x1402020
	public GBEFGAIGGHA_Shop()
	{
		ECMLOMPGMLC = new List<DPGGLKKBNBJ>(6000);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x14020C4 Offset: 0x14020C4 VA: 0x14020C4 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		ECMLOMPGMLC.Clear();
		for(int i = 0; i < 6000; i++)
		{
			DPGGLKKBNBJ data = new DPGGLKKBNBJ();
			data.FBGGEFFJJHB_xor = 0x2a843;
			data.BEBJKJKBOGH_date = 0;
			data.DJJGPACGEMM_product_id = 0;
			data.KMFLNILNPJD_Cnt = 0;
			ECMLOMPGMLC.Add(data);
		}
	}

	// // RVA: 0x14021FC Offset: 0x14021FC VA: 0x14021FC Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < ECMLOMPGMLC.Count; i++)
		{
			if(ECMLOMPGMLC[i].BEBJKJKBOGH_date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = ECMLOMPGMLC[i].DJJGPACGEMM_product_id;
				data2[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = ECMLOMPGMLC[i].KMFLNILNPJD_Cnt;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = ECMLOMPGMLC[i].BEBJKJKBOGH_date;
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x14028B8 Offset: 0x14028B8 VA: 0x14028B8 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				BKPAPCMJKHE_Shop shopDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
				for(int i = 0; i < shopDb.MHKCPJDNJKI_products.Count; i++)
				{
					string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						DPGGLKKBNBJ data = ECMLOMPGMLC[i];
						data.DJJGPACGEMM_product_id = i + 1;
						data.KMFLNILNPJD_Cnt = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
						data.BEBJKJKBOGH_date = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1402C48 Offset: 0x1402C48 VA: 0x1402C48 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GBEFGAIGGHA_Shop s = GPBJHKLFCEP as GBEFGAIGGHA_Shop;
		for(int i = 0; i < ECMLOMPGMLC.Count; i++)
		{
			ECMLOMPGMLC[i].ODDIHGPONFL_Copy(s.ECMLOMPGMLC[i]);
		}
	}

	// // RVA: 0x1402EC0 Offset: 0x1402EC0 VA: 0x1402EC0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		GBEFGAIGGHA_Shop other = GPBJHKLFCEP as GBEFGAIGGHA_Shop;
		if(ECMLOMPGMLC.Count != other.ECMLOMPGMLC.Count)
			return false;
		for(int i = 0; i < ECMLOMPGMLC.Count; i++)
		{
			if(!ECMLOMPGMLC[i].AGBOGBEOFME(other.ECMLOMPGMLC[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x14031E4 Offset: 0x14031E4 VA: 0x14031E4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
