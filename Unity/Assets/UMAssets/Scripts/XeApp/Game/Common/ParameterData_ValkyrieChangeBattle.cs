
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieChangeBattle : ParameterData
    {
        public const int DATA_VL = 0;
        public const int DATA_MC = 1;
        public const int DATA_DV = 2;
        public const int DATA_CS = 3;
        public const int DATA_BT = 4;

        // // RVA: 0xAF57C4 Offset: 0xAF57C4 VA: 0xAF57C4
        public bool Check(GameSetupData a_setup_data, ref int a_out_battle)
        {
			return Check(a_setup_data.teamInfo.prismValkyrieId, a_setup_data.musicInfo.musicId, a_setup_data.teamInfo.danceDivaList[0].prismDivaId, a_setup_data.teamInfo.danceDivaList[0].costumeModelId, ref a_out_battle);
        }

        // // RVA: 0xAF5998 Offset: 0xAF5998 VA: 0xAF5998
        public bool Check(int a_id_vl, int a_id_mc, int a_id_dv, int a_id_cs, ref int a_out_battle)
		{
			for(int i = 0; i < m_data_int[0].Count; i++)
			{
				if(m_data_int[0][i] == a_id_vl || m_data_int[0][i] == 0)
				{
					if(m_data_int[1][i] == a_id_mc || m_data_int[1][i] == 0)
					{
						if (m_data_int[2][i] == a_id_dv || m_data_int[2][i] == 0)
						{
							if (m_data_int[3][i] == a_id_cs || m_data_int[3][i] == 0)
							{
								a_out_battle = m_data_int[4][i];
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
