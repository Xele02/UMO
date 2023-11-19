using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutBingoSelectQuest : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx ItemIcon; // 0x14
		[SerializeField]
		private Text ItemName; // 0x18
		[SerializeField]
		private Text QuestText; // 0x1C
		[SerializeField]
		private ActionButton ItemButton; // 0x20
		private bool m_isItemIconLoad; // 0x24

		// RVA: 0x19D4234 Offset: 0x19D4234 VA: 0x19D4234
		private void Start()
		{
			return;
		}

		// RVA: 0x19D4238 Offset: 0x19D4238 VA: 0x19D4238
		private void Update()
		{
			return;
		}

		// RVA: 0x19D423C Offset: 0x19D423C VA: 0x19D423C
		public void Setting(int itemId, string ItemText, string questText)
		{
			SetText(ItemText, questText);
			SetItemIcon(itemId);
		}

		// RVA: 0x19D43F0 Offset: 0x19D43F0 VA: 0x19D43F0
		public void SettingButton(Action act)
		{
			ItemButton.ClearOnClickCallback();
			ItemButton.AddOnClickCallback(() =>
			{
				//0x19D4624
				act();
			});
		}

		// RVA: 0x19D42D8 Offset: 0x19D42D8 VA: 0x19D42D8
		private void SetItemIcon(int itemId)
		{
			m_isItemIconLoad = false;
			GameManager.Instance.ItemTextureCache.Load(itemId, (IiconTexture icon) =>
			{
				//0x19D453C
				icon.Set(ItemIcon);
				m_isItemIconLoad = true;
			});
		}

		// RVA: 0x19D4268 Offset: 0x19D4268 VA: 0x19D4268
		private void SetText(string ItemText, string questText)
		{
			ItemName.text = ItemText;
			QuestText.text = questText;
		}

		// // RVA: 0x19D44F8 Offset: 0x19D44F8 VA: 0x19D44F8
		// public bool ILayoutLoaded() { }

		// RVA: 0x19D4500 Offset: 0x19D4500 VA: 0x19D4500 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
