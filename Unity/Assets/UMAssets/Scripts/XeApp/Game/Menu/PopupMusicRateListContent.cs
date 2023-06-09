using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;

namespace XeApp.Game.Menu
{
	public class PopupMusicRateListContent : UIBehaviour, IPopupContent
	{
		private PopupMusicRateListContentSetting setup; // 0x10
		private PopupWindowControl control; // 0x14
		private int selectIndex; // 0x18
		private LayoutPopupMusicRateListWindow layout; // 0x1C
		private bool isInitializeLayout; // 0x20

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x16966EC Offset: 0x16966EC VA: 0x16966EC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupMusicRateListContentSetting s = setting as PopupMusicRateListContentSetting;
			this.control = control;
			setup = s;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			bool hasTab = false;
			if(setup.Tabs != null)
			{
				hasTab = setup.Tabs.Length > 0;
			}
			layout.SetStatus(control, setup.View, hasTab);
			layout.ChangeTab(PopupTabButton.ButtonLabel.MusicRateDetail);
			List<ECEPJHGMGBJ> l = setup.View.BGMPAMNAKHN(0);
			for(int i = 0; i < l.Count; i++)
			{
				MusicJacketTextureCache.TryInstall(l[i].JNCPEGJGHOG_JacketId);
			}
		}

		// RVA: 0x1696A44 Offset: 0x1696A44 VA: 0x1696A44 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1696A4C Offset: 0x1696A4C VA: 0x1696A4C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			if(layout.EnableTab)
			{
				control.InputDisable();
				AGLHPOOPOCG.HHCJCDFCLOB.OAGGKCHJBEO(() =>
				{
					//0x1697024
					layout.UpdateListMusicGrade(setup.View);
					control.InputEnable();
				}, () =>
				{
					//0x1697090
					layout.UpdateListMusicGrade(setup.View);
					control.InputEnable();
				}, () =>
				{
					//0x1697178
					MenuScene.Instance.GotoTitle();
				});
			}
			layout.ScrollView.SetlistTop(0);
			layout.ScrollView.SetZeroVelocity();
			layout.ScrollView.VisibleRangeUpdate();
		}

		// RVA: 0x1696D8C Offset: 0x1696D8C VA: 0x1696D8C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			layout.ScrollView.AllFree();
		}

		// RVA: 0x1696E08 Offset: 0x1696E08 VA: 0x1696E08 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && (layout == null || layout.IsListReady());
		}

		// RVA: 0x1696F28 Offset: 0x1696F28 VA: 0x1696F28 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_ShowTutorial());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x706A8C Offset: 0x706A8C VA: 0x706A8C
		//// RVA: 0x1696F4C Offset: 0x1696F4C VA: 0x1696F4C
		private IEnumerator Co_ShowTutorial()
		{
			//0x1697218
			control.InputDisable();
			yield return this.StartCoroutineWatched(TutorialManager.TryShowTutorialCoroutine(CheckGameResultTutorialCondition));
			control.InputEnable();
		}

		//// RVA: 0x1696FF8 Offset: 0x1696FF8 VA: 0x1696FF8
		private bool CheckGameResultTutorialCondition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition52;
		}

		//// RVA: 0x1697008 Offset: 0x1697008 VA: 0x1697008
		//private void CommunicateInfo(PopupMusicRateListContentSetting setup, Action connectionStart, Action OnSuccess) { }
	}
}
