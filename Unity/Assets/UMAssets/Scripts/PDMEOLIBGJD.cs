
using System;
using System.Text.RegularExpressions;

public class PDMEOLIBGJD : IKMBBPDBECA
{
	// RVA: 0xCC1EC0 Offset: 0xCC1EC0 VA: 0xCC1EC0 Slot: 4
	public override void KHEKNNFCAOI(string DLENPPIJNPA)
    {
		EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(DLENPPIJNPA);
		if(data.BBAJPINMOEP_Contains("name"))
		{
			OPFGFINHFCE_Name = (string)data["name"];
		}
		if(data.BBAJPINMOEP_Contains("desc"))
		{
			KLMPFGOCBHC_Description = (string)data["desc"];
		}
		if(data.BBAJPINMOEP_Contains("feature"))
		{
			string s = (string)data["feature"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					CEBFFLDKAEC_SecureInt sint = new CEBFFLDKAEC_SecureInt();
					sint.DNJEJEANJGL_Value = a;
					PGKIHFOKEHL_Feature.Add(sint);
				}
			}
		}
		if(data.BBAJPINMOEP_Contains("pickup"))
		{
			string s = (string)data["pickup"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					CEBFFLDKAEC_SecureInt sint = new CEBFFLDKAEC_SecureInt();
					sint.DNJEJEANJGL_Value = a;
					FLADABCFDFA_Pickup.Add(sint);
				}
			}
		}
		if(data.BBAJPINMOEP_Contains("episode"))
		{
			string s = (string)data["episode"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					CEBFFLDKAEC_SecureInt sint = new CEBFFLDKAEC_SecureInt();
					sint.DNJEJEANJGL_Value = a;
					IOKIFFAFPDI_Episode.Add(sint);
				}
			}
		}
		MDEIKCBEHHC = "";
		if(data.BBAJPINMOEP_Contains("kakutei"))
		{
            MDEIKCBEHHC = data["kakutei"].ToString();
            if(Regex.IsMatch(MDEIKCBEHHC, JpStringLiterals.StringLiteral_13053))
            {
                string s = Regex.Replace(Regex.Match(MDEIKCBEHHC, JpStringLiterals.StringLiteral_13053).Value, "[0-9]", (Match MABBBOEAPAA) =>
                {
                    //0xCC431C
                    return Convert.ToChar(MABBBOEAPAA.Value[0] + 65248).ToString();
                });
                MDEIKCBEHHC = Regex.Replace(MDEIKCBEHHC, JpStringLiterals.StringLiteral_13053, s);
            }
		}
		MFICPBJPCCJ_GachaBgId = 0;
		HNKHCIDOKFF_PlateBgId = 0;
		if(data.BBAJPINMOEP_Contains("bg_id"))
		{
			if(data["bg_id"].MDDJBLEDMBJ_IsInt)
			{
				HNKHCIDOKFF_PlateBgId = (int)data["bg_id"];
			}
			if(data["bg_id"].EPNAPDBIJJE_IsString)
			{
				string s = (string)data["bg_id"];
				string[] strs = s.Split(new char[] { '=' });
				if(strs.Length > 1)
				{
					if(strs[0].Contains("gc"))
					{
						int v = 0;
						if(int.TryParse(strs[1], out v))
							MFICPBJPCCJ_GachaBgId = v;
					}
					if(strs[0].Contains("pl"))
					{
						int v = 0;
						if(int.TryParse(strs[1], out v))
							HNKHCIDOKFF_PlateBgId = v;
					}
				}
			}
		}
		INHOGJODJFJ_GroupId = 0;
		if(data.BBAJPINMOEP_Contains("group_id"))
		{
			INHOGJODJFJ_GroupId = (int)data["group_id"];
		}
		MJNOAMAFNHA_CostItemId = 0;
		if(data.BBAJPINMOEP_Contains("cost_item_id"))
		{
			MJNOAMAFNHA_CostItemId = (int)data["cost_item_id"];
		}
		if(data.BBAJPINMOEP_Contains("ticket_vcid"))
		{
			string s = (string)data["ticket_vcid"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					CEBFFLDKAEC_SecureInt sint = new CEBFFLDKAEC_SecureInt();
					sint.DNJEJEANJGL_Value = a;
					ANFKCPGENCM_TicketVcId.Add(sint);
				}
			}
		}
		if(data.BBAJPINMOEP_Contains("templ"))
		{
			OKDLGFMLLFH_Templ = (string)data["templ"];
		}
		EIODHCIJDKO_Label = "";
		if(data.BBAJPINMOEP_Contains("label"))
		{
			EIODHCIJDKO_Label = (string)data["label"];
		}
		NEBCAAGLDHA_FreeSingle = "";
		if(data.BBAJPINMOEP_Contains("free_single"))
		{
			NEBCAAGLDHA_FreeSingle = (string)data["free_single"];
		}
		MKJPDIHLGBF_FreeMulti = "";
		if(data.BBAJPINMOEP_Contains("free_multi"))
		{
			MKJPDIHLGBF_FreeMulti = (string)data["free_multi"];
		}
		if(data.BBAJPINMOEP_Contains("close_at"))
		{
			if(data["close_at"].EPNAPDBIJJE_IsString)
			{
				EABMLBFHJBH_CloseAtString = (string)data["close_at"];
			}
		}
		if(data.BBAJPINMOEP_Contains("open_time"))
		{
			JOFAGCFNKIO_OpenTime = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(data, "open_time");
		}
		if(data.BBAJPINMOEP_Contains("new_episode"))
		{
			string s = (string)data["new_episode"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					HGBOODNMNFM d = new HGBOODNMNFM();
					d.KELFCMEOPPM_EpisodeId = a;
					NNDMIOEKKMM_NewEpisode.Add(d);
				}
			}
		}
		if(data.BBAJPINMOEP_Contains("new_scene"))
		{
			string s = (string)data["new_scene"];
			string[] strs = s.Split(new char[] { ',' });
			for(int i = 0; i < strs.Length; i++)
			{
				int a = 0;
				if(int.TryParse(strs[i], out a))
				{
					CEBFFLDKAEC_SecureInt d = new CEBFFLDKAEC_SecureInt();
					d.DNJEJEANJGL_Value = a;
					int ep = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[a - 1].KELFCMEOPPM_Ep;
					HGBOODNMNFM h = NNDMIOEKKMM_NewEpisode.Find((HGBOODNMNFM GHPLINIACBB) =>
					{
						//0xCC4394
						return ep == GHPLINIACBB.KELFCMEOPPM_EpisodeId;
					});
					if(h != null)
					{
						h.ADDCEJNOJLG_Scenes.Add(d);
					}
				}
			}
		}
		if(data.BBAJPINMOEP_Contains("banner_id"))
		{
			OPKCNBFBBKP_BannerId = (int)data["banner_id"];
		}
		LEJAMOFMMPA_HasOneDay = false;
		ABNMIDCBENB_OneDay = 0;
		if(data.BBAJPINMOEP_Contains("one_day"))
		{
			LEJAMOFMMPA_HasOneDay = true;
			ABNMIDCBENB_OneDay = (int)data["one_day"];
		}
		FPFECIDDNFA_LinkId = 0;
		MPHNHBBJDGP_LinkCount = 0;
		if(data.BBAJPINMOEP_Contains("link_id"))
		{
			FPFECIDDNFA_LinkId = (int)data["link_id"];
		}
		if(data.BBAJPINMOEP_Contains("link_count"))
		{
			MPHNHBBJDGP_LinkCount = (int)data["link_count"];
		}
		if(data.BBAJPINMOEP_Contains("day_count"))
		{
			KNMNJDKJHDM_HasDayCount = (int)data["day_count"] > 0;
		}
		IMCNDJMDNJE_DisableCarousel = false;
		if(data.BBAJPINMOEP_Contains("disable_carousel"))
		{
			IMCNDJMDNJE_DisableCarousel = (int)data["disable_carousel"] != 0;
		}
		EEFLOOBOAGF_ViewOrder = 0;
		if(data.BBAJPINMOEP_Contains("view_order"))
		{
			EEFLOOBOAGF_ViewOrder = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(data, "view_order");
		}
		BJIMIONBKDD_ShowPopup = true;
		if(data.BBAJPINMOEP_Contains("show_popup"))
		{
			BJIMIONBKDD_ShowPopup = (int)data["show_popup"] != 0;
		}
		FHHKLJCJNNC_FreeBadgeMess = "";
		if(data.BBAJPINMOEP_Contains("free_badge_mess"))
		{
			FHHKLJCJNNC_FreeBadgeMess = (string)data["free_badge_mess"];
		}
		JFDOLJDCCDJ_FreeTextureId = 0;
		if(data.BBAJPINMOEP_Contains("free_texture_id"))
		{
			JFDOLJDCCDJ_FreeTextureId = (int)data["free_texture_id"];
		}
		CICLLABDFFK_SaleButtonVisible = true;
		if(data.BBAJPINMOEP_Contains("sale_button_visible"))
		{
			CICLLABDFFK_SaleButtonVisible = (int)data["sale_button_visible"] != 0;
		}
    }
}
