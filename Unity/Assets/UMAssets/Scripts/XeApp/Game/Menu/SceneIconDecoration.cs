
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneIconDecoration
	{
		public enum Size
		{
			S = 0,
			M = 1,
			L = 2,
		}

		private LayoutObject m_frontObject; // 0x8
		private SceneIconDecorationBehaviour m_sceneIconDecrationBehaviour; // 0xC
		private Size m_size; // 0x10
		private static readonly LayoutPoolManager.PoolType[] prefabName = new LayoutPoolManager.PoolType[3] { LayoutPoolManager.PoolType.SceneIcon_S, LayoutPoolManager.PoolType.SceneIcon_S, LayoutPoolManager.PoolType.SceneIcon_L }; // 0x0
		private static readonly Vector2[] BaseSize = new Vector2[3] { new Vector2(256, 138), new Vector2(256, 138), new Vector2(512, 276) }; // 0x4

		//// RVA: 0x1369B2C Offset: 0x1369B2C VA: 0x1369B2C
		public SceneIconDecoration(GameObject parent, Size size, AbsoluteLayout parentLayout, GameObject positionParent)
		{
			m_frontObject = null;
			m_sceneIconDecrationBehaviour = null;
			m_size = Size.L;
			Initialize(parent, size, parentLayout, positionParent);
		}

		//// RVA: 0x136A420 Offset: 0x136A420 VA: 0x136A420
		public SceneIconDecoration()
		{
			return;
		}

		//// RVA: 0x1369B88 Offset: 0x1369B88 VA: 0x1369B88
		public void Initialize(GameObject parent, Size size, AbsoluteLayout parentLayout, GameObject positionParent)
		{
			Vector2 s = new Vector2();
			Release();
			Vector2 sp = parent.GetComponent<RectTransform>().sizeDelta;
			float f = Mathf.Max(sp.x / BaseSize[(int)size].x, sp.y / BaseSize[(int)size].y);
			if (size == Size.S)
			{
				s.x = Mathf.Clamp(f, 0.8f, 1.0f);
				s.y = Mathf.Clamp(f, 0.8f, 1.0f);
			}
			else
			{
				s.x = 0.8f;
				s.y = 0.8f;
			}
			m_frontObject = GameManager.Instance.IconDecorationCache.GetInstance(prefabName[(int)size]);
			m_frontObject.Runtime.transform.SetParent(parent.transform, false);
			m_frontObject.Runtime.transform.SetAsLastSibling();
			m_frontObject.Runtime.transform.localScale = new Vector3(s.x, s.y, 1);
			if(parentLayout != null)
			{
				parentLayout.AddView(m_frontObject.Runtime.Layout.Root);
				m_frontObject.ParentLayout = parentLayout;
			}
			if(positionParent != null)
			{
				m_frontObject.Runtime.transform.position = positionParent.transform.position;
			}
			m_size = size;
			m_sceneIconDecrationBehaviour = m_frontObject.Runtime.gameObject.GetComponentInChildren<SceneIconDecorationBehaviour>(true);
			m_sceneIconDecrationBehaviour.AdjustEpisodeName(parent.GetComponent<RectTransform>(), s);
			GameManager.Instance.UpdateAction += this.UpdateMaxAnime;
		}

		//// RVA: 0x136A428 Offset: 0x136A428 VA: 0x136A428
		public void Release()
		{
			if(m_frontObject != null)
			{
				GameManager.Instance.IconDecorationCache.Release(prefabName[(int)m_size], m_frontObject);
				m_frontObject = null;
			}
			GameManager.Instance.UpdateAction -= this.UpdateMaxAnime;
		}

		//// RVA: 0x136A8A0 Offset: 0x136A8A0 VA: 0x136A8A0
		//private bool IsMaxLevel(GCIJNCFDNON sceneData) { }

		//// RVA: 0x136A9DC Offset: 0x136A9DC VA: 0x136A9DC
		//public void Change(GCIJNCFDNON sceneData, DisplayType type) { }

		//// RVA: 0x136CE10 Offset: 0x136CE10 VA: 0x136CE10
		//private int GetRareToFrameUvIndex(int rare) { }

		//// RVA: 0x136B128 Offset: 0x136B128 VA: 0x136B128
		//public void SetActive(bool isActive) { }

		//// RVA: 0x136CEB0 Offset: 0x136CEB0 VA: 0x136CEB0
		//public bool IsActive() { }

		//// RVA: 0x136CF14 Offset: 0x136CF14 VA: 0x136CF14
		private void UpdateMaxAnime(float time)
		{
			m_sceneIconDecrationBehaviour.UpdateMaxAnime(time);
		}
	}

}
