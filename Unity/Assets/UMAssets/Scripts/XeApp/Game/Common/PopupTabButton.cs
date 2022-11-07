using XeSys.Gfx;
using UnityEngine;
using System.Text;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class PopupTabButton : ActionButton
	{
		public enum ButtonLabel
		{
			EventInfomation = 1,
			BugIfomation = 2,
			UpdateInfomation = 3,
			RightsExpression = 4,
			TermsofService = 5,
			MusicInformation = 6,
			EnemyInformation = 7,
			DivaLevelOfSkill = 8,
			CumulativePoint = 9,
			Rankings = 10,
			GrowItem = 11,
			OtherItem = 12,
			Menu = 13,
			Live = 14,
			Rarity = 15,
			Episode = 16,
			Wiki = 17,
			Help = 18,
			Plate = 19,
			LiveView = 20,
			LiveSystem = 21,
			SLive = 22,
			RewardMVP = 23,
			RewardAttack1st = 24,
			RewardDisempowerment = 25,
			MusicRateDetail = 26,
			MusicGradeView = 27,
			RewardDisempowermentItems = 28,
			Releasable = 29,
			Released = 30,
			SimpleAutoSet = 31,
			NormalAutoSet = 32,
			Max = 33,
			None = 34,
		}

		private const string uvBaseBlueUvName = "cmn_pop01_fnt_02_b";
		private const string uvBasePinkUvName = "cmn_pop01_fnt_02_p";
		[SerializeField]
		private RawImageEx[] m_blueLabel; // 0x80
		[SerializeField]
		private RawImageEx m_pinkLabel; // 0x84
		private TexUVListManager m_uvManager; // 0x88
		private PopupTabButton.ButtonLabel m_label; // 0x8C
		private static StringBuilder s_stringBuilder = new StringBuilder(64); // 0x0

		public PopupTabButton.ButtonLabel Label { get { return m_label; } } //0x1BB436C

		// // RVA: 0x1BB4374 Offset: 0x1BB4374 VA: 0x1BB4374 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			return base.InitializeFromLayout(layout, uvMan);
		}

		// // RVA: 0x1BB4394 Offset: 0x1BB4394 VA: 0x1BB4394 Slot: 11
		protected override void Start()
		{
			base.Start();
			m_animEndCallBack = () =>
			{
				//0x1BB4B0C
				return;
			};
		}

		// // RVA: 0x1BB44D0 Offset: 0x1BB44D0 VA: 0x1BB44D0
		public void SetLabel(PopupTabButton.ButtonLabel label)
		{
			s_stringBuilder.Clear();
			s_stringBuilder.AppendFormat("{0}{1:D2}", "cmn_pop01_fnt_02_b", label);
			TexUVData uvData = m_uvManager.GetUVData(s_stringBuilder.ToString());
			for(int i = 0; i < m_blueLabel.Length; i++)
			{
				m_blueLabel[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
			}
			s_stringBuilder.Clear();
			s_stringBuilder.AppendFormat("{0}{1:D2}", "cmn_pop01_fnt_02_p", label);
			uvData = m_uvManager.GetUVData(s_stringBuilder.ToString());
			m_pinkLabel.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);

			m_label = label;
		}

		// // RVA: 0x1BB4900 Offset: 0x1BB4900 VA: 0x1BB4900 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if (IsClick)
				return;
			base.OnPointerClick(eventData);
		}

		// // RVA: 0x1BB4934 Offset: 0x1BB4934 VA: 0x1BB4934 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			if (IsClick)
				return;
			base.OnPointerDown(eventData);
		}

		// // RVA: 0x1BB4968 Offset: 0x1BB4968 VA: 0x1BB4968 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			if (IsClick)
				return;
			base.OnPointerUp(eventData);
		}

		// // RVA: 0x1BB499C Offset: 0x1BB499C VA: 0x1BB499C Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (IsClick)
				return;
			base.OnPointerEnter(eventData);
		}

		// // RVA: 0x1BB49D0 Offset: 0x1BB49D0 VA: 0x1BB49D0 Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			if (IsClick)
				return;
			base.OnPointerExit(eventData);
		}
	}
}
