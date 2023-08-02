using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultSingRateEffectIcon : LayoutUGUIScriptBase
	{
		private class IconTexture
		{
			public Texture tex_base; // 0x8
			public Texture tex_mask; // 0xC
			public Material mat_add; // 0x10
			public Material mat_mul; // 0x14
			public string name; // 0x18
		}

		private AbsoluteLayout layoutRoot; // 0x14
		public Action onFinished; // 0x18
		public Action onChange; // 0x1C
		private RawImageEx[] ImageSingRankSmall; // 0x20
		private bool is_open; // 0x24
		private IconTexture[] m_icon_texture = new IconTexture[2]; // 0x28

		// RVA: 0x1D1A10C Offset: 0x1D1A10C VA: 0x1D1A10C
		private void Start()
		{
			return;
		}

		// RVA: 0x1D1A110 Offset: 0x1D1A110 VA: 0x1D1A110
		private void Update()
		{
			return;
		}

		// RVA: 0x1D1A114 Offset: 0x1D1A114 VA: 0x1D1A114 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) 
		{
			layoutRoot = layout.FindViewById("sw_game_res_mgrade_icon_anim") as AbsoluteLayout;
			ImageSingRankSmall = transform.GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) => {
				//0x1D1AA08
				return _.name == "swtexc_cmn_musicrate (ImageView)";
			}).ToArray();
			this.StartCoroutineWatched(Co_Load());
			return true;
		}

		// // RVA: 0x1D1A42C Offset: 0x1D1A42C VA: 0x1D1A42C
		public void Setup(HighScoreRatingRank.Type type)
		{
			for(int i = 0; i < ImageSingRankSmall.Length; i++)
			{
				int small_index = i;
				GameManager.Instance.MusicRatioTextureCache.Load(type, (IiconTexture texture) =>
				{
					//0x1D1AA88
					MusicRatioTextureCache.MusicRatioTexture t = texture as MusicRatioTextureCache.MusicRatioTexture;
					if(t != null)
					{
						t.Set(ImageSingRankSmall[small_index], type);
					}
				});
			}
		}

		// // RVA: 0x1D1A654 Offset: 0x1D1A654 VA: 0x1D1A654
		// public void SetupCallback(Action onFinished) { }

		// // RVA: 0x1D1A65C Offset: 0x1D1A65C VA: 0x1D1A65C
		// public void SetupChangeCallback(Action onChange) { }

		// // RVA: 0x1D1A664 Offset: 0x1D1A664 VA: 0x1D1A664
		public void Enter()
		{
			is_open = true;
			this.StartCoroutineWatched(Co_WaitEnter());
		}

		// // RVA: 0x1D1A720 Offset: 0x1D1A720 VA: 0x1D1A720
		public bool IsOpen()
		{
			return is_open;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E754 Offset: 0x71E754 VA: 0x71E754
		// // RVA: 0x1D1A694 Offset: 0x1D1A694 VA: 0x1D1A694
		private IEnumerator Co_WaitEnter()
		{
			//0x1D1AEE8
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play(39); // ?? no 39
			yield return null;
			yield return Co.R(Co_WaitAnim("hide"));
			if(onChange != null)
				onChange();
			yield return new WaitWhile(() => {
				//0x1D1A960
				return layoutRoot.IsPlayingChildren();
			});
			onFinished();
			is_open = false;
		}

		// // RVA: 0x1D1A430 Offset: 0x1D1A430 VA: 0x1D1A430
		// private void SetSingRankIcon(HighScoreRatingRank.Type type) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71E7CC Offset: 0x71E7CC VA: 0x71E7CC
		// // RVA: 0x1D1A758 Offset: 0x1D1A758 VA: 0x1D1A758
		private IEnumerator Co_WaitAnim(string label)
		{
			//0x1D1AD14
			while(layoutRoot.GetView(0).FrameAnimation.FrameCount < layoutRoot.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E844 Offset: 0x71E844 VA: 0x71E844
		// // RVA: 0x1D1A3A0 Offset: 0x1D1A3A0 VA: 0x1D1A3A0
		private IEnumerator Co_Load()
		{
			//0x1D1ABC4
			yield return this.StartCoroutineWatched(LoadIconTexture());
			Loaded();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E8BC Offset: 0x71E8BC VA: 0x71E8BC
		// // RVA: 0x1D1A840 Offset: 0x1D1A840 VA: 0x1D1A840
		private IEnumerator LoadIconTexture()
		{
			StringBuilder str; // 0x14
			string BundleName; // 0x18
			int i; // 0x1C
			string name; // 0x20
			AssetBundleLoadAssetOperation operation; // 0x24

			//0x1D1B1F0
			str = new StringBuilder(128);
			BundleName = "ly/110.xab";
			for(i = 0; i < m_icon_texture.Length; i++)
			{
				m_icon_texture[i] = new IconTexture();
				str.Clear();
				str.AppendFormat("musicrate_{0:D2}_", i + 1);
				name = str.ToString();
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_base", typeof(Texture));
				yield return Co.R(operation);
				m_icon_texture[i].tex_base = operation.GetAsset<Texture>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_mask", typeof(Texture));
				yield return Co.R(operation);
				m_icon_texture[i].tex_mask = operation.GetAsset<Texture>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_add", typeof(Material));
				yield return Co.R(operation);
				m_icon_texture[i].mat_add = operation.GetAsset<Material>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_mul", typeof(Material));
				yield return Co.R(operation);
				m_icon_texture[i].mat_mul = operation.GetAsset<Material>();
				m_icon_texture[i].name = name + "pack";
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				name = null;
				operation = null;
			}
		}
	}
}
