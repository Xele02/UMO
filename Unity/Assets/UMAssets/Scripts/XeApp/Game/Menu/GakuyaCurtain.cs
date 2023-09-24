using UnityEngine;
using System;
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GakuyaCurtain : MonoBehaviour
	{
		public enum MessageType
		{
			ChangeCostume = 0,
			ChangeDiva = 1,
		}

		[Serializable]
		private struct DivaSettingInfo
		{
			//[TooltipAttribute] // RVA: 0x66DDC4 Offset: 0x66DDC4 VA: 0x66DDC4
			public Color32 m_colorBorder1; // 0x0
			//[TooltipAttribute] // RVA: 0x66DE00 Offset: 0x66DE00 VA: 0x66DE00
			public Color32 m_colorBorder2; // 0x4
			//[TooltipAttribute] // RVA: 0x66DE3C Offset: 0x66DE3C VA: 0x66DE3C
			public Sprite m_spriteBorder; // 0x8
			//[TooltipAttribute] // RVA: 0x66DE7C Offset: 0x66DE7C VA: 0x66DE7C
			public Sprite m_spriteChara; // 0xC
			//[TooltipAttribute] // RVA: 0x66DEC4 Offset: 0x66DEC4 VA: 0x66DEC4
			public int m_messageImagePosId; // 0x10
		}

		//[TooltipAttribute] // RVA: 0x66DB6C Offset: 0x66DB6C VA: 0x66DB6C
		[SerializeField]
		private UGUIEnterLeave m_enterLeaveControl; // 0xC
		//[TooltipAttribute] // RVA: 0x66DBB4 Offset: 0x66DBB4 VA: 0x66DBB4
		[SerializeField]
		private List<Image> m_imageBorderGroup1; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DC10 Offset: 0x66DC10 VA: 0x66DC10
		private List<Image> m_imageBorderGroup2; // 0x14
		//[TooltipAttribute] // RVA: 0x66DC6C Offset: 0x66DC6C VA: 0x66DC6C
		[SerializeField]
		private Image m_imageChara; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DCBC Offset: 0x66DCBC VA: 0x66DCBC
		private List<Image> m_imageMessageList; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DD14 Offset: 0x66DD14 VA: 0x66DD14
		private List<DivaSettingInfo> m_divaSettinfInfos; // 0x20
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x66DD68 Offset: 0x66DD68 VA: 0x66DD68
		private List<Sprite> m_messageSprites; // 0x24

		// RVA: 0xB6FB44 Offset: 0xB6FB44 VA: 0xB6FB44
		public void SetDiva(int divaId)
		{
			// this was reverted with ghidra bugging. Not sure everything is right
			int idx = Mathf.Clamp(divaId - 1, 0, m_divaSettinfInfos.Count);
			DivaSettingInfo info = m_divaSettinfInfos[idx];
			foreach(var im in m_imageBorderGroup1)
			{
				im.color = info.m_colorBorder1;
				im.sprite = info.m_spriteBorder;
			}
			foreach (var im in m_imageBorderGroup2)
			{
				im.color = info.m_colorBorder2;
				im.sprite = info.m_spriteBorder;
			}
			m_imageChara.sprite = info.m_spriteChara;
			foreach (var im in m_imageMessageList)
			{
				im.enabled = false;
			}
			m_imageMessageList[info.m_messageImagePosId].enabled = true;
		}

		// RVA: 0xB700D0 Offset: 0xB700D0 VA: 0xB700D0
		public void SetMessageType(MessageType type)
		{
			foreach (var m in m_imageMessageList)
			{
				m.sprite = m_messageSprites[(int)type];
			}
		}

		//// RVA: 0xB7026C Offset: 0xB7026C VA: 0xB7026C
		//public void Enter() { }

		// RVA: 0xB70298 Offset: 0xB70298 VA: 0xB70298
		public void Leave()
		{
			m_enterLeaveControl.Leave();
		}

		// RVA: 0xB702C4 Offset: 0xB702C4 VA: 0xB702C4
		public void TryEnter()
		{
			m_enterLeaveControl.TryEnter();
		}

		//// RVA: 0xB702F0 Offset: 0xB702F0 VA: 0xB702F0
		//public void TryLeave() { }

		//// RVA: 0xB7031C Offset: 0xB7031C VA: 0xB7031C
		//public void Show() { }

		// RVA: 0xB70348 Offset: 0xB70348 VA: 0xB70348
		public void Hide()
		{
			m_enterLeaveControl.Hide();
		}

		// RVA: 0xB70374 Offset: 0xB70374 VA: 0xB70374
		public bool IsPlaying()
		{
			return m_enterLeaveControl.IsPlaying();
		}
	}
}
