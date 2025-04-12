using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using CriWare;
using XeApp.Game.Common;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutResultPopupGoDivaLevelup : LayoutUGUIScriptBase
	{
		public struct InitParam
		{
			public JLCHNKIHGHK.GDJKDOMAAPG divaParamType; // 0x0
			public int beforeLevel; // 0x4
			public int afterLevel; // 0x8
			public int beforeValue; // 0xC
			public int afterValue; // 0x10
		}

		private AbsoluteLayout m_layoutRoot; // 0x14
		private AbsoluteLayout m_layoutLevelup; // 0x18
		private AbsoluteLayout m_layoutStatusUpIcon; // 0x1C
		[SerializeField]
		private Text m_textBeforeValue; // 0x20
		[SerializeField]
		private Text m_textAfterValue; // 0x24
		[SerializeField]
		private Text m_textBeforeLevel; // 0x28
		[SerializeField]
		private Text m_textAfterLevel; // 0x2C
		private CriAtomExPlayback countUpSEPlayback; // 0x30
		private bool isPlayedCountupSE; // 0x34
		private bool isSkiped; // 0x35

		// RVA: 0x1D0B714 Offset: 0x1D0B714 VA: 0x1D0B714
		private void Update()
		{
			if(IsLoaded() && !isSkiped && InputManager.Instance.GetInScreenTouchCount() > 0 && ResultScene.IsScreenTouch())
				isSkiped = true;
		}

		// RVA: 0x1D0B7F0 Offset: 0x1D0B7F0 VA: 0x1D0B7F0
		private void OnDestroy()
		{
			return;
		}

		// RVA: 0x1D0B7F4 Offset: 0x1D0B7F4 VA: 0x1D0B7F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.Root;
			m_layoutLevelup = layout.FindViewById("sw_lvup_anim") as AbsoluteLayout;
			m_layoutStatusUpIcon = layout.FindViewById("sw_status_icon_up_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1D0B970 Offset: 0x1D0B970 VA: 0x1D0B970
		public void Setup(InitParam initParam)
		{
			m_textBeforeLevel.text = initParam.beforeLevel.ToString();
			m_textAfterLevel.text = initParam.afterLevel.ToString();
			m_textBeforeValue.text = initParam.beforeValue.ToString();
			m_textAfterValue.text = initParam.afterValue.ToString();
			if(initParam.divaParamType == JLCHNKIHGHK.GDJKDOMAAPG.LGOHMPBLPKA_2)
			{
				m_layoutRoot.StartAllAnimGoStop("03");
			}
			else if(initParam.divaParamType == JLCHNKIHGHK.GDJKDOMAAPG.GPCMMGOCPHC_1)
			{
				m_layoutRoot.StartAllAnimGoStop("02");
			}
			else if(initParam.divaParamType == JLCHNKIHGHK.GDJKDOMAAPG.BICPBLMPBPH_0)
			{
				m_layoutRoot.StartAllAnimGoStop("01");
			}
		}

		// RVA: 0x1D0BB6C Offset: 0x1D0BB6C VA: 0x1D0BB6C
		public void Show()
		{
			gameObject.SetActive(true);
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
			this.StartCoroutineWatched(Co_MainFlow());
		}

		// RVA: 0x1D0BC98 Offset: 0x1D0BC98 VA: 0x1D0BC98
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7175FC Offset: 0x7175FC VA: 0x7175FC
		// // RVA: 0x1D0BC0C Offset: 0x1D0BC0C VA: 0x1D0BC0C
		private IEnumerator Co_MainFlow()
		{
			//0x1D0BE54
			yield return Co.R(Co_PlayLevelupTitleAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x717674 Offset: 0x717674 VA: 0x717674
		// // RVA: 0x1D0BCF0 Offset: 0x1D0BCF0 VA: 0x1D0BCF0
		private IEnumerator Co_PlayLevelupTitleAnim()
		{
			//0x1D0BF54
			m_layoutLevelup.StartAllAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutLevelup, false));
			m_layoutLevelup.StartAllAnimLoop("logo_up", "loen_up");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7176EC Offset: 0x7176EC VA: 0x7176EC
		// // RVA: 0x1D0BD9C Offset: 0x1D0BD9C VA: 0x1D0BD9C
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x1D0C12C
			while(layout.IsPlayingChildren())
				yield return null;
		}
	}
}
