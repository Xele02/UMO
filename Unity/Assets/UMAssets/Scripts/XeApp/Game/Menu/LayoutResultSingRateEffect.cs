using System;
using System.Collections;
using System.Linq;
using System.Text;
using mcrs;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultSingRateEffect : LayoutUGUIScriptBase
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
		private Coroutine animCoroutine; // 0x18
		public Action onFinished; // 0x1C
		public Action onClick; // 0x20
		private Text TextSingRank; // 0x24
		private RawImageEx[] ImageSingRank; // 0x28
		private Rect[] SingRankArray; // 0x2C
		private bool is_touch; // 0x30
		private bool is_entered; // 0x31
		private bool is_open; // 0x32
		private IconTexture[] m_icon_texture = new IconTexture[9]; // 0x34
		private const int PACK_MAX_ICON_NUM = 20;

		// RVA: 0x1D17D90 Offset: 0x1D17D90 VA: 0x1D17D90
		private void Start()
		{
			return;
		}

		// RVA: 0x1D17D94 Offset: 0x1D17D94 VA: 0x1D17D94
		private void Update()
		{
			if(!is_touch && is_entered)
			{
				if(InputManager.Instance.GetInScreenTouchCount() > 0)
				{
					if(!ResultScene.IsScreenTouch())
						return;
					is_touch = true;
					if(onClick != null)
						onClick();
				}
			}
		}

		// RVA: 0x1D17E88 Offset: 0x1D17E88 VA: 0x1D17E88 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_game_res_mgrade_anim") as AbsoluteLayout;
			TextSingRank = transform.Find("sw_game_res_mgrade_anim (AbsoluteLayout)").Find("fnt (AbsoluteLayout)/mgrade (TextView)").GetComponent<Text>();
			ImageSingRank = transform.GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) => {
				//0x1D18E38
				return _.name == "swtexf_musicrate (ImageView)";
			}).ToArray();
			StringBuilder str = new StringBuilder();
			SingRankArray = new Rect[HighScoreRatingRank.GetRankIDMax()];
			for(int i = 0; i < SingRankArray.Length; i++)
			{
				str.Clear();
				str.AppendFormat("musicrate_{0:D2}", i + 1);
				SingRankArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
			}
			this.StartCoroutineWatched(Co_Load());
			return true;
		}

		// // RVA: 0x1D1840C Offset: 0x1D1840C VA: 0x1D1840C
		public void Setup(HighScoreRatingRank.Type type)
		{
			TextSingRank.text = HighScoreRatingRank.GetRankName(type);
			SetSingRankIcon(type);
		}

		// // RVA: 0x1D18978 Offset: 0x1D18978 VA: 0x1D18978
		// public void SetupCallback(Action onClick, Action onFinished) { }

		// // RVA: 0x1D18984 Offset: 0x1D18984 VA: 0x1D18984
		public void Enter()
		{
			is_open = true;
			if(animCoroutine != null)
				return;
			animCoroutine = this.StartCoroutineWatched(Co_WaitEnter());
		}

		// // RVA: 0x1D18A50 Offset: 0x1D18A50 VA: 0x1D18A50
		// public void Leave() { }

		// // RVA: 0x1D18B14 Offset: 0x1D18B14 VA: 0x1D18B14
		public bool IsOpen()
		{
			return is_open;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E34C Offset: 0x71E34C VA: 0x71E34C
		// // RVA: 0x1D189C4 Offset: 0x1D189C4 VA: 0x1D189C4
		private IEnumerator Co_WaitEnter()
		{
			//0x1D191E0
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			SoundManager.Instance.sePlayerResult.Play((int)cs_se_result.SE_RESULT_037);
			yield return Co_WaitAnim("go_icon");
			yield return new WaitWhile(() => {
				//0x1D18D64
				return layoutRoot.IsPlayingChildren();
			});
			layoutRoot.StartChildrenAnimGoStop("go_act", "st_act");
			is_entered = true;
			while(layoutRoot.IsPlayingChildren() && !is_touch)
				yield return null;
			yield return Co_WaitLeave();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E3C4 Offset: 0x71E3C4 VA: 0x71E3C4
		// // RVA: 0x1D18A88 Offset: 0x1D18A88 VA: 0x1D18A88
		private IEnumerator Co_WaitLeave()
		{
			//0x1D1951C
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
			yield return new WaitWhile(() => {
				//0x1D18D90
				return layoutRoot.IsPlayingChildren();
			});
			if(onFinished != null)
				onFinished();
			layoutRoot.StartChildrenAnimGoStop("st_wait");
			animCoroutine = null;
			is_open = false;
		}

		// // RVA: 0x1D17D98 Offset: 0x1D17D98 VA: 0x1D17D98
		// private void TouchScreen() { }

		// // RVA: 0x1D18468 Offset: 0x1D18468 VA: 0x1D18468
		private void SetSingRankIcon(HighScoreRatingRank.Type type)
		{
			if(((int)type - 1) <= SingRankArray.Length)
			{
				int sheetNum = ((int)type - 1) / 20;
				for(int i = 0; i < ImageSingRank.Length; i++)
				{
					ImageSingRank[i].material = m_icon_texture[sheetNum].mat_mul;
					ImageSingRank[i].alphaTexture = m_icon_texture[sheetNum].tex_mask;
					ImageSingRank[i].MaterialMul = m_icon_texture[sheetNum].mat_mul;
					ImageSingRank[i].MaterialAdd = m_icon_texture[sheetNum].mat_add;
					ImageSingRank[i].texture = m_icon_texture[sheetNum].tex_base;
					ImageSingRank[i].TextureName = m_icon_texture[sheetNum].name;
					ImageSingRank[i].uvRect = SingRankArray[(int)type - 1];
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E43C Offset: 0x71E43C VA: 0x71E43C
		// // RVA: 0x1D18B5C Offset: 0x1D18B5C VA: 0x1D18B5C
		private IEnumerator Co_WaitAnim(string label)
		{
			//0x1D1900C
			while(layoutRoot.GetView(0).FrameAnimation.FrameCount < layoutRoot.GetView(0).FrameAnimation.SearchLabelFrame(label))
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E4B4 Offset: 0x71E4B4 VA: 0x71E4B4
		// // RVA: 0x1D18380 Offset: 0x1D18380 VA: 0x1D18380
		private IEnumerator Co_Load()
		{
			//0x1D18EBC
			yield return this.StartCoroutineWatched(LoadIconTexture());
			Loaded();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71E52C Offset: 0x71E52C VA: 0x71E52C
		// // RVA: 0x1D18C44 Offset: 0x1D18C44 VA: 0x1D18C44
		private IEnumerator LoadIconTexture()
		{
			StringBuilder str; // 0x14
			string BundleName; // 0x18
			int i; // 0x1C
			string name; // 0x20
			AssetBundleLoadAssetOperation operation; // 0x24

			//0x1D1975C
			str = new StringBuilder(128);
			BundleName = "ly/110.xab";
			for(i = 0; i < m_icon_texture.Length; i++)
			{
				m_icon_texture[i] = new IconTexture();
				str.Clear();
				str.AppendFormat("musicrate_{0:D2}_", i + 1);
				name = str.ToString();
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_base", typeof(Texture));
				yield return operation;
				m_icon_texture[i].tex_base = operation.GetAsset<Texture>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_mask", typeof(Texture));
				yield return operation;
				m_icon_texture[i].tex_mask = operation.GetAsset<Texture>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_add", typeof(Material));
				yield return operation;
				m_icon_texture[i].mat_add = operation.GetAsset<Material>();
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				operation = AssetBundleManager.LoadAssetAsync(BundleName, name + "pack_mul", typeof(Material));
				yield return operation;
				m_icon_texture[i].mat_mul = operation.GetAsset<Material>();
				m_icon_texture[i].name = name + "pack";
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
				name = null;
				operation = null;
			}
		}
	}
}
