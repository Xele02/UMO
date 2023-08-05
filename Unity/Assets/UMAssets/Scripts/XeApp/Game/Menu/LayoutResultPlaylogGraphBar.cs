using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogGraphBar : LayoutUGUIScriptBase
	{
		private class GraphData
		{
			public GameObject obj; // 0x8
			public ResultPlaylogBarController control; // 0xC
		}

		// Fields
		private static readonly string[] GRAPH_OBJECT_NAME = new string[3]
			{
				"sw_graph_set (AbsoluteLayout)/graph (AbsoluteLayout)",
				"sw_graph_set (AbsoluteLayout)/graph_back (AbsoluteLayout)",
				"sw_graph_set (AbsoluteLayout)/graph_hl (AbsoluteLayout)"
			}; // 0x0
		private GraphData[] m_GraphData = new GraphData[3]; // 0x14
		private Text m_TimeText; // 0x18
		private Button m_GraphTouchArea; // 0x1C
		private bool m_IsStartInitialize; // 0x20
		private Action<int> m_OnClickGraph; // 0x24

		public Action<int> OnClickGraph { set { m_OnClickGraph = value; } } //0x1D06574

		// RVA: 0x1D0657C Offset: 0x1D0657C VA: 0x1D0657C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_TimeText = GetComponentInChildren<Text>(true);
			m_GraphTouchArea = GetComponentInChildren<Button>(true);
			Loaded();
			return true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71CFEC Offset: 0x71CFEC VA: 0x71CFEC
		//// RVA: 0x1D06618 Offset: 0x1D06618 VA: 0x1D06618
		public IEnumerator Co_LoadAsset()
		{
			string bundle_name; // 0x14
			AssetBundleLoadAssetOperation operation; // 0x18
			GameObject prefab; // 0x1C
			int i; // 0x20

			//0x1D06C7C
			bundle_name = PopupPlaylogDetail.BUNDLE_NAME;
			operation = AssetBundleManager.LoadAssetAsync(bundle_name, "PlaylogBarObj", typeof(GameObject));
			yield return operation;
			i = 0;
			prefab = operation.GetAsset<GameObject>();
			while(i < 3)
			{
				GameObject po = Instantiate(prefab);
				GraphData data = new GraphData();
				data.obj = transform.Find(GRAPH_OBJECT_NAME[i]).gameObject;
				data.control = po.GetComponent<ResultPlaylogBarController>();
				m_GraphData[i] = data;
				po.transform.SetParent(data.obj.transform, false);
				yield return null;
				i++;
			}
			AssetBundleManager.UnloadAssetBundle(bundle_name, false);
			yield return null;
		}

		//// RVA: 0x1D066C4 Offset: 0x1D066C4 VA: 0x1D066C4
		public void Setup(int index, PopupPlaylogDetail.ViewPlaylogDetailData.ViewNoteResultData data, int max_count)
		{
			this.StartCoroutineWatched(Co_Setup(index, data, max_count));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71D064 Offset: 0x71D064 VA: 0x71D064
		//// RVA: 0x1D066F0 Offset: 0x1D066F0 VA: 0x1D066F0
		private IEnumerator Co_Setup(int index, PopupPlaylogDetail.ViewPlaylogDetailData.ViewNoteResultData data, int max_count)
		{
			//0x1D07264
			LayoutUGUIRuntime runtime = GetComponent<LayoutUGUIRuntime>();
			yield return new WaitWhile(() =>
			{
				//0x1D06B60
				return !(runtime.IsReady && IsLoaded());
			});
			m_TimeText.text = string.Format(JpStringLiterals.StringLiteral_18054, data.time_range_end);
			for(int i = 0; i < 3; i++)
			{
				m_GraphData[i].control.Setup((ResultPlaylogBarController.GraphColorType)i, m_GraphData[i].obj.GetComponent<RectTransform>().sizeDelta, data.note_list, max_count);
			}
			m_GraphTouchArea.onClick.AddListener(() =>
			{
				//0x1D06BC4
				if(m_OnClickGraph != null)
				{
					m_OnClickGraph(index);
				}
			});
		}

		//// RVA: 0x1D067E8 Offset: 0x1D067E8 VA: 0x1D067E8
		public void ChangeGraphType(PopupPlaylogDetail.GraphType type)
		{
			for(int i = 0; i < 3; i++)
			{
				m_GraphData[i].control.ChangeGraphType(type);
			}
		}

		//// RVA: 0x1D06878 Offset: 0x1D06878 VA: 0x1D06878
		public bool IsPlayingChangeGraphAnim()
		{
			for (int i = 0; i < 3; i++)
			{
				if (m_GraphData[i].control.IsPlayingChangeGraphAnim())
					return true;
			}
			return false; 
		}
	}
}
