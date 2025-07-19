using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutNewYearEvent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<RawImageEx> m_imageTitle; // 0x14
		[SerializeField]
		private Text m_textPeriod; // 0x18
		[SerializeField]
		private List<SpEventButton> m_btnList; // 0x1C
		[SerializeField]
		private List<Text> m_textNext; // 0x20
		[SerializeField]
		private List<RawImageEx> m_imageNext; // 0x24
		private TexUVListManager m_uvManager; // 0x28
		private AbsoluteLayout m_layoutRoot; // 0x2C
		private AbsoluteLayout m_layoutButton; // 0x30
		private AbsoluteLayout m_layoutNext; // 0x34
		private SpEventTitleTextureCache m_texCacheTitle = new SpEventTitleTextureCache(); // 0x38
		private SpEventButtonTextureCache m_texCacheSpButton = new SpEventButtonTextureCache(); // 0x3C
		private List<OHKECKAPJJL> m_nextInfo = new List<OHKECKAPJJL>(); // 0x40
		private int m_nextIndex; // 0x44
		private int m_btnCount; // 0x48
		private Coroutine m_coNextLoop; // 0x4C
		public Action<OHKECKAPJJL> OnPushButton; // 0x50

		public bool IsDownloaded { get { 
			for(int i = 0; i < m_btnCount; i++)
			{
				if(!m_btnList[i].IsDownloaded)
					return false;
			}
			return true;
		} } //0x15CD5F8

		// RVA: 0x15CD6C8 Offset: 0x15CD6C8 VA: 0x15CD6C8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvManager = uvMan;
			m_layoutRoot = layout.FindViewById("btn_all") as AbsoluteLayout;
			m_layoutButton = layout.FindViewById("swtbl_btn") as AbsoluteLayout;
			m_layoutNext = layout.FindViewById("sw_sel_ev_nxt_change_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x15CD898 Offset: 0x15CD898 VA: 0x15CD898
		public void Release()
		{
			for(int i = 0; i < m_btnList.Count; i++)
			{
				m_btnList[i].Release();
			}
			m_texCacheTitle.Terminated();
			m_texCacheSpButton.Terminated();
		}

		// RVA: 0x15CD9C4 Offset: 0x15CD9C4 VA: 0x15CD9C4
		private void Update()
		{
			m_texCacheTitle.Update();
			m_texCacheSpButton.Update();
		}

		// // RVA: 0x15CDA14 Offset: 0x15CDA14 VA: 0x15CDA14
		public void Apply(IHKJLKLAMMC viewData, long currentTime)
		{
			m_btnCount = viewData.MMPDGHKFNLE_GetButtonsCount();
			switch(m_btnCount)
			{
				case 4:
					m_layoutButton.StartChildrenAnimGoStop("01");
					break;
				case 5:
					m_layoutButton.StartChildrenAnimGoStop("02");
					break;
				case 6:
					m_layoutButton.StartChildrenAnimGoStop("03");
					break;
				case 7:
					m_layoutButton.StartChildrenAnimGoStop("04");
					break;
				case 8:
					m_layoutButton.StartChildrenAnimGoStop("05");
					break;
			}
			KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
			m_texCacheTitle.Load(ev.PGIIDPEGGPI_EventId, viewData.HCGPNCJNKED(currentTime), (IiconTexture texture) =>
			{
				//0x15CF15C
				for(int i = 0; i < m_imageTitle.Count; i++)
				{
					texture.Set(m_imageTitle[i]);
				}
			});
			string s = MessageManager.Instance.GetMessage("menu", "sel_event_01_period");
			DateTime d1 = DateTime.Now;
			DateTime d2 = DateTime.Now;
			if(ev.GEFCIHNPKIG())
			{
				long l1, l2;
				ev.NJIKJJNLAPL(currentTime, out l1, out l2);
				d1 = Utility.GetLocalDateTime(l1);
				d2 = Utility.GetLocalDateTime(l2);
			}
			else
			{
				d1 = Utility.GetLocalDateTime(ev.GLIMIGNNGGB_Start);
				d2 = Utility.GetLocalDateTime(ev.DPJCPDKALGI_End1);
			}
			m_textPeriod.text = string.Format(s, new object[10]
			{
				d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute,
				d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute
			});
			for(int i = 0; i < m_btnList.Count; i++)
			{
				m_btnList[i].Hidden = true;
			}
			for(int i = 0; i < m_btnCount; i++)
			{
				m_btnList[i].Hidden = false;
				m_btnList[i].Apply(ev.PGIIDPEGGPI_EventId, viewData.EJAPIOEOPNF_GetButtonInfo(i), m_texCacheSpButton);
				m_btnList[i].OnPushButton = (OHKECKAPJJL _info) =>
				{
					//0x15CF2CC
					if(OnPushButton != null)
						OnPushButton(_info);
				};
			}
		}

		// // RVA: 0x15CE6E8 Offset: 0x15CE6E8 VA: 0x15CE6E8
		// private void ApplyNextInfo(List<OHKECKAPJJL> nextInfo) { }

		// // RVA: 0x15CE914 Offset: 0x15CE914 VA: 0x15CE914
		// private void SetNextInfo(int index, OHKECKAPJJL info) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F7314 Offset: 0x6F7314 VA: 0x6F7314
		// // RVA: 0x15CE888 Offset: 0x15CE888 VA: 0x15CE888
		// private IEnumerator Co_NextInfoLoop() { }

		// RVA: 0x15CEEC8 Offset: 0x15CEEC8 VA: 0x15CEEC8
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x15CEF54 Offset: 0x15CEF54 VA: 0x15CEF54
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x15CEFE0 Offset: 0x15CEFE0 VA: 0x15CEFE0
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// // RVA: 0x15CF00C Offset: 0x15CF00C VA: 0x15CF00C
		// public void Skip() { }
	}
}
