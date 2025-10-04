using FlatBuffers;
using System.Collections.Generic;

public class DCHENGJKOKI
{
	public uint[] OEOIHIIIMCK_add { get; set; } // 0x8 CJPIOPLFGFA BLMLNFDOJHF_get_add IJLDMBPEGAK_set_add
	public uint MBAMIOJNGBD_ch { get; set; } // 0xC PJHOHPBOIDJ NJBKAFBFJML_get_ch IGAFGHBHMIF_set_ch
	public uint BCCOMAODPJI_hp { get; set; } // 0x10 ADINNEKFLLL KBJDPCLDJEB_get_hp FPIIOJGBDEJ_set_hp
	public uint LJELGFAFGAB_so { get; set; } // 0x14 CJCOPPAFPKE APHFJDOOLCK_get_so KBEAJHMCGPM_set_so
	public uint KNEDJFLCCLN_vo { get; set; } // 0x18 HJMKHFAHBIO DKJNGOIGJGH_get_vo EOMMBJGKKJI_set_vo
	public uint ADLGKMBIPCA_fd { get; set; } // 0x1C KJBJJPDMEMK ECHDOIILAHP_get_fd BNPHIHICNCJ_set_fd
	public uint PIPCIMIALOO_sp { get; set; } // 0x20 INBCDPNEACE KJNBPECGBJJ_get_sp DMAJEBCFHHK_set_sp
}
public class MALFJMBMCLG
{
	public uint PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
	public uint JIBNPJCIALH_body { get; set; } // 0xC KOAOJEABIEG ODFPNCJNFPM_get_body LDFLKNMKMJG_set_body
	public string OPFGFINHFCE_name { get; set; } // 0x10 LGIIAPHCLPN DKJOHDGOIJE_get_name MJAMIGECMMF_set_name
	public uint PLALNIIBLOF_en { get; set; } // 0x14 DFMNDOMAPAB JPCJNLHHIPE_get_en JJFJNEJLBDG_set_en
	public uint OJGBNNIJNEM_ea { get; set; } // 0x18 GOCLPAADBNE LICAAFKDABO_get_ea PNPLHIKAPAC_set_ea
	public uint JPFMJHLCMJL_sa { get; set; } // 0x1C PIJIPMOBEIJ LLFFAPHPGFJ_get_sa PMGNHNIKHLE_set_sa
	public uint OKADDOIJGNB_ps { get; set; } // 0x20 AHENFOIADBF KJJLNOKJFKL_get_ps HANJMIACJMH_set_ps
	public uint KLCMKLPIDDJ_Month { get; set; } // 0x24 LBNFMGNGCDA FKGAMFACFKO_get_Month MHLPBOBOFJA_set_Month
	public uint BAOFEFFADPD_day { get; set; } // 0x28 MNBJKHKHMCL KHNONKOPIPO_get_day LBJPPBMDOGE_set_day
	public DCHENGJKOKI DFEDIAPLFHN { get; set; } // 0x2C JDPHNDKLPIO BOFLPJOHHOM_get_ GDFOALHOPEG_set_
	public int IJEKNCDIIAE_mver { get; set; } // 0x30 FAHNCMHNFCG KJIMMIBDCIL_get_mver DMEGNOKIKCD_set_mver
	public uint LIOGKHIGJKN_FreeMusicId { get; set; } // 0x34 DGLBKOGGKHO JNBPCHKDNMD_get_FreeMusicId MLPEHHGEEIB_set_FreeMusicId
	public uint CMBCBNEODPD_HomeBgId { get; set; } // 0x38 CLHDIBCIJBB EIMFDHBOECI_get_HomeBgId OJMIHHIIBPI_set_HomeBgId
}
public class MHKHMCAPDKK
{
	public MALFJMBMCLG[] INPCGKFIMIG { get; set; } // 0x8 HIGMNBMCFMA ALGNNBLEMFC_get_ DHAFGDNFCKI_set_
	public static MHKHMCAPDKK HEGEKFMJNCC(byte[] NIODCJLINJN)// 0x1952760
	{
		ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
		OEMMCAHOCEL res_readData_ = OEMMCAHOCEL.GetRootAsOEMMCAHOCEL(buffer);
		MHKHMCAPDKK res_data_ = new MHKHMCAPDKK();

		List<MALFJMBMCLG> INPCGKFIMIG_list_ = new List<MALFJMBMCLG>();
		for(int INPCGKFIMIG_idx_ = 0; INPCGKFIMIG_idx_ < res_readData_.NCMGOKNHGNLLength; INPCGKFIMIG_idx_++)
		{
			LPDFHGHGHPA INPCGKFIMIG_readData_ = res_readData_.GetNCMGOKNHGNL(INPCGKFIMIG_idx_);
			MALFJMBMCLG INPCGKFIMIG_data_ = new MALFJMBMCLG();

			INPCGKFIMIG_data_.PPFNGGCBJKC_id = INPCGKFIMIG_readData_.BBPHAPFBFHK/*_id*/;
			INPCGKFIMIG_data_.JIBNPJCIALH_body = INPCGKFIMIG_readData_.PKKHBFGMNGA/*_body*/;
			INPCGKFIMIG_data_.OPFGFINHFCE_name = INPCGKFIMIG_readData_.IIDCFMHCPLJ/*_name*/;
			INPCGKFIMIG_data_.PLALNIIBLOF_en = INPCGKFIMIG_readData_.CFLMCGOJJJD/*_en*/;
			INPCGKFIMIG_data_.OJGBNNIJNEM_ea = INPCGKFIMIG_readData_.NNNDHIHBMFL/*_ea*/;
			INPCGKFIMIG_data_.JPFMJHLCMJL_sa = INPCGKFIMIG_readData_.GJEJFAJHBME/*_sa*/;
			INPCGKFIMIG_data_.OKADDOIJGNB_ps = INPCGKFIMIG_readData_.OPDKCCDMPHA/*_ps*/;
			INPCGKFIMIG_data_.KLCMKLPIDDJ_Month = INPCGKFIMIG_readData_.IALIGIAJJGP/*_Month*/;
			INPCGKFIMIG_data_.BAOFEFFADPD_day = INPCGKFIMIG_readData_.FKGLOPMFMCP/*_day*/;
			HJJBMKIDKFG DFEDIAPLFHN_readData_ = INPCGKFIMIG_readData_.FFBCKIHFJJJ;
			DCHENGJKOKI DFEDIAPLFHN_data_ = new DCHENGJKOKI();

			List<uint> OEOIHIIIMCK_list_ = new List<uint>();
			for(int OEOIHIIIMCK_idx_ = 0; OEOIHIIIMCK_idx_ < DFEDIAPLFHN_readData_.KIJLMKMIBFLLength; OEOIHIIIMCK_idx_++)
			{
				OEOIHIIIMCK_list_.Add(DFEDIAPLFHN_readData_.GetKIJLMKMIBFL(OEOIHIIIMCK_idx_));
			}
			DFEDIAPLFHN_data_.OEOIHIIIMCK_add = OEOIHIIIMCK_list_.ToArray();

			DFEDIAPLFHN_data_.MBAMIOJNGBD_ch = DFEDIAPLFHN_readData_.KDPKPOBKKMJ/*_ch*/;
			DFEDIAPLFHN_data_.BCCOMAODPJI_hp = DFEDIAPLFHN_readData_.MHFDKEEEDEL/*_hp*/;
			DFEDIAPLFHN_data_.LJELGFAFGAB_so = DFEDIAPLFHN_readData_.FHLKEIBOFNN/*_so*/;
			DFEDIAPLFHN_data_.KNEDJFLCCLN_vo = DFEDIAPLFHN_readData_.EGEFMJCLNDM/*_vo*/;
			DFEDIAPLFHN_data_.ADLGKMBIPCA_fd = DFEDIAPLFHN_readData_.IJMEOOJHNCG/*_fd*/;
			DFEDIAPLFHN_data_.PIPCIMIALOO_sp = DFEDIAPLFHN_readData_.GKLHNNBMGKH/*_sp*/;
			INPCGKFIMIG_data_.DFEDIAPLFHN = DFEDIAPLFHN_data_;
			INPCGKFIMIG_data_.IJEKNCDIIAE_mver = INPCGKFIMIG_readData_.OFMGALJGDAO/*_mver*/;
			INPCGKFIMIG_data_.LIOGKHIGJKN_FreeMusicId = INPCGKFIMIG_readData_.BEJCCAMIPNB/*_FreeMusicId*/;
			INPCGKFIMIG_data_.CMBCBNEODPD_HomeBgId = INPCGKFIMIG_readData_.LAIOEDGDIFO/*_HomeBgId*/;
			INPCGKFIMIG_list_.Add(INPCGKFIMIG_data_);
		}
		res_data_.INPCGKFIMIG = INPCGKFIMIG_list_.ToArray();

		return res_data_;
	}
}
