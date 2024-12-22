using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomStampItem : SwapScrollListContent
	{
		public enum Type
		{
			Stamp = 0,
			Create = 1,
		}

		private AbsoluteLayout m_rootLayout; // 0x20
		private AbsoluteLayout m_selectLayout; // 0x24
		private AbsoluteLayout m_textAnim; // 0x28
		[SerializeField]
		private RawImageEx m_charactorImage; // 0x2C
		[SerializeField]
		private RawImageEx m_serifImage; // 0x30
		[SerializeField]
		private Text m_numText; // 0x34
		[SerializeField]
		private StayButton m_editCharaButton; // 0x38
		[SerializeField]
		private ActionButton m_createButton; // 0x3C
		[SerializeField]
		private Text[] m_serifText; // 0x40
		private Type m_type; // 0x44
		private int m_stampId = 1; // 0x48
		private int m_serifId = 1; // 0x4C
		private int number; // 0x50

		//public Type ItemType { get; } 0x19DE088
		public bool IsLongTap { get; set; } // 0x54
		public bool IsLongTapProcess { get; set; } // 0x55
		public int Number { get { return number; } } //0x19DE0B0
		//public Vector2 Size { get; } 0x19DEFC0

		// RVA: 0x19DE0B8 Offset: 0x19DE0B8 VA: 0x19DE0B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_rootLayout = layout.FindViewByExId("root_cstm_deco_item_03_swtbl_cstm_deco_creat") as AbsoluteLayout;
			m_selectLayout = layout.FindViewByExId("swtbl_cstm_deco_creat_sw_cstm_deco_item_03") as AbsoluteLayout;
			m_textAnim = layout.FindViewByExId("sw_cstm_deco_item_03_swtbl_ballon_text_03") as AbsoluteLayout;
			m_editCharaButton.ClearOnClickCallback();
			m_editCharaButton.AddOnClickCallback(() =>
			{
				//0x19DF164
				OnSelect();
			});
			m_createButton.ClearOnClickCallback();
			m_createButton.AddOnClickCallback(() =>
			{
				//0x19DF168
				OnSelect();
			});
			m_editCharaButton.ClearOnStayCallback();
			m_editCharaButton.AddOnStayCallback(() =>
			{
				//0x19DF16C
				IsLongTap = true;
				if (IsLongTapProcess)
					return;
				IsLongTapProcess = true;
				OnSelect();
			});
			return true;
		}

		//// RVA: 0x19DE3E8 Offset: 0x19DE3E8 VA: 0x19DE3E8
		//public void Initialize(LayoutDecoCustomStampItem.Type type, int num = 0) { }

		//// RVA: 0x19DE408 Offset: 0x19DE408 VA: 0x19DE408
		private void SwitchLayout(Type type)
		{
			m_type = type;
			if(type == Type.Stamp)
			{
				m_rootLayout.StartChildrenAnimGoStop("01", "01");
			}
			else if(type == Type.Create)
			{
				m_rootLayout.StartChildrenAnimGoStop("02", "02");
			}
		}

		//// RVA: 0x19DE4C4 Offset: 0x19DE4C4 VA: 0x19DE4C4
		public void SetNumText()
		{
			if(number != 0)
			{
				m_numText.enabled = true;
				m_numText.text = number.ToString();
			}
			else
			{
				m_numText.enabled = false;
			}
		}

		//// RVA: 0x19DE554 Offset: 0x19DE554 VA: 0x19DE554
		//public void Hide() { }

		//// RVA: 0x19DE5D4 Offset: 0x19DE5D4 VA: 0x19DE5D4
		//public void Show() { }

		//// RVA: 0x19DE68C Offset: 0x19DE68C VA: 0x19DE68C
		public void LoadStampTexture(int charaId, int serifId)
		{
			m_stampId = charaId;
			m_serifId = serifId;
			if(m_type == Type.Stamp)
			{
				NCPPAHHCCAO d = NCPPAHHCCAO.FKDIMODKKJD().Find((NCPPAHHCCAO item) =>
				{
					//0x19DF188
					return m_stampId == item.PPFNGGCBJKC;
				});
				MenuScene.Instance.DecorationItemTextureCache.LoadForDecoCustom(d.IDELKEKDIFD_CharaId, d.BEHMEDMNJMC_EmotionId, (IiconTexture image) =>
				{
					//0x19DF1CC
					SetImage(image, m_charactorImage);
				});
				IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP dbSerif = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
				{
					//0x19DF1F8
					return item.PPFNGGCBJKC == serifId;
				});
				MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(dbSerif.GBJFNGCDKPM_FrameId, (IiconTexture image) =>
				{
					//0x19DF1D4
					SetImage(image, m_serifImage);
				});
				dbSerif = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
				{
					//0x19DF23C
					return item.PPFNGGCBJKC == serifId;
				});
				m_textAnim.StartChildrenAnimGoStop(string.Format("{0:D2}", dbSerif.LDLGLHBGOKE_FontSize));
				string s = NCPPAHHCCAO.GHHOBKGGADG(m_serifId);
				for(int i = 0; i < m_serifText.Length; i++)
				{
					m_serifText[i].text = s;
				}
			}
		}

		//// RVA: 0x19DEC68 Offset: 0x19DEC68 VA: 0x19DEC68
		public void SetData(int charaId, int serifId, Type type, int num)
		{
			SwitchLayout(type);
			LoadStampTexture(charaId, serifId);
			number = num;
			SetNumText();
		}

		//// RVA: 0x19DECA8 Offset: 0x19DECA8 VA: 0x19DECA8
		private void OnSelect()
		{
			ClickButton.Invoke(0, this);
		}

		//// RVA: 0x19DED28 Offset: 0x19DED28 VA: 0x19DED28
		public void Copy(LayoutDecoCustomStampWindow.StampData item, int target = 0)
		{
			SetData(item.stampId, item.serifId, item.type, item.number);
			if (number == target)
				SelectEffectOn();
			else
				SelectEffectOff();
		}

		//// RVA: 0x19DEEE4 Offset: 0x19DEEE4 VA: 0x19DEEE4
		public void SetImage(IiconTexture texture, RawImageEx target)
		{
			texture.Set(target);
		}

		//// RVA: 0x19DEDD8 Offset: 0x19DEDD8 VA: 0x19DEDD8
		public void SelectEffectOn()
		{
			m_selectLayout.StartChildrenAnimLoop("logo_on", "loen_on");
		}

		//// RVA: 0x19DEE64 Offset: 0x19DEE64 VA: 0x19DEE64
		public void SelectEffectOff()
		{
			m_selectLayout.StartChildrenAnimGoStop("st_wait", "st_wait");
		}
		
		//// RVA: 0x19DF060 Offset: 0x19DF060 VA: 0x19DF060
		public void ResetStayButton(bool _isStay)
		{
			m_editCharaButton.ClearOnStayCallback();
			if (!_isStay)
				return;
			m_editCharaButton.AddOnStayCallback(() =>
			{
				//0x19DF1DC
				IsLongTap = true;
				if (IsLongTapProcess)
					return;
				IsLongTapProcess = true;
				OnSelect();
			});
		}

		//// RVA: 0x19DF134 Offset: 0x19DF134 VA: 0x19DF134
		//public void LongTap() { }
	}
}
