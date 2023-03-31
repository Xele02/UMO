
using System;
using System.Collections.Generic;
using XeSys;

public class NJOOMLFFIJB
{
	public enum LGAJNFGABFK
	{
		CCAPCGPIIPF_Normal = 0,
		AJGKPBOPIJI_Limited = 1,
		DDAFHPDFFPI_Brithday = 2
	}

	public LGAJNFGABFK NEJBNCHLMNJ_Type; // 0x8
	public long KJBGCLPMLCG_StartAt; // 0x10
	public long GJFPFFBAKGK_EndAt; // 0x18
	public int NKCNHKHGJHN_TalkType; // 0x20

	// RVA: 0x18ACCF8 Offset: 0x18ACCF8 VA: 0x18ACCF8
	public static List<NJOOMLFFIJB> FKDIMODKKJD(int PDJEMLMOEPF)
	{
		BJPLLEBHAGO_DivaInfo diva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[PDJEMLMOEPF - 1];
		List<NPCCDMKJBMM_HomeVoice.KLKLEALABPN> voiceList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGIMEEEALPK_HomeVoice.CDENCMNHNGA;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		List<NJOOMLFFIJB> res = new List<NJOOMLFFIJB>();
		for(int i = 0; i < voiceList.Count; i++)
		{
			if(voiceList[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(voiceList[i].INDDJNMPONH == 2)
				{
					if(time >= voiceList[i].PDBPFJJCADD && time < voiceList[i].FDBNFFNFOND && voiceList[i].CHOFDPDFPDC == PDJEMLMOEPF)
					{
						if(diva.DOAJJALOKLI == date.Month)
						{
							if(diva.PKNONBBKCCP == date.Day)
							{
								NJOOMLFFIJB data = new NJOOMLFFIJB();
								data.NEJBNCHLMNJ_Type = LGAJNFGABFK.DDAFHPDFFPI_Brithday;
								data.KJBGCLPMLCG_StartAt = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
								data.GJFPFFBAKGK_EndAt = data.KJBGCLPMLCG_StartAt + 86399;
								data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN;
								res.Add(data);
							}
						}
					}
				}
				else if(voiceList[i].INDDJNMPONH == 1)
				{
					if (time >= voiceList[i].PDBPFJJCADD && time < voiceList[i].FDBNFFNFOND && voiceList[i].CHOFDPDFPDC == PDJEMLMOEPF)
					{
						NJOOMLFFIJB data = new NJOOMLFFIJB();
						data.NEJBNCHLMNJ_Type = LGAJNFGABFK.AJGKPBOPIJI_Limited;
						data.KJBGCLPMLCG_StartAt = voiceList[i].PDBPFJJCADD;
						data.GJFPFFBAKGK_EndAt = voiceList[i].FDBNFFNFOND;
						data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN;
						res.Add(data);
					}
				}
				else if(voiceList[i].INDDJNMPONH == 0)
				{
					NJOOMLFFIJB data = new NJOOMLFFIJB();
					data.NEJBNCHLMNJ_Type = LGAJNFGABFK.CCAPCGPIIPF_Normal;
					data.KJBGCLPMLCG_StartAt = voiceList[i].PDBPFJJCADD;
					data.GJFPFFBAKGK_EndAt = voiceList[i].FDBNFFNFOND;
					data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN;
					res.Add(data);
				}
			}
		}
		return res;
	}
}
