using System;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicRatioTextureCache : IconTextureCache
	{
		public class MusicRatioTexture : IconTexture
		{
			private const float Width = 64;
			private const float Height = 50;
			private const int Column = 8;
			private const int Row = 10;
			public const int Unit = 80;

			public Material MaterialAdd { get; set; } // 0x20

			// RVA: 0x10541E0 Offset: 0x10541E0 VA: 0x10541E0
			public void Set(RawImageEx image, HighScoreRatingRank.Type rank)
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
				float w = Width / BaseTexture.width;
				float h = Height / BaseTexture.height;
				int idx = ((int)rank - 1) % Unit;
				image.uvRect = new Rect(w * (idx % Column), 
				1 - h * (idx / Column) - h, 
				w, h);
			}
		}

		private const int IconCount = 2;
		private const string TexturePath = "ct/mr/{0:D2}.xab";

		// RVA: 0x1053FD8 Offset: 0x1053FD8 VA: 0x1053FD8 Slot: 5
		public override void Terminated()
		{
			Clear();
		}

		// RVA: 0x1053FE0 Offset: 0x1053FE0 VA: 0x1053FE0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			MusicRatioTexture res = new MusicRatioTexture();
			SetupForSplitTexture(info, res);
			res.MaterialAdd = new Material(Shader.Find("XeSys/Unlit/SplitTextureAdd"));
			return res;
		}

		// // RVA: 0x10540CC Offset: 0x10540CC VA: 0x10540CC
		public void Load(HighScoreRatingRank.Type rank, Action<IiconTexture> callback)
		{
			Load(string.Format("ct/mr/{0:D2}.xab", ((int)rank - 1) / 80 + 1), callback);
		}

		// // RVA: 0x1054190 Offset: 0x1054190 VA: 0x1054190
		public void EntryCache()
		{
			if (HighScoreRatingRank.GetRankIDMax() < 1)
				return;
			for(int i = 1; i < HighScoreRatingRank.GetRankIDMax(); i++)
			{
				Load((HighScoreRatingRank.Type)i, null);
			}
		}
	}
}
