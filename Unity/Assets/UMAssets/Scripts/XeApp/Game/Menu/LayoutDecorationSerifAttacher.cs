using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSerifAttacher : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_item_stamp_layout_root"; // 0x0
		[SerializeField]
		private RawImageEx m_chara; // 0x14
		[SerializeField]
		private RawImageEx m_serifFrame; // 0x18
		[SerializeField]
		private List<Text> m_serifText = new List<Text>(); // 0x1C
		private AbsoluteLayout m_baseTbl; // 0x20
		private AbsoluteLayout m_charaAnim; // 0x24
		private AbsoluteLayout m_serifAnim; // 0x28
		private AbsoluteLayout m_serifTbl; // 0x2C
		private int m_charaId; // 0x30
		private int m_serifId; // 0x34
		private int m_fontSizeId; // 0x38
		private string m_text; // 0x3C
		private int m_frameType; // 0x40
		private bool IsLoadedChara; // 0x44
		private bool IsLoadedSerif; // 0x45

		// public bool IsLoaded { get; } 0x18B8964

		// RVA: 0x18B8984 Offset: 0x18B8984 VA: 0x18B8984 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_baseTbl = layout.FindViewById("swtbl_cstm_deco_item_stamp") as AbsoluteLayout;
			m_charaAnim = layout.FindViewById("sw_cmn_item_char_anim") as AbsoluteLayout;
			m_serifAnim = layout.FindViewById("sw_cmn_item_balloon_anim") as AbsoluteLayout;
			m_serifTbl = layout.FindViewById("swtbl_ballon_text_04") as AbsoluteLayout;
			return true;
		}

		// // RVA: 0x18B8BB8 Offset: 0x18B8BB8 VA: 0x18B8BB8
		public void Hide()
		{
			m_baseTbl.StartChildrenAnimGoStop(2, 2);
		}

		// RVA: 0x18B8BEC Offset: 0x18B8BEC VA: 0x18B8BEC
		public void Show(int charaId, int serifId = 0)
		{
			m_charaId = charaId;
			m_serifId = serifId;
			UpdateSerif();
			UpdateLayout();
			Enter();
			LoadCharaResource();
			LoadSerifResource();
		}

		// // RVA: 0x18B9060 Offset: 0x18B9060 VA: 0x18B9060
		public void SettingSerif(int serifId)
		{
			m_serifId = serifId;
			UpdateSerif();
			UpdateLayout();
			LoadSerifResource();
		}

		// // RVA: 0x18B8D7C Offset: 0x18B8D7C VA: 0x18B8D7C
		private void UpdateLayout()
		{
			int id = m_serifId;
			if(m_serifId > 0)
				id = m_charaId;
			if(id < 1)
			{
				m_baseTbl.StartChildrenAnimGoStop(m_charaId < 1 ? 2 : 0, m_charaId < 1 ? 2 : 0);
				return;
			}
			m_baseTbl.StartChildrenAnimGoStop(1, 1);
			m_serifTbl.StartChildrenAnimGoStop(m_fontSizeId - 1, m_fontSizeId - 1);
			m_serifText[m_fontSizeId - 1].text = m_text;
		}

		// // RVA: 0x18B8C28 Offset: 0x18B8C28 VA: 0x18B8C28
		private void UpdateSerif()
		{
			if(m_serifId != 0)
			{
				IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[m_serifId - 1];
				if(it == null)
					return;
				m_fontSizeId = it.LDLGLHBGOKE_FontSize;
				m_frameType = it.GBJFNGCDKPM_FrameId;
				m_text = NCPPAHHCCAO.GHHOBKGGADG(m_serifId);
			}
		}

		// // RVA: 0x18B8F88 Offset: 0x18B8F88 VA: 0x18B8F88
		private void LoadCharaResource()
		{
			if(m_charaId == 0)
			{
				IsLoadedChara = true;
				return;
			}
			IsLoadedChara = false;
			m_chara.enabled = false;
			this.StartCoroutineWatched(Co_LoadCharaResource());
		}

		// // RVA: 0x18B8FF4 Offset: 0x18B8FF4 VA: 0x18B8FF4
		private void LoadSerifResource()
		{
			if(m_serifId == 0)
			{
				IsLoadedSerif = true;
				return;
			}
			IsLoadedSerif = false;
			m_serifFrame.enabled = false;
			this.StartCoroutineWatched(Co_LoadSerifResource());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D6ADC Offset: 0x6D6ADC VA: 0x6D6ADC
		// // RVA: 0x18B9088 Offset: 0x18B9088 VA: 0x18B9088
		private IEnumerator Co_LoadCharaResource()
		{
			//0x18B956C
			bool isLoaded = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectedDecoCustom(m_charaId, 1, (IiconTexture image) =>
			{
				//0x18B92E8
				m_chara.enabled = true;
				image.Set(m_chara);
				isLoaded = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x18B941C
				return isLoaded;
			});
			IsLoadedChara = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6D6B54 Offset: 0x6D6B54 VA: 0x6D6B54
		// // RVA: 0x18B9114 Offset: 0x18B9114 VA: 0x18B9114
		private IEnumerator Co_LoadSerifResource()
		{
			//0x18B984C
			bool isLoaded = false;
			MenuScene.Instance.DecorationItemTextureCache.LoadForSelectSerif(m_frameType, (IiconTexture image) =>
			{
				//0x18B942C
				m_serifFrame.enabled = true;
				image.Set(m_serifFrame);
				isLoaded = true;
			});
			yield return new WaitUntil(() =>
			{
				//0x18B9560
				return isLoaded;
			});
			IsLoadedSerif = true;
		}

		// // RVA: 0x18B8ED4 Offset: 0x18B8ED4 VA: 0x18B8ED4
		private void Enter()
		{
			m_charaAnim.StartChildrenAnimGoStop("st_stop", "st_stop");
			m_serifAnim.StartChildrenAnimGoStop("st_stop", "st_stop");
		}
	}
}
