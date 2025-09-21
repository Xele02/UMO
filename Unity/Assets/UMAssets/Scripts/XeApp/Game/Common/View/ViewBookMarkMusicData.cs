using UnityEngine;

namespace XeApp.Game.Common.View
{
	public class ViewBookMarkMusicData : MonoBehaviour
	{
		//// RVA: 0xD30ECC Offset: 0xD30ECC VA: 0xD30ECC
		public static bool KNKGEALPDGF(int _DLAEJOBELBH_MusicId, int _OIPCCBHIKIA_index)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KNKGEALPDGF_GetBookmark(_DLAEJOBELBH_MusicId, _OIPCCBHIKIA_index);
		}

		//// RVA: 0xD30FB8 Offset: 0xD30FB8 VA: 0xD30FB8
		public static bool KNKGEALPDGF(int _DLAEJOBELBH_MusicId)
		{
			bool res = false;
			for(int i = 0; i < 3; i++)
			{
				res |= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KNKGEALPDGF_GetBookmark(_DLAEJOBELBH_MusicId, i);
			}
			return res;
		}

		//// RVA: 0xD310BC Offset: 0xD310BC VA: 0xD310BC
		public static void OBHMLEOHEFF_SetBookmark(int _DLAEJOBELBH_MusicId, int _OIPCCBHIKIA_index, bool _MHBBJADMHPN_ChoiceSelected)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.DOGPMKIKKDA_SetBookmark(_DLAEJOBELBH_MusicId, _OIPCCBHIKIA_index, _MHBBJADMHPN_ChoiceSelected);
		}

		//// RVA: 0xD311BC Offset: 0xD311BC VA: 0xD311BC
		public static string BDCDCCJHOCD_GetBookmarkName(int _OIPCCBHIKIA_index)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NPGGEAJMFCB_GetBookmarkName(_OIPCCBHIKIA_index);
		}

		//// RVA: 0xD312A0 Offset: 0xD312A0 VA: 0xD312A0
		public static void GLMEPJIKBLP_SetBookmarkName(int _OIPCCBHIKIA_index, string _OPFGFINHFCE_name)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BAAGCGEGIMK_SetBookmarkName(_OIPCCBHIKIA_index, _OPFGFINHFCE_name);
		}

		//// RVA: 0xD3138C Offset: 0xD3138C VA: 0xD3138C
		//public static List<IBJAKJJICBC> GLKIJNGMAGB(List<VerticalMusicDataList> DONOKFOFNBB, int FJFHNAJFNMK) { }
	}
}
