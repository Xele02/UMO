using UnityEngine;
using System;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class GakuyaInfos : MonoBehaviour
	{
		[Serializable]
		private struct DivaVisualInfo
		{
			//[TooltipAttribute] // RVA: 0x66E5B0 Offset: 0x66E5B0 VA: 0x66E5B0
			public Color m_color; // 0x0
		}

		[Serializable]
		private struct SelectButtonVisualInfo
		{
			//[TooltipAttribute] // RVA: 0x66E5E8 Offset: 0x66E5E8 VA: 0x66E5E8
			public Sprite m_baseSprite; // 0x0
			//[TooltipAttribute] // RVA: 0x66E61C Offset: 0x66E61C VA: 0x66E61C
			public Color m_iconColor; // 0x4
			//[TooltipAttribute] // RVA: 0x66E660 Offset: 0x66E660 VA: 0x66E660
			public Color m_textColor; // 0x14
		}

		[Serializable]
		private struct SelectButtonHandle
		{
			//[TooltipAttribute] // RVA: 0x66E6A4 Offset: 0x66E6A4 VA: 0x66E6A4
			public UGUIButton m_button; // 0x0
			//[TooltipAttribute] // RVA: 0x66E6E0 Offset: 0x66E6E0 VA: 0x66E6E0
			public Image m_imageBase; // 0x4
			//[TooltipAttribute] // RVA: 0x66E714 Offset: 0x66E714 VA: 0x66E714
			public Image m_imageIcon; // 0x8
			//[TooltipAttribute] // RVA: 0x66E754 Offset: 0x66E754 VA: 0x66E754
			public Text m_text; // 0xC
		}

		public enum SelectType
		{
			Status = 0,
			Dress = 1,
			Gift = 2,
			Profile = 3,
		}

		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DF94 Offset: 0x66DF94 VA: 0x66DF94
		private Image m_imageDivaNameLabel; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DFF0 Offset: 0x66DFF0 VA: 0x66DFF0
		private Text m_textDivaName; // 0x10
		//[TooltipAttribute] // RVA: 0x66E048 Offset: 0x66E048 VA: 0x66E048
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0x14
		//[TooltipAttribute] // RVA: 0x66E090 Offset: 0x66E090 VA: 0x66E090
		[SerializeField]
		private UGUIButton m_buttonChangeDiva; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E0E8 Offset: 0x66E0E8 VA: 0x66E0E8
		private SelectButtonHandle m_buttonHandleStatus; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E144 Offset: 0x66E144 VA: 0x66E144
		private SelectButtonHandle m_buttonHandleDress; // 0x2C
		//[TooltipAttribute] // RVA: 0x66E19C Offset: 0x66E19C VA: 0x66E19C
		[SerializeField]
		private SelectButtonHandle m_buttonHandleGift; // 0x3C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E1F0 Offset: 0x66E1F0 VA: 0x66E1F0
		private SelectButtonHandle m_buttonHandleProfile; // 0x4C
		//[TooltipAttribute] // RVA: 0x66E24C Offset: 0x66E24C VA: 0x66E24C
		[SerializeField]
		private GameObject m_giftLockObject; // 0x5C
		//[TooltipAttribute] // RVA: 0x66E2B8 Offset: 0x66E2B8 VA: 0x66E2B8
		[SerializeField]
		private Transform m_transformContent; // 0x60
		//[TooltipAttribute] // RVA: 0x66E30C Offset: 0x66E30C VA: 0x66E30C
		[SerializeField]
		private Transform m_transformEscapeContent; // 0x64
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E368 Offset: 0x66E368 VA: 0x66E368
		private Animator m_animatorContent; // 0x68
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E3DC Offset: 0x66E3DC VA: 0x66E3DC
		private GameObject m_contentTapGuard; // 0x6C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E458 Offset: 0x66E458 VA: 0x66E458
		private SelectButtonVisualInfo m_selectButtonVisualInfoNormal; // 0x70
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E4C0 Offset: 0x66E4C0 VA: 0x66E4C0
		private SelectButtonVisualInfo m_selectButtonVisualInfoSelecting; // 0x94
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66E528 Offset: 0x66E528 VA: 0x66E528
		private List<DivaVisualInfo> m_divaVisualInfos; // 0xB8
		[SerializeField]
		private ColorGroup m_contentColorGroup; // 0xBC
		[SerializeField]
		private Color m_colorNormal; // 0xC0
		[SerializeField]
		private Color m_colorLock; // 0xD0
		public Action OnClickChangeDivaButtonCallback; // 0xE0
		public Action<SelectType> OnClickSelectButtonCallback; // 0xE4
		public Action<SelectType> OnFinishSelectAnimCallback; // 0xE8
		private GameObject m_objectStatus; // 0xEC
		private GameObject m_objectDressList; // 0xF0
		private GameObject m_objectGiftList; // 0xF4
		private GameObject m_objectProfile; // 0xF8
		private SelectType m_selectType; // 0xFC
		private Coroutine m_coroutineContentChange; // 0x100
		private bool m_isLockGift; // 0x104

		public SelectType CurrentSelectType { get { return m_selectType; } } //0xB71F9C
		public bool IsLockGift { get { return m_isLockGift; } } //0xB71FA4

		// RVA: 0xB71FAC Offset: 0xB71FAC VA: 0xB71FAC
		private void Awake()
		{
			m_buttonChangeDiva.AddOnClickCallback(() =>
			{
				//0xB738C8
				if (OnClickChangeDivaButtonCallback != null)
					OnClickChangeDivaButtonCallback();
			});
			m_buttonHandleStatus.m_button.AddOnClickCallback(() =>
			{
				//0xB738DC
				OnClickSelectButton(SelectType.Status);
			});
			m_buttonHandleDress.m_button.AddOnClickCallback(() =>
			{
				//0xB738E4
				OnClickSelectButton(SelectType.Dress);
			});
			m_buttonHandleGift.m_button.AddOnClickCallback(() =>
			{
				//0xB738EC
				OnClickSelectButton(SelectType.Gift);
			});
			m_buttonHandleProfile.m_button.AddOnClickCallback(() =>
			{
				//0xB738F4
				OnClickSelectButton(SelectType.Profile);
			});
		}

		// RVA: 0xB721C4 Offset: 0xB721C4 VA: 0xB721C4
		public void Setup(GameObject status, GameObject dressList, GameObject giftList, GameObject profile)
		{
			m_objectStatus = status;
			m_objectDressList = dressList;
			m_objectGiftList = giftList;
			m_objectProfile = profile;
			status.transform.SetParent(m_transformEscapeContent, false);
			m_objectDressList.transform.SetParent(m_transformEscapeContent, false);
			m_objectGiftList.transform.SetParent(m_transformEscapeContent, false);
			m_objectProfile.transform.SetParent(m_transformEscapeContent, false);
			SetButtonsType(SelectType.Status);
			SetContentsType(SelectType.Status);
			m_selectType = SelectType.Status;
		}

		//// RVA: 0xB72390 Offset: 0xB72390 VA: 0xB72390
		public void SetGiftLock(int currentRank, int unlockRank)
		{
			m_isLockGift = currentRank < unlockRank;
			ApplyGiftLock(currentRank < unlockRank);
		}

		//// RVA: 0xB72484 Offset: 0xB72484 VA: 0xB72484
		public void SetDiva(int divaId)
		{
			int a = Mathf.Clamp(divaId - 1, 0, m_divaVisualInfos.Count - 1);
			DivaVisualInfo item = m_divaVisualInfos[a];
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textDivaName.text = bk.GetMessageByLabel(string.Format("diva_name_{0:D2}", divaId));
			m_textDivaName.color = item.m_color;
			m_imageDivaNameLabel.color = item.m_color;
		}

		//// RVA: 0xB72338 Offset: 0xB72338 VA: 0xB72338
		public void SetSelectType(SelectType type, bool force = false, bool isAnim = false)
		{
			if(isAnim)
			{
				ChangeSelectType(type);
			}
			else
			{
				if(force || m_selectType != type)
				{
					SetButtonsType(type);
					SetContentsType(type);
					m_selectType = type;
				}
			}
		}

		//// RVA: 0xB72FB0 Offset: 0xB72FB0 VA: 0xB72FB0
		public void SetScrollTop()
		{
			m_objectStatus.GetComponentInChildren<GakuyaStatus>().SetScrollTop();
			m_objectDressList.GetComponentInChildren<GakuyaCostumeListWindow>().SetScrollTop();
			m_objectGiftList.GetComponentInChildren<GakuyaPresentListWindow>().SetScrollTop();
			m_objectProfile.GetComponentInChildren<GakuyaProfile>().SetScrollTop();
		}

		//// RVA: 0xB733A0 Offset: 0xB733A0 VA: 0xB733A0
		public void SetActiveHideContent(bool isActive)
		{
			m_transformEscapeContent.gameObject.SetActive(isActive);
		}

		//// RVA: 0xB733F4 Offset: 0xB733F4 VA: 0xB733F4
		//public void Enter() { }

		//// RVA: 0xB7342C Offset: 0xB7342C VA: 0xB7342C
		//public void Leave() { }

		//// RVA: 0xB73458 Offset: 0xB73458 VA: 0xB73458
		public void TryEnter()
		{
			SetButtonsType(m_selectType);
			m_enterLeaveControl.TryEnter();
		}

		// RVA: 0xB73490 Offset: 0xB73490 VA: 0xB73490
		public void TryLeave()
		{
			m_enterLeaveControl.TryLeave();
		}

		//// RVA: 0xB734BC Offset: 0xB734BC VA: 0xB734BC
		//public void Show() { }

		//// RVA: 0xB734E8 Offset: 0xB734E8 VA: 0xB734E8
		public void Hide()
		{
			m_enterLeaveControl.Hide();
		}

		// RVA: 0xB73514 Offset: 0xB73514 VA: 0xB73514
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}

		//// RVA: 0xB723A8 Offset: 0xB723A8 VA: 0xB723A8
		private void ApplyGiftLock(bool isLock)
		{
			if(isLock)
			{
				m_giftLockObject.SetActive(true);
				m_contentColorGroup.color = m_colorLock;
			}
			else
			{
				m_giftLockObject.SetActive(false);
				m_contentColorGroup.color = m_colorNormal;
			}
			m_contentColorGroup.SetMaterialDirty();
		}

		//// RVA: 0xB726E8 Offset: 0xB726E8 VA: 0xB726E8
		private void ChangeSelectType(SelectType type)
		{
			if(m_selectType != type)
			{
				if (m_coroutineContentChange != null)
					this.StopCoroutineWatched(m_coroutineContentChange);
				if(type == SelectType.Gift && m_isLockGift)
				{
					TextPopupSetting s = new TextPopupSetting();
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					s.Text = JpStringLiterals.StringLiteral_16162;
					PopupWindowManager.Show(s, null, null, null, null);
				}
				else
				{
					m_coroutineContentChange = this.StartCoroutineWatched(Co_ChangeSelectType(m_selectType, type));
					m_selectType = type;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6DEEF4 Offset: 0x6DEEF4 VA: 0x6DEEF4
		//// RVA: 0xB73540 Offset: 0xB73540 VA: 0xB73540
		private IEnumerator Co_ChangeSelectType(SelectType currentType, SelectType nextType)
		{
			bool isLeaveLeft;

			//0xB73900
			m_contentTapGuard.SetActive(true);
			SetButtonsType(nextType);
			isLeaveLeft = currentType < nextType;
			m_animatorContent.CrossFade(isLeaveLeft ? "LeaveL" : "LeaveR", 0);
			yield return null;
			while(m_animatorContent.IsInTransition(0))
				yield return null;
			while (m_animatorContent.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			SetContentsType(nextType);
			m_animatorContent.CrossFade(isLeaveLeft ? "EnterR" : "EnterL", 0);
			yield return null;
			while (m_animatorContent.IsInTransition(0))
				yield return null;
			while (m_animatorContent.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			m_contentTapGuard.SetActive(false);
			if (OnFinishSelectAnimCallback != null)
				OnFinishSelectAnimCallback(nextType);
		}

		//// RVA: 0xB72950 Offset: 0xB72950 VA: 0xB72950
		private void SetButtonsType(SelectType type)
		{
			SetButtonSelecting(m_buttonHandleStatus, type == SelectType.Status);
			SetButtonSelecting(m_buttonHandleDress, type == SelectType.Dress);
			SetButtonSelecting(m_buttonHandleGift, type == SelectType.Gift);
			SetButtonSelecting(m_buttonHandleProfile, type == SelectType.Profile);
			if (type == SelectType.Gift)
				return;
			ApplyGiftLock(m_isLockGift);
		}

		//// RVA: 0xB73620 Offset: 0xB73620 VA: 0xB73620
		private void SetButtonSelecting(SelectButtonHandle buttonHandle, bool isSelecting)
		{
			if(isSelecting)
			{
				buttonHandle.m_button.SetOn();
				buttonHandle.m_button.enabled = false;
				buttonHandle.m_imageBase.sprite = m_selectButtonVisualInfoSelecting.m_baseSprite;
				buttonHandle.m_imageIcon.color = m_selectButtonVisualInfoSelecting.m_iconColor;
				buttonHandle.m_text.color = m_selectButtonVisualInfoSelecting.m_textColor;
			}
			else
			{
				buttonHandle.m_button.enabled = true;
				buttonHandle.m_button.SetOff();
				buttonHandle.m_imageBase.sprite = m_selectButtonVisualInfoNormal.m_baseSprite;
				buttonHandle.m_imageIcon.color = m_selectButtonVisualInfoNormal.m_iconColor;
				buttonHandle.m_text.color = m_selectButtonVisualInfoNormal.m_textColor;
			}
		}

		//// RVA: 0xB72A18 Offset: 0xB72A18 VA: 0xB72A18
		private void SetContentsType(SelectType type)
		{
			foreach(var k in m_transformContent)
			{
				(k as Transform).SetParent(m_transformEscapeContent, false);
			}
			switch(type)
			{
				case SelectType.Status:
					if(m_objectStatus != null)
						m_objectStatus.transform.SetParent(m_transformContent, false);
					break;
				case SelectType.Dress:
					if (m_objectDressList != null)
						m_objectDressList.transform.SetParent(m_transformContent, false);
					break;
				case SelectType.Gift:
					if (m_objectGiftList != null)
						m_objectGiftList.transform.SetParent(m_transformContent, false);
					break;
				case SelectType.Profile:
					if (m_objectProfile != null)
						m_objectProfile.transform.SetParent(m_transformContent, false);
					break;
				default:
					break;
			}
		}

		//// RVA: 0xB7382C Offset: 0xB7382C VA: 0xB7382C
		//private void OnClickChangeDivaButton() { }

		//// RVA: 0xB73840 Offset: 0xB73840 VA: 0xB73840
		private void OnClickSelectButton(SelectType type)
		{
			ChangeSelectType(type);
			if (OnClickSelectButtonCallback != null)
				OnClickSelectButtonCallback(type);
		}
	}
}
