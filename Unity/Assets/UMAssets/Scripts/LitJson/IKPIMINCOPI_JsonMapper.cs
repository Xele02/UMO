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
	public Type CHHEJNLOIEB_ElementType
	{
		get
		{
			if (HBMLACMKOGF_element_type == null)
				return typeof(EDOHBJAPLPF_JsonData);

			return HBMLACMKOGF_element_type;
		}

		set { HBMLACMKOGF_element_type = value; }
	}
	// RVA: 0x7FBD9C Offset: 0x7FBD9C VA: 0x7FBD9C
	//public bool HJENKHBBMMO() { }
	// RVA: 0x7FBDA4 Offset: 0x7FBDA4 VA: 0x7FBDA4
	//public void ELGAJICNGBG(bool NANNGLGOFKH) { }
	public bool EPNGJLOKGIF_IsArray
	{
		get { return FGKEHMPKILA_is_array; }
		set { FGKEHMPKILA_is_array = value; }
	}
	// RVA: 0x7FBDAC Offset: 0x7FBDAC VA: 0x7FBDAC
	//public bool GBCGDJBLLED() { }
	// RVA: 0x7FBDB4 Offset: 0x7FBDB4 VA: 0x7FBDB4
	//public void IBHPIGONLKH(bool NANNGLGOFKH) { }
	public bool AHEAPECLDEJ_IsList
	{
		get { return KKHKAKEDAPG_is_list; }
		set { KKHKAKEDAPG_is_list = value; }
	}
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
	public Type CHHEJNLOIEB_ElementType
	{
		get
		{
			if (HBMLACMKOGF_element_type == null)
				return typeof(EDOHBJAPLPF_JsonData);

			return HBMLACMKOGF_element_type;
		}

		set { HBMLACMKOGF_element_type = value; }
	}
	// RVA: 0x7FF6FC Offset: 0x7FF6FC VA: 0x7FF6FC
	//public bool JKPHKHMJJDB() { }
	// RVA: 0x7FF704 Offset: 0x7FF704 VA: 0x7FF704
	//public void DOPOGIEGKHG(bool NANNGLGOFKH) { }
	public bool EBIEKOOCMMM_IsDictionary
	{
		get { return FCILDCFBKMG_is_dictionary; }
		set { FCILDCFBKMG_is_dictionary = value; }
	}
	// RVA: 0x7FF70C Offset: 0x7FF70C VA: 0x7FF70C
	//public IDictionary<string, HNPAFOGPHIM> KOLEKPEKEEK() { }
	// RVA: 0x7FF714 Offset: 0x7FF714 VA: 0x7FF714
	//public void KLANBAKIPFH(IDictionary<string, HNPAFOGPHIM> NANNGLGOFKH) { }
	public IDictionary<string, HNPAFOGPHIM_PropertyMetadata> GJENOLNPNAC_Properties
	{
		get { return LALJJDFLKGD_properties; }
		set { LALJJDFLKGD_properties = value; }
	}
}

internal delegate void OGIPFNLOCBD_ExporterFunc    (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer);
public   delegate void OGIPFNLOCBD_ExporterFunc<T> (T LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer);
internal delegate object EFECLNPDNLP_ImporterFunc                (object BJKEOACPMHB_input);
public   delegate TValue EFECLNPDNLP_ImporterFunc<TJson, TValue> (TJson BJKEOACPMHB_input);

public delegate IHIFCPDDDKN_IJsonWrapper OEIBKOCANDB_WrapperFactory();

public class IKPIMINCOPI_JsonMapper // TypeDefIndex: 18705
{
	#region Fields
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
	#endregion

	#region Constructors
	// RVA: 0x8E90FC Offset: 0x8E90FC VA: 0x8E90FC
	static IKPIMINCOPI_JsonMapper()
	{
		EAKADAEHFNP_max_nesting_depth = 100;

		HBACDODMCJA_array_metadata = new Dictionary<Type, PNELLEFDAMJ_ArrayMetadata>();
		GGNJEAOKFFO_conv_ops = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
		AOCACFGDNAI_object_metadata = new Dictionary<Type, OBDHMJIBHIP_ObjectMetadata>();
		LEJBPAJGDGL_type_properties = new Dictionary<Type,
						IList<HNPAFOGPHIM_PropertyMetadata>>();

		NKKDEKFHAAC_static_writer = new KIJECNFNNDB_JsonWriter();

		NPCBCMOLMJK_datetime_format = DateTimeFormatInfo.InvariantInfo;

		CKAHMNAEIEB_base_exporters_table = new Dictionary<Type, OGIPFNLOCBD_ExporterFunc>();
		DJFPFJOCIJO_custom_exporters_table = new Dictionary<Type, OGIPFNLOCBD_ExporterFunc>();

		IFENDAFEPNC_base_importers_table = new Dictionary<Type,
							 IDictionary<Type, EFECLNPDNLP_ImporterFunc>>();
		FILBDMLOHNE_custom_importers_table = new Dictionary<Type,
							   IDictionary<Type, EFECLNPDNLP_ImporterFunc>>();

		FCBHJMAFPOG_RegisterBaseExporters();
		BLKCGAADNBI_RegisterBaseImporters();
	}
	#endregion

