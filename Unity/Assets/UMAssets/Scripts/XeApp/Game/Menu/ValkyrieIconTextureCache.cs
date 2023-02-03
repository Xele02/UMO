
using System;

namespace XeApp.Game.Menu
{
	public class ValkyrieIconTexture : IconTexture
	{
	}

	public class ValkyrieIconTextureCache : IconTextureCache
	{
		// // RVA: 0x16557F4 Offset: 0x16557F4 VA: 0x16557F4 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// // RVA: 0x16557FC Offset: 0x16557FC VA: 0x16557FC Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			ValkyrieIconTexture tex = new ValkyrieIconTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0x1655884 Offset: 0x1655884 VA: 0x1655884
		public void Load(int valkyrie, int form, Action<IiconTexture> callBack)
		{
			Load(MakeIconBundleName(valkyrie, form), callBack);
		}

		// // RVA: 0x1655A58 Offset: 0x1655A58 VA: 0x1655A58
		public void LoadPortraitIcon(int valkyrie, int form, Action<IiconTexture> callBack)
		{
			Load(MakePortraitIconBundleName(valkyrie, form), callBack);
		}

		// // RVA: 0x1655C2C Offset: 0x1655C2C VA: 0x1655C2C
		// public void TryInstallPortraitIcon(int valkyrie) { }

		// // RVA: 0x16558B8 Offset: 0x16558B8 VA: 0x16558B8
		public static string MakeIconBundleName(int valkyrie, int form)
		{
			return string.Format("ct/vl/01/{0:D2}_{1:D2}.xab", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[valkyrie - 1].DAJGPBLEEOB_ModelId, form + 1);
		}

		// // RVA: 0x1655A8C Offset: 0x1655A8C VA: 0x1655A8C
		public static string MakePortraitIconBundleName(int valkyrie, int form)
		{
			return string.Format("ct/vl/02/{0:D2}_{1:D2}.xab", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[valkyrie - 1].DAJGPBLEEOB_ModelId, form + 1);
		}
	}
}
