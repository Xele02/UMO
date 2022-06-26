using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoPlayerDataLoadPlayerData(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoPlayerDataLoadPlayerData "+json);
            
            EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
            EDOHBJAPLPF_JsonData names = jsonData["names"];

            // Hack directly send response
            string message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220622141305"",
    ""SAKASHO_CURRENT_DATE_TIME"": "+Utility.GetCurrentUnixTime()+@",
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""created_at"": 1501751856,
    ""data_status"": 1,
    ""updated_at"": 1656166393,
    ""player"": {";
            for(int i = 0; i < names.HNBFOAJIIAL_Count; i++)
            {
                string str = (string)names[i];
                message += @"
        """+str+@""":{}"+(i != names.HNBFOAJIIAL_Count -1 ? "," : "");
            }
            message += @"
    }
}";
            //UnityEngine.Debug.Log(message);
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }
    }
}