using UnityEngine;

namespace CriWare
{

	public class CriManaMovieController : CriManaMovieMaterial
	{
		public Renderer target; // 0x5C
		public bool useOriginalMaterial; // 0x60
		private Material originalMaterial; // 0x64

		// // RVA: 0x2961B8C Offset: 0x2961B8C VA: 0x2961B8C Slot: 6
		public override void CriInternalUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2961C90 Offset: 0x2961C90 VA: 0x2961C90 Slot: 10
		// public override bool RenderTargetManualSetup() { }

		// // RVA: 0x2961E58 Offset: 0x2961E58 VA: 0x2961E58 Slot: 11
		// public override void RenderTargetManualFinalize() { }

		// // RVA: 0x2961F58 Offset: 0x2961F58 VA: 0x2961F58 Slot: 8
		// protected override void OnMaterialAvailableChanged() { }
	}
}