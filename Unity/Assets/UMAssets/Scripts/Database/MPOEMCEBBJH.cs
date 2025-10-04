
using System.Collections.Generic;

[System.Obsolete("Use MPOEMCEBBJH_Pilot", true)]
public class MPOEMCEBBJH { }
[UMOClass(ReaderClass = "LBMIEHAHNFD")]
public class MPOEMCEBBJH_Pilot : DIHHCBACKGG_DbSection
{
	[UMOClass(ReaderClass = "BPIFDOECJPH")]
	public class KOAKMNKEHDE_PilotInfo
	{
		[UMOMember(ReaderMember = "PPFNGGCBJKC_id", Desc = "Id in the list")]
		public short PFGJJLGLPAC_PilotId; // 0x8
		[UMOMember(ReaderMember = "JPFMJHLCMJL_sa", Desc = "Serie")]
		public sbyte AIHCEGFANAM_SerieAttr; // 0xA
		[UMOMember(ReaderMember = "MJMPANIBFED_pid", Desc = "")]
		public short CHIMPKJDCPP_Pid; // 0xC

		//// RVA: 0x17BD028 Offset: 0x17BD028 VA: 0x17BD028
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember(ReaderMember = "NNCNIHFAPBO", Desc = "List of pilots")]
	public List<KOAKMNKEHDE_PilotInfo> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF_get_table ILHOADLEJPB_set_table

	//// RVA: 0x17BC85C Offset: 0x17BC85C VA: 0x17BC85C
	public KOAKMNKEHDE_PilotInfo GCINIJEMHFK_Get(int _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id != 0 && _PPFNGGCBJKC_id <= CDENCMNHNGA_table.Count)
		{
			return CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
		}
		return null;
	}

	// RVA: 0x17BC924 Offset: 0x17BC924 VA: 0x17BC924
	public MPOEMCEBBJH_Pilot()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 65;
		CDENCMNHNGA_table = new List<KOAKMNKEHDE_PilotInfo>(100);
	}

	// RVA: 0x17BCA1C Offset: 0x17BCA1C VA: 0x17BCA1C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x17BCA94 Offset: 0x17BCA94 VA: 0x17BCA94 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		LBMIEHAHNFD parser = LBMIEHAHNFD.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		KFIHBHIAMCL(parser);
		return true;
	}

	// RVA: 0x17BCC98 Offset: 0x17BCC98 VA: 0x17BCC98 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "Pilot IIEMACPEEBJ_Deserialize");
		return true;
	}

	//// RVA: 0x17BCAC0 Offset: 0x17BCAC0 VA: 0x17BCAC0
	private bool KFIHBHIAMCL(LBMIEHAHNFD JNCBKKEOKJD)
	{
		BPIFDOECJPH[] array = JNCBKKEOKJD.NNCNIHFAPBO;
		for (int i = 0; i < array.Length; i++)
		{
			KOAKMNKEHDE_PilotInfo data = new KOAKMNKEHDE_PilotInfo();
			data.PFGJJLGLPAC_PilotId = (short)array[i].PPFNGGCBJKC_id;
			data.AIHCEGFANAM_SerieAttr = (sbyte)array[i].JPFMJHLCMJL_sa;
			data.CHIMPKJDCPP_Pid = (short)array[i].MJMPANIBFED_pid;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	//// RVA: 0x17BCC9C Offset: 0x17BCC9C VA: 0x17BCC9C
	//private bool KFIHBHIAMCL(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }
	//PFGJJLGLPAC_PilotId = PPFNGGCBJKC_id
	//AIHCEGFANAM_SerieAttr = JPFMJHLCMJL_sa
	//CHIMPKJDCPP_Pid = MJMPANIBFED_pid

	//// RVA: 0x17BCF34 Offset: 0x17BCF34 VA: 0x17BCF34 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "MPOEMCEBBJH_Pilot.CAOGDCBPBAN");
		return 0;
	}
}
