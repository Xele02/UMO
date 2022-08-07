using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace XeApp.Game
{
	public abstract class MusicDirectionParamBase : ScriptableObject
	{
		public enum SpecialDirectionType
		{
			StageLighting = 0,
			CameraClip = 1,
			DivaClip = 2,
			StagePrefab = 3,
			DivaPrefab = 4,
			PilotVoice = 5,
			DivaVoice = 6,
			VoiceChanger = 7,
			Movie = 8,
			StageChanger = 9,
			Num = 10,
		}

		[Serializable]
		public class MikeReplaceTargetData
		{
			// [TooltipAttribute] // RVA: 0x661678 Offset: 0x661678 VA: 0x661678
			public int divaId; // 0x8
			// [TooltipAttribute] // RVA: 0x6616AC Offset: 0x6616AC VA: 0x6616AC
			public int costumeModelId; // 0xC

			// RVA: 0xC93DA8 Offset: 0xC93DA8 VA: 0xC93DA8
			public bool IsFulfill(int divaId, int costumeModelId)
			{
				return (this.divaId < 1 || this.divaId == divaId) && (this.costumeModelId < 1 || this.costumeModelId == costumeModelId);
			}
		}

		[Serializable]
		public class SpecialDirectionData
		{
			// [TooltipAttribute] // RVA: 0x6616E0 Offset: 0x6616E0 VA: 0x6616E0
			public int divaId; // 0x8
			// [TooltipAttribute] // RVA: 0x661714 Offset: 0x661714 VA: 0x661714
			[FormerlySerializedAsAttribute("costumeId")]
			public int costumeModelId; // 0xC
			// [TooltipAttribute] // RVA: 0x661774 Offset: 0x661774 VA: 0x661774
			public int valkyrieId; // 0x10
			// [TooltipAttribute] // RVA: 0x6617A8 Offset: 0x6617A8 VA: 0x6617A8
			public int pilotId; // 0x14
			// [TooltipAttribute] // RVA: 0x6617DC Offset: 0x6617DC VA: 0x6617DC
			public int positionId; // 0x18
			// [TooltipAttribute] // RVA: 0x661810 Offset: 0x661810 VA: 0x661810
			public int directionGroupId; // 0x1C

			// RVA: 0xC9491C Offset: 0xC9491C VA: 0xC9491C
			public bool IsFulfill(MusicDirectionParamBase.ConditionSetting setting)
			{
				bool diva_valid = true;
				if(divaId != 0)
				{
					diva_valid = divaId == setting.divaId;
					if(divaId < 0)
					{
						diva_valid = divaId == setting.divaId || Mathf.Abs(divaId) != setting.divaId;
					}
				}
				bool costume_valid = true;
				if(costumeModelId > 0)
				{
					costume_valid = false;
					if(costumeModelId == setting.costumeModelId)
						costume_valid = true;
				}
				bool valkyrie_valid = true;
				if(valkyrieId > 0)
				{
					valkyrie_valid = false;
					if(valkyrieId == setting.valkyrieId)
						valkyrie_valid = true;
				}
				bool pilot_valid = true;
				if(pilotId > 0)
				{
					pilot_valid = false;
					if(pilotId == setting.pilotId)
						pilot_valid = true;
				}
				bool position_valid = positionId < 1 || positionId == setting.positionId;
				return diva_valid && costume_valid && valkyrie_valid && pilot_valid && position_valid;
			}

			// RVA: 0xC953A4 Offset: 0xC953A4 VA: 0xC953A4
			public bool IsFulfill(List<MusicDirectionParamBase.ConditionSetting> settingList)
			{
				if(divaId < 0 && positionId == 0)
				{
					foreach(var s in settingList)
					{
						if(Mathf.Abs(divaId) == s.divaId)
						{
							return false;
						}
					}
				}
				foreach(var s2 in settingList)
				{
					if(IsFulfill(s2))
						return true;
				}
				return false;
			}
		}
		
		public class ConditionSetting
		{
			public int divaId; // 0x8
			public int costumeModelId; // 0xC
			public int valkyrieId; // 0x10
			public int pilotId; // 0x14
			public int positionId; // 0x18
			public int groupId; // 0x1C

			// RVA: 0xC9535C Offset: 0xC9535C VA: 0xC9535C
			public ConditionSetting(int divaId = 0, int costumeModelId = 0, int valkyrieId = 0, int pilotId = 0, int positionId = 0)
			{
				this.divaId = divaId;
				this.costumeModelId = costumeModelId;
				this.valkyrieId = valkyrieId;
				this.pilotId = pilotId;
				this.positionId = positionId;
			}
		}
		
		public class ResourceData
		{
			public int id; // 0x8
			public int divaId; // 0xC

			// RVA: 0xC93C54 Offset: 0xC93C54 VA: 0xC93C54
			public ResourceData(int id, int divaId)
			{
				this.id = id;
				this.divaId = divaId;
			}
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
		public bool psylliumOverride { get { return m_psylliumOverride; } } //0xC95328
		public Color psylliumColor { get { return m_psylliumColor; } } //0xC95330
		public float mikeStandOffsetRate { get { return m_mikeStandOffsetRate; } } //0xC95340
		public virtual int basaraPositionId { get { return 1; } } //0xC95348
		public virtual MusicDirectionBoolParam BoolParam { get { return null; } set { return; } } //0xC95350 0xC95358

		// // RVA: 0xC94354 Offset: 0xC94354 VA: 0xC94354
		// public List<MusicDirectionParamBase.ResourceData> CheckFulfill(List<MusicDirectionParamBase.SpecialDirectionData> data, List<MusicDirectionParamBase.ConditionSetting> settingList) { }

		// // RVA: 0xC94AE0 Offset: 0xC94AE0 VA: 0xC94AE0
		public List<int>[] GetSpecialDirectionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			List<MusicDirectionParamBase.ResourceData>[] data = new List<MusicDirectionParamBase.ResourceData>[10];
			data[0] = CheckStageLightingResourceId(settingList);
			data[3] = CheckStageExtensionResourceId(settingList);
			data[4] = CheckDivaExtensionResourceId(settingList);
			data[2] = CheckDivaCutinResourceId(settingList);
			data[1] = CheckMusicCameraCutinResourceId(settingList);
			data[7] = CheckMusicVoiceChangerResourceId(settingList);
			data[8] = CheckSpecialMovieResourceId(settingList);
			data[9] = CheckStageChangerResourceId(settingList);
			List<int>[] res = new List<int>[10];
			for(int i = 0; i < 10; i++)
			{
				List<int> resdata = new List<int>();
				if(data[i] == null)
				{
					resdata.Add(0);
				}
				else
				{
					foreach(var d in data[i])
					{
						resdata.Add(d.id);
					}
				}
				res[i] = resdata;
			}
			return res;
		}

		// // RVA: 0xC95238 Offset: 0xC95238 VA: 0xC95238
		public bool IsEnabledDirection(MusicDirectionBoolParam.DirectionType type)
		{
			if(BoolParam != null)
			{
				return BoolParam.IsEnabledDirection(type);
			}
			return false;
		}

		// // RVA: -1 Offset: -1 Slot: 7
		public abstract bool IsUseCommonMike(int divaId, int divaModelId);

		// // RVA: -1 Offset: -1 Slot: 8
		public abstract List<MusicDirectionParamBase.ResourceData> CheckStageLightingResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 9
		public abstract List<MusicDirectionParamBase.ResourceData> CheckStageExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 10
		public abstract List<MusicDirectionParamBase.ResourceData> CheckDivaExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 11
		public abstract List<MusicDirectionParamBase.ResourceData> CheckDivaCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 12
		public abstract List<MusicDirectionParamBase.ResourceData> CheckMusicCameraCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 13
		public abstract List<MusicDirectionParamBase.ResourceData> CheckMusicVoiceChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 14
		public abstract List<MusicDirectionParamBase.ResourceData> CheckSpecialMovieResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// // RVA: -1 Offset: -1 Slot: 15
		public abstract List<MusicDirectionParamBase.ResourceData> CheckStageChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList);

		// Added for UMO
		public abstract void WriteEffectList(System.IO.StreamWriter writer, string prefix);
		protected string GetCostumeImageString(int divaId, int costumeId)
		{
			string costumeImg = "";
			costumeId = Mathf.Abs(costumeId);
			divaId = Math.Abs(divaId);
			if (costumeId != 0 && divaId != 0)
			{
				LCLCCHLDNHJ_Costume CostumeDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume;
				var cosInfo = CostumeDb.NLIBHNJNJAN(divaId, costumeId);
				if (cosInfo != null)
				{
					costumeImg = "[[/images/costumes/" + cosInfo.JPIDIENBGKH_CostumeId + ".png]] ";
				}
			}
			return costumeImg;
		}
		protected string GetNumberAsString(int number)
		{
			return number != 0 ? ""+number : "";
		}
	}
}
