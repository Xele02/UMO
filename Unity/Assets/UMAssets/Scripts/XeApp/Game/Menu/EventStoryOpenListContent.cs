using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenListContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_thumbnail; // 0x20
		[SerializeField]
		private Text m_titleText; // 0x24

		// RVA: 0xB934C8 Offset: 0xB934C8 VA: 0xB934C8
		public void SetThumbnail(int uniqueId, int index)
		{
			GameManager.Instance.EventBannerTextureCache.LoadEventStoryThumbnail(uniqueId, (IiconTexture texture) =>
			{
				//0xB93E84
				texture.Set(m_thumbnail);
				m_thumbnail.uvRect = EventStoryListContent.CalcThumbnailRect(index, new Vector2(texture.BaseTexture.width, texture.BaseTexture.height));
			});
		}

		// RVA: 0xB93628 Offset: 0xB93628 VA: 0xB93628
		public void SetTitle(string title)
		{
			m_titleText.text = title;
		}
	}
}
