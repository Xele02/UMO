using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using XeSys;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvBgLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		public ActionButton m_okButton; // 0x14
		private AbsoluteLayout rootLayout; // 0x18
		private AbsoluteLayout bottomFrameLayout; // 0x1C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x20
		[SerializeField]
		private GameObject m_scrollBar; // 0x24
		private bool m_isSkiped; // 0x28
		private bool m_isStarted; // 0x29

		public SwapScrollList List { get { return m_scrollList; } } //0x151B2E8
		public bool IsSkip { get { return m_isSkiped; } } //0x151B2F0
		public float ScrollValue { get { return m_scrollList.ScrollRect.horizontalNormalizedPosition; } set { m_scrollList.ScrollRect.horizontalNormalizedPosition = value; } } //0x151B2F8 0x151B34C

		// RVA: 0x151B398 Offset: 0x151B398 VA: 0x151B398
		private void Update()
		{
			if(m_isStarted)
			{
				if (m_isSkiped)
					return;
				if (InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
					m_isSkiped = true;
			}
		}

		// RVA: 0x151B46C Offset: 0x151B46C VA: 0x151B46C
		public void SetupList(int count, bool resetScroll = true)
		{
			bottomFrameLayout.StartAnimGoStop(count < 3 ? "02" : "01");
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.ResetScrollVelocity();
			if (resetScroll)
				m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
			}
		}

		// RVA: 0x151B6D4 Offset: 0x151B6D4 VA: 0x151B6D4
		public void SetOkButtonHidden(bool isHidden)
		{
			m_okButton.Hidden = isHidden;
		}

		//// RVA: 0x151B708 Offset: 0x151B708 VA: 0x151B708
		//public void ScrollSetPosition(int index) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F7C6C Offset: 0x6F7C6C VA: 0x6F7C6C
		// RVA: 0x151B754 Offset: 0x151B754 VA: 0x151B754
		public IEnumerator Co_BeginScroll(float time)
		{
			float start; // 0x18
			float end; // 0x1C

			//0x151C20C
			start = 0;
			end = time;
			while (true)
			{
				start = Mathf.Min(start + Time.deltaTime, end);
				m_scrollList.ScrollRect.verticalNormalizedPosition = 1 - start / end;
				if (start < end)
				{
					if (!m_isSkiped)
						yield return null;
					else
					{
						m_scrollList.ScrollRect.verticalNormalizedPosition = 1;
						break;
					}
				}
				else
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7CE4 Offset: 0x6F7CE4 VA: 0x6F7CE4
		// RVA: 0x151B828 Offset: 0x151B828 VA: 0x151B828
		public IEnumerator Co_BeginTopScroll(float time)
		{
			float start; // 0x18
			float end; // 0x1C

			//0x151C49C
			start = 0;
			end = time;
			while (true)
			{
				start = Mathf.Min(start + Time.deltaTime, end);
				m_scrollList.ScrollRect.verticalNormalizedPosition = start / end;
				if (start < end)
				{
					if (!m_isSkiped)
						yield return null;
					else
					{
						m_scrollList.ScrollRect.verticalNormalizedPosition = 1;
						break;
					}
				}
				else
					break;
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7D5C Offset: 0x6F7D5C VA: 0x6F7D5C
		// RVA: 0x151B8FC Offset: 0x151B8FC VA: 0x151B8FC
		public IEnumerator Co_ShowGetItemPopup(IReadOnlyCollection<ViewOfferCompensation> itemList, bool isLimit)
		{
			//0x151C8DC
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			OfferGetAllItemPopupSetting s = new OfferGetAllItemPopupSetting();
			s.TitleText = bk.GetMessageByLabel("popup_vop_all_receive_title");
			s.IsCaption = true;
			s.isItemLimit = isLimit;
			s.WindowSize = SizeType.Large;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, null, null, null, null);
			yield return new WaitUntil(() =>
			{
				//0x151BEE8
				return PopupWindowManager.IsActivePopupWindow();
			});
			yield return new WaitWhile(() =>
			{
				//0x151BF64
				return PopupWindowManager.IsActivePopupWindow();
			});
			yield return Co.R(SceneCardCheck());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7DD4 Offset: 0x6F7DD4 VA: 0x6F7DD4
		//// RVA: 0x151B9C4 Offset: 0x151B9C4 VA: 0x151B9C4
		public IEnumerator SceneCardCheck()
		{
			bool prevInput;

			//0x151CEB0
			prevInput = GameManager.Instance.InputEnabled;
			GameManager.Instance.InputEnabled = true;
			bool isOpenRecordPlateInfo = true;
			this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Offer, () =>
			{
				//0x151BFE8
				isOpenRecordPlateInfo = false;
			}, false));
			yield return new WaitWhile(() =>
			{
				//0x151BFF4
				return isOpenRecordPlateInfo;
			});
			RecordPlateUtility.ClearShowedList();
			GameManager.Instance.InputEnabled = prevInput;
			while(CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.Count > 0)
			{
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.FIGHNFKAMGI.RemoveAt(0);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7E4C Offset: 0x6F7E4C VA: 0x6F7E4C
		// RVA: 0x151BA70 Offset: 0x151BA70 VA: 0x151BA70
		public IEnumerator Co_BeginAnim()
		{
			//0x151C000
			m_isStarted = true;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_LOBBY_002);
			rootLayout.StartChildrenAnimGoStop("go_in", "st_in");
			while (rootLayout.IsPlayingChildren())
				yield return null;
		}

		// RVA: 0x151BB1C Offset: 0x151BB1C VA: 0x151BB1C
		public void SkipAnim()
		{
			rootLayout.StartChildrenAnimGoStop("st_in");
			m_scrollList.ScrollRect.verticalNormalizedPosition = 1;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F7EC4 Offset: 0x6F7EC4 VA: 0x6F7EC4
		// RVA: 0x151BBDC Offset: 0x151BBDC VA: 0x151BBDC
		public IEnumerator Co_EndAnim()
		{
			//0x151C724
			rootLayout.StartChildrenAnimGoStop("go_out", "st_out");
			while (rootLayout.IsPlayingChildren())
				yield return null;
		}

		// RVA: 0x151BC88 Offset: 0x151BC88 VA: 0x151BC88 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			rootLayout = layout.Root[0] as AbsoluteLayout;
			rootLayout.StartAllAnimGoStop("st_wait");
			rootLayout.StartAllAnimGoStop("st_non");
			bottomFrameLayout = layout.FindViewByExId("sw_s_v_win_grad_onoff_anim_s_v_win_grad_02_b") as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
