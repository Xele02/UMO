using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using System.Diagnostics;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_swapScrollList; // 0x14
		[SerializeField]
		private RawImageEx m_logImage; // 0x18
		[SerializeField]
		private Text m_message; // 0x1C
		private List<CCAAJNJGNDO.GALFFONBIJG> m_storyList = new List<CCAAJNJGNDO.GALFFONBIJG>(); // 0x20
		private AbsoluteLayout m_titleLayout; // 0x24
		private AbsoluteLayout m_storyIconLayout; // 0x28

		// RVA: 0xB92AE4 Offset: 0xB92AE4 VA: 0xB92AE4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_titleLayout = layout.FindViewByExId("sw_sel_event_story_ul_sw_ul_logo_anim") as AbsoluteLayout;
			m_storyIconLayout = layout.FindViewByExId("sw_sel_event_story_ul_sw_icon_story_onoff_anim") as AbsoluteLayout;
			m_swapScrollList.OnUpdateItem.AddListener(OnUpdateList);
			return true;
		}

		// // RVA: 0xB92CBC Offset: 0xB92CBC VA: 0xB92CBC
		public void SetViewData(CCAAJNJGNDO data, int unlockStoryCount, bool isShowStoryIcon)
		{
			int total = 0;
			for(int i = 0; i < data.FFPCLEONGHE.Count; i++)
			{
				total += data.FFPCLEONGHE[i].CDOCOLOKCJK_Unlocked ? 1 : 0;
			}
			m_storyList.Clear();
			for(int i = -unlockStoryCount; i < 0; i++)
			{
				int index = total + i;
				if(index < data.FFPCLEONGHE.Count)
				{
					if(data.FFPCLEONGHE[index].CDOCOLOKCJK_Unlocked)
					{
						m_storyList.Add(data.FFPCLEONGHE[index]);
					}
				}
			}
			m_swapScrollList.SetItemCount(m_storyList.Count);
			m_swapScrollList.VisibleRegionUpdate();
			int a1 = CCAAJNJGNDO.FCMFPPALLOM(data.PPMNNKKFJNM_EventId);
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[a1 - 1];
			GameManager.Instance.MenuResidentTextureCache.LoadLogo((int)scene.EMIKBGHIOMN_SerieLogo, (IiconTexture texture) =>
			{
				//0xB9379C
				texture.Set(m_logImage);
			});
			m_storyIconLayout.StartChildrenAnimGoStop(isShowStoryIcon ? "01" : "02");
			m_message.text = MessageManager.Instance.GetMessage("menu", isShowStoryIcon ? "event_story_text_019" : "event_story_text_020");
		}

		// // RVA: 0xB932C0 Offset: 0xB932C0 VA: 0xB932C0
		public void ShowTitle()
		{
			m_titleLayout.StartAllAnim();
		}

		// RVA: 0xB932EC Offset: 0xB932EC VA: 0xB932EC
		private void OnUpdateList(int index, SwapScrollListContent content)
		{
			EventStoryOpenListContent c = content as EventStoryOpenListContent;
			if(c != null)
			{
				CCAAJNJGNDO.GALFFONBIJG data = m_storyList[index];
				c.SetThumbnail(data.DEIJDMPOPJF, data.DEAKHOJCBDM_Index - 1);
				c.SetTitle(data.FFPANKMKAPD_Title);
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DBD5C Offset: 0x6DBD5C VA: 0x6DBD5C
		// RVA: 0xB93664 Offset: 0xB93664 VA: 0xB93664
		public IEnumerator Co_LoadListContent()
		{
			AssetBundleLoadLayoutOperationBase layOp; // 0x18
			LayoutUGUIRuntime runtime; // 0x1C
			int i; // 0x20
			LayoutUGUIRuntime newGo; // 0x24

			//0xB93890
			layOp = AssetBundleManager.LoadLayoutAsync("ly/117.xab", "root_sel_event_data_content_s_layout_root");
			yield return layOp;
			GameObject go = null;
			yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0xB93884
				go = instance;
			}));
			m_swapScrollList.AddScrollObject(go.GetComponent<SwapScrollListContent>());
			runtime = go.GetComponent<LayoutUGUIRuntime>();
			for(i = 1; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				newGo = Instantiate(runtime);
				newGo.Layout = runtime.Layout.DeepClone();
				newGo.IsLayoutAutoLoad = false;
				newGo.UvMan = runtime.UvMan;
				newGo.LoadLayout();
				while(!newGo.IsReady)
					yield return null;
				m_swapScrollList.AddScrollObject(newGo.GetComponent<SwapScrollListContent>());
				newGo = null;
			}
			m_swapScrollList.Apply();
		}
	}
}
