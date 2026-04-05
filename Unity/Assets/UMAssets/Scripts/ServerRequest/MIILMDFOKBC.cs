
using UnityEngine;

[System.Obsolete("Use MIILMDFOKBC_GetLoginBonusRecord", true)]
public class MIILMDFOKBC {}
public class MIILMDFOKBC_GetLoginBonusRecord : CACGCMBKHDI_NetBaseAction
{
	public int PIDIKFIFAPG_Id; // 0x7C
	public bool FNDBKPJDEDC_AllPrizes; // 0x80
	public int IGNIIEBMFIN_Page = 1; // 0x84
	public int MLPLGFLKKLI_Ipp = 10; // 0x88
	public string OCGFKMHNEOF_name_for_api = ""; // 0x8C
	public EPLAAEHPCDM NFEAMMJIMPG_Result; // 0x90

	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } //0x1956C00 HGPAELCGELL_bgs

	// RVA: 0x1956A40 Offset: 0x1956A40 VA: 0x1956A40 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonusRecord(PIDIKFIFAPG_Id, FNDBKPJDEDC_AllPrizes, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1956B44 Offset: 0x1956B44 VA: 0x1956B44 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = null;
        BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
    }

	// RVA: 0x1956C10 Offset: 0x1956C10 VA: 0x1956C10
	private void DIAMDBHBKBH()
    {
        EPLAAEHPCDM data = new EPLAAEHPCDM();
        data.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG_Result = data;
    }
}
