using UnityEngine;
using System;
using UnityEngine.Events;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class AutoSettingPanel : MonoBehaviour
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
			//
		}

		[Serializable]
		public class TobbleButtonEvent : UnityEvent<bool>
		{
			//
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_attributeButtonGroup; // 0xC
		[SerializeField]
		private UGUIToggleButtonGroup m_statusButtonGroup; // 0x10
		[SerializeField]
		private UGUIToggleButton m_keepCenterSkill; // 0x14
		[SerializeField]
		private UGUIToggleButton m_compatibleDiva; // 0x18
		[SerializeField]
		private Text[] m_texts; // 0x1C
		[SerializeField]
		private SelectButtonEvent m_onSelectAttributeEvent; // 0x20
		[SerializeField]
		private SelectButtonEvent m_onSelectStatusEvent; // 0x24
		[SerializeField]
		private TobbleButtonEvent m_onSelectkeepCenterSkillEvent; // 0x28
		[SerializeField]
		private TobbleButtonEvent m_onSelectCompatibleDivaEvent; // 0x2C

		public UGUIToggleButtonGroup AttributeButtonGruop { get { return m_attributeButtonGroup; } } //0x1434CF8
		public UGUIToggleButtonGroup StatusButtonGruop { get { return m_statusButtonGroup; } } //0x1434D00
		public UGUIToggleButton KeepCenterSkillToggle { get { return m_keepCenterSkill; } } //0x1434D08
		public UGUIToggleButton CompatibleDivaToggle { get { return m_compatibleDiva; } } //0x1434D10
		public SelectButtonEvent OnSelectAttribute { get { return m_onSelectAttributeEvent; } } //0x1434D18
		public SelectButtonEvent OnSelectStatus { get { return m_onSelectStatusEvent; } } //0x1434D20
		public TobbleButtonEvent OnSelectCenterSkill { get { return m_onSelectkeepCenterSkillEvent; } } //0x1434D28
		public TobbleButtonEvent OnSelectCompatibleDiva { get { return m_onSelectCompatibleDivaEvent; } } //0x1434D30

		// RVA: 0x1434D38 Offset: 0x1434D38 VA: 0x1434D38
		private void Awake()
		{
			m_attributeButtonGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0x14350CC
				m_onSelectAttributeEvent.Invoke(index);
			});
			m_statusButtonGroup.OnSelectToggleButtonEvent.AddListener((int index) =>
			{
				//0x143514C
				m_onSelectStatusEvent.Invoke(index);
			});
			m_keepCenterSkill.AddOnClickCallback(() =>
			{
				//0x14351CC
				m_onSelectkeepCenterSkillEvent.Invoke(m_keepCenterSkill.IsOn);
			});
			m_compatibleDiva.AddOnClickCallback(() =>
			{
				//0x143526C
				m_onSelectCompatibleDivaEvent.Invoke(m_compatibleDiva.IsOn);
			});
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_texts[0].text = bk.GetMessageByLabel("unit_auto_popup_text_00");
			m_texts[1].text = bk.GetMessageByLabel("unit_auto_popup_text_01");

			m_attributeButtonGroup.transform.Find("Title/Text").GetComponent<Text>().text = JpStringLiterals.UMO_PlayAttr2;
			m_attributeButtonGroup.transform.Find("AttrAllToggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_All;
			m_attributeButtonGroup.transform.Find("Attr1Toggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Attr1;
			m_attributeButtonGroup.transform.Find("Attr2Toggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Attr2;
			m_attributeButtonGroup.transform.Find("Attr3Toggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Attr3;

			m_statusButtonGroup.transform.Find("Title/Text").GetComponent<Text>().text = JpStringLiterals.UMO_PlayStatus;
			m_statusButtonGroup.transform.Find("TotalToggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Total;
			m_statusButtonGroup.transform.Find("SoulToggle/Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11063;
			m_statusButtonGroup.transform.Find("VoiceToggle/Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11064;
			m_statusButtonGroup.transform.Find("CharmToggle/Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11065;
			m_statusButtonGroup.transform.Find("LifeToggle/Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11062;
			m_statusButtonGroup.transform.Find("SupportToggle/Label").GetComponent<Text>().text = JpStringLiterals.StringLiteral_11069;
			m_statusButtonGroup.transform.Find("FoldToggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Fold;
			m_statusButtonGroup.transform.Find("LuckToggle/Label").GetComponent<Text>().text = JpStringLiterals.UMO_Luck;
		}
	}
}
