using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class ValkyrieSelectController : MonoBehaviour
	{
		private const int MAX_DISPLAY_VALKYRIE = 3;
		public bool IsAssetLoad; // 0xC
		private LayoutSeriesTab m_SeriesTab; // 0x10
		private LayoutValkyrieSelect m_layoutValSelect; // 0x14
		private LayoutOfferValkyrieSelectModification m_layoutSortie; // 0x18
		private List<HEFCLPGPMLK.ANKPCIEKPAH>[] m_SeriesValkyrieList = new List<HEFCLPGPMLK.ANKPCIEKPAH>[5]; // 0x1C
		private HEFCLPGPMLK m_view; // 0x20
		private int m_SelectSeries; // 0x24
		private int m_Select; // 0x28
		private int offerSeries; // 0x2C
		private Action m_Updater; // 0x30
		private SwaipTouch m_SwaipTouch; // 0x38

		public bool IsLeader { private get; set; } // 0x34

		// RVA: 0x1655E4C Offset: 0x1655E4C VA: 0x1655E4C
		private void Start()
		{
			m_SwaipTouch = GetComponentInChildren<SwaipTouch>();
		}

		// RVA: 0x1655EB4 Offset: 0x1655EB4 VA: 0x1655EB4
		private void Update()
		{
			return;
		}

		//// RVA: 0x1655EB8 Offset: 0x1655EB8 VA: 0x1655EB8
		//public void chengeAnimStart() { }

		//// RVA: 0x1655F40 Offset: 0x1655F40 VA: 0x1655F40
		private void UpdateChangeAnim_Start()
		{
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			m_layoutValSelect.FadeOutValkyrieImage(LayoutValkyrieSelect.Direction.LEFT);
			m_layoutValSelect.FadeOutValkyrieImage(LayoutValkyrieSelect.Direction.RIGHT);
			ApplySelectValkyrie();
			m_Updater = UpdateChangeAnim_Wait;
		}

		//// RVA: 0x16566B8 Offset: 0x16566B8 VA: 0x16566B8
		private void UpdateChangeAnim_Wait()
		{
			SortieIconUpdate();
			sortieDisableDoneBtn();
			if (m_layoutValSelect.ValkyrieImageIsPlaying())
				return;
			m_layoutValSelect.ApplySelectValkyrieImage(m_SeriesValkyrieList[m_SelectSeries], m_Select);
			m_layoutValSelect.FadeInValkyrieImage(LayoutValkyrieSelect.Direction.LEFT);
			m_layoutValSelect.FadeInValkyrieImage(LayoutValkyrieSelect.Direction.RIGHT);
			m_Updater = UpdateChangeAnim_End;
		}

		//// RVA: 0x1656CC0 Offset: 0x1656CC0 VA: 0x1656CC0
		private void UpdateChangeAnim_End()
		{
			if (m_layoutValSelect.ValkyrieImageIsPlaying())
				return;
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
			m_SwaipTouch.ResetValue();
			m_SwaipTouch.ResetInputState();
			m_Updater = UpdateIdle;
		}

		//// RVA: 0x1656E2C Offset: 0x1656E2C VA: 0x1656E2C
		private void UpdateIdle()
		{
			if(m_SwaipTouch != null)
			{
				if (m_SwaipTouch.IsStop())
					return;
				if (m_SwaipTouch.IsSwaip(SwaipTouch.Direction.RIGHT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				if (m_SwaipTouch.IsSwaip(SwaipTouch.Direction.LEFT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
				if (m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.RIGHT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				if (m_SwaipTouch.IsFlickNoSwaip(SwaipTouch.Direction.LEFT))
					ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
			}
		}

		// RVA: 0x1656FCC Offset: 0x1656FCC VA: 0x1656FCC
		public void ChangeSelectValkyrie(LayoutValkyrieSelect.Direction dir = LayoutValkyrieSelect.Direction.NONE)
		{
			if(m_SeriesValkyrieList[m_SelectSeries].Count < 2)
			{
				m_SwaipTouch.enabled = m_layoutValSelect.SubValkyrieEnable(m_SeriesValkyrieList[m_SelectSeries].Count);
				ApplySelectValkyrie();
			}
			if(dir == LayoutValkyrieSelect.Direction.RIGHT)
			{
				m_Select++;
				if (m_Select >= m_SeriesValkyrieList[m_SelectSeries].Count)
					m_Select -= m_SeriesValkyrieList[m_SelectSeries].Count;
			}
			else if(dir == LayoutValkyrieSelect.Direction.LEFT)
			{
				m_Select--;
				if (m_Select < 0)
					m_Select += m_SeriesValkyrieList[m_SelectSeries].Count;
			}
			m_Updater = UpdateChangeAnim_Start;
		}

		//// RVA: 0x1657208 Offset: 0x1657208 VA: 0x1657208
		private void ApplyAbility()
		{
			ALEKLHIANJN d = new ALEKLHIANJN(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id, m_SeriesValkyrieList[m_SelectSeries][m_Select].CNLIAMIIJID_Level);
			m_layoutValSelect.HasAbility = m_SeriesValkyrieList[m_SelectSeries][m_Select].CNLIAMIIJID_Level > 0;
			m_layoutValSelect.SetAbility(d.OPFGFINHFCE_SkillName, d.CHHADJECKNL_GetLevel(), d.DMBDNIEEMCB_GetDesc(false));
			m_layoutValSelect.IsValInfoChange(m_layoutValSelect.HasAbility);
		}

		//// RVA: 0x1656094 Offset: 0x1656094 VA: 0x1656094
		private void ApplySelectValkyrie()
		{
			NHDJHOPLMDE n = new NHDJHOPLMDE(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id, 0);
			m_layoutValSelect.SetAtkArrowEnable(false);
			m_layoutValSelect.SetHitArrowEnable(false);
			string strAtk = n.KINFGHHNFCF_Atk.ToString();
			string strHit = n.NONBCCLGBAO_Hit.ToString();
			if (n.LAKLFHGMCLI(EPIFHEDDJAE.NGEDJNHECKN.FJFMLFPJKNB_2, IsLeader ? EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.FHBJEIEPABF_12 : EPIFHEDDJAE.JFEIHHBGFPF_AbilityCondition.PPNNBADDNKB_11))
			{
				if(n.KINFGHHNFCF_Atk > 0)
				{
					strAtk = "<color=#008200>" + (n.KINFGHHNFCF_Atk + m_SeriesValkyrieList[m_SelectSeries][m_Select].KINFGHHNFCF_Atk).ToString() + "</color>";
					m_layoutValSelect.SetAtkArrowEnable(true);
				}
				if(n.NONBCCLGBAO_Hit > 0)
				{
					strHit = "<color=#008200>" + (n.NONBCCLGBAO_Hit + m_SeriesValkyrieList[m_SelectSeries][m_Select].NONBCCLGBAO_Hit).ToString() + "</color>";
					m_layoutValSelect.SetHitArrowEnable(true);
				}
			}
			m_layoutValSelect.SetName(m_SeriesValkyrieList[m_SelectSeries][m_Select].PNIEAEHKGMJ_ValkName, m_SeriesValkyrieList[m_SelectSeries][m_Select].PMKFOEIFBLB_PilotName, strAtk, strHit);
			ApplyAbility();
			m_layoutValSelect.SetPilotTexture(m_SeriesValkyrieList[m_SelectSeries][m_Select].PFGJJLGLPAC_PilotId);
			m_SwaipTouch.enabled = m_layoutValSelect.SubValkyrieEnable(m_SeriesValkyrieList[m_SelectSeries].Count);
			m_layoutValSelect.SetMainValkyrieIcon(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id, 0, null);
		}

		// RVA: 0x16574A4 Offset: 0x16574A4 VA: 0x16574A4
		public void ValkyrieSelectUpdate()
		{
			if (m_Updater != null)
				m_Updater();
		}

		// RVA: 0x16574B8 Offset: 0x16574B8 VA: 0x16574B8
		public void Initialize()
		{
			m_SeriesTab.SetSeriesIcon();
			m_SeriesTab.SetSeriesButtonCallBack((SeriesAttr.Type type) =>
			{
				//0x16585C0
				if(InputManager.Instance.touchCount < 2)
				{
					if(!MenuScene.Instance.DirtyChangeScene)
					{
						if(!m_SwaipTouch.IsMoveFlickDistance())
						{
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							m_SeriesTab.ChangeSelectSeries((int)type, ref m_SelectSeries, ref m_Select);
							m_SeriesTab.ApplySelectSeriesButton((int)type - 1);
							m_Updater = UpdateChangeAnim_Start;
						}
					}
				}
			});
			m_layoutValSelect.SubValkyrieEnable(0);
			m_layoutValSelect.SetDefaultText(MessageManager.Instance.GetMessage("menu", "valkyrie_tuneup_skill_not"));
			m_layoutValSelect.SetIconState("02");
			m_layoutValSelect.IsValInfoChange(true);
		}

		// RVA: 0x16576A0 Offset: 0x16576A0 VA: 0x16576A0
		public void renewalSeriesTab()
		{
			m_SeriesTab.ChangeSelectSeries(m_SelectSeries + 1, ref m_SelectSeries, ref m_Select);
			for(int i = 0; i < 5; i++)
			{
				m_SeriesTab.ButtonDisable(i, m_SeriesValkyrieList[i].Count == 0);
			}
			m_SeriesTab.ApplySelectSeriesButton(m_SelectSeries);
			m_layoutValSelect.ApplySelectValkyrieImage(m_SeriesValkyrieList[m_SelectSeries], m_Select);
			m_layoutValSelect.SetDetachBtnHidden(false);

		}

		// RVA: 0x1657884 Offset: 0x1657884 VA: 0x1657884
		private void OnClickSeriesButton(SeriesAttr.Type type)
		{
			if(InputManager.Instance.touchCount < 2)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					if(!m_SwaipTouch.IsMoveFlickDistance())
					{
						SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
						m_SeriesTab.ChangeSelectSeries((int)type, ref m_SelectSeries, ref m_Select);
						m_SeriesTab.ApplySelectSeriesButton((int)type - 1);
						m_Updater = UpdateChangeAnim_Start;
					}
				}
			}
		}

		// RVA: 0x1657AA4 Offset: 0x1657AA4 VA: 0x1657AA4
		public void SetLayoutButton(Action selection, Action Detouch)
		{
			m_layoutValSelect.SetButtonCallBack(() =>
			{
				//0x1658854
				ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.LEFT);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			}, () =>
			{
				//0x16588CC
				ChangeSelectValkyrie(LayoutValkyrieSelect.Direction.RIGHT);
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			}, () =>
			{
				//0x1658944
				OnClickSelectButton(selection);
			}, Detouch);
		}

		//// RVA: 0x1657C18 Offset: 0x1657C18 VA: 0x1657C18
		private void OnClickSelectButton(Action act)
		{
			if(!m_SwaipTouch.IsMoveFlickDistance())
			{
				if(InputManager.Instance.GetInScreenTouchCount() < 2)
				{
					if(!MenuScene.Instance.DirtyChangeScene)
					{
						if (m_view.JHBMCGABHMD(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id))
							return;
						act();
					}
				}
			}
		}

		//// RVA: 0x1656828 Offset: 0x1656828 VA: 0x1656828
		private void SortieIconUpdate()
		{
			m_layoutSortie.AllHide();
			bool b = KDHGBOOECKC.HHCJCDFCLOB.CKBDHFNLLJE((BOPFPIHGJMD.LGEIPIHHNPH)offerSeries, (SeriesAttr.Type)m_SelectSeries + 1);
			if(m_SeriesValkyrieList[m_SelectSeries].Count < 2)
			{
				m_layoutSortie.IconSetting(0, m_view.JHBMCGABHMD(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id), b, m_SeriesValkyrieList[m_SelectSeries][m_Select].LABKKJAGDFN_FormationId > 0, m_SeriesValkyrieList[m_SelectSeries][m_Select].LABKKJAGDFN_FormationId);
			}
			else
			{
				for(int i = 0; i < 3; i++)
				{
					HEFCLPGPMLK.ANKPCIEKPAH valk = m_SeriesValkyrieList[m_SelectSeries][GetSelectIndex((LayoutValkyrieSelect.Direction) i - 1, m_SeriesValkyrieList[m_SelectSeries])];
					m_layoutSortie.IconSetting(i, m_view.JHBMCGABHMD(valk.LLOBHDMHJIG_Id), b, valk.LABKKJAGDFN_FormationId > 0, valk.LABKKJAGDFN_FormationId);
				}
			}
		}

		//// RVA: 0x1657E18 Offset: 0x1657E18 VA: 0x1657E18
		private int GetSelectIndex(LayoutValkyrieSelect.Direction dir, List<HEFCLPGPMLK.ANKPCIEKPAH> list)
		{
			int res = m_Select;
			if(dir == LayoutValkyrieSelect.Direction.RIGHT)
			{
				res++;
				if (list.Count <= res)
					res -= list.Count;
			}
			else if(dir == LayoutValkyrieSelect.Direction.LEFT)
			{
				res--;
				if (res < 0)
					res += list.Count;
			}
			return res;
		}

		//// RVA: 0x1656B80 Offset: 0x1656B80 VA: 0x1656B80
		public void sortieDisableDoneBtn()
		{
			m_layoutValSelect.SetSelectBtnCoverLayoutDisable(true);
			m_layoutValSelect.SetSelectBtnDisable(m_view.JHBMCGABHMD(m_SeriesValkyrieList[m_SelectSeries][m_Select].LLOBHDMHJIG_Id));
		}

		// RVA: 0x1657F28 Offset: 0x1657F28 VA: 0x1657F28
		public void DisableDetachBtn(bool IsDisable)
		{
			m_layoutValSelect.SetDetachBtnDisable(IsDisable);
		}

		// RVA: 0x1657F5C Offset: 0x1657F5C VA: 0x1657F5C
		public void LayoutDestroy()
		{
			DestroyImmediate(m_SeriesTab.gameObject);
			DestroyImmediate(m_layoutValSelect.gameObject);
			DestroyImmediate(m_layoutSortie.gameObject);
			m_SeriesTab = null;
			m_layoutValSelect = null;
			m_layoutSortie = null;
			IsAssetLoad = false;
		}

		// RVA: 0x1658068 Offset: 0x1658068 VA: 0x1658068
		public void StartAssetLoad()
		{
			this.StartCoroutineWatched(Co_LayoutAssetLoad());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9234 Offset: 0x6F9234 VA: 0x6F9234
		//// RVA: 0x165808C Offset: 0x165808C VA: 0x165808C
		private IEnumerator Co_LayoutAssetLoad()
		{
			string bundleName; // 0x14
			Font systemFont; // 0x18

			//0x1658978
			if (IsAssetLoad)
				yield break;
			bundleName = "ly/045.xab";
			systemFont = GameManager.Instance.GetSystemFont();
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName);
			yield return Co.R(Co_LoadAssetsLayoutValkyrieSelect(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutSeriesButton(bundleName, systemFont));
			yield return Co.R(Co_LoadAssetsLayoutSortieIcon(bundleName, systemFont));
			AssetBundleManager.UnloadAssetBundle(bundleName, false);
			while (m_layoutValSelect == null)
				yield return null;
			while (m_SeriesTab == null)
				yield return null;
			while (m_layoutSortie == null)
				yield return null;
			IsAssetLoad = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F92AC Offset: 0x6F92AC VA: 0x6F92AC
		//// RVA: 0x1658138 Offset: 0x1658138 VA: 0x1658138
		private IEnumerator Co_LoadAssetsLayoutValkyrieSelect(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1659434
			if(m_layoutValSelect == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_valkyrie01_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x16585C4
					instance.transform.SetParent(transform, false);
					m_layoutValSelect = instance.GetComponent<LayoutValkyrieSelect>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutValSelect.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F9324 Offset: 0x6F9324 VA: 0x6F9324
		//// RVA: 0x1658218 Offset: 0x1658218 VA: 0x1658218
		private IEnumerator Co_LoadAssetsLayoutSeriesButton(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1658DEC
			if(m_SeriesTab == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_val_btn_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1658694
					instance.transform.SetParent(transform, false);
					m_SeriesTab = instance.GetComponent<LayoutSeriesTab>();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_SeriesTab.transform.SetParent(transform, false);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6F939C Offset: 0x6F939C VA: 0x6F939C
		//// RVA: 0x16582F8 Offset: 0x16582F8 VA: 0x16582F8
		private IEnumerator Co_LoadAssetsLayoutSortieIcon(string bundleName, Font font)
		{
			AssetBundleLoadLayoutOperationBase operation;

			//0x1659100
			if(m_layoutSortie == null)
			{
				operation = AssetBundleManager.LoadLayoutAsync(bundleName, "root_sel_vfo_valkyrie_layout_root");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(font, (GameObject instance) =>
				{
					//0x1658764
					instance.transform.SetParent(transform, false);
					m_layoutSortie = instance.GetComponent<LayoutOfferValkyrieSelectModification>();
					m_layoutSortie.initialize();
				}));
				AssetBundleManager.UnloadAssetBundle(bundleName, false);
				operation = null;
			}
			else
			{
				m_layoutSortie.transform.SetParent(transform, false);
				m_layoutSortie.initialize();
			}
		}

		// RVA: 0x16583D8 Offset: 0x16583D8 VA: 0x16583D8
		public void EnterLayout()
		{
			m_SeriesTab.Enter();
			m_layoutValSelect.Enter();
		}

		// RVA: 0x1658428 Offset: 0x1658428 VA: 0x1658428
		public void LeaveLayout()
		{
			m_SeriesTab.Leave();
			m_layoutValSelect.Leave();
			m_layoutValSelect.MainValkyrieIconHide();
			m_layoutSortie.AllHide();
		}

		// RVA: 0x16584B8 Offset: 0x16584B8 VA: 0x16584B8
		public bool IsPlayingLayout()
		{
			return m_SeriesTab.IsPlaying() || m_layoutValSelect.IsPlaying();
		}

		// RVA: 0x1658514 Offset: 0x1658514 VA: 0x1658514
		public void SetSelectSeries(int series, int select)
		{
			m_SelectSeries = series;
			m_Select = select;
		}

		//// RVA: 0x1658520 Offset: 0x1658520 VA: 0x1658520
		public void GetSelectSeries(out int _series, out int _select)
		{
			_series = m_SelectSeries;
			_select = m_Select;
		}

		// RVA: 0x1658534 Offset: 0x1658534 VA: 0x1658534
		public void SetValKyrieList(List<HEFCLPGPMLK.ANKPCIEKPAH>[] list)
		{
			m_SeriesValkyrieList = list;
		}

		// RVA: 0x165853C Offset: 0x165853C VA: 0x165853C
		public void SetView(HEFCLPGPMLK view)
		{
			m_view = view;
		}

		// RVA: 0x1658544 Offset: 0x1658544 VA: 0x1658544
		public void SetOfferSeries(int _series)
		{
			offerSeries = _series;
		}
	}
}
