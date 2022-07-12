
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
            UnityEngine.Debug.LogError("TODO ParameterData_ValkyrieChangeBattle Check");
            return true;
        }

        // // RVA: 0xAF5998 Offset: 0xAF5998 VA: 0xAF5998
        // public bool Check(int a_id_vl, int a_id_mc, int a_id_dv, int a_id_cs, ref int a_out_battle) { }
    }
}