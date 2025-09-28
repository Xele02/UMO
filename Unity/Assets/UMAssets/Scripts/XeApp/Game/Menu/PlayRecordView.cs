
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class PlayRecordView
	{
		public PlayRecordView_Total m_total; // 0x8
		public List<PlayRecordView_Diva> m_diva; // 0xC

		//// RVA: 0xDE3224 Offset: 0xDE3224 VA: 0xDE3224
		public void Create(BBHNACPENDM_ServerSaveData a_player_data)
		{
			Create_Total(a_player_data);
			Create_Diva(a_player_data);
			Setup_Costume(a_player_data);
		}

		//// RVA: 0xDE3254 Offset: 0xDE3254 VA: 0xDE3254
		private void Create_Total(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_total = new PlayRecordView_Total();
			m_total.Setup(a_player_data);
		}

		//// RVA: 0xDE32E4 Offset: 0xDE32E4 VA: 0xDE32E4
		private void Create_Diva(BBHNACPENDM_ServerSaveData a_player_data)
		{
			m_diva = new List<PlayRecordView_Diva>();
			for(int i = 0; i < 10; i++)
			{
				PlayRecordView_Diva data = new PlayRecordView_Diva();
				data.Setup(i + 1, a_player_data);
				m_diva.Add(data);
			}
		}

		//// RVA: 0xDE33F0 Offset: 0xDE33F0 VA: 0xDE33F0
		private void Setup_Costume(BBHNACPENDM_ServerSaveData a_player_data)
		{
			LCLCCHLDNHJ_Costume dbCostumes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
			int[] m_costume_max_array = new int[11];
			int[] m_costume_color_max_array = new int[11];
			int[] m_costume_upgrade_max_array = new int[11];
			int[] m_costume_now_array = new int[11];
			int[] m_costume_color_now_array = new int[11];
			int[] m_costume_upgrade_now_array = new int[11];
			for(int i = 0; i < dbCostumes.CDENCMNHNGA_table.Count; i++)
			{
				LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo dbCostume = dbCostumes.CDENCMNHNGA_table[i];
				EBFLJMOCLNA_Costume.ILFJDCICIKN saveCostume = a_player_data.BEKHNNCGIEL_Costume.FABAGMLEKIB_CostumeList[i];
				if(dbCostume.PPEGAKEIEGM_Enabled == 2)
				{
					m_costume_max_array[0]++;
					m_costume_max_array[dbCostume.AHHJLDLAPAN_DivaId]++;
					for(int j = 0; j < dbCostume.BJGNGNPHCBA_LevelsInfo.Length; j++)
					{
						if(dbCostume.BJGNGNPHCBA_LevelsInfo[j].INDDJNMPONH_type == 4)
						{
							m_costume_color_max_array[0]++;
							m_costume_color_max_array[dbCostume.AHHJLDLAPAN_DivaId]++;
						}
					}
					if (dbCostume.LLLCMHENKKN_LevelMax > 0)
					{
						m_costume_upgrade_max_array[0]++;
						m_costume_upgrade_max_array[dbCostume.AHHJLDLAPAN_DivaId]++;
					}
					if(dbCostume.DAJGPBLEEOB_ModelId == 1 || saveCostume.FJODMPGPDDD_Unlocked)
					{
						if(a_player_data.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(dbCostume.AHHJLDLAPAN_DivaId).CPGFPEDMDEH_have != 0)
						{
							//LAB_00de38f4
							m_costume_now_array[0]++;
							m_costume_now_array[dbCostume.AHHJLDLAPAN_DivaId]++;
							if(dbCostume.LLLCMHENKKN_LevelMax > 0)
							{
								if(dbCostume.LLLCMHENKKN_LevelMax <= saveCostume.ANAJIAENLNB_lv)
								{
									m_costume_upgrade_now_array[0]++;
									m_costume_upgrade_now_array[dbCostume.AHHJLDLAPAN_DivaId]++;
								}
							}
							int numCol = dbCostume.KKLPLPGBOFD_GetAvaiableColor(saveCostume.ANAJIAENLNB_lv).Length;
							m_costume_color_now_array[0] += numCol;
							m_costume_color_now_array[dbCostume.AHHJLDLAPAN_DivaId]++;
						}
					}
				}
			}
			for(int i = 0; i < m_costume_now_array.Length; i++)
			{
				if(i == 0)
				{
					m_total.m_costume_now = m_costume_now_array[0];
					m_total.m_costume_max = m_costume_max_array[0];
					m_total.m_costume_color_now = m_costume_color_now_array[0];
					m_total.m_costume_color_max = m_costume_color_max_array[0];
					m_total.m_costume_upgrade_now = m_costume_upgrade_now_array[0];
					m_total.m_costume_upgrade_max = m_costume_upgrade_max_array[0];
				}
				else
				{
					m_diva[i - 1].m_costume_now = m_costume_now_array[i];
					m_diva[i - 1].m_costume_max = m_costume_max_array[i];
					m_diva[i - 1].m_costume_upgrade_now = m_costume_upgrade_now_array[i];
					m_diva[i - 1].m_costume_upgrade_max = m_costume_upgrade_max_array[i];
				}
			}
		}
	}
}
