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
			PlayerManualUpdate();
			if(renderMode == RenderMode.OnVisibility && !HaveRendererOwner)
			{
				if(target != null)
				{
					if(target.isVisible)
					{
						player.OnWillRenderObject(null);
					}
				}
			}
		}

		// // RVA: 0x2961C90 Offset: 0x2961C90 VA: 0x2961C90 Slot: 10
		public override bool RenderTargetManualSetup()
		{
			if(target == null)
			{
				target = gameObject.GetComponent<Renderer>();
			}
			if(target == null)
			{
				UnityEngine.Debug.LogError("[CRIWARE] Missing render target for the Mana Controller component: Please add a renderer to the GameObject or specify the target manually.");
			}
			else
			{
				originalMaterial = target.sharedMaterial;
				if(!useOriginalMaterial)
				{
					target.enabled = false;
				}
				return true;
			}
			return false;
		}

		// // RVA: 0x2961E58 Offset: 0x2961E58 VA: 0x2961E58 Slot: 11
		public override void RenderTargetManualFinalize()
		{
			if(target != null)
			{
				target.material = originalMaterial;
				if(!useOriginalMaterial)
					target.enabled = false;
			}
			originalMaterial = null;
		}

		// // RVA: 0x2961F58 Offset: 0x2961F58 VA: 0x2961F58 Slot: 8
		protected override void OnMaterialAvailableChanged()
		{
			if(target == null)
				return;
			if(!isMaterialAvailable)
			{
				target.material = originalMaterial;
				if(useOriginalMaterial)
					return;
				target.enabled = false;
			}
			else
			{
				target.material = material;
				target.enabled = true;
			}
		}
	}
}