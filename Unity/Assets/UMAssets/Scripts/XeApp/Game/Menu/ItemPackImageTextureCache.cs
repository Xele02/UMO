using System;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ItemPackImageTextureCache : IconTextureCache
	{
		public enum Type
		{
			None = 0,
			Pack1 = 1,
			Pack2 = 2,
			Num = 3,
		}

		public class ItemPackImageTexture : IconTexture
		{
			private const float Width = 128;
			private const float Height = 128;
			private const int Column = 4;
			private const int Row = 4;
			public const int Unit = 16;

			public Material MaterialAdd { get; set; } // 0x20

			// RVA: 0x14BCEE8 Offset: 0x14BCEE8 VA: 0x14BCEE8
			public void Set(RawImageEx image, Type type)
			{
				if(Material != null)
				{
					if(image != null)
					{
						image.material = Material;
						image.MaterialMul = Material;
						image.MaterialAdd = MaterialAdd;
						image.texture = BaseTexture;
						image.MaterialMul.SetTexture("_MainTex", BaseTexture);
						image.MaterialMul.SetTexture("_MaskTex", MaskTexture);
						image.MaterialAdd.SetTexture("_MainTex", BaseTexture);
						image.MaterialAdd.SetTexture("_MaskTex", MaskTexture);
					}
				}
				image.uvRect = new Rect(128.0f / BaseTexture.width * (((int)type - 1) % 4), 
					1 - 128.0f / BaseTexture.height * (((int)type - 1) / 4) - 128.0f / BaseTexture.height, 
					128.0f / BaseTexture.width, 128.0f / BaseTexture.height);
			}
		}
		private const string TexturePath = "ct/ip/{0:D2}.xab";

		// RVA: 0x14BCD00 Offset: 0x14BCD00 VA: 0x14BCD00 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x14BCD08 Offset: 0x14BCD08 VA: 0x14BCD08 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			ItemPackImageTexture tex = new ItemPackImageTexture();
			SetupForSplitTexture(info, tex);
			tex.MaterialAdd = new Material(Shader.Find("XeSys/Unlit/SplitTextureAdd"));
			return tex;
		}

		// RVA: 0x14BCDF4 Offset: 0x14BCDF4 VA: 0x14BCDF4
		public void Load(Type type, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/ip/{0:D2}.xab", ((int)type - 1) / 16 + 1), callback);
		}

		// // RVA: 0x14BCEB0 Offset: 0x14BCEB0 VA: 0x14BCEB0
		// public void EntryCache() { }
	}
}
