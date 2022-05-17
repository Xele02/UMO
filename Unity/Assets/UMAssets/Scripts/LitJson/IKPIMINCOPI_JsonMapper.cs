using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

internal struct HNPAFOGPHIM_PropertyMetadata
{
	// Fields
	public MemberInfo HHKBDDNBEAA_Info; // 0x0
	public bool KFKMLGBHPFI_IsField; // 0x4
	public Type JMKADEBOBLA_Type; // 0x8
}

// Namespace: 
internal struct PNELLEFDAMJ_ArrayMetadata
{
	// Fields
	private Type HBMLACMKOGF_element_type; // 0x0
	private bool FGKEHMPKILA_is_array; // 0x4
	private bool KKHKAKEDAPG_is_list; // 0x5

	// Properties
	// RVA: 0x7FBD8C Offset: 0x7FBD8C VA: 0x7FBD8C
	//public Type IGCFEPKFDIG() { }
	// RVA: 0x7FBD94 Offset: 0x7FBD94 VA: 0x7FBD94
	//public void GMAMBBAPNBP(Type NANNGLGOFKH) { }
	public Type CHHEJNLOIEB_ElementType { get; set; }
	// RVA: 0x7FBD9C Offset: 0x7FBD9C VA: 0x7FBD9C
	//public bool HJENKHBBMMO() { }
	// RVA: 0x7FBDA4 Offset: 0x7FBDA4 VA: 0x7FBDA4
	//public void ELGAJICNGBG(bool NANNGLGOFKH) { }
	public bool EPNGJLOKGIF_IsArray { get; set; }
	// RVA: 0x7FBDAC Offset: 0x7FBDAC VA: 0x7FBDAC
	//public bool GBCGDJBLLED() { }
	// RVA: 0x7FBDB4 Offset: 0x7FBDB4 VA: 0x7FBDB4
	//public void IBHPIGONLKH(bool NANNGLGOFKH) { }
	public bool AHEAPECLDEJ_IsList { get; set; }
}


// Namespace: 
internal struct OBDHMJIBHIP_ObjectMetadata // TypeDefIndex: 18699
{
	// Fields
	private Type HBMLACMKOGF_element_type; // 0x0
	private bool FCILDCFBKMG_is_dictionary; // 0x4
	private IDictionary<string, HNPAFOGPHIM_PropertyMetadata> LALJJDFLKGD_properties; // 0x8

	// Properties
	// RVA: 0x7FF6EC Offset: 0x7FF6EC VA: 0x7FF6EC
	//public Type IGCFEPKFDIG() { }
	// RVA: 0x7FF6F4 Offset: 0x7FF6F4 VA: 0x7FF6F4
	//public void GMAMBBAPNBP(Type NANNGLGOFKH) { }
	public Type CHHEJNLOIEB_ElementType { get; set; }
	// RVA: 0x7FF6FC Offset: 0x7FF6FC VA: 0x7FF6FC
	//public bool JKPHKHMJJDB() { }
	// RVA: 0x7FF704 Offset: 0x7FF704 VA: 0x7FF704
	//public void DOPOGIEGKHG(bool NANNGLGOFKH) { }
	public bool EBIEKOOCMMM_IsDictionary { get; set; }
	// RVA: 0x7FF70C Offset: 0x7FF70C VA: 0x7FF70C
	//public IDictionary<string, HNPAFOGPHIM> KOLEKPEKEEK() { }
	// RVA: 0x7FF714 Offset: 0x7FF714 VA: 0x7FF714
	//public void KLANBAKIPFH(IDictionary<string, HNPAFOGPHIM> NANNGLGOFKH) { }
	public IDictionary<string, HNPAFOGPHIM_PropertyMetadata> GJENOLNPNAC_Properties { get; set; }
}

internal delegate void OGIPFNLOCBD_ExporterFunc    (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer);
public   delegate void OGIPFNLOCBD_ExporterFunc<T> (T LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer);
internal delegate object EFECLNPDNLP_ImporterFunc                (object BJKEOACPMHB_input);
public   delegate TValue EFECLNPDNLP_ImporterFunc<TJson, TValue> (TJson BJKEOACPMHB_input);

public delegate IHIFCPDDDKN_IJsonWrapper OEIBKOCANDB_WrapperFactory();

