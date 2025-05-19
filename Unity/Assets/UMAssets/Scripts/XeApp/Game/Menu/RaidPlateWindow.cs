using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections;
using XeApp.Core;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class RaidPlateWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_damegeText; // 0x14
		[SerializeField]
		private Text m_text01; // 0x18
		[SerializeField]
		private Text m_text02; // 0x1C
		[SerializeField]
		private Text m_text03; // 0x20
		[SerializeField]
		private Text m_text04; // 0x24
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x28
		public AbsoluteLayout m_animText; // 0x2C
		private bool m_IsInialize; // 0x30

		public SwapScrollList Scroll { get { return m_scrollList; } } //0x1BD6DB4

		// RVA: 0x1BD6DBC Offset: 0x1BD6DBC VA: 0x1BD6DBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_animText = layout.FindViewByExId("sw_sel_music_raid_pop_plate_swtbl_bonus_text_01") as AbsoluteLayout;
			return true;
		}

		// RVA: 0x1BD6EA0 Offset: 0x1BD6EA0 VA: 0x1BD6EA0
		public void Initialize()
		{
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_damegeText.text = string.Format(bk.GetMessageByLabel("pop_raid_cannon_plate_text01"), ev.GGDBEANLCPC.HALIDDHLNEG_MCannonDamage);
			m_text01.text = "";
			m_text02.text = "";
			if(ev.GGDBEANLCPC.OPIBAPEGCLA_MCannonPlate.Count < 1)
			{
				m_text03.text = bk.GetMessageByLabel("pop_raid_cannon_plate_text03");
				m_text04.text = bk.GetMessageByLabel("pop_raid_cannon_plate_text04");
			}
			else
			{
				m_text03.text = string.Format(bk.GetMessageByLabel("pop_raid_cannon_plate_text02"), ev.GGDBEANLCPC.OPIBAPEGCLA_MCannonPlate.Count);
				m_text04.text = "";
			}
			m_animText.StartChildrenAnimGoStop("03");
			if(ev.GGDBEANLCPC.ACBHJKCJLON_SceneAttr == GameAttribute.Type.None)
			{
				if(ev.GGDBEANLCPC.KOGEKHMBHOI_SceneSerie == SeriesAttr.Type.None)
				{
					m_animText.StartChildrenAnimGoStop("03");
				}
				else
				{
					SetText_BonusSeries(ev.GGDBEANLCPC, m_text01, bk);
					m_animText.StartChildrenAnimGoStop("02");
				}
			}
			else
			{
				SetText_BonusAttribute(ev.GGDBEANLCPC, m_text01, bk);
				if(ev.GGDBEANLCPC.KOGEKHMBHOI_SceneSerie == SeriesAttr.Type.None)
				{
					m_animText.StartChildrenAnimGoStop("02");
				}
				else
				{
					SetText_BonusSeries(ev.GGDBEANLCPC, m_text02, bk);
					m_animText.StartChildrenAnimGoStop("01");
				}
			}
			UpdateContent(ev.GGDBEANLCPC.OPIBAPEGCLA_MCannonPlate);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x714E2C Offset: 0x714E2C VA: 0x714E2C
		// RVA: 0x1BD79B0 Offset: 0x1BD79B0 VA: 0x1BD79B0
		public IEnumerator LoadScrollObjectCoroutine()
		{
			string assetBundleName; // 0x18
			AssetBundleLoadLayoutOperationBase operation; // 0x1C
			RaidPlateWindowScrollItem scrObject; // 0x20
			int i; // 0x24

			//0x1BD8550
			int poolSize = m_scrollList.ScrollObjectCount;
			assetBundleName = "ly/200.xab";
			operation = AssetBundleManager.LoadLayoutAsync(assetBundleName, "root_sel_music_raid_pop_plate_icon_layout_root");
			yield return operation;
			GameObject prefab = operation.GetAsset<GameObject>();
			yield return Co.R(operation.CreateLayoutCoroutine(prefab.GetComponent<LayoutUGUIRuntime>(), GameManager.Instance.GetSystemFont(), (Layout loadLayout, TexUVListManager loadUvMan) =>
			{
				//0x1BD7C88
				for(i = 0; i < poolSize; i++)
				{
					GameObject g = Instantiate(prefab);
					LayoutUGUIRuntime l = g.GetComponent<LayoutUGUIRuntime>();
					l.IsLayoutAutoLoad = false;
					l.Layout = loadLayout.DeepClone();
					l.UvMan = loadUvMan;
					l.LoadLayout();
					Text[] txts = g.GetComponentsInChildren<Text>(true);
					for(int j = 0; j < txts.Length; j++)
					{
						GameManager.Instance.GetSystemFont().Apply(txts[j]);
					}
					m_scrollList.AddScrollObject(g.GetComponent<RaidPlateWindowScrollItem>());
				}
			}));
			yield return null;
			m_scrollList.Apply();
			AssetBundleManager.UnloadAssetBundle(assetBundleName, false);
			for(i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				while(!m_scrollList.ScrollObjects[i].IsLoaded())
					yield return null;
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			scrObject = m_scrollList.ScrollObjects[0] as RaidPlateWindowScrollItem;
			while(!scrObject.IsLoaded())
				yield return null;
			m_scrollList.SetContentEscapeMode(true);
		}

		// // RVA: 0x1BD775C Offset: 0x1BD775C VA: 0x1BD775C
		public void UpdateContent(List<GCIJNCFDNON_SceneInfo> sceneList)
		{
			m_scrollList.SetItemCount(sceneList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x1BD7FC0
				RaidPlateWindowScrollItem r = content as RaidPlateWindowScrollItem;
				float f = content.transform.localPosition.y;
				if(index < 0)
				{
					content.RectTransform.localPosition = new Vector3(-320, f, 0);
				}
				else
				{
					content.RectTransform.localPosition = new Vector3(m_scrollList.ContentSize.x + index % m_scrollList.ColumnCount + m_scrollList.LeftTopPosition.x, 
						m_scrollList.ContentSize.y, 0);
					r.UpdateContent(sceneList[index]);
				}
			});
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x1BD7A64 Offset: 0x1BD7A64 VA: 0x1BD7A64
		// public void UpdateRegion() { }

		// // RVA: 0x1BD7A90 Offset: 0x1BD7A90 VA: 0x1BD7A90
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			return;
		}

		// // RVA: 0x1BD7A94 Offset: 0x1BD7A94 VA: 0x1BD7A94
		private void OnDestroy()
		{
			Release();
		}

		// // RVA: 0x1BD7A98 Offset: 0x1BD7A98 VA: 0x1BD7A98
		public void Release()
		{
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				(m_scrollList.ScrollObjects[i] as RaidPlateWindowScrollItem).Release();
			}
		}

		// // RVA: 0x1BD747C Offset: 0x1BD747C VA: 0x1BD747C
		private void SetText_BonusAttribute(JKIJLMMLNPL a_info, Text a_text, MessageBank a_msg_bank)
		{
			a_text.text = string.Format(a_msg_bank.GetMessageByLabel("pop_raid_cannon_plate_bonus_format"), a_msg_bank.GetMessageByLabel(string.Format("missionevent_bonus_music_attribute{0:000}", (int)a_info.ACBHJKCJLON_SceneAttr)), a_info.GCMIDNBBMLA_SceneAttrBonus);
		}

		// // RVA: 0x1BD75EC Offset: 0x1BD75EC VA: 0x1BD75EC
		private void SetText_BonusSeries(JKIJLMMLNPL a_info, Text a_text, MessageBank a_msg_bank)
		{
			a_text.text = string.Format(a_msg_bank.GetMessageByLabel("pop_raid_cannon_plate_bonus_format"), a_msg_bank.GetMessageByLabel(string.Format("missionevent_bonus_series_attribute{0:000}", (int)a_info.KOGEKHMBHOI_SceneSerie)), a_info.IDDAGCGIAPA_SceneSerieBonus);
		}
	}
}
