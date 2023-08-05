using UnityEngine.Events;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public abstract class LayoutPopupConfigDetailBase : LayoutUGUIScriptBase
	{
		// RVA: -1 Offset: -1 Slot: 6
		public abstract void SetStatus();

		//// RVA: -1 Offset: -1 Slot: 7
		public abstract void SetTextTitle(string text);

		//// RVA: -1 Offset: -1 Slot: 8
		public abstract void SetTextOher3D(string text);

		//// RVA: -1 Offset: -1 Slot: 9
		public abstract void SetToggleButtonOher3DEnable(int index);

		//// RVA: 0x1EC2F9C Offset: 0x1EC2F9C VA: 0x1EC2F9C Slot: 10
		public virtual void SetTextDesc2d(string text)
		{
			return;
		}

		//// RVA: 0x1EC2FA0 Offset: 0x1EC2FA0 VA: 0x1EC2FA0 Slot: 11
		public virtual void SetToggleButton2DEnable(int index)
		{
			return;
		}

		//// RVA: -1 Offset: -1 Slot: 12
		public abstract void SetTextDescDiva3D(string text);

		//// RVA: -1 Offset: -1 Slot: 13
		public abstract void SetToggleButtonDiva3DEnable(int index);

		//// RVA: 0x1EC2B38 Offset: 0x1EC2B38 VA: 0x1EC2B38
		protected void SetToggleButtonCallback(ToggleButtonGroup group, UnityAction<int> callback)
		{
			if(group != null)
			{
				group.OnSelectToggleButtonEvent.AddListener(callback);
			}
		}

		// RVA: 0x1EC2FA4 Offset: 0x1EC2FA4 VA: 0x1EC2FA4 Slot: 14
		public virtual void Reset()
		{
			return;
		}

		// RVA: 0x1EC2FA8 Offset: 0x1EC2FA8 VA: 0x1EC2FA8 Slot: 15
		public virtual void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1EC2FE0 Offset: 0x1EC2FE0 VA: 0x1EC2FE0 Slot: 16
		public virtual void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}
