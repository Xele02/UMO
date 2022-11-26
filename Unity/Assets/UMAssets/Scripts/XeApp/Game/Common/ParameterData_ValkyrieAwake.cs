
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieAwake : ParameterData
    {
        public const int DATA_VL = 0;
        public const int DATA_MC = 1;
        public const int DATA_DV = 2;
        public const int DATA_CS = 3;
        public const int DATA_PL = 4;

        // // RVA: 0xAF5220 Offset: 0xAF5220 VA: 0xAF5220
        public bool Check(GameSetupData a_setup_data)
		{
			return Check(a_setup_data.teamInfo.prismValkyrieId, a_setup_data.teamInfo.danceDivaList[0].prismDivaId, a_setup_data.teamInfo.danceDivaList[0].prismCostumeModelId, a_setup_data.musicInfo.musicId);
		}

        // // RVA: 0xAF53F0 Offset: 0xAF53F0 VA: 0xAF53F0
        public bool Check(int a_id_vl, int a_id_dv, int a_id_cs, int a_id_mc)
		{
			for(int i = 0; i < m_data_int[DATA_VL].Count; i++)
			{
				if (m_data_int[DATA_VL][i] == a_id_vl)
				{
					if (m_data_int[DATA_MC][i] == a_id_mc)
					{
						if (m_data_int[DATA_DV][i] == a_id_dv || m_data_int[DATA_DV][i] == 0)
						{
							if (m_data_int[DATA_CS][i] == a_id_cs || m_data_int[DATA_CS][i] == 0)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}
    }
}
