using System;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionTrailSet : GachaDirectionAnimSetBase
	{
		public enum TrailType
		{
			Left2 = 0,
			Left1 = 1,
			Center = 2,
			Right1 = 3,
			Right2 = 4,
			_Num = 5,
		}

		public enum Preset
		{
			N0 = 0,
			N1 = 1,
			N3 = 2,
			N5 = 3,
		}

		public const int TrailNum = 5;
		[SerializeField]
		private List<GameObject> m_trails; // 0x18
		private Preset m_preset; // 0x1C
		private Transform m_savedParent; // 0x20

		public Action onEndAnim { private get; set; } // 0x24

		// RVA: 0xE95774 Offset: 0xE95774 VA: 0xE95774 Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			if(directionInfo.expectLevel <= GachaDirectionOrbTable.ExpectType.LV3)
				m_preset = (Preset)directionInfo.expectLevel;
			gameObject.SetActive(false);
		}

		// RVA: 0xE957DC Offset: 0xE957DC VA: 0xE957DC
		public void Begin(Transform parent)
		{
			if(m_preset == Preset.N0)
				return;
			gameObject.SetActive(true);
			m_savedParent = transform.parent;
			transform.SetParent(parent, false);
			for(int i = 0; i < m_trails.Count; i++)
			{
				m_trails[i].SetActive(false);
			}
			WaitForAnimationEnd(() =>
			{
				//0xE95CE0
				if(onEndAnim != null)
					onEndAnim();
			});
		}

		// RVA: 0xE959AC Offset: 0xE959AC VA: 0xE959AC
		public void End()
		{
			if(m_savedParent != null)
			{
				transform.SetParent(m_savedParent, false);
				m_savedParent = null;
			}
			gameObject.SetActive(false);
		}

		// // RVA: 0xE95AB0 Offset: 0xE95AB0 VA: 0xE95AB0
		public void NotifyFly(int phaseIndex)
		{
			if(phaseIndex == 2)
			{
				if(m_preset < Preset.N5)
					return;
				m_trails[0].SetActive(true);
				m_trails[4].SetActive(true);
			}
			else if(phaseIndex == 1)
			{
				if(m_preset < Preset.N3)
					return;
				m_trails[1].SetActive(true);
				m_trails[3].SetActive(true);
			}
			else
			{
				if(phaseIndex != 0 || m_preset < Preset.N1)
					return;
				m_trails[2].SetActive(true);
			}
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_003);
		}
	}
}
