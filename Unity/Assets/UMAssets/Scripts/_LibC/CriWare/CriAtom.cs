
using System;
using System.Collections.Generic;
using CriWare;

namespace ExternLib
{
    public static partial class LibCriWare
    {
		class CategoryData
		{
			public int id;
			public float volume;
		}

		static Dictionary<int, CategoryData> categories = new Dictionary<int, CategoryData>();

        public static void criAtomExCategory_SetVolumeById(int id, float volume)
        {
			if (!categories.ContainsKey(id))
			{
				categories[id] = new CategoryData();
				categories[id].id = id;
			}
			categories[id].volume = volume;
			TodoLogger.Log(0, "criAtomExCategory_SetVolumeById");
        }

        public static float criAtomExCategory_GetVolumeById(int id)
        {
			if(categories.ContainsKey(id))
			{
				return categories[id].volume;
			}
            return 0;
        }
    }
}
