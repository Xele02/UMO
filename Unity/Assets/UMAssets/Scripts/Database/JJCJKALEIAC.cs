
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JJCJKALEIAC_HomePickup", true)]
public class JJCJKALEIAC { }
public class JJCJKALEIAC_HomePickup : DIHHCBACKGG_DbSection
{
	public class COBEFDFGLKA
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		private sbyte BHMMADINAJO; // 0x18
		private int EHOIENNDEDH_IdCrypted; // 0x1C
		private int DGLIDLIIILE_PrioCrypted; // 0x20
		private int AECMLPKCEAE; // 0x24
		private sbyte OIFAFKDMEEJ_EnabledCrypted; // 0x28
		private sbyte ECDMGKIIKFL; // 0x29
		private sbyte NFMBDLMHEKK; // 0x2A
		private sbyte PLOLPNDKCDM; // 0x2B
		private sbyte OEPIBOJMOBF; // 0x2C
		private sbyte NJCHGIFEIKF; // 0x2D
		private long PCLNFCNIECH_OpenAtCrypted; // 0x30
		private long HHPIJHADAOB_CloseAtCrypted; // 0x38
		private int NNDGELGIMAO_GroupCrypted; // 0x40
		private int LCMLPPFCGJA; // 0x44
		private int KEEEAALEKDG; // 0x48
		private sbyte KHNPKIBAKFB; // 0x4C
		private NNJFKLBPBNK_SecureString BIBOHDLOHOD; // 0x50
		private NNJFKLBPBNK_SecureString FHBDAJIDLNN; // 0x54
		private NNJFKLBPBNK_SecureString JOEGFLCGFNO; // 0x58

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134F1B8 DEMEPMAEJOO 0x134EB80 HIGKAIDMOKN
		public int DAPGDCPDCNA_Prio { get { return DGLIDLIIILE_PrioCrypted ^ FBGGEFFJJHB_xor; } set { DGLIDLIIILE_PrioCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134F1C8 GFAHOLGECII 0x134EB90 KJKCIHEDEBB
		public int KNHOMNONOEB_AssetId { get { return AECMLPKCEAE ^ FBGGEFFJJHB_xor; } set { AECMLPKCEAE = value ^ FBGGEFFJJHB_xor; } } //0x134F1D8 NECFMEFKKPH 0x134EBA0 MHNEFLJACHA
		public sbyte PPEGAKEIEGM_Enabled { get { return (sbyte)(OIFAFKDMEEJ_EnabledCrypted ^ BHMMADINAJO); } set { OIFAFKDMEEJ_EnabledCrypted = (sbyte)(value ^ BHMMADINAJO); } } //0x134F1E8 KPOEEPIMMJP 0x134EBB0 NCIEAFEDPBH
		public sbyte JOPPFEHKNFO_Pickup { get { return (sbyte)(ECDMGKIIKFL ^ BHMMADINAJO); } set { ECDMGKIIKFL = (sbyte)(value ^ BHMMADINAJO); } } //0x134F1FC FNIOGOJFLMG 0x134EBC0 AJIOKKIJBED
		public sbyte OFMECFHNCHA_Popup { get { return (sbyte)(NFMBDLMHEKK ^ BHMMADINAJO); } set { NFMBDLMHEKK = (sbyte)(value ^ BHMMADINAJO); } } //0x134F210 OCBFEBBDDFI 0x134EBD0 BMFCGGIPJDL
		public sbyte GMELAKNFKMG { get { return (sbyte)(PLOLPNDKCDM ^ BHMMADINAJO); } set { PLOLPNDKCDM = (sbyte)(value ^ BHMMADINAJO); } } //0x134F224 GNIIGNBNAJF 0x134EBE0 DNGBCJOKLND
		public sbyte ODOAFNMJIMA { get { return (sbyte)(OEPIBOJMOBF ^ BHMMADINAJO); } set { OEPIBOJMOBF = (sbyte)(value ^ BHMMADINAJO); } } //0x134F238 GGOLPHFOEAJ 0x134EC9C FKMPBPDOBIO
		public sbyte ADHCKHFANAL { get { return (sbyte)(NJCHGIFEIKF ^ BHMMADINAJO); } set { NJCHGIFEIKF = (sbyte)(value ^ BHMMADINAJO); } } //0x134F24C LPICEPPJOMO 0x134EC8C EHJIKIJEILL
		public long PDBPFJJCADD_open_at { get { return PCLNFCNIECH_OpenAtCrypted ^ BBEGLBMOBOF_xorl; } set { PCLNFCNIECH_OpenAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x134F260 FOACOMBHPAC 0x134ECAC NBACOBCOJCA
		public long FDBNFFNFOND_close_at { get { return HHPIJHADAOB_CloseAtCrypted ^ BBEGLBMOBOF_xorl; } set { HHPIJHADAOB_CloseAtCrypted = value ^ BBEGLBMOBOF_xorl; } } //0x134F274 BPJOGHJCLDJ 0x134ECCC NLJKMCHOCBK
		public int KGICDMIJGDF_Group { get { return NNDGELGIMAO_GroupCrypted ^ FBGGEFFJJHB_xor; } set { NNDGELGIMAO_GroupCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134F288 ENACPBCEBLF 0x134ECEC KPCDPMGBPAG
		public int JPKPDCCGGLA { get { return LCMLPPFCGJA ^ FBGGEFFJJHB_xor; } set { LCMLPPFCGJA = value ^ FBGGEFFJJHB_xor; } } //0x134F298 KMHGMKABEAE 0x134ECFC PCFICMIDNGC
		public int AMKJDECHIOF { get { return KEEEAALEKDG ^ FBGGEFFJJHB_xor; } set { KEEEAALEKDG = value ^ FBGGEFFJJHB_xor; } } //0x134F2A8 CFKKLJPHGJL 0x134ED0C BNAMIEALHOB
		public sbyte KLHGOPBIOCN { get { return (sbyte)(KHNPKIBAKFB ^ BHMMADINAJO); } set { KHNPKIBAKFB = (sbyte)(value ^ BHMMADINAJO); } } //0x134F2B8 PGEKHCMFGAB 0x134ED1C INPFJDENBAC
		public string PIBLLGLCJEO_Param { get { return BIBOHDLOHOD.DNJEJEANJGL_Value; } set { BIBOHDLOHOD.DNJEJEANJGL_Value = value; } } //0x134F2CC CMKMAGNMPGC 0x134EBF0 CICCOMMMNHK
		public string FEMMDNIELFC_Desc { get { return FHBDAJIDLNN.DNJEJEANJGL_Value; } set { FHBDAJIDLNN.DNJEJEANJGL_Value = value; } } //0x134F2F8 JDHDMBHNKJD 0x134EC58 FNAJEJLLJOE
		public string AOBNHHIIJBO { get { return JOEGFLCGFNO.DNJEJEANJGL_Value; } set { JOEGFLCGFNO.DNJEJEANJGL_Value = value; } } //0x134F324 JGFPKPOOAJH 0x134EC24 NOPEKIPBLDK

		// RVA: 0x134F0F4 Offset: 0x134F0F4 VA: 0x134F0F4
		//public uint CAOGDCBPBAN() { }

		// RVA: 0x134EA00 Offset: 0x134EA00 VA: 0x134EA00
		public COBEFDFGLKA()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = -1;
			BHMMADINAJO = (sbyte)FBGGEFFJJHB_xor;
			KLHGOPBIOCN = 0;
			KGICDMIJGDF_Group = 0;
			JPKPDCCGGLA = 0;
			AMKJDECHIOF = 0;
			PPFNGGCBJKC_id = 0;
			DAPGDCPDCNA_Prio = 0;
			KNHOMNONOEB_AssetId = 0;
			PDBPFJJCADD_open_at = 0;
			FDBNFFNFOND_close_at = 0;
			ODOAFNMJIMA = 0;
			PPEGAKEIEGM_Enabled = 0;
			JOPPFEHKNFO_Pickup = 0;
			OFMECFHNCHA_Popup = 0;
			GMELAKNFKMG = 0;
			BIBOHDLOHOD = new NNJFKLBPBNK_SecureString();
			FHBDAJIDLNN = new NNJFKLBPBNK_SecureString();
			JOEGFLCGFNO = new NNJFKLBPBNK_SecureString();
			PIBLLGLCJEO_Param = "";
			FEMMDNIELFC_Desc = "";
			AOBNHHIIJBO = "";
		}
	}

	public class KOCBFBJBHLJ
	{
		private int FBGGEFFJJHB_xor; // 0x8
		public sbyte PLALNIIBLOF_en; // 0xC
		public sbyte KLCMKLPIDDJ_Month; // 0xD
		public sbyte BAOFEFFADPD_day; // 0xE
		private int EHOIENNDEDH_IdCrypted; // 0x10
		public int AECMLPKCEAE; // 0x14
		private NNJFKLBPBNK_SecureString JOEGFLCGFNO; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134F350 DEMEPMAEJOO 0x134EE0C HIGKAIDMOKN
		public int KNHOMNONOEB_AssetId { get { return AECMLPKCEAE ^ FBGGEFFJJHB_xor; } set { AECMLPKCEAE = value ^ FBGGEFFJJHB_xor; } } //0x134F360 NECFMEFKKPH 0x134EE1C MHNEFLJACHA
		public string AOBNHHIIJBO { get { return JOEGFLCGFNO.DNJEJEANJGL_Value; } set { JOEGFLCGFNO.DNJEJEANJGL_Value = value; } } //0x134F370 JGFPKPOOAJH 0x134EE2C NOPEKIPBLDK

		// RVA: 0x134ED2C Offset: 0x134ED2C VA: 0x134ED2C
		public KOCBFBJBHLJ()
		{
			JOEGFLCGFNO = new NNJFKLBPBNK_SecureString();
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			PLALNIIBLOF_en = 0;
			KLCMKLPIDDJ_Month = 0;
			KLCMKLPIDDJ_Month = 0;
			PPFNGGCBJKC_id = 0;
			KNHOMNONOEB_AssetId = 0;
			AOBNHHIIJBO = "";
		}
	}

	public class OHPHKIFMPEK
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private long BBEGLBMOBOF_xorl; // 0x10
		public sbyte PLALNIIBLOF_en; // 0x18
		private int EHOIENNDEDH_IdCrypted; // 0x1C
		private int AECMLPKCEAE; // 0x20
		private int NOFECLGOLAI_TypeCrypted; // 0x24
		private int BOBIDKJJEIM; // 0x28
		private int EIJOIHNONKF; // 0x2C
		private long OHCFBOKAOFO; // 0x30
		private NNJFKLBPBNK_SecureString JOEGFLCGFNO; // 0x38

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134F39C DEMEPMAEJOO 0x134EF64 HIGKAIDMOKN
		public long CCPECDBPFCJ { get { return OHCFBOKAOFO ^ BBEGLBMOBOF_xorl; } set { OHCFBOKAOFO = value ^ BBEGLBMOBOF_xorl; } } //0x134DD68 AALOFMLBJJG 0x134EF74 MJNKKKHHMGF
		// Type
		public int GBJFNGCDKPM_typ { get { return NOFECLGOLAI_TypeCrypted ^ FBGGEFFJJHB_xor; } set { NOFECLGOLAI_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x134DD58 CEJJMKODOGK 0x134EF94 HOHCEBMMACI
		public int JOFAGCFNKIO_OpenTime { get { return BOBIDKJJEIM ^ FBGGEFFJJHB_xor; } set { BOBIDKJJEIM = value ^ FBGGEFFJJHB_xor; } } //0x134DD7C JDJIHKNFDLG 0x134EFA4 JNKGBAPAGOB
		public int EBCHFBIINDP_End { get { return EIJOIHNONKF ^ FBGGEFFJJHB_xor; } set { EIJOIHNONKF = value ^ FBGGEFFJJHB_xor; } } //0x134DD8C LHAMEHALKDB 0x134EFB4 DHAPDOLCLHO
		public int KNHOMNONOEB_AssetId { get { return AECMLPKCEAE ^ FBGGEFFJJHB_xor; } set { AECMLPKCEAE = value ^ FBGGEFFJJHB_xor; } } //0x134F3AC NECFMEFKKPH 0x134EFC4 MHNEFLJACHA
		public string AOBNHHIIJBO { get { return JOEGFLCGFNO.DNJEJEANJGL_Value; } set { JOEGFLCGFNO.DNJEJEANJGL_Value = value; } } //0x134F3BC JGFPKPOOAJH 0x134EFD4 NOPEKIPBLDK

		// RVA: 0x134EE60 Offset: 0x134EE60 VA: 0x134EE60
		public OHPHKIFMPEK()
		{
			JOEGFLCGFNO = new NNJFKLBPBNK_SecureString();
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = LPDNKHAIOLH.CEIBAFOCNCA();
			CCPECDBPFCJ = 0;
			PLALNIIBLOF_en = 0;
			EBCHFBIINDP_End = 0;
			PPFNGGCBJKC_id = 0;
			GBJFNGCDKPM_typ = 0;
			AOBNHHIIJBO = "";
		}
	}

	public List<COBEFDFGLKA> CDENCMNHNGA_table = new List<COBEFDFGLKA>(); // 0x20
	public List<KOCBFBJBHLJ> ENONECOLGGC = new List<KOCBFBJBHLJ>(); // 0x24
	public List<OHPHKIFMPEK> HOFCPIHMHNB = new List<OHPHKIFMPEK>(); // 0x28

	//// RVA: 0x134DA08 Offset: 0x134DA08 VA: 0x134DA08
	public List<KOCBFBJBHLJ> NOHBJAPCJJI(long _EOLFJGMAJAB_CurrentTime)
	{
		DateTime date = Utility.GetLocalDateTime(_EOLFJGMAJAB_CurrentTime);
		List<KOCBFBJBHLJ> res = new List<KOCBFBJBHLJ>();
		for(int i = 0; i < ENONECOLGGC.Count; i++)
		{
			if(ENONECOLGGC[i].PLALNIIBLOF_en == 2 
				&& ENONECOLGGC[i].KLCMKLPIDDJ_Month == date.Month 
				&& ENONECOLGGC[i].BAOFEFFADPD_day == date.Day)
			{
				res.Add(ENONECOLGGC[i]);
			}
		}
		return res;
	}

	//// RVA: 0x134DBE8 Offset: 0x134DBE8 VA: 0x134DBE8
	public OHPHKIFMPEK OKMGCLFJDJI(int IHDHKBEMADL, long _EOLFJGMAJAB_CurrentTime)
	{
		for(int i = 0; i < HOFCPIHMHNB.Count; i++)
		{
			if(HOFCPIHMHNB[i].PLALNIIBLOF_en == 2 && HOFCPIHMHNB[i].GBJFNGCDKPM_typ == IHDHKBEMADL)
			{
				if(_EOLFJGMAJAB_CurrentTime >= HOFCPIHMHNB[i].CCPECDBPFCJ + HOFCPIHMHNB[i].JOFAGCFNKIO_OpenTime)
				{
					if (HOFCPIHMHNB[i].CCPECDBPFCJ + HOFCPIHMHNB[i].EBCHFBIINDP_End >= _EOLFJGMAJAB_CurrentTime)
						return HOFCPIHMHNB[i];
				}
			}
		}
		return null;
	}

	// RVA: 0x134DD9C Offset: 0x134DD9C VA: 0x134DD9C
	public JJCJKALEIAC_HomePickup()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 54;
	}

	// RVA: 0x134DEF8 Offset: 0x134DEF8 VA: 0x134DEF8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		ENONECOLGGC.Clear();
		HOFCPIHMHNB.Clear();
	}

	// RVA: 0x134DFC8 Offset: 0x134DFC8 VA: 0x134DFC8 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MFNEHMPBDKK parser = MFNEHMPBDKK.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			NNMHEHIOKGF[] array = parser.AGMBMGJAKFJ;
			for (int i = 0; i < array.Length; i++)
			{
				COBEFDFGLKA data = new COBEFDFGLKA();
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
				data.DAPGDCPDCNA_Prio = (int)array[i].DAPGDCPDCNA;
				data.KNHOMNONOEB_AssetId = (int)array[i].KNHOMNONOEB;
				data.PPEGAKEIEGM_Enabled = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, (int)array[i].PLALNIIBLOF, 0);
				data.JOPPFEHKNFO_Pickup = (sbyte)array[i].JOPPFEHKNFO;
				data.OFMECFHNCHA_Popup = (sbyte)array[i].OFMECFHNCHA;
				data.GMELAKNFKMG = (sbyte)array[i].GMELAKNFKMG;
				data.PIBLLGLCJEO_Param = array[i].PIBLLGLCJEO;
				data.AOBNHHIIJBO = array[i].AOBNHHIIJBO;
				data.FEMMDNIELFC_Desc = array[i].FEMMDNIELFC;
				data.ADHCKHFANAL = (sbyte)array[i].ADHCKHFANAL;
				data.ODOAFNMJIMA = (sbyte)array[i].ODOAFNMJIMA;
				data.PDBPFJJCADD_open_at = array[i].PDBPFJJCADD;
				data.FDBNFFNFOND_close_at = array[i].FDBNFFNFOND;
				data.KGICDMIJGDF_Group = array[i].KGICDMIJGDF;
				data.JPKPDCCGGLA = array[i].JPKPDCCGGLA;
				data.AMKJDECHIOF = array[i].AMKJDECHIOF;
				data.KLHGOPBIOCN = (sbyte)array[i].KLHGOPBIOCN;
				CDENCMNHNGA_table.Add(data);
			}
		}
		{
			EIGKPFPCGJK[] array = parser.PCKGJKCOPEB;
			for(int i = 0; i < array.Length;  i++)
			{
				KOCBFBJBHLJ data = new KOCBFBJBHLJ();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
				data.PLALNIIBLOF_en = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.KLCMKLPIDDJ_Month = (sbyte)array[i].KLCMKLPIDDJ;
				data.BAOFEFFADPD_day = (sbyte)array[i].BAOFEFFADPD;
				data.KNHOMNONOEB_AssetId = array[i].KNHOMNONOEB;
				data.AOBNHHIIJBO = array[i].AOBNHHIIJBO;
				ENONECOLGGC.Add(data);
			}
		}
		{
			OAPCAAGKGPP[] array = parser.KMGFICHGDGE;
			for(int i = 0; i < array.Length; i++)
			{
				OHPHKIFMPEK data = new OHPHKIFMPEK();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
				data.PLALNIIBLOF_en = (sbyte)JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.CCPECDBPFCJ = array[i].CCPECDBPFCJ;
				data.GBJFNGCDKPM_typ = array[i].GBJFNGCDKPM;
				data.JOFAGCFNKIO_OpenTime = array[i].JOFAGCFNKIO;
				data.EBCHFBIINDP_End = array[i].EBCHFBIINDP;
				data.KNHOMNONOEB_AssetId = array[i].KNHOMNONOEB;
				data.AOBNHHIIJBO = array[i].AOBNHHIIJBO;
				HOFCPIHMHNB.Add(data);
			}
		}
		return true;
	}

	// RVA: 0x134F008 Offset: 0x134F008 VA: 0x134F008 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x134F010 Offset: 0x134F010 VA: 0x134F010 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JJCJKALEIAC_HomePickup.CAOGDCBPBAN");
		return 0;
	}
}
