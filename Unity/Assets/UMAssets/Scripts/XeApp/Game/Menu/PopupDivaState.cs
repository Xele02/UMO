using UnityEngine.EventSystems;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using mcrs;

namespace XeApp.Game.Menu
{
	public class PopupDivaState : UIBehaviour, IPopupContent
	{
		[SerializeField]
		private DivaStatusParam m_param; // 0xC
		[SerializeField]
		private LayoutUGUIRuntime m_runtime; // 0x10
		private AbsoluteLayout m_statusChangeAnime; // 0x14
		private DivaStatePopupSetting m_setting; // 0x18

		public Transform Parent { get; private set; } // 0x1C

		// RVA: 0xF82E5C Offset: 0xF82E5C VA: 0xF82E5C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as DivaStatePopupSetting;
			m_param.InitializeDecoration();
			m_param.OnSceneSelectEvent.RemoveAllListeners();
			m_param.OnShowStatusEvent.RemoveAllListeners();
			m_param.OnSceneSelectEvent.AddListener((int sceneSlotIndex) =>
			{
				//0xF83470
				if(m_setting.IsFriend)
					return;
				if(!m_setting.IsChangeScene)
					return;
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				control.Close(() =>
				{
					//0xF83B08
					TeamSelectSceneListArgs arg = new TeamSelectSceneListArgs();
					arg.divaSlotIndex = m_setting.DivaSlotIndex;
					arg.divaData = m_setting.Diva;
					arg.defaultSelectScene = sceneSlotIndex;
					arg.isGoDiva = m_setting.IsGoDiva;
					arg.musicBaseData = m_setting.MusicData;
					MenuScene.Instance.Call(TransitionList.Type.SCENE_SELECT, arg, true);
				}, null);
			});
			m_param.OnShowStatusEvent.AddListener((int sceneSlotIndex) =>
			{
				//0xF8363C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if(m_setting.IsFriend)
				{
					GCIJNCFDNON_SceneInfo scene;
					if(sceneSlotIndex == 0)
					{
						scene = m_setting.FriendData.KHGKPKDBMOH_GetAssistScene();
					}
					else
					{
						scene = m_setting.FriendData.HDJOHAJPGBA_SubScene[sceneSlotIndex - 1];
					}
					MenuScene.Instance.ShowSceneStatusPopupWindow(scene, m_setting.PlayerData, false, MenuScene.Instance.GetCurrentScene().name, null, m_setting.IsFriend, false, SceneStatusParam.PageSave.Player, false);
				}
				else
				{
					GCIJNCFDNON_SceneInfo scene = DivaDataUtility.GetSceneData(m_setting.Diva, m_setting.PlayerData.OPIBAPEGCLA_Scenes, sceneSlotIndex);
					if(scene == null)
						return;
					MenuScene.Instance.ShowSceneStatusPopupWindow(scene, m_setting.PlayerData, false, MenuScene.Instance.GetCurrentScene().name, UpdateContent, m_setting.IsFriend, false, SceneStatusParam.PageSave.Player, false);
				}
			});
			if(m_setting.FriendData == null)
			{
				UpdateContent();
			}
			else
			{
				m_param.UpdateContent(m_setting.FriendData, m_setting.MusicData);
			}
			Parent = m_setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// // RVA: 0xF832C0 Offset: 0xF832C0 VA: 0xF832C0
		private void UpdateContent()
		{
			m_param.UpdateContent(m_setting.Diva, m_setting.PlayerData, m_setting.DivaSlotIndex, m_setting.MusicData);
		}

		// RVA: 0xF83398 Offset: 0xF83398 VA: 0xF83398 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF833A0 Offset: 0xF833A0 VA: 0xF833A0 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF833D8 Offset: 0xF833D8 VA: 0xF833D8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_param.Release();
		}

		// RVA: 0xF83434 Offset: 0xF83434 VA: 0xF83434 Slot: 21
		public bool IsReady()
		{
			return !m_param.IsLoading();
		}

		// RVA: 0xF83464 Offset: 0xF83464 VA: 0xF83464 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
