
using System;

namespace XeApp.Game.Menu
{
	public class CostumeIconTexture : IconTexture
	{
		//
	}
	public class CostumeTextureCache : IconTextureCache
	{
		// RVA: 0x16E8DA0 Offset: 0x16E8DA0 VA: 0x16E8DA0
		public CostumeTextureCache() : base(0)
		{
			return;
		}

		// // RVA: 0x16E8DAC Offset: 0x16E8DAC VA: 0x16E8DAC Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x16E8DB4 Offset: 0x16E8DB4 VA: 0x16E8DB4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			CostumeIconTexture icon = new CostumeIconTexture();
			SetupForSplitTexture(info, icon);
			return icon;
		}

		// // RVA: 0x16E8E3C Offset: 0x16E8E3C VA: 0x16E8E3C
		public void Load(int cosId, int colorId, Action<IiconTexture> callBack)
		{
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo costume = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[cosId - 1];
			Load(MakeCostumeTexturePath(costume.AHHJLDLAPAN_PrismDivaId, costume.DAJGPBLEEOB_PrismCostumeModelId, colorId), callBack);
		}

		// // RVA: 0x16E8948 Offset: 0x16E8948 VA: 0x16E8948
		public void Load(int divaId, int modelId, int colorId, Action<IiconTexture> callBack)
		{
			Load(MakeCostumeTexturePath(divaId, modelId, colorId), callBack);
		}

		// // RVA: 0x16DF598 Offset: 0x16DF598 VA: 0x16DF598
		public static string MakeCostumeTexturePath(int divaId, int modelId, int colorId)
		{
			if (colorId == 0)
				return string.Format("ct/dv/co/{0:D2}_{1:D3}.xab", divaId, modelId);
			else
				return string.Format("ct/dv/co/{0:D2}_{1:D3}_{2:D2}.xab", divaId, modelId, colorId);
		}

		// // RVA: 0x16E8FD0 Offset: 0x16E8FD0 VA: 0x16E8FD0
		public void TryInstallCostume(int divaId, int modelId, int colorId)
		{
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeCostumeTexturePath(divaId, modelId, colorId));
		}
	}
}
