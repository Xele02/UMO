using System;
using System.Linq;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class UnlockValkyrieInfo : LayoutUGUIScriptBase
	{
		private Action m_OnClickOk; // 0x14
		private AbsoluteLayout m_Anim; // 0x18
		private ActionButton m_OkButton; // 0x1C

		public Action OnClickOk { set { m_OnClickOk = value; } } //0x164C798

		// RVA: 0x164C7A0 Offset: 0x164C7A0 VA: 0x164C7A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_Anim = layout.FindViewByExId("root_ul_val_sw_ul_val_all_anim") as AbsoluteLayout;
			m_OkButton = GetComponentInChildren<ActionButton>(true);
			m_OkButton.AddOnClickCallback(() =>
			{
				//0x164D2D4
				if(m_OnClickOk != null)
					m_OnClickOk();
			});
			SetOperation(false);
			Loaded();
			return true;
		}

		// RVA: 0x164C934 Offset: 0x164C934 VA: 0x164C934
		public void Setup(PNGOLKLFFLH data)
		{
			RawImageEx[] riex = GetComponentsInChildren<RawImageEx>(true);
			RawImageEx icon = riex.Where((RawImageEx _) =>
			{
				//0x164D364
				return _.name == "swtexc_p_icon (ImageView)";
			}).First();
			GameManager.Instance.PilotTextureCache.Load(data.OPBPKNHIPPE_Pilot.PFGJJLGLPAC_PilotId, (IiconTexture texture) =>
			{
				//0x164D5E4
				texture.Set(icon);
			});
			Text[] txts = GetComponentsInChildren<Text>(true);
			txts.Where((Text _) =>
			{
				//0x164D3E4
				return _.name == "logo_00 (TextView)";
			}).First().text = data.IJBLEJOKEFH_ValkyrieName;
			txts.Where((Text _) =>
			{
				//0x164D464
				return _.name == "nickname_00 (TextView)";
			}).First().text = data.MJJCKMPICIK_PilotName;
			txts.Where((Text _) =>
			{
				//0x164D4E4
				return _.name == "pilot_00 (TextView)";
			}).First().text = data.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name;
			txts.Where((Text _) =>
			{
				//0x164D564
				return _.name == "text_00 (TextView)";
			}).First().text = data.KLMPFGOCBHC_ValkyrieDesc;
		}

		// RVA: 0x164D0FC Offset: 0x164D0FC VA: 0x164D0FC
		public bool IsPlaying()
		{
			return m_Anim.IsPlayingChildren();
		}

		// RVA: 0x164C900 Offset: 0x164C900 VA: 0x164C900
		public void SetOperation(bool is_operation)
		{
			m_OkButton.enabled = is_operation;
		}

		// RVA: 0x164D128 Offset: 0x164D128 VA: 0x164D128
		public void ResetAnim()
		{
			SetOperation(false);
			m_Anim.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x164D1B0 Offset: 0x164D1B0 VA: 0x164D1B0
		public void Enter()
		{
			m_Anim.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x164D23C Offset: 0x164D23C VA: 0x164D23C
		// public void Leave() { }

		// RVA: 0x164D2C8 Offset: 0x164D2C8 VA: 0x164D2C8
		public void Update()
		{
			return;
		}
	}
}
