using UnityEngine;

namespace XeApp.Game.Common.View
{
	public class ViewBookMarkMusicData : MonoBehaviour
	{
		//// RVA: 0xD30ECC Offset: 0xD30ECC VA: 0xD30ECC
		//public static bool KNKGEALPDGF(int DLAEJOBELBH, int OIPCCBHIKIA) { }

		//// RVA: 0xD30FB8 Offset: 0xD30FB8 VA: 0xD30FB8
		public static bool KNKGEALPDGF(int DLAEJOBELBH)
		{
			bool res = false;
			for(int i = 0; i < 3; i++)
			{
				res |= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_Save.KCCLEHLLOFG_Common.KNKGEALPDGF_GetBookmark(DLAEJOBELBH, i);
			}
			return res;
		}

		//// RVA: 0xD310BC Offset: 0xD310BC VA: 0xD310BC
		//public static void OBHMLEOHEFF(int DLAEJOBELBH, int OIPCCBHIKIA, bool MHBBJADMHPN) { }

		//// RVA: 0xD311BC Offset: 0xD311BC VA: 0xD311BC
		//public static string BDCDCCJHOCD(int OIPCCBHIKIA) { }

		//// RVA: 0xD312A0 Offset: 0xD312A0 VA: 0xD312A0
		//public static void GLMEPJIKBLP(int OIPCCBHIKIA, string OPFGFINHFCE) { }

		//// RVA: 0xD3138C Offset: 0xD3138C VA: 0xD3138C
		//public static List<IBJAKJJICBC> GLKIJNGMAGB(List<VerticalMusicDataList> DONOKFOFNBB, int FJFHNAJFNMK) { }
	}
}
