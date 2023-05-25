using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUnitSaveConfirmContent : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private UnitSaveConfirmPanel m_confirmPanel; // 0xC

		public Transform Parent { get; private set; } // 0x10

		// RVA: 0x11563E4 Offset: 0x11563E4 VA: 0x11563E4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUnitSaveConfirmContentSetting s = setting as PopupUnitSaveConfirmContentSetting;
			Parent = setting.m_parent;
			GetComponent<RectTransform>().anchoredPosition = new Vector2(-475, 232.5f);
			m_confirmPanel.InitializeDecroration();
			if(s.ConfirmType == ConfirmType.Save)
			{
				SetSaveConfirm(s.PlayerData, s.TargetUnitId, s.MusicData, s.EnemyData, s.FriendData, s.IsGoDiva);
			}
			else
			{
				SetLoadConfirm(s.PlayerData, s.TargetUnitId, s.MusicData, s.EnemyData, s.FriendData, s.IsGoDiva);
			}
		}

		// RVA: 0x1156768 Offset: 0x1156768 VA: 0x1156768 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1156770 Offset: 0x1156770 VA: 0x1156770 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x11567A8 Offset: 0x11567A8 VA: 0x11567A8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_confirmPanel.ReleaseDecoration();
		}

		// RVA: 0x1156804 Offset: 0x1156804 VA: 0x1156804 Slot: 21
		public bool IsReady()
		{
			return !GameManager.Instance.DivaIconCache.IsLoading() && !GameManager.Instance.SceneIconCache.IsLoading();
		}

		// RVA: 0x1156914 Offset: 0x1156914 VA: 0x1156914 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// RVA: 0x1156698 Offset: 0x1156698 VA: 0x1156698
		private void SetSaveConfirm(DFKGGBMFFGB_PlayerInfo playerData, int targetUnitId, EEDKAACNBBG_MusicData musicData, EJKBKMBJMGL_EnemyData enemyData, EAJCBFGKKFA_FriendInfo friendData, bool isGoDiva)
		{
			m_confirmPanel.Set(playerData, targetUnitId, UnitSaveConfirmPanel.Mode.Save, musicData, enemyData, friendData, isGoDiva);
		}

		//// RVA: 0x1156700 Offset: 0x1156700 VA: 0x1156700
		private void SetLoadConfirm(DFKGGBMFFGB_PlayerInfo playerData, int targetUnitId, EEDKAACNBBG_MusicData musicData, EJKBKMBJMGL_EnemyData enemyData, EAJCBFGKKFA_FriendInfo friendData, bool isGoDiva)
		{
			m_confirmPanel.Set(playerData, targetUnitId, UnitSaveConfirmPanel.Mode.Load, musicData, enemyData, friendData, isGoDiva);
		}
	}
}
