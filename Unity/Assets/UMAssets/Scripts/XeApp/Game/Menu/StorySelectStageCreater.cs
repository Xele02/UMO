using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public class StorySelectStageCreater : MonoBehaviour
	{
		public enum EffectType
		{
			NONE = 0,
			RELEASE = 1,
			UNLOCK = 2,
			APPEAR = 3,
			ADD_DIVA = 4,
			UPDATE = 5,
		}

		private class ItemObject
		{
			public Vector3 pos; // 0x8
			public Vector3 size; // 0x14
			public Action buttonCallback; // 0x20
			public bool isSizeL; // 0x24
			public LIEJFHMGNIA viewStageData; // 0x28
			public StorySelectStageIcon layoutIcon; // 0x2C
			public StorySelectStageTerminationIcon layoutTerminationIcon; // 0x30
			public StorySelectStageCompleteIcon layoutCompleteIcon; // 0x34
			public NewMarkIcon layoutNewIcon; // 0x38
			public bool isEmphasis; // 0x3C
			public bool isNewMark; // 0x3D

			//// RVA: 0x1A94E90 Offset: 0x1A94E90 VA: 0x1A94E90
			private bool IsEffect()
			{
				if(!viewStageData.NDLKPJDHHCN_NotShown)
				{
					if(!viewStageData.DHPNLACAGPG)
					{
						return viewStageData.PGCCOCKGCKO;
					}
				}
				return true;
			}

			//// RVA: 0x1A908EC Offset: 0x1A908EC VA: 0x1A908EC
			public void SetNewMark(LayoutStorySelectController ssController)
			{
				if(!viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					if(!viewStageData.HHBJAEOIGIH_IsLocked)
					{
						if(!viewStageData.MMEGDFPNONJ_HasDivaId)
						{
							if (viewStageData.EOBACDCDGOF_IsTerminate)
								return;
							ssController.AttachNewIcon(layoutIcon.GetNewPos(), true);
						}
					}
				}
			}

			//// RVA: 0x1A89B3C Offset: 0x1A89B3C VA: 0x1A89B3C
			public void SetStatus(LayoutStorySelectController ssController, bool isComplete)
			{
				int a = 0;
				if (viewStageData.EOBACDCDGOF_IsTerminate)
					a = (viewStageData.ENEKMHMKNFK ? 1 : 0) + 15;
				bool b = true;
				if (!viewStageData.EOBACDCDGOF_IsTerminate)
					b = viewStageData.ENEKMHMKNFK;
				float f = pos.x + size.x * 0.5f;
				if(viewStageData.ELIHAGFNOBN_IsStoryEndAndCompleted)
				{
					if (layoutCompleteIcon == null)
						return;
					layoutCompleteIcon.viewStageData = viewStageData;
					layoutCompleteIcon.SetStatus(isComplete);
					layoutCompleteIcon.SetCallback(buttonCallback);
					layoutCompleteIcon.SetPosition(new Vector3(f, pos.y, pos.z));
				}
				if(!viewStageData.ELIHAGFNOBN_IsStoryEndAndCompleted)
				{
					if (b)
					{
						if (layoutTerminationIcon == null)
							return;
						layoutTerminationIcon.viewStageData = viewStageData;
						layoutTerminationIcon.SetStatus();
						layoutTerminationIcon.SetCallback(buttonCallback);
						layoutTerminationIcon.SetPosition(new Vector3(f, pos.y, pos.z));
					}
					if((a & 15) == 0)
					{
						if(layoutIcon != null)
						{
							layoutIcon.viewStageData = viewStageData;
							layoutIcon.SetStatus();
							layoutIcon.SetCallback(buttonCallback);
							layoutIcon.SetPosition(new Vector3(f, pos.y, pos.z));
							if (!IsEffect())
							{
								if(!viewStageData.BCGLDMKODLC_StatusCompleted)
								{
									if (isEmphasis)
									{
										layoutIcon.ButtonEmphasis();
									}
									if(isNewMark)
									{
										SetNewMark(ssController);
									}
								}
							}
						}
					}
				}
			}

			//// RVA: 0x1A89FB4 Offset: 0x1A89FB4 VA: 0x1A89FB4
			public void Show()
			{
				if (layoutCompleteIcon != null)
					layoutCompleteIcon.Show();
				if (layoutTerminationIcon != null)
					layoutTerminationIcon.Show();
				if (layoutIcon != null)
					layoutIcon.Show();
			}

			//// RVA: 0x1A8688C Offset: 0x1A8688C VA: 0x1A8688C
			public void Hide()
			{
				if (layoutCompleteIcon != null)
					layoutCompleteIcon.Hide(true);
				if (layoutTerminationIcon != null)
					layoutTerminationIcon.Hide(true);
				if (layoutIcon != null)
					layoutIcon.Hide(true);
			}

			//// RVA: 0x1A94F00 Offset: 0x1A94F00 VA: 0x1A94F00
			//public void Clear() { }
		}

		private const int FOCUS_TIME = 10;
		private const int SCROLL_NEAR = 3;
		private const int ICON_TOP_POS = -300;
		private const int ICON_UNDER_POS = -450;
		private const int LEFT_SPACE = 370;
		private const int ICON_SPACE = 450;
		private const int MAP_TEXTURE_MAX_NUM = 9;
		private const int ICON_MAX_NUM = 36;
		private const float ARROW_MARGIN = 15;
		private const float WAIT_EFFECT_START = 1;
		private readonly Vector3 LAYOUT_SIZE = new Vector3(230, 230, 0); // 0x14
		private readonly Vector3 LAYOUT_SIZE_L = new Vector3(230, 230, 0); // 0x20
		private List<LIEJFHMGNIA> m_viewDataList; // 0x2C
		private float m_mapSize = 1184; // 0x30
		private float m_mapRatio = 0.5f; // 0x34
		private EffectType m_nowEffectType; // 0x38
		private int m_stageEffectIndex = -1; // 0x3C
		private bool m_isShowAll = true; // 0x4E
		private Vector2 m_bgScrollPosition = Vector2.zero; // 0x50
		private Action CallbackEffectPhaseEnd; // 0x58
		private List<StorySelectStageIcon> m_freeIconList = new List<StorySelectStageIcon>(32); // 0x5C
		private List<StorySelectStageIcon> m_freeIconLList = new List<StorySelectStageIcon>(32); // 0x60
		private StorySelectStageTerminationIcon m_freeTerminationIcon; // 0x64
		private StorySelectStageCompleteIcon m_freeCompleteIcon; // 0x68
		private NewMarkIcon m_freeNewMarkIcon; // 0x6C
		private RectTransform m_scrollIconRectRt; // 0x70
		private RectTransform m_scrollRectContentRt; // 0x74
		private float m_scrollPosRightX; // 0x78
		public Action PushIconListener; // 0x80
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x84
		private const float BGM_FADEOUT_TIME = 0.3f;
		private List<ItemObject> m_scrollViewList = new List<ItemObject>(64); // 0x88

		public LayoutStorySelectController storySelectController { get; set; } // 0xC
		public int page { get; set; } // 0x10
		public bool IsPlayingEffect { get; private set; } // 0x40
		public Action CallbackEffectEnd { get; set; } // 0x44
		public Action CallbackEffectOneStart { get; set; } // 0x48
		public bool IsEffectStart { get; private set; } // 0x4C
		public bool IsSetup { get; private set; } // 0x4D
		public bool IsBeginnerMissionTargetMusicClear { get; set; } // 0x7C

		//// RVA: 0x1A812A4 Offset: 0x1A812A4 VA: 0x1A812A4
		public static StorySelectStageCreater Create(Transform parent)
		{
			GameObject g = new GameObject("StorySelectStageCreater");
			g.transform.SetParent(parent, false);
			g.transform.SetAsFirstSibling();
			return g.AddComponent<StorySelectStageCreater>();
		}

		//// RVA: 0x1A8143C Offset: 0x1A8143C VA: 0x1A8143C
		public List<LIEJFHMGNIA> GetViewDataStageList()
		{
			return m_viewDataList;
		}

		//// RVA: 0x1A8166C Offset: 0x1A8166C VA: 0x1A8166C
		private bool IsComplete()
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete;
		}

		//// RVA: 0x1A81740 Offset: 0x1A81740 VA: 0x1A81740
		private StorySelectStageIcon FreeIconObject(bool isSizeL)
		{
			if(isSizeL)
			{
				if (m_freeIconLList.Count < 1)
					return null;
				StorySelectStageIcon res = m_freeIconLList[0];
				m_freeIconLList.RemoveAt(0);
				return res;
			}
			else
			{
				if (m_freeIconList.Count < 1)
					return null;
				StorySelectStageIcon res = m_freeIconList[0];
				m_freeIconList.RemoveAt(0);
				return res;
			}
		}

		//// RVA: 0x1A818C8 Offset: 0x1A818C8 VA: 0x1A818C8
		private StorySelectStageTerminationIcon FreeTerminationObject()
		{
			if (m_freeTerminationIcon == null)
				return null;
			StorySelectStageTerminationIcon res = m_freeTerminationIcon;
			m_freeTerminationIcon = null;
			return res;
		}

		//// RVA: 0x1A8196C Offset: 0x1A8196C VA: 0x1A8196C
		private StorySelectStageCompleteIcon FreeCompleteObject()
		{
			if(m_freeCompleteIcon != null)
			{
				StorySelectStageCompleteIcon res = m_freeCompleteIcon;
				m_freeCompleteIcon = null;
				return res;
			}
			return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B964 Offset: 0x72B964 VA: 0x72B964
		//// RVA: 0x1A81A10 Offset: 0x1A81A10 VA: 0x1A81A10
		public IEnumerator Setup()
		{
			//0x1A90FA8
			if(m_freeIconList.Count <= 0 || m_freeIconLList.Count <= 0)
			{
				for(int i = 0; i < storySelectController.layoutIcon.Count; i++)
				{
					m_freeIconList.Add(storySelectController.layoutIcon[i]);
					storySelectController.layoutIcon[i].gameObject.SetActive(false);
				}
				for (int i = 0; i < storySelectController.layoutIconL.Count; i++)
				{
					m_freeIconLList.Add(storySelectController.layoutIconL[i]);
					storySelectController.layoutIconL[i].gameObject.SetActive(false);
				}
			}
			//LAB_01a912b0
			if (m_freeTerminationIcon == null)
				m_freeTerminationIcon = storySelectController.layoutTerminationIcon;
			if (m_freeNewMarkIcon == null)
				m_freeNewMarkIcon = storySelectController.layoutNewIconMark;
			if (m_freeCompleteIcon == null)
				m_freeCompleteIcon = storySelectController.layoutCompleteIcon;
			SetupIconScroll();
			yield return null;
			SetupScrollPosition();
			SetupIcon();
			IsSetup = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72B9DC Offset: 0x72B9DC VA: 0x72B9DC
		//// RVA: 0x1A81ABC Offset: 0x1A81ABC VA: 0x1A81ABC
		public IEnumerator Check()
		{
			//0x1A8B370
			if((m_viewDataList[m_stageEffectIndex].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
			{
				int i = m_stageEffectIndex + 1;
				if (m_viewDataList.Count <= i)
					i = m_stageEffectIndex;
				int i2 = m_stageEffectIndex + 2;
				if (m_viewDataList.Count <= i2)
					i2 = m_stageEffectIndex;
				if(m_stageEffectIndex != i2)
				{
					if ((m_viewDataList[i2].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
						yield break;
				}
				m_scrollViewList[m_stageEffectIndex].layoutIcon.SetStatus();
				m_viewDataList[i].KHEKNNFCAOI(m_viewDataList[i].LFLLLOPAKCO_StoryId);
				ReplaceIcon(i);
			}
		}

		//// RVA: 0x1A81B68 Offset: 0x1A81B68 VA: 0x1A81B68
		private void Update()
		{
			UpdateScrollPosition();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BA54 Offset: 0x72BA54 VA: 0x72BA54
		//// RVA: 0x1A81FA0 Offset: 0x1A81FA0 VA: 0x1A81FA0
		private IEnumerator UpdateAddDivaEffect(int index, Action callback)
		{
			int prevIndex;

			//0x1A93D24
			prevIndex = index - 1;
			bool isCutinWait = true;
			List<int> l = new List<int>();
			l.Add(m_scrollViewList[index].viewStageData.AHHJLDLAPAN_DivaId);
			this.StartCoroutineWatched(CutinJoinDiva.Show(l, transform.parent.parent, () =>
			{
				//0x1A8A988
				isCutinWait = false;
			}));
			while(isCutinWait)
				yield return null;
			if(m_scrollViewList[prevIndex].layoutIcon != null)
			{
				m_scrollViewList[prevIndex].layoutIcon.ShrinkingIn();
				while(m_scrollViewList[prevIndex].layoutIcon.IsPlaying())
					yield return null;
				SwapStageIcon(index, prevIndex);
				m_scrollViewList[index].layoutIcon.LockAppearIn();
				while(m_scrollViewList[index].layoutIcon.IsPlaying())
					yield return null;
				m_scrollViewList[index].layoutIcon.SetButtonEnable(true);
				m_scrollViewList[prevIndex].layoutIcon.AppearIn();
				while(m_scrollViewList[prevIndex].layoutIcon.IsPlaying())
					yield return null;
			}
			else
			{
				if(m_scrollViewList[prevIndex].layoutTerminationIcon != null)
				{
					m_scrollViewList[prevIndex].layoutTerminationIcon.ShrinkingIn();
					while(m_scrollViewList[prevIndex].layoutTerminationIcon.IsPlaying())
						yield return null;
					SwapStageIcon(index, prevIndex);
					m_scrollViewList[prevIndex].layoutIcon.NoneIcon();
					m_scrollViewList[index].layoutTerminationIcon.LockAppearIn();
					while(m_scrollViewList[index].layoutTerminationIcon.IsPlaying())
						yield return null;
					m_scrollViewList[index].layoutTerminationIcon.SetButtonEnable(true);
					m_scrollViewList[prevIndex].layoutIcon.AppearIn();
					while(m_scrollViewList[prevIndex].layoutIcon.IsPlaying())
						yield return null;
				}
			}
			bool isWait = true;
			MenuScene.Instance.InputEnable();
			this.StartCoroutineWatched(ShowInfo(m_viewDataList[prevIndex], () =>
			{
				//0x1A8A994
				isWait = false;
			}));
			while(isWait)
				yield return null;
			MenuScene.Instance.InputDisable();
			if(callback != null)
				callback();
		}

		//// RVA: 0x1A82080 Offset: 0x1A82080 VA: 0x1A82080
		private void SetStageIcon(int index)
		{
			int no = index;
			m_scrollViewList[index].buttonCallback = () =>
			{
				//0x1A8A9A0
				OnClickIcon(no);
			};
			if(m_scrollViewList[index].layoutIcon != null)
			{
				m_scrollViewList[index].layoutIcon.viewStageData = m_scrollViewList[index].viewStageData;
				m_scrollViewList[index].layoutIcon.SetStatus();
				m_scrollViewList[index].layoutIcon.SetCallback(m_scrollViewList[index].buttonCallback);
			}
			else
			{
				if(m_scrollViewList[index].layoutTerminationIcon != null)
				{
					m_scrollViewList[index].layoutTerminationIcon.viewStageData = m_scrollViewList[index].viewStageData;
					m_scrollViewList[index].layoutTerminationIcon.SetStatus();
					m_scrollViewList[index].layoutTerminationIcon.SetCallback(m_scrollViewList[index].buttonCallback);
				}
			}
		}

		//// RVA: 0x1A8294C Offset: 0x1A8294C VA: 0x1A8294C
		private void SetPosStageIcon(int index)
		{
			m_scrollViewList[index].pos.x = index * 450 + 370;
			m_scrollViewList[index].pos.x += m_scrollViewList[index].size.x * -0.5f;
			m_scrollViewList[index].pos.y = (index & 1) == 0 ? -300 : -450;
			Vector3 pos = m_scrollViewList[index].pos;
			pos.x += m_scrollViewList[index].size.x * 0.5f;
			if(m_scrollViewList[index].layoutIcon != null)
			{
				m_scrollViewList[index].layoutIcon.SetPosition(pos);
			}
			if(m_scrollViewList[index].layoutTerminationIcon != null)
			{
				m_scrollViewList[index].layoutTerminationIcon.SetPosition(pos);
			}
		}

		//// RVA: 0x1A82F74 Offset: 0x1A82F74 VA: 0x1A82F74
		private void SwapStageList(List<ItemObject> list)
		{
			ItemObject tmp = list[list.Count - 1];
			list[list.Count - 1] = list[list.Count - 2];
			list[list.Count - 2] = tmp;
		}

		//// RVA: 0x1A8312C Offset: 0x1A8312C VA: 0x1A8312C
		private void SwapStageIcon(int index, int prevIndex)
		{
			LIEJFHMGNIA.PMBEMMPPNMN(m_viewDataList);
			SwapStageList(m_scrollViewList);
			if(m_scrollViewList[m_scrollViewList.Count - 1].layoutIcon != null)
			{
				m_scrollViewList[m_scrollViewList.Count - 1].layoutIcon.Hide(true);
				ReleaseObject(m_scrollViewList[m_scrollViewList.Count - 1]);
				m_scrollViewList[m_scrollViewList.Count - 1].layoutIcon = FreeIconObject(false);
			}
			else
			{
				if(m_scrollViewList[m_scrollViewList.Count - 1].layoutTerminationIcon != null)
				{
					m_scrollViewList[m_scrollViewList.Count - 1].layoutTerminationIcon.Hide(true);
					ReleaseObject(m_scrollViewList[m_scrollViewList.Count - 1]);
					m_scrollViewList[m_scrollViewList.Count - 1].layoutTerminationIcon = FreeTerminationObject();
				}	
			}
			m_scrollViewList[m_scrollViewList.Count - 1].isSizeL = false;
			m_scrollViewList[m_scrollViewList.Count - 1].size = LAYOUT_SIZE;
			m_scrollViewList[m_scrollViewList.Count - 2].isSizeL = true;
			m_scrollViewList[m_scrollViewList.Count - 2].size = LAYOUT_SIZE_L;
			for(int i = 0; i < m_viewDataList.Count; i++)
			{
				m_scrollViewList[i].viewStageData = m_viewDataList[i];
			}
			SetStageIcon(index);
			SetStageIcon(prevIndex);
			SetPosStageIcon(index);
			SetPosStageIcon(prevIndex);
			if(m_scrollViewList[index].layoutIcon != null)
			{
				m_scrollViewList[index].layoutIcon.LockIcon();
				m_scrollViewList[prevIndex].layoutIcon.NoneIcon();
			}
			m_stageEffectIndex = m_stageEffectIndex - 2;
		}

		//// RVA: 0x1A83FE0 Offset: 0x1A83FE0 VA: 0x1A83FE0
		private float CalcFocusPositionX(int index)
		{
			return index * 450 + m_scrollIconRectRt.sizeDelta.x * -0.5f + 370;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BACC Offset: 0x72BACC VA: 0x72BACC
		//// RVA: 0x1A8404C Offset: 0x1A8404C VA: 0x1A8404C
		private IEnumerator Focus(EffectType effectType, int index)
		{
			int tempIndex; // 0x1C
			float x; // 0x20
			ScrollRect stageScroll; // 0x24
			Vector3 pos; // 0x28
			bool isMove; // 0x34

			//0x1A8C430
			tempIndex = index;
			if (effectType == EffectType.ADD_DIVA)
				tempIndex = index - 1;
			yield return new WaitForSeconds(1);
			x = -Mathf.Max(CalcFocusPositionX(tempIndex), 0);
			stageScroll = storySelectController.layoutIconScroll;
			isMove = true;
			pos = Vector3.zero;
			do
			{
				pos.x = (x - stageScroll.content.localPosition.x) / 10.0f + stageScroll.content.localPosition.x;
				stageScroll.content.localPosition = pos;
				if(Mathf.Abs(x - stageScroll.content.localPosition.x) < 3)
				{
					pos.x = x;
					stageScroll.content.localPosition = pos;
					isMove = false;
				}
				UpdateScrollInner();
				yield return null;
			} while (isMove);
		}

		//// RVA: 0x1A8412C Offset: 0x1A8412C VA: 0x1A8412C
		private Coroutine EffectPhaseStart(EffectType effectType, int index)
		{
			if (effectType == EffectType.ADD_DIVA)
			{
				StorySelectStageIcon layout = m_scrollViewList[index].layoutIcon;
				CallbackEffectPhaseEnd = () =>
				{
					//0x1A8A9D0
					layout.SetButtonEnable(true);
				};
				return this.StartCoroutineWatched(UpdateAddDivaEffect(index, null));
			}
			else
			{
				LIEJFHMGNIA viewStageData = m_viewDataList[index];
				StorySelectStageIcon layout = m_scrollViewList[index].layoutIcon;
				StorySelectStageTerminationIcon layoutTermination = m_scrollViewList[index].layoutTerminationIcon;
				if (!viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					CallbackEffectPhaseEnd = () =>
					{
						//0x1A8AAB8
						if (viewStageData.EOBACDCDGOF_IsTerminate)
						{
							layoutTermination.SetButtonEnable(true);
							return;
						}
						if (viewStageData.MMEGDFPNONJ_HasDivaId)
						{
							if (!viewStageData.MMEGDFPNONJ_HasDivaId)
								return;
							if (!viewStageData.HHBJAEOIGIH_IsLocked)
								return;
						}
						layout.SetButtonEnable(true);
					};
				}
				return StartEffectPhase(effectType, index);
			}
		}

		//// RVA: 0x1A81B6C Offset: 0x1A81B6C VA: 0x1A81B6C
		private void UpdateScrollPosition()
		{
			if(storySelectController != null && storySelectController.IsLoadlayout)
			{
				m_bgScrollPosition.x = storySelectController.layoutIconScroll.content.anchoredPosition.x * m_mapRatio;
				storySelectController.layoutBgScroll.content.anchoredPosition = m_bgScrollPosition;
				if(!IsPlayingEffect)
				{
					if (storySelectController.layoutBgButton != null && storySelectController.layoutBgButton.IsShowBg)
						return;
					if(m_isShowAll)
					{
						UpdateScrollInner();
						float f = storySelectController.layoutIconScroll.content.transform.localPosition.x;
						if (Mathf.Abs(f) < 15)
							storySelectController.layoutArrowLeft.Hide();
						else
							storySelectController.layoutArrowLeft.Show();
						if(m_scrollPosRightX - 15 <= Mathf.Abs(f))
							storySelectController.layoutArrowRight.Hide();
						else
							storySelectController.layoutArrowRight.Show();
					}
				}
			}
		}

		//// RVA: 0x1A84D6C Offset: 0x1A84D6C VA: 0x1A84D6C
		public void Initialize()
		{
			m_viewDataList = LIEJFHMGNIA.FKDIMODKKJD(page, true, true, true);
			LIEJFHMGNIA.DJMAJKMBJNE(m_viewDataList);
			LIEJFHMGNIA.OCHGOAKIPPM(m_viewDataList);
		}

		//// RVA: 0x1A84E24 Offset: 0x1A84E24 VA: 0x1A84E24
		private RectTransform GetRectTransformRoot()
		{
			if(MenuScene.Instance != null)
			{
				if(MenuScene.Instance.GetCurrentTransitionRoot() != null)
				{
					if(MenuScene.Instance.GetCurrentTransitionRoot().transform.parent != null)
					{
						return MenuScene.Instance.GetCurrentTransitionRoot().transform.parent.GetComponent<RectTransform>();
					}
				}
			}
			return null;
		}

		//// RVA: 0x1A85134 Offset: 0x1A85134 VA: 0x1A85134
		public void SetupIconScroll()
		{
			m_scrollRectContentRt = storySelectController.layoutIconScroll.content.GetComponent<RectTransform>();
			m_scrollIconRectRt = storySelectController.layoutIconScroll.GetComponent<RectTransform>();
			m_scrollIconRectRt.sizeDelta = new Vector2(GetRectTransformRoot().sizeDelta.x + 4, m_scrollIconRectRt.sizeDelta.y);
			float f = GetRectTransformRoot().sizeDelta.x * 0.5f + m_viewDataList.Count * 450 - 80;
			storySelectController.layoutIconScroll.content.GetComponent<RectTransform>().sizeDelta = new Vector2(f, storySelectController.layoutIconScroll.content.GetComponent<RectTransform>().sizeDelta.y);
			m_scrollPosRightX = f - m_scrollIconRectRt.sizeDelta.x;
			m_mapRatio = (m_mapSize * 8.0f) / ((m_mapSize * 0.5f + 16200 - 450 + 370) - m_mapSize);
		}

		//// RVA: 0x1A85454 Offset: 0x1A85454 VA: 0x1A85454
		private void SetupScrollPosition()
		{
			int a = 0;
			EffectType eff = EffectType.NONE;
			for (int i = 0; i < m_viewDataList.Count; i++)
			{
				a = i;
				if (IsEffectIcon(m_viewDataList[i], out eff))
				{
					if(m_viewDataList[i].NDLKPJDHHCN_NotShown)
					{
						a = i - 1;
						if (a < 1)
							a = 0;
					}
					break;
				}
			}
			//LAB_01a85590
			int c = a;
			if(eff == EffectType.NONE && a - 1 > -1)
			{
				if((m_viewDataList[a - 1].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
				{
					c = a - 1;
					if (m_viewDataList[a - 1].BCGLDMKODLC_StatusCompleted)
						c = a;
				}
			}
			float f = CalcFocusPositionX(c);
			storySelectController.layoutIconScroll.content.GetComponent<RectTransform>().anchoredPosition = new Vector2(-f, storySelectController.layoutIconScroll.content.GetComponent<RectTransform>().anchoredPosition.y);
		}

		//// RVA: 0x1A8589C Offset: 0x1A8589C VA: 0x1A8589C
		private void SetupIcon()
		{
			Vector3 v = new Vector3(370, -300, 0);
			m_scrollViewList.Clear();
			bool b = false;
			EffectType eff = EffectType.NONE;
			for(int i = 0; i < m_viewDataList.Count; i++)
			{
				ItemObject obj = new ItemObject();
				m_scrollViewList.Add(obj);
				int no = i;
				m_scrollViewList[i].buttonCallback = () =>
				{
					//0x1A8AC64
					OnClickIcon(no);
				};
				m_scrollViewList[i].viewStageData = m_viewDataList[i];
				v.y = (i & 1) == 0 ? -300 : -450;
				m_scrollViewList[i].isSizeL = false;
				m_scrollViewList[i].size = LAYOUT_SIZE;
				if (m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
				{
					if(!b)
					{
						m_scrollViewList[i].size = LAYOUT_SIZE_L;
						m_scrollViewList[i].isSizeL = true;
					}
				}
				if(!m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
				{
					if(!m_viewDataList[i].HHBJAEOIGIH_IsLocked)
					{
						if(!m_viewDataList[i].BCGLDMKODLC_StatusCompleted)
						{
							m_scrollViewList[i].size = LAYOUT_SIZE_L;
							m_scrollViewList[i].isSizeL = true;
						}
					}
				}
				b = false;
				if((m_viewDataList[i].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
				{
					b = !m_viewDataList[i].BCGLDMKODLC_StatusCompleted;
				}
				m_scrollViewList[i].pos = v;
				m_scrollViewList[i].pos.x += m_scrollViewList[i].size.x * -0.5f;
				v.x += 450;
				IsEffectIcon(m_viewDataList[i], out eff);
			}
			UpdateScrollInner();
			for(int i = 0; i < m_scrollViewList.Count; i++)
			{
				if(!m_scrollViewList[i].viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					if (!m_scrollViewList[i].viewStageData.EOBACDCDGOF_IsTerminate)
					{
						m_scrollViewList[i].isEmphasis = true;
						if (eff == EffectType.NONE)
						{
							if (m_scrollViewList[i].layoutIcon != null)
								m_scrollViewList[i].layoutIcon.ButtonEmphasis();
						}
						if (m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
							return;
						if (m_viewDataList[i].HHBJAEOIGIH_IsLocked)
							return;
						m_scrollViewList[i].isNewMark = true;
						if (eff != EffectType.NONE)
							return;
						if (m_scrollViewList[i].layoutIcon != null)
						{
							m_scrollViewList[i].layoutNewIcon = m_freeNewMarkIcon;
							m_freeNewMarkIcon = null;
							storySelectController.AttachNewIcon(m_scrollViewList[i].layoutIcon.GetNewPos(), true);
							return;
						}
					}
				}
			}
		}

		//// RVA: 0x1A86418 Offset: 0x1A86418 VA: 0x1A86418
		private void ReplaceIcon(int index)
		{
			Vector3 v = new Vector3(index * 450 + 370, -300, 0);
			m_scrollViewList[index].Hide();
			ReleaseObject(m_scrollViewList[index]);
			v.y = (index & 1) == 0 ? -300 : -450;
			m_scrollViewList[index].isSizeL = false;
			m_scrollViewList[index].size = LAYOUT_SIZE;
			if(m_viewDataList[index].MMEGDFPNONJ_HasDivaId)
			{
				m_scrollViewList[index].isSizeL = true;
				m_scrollViewList[index].size = LAYOUT_SIZE_L;
			}
			if (!m_viewDataList[index].MMEGDFPNONJ_HasDivaId)
			{
				if(!m_viewDataList[index].HHBJAEOIGIH_IsLocked)
				{
					if(!m_viewDataList[index].BCGLDMKODLC_StatusCompleted)
					{
						m_scrollViewList[index].isSizeL = true;
						m_scrollViewList[index].size = LAYOUT_SIZE_L;
					}
				}
			}
			m_scrollViewList[index].pos = v;
			m_scrollViewList[index].pos.x += m_scrollViewList[index].size.x * -0.5f;
			v.x += 450;
			EffectType eff;
			IsEffectIcon(m_viewDataList[index], out eff);
			UpdateScrollInner();
			if(!m_scrollViewList[index].viewStageData.BCGLDMKODLC_StatusCompleted)
			{
				if (!m_scrollViewList[index].viewStageData.EOBACDCDGOF_IsTerminate)
				{
					m_scrollViewList[index].isEmphasis = true;
					if(eff == EffectType.NONE)
					{
						if (m_scrollViewList[index].layoutIcon != null)
							m_scrollViewList[index].layoutIcon.ButtonEmphasis();
					}
					if(!m_viewDataList[index].MMEGDFPNONJ_HasDivaId)
					{
						if(!m_viewDataList[index].HHBJAEOIGIH_IsLocked)
						{
							m_scrollViewList[index].isNewMark = true;
							if(eff == EffectType.NONE)
							{
								if (m_scrollViewList[index].layoutIcon != null)
								{
									m_scrollViewList[index].layoutNewIcon = m_freeNewMarkIcon;
									m_freeNewMarkIcon = null;
									storySelectController.AttachNewIcon(m_scrollViewList[index].layoutIcon.GetNewPos(), true);
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0x1A86A14 Offset: 0x1A86A14 VA: 0x1A86A14
		private void InterruptIcon()
		{
			Vector3 v = new Vector3(m_scrollViewList.Count * 450 + 370, -300, 0);
			EffectType effect = EffectType.NONE;
			bool b2 = false;
			int start = m_scrollViewList.Count;
			for (int i = start; i < m_viewDataList.Count; i++)
			{
				ItemObject item = new ItemObject();
				m_scrollViewList.Add(item);
				int no = i;
				m_scrollViewList[i].buttonCallback = () =>
				{
					//0x1A8AC94
					OnClickIcon(no);
				};
				item.viewStageData = m_viewDataList[i];
				v.y = ((i & 1) == 0) ? -300 : -450;
				item.isSizeL = false;
				Vector3 s = LAYOUT_SIZE;
				if(m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
				{
					item.isSizeL = true;
					if (!b2)
						s = LAYOUT_SIZE_L;
					else
					{
						item.isSizeL = false;
						s = LAYOUT_SIZE;
					}
				}
				if(!m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
				{
					if(!m_viewDataList[i].HHBJAEOIGIH_IsLocked)
					{
						if(!m_viewDataList[i].BCGLDMKODLC_StatusCompleted)
						{
							item.isSizeL = true;
							s = LAYOUT_SIZE_L;
						}
					}
				}
				b2 = false;
				if((m_viewDataList[i].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
				{
					b2 = !m_viewDataList[i].BCGLDMKODLC_StatusCompleted;
				}
				item.size = s;
				item.pos = v;
				item.pos.x += s.x * -0.5f;
				v.x += 450;
				IsEffectIcon(m_viewDataList[i], out effect);
			}
			for(int i = start; i < m_scrollViewList.Count; i++)
			{
				if(!m_scrollViewList[i].viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					if(!m_scrollViewList[i].viewStageData.EOBACDCDGOF_IsTerminate)
					{
						m_scrollViewList[i].isEmphasis = true;
						if (effect == EffectType.NONE)
						{
							if(m_scrollViewList[i].layoutIcon != null)
							{
								m_scrollViewList[i].layoutIcon.ButtonEmphasis();
							}
						}
						if (m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
							return;
						if (m_viewDataList[i].HHBJAEOIGIH_IsLocked)
							return;
						m_scrollViewList[i].isNewMark = true;
						if (effect != EffectType.NONE)
							return;
						if (m_scrollViewList[i].layoutIcon != null)
						{
							m_scrollViewList[i].layoutNewIcon = m_freeNewMarkIcon;
							m_freeNewMarkIcon = null;
							storySelectController.AttachNewIcon(m_scrollViewList[i].layoutIcon.GetNewPos(), true);
						}
					}
				}
			}
		}

		//// RVA: 0x1A85758 Offset: 0x1A85758 VA: 0x1A85758
		private bool IsEffectIcon(LIEJFHMGNIA data, out EffectType effectType)
		{
			effectType = EffectType.NONE;
			if (!data.CGDIFBMIJJH_AddDiva)
			{
				if (!data.NDLKPJDHHCN_NotShown)
				{
					if (!data.DHPNLACAGPG)
					{
						if (data.PGCCOCKGCKO)
							return true;
						if (data.ENEKMHMKNFK)
						{
							if (effectType != EffectType.NONE)
								return true;
							effectType = EffectType.RELEASE;
							data.NDLKPJDHHCN_NotShown = true;
							data.DHPNLACAGPG = true;
							return true;
						}
						if (data.PCFICCCLBNP_IsLastStoryAndCompleted)
						{
							return !IsComplete();
						}
						return false;
					}
					effectType = EffectType.UNLOCK;
				}
				else
				{
					if (data.DHPNLACAGPG)
					{
						effectType = EffectType.RELEASE;
						return true;
					}
					effectType = EffectType.APPEAR;
				}
			}
			else
				effectType = EffectType.ADD_DIVA;
			return true;
		}

		//// RVA: 0x1A85844 Offset: 0x1A85844 VA: 0x1A85844
		//private bool IsFocus(LIEJFHMGNIA data) { }

		//// RVA: 0x1A87568 Offset: 0x1A87568 VA: 0x1A87568
		private void ViewDone(LIEJFHMGNIA data)
		{
			if (data.CGDIFBMIJJH_AddDiva)
				return;
			bool b = data.DHPNLACAGPG;
			if (data.NDLKPJDHHCN_NotShown)
				data.CPIPDGGOLFO();
			if (b)
				data.JLHOLHCDELP();
		}

		//// RVA: 0x1A85868 Offset: 0x1A85868 VA: 0x1A85868
		//private bool IsInterruptDiva(LIEJFHMGNIA data) { }

		//// RVA: 0x1A875C8 Offset: 0x1A875C8 VA: 0x1A875C8
		//public bool IsInterruptDivaEffect() { }

		//// RVA: 0x1A87704 Offset: 0x1A87704 VA: 0x1A87704
		public void In(TransitionList.Type prevTransitionType = TransitionList.Type.UNDEFINED)
		{
			if (prevTransitionType == TransitionList.Type.UNLOCK_DIVA)
				this.StartCoroutineWatched(UnlockDivaPhase());
			else
				this.StartCoroutineWatched(NormalPhase());
		}

		//// RVA: 0x1A87850 Offset: 0x1A87850 VA: 0x1A87850
		//public void Out() { }

		//// RVA: 0x1A87854 Offset: 0x1A87854 VA: 0x1A87854
		public void HideAll()
		{
			m_isShowAll = false;
			for(int i = 0; i < m_scrollViewList.Count; i++)
			{
				if (m_scrollViewList[i].layoutIcon != null)
					m_scrollViewList[i].layoutIcon.Hide(false);
				if (m_scrollViewList[i].layoutTerminationIcon != null)
					m_scrollViewList[i].layoutTerminationIcon.Hide(false);
				if (m_scrollViewList[i].layoutCompleteIcon != null)
					m_scrollViewList[i].layoutCompleteIcon.Hide(false);
			}
			storySelectController.layoutArrowLeft.Hide();
			storySelectController.layoutArrowRight.Hide();
		}

		//// RVA: 0x1A87C70 Offset: 0x1A87C70 VA: 0x1A87C70
		public void ShowAll()
		{
			m_isShowAll = true;
			for(int i = 0; i < m_scrollViewList.Count; i++)
			{
				if (m_scrollViewList[i].layoutIcon != null)
					m_scrollViewList[i].layoutIcon.Show();
				if (m_scrollViewList[i].layoutTerminationIcon != null)
					m_scrollViewList[i].layoutTerminationIcon.Show();
				if (m_scrollViewList[i].layoutCompleteIcon != null)
					m_scrollViewList[i].layoutCompleteIcon.Show();
			}
			UpdateScrollPosition();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BB44 Offset: 0x72BB44 VA: 0x72BB44
		//// RVA: 0x1A8807C Offset: 0x1A8807C VA: 0x1A8807C
		private IEnumerator ProcStage()
		{
			Coroutine effectPhase;

			//0x1A90014
			m_stageEffectIndex++;
			m_nowEffectType = EffectType.NONE;
			while(m_stageEffectIndex < m_viewDataList.Count)
			{
				if (LIEJFHMGNIA.FDEGGJPAOHM(m_viewDataList) || LIEJFHMGNIA.PHNNCGBNCGO(m_viewDataList))
					InterruptIcon();
				if(IsEffectIcon(m_viewDataList[m_stageEffectIndex], out m_nowEffectType))
				{
					IsPlayingEffect = true;
					if(CallbackEffectOneStart != null && !IsEffectStart)
					{
						CallbackEffectOneStart();
					}
					IsEffectStart = true;
					yield return Co.R(Focus(m_nowEffectType, m_stageEffectIndex));
					effectPhase = EffectPhaseStart(m_nowEffectType, m_stageEffectIndex);
					while (m_viewDataList[m_stageEffectIndex].ENEKMHMKNFK)
						yield return null;
					ViewDone(m_viewDataList[m_stageEffectIndex]);
					yield return effectPhase;
					m_stageEffectIndex++;
					yield return null;
					effectPhase = null;
				}
				else
				{
					m_stageEffectIndex++;
				}
			}
			if(IsEffectStart)
			{
				yield return Co.R(Co_Save());
			}
			//LAB_01a9027c
			for(int i = 0; i < m_scrollViewList.Count; i++)
			{
				if(m_scrollViewList[i].layoutIcon != null)
				{
					m_scrollViewList[i].layoutIcon.SetButtonEnable(true);
				}
			}
			if (CallbackEffectEnd != null)
				CallbackEffectEnd();
			IsPlayingEffect = false;
			m_stageEffectIndex = -1;
			IsEffectStart = false;
			for(int i = 0; i < m_scrollViewList.Count; i++)
			{
				if (m_freeNewMarkIcon == null)
					yield break;
				if(!m_scrollViewList[i].viewStageData.BCGLDMKODLC_StatusCompleted)
				{
					if(m_scrollViewList[i].layoutIcon != null)
					{
						if(!m_scrollViewList[i].viewStageData.MMEGDFPNONJ_HasDivaId)
						{
							m_scrollViewList[i].isNewMark = true;
							m_scrollViewList[i].layoutNewIcon = m_freeNewMarkIcon;
							m_freeNewMarkIcon = null;
							m_scrollViewList[i].SetNewMark(storySelectController);
						}
						m_scrollViewList[i].isEmphasis = true;
						m_scrollViewList[i].layoutIcon.ButtonEmphasis();
						yield break;
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BBBC Offset: 0x72BBBC VA: 0x72BBBC
		//// RVA: 0x1A877C4 Offset: 0x1A877C4 VA: 0x1A877C4
		private IEnumerator NormalPhase()
		{
			//0x1A8C8D8
			yield return Co.R(PopupUnlock.Show(PopupUnlock.eSceneType.StorySelect, null, false, ReceiveUnlockPopup));
			yield return Co.R(ProcStage());
		}

		//// RVA: 0x1A88148 Offset: 0x1A88148 VA: 0x1A88148
		private void ReceiveUnlockPopup(PopupUnlock popup)
		{
			IsBeginnerMissionTargetMusicClear = popup.IsClearStoryMusic(4);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BC34 Offset: 0x72BC34 VA: 0x72BC34
		//// RVA: 0x1A87738 Offset: 0x1A87738 VA: 0x1A87738
		private IEnumerator UnlockDivaPhase()
		{
			//0x1A93BA0
			IsEffectStart = false;
			yield return Co.R(ShowTutorial());
			yield return Co.R(ShowHomeBgPopup());
			yield return Co.R(ProcStage());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BCAC Offset: 0x72BCAC VA: 0x72BCAC
		//// RVA: 0x1A881A0 Offset: 0x1A881A0 VA: 0x1A881A0
		private IEnumerator ShowHomeBgPopup()
		{
			//0x1A91500
			int f = 0;
			for(int i = m_viewDataList.Count - 1; i >= 0; i--)
			{
				if(!m_viewDataList[i].HHBJAEOIGIH_IsLocked)
				{
					if(m_viewDataList[i].MMEGDFPNONJ_HasDivaId)
					{
						f = i;
						break;
					}
				}
			}
			LIEJFHMGNIA l = m_viewDataList[f];
			BJPLLEBHAGO_DivaInfo diva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[l.AHHJLDLAPAN_DivaId - 1];
			CGFNKMNBNBN.HHGLKFFKFAB(diva.AHHJLDLAPAN_DivaId);
			if(CGFNKMNBNBN.JBNMNPMCIBM_HaveBg(diva.CMBCBNEODPD_HomeBgId))
				yield break;
			PopupPlusHomeBG.Setting s = new PopupPlusHomeBG.Setting();
			MenuScene.Instance.InputDisable();
			s.m_bundle_id = 1;
			s.m_titleName = CGFNKMNBNBN.ELKDCEEPLKB(diva.CMBCBNEODPD_HomeBgId).OPFGFINHFCE_Name;
			s.WindowSize = SizeType.Small;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.m_bg_id = CGFNKMNBNBN.ELKDCEEPLKB(diva.CMBCBNEODPD_HomeBgId).KEFGPJBKAOD_BgId;
			MenuScene.Instance.InputEnable();
			bool t_end_popup = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A8A4C4
				return;
			}, null, null, null, endCallBaack:() =>
			{
				//0x1A8A4E4
				t_end_popup = true;
			});
			while(!t_end_popup)
				yield return null;
		}

		//// RVA: 0x1A843E0 Offset: 0x1A843E0 VA: 0x1A843E0
		private Coroutine StartEffectPhase(EffectType effectType, int index)
		{
			if(!m_viewDataList[index].ENEKMHMKNFK)
			{
				if(m_scrollViewList[index].layoutIcon != null)
				{
					m_scrollViewList[index].layoutIcon.In(effectType);
				}
				if(m_scrollViewList[index].layoutTerminationIcon != null)
				{
					m_scrollViewList[index].layoutTerminationIcon.In(effectType);
				}
			}
			else
			{
				if (m_scrollViewList[index].layoutTerminationIcon != null)
				{
					m_scrollViewList[index].layoutTerminationIcon.In(EffectType.UPDATE);
				}
			}
			//LAB_01a846e8
			if(!m_viewDataList[index].ELIHAGFNOBN_IsStoryEndAndCompleted || IsComplete())
			{
				if(!m_viewDataList[index].NDLKPJDHHCN_NotShown)
				{
					if (m_viewDataList[index].MMEGDFPNONJ_HasDivaId)
						return this.StartCoroutineWatched(ProcFromShowToDivaJoin(index));
					else
						return this.StartCoroutineWatched(ProcFromShowToStageUnlock(index));
				}
				else if(!m_viewDataList[index].ENEKMHMKNFK)
				{
					if(m_viewDataList[index].MMEGDFPNONJ_HasDivaId)
					{
						if (m_viewDataList[index].HHBJAEOIGIH_IsLocked)
							return this.StartCoroutineWatched(ProcFromNoneToDiva(index));
						else
							return this.StartCoroutineWatched(ProcFromNoneToDivaJoin(index));
					}
					else if(!m_viewDataList[index].EOBACDCDGOF_IsTerminate)
					{
						if (m_viewDataList[index].HHBJAEOIGIH_IsLocked)
							return this.StartCoroutineWatched(ProcFromNoneToStageLock(index));
						else
							return this.StartCoroutineWatched(ProcFromNoneToStageUnlock(index));
					}
					else
						return this.StartCoroutineWatched(ProcFromNoneToStageTerminate(index));
				}
				else
				{
					return this.StartCoroutineWatched(ProcFromNoneToStageTerminateUnlock(effectType, index));
				}
			}
			else
			{
				return this.StartCoroutineWatched(ProcFromShowToComplete(index));
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BD24 Offset: 0x72BD24 VA: 0x72BD24
		//// RVA: 0x1A8885C Offset: 0x1A8885C VA: 0x1A8885C
		private IEnumerator AnimWaitDefault(int index)
		{
			StorySelectStageIcon layout;

			//0x1A8ACC8
			layout = m_scrollViewList[index].layoutIcon;
			while(layout.IsPlaying())
				yield return null;
			if(CallbackEffectPhaseEnd != null)
				CallbackEffectPhaseEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BD9C Offset: 0x72BD9C VA: 0x72BD9C
		//// RVA: 0x1A88924 Offset: 0x1A88924 VA: 0x1A88924
		private IEnumerator PopupShowAppearDiva(int index)
		{
			//0x1A8CA94
			MenuScene.Instance.InputEnable();
			yield return ShowInfo(m_viewDataList[index], null);
			MenuScene.Instance.InputDisable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BE14 Offset: 0x72BE14 VA: 0x72BE14
		//// RVA: 0x1A889EC Offset: 0x1A889EC VA: 0x1A889EC
		private IEnumerator SeriesFader(int index)
		{
			int logo_id;

			//0x1A90A6C
			LIEJFHMGNIA viewStageData = m_viewDataList[index];
			FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas.Find((FFHPBEPOMAK_DivaInfo _) =>
			{
				//0x1A8A4F8
				return _.AHHJLDLAPAN_DivaId == viewStageData.AHHJLDLAPAN_DivaId;
			});
			logo_id = diva != null ? diva.AIHCEGFANAM_Serie : 1;
			if(UnlockFadeManager.Instance != null)
			{
				UnlockFadeManager.Release();
				yield return null;
			}
			UnlockFadeManager.Create();
			this.StartCoroutineWatched(UnlockFadeManager.Instance.Co_LoadFadeEffect(logo_id));
			while(!UnlockFadeManager.Instance.IsLoaded())
				yield return null;
			UnlockFadeManager.Instance.GetEffect().Enter();
			while(!UnlockFadeManager.Instance.GetEffect().IsEntered())
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BE8C Offset: 0x72BE8C VA: 0x72BE8C
		//// RVA: 0x1A88AB4 Offset: 0x1A88AB4 VA: 0x1A88AB4
		private IEnumerator ShowJoinDiva(int index)
		{
			LIEJFHMGNIA viewStageData;

			//0x1A933BC
			viewStageData = m_viewDataList[index];
			yield return Co.R(m_scrollViewList[index].layoutIcon.StampPressAnim());
			KDLPEDBKMID.HHCJCDFCLOB.NMFCNFFFMAC_InstallDivaCostume(viewStageData.AHHJLDLAPAN_DivaId, 1, false);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			yield return Co.R(SeriesFader(index));
			viewStageData.PGCCOCKGCKO = false;
			MenuScene.Instance.BgControl.StoryBgHide();
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.Call(TransitionList.Type.UNLOCK_DIVA, new UnlockDivaArgs() { diva_id = viewStageData.AHHJLDLAPAN_DivaId }, true);
			}
			while(true)
				yield return null;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BF04 Offset: 0x72BF04 VA: 0x72BF04
		//// RVA: 0x1A883C4 Offset: 0x1A883C4 VA: 0x1A883C4
		private IEnumerator ProcFromNoneToDiva(int index)
		{
			StorySelectStageIcon layout;

			//0x1A8E5B8
			layout = m_scrollViewList[index].layoutIcon;
			while(layout.IsPlaying())
				yield return null;
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialCodition));
			int index_ = index;
			if(index + 1 < m_viewDataList.Count)
				index_++;
			if((m_viewDataList[index_].AHHJLDLAPAN_DivaId & 0xfffffffeU) != 8)
			{
				yield return Co.R(PopupShowAppearDiva(index));
				if(CallbackEffectPhaseEnd != null)
					CallbackEffectPhaseEnd();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BF7C Offset: 0x72BF7C VA: 0x72BF7C
		//// RVA: 0x1A8846C Offset: 0x1A8846C VA: 0x1A8846C
		private IEnumerator ProcFromNoneToDivaJoin(int index)
		{
			StorySelectStageIcon layout;

			//0x1A8E910
			layout = m_scrollViewList[index].layoutIcon;
			while(layout.IsPlaying())
				yield return null;
			int index_ = index;
			if(index + 1 < m_viewDataList.Count)
				index_++;
			if((m_viewDataList[index_].AHHJLDLAPAN_DivaId & 0xfffffffeU) != 8)
			{
				yield return Co.R(PopupShowAppearDiva(index));
				yield return Co.R(ShowJoinDiva(index));
				if(CallbackEffectPhaseEnd != null)
					CallbackEffectPhaseEnd();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72BFF4 Offset: 0x72BFF4 VA: 0x72BFF4
		//// RVA: 0x1A885BC Offset: 0x1A885BC VA: 0x1A885BC
		private IEnumerator ProcFromNoneToStageLock(int index)
		{
			//0x1A8EC0C
			yield return Co.R(AnimWaitDefault(index));
			int index_ = index;
			if(index + 1 < m_viewDataList.Count)
				index_++;
			if((m_viewDataList[index_].AHHJLDLAPAN_DivaId & 0xfffffffeU) != 8)
			{
				MenuScene.Instance.InputEnable();
				yield return ShowInfo(m_viewDataList[index], null);
				MenuScene.Instance.InputDisable();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C06C Offset: 0x72C06C VA: 0x72C06C
		//// RVA: 0x1A88664 Offset: 0x1A88664 VA: 0x1A88664
		private IEnumerator ProcFromNoneToStageUnlock(int index)
		{
			//0x1A8F434
			yield return Co.R(AnimWaitDefault(index));
			int index_ = index;
			if(index + 1 < m_viewDataList.Count)
				index_++;
			if((m_viewDataList[index_].AHHJLDLAPAN_DivaId & 0xfffffffeU) != 8)
			{
				MenuScene.Instance.InputEnable();
				yield return ShowInfo(m_viewDataList[index], null);
				MenuScene.Instance.InputDisable();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C0E4 Offset: 0x72C0E4 VA: 0x72C0E4
		//// RVA: 0x1A88514 Offset: 0x1A88514 VA: 0x1A88514
		private IEnumerator ProcFromNoneToStageTerminate(int index)
		{
			StorySelectStageTerminationIcon layout;

			//0x1A8EF10
			layout = m_scrollViewList[index].layoutTerminationIcon;
			while(layout.IsPlaying())
				yield return null;
			yield return this.StartCoroutineWatched(PopupShowTermination());
			if(CallbackEffectPhaseEnd != null)
				CallbackEffectPhaseEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C15C Offset: 0x72C15C VA: 0x72C15C
		//// RVA: 0x1A88304 Offset: 0x1A88304 VA: 0x1A88304
		private IEnumerator ProcFromNoneToStageTerminateUnlock(EffectType effectType, int index)
		{
			StorySelectStageTerminationIcon layout;

			//0x1A8F170
			layout = m_scrollViewList[index].layoutTerminationIcon;
			while(layout.IsPlaying())
				yield return null;
			m_viewDataList[index].ENEKMHMKNFK = false;
			layout.Hide(true);
			m_freeTerminationIcon = layout;
			m_scrollViewList[index].layoutTerminationIcon = null;
			yield return StartEffectPhase(effectType, index);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C1D4 Offset: 0x72C1D4 VA: 0x72C1D4
		//// RVA: 0x1A8870C Offset: 0x1A8870C VA: 0x1A8870C
		private IEnumerator ProcFromShowToDivaJoin(int index)
		{
			StorySelectStageIcon layout;

			//0x1A8FBB8
			layout = m_scrollViewList[index].layoutIcon;
			while(layout.IsPlaying())
				yield return null;
			layout.SetNoiseEnable(false);
			yield return Co.R(ShowJoinDiva(index));
			if(CallbackEffectPhaseEnd != null)
				CallbackEffectPhaseEnd();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C24C Offset: 0x72C24C VA: 0x72C24C
		//// RVA: 0x1A887B4 Offset: 0x1A887B4 VA: 0x1A887B4
		private IEnumerator ProcFromShowToStageUnlock(int index)
		{
			//0x1A8FE3C
			yield return Co.R(AnimWaitDefault(index));
			m_scrollViewList[index].layoutIcon.SetNoiseEnable(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C2C4 Offset: 0x72C2C4 VA: 0x72C2C4
		//// RVA: 0x1A8825C Offset: 0x1A8825C VA: 0x1A8825C
		private IEnumerator ProcFromShowToComplete(int index)
		{
			//0x1A8F738
			storySelectController.layoutIconScroll.content.localPosition = new Vector3(-m_scrollPosRightX, 0, 0);
            StorySelectStageCompleteIcon complete = m_scrollViewList[index].layoutCompleteIcon;
			bool isLoading = true;
			yield return Co.R(storySelectController.Co_CompleteProduction(() =>
			{
				//0x1A8A54C
				isLoading = false;
			}, () =>
			{
				//0x1A8A558
				complete.viewStageData = m_viewDataList[index];
				complete.In(EffectType.APPEAR);
			}));
			while(isLoading)
				yield return null;
			while(complete.IsPlaying())
				yield return null;
			StoryComplete();
			yield return Co.R(PopupShowComplete());
			yield return Co.R(PopupShowMissionGuidance());
        }

		//// RVA: 0x1A88C9C Offset: 0x1A88C9C VA: 0x1A88C9C
		private bool IsInterruptLock(int no)
		{
			int index = no - 1;
			if((m_viewDataList[no].AHHJLDLAPAN_DivaId & 0xfffffffeU) != 8 && index > -1)
			{
				if(index < m_viewDataList.Count)
				{
					if((m_viewDataList[index].AHHJLDLAPAN_DivaId & 0xfffffffeU) == 8)
					{
						return !m_viewDataList[index].BCGLDMKODLC_StatusCompleted;
					}
				}
			}
			return false;
		}

		//// RVA: 0x1A88E34 Offset: 0x1A88E34 VA: 0x1A88E34
		private void OnClickIcon(int no)
		{
			if(!m_viewDataList[no].ELIHAGFNOBN_IsStoryEndAndCompleted)
			{
				if(!m_viewDataList[no].EOBACDCDGOF_IsTerminate)
				{
					if(IsInterruptLock(no))
					{
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						this.StartCoroutineWatched(PopupShowLock(no, bk.GetMessageByLabel("story_unlock_08"), bk.GetMessageByLabel("story_unlock_09"), true));
					}
					else
					{
						this.StartCoroutineWatched(ShowInfo(m_viewDataList[no], null));
					}
				}
				else
				{
					this.StartCoroutineWatched(PopupShowTermination());
				}
			}
			else
			{
				this.StartCoroutineWatched(PopupShowComplete());
			}
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if (PushIconListener != null)
				PushIconListener();
		}

		//// RVA: 0x1A89328 Offset: 0x1A89328 VA: 0x1A89328
		public void ClearIconPushEvent()
		{
			PushIconListener = null;
		}

		//// RVA: 0x1A89314 Offset: 0x1A89314 VA: 0x1A89314
		//private void OnPushIcon() { }

		//[IteratorStateMachineAttribute] // RVA: 0x72C33C Offset: 0x72C33C VA: 0x72C33C
		//// RVA: 0x1A89254 Offset: 0x1A89254 VA: 0x1A89254
		private IEnumerator ShowInfo(LIEJFHMGNIA stageData, Action finish)
		{
			LayoutStorySelectInfo layoutInfo;

			//0x1A91CF0
			GameManager.Instance.AddPushBackButtonHandler(ShowInfoBackButtonEmpty);
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			bool isLoading = true;
			this.StartCoroutineWatched(storySelectController.LoadLayoutInfo(() =>
			{
				//0x1A8A640
				isLoading = false;
			}));
			while (isLoading)
				yield return null;
			if (storySelectController.layoutInfo == null)
			{
				GameManager.Instance.RemovePushBackButtonHandler(ShowInfoBackButtonEmpty);
				if (MenuScene.Instance != null)
					MenuScene.Instance.RaycastEnable();
				if (finish != null)
					finish();
				yield break;
			}
			layoutInfo = storySelectController.layoutInfo;
			int selectLabel = 0;
			layoutInfo.transform.SetParent(transform.parent.parent, false);
			layoutInfo.transform.SetAsLastSibling();
			yield return null;
			if (stageData.IFNPBIJEPBO_IsDlded)
			{
				yield return Co.R(ChangeBgm(stageData, false, null, null));
			}
			bool isWaitChangeBgm = true;
			layoutInfo.SetStatus(stageData, (int label) =>
			{
				//0x1A8A64C
				selectLabel = label;
				if (label == 4)
				{
					GameManager.Instance.AddPushBackButtonHandler(ShowInfoBackButtonEmpty);
				}
				if (label == 1)
				{
					if (stageData.IFNPBIJEPBO_IsDlded)
					{
						this.StartCoroutineWatched(ChangeBgm(stageData, true, () =>
						{
							//0x1A8A854
							isWaitChangeBgm = false;
						}, null));
						return;
					}
					isWaitChangeBgm = false;
				}
				else
					isWaitChangeBgm = false;
			});
			while (!layoutInfo.IsReady())
				yield return null;
			if (stageData.MBJOBPJKGBO)
			{
				stageData.MFEGPPKFCEI();
				yield return Co.R(Co_Save());
			}
			layoutInfo.In();
			yield return null;
			while (layoutInfo.IsPlayingInAnim())
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(ShowInfoBackButtonEmpty);
			GameManager.Instance.AddPushBackButtonHandler(ShowInfoBackButton);
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
			while (layoutInfo.IsShow())
			{
				if (selectLabel != 4)
					yield return null;
				else
				{
					yield return Co.R(ChangeBgm(stageData, false, null, null));
					layoutInfo.ChangeButton();
					selectLabel = 0;
					GameManager.Instance.RemovePushBackButtonHandler(ShowInfoBackButtonEmpty);
					yield return null;
				}
			}
			layoutInfo.Clear();
			layoutInfo.transform.SetParent(transform.parent, false);
			yield return null;
			if (selectLabel == 3)
			{
				if (IsEffectStart)
				{
					yield return Co.R(Co_Save());
				}
			}
			else if (selectLabel == 4)
			{
				isWaitChangeBgm = true;
				yield return Co.R(ChangeBgm(stageData, false, () =>
				{
					//0x1A8A860
					isWaitChangeBgm = false;
				}, null));
			}
			//LAB_01a91d90
			while (isWaitChangeBgm)
				yield return null;
			GameManager.Instance.RemovePushBackButtonHandler(ShowInfoBackButton);
			if (selectLabel != 1)
			{
				PGIGNJDPCAH.HIHIEBACIHJ(PGIGNJDPCAH.FELLIEJEPIJ.LPBDIINNFEE_5/*5*/);
				if (MenuScene.CheckDatelineAndAssetUpdate())
				{
					if (finish != null)
						finish();
					yield break;
				}
			}
			//LAB_01a91f0c
			if (selectLabel == 2)
			{
				MenuScene.Instance.Call(TransitionList.Type.TEAM_SELECT, m_teamSelectSceneArgs, true);
				Database.Instance.gameSetup.musicInfo.SetupInfoByStoryMusic(stageData.KLCIIHKFPPO_StoryMusicId, stageData.IOMLIADJJLD(true));
				Database.Instance.selectedMusic.SetStoryMusic(stageData);
			}
			else if (selectLabel == 3)
			{
				if (MenuScene.Instance != null)
				{
					LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA[stageData.LFLLLOPAKCO_StoryId - 1];
					int freeMusicId = dbStory.ICKPLIABPKC_FreeMusicId;
					MusicSelectArgs arg = null;
					if (freeMusicId > 0)
					{
						long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						for (int i = 1; i - 1 <= 5; i++)
						{
							List<IBJAKJJICBC> l = IBJAKJJICBC.FKDIMODKKJD(i, time, true, false, false, false);
							IBJAKJJICBC i_ = l.Find((IBJAKJJICBC x) =>
							{
								//0x1A8A874
								return freeMusicId == x.GHBPLHBNMBK_FreeMusicId;
							});
							if (i_ != null)
							{
								arg = new MusicSelectArgs();
								arg.SetSelection(i_.GHBPLHBNMBK_FreeMusicId);
								MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
								break;
							}
						}
					}
					else
					{
						MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					}
				}
			}
			if (finish != null)
				finish();
		}

		//// RVA: 0x1A89354 Offset: 0x1A89354 VA: 0x1A89354
		private void ShowInfoBackButtonEmpty()
		{
			return;
		}

		//// RVA: 0x1A89358 Offset: 0x1A89358 VA: 0x1A89358
		private void ShowInfoBackButton()
		{
			if (storySelectController.layoutInfo != null)
				storySelectController.layoutInfo.Close();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C3B4 Offset: 0x72C3B4 VA: 0x72C3B4
		//// RVA: 0x1A89428 Offset: 0x1A89428 VA: 0x1A89428
		private IEnumerator Co_Save()
		{
			//0x1A8B6C4
			bool isWait = true;
			MenuScene.Instance.InputDisable();
			MenuScene.Save(() =>
			{
				//0x1A8A8C0
				isWait = false;
			}, () =>
			{
				//0x1A8A4C8
				return;
			});
			while (isWait)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C42C Offset: 0x72C42C VA: 0x72C42C
		//// RVA: 0x1A8915C Offset: 0x1A8915C VA: 0x1A8915C
		private IEnumerator PopupShowLock(int no, string title, string message, bool isInterruptLock = false)
		{
			//0x1A8D24C
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent(title, SizeType.Small, string.IsNullOrEmpty(message) ? m_viewDataList[no].FHPHCFEEBMP : message, isInterruptLock ? new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			} : new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Live, Type = PopupButton.ButtonType.Live }
			}, false, false);
			bool isWait = true;
			bool isLive = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A8A8D4
				isWait = false;
				if(label == PopupButton.ButtonLabel.Live)
					isLive = true;
			}, null, null, null);
			while(isWait)
				yield return null;
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
			if(isLive)
			{
				if(MenuScene.Instance != null)
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		//// RVA: 0x1A894DC Offset: 0x1A894DC VA: 0x1A894DC
		private void StoryComplete()
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.EOHHFADHHBL_Complete = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C4A4 Offset: 0x72C4A4 VA: 0x72C4A4
		//// RVA: 0x1A89074 Offset: 0x1A89074 VA: 0x1A89074
		private IEnumerator PopupShowComplete()
		{
			//0x1A8CCC0
			GameManager.Instance.CloseSnsNotice();
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, bk.GetMessageByLabel("popup_story_complete_stage"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, false);
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A8A8F4
				isWait = false;
			}, null, null, null);
			while (isWait)
				yield return null;
			if (MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C51C Offset: 0x72C51C VA: 0x72C51C
		//// RVA: 0x1A895CC Offset: 0x1A895CC VA: 0x1A895CC
		private IEnumerator PopupShowMissionGuidance()
		{
			//0x1A8D988
			GameManager.Instance.CloseSnsNotice();
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastDisable();
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, bk.GetMessageByLabel("popup_story_mission_guidance"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Mission, Type = PopupButton.ButtonType.Other }
			}, false, false);
			bool changeMission = false;
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A8A908
				isWait = false;
				if(type == PopupButton.ButtonType.Other)
					changeMission = true;
			}, null, null, null);
			while(isWait)
				yield return null;
			if(MenuScene.Instance != null)
			{
				MenuScene.Instance.RaycastEnable();
			}
			if(changeMission)
			{
				QuestTopArgs args = new QuestTopArgs(2);
				MenuScene.Instance.Mount(TransitionUniqueId.QUEST, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C594 Offset: 0x72C594 VA: 0x72C594
		//// RVA: 0x1A890E8 Offset: 0x1A890E8 VA: 0x1A890E8
		private IEnumerator PopupShowTermination()
		{
			//0x1A8E038
			GameManager.Instance.CloseSnsNotice();
			if(MenuScene.Instance != null)
				MenuScene.Instance.RaycastDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, bk.GetMessageByLabel("popup_story_termination"), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
			}, false, false);
			bool isWait = true;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A8A928
				isWait = false;
			}, null, null, null);
			while(isWait)
				yield return null;
			if(MenuScene.Instance != null)
				MenuScene.Instance.RaycastEnable();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C60C Offset: 0x72C60C VA: 0x72C60C
		//// RVA: 0x1A89680 Offset: 0x1A89680 VA: 0x1A89680
		private IEnumerator DownLoadMusic(LIEJFHMGNIA stageData, Action finish)
		{
			UGUIFader fader; // 0x18
			TipsControl tipsCtrl; // 0x1C
			int musicId; // 0x20
			ILCCJNDFFOB lw; // 0x24
			float pre; // 0x28

			//0x1A8BA48
			if (stageData.IFNPBIJEPBO_IsDlded)
				yield break;
			fader = GameManager.Instance.fullscreenFader;
			tipsCtrl = TipsControl.Instance;
			MenuScene.Instance.InputDisable();
			fader.Fade(0.5f, new Color(0, 0, 0, 0.5f));
			tipsCtrl.Show(3);
			while(fader.isFading)
				yield return null;
			yield return TipsControl.Instance.WaitLoadingYield;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			musicId = stageData.KKPAHLMJKIH_WavId;
			int a1 = stageData.KEFGPJBKAOD_WavId;
			int videoQuality = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				videoQuality = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			lw.OJOLFJGNEMO(0, musicId);
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA_DownloadSongDatas(musicId, a1, videoQuality, 1);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				if(pre < 50)
				{
					if(KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP >= 50)
					{
						lw.OJOLFJGNEMO(1, musicId);
					}
				}
				pre = KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP;
				yield return null;
			}
			lw.OJOLFJGNEMO(2, musicId);
			stageData.OBGKIMDIAJF_CheckIsDlded();
			fader.Fade(0.5f, 0);
			tipsCtrl.Close();
			while(fader.isFading)
				yield return null;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			MenuScene.Instance.InputEnable();
			if(finish != null)
				finish();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C684 Offset: 0x72C684 VA: 0x72C684
		//// RVA: 0x1A89748 Offset: 0x1A89748 VA: 0x1A89748
		private IEnumerator ChangeBgm(LIEJFHMGNIA stageData, bool isStoryMenuBgm = false, Action finish = null, Action downloadFinish = null)
		{
			//0x1A8AEC8
			if(!stageData.MMEGDFPNONJ_HasDivaId)
			{
				if(!stageData.HHBJAEOIGIH_IsLocked)
				{
					if(!isStoryMenuBgm)
					{
						yield return Co.R(DownLoadMusic(stageData, downloadFinish));
					}
					BgmPlayer bgmPlayer = SoundManager.Instance.bgmPlayer;
					int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + stageData.KKPAHLMJKIH_WavId;
					if (isStoryMenuBgm)
					{
						bgmId = BgmPlayer.MENU_BGM_ID_BASE + 3;
					}
					bool isFadeOut = true;
					if(bgmPlayer.isPlaying)
					{
						bgmPlayer.FadeOut(0.3f, () =>
						{
							//0x1A8A93C
							bgmPlayer.ContinuousPlay(bgmId, 1);
							isFadeOut = false;
						});
					}
					else
					{
						bgmPlayer.ContinuousPlay(bgmId, 1);
					}
					if(isStoryMenuBgm)
					{
						while (isFadeOut)
							yield return null;
					}
				}
			}
			if (finish != null)
				finish();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72C6FC Offset: 0x72C6FC VA: 0x72C6FC
		//// RVA: 0x1A89860 Offset: 0x1A89860 VA: 0x1A89860
		private IEnumerator ShowTutorial()
		{
			//0x1A9393C
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine((TutorialConditionId conditionId) =>
			{
				//0x1A8A4CC
				return conditionId == TutorialConditionId.Condition14;
			}));
			if(CallbackEffectPhaseEnd != null)
				CallbackEffectPhaseEnd();
		}

		//// RVA: 0x1A8990C Offset: 0x1A8990C VA: 0x1A8990C
		private bool CheckTutorialCodition(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition32;
		}

		//// RVA: 0x1A8991C Offset: 0x1A8991C VA: 0x1A8991C
		private StorySelectStageIcon GetFreeObject(ItemObject obj)
		{
			if(obj != null)
			{
				if (!obj.viewStageData.EOBACDCDGOF_IsTerminate)
					return FreeIconObject(obj.isSizeL);
			}
			return null;
		}

		//// RVA: 0x1A8996C Offset: 0x1A8996C VA: 0x1A8996C
		private StorySelectStageTerminationIcon GetFreeTerminationObject(ItemObject obj)
		{
			if (obj == null)
				return null;
			if(!obj.viewStageData.EOBACDCDGOF_IsTerminate)
			{
				if (!obj.viewStageData.ENEKMHMKNFK)
					return null;
			}
			return FreeTerminationObject();
		}

		//// RVA: 0x1A899D8 Offset: 0x1A899D8 VA: 0x1A899D8
		private StorySelectStageCompleteIcon GetFreeCompleteObject(ItemObject obj)
		{
			if(obj != null)
			{
				if (obj.viewStageData.ELIHAGFNOBN_IsStoryEndAndCompleted)
					return FreeCompleteObject();
			}
			return null;
		}

		//// RVA: 0x1A83BEC Offset: 0x1A83BEC VA: 0x1A83BEC
		private void ReleaseObject(ItemObject obj)
		{
			if (obj != null)
			{
				if (obj.layoutCompleteIcon != null)
				{
					m_freeCompleteIcon = obj.layoutCompleteIcon;
					obj.layoutCompleteIcon = null;
				}
				if (obj.layoutTerminationIcon != null)
				{
					m_freeTerminationIcon = obj.layoutTerminationIcon;
					obj.layoutTerminationIcon = null;
				}
				if (obj.layoutIcon != null)
				{
					if (!obj.isSizeL)
					{
						m_freeIconList.Add(obj.layoutIcon);
					}
					else
					{
						m_freeIconLList.Add(obj.layoutIcon);
					}
					obj.layoutIcon = null;
					if (obj.layoutNewIcon != null)
					{
						m_freeNewMarkIcon = obj.layoutNewIcon;
						obj.layoutNewIcon = null;
					}
				}
			}
		}

		//// RVA: 0x1A89A20 Offset: 0x1A89A20 VA: 0x1A89A20
		private void CalcScrollVisibleRange(ScrollRect rect, out float xLeft, out float xRight)
		{
			xLeft = rect.horizontalNormalizedPosition * (m_scrollRectContentRt.sizeDelta.x - m_scrollIconRectRt.sizeDelta.x);
			xRight = xLeft + m_scrollIconRectRt.sizeDelta.x;
		}

		//// RVA: 0x1A89AFC Offset: 0x1A89AFC VA: 0x1A89AFC
		//private bool InScrollView(float x, float y, int w, int h, float xLeft, float xRight) { }

		//// RVA: 0x1A84848 Offset: 0x1A84848 VA: 0x1A84848
		private void UpdateScrollInner()
		{
			if(m_scrollIconRectRt != null)
			{
				if(m_scrollRectContentRt != null)
				{
					float x, x2;
					CalcScrollVisibleRange(storySelectController.layoutIconScroll, out x, out x2);
					for(int i = 0; i < m_scrollViewList.Count; i++)
					{
						if (m_scrollViewList[i].pos.x + m_scrollViewList[i].size.x < x || x2 < m_scrollViewList[i].pos.x)
						{
							if(m_scrollViewList[i].layoutIcon != null || m_scrollViewList[i].layoutTerminationIcon != null || m_scrollViewList[i].layoutCompleteIcon != null)
							{
								m_scrollViewList[i].Hide();
								ReleaseObject(m_scrollViewList[i]);
							}
						}
						else
						{
							if(m_scrollViewList[i].layoutIcon == null)
							{
								if(m_scrollViewList[i].layoutTerminationIcon == null)
								{
									m_scrollViewList[i].layoutIcon = GetFreeObject(m_scrollViewList[i]);
									m_scrollViewList[i].layoutTerminationIcon = GetFreeTerminationObject(m_scrollViewList[i]);
									m_scrollViewList[i].layoutCompleteIcon = GetFreeCompleteObject(m_scrollViewList[i]);
									if (m_scrollViewList[i].layoutIcon != null || m_scrollViewList[i].layoutTerminationIcon != null || m_scrollViewList[i].layoutCompleteIcon != null)
									{
										m_scrollViewList[i].SetStatus(storySelectController, IsComplete());
										m_scrollViewList[i].Show();
									}
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0x1A8A130 Offset: 0x1A8A130 VA: 0x1A8A130
		//private void ResetScrollPosition(ScrollRect rect) { }
	}
}
