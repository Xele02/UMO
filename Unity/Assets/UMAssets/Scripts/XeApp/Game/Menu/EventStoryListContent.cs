using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventStoryListContent : SwapScrollListContent
	{
		public enum ButtonLabel
		{
			Look = 0,
			Release = 1,
			Num = 2,
		}
		
		public enum ButtonFunc
		{
			None = 0,
			Look = 1,
			Release = 2,
			UnReadPrevStory = 3,
			UnRelease = 4,
		}

		public enum ReleaseFont
		{
			DoRelease = 0,
			UnRelease = 1,
		}

		[SerializeField]
		private RawImageEx m_thumbnail; // 0x20
		[SerializeField]
		private Text m_titleText; // 0x24
		[SerializeField]
		private Text m_unlockText; // 0x28
		[SerializeField]
		private ActionButton[] m_buttons; // 0x2C
		private AbsoluteLayout m_textGroupLayout; // 0x30
		private AbsoluteLayout m_snsIconLayer; // 0x34
		private AbsoluteLayout m_thumbnailLayer; // 0x38
		private AbsoluteLayout m_noiselayer; // 0x3C
		private AbsoluteLayout m_arrowLayer; // 0x40
		private AbsoluteLayout m_buttonLayer; // 0x44
		private AbsoluteLayout m_unReleaseFont; // 0x48
		//[CompilerGeneratedAttribute] // RVA: 0x66D0AC Offset: 0x66D0AC VA: 0x66D0AC
		public UnityAction<ButtonLabel, int, ButtonFunc> PushButtonListener; // 0x4C
		private static Matrix23 identity; // 0x0
		private ButtonFunc m_func; // 0x50
		[SerializeField]
		private int m_capture; // 0x54
		private NewMarkIcon m_newMarkIcon; // 0x58

		// RVA: 0xB915D8 Offset: 0xB915D8 VA: 0xB915D8
		public void OnDestroy()
		{
			DeleteNewMark();
		}

		// RVA: 0xB915EC Offset: 0xB915EC VA: 0xB915EC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_textGroupLayout = layout.FindViewByExId("sw_sel_event_data_content_swtbl_sel_event_data_font") as AbsoluteLayout;
			m_snsIconLayer = layout.FindViewByExId("sw_sel_event_data_content_s_e_d_icon_sns") as AbsoluteLayout;
			m_thumbnailLayer = layout.FindViewByExId("sw_sel_event_data_content_thumbnail") as AbsoluteLayout;
			m_noiselayer = layout.FindViewByExId("sw_sel_event_data_content_sw_s_e_d_noise_anim") as AbsoluteLayout;
			m_arrowLayer = layout.FindViewByExId("sw_sel_event_data_content_s_e_d_icon_01") as AbsoluteLayout;
			m_buttonLayer = layout.FindViewByExId("sw_sel_event_data_content_swtbl_sel_event_data_btn") as AbsoluteLayout;
			m_unReleaseFont = layout.FindViewByExId("sw_s_e_d_btn2_anim_swtbl_s_e_d_btn_fnt") as AbsoluteLayout;
			for(int i = 0; i < m_buttons.Length; i++)
			{
				int label = i;
				m_buttons[i].AddOnClickCallback(() =>
				{
					//0xB928F0
					OnPushButton((ButtonLabel)label);
				});
			}
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0xB91AC4 Offset: 0xB91AC4 VA: 0xB91AC4
		public void SetTitleText(string title)
		{
			m_titleText.text = title;
		}

		//// RVA: 0xB91B00 Offset: 0xB91B00 VA: 0xB91B00
		public void SetUnlockText(string mess)
		{
			m_unlockText.text = mess;
		}

		//// RVA: 0xB91B3C Offset: 0xB91B3C VA: 0xB91B3C
		public void EnableSnsIcon(bool isEnable)
		{
			m_snsIconLayer.StartAnimGoStop(isEnable ? "01" : "02");
			UpdateAbsoluteLayout(m_snsIconLayer);
		}

		//// RVA: 0xB91D28 Offset: 0xB91D28 VA: 0xB91D28
		public void EnableThumbnail(bool isEnable)
		{
			m_thumbnailLayer.StartAnimGoStop(isEnable ? "01" : "02");
			UpdateAbsoluteLayout(m_thumbnailLayer);
		}

		//// RVA: 0xB91DC4 Offset: 0xB91DC4 VA: 0xB91DC4
		public void EnableNoise(bool isEnable)
		{
			m_noiselayer.StartAnimGoStop(isEnable ? "01" : "02");
			UpdateAbsoluteLayout(m_noiselayer);
		}

		//// RVA: 0xB91E60 Offset: 0xB91E60 VA: 0xB91E60
		public void EnableArrow(bool isEnable)
		{
			m_arrowLayer.StartAnimGoStop(isEnable ? "01" : "02");
			UpdateAbsoluteLayout(m_arrowLayer);
		}

		//// RVA: 0xB91EFC Offset: 0xB91EFC VA: 0xB91EFC
		public void EnableLockMessage(bool isEnable)
		{
			m_textGroupLayout.StartChildrenAnimGoStop(isEnable ? "01" : "02");
			UpdateAbsoluteLayout(m_textGroupLayout);
		}

		//// RVA: 0xB91F98 Offset: 0xB91F98 VA: 0xB91F98
		public void EnableNewIcon(bool a_enable)
		{
			if (m_newMarkIcon != null)
				m_newMarkIcon.SetActive(a_enable);
		}

		//// RVA: 0xB91FAC Offset: 0xB91FAC VA: 0xB91FAC
		public void SetLock(bool isLock)
		{
			for(int i = 0; i < m_buttons.Length; i++)
			{
				m_buttons[i].Disable = isLock;
				UpdateAbsoluteLayout(m_buttons[i].RootAbsoluteLayout);
			}
		}

		//// RVA: 0xB9209C Offset: 0xB9209C VA: 0xB9209C
		public void SetButtonLabel(ButtonLabel label)
		{
			m_buttonLayer.StartChildrenAnimGoStop(label == ButtonLabel.Look ? "01" : "02");
			UpdateAbsoluteLayout(m_buttonLayer);
		}

		//// RVA: 0xB92138 Offset: 0xB92138 VA: 0xB92138
		public void SetButtonFunc(ButtonFunc func)
		{
			m_func = func;
		}

		//// RVA: 0xB92140 Offset: 0xB92140 VA: 0xB92140
		public void ChangeReleaseFont(ReleaseFont font)
		{
			if(font == ReleaseFont.UnRelease)
			{
				m_unReleaseFont.StartChildrenAnimGoStop("02");
			}
			else if(font == ReleaseFont.DoRelease)
			{
				m_unReleaseFont.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0xB921F4 Offset: 0xB921F4 VA: 0xB921F4
		public void SetThumbnail(int id, bool isEpilogue)
		{
			GameManager.Instance.EventBannerTextureCache.LoadEventStoryThumbnail(id, (IiconTexture texture) =>
			{
				//0xB92920
				texture.Set(m_thumbnail);
				m_thumbnail.uvRect = new Rect(0, isEpilogue ? 0 : 0.5f, 1, 0.5f);
			});
		}

		//// RVA: 0xB9235C Offset: 0xB9235C VA: 0xB9235C
		public void SetThumbnail(int id, int index)
		{
			m_capture = index;
			GameManager.Instance.EventBannerTextureCache.LoadEventStoryThumbnail(id, (IiconTexture texture) =>
			{
				//0xB925FC
				texture.Set(m_thumbnail);
				m_thumbnail.uvRect = CalcThumbnailRect(m_capture - 1, new Vector2(texture.BaseTexture.width, texture.BaseTexture.height));
			});
		}

		//// RVA: 0xB92474 Offset: 0xB92474 VA: 0xB92474
		public static Rect CalcThumbnailRect(int index, Vector2 textureSize)
		{
			int x = index % Mathf.RoundToInt((textureSize.y / 128));
			int y = index / Mathf.RoundToInt((textureSize.y / 128));
			float f = 128.0f / textureSize.y;
			return new Rect(256.0f / textureSize.x * x, (1 - f * y) - f, 256.0f / textureSize.x, f);
		}

		//// RVA: 0xB92558 Offset: 0xB92558 VA: 0xB92558
		private void OnPushButton(ButtonLabel label)
		{
			if (PushButtonListener != null)
				PushButtonListener(label, Index, m_func);
		}

		//// RVA: 0xB9048C Offset: 0xB9048C VA: 0xB9048C
		public void CreateNewMark()
		{
			m_newMarkIcon = new NewMarkIcon();
			m_newMarkIcon.Initialize(transform.Find("sw_sel_event_data_content (AbsoluteLayout)").Find("swtbl_icon (AbsoluteLayout)").Find("cmn_icon01 (AbsoluteLayout)").gameObject);
			m_newMarkIcon.SetActive(false);
		}

		//// RVA: 0xB9075C Offset: 0xB9075C VA: 0xB9075C
		public void DeleteNewMark()
		{
			if (m_newMarkIcon != null)
				m_newMarkIcon.Release();
		}

		//// RVA: 0xB91BD8 Offset: 0xB91BD8 VA: 0xB91BD8
		private void UpdateAbsoluteLayout(AbsoluteLayout abs)
		{
			abs.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
			abs.UpdateAll(identity, Color.white);
		}
	}
}
