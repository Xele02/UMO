
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieChangeExplosion : ParameterData
    {
        public const int DATA_EN = 0;

        // // RVA: 0xAF651C Offset: 0xAF651C VA: 0xAF651C
        public bool Check(GameSetupData a_setup_data)
		{
			return Check(a_setup_data.musicInfo.GetEnemyInfo().EJNIMIAPJFJ_Id);
		}

        // // RVA: 0xAF658C Offset: 0xAF658C VA: 0xAF658C
        public bool Check(int a_id_en)
		{
			for(int i = 0; i < m_data_int[DATA_EN].Count; i++)
			{
				if (m_data_int[DATA_EN][i] == a_id_en)
					return true;
			}
			return false;
		}
    }
}
