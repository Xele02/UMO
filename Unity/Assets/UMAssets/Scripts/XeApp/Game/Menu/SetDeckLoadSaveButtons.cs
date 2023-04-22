using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class SetDeckLoadSaveButtons : MonoBehaviour
	{
		public enum ModeType
		{
			NewSave = 0,
			Overwrite = 1,
		}
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6817C0 Offset: 0x6817C0 VA: 0x6817C0
		private InOutAnime m_inOut; // 0xC
		//[TooltipAttribute] // RVA: 0x681808 Offset: 0x681808 VA: 0x681808
		[SerializeField]
		private UGUIButton m_saveButton; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x681858 Offset: 0x681858 VA: 0x681858
		private UGUIButton m_loadButton; // 0x14
		//[TooltipAttribute] // RVA: 0x6818B0 Offset: 0x6818B0 VA: 0x6818B0
		[SerializeField]
		private Image m_SaveTextSprite; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x681910 Offset: 0x681910 VA: 0x681910
		private UnitSetSaveTextScriptableObject m_SaveTextSpriteList; // 0x1C
		public Action OnClickSaveButton; // 0x20
		public Action OnClickLoadButton; // 0x24

		public InOutAnime InOut { get { return m_inOut; } } //0xA6F430

		// RVA: 0xA6F438 Offset: 0xA6F438 VA: 0xA6F438
		private void Awake()
		{
			if(m_saveButton != null)
			{
				m_saveButton.AddOnClickCallback(() =>
				{
					//0xA6F688
					if (OnClickSaveButton != null)
						OnClickSaveButton();
				});
			}
			if(m_loadButton != null)
			{
				m_loadButton.AddOnClickCallback(() =>
				{
					//0xA6F69C
					if (OnClickLoadButton != null)
						OnClickLoadButton();
				});
			}
		}

		//// RVA: 0xA6F5CC Offset: 0xA6F5CC VA: 0xA6F5CC
		public void SetType(ModeType type)
		{
			m_SaveTextSprite.sprite = m_SaveTextSpriteList.GetSaveTextSprite((int)type);
			if(type == ModeType.Overwrite)
			{
				m_loadButton.Disable = false;
			}
			else
			{
				m_loadButton.Disable = true;
			}
		}
	}
}
