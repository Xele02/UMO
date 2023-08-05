using mcrs;
using System.Collections;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutLogoCutin : LayoutUGUIScriptBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x14
		private RawImageEx m_imgLogo; // 0x18
		private bool m_is_load_logo; // 0x1C
		private bool m_is_enter; // 0x1D
		private bool m_is_entered; // 0x1E

		// RVA: 0x1D664F0 Offset: 0x1D664F0 VA: 0x1D664F0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_ul_bridge_effect") as AbsoluteLayout;
			m_imgLogo = transform.Find("sw_ul_bridge_effect (AbsoluteLayout)/cmn_logo_ul (AbsoluteLayout)/cmn_logo_ul_01 (ImageView)").GetComponent<RawImageEx>();
			Loaded();
			return true;
		}

		//// RVA: 0x1D66634 Offset: 0x1D66634 VA: 0x1D66634
		public void Load(int logo_id)
		{
			this.StartCoroutineWatched(Co_Load(logo_id));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73116C Offset: 0x73116C VA: 0x73116C
		//// RVA: 0x1D66658 Offset: 0x1D66658 VA: 0x1D66658
		private IEnumerator Co_Load(int logo_id)
		{
			//0x1D66AB8
			m_is_load_logo = false;
			GameManager.Instance.MenuResidentTextureCache.LoadLogoUnlock(logo_id, (IiconTexture icon) =>
			{
				//0x1D66904
				icon.Set(m_imgLogo);
				m_is_load_logo = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x1D669EC
				GameManager.Instance.MenuResidentTextureCache.Update();
				return m_is_load_logo;
			});
		}

		//// RVA: 0x1D66720 Offset: 0x1D66720 VA: 0x1D66720
		public void Enter()
		{
			if (m_is_enter)
				return;
			this.StartCoroutineWatched(Co_WaitEnter());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7311E4 Offset: 0x7311E4 VA: 0x7311E4
		//// RVA: 0x1D66754 Offset: 0x1D66754 VA: 0x1D66754
		private IEnumerator Co_WaitEnter()
		{
			//0x1D66D20
			m_is_enter = true;
			SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_UNLOCK_000);
			m_layoutRoot.StartChildrenAnimGoStop("go_in_bridge", "st_in_bridge");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D66AB0
				return IsPlaying();
			});
			m_is_entered = true;
		}

		//// RVA: 0x1D66800 Offset: 0x1D66800 VA: 0x1D66800
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out_bridge", "st_out_bridge");
			m_is_enter = false;
		}

		//// RVA: 0x1D66894 Offset: 0x1D66894 VA: 0x1D66894
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		//// RVA: 0x1D668C0 Offset: 0x1D668C0 VA: 0x1D668C0
		public bool IsEntered()
		{
			return m_is_entered;
		}

		//// RVA: 0x1D668C8 Offset: 0x1D668C8 VA: 0x1D668C8
		public void LogoEnabled(bool enable)
		{
			m_imgLogo.enabled = enable;
		}
	}
}
