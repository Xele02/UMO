
using System;
using System.Collections.Generic;
using XeSys;

public class LKBGPLDLNIK
{
	public static bool HPLKPMKPKLO = false; // 0x0
	public static bool JJAOMJGIHPF = false; // 0x1
	public static int PMMENMJPECC = 65; // 0x4

	//// RVA: 0x1808CB4 Offset: 0x1808CB4 VA: 0x1808CB4
	public static long OEAJOJBJFNB(long EMJFLGOJKHE, PEBFNABDJDI_System GDEKCOOBLMA)
	{
		DateTime date = Utility.GetLocalDateTime(EMJFLGOJKHE);
		long t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
		List<sbyte> gachaHour = GDEKCOOBLMA.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour;
		bool wasAfter = false;
		for(int i = -1; i <= 1; i++)
		{
			for (int j = 0; j < gachaHour.Count; j++)
			{
				int delta = (i * 24 + gachaHour[j]) * 3600;
				bool isAfter = EMJFLGOJKHE >= (t + delta);
				bool b2 = isAfter;
				if (!isAfter)
				{
					b2 = !wasAfter;
				}
				wasAfter |= isAfter;
				if (!isAfter && !b2)
					return t + delta;
			}
		}
		return 0;
	}

	//// RVA: 0x1808ED8 Offset: 0x1808ED8 VA: 0x1808ED8
	public static int JPIMHNNGJGI(long JHNMKKNEENE, long EMJFLGOJKHE, PEBFNABDJDI_System GDEKCOOBLMA)
	{
		if(EMJFLGOJKHE != 0)
		{
			long t = OEAJOJBJFNB(EMJFLGOJKHE, GDEKCOOBLMA);
			if(t >= JHNMKKNEENE)
			{
				return (int)(t - JHNMKKNEENE);
			}
		}
		return 0;
	}

	//// RVA: 0x1808F90 Offset: 0x1808F90 VA: 0x1808F90
	public static int JPIMHNNGJGI(long JHNMKKNEENE)
	{
		return JPIMHNNGJGI(JHNMKKNEENE, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NKIGFPJPALK_LastLotTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System);
	}

	//// RVA: 0x1809140 Offset: 0x1809140 VA: 0x1809140
	//public static void ADLJMCPENGM() { }
}
