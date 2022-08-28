
using System.Collections.Generic;

public class MPOEMCEBBJH { }
public class MPOEMCEBBJH_Pilot : DIHHCBACKGG_DbSection
{
	public class KOAKMNKEHDE_PilotInfo
	{
		public short PFGJJLGLPAC_Id; // 0x8
		public sbyte AIHCEGFANAM_Sa; // 0xA
		public short CHIMPKJDCPP_Pid; // 0xC

		//// RVA: 0x17BD028 Offset: 0x17BD028 VA: 0x17BD028
		//public uint CAOGDCBPBAN() { }
	}

	public List<KOAKMNKEHDE_PilotInfo> CDENCMNHNGA_PilotList { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x17BC85C Offset: 0x17BC85C VA: 0x17BC85C
	public KOAKMNKEHDE_PilotInfo GCINIJEMHFK_GetPilot(int PPFNGGCBJKC)
	{
		if(PPFNGGCBJKC != 0 && PPFNGGCBJKC <= CDENCMNHNGA_PilotList.Count)
		{
			return CDENCMNHNGA_PilotList[PPFNGGCBJKC - 1];
		}
		return null;
	}

	// RVA: 0x17BC924 Offset: 0x17BC924 VA: 0x17BC924
	public MPOEMCEBBJH_Pilot()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 65;
		CDENCMNHNGA_PilotList = new List<KOAKMNKEHDE_PilotInfo>(100);
	}

	// RVA: 0x17BCA1C Offset: 0x17BCA1C VA: 0x17BCA1C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_PilotList.Clear();
	}

	// RVA: 0x17BCA94 Offset: 0x17BCA94 VA: 0x17BCA94 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		LBMIEHAHNFD parser = LBMIEHAHNFD.HEGEKFMJNCC(DBBGALAPFGC);
		KFIHBHIAMCL(parser);
		return true;
	}

	// RVA: 0x17BCC98 Offset: 0x17BCC98 VA: 0x17BCC98 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(100, "Pilot IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x17BCAC0 Offset: 0x17BCAC0 VA: 0x17BCAC0
	private bool KFIHBHIAMCL(LBMIEHAHNFD JNCBKKEOKJD)
	{
		BPIFDOECJPH[] array = JNCBKKEOKJD.NNCNIHFAPBO;
		for (int i = 0; i < array.Length; i++)
		{
			KOAKMNKEHDE_PilotInfo data = new KOAKMNKEHDE_PilotInfo();
			data.PFGJJLGLPAC_Id = (short)array[i].PPFNGGCBJKC;
			data.AIHCEGFANAM_Sa = (sbyte)array[i].JPFMJHLCMJL;
			data.CHIMPKJDCPP_Pid = (short)array[i].MJMPANIBFED;
			CDENCMNHNGA_PilotList.Add(data);
		}
		return true;
	}

	//// RVA: 0x17BCC9C Offset: 0x17BCC9C VA: 0x17BCC9C
	//private bool KFIHBHIAMCL(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	//// RVA: 0x17BCF34 Offset: 0x17BCF34 VA: 0x17BCF34 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(100, "pilot CAOGDCBPBAN");
		return 0;
	}
}
