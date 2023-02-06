using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropFriendInfo : LayoutUGUIScriptBase
	{
		private bool isSetupFinished; // 0x11
		public Action onFinished; // 0x14
		private AbsoluteLayout layoutRootAnim; // 0x18
		private AbsoluteLayout layoutRoot; // 0x1C
		private Text textPlayerName; // 0x20
		private Text textPlayerRank; // 0x24
		private Text textSingRank; // 0x28
		private RawImageEx imageSingRank; // 0x2C
		private AbsoluteLayout layoutDivaImage; // 0x30
		private RawImageEx imageDiva; // 0x34
		private DivaIconDecoration divaIconDecoration; // 0x38
		private AbsoluteLayout layoutSceneImage; // 0x3C
		private RawImageEx imageScene; // 0x40
		private SceneIconDecoration sceneIconDecoration; // 0x44
		private ActionButton sendFriendRequest; // 0x48
		public Action onClickSendFriendRequestCallback; // 0x4C

		// RVA: 0x1D8E64C Offset: 0x1D8E64C VA: 0x1D8E64C
		private void Start()
		{
			return;
		}

		// RVA: 0x1D8E650 Offset: 0x1D8E650 VA: 0x1D8E650
		private void Update()
		{
			return;
		}

		// RVA: 0x1D8E654 Offset: 0x1D8E654 VA: 0x1D8E654 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRootAnim = layout.FindViewById("sw_guest_set_anim") as AbsoluteLayout;
			layoutRoot = layoutRootAnim.FindViewById("sw_guest_set") as AbsoluteLayout;
			layoutDivaImage = layoutRoot.FindViewById("swtex_cmn_diva_icon") as AbsoluteLayout;
			layoutSceneImage = layoutRoot.FindViewById("swtex_cmn_scene_icon") as AbsoluteLayout;
			Transform t = transform.Find("sw_guest_set_anim (AbsoluteLayout)/sw_guest_set (AbsoluteLayout)");
			imageDiva = t.Find("swtexc_cmn_diva_icon (ImageView)").GetComponent<RawImageEx>();
			imageScene = t.Find("swtex_cmn_scene_icon (ImageView)").GetComponent<RawImageEx>();
			imageSingRank = t.Find("cmn_musicrate (AbsoluteLayout)/cmn_musicrate (ImageView)").GetComponent<RawImageEx>();
			textPlayerName = t.Find("g_name (TextView)").GetComponent<Text>();
			textPlayerRank = t.Find("g_lv (TextView)").GetComponent<Text>();
			textSingRank = t.Find("lv_txt_00 (TextView)").GetComponent<Text>();
			sendFriendRequest = t.Find("sw_btn_friend (AbsoluteLayout)").GetComponent<ActionButton>();
			sendFriendRequest.AddOnClickCallback(OnClickSendFriendRequest);
			Loaded();
			return true;
		}

		// // RVA: 0x1D8EBB8 Offset: 0x1D8EBB8 VA: 0x1D8EBB8
		public void Setup(EAJCBFGKKFA_FriendInfo friendData)
		{
			isSetupFinished = false;
			if(friendData != null)
			{
				StringBuilder str = new StringBuilder();
				str.SetFormat("RANK {0}", friendData.ILOJAJNCPEC_Rank);
				textPlayerName.text = friendData.LBODHBDOMGK_Name;
				textPlayerRank.text = str.ToString();
				if(friendData.PDIPANKOKOL_FriendType == IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend)
				{
					HiddenFriendRequestButton();
				}
				int divaId = 0;
				int costumeId = 0;
				int colorId = 0;
				if(friendData.JIGONEMPPNP_Diva != null)
				{
					divaId = friendData.JIGONEMPPNP_Diva.AHHJLDLAPAN_DivaId;
					costumeId = friendData.JIGONEMPPNP_Diva.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId;
					colorId = friendData.JIGONEMPPNP_Diva.EKFONBFDAAP_ColorId;
				}
				MenuScene.Instance.DivaIconCache.Load(divaId, costumeId, colorId, (IiconTexture iconTexture) =>
				{
					//0x1D8F49C
					iconTexture.Set(imageDiva);
				});
				bool isKira = false;
				int sceneId = 0;
				int sceneRank = 0;
				if(friendData.KHGKPKDBMOH_GetAssistScene() != null)
				{
					sceneId = friendData.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId;
					sceneRank = friendData.KHGKPKDBMOH_GetAssistScene().CGIELKDLHGE_GetEvolveId();
					isKira = friendData.KHGKPKDBMOH_GetAssistScene().MBMFJILMOBP_IsKira();
				}
				MenuScene.Instance.SceneIconCache.Load(sceneId, sceneRank, (IiconTexture iconTexture) =>
				{
					//0x1D8F590
					iconTexture.Set(imageScene);
					SceneIconTextureCache.ChangeKiraMaterial(imageScene, iconTexture as IconTexture, isKira);
				});
				divaIconDecoration = new DivaIconDecoration(imageDiva.gameObject, DivaIconDecoration.Size.S, layoutDivaImage, null);
				divaIconDecoration.Change(friendData.JIGONEMPPNP_Diva, friendData, DisplayType.Level, friendData.AFBMEMCHJCL_MainScene);
				sceneIconDecoration = new SceneIconDecoration(imageScene.gameObject, SceneIconDecoration.Size.S, layoutSceneImage, null);
				sceneIconDecoration.Change(friendData.KHGKPKDBMOH_GetAssistScene(), DisplayType.Level);
				HighScoreRatingRank.Type rank = friendData.AGJIIKKOKFJ_ScoreRatingRank;
				textSingRank.text = friendData.BJGOPOEAAIC_MusicRatio.ToString();
				GameManager.Instance.MusicRatioTextureCache.Load(rank, (IiconTexture texture) =>
				{
					//0x1D8F6F8
					if(texture != null)
					{
						(texture as MusicRatioTextureCache.MusicRatioTexture).Set(imageSingRank, rank);
					}
				});
				isSetupFinished = true;
			}
		}

		// // RVA: 0x1D8F208 Offset: 0x1D8F208 VA: 0x1D8F208
		public void Release()
		{
			if(divaIconDecoration != null)
				divaIconDecoration.Release();
			if(sceneIconDecoration != null)
				sceneIconDecoration.Release();
		}

		// // RVA: 0x1D8F240 Offset: 0x1D8F240 VA: 0x1D8F240
		public void StartBeginAnim()
		{
			if (!isSetupFinished)
				return;
			layoutRootAnim.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_PlayingAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7190D4 Offset: 0x7190D4 VA: 0x7190D4
		// // RVA: 0x1D8F2F0 Offset: 0x1D8F2F0 VA: 0x1D8F2F0
		private IEnumerator Co_PlayingAnim()
		{
			//0x1D8F7D4
			yield return new WaitWhile(() =>
			{
				//0x1D8F470
				return layoutRootAnim.IsPlayingChildren();
			});
			if (onFinished != null)
				onFinished();
		}

		// // RVA: 0x1D8F39C Offset: 0x1D8F39C VA: 0x1D8F39C
		// public void SkipBeginAnim() { }

		// // RVA: 0x1D8F1D8 Offset: 0x1D8F1D8 VA: 0x1D8F1D8
		public void HiddenFriendRequestButton()
		{
			sendFriendRequest.Hidden = true;
		}

		// // RVA: 0x1D8F424 Offset: 0x1D8F424 VA: 0x1D8F424
		// public void DisableFriendRequestButton() { }

		// // RVA: 0x1D8F454 Offset: 0x1D8F454 VA: 0x1D8F454
		private void OnClickSendFriendRequest()
		{
			TodoLogger.LogNotImplemented("OnClickSendFriendRequest");
		}
	}
}
