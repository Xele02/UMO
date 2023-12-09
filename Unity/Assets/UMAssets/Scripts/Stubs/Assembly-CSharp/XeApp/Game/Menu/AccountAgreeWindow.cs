using mcrs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class AccountAgreeWindow : MonoBehaviour
	{
		public enum Result
		{
			None = 0,
			AccountRemove = 1,
			Cancel = 2,
		}

		[SerializeField]
		private Text titleText; // 0x10
		[SerializeField]
		private Text agreeText; // 0x14
		[SerializeField]
		private Text agreeButtonText; // 0x18
		[SerializeField]
		private Text accountRemoveButtonText; // 0x1C
		[SerializeField]
		private Text cancelButtonText; // 0x20
		[SerializeField]
		private Text consentButtonText; // 0x24
		[SerializeField]
		private UGUIToggleButton agreeToggleButton; // 0x28
		[SerializeField]
		private UGUIButton accountRemoveButton; // 0x2C
		[SerializeField]
		private UGUIButton cancelButton; // 0x30
		[SerializeField]
		private UGUIButton consentButton; // 0x34
		[SerializeField]
		private Image backGroundImage; // 0x38
		private InOutAnime _inOutAnime; // 0x3C
		private List<ButtonBase> _buttonList = new List<ButtonBase>(); // 0x40
		private ScrollRect _scrollRect; // 0x44
		
		public Result WindowResult { get; private set; } // 0xC

		// RVA: 0x142D890 Offset: 0x142D890 VA: 0x142D890
		private void Awake()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			if (titleText != null)
				titleText.text = bk.GetMessageByLabel("popup_account_management_text011");
			if (agreeText != null)
				agreeText.text = bk.GetMessageByLabel("popup_account_management_text012");
			if (agreeButtonText != null)
				agreeButtonText.text = bk.GetMessageByLabel("popup_account_management_text013");
			if (accountRemoveButtonText != null)
				accountRemoveButtonText.text = bk.GetMessageByLabel("popup_account_management_text015");
			if (cancelButtonText != null)
				cancelButtonText.text = bk.GetMessageByLabel("popup_account_management_text014");
			if (consentButtonText != null)
				consentButtonText.text = bk.GetMessageByLabel("popup_account_remove_consent_button");
			if (agreeToggleButton != null)
			{
				agreeToggleButton.AddOnClickCallback(() =>
				{
					//0x142E49C
					if (accountRemoveButton != null)
					{
						accountRemoveButton.Disable = !agreeToggleButton.IsOn;
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					}
				});
				_buttonList.Add(agreeToggleButton);
			}
			if(accountRemoveButton != null)
			{
				accountRemoveButton.AddOnClickCallback(() =>
				{
					//0x142E5C4
					if (WindowResult == Result.None)
						return;
					WindowResult = Result.AccountRemove;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				});
				_buttonList.Add(accountRemoveButton);
			}
			if(cancelButton != null)
			{
				cancelButton.AddOnClickCallback(() =>
				{
					//0x142E630
					if (WindowResult == Result.None)
						return;
					WindowResult = Result.Cancel;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
				});
				_buttonList.Add(cancelButton);
			}
			if(consentButton != null)
			{
				consentButton.AddOnClickCallback(() =>
				{
					//0x142E69C
					_buttonList.ForEach((ButtonBase _) =>
					{
						//0x142EB30
						_.IsInputOff = true;
					});
					NKGJPJPHLIF.HHCJCDFCLOB.NBLAOIPJFGL_OpenURL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.JLJEEMEOPLE["utapass_site"], () =>
					{
						//0x142E95C
						_buttonList.ForEach((ButtonBase _) =>
						{
							//0x142EB60
							_.IsInputOff = false;
						});
					});
				});
				_buttonList.Add(consentButton);
			}
			if (backGroundImage != null)
				backGroundImage.enabled = false;
			_inOutAnime = GetComponentInChildren<InOutAnime>();
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x142EB90
				_.IsInputOff = true;
			});
			_scrollRect = GetComponentInChildren<ScrollRect>();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C942C Offset: 0x6C942C VA: 0x6C942C
		// RVA: 0x142E20C Offset: 0x142E20C VA: 0x142E20C
		public IEnumerator Co_Show()
		{
			//0x142F29C
			WindowResult = Result.None;
			if (agreeToggleButton != null)
				agreeToggleButton.SetOff();
			if (accountRemoveButton != null)
				accountRemoveButton.Disable = true;
			if(_inOutAnime != null)
			{
				_scrollRect.vertical = _scrollRect.content.sizeDelta.y <= _scrollRect.content.rect.height;
				_scrollRect.content.anchoredPosition = new Vector2(0, 0);
				_scrollRect.velocity = new Vector2(0, 0);
				transform.SetAsLastSibling();
				backGroundImage.enabled = true;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
				bool isWait = true;
				_inOutAnime.Enter(false, () =>
				{
					//0x142EC28
					isWait = false;
				});
				while (isWait)
					yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C94A4 Offset: 0x6C94A4 VA: 0x6C94A4
		// RVA: 0x142E2B8 Offset: 0x142E2B8 VA: 0x142E2B8
		public IEnumerator Co_Run()
		{
			//0x142EF28
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x142EBC0
				_.IsInputOff = false;
			});
			while (WindowResult == Result.None)
				yield return null;
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x142EBF0
				_.IsInputOff = true;
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C951C Offset: 0x6C951C VA: 0x6C951C
		// RVA: 0x142E364 Offset: 0x142E364 VA: 0x142E364
		public IEnumerator Co_Close()
		{
			//0x142EC4C
			if(_inOutAnime != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
				bool isWait = true;
				_inOutAnime.Leave(false, () =>
				{
					//0x142EC3C
					isWait = false;
				});
				while (isWait)
					yield return null;
				backGroundImage.enabled = false;
			}
		}
	}
}
