using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Common
{
	public class BoneSpringSuppressor
	{
		public enum Preset
		{
			preset01 = 0,
			preset02 = 1,
			preset03 = 2,
			preset04 = 3,
			preset05 = 4,
			preset06 = 5,
			preset07 = 6,
			preset08 = 7,
			preset09 = 8,
			preset10 = 9,
			preset11_Wind = 10,
			preset12 = 11,
			preset13 = 12,
			preset14 = 13,
			preset15 = 14,
			preset16 = 15,
			preset17 = 16,
			preset18 = 17,
			preset19 = 18,
			preset20 = 19,
			preset21 = 20,
			preset22 = 21,
			preset23 = 22,
			preset24 = 23,
			preset25 = 24,
			preset26 = 25,
			preset27 = 26,
			preset28 = 27,
			preset29 = 28,
			preset30 = 29,
			_Num = 30,
		}

		public class BindData
		{
			protected BoneSpringControlPoint m_point; // 0x8
			protected float m_influenceRate; // 0xC
			protected float m_savedInfluence; // 0x10

			// // RVA: 0xE635E4 Offset: 0xE635E4 VA: 0xE635E4
			public BindData(BoneSpringControlPoint point, BoneSpringSuppressParam.TargetData data)
			{
				m_point = point;
				m_savedInfluence = point.influence;
				m_influenceRate = data.influenceRate;
			}

			// // RVA: 0xE6367C Offset: 0xE6367C VA: 0xE6367C Slot: 4
			public virtual void ApplyValue(float suppressValue)
			{
				m_point.influenceSuppressRate = m_influenceRate * suppressValue;
			}
		}

		public class BindDataWind : BindData
		{
			// // RVA: 0xE635E0 Offset: 0xE635E0 VA: 0xE635E0
			public BindDataWind(BoneSpringControlPoint point, BoneSpringSuppressParam.TargetData data)
				: base(point, data)
			{
				return;
			}

			// // RVA: 0xE636C0 Offset: 0xE636C0 VA: 0xE636C0 Slot: 4
			public override void ApplyValue(float suppressValue)
			{
				m_point.influenceSuppressRateWind = m_influenceRate * suppressValue;
			}
		}

		public const int PresetNum = 30;
		private const float SUPPRESS_VALUE_EPSILON = 0.001f;
		private bool m_isReady; // 0x8
		private BoneSpringSuppressParam m_param; // 0xC
		private List<BindData> m_bindDatas; // 0x10
		private float m_suppressValue; // 0x14
		private bool m_isSuppressing; // 0x18
		private Preset m_preset = Preset._Num; // 0x1C

		// // RVA: 0xE627A0 Offset: 0xE627A0 VA: 0xE627A0
		public void Load(GameObject root, BoneSpringSuppressParam param, BoneSpringSuppressor.Preset preset)
		{
			m_param = param;
			m_preset = preset;
			if(m_bindDatas == null)
			{
				m_bindDatas = new List<BindData>(param.targetCount);
			}
			else
			{
				m_bindDatas.Clear();
				m_bindDatas.Capacity = m_param.targetCount;
			}
			BoneSpringController ctrl = root.GetComponentInChildren<BoneSpringController>();
			for(int i = 0; i < m_param.targetCount; i++)
			{
				BoneSpringSuppressParam.TargetData data = m_param.GetTargetData(i);
				Transform t = ctrl.gameObject.transform.Find(data.pointPath);
				if(t == null)
				{
					TodoLogger.LogError(TodoLogger.Game, "Point not found : "+data.pointPath);
				}
				else
				{
					BoneSpringControlPoint ctrlPoint = t.GetComponent<BoneSpringControlPoint>();
					if(ctrlPoint == null)
					{
						TodoLogger.LogError(TodoLogger.Game, "Component CtrlPoint not found on "+data.pointPath);
					}
					else
					{
						if(m_preset == Preset.preset11_Wind)
						{
							m_bindDatas.Add(new BindDataWind(ctrlPoint, data));
						}
						else
						{
							m_bindDatas.Add(new BindData(ctrlPoint, data));
						}
					}
				}
			}
			m_suppressValue = 0;
			m_isReady = true;
			m_isSuppressing = false;
		}

		// // RVA: 0xE63638 Offset: 0xE63638 VA: 0xE63638
		// public void Unload() { }

		// // RVA: 0xE61EFC Offset: 0xE61EFC VA: 0xE61EFC
		public void SetSuppressValue(float suppressValue)
		{
			m_suppressValue = suppressValue;
		}

		// // RVA: 0xE61F04 Offset: 0xE61F04 VA: 0xE61F04
		public void UpdateSuppress()
		{
			if(m_isReady)
			{
				for(int i = 0; i < m_bindDatas.Count; i++)
				{
					m_bindDatas[i].ApplyValue(m_suppressValue);
				}
			}
		}

		// // RVA: 0xE63644 Offset: 0xE63644 VA: 0xE63644
		// private static bool CheckEquivalent(float checkValue, float baseValue, float epsilon) { }
	}
}
