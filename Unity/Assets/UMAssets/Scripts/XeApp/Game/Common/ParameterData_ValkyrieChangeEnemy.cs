
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieChangeEnemy : ParameterData
    {
        public const int DATA_VL = 0;
        public const int DATA_MC = 1;
        public const int DATA_DV = 2;
        public const int DATA_CS = 3;
        public const int DATA_EN = 4;

        // // RVA: 0xAF5EAC Offset: 0xAF5EAC VA: 0xAF5EAC
        public bool Check(GameSetupData a_setup_data, ref int a_out_enemy)
		{
			return Check(a_setup_data.teamInfo.prismValkyrieId, a_setup_data.teamInfo.danceDivaList[0].prismDivaId, a_setup_data.teamInfo.danceDivaList[0].prismCostumeModelId,
				a_setup_data.musicInfo.musicId, ref a_out_enemy);
		}

        // // RVA: 0xAF6080 Offset: 0xAF6080 VA: 0xAF6080
        public bool Check(int a_id_vl, int a_id_dv, int a_id_cs, int a_id_mc, ref int a_out_enemy)
		{
			for(int i = 0; i < m_data_int[0].Count; i++)
			{
				if(m_data_int[0][i] == a_id_vl && 
					(m_data_int[1][i] == a_id_mc || m_data_int[1][i] == 0) && 
					(m_data_int[2][i] == a_id_dv || m_data_int[2][i] == 0) &&
					(m_data_int[3][i] == a_id_cs || m_data_int[3][i] == 0))
				{
					a_out_enemy = m_data_int[3][i];
					return true;
				}
			}
			return false;
		}
    }
}
