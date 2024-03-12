using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using XeApp.Game.Common;
using mcrs;
using XeSys;
using System;

namespace XeApp.Game.Menu
{
	public class DecoStampMakerScene : TransitionRoot
	{
		private DecoCustomDecorator m_decorator; // 0x48
		private LayoutDecoCustomStampWindow m_customStampWindow; // 0x4C
		private bool isChangeProcess = true; // 0x50
		private Coroutine sortLayoutCoroutine; // 0x54
		private LayoutDecoCustomViewStamp m_viewStamp; // 0x58
		private bool isNewCreate; // 0x5C
		private bool isSelectCharactor; // 0x5D
		private DecoCreateStampPopupSetting m_EditStampSetting; // 0x60
		private PopupShopItemContent m_popupSetting; // 0x64
		private LayoutDecoCustomStampWindow.StampData targetStamp; // 0x68
		private DecoCustomDecorator.DecoratorType currentType; // 0x6C
		private bool isCancelSerif; // 0x70
		[SerializeField] // RVA: 0x66BA38 Offset: 0x66BA38 VA: 0x66BA38
		private Image m_panel; // 0x74

		// RVA: 0x1587DE8 Offset: 0x1587DE8 VA: 0x1587DE8
		private void Awake()
		{
			base.Awake();
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15509, 0);
			m_EditStampSetting = new DecoCreateStampPopupSetting();
			m_EditStampSetting.WindowSize = Common.SizeType.Middle;
			m_EditStampSetting.SetParent(transform);
			this.StartCoroutineWatched(Co_LayoutAssetLoad());
			this.StartCoroutineWatched(CharaTexCasheCreate(CreateItemDataList(0)));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3D7C Offset: 0x6D3D7C VA: 0x6D3D7C
		//// RVA: 0x1587F58 Offset: 0x1587F58 VA: 0x1587F58
		private IEnumerator Co_LayoutAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0x158E4A8
			m_decorator = GetComponent<DecoCustomDecorator>();
			m_decorator.DecideItemCallback = DecideEnter;
			m_decorator.SelectIdCallback = SelectId;
			m_decorator.LoadResoruce();
			while (!m_decorator.IsLoaded)
				yield return null;
			bundleName = "ly/206.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetCustomStampWindow(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetCustomViewStamp(bundleName, systemFont));
			while (m_customStampWindow == null)
				yield return null;
			while (m_viewStamp == null)
				yield return null;
			m_viewStamp.Hide();
			m_customStampWindow.SetCancleButtonAction(EnterSort);
			m_customStampWindow.OnStampEdit = EditStamp;
			m_customStampWindow.OnDeleteStamp = DeleteCheck;
			yield return this.StartCoroutineWatched(m_customStampWindow.Co_LoadListItem());
			m_customStampWindow.SwitchLayout(0);
			m_decorator.ReShow();
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3DF4 Offset: 0x6D3DF4 VA: 0x6D3DF4
		//// RVA: 0x1588210 Offset: 0x1588210 VA: 0x1588210
		private IEnumerator Co_LoadAssetCustomStampWindow(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x158EB80
			if(m_customStampWindow == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_cstm_deco_win_02_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x158BE38
					instance.transform.SetParent(transform, false);
					m_customStampWindow = instance.GetComponent<LayoutDecoCustomStampWindow>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_customStampWindow.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3E6C Offset: 0x6D3E6C VA: 0x6D3E6C
		//// RVA: 0x15882F0 Offset: 0x15882F0 VA: 0x15882F0
		private IEnumerator Co_LoadAssetCustomViewStamp(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x158EE94
			if(m_viewStamp == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_cstm_deco_item_stamp_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x158BF08
					instance.transform.SetParent(transform, false);
					m_viewStamp = instance.GetComponent<LayoutDecoCustomViewStamp>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_viewStamp.transform.SetParent(transform, false);
			}
		}

		// RVA: 0x15883D0 Offset: 0x15883D0 VA: 0x15883D0 Slot: 16
		protected override void OnPreSetCanvas()
		{
			Color c = m_panel.color;
			c.a = 0;
			m_panel.color = c;
			isNewCreate = false;
			m_viewStamp.Hide();
			m_customStampWindow.Hide();
			m_customStampWindow.Prepare();
			m_customStampWindow.SwitchLayout(0);
			m_decorator.Leave();
		}

		// RVA: 0x1588570 Offset: 0x1588570 VA: 0x1588570 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return m_decorator.IsPlayingEnd() && !IsAnimationPlaying();
		}

		// RVA: 0x15885E0 Offset: 0x15885E0 VA: 0x15885E0 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_customStampWindow.Enter();
		}

