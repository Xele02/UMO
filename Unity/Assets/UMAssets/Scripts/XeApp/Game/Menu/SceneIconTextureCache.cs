using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneIconTexture : IconTexture
	{
		public static readonly Rect IconUv = new Rect(0, 0.203125f, 1, 0.59375f); // 0x0

		public Material KiraEnableMaterial { get; set; } // 0x20

		// RVA: 0x13704C0 Offset: 0x13704C0 VA: 0x13704C0 Slot: 15
		public override void Release()
		{
			base.Release();
			if(KiraEnableMaterial != null)
				KiraEnableMaterial = null;
		}

		// RVA: 0x1370564 Offset: 0x1370564 VA: 0x1370564 Slot: 16
		public override void Set(RawImageEx image)
		{
			base.Set(image);
			image.uvRect = IconUv;
		}

		// RVA: 0x1370644 Offset: 0x1370644 VA: 0x1370644 Slot: 17
		public override void Set(RawImage image)
		{
			if(image != null)
			{
				base.Set(image);
				image.uvRect = IconUv;
			}
		}

		// RVA: 0x137076C Offset: 0x137076C VA: 0x137076C
		public void EnableKira(RawImageEx image)
		{
			if(image != null)
			{
				image.material = KiraEnableMaterial;
				image.MaterialMul = KiraEnableMaterial;
			}
			if(Material != null)
			{
				if(Material.HasProperty(SceneIconTextureCache.IsKiraShaderParam))
				{
					Material.SetFloat(SceneIconTextureCache.IsKiraShaderParam, 1.0f);
				}
			}
		}

		// RVA: 0x1370944 Offset: 0x1370944 VA: 0x1370944
		public void DisableKira(RawImageEx image)
		{
			if(image != null)
			{
				image.material = Material;
				image.MaterialMul = Material;
			}
			if(Material != null)
			{
				if (Material.HasProperty(SceneIconTextureCache.IsKiraShaderParam))
				{
					Material.SetFloat(SceneIconTextureCache.IsKiraShaderParam, 0.0f);
				}
			}
		}
	}

	public class SceneRareBreakTexture : IconTexture
	{
		public Material KiraEnableMaterial { get; set; } // 0x20

		// RVA: 0x1378790 Offset: 0x1378790 VA: 0x1378790 Slot: 15
		public override void Release()
		{
			base.Release();
			if(KiraEnableMaterial != null)
				KiraEnableMaterial = null;
		}

		// RVA: 0x1378834 Offset: 0x1378834 VA: 0x1378834 Slot: 16
		public override void Set(RawImageEx image)
		{
			base.Set(image);
			image.uvRect = SceneIconTexture.IconUv;
		}

		// RVA: 0x1378914 Offset: 0x1378914 VA: 0x1378914 Slot: 17
		public override void Set(RawImage image)
		{
			if (image != null)
			{
				base.Set(image);
				image.uvRect = SceneIconTexture.IconUv;
			}
		}

		// RVA: 0x1371640 Offset: 0x1371640 VA: 0x1371640
		public void EnableKira(RawImageEx image)
		{
			if(image != null)
			{
				image.material = KiraEnableMaterial;
				image.MaterialMul = KiraEnableMaterial;
			}
		}

		// RVA: 0x1371724 Offset: 0x1371724 VA: 0x1371724
		public void DisableKira(RawImageEx image)
		{
			if (image != null)
			{
				image.material = Material;
				image.MaterialMul = Material;
			}
		}

		// RVA: 0x13712E0 Offset: 0x13712E0 VA: 0x13712E0
		public void SetKiraMaterial()
		{
			if(KiraEnableMaterial != null)
			{
				if (KiraEnableMaterial.HasProperty(SceneIconTextureCache.IsKiraShaderParam))
				{
					KiraEnableMaterial.SetFloat(SceneIconTextureCache.IsKiraShaderParam, 1.0f);
				}
			}
			if (Material != null)
			{
				if (Material.HasProperty(SceneIconTextureCache.IsKiraShaderParam))
				{
					Material.SetFloat(SceneIconTextureCache.IsKiraShaderParam, 0.0f);
				}
			}
		}
	}


	public class SceneIconTextureCache : IconTextureCache
	{
		private Texture2D SharedAlphaTexture; // 0x20
		private IiconTexture m_loadingTexture; // 0x24
		private Material m_kira256Material; // 0x28
		private Material m_kira2048Material; // 0x2C
		private Material m_kira2048HoloMaterial; // 0x30
		private int m_kiraEnableShaderParam; // 0x34
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x38
		public const string SharedAlphaTextureAssetBundleName = "ct/sc/me/01/al.xab";
		public const string TextureAssetBundleFormat = "ct/sc/me/01/{0:D6}_{1:D2}.xab";
		public const string TextureAsset2BundleFormat = "ct/sc/me/01_2/{0:D6}_{1:D2}.xab";
		public const string TextureAssetBundleVersionFormat = "ct/sc/me/01/{0:D6}_{2:D2}_{1:D2}.xab";
		public const string TextureAsset2BundleVersionFormat = "ct/sc/me/01_2/{0:D6}_{2:D2}_{1:D2}.xab";
		public const string LargeSizeTextureBundlePath = "ct/sc/me/02_2/{0:D6}_{1:D2}.xab";
		public const string KiraEffectAssetBundleName = "ct/sc/ef.xab";
		public const string KiraEffect256MaterialName = "eff_256";
		public const string KiraEffect2048MaterialName = "eff_2048";
		public const string KiraEffect2048HoloMaterialName = "holo_2048_a_mul";
		public static int IsKiraShaderParam; // 0x0

		// // RVA: 0x1370C64 Offset: 0x1370C64 VA: 0x1370C64 Slot: 5
		// public override void Terminated() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6C62B0 Offset: 0x6C62B0 VA: 0x6C62B0
		// // RVA: 0x1370C74 Offset: 0x1370C74 VA: 0x1370C74
		public IEnumerator Initialize()
		{
			AssetBundleLoadAllAssetOperationBase operation;

			//0x1371E80
			operation = AssetBundleManager.LoadAllAssetAsync("ct/sc/ef.xab");
			yield return operation;

			m_kira256Material = operation.GetAsset<Material>("eff_256");
			m_kira2048Material = operation.GetAsset<Material>("eff_2048");

			AssetBundleManager.UnloadAssetBundle("ct/sc/ef.xab", false);

			m_kiraEnableShaderParam = Shader.PropertyToID("_UseEffect");
			IsKiraShaderParam = Shader.PropertyToID("_IsKira");

			operation = AssetBundleManager.LoadAllAssetAsync("ct/sc/me/01/al.xab");
			yield return operation;

			SharedAlphaTexture = operation.GetAsset<Texture2D>("al");

			AssetBundleManager.UnloadAssetBundle("ct/sc/me/01/al.xab", false);

			Load(0, 1, (IiconTexture texture) =>
			{
				//0x1371E74
				m_loadingTexture = texture;
			});
			while (m_loadingTexture == null)
				yield return null;

			yield return AssetBundleManager.LoadUnionAssetBundle("ct/sc/fr_256.xab");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6C6328 Offset: 0x6C6328 VA: 0x6C6328
		// // RVA: 0x1370D20 Offset: 0x1370D20 VA: 0x1370D20
		// public IEnumerator LoadKiraMaterial(Action LoadEndAction) { }

		// // RVA: 0x1370DE8 Offset: 0x1370DE8 VA: 0x1370DE8
		// public void ReleaseKiraMaterial() { }

		// // RVA: 0x136EBA4 Offset: 0x136EBA4 VA: 0x136EBA4
		public void SetLoadingTexture(RawImageEx image)
		{
			m_loadingTexture.Set(image);
		}

		// // RVA: 0x1370DF8 Offset: 0x1370DF8 VA: 0x1370DF8 Slot: 7
		protected override IiconTexture CreateIconTexture(IconTextureLodingInfo info)
		{
			IiconTexture res;
			if(info.TextureType == IconTextureType.Texture)
			{
				res = new SceneIconTexture();
				SetupForSceneIconTexture(info, res, SharedAlphaTexture);
			}
			else
			{
				res = new SceneRareBreakTexture();
				res.Material = info.Operation.GetAsset<Material>(Path.GetFileNameWithoutExtension(info.Path));
				res.BaseTexture = info.Operation.GetAsset<Texture2D>("main");
				res.MaskTexture = info.Operation.GetAsset<Texture2D>("mask");
				res.CreateCount = GetCreateCountAndIncrement();
				(res as SceneRareBreakTexture).KiraEnableMaterial = new Material(res.Material);
				(res as SceneRareBreakTexture).SetKiraMaterial();
			}
			return res;
		}

		// // RVA: 0x13711B0 Offset: 0x13711B0 VA: 0x13711B0
		private void SetupForSceneIconTexture(IconTextureLodingInfo info, IiconTexture icon, Texture2D maskTexture)
		{
			SetupForSplitTexture(info, icon, maskTexture);
			(icon as SceneIconTexture).KiraEnableMaterial = new Material(m_kira256Material);
		}

		// // RVA: 0x136EC84 Offset: 0x136EC84 VA: 0x136EC84
		public void Load(int id, int rank, Action<IiconTexture> callBack)
		{
			int index = id - 1;
			int version = 0;
			bool feed = false;
			IconTextureType iconTextureType = IconTextureType.Texture;
			int baseRare = 0;
			if (index > -1)
			{
				List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA;
				if(index < scenes.Count)
				{
					baseRare = scenes[index].EKLIPGELKCL_Rarity;
					version = scenes[index].JIJOGLFOOMN_Aver;
					feed = scenes[index].MCCIFLKCNKO_Feed;
				}
			}
			if(!feed)
			{
				iconTextureType = (IsPlateAnimation() && baseRare > 5) ? IconTextureType.Material : IconTextureType.Texture;
			}
			Load(MakeBundlePath(m_strBuilder, id, rank, baseRare, version, feed).ToString(), iconTextureType, callBack);
		}

		// // RVA: 0x13637A4 Offset: 0x13637A4 VA: 0x13637A4
		public static void ChangeKiraMaterial(RawImageEx image, IconTexture texture, bool isEnable)
		{
			if(texture != null && image != null)
			{
				if(texture is SceneIconTexture)
				{
					if(isEnable)
					{
						(texture as SceneIconTexture).EnableKira(image);
					}
					else
					{
						(texture as SceneIconTexture).DisableKira(image);
					}
				}
				else if(texture is SceneRareBreakTexture)
				{
					if(isEnable)
					{
						(texture as SceneRareBreakTexture).EnableKira(image);
					}
					else
					{
						(texture as SceneRareBreakTexture).DisableKira(image);
					}
				}
			}
		}

		// // RVA: 0x1371820 Offset: 0x1371820 VA: 0x1371820
		// public void ChangeKiraMaterial_2048(RawImageEx _image) { }

		// // RVA: 0x1371884 Offset: 0x1371884 VA: 0x1371884
		// public void ChangeKiraMaterial_holo(RawImageEx _image) { }

		// // RVA: 0x13718E8 Offset: 0x13718E8 VA: 0x13718E8
		// public void TryInstall(DFKGGBMFFGB playerData) { }

		// // RVA: 0x1371A2C Offset: 0x1371A2C VA: 0x1371A2C
		public void TryInstall(int sceneId, int evolveId)
		{
			bool isFeed = false;
			int index = sceneId - 1;
			int version = 0;
			int baseRare = 0;
			if(index >= 0)
			{
				List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA;
				if (index < scenes.Count)
				{
					baseRare = scenes[index].EKLIPGELKCL_Rarity;
					version = scenes[index].JIJOGLFOOMN_Aver;
					isFeed = scenes[index].MCCIFLKCNKO_Feed;
				}
			}
			KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MakeBundlePath(m_strBuilder, sceneId, evolveId, baseRare, version, isFeed).ToString());
		}

		// // RVA: 0x13715E0 Offset: 0x13715E0 VA: 0x13715E0
		public StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, int baseRare, int version, bool isFeed)
		{
			return MakeBundlePath(strBuilder, sceneId, evolvId, !isFeed && IsPlateAnimation() && baseRare > 5, version);
		}

		// // RVA: 0x1371D6C Offset: 0x1371D6C VA: 0x1371D6C
		public StringBuilder MakeBundlePath(StringBuilder strBuilder, int sceneId, int evolvId, bool usePlateAnim, int version)
		{
			string format = usePlateAnim ? "ct/sc/me/01_2/{0:D6}_{2:D2}_{1:D2}.xab" : "ct/sc/me/01/{0:D6}_{2:D2}_{1:D2}.xab";
			if(version == 0)
				format = usePlateAnim ? "ct/sc/me/01_2/{0:D6}_{1:D2}.xab" : "ct/sc/me/01/{0:D6}_{1:D2}.xab";
			strBuilder.SetFormat(format, sceneId, evolvId, version);
			return strBuilder;
		}

		// // RVA: 0x13714EC Offset: 0x13714EC VA: 0x13714EC
		private bool IsPlateAnimation()
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.DFLJOKOKLIL_IsPlateAnimationOther == 0;
		}
	}
}
