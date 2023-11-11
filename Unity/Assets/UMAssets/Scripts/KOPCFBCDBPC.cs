
using System.Collections.Generic;
using XeSys;

public class KOPCFBCDBPC
{
	private const long BHEHGCHGBDG = 0x5a7d5afa35ac5a5a;
	public string OPFGFINHFCE_Name; // 0x8
	public string KLMPFGOCBHC_Description; // 0xC
	public string FJGCDPLCIAK_UniqueKey; // 0x10
	public NABANOOIECF LKPHIGAFJKD_VirtualCurrency; // 0x14
	public long JJLCCDHHOKK_OpenAtCrypted = 0x5a7d5afa35ac5a5a; // 0x18
	public long JLFFBIOJBAO_CloseAtCrypted = 0x5a7d5afa35ac5a5a; // 0x20
	public List<MMNNAPPLHFM> BMFEGOMNECF_Step; // 0x28
	public IAPIDHGIEED LKHAAGIJEPG_PlayerStatus; // 0x2C

	public long KBFOIECIADN_OpenAt { get { return JJLCCDHHOKK_OpenAtCrypted ^ BHEHGCHGBDG; } set { JJLCCDHHOKK_OpenAtCrypted = value ^ BHEHGCHGBDG; } } //0x11323B8 NAIEFPFHLJM 0x11323D8 BMLJOGEMFBH
	public long EGBOHDFBAPB_CloseAt { get { return JLFFBIOJBAO_CloseAtCrypted ^ BHEHGCHGBDG; } set { JLFFBIOJBAO_CloseAtCrypted = value ^ BHEHGCHGBDG; } } //0x11323FC MGOEKKJNOLF 0x113241C NHPFDCAFAFF

	//// RVA: 0x1132440 Offset: 0x1132440 VA: 0x1132440
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_Description = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		FJGCDPLCIAK_UniqueKey = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.FJGCDPLCIAK_unique_key];
		LKPHIGAFJKD_VirtualCurrency = new NABANOOIECF();
		LKPHIGAFJKD_VirtualCurrency.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.LKPHIGAFJKD_virtual_currency]);
		KBFOIECIADN_OpenAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at, 0);
		EGBOHDFBAPB_CloseAt = JsonUtil.GetLong(IDLHJIOMJBK, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at, 0);
		LKHAAGIJEPG_PlayerStatus = new IAPIDHGIEED();
		LKHAAGIJEPG_PlayerStatus.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status]);
		EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BMFEGOMNECF_steps];
		BMFEGOMNECF_Step = new List<MMNNAPPLHFM>();
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			MMNNAPPLHFM m = new MMNNAPPLHFM();
			m.KHEKNNFCAOI(d[i]);
			BMFEGOMNECF_Step.Add(m);
		}
	}
}
