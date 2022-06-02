using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfo : MonoBehaviour
	{
		[Serializable]
		private class DivaInfo
		{
			[SerializeField]
			public SetDeckDivaCardControl m_divaControl;
			[SerializeField]
			public SetDeckSceneSetControl m_sceneSetControl;
		}

		[SerializeField]
		private SetDeckUnitInfoAnimeControl m_animeControl;
		[SerializeField]
		private List<SetDeckUnitInfo.DivaInfo> m_divaInfos;
		[SerializeField]
		private List<SetDeckDivaCardControl> m_additionDivas;
		[SerializeField]
		private SetDeckAssistCardControl m_assist;
		[SerializeField]
		private SetDeckUnitInfoMessageControl m_messageControl;
		[SerializeField]
		private GameObject m_tapGuardObject;
	}
}
