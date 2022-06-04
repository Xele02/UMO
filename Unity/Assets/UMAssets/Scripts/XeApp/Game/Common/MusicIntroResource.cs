using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicIntroResource : MonoBehaviour
	{
		// Fields
		// [CompilerGeneratedAttribute] // RVA: 0x687870 Offset: 0x687870 VA: 0x687870
		// private GameObject <runwayPrefab>k__BackingField; // 0xC
		// [CompilerGeneratedAttribute] // RVA: 0x687880 Offset: 0x687880 VA: 0x687880
		// private GameObject <enviromentPrefab>k__BackingField; // 0x10
		// [CompilerGeneratedAttribute] // RVA: 0x687890 Offset: 0x687890 VA: 0x687890
		// private ValkyrieColorParam <paramColor>k__BackingField; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x6878A0 Offset: 0x6878A0 VA: 0x6878A0
		// private ValkyrieIntroParam <paramIntro>k__BackingField; // 0x18

		// public MusicIntroResource.OverrideAnimationClip m_override_anim; // 0x1C

		// [CompilerGeneratedAttribute] // RVA: 0x6878B0 Offset: 0x6878B0 VA: 0x6878B0
		// private bool <isLoadedRunway>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x6878C0 Offset: 0x6878C0 VA: 0x6878C0
		// private bool <isLoadedEnviroment>k__BackingField; // 0x21
		// [CompilerGeneratedAttribute] // RVA: 0x6878D0 Offset: 0x6878D0 VA: 0x6878D0
		// private bool <isLoadedAnimator>k__BackingField; // 0x22

		// Properties
		public GameObject runwayPrefab { get; set; }
		public GameObject enviromentPrefab { get; set; }
		public ValkyrieColorParam paramColor { get; set; }
		// public ValkyrieIntroParam paramIntro { get; set; }
		public bool isLoadedRunway { get; set; }
		public bool isLoadedEnviroment { get; set; }
		public bool isLoadedAnimator { get; set; }
		public bool isAllLoaded { get; }

		// Methods

		// [CompilerGeneratedAttribute] // RVA: 0x7394D4 Offset: 0x7394D4 VA: 0x7394D4
		// // RVA: 0xAEA2F4 Offset: 0xAEA2F4 VA: 0xAEA2F4
		// public GameObject get_runwayPrefab() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7394E4 Offset: 0x7394E4 VA: 0x7394E4
		// // RVA: 0xAEA828 Offset: 0xAEA828 VA: 0xAEA828
		// private void set_runwayPrefab(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7394F4 Offset: 0x7394F4 VA: 0x7394F4
		// // RVA: 0xAEA2FC Offset: 0xAEA2FC VA: 0xAEA2FC
		// public GameObject get_enviromentPrefab() { }

		// [CompilerGeneratedAttribute] // RVA: 0x739504 Offset: 0x739504 VA: 0x739504
		// // RVA: 0xAEA830 Offset: 0xAEA830 VA: 0xAEA830
		// private void set_enviromentPrefab(GameObject value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x739514 Offset: 0x739514 VA: 0x739514
		// // RVA: 0xAEA838 Offset: 0xAEA838 VA: 0xAEA838
		// public ValkyrieColorParam get_paramColor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x739524 Offset: 0x739524 VA: 0x739524
		// // RVA: 0xAEA840 Offset: 0xAEA840 VA: 0xAEA840
		// private void set_paramColor(ValkyrieColorParam value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x739534 Offset: 0x739534 VA: 0x739534
		// // RVA: 0xAEA848 Offset: 0xAEA848 VA: 0xAEA848
		// public ValkyrieIntroParam get_paramIntro() { }

		// [CompilerGeneratedAttribute] // RVA: 0x739544 Offset: 0x739544 VA: 0x739544
		// // RVA: 0xAEA850 Offset: 0xAEA850 VA: 0xAEA850
		// private void set_paramIntro(ValkyrieIntroParam value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x739554 Offset: 0x739554 VA: 0x739554
		// // RVA: 0xAEA858 Offset: 0xAEA858 VA: 0xAEA858
		// public bool get_isLoadedRunway() { }

		// [CompilerGeneratedAttribute] // RVA: 0x739564 Offset: 0x739564 VA: 0x739564
		// // RVA: 0xAEA860 Offset: 0xAEA860 VA: 0xAEA860
		// private void set_isLoadedRunway(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x739574 Offset: 0x739574 VA: 0x739574
		// // RVA: 0xAEA868 Offset: 0xAEA868 VA: 0xAEA868
		// public bool get_isLoadedEnviroment() { }

		// [CompilerGeneratedAttribute] // RVA: 0x739584 Offset: 0x739584 VA: 0x739584
		// // RVA: 0xAEA870 Offset: 0xAEA870 VA: 0xAEA870
		// private void set_isLoadedEnviroment(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x739594 Offset: 0x739594 VA: 0x739594
		// // RVA: 0xAEA878 Offset: 0xAEA878 VA: 0xAEA878
		// public bool get_isLoadedAnimator() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7395A4 Offset: 0x7395A4 VA: 0x7395A4
		// // RVA: 0xAEA880 Offset: 0xAEA880 VA: 0xAEA880
		// private void set_isLoadedAnimator(bool value) { }

		// // RVA: 0xAEA888 Offset: 0xAEA888 VA: 0xAEA888
		// public bool get_isAllLoaded() { }

		// // RVA: 0xAEA8B4 Offset: 0xAEA8B4 VA: 0xAEA8B4
		// public void OnDestroy() { }

		// // RVA: 0xAEA8CC Offset: 0xAEA8CC VA: 0xAEA8CC
		// public void LoadResources(int runwayId, int enviromentId, int valkyrieId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7395B4 Offset: 0x7395B4 VA: 0x7395B4
		// // RVA: 0xAEA904 Offset: 0xAEA904 VA: 0xAEA904
		// private IEnumerator Co_LoadResources(int runwayId, int enviromentId, int valkyrieId) { }

		// // RVA: 0xAEA9FC Offset: 0xAEA9FC VA: 0xAEA9FC
		public void OverrideMusicStartTime(ref float a_sec)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAEAAD4 Offset: 0xAEAAD4 VA: 0xAEAAD4
		// public void OverrideIntroEndTime(ref int a_msec) { }

		// // RVA: 0xAEABBC Offset: 0xAEABBC VA: 0xAEABBC
		// public void .ctor() { }
	}
}
