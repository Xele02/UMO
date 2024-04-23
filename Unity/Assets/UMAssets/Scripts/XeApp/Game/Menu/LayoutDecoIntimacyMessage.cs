using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using mcrs;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyMessage : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textInfo; // 0x14
		[SerializeField]
		private Text m_textInfoLocked; // 0x18
		[SerializeField]
		private RawImageEx m_imageTipsWindow; // 0x1C
		[SerializeField]
		private RawImageEx m_imageTipsWindowLocked; // 0x20
		private AbsoluteLayout m_layoutRoot; // 0x24
		private AbsoluteLayout m_layoutInfo; // 0x28
		private AbsoluteLayout m_layoutInfoLocked; // 0x2C
		private AbsoluteLayout m_layoutColor; // 0x30
		private AbsoluteLayout m_layoutColorLocked; // 0x34
		private AbsoluteLayout m_layoutUsing; // 0x38
		private bool m_isOpen; // 0x3C
		private Coroutine m_coroutine; // 0x40

		// RVA: 0x19EAFD0 Offset: 0x19EAFD0 VA: 0x19EAFD0
		private void OnDisable()
		{
			if(m_coroutine != null)
			{
				this.StopCoroutineWatched(m_coroutine);
				m_coroutine = null;
				Hide();
			}
		}

		// // RVA: 0x19EB0B0 Offset: 0x19EB0B0 VA: 0x19EB0B0
		public void SetTextLevelUpBonus(int divaId, string name, JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK type, int param)
		{
			m_layoutColor.StartChildrenAnimGoStop(divaId.ToString("D2"));
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string str = "";
			switch(type)
			{
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.POBNHLKGMPF_1:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_001");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.EHJDMAOKHHP_2:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_002");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.JFEKIMDCKIH_3:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_003");
					break;
				case JJOELIOGMKK_DivaIntimacyInfo.LPBGKOJDNJK.GBINCMPKLOF_4:
					str = bk.GetMessageByLabel("diva_intimacy_lvup_text_004");
					break;
			}
			m_textInfo.text = string.Format(str, name, param);
			m_layoutUsing = m_layoutInfo;
			m_layoutRoot.StartChildrenAnimGoStop("01", "01");
		}

		// // RVA: 0x19EB34C Offset: 0x19EB34C VA: 0x19EB34C
		public void SetTextSystem(int divaId, string text)
		{
			m_layoutColor.StartChildrenAnimGoStop(divaId.ToString("D2"));
			m_textInfo.text = text;
			m_layoutUsing = m_layoutInfo;
		}

		// // RVA: 0x19EB420 Offset: 0x19EB420 VA: 0x19EB420
		public void SetTextLock(int divaId, string text)
		{
			m_layoutColorLocked.StartChildrenAnimGoStop(divaId.ToString("D2"));
			m_textInfoLocked.text = text;
			m_layoutUsing = m_layoutInfoLocked;
			m_layoutRoot.StartChildrenAnimGoStop("02", "02");
		}

		// // RVA: 0x19EB528 Offset: 0x19EB528 VA: 0x19EB528
		// public void SetTextUnlock(int divaId, string text) { }

		// // RVA: 0x19EB630 Offset: 0x19EB630 VA: 0x19EB630
		public void Enter()
		{
			if(m_layoutUsing == m_layoutInfo)
			{
				SoundManager.Instance.sePlayerMenu.Play((int)cs_se_menu.SE_INTIMACY_002);
			}
			gameObject.SetActive(true);
			m_layoutUsing.StartChildrenAnimGoStop("go_in", "st_in");
			m_layoutUsing.UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
			m_layoutUsing.UpdateAll(new Matrix23(), Color.white);
			m_isOpen = true;
		}

		// // RVA: 0x19EB7FC Offset: 0x19EB7FC VA: 0x19EB7FC
		public void Leave()
		{
			if(gameObject.activeInHierarchy)
			{
				m_coroutine = this.StartCoroutineWatched(Co_Leave());
			}
			else
				Hide();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D1284 Offset: 0x6D1284 VA: 0x6D1284
		// // RVA: 0x19EB864 Offset: 0x19EB864 VA: 0x19EB864
		private IEnumerator Co_Leave()
		{
			//0x19EBD38
			m_layoutUsing.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x19EBD08
				return m_layoutUsing.IsPlayingChildren();
			});
			Hide();
		}

		// // RVA: 0x19EB910 Offset: 0x19EB910 VA: 0x19EB910
		public bool IsOpenWindow()
		{
			return m_isOpen;
		}

		// // RVA: 0x19EB918 Offset: 0x19EB918 VA: 0x19EB918
		// public void Show() { }

		// // RVA: 0x19EB008 Offset: 0x19EB008 VA: 0x19EB008
		public void Hide()
		{
			if(m_layoutUsing != null)
				m_layoutUsing.StartChildrenAnimGoStop("st_out");
			gameObject.SetActive(false);
			m_isOpen = false;
		}

		// RVA: 0x19EB9C0 Offset: 0x19EB9C0 VA: 0x19EB9C0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_pre_win_01_swtbl_pre_win_01") as AbsoluteLayout;
			m_layoutInfo = layout.FindViewByExId("swtbl_pre_win_01_sw_fs_win_col_anim") as AbsoluteLayout;
			m_layoutInfoLocked = layout.FindViewByExId("swtbl_pre_win_01_sw_fs_win_colno_anim") as AbsoluteLayout;
			m_layoutColor = layout.FindViewByExId("sw_fs_win_col_anim_swtbl_fs_win_col") as AbsoluteLayout;
			m_layoutColorLocked = layout.FindViewByExId("sw_fs_win_colno_anim_swtbl_fs_win_col") as AbsoluteLayout;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
			m_imageTipsWindow.raycastTarget = false;
			m_imageTipsWindowLocked.raycastTarget = false;
			Loaded();
			return true;
		}
	}
}
