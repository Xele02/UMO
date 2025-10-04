
using UnityEngine;

[System.Obsolete("Use BLHOHLGCJHI_GetItemSetRecord", true)]
public class BLHOHLGCJHI { }
public class BLHOHLGCJHI_GetItemSetRecord : CACGCMBKHDI_Request
{
	// Fields
	public string DKBGNOMDCMK_ItemSetName; // 0x7C
	public int KHDLOLOPCOK = 3; // 0x80
	public int LLPOINKCHEJ = 1; // 0x84
	public IKMBBPDBECA KACECFNECON_extra; // 0x88

	public HIMAFGJCECK NFEAMMJIMPG_Result { get; private set; } // 0x8C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } //0x19C1A6C HGPAELCGELL_bgs

	// RVA: 0x19C18B4 Offset: 0x19C18B4 VA: 0x19C18B4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoItemSet.GetItemSetRecord(DKBGNOMDCMK_ItemSetName, KHDLOLOPCOK, LLPOINKCHEJ, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x19C19B0 Offset: 0x19C19B0 VA: 0x19C19B0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	// RVA: 0x19C1A7C Offset: 0x19C1A7C VA: 0x19C1A7C Slot: 15
	public override void NLDKLFODOJJ()
	{
		return;
	}

	// RVA: 0x19C1A80 Offset: 0x19C1A80 VA: 0x19C1A80
	private void DIAMDBHBKBH()
	{
		HIMAFGJCECK data = new HIMAFGJCECK();
		data.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result), KACECFNECON_extra);
		NFEAMMJIMPG_Result = data;
	}
}
