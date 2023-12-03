
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferGetAllItemPopupSetting : PopupSetting
	{
		public bool isItemLimit; // 0x34

		public override string PrefabPath { get { return ""; } } //0x152A86C
		public override string BundleName { get { return "ly/143.xab"; } } //0x152A8C8
		public override string AssetName { get { return "root_sel_vfo_result_pop_layout_root"; } } //0x152A924
		public override bool IsAssetBundle { get { return true; } } //0x152A980
		public override bool IsPreload { get { return false; } } //0x152A988
		public override GameObject Content { get { return m_content; } } //0x152A990

		//// RVA: 0x152A998 Offset: 0x152A998 VA: 0x152A998
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F843C Offset: 0x6F843C VA: 0x6F843C
		// RVA: 0x152A9A0 Offset: 0x152A9A0 VA: 0x152A9A0 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			int loadCount; // 0x20
			AssetBundleLoadLayoutOperationBase layOp; // 0x24

			//0x152AD10
			loadCount = 0;
			layOp = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x152AA70
				m_content = instance;
			}));
			Content.transform.SetParent(parent, false);
			OfferAllRecvItemPopup itemPopup = Content.GetComponent<OfferAllRecvItemPopup>();
			loadCount++;
			layOp = null;
			List<OfferAllRecvItemContent> itemContentList = new List<OfferAllRecvItemContent>();
			layOp = AssetBundleManager.LoadLayoutAsync(BundleName, "root_sel_vfo_item2_layout_root");
			LayoutUGUIRuntime baseRuntime = null;
			ScrollRect scrollRect = itemPopup.GetComponentInChildren<ScrollRect>(true);
			scrollRect.horizontal = false;
			scrollRect.vertical = true;
			Transform range = scrollRect.content.Find("Range");
			yield return layOp;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x152AAA0
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = baseRuntime.name.Replace("(Clone)", "_00");
				instance.transform.SetParent(range, false);
				itemContentList.Add(instance.GetComponent<OfferAllRecvItemContent>());
				itemPopup.List.AddScrollObject(itemContentList[itemContentList.Count - 1]);
			}));
			for(int i = 0; i < OfferAllRecvItemPopup.LastCompensationList.Count; i++)
			{
				;
			}
			for(int i = 0; i < itemPopup.List.ScrollObjectCount; i++)
			{
				LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(baseRuntime);
				r.name = baseRuntime.name.Replace("00", i.ToString("D2"));
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				r.transform.SetParent(range, false);
				itemContentList.Add(r.GetComponent<OfferAllRecvItemContent>());
				itemPopup.List.AddScrollObject(itemContentList[itemContentList.Count - 1]);
			}
			layOp = null;
			loadCount++;
			yield return null;
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
		}
	}
}
