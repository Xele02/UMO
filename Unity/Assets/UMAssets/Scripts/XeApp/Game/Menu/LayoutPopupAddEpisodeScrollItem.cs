using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutPopupAddEpisodeScrollItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_episodeName; // 0x20
		[SerializeField]
		private RawImageEx m_icon; // 0x24
		[SerializeField]
		private ActionButton m_btnShowAddEpisode; // 0x28

		public Action<int, LayoutPopupAddEpisode.Type> OnclickAddEpisode { get; set; } // 0x2C
		public int EpisodeId { get; set; } // 0x30
		public LayoutPopupAddEpisode.Type Type { get; set; } // 0x34

		// RVA: 0x15E78A8 Offset: 0x15E78A8 VA: 0x15E78A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_btnShowAddEpisode.AddOnClickCallback(() =>
			{
				//0x15E7B38
				if(OnclickAddEpisode != null)
					OnclickAddEpisode.Invoke(EpisodeId, Type);
			});
			Loaded();
			return true;
		}

		// RVA: 0x15E7960 Offset: 0x15E7960 VA: 0x15E7960
		public void SetEpisodeName(string text)
		{
			if(m_episodeName != null)
			{
				m_episodeName.text = text;
			}
		}

		// RVA: 0x15E7A20 Offset: 0x15E7A20 VA: 0x15E7A20
		public void SetImageIcon(int id)
		{
			GameManager.Instance.ItemTextureCache.Load(id, (IiconTexture texture) =>
			{
				//0x15E7BAC
				if(texture != null)
				{
					texture.Set(m_icon);
				}
			});
		}
	}
}
