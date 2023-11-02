
using UnityEngine;

[System.Obsolete("Use BLHOHLGCJHI_GetItemSetRecord", true)]
public class BLHOHLGCJHI { }
public class BLHOHLGCJHI_GetItemSetRecord : CACGCMBKHDI_Request
{
	// Fields
	public string DKBGNOMDCMK_ItemSetName; // 0x7C
	public int KHDLOLOPCOK = 3; // 0x80
	public int LLPOINKCHEJ = 1; // 0x84
	public IKMBBPDBECA KACECFNECON; // 0x88

	public HIMAFGJCECK NFEAMMJIMPG { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null } } //0x19C1A6C HGPAELCGELL

	// RVA: 0x19C18B4 Offset: 0x19C18B4 VA: 0x19C18B4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoItemSet.GetItemSetRecord(DKBGNOMDCMK_ItemSetName, KHDLOLOPCOK, LLPOINKCHEJ, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x19C19B0 Offset: 0x19C19B0 VA: 0x19C19B0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = null;
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
		data.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(NGCAIEGPLKD_result), KACECFNECON);
		NFEAMMJIMPG = data;
	}
}
