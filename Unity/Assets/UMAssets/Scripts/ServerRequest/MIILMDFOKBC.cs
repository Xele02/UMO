
using UnityEngine;

[System.Obsolete("Use MIILMDFOKBC_GetLoginBonusRecord", true)]
public class MIILMDFOKBC {}
public class MIILMDFOKBC_GetLoginBonusRecord : CACGCMBKHDI_Request
{
	public int PIDIKFIFAPG_Id; // 0x7C
	public bool FNDBKPJDEDC_AllPrizes; // 0x80
	public int IGNIIEBMFIN_Page = 1; // 0x84
	public int MLPLGFLKKLI_Ipp = 10; // 0x88
	public string OCGFKMHNEOF = ""; // 0x8C
	public EPLAAEHPCDM NFEAMMJIMPG; // 0x90

	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } //0x1956C00 HGPAELCGELL

	// RVA: 0x1956A40 Offset: 0x1956A40 VA: 0x1956A40 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonusRecord(PIDIKFIFAPG_Id, FNDBKPJDEDC_AllPrizes, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1956B44 Offset: 0x1956B44 VA: 0x1956B44 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = null;
        BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
    }

	// RVA: 0x1956C10 Offset: 0x1956C10 VA: 0x1956C10
	private void DIAMDBHBKBH()
    {
        EPLAAEHPCDM data = new EPLAAEHPCDM();
        data.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG = data;
    }
}
