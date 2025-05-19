
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;

public class JKIJLMMLNPL
{
	private class GMJBEOLMJKB
	{
		public GCIJNCFDNON_SceneInfo COIODGJDJEJ_ViewScene; // 0x8
		public int ODNDCOMBAOH; // 0xC
		public int CGIKGNJJCIG; // 0x10
		public int BDLNMOIOMHK; // 0x14

		// RVA: 0x146948C Offset: 0x146948C VA: 0x146948C
		public void NCLLHLHCOJE()
		{
			int t = COIODGJDJEJ_ViewScene.CMCKNKKCNDK_Status.Total;
			BDLNMOIOMHK = (t * ODNDCOMBAOH) / 100 + t + (t * CGIKGNJJCIG) / 100;
		}
	}	

	public int LOAJLHEIMFD_MCannonDamageBase; // 0x8
	public int EDJHGLOKLEN_MCannonDamageUtaRate; // 0xC
	public int DMDHECLBECL_MCannonDamagePlate; // 0x10
	public int HALIDDHLNEG_MCannonDamage; // 0x14
	public GameAttribute.Type ACBHJKCJLON_SceneAttr; // 0x18
	public SeriesAttr.Type KOGEKHMBHOI_SceneSerie; // 0x1C
	public int GCMIDNBBMLA_SceneAttrBonus; // 0x20
	public int IDDAGCGIAPA_SceneSerieBonus; // 0x24
	public List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_MCannonPlate; // 0x28

	// RVA: 0x1468C38 Offset: 0x1468C38 VA: 0x1468C38
	public JKIJLMMLNPL()
	{
		ACBHJKCJLON_SceneAttr = GameAttribute.Type.None;
		KOGEKHMBHOI_SceneSerie = SeriesAttr.Type.None;
		GCMIDNBBMLA_SceneAttrBonus = 0;
		IDDAGCGIAPA_SceneSerieBonus = 0;
		OPIBAPEGCLA_MCannonPlate = new List<GCIJNCFDNON_SceneInfo>(100);
	}

	// RVA: 0x1468CD4 Offset: 0x1468CD4 VA: 0x1468CD4
	public void DEHCKHMIENO(Func<int, bool> CJNCOELLDFC)
	{
		int cnt = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes.Count;
		List<GMJBEOLMJKB> l = new List<GMJBEOLMJKB>();
		for(int i = 0; i < cnt; i++)
		{
			GCIJNCFDNON_SceneInfo viewscene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[i];
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[viewscene.BCCHOBPJJKE_SceneId - 1];
			if(dbScene.PPEGAKEIEGM_En == 2)
			{
				if(viewscene.CGKAEMGLHNK_IsUnlocked() && !viewscene.MCCIFLKCNKO_Feed && (CJNCOELLDFC == null || !CJNCOELLDFC(viewscene.BCCHOBPJJKE_SceneId)))
				{
					GMJBEOLMJKB data = new GMJBEOLMJKB();
					data.COIODGJDJEJ_ViewScene = viewscene;
					if((byte)ACBHJKCJLON_SceneAttr == viewscene.JGJFIJOCPAG_SceneAttr)
					{
						data.ODNDCOMBAOH = GCMIDNBBMLA_SceneAttrBonus;
					}
					if(viewscene.AIHCEGFANAM_SceneSeries == KOGEKHMBHOI_SceneSerie)
					{
						data.CGIKGNJJCIG = IDDAGCGIAPA_SceneSerieBonus;
					}
					data.NCLLHLHCOJE();
					l.Add(data);
				}
			}
		}
		l.Sort((GMJBEOLMJKB HKICMNAACDA, GMJBEOLMJKB BNKHBCBJBKI) =>
		{
			//0x14696C0
			return BNKHBCBJBKI.BDLNMOIOMHK - HKICMNAACDA.BDLNMOIOMHK;
		});
		cnt = Mathf.Min(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("mcannon_plate_max", 100), l.Count);
		int val = 0;
		for(int i = 0; i < cnt; i++)
		{
			OPIBAPEGCLA_MCannonPlate.Add(l[i].COIODGJDJEJ_ViewScene);
			val += l[i].BDLNMOIOMHK;
		}
		LOAJLHEIMFD_MCannonDamageBase = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("mcannon_damage_base", 10000);
		EDJHGLOKLEN_MCannonDamageUtaRate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("mcannon_damage_urate", 10000) * GameManager.Instance.ViewPlayerData.BJGOPOEAAIC;
		DMDHECLBECL_MCannonDamagePlate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("mcannon_damage_plate", 10) * val;
		HALIDDHLNEG_MCannonDamage = (EDJHGLOKLEN_MCannonDamageUtaRate + LOAJLHEIMFD_MCannonDamageBase + DMDHECLBECL_MCannonDamagePlate) / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("mcannon_damage_denomi", 1000);
	}

	// RVA: 0x1469518 Offset: 0x1469518 VA: 0x1469518
	public static void DJNPDEOLNHD_UpdateMacrossCannonPower()
	{
		JKIJLMMLNPL data = new JKIJLMMLNPL();
		data.DEHCKHMIENO(null);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.OENMBJEKJII_McPower = data.HALIDDHLNEG_MCannonDamage;
	}
}
