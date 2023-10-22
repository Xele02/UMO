using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationFrameButton : LayoutUGUIScriptBase
	{
		public delegate void ButtonCallBack(ButtonType type);

		public enum ButtonType
		{
			Flip = 1,
			Serif = 2,
			PriDown = 4,
			PriUp = 8,
			Kira = 16,
			Num = 5,
			None = 0,
		}

		[SerializeField]
		private ActionButton m_flipButon; // 0x14
		[SerializeField]
		private ActionButton m_serifButon; // 0x18
		[SerializeField]
		private ActionButton m_priorityDownButon; // 0x1C
		[SerializeField]
		private ActionButton m_priorityUpButon; // 0x20
		[SerializeField]
		private ActionButton m_kiraButon; // 0x24
		public ButtonCallBack OnClickButton; // 0x28
		private float m_halfWidth; // 0x2C
		private float m_halfHeight; // 0x30
		private AbsoluteLayout m_kiraOnOffLayout; // 0x34

		//// RVA: 0x19F065C Offset: 0x19F065C VA: 0x19F065C
		//public static bool CheckButtonType(LayoutDecorationFrameButton.ButtonType type1, LayoutDecorationFrameButton.ButtonType type2) { }

		// RVA: 0x19F0670 Offset: 0x19F0670 VA: 0x19F0670 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_flipButon.AddOnClickCallback(() =>
			{
				//0x19F0D98
				OnClickButton(ButtonType.Flip);
			});
			m_serifButon.AddOnClickCallback(() =>
			{
				//0x19F1228
				SetEnable(ButtonType.Serif, false);
				OnClickButton(ButtonType.Serif);
			});
			m_priorityDownButon.AddOnClickCallback(() =>
			{
				//0x19F1264
				OnClickButton(ButtonType.PriDown);
			});
			m_priorityUpButon.AddOnClickCallback(() =>
			{
				//0x19F1290
				OnClickButton(ButtonType.PriUp);
			});
			m_kiraButon.AddOnClickCallback(() =>
			{
				//0x19F12BC
				OnClickButton(ButtonType.Kira);
			});
			m_kiraOnOffLayout = layout.FindViewByExId("sw_deco_frm_btn_kira_anim_swtexf_deco_fnt_kira_on") as AbsoluteLayout;
			return base.InitializeFromLayout(layout, uvMan);
		}

		//// RVA: 0x19F091C Offset: 0x19F091C VA: 0x19F091C
		public void Setting(RectTransform rect, ButtonType buttonType, ButtonCallBack onClickButton)
		{
			m_halfWidth = rect.sizeDelta.x * 0.5f;
			m_halfHeight = rect.sizeDelta.y * 0.5f;
			OnClickButton = onClickButton;
			for(int i = 0; i < (int)ButtonType.Num; i++)
			{
				SetEnable((ButtonType)(1 << i), 0 < ((int)buttonType & (1 << i)));
			}
		}

		//// RVA: 0x19F0B20 Offset: 0x19F0B20 VA: 0x19F0B20
		public void SetKiraButtonState(bool isKira)
		{
			m_kiraOnOffLayout.StartChildrenAnimGoStop(isKira ? "02" : "01");
		}

		//// RVA: 0x19F09D8 Offset: 0x19F09D8 VA: 0x19F09D8
		private void SetEnable(ButtonType type, bool isEnable)
		{
			if((type & ButtonType.Serif) != 0)
			{
				m_serifButon.Hidden = !isEnable;
				SetPosition(m_serifButon, m_halfWidth, m_halfHeight);
			}
			if((type & ButtonType.Flip) != 0)
			{
				m_flipButon.Hidden = !isEnable;
				SetPosition(m_flipButon, 0, m_halfHeight);
			}
			else if((type & ButtonType.PriDown) != 0)
			{
				m_priorityDownButon.Hidden = !isEnable;
				SetPosition(m_priorityDownButon, - m_halfWidth, 0);
			}
			else if((type & ButtonType.PriUp) != 0)
			{
				m_priorityUpButon.Hidden = !isEnable;
				SetPosition(m_priorityUpButon, m_halfWidth, 0);
			}
			else if((type & ButtonType.Kira) != 0)
			{
				m_kiraButon.Hidden = !isEnable;
				SetPosition(m_kiraButon, 0, -m_halfHeight);
			}
		}

		//// RVA: 0x19F0BB8 Offset: 0x19F0BB8 VA: 0x19F0BB8
		private void SetPosition(ActionButton button, float offsetX, float offsetY)
		{
			button.transform.localPosition = new Vector2(offsetX, offsetY);
		}

		//// RVA: 0x19F0CCC Offset: 0x19F0CCC VA: 0x19F0CCC
		public void Hidden()
		{
			m_flipButon.Hidden = true;
			m_serifButon.Hidden = true;
			m_priorityDownButon.Hidden = true;
			m_priorityUpButon.Hidden = true;
			m_kiraButon.Hidden = true;
		}
	}
}
