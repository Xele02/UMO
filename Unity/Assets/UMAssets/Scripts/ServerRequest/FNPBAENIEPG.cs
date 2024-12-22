
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
			BIOGKIEECGN_CreatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
			MLGKDBJLNBM_DataStatus = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MLGKDBJLNBM_data_status];
			EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
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
	public int AFKAGFOFAHM; // 0x8C
	public int BPNPBJALGHM; // 0x90
	public int APHNELOFGAK; // 0x94
	public int LGEKLPJFJEI_TotalCurrency; // 0x98
	public List<string> HHIHCJKLJFF; // 0x9C
	public string AHEFHIMGIBI; // 0xA0
	public bool CHDDDCCHJJH = true; // 0xA4

	public override bool BNCFONNOHFO { get { return !CLBFPFLNGKF; } } //0x13E7E90 NPLNAJFJPEE
	public override bool ICFMKEFJOIE { get { return !CLBFPFLNGKF; } } //0x13E7EA4 HOPDAAAEBBG
	public PKNFMLJNKHA NFEAMMJIMPG { get; set; } // 0xA8 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	//// RVA: 0x13E7EB8 Offset: 0x13E7EB8 VA: 0x13E7EB8
	public void DOMFHDPMCCO(BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IDLHJIOMJBK, int AFKAGFOFAHM, int BPNPBJALGHM, int APHNELOFGAK)
	{
		AHEFHIMGIBI = IDLHJIOMJBK.PBNINEMAOPB();
		CHDDDCCHJJH = !IDLHJIOMJBK.BLOCFLFHCFJ;
		HHIHCJKLJFF = IDLHJIOMJBK.KFGDPMNCCFO;
		this.AFKAGFOFAHM = AFKAGFOFAHM;
		this.BPNPBJALGHM = BPNPBJALGHM;
		this.APHNELOFGAK = APHNELOFGAK;
		MCKEOKFMLAH = IDLHJIOMJBK.MCKEOKFMLAH;
	}

	// RVA: 0x13E7F80 Offset: 0x13E7F80 VA: 0x13E7F80 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPayment.PurchaseAndSave(AFKAGFOFAHM, BPNPBJALGHM, APHNELOFGAK, HHIHCJKLJFF.ToArray(), AHEFHIMGIBI, CHDDDCCHJJH, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13E80C8 Offset: 0x13E80C8 VA: 0x13E80C8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
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
