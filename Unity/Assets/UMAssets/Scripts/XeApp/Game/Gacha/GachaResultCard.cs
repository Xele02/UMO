using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeApp.Game.Menu;

namespace XeApp.Game.Gacha
{
	public class GachaResultCard : LayoutLabelScriptBase
	{
		[SerializeField]
		private int m_cardIndex; // 0x18
		[SerializeField]
		private RawImageEx m_cardImage; // 0x1C
		[SerializeField]
		private RawImageEx m_frameImage; // 0x20
		[SerializeField]
		private LayoutUGUIHitOnly m_hitOnly; // 0x24
		[SerializeField]
		private StayButton m_stayButton; // 0x28
		[SerializeField]
		private RectTransform m_newDecoRoot; // 0x2C
		private LayoutSymbolData m_symbolMain; // 0x30
		private LayoutSymbolData m_symbolStyle; // 0x34
		private RectTransform m_rectTransform; // 0x38
		private Vector2 m_cardImagePos; // 0x3C

		public Action<GachaResultCard> onClick { private get; set; } // 0x44
		public int cardIndex { get { return m_cardIndex; } } //0x98ED78
		public RectTransform newDecoRoot { get { return m_newDecoRoot; } } //0x98ED80

		// RVA: 0x98ED88 Offset: 0x98ED88 VA: 0x98ED88
		public void SetStyle(int starNum, bool isNew)
		{
			if(starNum == 5)
			{
				m_symbolStyle.StartAnim(isNew ? "s5_new" : "s5_base");
			}
			else if(starNum == 6)
			{
				m_symbolStyle.StartAnim(isNew ? "s5_new" : "s5_base");
			}
			else if(starNum == 4)
			{
				m_symbolStyle.StartAnim(isNew ? "s4_new" : "s4_base");
			}
			else
			{
				m_symbolStyle.StartAnim(isNew ? "s3_new" : "s3_base");
			}
		}

		// RVA: 0x98EEDC Offset: 0x98EEDC VA: 0x98EEDC
		public void SetCardTexture(IiconTexture iconTex)
		{
			iconTex.Set(m_cardImage);
		}

		// RVA: 0x98EFBC Offset: 0x98EFBC VA: 0x98EFBC
		public void SetFrameTexture(IiconTexture iconTex)
		{
			if(iconTex == null)
				return;
			iconTex.Set(m_frameImage);
		}

		// RVA: 0x98F098 Offset: 0x98F098 VA: 0x98F098
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x98F0C4 Offset: 0x98F0C4 VA: 0x98F0C4
		public void LeaveImmediately()
		{
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x98F140 Offset: 0x98F140 VA: 0x98F140
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x98F1BC Offset: 0x98F1BC VA: 0x98F1BC
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		// RVA: 0x98F238 Offset: 0x98F238 VA: 0x98F238
		private void Update()
		{
			if(m_rectTransform != null)
				m_rectTransform.anchoredPosition = m_cardImagePos;
		}

		// RVA: 0x98F2FC Offset: 0x98F2FC VA: 0x98F2FC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("card" + m_cardIndex.ToString("D2") + "_main", layout);
			m_symbolStyle = CreateSymbol("card" + m_cardIndex.ToString("D2") + "_style", layout);
			m_cardImage.material = new Material(Shader.Find("XeSys/Unlit/SplitTexture"));
			m_cardImage.MaterialMul = m_cardImage.material;
			m_rectTransform = m_cardImage.GetComponent<RectTransform>();
			m_rectTransform.sizeDelta = new Vector2(m_rectTransform.sizeDelta.x, m_rectTransform.sizeDelta.y * SceneIconTexture.IconUv.height);
			m_cardImagePos = new Vector2(m_rectTransform.anchoredPosition.x, m_rectTransform.anchoredPosition.y * SceneIconTexture.IconUv.height);
			m_stayButton.ClearOnClickCallback();
			m_stayButton.AddOnClickCallback(() =>
			{
				//0x98F784
				if(onClick != null)
					onClick(this);
			});
			m_stayButton.ClearOnStayCallback();
			m_stayButton.AddOnStayCallback(() =>
			{
				//0x98F7F4
				if(onClick != null)
					onClick(this);
			});
			Loaded();
			return true;
		}
	}
}
