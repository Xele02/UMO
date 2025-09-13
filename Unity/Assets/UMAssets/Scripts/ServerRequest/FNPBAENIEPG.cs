
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use FNPBAENIEPG_PurchaseAndSave", true)]
public class FNPBAENIEPG { }
public class FNPBAENIEPG_PurchaseAndSave : CACGCMBKHDI_Request
{
	public class PKNFMLJNKHA
	{
		public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Balances; // 0x8
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18
		public int MLGKDBJLNBM_DataStatus; // 0x20

		// RVA: 0x13E81F0 Offset: 0x13E81F0 VA: 0x13E81F0
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			BIOGKIEECGN_CreatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_CreatedAt];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			MLGKDBJLNBM_DataStatus = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
			EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_Balances];
			BBEPLKNMICJ_Balances = new List<MCKCJMLOAFP_CurrencyInfo>(d.HNBFOAJIIAL_Count);
			for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo data = new MCKCJMLOAFP_CurrencyInfo();
				data.DPKCOKLMFMK(d[i]);
				BBEPLKNMICJ_Balances.Add(data);
			}
		}
	}

	public long MCKEOKFMLAH; // 0x80
	public bool CLBFPFLNGKF; // 0x88
	public int AFKAGFOFAHM_ProductId; // 0x8C
	public int BPNPBJALGHM_Quantity; // 0x90
	public int _APHNELOFGAK_CurrencyId; // 0x94
	public int LGEKLPJFJEI_TotalCurrency; // 0x98
	public List<string> HHIHCJKLJFF; // 0x9C
	public string AHEFHIMGIBI_PlayerData; // 0xA0
	public bool CHDDDCCHJJH_Replace = true; // 0xA4

	public override bool BNCFONNOHFO { get { return !CLBFPFLNGKF; } } //0x13E7E90 NPLNAJFJPEE
	public override bool ICFMKEFJOIE { get { return !CLBFPFLNGKF; } } //0x13E7EA4 HOPDAAAEBBG
	public PKNFMLJNKHA NFEAMMJIMPG { get; set; } // 0xA8 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x13E7EB8 Offset: 0x13E7EB8 VA: 0x13E7EB8
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, int _AFKAGFOFAHM_ProductId, int _BPNPBJALGHM_Quantity, int _APHNELOFGAK_CurrencyId)
	{
		AHEFHIMGIBI_PlayerData = IDLHJIOMJBK.PBNINEMAOPB();
		CHDDDCCHJJH_Replace = !IDLHJIOMJBK.BLOCFLFHCFJ_Keep;
		HHIHCJKLJFF = IDLHJIOMJBK.KFGDPMNCCFO_NaespaceForSave;
		this.AFKAGFOFAHM_ProductId = _AFKAGFOFAHM_ProductId;
		this.BPNPBJALGHM_Quantity = _BPNPBJALGHM_Quantity;
		this._APHNELOFGAK_CurrencyId = _APHNELOFGAK_CurrencyId;
		MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
	}

	// RVA: 0x13E7F80 Offset: 0x13E7F80 VA: 0x13E7F80 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPayment.PurchaseAndSave(AFKAGFOFAHM_ProductId, BPNPBJALGHM_Quantity, _APHNELOFGAK_CurrencyId, HHIHCJKLJFF.ToArray(), AHEFHIMGIBI_PlayerData, CHDDDCCHJJH_Replace, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13E80C8 Offset: 0x13E80C8 VA: 0x13E80C8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		PJKLMCGEJMK.DALFMJFKCGJ = MCKEOKFMLAH;
		PKNFMLJNKHA r = new PKNFMLJNKHA();
		r.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG = r;
	}

	//// RVA: 0x13E84DC Offset: 0x13E84DC VA: 0x13E84DC Slot: 10
	//public override bool CPIIKMBBKAI() { }

	//// RVA: 0x13E8580 Offset: 0x13E8580 VA: 0x13E8580 Slot: 11
	//public override void CBEPCFJOJOI() { }

	// RVA: 0x13E873C Offset: 0x13E873C VA: 0x13E873C
	public void MJMAHKAKPCG(List<MCKCJMLOAFP_CurrencyInfo> EABDEAANPOE)
	{
		NFEAMMJIMPG = new PKNFMLJNKHA();
		NFEAMMJIMPG.BBEPLKNMICJ_Balances = EABDEAANPOE;
	}
}
