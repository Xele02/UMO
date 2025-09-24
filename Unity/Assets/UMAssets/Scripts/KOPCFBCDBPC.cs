
using System.Collections.Generic;
using XeSys;

public class KOPCFBCDBPC
{
	private const long BHEHGCHGBDG = 0x5a7d5afa35ac5a5a;
	public string OPFGFINHFCE_name; // 0x8
	public string KLMPFGOCBHC_description; // 0xC
	public string FJGCDPLCIAK_unique_key; // 0x10
	public NABANOOIECF LKPHIGAFJKD_virtual_currency; // 0x14
	public long JJLCCDHHOKK_OpenAtCrypted = 0x5a7d5afa35ac5a5a; // 0x18
	public long JLFFBIOJBAO_CloseAtCrypted = 0x5a7d5afa35ac5a5a; // 0x20
	public List<MMNNAPPLHFM> BMFEGOMNECF_steps; // 0x28
	public IAPIDHGIEED LKHAAGIJEPG_player_status; // 0x2C

	public long KBFOIECIADN_opened_at { get { return JJLCCDHHOKK_OpenAtCrypted ^ BHEHGCHGBDG; } set { JJLCCDHHOKK_OpenAtCrypted = value ^ BHEHGCHGBDG; } } //0x11323B8 NAIEFPFHLJM 0x11323D8 BMLJOGEMFBH
	public long EGBOHDFBAPB_closed_at { get { return JLFFBIOJBAO_CloseAtCrypted ^ BHEHGCHGBDG; } set { JLFFBIOJBAO_CloseAtCrypted = value ^ BHEHGCHGBDG; } } //0x11323FC MGOEKKJNOLF 0x113241C NHPFDCAFAFF

	//// RVA: 0x1132440 Offset: 0x1132440 VA: 0x1132440
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		FJGCDPLCIAK_unique_key = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FJGCDPLCIAK_unique_key];
		LKPHIGAFJKD_virtual_currency = new NABANOOIECF();
		LKPHIGAFJKD_virtual_currency.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.LKPHIGAFJKD_virtual_currency]);
		KBFOIECIADN_opened_at = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at, 0);
		EGBOHDFBAPB_closed_at = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at, 0);
		LKHAAGIJEPG_player_status = new IAPIDHGIEED();
		LKHAAGIJEPG_player_status.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status]);
		EDOHBJAPLPF_JsonData d = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BMFEGOMNECF_steps];
		BMFEGOMNECF_steps = new List<MMNNAPPLHFM>();
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			MMNNAPPLHFM m = new MMNNAPPLHFM();
			m.KHEKNNFCAOI_Init(d[i]);
			BMFEGOMNECF_steps.Add(m);
		}
	}
}
