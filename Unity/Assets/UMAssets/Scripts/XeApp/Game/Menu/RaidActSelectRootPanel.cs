using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidActSelectRootPanel : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RaidActSelectPanel m_layoutPanelL; // 0x14
		[SerializeField]
		private RaidActSelectPanel m_layoutPanelR; // 0x18
		[SerializeField]
		private Text m_textFreePlay; // 0x1C
		private AbsoluteLayout m_layoutFreePlay; // 0x20
		private bool m_isShow; // 0x24
		private bool m_isFreePlay; // 0x25
		private bool m_isAssisted; // 0x26

		public RaidActSelectPanel Left { get { return m_layoutPanelL; } } //0x14490AC
		public RaidActSelectPanel Right { get { return m_layoutPanelR; } } //0x14492CC

		// RVA: 0x145525C Offset: 0x145525C VA: 0x145525C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_layoutFreePlay = layout.FindViewById("sw_ap_message_inout_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x14492DC Offset: 0x14492DC VA: 0x14492DC
		public void SetFreePlay(bool isFreePlay)
		{
			m_isFreePlay = isFreePlay;
			m_textFreePlay.text = MessageManager.Instance.GetMessage("menu", "raid_first_attack_free_ap_02");
		}

		// // RVA: 0x14493B4 Offset: 0x14493B4 VA: 0x14493B4
		public void SetAssisted(bool isAssisted)
		{
			m_isAssisted = isAssisted;
		}

		// // RVA: 0x1455338 Offset: 0x1455338 VA: 0x1455338
		// public void Show() { }

		// // RVA: 0x1455388 Offset: 0x1455388 VA: 0x1455388
		// public void Hide() { }

		// RVA: 0x14553D8 Offset: 0x14553D8 VA: 0x14553D8
		public void Enter()
		{
			if(!m_isShow)
			{
				if(!m_isFreePlay)
				{
					m_layoutFreePlay.StartChildrenAnimGoStop("st_wait");
					if(m_isAssisted)
					{
						//LAB_014554d0
						m_layoutPanelL.Hide();
						m_layoutPanelR.Enter(true);
					}
					else
					{
						m_layoutPanelL.Enter(false);
						m_layoutPanelR.Enter(false);
					}
				}
				else
				{
					m_layoutFreePlay.StartChildrenAnimGoStop("go_in", "st_in");
					m_layoutPanelL.Hide();
					m_layoutPanelR.Enter(true);
				}
			}
			//LAB_014554f4
			m_isShow = true;
		}

		// RVA: 0x1455540 Offset: 0x1455540 VA: 0x1455540
		public void Leave()
		{
			if(m_isShow)
			{
				if(!m_isFreePlay)
				{
					m_layoutFreePlay.StartChildrenAnimGoStop("st_wait");
					m_layoutPanelL.Leave(false);
					m_layoutPanelR.Leave(false);
				}
				else
				{
					m_layoutFreePlay.StartChildrenAnimGoStop("go_out", "st_out");
					m_layoutPanelL.Hide();
					m_layoutPanelR.Leave(true);
				}
			}
			m_isShow = false;
		}
	}
}