	#region Private Methods
	// RVA: 0x8EB8CC Offset: 0x8EB8CC VA: 0x8EB8CC
	private static void FNJALHOGCFM_AddArrayMetadata(Type INDDJNMPONH_type)
	{
		if (HBACDODMCJA_array_metadata.ContainsKey(INDDJNMPONH_type))
			return;

		PNELLEFDAMJ_ArrayMetadata data = new PNELLEFDAMJ_ArrayMetadata();

		data.EPNGJLOKGIF_IsArray = INDDJNMPONH_type.IsArray;

		if (INDDJNMPONH_type.GetInterface("System.Collections.IList") != null)
			data.AHEAPECLDEJ_IsList = true;
		
		foreach (PropertyInfo p_info in INDDJNMPONH_type.GetProperties())
		{
			if (p_info.Name != "Item")
				continue;

			ParameterInfo[] parameters = p_info.GetIndexParameters();

			if (parameters.Length != 1)
				continue;

			if (parameters[0].ParameterType == typeof(int))
				data.CHHEJNLOIEB_ElementType = p_info.PropertyType;
		}

		lock (ADLIMKLIAFM_array_metadata_lock)
		{
			try
			{
				HBACDODMCJA_array_metadata.Add(INDDJNMPONH_type, data);
			}
			catch (ArgumentException)
			{
				return;
			}
		}
	}

	// RVA: 0x8EBF34 Offset: 0x8EBF34 VA: 0x8EBF34
	private static void NHFPMEJCJJD_AddObjectMetadata(Type INDDJNMPONH_type)
	{
		if (AOCACFGDNAI_object_metadata.ContainsKey(INDDJNMPONH_type))
			return;

		OBDHMJIBHIP_ObjectMetadata data = new OBDHMJIBHIP_ObjectMetadata();

		if (INDDJNMPONH_type.GetInterface("System.Collections.IDictionary") != null)
			data.EBIEKOOCMMM_IsDictionary = true;

		data.GJENOLNPNAC_Properties = new Dictionary<string, HNPAFOGPHIM_PropertyMetadata>();

		foreach (PropertyInfo p_info in INDDJNMPONH_type.GetProperties())
		{
			if (p_info.Name == "Item")
			{
				ParameterInfo[] parameters = p_info.GetIndexParameters();

				if (parameters.Length != 1)
					continue;

				if (parameters[0].ParameterType == typeof(string))
					data.CHHEJNLOIEB_ElementType = p_info.PropertyType;

				continue;
			}

			HNPAFOGPHIM_PropertyMetadata p_data = new HNPAFOGPHIM_PropertyMetadata();
			p_data.HHKBDDNBEAA_Info = p_info;
			p_data.JMKADEBOBLA_Type = p_info.PropertyType;

			data.GJENOLNPNAC_Properties.Add(p_info.Name, p_data);
		}

		foreach (FieldInfo f_info in type.GetFields())
		{
			HNPAFOGPHIM_PropertyMetadata p_data = new HNPAFOGPHIM_PropertyMetadata();
			p_data.HHKBDDNBEAA_Info = f_info;
			p_data.KFKMLGBHPFI_IsField = true;
			p_data.JMKADEBOBLA_Type = f_info.FieldType;

			data.GJENOLNPNAC_Properties.Add(f_info.Name, p_data);
		}

		lock (EGMFLEOLEHJ_object_metadata_lock)
		{
			try
			{
				AOCACFGDNAI_object_metadata.Add(INDDJNMPONH_type, data);
			}
			catch (ArgumentException)
			{
				return;
			}
		}
	}

