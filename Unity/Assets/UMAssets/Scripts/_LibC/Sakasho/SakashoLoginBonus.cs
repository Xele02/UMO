using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoLoginBonusGetLoginBonuses(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = 1;
			res["next_page"] = 0;
			res["previous_page"] = 0;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
