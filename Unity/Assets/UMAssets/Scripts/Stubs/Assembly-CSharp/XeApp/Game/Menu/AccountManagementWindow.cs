using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;
using XeSys;
using System.Collections;
using mcrs;

namespace XeApp.Game.Menu
{
	public class AccountManagementWindow : MonoBehaviour
	{
		public enum Result
		{
			None = 0,
			Close = 1,
			TakeOver = 2,
			AccountRemove = 3,
		}

		[SerializeField]
		private UGUIButton takeOverButton; // 0x10
		[SerializeField]
		private UGUIButton accountRemoveButton; // 0x14
		[SerializeField]
		private UGUIButton closeButton; // 0x18
		[SerializeField]
		private Text windowTitle; // 0x1C
		[SerializeField]
		private Text takeOverText; // 0x20
		[SerializeField]
		private Text takeOverText2; // 0x24
		[SerializeField]
		private Text takeOverText3; // 0x28
		[SerializeField]
		private Text takeOverButtonText; // 0x2C
		[SerializeField]
		private Text accountRemoveText; // 0x30
		[SerializeField]
		private Text accountRemoveText2; // 0x34
		[SerializeField]
		private Text accountRemoveText3; // 0x38
		[SerializeField]
		private Text accountRemoveButtonText; // 0x3C
		[SerializeField]
		private Text closeButtonText; // 0x40
		[SerializeField]
		private Image backGroundImage; // 0x44
		[SerializeField]
		private RectTransform accountRemoveRoot; // 0x48
		private InOutAnime _inOutAnime; // 0x4C
		private List<ButtonBase> _buttonList = new List<ButtonBase>(); // 0x50

		public Result WindowResult { get; private set; } // 0xC

		// RVA: 0x1431804 Offset: 0x1431804 VA: 0x1431804
		private void Awake()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			if (windowTitle != null)
				windowTitle.text = bk.GetMessageByLabel("popup_account_management_text001");
			if (takeOverText != null)
				takeOverText.text = bk.GetMessageByLabel("popup_account_management_text002");
			if (takeOverText2 != null)
				takeOverText2.text = bk.GetMessageByLabel("popup_account_management_text003");
			if (takeOverText3 != null)
				takeOverText3.text = bk.GetMessageByLabel("popup_account_management_text004");
			if (takeOverButtonText != null)
				takeOverButtonText.text = bk.GetMessageByLabel("popup_account_management_text005");
			if (accountRemoveText != null)
				accountRemoveText.text = bk.GetMessageByLabel("popup_account_management_text009");
			if (accountRemoveText2 != null)
				accountRemoveText2.text = bk.GetMessageByLabel("popup_account_management_text007");
			if (accountRemoveText3 != null)
				accountRemoveText3.text = bk.GetMessageByLabel("popup_account_management_text008");
			if (accountRemoveButtonText != null)
				accountRemoveButtonText.text = bk.GetMessageByLabel("popup_account_management_text006");
			if (closeButtonText != null)
				closeButtonText.text = bk.GetMessageByLabel("popup_account_management_text010");
			if(takeOverButton != null)
			{ 
				takeOverButton.AddOnClickCallback(() =>
				{
					//0x1432718
					if (WindowResult != Result.None)
						return;
					WindowResult = Result.TakeOver;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
				_buttonList.Add(takeOverButton);
			}
			if(accountRemoveButton != null)
			{
				accountRemoveButton.AddOnClickCallback(() =>
				{
					//0x1432784
					if (WindowResult != Result.None)
						return;
					WindowResult = Result.AccountRemove;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
				_buttonList.Add(accountRemoveButton);
			}
			if(closeButton != null)
			{
				closeButton.AddOnClickCallback(() =>
				{
					//0x14327F0
					if (WindowResult != Result.None)
						return;
					WindowResult = Result.Close;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				});
				_buttonList.Add(closeButton);
			}
			if (backGroundImage != null)
				backGroundImage.enabled = false;
			_inOutAnime = GetComponentInChildren<InOutAnime>();
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x14328D8
				_.IsInputLock = true;
			});
			if (accountRemoveRoot != null)
				accountRemoveRoot.gameObject.SetActive(false);
		}


		//[IteratorStateMachineAttribute] // RVA: 0x6C998C Offset: 0x6C998C VA: 0x6C998C
		// RVA: 0x14323A8 Offset: 0x14323A8 VA: 0x14323A8
		public IEnumerator Co_Show()
		{
			//0x1433108
			if(_inOutAnime != null)
			{
				transform.SetAsLastSibling();
				WindowResult = Result.None;
				if(!_inOutAnime.IsEnter)
				{
					backGroundImage.enabled = true;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_000);
					bool isWait = true;
					_inOutAnime.Enter(false, () =>
					{
						//0x1432970
						isWait = false;
					});
					while (isWait)
						yield return null;
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C9A04 Offset: 0x6C9A04 VA: 0x6C9A04
		// RVA: 0x1432454 Offset: 0x1432454 VA: 0x1432454
		public IEnumerator Co_Run()
		{
			//0x1432C70
			GameManager.Instance.AddPushBackButtonHandler(AndroidBackButton);
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x1432908
				_.IsInputLock = false;
			});
			while (WindowResult == Result.None)
				yield return null;
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x1432938
				_.IsInputLock = true;
			});
			GameManager.Instance.RemovePushBackButtonHandler(AndroidBackButton);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C9A7C Offset: 0x6C9A7C VA: 0x6C9A7C
		// RVA: 0x1432500 Offset: 0x1432500 VA: 0x1432500
		public IEnumerator Co_Close()
		{
			//0x1432994
			if(_inOutAnime != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
				bool isWait = true;
				_inOutAnime.Leave(false, () =>
				{
					//0x1432984
					isWait = false;
				});
				while (isWait)
					yield return null;
				backGroundImage.enabled = false;
			}
		}

		//// RVA: 0x14325AC Offset: 0x14325AC VA: 0x14325AC
		private void AndroidBackButton()
		{
			if (closeButton != null && !closeButton.IsInputLock)
				closeButton.PerformClick();
		}
	}
}
