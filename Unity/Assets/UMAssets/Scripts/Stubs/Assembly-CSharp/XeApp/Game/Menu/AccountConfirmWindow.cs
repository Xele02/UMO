using mcrs;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class AccountConfirmWindow : MonoBehaviour
	{
		public enum Result
		{
			None = 0,
			OK = 1,
			Cancel = 2,
		}

		[SerializeField]
		private Text titleText; // 0x10
		[SerializeField]
		private Text contentText; // 0x14
		[SerializeField]
		private Text okButtonText; // 0x18
		[SerializeField]
		private Text cancelButtonText; // 0x1C
		[SerializeField]
		private UGUIButton okButton; // 0x20
		[SerializeField]
		private UGUIButton cancelButton; // 0x24
		[SerializeField]
		private Image backGroundImage; // 0x28
		private ScrollRect _scrollRect; // 0x2C
		private InOutAnime _inOutAnime; // 0x30
		private List<ButtonBase> _buttonList = new List<ButtonBase>(); // 0x34

		public Result WindowResult { get; private set; } // 0xC

		// RVA: 0x142F85C Offset: 0x142F85C VA: 0x142F85C
		private void Awake()
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			if (titleText != null)
				titleText.text = bk.GetMessageByLabel("popup_account_management_text016");
			if (okButtonText != null)
				okButtonText.text = bk.GetMessageByLabel("popup_account_management_text019");
			if (cancelButtonText != null)
				cancelButtonText.text = bk.GetMessageByLabel("popup_account_management_text018");
			if(okButton != null)
			{
				okButton.AddOnClickCallback(() =>
				{
					//0x1430AC0
					if (WindowResult != Result.None)
						return;
					WindowResult = Result.OK;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				});
				_buttonList.Add(okButton);
			}
			if(cancelButton != null)
			{
				cancelButton.AddOnClickCallback(() =>
				{
					//0x1430B2C
					if (WindowResult != Result.None)
						return;
					WindowResult = Result.Cancel;
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
				});
				_buttonList.Add(cancelButton);
			}
			if (backGroundImage != null)
				backGroundImage.enabled = false;
			_inOutAnime = GetComponentInChildren<InOutAnime>();
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x1430C14
				_.IsInputOff = true;
			});
			_scrollRect = GetComponentInChildren<ScrollRect>();
		}

		// RVA: 0x142FE3C Offset: 0x142FE3C VA: 0x142FE3C
		public void SetContent(int playerId, string name, int playerRank, bool facebook, bool twitter, bool line, bool apple, MCKCJMLOAFP_CurrencyInfo balanceData, bool passAvailable, bool topPlan)
		{
			if (contentText != null)
			{
				MessageBank bk = MessageManager.Instance.GetBank("common");
				StringBuilder str = new StringBuilder();
				str.SetFormat("popup_account_management_text017", new object[8]
				{
					playerId, name, playerRank,
					MakeAccountLinkagingText(facebook, twitter, line, apple),
					balanceData.BDLNMOIOMHK_Total,
					balanceData.KCKBGALKNMA_NumPaidCrystal,
					balanceData.JLNEMPJICEH_NumFreeCrystal,
					MakePassText(passAvailable,topPlan)
				});
				contentText.text = str.ToString();
			}
		}

		//// RVA: 0x1430394 Offset: 0x1430394 VA: 0x1430394
		private string MakeAccountLinkagingText(bool facebook, bool twitter, bool line, bool apple)
		{
			MessageBank bk = MessageManager.Instance.GetBank("common");
			StringBuilder str = new StringBuilder();
			bool b = false;
			if(!facebook && !twitter && !line)
			{
				str.Set(bk.GetMessageByLabel("popup_account_linkaging_text_none"));
			}
			else
			{
				if(apple)
				{
					str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_apple"));
					b = true;
				}
				if(facebook)
				{
					if(b)
					{
						str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_separator"));
					}
					str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_facebook"));
					b = true;
				}
				if(twitter)
				{
					if (b)
					{
						str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_separator"));
					}
					str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_twitter"));
					b = true;
				}
				if (line)
				{
					if (b)
					{
						str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_separator"));
					}
					str.Append(bk.GetMessageByLabel("popup_account_linkaging_text_line"));
				}
			}
			return str.ToString();
		}

		//// RVA: 0x143074C Offset: 0x143074C VA: 0x143074C
		private string MakePassText(bool passAvailable, bool topPlan)
		{
			return MessageManager.Instance.GetBank("common").GetMessageByLabel(!passAvailable ? "popup_account_remove_pass_001" : (topPlan ? "popup_account_remove_pass_003" : "popup_account_remove_pass_002"));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C96F4 Offset: 0x6C96F4 VA: 0x6C96F4
		// RVA: 0x1430830 Offset: 0x1430830 VA: 0x1430830
		public IEnumerator Co_Show()
		{
			//0x1430FAC
			WindowResult = Result.None;
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
					//0x1430CAC
					isWait = false;
				});
				while (isWait)
					yield return null;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C976C Offset: 0x6C976C VA: 0x6C976C
		// RVA: 0x14308DC Offset: 0x14308DC VA: 0x14308DC
		public IEnumerator Co_Wait()
		{
			//0x1431484
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x1430C44
				_.IsInputOff = false;
			});
			while(WindowResult == Result.None)
				yield return null;
			_buttonList.ForEach((ButtonBase _) =>
			{
				//0x1430C74
				_.IsInputOff = true;
			});
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6C97E4 Offset: 0x6C97E4 VA: 0x6C97E4
		// RVA: 0x1430988 Offset: 0x1430988 VA: 0x1430988
		public IEnumerator Co_Close()
		{
			//0x1430CD0
			if(_inOutAnime != null)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_001);
				bool isWait = true;
				_inOutAnime.Leave(false, () =>
				{
					//0x1430CC0
					isWait = false;
				});
				while (isWait)
					yield return null;
				backGroundImage.enabled = false;
			}
		}
	}
}
