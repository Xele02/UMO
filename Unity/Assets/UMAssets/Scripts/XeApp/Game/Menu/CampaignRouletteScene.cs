using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CampaignRouletteScene : TransitionRoot, IPointerClickHandler, IEventSystemHandler
	{
		public class MiniCharaTexture
		{
			public int dir; // 0x8
			public int divaId; // 0xC
			public int type; // 0x10
			public int index; // 0x14
			public int imageId; // 0x18
			public RawImageEx image; // 0x1C

			// RVA: 0x10A83C0 Offset: 0x10A83C0 VA: 0x10A83C0
			public static MiniCharaTexture Make(RawImageEx image)
			{
				string[] strs = image.name.Split(new char[]{' '});
				strs = strs[0].Split(new char[]{'_'});
				if(strs.Length > 0)
				{
					MiniCharaTexture d = new MiniCharaTexture();
					for(int i = 0; i < strs.Length; i++)
					{
						switch(i)
						{
							case 1:
								d.dir = strs[1].Contains("r") ? 1 : 0;
								break;
							case 2:
								d.divaId = int.Parse(strs[2]);
								break;
							case 3:
								d.type = int.Parse(strs[3]);
								break;
							case 4:
								d.index = int.Parse(strs[4]);
								break;
						}
					}
					d.imageId = int.Parse(d.divaId.ToString("D2") + d.type.ToString("D2") + d.index.ToString("D3"));
					d.image = image;
					return d;
				}
				return null;
			}
		}

		private LayoutCampaignRouletteMain m_layoutMain; // 0x48
		private LayoutCampaignRouletteResult m_layoutResult; // 0x4C
		private LayoutPopupCampaign1st m_layoutPopup1st; // 0x50
		private CampaignRouletteEffect m_effectObject; // 0x54
		private TipsTextureCache m_textureCache; // 0x58
		private Texture2D m_textureBG; // 0x5C
		private LLBKNDPMGEP m_view; // 0x60
		private Coroutine m_loadCoroutine; // 0x64
		private Coroutine m_animCoroutine; // 0x68
		private bool m_isEndEnterAnimation; // 0x6C

		// RVA: 0x10A55D4 Offset: 0x10A55D4 VA: 0x10A55D4 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			this.StartCoroutineWatched(Co_InitializeLayout());
		}

		// RVA: 0x10A5628 Offset: 0x10A5628 VA: 0x10A5628
		private void Update()
		{
			if(m_textureCache != null)
				m_textureCache.Update();
		}

		// RVA: 0x10A563C Offset: 0x10A563C VA: 0x10A563C
		private void OnDestroy()
		{
			if(m_textureCache != null)
				m_textureCache.Terminated();
			m_textureCache = null;
		}

		// RVA: 0x10A5670 Offset: 0x10A5670 VA: 0x10A5670 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_view = new LLBKNDPMGEP();
			m_view.KHEKNNFCAOI();
			m_loadCoroutine = this.StartCoroutineWatched(Co_Load(m_view.EKANGPODCEP_EventId));
			m_layoutMain.SetParent(transform);
			m_layoutResult.SetParent(null);
			m_textureCache = new TipsTextureCache();
			List<MiniCharaTexture> l = m_layoutMain.GetMiniCharaList();
			l.AddRange(m_layoutResult.GetMiniCharaList());
			for(int i = 0; i < l.Count; i++)
			{
				MiniCharaTexture info = l[i];
				m_textureCache.LoadChara(l[i].dir, l[i].imageId, (IiconTexture texture) =>
				{
					//0x10A6324
					m_layoutMain.SetCharaTexture(info, texture);
					m_layoutResult.SetCharaTexture(info, texture);
				});
			}
			m_effectObject.Stop();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB39C Offset: 0x6CB39C VA: 0x6CB39C
		// // RVA: 0x10A59DC Offset: 0x10A59DC VA: 0x10A59DC
		private IEnumerator Co_Load(int eventId)
		{
			//0x10A6724
			yield return Co.R(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.Campaign, eventId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			RawImage img = GameObject.Find("BgImage").GetComponent<RawImage>();
			img.texture = m_textureBG;
			bool isChangedCueSheet = true;
			SoundManager.Instance.voDiva.RequestChangeCueSheet(1, () =>
			{
				//0x10A63C0
				isChangedCueSheet = false;
			});
			while(isChangedCueSheet)
				yield return null;
			m_loadCoroutine = null;
		}

		// RVA: 0x10A5AAC Offset: 0x10A5AAC VA: 0x10A5AAC Slot: 18
		protected override void OnPostSetCanvas() 
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0x10A5AB4 Offset: 0x10A5AB4 VA: 0x10A5AB4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning && m_loadCoroutine == null;
		}

		// RVA: 0x10A5B78 Offset: 0x10A5B78 VA: 0x10A5B78 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.Play(BgmPlayer.MENU_TRIAL_ID_BASE, 1);
			return true;
		}

		// RVA: 0x10A5C58 Offset: 0x10A5C58 VA: 0x10A5C58 Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		// RVA: 0x10A5C5C Offset: 0x10A5C5C VA: 0x10A5C5C Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_isEndEnterAnimation = false;
			m_layoutMain.Enter(() =>
			{
				//0x10A60B0
				m_isEndEnterAnimation = true;
			});
		}

		// RVA: 0x10A5D0C Offset: 0x10A5D0C VA: 0x10A5D0C Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return m_isEndEnterAnimation;
		}

		// // RVA: 0x10A5D14 Offset: 0x10A5D14 VA: 0x10A5D14 Slot: 31
		public void OnPointerClick(PointerEventData eventData)
		{
			if(m_animCoroutine != null)
				return;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			m_animCoroutine = this.StartCoroutineWatched(Co_StartRoulette());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB414 Offset: 0x6CB414 VA: 0x6CB414
		// // RVA: 0x10A5D98 Offset: 0x10A5D98 VA: 0x10A5D98
		private IEnumerator Co_StartRoulette()
		{
			FFHPBEPOMAK_DivaInfo diva;

			//0x10A75DC
			int rank = m_view.GMODKHLGILM_Rank;
			if(rank > 0)
			{
				m_layoutResult.Setup(rank, 7);
				GameManager.Instance.InputEnabled = false;
				yield return Co.R(m_layoutMain.StartRoulette(rank));
				m_layoutMain.SetParent(null);
				m_layoutResult.SetParent(transform);
				yield return Co.R(m_layoutResult.StartRouletteResult(rank, () =>
				{
					//0x10A63D4
					m_effectObject.Play(rank);
				}));
				yield return new WaitForSeconds(2);
				GameManager.Instance.InputEnabled = true;
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				PopupCampaignPrizeListSetting s = new PopupCampaignPrizeListSetting();
				s.View = m_view;
				s.TitleText = bk.GetMessageByLabel("popup_campaign_result_title");
				s.WindowSize = SizeType.Large;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool done = false;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x10A6320
					return;
				}, null, null, null, true, true, false, null, () =>
				{
					//0x10A64C0
					done = true;
				});
				yield return new WaitWhile(() =>
				{
					//0x10A64CC
					return !done;
				});
				yield return new WaitForSeconds(0.5f);
				diva = GameManager.Instance.GetHomeDiva();
				bool isChangedCueSheet = true;
				SoundManager.Instance.voDiva.RequestChangeCueSheet(diva.AHHJLDLAPAN_DivaId, () =>
				{
					//0x10A6420
					isChangedCueSheet = false;
				});
				while(isChangedCueSheet)
					yield return null;
				if(rank == 1)
				{
					m_layoutPopup1st.Setup(diva.AHHJLDLAPAN_DivaId, m_textureCache);
					GameManager.PushBackButtonHandler backButton = () =>
					{
						//0x10A642C
						if(m_layoutPopup1st.OnClickButton != null)
							m_layoutPopup1st.OnClickButton();
					};
					GameManager.Instance.AddPushBackButtonHandler(backButton);
					done = false;
					m_layoutPopup1st.OnClickButton = () =>
					{
						//0x10A64E8
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
						done = true;
						GameManager.Instance.RemovePushBackButtonHandler(backButton);
					};
					SoundManager.Instance.voDiva.Play(DivaVoicePlayer.VoiceCategory.Campaign, 0);
					while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
						yield return null;
					m_layoutPopup1st.Enter();
					yield return new WaitWhile(() =>
					{
						//0x10A65E4
						return !done;
					});
				}
				m_animCoroutine = null;
				MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
			}
		}

		// // RVA: 0x10A5E44 Offset: 0x10A5E44 VA: 0x10A5E44
		// private void GoToTitle() { }

		// // RVA: 0x10A5604 Offset: 0x10A5604 VA: 0x10A5604
		// private void InitializeLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6CB48C Offset: 0x6CB48C VA: 0x6CB48C
		// // RVA: 0x10A5F50 Offset: 0x10A5F50 VA: 0x10A5F50
		private IEnumerator Co_InitializeLayout()
		{
			//0x10A65FC
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6CB504 Offset: 0x6CB504 VA: 0x6CB504
		// // RVA: 0x10A5FFC Offset: 0x10A5FFC VA: 0x10A5FFC
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			AssetBundleLoadAssetOperation operation2; // 0x20

			//0x10A6A9C
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/120.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_cpn_roul_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10A60BC
				m_layoutMain = instance.GetComponent<LayoutCampaignRouletteMain>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_cpn_roul_result_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10A6138
				m_layoutResult = instance.GetComponent<LayoutCampaignRouletteResult>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_cpn_roul_congrats_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10A61B4
				instance.transform.SetParent(transform, false);
				m_layoutPopup1st = instance.GetComponent<LayoutPopupCampaign1st>();
				m_layoutPopup1st.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation2 = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "EffectObject", typeof(GameObject));
			yield return operation2;
			m_effectObject = Instantiate(operation2.GetAsset<GameObject>()).GetComponentInChildren<CampaignRouletteEffect>();
			m_effectObject.transform.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			operation2 = AssetBundleManager.LoadAssetAsync(bundleName.ToString(), "sel_cpn_roul_bg", typeof(Texture2D));
			yield return operation2;
			m_textureBG = operation2.GetAsset<Texture2D>();
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			while(!m_layoutMain.IsLoaded())
				yield return null;
			while(!m_layoutResult.IsLoaded())
				yield return null;
			while(!m_layoutPopup1st.IsLoaded())
				yield return null;
		}
	}
}
