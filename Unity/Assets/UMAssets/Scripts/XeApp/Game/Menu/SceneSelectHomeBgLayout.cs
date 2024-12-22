using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneSelectHomeBgLayout : LayoutUGUIScriptBase
	{
		private enum PlateState
		{
			Undeveloped = 0,
			Evolution = 1,
			Num = 2,
		}

		public enum SetBgType
		{
			Undeveloped = 0,
			EvoleOnly = 1,
			Evole = 2,
			Default = 3,
			LimitBg = 4,
		}

		private const int Undeveloped = 1;
		private const int Evolution = 2;
		[SerializeField]
		private Text m_setBgTitle; // 0x20
		[SerializeField]
		private Text m_setBgExplanation; // 0x24
		[SerializeField]
		private RawImageEx[] m_sceneImages; // 0x28
		[SerializeField]
		private RawImageEx[] m_sceneUnitImages; // 0x2C
		[SerializeField]
		private RawImageEx m_limitBgImage; // 0x30
		[SerializeField]
		private ActionButton[] m_sceneImagesButtons; // 0x34
		private AbsoluteLayout m_bgTypeLayout; // 0x38
		private AbsoluteLayout[] m_sceneSelectCursorLayout; // 0x3C
		private AbsoluteLayout[] m_sceneEpisodeLayout; // 0x40
		private AbsoluteLayout[] m_sceneSkillLayout; // 0x44
		private int m_loadCount; // 0x48
		private int m_loadedCount; // 0x4C
		private string[] ScenaAnim = new string[2]
		{
			"swtbl_sw_scene02_sw_scene02_anim_01", "swtbl_sw_scene02_sw_scene02_anim_02"
		}; // 0x50

		public GCIJNCFDNON_SceneInfo SceneData { get; set; } // 0x14
		public GCIJNCFDNON_SceneInfo HomeBgSceneData { get; set; } // 0x18
		public int SceneEvolveId { get; set; } // 0x1C

		// // RVA: 0x13790A4 Offset: 0x13790A4 VA: 0x13790A4
		// public bool IsLoaded() { }

		// RVA: 0x1379108 Offset: 0x1379108 VA: 0x1379108 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_bgTypeLayout = layout.FindViewByExId("sw_sel_card_bg_select_swtbl_sw_scene02") as AbsoluteLayout;
			m_sceneSelectCursorLayout = new AbsoluteLayout[2];
			m_sceneEpisodeLayout = new AbsoluteLayout[2];
			m_sceneSkillLayout = new AbsoluteLayout[2];
			for(int i = 0; i < ScenaAnim.Length; i++)
			{
				AbsoluteLayout l = layout.FindViewByExId(ScenaAnim[i]) as AbsoluteLayout;
				m_sceneSelectCursorLayout[i] = l.FindViewByExId("sw_sel_card_bg_cursor_onoff_anim_sw_sel_card_bg_cursor_anim") as AbsoluteLayout;
				m_sceneEpisodeLayout[i] = l.FindViewByExId("sw_sw_sel_card_ep_onoff_anim_sw_sel_card_ep_anim") as AbsoluteLayout;
				m_sceneSkillLayout[i] = l.FindViewByExId("sw_sel_card_skill_ef_anim_sel_card_icon_skill_01") as AbsoluteLayout;
			}
			SetUnitIcon(false);
			m_loadCount = 0;
			m_loadedCount = 0;
			Loaded();
			return true;
		}

		// // RVA: 0x1378D50 Offset: 0x1378D50 VA: 0x1378D50
		// public void Initialzie() { }

		// // RVA: 0x13796B8 Offset: 0x13796B8 VA: 0x13796B8
		private void SetUnitIcon(bool enable)
		{
			for(int i = 0; i < m_sceneUnitImages.Length; i++)
			{
				m_sceneUnitImages[i].enabled = enable;
			}
		}

		// // RVA: 0x1379750 Offset: 0x1379750 VA: 0x1379750
		// private void SetSceneSelectCursorAnime(bool isSelect1, bool isSelect2) { }

		// // RVA: 0x1379880 Offset: 0x1379880 VA: 0x1379880
		// private void SettingSceneState(SceneSelectHomeBgLayout.SetBgType bgType) { }

		// // RVA: 0x13798C8 Offset: 0x13798C8 VA: 0x13798C8
		// private void SelectHomeBgScene(SceneSelectHomeBgLayout.PlateState plateState) { }

		// // RVA: 0x1379968 Offset: 0x1379968 VA: 0x1379968
		// private void SetSceneIcon(SceneSelectHomeBgLayout.PlateState plateState, GCIJNCFDNON sceneData, SceneSelectHomeBgLayout.SetBgType setBgType) { }

		// [IteratorStateMachineAttribute] // RVA: 0x72DF04 Offset: 0x72DF04 VA: 0x72DF04
		// // RVA: 0x1379B10 Offset: 0x1379B10 VA: 0x1379B10
		// private IEnumerator SetSceneLimitBg() { }

		// [IteratorStateMachineAttribute] // RVA: 0x72DF7C Offset: 0x72DF7C VA: 0x72DF7C
		// // RVA: 0x1378EA0 Offset: 0x1378EA0 VA: 0x1378EA0
		// public IEnumerator SetSceneData(SceneSelectHomeBgLayout.SetBgType bgType) { }

		// [CompilerGeneratedAttribute] // RVA: 0x72DFF4 Offset: 0x72DFF4 VA: 0x72DFF4
		// // RVA: 0x1379D3C Offset: 0x1379D3C VA: 0x1379D3C
		// private void <SetSceneLimitBg>b__37_0(Texture2D texture) { }

		// [CompilerGeneratedAttribute] // RVA: 0x72E004 Offset: 0x72E004 VA: 0x72E004
		// // RVA: 0x1379D70 Offset: 0x1379D70 VA: 0x1379D70
		// private void <SetSceneData>b__38_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x72E014 Offset: 0x72E014 VA: 0x72E014
		// // RVA: 0x1379D78 Offset: 0x1379D78 VA: 0x1379D78
		// private void <SetSceneData>b__38_1() { }
	}
}
