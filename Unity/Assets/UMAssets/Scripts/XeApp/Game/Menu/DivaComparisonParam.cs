using System.Text;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaComparisonParam : ComparisonParamBase
	{
		protected enum SkillDiapIndex
		{
			MainSlotCenter = 0,
			MainSlotActive = 1,
			MainSlotLive = 2,
			SubSlotLive1 = 3,
			SubSlotLive2 = 4,
			Max = 5,
		}

		protected DivaIconDecoration m_divaIconDecoration = new DivaIconDecoration(); // 0x50
		protected FFHPBEPOMAK m_divaData; // 0x54
		protected DFKGGBMFFGB m_playerData; // 0x58
		protected EEDKAACNBBG m_musicData; // 0x5C
		protected StringBuilder m_strBuilder = new StringBuilder(64); // 0x60
		private bool m_isDisp2ndCenterSkill; // 0x64
		private bool m_isDisp2ndLiveSkill; // 0x65

		// RVA: 0x17D2AB4 Offset: 0x17D2AB4 VA: 0x17D2AB4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			OnPushDetailsEvent -= OnShowSkillDetials;
			OnPushDetailsEvent += OnShowSkillDetials;
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x17D2BA4 Offset: 0x17D2BA4 VA: 0x17D2BA4 Slot: 7
		public override void InitializeDecoration()
		{
			m_divaIconDecoration.Initialize(m_iconImage.gameObject, DivaIconDecoration.Size.M, true, false, null, null);
		}

		//// RVA: 0x17D2C40 Offset: 0x17D2C40 VA: 0x17D2C40 Slot: 8
		public override void ReleaseDecoration()
		{
			m_divaIconDecoration.Release();
		}

		//// RVA: 0x17D2E70 Offset: 0x17D2E70 VA: 0x17D2E70 Slot: 9
		public override void UpdateDecoration(DisplayType type)
		{
			if(m_divaData != null)
				m_divaIconDecoration.Change(m_divaData, m_playerData, type);
		}

		//// RVA: 0x17D3390 Offset: 0x17D3390 VA: 0x17D3390
		public void UpdateContent(FFHPBEPOMAK divaData, FFHPBEPOMAK comparisonDiva, DFKGGBMFFGB playerData, EEDKAACNBBG musicData, bool isCenterDiva)
		{
			m_divaData = divaData;
			m_playerData = playerData;
			m_musicData = musicData;
			TodoLogger.Log(0, "UpdateContent");
		}

		//// RVA: 0x17D5054 Offset: 0x17D5054 VA: 0x17D5054 Slot: 6
		protected override void UpdateSkillText(int pos, int index)
		{
			TodoLogger.Log(0, "UpdateSkillText");
		}

		//// RVA: 0x17D5C98 Offset: 0x17D5C98 VA: 0x17D5C98
		//private GCIJNCFDNON GetSlotSceneData(DivaComparisonParam.SkillDiapIndex index) { }

		//// RVA: 0x17D5E38 Offset: 0x17D5E38 VA: 0x17D5E38
		private void OnShowSkillDetials(ComparisonSkillInfo info, int index)
		{
			TodoLogger.LogNotImplemented("OnShowSkillDetials");
		}

		//[CompilerGeneratedAttribute] // RVA: 0x72D76C Offset: 0x72D76C VA: 0x72D76C
		//// RVA: 0x17D612C Offset: 0x17D612C VA: 0x17D612C
		//private void <UpdateContent>b__12_0(IiconTexture texture) { }

		//[CompilerGeneratedAttribute] // RVA: 0x72D77C Offset: 0x72D77C VA: 0x72D77C
		//// RVA: 0x17D6218 Offset: 0x17D6218 VA: 0x17D6218
		//private void <UpdateContent>b__12_1(IiconTexture texture) { }
	}
}
