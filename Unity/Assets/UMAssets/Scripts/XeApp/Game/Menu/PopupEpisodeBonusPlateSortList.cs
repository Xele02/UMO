using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusPlateSortListSetting : PopupSetting
	{
		private LayoutEpisodeBonusSortWindow m_episodeLayout; // 0x34

		public override string PrefabPath { get { return ""; } } //0xF88ED8
		public override string AssetName { get { return "root_pop_ep_plate_win_layout_root"; } } //0xF88F34
		public override string BundleName { get { return "ly/015.xab"; } } //0xF88F90
		public override bool IsAssetBundle { get { return true; } } //0xF88FEC
		public override bool IsPreload { get { return true; } } //0xF88FF4
		public override GameObject Content { get { return m_content; } } //0xF88FFC
		public int ScrollItemCount { get; set; } // 0x38
		public UnityAction<int, SwapScrollListContent> UpdateList { get; set; } // 0x3C

		// // RVA: 0xF89004 Offset: 0xF89004 VA: 0xF89004
		// public void SetContent(GameObject obj) { }

		// [IteratorStateMachineAttribute] // RVA: 0x72E704 Offset: 0x72E704 VA: 0x72E704
		// RVA: 0xF8900C Offset: 0xF8900C VA: 0xF8900C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			int poolSize; // 0x1C
			List<SwapScrollListContent> contentList; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int i; // 0x28

			//0xF891E8
			m_parent = parent;
			yield return Co.R(AssetBundleManager.LoadUnionAssetBundle(BundleName));
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			m_episodeLayout = m_content.GetComponent<LayoutEpisodeBonusSortWindow>();
			poolSize = m_episodeLayout.ScrollList.ScrollObjectCount;
			contentList = new List<SwapScrollListContent>();
			LayoutUGUIRuntime baseRuntime = null;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_ep_plate_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xF890E4
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				m_episodeLayout.ScrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Object.Instantiate(baseRuntime);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				contentList.Add(r.GetComponent<SwapScrollListContent>());
			}
			while(!m_episodeLayout.IsLoaded())
				yield return null;
			for(i = 0; i < contentList.Count; i++)
			{
				while(!contentList[i].IsLoaded())
					yield return null;
				m_episodeLayout.ScrollList.AddScrollObject(contentList[i]);
			}
			m_episodeLayout.ScrollList.Apply();
			AssetBundleManager.UnloadAssetBundle(BundleName, false);
		}

		// [CompilerGeneratedAttribute] // RVA: 0x72E77C Offset: 0x72E77C VA: 0x72E77C
		// [DebuggerHiddenAttribute] // RVA: 0x72E77C Offset: 0x72E77C VA: 0x72E77C
		// // RVA: 0xF890D4 Offset: 0xF890D4 VA: 0xF890D4
		// private IEnumerator <>n__0(Transform parent) { }
	}

	public class PopupEpisodeBonusPlateSortList
	{
		private MonoBehaviour m_monoBehaviour; // 0x8
		private PopupEpisodeBonusPlateSortListSetting m_epispdeSetting = new PopupEpisodeBonusPlateSortListSetting(); // 0xC
		private PopupEpisodeGachaList m_gachaList = new PopupEpisodeGachaList(); // 0x10
		private int m_episodeId; // 0x14
		private CIKHPBBNEIM m_viewEpisodeBonus; // 0x18

		public PopupEpisodeGachaList popupEpisodeGachaList { get { return m_gachaList; } } //0xF881B8
		public HomeBannerTextureCache bannerTexCache { get; set; } // 0x1C

		// RVA: 0xF84B30 Offset: 0xF84B30 VA: 0xF84B30
		public void Initialize(Transform parent, MonoBehaviour monoBehaviour)
		{
			m_monoBehaviour = monoBehaviour;
			m_epispdeSetting.WindowSize = SizeType.Large;
			m_epispdeSetting.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.GachaPull, Type = PopupButton.ButtonType.Positive }
			};
			m_epispdeSetting.SetParent(parent);
			m_epispdeSetting.UpdateList = OnUpdateList;
			m_gachaList.bannerTexCache = bannerTexCache;
			m_gachaList.Initialize(parent);
		}

		// RVA: 0xF86018 Offset: 0xF86018 VA: 0xF86018
		public void Setup(int episodeId, CIKHPBBNEIM viewEpisodeBonus)
		{
			m_episodeId = episodeId;
			m_viewEpisodeBonus = viewEpisodeBonus;
			m_epispdeSetting.UpdateList = OnUpdateList;
			m_epispdeSetting.TitleText = string.Format(MessageManager.Instance.GetMessage("menu", "popup_episodebonus_platelist_title"), PIGBBNDPPJC.EJOJNFDHDHN_GetEpName(episodeId));
			m_epispdeSetting.ScrollItemCount = m_viewEpisodeBonus.GGHMLFOFELH(episodeId).FLJNOOPOAGI.Count;
			m_gachaList.PopupEpisodeBonusPlateSort = this;
			m_gachaList.GachaId = m_viewEpisodeBonus.GGHMLFOFELH(episodeId).MLLPMJFOKEC[0];
		}

		// RVA: 0xF86290 Offset: 0xF86290 VA: 0xF86290
		public void Show()
		{
			PopupWindowManager.Show(m_epispdeSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel btnlabel) =>
			{
				//0xF88A78
				if(btnlabel != PopupButton.ButtonLabel.GachaPull)
					return;
				m_monoBehaviour.StartCoroutineWatched(m_gachaList.Show());
			}, null, null, null, true, true, false);
		}

		// RVA: 0xF88674 Offset: 0xF88674 VA: 0xF88674
		private void OnUpdateList(int index, SwapScrollListContent content)
		{
			EpisodeBonusPlateScrollContent c = content as EpisodeBonusPlateScrollContent;
			if(c != null)
			{
				EpisodeBonusPlateScrollContent.ShowEpisodeBonusAnimationInfo info = new EpisodeBonusPlateScrollContent.ShowEpisodeBonusAnimationInfo();
				GCIJNCFDNON_SceneInfo scene = null;
				if(index < m_viewEpisodeBonus.GGHMLFOFELH(m_episodeId).FLJNOOPOAGI.Count)
				{
                    CIKHPBBNEIM.ODGCADPPIFA d = m_viewEpisodeBonus.GGHMLFOFELH(m_episodeId).FLJNOOPOAGI[index];
					info.isDisplay = true;
					info.isHave = d.IADCHIFJHOJ_Unlocked;
					info.isAvailable = d.ILOKENBBBAE_Available;
					info.isEvo = d.ONCKEDBOIDN_IsEvo;
					info.isAssist = d.GKBNFLFEIOF_IsAssist;
					info.isAssistEvo = d.JKCLMIDAIMI_IsAssistEvo;
					info.bonusBefore = d.FDLEABMKOGO_BonusBefore;
					info.bonusAfter = d.ALDAOOLPHCH_BonusAfter;
					scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[d.BCCHOBPJJKE_SceneId - 1];
				}
				c.UpdateContent(scene, info);
			}
		}
	}
}
