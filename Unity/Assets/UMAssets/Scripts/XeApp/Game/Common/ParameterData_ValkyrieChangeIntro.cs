
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieChangeIntro : ParameterData
    {
        public const int DATA_VL = 0;
        public const int DATA_MC = 1;
        public const int DATA_DV = 2;
        public const int DATA_CS = 3;
        public const int DATA_INTRO = 4;
        public const int DATA_SKY = 5;

        // // RVA: 0xAF66C8 Offset: 0xAF66C8 VA: 0xAF66C8
        public bool Check(GameSetupData a_setup_data, ref int a_out_intro, ref int a_out_intro_sky)
        {
			return Check(a_setup_data.teamInfo.prismValkyrieId, a_setup_data.teamInfo.danceDivaList[0].prismDivaId, a_setup_data.teamInfo.danceDivaList[0].prismCostumeModelId,
						a_setup_data.musicInfo.musicId, ref a_out_intro, ref a_out_intro_sky);
        }

        // // RVA: 0xAF68A4 Offset: 0xAF68A4 VA: 0xAF68A4
        public bool Check(int a_id_vl, int a_id_dv, int a_id_cs, int a_id_mc, ref int a_out_intro, ref int a_out_intro_sky)
		{
			for(int i = 0; i < m_data_int[0].Count; i++)
			{
				if(m_data_int[0][i] == a_id_vl)
				{
					if(m_data_int[1][i] != a_id_mc && m_data_int[1][i] != 0)
					{
						continue;
					}
					if (m_data_int[2][i] != a_id_dv && m_data_int[2][i] != 0)
					{
						continue;
					}
					if (m_data_int[3][i] != a_id_cs && m_data_int[3][i] != 0)
					{
						continue;
					}
					a_out_intro = m_data_int[4][i];
					a_out_intro_sky = m_data_int[5][i];
					return true;
				}
			}
			return false;
		}
    }
}
