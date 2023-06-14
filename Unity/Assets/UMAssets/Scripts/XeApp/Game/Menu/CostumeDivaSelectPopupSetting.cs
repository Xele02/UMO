
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{ 
	public class CostumeDivaSelectPopupSetting : PopupSetting
	{
		private List<int> m_filterDivaIdList = new List<int>(); // 0x34
		private bool m_IsReady; // 0x38

		public List<int> FilterDivaIdList { get { return m_filterDivaIdList; } set { m_filterDivaIdList = value; } } //0x1628D2C 0x1628D34
		public override string PrefabPath { get { return ""; } } //0x1628D3C
		public override string BundleName { get { return "ly/128.xab"; } } //0x1628D98
		public override string AssetName { get { return "PopupCostumeDivaSelect"; } } //0x1628DF4
		public override bool IsAssetBundle { get { return true; } } //0x1628E50
		public override bool IsPreload { get { return true; } } //0x1628E58
		public override GameObject Content { get { return m_content; } } //0x1628E60

		//// RVA: 0x1628E68 Offset: 0x1628E68 VA: 0x1628E68
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6CF50C Offset: 0x6CF50C VA: 0x6CF50C
		//// RVA: 0x1628E70 Offset: 0x1628E70 VA: 0x1628E70 Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x162973C
			m_IsReady = false;
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			yield return Co.R(m_content.GetComponent<CostumeDivaSelectWindow>().CreateDivaIcon());
			m_IsReady = true;
		}

		//// RVA: 0x1628F38 Offset: 0x1628F38 VA: 0x1628F38
		public void Update()
		{
			if (!m_IsReady)
				return;
			m_content.GetComponent<CostumeDivaSelectWindow>().Update();
		}

		//// RVA: 0x16291F4 Offset: 0x16291F4 VA: 0x16291F4
		public List<int> GetFilterDivaIdList()
		{
			if(m_content != null)
			{
				return m_content.GetComponent<CostumeDivaSelectWindow>().GetFilterDivaIdList();
			}
			return null;
		}

		//// RVA: 0x16294A0 Offset: 0x16294A0 VA: 0x16294A0
		public void SetFilterDivaIdList(List<int> divaList)
		{
			if (m_content != null)
			{
				m_content.GetComponent<CostumeDivaSelectWindow>().SetDivaFilterButton(divaList);
			}
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6CF584 Offset: 0x6CF584 VA: 0x6CF584
		//[CompilerGeneratedAttribute] // RVA: 0x6CF584 Offset: 0x6CF584 VA: 0x6CF584
		//// RVA: 0x1629730 Offset: 0x1629730 VA: 0x1629730
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
