using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class DecoCustomDecorator : MonoBehaviour
	{
		public enum DecoratorType
		{
			Chara = 0,
			Serif = 1,
			Num = 2,
		}

		public enum TabType
		{
			None = -1,
			Use = 0,
			Temp = 1,
			serif1 = 2,
			serif2 = 3,
			serif3 = 4,
			serif4 = 5,
			pose1 = 6,
			pose2 = 7,
			pose3 = 8,
		}

		public class TabCallBackData
		{
			public int m_tabNumIndex; // 0x8
			public TabType[] m_typeList; // 0xC

			// RVA: 0xC5A284 Offset: 0xC5A284 VA: 0xC5A284
			public TabCallBackData(int tabNumTable, TabType[] typeList)
			{
				m_tabNumIndex = tabNumTable;
				m_typeList = typeList;
			}
		}

		private readonly string AssetName = "root_cstm_deco_win_01_layout_root"; // 0xC
		public TabCallBackData[] tabCallBackList = new TabCallBackData[2]
			{
				new TabCallBackData(1, new TabType[4] { TabType.Use, TabType.pose1, TabType.pose2, TabType.pose3 }),
				new TabCallBackData(0, new TabType[6] { TabType.Use, TabType.Temp, TabType.serif1, TabType.serif2, TabType.serif3, TabType.serif4 })
			}; // 0x10
		private LayoutDecoCustomWindow01 m_layoutDecorationWindow01; // 0x14
		private DecoratorType m_type; // 0x18
		private TabType m_tab; // 0x1C
		private Action m_closeCallBack; // 0x20
		public Action ClickLeftButtonCallback; // 0x28
		public Action ClickRightButtonCallback; // 0x2C
		public Action<LayoutDecoCustomSelectItemBase> DecideItemCallback; // 0x30
		public Action<int> SelectIdCallback; // 0x34

		public bool IsLoaded { get; private set; } // 0x24
		public bool IsLoadedResource { get; private set; } // 0x25
		public int TargetStampId { get { return m_layoutDecorationWindow01.TargetStampId; } set { m_layoutDecorationWindow01.TargetStampId = value; } } //0xC59FA0 0xC59FCC
		public int TargetSerifId { get { return m_layoutDecorationWindow01.TargetSerifId; } set { m_layoutDecorationWindow01.TargetSerifId = value; } } //0xC5A000 0xC5A02C
		public bool IsMatchEditChara { get; set; } // 0x38
		public int OriginEditCharaId { get; set; } // 0x3C
		public int OriginEditSerifId { get; set; } // 0x40
		public bool IsCreate { get; set; } // 0x44
		public bool RightButtonHidden { set { m_layoutDecorationWindow01.RightButtonHidden = value; } } //0xC5A7E4
		public bool LeftButtonHidden { set { m_layoutDecorationWindow01.LeftButtonHidden = value; } } //0xC5A818

		//// RVA: 0xC59E80 Offset: 0xC59E80 VA: 0xC59E80
		public void TabCallBack(int index)
		{
			m_tab = tabCallBackList[(int)m_type].m_typeList[index];
			m_layoutDecorationWindow01.ChangeTab(m_type, m_tab);
		}

		//// RVA: 0xC59F48 Offset: 0xC59F48 VA: 0xC59F48
		public void UpdateScrollList()
		{
			m_layoutDecorationWindow01.UpdateTab(m_type, m_tab);
		}

		//// RVA: 0xC5A0A0 Offset: 0xC5A0A0 VA: 0xC5A0A0
		public void LoadResoruce()
		{
			IsLoaded = false;
			int is_enable_famous_phrase_4 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.LPJLEHAJADA("is_enable_famous_phrase_4", 0);
			if(is_enable_famous_phrase_4 == 0)
			{
				tabCallBackList[1] = new TabCallBackData(2, new TabType[5] { TabType.Use, TabType.Temp, TabType.serif1, TabType.serif2, TabType.serif3 });
			}
			this.StartCoroutineWatched(LoadResource());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D758C Offset: 0x6D758C VA: 0x6D758C
		//// RVA: 0xC5A2AC Offset: 0xC5A2AC VA: 0xC5A2AC
		private IEnumerator LoadResource()
		{
			//0xC5AE74
			yield return this.StartCoroutineWatched(LoadWindow());
			IsLoaded = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D7604 Offset: 0x6D7604 VA: 0x6D7604
		//// RVA: 0xC5A358 Offset: 0xC5A358 VA: 0xC5A358
		private IEnumerator LoadWindow()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0xC5AFBC
			op = AssetBundleManager.LoadLayoutAsync("ly/206.xab", AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xC5AAA8
				instance.transform.SetParent(transform, false);
				m_layoutDecorationWindow01 = instance.GetComponent<LayoutDecoCustomWindow01>();
				m_layoutDecorationWindow01.Hide();
				m_layoutDecorationWindow01.OnClickRightButton = OnClickRightButton;
				m_layoutDecorationWindow01.OnClickLeftButton = OnClickLeftButton;
				m_layoutDecorationWindow01.OnDecideItem = DecideItemCallback;
			}));
		}

		//// RVA: 0xC5A404 Offset: 0xC5A404 VA: 0xC5A404
		public void LoadSelectItem(DecoratorType type, List<LayoutDecoCustomWindow01.SelectItemData> selectItemData)
		{
			IsLoadedResource = false;
			m_type = type;
			this.StartCoroutineWatched(Co_LoadSelectItem(selectItemData));
		}

		//// RVA: 0xC5A4E4 Offset: 0xC5A4E4 VA: 0xC5A4E4
		public void ReSetItemList(List<LayoutDecoCustomWindow01.SelectItemData> selectItemData)
		{
			m_layoutDecorationWindow01.ResetList(selectItemData);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D767C Offset: 0x6D767C VA: 0x6D767C
		//// RVA: 0xC5A43C Offset: 0xC5A43C VA: 0xC5A43C
		public IEnumerator Co_LoadSelectItem(List<LayoutDecoCustomWindow01.SelectItemData> selectItemData)
		{
			//0xC5AC84
			m_layoutDecorationWindow01.LoadResource(m_type == DecoratorType.Serif ? LayoutDecoCustomWindow01.SelectItemType.Serif : LayoutDecoCustomWindow01.SelectItemType.Chara, selectItemData);
			yield return new WaitUntil(() =>
			{
				//0xC5AC54
				return m_layoutDecorationWindow01.IsLoaded;
			});
			IsLoadedResource = true;
		}

		//// RVA: 0xC5A538 Offset: 0xC5A538 VA: 0xC5A538
		//private LayoutDecoCustomWindow01.SelectItemType DecorationTypeToSelectItemType() { }

		//// RVA: 0xC5A554 Offset: 0xC5A554 VA: 0xC5A554
		public void OnClickRightButton()
		{
			ClickRightButtonCallback();
		}

		//// RVA: 0xC5A580 Offset: 0xC5A580 VA: 0xC5A580
		public void OnClickLeftButton()
		{
			ClickLeftButtonCallback();
		}

		//// RVA: 0xC5A5AC Offset: 0xC5A5AC VA: 0xC5A5AC
		public void Enter()
		{
			if (IsMatchEditChara && m_type == DecoratorType.Serif)
				TargetSerifId = OriginEditSerifId;
			m_layoutDecorationWindow01.Enter(m_type, tabCallBackList[(int)m_type].m_tabNumIndex, tabCallBackList[(int)m_type].m_typeList, TabCallBack, IsCreate, IsMatchEditChara, SelectIdCallback);
		}

		//// RVA: 0xC5A760 Offset: 0xC5A760 VA: 0xC5A760
		public void ReShow()
		{
			m_layoutDecorationWindow01.Open();
		}

		//// RVA: 0xC5A78C Offset: 0xC5A78C VA: 0xC5A78C
		public void Leave()
		{
			if (!m_layoutDecorationWindow01.IsOpen)
				return;
			m_layoutDecorationWindow01.Leave();
		}

		//// RVA: 0xC5A84C Offset: 0xC5A84C VA: 0xC5A84C
		public bool IsPlayingEnd()
		{
			return m_layoutDecorationWindow01.IsPlayingEnd();
		}

		//// RVA: 0xC5A878 Offset: 0xC5A878 VA: 0xC5A878
		public void ScrollVisibleUpdate()
		{
			m_layoutDecorationWindow01.ScrollVisibleUpdate();
		}
	}
}
