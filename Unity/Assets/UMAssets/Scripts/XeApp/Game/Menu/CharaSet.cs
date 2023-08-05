using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Text;

namespace XeApp.Game.Menu
{
	public class CharaSet : LayoutUGUIScriptBase
	{
		private enum IconLoadBit
		{
			None = 0,
			Diva = 1,
			Scene1 = 2,
			Scene2 = 4,
			Scene3 = 8,
			All = 15,
		}

		[SerializeField]
		private StayButton[] m_divaButton; // 0x14
		[SerializeField]
		private SceneButton[] m_mainSceneButton; // 0x18
		[SerializeField]
		private SceneButton[] m_subSceneButtons; // 0x1C
		[SerializeField]
		private RawImageEx[] m_divaImages; // 0x20
		[SerializeField]
		private RawImageEx[] m_mainSceneImages; // 0x24
		[SerializeField]
		private RawImageEx[] m_subSceneImages; // 0x28
		[SerializeField]
		private string m_charaWindowExId; // 0x2C
		[SerializeField]
		private string m_charaWindowSymbol; // 0x30
		[SerializeField]
		public DivaSelectEvent m_onDivaClickEvent; // 0x34
		[SerializeField]
		public DivaSelectEvent m_onDivaStayEvent; // 0x38
		[SerializeField]
		public SceneSelectEvent m_onSceneClickEvent; // 0x3C
		[SerializeField]
		public SceneSelectEvent m_onSceneStayEvent; // 0x40
		private DivaIconDecoration[] m_divaDecoration = new DivaIconDecoration[2]; // 0x44
		private SceneIconDecoration[] m_mainSceneDecoration = new SceneIconDecoration[2]; // 0x48
		private SceneIconDecoration[] m_subSceneDecoration = new SceneIconDecoration[2]; // 0x4C
		private AbsoluteLayout m_charaWindow; // 0x50
		private AbsoluteLayout[] m_palette1; // 0x54
		private AbsoluteLayout[] m_palette2; // 0x58
		private AbsoluteLayout[] m_multiIcons; // 0x5C
		private FFHPBEPOMAK_DivaInfo m_divaData; // 0x60
		private DFKGGBMFFGB_PlayerInfo m_playerData; // 0x64
		private int m_divaSlotNumber; // 0x68
		private IconLoadBit m_iconLoadedBf; // 0x6C

		public SceneButton[] MainSceneBusttons { get { return m_mainSceneButton; } } //0x10AC864
		//public bool IsLoadedTexture { get; } 0x10AC86C

		// RVA: 0x10AC880 Offset: 0x10AC880 VA: 0x10AC880 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_charaWindow = layout.FindViewById(m_charaWindowExId) as AbsoluteLayout;
			for (int i = 0; i < m_divaDecoration.Length; i++)
			{
				m_divaDecoration[i] = new DivaIconDecoration();
			}
			for(int i = 0; i < m_mainSceneDecoration.Length; i++)
			{
				m_mainSceneDecoration[i] = new SceneIconDecoration();
			}
			for(int i = 0; i < m_subSceneDecoration.Length; i++)
			{
				m_subSceneDecoration[i] = new SceneIconDecoration();
			}
			StringBuilder str = new StringBuilder(64);
			str.Append(name);
			str.Replace(" (AbsoluteLayout)", "");
			str.Insert(0, "_");
			str.Insert(0, m_charaWindowSymbol);
			AbsoluteLayout a = layout.FindViewByExId(str.ToString()) as AbsoluteLayout;
			m_palette1 = new AbsoluteLayout[2];
			m_palette1[0] = a.FindViewByExId("sw_set_deck_unit_frame_01_all_swtbl_set_deck_unit_frame_01_collar") as AbsoluteLayout;
			m_palette1[1] = a.FindViewByExId("sw_set_deck_unit_frame_01_all_swtbl_set_deck_unit_frame_grad_01_collar") as AbsoluteLayout;
			m_palette2 = new AbsoluteLayout[2];
			m_palette2[0] = a.FindViewByExId("sw_set_deck_unit_frame_02_all_swtbl_set_deck_unit_frame_01_collar") as AbsoluteLayout;
			m_palette2[1] = a.FindViewByExId("sw_set_deck_unit_frame_02_all_swtbl_set_deck_unit_frame_grad_01_collar") as AbsoluteLayout;
			m_multiIcons = new AbsoluteLayout[2];
			for(int i = 0; i < m_multiIcons.Length; i++)
			{
				m_multiIcons[i] = (a.FindViewByExId(string.Format("sw_set_deck_unit_wind_{0:D2}_sw_chara_icon_01_anim", i + 1)) as AbsoluteLayout).FindViewByExId("sw_chara_icon_01_anim_swtbl_set_icon_multi_01") as AbsoluteLayout;
			}
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x10AD3FC Offset: 0x10AD3FC VA: 0x10AD3FC
		//public void InitializeIcon() { }

		//// RVA: 0x10AD6CC Offset: 0x10AD6CC VA: 0x10AD6CC
		//public void Release() { }

		//// RVA: 0x10AD85C Offset: 0x10AD85C VA: 0x10AD85C
		//public void SetDiva(int divaSlotNumber, FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, UnitWindowConstant.OperationMode opMode, EEDKAACNBBG musicData, bool isGoDiva) { }

		//// RVA: 0x10AFA18 Offset: 0x10AFA18 VA: 0x10AFA18
		//public void SetShowMultiIcon(bool isShow) { }

		//// RVA: 0x10AFB24 Offset: 0x10AFB24 VA: 0x10AFB24
		//public void SetButtonState(UnitWindowConstant.OperationMode opMode) { }

		//// RVA: 0x10AFCDC Offset: 0x10AFCDC VA: 0x10AFCDC
		//public StayButton GetDivaButton() { }

		//// RVA: 0x10AFD1C Offset: 0x10AFD1C VA: 0x10AFD1C
		//public void UpdateIcon(SortItem item, bool isCenter, bool isGoDiva) { }

		//// RVA: 0x10B0394 Offset: 0x10B0394 VA: 0x10B0394
		//public void ChangeDisplayMode(string frameName) { }

		//// RVA: 0x10B04CC Offset: 0x10B04CC VA: 0x10B04CC
		//private void OnSelectDiva() { }

		//// RVA: 0x10B0554 Offset: 0x10B0554 VA: 0x10B0554
		//private void OnShowDivaStatus() { }

		//// RVA: 0x10B05DC Offset: 0x10B05DC VA: 0x10B05DC
		//private void OnSelectMainScene() { }

		//// RVA: 0x10B0710 Offset: 0x10B0710 VA: 0x10B0710
		//private void OnShowMainSceneStatus() { }

		//// RVA: 0x10B0844 Offset: 0x10B0844 VA: 0x10B0844
		//private void OnSelectSubScene(int subSceneSlot) { }

		//// RVA: 0x10B09DC Offset: 0x10B09DC VA: 0x10B09DC
		//private void OnShowSubSceneStatus(int subSceneSlot) { }

		//[CompilerGeneratedAttribute] // RVA: 0x730414 Offset: 0x730414 VA: 0x730414
		//// RVA: 0x10B0C14 Offset: 0x10B0C14 VA: 0x10B0C14
		//private void <SetDiva>b__31_0(IiconTexture texture) { }
	}
}
