using XeSys.Gfx;
using System;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogGraphParts : LayoutUGUIScriptBase
	{
		public enum SizeType
		{
			None = -1,
			S = 0,
			L = 1,
			Num = 2,
		}

		public enum ModeType
		{
			None = -1,
			Normal = 0,
			Valkyrie = 1,
			Diva1 = 2,
			Diva2 = 3,
			Num = 4,
		}

		[Serializable]
		public class PartsData
		{
			[Serializable]
			public class ModeParts
			{
				public GameObject icon; // 0x8
				public GameObject line; // 0xC
			}
	
			public ModeParts[] mode_parts = new ModeParts[4]; // 0x8
			public GameObject division_line; // 0xC
			public GameObject skill_icon; // 0x10

			//// RVA: 0x1D07790 Offset: 0x1D07790 VA: 0x1D07790
			//public void Init() { }

			//// RVA: 0x1D07854 Offset: 0x1D07854 VA: 0x1D07854
			public void SetActive(bool is_active)
			{
				for(int i = 0; i < mode_parts.Length; i++)
				{
					if (mode_parts[i].icon != null)
					{
						mode_parts[i].icon.SetActive(is_active);
					}
					if (mode_parts[i].line != null)
					{
						mode_parts[i].line.SetActive(is_active);
					}
				}
				if(division_line != null)
				{
					division_line.SetActive(is_active);
				}
				if(skill_icon != null)
				{
					skill_icon.SetActive(is_active);
				}
			}
		}
		
		public PartsData[] m_PartsData = new PartsData[2]; // 0x14

		// RVA: 0x1D076E0 Offset: 0x1D076E0 VA: 0x1D076E0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			for(int i = 0; i < 2; i++)
			{
				m_PartsData[i].SetActive(false);
			}
			gameObject.SetActive(false);
			return true;
		}

		// RVA: 0x1D07798 Offset: 0x1D07798 VA: 0x1D07798
		public PartsData GetPartsData(SizeType type)
		{
			return m_PartsData[(int)type];
		}
	}
}