	// RVA: 0x8EC850 Offset: 0x8EC850 VA: 0x8EC850
	private static void GLDMGHFLHIL_AddTypeProperties(Type INDDJNMPONH_type)
	{
		if (LEJBPAJGDGL_type_properties.ContainsKey(INDDJNMPONH_type))
			return;

		IList<HNPAFOGPHIM_PropertyMetadata> props = new List<HNPAFOGPHIM_PropertyMetadata>();

		foreach (PropertyInfo p_info in INDDJNMPONH_type.GetProperties())
		{
			if (p_info.Name == "Item")
				continue;

			HNPAFOGPHIM_PropertyMetadata p_data = new HNPAFOGPHIM_PropertyMetadata();
			p_data.HHKBDDNBEAA_Info = p_info;
			p_data.KFKMLGBHPFI_IsField = false;
			props.Add(p_data);
		}

		foreach (FieldInfo f_info in INDDJNMPONH_type.GetFields())
		{
			HNPAFOGPHIM_PropertyMetadata p_data = new HNPAFOGPHIM_PropertyMetadata();
			p_data.HHKBDDNBEAA_Info = f_info;
			p_data.KFKMLGBHPFI_IsField = true;

			props.Add(p_data);
		}

		lock (DDEGDJNNPMF_type_properties_lock)
		{
			try
			{
				LEJBPAJGDGL_type_properties.Add(INDDJNMPONH_type, props);
			}
			catch (ArgumentException)
			{
				return;
			}
		}
	}

	// RVA: 0x8ECEEC Offset: 0x8ECEEC VA: 0x8ECEEC
	private static MethodInfo KCEEPBALDNK_GetConvOp(Type ECHKGBBOLFM_t1, Type KAMKECFBELN_t2)
	{
		lock (ODDJPNEIIHM_conv_ops_lock)
		{
			if (!GGNJEAOKFFO_conv_ops.ContainsKey(t1))
				GGNJEAOKFFO_conv_ops.Add(t1, new Dictionary<Type, MethodInfo>());
		}

		if (GGNJEAOKFFO_conv_ops[t1].ContainsKey(t2))
			return conv_ops[t1][t2];

		MethodInfo op = t1.GetMethod(
			"op_Implicit", new Type[] { t2 });

		lock (ODDJPNEIIHM_conv_ops_lock)
		{
			try
			{
				GGNJEAOKFFO_conv_ops[t1].Add(t2, op);
			}
			catch (ArgumentException)
			{
				return GGNJEAOKFFO_conv_ops[t1][t2];
			}
		}

		return op;
	}

