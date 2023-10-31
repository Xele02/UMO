using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Gacha;
using XeSys.uGUI;

namespace XeApp.Game.Common
{
	public class GachaDirectionObject : MonoBehaviour
	{
		private enum Phase
		{
			None = 0,
			Start = 1,
			Quartz = 2,
			Cutin = 3,
			Rare = 4,
			Card = 5,
			CardWait = 6,
			Result = 7,
			_Num = 8,
		}

		private static readonly Color s_skipFadeColor = Color.white; // 0x0
		private static readonly Color s_allSkipFadeColor = Color.black; // 0x10
		[SerializeField]
		private Transform m_elementRoot; // 0xC
		[SerializeField]
		private Transform m_quartzRoot; // 0x10
		private GachaDirectionStartSet m_startSet; // 0x14
		private GachaDirectionTrailSet m_trailSet; // 0x18
		private GachaDirectionQuartzSet m_quartzSet; // 0x1C
		private GachaDirectionCutinSet m_cutinSet; // 0x20
		private List<GachaDirectionRareSet> m_commonRareSet; // 0x24
		private GachaDirectionCardSet m_cardSet; // 0x28
		private GachaDirectionRareSet m_rareSet; // 0x2C
		private List<GachaDirectionStone> m_stones; // 0x34
		private GachaDirectionStone m_stoneForCutin; // 0x38
		private GachaDirectionCardName m_cardName; // 0x3C
		private GachaDirectionCardFrame m_cardFrame; // 0x40
		private GachaDirectionCamera m_cameraObject; // 0x44
		private WeakReference m_directionInfo; // 0x48
		private int m_currentCardIndex; // 0x5C
		private Phase m_currentPhase; // 0x60
		private bool m_isEndIntro; // 0x64
		private bool m_isInMain; // 0x65
		private int m_skipLockCount; // 0x68

		//public Transform elementRoot { get; } 0x1C19AC8
		//public Transform quartzRoot { get; } 0x1C19AD0
		private GachaDirectionRareSet currentRareSet { get; set; } // 0x30
		private DirectionInfo directionInfo { get
			{
				if(m_directionInfo.IsAlive)
				{
					return m_directionInfo.Target as DirectionInfo;
				}
				return null;
			}
		} //0x1C19AE8
		public Action onEndIntroCallback { private get; set; } // 0x4C
		public Action onEndAllCallback { private get; set; } // 0x50
		public Action<CardInfo> onRequestDelayLoad { private get; set; } // 0x54
		//public bool canAllSkip { get; } 0x1C19C68
		public bool isLastCard { get { return directionInfo.cardNum - 1 <= m_currentCardIndex; } } //0x1C18F3C
		//private bool isRareCard { get; } 0x1C19CA8
		//public bool isOrbChange { get; } 0x1C18FC8
		public bool isIgnoreEventFade { get; private set; } // 0x58

		// RVA: 0x1C19D1C Offset: 0x1C19D1C VA: 0x1C19D1C
		public void RegisterDirectionInfo(DirectionInfo directionInfo)
		{
			m_directionInfo = new WeakReference(directionInfo);
		}

		// RVA: 0x1C19D94 Offset: 0x1C19D94 VA: 0x1C19D94
		public void Initialize(GachaDirectionResource resource)
		{
			InstantiatePrefab(resource);
			m_startSet.onEndEnterAnim = OnEndAuraEnter;
			m_startSet.onEndLeaveAnim = OnEndAuraLeave;
			m_quartzSet.onEndMainAnim = OnEndStoneMain;
			m_cutinSet.onEndMainAnim = OnEndCutinMain;
			for(int i = 0; i < m_commonRareSet.Count; i++)
			{
				m_commonRareSet[i].onEndMainAnim = OnEndCardSp;
			}
			m_cardSet.onEndEnterAnim = OnEndCardEnter;
			m_cardSet.onEndWaitAnim = OnEndCardWait;
			m_cardName.SetFont(GameManager.Instance.GetSystemFont());
		}

		// RVA: 0x1C1AF6C Offset: 0x1C1AF6C VA: 0x1C1AF6C
		public void RegisterCameraObject(GachaDirectionCamera cameraObject)
		{
			m_cameraObject = cameraObject;
		}

