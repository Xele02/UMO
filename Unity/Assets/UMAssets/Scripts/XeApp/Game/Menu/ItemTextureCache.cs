using System;

namespace XeApp.Game.Menu
{
	public class ItemTextureCache : IconTextureCache
	{
		// RVA: 0x14BD444 Offset: 0x14BD444 VA: 0x14BD444
		public ItemTextureCache() : base(40)
		{
			return;
		}

		// // RVA: 0x14BD450 Offset: 0x14BD450 VA: 0x14BD450 Slot: 5
		// public override void Terminated() { }

		// // RVA: 0x14BD458 Offset: 0x14BD458 VA: 0x14BD458 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			ItemTexture tex = new ItemTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x14BD4E0 Offset: 0x14BD4E0 VA: 0x14BD4E0
		public void Load(int id, Action<IiconTexture> callBack)
		{
			Load(MakeItemIconTexturePath(id, 0), callBack);
		}

		// // RVA: 0x14BD918 Offset: 0x14BD918 VA: 0x14BD918
		public void Load(int id, int subId, Action<IiconTexture> callBack)
		{
			Load(MakeItemIconTexturePath(id, subId), callBack);
		}

		// // RVA: 0x14BD94C Offset: 0x14BD94C VA: 0x14BD94C
		// public void LoadEmblem(int emblemId, Action<IiconTexture> callback) { }

		// // RVA: 0x14BDA14 Offset: 0x14BDA14 VA: 0x14BDA14
		// public void TryInstallEmblem(int emblemId) { }

		// // RVA: 0x14BDAC4 Offset: 0x14BDAC4 VA: 0x14BDAC4
		public void TryInstall(int id, int subId = 0)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeItemIconTexturePath(id, subId));
		}

		// // RVA: 0x14BDB7C Offset: 0x14BDB7C VA: 0x14BDB7C
		// private static int ConvertDegreeTexId(int itemId) { }

		// // RVA: 0x14BD984 Offset: 0x14BD984 VA: 0x14BD984
		// public static string MakeEmblemIconTexturePath(int emblemId) { }

		// // RVA: 0x14BD514 Offset: 0x14BD514 VA: 0x14BD514
		public static string MakeItemIconTexturePath(int id, int subId = 0)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category val = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id);
			int val2 = 0;
			if ((int)val < 6)
			{
				if (val != EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene/*4*/)
				{
					val2 = id;
					//!!break;
				}
				else
				{
					TodoLogger.Log(0, "MakeItemIconTexturePath");
					/*int val3 = EKLNMHFCAOI.DEACAHNLMNI(id);
					if(val3 < 1)
					{
						//LAB_014bd7d8
						val2 = 40000;
						!!break;
					}
					else
					{
						IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene
					}*/
				}
			}
			else
			{
				TodoLogger.Log(0, "MakeItemIconTexturePath");
				val = val - 14;
				switch (val)
				{
					default:
						val2 = id;
						break;
				}
			}
			if(subId < 1)
			{
				return string.Format("ct/im/{0:D5}.xab", val2);
			}
			else
			{
				return string.Format("ct/im/{0:D5}_{1:D2}.xab", val2, subId);
			}
		}

		// // RVA: 0x14BDCF8 Offset: 0x14BDCF8 VA: 0x14BDCF8
		// public static string MakeDecoItemIconTexturePath(int id, int subId = 0) { }

		// // RVA: 0x14BDFFC Offset: 0x14BDFFC VA: 0x14BDFFC
		// public static string MakeDecoPosterIconTexturePath(int id, int subId = 0) { }

		// // RVA: 0x14BE294 Offset: 0x14BE294 VA: 0x14BE294
		// public static string MakeDecoCostumeTorsoIconTexturePath(int id, int subId = 0) { }

		// // RVA: 0x14BE194 Offset: 0x14BE194 VA: 0x14BE194
		// public static string MakeDecoVFFigureIconTexturePath(int id, int subId = 0) { }

		// // RVA: 0x14BE3FC Offset: 0x14BE3FC VA: 0x14BE3FC
		// private static string MakeDecoItemDirectoryPath(EKLNMHFCAOI.FKGCBLHOOCL type) { }

	}
}
