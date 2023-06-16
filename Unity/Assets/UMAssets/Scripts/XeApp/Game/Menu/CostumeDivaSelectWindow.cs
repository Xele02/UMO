using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class CostumeDivaSelectWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ToggleButton[] m_divaToggleButton; // 0x14
		[SerializeField]
		private RawImageEx[] m_divaIconImages; // 0x18
		private List<int> m_divaList = new List<int>(); // 0x1C
		private bool[] m_isLoaded; // 0x20
		private bool m_isOldAllButton = true; // 0x24

		//private DFKGGBMFFGB_PlayerInfo PlayerData { get; } 0x16299C4
		public bool IsInitialized { get; private set; } // 0x25

		// RVA: 0x1629A70 Offset: 0x1629A70 VA: 0x1629A70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			for(int i = 0; i < m_divaToggleButton.Length; i++)
			{
				int index = i;
				m_divaToggleButton[i].AddOnClickCallback(() =>
				{
					//0x162A234
					if(index == 0)
					{
						if (!m_divaToggleButton[index].IsOn)
							return;
					}
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				});
			}
			return true;
		}

		//// RVA: 0x1629590 Offset: 0x1629590 VA: 0x1629590
		public void SetDivaFilterButton(List<int> divaIdList)
		{
			uint bit = 0;
			if (divaIdList.Count != 10)
			{
				for (int i = 0; i < divaIdList.Count; i++)
				{
					bit |= (uint)(1 << (divaIdList[i] - 1));
				}
			}
			SetDivaFilterButton(bit);
		}

		//// RVA: 0x1629C04 Offset: 0x1629C04 VA: 0x1629C04
		public void SetDivaFilterButton(uint bit)
		{
			if (bit == 0)
				PushFilterButton(0, m_divaToggleButton);
			m_divaToggleButton[0].SetOff();
			for(int i = 0; i < m_divaList.Count; i++)
			{
				if((bit & (1 << (m_divaList[i] - 1))) == 0)
				{
					m_divaToggleButton[i + 1].SetOff();
				}
				else
				{
					m_divaToggleButton[i + 1].SetOn();
				}
			}
		}

		//// RVA: 0x1629DD4 Offset: 0x1629DD4 VA: 0x1629DD4
		private void PushFilterButton(int index, ToggleButton[] buttons)
		{
			if(index == 0)
			{
				buttons[0].SetOn();
				for(int i = 1; i < buttons.Length; i++)
				{
					buttons[i].SetOff();
				}
			}
			else
			{
				bool need0 = true;
				for (int i = 1; i < buttons.Length; i++)
				{
					if(buttons[i].IsOn)
					{
						need0 = false;
						break;
					}
				}
				if(need0)
				{
					buttons[0].SetOn();
				}
				else
				{
					buttons[0].SetOff();
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CDDD4 Offset: 0x6CDDD4 VA: 0x6CDDD4
		//// RVA: 0x16298A0 Offset: 0x16298A0 VA: 0x16298A0
		public IEnumerator CreateDivaIcon()
		{
			//0x162A4FC
			IsInitialized = false;
			for(int i = 0; i < 10; i++)
			{
				m_divaList.Add(i + 1);
			}
			for(int i = 0; i < m_divaList.Count; i++)
			{
				m_divaToggleButton[i + 1].Hidden = true;
			}
			SetDivaFilterButton(0);
			m_isLoaded = new bool[m_divaList.Count];
			for(int i = 0; i < m_divaList.Count; i++)
			{
				m_isLoaded[i] = false;
				DivaIconLoad(m_divaList[i], 1, 0);
			}
			yield return new WaitWhile(() =>
			{
				//0x162A1B0
				for(int i = 0; i < m_isLoaded.Length; i++)
				{
					if (!m_isLoaded[i])
						return true;
				}
				return false;
			});
			IsInitialized = true;
		}

		//// RVA: 0x1629F9C Offset: 0x1629F9C VA: 0x1629F9C
		public void DivaIconLoad(int divaId, int costumeModelId, int costumeColorId)
		{
			int index = divaId - 1;
			MenuScene.Instance.DivaIconCache.Load(divaId, costumeModelId, costumeColorId, (IiconTexture texture) =>
			{
				//0x162A304
				m_divaToggleButton[index + 1].Hidden = false;
				texture.Set(m_divaIconImages[index]);
				m_isLoaded[index] = true;
			});
		}

		// RVA: 0x1628FD8 Offset: 0x1628FD8 VA: 0x1628FD8
		public void Update()
		{
			if(IsInitialized)
			{
				uint bit = 0;
				if(!m_divaToggleButton[0].IsOn || m_isOldAllButton)
				{
					for(int i = 0; i < m_divaList.Count; i++)
					{
						if(m_divaToggleButton[i + 1].IsOn)
						{
							bit |= (uint)(1 << (m_divaList[i] - 1));
						}
					}
				}
				SetDivaFilterButton(bit);
				m_isOldAllButton = m_divaToggleButton[0].IsOn;
			}
		}

		//// RVA: 0x16292D4 Offset: 0x16292D4 VA: 0x16292D4
		public List<int> GetFilterDivaIdList()
		{
			List<int> l = new List<int>();
			for(int i = 1; i < m_divaToggleButton.Length; i++)
			{
				if(m_divaToggleButton[0].IsOn)
				{
					l.Add(m_divaList[i - 1]);
				}
				else
				{
					if(m_divaToggleButton[i].IsOn)
						l.Add(m_divaList[i - 1]);
				}
			}
			return l;
		}
	}
}