		// RVA: 0x158860C Offset: 0x158860C VA: 0x158860C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return !m_customStampWindow.IsPlaying();
		}

		// RVA: 0x158863C Offset: 0x158863C VA: 0x158863C Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_customStampWindow.Leave();
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
		}

		// RVA: 0x15887AC Offset: 0x15887AC VA: 0x15887AC Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_customStampWindow.IsPlaying();
		}

		//// RVA: 0x15885B4 Offset: 0x15885B4 VA: 0x15885B4
		private bool IsAnimationPlaying()
		{
			return m_customStampWindow.IsPlaying();
		}

		//// RVA: 0x15887DC Offset: 0x15887DC VA: 0x15887DC
		private void EnterCreateStamp()
		{
			if(!IsAnimationPlaying())
			{
				ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15510, 0);
				Color c = m_panel.color;
				c.a = 0.4f;
				m_panel.color = c;
				this.StartCoroutineWatched(Co_EnterCreateStamp());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3EE4 Offset: 0x6D3EE4 VA: 0x6D3EE4
		//// RVA: 0x15889A4 Offset: 0x15889A4 VA: 0x15889A4
		private IEnumerator Co_EnterCreateStamp()
		{
			//0x158E0A4
			m_customStampWindow.Leave();
			GameManager.Instance.AddPushBackButtonHandler(NotBackKey);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
			while (m_customStampWindow.IsPlaying())
				yield return null;
			MenuScene.Instance.InputEnable();
			DecoCreateStampWindowProcess(0, EnterSelectCharactor, CancelEditStamp);
		}

		//// RVA: 0x1588A50 Offset: 0x1588A50 VA: 0x1588A50
		private void EnterSelectCharactor()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			DecoCreateStampWindowProcess(DecoCustomDecorator.DecoratorType.Serif, EnterSelectSerif, EnterCancelSerif);
		}

		//// RVA: 0x1588BAC Offset: 0x1588BAC VA: 0x1588BAC
		private void EnterCancelSerif()
		{
			isCancelSerif = true;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
			DecoCreateStampWindowProcess(DecoCustomDecorator.DecoratorType.Chara, EnterSelectCharactor, CancelEditStamp);
		}

		//// RVA: 0x1588CCC Offset: 0x1588CCC VA: 0x1588CCC
		private void EnterSelectSerif()
		{
			if (m_decorator.TargetSerifId == 0)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_SaveStamp());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3F5C Offset: 0x6D3F5C VA: 0x6D3F5C
		//// RVA: 0x1588D68 Offset: 0x1588D68 VA: 0x1588D68
		private IEnumerator Co_SaveStamp()
		{
			int number;

			//0x158F1A8
			MenuScene.Instance.InputDisable();
			targetStamp.serifId = m_decorator.TargetSerifId;
			targetStamp.stampId = m_decorator.TargetStampId;
			if(!isNewCreate)
			{
				number = targetStamp.number;
				m_customStampWindow.UpdateStamp(targetStamp, targetStamp.number);
				ILCCJNDFFOB.HHCJCDFCLOB.OMLMHKGCJPH(number, JpStringLiterals.StringLiteral_15524, targetStamp.stampId, targetStamp.serifId);
			}
			else
			{
				number = m_customStampWindow.GetStampCount();
				m_customStampWindow.AddStamp(m_decorator.TargetStampId, m_decorator.TargetSerifId);
				ILCCJNDFFOB.HHCJCDFCLOB.OMLMHKGCJPH(number, JpStringLiterals.StringLiteral_15525, m_decorator.TargetStampId, m_decorator.TargetSerifId);
			}
			while (!m_customStampWindow.IsSaveSucces)
				yield return null;
			m_EditStampSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_EditStampSetting.charactorId = m_decorator.TargetStampId;
			m_EditStampSetting.serifId = m_decorator.TargetSerifId;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_EditStampSetting.TitleText = string.Format(bk.GetMessageByLabel("pop_customstamp_edit_save_title"), number);
			PopupWindowManager.Show(m_EditStampSetting, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x158BFD8
				if (t != PopupButton.ButtonType.Positive)
					return;
				CreateStampEndProcess();
				MenuScene.Instance.InputEnable();
			}, null, null, null);
		}

		//// RVA: 0x1588E14 Offset: 0x1588E14 VA: 0x1588E14
		private void CancelEditStamp()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
			CreateStampEndProcess();
		}

		//// RVA: 0x1588E78 Offset: 0x1588E78 VA: 0x1588E78
		private void CreateStampEndProcess()
		{
			isNewCreate = false;
			m_viewStamp.Hide();
			m_decorator.Leave();
			m_customStampWindow.Enter();
			GameManager.Instance.RemovePushBackButtonHandler(NotBackKey);
			MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton(false);
			MenuScene.Instance.HeaderMenu.MenuStack.EnterLabel();
			Color c = m_panel.color;
			c.a = 0;
			m_panel.color = c;
			m_customStampWindow.ResetTarget();
		}

		//// RVA: 0x1588B68 Offset: 0x1588B68 VA: 0x1588B68
		private void DecoCreateStampWindowProcess(DecoCustomDecorator.DecoratorType type, Action right, Action left)
		{
			if(isChangeProcess)
			{
				currentType = type;
				this.StartCoroutineWatched(Co_CreateStampWindowProcess(type, right, left));
			}
		}

		//// RVA: 0x158929C Offset: 0x158929C VA: 0x158929C
		private void SelectId(int id)
		{
			if(!isSelectCharactor)
			{
				m_decorator.TargetSerifId = id;
				return;
			}
			if(!isCancelSerif)
			{
				m_decorator.TargetStampId = id;
				return;
			}
			isCancelSerif = false;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D3FD4 Offset: 0x6D3FD4 VA: 0x6D3FD4
		//// RVA: 0x15891C4 Offset: 0x15891C4 VA: 0x15891C4
		private IEnumerator Co_CreateStampWindowProcess(DecoCustomDecorator.DecoratorType type, Action right, Action left)
		{
			bool isChara;

			//0x158D3D4
			isChangeProcess = false;
			m_decorator.Leave();
			isChara = type == DecoCustomDecorator.DecoratorType.Chara;
			while (!m_decorator.IsPlayingEnd())
				yield return null;
			m_decorator.LoadSelectItem(type, CreateItemDataList(type));
			while (!m_decorator.IsLoadedResource)
				yield return null;
			m_decorator.ClickRightButtonCallback = right;
			m_decorator.ClickLeftButtonCallback = left;
			isSelectCharactor = isChara;
			m_decorator.Enter();
			if(type == DecoCustomDecorator.DecoratorType.Chara)
			{
				m_viewStamp.CharaSelect();
				m_viewStamp.SetTexCharactor(m_decorator.TargetStampId);
			}
			else
			{
				m_viewStamp.SerifSelect();
				m_viewStamp.SetTexSerif(m_decorator.TargetSerifId);
			}
			while (!m_viewStamp.IsCharaTexLoad)
				yield return null;
			while (!m_viewStamp.IsSerifTexLoad)
				yield return null;
			m_viewStamp.Show();
			m_decorator.ReShow();
			yield return null;
			m_decorator.RightButtonHidden = right == null;
			m_decorator.LeftButtonHidden = left == null;
			while (!m_decorator.IsPlayingEnd())
				yield return null;
			isChangeProcess = true;
		}

		//// RVA: 0x1589338 Offset: 0x1589338 VA: 0x1589338
		private void EnterSort()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			GameManager.Instance.AddPushBackButtonHandler(NotBackKey);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveLabel(false);
			MenuScene.Instance.HeaderMenu.MenuStack.LeaveBackButton(false);
			this.StartCoroutineWatched(Co_SortWindowProcess(false, LayoutDecoCustomStampWindow.Mode.Sort, PrepareSort, null, null));
		}

		//// RVA: 0x15896F0 Offset: 0x15896F0 VA: 0x15896F0
		private void EnterSortSave()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			ReturnCreateStamp(true);
		}

		//// RVA: 0x15899DC Offset: 0x15899DC VA: 0x15899DC
		private void EnterSortCancel()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_002);
			ReturnCreateStamp(false);
			m_customStampWindow.ExchangeCancell();
		}

		//// RVA: 0x1589758 Offset: 0x1589758 VA: 0x1589758
		private void ReturnCreateStamp(bool isSave)
		{
			MenuScene.Instance.InputDisable();
			sortLayoutCoroutine = this.StartCoroutineWatched(Co_SortWindowProcess(isSave, LayoutDecoCustomStampWindow.Mode.CreateStamp, PrepareCreateStamp, () =>
			{
				//0x158C08C
				GameManager.Instance.RemovePushBackButtonHandler(NotBackKey);
				MenuScene.Instance.HeaderMenu.MenuStack.EnterBackButton();
				MenuScene.Instance.HeaderMenu.MenuStack.EnterLabel();
			}, () =>
			{
				//0x158C344
				MenuScene.Instance.InputEnable();
			}));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D404C Offset: 0x6D404C VA: 0x6D404C
		//// RVA: 0x15895E0 Offset: 0x15895E0 VA: 0x15895E0
		private IEnumerator Co_SortWindowProcess(bool isSave, LayoutDecoCustomStampWindow.Mode mode, Action<Action> prepareProcess, Action callback, Action endCoroutin)
		{
			//0x158F980
			if(isSave)
			{
				yield return this.StartCoroutineWatched(Co_CheckSavePopup(endCoroutin));
				while (!m_customStampWindow.IsSaveSucces)
					yield return null;
			}
			m_customStampWindow.Leave();
			while (IsAnimationPlaying())
				yield return null;
			bool isDone = false;
			prepareProcess(() =>
			{
				//0x158C418
				isDone = true;
			});
			while (!isDone)
				yield return null;
			m_customStampWindow.SwitchLayout(mode);
			m_customStampWindow.Enter();
			while (IsAnimationPlaying())
				yield return null;
			if (callback != null)
				callback();
			if (endCoroutin != null)
				endCoroutin();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D40C4 Offset: 0x6D40C4 VA: 0x6D40C4
		//// RVA: 0x1589A84 Offset: 0x1589A84 VA: 0x1589A84
		private IEnumerator Co_CheckSavePopup(Action _endCoroutin)
		{
			//0x158CE70
			bool isDone = false;
			bool isCancel = false;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_customstamp_sort_save_title");
			s.Text = bk.GetMessageByLabel("pop_customstamp_sort_save_desc");
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x158C42C
				isDone = true;
				if(t != PopupButton.ButtonType.Positive)
				{
					if (t == PopupButton.ButtonType.Negative)
						isCancel = true;
					return;
				}
				m_customStampWindow.ExchangeSave();
			}, null, null, null);
			while (!isDone)
				yield return null;
			if(isCancel)
			{
				if (_endCoroutin != null)
					_endCoroutin();
				this.StopCoroutineWatched(sortLayoutCoroutine);
			}
		}

		//// RVA: 0x1589B4C Offset: 0x1589B4C VA: 0x1589B4C
		private void PrepareCreateStamp(Action callback)
		{
			m_customStampWindow.SetCancleButtonAction(EnterSort);
			m_customStampWindow.SetDecideButtonAction(null);
			if (callback != null)
				callback();
		}

		//// RVA: 0x1589C74 Offset: 0x1589C74 VA: 0x1589C74
		private void PrepareSort(Action callback)
		{
			m_customStampWindow.SetCancleButtonAction(EnterSortCancel);
			m_customStampWindow.SetDecideButtonAction(EnterSortSave);
			if (callback != null)
				callback();
		}

		//// RVA: 0x1589DD4 Offset: 0x1589DD4 VA: 0x1589DD4
		private void DecideEnter(LayoutDecoCustomSelectItemBase item)
		{
			if(item.IsShopProducts)
			{
				RequestBuyOne(item.ShopProduct);
				return;
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_viewStamp.Show();
			if(item.Type == LayoutDecoCustomWindow01.SelectItemType.Serif)
			{
				m_viewStamp.SetTexSerif(item.Id);
				m_decorator.TargetSerifId = item.Id;
				targetStamp.serifId = item.Id;
			}
			else if(item.Type == LayoutDecoCustomWindow01.SelectItemType.Chara)
			{
				m_viewStamp.SetTexCharactor(item.Id);
				m_decorator.TargetStampId = item.Id;
				m_decorator.IsMatchEditChara = m_decorator.OriginEditCharaId == GetStampCharaId(item.Id);
				targetStamp.stampId = item.Id;
			}
			else
			{
				m_viewStamp.Hide();
			}
			m_decorator.ScrollVisibleUpdate();
		}

		//// RVA: 0x158A118 Offset: 0x158A118 VA: 0x158A118
		private void RequestBuyOne(FJGOKILCBJA product)
		{
			CKPOGHOIBEP d = new CKPOGHOIBEP();
			d.IJELHNMHAJH(this, product, () =>
			{
				//0x158C268
				m_decorator.ReSetItemList(CreateItemDataList(currentType));
				m_decorator.UpdateScrollList();
			}, null, MenuScene.Instance.GotoTitle, null);
		}

		//// RVA: 0x158A3C0 Offset: 0x158A3C0 VA: 0x158A3C0
		private void DeleteCheck(Action callback)
		{
			LayoutDecoCustomStampWindow.StampData data = m_customStampWindow.GetTargetStampInfo();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int stampNumber = data.number;
			m_EditStampSetting.TitleText = string.Format(bk.GetMessageByLabel("pop_customstamp_delete_title"), data.number);
			m_EditStampSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_EditStampSetting.charactorId = data.stampId;
			m_EditStampSetting.serifId = data.serifId;
			PopupWindowManager.Show(m_EditStampSetting, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x158C48C
				if(t == PopupButton.ButtonType.Negative)
				{
					if (callback != null)
						callback();
				}
				else if(t == PopupButton.ButtonType.Positive)
				{
					ILCCJNDFFOB.HHCJCDFCLOB.OMLMHKGCJPH(data.number, JpStringLiterals.StringLiteral_11225, data.stampId, data.serifId);
					MenuScene.Instance.InputDisable();
					m_customStampWindow.DeleteStamp(data.number, () =>
					{
						//0x158C6D4
						DeleteNotif(stampNumber, callback);
						MenuScene.Instance.InputEnable();
					});
				}
			}, null, null, null);
		}

		//// RVA: 0x158A7D4 Offset: 0x158A7D4 VA: 0x158A7D4
		private void DeleteNotif(int stampNumber, Action callback)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_EditStampSetting.TitleText = string.Format(bk.GetMessageByLabel("pop_customstamp_deletecheck_title"), stampNumber);
			m_EditStampSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(m_EditStampSetting, (PopupWindowControl cont, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x158C7A0
				if (callback != null)
					callback();
			}, null, null, null);
		}

		//// RVA: 0x158AAA8 Offset: 0x158AAA8 VA: 0x158AAA8
		private void EditStamp()
		{
			this.StartCoroutineWatched(Co_EditStamp());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D413C Offset: 0x6D413C VA: 0x6D413C
		//// RVA: 0x158AACC Offset: 0x158AACC VA: 0x158AACC
		private IEnumerator Co_EditStamp()
		{
			LayoutDecoCustomStampWindow.StampData data;

			//0x158D90C
			MenuScene.Instance.InputDisable();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			data = m_customStampWindow.GetTargetStampInfo();
			if(data.type == LayoutDecoCustomStampItem.Type.Create)
			{
				bool isDone = false;
				bool isCancel = false;
				if(m_customStampWindow.IsStampMax())
				{
					MenuScene.Instance.InputEnable();
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					TextPopupSetting s = new TextPopupSetting();
					s.TitleText = bk.GetMessageByLabel("pop_customstamp_createlimit_title");
					s.Text = bk.GetMessageByLabel("pop_customstamp_createlimit_desc");
					s.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
					{
						//0x158C7BC
						if (t == PopupButton.ButtonType.Positive)
						{
							isDone = true;
							isCancel = true;
						}
					}, null, null, null);
				}
				else
				{
					isDone = true;
					isNewCreate = true;
				}
				while (!isDone)
					yield return null;
				if (isCancel)
					yield break;
			}
			//LAB_0158de10
			targetStamp = data;
			if(targetStamp.number == 0)
			{
				m_decorator.IsCreate = true;
			}
			else
			{
				m_decorator.TargetStampId = targetStamp.stampId;
				m_decorator.TargetSerifId = targetStamp.serifId;
				m_decorator.OriginEditCharaId = GetStampCharaId(targetStamp.stampId);
				m_decorator.OriginEditSerifId = targetStamp.serifId;
				m_decorator.IsMatchEditChara = true;
				m_decorator.IsCreate = false;
			}
			EnterCreateStamp();
		}

		//// RVA: 0x1587FE4 Offset: 0x1587FE4 VA: 0x1587FE4
		private List<LayoutDecoCustomWindow01.SelectItemData> CreateItemDataList(DecoCustomDecorator.DecoratorType type)
		{
			if(type == DecoCustomDecorator.DecoratorType.Serif)
			{
				List<LayoutDecoCustomWindow01.SelectItemData> l = new List<LayoutDecoCustomWindow01.SelectItemData>(CreateStampPartsList(LayoutDecoCustomWindow01.SelectItemType.Serif));
				l.AddRange(CreateDecoShopStampPartsList(EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif));
				return l;
			}
			else if(type == DecoCustomDecorator.DecoratorType.Chara)
			{
				List<LayoutDecoCustomWindow01.SelectItemData> l = new List<LayoutDecoCustomWindow01.SelectItemData>(CreateStampPartsList(LayoutDecoCustomWindow01.SelectItemType.Chara));
				l.AddRange(CreateDecoShopStampPartsList(EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara));
				return l;
			}
			return new List<LayoutDecoCustomWindow01.SelectItemData>();
		}

		//// RVA: 0x158AB78 Offset: 0x158AB78 VA: 0x158AB78
		private List<LayoutDecoCustomWindow01.SelectItemData> CreateStampPartsList(LayoutDecoCustomWindow01.SelectItemType selectItemType)
		{
			List<LayoutDecoCustomWindow01.SelectItemData> res;
			List<LayoutDecoCustomWindow01.SelectItemData> l;
			if (selectItemType == LayoutDecoCustomWindow01.SelectItemType.Chara)
				l = PossetionCharList();
			else
				l = PossetionSerifList();
			res = new List<LayoutDecoCustomWindow01.SelectItemData>(l);
			return res;
		}

		//// RVA: 0x158BB04 Offset: 0x158BB04 VA: 0x158BB04
		private List<LayoutDecoCustomWindow01.SelectItemData> PossetionCharList()
		{
			List<LayoutDecoCustomWindow01.SelectItemData> res = new List<LayoutDecoCustomWindow01.SelectItemData>();
			List<NCPPAHHCCAO> l = NCPPAHHCCAO.FKDIMODKKJD();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].BFINGCJHOHI_Cnt > 0)
				{
					res.Add(new LayoutDecoCustomWindow01.SelectItemData() {
						id = l[i].PPFNGGCBJKC,
						type = LayoutDecoCustomWindow01.SelectItemType.Chara,
						text = null,
						series = (SeriesAttr.Type)l[i].CPKMLLNADLJ,
						isShopProduct = false,
						charaId = l[i].IDELKEKDIFD_CharaId,
						charaType = l[i].INDDJNMPONH,
						emotion = l[i].BEHMEDMNJMC_EmotionId,
						IsNew = false,
						tabCategory = l[i].BEHMEDMNJMC_EmotionId,
						product = null
					});
				}
			}
			return res;
		}

		//// RVA: 0x158B588 Offset: 0x158B588 VA: 0x158B588
		private List<LayoutDecoCustomWindow01.SelectItemData> PossetionSerifList()
		{
			List<LayoutDecoCustomWindow01.SelectItemData> res = new List<LayoutDecoCustomWindow01.SelectItemData>();
			for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
			{
				IOEKHJBOMDH_DecoStamp.GFPPDCEPLCM saveStamp = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.DMKMNGELNAE_Serif[i];
				if(saveStamp.BFINGCJHOHI_Cnt > 0)
				{
					int itemid = saveStamp.PPFNGGCBJKC_Id;
					IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP dbStamp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
					{
						//0x158C7CC
						return item.PPFNGGCBJKC == itemid;
					});
					res.Add(new LayoutDecoCustomWindow01.SelectItemData()
					{
						id = dbStamp.PPFNGGCBJKC,
						type = LayoutDecoCustomWindow01.SelectItemType.Serif,
						text = null,
						series = (SeriesAttr.Type) dbStamp.CPKMLLNADLJ,
						isShopProduct = false,
						charaId = dbStamp.JBFLEDKDFCO,
						charaType = 0,
						emotion = 0,
						IsNew = false,
						tabCategory = dbStamp.DMEDKJPOLCH,
						product = null
					});
				}
			}
			return res;
		}

		//// RVA: 0x158AD04 Offset: 0x158AD04 VA: 0x158AD04
		private List<LayoutDecoCustomWindow01.SelectItemData> CreateDecoShopStampPartsList(EKLNMHFCAOI.FKGCBLHOOCL_Category category)
		{
			List<LayoutDecoCustomWindow01.SelectItemData> res = new List<LayoutDecoCustomWindow01.SelectItemData>();
			List<AODFBGCCBPE> l = AODFBGCCBPE.FKDIMODKKJD(false);
			AODFBGCCBPE a = l.Find((AODFBGCCBPE item) =>
			{
				//0x158C3E0
				return item.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5;
			});
			if(a == null)
			{
				Debug.LogError("ShopData Type Deco None");
			}
			else
			{
				List<FJGOKILCBJA> l2 = a.MHKCPJDNJKI.FindAll((FJGOKILCBJA item) =>
				{
					//0x158C810
					return category == EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.KIJAPOFAGPN_ItemFullId);
				});
				List<FJGOKILCBJA> l3 = l2.FindAll((FJGOKILCBJA item) =>
				{
					//0x158C8CC
					if(item.EAIJAAEKDAB_GetNumRemain() != 0)
					{
						return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.KIJAPOFAGPN_ItemFullId), null) == 0;
					}
					return false;
				});
				for(int i = 0; i < l3.Count; i++)
				{
					LayoutDecoCustomWindow01.SelectItemData data = new LayoutDecoCustomWindow01.SelectItemData();
					data.series = SeriesAttr.Type.None;
					data.tabCategory = 0;
					data.charaId = 0;
					int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(l3[i].KIJAPOFAGPN_ItemFullId);
					if(id > 0)
					{
						if(category == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
						{
							IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[id - 1];
							data.charaId = dbItem.JBFLEDKDFCO;
							data.tabCategory = dbItem.DMEDKJPOLCH;
							data.series = (SeriesAttr.Type)dbItem.CPKMLLNADLJ;
						}
						else if(category == EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara)
						{
							IHFIAFDLAAK_DecoStamp.MFHKPMPJGHC dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[id - 1];
							data.charaId = dbItem.JBFLEDKDFCO_CharaId;
							data.tabCategory = dbItem.ALAEHBKAEPB;
						}
					}
					data.id = id;
					data.type = category != EKLNMHFCAOI.FKGCBLHOOCL_Category.GGEFMAAOMFH_StampItemChara ? LayoutDecoCustomWindow01.SelectItemType.Serif : LayoutDecoCustomWindow01.SelectItemType.Chara;
					data.text = null;
					data.isShopProduct = true;
					data.charaType = 0;
					data.emotion = 0;
					data.IsNew = false;
					data.product = l3[i];
					res.Add(data);
				}
			}
			return res;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D41B4 Offset: 0x6D41B4 VA: 0x6D41B4
		//// RVA: 0x1588164 Offset: 0x1588164 VA: 0x1588164
		private IEnumerator CharaTexCasheCreate(List<LayoutDecoCustomWindow01.SelectItemData> list)
		{
			//0x158CA1C
			int loadCount = 0;
			foreach(var k in list)
			{
				MenuScene.Instance.DecorationItemTextureCache.LoadForDecoCustom(k.charaId, k.emotion, (IiconTexture image) =>
				{
					//0x158CA08
					loadCount++;
				});
			}
			while (loadCount != list.Count)
				yield return null;
		}

		//// RVA: 0x158A26C Offset: 0x158A26C VA: 0x158A26C
		private int GetStampCharaId(int targetId)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(targetId > 0)
				{
					if(targetId <= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps.Count)
					{
						return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.FHBIIONKIDI_Stamps[targetId - 1].JBFLEDKDFCO_CharaId;
					}
				}
			}
			return 0;
		}

		//// RVA: 0x158BE24 Offset: 0x158BE24 VA: 0x158BE24
		private void NotBackKey()
		{
			return;
		}
		
		//[CompilerGeneratedAttribute] // RVA: 0x6D426C Offset: 0x6D426C VA: 0x6D426C
		//// RVA: 0x158C268 Offset: 0x158C268 VA: 0x158C268
		//private void <RequestBuyOne>b__44_0() { }
	}
}
