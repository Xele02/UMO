using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;
using XeApp.Game.Menu;

namespace XeApp.Game.Common
{
	public class DivaResource : MonoBehaviour
	{
		public enum SetupFlags
		{
			Default = 0,
			Manual = 1,
		}

		public DivaParam divaParam;
		public GameObject divaPrefab;
		public GameObject mikePrefab;
		public GameObject mikeStandPrefab;
		public GameObject mikeCommonPrefab;
		public List<GameObject> prefabEffect;
		public GameObject prefabWind;
		public RuntimeAnimatorController divaAnimatorController;
		public RuntimeAnimatorController facialAnimatorController;
		public RuntimeAnimatorController mikeStandAnimatorController;
		public DivaMenuParam divaMenuParam;
		public MenuDivaVoiceTable menuVoiceTable;
		public MenuDivaVoiceTableCos menuVoiceTableCos;
		public AnimationClip mikeStandAnimationOverrideClip;
		public SetupFlags setupFlags;
		public GameObject subDivaPrefab;
		public List<GameObject> subPrefabEffect;
		public GameObject subPrefabWind;
	}
}
