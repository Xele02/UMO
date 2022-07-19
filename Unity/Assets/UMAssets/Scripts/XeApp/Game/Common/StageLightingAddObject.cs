using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageLightingAddObject : MonoBehaviour
	{
		private enum ControlType
		{
			DivaColor = 0,
			DivaRimColor = 1,
			DivaRimPower = 2,
			ShadowColor = 3,
			Num = 4,
		}

		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private StageLightingResource resource; // 0x14
		private GameDivaObject divaObject; // 0x18
		private List<DivaExtensionObject> divaExtensionObjectList = new List<DivaExtensionObject>(); // 0x1C
		private int index; // 0x20
		private Transform[] colorControlTransforms = new Transform[4]; // 0x24
		public static string[] colorControlObjectName = new string[4] { "diva_color", "diva_rim_color", "diva_rim_power", "shadow_color" }; // 0x0

		// RVA: 0x13A696C Offset: 0x13A696C VA: 0x13A696C
		//public void ResetAnimationPreview(float time) { }

		// RVA: 0x13A6AD8 Offset: 0x13A6AD8 VA: 0x13A6AD8
		private void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO StageLightingAddObject LateUpdate");
		}

		// RVA: 0x13A6EDC Offset: 0x13A6EDC VA: 0x13A6EDC
		public void Initialize(int index, StageLightingResource resource, GameDivaObject divaObject, List<DivaExtensionObject> divaExtensionObjectList)
		{
			UnityEngine.Debug.LogError("TODO StageLightingAddObject Initialize");
		}

		// RVA: 0x13A6E00 Offset: 0x13A6E00 VA: 0x13A6E00
		//private Color TransformToColor(Transform t) { }

		//// RVA: 0x13A7470 Offset: 0x13A7470 VA: 0x13A7470
		//public void PlayMusicAnimation() { }

		//// RVA: 0x13A7704 Offset: 0x13A7704 VA: 0x13A7704
		//public void Stop() { }

		//// RVA: 0x13A77B0 Offset: 0x13A77B0 VA: 0x13A77B0
		//public void Pause() { }

		//// RVA: 0x13A7868 Offset: 0x13A7868 VA: 0x13A7868
		//public void Resume() { }

		//// RVA: 0x13A7554 Offset: 0x13A7554 VA: 0x13A7554
		//public void ChangeAnimationTime(double time) { }
	}
}
