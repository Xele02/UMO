using System.Collections;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MenuDivaControlBase : MenuDivaManager.ControlDelegater
	{
		protected MenuDivaObject DivaObject { get; private set; } // 0x8
		protected MenuDivaManager DivaManager { get; private set; } // 0xC

		//// RVA: 0xEC84E4 Offset: 0xEC84E4 VA: 0xEC84E4 Slot: 6
		public virtual void OnUpdate()
		{
			return;
		}

		//// RVA: 0xEC84E8 Offset: 0xEC84E8 VA: 0xEC84E8 Slot: 7
		public virtual void OnLateUpdate()
		{
			return;
		}

		//// RVA: 0xEC84EC Offset: 0xEC84EC VA: 0xEC84EC
		protected Coroutine StartCoroutine(IEnumerator routine)
		{
			if (DivaManager != null)
				return DivaManager.StartCoroutineWatched(routine);
			return null;
		}

		//// RVA: 0xEC85B0 Offset: 0xEC85B0 VA: 0xEC85B0
		//protected void this.StopCoroutineWatched(Coroutine routine) { }

		//// RVA: 0xEC866C Offset: 0xEC866C VA: 0xEC866C Slot: 4
		public void BeginControl(MenuDivaManager divaManager, MenuDivaObject divaObject)
		{
			DivaObject = divaObject;
			DivaManager = divaManager;
			OnBeginControl();
		}

		//// RVA: 0xEC8684 Offset: 0xEC8684 VA: 0xEC8684 Slot: 5
		public void EndControl()
		{
			OnEndControl();
			DivaObject = null;
			DivaManager = null;
		}

		//// RVA: 0xEC86B4 Offset: 0xEC86B4 VA: 0xEC86B4 Slot: 8
		protected virtual void OnBeginControl()
		{
			return;
		}

		//// RVA: 0xEC86B8 Offset: 0xEC86B8 VA: 0xEC86B8 Slot: 9
		protected virtual void OnEndControl()
		{
			return;
		}
	}
}
