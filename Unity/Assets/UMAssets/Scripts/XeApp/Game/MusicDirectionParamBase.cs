using UnityEngine;
using System;

namespace XeApp.Game
{
	public class MusicDirectionParamBase : ScriptableObject
	{
		[Serializable]
		public class MikeReplaceTargetData
		{
			public int divaId;
			public int costumeModelId;
		}

		[Serializable]
		public class SpecialDirectionData
		{
			public int divaId;
			public int costumeModelId;
			public int valkyrieId;
			public int pilotId;
			public int positionId;
			public int directionGroupId;
		}

		//[TooltipAttribute] // RVA: 0x6614B4 Offset: 0x6614B4 VA: 0x6614B4
		[SerializeField] // RVA: 0x6614B4 Offset: 0x6614B4 VA: 0x6614B4
		protected float m_startOffsetSec; // 0xC
		//[TooltipAttribute] // RVA: 0x661534 Offset: 0x661534 VA: 0x661534
		[SerializeField] // RVA: 0x661534 Offset: 0x661534 VA: 0x661534
		protected bool m_psylliumOverride; // 0x10
		//[TooltipAttribute] // RVA: 0x6615A8 Offset: 0x6615A8 VA: 0x6615A8
		[SerializeField] // RVA: 0x6615A8 Offset: 0x6615A8 VA: 0x6615A8
		protected Color m_psylliumColor; // 0x14
		//[TooltipAttribute] // RVA: 0x661608 Offset: 0x661608 VA: 0x661608
		[SerializeField] // RVA: 0x661608 Offset: 0x661608 VA: 0x661608
		protected float m_mikeStandOffsetRate; // 0x24

		// Properties
		public float stateOffsetSec { get; }
		public bool psylliumOverride { get; }
		public Color psylliumColor { get; }
		public float mikeStandOffsetRate { get; }
		public virtual int basaraPositionId { get; }
		public virtual MusicDirectionBoolParam BoolParam { get; set; }

		// Methods

		// // RVA: 0xC94354 Offset: 0xC94354 VA: 0xC94354
		// public List<MusicDirectionParamBase.ResourceData> CheckFulfill(List<MusicDirectionParamBase.SpecialDirectionData> data, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xC94AE0 Offset: 0xC94AE0 VA: 0xC94AE0
		// public List<int>[] GetSpecialDirectionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xC95238 Offset: 0xC95238 VA: 0xC95238
		// public bool IsEnabledDirection(MusicDirectionBoolParam.DirectionType type) { }

		// // RVA: 0xC95320 Offset: 0xC95320 VA: 0xC95320
		// public float get_stateOffsetSec() { }

		// // RVA: 0xC95328 Offset: 0xC95328 VA: 0xC95328
		// public bool get_psylliumOverride() { }

		// // RVA: 0xC95330 Offset: 0xC95330 VA: 0xC95330
		// public Color get_psylliumColor() { }

		// // RVA: 0xC95340 Offset: 0xC95340 VA: 0xC95340
		// public float get_mikeStandOffsetRate() { }

		// // RVA: 0xC95348 Offset: 0xC95348 VA: 0xC95348 Slot: 4
		// public virtual int get_basaraPositionId() { }

		// // RVA: 0xC95350 Offset: 0xC95350 VA: 0xC95350 Slot: 5
		// public virtual MusicDirectionBoolParam get_BoolParam() { }

		// // RVA: 0xC95358 Offset: 0xC95358 VA: 0xC95358 Slot: 6
		// public virtual void set_BoolParam(MusicDirectionBoolParam value) { }

		// // RVA: -1 Offset: -1 Slot: 7
		// public abstract bool IsUseCommonMike(int divaId, int divaModelId);

		// // RVA: -1 Offset: -1 Slot: 8
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckStageLightingResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 9
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckStageExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 10
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckDivaExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 11
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckDivaCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 12
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckMusicCameraCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 13
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckMusicVoiceChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 14
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckSpecialMovieResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 15
		// public abstract List<MusicDirectionParamBase.ResourceData> CheckStageChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: 0xC93FC4 Offset: 0xC93FC4 VA: 0xC93FC4
		// protected void .ctor() { }
	}
}
