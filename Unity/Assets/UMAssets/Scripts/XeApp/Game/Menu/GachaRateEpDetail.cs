using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateEpDetail : GachaRateElemBase
	{
		[SerializeField]
		private Text m_episodeContent; // 0x24
		private int m_episodeId; // 0x28

		public Action<int> onClickRewardButton { private get; set; } // 0x2C

		// RVA: 0xEE44A8 Offset: 0xEE44A8 VA: 0xEE44A8
		public void SetEpisodeId(int episodeId)
		{
			m_episodeId = episodeId;
		}

		// RVA: 0xEE44B0 Offset: 0xEE44B0 VA: 0xEE44B0
		public void SetEpisodeContent(string text)
		{
			m_episodeContent.text = text;
		}

		// RVA: 0xEE44EC Offset: 0xEE44EC VA: 0xEE44EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
