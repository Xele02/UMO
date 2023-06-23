using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using XeSys.Gfx;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SceneGrowthInfinityPanel : SceneGrowthPanelBase, ISceneGrowthPanel
	{
		private enum Flags
		{
			Open = 1,
		}

		[SerializeField]
		private NumberBase m_stockNumber; // 0x28
		[SerializeField]
		private NumberBase m_valueNumber; // 0x2C
		[SerializeField]
		private ActionButton m_button; // 0x30
		private UnityAction m_panelPushAction; // 0x34
		private AbsoluteLayout m_rootAnime; // 0x38
		private AbsoluteLayout m_buttonAnime; // 0x3C
		private AbsoluteLayout m_numberMaxAnime; // 0x40
		private uint m_flags; // 0x44
		private short m_value; // 0x48
		private int m_stock; // 0x4C
		private GameObject m_3dEffect; // 0x50
		private const int StockMax = 10000;

		public bool IsPossible { get; set; } // 0x54
		public int Stock { get { return m_stock; } } //0x15A96A8
		public GrowthPanelType PanelType { get { return GrowthPanelType.Infinity; } } //0x15AE124
		//public Transform transform { get; } 0x15AE12C

		// RVA: 0x15ADEEC Offset: 0x15ADEEC VA: 0x15ADEEC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootAnime = layout.FindViewByExId("root_sw_endicon_set_layout_root") as AbsoluteLayout;
			m_buttonAnime = layout.FindViewByExId("root_sw_endicon_set_sw_btn_end") as AbsoluteLayout;
			m_numberMaxAnime = layout.FindViewByExId("root_sw_endicon_set_swnum_end") as AbsoluteLayout;
			ClearLoadedCallback();
			m_button.AddOnClickCallback(OnPushButton);
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x15AE134 Offset: 0x15AE134 VA: 0x15AE134
		//public void SetOpen() { }

		//// RVA: 0x15AE144 Offset: 0x15AE144 VA: 0x15AE144
		//public void SetClose() { }

		//// RVA: 0x15AE154 Offset: 0x15AE154 VA: 0x15AE154
		//public bool IsOpen() { }

		//// RVA: 0x15A95A4 Offset: 0x15A95A4 VA: 0x15A95A4
		public void SetStock(int stock)
		{
			m_stock = stock;
			m_stockNumber.SetNumber(stock, 0);
			m_button.Dark = m_stock == 0;
			m_numberMaxAnime.StartChildrenAnimGoStop(stock < 10000 ? "nomal" : "max");
		}

		//// RVA: 0x15A9560 Offset: 0x15A9560 VA: 0x15A9560
		public void SetValue(short value)
		{
			m_value = value;
			m_valueNumber.SetNumber(value, 0);
		}

		//// RVA: 0x15A9498 Offset: 0x15A9498 VA: 0x15A9498 Slot: 8
		public void Wait()
		{
			m_rootAnime.StartAllAnimGoStop("st_expand");
			m_buttonAnime.StartAllAnimGoStop(m_stock == 0 ? "st_get" : "st_get2");
		}

		//// RVA: 0x15AE160 Offset: 0x15AE160 VA: 0x15AE160 Slot: 9
		public void Expand()
		{
			m_rootAnime.StartAllAnimGoStop((m_flags & 1) == 0 ? "st_wait" : "st_expand");
		}

		//// RVA: 0x15AE1FC Offset: 0x15AE1FC VA: 0x15AE1FC Slot: 10
		//public void PlayUnLockAnime() { }

		//// RVA: 0x15AE2B0 Offset: 0x15AE2B0 VA: 0x15AE2B0 Slot: 11
		public void PlayExpandAnime()
		{
			if ((m_flags & 1) == 0)
				m_rootAnime.StartAllAnimGoStop("go_expand", "st_expand");
			else
				m_rootAnime.StartAllAnimGoStop("st_expand");
			if(m_stock == 0)
				m_buttonAnime.StartAllAnimGoStop("go_open", "st_open");
			else
				m_buttonAnime.StartAllAnimGoStop("go_open2", "st_open2");
		}

		//// RVA: 0x15A96A0 Offset: 0x15A96A0 VA: 0x15A96A0
		public void SetPanelPuashAction(UnityAction action)
		{
			m_panelPushAction = action;
		}

		//// RVA: 0x15AE3D4 Offset: 0x15AE3D4 VA: 0x15AE3D4
		private void OnPushButton()
		{
			if(m_button.Dark)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_005);
			}
			if(m_panelPushAction != null && !m_button.Dark)
			{
				m_panelPushAction();
			}
		}

		//// RVA: 0x15AE4B0 Offset: 0x15AE4B0 VA: 0x15AE4B0 Slot: 12
		public void ConnectEffect(GameObject eff)
		{
			m_3dEffect = eff;
			eff.gameObject.SetActive(false);
			eff.transform.SetParent(transform, false);
			m_3dEffect.transform.localPosition = new Vector3(90, -50, 0);
			eff.transform.SetAsFirstSibling();
		}

		//// RVA: 0x15A96B8 Offset: 0x15A96B8 VA: 0x15A96B8 Slot: 14
		public void ShowLoopEffect()
		{
			if (m_3dEffect == null || m_stock < 1)
				return;
			m_3dEffect.gameObject.SetActive(true);
		}

		//// RVA: 0x15AA180 Offset: 0x15AA180 VA: 0x15AA180 Slot: 15
		public void StopLoopEffect()
		{
			if (m_3dEffect == null)
				return;
			m_3dEffect.gameObject.SetActive(false);
		}

		//// RVA: 0x15AE61C Offset: 0x15AE61C VA: 0x15AE61C Slot: 13
		public GameObject DisConnectEffect(Transform parent)
		{
			GameObject g = m_3dEffect;
			m_3dEffect = null;
			g.transform.SetParent(parent, false);
			return g;
		}
	}
}
