using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game
{
	public class MusicDirectionParamList : MusicDirectionParamBase
	{
		[Serializable]
		public class MikeReplaceTargetDataList
		{
			// [TooltipAttribute] // RVA: 0x661B30 Offset: 0x661B30 VA: 0x661B30
			public List<MusicDirectionParamBase.MikeReplaceTargetData> m_mikeReplaceTargetDataList = new List<MikeReplaceTargetData>(); // 0x8

			// RVA: 0xC968DC Offset: 0xC968DC VA: 0xC968DC
			public bool IsFulfill(int divaId, int costumeModelId)
			{
				if(m_mikeReplaceTargetDataList.Count == 0)
					return false;
				foreach(var m in m_mikeReplaceTargetDataList)
				{
					if((m.divaId > 0 && m.divaId != divaId) || (m.costumeModelId > 0 && m.costumeModelId != costumeModelId))
						return false;
				}
				return true;
			}
		}

		[Serializable]
		public class SpecialDirectionDataList
		{
			// [TooltipAttribute] // RVA: 0x661B64 Offset: 0x661B64 VA: 0x661B64
			public int m_bundleId; // 0x8
			// [TooltipAttribute] // RVA: 0x661B98 Offset: 0x661B98 VA: 0x661B98
			public int m_resourceGroupId; // 0xC
			// [TooltipAttribute] // RVA: 0x661BCC Offset: 0x661BCC VA: 0x661BCC
			public int m_attachDivaId; // 0x10
			// [TooltipAttribute] // RVA: 0x661C00 Offset: 0x661C00 VA: 0x661C00
			public List<MusicDirectionParamBase.SpecialDirectionData> m_specialDirectionDataList = new List<SpecialDirectionData>(); // 0x14

			// RVA: 0xC96008 Offset: 0xC96008 VA: 0xC96008
			public List<MusicDirectionParamBase.SpecialDirectionData> CheckFulfill(List<MusicDirectionParamBase.ConditionSetting> settingList)
			{
				List<MusicDirectionParamBase.SpecialDirectionData> res = new List<MusicDirectionParamBase.SpecialDirectionData>();
				List<MusicDirectionParamBase.ResourceData> resourceList = new List<ResourceData>();
				if(m_specialDirectionDataList.Count != 0)
				{
					Dictionary<int,bool> dict = new Dictionary<int, bool>();
					foreach(var s in m_specialDirectionDataList) //LAB_00c96188
					{
						if(dict.ContainsKey(s.directionGroupId))//LAB_00c96238
						{
							//goto code_r0x00c96254;
							if(dict[s.directionGroupId])
							{
								if(s.IsFulfill(settingList))
								{
									res.Add(s);
									dict[s.directionGroupId] = true;
								}
								else
								{
									dict[s.directionGroupId] = false;
								}
							}
						}
						else
						{
							//goto LAB_00c962f4;
							if(s.IsFulfill(settingList))
							{
								res.Add(s);
								dict[s.directionGroupId] = true;
							}
							else
							{
								dict[s.directionGroupId] = false;
							}
						}
					}
					foreach(var k in dict)
					{
						if(k.Value)
						{
							return res;
						}
					}
				}
				return null;
			}
		}

		// [TooltipAttribute] // RVA: 0x661844 Offset: 0x661844 VA: 0x661844
		[SerializeField]
		private int m_basaraPositionId = 1; // 0x28
		// [TooltipAttribute] // RVA: 0x6618A8 Offset: 0x6618A8 VA: 0x6618A8
		[SerializeField]
		private List<MusicDirectionParamList.MikeReplaceTargetDataList> m_mikeReplaceTargetList = new List<MikeReplaceTargetDataList>(); // 0x2C
		// [TooltipAttribute] // RVA: 0x6618F0 Offset: 0x6618F0 VA: 0x6618F0
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stageLightingList = new List<SpecialDirectionDataList>(); // 0x30
		// [TooltipAttribute] // RVA: 0x661938 Offset: 0x661938 VA: 0x661938
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_cameraClipList = new List<SpecialDirectionDataList>(); // 0x34
		// [TooltipAttribute] // RVA: 0x661980 Offset: 0x661980 VA: 0x661980
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_divaClipList = new List<SpecialDirectionDataList>(); // 0x38
		// [TooltipAttribute] // RVA: 0x6619C8 Offset: 0x6619C8 VA: 0x6619C8
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stagePrefabList = new List<SpecialDirectionDataList>(); // 0x3C
		[SerializeField]
		// [TooltipAttribute] // RVA: 0x661A10 Offset: 0x661A10 VA: 0x661A10
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_divaPrefabList = new List<SpecialDirectionDataList>(); // 0x40
		// [TooltipAttribute] // RVA: 0x661A58 Offset: 0x661A58 VA: 0x661A58
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_voiceChangerList = new List<SpecialDirectionDataList>(); // 0x44
		// [TooltipAttribute] // RVA: 0x661AA0 Offset: 0x661AA0 VA: 0x661AA0
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_movieList = new List<SpecialDirectionDataList>(); // 0x48
		// [TooltipAttribute] // RVA: 0x661AE8 Offset: 0x661AE8 VA: 0x661AE8
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stageChangerList = new List<SpecialDirectionDataList>(); // 0x4C

		public override int basaraPositionId { get { return m_basaraPositionId; } } //0xC96B28

		// RVA: 0xC956CC Offset: 0xC956CC VA: 0xC956CC
		private List<MusicDirectionParamBase.ResourceData> CheckCondition(List<MusicDirectionParamList.SpecialDirectionDataList> data, List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			List<MusicDirectionParamBase.ResourceData> res = new List<ResourceData>();
			List<int> groupIds = new List<int>();
			for(int i = 0; i < data.Count; i++)
			{
				List<MusicDirectionParamBase.SpecialDirectionData> fullfill = data[i].CheckFulfill(settingList);
				if(fullfill != null)
				{
					bool isValid = true;
					foreach(var g in groupIds)
					{
						if(g == data[i].m_resourceGroupId)
						{
							isValid = false;
							break;
						}
					}
					if(isValid)
					{
						bool isAttachValid = false;
						int divaId = 0;
						foreach(var s in settingList)
						{
							if(s.divaId == data[i].m_attachDivaId)
							{
								isAttachValid = true;
								divaId = s.divaId;
							}
						}
						if(!isAttachValid)
						{
							for(int j = 0; j < fullfill.Count; j++)
							{
								if(fullfill[j].divaId > 0)
								{
									divaId = fullfill[j].divaId;
									break;
								}
								if(fullfill[j].positionId > 0)
								{
									foreach(var s in settingList)
									{
										if(fullfill[j].positionId != s.positionId)
										{
											divaId = s.divaId;
											break;
										}
									}
								}
							}
						}
						res.Add(new ResourceData(data[i].m_bundleId, divaId));
						groupIds.Add(data[i].m_resourceGroupId);
					}
				}
			}
			if(res.Count == 0)
			{
				res.Add(new ResourceData(0, 0));
			}
			return res;
		}

		// RVA: 0xC967DC Offset: 0xC967DC VA: 0xC967DC Slot: 7
		public override bool IsUseCommonMike(int divaId, int divaModelId)
		{
			for(int i = 0; i < m_mikeReplaceTargetList.Count; i++)
			{
				if(m_mikeReplaceTargetList[i].IsFulfill(divaId, divaModelId))
				{
					return true;
				}
			}
			return false;
		}

		// RVA: 0xC96AC8 Offset: 0xC96AC8 VA: 0xC96AC8 Slot: 8
		public override List<MusicDirectionParamBase.ResourceData> CheckStageLightingResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_stageLightingList, settingList);
		}

		// RVA: 0xC96AD4 Offset: 0xC96AD4 VA: 0xC96AD4 Slot: 9
		public override List<MusicDirectionParamBase.ResourceData> CheckStageExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_stagePrefabList, settingList);
		}

		// RVA: 0xC96AE0 Offset: 0xC96AE0 VA: 0xC96AE0 Slot: 10
		public override List<MusicDirectionParamBase.ResourceData> CheckDivaExtensionResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_divaPrefabList, settingList);
		}

		// // RVA: 0xC96AEC Offset: 0xC96AEC VA: 0xC96AEC Slot: 11
		public override List<MusicDirectionParamBase.ResourceData> CheckDivaCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_divaClipList, settingList);
		}

		// // RVA: 0xC96AF8 Offset: 0xC96AF8 VA: 0xC96AF8 Slot: 12
		public override List<MusicDirectionParamBase.ResourceData> CheckMusicCameraCutinResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_cameraClipList, settingList);
		}

		// // RVA: 0xC96B04 Offset: 0xC96B04 VA: 0xC96B04 Slot: 13
		public override List<MusicDirectionParamBase.ResourceData> CheckMusicVoiceChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_voiceChangerList, settingList);
		}

		// // RVA: 0xC96B10 Offset: 0xC96B10 VA: 0xC96B10 Slot: 14
		public override List<MusicDirectionParamBase.ResourceData> CheckSpecialMovieResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_movieList, settingList);
		}

		// // RVA: 0xC96B1C Offset: 0xC96B1C VA: 0xC96B1C Slot: 15
		public override List<MusicDirectionParamBase.ResourceData> CheckStageChangerResourceId(List<MusicDirectionParamBase.ConditionSetting> settingList)
		{
			return CheckCondition(m_stageChangerList, settingList);
		}
	}
}
