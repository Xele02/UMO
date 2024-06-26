using XeApp.Core;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.RhythmGame.UI;

public class RhythmTouchEffectEditor : MainSceneBase
{
	private void Awake()
	{
		TodoLogger.LogError(0, "Implement monobehaviour");
	}
	[SerializeField]
	private RectTransform menuRectTransform;
	[SerializeField]
	private Dropdown effectSelectDropDown;
	[SerializeField]
	private Camera uiCamera;
	[SerializeField]
	private TouchPrefabInstance touchPrefabInstance;
	[SerializeField]
	private GameObject[] prefabs;
	[SerializeField]
	private Toggle[] skillToggleButtons;
	[SerializeField]
	private int[] skillKindArray;
}
