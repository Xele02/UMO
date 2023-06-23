using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.Events;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SceneGrowthPanel : SceneGrowthPanelBase, ISceneGrowthPanel
	{
		public enum Flags
		{
			Episode = 1,
			Possible = 2,
		}
	
		[SerializeField]
		private RawImageEx m_labelImage; // 0x28
		[SerializeField]
		private RawImageEx m_episodeIcon; // 0x2C
		[SerializeField]
		private NumberBase m_number; // 0x30
		[SerializeField]
		private RawImageEx[] m_numberImages; // 0x34
		[SerializeField]
		private ActionButton m_button; // 0x38
		private UnityAction m_panelPushAction; // 0x3C
		private AbsoluteLayout m_abs; // 0x40
		private AbsoluteLayout m_labelLayout; // 0x44
		private AbsoluteLayout m_buttonAnimeLayout; // 0x48
		private AbsoluteLayout m_getAbs; // 0x4C
		private AbsoluteLayout m_episodeAnimeLayout; // 0x50
		private AbsoluteLayout m_rewardAnimeLayout; // 0x54
		private AbsoluteLayout m_epstoryLayout; // 0x58
		private AbsoluteLayout m_epstoryRibbonLayout; // 0x5C
		private int m_index; // 0x60
		private uint m_flags; // 0x64
		private TexUVListManager m_uvManager; // 0x68
		private GameObject m_3dEffect; // 0x6C
		private SceneGrowthPassButton m_passLayout; // 0x70
		private readonly Rect iconUv = new Rect(0, 0, 1, 1); // 0x74
		private static readonly string[] m_uvNameTable = new string[22]
		{
			"", "ab_icon_11li", "ab_icon_14so", "ab_icon_17vo", "ab_icon_20ch", "ab_icon_23cs",
			"ab_icon_24as", "ab_icon_25ls", "ab_icon_26su", "ab_icon_27fo", "ab_star",
			"ab_icon_30no", "", "", "", "", "", "", "ab_icon_33ep", "ab_icon_29lu", "", "ab_icon_33ep"
		}; // 0x0

		//public int Index { get; } 0x10DA9B8
		//public bool IsEpisode { get; } 0x10DA9C0
		public bool IsPossible { get { return (m_flags & 2) != 0; } set { if (value) m_flags |= 2; else m_flags &= 0xfffffffd; } } //0x10DA9CC 0x10DA9E4
		public GrowthPanelType PanelType { get { return GrowthPanelType.Normal; } } //0x10DAECC
		//public Transform transform { get; } 0x10DAED4

		// RVA: 0x10DA9F0 Offset: 0x10DA9F0 VA: 0x10DA9F0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			m_abs = layout.FindViewByExId("root_sw_abicon_set_layout_root") as AbsoluteLayout;
			m_labelLayout = layout.FindViewByExId("sw_btn_ab_swtbl_ab_icon") as AbsoluteLayout;
			m_buttonAnimeLayout = layout.FindViewByExId("root_sw_abicon_set_sw_btn_ab") as AbsoluteLayout;
			m_getAbs = layout.FindViewByExId("root_sw_abicon_set_swtbl_get_position") as AbsoluteLayout;
			m_episodeAnimeLayout = layout.FindViewByExId("sw_btn_ab_swtbl_ep_parts") as AbsoluteLayout;
			m_rewardAnimeLayout = layout.FindViewByExId("sw_ep_icon_anim_sw_ep_icon") as AbsoluteLayout;
			m_epstoryLayout = layout.FindViewByExId("sw_ep_icon_anim_sw_ep_icon") as AbsoluteLayout;
			m_epstoryRibbonLayout = layout.FindViewByExId("sw_ep_parts_anim_ab_icon_33ep_2") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x10DCBC8
				if(m_button.Dark)
				{
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_005);
				}
				if(m_panelPushAction != null && !m_button.Dark)
				{
					m_panelPushAction();
				}
			});
			ClearLoadedCallback();
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x10DAEDC Offset: 0x10DAEDC VA: 0x10DAEDC
		public void SetLabel(int type, bool isLock)
		{
			m_labelLayout.StartChildrenAnimGoStop(isLock ? "02" : "01");
			if(!isLock)
			{
				TexUVData uvData = m_uvManager.GetUVData(m_uvNameTable[(int)type]);
				if(uvData != null)
				{
					m_labelImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvData);
				}
			}
			bool b = false;
			if(type != 18)
			{
				b = type != 21;
			}
			m_episodeAnimeLayout.StartChildrenAnimGoStop(b ? "nomal" : "ep");
			if (type == 21 || type == 18)
				m_flags |= 1;
			else
				m_flags &= 0xfffffffe;
			if (type == 21)
			{
				m_epstoryLayout.StartChildrenAnimGoStop("02");
				m_epstoryRibbonLayout.StartChildrenAnimGoStop("02");
			}
			else
			{
				m_epstoryLayout.StartChildrenAnimGoStop("01");
				m_epstoryRibbonLayout.StartChildrenAnimGoStop("01");
			}
		}

		//// RVA: 0x10DB1DC Offset: 0x10DB1DC VA: 0x10DB1DC
		public void SetEpisodeIcon(int lastRewardItemId)
		{
			if(lastRewardItemId != 0)
			{
				GameManager.Instance.ItemTextureCache.Load(lastRewardItemId, (IiconTexture texture) =>
				{
					//0x10DCCA4
					texture.Set(m_episodeIcon);
				});
				m_episodeIcon.uvRect = iconUv;
			}
		}

		//// RVA: 0x10DB338 Offset: 0x10DB338 VA: 0x10DB338
		public void SetGet(bool isGet, bool isLock)
		{
			m_getAbs.StartAllAnimGoStop(isGet ? "st_in" : "st_wait");
			m_getAbs.StartAllAnimGoStop(isLock ? "03" : ((m_flags & 1) != 0 ? "ep" : "nomal"));
			m_rewardAnimeLayout.StartAnimGoStop(isGet ? "st_get_i" : "st_wait");
			m_buttonAnimeLayout.StartChildrenAnimGoStop(isLock ? "lock" : (isGet ? "st_get" : "st_wait"));
			m_button.Dark = isGet;
		}

		//// RVA: 0x10DB4E8 Offset: 0x10DB4E8 VA: 0x10DB4E8
		public void SetIndex(int index)
		{
			m_index = index;
		}

		//// RVA: 0x10DB4F0 Offset: 0x10DB4F0 VA: 0x10DB4F0
		public void SetValue(int value)
		{
			for(int i = 0; i < m_numberImages.Length; i++)
			{
				m_numberImages[i].enabled = value > 0;
			}
			m_number.SetNumber(value, 0);
		}

		//// RVA: 0x10DB5C0 Offset: 0x10DB5C0 VA: 0x10DB5C0 Slot: 8
		public void Wait()
		{
			m_abs.StartAllAnimGoStop("st_open");
		}

		//// RVA: 0x10DB63C Offset: 0x10DB63C VA: 0x10DB63C Slot: 9
		public void Expand()
		{
			m_abs.StartAllAnimGoStop("st_wait");
		}

		//// RVA: 0x10DB6B8 Offset: 0x10DB6B8 VA: 0x10DB6B8 Slot: 10
		//public void PlayUnLockAnime() { }

		//// RVA: 0x10DB86C Offset: 0x10DB86C VA: 0x10DB86C Slot: 11
		public void PlayExpandAnime()
		{
			SetGet(false, false);
			m_abs.StartAllAnimGoStop("go_open", "st_open");
		}

		//// RVA: 0x10DB908 Offset: 0x10DB908 VA: 0x10DB908
		public void SetPanelPuashAction(UnityAction action)
		{
			m_panelPushAction = action;
		}

		//// RVA: 0x10DB910 Offset: 0x10DB910 VA: 0x10DB910 Slot: 12
		public void ConnectEffect(GameObject eff)
		{
			m_3dEffect = eff;
			eff.transform.SetParent(transform, false);
			eff.transform.SetAsFirstSibling();
			m_3dEffect.transform.localPosition = new Vector3(50, -50, 0);
			m_3dEffect.gameObject.SetActive(false);
		}

		//// RVA: 0x10DBA80 Offset: 0x10DBA80 VA: 0x10DBA80 Slot: 14
		public void ShowLoopEffect()
		{
			if (m_3dEffect == null || (m_flags & 2) == 0)
				return;
			if (m_button.Dark)
				return;
			m_3dEffect.gameObject.SetActive(true);
		}

		//// RVA: 0x10DBB8C Offset: 0x10DBB8C VA: 0x10DBB8C Slot: 15
		public void StopLoopEffect()
		{
			if (m_3dEffect == null)
				return;
			m_3dEffect.gameObject.SetActive(false);
		}

		//// RVA: 0x10DBC64 Offset: 0x10DBC64 VA: 0x10DBC64 Slot: 13
		public GameObject DisConnectEffect(Transform parent)
		{
			m_3dEffect.transform.SetParent(parent, false);
			GameObject g = m_3dEffect;
			m_3dEffect = null;
			return g;
		}

		//// RVA: 0x10DBCCC Offset: 0x10DBCCC VA: 0x10DBCCC
		public void ConnectPassLayout(SceneGrowthPassButton layout)
		{
			m_passLayout = layout;
			(layout.transform as RectTransform).SetParent(transform, false);
			(layout.transform as RectTransform).SetAsLastSibling();
			(layout.transform as RectTransform).anchoredPosition = new Vector2(m_labelImage.rectTransform.sizeDelta.x * 0.5f + 70, m_labelImage.rectTransform.sizeDelta.y * 0.5f + 16);
			m_passLayout.gameObject.SetActive(true);
			m_passLayout.Show();
		}

		//// RVA: 0x10DBFC4 Offset: 0x10DBFC4 VA: 0x10DBFC4
		public void DisConnectPassLayout(Transform parent)
		{
			if (m_passLayout == null)
				return;
			m_passLayout.Hide();
			m_passLayout.gameObject.SetActive(false);
			m_passLayout.transform.SetParent(parent, false);
			m_passLayout = null;
		}
	}
}
