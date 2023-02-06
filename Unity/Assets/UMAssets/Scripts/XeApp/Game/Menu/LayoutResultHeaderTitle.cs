using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutResultHeaderTitle : LayoutUGUIScriptBase
	{
		public enum TitleType
		{
			LIVE = 0,
			S_LIVE = 1,
			SKIP = 2,
			SUPPORT = 3,
		}

		private AbsoluteLayout layoutRoot; // 0x14
		private AbsoluteLayout layoutSkipCount; // 0x18
		public Action onFinished; // 0x1C
		private Rect[] m_titleUvArray; // 0x20
		private Rect[] m_titleBgUvArray; // 0x24
		private Text m_textSkipCount; // 0x28
		private RawImageEx[] m_titleImage; // 0x2C
		private RawImageEx m_titleBgImage; // 0x30

		// RVA: 0x18DEC70 Offset: 0x18DEC70 VA: 0x18DEC70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			layoutRoot = layout.FindViewById("sw_midasi_in_anim") as AbsoluteLayout;
			layoutSkipCount = layout.FindViewById("sw_g_r_skipnum_bg_onoff_anim") as AbsoluteLayout;
			string[] strs = new string[4]
			{
				"g_r_midasi", "g_r_midasi_02", "g_r_midasi_03", "g_r_midasi_04"
			};
			m_titleUvArray = new Rect[4];
			for(int i = 0; i < m_titleUvArray.Length; i++)
			{
				m_titleUvArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(strs[i]));
			}
			strs = new string[4]
			{
				"g_r_midasi_ef_1", "g_r_midasi_ef_1", "g_r_midasi_ef_3", "g_r_midasi_ef_3"
			};
			m_titleBgUvArray = new Rect[4];
			for(int i = 0; i < m_titleBgUvArray.Length; i++)
			{
				m_titleBgUvArray[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(strs[i]));
			}
			Text[] ts = GetComponentsInChildren<Text>(true);
			m_textSkipCount = System.Array.Find(ts, (Text _) =>
			{
				//0x18DFDBC
				return _.name == "skip_num (TextView)";
			});
			RawImageEx[] rs = GetComponentsInChildren<RawImageEx>(true);
			m_titleImage = System.Array.FindAll(rs, (RawImageEx _) =>
			{
				//0x18DFE3C
				return _.name.StartsWith("g_r_midasi (ImageView)");
			});
			m_titleBgImage = System.Array.Find(rs, (RawImageEx _) =>
			{
				//0x18DFED4
				return _.name.StartsWith("g_r_midasi_ef_1 (ImageView)");
			});
			Loaded();
			return true;
		}

		//// RVA: 0x18DF894 Offset: 0x18DF894 VA: 0x18DF894
		public void StartBeginAnim()
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			this.StartCoroutineWatched(Co_PlayingStartPopupAnim());
		}

		//// RVA: 0x18DF9C4 Offset: 0x18DF9C4 VA: 0x18DF9C4
		public void StartAlreadyAnim()
		{
			layoutRoot.StartChildrenAnimLoop("logo_act", "loen_act");
		}

		//// RVA: 0x18DFA50 Offset: 0x18DFA50 VA: 0x18DFA50
		public void SkipAnim()
		{
			StartAlreadyAnim();
		}

		//// RVA: 0x18DFA54 Offset: 0x18DFA54 VA: 0x18DFA54
		public void ChangeTitle(TitleType type)
		{
			for(int i = 0; i < m_titleImage.Length; i++)
			{
				m_titleImage[i].uvRect = m_titleUvArray[(int)type];
			}
			m_titleBgImage.uvRect = m_titleBgUvArray[(int)type];
		}

		//// RVA: 0x18DFBC8 Offset: 0x18DFBC8 VA: 0x18DFBC8
		public void SetSkipCount(int count)
		{
			if(count < 2)
			{
				layoutSkipCount.StartChildrenAnimGoStop("02");
				return;
			}
			m_textSkipCount.text = string.Format("{0}StringLiteral_17960", m_textSkipCount);
			layoutSkipCount.StartChildrenAnimGoStop("01");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x71C064 Offset: 0x71C064 VA: 0x71C064
		//// RVA: 0x18DF938 Offset: 0x18DF938 VA: 0x18DF938
		private IEnumerator Co_PlayingStartPopupAnim()
		{
			//0x18DFF70
			yield return new WaitWhile(() => {
				//0x18DFD14
				return layoutRoot.IsPlayingChildren();
			});
			StartAlreadyAnim();
			if(onFinished != null)
				onFinished();
		}
	}
}
