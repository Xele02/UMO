using System.Collections.Generic;

public class HPBPIOPPDCB { }
public class HPBPIOPPDCB_Diva : DIHHCBACKGG
{
	public static bool DINNDBNPNFK; // 0x0
	public const int NLPCOAKLBAN = 0;
	public const int AGBLDFIFLBJ = 10;
	public const int DNLFNEFLNED = 200;
	public int AGNCAAFGLBE; // 0x20
	public List<BJPLLEBHAGO> CDENCMNHNGA = new List<BJPLLEBHAGO>(10); // 0x24

	// // RVA: 0x160846C Offset: 0x160846C VA: 0x160846C
	// public bool BEEGJHCDHJB(int AHHJLDLAPAN) { }

	// // RVA: 0x1608560 Offset: 0x1608560 VA: 0x1608560
	public BJPLLEBHAGO GCINIJEMHFK(int AHHJLDLAPAN)
    {
        UnityEngine.Debug.LogError("TODO");
        return null;
    }

	// // RVA: 0x16085F0 Offset: 0x16085F0 VA: 0x16085F0
	public HPBPIOPPDCB_Diva()
    {
		JIKKNHIAEKG = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 19;
    }

	// // RVA: 0x16086E8 Offset: 0x16086E8 VA: 0x16086E8 Slot: 8
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA.Clear();
		for(int i = 0; i < 10; i++)
		{
			BJPLLEBHAGO data = new BJPLLEBHAGO();
			data.AHHJLDLAPAN = (sbyte)i;
			for(int j = 0; j < 200; j++)
			{
				EPPOHFLMDBC data2 = new EPPOHFLMDBC();
				data2.DOMFHDPMCCO(j, 0x7517748f, 0, 0, 0, 0, 0, 0);
				data.CMCKNKKCNDK.Add(data2);
			}
			CDENCMNHNGA.Add(data);
		}
    }

	// // RVA: 0x16088BC Offset: 0x16088BC VA: 0x16088BC Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
        UnityEngine.Debug.LogError("TODO Database Load");
		return true;
    }

	// // RVA: 0x16093A0 Offset: 0x16093A0 VA: 0x16093A0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		UnityEngine.Debug.LogError("TODO");
		return true;
	}

	// // RVA: 0x16093A8 Offset: 0x16093A8 VA: 0x16093A8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		UnityEngine.Debug.LogError("TODO CAOGDCBPBAN");
		return 0;
	}
}
