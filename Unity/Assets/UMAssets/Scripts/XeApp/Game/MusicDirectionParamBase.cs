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
		protected Color m_psylliumColor = new Color(1.0f, 1.0f, 1.0f, 1.0f); // 0x14
		//[TooltipAttribute] // RVA: 0x661608 Offset: 0x661608 VA: 0x661608
		[SerializeField] // RVA: 0x661608 Offset: 0x661608 VA: 0x661608
		protected float m_mikeStandOffsetRate = 1.0f; // 0x24

		public float stateOffsetSec { get { return m_startOffsetSec; } } //0xC95320
		// public bool psylliumOverride { get; } 0xC95328
		// public Color psylliumColor { get; } 0xC95330
		// public float mikeStandOffsetRate { get; } 0xC95340
		// public virtual int basaraPositionId { get; } 0xC95348
		// public virtual MusicDirectionBoolParam BoolParam { get; set; } 0xC95350 0xC95358

		// // RVA: 0xC94354 Offset: 0xC94354 VA: 0xC94354
		// public List<MusicDirectionParamBase.ResourceData> CheckFulfill(List<MusicDirectionParamBase.SpecialDirectionData> data, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xC94AE0 Offset: 0xC94AE0 VA: 0xC94AE0
		// public List<int>[] GetSpecialDirectionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xC95238 Offset: 0xC95238 VA: 0xC95238
		// public bool IsEnabledDirection(MusicDirectionBoolParam.DirectionType type) { }

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
	}
}
