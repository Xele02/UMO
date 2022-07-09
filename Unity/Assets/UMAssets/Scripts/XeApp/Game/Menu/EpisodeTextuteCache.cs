using System;
using System.Text;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EpisodeTextuteCache : IconTextureCache
	{
		public const string EpisodeIconTexturePath = "ct/ep/ic/{0:D4}.xab";
		public const string EpisodeBgTexturePath = "ct/ep/bg/{0:D4}.xab";
		public const string DivaBustupTexturePath = "ct/dv/tx/bu/{0:D3}_{1:D3}.xab";
		public const string DivaBustupPalleteChangeTexturePath = "ct/dv/tx/bu/{0:D3}_{1:D3}_{2:D2}.xab";
		private StringBuilder m_strBuilder = new StringBuilder(24); // 0x20
		private static readonly Rect imageUv = new Rect(0.117188f, 0, 0.765625f, 1); // 0x0
		private static readonly Rect[] BustupUvTbl = new Rect[11] {
			new Rect(0.337891f, 0.193359f, 0.289062f, 0.757812f),
			new Rect(0.353516f, 0.21875f, 0.291016f, 0.75f),
			new Rect(0.367188f, 0.216797f, 0.279297f, 0.71875f),
			new Rect(0.355469f, 0.199219f, 0.291016f, 0.75f),
			new Rect(0.328125f, 0.201172f, 0.304688f, 0.783203f),
			new Rect(0.357422f, 0.228516f, 0.291016f, 0.75f),
			new Rect(0.355469f, 0.226562f, 0.287109f, 0.734375f),
			new Rect(0.380859f, 0.228516f, 0.267578f, 0.689453f),
			new Rect(0.328125f, 0.234375f, 0.279297f, 0.716797f),
			new Rect(0.339844f, 0.255859f, 0.253906f, 0.650391f),
			new Rect(0.345703f, 0.21875f, 0.28125f, 0.716797f),
		}; // 0x10

		// public static Rect ImageUv { get; } 0xF09714

		// RVA: 0xF097A8 Offset: 0xF097A8 VA: 0xF097A8 Slot: 5
		// public override void Terminated() { }

		// RVA: 0xF097B0 Offset: 0xF097B0 VA: 0xF097B0 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			EpisodeTexture tex = new EpisodeTexture();
			SetupForSplitTexture(info, tex);
			return tex;
		}

		// // RVA: 0xEF3A6C Offset: 0xEF3A6C VA: 0xEF3A6C
		// public void Load(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0xEF3B44 Offset: 0xEF3B44 VA: 0xEF3B44
		// public void LoadBg(int id, Action<IiconTexture> callBack) { }

		// // RVA: 0xF09838 Offset: 0xF09838 VA: 0xF09838
		public void LoadDivaBustupTexture(int divaId, int modelId, int colorId, Action<IiconTexture, Rect> complete)
		{
			m_strBuilder.Clear();
			if(colorId < 1)
			{
				m_strBuilder.SetFormat(DivaBustupTexturePath, divaId, modelId);
				if(!KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.PPCCFNAPHCH(m_strBuilder.ToString()))
				{
					int id = FindEpisodeIdFromModelId(divaId, modelId);
					if(id == 0)
						id = 1;
					m_strBuilder.SetFormat(EpisodeIconTexturePath, id);
				}
			}
			else
			{
				m_strBuilder.SetFormat(DivaBustupPalleteChangeTexturePath, divaId, modelId, colorId);
			}
			Load(m_strBuilder.ToString(), (IiconTexture iconTexture) => {
				//0xF0A880
				if(complete != null)
				{
					complete(iconTexture, BustupUvTbl[divaId]);
				}
			});
		}

		// // RVA: 0xF09B6C Offset: 0xF09B6C VA: 0xF09B6C
		private int FindEpisodeIdFromModelId(int divaId, int modelId)
		{
			UnityEngine.Debug.LogError("TODO FindEpisodeIdFromModelId");
			return 0;
		}

		// // RVA: 0xF0A150 Offset: 0xF0A150 VA: 0xF0A150
		// public void TryInstallIcon(int episodeId) { }

		// // RVA: 0xF07014 Offset: 0xF07014 VA: 0xF07014
		// public void TryInstallIcon(List<PIGBBNDPPJC> episodeList) { }

		// // RVA: 0xF0A26C Offset: 0xF0A26C VA: 0xF0A26C
		// public void TryInstallBg(int episodeId) { }

	}
}
