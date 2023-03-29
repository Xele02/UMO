
using System.Collections.Generic;

public class PLADCDJLOBE
{
	public enum PNLNGHNHCNI
	{
		NHANNKGPAHM = 0,
		KJHABBHBFPD = 1,
		PAAIHBHJJMM = 2,
		MOFPBMFPFHF = 3,
		IEGNGNLGLGN = 4,
		CCDOBDNDPIL = 5,
	}

	public enum ENNOBKHBNCG
	{
		HJNNKCMLGFL = 0,
		ODBLGDGLEIO = 1,
		OLLIGIKNCMM = 2,
		OMNJOCHOGDG = 3,
		PAMGIIDEEMC = 4,
		NHANNKGPAHM = 5,
		DIDJLIPNCKO = 6,
	}

	public enum OCMHGKIFNHP
	{
		HJNNKCMLGFL = 0,
		JFEDIMKFDNH = 1,
		OEDCONLFLHD = 2,
	}

	public PNLNGHNHCNI MMMGMNAMGDF; // 0x8
	public string KLMPFGOCBHC; // 0xC
	public int PAAGIJHEIHK; // 0x10
	public int DEKECNIBBIB; // 0x14
	public bool JDBLMAHMHJO_IsAchieved; // 0x18
	public ENNOBKHBNCG BGOCBNPGNKM; // 0x1C
	public int EKANGPODCEP; // 0x20
	public OCMHGKIFNHP CICPBBKEBNJ; // 0x24
	public int LMPPENOILPF; // 0x28
	
	//// RVA: 0xFE7B80 Offset: 0xFE7B80 VA: 0xFE7B80
	public static PLADCDJLOBE HEGEKFMJNCC()
	{
		FKMOKDCJFEN f = FKMOKDCJFEN.KFHCJLFAHAG();
		if (f == null)
		{
			IKDICBBFBMI_EventBase ev = MCOABJIJFFN();
			if (ev == null)
			{
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				PLADCDJLOBE p = null;
				for (int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
				{
					TodoLogger.Log(0, "Event");
				}
				List<FKMOKDCJFEN> l = FKMOKDCJFEN.CMLEFPDNBCB(false, 0, true);
				if (l != null && l.Count > 0)
				{
					int idx = -1;
					for (int i = 0; i < l.Count; i++)
					{
						if (l[i].LMPPENOILPF != 0)
						{
							if (l[i].CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ/*1*/)
							{
								if (idx != -1)
								{
									if (l[i].LMPPENOILPF < l[idx].LMPPENOILPF)
										idx = i;
								}
								else
								{
									idx = i;
								}
							}
						}
					}
					if (idx > -1)
					{
						PLADCDJLOBE data = new PLADCDJLOBE();
						data.AODPJKPIHME(l[idx]);
						if (p != null)
						{
							if (p.LMPPENOILPF <= data.LMPPENOILPF)
								return p;
						}
						return data;
					}
				}
				return p;
			}
			else
			{
				TodoLogger.Log(0, "Event");
			}
		}
		else
		{
			PLADCDJLOBE data = new PLADCDJLOBE();
			data.LJIFDOFIHEA(f);
			return data;
		}
		return null;
	}

	//// RVA: 0xFE83E4 Offset: 0xFE83E4 VA: 0xFE83E4
	public void LJIFDOFIHEA(FKMOKDCJFEN GOACJBOCLHH)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.NHANNKGPAHM/*0*/;
		KLMPFGOCBHC = GOACJBOCLHH.ADFLDIBPJLP();
		DEKECNIBBIB = GOACJBOCLHH.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId;
		LMPPENOILPF = 10;
		BGOCBNPGNKM = ENNOBKHBNCG.NHANNKGPAHM/*5*/;
		JDBLMAHMHJO_IsAchieved = GOACJBOCLHH.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
	}

	//// RVA: 0xFE8EB8 Offset: 0xFE8EB8 VA: 0xFE8EB8
	//public void HJBGNOEIJOL(LIEJFHMGNIA OIFJPOMLKAH) { }

	//// RVA: 0xFE9020 Offset: 0xFE9020 VA: 0xFE9020
	//public void HDCOEJNNMKN() { }

	//// RVA: 0xFE8CD8 Offset: 0xFE8CD8 VA: 0xFE8CD8
	public void AODPJKPIHME(FKMOKDCJFEN GOACJBOCLHH)
	{
		MMMGMNAMGDF = PNLNGHNHCNI.KJHABBHBFPD/*1*/;
		KLMPFGOCBHC = GOACJBOCLHH.ADFLDIBPJLP();
		DEKECNIBBIB = GOACJBOCLHH.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId;
		JDBLMAHMHJO_IsAchieved = GOACJBOCLHH.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
		LMPPENOILPF = GOACJBOCLHH.LMPPENOILPF;
		BGOCBNPGNKM = ILLPDLODANB.FJFPHHEFMIB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[GOACJBOCLHH.CMEJFJFOIIJ_QuestId - 1]) ? ENNOBKHBNCG.OMNJOCHOGDG/*3*/ : ENNOBKHBNCG.OLLIGIKNCMM/*2*/;
	}

	//// RVA: 0xFE8C40 Offset: 0xFE8C40 VA: 0xFE8C40
	//public void IFAOJAKAPHH(FKMOKDCJFEN GOACJBOCLHH) { }

	//// RVA: 0xFE88F4 Offset: 0xFE88F4 VA: 0xFE88F4
	//private void OMAOEIOLKPH(IKDICBBFBMI LIKDEHHKFEH) { }

	//// RVA: 0xFE847C Offset: 0xFE847C VA: 0xFE847C
	private static IKDICBBFBMI_EventBase MCOABJIJFFN()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Count; i++)
		{
			TodoLogger.Log(0, "Event");
		}
		return null;
	}
}
