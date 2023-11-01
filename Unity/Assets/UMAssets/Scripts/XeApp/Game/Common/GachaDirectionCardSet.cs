using System;
using UnityEngine;
using System.Collections.Generic;
using mcrs;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardSet : GachaDirectionAnimSetBase
	{
		[Serializable]
		private class AttributeSetting
		{
			[SerializeField]
			private Transform m_nameRoot; // 0x8
			[SerializeField]
			private List<GameObject> m_objects; // 0xC

			public Transform nameRoot { get { return m_nameRoot; } } //0x1C17204

			// // RVA: 0x1C1720C Offset: 0x1C1720C VA: 0x1C1720C
			public void Activate()
			{
				for(int i = 0; i < m_objects.Count; i++)
				{
					m_objects[i].SetActive(true);
				}
			}

			// // RVA: 0x1C17124 Offset: 0x1C17124 VA: 0x1C17124
			public void Deactivate()
			{
				for(int i = 0; i < m_objects.Count; i++)
				{
					m_objects[i].SetActive(false);
				}
			}
		}

		private static readonly int State_EnterS6 = Animator.StringToHash("Card_EnterS6"); // 0x0
		private static readonly int State_EnterS5 = Animator.StringToHash("Card_EnterS5"); // 0x4
		private static readonly int State_EnterS4 = Animator.StringToHash("Card_EnterS4"); // 0x8
		private static readonly int State_EnterS3 = Animator.StringToHash("Card_EnterS3"); // 0xC
		private static readonly int State_EnterS2 = Animator.StringToHash("Card_EnterS2"); // 0x10
		private static readonly int State_EnterS1 = Animator.StringToHash("Card_EnterS1"); // 0x14
		private static readonly int State_IdleS6 = Animator.StringToHash("Card_IdleS6"); // 0x18
		private static readonly int State_IdleS5 = Animator.StringToHash("Card_IdleS5"); // 0x1C
		private static readonly int State_IdleS4 = Animator.StringToHash("Card_IdleS4"); // 0x20
		private static readonly int State_IdleS3 = Animator.StringToHash("Card_IdleS3"); // 0x24
		private static readonly int State_IdleS2 = Animator.StringToHash("Card_IdleS2"); // 0x28
		private static readonly int State_IdleS1 = Animator.StringToHash("Card_IdleS1"); // 0x2C
		private static readonly int State_AttrHoshi = Animator.StringToHash("attribute_HOSHI"); // 0x30
		private static readonly int State_AttrAi = Animator.StringToHash("attribute_AI"); // 0x34
		private static readonly int State_AttrInochi = Animator.StringToHash("attribute_INOCHI"); // 0x38
		private static readonly int State_AttrMu = Animator.StringToHash("attribute_MU"); // 0x3C
		private static readonly int State_SeriesFirst = Animator.StringToHash("card_IP_macross"); // 0x40
		private static readonly int State_SeriesFrontier = Animator.StringToHash("card_IP_frontier"); // 0x44
		private static readonly int State_SeriesSeven = Animator.StringToHash("card_IP_seven"); // 0x48
		private static readonly int State_SeriesDelta = Animator.StringToHash("card_IP_delta"); // 0x4C
		private static readonly int State_SeriesPlus = Animator.StringToHash("card_IP_puls"); // 0x50
		[SerializeField]
		private List<Renderer> m_cardRenderers; // 0x18
		[SerializeField]
		private Animator m_cardNamePlateAnimator; // 0x1C
		[SerializeField]
		private Animator m_cardSeriesAnimator; // 0x20
		[SerializeField]
		private List<Transform> m_cardFrameParents; // 0x24
		[SerializeField]
		private AttributeSetting m_attrHoshi; // 0x28
		[SerializeField]
		private AttributeSetting m_attrAi; // 0x2C
		[SerializeField]
		private AttributeSetting m_attrInochi; // 0x30
		[SerializeField]
		private AttributeSetting m_attrZen; // 0x34

		public Action onEndEnterAnim { private get; set; } // 0x38
		public Action onEndWaitAnim { private get; set; } // 0x3C
		private int stateEnter { get; set; } // 0x40
		private int stateIdle { get; set; } // 0x44
		private int cardNameAttrState { get; set; } // 0x48
		private Transform cardNameRoot { get; set; } // 0x4C
		private Transform cardFrameRoot { get; set; } // 0x50
		private int cardSeriesState { get; set; } // 0x54
		private int waitStateSeId { get; set; } // 0x58

		// // RVA: 0x1C16B78 Offset: 0x1C16B78 VA: 0x1C16B78 Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1C16BB0 Offset: 0x1C16BB0 VA: 0x1C16BB0
		public void SetCardStarNum(int starNum)
		{
			switch(starNum - 1)
			{
				case 0:
					stateEnter = State_EnterS1;
					waitStateSeId = 14;
					stateIdle = State_IdleS1;
					break;
				case 1:
					stateEnter = State_EnterS2;
					waitStateSeId = 14;
					stateIdle = State_IdleS2;
					break;
				case 2:
					stateEnter = State_EnterS3;
					waitStateSeId = 14;
					stateIdle = State_IdleS3;
					break;
				case 3:
					stateEnter = State_EnterS4;
					waitStateSeId = 13;
					stateIdle = State_IdleS4;
					break;
				case 4:
					stateEnter = State_EnterS5;
					waitStateSeId = 12;
					stateIdle = State_IdleS5;
					break;
				case 5:
					stateEnter = State_EnterS6;
					waitStateSeId = 25;
					stateIdle = State_IdleS6;
					break;
				default:
					break;
			}
			cardFrameRoot = m_cardFrameParents[starNum - 1];
		}

		// RVA: 0x1C16E78 Offset: 0x1C16E78 VA: 0x1C16E78
		public void SetCardAttribute(int attrId)
		{
			m_attrHoshi.Deactivate();
			m_attrAi.Deactivate();
			m_attrInochi.Deactivate();
			m_attrZen.Deactivate();
			switch(attrId)
			{
				case 1:
					cardNameAttrState = State_AttrHoshi;
					cardNameRoot = m_attrHoshi.nameRoot;
					m_attrHoshi.Activate();
					break;
				case 2:
					cardNameAttrState = State_AttrAi;
					cardNameRoot = m_attrAi.nameRoot;
					m_attrAi.Activate();
					break;
				case 3:
					cardNameAttrState = State_AttrInochi;
					cardNameRoot = m_attrInochi.nameRoot;
					m_attrInochi.Activate();
					break;
				case 4:
					cardNameAttrState = State_AttrMu;
					cardNameRoot = m_attrZen.nameRoot;
					m_attrZen.Activate();
					break;
				default:
					break;
			}
		}

		// RVA: 0x1C172EC Offset: 0x1C172EC VA: 0x1C172EC
		public void SetCardSeries(int seriesId)
		{
			switch(seriesId)
			{
				case 1:
					cardSeriesState = State_SeriesDelta;
					break;
				case 2:
					cardSeriesState = State_SeriesFrontier;
					break;
				case 3:
					cardSeriesState = State_SeriesSeven;
					break;
				case 4:
					cardSeriesState = State_SeriesFirst;
					break;
				case 5:
					cardSeriesState = State_SeriesPlus;
					break;
				default:
					break;
			}
		}

		// RVA: 0x1C174D8 Offset: 0x1C174D8 VA: 0x1C174D8
		public void ApplyCardTexture(Texture texture)
		{
			for(int i = 0; i < m_cardRenderers.Count; i++)
			{
				m_cardRenderers[i].material.SetTexture("_MainTex", texture);
			}
		}

		// RVA: 0x1C175F4 Offset: 0x1C175F4 VA: 0x1C175F4
		public void ApplyCardMaterial(Material material)
		{
			for(int i = 0; i < m_cardRenderers.Count; i++)
			{
				m_cardRenderers[i].material = material;
			}
		}

		// RVA: 0x1C176D8 Offset: 0x1C176D8 VA: 0x1C176D8
		public void SetCardNameParent(Transform cardNameTransform)
		{
			cardNameTransform.SetParent(cardNameRoot, false);
		}

		// RVA: 0x1C17710 Offset: 0x1C17710 VA: 0x1C17710
		public void SetCardFrameParent(Transform cardFrameTransform)
		{
			cardFrameTransform.SetParent(cardFrameRoot, false);
		}

		// RVA: 0x1C17748 Offset: 0x1C17748 VA: 0x1C17748
		public void Begin()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_011);
			gameObject.SetActive(true);
			animator.Play(stateEnter, 0, 0);
			WaitForAnimationEnd(() =>
			{
				//0x1C17E24
				if(onEndEnterAnim != null)
					onEndEnterAnim();
			});
			m_cardSeriesAnimator.gameObject.SetActive(false);
		}

		// RVA: 0x1C178D4 Offset: 0x1C178D4 VA: 0x1C178D4
		public void Wait()
		{
			SoundManager.Instance.sePlayerGacha.Play(waitStateSeId);
			animator.Play(stateIdle, 0, 0);
			WaitForAnimationEnd(() =>
			{
				//0x1C17E38
				if(onEndWaitAnim != null)
					onEndWaitAnim();
			});
			m_cardNamePlateAnimator.Play(cardNameAttrState, 0, 0);
			m_cardSeriesAnimator.gameObject.SetActive(true);
			m_cardSeriesAnimator.Play(cardSeriesState, 0, 0);
		}

		// RVA: 0x1C17A9C Offset: 0x1C17A9C VA: 0x1C17A9C
		public void End()
		{
			gameObject.SetActive(false);
		}
	}
}
