using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game
{
	public class MusicDirectionParam : MusicDirectionParamBase
	{
		[Serializable]
		public class SpecialDirectionDataSolo
		{
			public int bundleId;
			public int divaId;
			public int costumeModelId;
			public int valkyrieId;
			public int pilotId;
			public int positionId;
			public int directionGroupId;
		}

		[SerializeField]
		private List<MusicDirectionParamBase.MikeReplaceTargetData> m_mikeReplaceTargetList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_stageLightingList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_cameraClipList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_divaClipList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_stagePrefabList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_divaPrefabList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_voiceChangerList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_movieList;
		[SerializeField]
		private List<MusicDirectionParam.SpecialDirectionDataSolo> m_stageChangerList;
	}
}
