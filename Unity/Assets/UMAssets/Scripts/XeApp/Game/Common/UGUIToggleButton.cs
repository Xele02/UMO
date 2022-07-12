using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class UGUIToggleButton : ButtonBase
	{
		[Serializable]
		private struct PushDownSetting
		{
			//[TooltipAttribute] // RVA: 0x68CFDC Offset: 0x68CFDC VA: 0x68CFDC
			public Transform m_targetTrans; // 0x0
			//[TooltipAttribute] // RVA: 0x68D02C Offset: 0x68D02C VA: 0x68D02C
			public Vector3 m_offset; // 0x4

			// RVA: 0x7FF79C Offset: 0x7FF79C VA: 0x7FF79C
			public PushDownSetting(Transform trans, Vector3 offset)
			{
				m_targetTrans = trans;
				m_offset = offset;
			}
		}
		
		[SerializeField]
		private short m_gropId = -1; // 0x30
		[SerializeField]
		private bool m_isNotRepeat; // 0x32
		[SerializeField]
		private UGUIToggleButtonGroup m_parent; // 0x34
		[SerializeField]
		private Image m_checkmark; // 0x38
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x68CEF8 Offset: 0x68CEF8 VA: 0x68CEF8
		private GameObject m_hiddenControlObj; // 0x3C
		//[TooltipAttribute] // RVA: 0x68CF78 Offset: 0x68CF78 VA: 0x68CF78
		[SerializeField]
		private UGUIToggleButton.PushDownSetting m_pushDownSetting = new PushDownSetting(null, Vector3.zero); // 0x40
		private Vector3 m_pushDownBasePos; // 0x50
		private bool m_isSet; // 0x5C

		//public short GropID { get; } 0x1CDC234
		public bool IsOn { get { return m_isSet; } } //0x1CDC23C

		// RVA: 0x1CDC244 Offset: 0x1CDC244 VA: 0x1CDC244
		public void Awake()
		{
			if(m_pushDownSetting.m_targetTrans != null)
			{
				m_pushDownBasePos = m_pushDownSetting.m_targetTrans.localPosition;
			}
		}

		// RVA: 0x1CDC314 Offset: 0x1CDC314 VA: 0x1CDC314 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(!Hidden && !Disable && !IsInputOff && !IsInputLock && IsEnableTouchId(eventData))
			{
				if(m_gropId > -1)
				{
					if(m_parent != null)
					{
						if(!m_isSet)
						{
							base.OnPointerClick(eventData);
						}
						m_parent.SelectGroupButton(this);
						return;
					}
				}
				if(!m_isNotRepeat)
				{
					if(m_isSet)
					{
						SetOff();
					}
				}
				else
				{
					if (m_isSet)
						return;
				}
				m_isClick = true;
				OnClickEvent();
			}
		}

		// RVA: 0x1CDC738 Offset: 0x1CDC738 VA: 0x1CDC738 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CDC73C Offset: 0x1CDC73C VA: 0x1CDC73C Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CDC740 Offset: 0x1CDC740 VA: 0x1CDC740 Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CDC744 Offset: 0x1CDC744 VA: 0x1CDC744 Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CDC748 Offset: 0x1CDC748 VA: 0x1CDC748 Slot: 21
		public override void SetOff()
		{
			if(!Hidden && !Disable)
			{
				m_checkmark.enabled = false;
				SetPushDownAnime(false);
				base.SetOff();
				m_isSet = false;
			}
		}

		// RVA: 0x1CDC924 Offset: 0x1CDC924 VA: 0x1CDC924 Slot: 20
		public override void SetOn()
		{
			if (!Hidden && !Disable)
			{
				m_checkmark.enabled = true;
				SetPushDownAnime(true);
				base.SetOn();
				m_isSet = true;
			}
		}

		// RVA: 0x1CDC99C Offset: 0x1CDC99C VA: 0x1CDC99C Slot: 23
		protected override void PlayNormal()
		{
			base.PlayNormal();
			if(m_hiddenControlObj != null)
			{
				m_hiddenControlObj.SetActive(true);
			}
		}

		// RVA: 0x1CDCA60 Offset: 0x1CDCA60 VA: 0x1CDCA60 Slot: 26
		protected override void PlayHidden()
		{
			base.PlayHidden();
			if (m_hiddenControlObj != null)
			{
				m_hiddenControlObj.SetActive(false);
			}
		}

		// RVA: 0x1CDC248 Offset: 0x1CDC248 VA: 0x1CDC248
		//private void InitPushDownAnime() { }

		// RVA: 0x1CDC7C0 Offset: 0x1CDC7C0 VA: 0x1CDC7C0
		private void SetPushDownAnime(bool isDown)
		{
			if(m_pushDownSetting.m_targetTrans != null)
			{
				Vector3 pos = m_pushDownBasePos;
				if(isDown)
				{
					pos += m_pushDownSetting.m_offset;
				}
				m_pushDownSetting.m_targetTrans.localPosition = pos;
			}
		}
	}
}
