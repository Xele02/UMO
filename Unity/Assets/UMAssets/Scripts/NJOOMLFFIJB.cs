
using System;
using System.Collections.Generic;
using XeSys;

public class NJOOMLFFIJB
{
	public enum LGAJNFGABFK_Type
	{
		CCAPCGPIIPF_0_Normal = 0,
		AJGKPBOPIJI_1_Limited = 1,
		DDAFHPDFFPI_2_Birthday = 2
	}

	public LGAJNFGABFK_Type NEJBNCHLMNJ_Type; // 0x8
	public long KJBGCLPMLCG_OpenedAt; // 0x10
	public long GJFPFFBAKGK_CloseAt; // 0x18
	public int NKCNHKHGJHN_TalkType; // 0x20

	// RVA: 0x18ACCF8 Offset: 0x18ACCF8 VA: 0x18ACCF8
	public static List<NJOOMLFFIJB> FKDIMODKKJD_GetList(int _PDJEMLMOEPF_CenterDivaId)
	{
		BJPLLEBHAGO_DivaInfo diva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[_PDJEMLMOEPF_CenterDivaId - 1];
		List<NPCCDMKJBMM_HomeVoice.KLKLEALABPN> voiceList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGIMEEEALPK_HomeVoice.CDENCMNHNGA_table;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		DateTime date = Utility.GetLocalDateTime(time);
		List<NJOOMLFFIJB> res = new List<NJOOMLFFIJB>();
		for(int i = 0; i < voiceList.Count; i++)
		{
			if(voiceList[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(voiceList[i].INDDJNMPONH_type == (int)LGAJNFGABFK_Type.DDAFHPDFFPI_2_Birthday)
				{
					if(time >= voiceList[i].PDBPFJJCADD_open_at && time < voiceList[i].FDBNFFNFOND_close_at && voiceList[i].CHOFDPDFPDC_ConfigValue == _PDJEMLMOEPF_CenterDivaId)
					{
						if(diva.DOAJJALOKLI_Month == date.Month)
						{
							if(diva.PKNONBBKCCP_Day == date.Day)
							{
								NJOOMLFFIJB data = new NJOOMLFFIJB();
								data.NEJBNCHLMNJ_Type = LGAJNFGABFK_Type.DDAFHPDFFPI_2_Birthday;
								data.KJBGCLPMLCG_OpenedAt = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
								data.GJFPFFBAKGK_CloseAt = data.KJBGCLPMLCG_OpenedAt + 86399;
								data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN_TalkType;
								res.Add(data);
							}
						}
					}
				}
				else if(voiceList[i].INDDJNMPONH_type == (int)LGAJNFGABFK_Type.AJGKPBOPIJI_1_Limited)
				{
					if (time >= voiceList[i].PDBPFJJCADD_open_at && time < voiceList[i].FDBNFFNFOND_close_at && voiceList[i].CHOFDPDFPDC_ConfigValue == _PDJEMLMOEPF_CenterDivaId)
					{
						NJOOMLFFIJB data = new NJOOMLFFIJB();
						data.NEJBNCHLMNJ_Type = LGAJNFGABFK_Type.AJGKPBOPIJI_1_Limited;
						data.KJBGCLPMLCG_OpenedAt = voiceList[i].PDBPFJJCADD_open_at;
						data.GJFPFFBAKGK_CloseAt = voiceList[i].FDBNFFNFOND_close_at;
						data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN_TalkType;
						res.Add(data);
					}
				}
				else if(voiceList[i].INDDJNMPONH_type == (int)LGAJNFGABFK_Type.CCAPCGPIIPF_0_Normal)
				{
					NJOOMLFFIJB data = new NJOOMLFFIJB();
					data.NEJBNCHLMNJ_Type = LGAJNFGABFK_Type.CCAPCGPIIPF_0_Normal;
					data.KJBGCLPMLCG_OpenedAt = voiceList[i].PDBPFJJCADD_open_at;
					data.GJFPFFBAKGK_CloseAt = voiceList[i].FDBNFFNFOND_close_at;
					data.NKCNHKHGJHN_TalkType = voiceList[i].NKCNHKHGJHN_TalkType;
					res.Add(data);
				}
			}
		}
		return res;
	}
}
