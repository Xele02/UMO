using System;
using System.Linq;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupCampaign1st : LayoutUGUIScriptBase
	{
		private Text m_textContent1; // 0x14
		private Text m_textContent2; // 0x18
		private RawImageEx m_charaLeft; // 0x1C
		private RawImageEx m_charaRight; // 0x20
		private ActionButton m_button; // 0x24
		private AbsoluteLayout m_layoutRoot; // 0x28
		private TipsTextureCache m_textureCache; // 0x2C
		private readonly int[,] m_textureIdTable = new int[10, 2]
		{
			{ 102001, 0},
			{ 202005, 1},
			{ 302001, 1},
			{ 402005, 0},
			{ 502005, 0},
			{ 602007, 0},
			{ 799007, 1},
			{ 801008, 0},
			{ 901005, 1},
			{ 1001000, 0}
		}; // 0x30
		public Action OnClickButton; // 0x34

		// RVA: 0x15E86B8 Offset: 0x15E86B8 VA: 0x15E86B8
		private void OnDestroy()
		{
			if(m_textureCache != null)
				m_textureCache = null;
		}

		// RVA: 0x15E86CC Offset: 0x15E86CC VA: 0x15E86CC
		public void Setup(int divaId, TipsTextureCache textureCache)
		{
			m_textureCache = textureCache;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textContent2.text = bk.GetMessageByLabel("campaign_live_3rd_msg_chara_" + divaId.ToString("D2"));
			m_charaLeft.enabled = false;
			m_charaRight.enabled = false;
			int dir = m_textureIdTable[divaId - 1,1];
			m_textureCache.LoadChara(dir, m_textureIdTable[divaId - 1, 0], (IiconTexture texture) =>
			{
				//0x15E98AC
				if(dir == 0)
				{
					texture.Set(m_charaLeft);
					m_charaLeft.enabled = true;
				}
				else
				{
					texture.Set(m_charaRight);
					m_charaRight.enabled = true;
				}
			});
		}

		// RVA: 0x15E89C8 Offset: 0x15E89C8 VA: 0x15E89C8
		public void Enter()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			transform.SetAsLastSibling();
		}

		// // RVA: 0x15E8A80 Offset: 0x15E8A80 VA: 0x15E8A80
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x15E8B0C Offset: 0x15E8B0C VA: 0x15E8B0C
		// public void Show() { }

		// RVA: 0x15E8BB4 Offset: 0x15E8BB4 VA: 0x15E8BB4
		public void Hide()
		{
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x15E8C30 Offset: 0x15E8C30 VA: 0x15E8C30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_pop_cpn_roul_congrats") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_textContent1 = txts.Where((Text _) =>
			{
				//0x15E952C
				return _.name == "txt_01 (TextView)";
			}).First();
			m_textContent2 = txts.Where((Text _) =>
			{
				//0x15E95AC
				return _.name == "txt_02 (TextView)";
			}).First();
			RawImageEx[] imgs = GetComponentsInChildren<RawImageEx>(true);
			m_charaLeft = imgs.Where((RawImageEx _) =>
			{
				//0x15E962C
				return _.transform.parent.name == "sw_tips_minichara_l (AbsoluteLayout)" && _.name == "swtexc_cmn_minichara (ImageView)";
			}).First();
			m_charaRight = imgs.Where((RawImageEx _) =>
			{
				//0x15E972C
				return _.transform.parent.name == "sw_tips_minichara_r (AbsoluteLayout)" && _.name == "swtexc_cmn_minichara (ImageView)";
			}).First();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textContent1.text = bk.GetMessageByLabel("campaign_live_3rd_content_02");
			m_textContent1.GetComponent<BetterOutline>().enabled = false; // disable one of the 2 better outline component which explode the vertex size.
			ActionButton[] btns = GetComponentsInChildren<ActionButton>(true);
			m_button = btns.Where((ActionButton _) =>
			{
				//0x15E982C
				return _.name == "sw_roul_btn_all_anim_01 (AbsoluteLayout)";
			}).First();
			m_button.AddOnClickCallback(() =>
			{
				//0x15E9488
				Leave();
				if(OnClickButton != null)
					OnClickButton();
			});
			Loaded();
			return true;
		}
	}
}
