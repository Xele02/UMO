
using System.Collections.Generic;

public class NPOOPJIOMHF { }
public class NPOOPJIOMHF_Prism : KLFDBFMNLBL_SaveBlock
{
	public class CLGGEONAHPL_TeamSelectionSetting
	{
		public int PPFNGGCBJKC { get; set; } // 0x8  FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
		public int OCAMDLMPBGA_SelectedDivaSoloId { get; set; } // 0xC  JKDMAFHPKDJ DHOGDENEIOI DBDFNFLGDFN
		public int PGCEGEJOOON_SelectedCostumeSoloId { get; set; } // 0x10 LBLNPAKCIHN BJKANAJCKJJ IMCNLEMAKCL
		public int IAFIKNONLJF_SelectedCostumeColorSoloId { get; set; } // 0x14 NPOJFHOFBPH EHNBEEJHDLA PAEBFDHCHAN
		public int EPDPAHNLMKH_SelectedValkyrieSoloId { get; set; } // 0x18 HJLOLGLNLCA BFFLALNNIKK CNNFHPDGEPE
		public int PLALNIIBLOF { get; set; } // 0x1C DFMNDOMAPAB JPCJNLHHIPE JJFJNEJLBDG
		public int MKKGKKHABEK_ValkyrieMode { get; set; } // 0x20 GKMEIOCLJFA IDKGINELPLK JDLJNLOADHG
		public int JPBJOGBGKGA_DivaMode { get; set; } // 0x24 LPBDPIKDEDC AIMDOKAFGKM PGMKINKKNIF
		public int NLFMKOJHAHJ_ShowNotes { get; set; } // 0x28 NKBLDLKFDLA HDDMCLEAEHN IMGNMJHPPKP
		public int AIPJAKIFMPN_SelectedDiva0Id { get; set; } // 0x2C FHAKLKNIAFC PDFFGBBKILE HLEPFOEMEJK
		public int JMAGFEENOED_SelectedDiva1Id { get; set; } // 0x30 GLKLOAGDFDK GDPLEDJGNJO GGLKCLOJNBP
 		public int LFHILMNKGCB_SelectedDiva2Id { get; set; } // 0x34 ANOAMMHNHCC LOJMJIOKDNE ICPOICEMPCC
		public int OLKOJOACIBD_SelectedDiva3Id { get; set; } // 0x38 FNKNIHBMPAG JDFCLDKKJPE JFAHGDELEGL
		public int INBGAKAAJPB_SelectedDiva4Id { get; set; } // 0x3C GIIMBPCNIJK CEHMGMABOCK PEIEKMLPAPP
		public int FHFONPEHLMN_SelectedCostume0Id { get; set; } // 0x40 FNEOMJMPGIE FAPNEFPMOHH LNIDPBADCKC
		public int HPPOFOIJJMB_SelectedCostume1Id { get; set; } // 0x44 FKPCGPBNEJG AFOFDIDKFIP OPELHGPPFMH
		public int NBPNNNBCGFG_SelectedCostume2Id { get; set; } // 0x48 HIKEKGBELIJ NOELAAJGMPC ALIFKLDBPOK
		public int LLKEMHHHLEN_SelectedCostume3Id { get; set; } // 0x4C NOOLEOPFOEL CBKBHPCNOEO GCHEHHMPAMM
		public int DGDLPGFKCFA_SelectedCostume4Id { get; set; } // 0x50 OODLJLEKEAC ELNEKAKEBCA JNHKBCKBJKP
		public int ADLOGNCDIFG_SelectedCostumeColor0Id { get; set; } // 0x54 LODCCPIGBDM MFBJJBPLDIE BIHGOABBDCM
		public int DFHNEEBKEIC_SelectedCostumeColor1Id { get; set; } // 0x58 MPDOHPENCIN DHEJFLFAIGJ KNIBDIFNCBK
		public int BFMDCDFAJKE_SelectedCostumeColor2Id { get; set; } // 0x5C OMDJFDAAEGM PNKONHJPADN AKPFBBDBEKI
		public int OHCNKIKIGHM_SelectedCostumeColor3Id { get; set; } // 0x60 EOLBKCFOCAB FMBGIOHLENJ GIELMDLGBIM
		public int HDKHGAACNFG_SelectedCostumecolor4Id { get; set; } // 0x64 MNNBEKJIAPN HKOOFEICKBG NPOFHAKEPDO
		public int PIJEEAOMMGA_SelectedValkyrie { get; set; } // 0x68 MOPHNDHDLNC MNNMJGCFHKD ELNIKMIIGIP

		// // RVA: 0x1CBE168 Offset: 0x1CBE168 VA: 0x1CBE168
		// public bool CHFOOMPEABN() { }

		// // RVA: 0x1CB83C4 Offset: 0x1CB83C4 VA: 0x1CB83C4
		// public void ODDIHGPONFL(NPOOPJIOMHF.CLGGEONAHPL GPBJHKLFCEP) { }

