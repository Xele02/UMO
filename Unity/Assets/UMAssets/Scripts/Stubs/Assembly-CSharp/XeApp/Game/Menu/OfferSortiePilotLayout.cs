using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferSortiePilotLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx pilotImage; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18
		private AbsoluteLayout m_position; // 0x1C
		private bool m_IsLoading; // 0x20

		// RVA: 0x171129C Offset: 0x171129C VA: 0x171129C
		private void Start()
		{
			return;
		}

		// RVA: 0x17112A0 Offset: 0x17112A0 VA: 0x17112A0
		private void Update()
		{ 
			return;
		}

		// RVA: 0x17112A4 Offset: 0x17112A4 VA: 0x17112A4
		public void SetUp(int pilotId, bool IsSortie)
		{
			m_IsLoading = true;
			MenuScene.Instance.InputDisable();
			GameManager.Instance.PilotTextureCache.Load(pilotId, (IiconTexture icon) =>
			{
				//0x17118B0
				m_IsLoading = false;
				pilotImage.enabled = true;
				icon.Set(pilotImage);
				MenuScene.Instance.InputEnable();
			});
			m_position.StartChildrenAnimGoStop(IsSortie ? "01" : "02");
		}

		// RVA: 0x171145C Offset: 0x171145C VA: 0x171145C
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x17114E8 Offset: 0x17114E8 VA: 0x17114E8
		public void SortieLeave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1711574 Offset: 0x1711574 VA: 0x1711574
		// public void ResultLeave() { }

		// RVA: 0x1711600 Offset: 0x1711600 VA: 0x1711600
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x171167C Offset: 0x171167C VA: 0x171167C
		// public void Show() { }

		// RVA: 0x17116F8 Offset: 0x17116F8 VA: 0x17116F8
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlaying();
		}

		// // RVA: 0x1711724 Offset: 0x1711724 VA: 0x1711724
		// public bool IsPlayingChildren() { }

		// // RVA: 0x1711750 Offset: 0x1711750 VA: 0x1711750
		// public bool IsImageLoading() { }

		// RVA: 0x1711758 Offset: 0x1711758 VA: 0x1711758 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("sw_pilot_position_sw_pilot_inout_anim") as AbsoluteLayout;
			m_position = layout.FindViewByExId("root_sortie_vfo_pilot_sw_pilot_inout_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
