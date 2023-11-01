using System;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionCutinSet : GachaDirectionAnimSetBase
	{
		public enum CutinType
		{
			Default = 0,
			Long = 1,
			S6 = 2,
		}

		[Serializable]
		public class RefData
		{
			[SerializeField]
			private List<GameObject> m_gameObjects; // 0x8

			// RVA: 0x1C188A8 Offset: 0x1C188A8 VA: 0x1C188A8
			public RefData()
			{
				m_gameObjects = new List<GameObject>();
			}

			// // RVA: 0x1C1820C Offset: 0x1C1820C VA: 0x1C1820C
			public void Show()
			{
				for(int i = 0; i < m_gameObjects.Count; i++)
				{
					m_gameObjects[i].SetActive(true);
				}
			}

			// // RVA: 0x1C182EC Offset: 0x1C182EC VA: 0x1C182EC
			public void Hide()
			{
				for(int i = 0; i < m_gameObjects.Count; i++)
				{
					m_gameObjects[i].SetActive(false);
				}
			}
		}

		[Serializable]
		public class TypeChangeData
		{
			[SerializeField]
			private Cubemap quartz_Cube_map; // 0x8

			// // RVA: 0x1C18744 Offset: 0x1C18744 VA: 0x1C18744
			public void Apply(Material quartzMat)
			{
				quartzMat.SetTexture("_Cube_map", quartz_Cube_map);
			}

			// // RVA: 0x1C187C8 Offset: 0x1C187C8 VA: 0x1C187C8
			// public void Disapply() { }
		}

		[SerializeField]
		private GachaDirectionStone.RefData m_quartzRefData; // 0x18
		[SerializeField]
		private List<RefData> m_cutinRefData; // 0x1C
		[SerializeField]
		// [HeaderAttribute] // RVA: 0x686F4C Offset: 0x686F4C VA: 0x686F4C
		private List<Renderer> m_changeRenderers; // 0x20
		[SerializeField]
		private TypeChangeData m_changeToBlue; // 0x24
		[SerializeField]
		private TypeChangeData m_changeToRed; // 0x28
		[SerializeField]
		private TypeChangeData m_changeToGold; // 0x2C
		private GachaDirectionQuartzTable.QuartzType m_quartzType; // 0x30
		private bool m_useLong; // 0x34
		private Material m_quartzMaterial; // 0x38
		private List<TypeChangeData> m_changeDatas; // 0x3C
		private CutinType m_cutin_type; // 0x40
		private static readonly int State_CutinShort = Animator.StringToHash("Cutin_Short"); // 0x0
		private static readonly int State_CutinLong = Animator.StringToHash("Cutin_Long"); // 0x4
		private static readonly int State_CutinS6 = Animator.StringToHash("Cutin_S6"); // 0x8

		public Action onEndMainAnim { private get; set; } // 0x44

		// // RVA: 0x1C17E54 Offset: 0x1C17E54 VA: 0x1C17E54
		public GachaDirectionStone.RefData GetQuartzRefData()
		{
			return m_quartzRefData;
		}

		// RVA: 0x1C17E6C Offset: 0x1C17E6C VA: 0x1C17E6C Slot: 4
		protected override void OnAwake()
		{
			for(int i = 0; i < m_changeRenderers.Count; i++)
			{
				if(m_quartzMaterial == null)
					m_quartzMaterial = new Material(m_changeRenderers[i].material);
				m_changeRenderers[i].sharedMaterial = m_quartzMaterial;
			}
			m_changeDatas = new List<TypeChangeData>(3);
			m_changeDatas.Add(m_changeToBlue);
			m_changeDatas.Add(m_changeToRed);
			m_changeDatas.Add(m_changeToGold);
		}

		// // RVA: 0x1C180D0 Offset: 0x1C180D0 VA: 0x1C180D0 Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
			for(int i = 0; i < m_cutinRefData.Count; i++)
			{
				if(i == directionInfo.divaId - 1)
					m_cutinRefData[i].Show();
				else
					m_cutinRefData[i].Hide();
			}
		}

		// RVA: 0x1C183CC Offset: 0x1C183CC VA: 0x1C183CC
		public void SetQuartzType(GachaDirectionQuartzTable.QuartzType quartzType, CutinType a_cutin_type)
		{
			m_cutin_type = a_cutin_type;
			m_quartzType = quartzType;
			if(a_cutin_type > CutinType.Default && a_cutin_type <= CutinType.S6)
				quartzType = GachaDirectionQuartzTable.QuartzType.LV3_Gold;
			ChangeQuartzType(quartzType);
		}

		// RVA: 0x1C184EC Offset: 0x1C184EC VA: 0x1C184EC
		public void Begin()
		{
			gameObject.SetActive(true);
			if(m_cutin_type == CutinType.Long)
			{
				animator.Play(State_CutinLong);
			}
			else if(m_cutin_type == CutinType.S6)
			{
				animator.Play(State_CutinS6);
			}
			else
			{
				animator.Play(State_CutinShort);
			}
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_016);
			WaitForAnimationEnd(() =>
			{
				//0x1C18894
				if(onEndMainAnim != null)
					onEndMainAnim();
			});
		}

		// RVA: 0x1C1870C Offset: 0x1C1870C VA: 0x1C1870C
		public void End()
		{
			gameObject.SetActive(false);
		}

		// // RVA: 0x1C183E4 Offset: 0x1C183E4 VA: 0x1C183E4
		private void ChangeQuartzType(GachaDirectionQuartzTable.QuartzType type)
		{
			for(int i = 0; i < m_changeDatas.Count; i++)
			{
				if((int)type == i)
				{
					m_changeDatas[i].Apply(m_quartzMaterial);
				}
			}
		}
	}
}
