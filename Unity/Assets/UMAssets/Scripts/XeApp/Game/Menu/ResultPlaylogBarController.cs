using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using XeApp.Game.RhythmGame;

namespace XeApp.Game.Menu
{
	public class ResultPlaylogBarController : MonoBehaviour
	{
		public enum GraphColorType
		{
			None = -1,
			Normal = 0,
			Back = 1,
			HighLight = 2,
			Num = 3,
		}

		[Serializable]
		private class GraphColorData
		{
			public Color left = Color.white; // 0x8
			public Color right = Color.white; // 0x18
		}

		[Serializable]
		private class GraphColorDataTable
		{
			public GraphColorData[] table = new GraphColorData[5]; // 0x8
		}

		private class ResultData
		{
			public RawImage image; // 0x8
			public int count; // 0xC
		}

		[SerializeField]
		private GraphColorDataTable[] GraphColorTable = new GraphColorDataTable[3]; // 0xC
		private static readonly string[] BAR_OBJ_NAME_TABLE = new string[5] {
			"bar_miss", "bar_bad", "bar_good", "bar_great", "bar_perfect"
		}; // 0x0
		private static readonly float GRAPH_CHANGE_ANIM_TIME = 0.2f; // 0x4
		private ResultData[] m_ResultDataList = new ResultData[5]; // 0x10
		private Vector2 m_BarSize = Vector2.zero; // 0x14
		private int m_ResultCount; // 0x1C
		private int m_MaxCount; // 0x20
		private PopupPlaylogDetail.GraphType m_GraphType = PopupPlaylogDetail.GraphType.None; // 0x24
		private int m_ChangeGraphAnimCount; // 0x28

		// RVA: 0xB4C6C8 Offset: 0xB4C6C8 VA: 0xB4C6C8
		public void Awake()
		{
			for(int i = 0; i < BAR_OBJ_NAME_TABLE.Length; i++)
			{
				m_ResultDataList[i] = new ResultData() { 
					image = transform.Find(BAR_OBJ_NAME_TABLE[i]).GetComponent<RawImage>()
				};
			}
		}

		// RVA: 0xB4C8B4 Offset: 0xB4C8B4 VA: 0xB4C8B4
		public void Setup(ResultPlaylogBarController.GraphColorType type, Vector2 size, List<RhythmGamePlayLog.NoteData> list, int max_count)
		{
			TodoLogger.Log(0, "Setup");
		}

		// // RVA: 0xB4CD04 Offset: 0xB4CD04 VA: 0xB4CD04
		// public void ChangeGraphType(PopupPlaylogDetail.GraphType type) { }

		// // RVA: 0xB4D0AC Offset: 0xB4D0AC VA: 0xB4D0AC
		// public void EnterGraphAnim(RhythmGameConsts.NoteResult type, float time) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7225DC Offset: 0x7225DC VA: 0x7225DC
		// // RVA: 0xB4CFC4 Offset: 0xB4CFC4 VA: 0xB4CFC4
		// private IEnumerator Co_ChangeGraphAnim(RawImage image, float height, float time) { }

		// [IteratorStateMachineAttribute] // RVA: 0x722654 Offset: 0x722654 VA: 0x722654
		// // RVA: 0xB4D170 Offset: 0xB4D170 VA: 0xB4D170
		// private IEnumerator Co_EnterGraphAnim(RhythmGameConsts.NoteResult type, float height, float time) { }

		// // RVA: 0xB4D298 Offset: 0xB4D298 VA: 0xB4D298
		// public void FinishAnim() { }

		// // RVA: 0xB4D2BC Offset: 0xB4D2BC VA: 0xB4D2BC
		public bool IsPlayingChangeGraphAnim()
		{
			TodoLogger.Log(0, "IsPlayingChangeGraphAnim");
			return false;
		}
	}
}
