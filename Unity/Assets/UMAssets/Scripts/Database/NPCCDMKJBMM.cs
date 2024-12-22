
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use NPCCDMKJBMM_HomeVoice", true)]
public class NPCCDMKJBMM { }
public class NPCCDMKJBMM_HomeVoice : DIHHCBACKGG_DbSection
{
	public class KLKLEALABPN
	{
		public int PPFNGGCBJKC; // 0x8
		public sbyte PPEGAKEIEGM_Enabled; // 0xC
		public sbyte INDDJNMPONH; // 0xD
		public int NKCNHKHGJHN_TalkType; // 0x10
		public int CHOFDPDFPDC_DivaId; // 0x14
		public long PDBPFJJCADD_StartAt; // 0x18
		public long FDBNFFNFOND_EndAt; // 0x20

		// RVA: 0x1CB5F60 Offset: 0x1CB5F60 VA: 0x1CB5F60
		//public uint CAOGDCBPBAN() { }
	}

	public List<KLKLEALABPN> CDENCMNHNGA = new List<KLKLEALABPN>(); // 0x20

	// RVA: 0x1CB59F4 Offset: 0x1CB59F4 VA: 0x1CB59F4
	public NPCCDMKJBMM_HomeVoice()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 55;
	}

	// RVA: 0x1CB5AE8 Offset: 0x1CB5AE8 VA: 0x1CB5AE8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1CB5B60 Offset: 0x1CB5B60 VA: 0x1CB5B60 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		PCKMEHLNOFO parser = PCKMEHLNOFO.HEGEKFMJNCC(DBBGALAPFGC);
		OCANCOENHML[] array = parser.EKDAACJJAPP;
		for(int i = 0; i < array.Length; i++)
		{
			KLKLEALABPN data = new KLKLEALABPN();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
			data.INDDJNMPONH = (sbyte)array[i].GBJFNGCDKPM;
			data.NKCNHKHGJHN_TalkType = (int)array[i].CHOIMHCMAHG;
			data.CHOFDPDFPDC_DivaId = (int)array[i].JBFLEDKDFCO;
			data.PDBPFJJCADD_StartAt = array[i].PDBPFJJCADD;
			data.FDBNFFNFOND_EndAt = array[i].FDBNFFNFOND;
			// UMO : Update all talk to work in current year
			long prevStart = data.PDBPFJJCADD_StartAt;
			if(data.PDBPFJJCADD_StartAt != 0)
			{
				DateTime startDate = Utility.GetLocalDateTime(data.PDBPFJJCADD_StartAt);
				data.PDBPFJJCADD_StartAt = Utility.GetTargetUnixTime(DateTime.Now.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute, startDate.Second);
			}
			if(data.FDBNFFNFOND_EndAt != 0)
			{
				if(prevStart == 0)
				{
					DateTime endDate = Utility.GetLocalDateTime(data.FDBNFFNFOND_EndAt);
					data.FDBNFFNFOND_EndAt = Utility.GetTargetUnixTime(DateTime.Now.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute, endDate.Second);
				}
				else
				{
					data.FDBNFFNFOND_EndAt = data.PDBPFJJCADD_StartAt + (data.FDBNFFNFOND_EndAt - prevStart);
				}
			}
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1CB5E3C Offset: 0x1CB5E3C VA: 0x1CB5E3C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x1CB5E44 Offset: 0x1CB5E44 VA: 0x1CB5E44 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NPCCDMKJBMM_HomeVoice.CAOGDCBPBAN");
		return 0;
	}
}
