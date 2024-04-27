using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class EventStoryBannerListContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_image; // 0x20
		[SerializeField]
		private Text m_periodText; // 0x24
		[SerializeField]
		private ActionButton m_button; // 0x28
		private AbsoluteLayout eventBannerBtn; // 0x2C
		private AbsoluteLayout newMarkLayer; // 0x30
		private TexUVListManager m_uvMan; // 0x34
		private int m_eventId; // 0x38
		private string m_period = ""; // 0x3C

		// RVA: 0xB8F400 Offset: 0xB8F400 VA: 0xB8F400
		private void Start()
		{
			return;
		}

		// RVA: 0xB8F404 Offset: 0xB8F404 VA: 0xB8F404
		private void Update()
		{
			return;
		}

		// RVA: 0xB8F408 Offset: 0xB8F408 VA: 0xB8F408
		public void Setup(int _eventId, string _period)
		{
			m_eventId = _eventId;
			m_period = _period;
		}

		// RVA: 0xB8F414 Offset: 0xB8F414 VA: 0xB8F414
		public void ShowNewMark(bool isNew)
		{
			newMarkLayer.StartChildrenAnimGoStop(isNew ? "01" : "02");
		}

		// RVA: 0xB8F4A8 Offset: 0xB8F4A8 VA: 0xB8F4A8
		public void SetStatus(Action<int> Onclick)
		{
			m_image.enabled = false;
			GameManager.Instance.EventBannerTextureCache.LoadBanner(m_eventId, (IiconTexture image) =>
			{
				//0xB8F978
				m_image.enabled = true;
				image.Set(m_image);
			});
			if(m_eventId < 1000)
			{
				m_period = "---";
			}
			m_button.AddOnClickCallback(() =>
			{
				//0xB8FAA4
				Onclick(m_eventId);
			});
			if(m_periodText != null)
			{
				m_periodText.text = m_period;
				m_periodText.alignByGeometry = true;
				m_periodText.verticalOverflow = VerticalWrapMode.Truncate;
				m_periodText.horizontalOverflow = HorizontalWrapMode.Wrap;
				m_periodText.resizeTextForBestFit = true;
			}
		}

		// RVA: 0xB8F7B4 Offset: 0xB8F7B4 VA: 0xB8F7B4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			eventBannerBtn = layout.FindViewById("sw_pop_eve_story_btn_bnr_anim") as AbsoluteLayout;
			newMarkLayer = layout.FindViewByExId("sw_pop_eve_story_btn_bnr_anim_sw_new_onoff") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
