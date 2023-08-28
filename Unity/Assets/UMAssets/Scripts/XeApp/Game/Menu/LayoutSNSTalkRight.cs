using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutSNSTalkRight : LayoutSNSBase
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
		private readonly string[] m_layoutEmotionFindTbl = new string[3] { "", "sw_sns_r_anim_swtbl_sel_sns_emo_r", "sw_sns_rs_anim_swtbl_sel_sns_emo_r" }; // 0x34
		private readonly string[] m_layoutWindowAnimFindTbl = new string[3] { "", "swtbl_sns_r_sw_sns_r_anim", "swtbl_sns_r_sw_sns_rs_anim" }; // 0x38

		//// RVA: 0x193C29C Offset: 0x193C29C VA: 0x193C29C Slot: 7
		public override void SetPosition(float pos_x, float pos_y)
		{
			if (m_rootRt != null)
			{
				m_rootRt.anchoredPosition = new Vector2(pos_x, -pos_y);
			}
		}

		//// RVA: 0x193C384 Offset: 0x193C384 VA: 0x193C384 Slot: 8
		public override void Show()
		{
			if (m_viewData == null)
				return;
			AbsoluteLayout w = GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId);
			if (w == null)
				return;
			gameObject.SetActive(true);
			w.StartChildrenAnimGoStop("st_stop");
		}

		// RVA: 0x193C45C Offset: 0x193C45C VA: 0x193C45C Slot: 9
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

		//// RVA: 0x193C518 Offset: 0x193C518 VA: 0x193C518 Slot: 10
		public override void In()
		{
			if (m_viewData == null || GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId) == null)
				return;
			gameObject.SetActive(true);
			GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId).StartChildrenAnimGoStop("go_in", "st_in");
			if (!SePlayEnable)
				return;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_SNS_000);
		}

		//// RVA: 0x193C648 Offset: 0x193C648 VA: 0x193C648 Slot: 11
		public override void Out()
		{
			if (m_viewData == null)
				return;
			if (GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId) == null)
				return;
			GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId).StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x193C6E0 Offset: 0x193C6E0 VA: 0x193C6E0 Slot: 12
		public override bool IsPlaying()
		{
			return GetWindowAnim(m_viewData.HMKFHLLAKCI_WindowSizeId).IsPlayingChildren();
		}

		//// RVA: 0x193C730 Offset: 0x193C730 VA: 0x193C730
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

		//// RVA: 0x193C444 Offset: 0x193C444 VA: 0x193C444
		//private AbsoluteLayout GetWindowAnim() { }

		//// RVA: 0x193C7AC Offset: 0x193C7AC VA: 0x193C7AC Slot: 13
		public override void SetStatus(SNSTalkCreater.ViewTalk talk)
		{
			m_viewData = talk.talk;
			SetName(talk.chara.OPFGFINHFCE + talk.chara.HAPAFECPFEK);
			SetTalk(m_viewData.LJGOOOMOMMA_Desc);
			SetDivaIconTexture(talk.chara.IDELKEKDIFD_CharaId);
			SetEmotion(m_viewData.OKMMDJCAHNK_WinShapeId);
			SetWindowSize(m_viewData.HMKFHLLAKCI_WindowSizeId);
		}

		//// RVA: 0x193C8BC Offset: 0x193C8BC VA: 0x193C8BC
		public void SetName(string name)
		{
			for(int i = 0; i < m_name.Length; i++)
			{
				if (m_name[i] != null)
					m_name[i].text = name;
			}
		}

		//// RVA: 0x193CA10 Offset: 0x193CA10 VA: 0x193CA10
		public void SetTalk(string talk)
		{
			for (int i = 0; i < m_talk.Length; i++)
			{
				if (m_talk[i] != null)
					m_talk[i].text = talk;
			}
		}

		//// RVA: 0x193CD08 Offset: 0x193CD08 VA: 0x193CD08
		public void SetEmotion(int emotionId)
		{
			if(m_viewData.HMKFHLLAKCI_WindowSizeId > -1 && m_viewData.HMKFHLLAKCI_WindowSizeId < m_emotionTbl.Length)
			{
				if(m_emotionTbl[m_viewData.HMKFHLLAKCI_WindowSizeId] != null)
				{
					m_emotionTbl[m_viewData.HMKFHLLAKCI_WindowSizeId].StartChildrenAnimGoStop(emotionId.ToString("D2"), emotionId.ToString("D2"));
				}
			}
		}

		//// RVA: 0x193CE5C Offset: 0x193CE5C VA: 0x193CE5C
		public void SetWindowSize(int sizeId)
		{
			if(m_windowTbl != null)
			{
				m_windowTbl.StartChildrenAnimGoStop(sizeId.ToString("D2"), sizeId.ToString("D2"));
			}
		}

		//// RVA: 0x193CB64 Offset: 0x193CB64 VA: 0x193CB64
		private void SetDivaIconTexture(int divaId)
		{
			for(int i = 0; i < m_image.Length; i++)
			{
				int index = i;
				GameManager.Instance.SnsIconCache.CharIconLoad(divaId, (IiconTexture icon) =>
				{
					//0x193D864
					icon.Set(m_image[index]);
				});
			}
		}

		// RVA: 0x193CF10 Offset: 0x193CF10 VA: 0x193CF10 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowTbl = layout.Root[0] as AbsoluteLayout;
			m_emotionTbl = new AbsoluteLayout[m_layoutEmotionFindTbl.Length];
			for (int i = 0; i < m_layoutEmotionFindTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_layoutEmotionFindTbl[i]))
				{
					m_emotionTbl[i] = layout.FindViewByExId(m_layoutEmotionFindTbl[i]) as AbsoluteLayout;
				}
			}
			m_windowAnim = new AbsoluteLayout[m_layoutWindowAnimFindTbl.Length];
			for (int i = 0; i < m_layoutWindowAnimFindTbl.Length; i++)
			{
				if (!string.IsNullOrEmpty(m_layoutWindowAnimFindTbl[i]))
				{
					m_windowAnim[i] = layout.FindViewByExId(m_layoutWindowAnimFindTbl[i]) as AbsoluteLayout;
				}
			}
			m_rootRt = GetComponent<RectTransform>();
			for (int i = 0; i < m_talk.Length; i++)
			{
				if (m_talk[i] != null)
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
