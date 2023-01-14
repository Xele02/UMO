using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys;
using XeApp.Game.Common.uGUI;

namespace XeApp.Game.Menu
{
	public abstract class ComparisonParamBase : LayoutUGUIScriptBase
	{
		protected enum Flags
		{
			ImageLoaded = 1,
		}

		[SerializeField]
		protected LayoutUGUIRuntime m_runtime; // 0x14
		[SerializeField]
		protected Text m_nameText; // 0x18
		[SerializeField]
		protected Text[] m_paramTexts; // 0x1C
		[SerializeField]
		protected RawImageEx m_iconImage; // 0x20
		[SerializeField]
		protected RawImageEx[] m_arrowImages; // 0x24
		[SerializeField]
		protected Text[] m_notesTitle; // 0x28
		[SerializeField]
		protected ComparisonNotesBase[] m_notes; // 0x2C
		[SerializeField]
		protected ComparisonSkillInfo[] m_skillInfos; // 0x30
		protected int m_skillDispIndex; // 0x34
		protected int m_skillDispMax; // 0x38
		protected byte m_flags; // 0x3C
		protected TexUVListManager m_uvManager; // 0x40
		protected TexUVList m_cmnTexUvList; // 0x44
		protected bool m_isCenterDiva; // 0x48
		protected UnityAction<ComparisonSkillInfo, int> OnPushDetailsEvent; // 0x4C
		public const string m_noCompatibleAnimeLabel = "01";
		public const string m_mainSlotAnimationLabel = "02";
		public const string m_noCenterDivaAnimationLabel = "04";
		public const string m_misMatchMusic = "06";
		public const string m_misMatchSeries = "07";
		public const string m_misMatchAttr = "08";
		private static readonly SkillType.Type[] m_skillTypeAnimeLabel = new SkillType.Type[5] {
			SkillType.Type.CenterSkill, SkillType.Type.ActiveSkill, SkillType.Type.LiveSkill,
			SkillType.Type.LiveSkill, SkillType.Type.LiveSkill
		}; // 0x0

		// RVA: 0x1B50E5C Offset: 0x1B50E5C VA: 0x1B50E5C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			m_uvManager = uvMan;
			m_cmnTexUvList = uvMan.GetTexUVList("cmn_tex_pack");
			for(int i = 0; i < m_notesTitle.Length; i++)
			{
				m_notesTitle[i].text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("popup_comparison_00");
			}
			for(int i = 0; i < m_skillInfos.Length; i++)
			{
				m_skillInfos[i].OnPushDetailsEvent = OnPushDetails;
			}
			Loaded();
			return true;
		}

		//// RVA: 0x1B510C0 Offset: 0x1B510C0 VA: 0x1B510C0
		public void ChangeDisplay(int index)
		{
			if (m_skillDispMax <= index)
				index = 0;
			m_skillDispIndex = index;
			UpdateText(0, index);
			UpdateSkillText(0, m_skillDispIndex);
		}

		//// RVA: 0x1B511E4 Offset: 0x1B511E4 VA: 0x1B511E4
		public int GetDisplayIndex()
		{
			return m_skillDispIndex;
		}

		//// RVA: 0x1B511EC Offset: 0x1B511EC VA: 0x1B511EC
		public int GetDisplayMax()
		{
			return m_skillDispMax;
		}

		//// RVA: 0x1B511F4 Offset: 0x1B511F4 VA: 0x1B511F4
		protected void ComparisonValue(Text text, int befor, int after, int arrowIndex)
		{
			if(befor < after)
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.UpColor);
				m_arrowImages[arrowIndex].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_cmnTexUvList.GetUVData("cmn_status_icon_up"));
			}
			else if(befor == after)
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.NormalColor);
				m_arrowImages[arrowIndex].enabled = false;
				return;
			}
			else
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.DownColor);
				m_arrowImages[arrowIndex].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_cmnTexUvList.GetUVData("cmn_status_icon_down"));
			}
			m_arrowImages[arrowIndex].enabled = true;
		}

		//// RVA: 0x1B515E4 Offset: 0x1B515E4 VA: 0x1B515E4
		protected void SetSkillType(int pos, SkillType.Type type)
		{
			m_skillInfos[pos].SetSkillTypeAll(type);
		}

		//// RVA: 0x1B5169C Offset: 0x1B5169C VA: 0x1B5169C
		protected void SetSkillRank(int pos, SkillRank.Type rank, int index = 0)
		{
			m_skillInfos[pos].SetSkillRank(rank, index);
		}

		//// RVA: 0x1B51834 Offset: 0x1B51834 VA: 0x1B51834
		protected void SetSkillLevel(int pos, int level, int index = 0)
		{
			m_skillInfos[pos].SetSkillLevel(level, index);
		}

		//// RVA: 0x1B51A68 Offset: 0x1B51A68 VA: 0x1B51A68
		protected void SetSkillDescription(int pos, string description, int index = 0)
		{
			m_skillInfos[pos].SetSkillDescription(description, index);
		}

		//// RVA: 0x1B51E34 Offset: 0x1B51E34 VA: 0x1B51E34
		protected void SetSkillCrossFade(int pos, bool enable)
		{
			m_skillInfos[pos].SetSkillCrossFade(enable);
		}

		//// RVA: 0x1B51F34 Offset: 0x1B51F34 VA: 0x1B51F34
		public void SetSkillMask(int pos, ComparisonSkillInfo.SkillMask mask)
		{
			m_skillInfos[pos].SetSkillMask(mask);
		}

		//// RVA: 0x1B5110C Offset: 0x1B5110C VA: 0x1B5110C
		protected void UpdateText(int pos, int index)
		{
			SetSkillType(pos, m_skillTypeAnimeLabel[index]);
		}

		//// RVA: -1 Offset: -1 Slot: 6
		protected abstract void UpdateSkillText(int pos, int index);

		//// RVA: -1 Offset: -1 Slot: 7
		public abstract void InitializeDecoration();

		//// RVA: -1 Offset: -1 Slot: 8
		public abstract void ReleaseDecoration();

		//// RVA: -1 Offset: -1 Slot: 9
		public abstract void UpdateDecoration(DisplayType type);

		//// RVA: 0x1B52128 Offset: 0x1B52128 VA: 0x1B52128
		//protected bool IsCenterDiva(JLKEOGLJNOD unitData, FFHPBEPOMAK divaData, int divaSlot, bool isGoDiva) { }

		//// RVA: 0x1B52220 Offset: 0x1B52220 VA: 0x1B52220
		//protected bool IsMainSlot(FFHPBEPOMAK divaData, GCIJNCFDNON sceneData) { }

		//// RVA: 0x1B52278 Offset: 0x1B52278 VA: 0x1B52278
		public bool IsLoading()
		{
			return (m_flags & 1) == 0;
		}

		//// RVA: 0x1B5228C Offset: 0x1B5228C VA: 0x1B5228C
		protected void SetLoaded()
		{
			m_flags |= (byte)Flags.ImageLoaded;
		}

		//// RVA: 0x1B5229C Offset: 0x1B5229C VA: 0x1B5229C
		private void OnPushDetails(ComparisonSkillInfo info, int index)
		{
			TodoLogger.LogNotImplemented("OnPushDetails");
		}
	}
}
