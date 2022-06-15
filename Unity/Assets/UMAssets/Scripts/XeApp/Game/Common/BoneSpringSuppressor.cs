using System.Collections.Generic;

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
			//protected BoneSpringControlPoint m_point; // 0x8
			protected float m_influenceRate; // 0xC
			protected float m_savedInfluence; // 0x10

			// // RVA: 0xE635E4 Offset: 0xE635E4 VA: 0xE635E4
			// public void .ctor(BoneSpringControlPoint point, BoneSpringSuppressParam.TargetData data) { }

			// // RVA: 0xE6367C Offset: 0xE6367C VA: 0xE6367C Slot: 4
			// public virtual void ApplyValue(float suppressValue) { }
		}

		public class BindDataWind : BindData
		{
			// // RVA: 0xE635E0 Offset: 0xE635E0 VA: 0xE635E0
			// public void .ctor(BoneSpringControlPoint point, BoneSpringSuppressParam.TargetData data) { }

			// // RVA: 0xE636C0 Offset: 0xE636C0 VA: 0xE636C0 Slot: 4
			// public override void ApplyValue(float suppressValue) { }
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
		// public void Load(GameObject root, BoneSpringSuppressParam param, BoneSpringSuppressor.Preset preset) { }

		// // RVA: 0xE63638 Offset: 0xE63638 VA: 0xE63638
		// public void Unload() { }

		// // RVA: 0xE61EFC Offset: 0xE61EFC VA: 0xE61EFC
		// public void SetSuppressValue(float suppressValue) { }

		// // RVA: 0xE61F04 Offset: 0xE61F04 VA: 0xE61F04
		// public void UpdateSuppress() { }

		// // RVA: 0xE63644 Offset: 0xE63644 VA: 0xE63644
		// private static bool CheckEquivalent(float checkValue, float baseValue, float epsilon) { }
	}
}
