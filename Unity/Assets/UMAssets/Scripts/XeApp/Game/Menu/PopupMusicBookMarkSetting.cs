
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;

namespace XeApp.Game.Menu
{ 
	public class PopupMusicBookMarkSetting : PopupSettingUGUI
	{
		public override string PrefabPath { get { return ""; } } //0x16935E8
		public override string AssetName { get { return "PopupMusicBookMarkContent"; } } //0x1693644
		public override string BundleName { get { return "ly/038.xab"; } } //0x16936A0
		public override bool IsAssetBundle { get { return true; } } //0x16936FC
		public override bool IsPreload { get { return true; } } //0x1693704
		public override GameObject Content { get { return m_content; } } //0x169370C
		public PopupMusicBookMarkContentLayout Layout { get; set; } // 0x34
		public IBJAKJJICBC SelectMusicData { get; set; } // 0x38
		public List<VerticalMusicDataList> VerticalMusicDataList { get; set; } // 0x3C
		public bool Initialize { get; set; } // 0x40

		//// RVA: 0x1693714 Offset: 0x1693714 VA: 0x1693714
		//public void SetContent(GameObject obj) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F5534 Offset: 0x6F5534 VA: 0x6F5534
		// RVA: 0x169373C Offset: 0x169373C VA: 0x169373C Slot: 4
		public override IEnumerator LoadAssetBundlePrefab(Transform parent)
		{
			//0x1693868
			m_parent = parent;
			yield return Co.R(base.LoadAssetBundlePrefab(parent));
			Layout = m_content.GetComponent<PopupMusicBookMarkContentLayout>();
			yield return null;
		}

		//// RVA: 0x1693804 Offset: 0x1693804 VA: 0x1693804
		public void SelectMusicSetMusicBookMark()
		{
			Layout.SetMusicBookMark();
		}

		//// RVA: 0x169382C Offset: 0x169382C VA: 0x169382C
		public bool IsChangeBookMark()
		{
			return Layout.IsChangeBookMark();
		}

		//[DebuggerHiddenAttribute] // RVA: 0x6F55AC Offset: 0x6F55AC VA: 0x6F55AC
		//[CompilerGeneratedAttribute] // RVA: 0x6F55AC Offset: 0x6F55AC VA: 0x6F55AC
		//// RVA: 0x169385C Offset: 0x169385C VA: 0x169385C
		//private IEnumerator <>n__0(Transform parent) { }
	}
}
