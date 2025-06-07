using System;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBossTexture : IconTexture
	{
	}

	public class RaidBossTextureCache : IconTextureCache
	{
		public const string BundleFormatForBoss = "ct/rd/bs/{0:D3}_{1:D2}.xab";
		public const string BundleFormatForBossCutin = "ct/rd/bc/{0:D3}_{1:D2}.xab";
		public const string BundleFormatForBossIcon = "ct/rd/bi/{0:D3}_{1:D2}.xab";
		private StringBuilder m_bundleName = new StringBuilder(32); // 0x20

		// RVA: 0x1BCC238 Offset: 0x1BCC238 VA: 0x1BCC238
		public RaidBossTextureCache() : base(1)
		{
			return;
		}

		// RVA: 0x1BCC2BC Offset: 0x1BCC2BC VA: 0x1BCC2BC Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x1BCC2C4 Offset: 0x1BCC2C4 VA: 0x1BCC2C4 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			RaidBossTexture res = new RaidBossTexture();
			SetupForSplitTexture(info, res);
			return res;
		}

		// RVA: 0x1BCC34C Offset: 0x1BCC34C VA: 0x1BCC34C
		public void LoadForBoss(int id, Action<IiconTexture> callBack)
		{
			m_bundleName.SetFormat("ct/rd/bs/{0:D3}_{1:D2}.xab", id, 1);
			Load(m_bundleName.ToString(), callBack);
		}

		// // RVA: 0x1BCC444 Offset: 0x1BCC444 VA: 0x1BCC444
		public void LoadForBossCutin(int id, Action<IiconTexture> callBack)
		{
			m_bundleName.SetFormat("ct/rd/bc/{0:D3}_{1:D2}.xab", id, 1);
			Load(m_bundleName.ToString(), callBack);
		}

		// // RVA: 0x1BCC53C Offset: 0x1BCC53C VA: 0x1BCC53C
		public void LoadForBossIcon(int id, Action<IiconTexture> callBack)
		{
			m_bundleName.SetFormat("ct/rd/bi/{0:D3}_{1:D2}.xab", id, 1);
			Load(m_bundleName.ToString(), callBack);
		}
	}
}
