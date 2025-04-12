using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SetDeckDivaCardControl : MonoBehaviour
	{
		public enum ImpType
		{
			Off = 0,
			NoMessage = 1,
			MemberLimit = 2,
			Prism = 3,
		}

		//[TooltipAttribute] // RVA: 0x680544 Offset: 0x680544 VA: 0x680544
		//[HeaderAttribute] // RVA: 0x680544 Offset: 0x680544 VA: 0x680544
		[SerializeField]
		private UGUIStayButton m_divaButton; // 0xC
		//[TooltipAttribute] // RVA: 0x6805BC Offset: 0x6805BC VA: 0x6805BC
		[SerializeField]
		private Image m_emptyBackImage; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680614 Offset: 0x680614 VA: 0x680614
		private Image m_divaBackImage; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68066C Offset: 0x68066C VA: 0x68066C
		private Image m_emptyImage; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6806B4 Offset: 0x6806B4 VA: 0x6806B4
		private RawImage m_divaImage; // 0x1C
		//[TooltipAttribute] // RVA: 0x680704 Offset: 0x680704 VA: 0x680704
		[SerializeField]
		private RawImage m_divaIconImage; // 0x20
		//[TooltipAttribute] // RVA: 0x680760 Offset: 0x680760 VA: 0x680760
		[SerializeField]
		private Image m_divaFrameImage; // 0x24
		//[TooltipAttribute] // RVA: 0x6807B4 Offset: 0x6807B4 VA: 0x6807B4
		[SerializeField]
		private Image m_divaFrontImage; // 0x28
		//[TooltipAttribute] // RVA: 0x68082C Offset: 0x68082C VA: 0x68082C
		[SerializeField]
		private Image m_unitIconImage; // 0x2C
		//[TooltipAttribute] // RVA: 0x68088C Offset: 0x68088C VA: 0x68088C
		[SerializeField]
		private SetDeckDivaStatusControl m_divaStatus; // 0x30
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6808E8 Offset: 0x6808E8 VA: 0x6808E8
		private UGUIButton m_costumeButton; // 0x34
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680938 Offset: 0x680938 VA: 0x680938
		private RawImage m_costumeImage; // 0x38
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680988 Offset: 0x680988 VA: 0x680988
		private GameObject m_costumeImpObject; // 0x3C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6809F0 Offset: 0x6809F0 VA: 0x6809F0
		private GameObject m_divaImpObject; // 0x40
		//[TooltipAttribute] // RVA: 0x680A58 Offset: 0x680A58 VA: 0x680A58
		[SerializeField]
		private Image m_prismImpImage; // 0x44
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680ABC Offset: 0x680ABC VA: 0x680ABC
		private Text m_messageText; // 0x48
		//[HeaderAttribute] // RVA: 0x680B04 Offset: 0x680B04 VA: 0x680B04
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x680B04 Offset: 0x680B04 VA: 0x680B04
		private DivaColorSetScriptableObject m_divaColors; // 0x4C
		public Action OnClickDivaButton; // 0x50
		public Action OnStayDivaButton; // 0x54
		public Action OnClickCostumeButton; // 0x58
		private FFHPBEPOMAK_DivaInfo m_divaData; // 0x5C
		private DFKGGBMFFGB_PlayerInfo m_playerData; // 0x60
		private int m_musicId; // 0x64
		private bool m_isStory; // 0x68
		private bool m_isGoDivaSub; // 0x69
		private int m_divaTextureLoadingCount; // 0x6C
		private int m_costumeTextureLoadingCount; // 0x70

		public bool IsLoading { get { return m_divaTextureLoadingCount > 0 || m_costumeTextureLoadingCount > 0; } } //0xA68268
		public FFHPBEPOMAK_DivaInfo DivaData { get { return m_divaData; } } //0xA6A0C0
		public UGUIStayButton DivaButton { get { return m_divaButton; } } //0xA6A0C8
		//private bool IsEmpty { get; } 0xA6A0D0

		//// RVA: 0xA6A0E4 Offset: 0xA6A0E4 VA: 0xA6A0E4
		private void Awake()
		{
			SetImp(ImpType.Off);
			SetShowMultiIcon(false);
			if(m_divaButton != null)
			{
				m_divaButton.AddOnClickCallback(() => {
					//0xA6BBBC
					if(OnClickDivaButton != null)
						OnClickDivaButton();
				});
				m_divaButton.AddOnStayCallback(() => {
					//0xA6BBD0
					if(OnStayDivaButton != null)
						OnStayDivaButton();
				});
			}
			if(m_costumeButton != null)
			{
				m_costumeButton.AddOnClickCallback(() => {
					//0xA6BBE4
					if (OnClickCostumeButton != null)
						OnClickCostumeButton();
				});
			}
		}

		//// RVA: 0xA6A3A8 Offset: 0xA6A3A8 VA: 0xA6A3A8
		public void Set(FFHPBEPOMAK_DivaInfo divaData, DFKGGBMFFGB_PlayerInfo playerData, bool isCenter, bool isGoDiva, int musicId = 0, bool isStory = false)
		{
			m_divaData = divaData;
			m_playerData = playerData;
			m_musicId = musicId;
			m_isStory = isStory;
			m_isGoDivaSub = isGoDiva & !isCenter;
			SetDivaImageAndColor(divaData, divaData != null ? m_isGoDivaSub : false);
			if (m_divaStatus != null)
			{
				if (m_divaData != null)
				{
					m_divaStatus.gameObject.SetActive(true);
					m_divaStatus.SetSkill(m_divaData, m_playerData, isCenter, m_musicId);
					m_divaFrontImage.enabled = true;
				}
				else
				{
					m_divaStatus.gameObject.SetActive(false);
					m_divaFrontImage.enabled = false;
				}
			}
			if(m_divaData == null || m_isGoDivaSub)
			{
				m_costumeButton.gameObject.SetActive(false);
			}
			else
			{
				m_costumeButton.gameObject.SetActive(true);
			}
			if(m_divaData != null && !m_isGoDivaSub)
			{
				SetCostumeImage(m_divaData);
			}
		}

		//// RVA: 0xA6B4F8 Offset: 0xA6B4F8 VA: 0xA6B4F8
		public void SetForPrism(FFHPBEPOMAK_DivaInfo divaData)
		{
			m_divaData = divaData;
			SetDivaImageAndColor(divaData, false);
			if(m_divaFrontImage != null)
			{
				m_divaFrontImage.gameObject.SetActive(false);
			}
			if(m_divaStatus != null)
			{
				m_divaStatus.gameObject.SetActive(false);
			}
			m_costumeButton.gameObject.SetActive(m_divaData != null);
			if(m_divaData != null)
				SetCostumeImage(m_divaData);
		}

		//// RVA: 0xA68D84 Offset: 0xA68D84 VA: 0xA68D84
		public void SetForAssist(FFHPBEPOMAK_DivaInfo divaData)
		{
			m_divaData = divaData;
			SetDivaImageAndColor(divaData, false);
			if (m_divaFrontImage != null)
				m_divaFrontImage.gameObject.SetActive(false);
			if (m_divaStatus != null)
				m_divaStatus.gameObject.SetActive(false);
			if (m_costumeButton != null)
				m_costumeButton.gameObject.SetActive(false);
		}

		//// RVA: 0xA6B6E0 Offset: 0xA6B6E0 VA: 0xA6B6E0
		public void SetStatusDisplayType(DisplayType type)
		{
			if(m_divaStatus != null && m_divaData != null)
			{
				m_divaStatus.SetDispType(type, m_divaData, m_playerData, m_musicId, m_isStory, m_isGoDivaSub);
			}
		}

		//// RVA: 0xA6A2EC Offset: 0xA6A2EC VA: 0xA6A2EC
		public void SetShowMultiIcon(bool isShow)
		{
			if(m_unitIconImage != null)
				m_unitIconImage.enabled = isShow;
		}

		//// RVA: 0xA68A30 Offset: 0xA68A30 VA: 0xA68A30
		public void SetImp(SetDeckDivaCardControl.ImpType type)
		{
			if(type == ImpType.Off)
			{
				m_divaImpObject.SetActive(false);
				m_costumeImpObject.SetActive(false);
				return;
			}
			m_divaImpObject.SetActive(true);
			m_costumeImpObject.SetActive(true);
			MessageBank bank = MessageManager.Instance.GetBank("menu");
			if(type == ImpType.Prism)
			{
				m_messageText.enabled = false;
				m_prismImpImage.enabled = true;
			}
			else if(type == ImpType.MemberLimit)
			{
				m_messageText.enabled = true;
				m_messageText.text = bank.GetMessageByLabel("unit_diva_limit_message");
				m_prismImpImage.enabled = false;
			}
			else if(type == ImpType.NoMessage)
			{
				m_messageText.enabled = false;
				m_prismImpImage.enabled = false;
			}
		}

		//// RVA: 0xA6A648 Offset: 0xA6A648 VA: 0xA6A648
		private void SetDivaImageAndColor(FFHPBEPOMAK_DivaInfo divaData, bool isGoDivaSub = false)
		{
			if(divaData == null)
			{
				m_emptyBackImage.gameObject.SetActive(true);
				m_emptyImage.gameObject.SetActive(true);
				m_divaBackImage.gameObject.SetActive(false);
				m_divaImage.gameObject.SetActive(false);
				m_divaIconImage.gameObject.SetActive(false);
				m_divaFrameImage.gameObject.SetActive(false);
				return;
			}
			m_emptyBackImage.gameObject.SetActive(false);
			m_emptyImage.gameObject.SetActive(false);
			m_divaBackImage.gameObject.SetActive(true);
			m_divaImage.gameObject.SetActive(true);
			m_divaIconImage.gameObject.SetActive(false);
			m_divaFrameImage.gameObject.SetActive(true);
			if(isGoDivaSub)
			{
				m_divaImage.gameObject.SetActive(false);
				m_divaIconImage.gameObject.SetActive(true);
				m_divaTextureLoadingCount++;
				GameManager.Instance.DivaIconCache.LoadEventGoDivaIcon(divaData.AHHJLDLAPAN_DivaId, DivaIconTextureCache.GoDivaIconType.Naked, (IiconTexture texture) =>
				{
					//0xA6BBF8
					texture.Set(m_divaIconImage);
					m_divaTextureLoadingCount--;
				});
			}
			else
			{
				m_divaTextureLoadingCount++;
				GameManager.Instance.EpisodeIconCache.LoadDivaBustupTexture(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, divaData.EKFONBFDAAP_ColorId, (IiconTexture texture, Rect rect) => {
					//0xA6BCE4
					texture.Set(m_divaImage);
					m_divaImage.uvRect = rect;
					m_divaTextureLoadingCount--;
				});
				Color col = m_divaColors.GetDivaColor(divaData.AHHJLDLAPAN_DivaId);
				m_divaBackImage.color = new Color(col.r, col.g, col.b, m_divaBackImage.color.a);
				m_divaFrameImage.color = new Color(col.r, col.g, col.b, m_divaFrameImage.color.a);
				m_divaFrontImage.color = new Color(col.r, col.g, col.b, m_divaFrontImage.color.a);
			}
		}

		//// RVA: 0xA6B280 Offset: 0xA6B280 VA: 0xA6B280
		private void SetCostumeImage(FFHPBEPOMAK_DivaInfo divaData)
		{
			m_costumeTextureLoadingCount++;
			LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cosInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.NLIBHNJNJAN_GetUnlockedCostumeOrDefault(divaData.AHHJLDLAPAN_DivaId, divaData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId);
			if(cosInfo != null)
			{
				GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume, cosInfo.JPIDIENBGKH_CostumeId), divaData.EKFONBFDAAP_ColorId, (IiconTexture icon) =>
				{
					//0xA6BE1C
					icon.Set(m_costumeImage);
					m_costumeTextureLoadingCount--;
				});
			}
		}

		//// RVA: 0xA6BB74 Offset: 0xA6BB74 VA: 0xA6BB74
		//private Color ColorAlphaMarge(Color targetColor, float a) { }
	}
}
