using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeSys;

namespace XeApp.Game.Menu
{
	internal class RaidBossEncountWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text01; // 0x14
		[SerializeField]
		private RawImageEx m_itemImage; // 0x18
		private bool m_IsInialize; // 0x1C

		public bool Unused() { return m_IsInialize; }

		// RVA: 0x145B6E4 Offset: 0x145B6E4 VA: 0x145B6E4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}

		// RVA: 0x145B6FC Offset: 0x145B6FC VA: 0x145B6FC
		public void Initialize()
		{
			PKNOKJNLPOE_NetEventRaidController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_NetEventRaidController;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			MenuScene.Instance.ItemTextureCache.Load(NKOBMDPHNGP_NetEventRaidLobbyController.ADPMLOEOAFD_GetTicketId(), (IiconTexture texture) =>
			{
				//0x145BAB0
				texture.Set(m_itemImage);
			});
			if(ev.KBFCALJDLPH())
			{
				m_text01.text = string.Format(bk.GetMessageByLabel("pop_raid_bosspop_text01"), NKOBMDPHNGP_NetEventRaidLobbyController.GPNELLFNPLA(), ev.NPICFLFAIJK_GetNumTicket(), ev.NPICFLFAIJK_GetNumTicket() - 1);
			}
			else
			{
				m_text01.text = string.Format(bk.GetMessageByLabel("pop_raid_bosspop_not_text01"), NKOBMDPHNGP_NetEventRaidLobbyController.GPNELLFNPLA(), ev.NPICFLFAIJK_GetNumTicket());
			}
			m_IsInialize = true;
		}
	}
}