		// RVA: 0x1C1AF74 Offset: 0x1C1AF74 VA: 0x1C1AF74
		public void Setup(bool retryTime = false)
		{
			if(retryTime)
			{
				for(int i = 0; i < m_stones.Count; i++)
				{
					m_stones[i].meshRefData.SetParent(m_stones[i].transform, false);
				}
				m_stoneForCutin.meshRefData.SetParent(m_stoneForCutin.transform, false);
			}
			for(int i = 0; i < directionInfo.cardNum; i++)
			{
				m_stones[i].meshRefData.SetParent(m_quartzSet.GetQuartzRefData(i - directionInfo.cardNum == -1 ? 9 : i));
			}
			m_stoneForCutin.meshRefData.SetParent(m_cutinSet.m_quartzRefData, false);
			m_startSet.Setup(directionInfo);
			m_trailSet.Setup(directionInfo);
			m_quartzSet.Setup(directionInfo);
			m_cutinSet.Setup(directionInfo);
			for(int i = 0; i < m_commonRareSet.Count; i++)
			{
				m_commonRareSet[i].Setup(directionInfo);
			}
			m_cardSet.Setup(directionInfo);
			m_cardFrame.Setup(directionInfo);
			m_isEndIntro = false;
			m_isInMain = false;
		}

		//// RVA: 0x1C1A15C Offset: 0x1C1A15C VA: 0x1C1A15C
		private void InstantiatePrefab(GachaDirectionResource resource)
		{
			if(m_startSet != null)
			{
				Destroy(m_startSet.gameObject);
				m_startSet = null;
			}
			if(m_trailSet != null)
			{
				Destroy(m_trailSet.gameObject);
				m_trailSet = null;
			}
			if (m_quartzSet != null)
			{
				Destroy(m_quartzSet.gameObject);
				m_quartzSet = null;
			}
			if(m_cutinSet != null)
			{
				Destroy(m_cutinSet.gameObject);
				m_cutinSet = null;
			}
			if(m_commonRareSet != null)
			{
				for(int i = 0; i < m_commonRareSet.Count; i++)
				{
					if(m_commonRareSet[i] != null)
					{
						Destroy(m_commonRareSet[i].gameObject);
					}
				}
				m_commonRareSet = null;
			}
			if(m_cardSet != null)
			{
				Destroy(m_cardSet.gameObject);
				m_cardSet = null;
			}
			m_startSet = Instantiate(resource.startSetPrefab).GetComponent<GachaDirectionStartSet>();
			m_startSet.transform.SetParent(m_elementRoot, false);
			m_trailSet = Instantiate(resource.trailSetPrefab).GetComponent<GachaDirectionTrailSet>();
			m_trailSet.transform.SetParent(m_elementRoot, false);
			m_quartzSet = Instantiate(resource.quartzSetPrefab).GetComponent<GachaDirectionQuartzSet>();
			m_quartzSet.transform.SetParent(m_elementRoot, false);
			m_cutinSet = Instantiate(resource.cutinSetPrefab).GetComponent<GachaDirectionCutinSet>();
			m_cutinSet.transform.SetParent(m_elementRoot, false);
			m_commonRareSet = new List<GachaDirectionRareSet>();
			for(int i = 0; i < resource.commonRareSetPrefab.Count; i++)
			{
				GachaDirectionRareSet obj = Instantiate(resource.commonRareSetPrefab[i]).GetComponent<GachaDirectionRareSet>();
				obj.transform.SetParent(m_elementRoot, false);
				m_commonRareSet.Add(obj);
			}
			m_cardSet = Instantiate(resource.cardSetPrefab).GetComponent<GachaDirectionCardSet>();
			m_cardSet.transform.SetParent(m_elementRoot, false);
			m_stones = new List<GachaDirectionStone>(10);
			for(int i = 0; i < 10; i++)
			{
				GachaDirectionStone obj = Instantiate(resource.stonePrefab).GetComponent<GachaDirectionStone>();
				obj.transform.SetParent(m_quartzRoot, false);
				m_stones.Add(obj);
			}
			m_stoneForCutin = Instantiate(resource.stonePrefab).GetComponent<GachaDirectionStone>();
			m_stoneForCutin.transform.SetParent(m_quartzRoot, false);
			m_quartzRoot.gameObject.SetActive(false);
			m_cardName = Instantiate(resource.cardNamePrefab).GetComponent<GachaDirectionCardName>();
			m_cardName.transform.SetParent(m_cardSet.transform);
			m_cardFrame = Instantiate(resource.cardFramePrefab).GetComponent<GachaDirectionCardFrame>();
			m_cardFrame.transform.SetParent(m_elementRoot, false);
		}

