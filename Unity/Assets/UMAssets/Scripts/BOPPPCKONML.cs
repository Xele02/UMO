using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XeSys;

public class BOPPPCKONML
{
	public const int HIPKCMPGCDK = 50;
	public const int ECFEMKGFDCE = 1;
	public const int MMAMNHPKOPH = 5;
	private static string PLHNDPDKNLB = "inventory_record"; // 0x0
	public long KAKFEGGEKLB; // 0x8
	public long JJJEFNCIFJN; // 0x10
	public int AGPKGMFOJHC; // 0x18
	public int ECPCDCKJOPC; // 0x1C
	private bool FLPHABPKNGM; // 0x20
	private bool LCKPHJINHPH; // 0x21
	private static List<string> HMJBJGFPEPG = new List<string>() { "inventory_record" }; // 0x4
	public List<GJDFHLBONOL> PJJFEAHIPGL = new List<GJDFHLBONOL>(); // 0x24
	public List<GJDFHLBONOL> LCEMDBMFMFK = new List<GJDFHLBONOL>(); // 0x28

	//// RVA: 0x19D11B4 Offset: 0x19D11B4 VA: 0x19D11B4
	public void LHPDDGIJKNB()
	{
		FLPHABPKNGM = false;
		LCKPHJINHPH = false;
		PJJFEAHIPGL.Clear();
		for(int i = 0; i < 50; i++)
		{
			GJDFHLBONOL data = new GJDFHLBONOL();
			data.LJGOOOMOMMA_Message = "";
			data.HAAJGNCFNJM_ItemName = "";
			PJJFEAHIPGL.Add(data);
		}
		LCEMDBMFMFK.Clear();
		for(int i = 0; i < 50; i++)
		{
			GJDFHLBONOL data = new GJDFHLBONOL();
			data.LJGOOOMOMMA_Message = "";
			data.HAAJGNCFNJM_ItemName = "";
			LCEMDBMFMFK.Add(data);
		}
	}

