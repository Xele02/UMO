
using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{ 
	public class PlayRecordView_Diva
	{
		public class SNS
		{
			public string m_title; // 0x8
			public bool m_enable; // 0xC
			public DateTime m_time; // 0x10
		}

		public int m_diva_level; // 0x8
		public int m_costume_now; // 0xC
		public int m_costume_max; // 0x10
		public int m_costume_upgrade_now; // 0x14
		public int m_costume_upgrade_max; // 0x18
		public int m_music_lv_max; // 0x1C
		public int m_intimacy_touch; // 0x20
		public int m_intimacy_present; // 0x24
		public int m_diva_event_soul; // 0x28
		public int m_diva_event_soul_max; // 0x2C
		public int m_diva_event_voice; // 0x30
		public int m_diva_event_voice_max; // 0x34
		public int m_diva_event_charm; // 0x38
		public int m_diva_event_charm_max; // 0x3C
		public List<SNS> m_sns; // 0x40
		public int m_sns_cnt; // 0x44

		// RVA: 0xDE4020 Offset: 0xDE4020 VA: 0xDE4020
		public void Setup(int a_diva_id, BBHNACPENDM_ServerSaveData a_player_data)
		{
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo saveDiva = a_player_data.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[a_diva_id - 1];
			m_diva_level = saveDiva.HEBKEJBDCBH_DivaLevel;
			m_intimacy_touch = Mathf.Max(0, saveDiva.NEAADNDKGLG_IntimacyTouchTotal);
			m_intimacy_present = Mathf.Max(0, saveDiva.DDODJCCIENF_IntimacyPresentTotal);
			for(int i = 0; i < saveDiva.ANAJIAENLNB_Levels.Count; i++)
			{
				if (KDOMGMCGHDC.BKEMLLBKELP(saveDiva.ANAJIAENLNB_Levels[i]))
					m_music_lv_max++;
			}
			int maxLevel = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			m_diva_event_soul = saveDiva.MMCEMJILMJI_EvSoLevel;
			m_diva_event_soul_max = maxLevel;
			m_diva_event_voice = saveDiva.HDPANGMKKCP_EvVoLevel;
			m_diva_event_voice_max = maxLevel;
			m_diva_event_charm = saveDiva.FFMLBEEBHDD_EvChLevel;
			m_diva_event_charm_max = maxLevel;
			SetupSNS(a_diva_id, a_player_data);
		}

		// RVA: 0xDE4418 Offset: 0xDE4418 VA: 0xDE4418
		private void SetupSNS(int a_diva_id, BBHNACPENDM_ServerSaveData a_player_data)
		{
			MessageBank bk = MessageManager.Instance.GetBank("master");
			m_sns_cnt = 0;
			m_sns = new List<SNS>();
			BJPLLEBHAGO_DivaInfo dbDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(a_diva_id);
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA.Count; i++)
			{
				BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
				if(dbSns.PPEGAKEIEGM_Enabled == 2)
				{
					if(dbSns.MALFHCHNEFN_RoomId == 3 && dbSns.JKNGNIMLDDJ == 10)
					{
						DateTime date = Utility.GetLocalDateTime(dbSns.DPIBHFNDJII);
						if(date.Month == dbDiva.DOAJJALOKLI_Month && date.Day == dbDiva.PKNONBBKCCP_Day)
						{
							if(bk.GetMessageByLabel("sns_dsc_"+dbSns.AIPLIEMLHGC.ToString("D4")).Contains(JpStringLiterals.StringLiteral_19017))
							{
								DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = a_player_data.FLHMJHBOBEA_Sns.HAJEJPFGILG[i];
								SNS data = new SNS();
								object[] o = new object[4] { date.Year, date.Month, date.Day, bk.GetMessageByLabel("sns_nm_" + dbSns.AIPLIEMLHGC.ToString("D4")) };
								data.m_enable = false;
								data.m_title = string.Format(JpStringLiterals.StringLiteral_19018, o);
								data.m_time = date;
								if (saveSns.BEBJKJKBOGH_Date != 0)
								{
									data.m_enable = true;
									m_sns_cnt++;
								}
								m_sns.Add(data);
							}
						}
					}
				}
			}
			m_sns.Sort((SNS a, SNS b) =>
			{
				//0xDE4E20
				return a.m_time.CompareTo(b.m_time);
			});
		}
	}
}
