using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class SetDeckUnitInfoMessageControl : MonoBehaviour
	{
		public enum DispType
		{
			Keep = 0,
			OneShot = 1,
		}

		public enum MessageType
		{
			UnitSetHelp = 0,
		}

		private enum StatusType
		{
			Hide = 0,
			Enter = 1,
			Show = 2,
			Leave = 3,
		}

		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684520 Offset: 0x684520 VA: 0x684520
		private ColorGroup m_colorGroup; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684578 Offset: 0x684578 VA: 0x684578
		private GameObject m_allObject; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6845DC Offset: 0x6845DC VA: 0x6845DC
		private Text m_messageText; // 0x14
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684624 Offset: 0x684624 VA: 0x684624
		private UGUICurveMover.CurveInfo m_inOutCurveInfo; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x684680 Offset: 0x684680 VA: 0x684680
		private float m_dispTimeLength; // 0x20
		private DispType m_dispType; // 0x24
		private MessageType m_messageType; // 0x28
		private StatusType m_statusType; // 0x2C
		private float m_dispTimeCount; // 0x30
		private UGUICurveMover m_inOutCuveMover = new UGUICurveMover(); // 0x34
		private static readonly Color HideColor = new Color(1, 1, 1, 0); // 0x0
		private static readonly Color ShowColor = new Color(1, 1, 1, 1); // 0x10

		//public bool IsShown { get; } 0xC35AE0
		//public bool IsPlaying { get; } 0xC35AF8

		// RVA: 0xC35B18 Offset: 0xC35B18 VA: 0xC35B18
		private void Awake()
		{
			Hide();
		}

		// RVA: 0xC35C6C Offset: 0xC35C6C VA: 0xC35C6C
		private void Update()
		{
			if(m_statusType == StatusType.Leave)
			{
				m_inOutCuveMover.Update(Time.deltaTime);
				if(!m_inOutCuveMover.IsPlaying)
				{
					m_colorGroup.color = HideColor;
					m_colorGroup.SetMaterialDirty();
					m_statusType = StatusType.Hide;
					m_allObject.SetActive(false);
					return;
				}
			}
			else
			{
				if (m_statusType == StatusType.Show)
				{
					if (m_dispType != DispType.OneShot)
						return;
					m_dispTimeCount += Time.deltaTime;
					if (m_dispTimeCount < m_dispTimeLength)
						return;
					Leave();
					return;
				}
				if (m_statusType != StatusType.Enter)
					return;
				m_inOutCuveMover.Update(Time.deltaTime);
				if(!m_inOutCuveMover.IsPlaying)
				{
					m_colorGroup.color = ShowColor;
					m_colorGroup.SetMaterialDirty();
					m_statusType = StatusType.Show;
					return;
				}
			}
			m_colorGroup.color = Color.Lerp(HideColor, ShowColor, m_inOutCuveMover.CurrentValue);
			m_colorGroup.SetMaterialDirty();
		}

		//// RVA: 0xC36298 Offset: 0xC36298 VA: 0xC36298
		public void Enter(DispType dispType, MessageType messageType = 0)
		{
			m_allObject.SetActive(true);
			m_dispType = dispType;
			m_messageType = messageType;
			m_dispTimeCount = 0;
			ApplyMessage(messageType);
			if(m_statusType > StatusType.Enter)
			{
				m_colorGroup.color = HideColor;
			}
			m_colorGroup.SetMaterialDirty();
			m_inOutCuveMover.Setup(ref m_inOutCurveInfo);
			m_inOutCuveMover.Play(false);
			m_statusType = StatusType.Enter;
		}

		//// RVA: 0xC36544 Offset: 0xC36544 VA: 0xC36544
		//public void Show(SetDeckUnitInfoMessageControl.DispType dispType, SetDeckUnitInfoMessageControl.MessageType messageType = 0) { }

		//// RVA: 0xC3612C Offset: 0xC3612C VA: 0xC3612C
		public void Leave()
		{
			if(m_statusType > StatusType.Hide && m_statusType < StatusType.Leave)
			{
				m_colorGroup.color = ShowColor;
				m_colorGroup.SetMaterialDirty();
				m_inOutCuveMover.Setup(ref m_inOutCurveInfo);
				m_inOutCuveMover.Play(false);
				m_statusType = StatusType.Leave;
			}
		}

		//// RVA: 0xC35B1C Offset: 0xC35B1C VA: 0xC35B1C
		public void Hide()
		{
			m_colorGroup.color = HideColor;
			m_colorGroup.SetMaterialDirty();
			m_inOutCuveMover.Stop();
			m_allObject.SetActive(false);
			m_statusType = StatusType.Hide;
		}

		//// RVA: 0xC36448 Offset: 0xC36448 VA: 0xC36448
		private void ApplyMessage(MessageType messageType)
		{
			if (messageType != MessageType.UnitSetHelp)
				return;
			m_messageText.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel("unit_unitset_description");
		}
	}
}
