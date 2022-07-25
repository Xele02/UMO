using UnityEngine;
using System.Collections.Generic;

public class JPAPJLIPNOK : CACGCMBKHDI_Request
{
	private bool CHEGCAOBBEA; // 0x80

	public string FPCIBJLJOFI { get; set; } // 0x7C LCFILOOJABA NOJDHDJNPAL IHJLOEIKMDI
	public IKAHKDKIGNA NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA { get { return CHEGCAOBBEA; } } //0x1BA51CC HGPAELCGELL

	// RVA: 0x1BA5024 Offset: 0x1BA5024 VA: 0x1BA5024 Slot: 12
	public override void DHLDNIEELHO() 
    {
        EBGACDGNCAA = SakashoAsset.GetAssetList(FPCIBJLJOFI, this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// RVA: 0x1BA5110 Offset: 0x1BA5110 VA: 0x1BA5110 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        CHEGCAOBBEA = false;
        BNJPAKLNOPA_WorkerThreadQueue.Add(this.JFEPLJOIFBI);
    }

	// RVA: 0x1BA51D4 Offset: 0x1BA51D4 VA: 0x1BA51D4 Slot: 15
	public override void NLDKLFODOJJ()
    {
        return;
    }

	// RVA: 0x1BA51D8 Offset: 0x1BA51D8 VA: 0x1BA51D8
	private void JFEPLJOIFBI()
    { 
        EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        NFEAMMJIMPG = new IKAHKDKIGNA();
        NFEAMMJIMPG.KHEKNNFCAOI(json);
        NFEAMMJIMPG.PNELHHHCFAI = FPCIBJLJOFI;
        CHEGCAOBBEA = true;
    }
}

public class IKAHKDKIGNA
{
	public List<GCGNICILKLD_AssetFileInfo> KGHAJGGMPKL; // 0x8
	public string GLMGHMCOMEC; // 0xC
	public string PNELHHHCFAI; // 0x10

	// // RVA: 0x8DB638 Offset: 0x8DB638 VA: 0x8DB638
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
        EDOHBJAPLPF_JsonData files = IDLHJIOMJBK[AFEHLCGHAEE.KGHAJGGMPKL/*files*/];
        int num = files.HNBFOAJIIAL_Count;
        KGHAJGGMPKL = new List<GCGNICILKLD_AssetFileInfo>(num);
        for(int i = 0; i < num; i++)
        {
            EDOHBJAPLPF_JsonData fileData = files[i];
            GCGNICILKLD_AssetFileInfo fileInfo = new GCGNICILKLD_AssetFileInfo();
            fileInfo.KHEKNNFCAOI_Load(fileData, i);
            KGHAJGGMPKL.Add(fileInfo);
        }
        GLMGHMCOMEC = (string)IDLHJIOMJBK[AFEHLCGHAEE.GLMGHMCOMEC/*base_url*/];
    }

	// // RVA: 0x8DB8C0 Offset: 0x8DB8C0 VA: 0x8DB8C0
	public bool PPCCFNAPHCH(string CKDFCDDOBDH)
	{
		for(int i = 0; i < KGHAJGGMPKL.Count; i++)
		{
			if (KGHAJGGMPKL[i].OIEAICNAMNB_LocalFileName == "/android/" + CKDFCDDOBDH)
				return true;
		}
		return false;
	}

	// // RVA: 0x8DBA08 Offset: 0x8DBA08 VA: 0x8DBA08
	// public GCGNICILKLD BIKLNKNFFMK(string CKDFCDDOBDH) { }
}