		// // RVA: 0x1CB88DC Offset: 0x1CB88DC VA: 0x1CB88DC
		// public bool AGBOGBEOFME(NPOOPJIOMHF.CLGGEONAHPL OIKJFMGEICL) { }

		// // RVA: 0x1CB8EA8 Offset: 0x1CB8EA8 VA: 0x1CB8EA8
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NPOOPJIOMHF.CLGGEONAHPL OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	// private const int ECFEMKGFDCE = 3;
	// public static string POFDDFCGEGP = "_"; // 0x0

	public List<NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting> AHBBMJANGHE_TeamSelectionBySongs { get; private set; } // 0x24 DLDLMEDGOBA MELKCNPOKKB CEGODGDEJGN
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1CB6740 Offset: 0x1CB6740 VA: 0x1CB6740
	public NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting GCINIJEMHFK_GetTeamForSong(int PPFNGGCBJKC)
	{
		int index = 0;
		if(PPFNGGCBJKC > 0)
			index = PPFNGGCBJKC - 1;
		return AHBBMJANGHE_TeamSelectionBySongs[index];
	}

	// // RVA: 0x1CB67CC Offset: 0x1CB67CC VA: 0x1CB67CC
	// public bool DFIGPDCBAPB(int PPFNGGCBJKC) { }

	// // RVA: 0x1CB6A28 Offset: 0x1CB6A28 VA: 0x1CB6A28
	public NPOOPJIOMHF_Prism()
	{
		AHBBMJANGHE_TeamSelectionBySongs = new List<CLGGEONAHPL_TeamSelectionSetting>(300);
		KMBPACJNEOF();
	}

	// // RVA: 0x1CB6ACC Offset: 0x1CB6ACC VA: 0x1CB6ACC Slot: 4
	public override void KMBPACJNEOF()
	{
		AHBBMJANGHE_TeamSelectionBySongs.Clear();
		for(int i = 0; i <= 299; i++)
		{
			NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting data = new NPOOPJIOMHF_Prism.CLGGEONAHPL_TeamSelectionSetting();
			data.PPFNGGCBJKC = i+1;
			data.OCAMDLMPBGA_SelectedDivaSoloId = 0;
			data.PGCEGEJOOON_SelectedCostumeSoloId = 0;
			data.IAFIKNONLJF_SelectedCostumeColorSoloId = 0;
			data.EPDPAHNLMKH_SelectedValkyrieSoloId = 0;
			data.PLALNIIBLOF = 0;
			data.MKKGKKHABEK_ValkyrieMode = 0;
			data.JPBJOGBGKGA_DivaMode = 0;
			data.NLFMKOJHAHJ_ShowNotes = 1;
			data.AIPJAKIFMPN_SelectedDiva0Id = 0;
			data.JMAGFEENOED_SelectedDiva1Id = 0;
			data.LFHILMNKGCB_SelectedDiva2Id = 0;
			data.OLKOJOACIBD_SelectedDiva3Id = 0;
			data.INBGAKAAJPB_SelectedDiva4Id = 0;
			data.FHFONPEHLMN_SelectedCostume0Id = 0;
			data.HPPOFOIJJMB_SelectedCostume1Id = 0;
			data.NBPNNNBCGFG_SelectedCostume2Id = 0;
			data.LLKEMHHHLEN_SelectedCostume3Id = 0;
			data.DGDLPGFKCFA_SelectedCostume4Id = 0;
			data.ADLOGNCDIFG_SelectedCostumeColor0Id = 0;
			data.DFHNEEBKEIC_SelectedCostumeColor1Id = 0;
			data.BFMDCDFAJKE_SelectedCostumeColor2Id = 0;
			data.OHCNKIKIGHM_SelectedCostumeColor3Id = 0;
			data.HDKHGAACNFG_SelectedCostumecolor4Id = 0;
			data.PIJEEAOMMGA_SelectedValkyrie = 0;
			AHBBMJANGHE_TeamSelectionBySongs.Add(data);
		}
	}

	// // RVA: 0x1CB6E60 Offset: 0x1CB6E60 VA: 0x1CB6E60 Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1CB7B80 Offset: 0x1CB7B80 VA: 0x1CB7B80 Slot: 6
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		TodoLogger.Log(0, "TODO");
		return true;
	}

	// // RVA: 0x1CB81F4 Offset: 0x1CB81F4 VA: 0x1CB81F4 Slot: 7
	// public override void BMGGKONLFIC(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1CB8694 Offset: 0x1CB8694 VA: 0x1CB8694 Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1CB8A9C Offset: 0x1CB8A9C VA: 0x1CB8A9C Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1CBE0EC Offset: 0x1CBE0EC VA: 0x1CBE0EC Slot: 9
	// public override bool NFKFOODCJJB() { }
}
