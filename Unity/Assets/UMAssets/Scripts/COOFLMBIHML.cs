

using System.Collections.Generic;

public class COOFLMBIHML
{
	public class IKBKEPGDGMJ
	{
		public int BCCHOBPJJKE_SceneId; // 0x8
		public int FCDKJAKLGMB; // 0xC
		public int MKNDAOHGOAK; // 0x10
	}

	public const int AHNFCNAHCJC = 100000;
	private List<IKBKEPGDGMJ> HDNPGKDFEJB = new List<IKBKEPGDGMJ>(); // 0x8
	private int DBOFPMOMPFH; // 0xC

	//// RVA: 0x1765828 Offset: 0x1765828 VA: 0x1765828
	public void KHEKNNFCAOI(int FKDCCLPGKDK, OKGLGHCBCJP_Database LKMHPJKIFDN, bool ECMMLBJNEKG = false)
	{
		List<int> rarityCnt = new List<int>();
		for(int i = 0; i < 10; i++)
		{
			rarityCnt.Add(0);
		}
		int total = 0;
		for (int i = 0; i < LKMHPJKIFDN.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate.Count; i++)
		{
			total += LKMHPJKIFDN.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[i].DNJEJEANJGL_Value;
		}
		for(int i = 0; i < LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
			int a = 0;
			if (!ECMMLBJNEKG)
				a = scene.LDMOHIKFDEK_Gdrp;
			else
				a = scene.FPHOPBNPCML_Odrp;
			if(a != 0 && scene.PPEGAKEIEGM_En == 2)
			{
				if(LKMHPJKIFDN.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[scene.EKLIPGELKCL_Rarity - 1].DNJEJEANJGL_Value > 0)
				{
					rarityCnt[scene.EKLIPGELKCL_Rarity - 1]++;
				}
			}
		}
		int c = LKMHPJKIFDN.HGLIIPFLMFB_Drop.BFNDKINIEOE_GameDropMaEq[FKDCCLPGKDK - 1];
		int d = LKMHPJKIFDN.HGLIIPFLMFB_Drop.CFECAEBGLIH_GameDropMaNe[FKDCCLPGKDK - 1];
		for (int i = 0; i < LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
			int a = 0;
			if (!ECMMLBJNEKG)
				a = scene.LDMOHIKFDEK_Gdrp;
			else
				a = scene.FPHOPBNPCML_Odrp;
			if (a != 0 && scene.PPEGAKEIEGM_En == 2)
			{
				if (LKMHPJKIFDN.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[scene.EKLIPGELKCL_Rarity - 1].DNJEJEANJGL_Value > 0)
				{
					int v = rarityCnt[scene.EKLIPGELKCL_Rarity - 1];
					int r = (v * 100000) / total;
					if(FKDCCLPGKDK != 4)
					{
						r = ((scene.FKDCCLPGKDK_Ma == FKDCCLPGKDK ? c : d) * r) / (c + d);
					}
					if(r > 0)
					{
						IKBKEPGDGMJ data = new IKBKEPGDGMJ();
						data.BCCHOBPJJKE_SceneId = scene.BCCHOBPJJKE_Id;
						data.MKNDAOHGOAK = r;
						HDNPGKDFEJB.Add(data);
					}
				}
			}
		}
		int cnt = 0;
		for (int i = 0; i < HDNPGKDFEJB.Count; i++)
		{
			cnt += HDNPGKDFEJB[i].MKNDAOHGOAK;
			HDNPGKDFEJB[i].FCDKJAKLGMB = cnt;
		}
		DBOFPMOMPFH = cnt;
	}

	//// RVA: 0x1766118 Offset: 0x1766118 VA: 0x1766118
	public int NEHHNEPPIBK()
	{
		TodoLogger.Log(0, "NEHHNEPPIBK");
		return 0;
	}
}
