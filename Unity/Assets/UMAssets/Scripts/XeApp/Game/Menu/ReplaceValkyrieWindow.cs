using System.Linq;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ReplaceValkyrieWindow : LayoutUGUIScriptBase
	{
		private class StatusLayout
		{
			public RawImageEx logo_image; // 0x8
			public RawImageEx valkyrie_image; // 0xC
			public Text valkyrie_name; // 0x10
			public Text pilot_name; // 0x14
			public Text attack_value; // 0x18
			public Text hit_value; // 0x1C
		}

		private StatusLayout[] m_StatusLayout = new StatusLayout[2]; // 0x14
		private RawImageEx m_CompIconAtk; // 0x18
		private RawImageEx m_CompIconHit; // 0x1C
		private TexUVList m_CmnTexUvList; // 0x20

		// RVA: 0xCFC9A0 Offset: 0xCFC9A0 VA: 0xCFC9A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			for (int i = 0; i < 2; i++)
			{
				m_StatusLayout[i] = new StatusLayout();
				RawImageEx[] ims = transform.Find("sw_val_status_all (AbsoluteLayout)/" + "sw_card_status_" + (i == 0 ? "l" : "r") + " (AbsoluteLayout)").GetComponentsInChildren<RawImageEx>();
				m_StatusLayout[i].logo_image = ims.Where((RawImageEx _) =>
				{
					//0xCFE47C
					return _.name == "swtexc_cmn_logo (ImageView)";
				}).First();
				m_StatusLayout[i].valkyrie_image = ims.Where((RawImageEx _) =>
				{
					//0xCFE4FC
					return _.name == "swtexc_cmn_val_m02 (ImageView)";
				}).First();
				if (i == 1)
				{
					m_CompIconAtk = ims.Where((RawImageEx _) =>
					{
						//0xCFE57C
						return _.name == "cmn_status_icon_up_attack (ImageView)";
					}).First();
					m_CompIconHit = ims.Where((RawImageEx _) =>
					{
						//0xCFE5FC
						return _.name == "cmn_status_icon_up_hit (ImageView)";
					}).First();
				}
				Text[] txts = transform.GetComponentsInChildren<Text>();
				m_StatusLayout[i].valkyrie_name = txts.Where((Text _) =>
				{
					//0xCFE67C
					return _.name == "valkyrie_name_01 (TextView)";
				}).First();
				m_StatusLayout[i].pilot_name = txts.Where((Text _) =>
				{
					//0xCFE6FC
					return _.name == "pilot_name_01 (TextView)";
				}).First();
				m_StatusLayout[i].attack_value = txts.Where((Text _) =>
				{
					//0xCFE77C
					return _.name == "attack_01 (TextView)";
				}).First();
				m_StatusLayout[i].hit_value = txts.Where((Text _) =>
				{
					//0xCFE7FC
					return _.name == "hit_01 (TextView)";
				}).First();
			}
			m_CmnTexUvList = uvMan.GetTexUVList("cmn_tex_pack");
			Loaded();
			return true;
		}

		// RVA: 0xCFD898 Offset: 0xCFD898 VA: 0xCFD898
		public void Start()
		{
			return;
		}

		// RVA: 0xCFD89C Offset: 0xCFD89C VA: 0xCFD89C
		public void Update()
		{
			return;
		}

		//// RVA: 0xCFD8A0 Offset: 0xCFD8A0 VA: 0xCFD8A0
		private void ApplyValkyrieData(PNGOLKLFFLH before, PNGOLKLFFLH after, NHDJHOPLMDE before_ab, NHDJHOPLMDE after_ab)
		{
			for (int i = 0; i < 2; i++)
			{
				PNGOLKLFFLH data = i == 0 ? before : after;
				NHDJHOPLMDE data_ab = i == 0 ? before_ab : after_ab;
				int index = i;
				MenuScene.Instance.MenuResidentTextureCache.LoadLogo((int)SeriesLogoId.ConvertFromAttr((SeriesAttr.Type)data.AIHCEGFANAM_Serie), (IiconTexture texture) =>
				{
					//0xCFE87C
					texture.Set(m_StatusLayout[index].logo_image);
				});
				MenuScene.Instance.ValkyrieIconCache.LoadPortraitIcon(data.GPPEFLKGGGJ_ValkyrieId, 0, (IiconTexture texture) =>
				{
					//0xCFE9BC
					texture.Set(m_StatusLayout[index].valkyrie_image);
				});
				m_StatusLayout[i].valkyrie_name.text = data.IJBLEJOKEFH_ValkyrieName;
				m_StatusLayout[i].pilot_name.text = data.OPBPKNHIPPE_Pilot.OPFGFINHFCE_Name;
				m_StatusLayout[i].attack_value.text = data.KINFGHHNFCF_Atk.ToString();
				m_StatusLayout[i].hit_value.text = data.NONBCCLGBAO_Hit.ToString();
				if (data_ab != null)
				{
					m_StatusLayout[i].attack_value.text = (data.KINFGHHNFCF_Atk + data_ab.KINFGHHNFCF_Atk).ToString();
					m_StatusLayout[i].hit_value.text = (data.NONBCCLGBAO_Hit + data_ab.NONBCCLGBAO_Hit).ToString();
					ApplyComparisonValue(before.KINFGHHNFCF_Atk + (before_ab != null ? before_ab.KINFGHHNFCF_Atk : 0), after.KINFGHHNFCF_Atk + (after_ab != null ? after_ab.KINFGHHNFCF_Atk : 0), m_StatusLayout[i].attack_value, m_CompIconAtk);
					ApplyComparisonValue(before.NONBCCLGBAO_Hit + (before_ab != null ? before_ab.NONBCCLGBAO_Hit : 0), after.NONBCCLGBAO_Hit + (after_ab != null ? after_ab.NONBCCLGBAO_Hit : 0), m_StatusLayout[i].hit_value, m_CompIconHit);
				}
			}
		}

		//// RVA: 0xCFE05C Offset: 0xCFE05C VA: 0xCFE05C
		private void ApplyComparisonValue(int before, int after, Text text, RawImageEx image)
		{
			if (before < after)
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.UpColor);
				image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_CmnTexUvList.GetUVData("cmn_status_icon_up"));
			}
			else if (before == after)
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.NormalColor);
				image.enabled = false;
				return;
			}
			else
			{
				RichTextUtility.ChangeColor(text, StatusTextColor.DownColor);
				image.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_CmnTexUvList.GetUVData("cmn_status_icon_down"));
			}
			image.enabled = true;
		}

		//// RVA: 0xCFE36C Offset: 0xCFE36C VA: 0xCFE36C
		public void SetValkyrieData(PNGOLKLFFLH before, PNGOLKLFFLH after, NHDJHOPLMDE before_ab, NHDJHOPLMDE after_ab)
		{
			ApplyValkyrieData(before, after, before_ab, after_ab);
		}
	}
}
