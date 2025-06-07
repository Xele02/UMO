using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropFoldRadar : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text01; // 0x14
		[SerializeField]
		private NumberBase m_itemNum; // 0x18
		[SerializeField]
		private ActionButton m_okButton; // 0x1C
		private AbsoluteLayout m_rootAnim; // 0x20
		private AbsoluteLayout m_loopAnim; // 0x24
		public Action onClickOkayButton; // 0x28

		// RVA: 0x1D8D8CC Offset: 0x1D8D8CC VA: 0x1D8D8CC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_text01.text = string.Format(bk.GetMessageByLabel("result_drop_foldradar_text"), NKOBMDPHNGP_EventRaidLobby.GPNELLFNPLA());
			m_okButton.AddOnClickCallback(() =>
			{
				//0x1D8DED4
				if(onClickOkayButton != null)
					onClickOkayButton();
			});
			m_rootAnim = layout.FindViewByExId("root_g_r_r02_pop_cc_sw_g_r_r02_pop_anim") as AbsoluteLayout;
			m_loopAnim = layout.FindViewByExId("sw_g_r_r02_pop_anim_sw_g_r_r02_ef_01_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1D8DB64 Offset: 0x1D8DB64 VA: 0x1D8DB64
		public void Setup(int itemNum)
		{
			m_itemNum.SetNumber(itemNum, 0);
		}

		// // RVA: 0x1D8DBA4 Offset: 0x1D8DBA4 VA: 0x1D8DBA4
		public void StartBeginAnim()
		{
			this.StartCoroutineWatched(Co_EnterAnimation());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x718D84 Offset: 0x718D84 VA: 0x718D84
		// // RVA: 0x1D8DBC8 Offset: 0x1D8DBC8 VA: 0x1D8DBC8
		private IEnumerator Co_EnterAnimation()
		{
			//0x1D8E188
			m_loopAnim.StartChildrenAnimLoop("lo_");
			yield return this.StartCoroutineWatched(Co_EnterAnim());

		}

		// // RVA: 0x1D8DC74 Offset: 0x1D8DC74 VA: 0x1D8DC74
		// public void StartEndAnim(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x718DFC Offset: 0x718DFC VA: 0x718DFC
		// // RVA: 0x1D8DC98 Offset: 0x1D8DC98 VA: 0x1D8DC98
		// private IEnumerator Co_StartEndAnimation(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x718E74 Offset: 0x718E74 VA: 0x718E74
		// // RVA: 0x1D8DD60 Offset: 0x1D8DD60 VA: 0x1D8DD60
		private IEnumerator Co_EnterAnim()
		{
			//0x1D8DF44
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_025);
			m_rootAnim.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			yield return new WaitWhile(() =>
			{
				//0x1D8DEE8
				return m_rootAnim.IsPlayingChildren();
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x718EEC Offset: 0x718EEC VA: 0x718EEC
		// // RVA: 0x1D8DE0C Offset: 0x1D8DE0C VA: 0x1D8DE0C
		// private IEnumerator Co_LeaveAnim() { }

		// // RVA: 0x1D8DEB8 Offset: 0x1D8DEB8 VA: 0x1D8DEB8
		// private void OnClickOkButton() { }

		// [CompilerGeneratedAttribute] // RVA: 0x718F84 Offset: 0x718F84 VA: 0x718F84
		// // RVA: 0x1D8DF14 Offset: 0x1D8DF14 VA: 0x1D8DF14
		// private bool <Co_LeaveAnim>b__13_0() { }
	}
}
