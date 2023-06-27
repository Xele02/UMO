using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthRoad : SceneGrowthPanelBase
	{
		public enum Type
		{
			Normal = 0,
			Down = 1,
			Up = 2,
		}

		public enum ImageIndex
		{
			Effect = 0,
			EffectBase = 1,
			Base = 2,
		}

		private enum Flags
		{
			Expanded = 1,
		}

		[SerializeField]
		private Type m_type; // 0x28
		[SerializeField]
		private RawImageEx[] m_replaceUvImages; // 0x2C
		[SerializeField]
		private string m_rootExId; // 0x30
		[SerializeField]
		private string m_addEffectExId; // 0x34
		private static readonly string[,] m_uvNameTable = new string[8, 3]
			{
				{ "ab_root_s_1", "ab_root_s_2", "ab_root_s_3" },
				{ "ab_root_down_1", "ab_root_down_2", "ab_root_down_3" },
				{ "ab_root_up_1", "ab_root_up_2", "ab_root_up_3" },
				{ "ab_root_s_1", "ab_root_s_2", "ab_root_s_3" },
				{ "ab_root_m_s_1_t", "ab_root_m_s_2_t", "ab_root_m_s_3_t" },
				{ "ab_root_down_1_s", "ab_root_down_2_s", "ab_root_down_3_s" },
				{ "ab_root_up_1_s", "ab_root_up_2_s", "ab_root_up_3_s" },
				{ "ab_root_m_s_1_t", "ab_root_m_s_2_t", "ab_root_m_s_3_t" }
			}; // 0x0
		private AbsoluteLayout m_abs; // 0x38
		private AbsoluteLayout m_addEffectAbs; // 0x3C
		private TexUVListManager m_uvManager; // 0x40
		private int m_index; // 0x44
		private uint m_flags; // 0x48
		private bool m_isSub; // 0x4C
		private bool m_isCenter; // 0x4D
		private bool m_isPossible; // 0x4E

		public Type RoadType { get { return m_type; } } //0x10DD1C8
		//public int Index { get; } 0x10DD1D0

		// RVA: 0x10DD1D8 Offset: 0x10DD1D8 VA: 0x10DD1D8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_abs = layout.FindViewByExId(m_rootExId) as AbsoluteLayout;
			m_addEffectAbs = layout.FindViewByExId(m_addEffectExId) as AbsoluteLayout;
			m_uvManager = uvMan;
			ClearLoadedCallback();
			SetEnableRaycaster(false);
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x10DD350 Offset: 0x10DD350 VA: 0x10DD350
		//public bool IsExpanded() { }

		//// RVA: 0x10DD35C Offset: 0x10DD35C VA: 0x10DD35C
		public void SetIndex(int index)
		{
			m_index = index;
		}

		//// RVA: 0x10DD364 Offset: 0x10DD364 VA: 0x10DD364
		public void SetPossible(bool isPossible)
		{
			m_isPossible = isPossible;
		}

		//// RVA: 0x10DD36C Offset: 0x10DD36C VA: 0x10DD36C
		//public void Wait() { }

		//// RVA: 0x10DA8F8 Offset: 0x10DA8F8 VA: 0x10DA8F8
		public void Expand()
		{
			m_abs.StartChildrenAnimGoStop("st_wait");
			m_addEffectAbs.StartChildrenAnimGoStop("st_wait");
			m_flags &= 0xfffffffe;
		}

		//// RVA: 0x10DD3E8 Offset: 0x10DD3E8 VA: 0x10DD3E8
		public void Expanded(bool isOpen)
		{
			if (isOpen)
				SetOpen(m_isSub, m_isCenter);
			else
				SetClose();
			m_flags |= 1;
		}

		//// RVA: 0x10DD44C Offset: 0x10DD44C VA: 0x10DD44C
		//public void PlayUnLockAnime() { }

		//// RVA: 0x10DD7B4 Offset: 0x10DD7B4 VA: 0x10DD7B4
		public void PlayExpandAnime()
		{
			if((m_flags & 1) == 0)
			{
				int row = (int)m_type;
				if (m_isSub)
					row += 4;
				if (m_type == Type.Normal && !m_isCenter)
					row += 3;
				m_replaceUvImages[0].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTable[row, m_isPossible ? 0 : 1]));
				m_replaceUvImages[1].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTable[row, m_isPossible ? 0 : 1]));
				m_replaceUvImages[2].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTable[row, m_isPossible ? 0 : 1]));
				m_abs.StartAllAnimGoStop("go_in", "st_in");
				m_addEffectAbs.StartChildrenAnimGoStop("go_in", "st_in");
			}
		}

		//// RVA: 0x10DD428 Offset: 0x10DD428 VA: 0x10DD428
		//public void SetOpen() { }

		//// RVA: 0x10DDC50 Offset: 0x10DDC50 VA: 0x10DDC50
		public void SetOpen(bool isSub, bool isCenter)
		{
			m_isSub = isSub;
			m_isCenter = isCenter;
			int row = (int)m_type;
			if (isSub)
				row += 4;
			if (m_type == Type.Normal && !m_isCenter)
				row += 3;
			m_replaceUvImages[2].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTable[row, 2]));
		}

		//// RVA: 0x10DD434 Offset: 0x10DD434 VA: 0x10DD434
		public void SetClose()
		{
			if ((m_flags & 1) != 0)
				return;
			SetClose(m_isSub, m_isCenter);
		}

		//// RVA: 0x10DDE3C Offset: 0x10DDE3C VA: 0x10DDE3C
		public void SetClose(bool isSub, bool isCenter)
		{
			m_isSub = isSub;
			m_isCenter = isCenter;
			int row = (int)m_type;
			if (isSub)
				row += 4;
			if (m_type == Type.Normal && !m_isCenter)
				row += 3;
			m_replaceUvImages[2].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvManager.GetUVData(m_uvNameTable[row, m_isPossible ? 0 : 1]));
		}

		//// RVA: 0x10DE02C Offset: 0x10DE02C VA: 0x10DE02C
		//public void ConnectEffect(GameObject eff) { }

		//// RVA: 0x10DE030 Offset: 0x10DE030 VA: 0x10DE030
		//public void ShowLoopEffect() { }

		//// RVA: 0x10DE034 Offset: 0x10DE034 VA: 0x10DE034
		//public void StopLoopEffect() { }

		//// RVA: 0x10DE038 Offset: 0x10DE038 VA: 0x10DE038
		//public GameObject DisConnectEffect(Transform parent) { }
	}
}
