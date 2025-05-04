using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LobbyLiveWindow : LayoutUGUIScriptBase
	{
		public class LobbyLiveSerif
		{
			public AbsoluteLayout m_animRoot; // 0x8
			public AbsoluteLayout m_txtAnim; // 0xC
			public RawImageEx m_attrTex; // 0x10
			public Text[] m_text; // 0x14
			private bool m_isLeave; // 0x18

			// // RVA: 0x1299448 Offset: 0x1299448 VA: 0x1299448
			public void Enter()
			{
				m_isLeave = false;
				m_animRoot.StartChildrenAnimGoStop("go_in", "st_in");
			}

			// [IteratorStateMachineAttribute] // RVA: 0x6E82C4 Offset: 0x6E82C4 VA: 0x6E82C4
			// // RVA: 0x12994DC Offset: 0x12994DC VA: 0x12994DC
			public IEnumerator StartLoopAnim()
			{
				//0x12997C4
				yield return null;
				while(m_animRoot.IsPlayingChildren())
					yield return null;
				if(!m_isLeave)
					m_animRoot.StartChildrenAnimLoop("logo_act");
			}

			// // RVA: 0x1299620 Offset: 0x1299620 VA: 0x1299620
			// public void Leave() { }

			// // RVA: 0x129841C Offset: 0x129841C VA: 0x129841C
			public void Hide()
			{
				m_isLeave = true;
				m_animRoot.StartChildrenAnimGoStop("st_wait");
			}

			// // RVA: 0x12996B4 Offset: 0x12996B4 VA: 0x12996B4
			// public bool IsPlaying() { }

			// // RVA: 0x1298BB8 Offset: 0x1298BB8 VA: 0x1298BB8
			public void SetFontType(int type)
			{
				m_txtAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", type));
			}

			// // RVA: 0x129826C Offset: 0x129826C VA: 0x129826C
			public void SetText(string text)
			{
				for(int i = 0; i < m_text.Length; i++)
				{
					m_text[i].text = text;
				}
			}

			// // RVA: 0x129830C Offset: 0x129830C VA: 0x129830C
			public void SetAttrTexture(int i)
			{
				MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(i, (IiconTexture image) =>
				{
					//0x12996E0
					image.Set(m_attrTex);
				});
			}
		}

		public static readonly int ViewStampMax = 7; // 0x0
		public static readonly int GetStampMax = 20; // 0x4
		private LobbyLiveSerif[] m_serif; // 0x14
		private int showIndex; // 0x18
		private List<int> showIndexList = new List<int>(); // 0x1C
		private List<int> viewSerifs = new List<int>(); // 0x20
		private Coroutine coroutine; // 0x24

		// RVA: 0x12978AC Offset: 0x12978AC VA: 0x12978AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Transform t = transform.Find("sw_lb_live_blln_pos_01 (AbsoluteLayout)");
			m_serif = new LobbyLiveSerif[t.childCount];
			for(int i = 0; i < m_serif.Length; i++)
			{
				m_serif[i] = new LobbyLiveSerif();
				Transform t0 = t.Find(string.Format("{0:D2} (AbsoluteLayout)", i + 1));
				m_serif[i].m_animRoot = layout.FindViewByExId(string.Format("sw_lb_live_blln_pos_01_0{0}", i + 1)) as AbsoluteLayout;
				m_serif[i].m_txtAnim = m_serif[i].m_animRoot.FindViewById("swtbl_fuki_txt")  as AbsoluteLayout;
				m_serif[i].m_text = t0.GetComponentsInChildren<Text>(true).Where((Text _) =>
				{
					//0x1298F58
					return _.name.Contains("txt_01 (TextView)");
				}).ToArray();
				m_serif[i].m_attrTex = t0.GetComponentsInChildren<RawImageEx>(true).Where((RawImageEx _) =>
				{
					//0x1298FF0
					return _.name == "swtexc_dc_blln_01 (ImageView)";
				}).First();
			}
			string s = NCPPAHHCCAO.GHHOBKGGADG(1);
			for(int i = 0; i < m_serif.Length; i++)
			{
				m_serif[i].SetText(s);
				m_serif[i].SetAttrTexture(1);
				m_serif[i].Hide();
				m_serif[i].m_attrTex.raycastTarget = false;
			}
			return true;
		}

		// RVA: 0x12984A0 Offset: 0x12984A0 VA: 0x12984A0
		public void AddLiveStamp(int serifId)
		{
			viewSerifs.Insert(showIndex, serifId);
		}

		// // RVA: 0x1298528 Offset: 0x1298528 VA: 0x1298528
		public void SetSerifs(List<int> list)
		{
			viewSerifs.Clear();
			viewSerifs = list;
			list.Reverse();
			showIndexList.Clear();
			showIndex = 0;
			List<int> l2 = new List<int>();
			l2.Add(0);
			l2.Add(1);
			l2.Add(2);
			l2.Add(3);
			l2.Add(4);
			l2.Add(5);
			l2.Add(6);
			showIndexList = l2.OrderBy((int i) =>
			{
				//0x1299070
				return Guid.NewGuid();
			}).ToList();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6E824C Offset: 0x6E824C VA: 0x6E824C
		// // RVA: 0x129887C Offset: 0x129887C VA: 0x129887C
		public IEnumerator Co_SerifAnimation()
		{
			//0x12990F8
			yield return new WaitForSecondsRealtime(1);
			yield return null;
			while(true)
			{
				if(showIndex < viewSerifs.Count)
				{
					yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(0.1f,0.3f));
					SetStamp(viewSerifs[showIndex % ViewStampMax], showIndex % ViewStampMax);
					m_serif[showIndexList[showIndex % ViewStampMax]].Enter();
					this.StartCoroutineWatched(m_serif[showIndexList[showIndex % ViewStampMax]].StartLoopAnim());
					showIndex++;
				}
				else
					yield return null;
			}
		}

		// // RVA: 0x1298928 Offset: 0x1298928 VA: 0x1298928
		public void SetStamp(int serifId, int index)
		{
			KDKFHGHGFEK k = new KDKFHGHGFEK();
			k.KHEKNNFCAOI(serifId, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif);
			m_serif[showIndexList[index]].SetText(k.DOIGLOBENMG_StampName);
			m_serif[showIndexList[index]].SetAttrTexture(k.GBJFNGCDKPM_Attribute);
			m_serif[showIndexList[index]].SetFontType(k.DBGAJBIBODC_FontType);
		}

		// RVA: 0x1298C70 Offset: 0x1298C70 VA: 0x1298C70
		private void Update()
		{
			return;
		}

		// // RVA: 0x1298C74 Offset: 0x1298C74 VA: 0x1298C74
		public void AllEnter()
		{
			coroutine = this.StartCoroutineWatched(Co_SerifAnimation());
		}

		// // RVA: 0x1298C9C Offset: 0x1298C9C VA: 0x1298C9C
		public void AllLeave()
		{
			this.StopCoroutineWatched(coroutine);
			for(int i = 0; i < m_serif.Length; i++)
			{
				m_serif[i].Hide();
			}
		}

		// // RVA: 0x1298D34 Offset: 0x1298D34 VA: 0x1298D34
		public void AllHide()
		{
			for(int i = 0; i < m_serif.Length; i++)
			{
				m_serif[i].Hide();
			}
		}
	}
}
