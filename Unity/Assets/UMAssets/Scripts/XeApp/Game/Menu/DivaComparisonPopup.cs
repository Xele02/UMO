using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class DivaComparisonPopup : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		[SerializeField]
		private DivaComparisonParam[] m_params; // 0xC
		[SerializeField]
		private InfoButton m_infoButton; // 0x10
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x14
		private DivaComparisonPopupSetting m_popupSetting; // 0x18

		public Transform Parent { get; private set; } // 0x1C

		// RVA: 0x17D6314 Offset: 0x17D6314 VA: 0x17D6314 Slot: 24
		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return true;
		}

		// RVA: 0x17D631C Offset: 0x17D631C VA: 0x17D631C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			DivaComparisonPopupSetting ds = setting as DivaComparisonPopupSetting;
			Parent = setting.m_parent;
			m_infoButton.OnClickButton = (int page) =>
			{
				//0x17D6A80
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				for(int i = 0; i < m_params.Length; i++)
				{
					m_params[i].ChangeDisplay(page - 1);
				}
			};
			m_params[0].UpdateContent(ds.BeforeDiva, ds.BeforeDiva, ds.PlayerData, ds.MusicData, ds.IsCenterDiva);
			m_params[1].UpdateContent(ds.AfterDiva, ds.BeforeDiva, ds.PlayerData, ds.MusicData, ds.IsCenterDiva);
			for(int i = 0; i < m_params.Length; i++)
			{
				m_params[i].InitializeDecoration();
				m_params[i].UpdateDecoration(DisplayType.Level);
			}
			m_infoButton.SetPage(m_params[0].GetDisplayIndex(), m_params[0].GetDisplayMax());
			gameObject.SetActive(true);
		}

		// RVA: 0x17D68B4 Offset: 0x17D68B4 VA: 0x17D68B4 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x17D68EC Offset: 0x17D68EC VA: 0x17D68EC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			for(int i = 0; i < m_params.Length; i++)
			{
				m_params[i].ReleaseDecoration();
			}
		}

		// RVA: 0x17D69B0 Offset: 0x17D69B0 VA: 0x17D69B0 Slot: 21
		public bool IsReady()
		{
			for(int i = 0; i < m_params.Length; i++)
			{
				if (m_params[i].IsLoading())
					return false;
			}
			return m_runtime.IsReady;
		}

		// RVA: 0x17D6A6C Offset: 0x17D6A6C VA: 0x17D6A6C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x17D6A70 Offset: 0x17D6A70 VA: 0x17D6A70 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}
	}
}
