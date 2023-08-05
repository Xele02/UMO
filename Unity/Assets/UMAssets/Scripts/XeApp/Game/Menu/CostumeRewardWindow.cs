using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys;
using System.Text;
using System;
using System.Collections;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class CostumeRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		private List<LFAFJCNKLML.FHLDDEKAJKI> m_list; // 0x18
		private List<CostumeRewardItem> m_scrollItemList = new List<CostumeRewardItem>(); // 0x1C
		private const int ICON_START_MARGIN = 20;

		public bool IsInitialized { get; private set; } // 0x20

		// RVA: 0x163A834 Offset: 0x163A834 VA: 0x163A834 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ClearLoadedCallback();
			Transform t1 = transform.Find("scroll_area (AbsoluteLayout)");
			Text txt = t1.Find("txt_00 (TextView)").GetComponent<Text>();
			Text txt2 = t1.Find("txt_01 (TextView)").GetComponent<Text>();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			StringBuilder str = new StringBuilder();
			str.SetFormat(bk.GetMessageByLabel("costume_upgrade_cmn_rankup_attention_text"), MOEALEGLGCH.FLGEJDKMNMI());
			string[] strs = str.ToString().Split(new string[] { JpStringLiterals.StringLiteral_10137 }, StringSplitOptions.RemoveEmptyEntries);
			if(strs.Length > 1)
			{
				txt.text = strs[0];
				txt2.text = strs[1];
			}
			return true;
		}

		//// RVA: 0x163ABDC Offset: 0x163ABDC VA: 0x163ABDC
		public void ResetScrollPosition()
		{
			m_scrollRect.content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		//// RVA: 0x163ACC0 Offset: 0x163ACC0 VA: 0x163ACC0
		public void Enter(LFAFJCNKLML data)
		{
			m_list = data.OCOOHBINGBG;
			int lvl = data.GKIKAABHAAD_Level;
			for (int i = 0; i < m_scrollItemList.Count; i++)
			{
				m_scrollItemList[i].SetItem(data, i, i < lvl, data.AHHJLDLAPAN_DivaId, data.JPIDIENBGKH_CostumeId, data.DAJGPBLEEOB_PrismCostumeId);
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6CE874 Offset: 0x6CE874 VA: 0x6CE874
		//// RVA: 0x163A6E4 Offset: 0x163A6E4 VA: 0x163A6E4
		public IEnumerator CreateItemIcon(int count)
		{
			AssetBundleLoadLayoutOperationBase layout; // 0x1C
			int i; // 0x20

			//0x163B034
			LayoutUGUIRuntime runtime = null;
			IsInitialized = false;
			m_scrollItemList.Clear();
			layout = AssetBundleManager.LoadLayoutAsync("ly/128.xab", "PopupCostumeRewardList");
			yield return layout;
			yield return Co.R(layout.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0x163AF3C
				runtime = obj.GetComponent<LayoutUGUIRuntime>();
				m_scrollItemList.Add(runtime.GetComponent<CostumeRewardItem>());
			}));
			AssetBundleManager.UnloadAssetBundle("ly/128.xab", false);
			for(i = 0; i < count - 1; i++)
			{
				LayoutUGUIRuntime r = Instantiate(runtime);
				r.IsLayoutAutoLoad = false;
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				m_scrollItemList.Add(r.GetComponent<CostumeRewardItem>());
			}
			for(i = 0; i < m_scrollItemList.Count; i++)
			{
				while (!m_scrollItemList[i].IsLoaded())
					yield return null;
				m_scrollItemList[i].transform.SetParent(m_scrollRect.content.GetChild(0), false);
			}
			IsInitialized = true;
		}
	}
}
