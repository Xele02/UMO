using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutSNSTalkLeft : LayoutSNSBase
	{
		[SerializeField]
		private Text[] m_talk; // 0x14
		[SerializeField]
		private Text[] m_name; // 0x18
		[SerializeField]
		private RawImageEx[] m_image; // 0x1C
		private AbsoluteLayout m_windowTbl; // 0x20
		private AbsoluteLayout[] m_emotionTbl; // 0x24
		private AbsoluteLayout[] m_windowAnim; // 0x28
		private RectTransform m_rootRt; // 0x2C
		private IMKNEDJDNGC m_viewData; // 0x30
		private readonly string[] m_layoutEmotionFindTbl = new string[3] { "", "sw_sns_l_anim_swtbl_sel_sns_emo_l", "sw_sns_ls_anim_swtbl_sel_sns_emo_l" }; // 0x34
		private readonly string[] m_layoutWindowAnimFindTbl = new string[3] { "", "swtbl_sns_l_sw_sns_l_anim", "swtbl_sns_l_sw_sns_ls_anim" }; // 0x38

		//// RVA: 0x193ABA8 Offset: 0x193ABA8 VA: 0x193ABA8 Slot: 7
		//public override void SetPosition(float pos_x, float pos_y) { }

		//// RVA: 0x193AC90 Offset: 0x193AC90 VA: 0x193AC90 Slot: 8
		//public override void Show() { }

		// RVA: 0x193AD68 Offset: 0x193AD68 VA: 0x193AD68 Slot: 9
		public override void Hide()
		{
			if (m_viewData == null)
				return;
			AbsoluteLayout w = GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId);
			if (w == null)
				return;
			w.StartChildrenAnimGoStop("st_out", "st_out");
			gameObject.SetActive(false);
		}

		//// RVA: 0x193AE24 Offset: 0x193AE24 VA: 0x193AE24 Slot: 10
		//public override void In() { }

		//// RVA: 0x193AF54 Offset: 0x193AF54 VA: 0x193AF54 Slot: 11
		//public override void Out() { }

		//// RVA: 0x193AFEC Offset: 0x193AFEC VA: 0x193AFEC Slot: 12
		public override bool IsPlaying()
		{
			return GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId).IsPlayingChildren();
		}

		//// RVA: 0x193B03C Offset: 0x193B03C VA: 0x193B03C
		private AbsoluteLayout GetWindowAnim(int windowSizeId)
		{
			if(windowSizeId > -1)
			{
				if(windowSizeId < m_windowAnim.Length)
				{
					return m_windowAnim[windowSizeId];
				}
			}
			return null;
		}

		//// RVA: 0x193AD50 Offset: 0x193AD50 VA: 0x193AD50
		//private AbsoluteLayout GetWindowAnim() { }

		//// RVA: 0x193B0B8 Offset: 0x193B0B8 VA: 0x193B0B8 Slot: 13
		//public override void SetStatus(SNSTalkCreater.ViewTalk talk) { }

		//// RVA: 0x193B1C8 Offset: 0x193B1C8 VA: 0x193B1C8
		//public void SetName(string name) { }

		//// RVA: 0x193B31C Offset: 0x193B31C VA: 0x193B31C
		//public void SetTalk(string talk) { }

		//// RVA: 0x193B614 Offset: 0x193B614 VA: 0x193B614
		//public void SetEmotion(int emotionId) { }

		//// RVA: 0x193B768 Offset: 0x193B768 VA: 0x193B768
		//public void SetWindowSize(int sizeId) { }

		//// RVA: 0x193B470 Offset: 0x193B470 VA: 0x193B470
		//private void SetDivaIconTexture(int divaId) { }

		// RVA: 0x193B81C Offset: 0x193B81C VA: 0x193B81C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowTbl = layout.Root[0] as AbsoluteLayout;
			m_emotionTbl = new AbsoluteLayout[m_layoutEmotionFindTbl.Length];
			for(int i = 0; i < m_layoutEmotionFindTbl.Length; i++)
			{
				if(!string.IsNullOrEmpty(m_layoutEmotionFindTbl[i]))
				{
					m_emotionTbl[i] = layout.FindViewByExId(m_layoutEmotionFindTbl[i]) as AbsoluteLayout;
				}
			}
			m_windowAnim = new AbsoluteLayout[m_layoutWindowAnimFindTbl.Length];
			for(int i = 0; i < m_layoutWindowAnimFindTbl.Length; i++)
			{
				if(!string.IsNullOrEmpty(m_layoutWindowAnimFindTbl[i]))
				{
					m_windowAnim[i] = layout.FindViewByExId(m_layoutWindowAnimFindTbl[i]) as AbsoluteLayout;
				}
			}
			m_rootRt = GetComponent<RectTransform>();
			for(int i = 0; i < m_talk.Length; i++)
			{
				if(m_talk[i] != null)
				{
					m_talk[i].horizontalOverflow = HorizontalWrapMode.Overflow;
				}
			}
			m_windowTbl.StartAllAnimGoStop("st_wait");
			Loaded();
			return true;
		}
	}
}
