
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{ 
	public class BadgeIcon
	{
		private LayoutObject m_object; // 0x8
		private BadgeIconBehaviour m_behaviour; // 0xC

		// RVA: 0x14355F0 Offset: 0x14355F0 VA: 0x14355F0
		public BadgeIcon() { }

		// RVA: 0x14355F8 Offset: 0x14355F8 VA: 0x14355F8
		public BadgeIcon(GameObject parent, AbsoluteLayout parentLayout)
		{
			Initialize(parent, parentLayout);
		}

		// RVA: 0x1435628 Offset: 0x1435628 VA: 0x1435628
		public void Initialize(GameObject parent, AbsoluteLayout parentLayout)
		{
			Release();
			m_object = GameManager.Instance.IconDecorationCache.GetInstance(LayoutPoolManager.PoolType.Badge);
			m_object.Runtime.transform.SetParent(parent.transform, false);
			m_object.Runtime.transform.SetAsLastSibling();
			if(parentLayout != null)
			{
				parentLayout.AddView(m_object.Runtime.Layout.Root);
				m_object.ParentLayout = parentLayout;
			}
			m_behaviour = m_object.Runtime.gameObject.GetComponentInChildren<BadgeIconBehaviour>();
		}

		// RVA: 0x1435900 Offset: 0x1435900 VA: 0x1435900
		public void Release()
		{
			if (m_object == null)
				return;
			GameManager.Instance.IconDecorationCache.Release(LayoutPoolManager.PoolType.Badge, m_object);
			m_object = null;
			m_behaviour = null;
		}

		// RVA: 0x14359E4 Offset: 0x14359E4 VA: 0x14359E4
		public void Set(BadgeConstant.ID id, string text)
		{
			if (m_behaviour == null)
				return;
			if(id >= BadgeConstant.ID.New && id <= BadgeConstant.ID.Menu_ResvMsg)
			{
				m_behaviour.SetType(BadgeIconBehaviour.Type.Image);
				m_behaviour.SetTextureUv(id);
			}
			else if(id == BadgeConstant.ID.Label)
			{
				m_behaviour.SetType(BadgeIconBehaviour.Type.Text);
				m_behaviour.SetText(text);
			}
			else if(id != BadgeConstant.ID.None)
			{
				m_behaviour.SetType(BadgeIconBehaviour.Type.Exclamation);
			}
			else
			{
				m_behaviour.SetType(BadgeIconBehaviour.Type.Hide);
			}
		}
	}
}
