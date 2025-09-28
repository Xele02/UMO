
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use FNPBAENIEPG_PurchaseAndSave", true)]
public class FNPBAENIEPG { }
public class FNPBAENIEPG_PurchaseAndSave : CACGCMBKHDI_Request
{
	public class PKNFMLJNKHA
	{
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_balances; // 0x8
		public long BIOGKIEECGN_created_at; // 0x10
		public long IFNLEKOILPM_updated_at; // 0x18
		public int MLGKDBJLNBM_data_status; // 0x20

		// RVA: 0x13E81F0 Offset: 0x13E81F0 VA: 0x13E81F0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			BIOGKIEECGN_created_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_updated_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			MLGKDBJLNBM_data_status = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
			EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
			BBEPLKNMICJ_balances = new List<MCKCJMLOAFP_CurrencyInfo>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
				data.DPKCOKLMFMK(d[i]);
				BBEPLKNMICJ_balances.Add(data);
			}
		}
	}

	public long MCKEOKFMLAH_SaveId; // 0x80
	public bool CLBFPFLNGKF; // 0x88
	public int AFKAGFOFAHM_ProductId; // 0x8C
	public int BPNPBJALGHM_quantity; // 0x90
	public int _APHNELOFGAK_CurrencyId; // 0x94
	public int LGEKLPJFJEI_TotalCurrency; // 0x98
	public List<string> HHIHCJKLJFF_Names; // 0x9C
	public string AHEFHIMGIBI_PlayerData; // 0xA0
	public bool CHDDDCCHJJH_replace = true; // 0xA4

	public override bool BNCFONNOHFO { get { return !CLBFPFLNGKF; } } //0x13E7E90 NPLNAJFJPEE
	public override bool ICFMKEFJOIE { get { return !CLBFPFLNGKF; } } //0x13E7EA4 HOPDAAAEBBG
	public PKNFMLJNKHA NFEAMMJIMPG_Result { get; set; } // 0xA8 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x13E7EB8 Offset: 0x13E7EB8 VA: 0x13E7EB8
	public void DOMFHDPMCCO_Init(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE _IDLHJIOMJBK_data, int _AFKAGFOFAHM_ProductId, int _BPNPBJALGHM_quantity, int _APHNELOFGAK_CurrencyId)
	{
		AHEFHIMGIBI_PlayerData = _IDLHJIOMJBK_data.PBNINEMAOPB();
		CHDDDCCHJJH_replace = !_IDLHJIOMJBK_data.BLOCFLFHCFJ_Keep;
		HHIHCJKLJFF_Names = _IDLHJIOMJBK_data.KFGDPMNCCFO_NaespaceForSave;
		this.AFKAGFOFAHM_ProductId = _AFKAGFOFAHM_ProductId;
		this.BPNPBJALGHM_quantity = _BPNPBJALGHM_quantity;
		this._APHNELOFGAK_CurrencyId = _APHNELOFGAK_CurrencyId;
		MCKEOKFMLAH_SaveId = _IDLHJIOMJBK_data.MCKEOKFMLAH_SaveId;
	}

	// RVA: 0x13E7F80 Offset: 0x13E7F80 VA: 0x13E7F80 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPayment.PurchaseAndSave(AFKAGFOFAHM_ProductId, BPNPBJALGHM_quantity, _APHNELOFGAK_CurrencyId, HHIHCJKLJFF_Names.ToArray(), AHEFHIMGIBI_PlayerData, CHDDDCCHJJH_replace, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13E80C8 Offset: 0x13E80C8 VA: 0x13E80C8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		PJKLMCGEJMK.DALFMJFKCGJ = MCKEOKFMLAH_SaveId;
		PKNFMLJNKHA r = new PKNFMLJNKHA();
		r.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG_Result = r;
	}

	//// RVA: 0x13E84DC Offset: 0x13E84DC VA: 0x13E84DC Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0x13E8580 Offset: 0x13E8580 VA: 0x13E8580 Slot: 11
	//public override void CBEPCFJOJOI() { }

	// RVA: 0x13E873C Offset: 0x13E873C VA: 0x13E873C
	public void MJMAHKAKPCG(List<MCKCJMLOAFP_CurrencyInfo> EABDEAANPOE)
	{
		NFEAMMJIMPG_Result = new PKNFMLJNKHA();
		NFEAMMJIMPG_Result.BBEPLKNMICJ_balances = EABDEAANPOE;
	}
}