	// RVA: 0x8EDA54 Offset: 0x8EDA54 VA: 0x8EDA54
	private static object GAPADDGOKOC_ReadValue(Type OGHDELCOELF_inst_type, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
	{
		CLJIOLIEPNA_reader.Read();

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HCCMCHLILCI_ArrayEnd)
			return null;

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.GMKPJPDCMJM_Null)
		{

			if (!OGHDELCOELF_inst_type.IsClass)
				throw new IKFDGFEAJPL_JsonException(String.Format(
						"Can't assign null to an instance of type {0}",
						inst_type));

			return null;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.PFOFBNKFKCA_Double ||
			CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.CEIBAFOCNCA_Int ||
			CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HJBKGEBNJMP_Long ||
			CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.IAAHPCHFCFB_String ||
			CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.JIJLIKNGOOH_Boolean)
		{

			Type json_type = CLJIOLIEPNA_reader.BLNDFNMPILA_Value.GetType();

			if (OGHDELCOELF_inst_type.IsAssignableFrom(json_type))
				return CLJIOLIEPNA_reader.BLNDFNMPILA_Value;

			// If there's a custom importer that fits, use it
			if (FILBDMLOHNE_custom_importers_table.ContainsKey(json_type) &&
				FILBDMLOHNE_custom_importers_table[json_type].ContainsKey(
					OGHDELCOELF_inst_type))
			{

				EFECLNPDNLP_ImporterFunc importer =
					FILBDMLOHNE_custom_importers_table[json_type][OGHDELCOELF_inst_type];

				return importer(CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			}

			// Maybe there's a base importer that works
			if (IFENDAFEPNC_base_importers_table.ContainsKey(json_type) &&
				IFENDAFEPNC_base_importers_table[json_type].ContainsKey(
					OGHDELCOELF_inst_type))
			{

				EFECLNPDNLP_ImporterFunc importer =
					IFENDAFEPNC_base_importers_table[json_type][OGHDELCOELF_inst_type];

				return importer(CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			}

			// Maybe it's an enum
			if (OGHDELCOELF_inst_type.IsEnum)
				return Enum.ToObject(OGHDELCOELF_inst_type, CLJIOLIEPNA_reader.BLNDFNMPILA_Value);

			// Try using an implicit conversion operator
			MethodInfo conv_op = KCEEPBALDNK_GetConvOp(OGHDELCOELF_inst_type, json_type);

			if (conv_op != null)
				return conv_op.Invoke(null,
									   new object[] { CLJIOLIEPNA_reader.BLNDFNMPILA_Value });

			// No luck
			throw new IKFDGFEAJPL_JsonException(String.Format(
					"Can't assign value '{0}' (type {1}) to type {2}",
					CLJIOLIEPNA_reader.BLNDFNMPILA_Value, json_type, OGHDELCOELF_inst_type));
		}

		object instance = null;

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.LNNBLGKFCCA_ArrayStart)
		{

			FNJALHOGCFM_AddArrayMetadata(OGHDELCOELF_inst_type);
			PNELLEFDAMJ_ArrayMetadata t_data = HBACDODMCJA_array_metadata[OGHDELCOELF_inst_type];

			if (!t_data.EPNGJLOKGIF_IsArray && !t_data.AHEAPECLDEJ_IsList)
				throw new IKFDGFEAJPL_JsonException(String.Format(
						"Type {0} can't act as an array",
						OGHDELCOELF_inst_type));

			IList list;
			Type elem_type;

			if (!t_data.EPNGJLOKGIF_IsArray)
			{
				list = (IList)Activator.CreateInstance(OGHDELCOELF_inst_type);
				elem_type = t_data.CHHEJNLOIEB_ElementType;
			}
			else
			{
				list = new ArrayList();
				elem_type = OGHDELCOELF_inst_type.GetElementType();
			}

			while (true)
			{
				object item = ReadValue(elem_type, CLJIOLIEPNA_reader);
				if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HCCMCHLILCI_ArrayEnd)
					break;

				list.Add(item);
			}

			if (t_data.EPNGJLOKGIF_IsArray)
			{
				int n = list.Count;
				instance = Array.CreateInstance(elem_type, n);

				for (int i = 0; i < n; i++)
					((Array)instance).SetValue(list[i], i);
			}
			else
				instance = list;

		}
		else if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.EKHMLPGOKGB_ObjectStart)
		{

			NHFPMEJCJJD_AddObjectMetadata(OGHDELCOELF_inst_type);
			OBDHMJIBHIP_ObjectMetadata t_data = AOCACFGDNAI_object_metadata[OGHDELCOELF_inst_type];

			instance = Activator.CreateInstance(OGHDELCOELF_inst_type);

			while (true)
			{
				CLJIOLIEPNA_reader.FKGBNKPHCJL_Read();

				if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.EANBLFODAJI_ObjectEnd)
					break;

				string property = (string)CLJIOLIEPNA_reader.BLNDFNMPILA_Value;

				if (t_data.GJENOLNPNAC_Properties.ContainsKey(property))
				{
					HNPAFOGPHIM_PropertyMetadata prop_data =
						t_data.GJENOLNPNAC_Properties[property];

					if (prop_data.KFKMLGBHPFI_IsField)
					{
						((FieldInfo)prop_data.HHKBDDNBEAA_Info).SetValue(
							instance, GAPADDGOKOC_ReadValue(prop_data.JMKADEBOBLA_Type, CLJIOLIEPNA_reader));
					}
					else
					{
						PropertyInfo p_info =
							(PropertyInfo)prop_data.HHKBDDNBEAA_Info;

						if (p_info.CanWrite)
							p_info.SetValue(
								instance,
								GAPADDGOKOC_ReadValue(prop_data.JMKADEBOBLA_Type, CLJIOLIEPNA_reader),
								null);
						else
							GAPADDGOKOC_ReadValue(prop_data.JMKADEBOBLA_Type, CLJIOLIEPNA_reader);
					}

				}
				else
				{
					if (!t_data.EBIEKOOCMMM_IsDictionary)
						throw new IKFDGFEAJPL_JsonException(String.Format(
								"The type {0} doesn't have the " +
								"property '{1}'", OGHDELCOELF_inst_type, property));

					((IDictionary)instance).Add(
						property, GAPADDGOKOC_ReadValue(
							t_data.CHHEJNLOIEB_ElementType, CLJIOLIEPNA_reader));
				}

			}

		}

		return instance;
	}

	// RVA: 0x8EF3FC Offset: 0x8EF3FC VA: 0x8EF3FC
	private static IHIFCPDDDKN_IJsonWrapper GAPADDGOKOC_ReadValue(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
	{
		CLJIOLIEPNA_reader.FKGBNKPHCJL_Read();

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HCCMCHLILCI_ArrayEnd ||
			CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.GMKPJPDCMJM_Null)
			return null;

		IHIFCPDDDKN_IJsonWrapper instance = BJECIFKPLJC_factory();

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.IAAHPCHFCFB_String)
		{
			instance.BIFDLDOBBEF_SetString((string)CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			return instance;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.PFOFBNKFKCA_Double)
		{
			instance.LACMCDADMBP_SetDouble((double)CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			return instance;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.CEIBAFOCNCA_Int)
		{
			instance.EOPNENFNMGE_SetInt((int)CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			return instance;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HJBKGEBNJMP_Long)
		{
			instance.BOGHKGJMJKL_SetLong((long)CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			return instance;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.JIJLIKNGOOH_Boolean)
		{
			instance.BDMBEANLAFO_SetBoolean((bool)CLJIOLIEPNA_reader.BLNDFNMPILA_Value);
			return instance;
		}

		if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.LNNBLGKFCCA_ArrayStart)
		{
			instance.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			while (true)
			{
				IHIFCPDDDKN_IJsonWrapper item = GAPADDGOKOC_ReadValue(BJECIFKPLJC_factory, CLJIOLIEPNA_reader);
				if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.HCCMCHLILCI_ArrayEnd)
					break;

				((IList)instance).Add(item);
			}
		}
		else if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.EKHMLPGOKGB_ObjectStart)
		{
			instance.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);

			while (true)
			{
				CLJIOLIEPNA_reader.FKGBNKPHCJL_Read();

				if (CLJIOLIEPNA_reader.FDPPJPGNCMK_Token == LIMGNGJNDAK_JsonToken.EANBLFODAJI_ObjectEnd)
					break;

				string property = (string)CLJIOLIEPNA_reader.BLNDFNMPILA_Value;

				((IDictionary)instance)[property] = GAPADDGOKOC_ReadValue(
					BJECIFKPLJC_factory, CLJIOLIEPNA_reader);
			}

		}

		return instance;
	}

	// RVA: 0x8E9430 Offset: 0x8E9430 VA: 0x8E9430
	private static void FCBHJMAFPOG_RegisterBaseExporters()
	{
		CKAHMNAEIEB_base_exporters_table[typeof(byte)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToInt32((byte)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(char)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToString((char)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(DateTime)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToString((DateTime)LMNBBOIJBBL_obj,
												NPCBCMOLMJK_datetime_format));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(decimal)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write((decimal)LMNBBOIJBBL_obj);
			};

		CKAHMNAEIEB_base_exporters_table[typeof(sbyte)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToInt32((sbyte)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(short)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToInt32((short)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(ushort)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToInt32((ushort)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(uint)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write(Convert.ToUInt64((uint)LMNBBOIJBBL_obj));
			};

		CKAHMNAEIEB_base_exporters_table[typeof(ulong)] =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write((ulong)LMNBBOIJBBL_obj);
			};
	}

	// RVA: 0x8EA5E8 Offset: 0x8EA5E8 VA: 0x8EA5E8
	private static void BLKCGAADNBI_RegisterBaseImporters()
	{
		EFECLNPDNLP_ImporterFunc importer;

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToByte((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(byte), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToUInt64((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(ulong), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToSByte((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(sbyte), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToInt16((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(short), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToUInt16((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(ushort), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToUInt32((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(uint), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToSingle((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(float), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToDouble((int)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(int),
						  typeof(double), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToDecimal((double)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(double),
						  typeof(decimal), importer);


		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToUInt32((long)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(long),
						  typeof(uint), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToChar((string)BJKEOACPMHB_input);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(string),
						  typeof(char), importer);

		importer = delegate (object BJKEOACPMHB_input) {
			return Convert.ToDateTime((string)BJKEOACPMHB_input, NPCBCMOLMJK_datetime_format);
		};
		BLKCGAADNBI_RegisterBaseImporters(IFENDAFEPNC_base_importers_table, typeof(string),
						  typeof(DateTime), importer);
	}

	// RVA: 0x8EFE2C Offset: 0x8EFE2C VA: 0x8EFE2C
	private static void MJBPPCBFPFG_RegisterImporter(IDictionary<Type, IDictionary<Type, EFECLNPDNLP_ImporterFunc>> CDENCMNHNGA_table, Type AJAIOPIHGCL_json_type, Type FMENOANEJOF_value_type, EFECLNPDNLP_ImporterFunc FDJLCJHLGFI_importer)
    {
        if (!CDENCMNHNGA_table.ContainsKey(AJAIOPIHGCL_json_type))
			CDENCMNHNGA_table.Add(AJAIOPIHGCL_json_type, new Dictionary<Type, EFECLNPDNLP_ImporterFunc>());

		CDENCMNHNGA_table[AJAIOPIHGCL_json_type][FMENOANEJOF_value_type] = FDJLCJHLGFI_importer;
    }

	// RVA: 0x8F0110 Offset: 0x8F0110 VA: 0x8F0110
	private static void MDNHFHCGIMC_WriteValue(object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer, bool AHCEFLAMCNH_writer_is_private, int DMGALMEPLCF_depth)
	{
		if (DMGALMEPLCF_depth > EAKADAEHFNP_max_nesting_depth)
			throw new IKFDGFEAJPL_JsonException(
				String.Format("Max allowed object depth reached while " +
							   "trying to export from type {0}",
							   LMNBBOIJBBL_obj.GetType()));

		if (LMNBBOIJBBL_obj == null)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write(null);
			return;
		}

		if (LMNBBOIJBBL_obj is IHIFCPDDDKN_IJsonWrapper)
		{
			if (AHCEFLAMCNH_writer_is_private)
				OMLLGAKPMAN_writer.CJNPADFBBBB_TextOMLLGAKPMAN_writer.FPEKCEGADMG_Write(((IHIFCPDDDKN_IJsonWrapper)obj).ToJson());
			else
				((IHIFCPDDDKN_IJsonWrapper)obj).ToJson(OMLLGAKPMAN_writer);

			return;
		}

		if (LMNBBOIJBBL_obj is String)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write((string)LMNBBOIJBBL_obj);
			return;
		}

		if (LMNBBOIJBBL_obj is Double)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write((double)LMNBBOIJBBL_obj);
			return;
		}

		if (LMNBBOIJBBL_obj is Int32)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write((int)LMNBBOIJBBL_obj);
			return;
		}

		if (LMNBBOIJBBL_obj is Boolean)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write((bool)LMNBBOIJBBL_obj);
			return;
		}

		if (LMNBBOIJBBL_obj is Int64)
		{
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write((long)LMNBBOIJBBL_obj);
			return;
		}

		if (LMNBBOIJBBL_obj is Array)
		{
			OMLLGAKPMAN_writer.PCMFCDODNMB_WriteArrayStart();

			foreach (object elem in (Array)LMNBBOIJBBL_obj)
				MDNHFHCGIMC_WriteValue(elem, OMLLGAKPMAN_writer, AHCEFLAMCNH_writer_is_private, DMGALMEPLCF_depth + 1);

			OMLLGAKPMAN_writer.KJLDOKNDPCO_WriteArrayEnd();

			return;
		}

		if (LMNBBOIJBBL_obj is IList)
		{
			OMLLGAKPMAN_writer.PCMFCDODNMB_WriteArrayStart();
			foreach (object elem in (IList)LMNBBOIJBBL_obj)
				MDNHFHCGIMC_WriteValue(elem, OMLLGAKPMAN_writer, AHCEFLAMCNH_writer_is_private, DMGALMEPLCF_depth + 1);
			OMLLGAKPMAN_writer.KJLDOKNDPCO_WriteArrayEnd();

			return;
		}

		if (LMNBBOIJBBL_obj is IDictionary)
		{
			OMLLGAKPMAN_writer.APFBNDGICIA_WriteObjectStart();
			foreach (DictionaryEntry entry in (IDictionary)LMNBBOIJBBL_obj)
			{
				OMLLGAKPMAN_writer.ABKCJDMNIOC_WritePropertyName((string)entry.Key);
				MDNHFHCGIMC_WriteValue(entry.Value, OMLLGAKPMAN_writer, AHCEFLAMCNH_writer_is_private,
							DMGALMEPLCF_depth + 1);
			}
			OMLLGAKPMAN_writer.LKJOBFDIMPF_WriteObjectEnd();

			return;
		}

		Type obj_type = LMNBBOIJBBL_obj.GetType();

		// See if there's a custom exporter for the object
		if (DJFPFJOCIJO_custom_exporters_table.ContainsKey(obj_type))
		{
			OGIPFNLOCBD_ExporterFunc exporter = DJFPFJOCIJO_custom_exporters_table[obj_type];
			exporter(LMNBBOIJBBL_obj, OMLLGAKPMAN_writer);

			return;
		}

		// If not, maybe there's a base exporter
		if (CKAHMNAEIEB_base_exporters_table.ContainsKey(obj_type))
		{
			OGIPFNLOCBD_ExporterFunc exporter = CKAHMNAEIEB_base_exporters_table[obj_type];
			exporter(LMNBBOIJBBL_obj, OMLLGAKPMAN_writer);

			return;
		}

		// Last option, let's see if it's an enum
		if (LMNBBOIJBBL_obj is Enum)
		{
			Type e_type = Enum.GetUnderlyingType(obj_type);

			if (e_type == typeof(long)
				|| e_type == typeof(uint)
				|| e_type == typeof(ulong))
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write((ulong)LMNBBOIJBBL_obj);
			else
				OMLLGAKPMAN_writer.FPEKCEGADMG_Write((int)LMNBBOIJBBL_obj);

			return;
		}

		// Okay, so it looks like the input should be exported as an
		// object
		GLDMGHFLHIL_AddTypeProperties(obj_type);
		IList<HNPAFOGPHIM_PropertyMetadata> props = LEJBPAJGDGL_type_properties[obj_type];

		OMLLGAKPMAN_writer.APFBNDGICIA_WriteObjectStart();
		foreach (HNPAFOGPHIM_PropertyMetadata p_data in props)
		{
			if (p_data.KFKMLGBHPFI_IsField)
			{
				OMLLGAKPMAN_writer.ABKCJDMNIOC_WritePropertyName(p_data.HHKBDDNBEAA_Info.Name);
				MDNHFHCGIMC_WriteValue(((FieldInfo)p_data.HHKBDDNBEAA_Info).GetValue(LMNBBOIJBBL_obj),
							OMLLGAKPMAN_writer, AHCEFLAMCNH_writer_is_private, DMGALMEPLCF_depth + 1);
			}
			else
			{
				PropertyInfo p_info = (PropertyInfo)p_data.HHKBDDNBEAA_Info;

				if (p_info.CanRead)
				{
					OMLLGAKPMAN_writer.ABKCJDMNIOC_WritePropertyName(p_data.HHKBDDNBEAA_Info.Name);
					MDNHFHCGIMC_WriteValue(p_info.GetValue(LMNBBOIJBBL_obj, null),
								OMLLGAKPMAN_writer, AHCEFLAMCNH_writer_is_private, DMGALMEPLCF_depth + 1);
				}
			}
		}
		OMLLGAKPMAN_writer.LKJOBFDIMPF_WriteObjectEnd();
	}
	#endregion

	// RVA: 0x8F1AD8 Offset: 0x8F1AD8 VA: 0x8F1AD8
	public static string EJCOJCGIBNG_ToJson(object LMNBBOIJBBL_obj)
	{
		lock (BNBONKFHCKP_static_writer_lock)
		{
			NKKDEKFHAAC_static_writer.LHPDDGIJKNB_Reset();

			MDNHFHCGIMC_WriteValue(LMNBBOIJBBL_obj, NKKDEKFHAAC_static_writer, true, 0);

			return NKKDEKFHAAC_static_writer.ToString();
		}
	}

	// RVA: 0x8F1CD4 Offset: 0x8F1CD4 VA: 0x8F1CD4
	public static void EJCOJCGIBNG_ToJson(object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer)
	{
		MDNHFHCGIMC_WriteValue(obj, OMLLGAKPMAN_writer, false, 0);
	}

	// RVA: 0x8F1D6C Offset: 0x8F1D6C VA: 0x8F1D6C
	public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
	{
		return (EDOHBJAPLPF_JsonData)EJMBECKABEL_ToWrapper(
			delegate { return new EDOHBJAPLPF_JsonData(); }, CLJIOLIEPNA_reader);
	}

	// RVA: 0x8F1FF0 Offset: 0x8F1FF0 VA: 0x8F1FF0
	public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(TextReader CLJIOLIEPNA_reader)
	{
		MFJGDLBFMEL_JsonReader json_reader = new MFJGDLBFMEL_JsonReader(CLJIOLIEPNA_reader);

		return (EDOHBJAPLPF_JsonData)EJMBECKABEL_ToWrapper(
			delegate { return new EDOHBJAPLPF_JsonData(); }, json_reader);
	}

	// RVA: 0x8E8D34 Offset: 0x8E8D34 VA: 0x8E8D34
	public static EDOHBJAPLPF_JsonData PFAMKCGJKKL_ToObject(string DLENPPIJNPA_json)
	{
		return (EDOHBJAPLPF_JsonData)EJMBECKABEL_ToWrapper(
			delegate { return new EDOHBJAPLPF_JsonData(); }, DLENPPIJNPA_json);
	}
	// RVA: -1 Offset: -1
	public static T PFAMKCGJKKL_ToObject<T>(MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
	{
		return (T)GAPADDGOKOC_ReadValue(typeof(T), CLJIOLIEPNA_reader);
	}
	/* GenericInstMethod :
    |
    |-RVA: 0x1AB5D18 Offset: 0x1AB5D18 VA: 0x1AB5D18
    |-IKPIMINCOPI.PFAMKCGJKKL<object>
    */

	// RVA: -1 Offset: -1
	public static T PFAMKCGJKKL_ToObject<T>(TextReader CLJIOLIEPNA_reader)
	{
		MFJGDLBFMEL_JsonReader json_reader = new MFJGDLBFMEL_JsonReader(CLJIOLIEPNA_reader);

		return (T)GAPADDGOKOC_ReadValue(typeof(T), json_reader);
	}
	/* GenericInstMethod :
    |
    |-RVA: 0x1AB5E90 Offset: 0x1AB5E90 VA: 0x1AB5E90
    |-IKPIMINCOPI.PFAMKCGJKKL<object>
    */

	// RVA: -1 Offset: -1
	public static T PFAMKCGJKKL_ToObject<T>(string DLENPPIJNPA_json)
	{
		MFJGDLBFMEL_JsonReader reader = new MFJGDLBFMEL_JsonReader(DLENPPIJNPA_json);

		return (T)GAPADDGOKOC_ReadValue(typeof(T), reader);
	}
	/* GenericInstMethod :
    |
    |-RVA: 0x1AB602C Offset: 0x1AB602C VA: 0x1AB602C
    |-IKPIMINCOPI.PFAMKCGJKKL<object>
    */

	// RVA: 0x8F1F68 Offset: 0x8F1F68 VA: 0x8F1F68
	public static IHIFCPDDDKN_IJsonWrapper EJMBECKABEL_ToWrapper(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, MFJGDLBFMEL_JsonReader CLJIOLIEPNA_reader)
	{
		return GAPADDGOKOC_ReadValue(BJECIFKPLJC_factory, CLJIOLIEPNA_reader);
	}

	// RVA: 0x8F2210 Offset: 0x8F2210 VA: 0x8F2210
	public static IHIFCPDDDKN_IJsonWrapper EJMBECKABEL_ToWrapper(OEIBKOCANDB_WrapperFactory BJECIFKPLJC_factory, string DLENPPIJNPA_json)
	{
		MFJGDLBFMEL_JsonReader reader = new MFJGDLBFMEL_JsonReader(DLENPPIJNPA_json);

		return GAPADDGOKOC_ReadValue(BJECIFKPLJC_factory, reader);
	}

	// RVA: -1 Offset: -1
	public static void LIEDACPLEMK_RegisterExporter<T>(FMJNNJIAOIG_ExporterFunc<T> IDCEIBMHEGO_exporter)
	{
		OGIPFNLOCBD_ExporterFunc exporter_wrapper =
			delegate (object LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer) {
				IDCEIBMHEGO_exporter((T)LMNBBOIJBBL_obj, OMLLGAKPMAN_writer);
			};

		DJFPFJOCIJO_custom_exporters_table[typeof(T)] = exporter_wrapper;
	}
	/* GenericInstMethod :
    |
    |-RVA: 0x1C79A5C Offset: 0x1C79A5C VA: 0x1C79A5C
    |-IKPIMINCOPI.LIEDACPLEMK<object>
    */

	// RVA: -1 Offset: -1
	public static void MJBPPCBFPFG_RegisterImporter<TJson, TValue>(MAIGGGACCCE_ImporterFunc<TJson, TValue> FDJLCJHLGFI_importer)
	{
		EFECLNPDNLP_ImporterFunc importer_wrapper =
			delegate (object BJKEOACPMHB_input) {
				return FDJLCJHLGFI_importer((TJson)BJKEOACPMHB_input);
			};

		MJBPPCBFPFG_RegisterImporter(FILBDMLOHNE_custom_importers_table, typeof(TJson),
						  typeof(TValue), importer_wrapper);
	}
	/* GenericInstMethod :
    |
    |-RVA: 0x1C79C44 Offset: 0x1C79C44 VA: 0x1C79C44
    |-IKPIMINCOPI.MJBPPCBFPFG<object, object>
    */

	// RVA: 0x8F22BC Offset: 0x8F22BC VA: 0x8F22BC
	public static void PHGPKMENKIC_UnregisterExporters()
	{
		DJFPFJOCIJO_custom_exporters_table.Clear();
	}

	// RVA: 0x8F23D0 Offset: 0x8F23D0 VA: 0x8F23D0
	public static void GAHIHNFIDCH_UnregisterImporters()
	{
		FILBDMLOHNE_custom_importers_table.Clear();
	}

	// RVA: 0x8F24E4 Offset: 0x8F24E4 VA: 0x8F24E4
	//public void .ctor() { }
}
