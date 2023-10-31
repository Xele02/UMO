using System;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneFrameTexture : IconTexture
	{
		private static readonly Rect BaseUv = new Rect(0, 0, 1, 1); // 0x0
		private static readonly Rect CardUv = BaseUv; // 0x10
		private bool m_useCardUv; // 0x20

		// RVA: 0x15A62E4 Offset: 0x15A62E4 VA: 0x15A62E4
		public SceneFrameTexture(bool useCardUv = false)
		{
			m_useCardUv = useCardUv;
		}

		// RVA: 0x15A6304 Offset: 0x15A6304 VA: 0x15A6304 Slot: 16
		public override void Set(RawImageEx image)
		{
			if(Material != null)
			{
				if(image != null)
				{
					image.MaterialAdd = Material;
					base.Set(image);
					if(!m_useCardUv)
					{
						image.uvRect = BaseUv;
					}
					else
					{
						image.uvRect = CardUv;
					}
				}
			}
		}
	}

	public class SceneFrameTextureCache : IconTextureCache
	{
		private bool m_useCardUv; // 0x20

		// RVA: 0x15A6610 Offset: 0x15A6610 VA: 0x15A6610
		public SceneFrameTextureCache() : base(1)
		{
			return;
		}

		// // RVA: 0x15A661C Offset: 0x15A661C VA: 0x15A661C
		// public void SetUseCardUv(bool useCardUv) { }

		// // RVA: 0x15A6624 Offset: 0x15A6624 VA: 0x15A6624 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x15A6634 Offset: 0x15A6634 VA: 0x15A6634 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			SceneFrameTexture tex = new SceneFrameTexture(m_useCardUv);
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// RVA: 0x15A66C4 Offset: 0x15A66C4 VA: 0x15A66C4
		public void Load(GameAttribute.Type attribute, int baseRare, int evolveId, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/sc/fr/{0:D2}/{1:D1}_{2:D1}.xab", attribute, baseRare, evolveId), callback);
		}
	}
}
