
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class DivaIconDecoration
	{
		public enum Size
		{
			S = 0,
			M = 1,
			L = 2,
		}

		public static int FriendFanFadeAnimStartFrame = 1; // 0x0
		public static int FriendFanFadeAnimEndFrame = 404; // 0x4
		private LayoutObject m_frontObject; // 0x8
		private LayoutObject m_friendObject; // 0xC
		private DivaIconDecorationBehaviour m_divaIconDecorationBehaviour; // 0x10
		private DivaFriendIconDecorationBehaviour m_divaFriendIconDecrationBehaviour; // 0x14
		private DivaIconDecoration.Size m_size; // 0x18
		private EDMIONMCICN m_calcStatusResult; // 0x1C
		private StatusData m_status = new StatusData(); // 0x40
		private static readonly LayoutPoolManager.PoolType[] prefabName = new LayoutPoolManager.PoolType[3] { LayoutPoolManager.PoolType.DivaIcon_S, LayoutPoolManager.PoolType.DivaIcon_M, LayoutPoolManager.PoolType.DivaIcon_L }; // 0x8
		private static readonly float[] BaseSize = new float[3] { 128, 256, 512 }; // 0xC

		//// RVA: 0x17E158C Offset: 0x17E158C VA: 0x17E158C
		public DivaIconDecoration(GameObject parent, Size size, AbsoluteLayout parentLayout, GameObject positionParent)
		{
			Initialize(parent, size, true, false, parentLayout, positionParent);
			m_calcStatusResult.OBKGEDCKHHE();
		}

		//// RVA: 0x17E1650 Offset: 0x17E1650 VA: 0x17E1650
		public DivaIconDecoration(GameObject parent, Size size, bool useDiva, bool useFriend, AbsoluteLayout parentLayout, GameObject positionParent)
		{
			Initialize(parent, size, useDiva, useFriend, parentLayout, positionParent);
			m_calcStatusResult.OBKGEDCKHHE();
		}

		//// RVA: 0x17D60A4 Offset: 0x17D60A4 VA: 0x17D60A4
		public DivaIconDecoration()
		{
			m_calcStatusResult.OBKGEDCKHHE();
		}

		//// RVA: 0x17D2C14 Offset: 0x17D2C14 VA: 0x17D2C14
		//public void Initialize(GameObject parent, DivaIconDecoration.Size size, AbsoluteLayout parentLayout, GameObject positionParent) { }

		//// RVA: 0x17E1718 Offset: 0x17E1718 VA: 0x17E1718
		public void Initialize(GameObject parent, Size size, bool useDiva, bool useFriend, AbsoluteLayout parentLayout, GameObject positionParent)
		{
			Release();
			m_size = size;
			Vector2 s = new Vector2();
			if(useDiva)
			{
				Vector2 sp = parent.GetComponent<RectTransform>().sizeDelta;
				s.x = Mathf.Clamp(sp.x / BaseSize[(int)size], 0.65f, 1.0f);
				s.y = Mathf.Clamp(sp.y / BaseSize[(int)size], 0.65f, 1.0f);
				m_frontObject = GameManager.Instance.IconDecorationCache.GetInstance(prefabName[(int)size]);
				m_frontObject.Runtime.transform.SetParent(parent.transform, false);
				m_frontObject.Runtime.transform.SetAsLastSibling();
				m_frontObject.Runtime.transform.localScale = new Vector3(s.x, s.y, 1.0f);
				if(parentLayout != null)
				{
					parentLayout.AddView(m_frontObject.Runtime.Layout.Root);
					m_frontObject.ParentLayout = parentLayout;
				}
				if(positionParent != null)
				{
					m_frontObject.Runtime.transform.position = positionParent.transform.position;
				}
				m_divaIconDecorationBehaviour = m_frontObject.Runtime.gameObject.GetComponentInChildren<DivaIconDecorationBehaviour>(true);
			}
			if(useFriend)
			{
				m_friendObject = GameManager.Instance.IconDecorationCache.GetInstance(size == Size.S ? LayoutPoolManager.PoolType.FriendIcon_S : LayoutPoolManager.PoolType.FriendIcon_M);
				m_friendObject.Runtime.transform.SetParent(parent.transform, false);
				m_friendObject.Runtime.transform.SetAsLastSibling();
				m_divaFriendIconDecrationBehaviour = m_friendObject.Runtime.GetComponentInChildren<DivaFriendIconDecorationBehaviour>(true);
				if(parentLayout != null)
				{
					parentLayout.AddView(m_friendObject.Runtime.Layout.Root);
					m_friendObject.ParentLayout = parentLayout;
				}
				if (positionParent != null)
				{
					m_friendObject.Runtime.transform.position = positionParent.transform.position;
				}
			}
		}

		//// RVA: 0x17D2C68 Offset: 0x17D2C68 VA: 0x17D2C68
		public void Release()
		{
			if(m_frontObject != null)
			{
				GameManager.Instance.IconDecorationCache.Release(prefabName[(int)m_size], m_frontObject);
				m_divaIconDecorationBehaviour = null;
				m_frontObject = null;
			}
			if(m_friendObject != null)
			{
				GameManager.Instance.IconDecorationCache.Release(m_size == Size.S ? LayoutPoolManager.PoolType.FriendIcon_S : LayoutPoolManager.PoolType.FriendIcon_M, m_friendObject);
				m_divaFriendIconDecrationBehaviour = null;
				m_friendObject = null;
			}
		}

		//// RVA: 0x17D2EC0 Offset: 0x17D2EC0 VA: 0x17D2EC0
		//public void Change(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData, DisplayType type) { }

		//// RVA: 0x17E2640 Offset: 0x17E2640 VA: 0x17E2640
		//public void Change(FFHPBEPOMAK divaData, EAJCBFGKKFA friendPlayerData, DisplayType type, GCIJNCFDNON assistMainScene) { }

		//// RVA: 0x17E29F8 Offset: 0x17E29F8 VA: 0x17E29F8
		//public void Change(FFHPBEPOMAK divaData, DisplayType type) { }

		//// RVA: 0x17E2A90 Offset: 0x17E2A90 VA: 0x17E2A90
		//public void Change(FFHPBEPOMAK divaData, EAJCBFGKKFA friendPlayerData, bool isFavorite, DisplayType type) { }

		//// RVA: 0x17E2C64 Offset: 0x17E2C64 VA: 0x17E2C64
		//public void FadeFrienFanAnimationSetFrame(int frame) { }

		//// RVA: 0x17E2380 Offset: 0x17E2380 VA: 0x17E2380
		//private void Change(FFHPBEPOMAK divaData, StatusData statusData, int luck, int rarity, DisplayType type) { }

		//// RVA: 0x17E2128 Offset: 0x17E2128 VA: 0x17E2128
		//public static int GetEquipmentRarity(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData) { }

		//// RVA: 0x17D4D5C Offset: 0x17D4D5C VA: 0x17D4D5C
		//public static int GetEquipmentLuck(FFHPBEPOMAK divaData, DFKGGBMFFGB playerData) { }

		//// RVA: 0x17E2F34 Offset: 0x17E2F34 VA: 0x17E2F34
		//public static int GetEquipmentLuck(List<GCIJNCFDNON> sceneList) { }

		//// RVA: 0x17D4F90 Offset: 0x17D4F90 VA: 0x17D4F90
		//public void SetActive(bool isActive) { }

		//// RVA: 0x17E3048 Offset: 0x17E3048 VA: 0x17E3048
		//public bool IsActive() { }
	}
}
