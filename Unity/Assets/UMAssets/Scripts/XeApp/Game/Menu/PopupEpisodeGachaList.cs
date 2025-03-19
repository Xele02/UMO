using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Gacha;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeGachaSetting : PopupSetting
	{
		public override string PrefabPath { get { return ""; } } //0xF8B118
		public override string AssetName { get { return "root_pop_ep_gacha_layout_root"; } } //0xF8B174
		public override string BundleName { get { return "ly/015.xab"; } } //0xF8B1D0
		public override bool IsAssetBundle { get { return true; } } //0xF8B22C
		public override bool IsPreload { get { return true; } } //0xF8B234
		public override GameObject Content { get { return m_content; } } //0xF8B23C
		public LOBDIAABMKG GachaProductData { get; set; } // 0x34
		public HomeBannerTextureCache bannerTexCache { get; set; } // 0x38

		// // RVA: 0xF8B244 Offset: 0xF8B244 VA: 0xF8B244
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x72E83C Offset: 0x72E83C VA: 0x72E83C
		// RVA: 0xF8B24C Offset: 0xF8B24C VA: 0xF8B24C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0xF8B320
			m_parent = parent;
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(BundleName));
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x72E8B4 Offset: 0x72E8B4 VA: 0x72E8B4
		// [DebuggerHiddenAttribute] // RVA: 0x72E8B4 Offset: 0x72E8B4 VA: 0x72E8B4
		// // RVA: 0xF8B314 Offset: 0xF8B314 VA: 0xF8B314
		// private IEnumerator <>n__0(Transform parent) { }
	}

	public class PopupEpisodeGachaList
	{
		private PopupEpisodeGachaSetting m_gachaSetting = new PopupEpisodeGachaSetting(); // 0xC
		private TextPopupSetting m_noGachaTextSetting = new TextPopupSetting(); // 0x10
		private bool m_isError; // 0x18
		private bool m_isGachaTransition; // 0x19
		private LOBDIAABMKG m_gachaProductData; // 0x1C
		private GachaScene.GachaArgs m_gachaArgs = new GachaScene.GachaArgs(); // 0x20
		public UnityAction InputEnable; // 0x28
		public UnityAction InputDisable; // 0x2C

		public PopupEpisodeBonusPlateSortList PopupEpisodeBonusPlateSort { get; set; } // 0x8
		public int GachaId { get; set; } // 0x14
		public HomeBannerTextureCache bannerTexCache { get; set; } // 0x24

		// RVA: 0xF881D8 Offset: 0xF881D8 VA: 0xF881D8
		public void Initialize(Transform parant)
		{
			m_gachaSetting.TitleText = MessageManager.Instance.GetMessage("menu", "popup_gachatransition_title");
			m_gachaSetting.WindowSize = SizeType.Small;
			m_gachaSetting.IsCaption = true;
			m_gachaSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_gachaSetting.SetParent(parant);
			m_gachaSetting.bannerTexCache = bannerTexCache;
			m_noGachaTextSetting.TitleText = MessageManager.Instance.GetMessage("menu", "popup_gachatransition_title");
			m_noGachaTextSetting.IsCaption = true;
			m_noGachaTextSetting.Text = MessageManager.Instance.GetMessage("menu", "popup_not_gachatransition");
			m_noGachaTextSetting.WindowSize = SizeType.Small;
			m_noGachaTextSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			m_noGachaTextSetting.SetParent(parant);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72E9A4 Offset: 0x72E9A4 VA: 0x72E9A4
		// // RVA: 0xF8A430 Offset: 0xF8A430 VA: 0xF8A430
		private IEnumerator CoroutineGetProductList()
		{
			//0xF8AA68
			bool isEnd = false;
			m_isGachaTransition = false;
			NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.LILDGEPCPPG_GetProducList(() =>
			{
				//0xF8AA08
				isEnd = true;
				m_isError = false;
			}, () =>
			{
				//0xF8AA38
				isEnd = true;
				m_isError = true;
			}, false, true);
			while(!isEnd)
				yield return null;
			if(!m_isGachaTransition)
			{
				for(int i = 0; i < GachaUtility.netGachaProducts.Count; i++)
				{
					if(GachaUtility.netGachaProducts[i].FDEBLMKEMLF_TypeAndSeriesId == GachaId)
					{
						m_isGachaTransition = true;
						m_gachaProductData = GachaUtility.netGachaProducts[i];
						break;
					}
				}
			}
		}

		// // RVA: 0xF8A4DC Offset: 0xF8A4DC VA: 0xF8A4DC
		private void ChangeEpisodeGatchScene()
		{
			GachaUtility.typeAndSeriesId = -1;
			m_gachaArgs.Init(m_gachaProductData.FDEBLMKEMLF_TypeAndSeriesId, true);
			MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, m_gachaArgs, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x72EA1C Offset: 0x72EA1C VA: 0x72EA1C
		// RVA: 0xF88AD0 Offset: 0xF88AD0 VA: 0xF88AD0
		public IEnumerator Show()
		{
			//0xF8AE20
			if(InputDisable != null)
				InputDisable();
			PopupWindowManager.SetInputState(false);
			yield return Co.R(CoroutineGetProductList());
			PopupWindowManager.SetInputState(true);
			if(!m_isError)
			{
				if(!m_isGachaTransition)
				{
					NoGachaPopupShow();
				}
				else
				{
					GachaPopupShow();
				}
			}
			else
			{
				if(InputEnable != null)
					InputEnable();
				PopupWindowManager.Close(null, null);
				MenuScene.Instance.GotoTitle();
			}
		}

		// // RVA: 0xF8A638 Offset: 0xF8A638 VA: 0xF8A638
		private void GachaPopupShow()
		{
			m_gachaSetting.GachaProductData = m_gachaProductData;
			PopupWindowManager.Show(m_gachaSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel btnlabel) =>
			{
				//0xF8A8EC
				if(btnlabel == PopupButton.ButtonLabel.Ok)
				{
					PopupWindowManager.Close(null, null);
					ChangeEpisodeGatchScene();
				}
				else if(btnlabel == PopupButton.ButtonLabel.Cancel)
				{
					PopupEpisodeBonusPlateSort.Show();
				}
			}, null, null, () =>
			{
				//0xF8A9B0
				if(InputEnable != null)
					InputEnable();
			}, true, true, false);
		}

		// // RVA: 0xF8A7A0 Offset: 0xF8A7A0 VA: 0xF8A7A0
		private void NoGachaPopupShow()
		{
			PopupWindowManager.Show(m_noGachaTextSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel btnlabel) =>
			{
				//0xF8A9C4
				PopupEpisodeBonusPlateSort.Show();
			}, null, null, () =>
			{
				//0xF8A9EC
				if(InputEnable != null)
					InputEnable();
			}, true, true, false);
		}
	}
}
