
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;

public class JKIJLMMLNPL
{
	private class GMJBEOLMJKB
	{
		public GCIJNCFDNON_SceneInfo COIODGJDJEJ_scene; // 0x8
		public int ODNDCOMBAOH; // 0xC
		public int CGIKGNJJCIG; // 0x10
		public int BDLNMOIOMHK_total; // 0x14

		// RVA: 0x146948C Offset: 0x146948C VA: 0x146948C
		public void NCLLHLHCOJE()
		{
			int t = COIODGJDJEJ_scene.CMCKNKKCNDK_status.Total;
			BDLNMOIOMHK_total = (t * ODNDCOMBAOH) / 100 + t + (t * CGIKGNJJCIG) / 100;
		}
	}	

	public int LOAJLHEIMFD_MCannonDamageBase; // 0x8
	public int EDJHGLOKLEN_MCannonDamageUtaRate; // 0xC
	public int DMDHECLBECL_MCannonDamagePlate; // 0x10
	public int HALIDDHLNEG_Damage; // 0x14
	public GameAttribute.Type ACBHJKCJLON_SceneAttr; // 0x18
	public SeriesAttr.Type KOGEKHMBHOI_SceneSerie; // 0x1C
	public int GCMIDNBBMLA_SceneAttrBonus; // 0x20
	public int IDDAGCGIAPA_SceneSerieBonus; // 0x24
	public List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_Scenes; // 0x28

	// RVA: 0x1468C38 Offset: 0x1468C38 VA: 0x1468C38
	public JKIJLMMLNPL()
	{
		ACBHJKCJLON_SceneAttr = GameAttribute.Type.None;
		KOGEKHMBHOI_SceneSerie = SeriesAttr.Type.None;
		GCMIDNBBMLA_SceneAttrBonus = 0;
		IDDAGCGIAPA_SceneSerieBonus = 0;
		OPIBAPEGCLA_Scenes = new List<GCIJNCFDNON_SceneInfo>(100);
	}

	// RVA: 0x1468CD4 Offset: 0x1468CD4 VA: 0x1468CD4
	public void DEHCKHMIENO(Func<int, bool> CJNCOELLDFC)
	{
		int cnt = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Count;
		List<GMJBEOLMJKB> l = new List<GMJBEOLMJKB>();
		for(int i = 0; i < cnt; i++)
		{
			GCIJNCFDNON_SceneInfo viewscene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[i];
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[viewscene.BCCHOBPJJKE_SceneId - 1];
			if(dbScene.PPEGAKEIEGM_Enabled == 2)
			{
				if(viewscene.FJODMPGPDDD_Unlocked && !viewscene.MCCIFLKCNKO_Feed && (CJNCOELLDFC == null || !CJNCOELLDFC(viewscene.BCCHOBPJJKE_SceneId)))
				{
					GMJBEOLMJKB data = new GMJBEOLMJKB();
					data.COIODGJDJEJ_scene = viewscene;
					if((byte)ACBHJKCJLON_SceneAttr == viewscene.JGJFIJOCPAG_SceneAttr)
					{
						data.ODNDCOMBAOH = GCMIDNBBMLA_SceneAttrBonus;
					}
					if(viewscene.AIHCEGFANAM_SerieAttr == KOGEKHMBHOI_SceneSerie)
					{
						data.CGIKGNJJCIG = IDDAGCGIAPA_SceneSerieBonus;
					}
					data.NCLLHLHCOJE();
					l.Add(data);
				}
			}
		}
		l.Sort((GMJBEOLMJKB _HKICMNAACDA_a, GMJBEOLMJKB _BNKHBCBJBKI_b) =>
		{
			//0x14696C0
			return _BNKHBCBJBKI_b.BDLNMOIOMHK_total - _HKICMNAACDA_a.BDLNMOIOMHK_total;
		});
		cnt = Mathf.Min(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_plate_max", 100), l.Count);
		int val = 0;
		for(int i = 0; i < cnt; i++)
		{
			OPIBAPEGCLA_Scenes.Add(l[i].COIODGJDJEJ_scene);
			val += l[i].BDLNMOIOMHK_total;
		}
		LOAJLHEIMFD_MCannonDamageBase = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_damage_base", 10000);
		EDJHGLOKLEN_MCannonDamageUtaRate = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_damage_urate", 10000) * GameManager.Instance.ViewPlayerData.BJGOPOEAAIC_UtaRate;
		DMDHECLBECL_MCannonDamagePlate = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_damage_plate", 10) * val;
		HALIDDHLNEG_Damage = (EDJHGLOKLEN_MCannonDamageUtaRate + LOAJLHEIMFD_MCannonDamageBase + DMDHECLBECL_MCannonDamagePlate) / IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("mcannon_damage_denomi", 1000);
	}

	// RVA: 0x1469518 Offset: 0x1469518 VA: 0x1469518
	public static void DJNPDEOLNHD_UpdateMacrossCannonPower()
	{
		JKIJLMMLNPL data = new JKIJLMMLNPL();
		data.DEHCKHMIENO(null);
		CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower = data.HALIDDHLNEG_Damage;
	}
}
