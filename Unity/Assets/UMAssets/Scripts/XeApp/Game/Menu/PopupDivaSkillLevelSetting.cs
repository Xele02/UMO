
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class PopupDivaSkillLevelSetting : PopupSetting
	{
		public int selectMusicId { get; set; } // 0x34
		public override string PrefabPath { get { return "Menu/Prefab/PopupWindow/root_pop_diva_exp_layout_root"; } } //0xF821DC
		public override string BundleName { get { return "ly/042.xab"; } } //0xF82238
		public override string AssetName { get { return "root_pop_diva_exp_layout_root"; } } //0xF82294
		public override bool IsAssetBundle { get { return true; } } //0xF822F0
		public override bool IsPreload { get { return true; } } //0xF822F8
		public override GameObject Content { get { return m_content; } } //0xF82300

		//// RVA: 0xF82308 Offset: 0xF82308 VA: 0xF82308
		public void SetContent(GameObject obj)
		{
			m_content = obj;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x707B1C Offset: 0x707B1C VA: 0x707B1C
		//// RVA: 0xF82310 Offset: 0xF82310 VA: 0xF82310 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			int loadCount; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			LayoutPopupDivaSkillInfoScrollList divaSkillLevelScrollListLayout; // 0x20
			List<LayoutPopupDivaSkillInfoItem> divaSkillItemLayout; // 0x24
			int num; // 0x28
			int counter; // 0x2C

			//0xF82474
			loadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, AssetName);
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xF823CC
				m_content = instance;
			}));
			loadCount++;
			divaSkillLevelScrollListLayout = m_content.GetComponent<LayoutPopupDivaSkillInfoScrollList>();
			divaSkillItemLayout = new List<LayoutPopupDivaSkillInfoItem>();
			num = 5;
			counter = 0;
			loadCount++;
			operation = AssetBundleManager.LoadLayoutAsync(BundleName, "root_pop_diva_exp_info_layout_root");
			LayoutUGUIRuntime sourceObject = null;
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xF823F4
				sourceObject = instance.GetComponent<LayoutUGUIRuntime>();
			}));
			for(; counter < num; counter++)
			{
				LayoutUGUIRuntime r = UnityEngine.Object.Instantiate(sourceObject);
				r.IsLayoutAutoLoad = false;
				r.UvMan = sourceObject.UvMan;
				r.Layout = sourceObject.Layout.DeepClone();
				r.LoadLayout();
				divaSkillItemLayout.Add(r.GetComponent<LayoutPopupDivaSkillInfoItem>());
			}
			for(int i = 0; i < loadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(BundleName, false);
			}
			yield return null;
			UnityEngine.Object.Destroy(sourceObject.gameObject);
			divaSkillLevelScrollListLayout.AddView(divaSkillItemLayout);
			m_content.transform.SetParent(m_parent, false);
			m_content.gameObject.SetActive(false);
			for(int i = 0; i < divaSkillItemLayout.Count; i++)
			{
				divaSkillItemLayout[i].Hide();
			}
		}
	}
}
