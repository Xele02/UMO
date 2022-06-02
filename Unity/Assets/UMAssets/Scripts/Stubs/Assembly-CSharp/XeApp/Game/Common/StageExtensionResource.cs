using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class StageExtensionResource : MonoBehaviour
	{
		public bool isUnused;
		public MusicExtensionPrefabParam param;
		public MusicExtensionPrefabMovieParam paramMovie;
		public List<GameObject> prefabList;
		public AnimationClip clip;
		public RuntimeAnimatorController animatorController;
		public CriManaMovieController moviePlayer;
		public Material movieMaterial;
	}
}