		// RVA: 0x1C1B4E8 Offset: 0x1C1B4E8 VA: 0x1C1B4E8
		public void SetupDelayedResource(GachaDirectionResource resource)
		{
			CardInfo info = directionInfo.GetCardInfo(m_currentCardIndex);
			if(m_rareSet != null)
			{
				Destroy(m_rareSet.gameObject);
				m_rareSet = null;
			}
			if(info.hasSpAnim)
			{
				if(info.spAnimId < 0)
				{
					currentRareSet = m_commonRareSet[info.spAnimId == -2 ? 1 : 0];
					if(resource.cardMaterial != null)
						currentRareSet.ApplyCardMaterial(resource.cardMaterial);
					else
						currentRareSet.ApplyCardTexture(resource.cardTexture);
				}
				else
				{
					m_rareSet = Instantiate(resource.rareSetPrefab).GetComponent<GachaDirectionRareSet>();
					m_rareSet.transform.SetParent(m_elementRoot, false);
					GachaDirectionEventListener lst = m_rareSet.GetComponent<GachaDirectionEventListener>();
					lst.directionObject = this;
					m_rareSet.onEndMainAnim = OnEndCardSp;
					m_rareSet.Setup(directionInfo);
					if (resource.cardMaterial != null)
						m_rareSet.ApplyCardMaterial(resource.cardMaterial);
					else
						m_rareSet.ApplyCardTexture(resource.cardTexture);
					currentRareSet = m_rareSet;
				}
			}
			int cutinType = 2;
			if(info.starNum != 6)
			{
				cutinType = (info.GetLastQuartzType() != GachaDirectionQuartzTable.QuartzType.LV3_Gold && info.starNum == 5) ? 1 : 0;
			}
			m_cutinSet.SetQuartzType(info.GetLastQuartzType(), cutinType);
			m_cardSet.SetCardStarNum(info.starNum);
			m_cardSet.SetCardAttribute(info.attrId);
			m_cardSet.SetCardSeries(info.seriesId);
			m_cardSet.SetCardNameParent(m_cardName.transform);
			m_cardSet.SetCardFrameParent(m_cardFrame.m_animationNode);
			if (resource.cardMaterial != null)
				m_cardSet.ApplyCardMaterial(resource.cardMaterial);
			else
				m_cardSet.ApplyCardTexture(resource.cardTexture);
			m_cardName.SetText(info.name);
			m_cardName.SetAttribute(info.attrId);
			m_cardFrame.SetStarNum(info.starNum);
			switch(info.attrId - 1)
			{
				case 0:
					m_cardFrame.m_vIndex = 1;
					break;
				case 1:
					m_cardFrame.m_vIndex = 0;
					break;
				case 2:
				case 3:
					m_cardFrame.m_vIndex = info.attrId - 1;
					break;
				default:
					break;
			}
			m_cardFrame.m_uvDirty = true;
			StartCardSet(info);
		}

		// RVA: 0x1C1BFE4 Offset: 0x1C1BFE4 VA: 0x1C1BFE4
		public void StartIntro(bool isRetry)
		{
			m_currentCardIndex = 0;
			m_startSet.Begin(isRetry);
			m_cameraObject.Start_Enter(isRetry, directionInfo.isPaid);
			m_currentPhase = Phase.Start;
		}

		// RVA: 0x1C1C290 Offset: 0x1C1C290 VA: 0x1C1C290
		public void StartMain()
		{
			m_isInMain = true;
			m_startSet.Leave();
			m_trailSet.Begin(m_startSet.m_valkyrieRoot);
			m_cameraObject.Start_Leave();
		}

