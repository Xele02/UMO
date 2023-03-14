using XeApp.Core;
using System.Collections.Generic;
using XeApp.Game.RhythmGame;
using UnityEngine;

namespace XeApp.Game.RhythmAdjust
{
	public class RhythmAdjustScene : MainSceneBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private List<RNote> rNoteList;
		[SerializeField]
		private GameObject notesOwner;
		[SerializeField]
		private RNoteObject rNoteObject;
		[SerializeField]
		private RNoteSingle[] rNoteSingle;
		[SerializeField]
		private RectTransform touchRect;
		[SerializeField]
		private Transform judgePointTransform;
		[SerializeField]
		private TextAsset scoreDataResource;
		[SerializeField]
		private GameObject layoutRoot;
		[SerializeField]
		private GameObject bgRoot;
	}
}
