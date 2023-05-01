using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SnsNotificationLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_faceIcon; // 0x14
		[SerializeField]
		private RawImageEx m_offerFaceIcon; // 0x18
		[SerializeField]
		private Text m_roomText; // 0x1C
		[SerializeField]
		private Text m_messageText; // 0x20
		[SerializeField]
		private SnsNotificationButton m_button; // 0x24
		[SerializeField]
		private SnsNotificationButton m_offerButton; // 0x28
		[SerializeField]
		private Text m_OfferText; // 0x2C
		private const int BASARA_ID = 9;
		private AbsoluteLayout m_layout; // 0x30
		private AbsoluteLayout m_maxIconLayout; // 0x34
		private AbsoluteLayout m_offeranimLayout; // 0x38
		private AbsoluteLayout m_releaseLevel; // 0x3C
		private AbsoluteLayout m_divaNameChange; // 0x40
		public UnityAction PushButtonHandler; // 0x44 0x12D1FD8 0x12D2154
		private AbsoluteLayout m_animeLayout; // 0x48
		private bool IsOffer; // 0x4E

		public SnsNotificationButton Button { get { return m_button; } } //0x12D2144
		public SnsNotificationButton OfferButton { get { return m_offerButton; } } //0x12D214C
		public bool IsPushed { get; private set; } // 0x4C
		public bool IsLoadedIcon { get; private set; } // 0x4D

		// RVA: 0x12D269C Offset: 0x12D269C VA: 0x12D269C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layout = layout.FindViewByExId("root_sns_notifi_swtbl_sw_sns_notifi_btn_inout") as AbsoluteLayout;
			m_animeLayout = layout.FindViewByExId("sw_sns_notifi_btn_inout_anim_sw_sns_notifi_btn_anim") as AbsoluteLayout;
			m_offeranimLayout = layout.FindViewByExId("swtbl_sw_sns_notifi_btn_inout_sw_sns_notifi_btn_inout_anim_02") as AbsoluteLayout;
			m_releaseLevel = layout.FindViewByExId("sw_sns_notifi_btn_anim_02_swtbl_sns_notifi_lv") as AbsoluteLayout;
			m_maxIconLayout = layout.FindViewByExId("swtbl_sns_notifi_lv_swtbl_sns_notifi_icon_max") as AbsoluteLayout;
			m_animeLayout.StartAnimGoStop("st_wait");
			m_divaNameChange = layout.FindViewByExId("swtbl_sns_notifi_lv_fnt_01") as AbsoluteLayout;
			m_button.AddOnClickCallback(OnPushButton);
			m_offerButton.AddOnClickCallback(OnPushButton);
			ClearLoadedCallback();
			Loaded();
			return true;
		}

		// RVA: 0x12D2AC0 Offset: 0x12D2AC0 VA: 0x12D2AC0
		public void OnDestroy()
		{
			PushButtonHandler = null;
			m_animeLayout = null;
		}

		//// RVA: 0x12D1598 Offset: 0x12D1598 VA: 0x12D1598
		public void SetFaceIcon(int charaId, bool IsOffer = false)
		{
			IsLoadedIcon = false;
			GameManager.Instance.SnsIconCache.CharIconLoad(charaId, (IiconTexture texture) =>
			{
				//0x12D2DB4
				if(!IsOffer)
				{
					texture.Set(m_faceIcon);
				}
				else
				{
					texture.Set(m_offerFaceIcon);
				}
				IsLoadedIcon = true;
			});
		}

		//// RVA: 0x12D1700 Offset: 0x12D1700 VA: 0x12D1700
		public void SetRoomName(string name)
		{
			m_roomText.text = name;
			m_OfferText.text = name;
		}

		//// RVA: 0x12D176C Offset: 0x12D176C VA: 0x12D176C
		public void SetMessage(string message)
		{
			m_messageText.text = message;
		}

		//// RVA: 0x12D1E88 Offset: 0x12D1E88 VA: 0x12D1E88
		public void Show(bool isEnableButton = true)
		{
			m_layout.StartChildrenAnimGoStop("01");
			IsPushed = false;
			m_button.IsInputOff = !isEnableButton;
			m_animeLayout.StartAnimGoStop("go_in", "st_in");
			IsOffer = false;
		}

		//// RVA: 0x12D1D8C Offset: 0x12D1D8C VA: 0x12D1D8C
		public void ShowOffer(bool isEnableButton = true)
		{
			m_layout.StartChildrenAnimGoStop("02");
			IsPushed = false;
			m_button.IsInputOff = !isEnableButton;
			m_offeranimLayout.StartChildrenAnimGoStop("go_in", "st_in");
			IsOffer = true;
			SettingOfferNotifi();
		}

		//// RVA: 0x12D2AD8 Offset: 0x12D2AD8 VA: 0x12D2AD8
		private void SettingOfferNotifi()
		{
			TodoLogger.Log(0, "SettingOfferNotifi");
		}

		//// RVA: 0x12D2D0C Offset: 0x12D2D0C VA: 0x12D2D0C
		//private bool IsBasara(int _divaId) { }

		//// RVA: 0x12D1D34 Offset: 0x12D1D34 VA: 0x12D1D34
		public void ButtonDisable()
		{
			m_button.IsInputOff = true;
			m_offerButton.IsInputLock = true;
		}

		//// RVA: 0x12D20E4 Offset: 0x12D20E4 VA: 0x12D20E4
		public void ButtonEnable()
		{
			m_button.IsInputOff = false;
			m_offerButton.IsInputOff = false;
		}

		//// RVA: 0x12D2260 Offset: 0x12D2260 VA: 0x12D2260
		public void Close()
		{
			if(IsOffer)
			{
				m_offeranimLayout.StartChildrenAnimGoStop("go_out", "st_out");
			}
			else
			{
				m_animeLayout.StartAnimGoStop("go_out", "st_out");
			}
		}

		//// RVA: 0x12D1F7C Offset: 0x12D1F7C VA: 0x12D1F7C
		public bool IsPlaying()
		{
			if(!IsOffer)
			{
				return m_animeLayout.IsPlaying();
			}
			else
			{
				return m_offeranimLayout.IsPlayingChildren();
			}
		}

		//// RVA: 0x12D2D1C Offset: 0x12D2D1C VA: 0x12D2D1C
		private void OnPushButton()
		{
			if(PushButtonHandler != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				PushButtonHandler();
			}
			IsPushed = true;
		}
	}
}