		//// RVA: 0x1C190C4 Offset: 0x1C190C4 VA: 0x1C190C4
		//public void NotifyOrbFlash() { }

		//// RVA: 0x1C19114 Offset: 0x1C19114 VA: 0x1C19114
		//public void NotifyOrbChange() { }

		//// RVA: 0x1C191C4 Offset: 0x1C191C4 VA: 0x1C191C4
		//public void NotifyValkyrieFly(int phaseIndex) { }

		//// RVA: 0x1C19228 Offset: 0x1C19228 VA: 0x1C19228
		//public void NotifyQuartzChange(int phaseIndex) { }

		//// RVA: 0x1C19480 Offset: 0x1C19480 VA: 0x1C19480
		//public void NotifyQuartzBreak() { }

		//// RVA: 0x1C1965C Offset: 0x1C1965C VA: 0x1C1965C
		//public void NotifyCutinVoice() { }

		//// RVA: 0x1C19788 Offset: 0x1C19788 VA: 0x1C19788
		//public void NotifyCutinEvolve() { }

		//// RVA: 0x1C199C0 Offset: 0x1C199C0 VA: 0x1C199C0
		//public void NotifySkipLock() { }

		//// RVA: 0x1C19A00 Offset: 0x1C19A00 VA: 0x1C19A00
		//public void NotifySkipUnlock() { }

		//// RVA: 0x1C1982C Offset: 0x1C1982C VA: 0x1C1982C
		//public void NotifyQuartzRotateS6() { }

		//// RVA: 0x1C198AC Offset: 0x1C198AC VA: 0x1C198AC
		//public void NotifyLastStarS6() { }

		// RVA: 0x1C1C4B8 Offset: 0x1C1C4B8 VA: 0x1C1C4B8
		public void RequestSkip()
		{
			if(m_skipLockCount < 1)
			{
				switch(m_currentPhase)
				{
					case Phase.Quartz:
						DoSkipFade(s_skipFadeColor, OnEndStoneMain);
						break;
					case Phase.Cutin:
						DoSkipFade(s_skipFadeColor, () =>
						{
							//0x1C1D584
							OnEndCutinMain();
							if (currentRareSet != null)
								OnEndCardSp();
							else
								OnEndCardEnter();
						});
						break;
					case Phase.Rare:
						DoSkipFade(s_skipFadeColor, () =>
						{
							//0x1C1D62C
							OnEndCardSp();
							OnEndCardEnter();
						});
						break;
					case Phase.Card:
						DoSkipFade(s_skipFadeColor, OnEndCardEnter);
						break;
					case Phase.CardWait:
						DoSkipFade(s_skipFadeColor, OnEndCardWait);
						break;
					default:
						break;
				}
			}
		}

		// RVA: 0x1C1C8B0 Offset: 0x1C1C8B0 VA: 0x1C1C8B0
		public void RequestAllSkip()
		{
			if(m_currentPhase > Phase.None && m_currentPhase < Phase.Result)
			{
				DoSkipFade(s_skipFadeColor, () =>
				{
					//0x1C1D648
					if (onEndAllCallback != null)
						onEndAllCallback();
					m_startSet.End();
					m_trailSet.End();
					m_quartzSet.End();
					m_cutinSet.End();
					if(currentRareSet != null)
						currentRareSet.End();
					m_cardSet.End();
					m_cardFrame.End();
					GoToResult();
				});
			}
		}

		// RVA: 0x1C1C9B8 Offset: 0x1C1C9B8 VA: 0x1C1C9B8
		public void DoExit()
		{
			isIgnoreEventFade = true;
		}

		//// RVA: 0x1C1C9C4 Offset: 0x1C1C9C4 VA: 0x1C1C9C4
		private void OnEndAuraEnter()
		{
			m_isEndIntro = true;
			if (onEndIntroCallback != null)
				onEndIntroCallback();
		}

		//// RVA: 0x1C1C9E4 Offset: 0x1C1C9E4 VA: 0x1C1C9E4
		private void OnEndAuraLeave()
		{
			m_startSet.End();
			m_trailSet.End();
			m_quartzSet.Begin();
			m_cameraObject.Quartz_Begin();
			m_currentPhase = Phase.Quartz;
		}

