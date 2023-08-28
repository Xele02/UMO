using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CommonMenuStackLabel : LayoutLabelScriptBase
	{
		public enum LabelType
		{
			_None = -2,
			_Undefined = -1,
			Home = 0,
			Present = 1,
			Friend = 2,
			Setting = 3,
			Unit = 4,
			Diva = 5,
			Plate = 6,
			Episode = 7,
			Story = 8,
			Free = 9,
			Quest = 10,
			Event = 11,
			Gacha = 12,
			Menu = 13,
			SimulationLive = 14,
			Shop = 15,
			CostumeUpgrade = 16,
			Operation = 17,
			BingoMission = 18,
			ValkyrieTuneUp = 19,
			LobbyMember = 20,
			BastStorage = 21,
			StampMaker = 22,
			Visit = 23,
			BlockList = 24,
			Search = 25,
			_Num = 26,
		}
		
		private static readonly string s_labelImageUvFormat = "cmn_back_title_{0:D2}"; // 0x0
		private const int s_labelBgLongLength = 14;
		private static readonly string[] s_groupToDescIdFormat = new string[20] {
			"header_desc_title{0:D3}", "header_desc_loginbonus{0:D3}", "header_desc_home{0:D3}", "header_desc_setting{0:D3}", "header_desc_story{0:D3}", "header_desc_free{0:D3}",
			"header_desc_gacha{0:D3}", "header_desc_option{0:D3}", "header_desc_result{0:D3}", "header_desc_free{0:D3}", "header_desc_quest{0:D3}", "header_desc_evquest{0:D3}",
			"header_desc_free{0:D3}", "header_desc_simulation_result{0:D3}", "header_desc_episode_appeal{0:D3}", "header_desc_lobby{0:D3}", "header_desc_home{0:D3}", "header_desc_musicrate{0:D3}",
			"header_desc_free{0:D3}", "header_desc_vop{0:D3}"
		}; // 0x4
		[SerializeField]
		private RawImageEx m_labelImage; // 0x18
		[SerializeField]
		private RectTransform m_labelImageRect; // 0x1C
		[SerializeField]
		private Vector2 m_labelTexSize; // 0x20
		[SerializeField]
		private Text m_description; // 0x28
		private List<Vector2> m_labelImageSizes; // 0x2C
		private List<Rect> m_labelUvRects; // 0x30
		private StringBuilder m_descIdBuilder = new StringBuilder(32); // 0x34
		private LayoutSymbolData m_symbolLabelBg; // 0x38

		//// RVA: 0x1B4A394 Offset: 0x1B4A394 VA: 0x1B4A394
		public void SetLabel(CommonMenuStackLabel.LabelType type)
		{
			m_labelImage.uvRect = m_labelUvRects[(int)type];
			m_labelImageRect.sizeDelta = m_labelImageSizes[(int)type];
		}

		//// RVA: 0x1B4A4B4 Offset: 0x1B4A4B4 VA: 0x1B4A4B4
		public void SetDescription(SceneGroupCategory group, int descId)
		{
			if(descId > -1)
			{
				m_descIdBuilder.SetFormat(s_groupToDescIdFormat[(int)group], descId);
				m_description.text = MessageManager.Instance.GetBank("menu").GetMessageByLabel(m_descIdBuilder.ToString());
				m_symbolLabelBg.StartAnim(m_description.text.Length < 14 ? "short" : "long");
			}
		}

		// RVA: 0x1B4B64C Offset: 0x1B4B64C VA: 0x1B4B64C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			StringBuilder str = new StringBuilder(s_labelImageUvFormat.Length);

			m_labelUvRects = new List<Rect>(26);
			m_labelImageSizes = new List<Vector2>(26);
			for(int i = 0; i < 26; i++)
			{
				str.SetFormat(s_labelImageUvFormat, i);
				Rect r = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(str.ToString()));
				m_labelUvRects.Add(r);
				float w = Mathf.RoundToInt(m_labelTexSize.x * r.width);
				float h = Mathf.RoundToInt(m_labelTexSize.y * r.height);
				m_labelImageSizes.Add(new Vector2(w, h));
			}
			m_description.text = string.Empty;
			m_symbolLabelBg = CreateSymbol("label_bg", layout);
			Loaded();
			return true;
		}
	}
}
