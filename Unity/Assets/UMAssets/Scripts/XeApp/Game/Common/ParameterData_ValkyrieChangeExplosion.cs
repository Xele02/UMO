
namespace XeApp.Game.Common
{
    public class ParameterData_ValkyrieChangeExplosion : ParameterData
    {
        public const int DATA_EN = 0;

        // // RVA: 0xAF651C Offset: 0xAF651C VA: 0xAF651C
        public bool Check(GameSetupData a_setup_data)
		{
			TodoLogger.Log(0, "ParameterData_ValkyrieChangeExplosion Check");
			return true;
		}

        // // RVA: 0xAF658C Offset: 0xAF658C VA: 0xAF658C
        // public bool Check(int a_id_en) { }
    }
}
