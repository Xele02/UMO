using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfo : MonoBehaviour
	{
		[Serializable]
		private class DivaInfo
		{
			//[TooltipAttribute] // RVA: 0x68431C Offset: 0x68431C VA: 0x68431C
			[SerializeField]
			public SetDeckDivaCardControl m_divaControl; // 0x8
			[SerializeField]
			//[TooltipAttribute] // RVA: 0x684370 Offset: 0x684370 VA: 0x684370
			public SetDeckSceneSetControl m_sceneSetControl; // 0xC
		}

		public delegate void EventOnClickDiva(int divaSlotNumber, FFHPBEPOMAK divaData);
		public delegate void EventOnClickCostume(int divaSlotNumber, FFHPBEPOMAK divaData);
		public delegate void EventOnClickScene(int divaSlotNumber, int sceneSlotNumber, FFHPBEPOMAK divaData, GCIJNCFDNON sceneData);

		//[TooltipAttribute] // RVA: 0x684144 Offset: 0x684144 VA: 0x684144
		[SerializeField]
		private SetDeckUnitInfoAnimeControl m_animeControl; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68418C Offset: 0x68418C VA: 0x68418C
		private List<DivaInfo> m_divaInfos; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6841DC Offset: 0x6841DC VA: 0x6841DC
		private List<SetDeckDivaCardControl> m_additionDivas; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684224 Offset: 0x684224 VA: 0x684224
		private SetDeckAssistCardControl m_assist; // 0x18
		//[TooltipAttribute] // RVA: 0x68427C Offset: 0x68427C VA: 0x68427C
		[SerializeField]
		private SetDeckUnitInfoMessageControl m_messageControl; // 0x1C
		//[TooltipAttribute] // RVA: 0x6842D4 Offset: 0x6842D4 VA: 0x6842D4
		[SerializeField]
		private GameObject m_tapGuardObject; // 0x20
		public EventOnClickDiva OnClickDiva; // 0x24
		public EventOnClickDiva OnStayDiva; // 0x28
		public EventOnClickCostume OnClickCostume; // 0x2C
		public EventOnClickScene OnClickScene; // 0x30
		public EventOnClickScene OnStayScene; // 0x34

		public SetDeckUnitInfoAnimeControl AnimeControl { get { return m_animeControl; } } //0xC30B88
		public bool ExistAssistControl { get { return m_assist != null; } } //0xC30B90
		public SetDeckAssistCardControl AssistControl { get { return m_assist; } } //0xC30C1C
		//public bool ExistMessageControl { get; } 0xC30C24
		//public SetDeckUnitInfoMessageControl MessageControl { get; } 0xC30CB0
		//public UGUIStayButton CenterMainSceneButton { get; } 0xC30CB8
		//public UGUIStayButton SecondDivaButton { get; } 0xC30DB8

		// RVA: 0xC30E68 Offset: 0xC30E68 VA: 0xC30E68
		private void Awake()
		{
			SetTapGuard(false);
			int i = 0;
			foreach(var d in m_divaInfos)
			{
				if (i > 2)
					break;
				int tmpDivaSlotNumber = i;
				if (d.m_divaControl != null)
				{
					d.m_divaControl.OnClickDivaButton = () => 
					{
						//0xC34910
						OnClickDivaButton(tmpDivaSlotNumber);
					};
					d.m_divaControl.OnStayDivaButton = () =>
					{
						//0xC34940
						OnStayDivaButton(tmpDivaSlotNumber);
					};
					d.m_divaControl.OnClickCostumeButton = () =>
					{
						//0xC34970
						OnClickCostumeButton(tmpDivaSlotNumber);
					};
				}
				if(d.m_sceneSetControl != null)
				{
					int tmpSceneSlotNumber = 0;
					foreach (var s in d.m_sceneSetControl.Scenes)
					{
						s.OnClickSceneButton = () =>
						{
							//0xC349A0
							OnClickSceneButton(tmpDivaSlotNumber, tmpSceneSlotNumber);
						};
						s.OnStaySceneButton = () =>
						{
							//0xC349D4
							OnStaySceneButton(tmpDivaSlotNumber, tmpSceneSlotNumber);
						};
						tmpSceneSlotNumber++;
					}
				}
				i++;
			}
			foreach(var d in m_additionDivas)
			{
				int tmpDivaSlotNumber = i;
				if (d != null)
				{
					d.OnClickDivaButton = () =>
					{
						//0xC34A08
						OnClickDivaButton(tmpDivaSlotNumber);
					};
					d.OnStayDivaButton = () =>
					{
						//0xC34A38
						OnStayDivaButton(tmpDivaSlotNumber);
					};
					d.OnClickCostumeButton = () =>
					{
						//0xC34A68
						OnClickCostumeButton(tmpDivaSlotNumber);
					};
				}
				i++;
			}
		}

		//// RVA: 0xC318F8 Offset: 0xC318F8 VA: 0xC318F8
		//public void UpdateContent(DFKGGBMFFGB viewPlayerData, JLKEOGLJNOD viewUnitData, SetDeckParamCalculator paramCalculator, EEDKAACNBBG viewMusicData, GameSetupData.MusicInfo musicInfo, bool isGoDiva) { }

		//// RVA: 0xC32AEC Offset: 0xC32AEC VA: 0xC32AEC
		//public void SetStatusDisplayType(SortItem divaItem, SortItem sceneItem) { }

		//// RVA: 0xC32EF0 Offset: 0xC32EF0 VA: 0xC32EF0
		//public bool IsUpdatingContent() { }

		//// RVA: 0xC31824 Offset: 0xC31824 VA: 0xC31824
		public void SetTapGuard(bool isEnable)
		{
			if(m_tapGuardObject != null)
			{
				m_tapGuardObject.SetActive(isEnable);
			}
		}

		//// RVA: 0xC335A8 Offset: 0xC335A8 VA: 0xC335A8
		private void OnClickDivaButton(int divaSlotNumber)
		{
			if(OnClickDiva != null)
			{
				OnClickDiva(divaSlotNumber, GetDivaDataBySlotNumber(divaSlotNumber));
			}
		}

		//// RVA: 0xC33C54 Offset: 0xC33C54 VA: 0xC33C54
		private void OnStayDivaButton(int divaSlotNumber)
		{
			if(OnStayDiva != null)
			{
				OnStayDiva(divaSlotNumber, GetDivaDataBySlotNumber(divaSlotNumber));
			}
		}

		//// RVA: 0xC33CA8 Offset: 0xC33CA8 VA: 0xC33CA8
		private void OnClickCostumeButton(int divaSlotNumber)
		{
			if(OnClickCostume != null)
			{
				OnClickCostume(divaSlotNumber, GetDivaDataBySlotNumber(divaSlotNumber));
			}
		}

		//// RVA: 0xC34180 Offset: 0xC34180 VA: 0xC34180
		private void OnClickSceneButton(int divaSlotNumber, int sceneSlotNumber)
		{
			if(OnClickScene != null)
			{
				OnClickScene(divaSlotNumber, sceneSlotNumber, GetDivaDataBySlotNumber(divaSlotNumber), GetSceneDataBySlotNumber(divaSlotNumber, sceneSlotNumber));
			}
		}

		//// RVA: 0xC3488C Offset: 0xC3488C VA: 0xC3488C
		private void OnStaySceneButton(int divaSlotNumber, int sceneSlotNumber)
		{
			if(OnStayScene != null)
			{
				OnStayScene(divaSlotNumber, sceneSlotNumber, GetDivaDataBySlotNumber(divaSlotNumber), GetSceneDataBySlotNumber(divaSlotNumber, sceneSlotNumber));
			}
		}

		//// RVA: 0xC335FC Offset: 0xC335FC VA: 0xC335FC
		private FFHPBEPOMAK GetDivaDataBySlotNumber(int divaSlotNumber)
		{
			if(m_divaInfos != null)
			{
				if(divaSlotNumber < 3 && divaSlotNumber < m_divaInfos.Count)
				{
					if (m_divaInfos[divaSlotNumber] == null)
						return null;
					if (m_divaInfos[divaSlotNumber].m_divaControl == null)
						return null;
					return m_divaInfos[divaSlotNumber].m_divaControl.DivaData;
				}
				divaSlotNumber -= 3;
			}
			if (m_additionDivas != null && divaSlotNumber < m_additionDivas.Count)
			{
				if (m_additionDivas[divaSlotNumber] == null)
					return null;
				return m_additionDivas[divaSlotNumber].DivaData;
			}
			return null;
		}

		//// RVA: 0xC341FC Offset: 0xC341FC VA: 0xC341FC
		private GCIJNCFDNON GetSceneDataBySlotNumber(int divaSlotNumber, int sceneSlotNumber)
		{
			if(m_divaInfos != null && divaSlotNumber < m_divaInfos.Count)
			{
				if(m_divaInfos[divaSlotNumber] != null && m_divaInfos[divaSlotNumber].m_sceneSetControl != null)
				{
					if(sceneSlotNumber < m_divaInfos[divaSlotNumber].m_sceneSetControl.Scenes.Count)
					{
						if(m_divaInfos[divaSlotNumber].m_sceneSetControl.Scenes[sceneSlotNumber] != null)
						{
							return m_divaInfos[divaSlotNumber].m_sceneSetControl.Scenes[sceneSlotNumber].SceneData;
						}
					}
				}
			}
			return null;
		}

		//// RVA: 0xC32884 Offset: 0xC32884 VA: 0xC32884
		//private void SetMultiIconMemberCount(int memberCount) { }
	}
}
