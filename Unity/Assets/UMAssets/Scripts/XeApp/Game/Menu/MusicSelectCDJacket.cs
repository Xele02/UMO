using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDJacket : LayoutLabelScriptBase
	{
		private static readonly int[] s_attrToIndex = new int[5] { 4, 0, 1, 2, 3 }; // 0x0
		[SerializeField]
		private RawImageEx m_jacketImage; // 0x18
		[SerializeField]
		private int m_jacketIndex; // 0x1C
		[SerializeField]
		private string m_frameAttrPreset; // 0x20
		[SerializeField]
		private List<RawImageEx> m_allImages; // 0x24
		[SerializeField]
		private MusicSelectCDButton m_cdButton; // 0x28
		private LayoutSymbolData m_symbolFrameAttr; // 0x2C
		private int m_latestJacketId = -1; // 0x30
		private bool m_latestJacketIsEvent; // 0x34
		private bool m_isHide; // 0x35

		private MusicJacketTextureCache jacketTexCache { get { return GameManager.Instance.MusicJacketTextureCache; } } //0x166DC50
		public int jacketIndex { get { return m_jacketIndex; } } //0x166DCEC

		// // RVA: 0x166DCF4 Offset: 0x166DCF4 VA: 0x166DCF4
		public void ChangeJacket(int jacketId, GameAttribute.Type attr, bool forEvent)
		{
			if(m_symbolFrameAttr != null)
			{
				m_symbolFrameAttr.GoToFrame("index", s_attrToIndex[(int)attr]);
			}
			m_jacketImage.enabled = false;
			m_latestJacketId = jacketId;
			if(forEvent)
			{
				m_latestJacketIsEvent = true;
				jacketTexCache.LoadForEvent(jacketId, (IiconTexture image) =>
				{
					//0x166E318
					if(m_latestJacketIsEvent && m_latestJacketId == jacketId && !m_isHide)
					{
						m_jacketImage.enabled = true;
						image.Set(m_jacketImage);
					}
				});
			}
			else
			{
				m_latestJacketIsEvent = false;
				jacketTexCache.Load(jacketId, (IiconTexture image) =>
				{
					//0x166E4AC
					if(!m_latestJacketIsEvent && m_latestJacketId == jacketId && !m_isHide)
					{
						m_jacketImage.enabled = true;
						image.Set(m_jacketImage);
					}
				});
			}
		}

		// RVA: 0x166DF70 Offset: 0x166DF70 VA: 0x166DF70
		public void Hide()
		{
			for(int i = 0; i < m_allImages.Count; i++)
			{
				m_allImages[i].enabled = false;
			}
			if(m_cdButton != null)
				m_cdButton.enabled = false;
			m_isHide = true;
		}

		// // RVA: 0x166E0C4 Offset: 0x166E0C4 VA: 0x166E0C4
		public void Show()
		{
			for(int i = 0; i < m_allImages.Count; i++)
			{
				m_allImages[i].enabled = true;
			}
			if(m_cdButton != null)
				m_cdButton.enabled = true;
			m_isHide = false;
		}

		// RVA: 0x166E218 Offset: 0x166E218 VA: 0x166E218 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			if(!string.IsNullOrEmpty(m_frameAttrPreset))
			{
				m_symbolFrameAttr = CreateSymbol(m_frameAttrPreset, layout);
			}
			Loaded();
			return true;
		}
	}
}