	//// RVA: 0x19D13D0 Offset: 0x19D13D0 VA: 0x19D13D0
	public void PCODDPDFLHK(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		LHPDDGIJKNB();
		NAIJIFAJGGK_RequestLoadPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
		req.HHIHCJKLJFF_BlockToRequest = HMJBJGFPEPG;
		req.IJMPLDBGMHC_OnDataReceived = IIEMACPEEBJ;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x18ED7A0
			long l;
			List<GJDFHLBONOL> l2 = LIIBNLMMMHK(out l);
			if (GDELKANOPBH() >= l)
			{
				BHFHGFKBOHH();
			}
			else
			{
				for(int i = 0; i < 50; i++)
				{
					PJJFEAHIPGL[i].ODDIHGPONFL(l2[i]);
				}
				HJMKBCFJOOH(BHFHGFKBOHH, AOCANKOMKFG);
			}
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x18ED964
		};
	}

	//// RVA: 0x19D16A0 Offset: 0x19D16A0 VA: 0x19D16A0
	private bool IIEMACPEEBJ(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH)
	{
		LHPDDGIJKNB();
		EDOHBJAPLPF_JsonData data = NMICBJDPLOH[PLHNDPDKNLB];
		if (!data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
			LCKPHJINHPH = true;
		if (!data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id))
			LCKPHJINHPH = true;
		KAKFEGGEKLB = JsonUtil.GetInt(data, AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id, 0);
		JJJEFNCIFJN = KAKFEGGEKLB;
		AGPKGMFOJHC = JsonUtil.GetInt(data, AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev, 0);
		ECPCDCKJOPC = AGPKGMFOJHC;
		if(data.BBAJPINMOEP_Contains(PLHNDPDKNLB))
		{
			EDOHBJAPLPF_JsonData dataList = data[PLHNDPDKNLB];
			for(int i = 0; i < dataList.HNBFOAJIIAL_Count; i++)
			{
				if (i < 50)
				{
					EDOHBJAPLPF_JsonData d = dataList[i];
					if (!d.BBAJPINMOEP_Contains("m"))
						LCKPHJINHPH = true;
					if (d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm))
						LCKPHJINHPH = true;
					if (d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt))
						LCKPHJINHPH = true;
					if (d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date))
						LCKPHJINHPH = true;
					if (d.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FPOMEEJFBIG_odr))
						LCKPHJINHPH = true;
					PJJFEAHIPGL[i].LJGOOOMOMMA_Message = JsonUtil.GetString(d, "m", "");
					PJJFEAHIPGL[i].JJBGOIMEIPF_ItemFullId = JsonUtil.GetInt(d, AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm, 0);
					PJJFEAHIPGL[i].MBJIFDBEDAC_ItemCount = JsonUtil.GetInt(d, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0);
					PJJFEAHIPGL[i].LNDEFMALKAN_ReceivedAt = JsonUtil.GetLong(d, AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0);
					PJJFEAHIPGL[i].EILKGEADKGH_Order = JsonUtil.GetLong(d, AFEHLCGHAEE_Strings.FPOMEEJFBIG_odr, 0);
					LCEMDBMFMFK[i].ODDIHGPONFL(PJJFEAHIPGL[i]);
				}
				else
					LCKPHJINHPH = true;
			}
		}
		return true;
	}

	//// RVA: 0x19D1E44 Offset: 0x19D1E44 VA: 0x19D1E44
	private EDOHBJAPLPF_JsonData AHGNJOONPHI(GJDFHLBONOL AIMLPJOGPID)
	{
		EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
		res["m"] = AIMLPJOGPID.LJGOOOMOMMA_Message;
		res[AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm] = AIMLPJOGPID.JJBGOIMEIPF_ItemFullId;
		res[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = AIMLPJOGPID.MBJIFDBEDAC_ItemCount;
		res[AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date] = AIMLPJOGPID.LNDEFMALKAN_ReceivedAt;
		res[AFEHLCGHAEE_Strings.FPOMEEJFBIG_odr] = AIMLPJOGPID.EILKGEADKGH_Order;
		return res;
	}

	//// RVA: 0x19D20A0 Offset: 0x19D20A0 VA: 0x19D20A0
	private string OKJPIBHMKMJ(out bool BLOCFLFHCFJ, long FAEBIDLDKPJ)
	{
		int a1 = 0;
		for(int i = 0; i < 50; i++)
		{
			if (PJJFEAHIPGL[i].EILKGEADKGH_Order != LCEMDBMFMFK[i].EILKGEADKGH_Order)
				a1++;
		}
		KAKFEGGEKLB = FAEBIDLDKPJ;
		if(false)//if(!FLPHABPKNGM && a1 < 5 && !LCKPHJINHPH) UMO : save all always, system don't work for partial update
		{
			BLOCFLFHCFJ = true;
			BHBONAHFKHD d = new BHBONAHFKHD();
			for(int i = 0; i < PJJFEAHIPGL.Count; i++)
			{
				if (PJJFEAHIPGL[i].EILKGEADKGH_Order != LCEMDBMFMFK[i].EILKGEADKGH_Order)
				{
					d.OJLJAHAGBLK(PLHNDPDKNLB, AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + PLHNDPDKNLB + AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + i, AHGNJOONPHI(PJJFEAHIPGL[i]));
				}
			}
			d.OJLJAHAGBLK(PLHNDPDKNLB, AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id, (EDOHBJAPLPF_JsonData)KAKFEGGEKLB);
			if(ECPCDCKJOPC != 1)
			{
				d.OJLJAHAGBLK(PLHNDPDKNLB, AFEHLCGHAEE_Strings.FAIOPNOJIBF_Slash + AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev, 1);
			}
			return d.MGPEIGDOMPH.EJCOJCGIBNG_ToJson();
		}
		else
		{
			BLOCFLFHCFJ = false;
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < PJJFEAHIPGL.Count; i++)
			{
				data.Add(AHGNJOONPHI(PJJFEAHIPGL[i]));
			}
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 1;
			res[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = KAKFEGGEKLB;
			res[PLHNDPDKNLB] = data;
			EDOHBJAPLPF_JsonData res2 = new EDOHBJAPLPF_JsonData();
			res2[PLHNDPDKNLB] = res;
			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(res2, writer);
			return writer.ToString();
		}
	}

	//// RVA: 0x19D2A30 Offset: 0x19D2A30 VA: 0x19D2A30
	private int KCKOKCHMIBA()
	{
		if (PJJFEAHIPGL.Count == 0)
			return 0;
		long max = long.MaxValue;
		int res = 0;
		for(int i = 0; i < PJJFEAHIPGL.Count; i++)
		{
			if (PJJFEAHIPGL[i].EILKGEADKGH_Order == 0)
				return i;
			if(PJJFEAHIPGL[i].EILKGEADKGH_Order < max)
			{
				max = PJJFEAHIPGL[i].EILKGEADKGH_Order;
				res = i;
			}
		}
		return res;
	}

	//// RVA: 0x19D2BF8 Offset: 0x19D2BF8 VA: 0x19D2BF8
	private long GDELKANOPBH()
	{
		if (PJJFEAHIPGL.Count == 0)
			return 0;
		long res = 0;
		for(int i = 0; i < PJJFEAHIPGL.Count; i++)
		{
			if(res < PJJFEAHIPGL[i].EILKGEADKGH_Order)
			{
				res = PJJFEAHIPGL[i].EILKGEADKGH_Order;
			}
		}
		return res;
	}

	//// RVA: 0x19D2D50 Offset: 0x19D2D50 VA: 0x19D2D50
	public void ANIJHEBLMGB(GJDFHLBONOL CCBEKGNDDBE)
	{
		int idx = KCKOKCHMIBA();
		long order = GDELKANOPBH();
		PJJFEAHIPGL[idx].ODDIHGPONFL(CCBEKGNDDBE);
		PJJFEAHIPGL[idx].LNDEFMALKAN_ReceivedAt = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		PJJFEAHIPGL[idx].EILKGEADKGH_Order = order;
	}

	//// RVA: 0x19D2F50 Offset: 0x19D2F50 VA: 0x19D2F50
	public void HJMKBCFJOOH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		bool b = false;
		for(int i = 0; i < 50; i++)
		{
			if(PJJFEAHIPGL[i].EILKGEADKGH_Order != LCEMDBMFMFK[i].EILKGEADKGH_Order)
			{
				b = true;
				break;
			}
		}
		if(!b)
		{
			if(ECPCDCKJOPC == 1)
			{
				BHFHGFKBOHH();
				return;
			}
		}
		AGPKGMFOJHC = 1;
		GGKHIHFPKDH_SavePlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
		req.HHIHCJKLJFF_Names = HMJBJGFPEPG;
		req.NBFDEFGFLPJ = (SakashoErrorId FMEMECBIDIB) =>
		{
			//0x18ED790
			return true;
		};
		bool isPartial = false;
		req.AHEFHIMGIBI_PlayerData = OKJPIBHMKMJ(out isPartial, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MCKEOKFMLAH_SaveId + 1);
		req.CHDDDCCHJJH_Replace = !isPartial;
		req.MCKEOKFMLAH_SaveId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MCKEOKFMLAH_SaveId + 1;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x18ED998
			for(int i = 0; i < 50; i++)
			{
				LCEMDBMFMFK[i].ODDIHGPONFL(PJJFEAHIPGL[i]);
			}
			ECPCDCKJOPC = AGPKGMFOJHC;
			JJJEFNCIFJN = KAKFEGGEKLB;
			FLPHABPKNGM = true;
			LCKPHJINHPH = false;
			BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x18EDB7C
			AOCANKOMKFG();
		};
	}

	//// RVA: 0x19D3498 Offset: 0x19D3498 VA: 0x19D3498
	private string HIOMFHINAAH()
	{
		return string.Concat(new object[4]
		{
			Application.persistentDataPath, "/60/", NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId, ".bin"
		});
	}

	//// RVA: 0x19D371C Offset: 0x19D371C VA: 0x19D371C
	public List<GJDFHLBONOL> LIIBNLMMMHK(out long CJBHNAPHONN)
	{
		List<GJDFHLBONOL> res = new List<GJDFHLBONOL>();
		string path = HIOMFHINAAH();
		if(!File.Exists(path))
		{
			CJBHNAPHONN = 0;
			return null;
		}
		else
		{
			byte[] bytes = File.ReadAllBytes(path);
			for(int i = 0; i < bytes.Length; i++)
			{
				bytes[i] ^= 0x75;
			}
			string str = Encoding.UTF8.GetString(bytes);
			EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(str);
			EDOHBJAPLPF_JsonData l = data["list"];
			CJBHNAPHONN = 0;
			for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
			{
				GJDFHLBONOL d = new GJDFHLBONOL();
				d.LJGOOOMOMMA_Message = JsonUtil.GetString(l[i], "m", "");
				d.JJBGOIMEIPF_ItemFullId = JsonUtil.GetInt(l[i], AFEHLCGHAEE_Strings.AIHOJKFNEEN_itm, 0);
				d.MBJIFDBEDAC_ItemCount = JsonUtil.GetInt(l[i], AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0);
				d.LNDEFMALKAN_ReceivedAt = JsonUtil.GetLong(l[i], AFEHLCGHAEE_Strings.BEBJKJKBOGH_Date, 0);
				d.EILKGEADKGH_Order = JsonUtil.GetLong(l[i], AFEHLCGHAEE_Strings.FPOMEEJFBIG_odr, 0);
				if ((CJBHNAPHONN - 1) < d.EILKGEADKGH_Order)
					CJBHNAPHONN = d.EILKGEADKGH_Order + 1;
				res.Add(d);
			}
			return res;
		}
	}

	//// RVA: 0x19D3CD4 Offset: 0x19D3CD4 VA: 0x19D3CD4
	public void EAKEHFCEKCF_SaveFile()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < PJJFEAHIPGL.Count; i++)
		{
			data.Add(AHGNJOONPHI(PJJFEAHIPGL[i]));
		}
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2["list"] = data;
		string path = HIOMFHINAAH();
		string dir = Path.GetDirectoryName(path);
		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		byte[] bytes = Encoding.UTF8.GetBytes(data2.EJCOJCGIBNG_ToJson());
		for(int i = 0; i < bytes.Length; i++)
		{
			bytes[i] ^= 0x75;
		}
		File.WriteAllBytes(path, bytes);
	}

	//// RVA: 0x19D409C Offset: 0x19D409C VA: 0x19D409C
	//public void EOKDIMDKHKG() { }
}