public class IKPIMINCOPI_JsonMapper // TypeDefIndex: 18705
{
        // Fields
        private static int EAKADAEHFNP_max_nesting_depth; // 0x0
        private static IFormatProvider NPCBCMOLMJK_datetime_format; // 0x4
        private static IDictionary<Type, OGIPFNLOCBD_ExporterFunc> CKAHMNAEIEB_base_exporters_table; // 0x8
        private static IDictionary<Type, OGIPFNLOCBD_ExporterFunc> DJFPFJOCIJO_custom_exporters_table; // 0xC
        private static IDictionary<Type, IDictionary<Type, EFECLNPDNLP_ImporterFunc>> IFENDAFEPNC_base_importers_table; // 0x10
        private static IDictionary<Type, IDictionary<Type, EFECLNPDNLP_ImporterFunc>> FILBDMLOHNE_custom_importers_table; // 0x14
        private static IDictionary<Type, PNELLEFDAMJ_ArrayMetadata> HBACDODMCJA_array_metadata; // 0x18
        private static readonly object ADLIMKLIAFM_array_metadata_lock = new Object (); // 0x1C
        private static IDictionary<Type, IDictionary<Type, MethodInfo>> GGNJEAOKFFO_conv_ops; // 0x20
        private static readonly object ODDJPNEIIHM_conv_ops_lock = new Object (); // 0x24
        private static IDictionary<Type, OBDHMJIBHIP_ObjectMetadata> AOCACFGDNAI_object_metadata; // 0x28
        private static readonly object EGMFLEOLEHJ_object_metadata_lock = new Object (); // 0x2C
        private static IDictionary<Type, IList<HNPAFOGPHIM_PropertyMetadata>> LEJBPAJGDGL_type_properties; // 0x30
        private static readonly object DDEGDJNNPMF_type_properties_lock = new Object (); // 0x34
        private static KIJECNFNNDB_JsonWriter NKKDEKFHAAC_static_writer; // 0x38
        private static readonly object BNBONKFHCKP_static_writer_lock = new Object (); // 0x3C

        // Methods

        // RVA: 0x8E90FC Offset: 0x8E90FC VA: 0x8E90FC
        static IKPIMINCOPI_JsonMapper()
        {
            // TODO init vars
        }

        // RVA: 0x8EB8CC Offset: 0x8EB8CC VA: 0x8EB8CC
        //private static void FNJALHOGCFM_AddArrayMetadata(Type INDDJNMPONH_type) { }

        // RVA: 0x8EBF34 Offset: 0x8EBF34 VA: 0x8EBF34
        //private static void NHFPMEJCJJD_AddObjectMetadata(Type INDDJNMPONH_type) { }

        // RVA: 0x8EC850 Offset: 0x8EC850 VA: 0x8EC850
        //private static void GLDMGHFLHIL_AddTypeProperties(Type INDDJNMPONH_type) { }

        // RVA: 0x8ECEEC Offset: 0x8ECEEC VA: 0x8ECEEC
        //private static MethodInfo KCEEPBALDNK_GetConvOp(Type ECHKGBBOLFM_t1, Type KAMKECFBELN_t2) { }

        // RVA: 0x8EDA54 Offset: 0x8EDA54 VA: 0x8EDA54
        //private static object GAPADDGOKOC_ReadValue(Type OGHDELCOELF_inst_type, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader) { }

