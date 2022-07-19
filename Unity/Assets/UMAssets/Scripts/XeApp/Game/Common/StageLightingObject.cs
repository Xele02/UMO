using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageLightingObject : MonoBehaviour
	{
		private enum ControlType
		{
			DivaColor = 0,
			DivaRimColor = 1,
			DivaRimPower = 2,
			ShadowColor = 3,
			StageColor = 4,
			LightA = 5,
			LightB = 6,
			LightC = 7,
			Num = 8,
		}

		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private StageLightingResource resource; // 0x14
		private StageObject stageObject; // 0x18
		private GameDivaObject divaObject; // 0x1C
		private List<StageExtensionObject> stageExtensionObjectList = new List<StageExtensionObject>(); // 0x20
		private List<DivaExtensionObject> divaExtensionObjectList = new List<DivaExtensionObject>(); // 0x24
		private GameDivaObject[] subDivaObject; // 0x28
		private int subDivaNum; // 0x2C
		private Transform[] colorControlTransforms = new Transform[8]; // 0x30
		public static string[] colorControlObjectName = new string[8] { "diva_color", "diva_rim_color", "diva_rim_power", "shadow_color", "stage_color",
							"light_a", "light_b", "light_c"}; // 0x0

		//// RVA: 0x13A7C04 Offset: 0x13A7C04 VA: 0x13A7C04
		//public void ResetAnimationPreview(float time) { }

		//// RVA: 0x13A7D70 Offset: 0x13A7D70 VA: 0x13A7D70
		private void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO StageLightingObject LateUpdate");
		}

		//// RVA: 0x13A8680 Offset: 0x13A8680 VA: 0x13A8680
		public void Initialize(StageLightingResource resource, StageObject stageObject, GameDivaObject divaObject, List<StageExtensionObject> stageExtensionObjectList, List<DivaExtensionObject> divaExtensionObjectList, GameDivaObject[] subDivaObject, int subDivaNum)
		{
			UnityEngine.Debug.LogError("TODO StageLightingObject Initialize");
		}

		//// RVA: 0x13A85A4 Offset: 0x13A85A4 VA: 0x13A85A4
		//private Color TransformToColor(Transform t) { }

		//// RVA: 0x13A8A88 Offset: 0x13A8A88 VA: 0x13A8A88
		//public void PlayMusicAnimation() { }

		//// RVA: 0x13A8D1C Offset: 0x13A8D1C VA: 0x13A8D1C
		//public void Stop() { }

		//// RVA: 0x13A8DC8 Offset: 0x13A8DC8 VA: 0x13A8DC8
		//public void Pause() { }

		//// RVA: 0x13A8E80 Offset: 0x13A8E80 VA: 0x13A8E80
		//public void Resume() { }

		//// RVA: 0x13A8B6C Offset: 0x13A8B6C VA: 0x13A8B6C
		//public void ChangeAnimationTime(double time) { }
	}
}
