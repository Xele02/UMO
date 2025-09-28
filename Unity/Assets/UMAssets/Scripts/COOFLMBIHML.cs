

using System.Collections.Generic;

public class COOFLMBIHML
{
	public class IKBKEPGDGMJ
	{
		public int BCCHOBPJJKE_SceneId; // 0x8
		public int FCDKJAKLGMB_TargetValue; // 0xC
		public int MKNDAOHGOAK_weight; // 0x10
	}

	public const int AHNFCNAHCJC = 100000;
	private List<IKBKEPGDGMJ> HDNPGKDFEJB = new List<IKBKEPGDGMJ>(); // 0x8
	private int DBOFPMOMPFH; // 0xC

	//// RVA: 0x1765828 Offset: 0x1765828 VA: 0x1765828
	public void KHEKNNFCAOI_Init(int _FKDCCLPGKDK_JacketAttr, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, bool ECMMLBJNEKG/* = false*/)
	{
		List<int> rarityCnt = new List<int>();
		for(int i = 0; i < 10; i++)
		{
			rarityCnt.Add(0);
		}
		int total = 0;
		for (int i = 0; i < _LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate.Count; i++)
		{
			total += _LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[i].DNJEJEANJGL_Value;
		}
		for(int i = 0; i < _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			int a = 0;
			if (!ECMMLBJNEKG)
				a = scene.LDMOHIKFDEK_Gdrp;
			else
				a = scene.FPHOPBNPCML_Odrp;
			if(a != 0 && scene.PPEGAKEIEGM_Enabled == 2)
			{
				if(_LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[scene.EKLIPGELKCL_Rarity - 1].DNJEJEANJGL_Value > 0)
				{
					rarityCnt[scene.EKLIPGELKCL_Rarity - 1]++;
				}
			}
		}
		int c = _LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.BFNDKINIEOE_GameDropMaEq[_FKDCCLPGKDK_JacketAttr - 1];
		int d = _LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.CFECAEBGLIH_GameDropMaNe[_FKDCCLPGKDK_JacketAttr - 1];
		for (int i = 0; i < _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN scene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			int a = 0;
			if (!ECMMLBJNEKG)
				a = scene.LDMOHIKFDEK_Gdrp;
			else
				a = scene.FPHOPBNPCML_Odrp;
			if (a != 0 && scene.PPEGAKEIEGM_Enabled == 2)
			{
				if (_LKMHPJKIFDN_md.HGLIIPFLMFB_Drop.BNFPHOEFKBA_GameDropRate[scene.EKLIPGELKCL_Rarity - 1].DNJEJEANJGL_Value > 0)
				{
					int v = rarityCnt[scene.EKLIPGELKCL_Rarity - 1];
					int r = (v * 100000) / total;
					if(_FKDCCLPGKDK_JacketAttr != 4)
					{
						r = ((scene.FKDCCLPGKDK_JacketAttr == _FKDCCLPGKDK_JacketAttr ? c : d) * r) / (c + d);
					}
					if(r > 0)
					{
						IKBKEPGDGMJ data = new IKBKEPGDGMJ();
						data.BCCHOBPJJKE_SceneId = scene.BCCHOBPJJKE_SceneId;
						data.MKNDAOHGOAK_weight = r;
						HDNPGKDFEJB.Add(data);
					}
				}
			}
		}
		int cnt = 0;
		for (int i = 0; i < HDNPGKDFEJB.Count; i++)
		{
			cnt += HDNPGKDFEJB[i].MKNDAOHGOAK_weight;
			HDNPGKDFEJB[i].FCDKJAKLGMB_TargetValue = cnt;
		}
		DBOFPMOMPFH = cnt;
	}

	//// RVA: 0x1766118 Offset: 0x1766118 VA: 0x1766118
	public int NEHHNEPPIBK()
	{
		int rnd = UnityEngine.Random.Range(0, DBOFPMOMPFH);
		int idx = 0;
		for(int i = 0; i < HDNPGKDFEJB.Count; i++)
		{
			if(HDNPGKDFEJB[i].FCDKJAKLGMB_TargetValue > rnd)
			{
				idx = i;
				break;
			}
		}
		return HDNPGKDFEJB[idx].BCCHOBPJJKE_SceneId;
	}
}
