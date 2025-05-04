using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System;
using System.Collections;
using XeApp.Core;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidEventBanner : LayoutLabelScriptBase
	{
		public enum Style
		{
			Enable = 0,
			Disable = 1,
			Ticket = 2,
			Period = 3,
			Counting = 4,
			Raid = 5,
		}

		[SerializeField]
		private RawImageEx m_eventBannerImage1; // 0x18
		[SerializeField]
		private RawImageEx m_eventBannerImage2; // 0x1C
		[SerializeField]
		private RawImageEx m_eventTicketImage; // 0x20
		[SerializeField]
		private RawImageEx m_timeImage; // 0x24
		[SerializeField]
		private ButtonBase m_bannerButton; // 0x28
		[SerializeField]
		private Text m_disabledText; // 0x2C
		[SerializeField]
		private Text m_limitTimeText; // 0x30
		[SerializeField]
		private NumberBase m_curTicketCount; // 0x34
		[SerializeField]
		private Material m_materialSource; // 0x38
		private LayoutSymbolData m_symbolMain; // 0x3C
		private LayoutSymbolData m_symbolStatus; // 0x40
		private string m_music_event_remain_prefix = ""; // 0x44
		private string m_music_event_remain_time = ""; // 0x48
		private StringBuilder m_bundleName = new StringBuilder(64); // 0x4C
		private const string TexturePath = "ct/ba/rd/{0:D5}.xab";
		private const string TextureBaseAssetFormat = "{0:D5}_base";
		private const string TextureMaskAssetFormat = "{0:D5}_mask";
		private Material m_materialInstance; // 0x50
		private Texture m_texture; // 0x54
		private Texture m_maskTexture; // 0x58
		private bool m_isDisabled; // 0x5C
		private bool m_isShow; // 0x64

		public Action onClickBanner { private get; set; } // 0x60

		// // RVA: 0x1BCE5EC Offset: 0x1BCE5EC VA: 0x1BCE5EC
		// public void TryEnter() { }

		// // RVA: 0x1BCE680 Offset: 0x1BCE680 VA: 0x1BCE680
		// public void TryLeave() { }

		// // RVA: 0x1BCE5FC Offset: 0x1BCE5FC VA: 0x1BCE5FC
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1BCE690 Offset: 0x1BCE690 VA: 0x1BCE690
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1BCE714 Offset: 0x1BCE714 VA: 0x1BCE714
		// public void Show() { }

		// // RVA: 0x1BCE798 Offset: 0x1BCE798 VA: 0x1BCE798
		// public void Hide() { }

		// // RVA: 0x1BCE81C Offset: 0x1BCE81C VA: 0x1BCE81C
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x1BCE848 Offset: 0x1BCE848 VA: 0x1BCE848
		public void ChangeEventBanner(int eventId)
		{
			m_bannerButton.Hidden = true;
			m_eventBannerImage1.enabled = false;
			m_eventBannerImage2.enabled = false;
			if(eventId == 0)
				return;
			this.StartCoroutineWatched(Co_LoadBanner(eventId, () =>
			{
				//0x1BCF200
				m_bannerButton.Hidden = false;
				m_eventBannerImage1.enabled = true;
				m_eventBannerImage2.enabled = true;
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7122BC Offset: 0x7122BC VA: 0x7122BC
		// // RVA: 0x1BCE964 Offset: 0x1BCE964 VA: 0x1BCE964
		private IEnumerator Co_LoadBanner(int eventId, Action callback)
		{
			string bundleName; // 0x1C
			int loadCount; // 0x20
			AssetBundleLoadAssetOperation op; // 0x24

			//0x1BCF2A4
			m_bundleName.SetFormat("ct/ba/rd/{0:D5}.xab", eventId);
			bundleName = m_bundleName.ToString();
			loadCount = 0;
			op = AssetBundleManager.LoadAssetAsync(bundleName, string.Format("{0:D5}_base", eventId), typeof(Texture));
			yield return op;
			m_texture = op.GetAsset<Texture>();
			loadCount++;
			op = AssetBundleManager.LoadAssetAsync(bundleName, string.Format("{0:D5}_mask", eventId), typeof(Texture));
			yield return op;
			m_maskTexture = op.GetAsset<Texture>();
			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
			}
			m_materialInstance.SetTexture("_MainTex", m_texture);
			m_materialInstance.SetTexture("_MaskTex", m_maskTexture);
			m_eventBannerImage1.MaterialMul = m_materialInstance;
			m_eventBannerImage1.material = m_materialInstance;
			m_eventBannerImage1.texture = m_texture;
			m_eventBannerImage1.uvRect = new Rect(0, 0.5f, 1, 0.5f);
			m_eventBannerImage2.MaterialMul = m_materialInstance;
			m_eventBannerImage2.material = m_materialInstance;
			m_eventBannerImage2.texture = m_texture;
			m_eventBannerImage2.uvRect = new Rect(0, 0, 1, 0.5f);
			callback();
		}

		// // RVA: 0x1BCEA44 Offset: 0x1BCEA44 VA: 0x1BCEA44
		// public void SetEventTicket(IiconTexture image) { }

		// // RVA: 0x1BCEB54 Offset: 0x1BCEB54 VA: 0x1BCEB54
		// public void SetDisableLabel(string label) { }

		// // RVA: 0x1BCEB90 Offset: 0x1BCEB90 VA: 0x1BCEB90
		// public void SetMusicEventRemainPrefix(string a_text) { }

		// // RVA: 0x1BCEBE4 Offset: 0x1BCEBE4 VA: 0x1BCEBE4
		// public void SetLimitTimeLabel(string label) { }

		// // RVA: 0x1BCEC34 Offset: 0x1BCEC34 VA: 0x1BCEC34
		// public void SetStyle(RaidEventBanner.Style style) { }

		// // RVA: 0x1BCEDB4 Offset: 0x1BCEDB4 VA: 0x1BCEDB4
		// public void SetTicketCount(int count) { }

		// RVA: 0x1BCEDF4 Offset: 0x1BCEDF4 VA: 0x1BCEDF4
		public void Release()
		{
			Resources.UnloadAsset(m_texture);
			Resources.UnloadAsset(m_maskTexture);
			m_texture = null;
			m_maskTexture = null;
			if(m_eventBannerImage1 != null)
			{
				m_eventBannerImage1.material = null;
				m_eventBannerImage1.MaterialMul = null;
				m_eventBannerImage1.MaterialAdd = null;
			}
			if(m_eventBannerImage2 != null)
			{
				m_eventBannerImage2.material = null;
				m_eventBannerImage2.MaterialMul = null;
				m_eventBannerImage2.MaterialAdd = null;
			}
		}

		// RVA: 0x1BCEFDC Offset: 0x1BCEFDC VA: 0x1BCEFDC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_materialInstance = new Material(m_materialSource);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStatus = CreateSymbol("status", layout);
			m_bannerButton.ClearOnClickCallback();
			m_bannerButton.AddOnClickCallback(() =>
			{
				//0x1BCF27C
				if(m_isDisabled)
					return;
				if(onClickBanner != null)
					onClickBanner();
			});
			m_eventTicketImage.enabled = false;
			Loaded();
			return true;
		}
	}
}
