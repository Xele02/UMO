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
			public List<MusicDirectionParamBase.MikeReplaceTargetData> m_mikeReplaceTargetDataList;
		}

		[Serializable]
		public class SpecialDirectionDataList
		{
			public int m_bundleId;
			public int m_resourceGroupId;
			public int m_attachDivaId;
			public List<MusicDirectionParamBase.SpecialDirectionData> m_specialDirectionDataList;
		}

		[SerializeField]
		private int m_basaraPositionId;
		[SerializeField]
		private List<MusicDirectionParamList.MikeReplaceTargetDataList> m_mikeReplaceTargetList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stageLightingList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_cameraClipList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_divaClipList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stagePrefabList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_divaPrefabList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_voiceChangerList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_movieList;
		[SerializeField]
		private List<MusicDirectionParamList.SpecialDirectionDataList> m_stageChangerList;
	}
}
