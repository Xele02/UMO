using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using XeApp.Core;
using XeSys;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GrowthAbilityList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private GameObject m_rootObject; // 0x14
		[SerializeField]
		private Text m_headerText; // 0x18
		private LayoutUGUIRuntime m_sourceObject; // 0x1C
		private List<LayoutUGUIRuntime> m_scrollObjects; // 0x20

		// RVA: 0xE21D98 Offset: 0xE21D98 VA: 0xE21D98 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			return true;
		}

		// RVA: 0xE21DB0 Offset: 0xE21DB0 VA: 0xE21DB0
		public int GetCount()
		{
			return m_scrollObjects.Count;
		}

		// RVA: 0xE21E28 Offset: 0xE21E28 VA: 0xE21E28
		public void SetHeader(int releaseCount, bool isOverEpisodePoint)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(isOverEpisodePoint)
			{
				m_headerText.text = string.Format(bk.GetMessageByLabel("growth_popup_text19"), releaseCount, SystemTextColor.LackColor);
			}
			else
			{
				m_headerText.text = string.Format(bk.GetMessageByLabel("growth_popup_text06"), releaseCount);
			}
		}

		// RVA: 0xE21FF8 Offset: 0xE21FF8 VA: 0xE21FF8
		public void SetValue(int index, int label, int value)
		{
			GrowthAbilityIcon icon = m_scrollObjects[index].GetComponent<GrowthAbilityIcon>();
			icon.gameObject.SetActive(false);
			icon.SetValue(label, value);
		}

		// RVA: 0xE22110 Offset: 0xE22110 VA: 0xE22110
		public void SetOff(int index)
		{
			m_scrollObjects[index].GetComponent<GrowthAbilityIcon>().gameObject.SetActive(false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x724704 Offset: 0x724704 VA: 0x724704
		// RVA: 0xE22200 Offset: 0xE22200 VA: 0xE22200
		public IEnumerator LoadObjectCoroutine(int needCount)
		{
			int loadCount; // 0x18
			int addStartIndex; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOperation; // 0x20

			//0xE22470
			loadCount = needCount - m_scrollObjects.Count;
			if (loadCount < 1)
				yield break;
			if(m_sourceObject == null)
			{
				lytOperation = AssetBundleManager.LoadLayoutAsync("ly/019.xab", "root_pop_ability_layout_root");
				yield return lytOperation;
				yield return Co.R(lytOperation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xE22354
					m_sourceObject = instance.GetComponent<LayoutUGUIRuntime>();
					m_sourceObject.transform.SetParent(transform, false);
					m_sourceObject.gameObject.SetActive(false);
				}));
				AssetBundleManager.UnloadAssetBundle("ly/019.xab", false);
				lytOperation = null;
			}
			addStartIndex = m_scrollObjects.Count;
			for(int i = 0; i < loadCount; i++)
			{
				LayoutUGUIRuntime r = Instantiate(m_sourceObject);
				r.gameObject.SetActive(true);
				r.IsLayoutAutoLoad = false;
				r.Layout = m_sourceObject.Layout.DeepClone();
				r.UvMan = m_sourceObject.UvMan;
				r.LoadLayout();
				m_scrollObjects.Add(r);
			}
			yield return null;
			for(int i = addStartIndex; i < m_scrollObjects.Count; i++)
			{
				m_scrollObjects[i].transform.SetParent(m_rootObject.transform);
				(m_scrollObjects[i].transform as RectTransform).anchoredPosition = new Vector2((i % 2) * 291, (i / 2) * -41);
			}
		}
	}
}
