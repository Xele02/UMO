
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusListSetting : PopupSetting
	{
		private List<IKDICBBFBMI_EventBase.GNPOABJANKO> episodeList = new List<IKDICBBFBMI_EventBase.GNPOABJANKO>(); // 0x34

		public override string PrefabPath { get { return ""; } } //0xF86398
		public override string AssetName { get { return "root_pop_ep_eve_layout_root"; } } //0xF863F4
		public override string BundleName { get { return "ly/015.xab"; } } //0xF86450
		public override bool IsAssetBundle { get { return true; } } //0xF864AC
		public override bool IsPreload { get { return true; } } //0xF864B4
		//public List<IKDICBBFBMI_EventBase.GNPOABJANKO> EpisodeList { get; } 0xF85C50
		public CIKHPBBNEIM ViewEpisodeBonus { get; set; } // 0x38

		//// RVA: 0xF864C4 Offset: 0xF864C4 VA: 0xF864C4
		public void Setup(List<IKDICBBFBMI_EventBase.GNPOABJANKO> episodeList, CIKHPBBNEIM viewEpisodeBonus)
		{
			this.episodeList.Clear();
			this.episodeList.AddRange(episodeList);
			ViewEpisodeBonus = viewEpisodeBonus;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72E59C Offset: 0x72E59C VA: 0x72E59C
		//								// RVA: 0xF86578 Offset: 0xF86578 VA: 0xF86578 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			int loadCount; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C

			//0xF866D8
			m_parent = parent;
			if (m_content != null)
				yield break;
			loadCount = 0;

			operation = AssetBundleManager.LoadLayoutAsync(BundleName.ToString(), AssetName.ToString());
			yield return Co.R(operation);

			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				m_content = instance;
			}));

			loadCount++;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName.ToString(), false);
			}
			m_content.transform.SetParent(m_parent, false);
			m_content.gameObject.SetActive(false);
			operation = null;
		}
	}
}