        // RVA: 0x8EF3FC Offset: 0x8EF3FC VA: 0x8EF3FC
        private static IHIFCPDDDKN_IJsonWrapper GAPADDGOKOC_ReadValue(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
        {
            
            return null;
        }

        // RVA: 0x8E9430 Offset: 0x8E9430 VA: 0x8E9430
        //private static void FCBHJMAFPOG_RegisterBaseExporters() { }

        // RVA: 0x8EA5E8 Offset: 0x8EA5E8 VA: 0x8EA5E8
        //private static void BLKCGAADNBI_RegisterBaseImporters() { }

        // RVA: 0x8EFE2C Offset: 0x8EFE2C VA: 0x8EFE2C
        //private static void MJBPPCBFPFG_RegisterImporter(IDictionary<Type, IDictionary<Type, EFECLNPDNLP_ImporterFunc>> CDENCMNHNGA_table, Type AJAIOPIHGCL_json_type, Type FMENOANEJOF_value_type, EFECLNPDNLP_ImporterFunc FDJLCJHLGFI_importer) { }

        // RVA: 0x8F0110 Offset: 0x8F0110 VA: 0x8F0110
        //private static void MDNHFHCGIMC_WriteValue(object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer, bool AHCEFLAMCNH_writer_is_private, int DMGALMEPLCF_depth) { }

        // RVA: 0x8F1AD8 Offset: 0x8F1AD8 VA: 0x8F1AD8
        //public static string EJCOJCGIBNG_ToJson(object LMNBBOIJBBL_obj) { }

        // RVA: 0x8F1CD4 Offset: 0x8F1CD4 VA: 0x8F1CD4
        //public static void EJCOJCGIBNG_ToJson(object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) { }

        // RVA: 0x8F1D6C Offset: 0x8F1D6C VA: 0x8F1D6C
        //public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader) { }

        // RVA: 0x8F1FF0 Offset: 0x8F1FF0 VA: 0x8F1FF0
        //public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(TextReader CLJIOLIEPNA_reader) { }

        // RVA: 0x8E8D34 Offset: 0x8E8D34 VA: 0x8E8D34
        public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(string DLENPPIJNPA_json)
        {
            // TODO
            IHIFCPDDDKN_IJsonWrapper a = EJMBECKABEL_ToWrapper(() => { return new EDOHBJAPLPF_JsonData(); }, DLENPPIJNPA_json);
            if(a == null)
                return null;
            return a as EDOHBJAPLPF_JsonData;
        }
        // RVA: -1 Offset: -1
        //public static T PFAMKCGJKKL_ToObject<T>(MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader) { }
        /* GenericInstMethod :
        |
        |-RVA: 0x1AB5D18 Offset: 0x1AB5D18 VA: 0x1AB5D18
        |-IKPIMINCOPI.PFAMKCGJKKL<object>
        */

        // RVA: -1 Offset: -1
        //public static T PFAMKCGJKKL_ToObject<T>(TextReader CLJIOLIEPNA_reader) { }
        /* GenericInstMethod :
        |
        |-RVA: 0x1AB5E90 Offset: 0x1AB5E90 VA: 0x1AB5E90
        |-IKPIMINCOPI.PFAMKCGJKKL<object>
        */

        // RVA: -1 Offset: -1
        //public static T PFAMKCGJKKL_ToObject<T>(string DLENPPIJNPA_json) { }
        /* GenericInstMethod :
        |
        |-RVA: 0x1AB602C Offset: 0x1AB602C VA: 0x1AB602C
        |-IKPIMINCOPI.PFAMKCGJKKL<object>
        */

        // RVA: 0x8F1F68 Offset: 0x8F1F68 VA: 0x8F1F68
        //public static IHIFCPDDDKN_IJsonWrapper EJMBECKABEL_ToWrapper(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader) { }

        // RVA: 0x8F2210 Offset: 0x8F2210 VA: 0x8F2210
        public static IHIFCPDDDKN_IJsonWrapper EJMBECKABEL_ToWrapper(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, string DLENPPIJNPA_json)
        {
            MFJGDLBFMEL_JsonReader reader = new MFJGDLBFMEL_JsonReader(DLENPPIJNPA_json);
            return GAPADDGOKOC_ReadValue(BJECIFKPLJC_factory, reader);
        }

        // RVA: -1 Offset: -1
        //public static void LIEDACPLEMK_RegisterExporter<T>(FMJNNJIAOIG_ExporterFunc<T> IDCEIBMHEGO_exporter) { }
        /* GenericInstMethod :
        |
        |-RVA: 0x1C79A5C Offset: 0x1C79A5C VA: 0x1C79A5C
        |-IKPIMINCOPI.LIEDACPLEMK<object>
        */

        // RVA: -1 Offset: -1
        //public static void MJBPPCBFPFG_RegisterImporter<TJson, TValue>(MAIGGGACCCE_ImporterFunc<TJson, TValue> FDJLCJHLGFI_importer) { }
        /* GenericInstMethod :
        |
        |-RVA: 0x1C79C44 Offset: 0x1C79C44 VA: 0x1C79C44
        |-IKPIMINCOPI.MJBPPCBFPFG<object, object>
        */

        // RVA: 0x8F22BC Offset: 0x8F22BC VA: 0x8F22BC
        //public static void PHGPKMENKIC_UnregisterExporters() { }

        // RVA: 0x8F23D0 Offset: 0x8F23D0 VA: 0x8F23D0
        //public static void GAHIHNFIDCH_UnregisterImporters() { }

        // RVA: 0x8F24E4 Offset: 0x8F24E4 VA: 0x8F24E4
        //public void .ctor() { }
}
