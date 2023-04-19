
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PopupMusicGradeGetRewardSetting : PopupSetting
	{
		public HighScoreRatingRank.Type NowGrade { get; set; } // 0x34
		public List<HighScoreRating.UtaGradeData> RewardList { get; set; } // 0x38
		public override string PrefabPath { get { return ""; } } //0x16955B8
		public override string BundleName { get { return "ly/111.xab"; } } //0x1695614
		public override string AssetName { get { return "root_pop_m_rate_reward_layout_root"; } } //0x1695670
		public override bool IsAssetBundle { get { return true; } } //0x16956CC
		public override bool IsPreload { get { return false; } } //0x16956D4
		public override GameObject Content { get { return m_content; } } //0x16956DC

		//// RVA: 0x16956E4 Offset: 0x16956E4 VA: 0x16956E4
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x7065D4 Offset: 0x7065D4 VA: 0x7065D4
		//// RVA: 0x16956EC Offset: 0x16956EC VA: 0x16956EC Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1696024
			m_parent = parent;
			if(m_content == null)
			{
				yield return Co.R(Co_LoadPopupResource());
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70664C Offset: 0x70664C VA: 0x70664C
		//// RVA: 0x16957B4 Offset: 0x16957B4 VA: 0x16957B4
		public IEnumerator Co_LoadPopupResource()
		{
			int loadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase operation; // 0x20

			//0x16959FC
			loadCount = 0;
			LayoutPopupMusicGradeGetRewardList layout = null;
			if(m_content == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_m_rate_reward_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1695870
					m_content = instance;
					layout = instance.GetComponent<LayoutPopupMusicGradeGetRewardList>();
				}));
				loadCount++;
				yield return null;
			}
			//LAB_01695c9c
			GameObject itemObj = null;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_m_rate_item_pt_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x169590C
				itemObj = instance;
				layout.FxScrollView.AddLayoutCache(0, instance.GetComponent<LayoutUGUIRuntime>(), 7);
			}));
			UnityEngine.Object.Destroy(itemObj);
			loadCount++;
			operation = null;
			for (int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
		}
	}
}
