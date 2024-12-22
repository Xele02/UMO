using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoNormalLotProductGetNormalLotItems(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenesList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.FindAll((MLIBEPGADJH_Scene.KKLDOOJBJMN _) =>
			{
				return _.PPEGAKEIEGM_En == 2/* && _.EKLIPGELKCL_Rarity == 5*/;
			});

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id] = (int)jsonData["productId"];
			res[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity] = (int)jsonData["quantity"];
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(new EDOHBJAPLPF_JsonData());
			for(int i = 0; i < (int)jsonData["quantity"]; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["item_count"] = 1;
				d["item_name"] = "scene";
				int id = scenesList[UnityEngine.Random.Range(0, scenesList.Count - 1)].BCCHOBPJJKE_Id;
				d["item_value"] = id;
				res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(d);
			}
			
			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