		//// RVA: 0x1C1CBF4 Offset: 0x1C1CBF4 VA: 0x1C1CBF4
		private void OnEndStoneMain()
		{
			m_quartzSet.End();
			PrepareCardSet();
		}

		//// RVA: 0x1C1CDD8 Offset: 0x1C1CDD8 VA: 0x1C1CDD8
		private void OnEndCutinMain()
		{
			m_cutinSet.End();
			if(currentRareSet != null)
			{
				currentRareSet.Begin();
				m_currentPhase = Phase.Rare;
			}
			else
			{
				m_cardSet.Begin();
				m_cardFrame.Begin();
				m_currentPhase = Phase.Card;
			}
		}

		//// RVA: 0x1C1D074 Offset: 0x1C1D074 VA: 0x1C1D074
		private void OnEndCardSp()
		{
			currentRareSet.End();
			m_cardSet.Begin();
			m_cardFrame.Begin();
			m_currentPhase = Phase.Card;
		}

		//// RVA: 0x1C1D16C Offset: 0x1C1D16C VA: 0x1C1D16C
		private void OnEndCardEnter()
		{
			m_cardSet.Wait();
			m_cardFrame.Wait();
			m_currentPhase = Phase.CardWait;
		}

		//// RVA: 0x1C1D1BC Offset: 0x1C1D1BC VA: 0x1C1D1BC
		private void OnEndCardWait()
		{
			if(isLastCard)
			{
				if (onEndAllCallback != null)
					onEndAllCallback();
				m_cardSet.End();
				m_cardFrame.End();
				GoToResult();
			}
			else
			{
				m_currentCardIndex++;
				m_cardSet.End();
				m_cardFrame.End();
				PrepareCardSet();
			}
		}

		//// RVA: 0x1C1CC74 Offset: 0x1C1CC74 VA: 0x1C1CC74
		private void PrepareCardSet()
		{
			currentRareSet = null;
			if(m_rareSet != null)
			{
				Destroy(m_rareSet.gameObject);
				m_rareSet = null;
			}
			onRequestDelayLoad(directionInfo.GetCardInfo(m_currentCardIndex));
		}

		//// RVA: 0x1C1BF4C Offset: 0x1C1BF4C VA: 0x1C1BF4C
		private void StartCardSet(CardInfo cardInfo)
		{
			m_cameraObject.Card_Begin();
			m_stoneForCutin.ChangeQuartzType(cardInfo.GetLastQuartzType());
			m_cutinSet.Begin();
			m_currentPhase = Phase.Cutin;
		}

		//// RVA: 0x1C1D27C Offset: 0x1C1D27C VA: 0x1C1D27C
		private void GoToResult()
		{
			m_currentCardIndex = directionInfo.cardNum;
			m_isEndIntro = false;
			m_isInMain = false;
			currentRareSet = null;
			m_startSet.Result();
			m_cameraObject.Start_Result();
			m_currentPhase = Phase.Result;
			m_skipLockCount = 0;
		}

		//// RVA: 0x1C1C680 Offset: 0x1C1C680 VA: 0x1C1C680
		private void DoSkipFade(Color baseColor, Action onEnd)
		{
			UGUIFader fader = GameManager.Instance.fullscreenFader;
			if (fader.isFading)
			{
				fader.Fade(Mathf.Min(0.08333334f, fader.currentTime - fader.targetTime), fader.currentColor, new Color(baseColor.r, baseColor.g, baseColor.b, 1));
			}
			else
			{
				fader.Fade(0.08333334f, new Color(baseColor.r, baseColor.g, baseColor.b, 0), new Color(baseColor.r, baseColor.g, baseColor.b, 1));
			}
			this.StartCoroutineWatched(Co_WaitForSkipFade(onEnd));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x738738 Offset: 0x738738 VA: 0x738738
		//// RVA: 0x1C1D42C Offset: 0x1C1D42C VA: 0x1C1D42C
		private IEnumerator Co_WaitForSkipFade(Action onEnd)
		{
			//0x1C1D7C4
			while (GameManager.IsFading())
				yield return null;
			if (onEnd != null)
				onEnd();
		}
	}
}
