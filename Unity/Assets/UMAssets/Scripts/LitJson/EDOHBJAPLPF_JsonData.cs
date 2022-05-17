using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

//https://github.com/LitJSON/litjson/blob/cd646def20af4aff19a02f8e7bcdd28b54fc850f/src/LitJson/JsonData.cs

public class EDOHBJAPLPF_JsonData : IHIFCPDDDKN_IJsonWrapper, IEquatable<EDOHBJAPLPF_JsonData> 
{
	#region Fields
	private IList<EDOHBJAPLPF_JsonData> HGNCNIHIPJJ_inst_array; // 0x8
	private bool KIDMELNMHEN_inst_boolean; // 0xC
	private double EMLHILAIKMM_inst_double; // 0x10
	private int NFGINMFAEOB_inst_int; // 0x18
	private long IKLMIBFMGEC_inst_long; // 0x20
	private IDictionary<string, EDOHBJAPLPF_JsonData> JMGLNPKCBPG_inst_object; // 0x28
	private string FCNDAFPPLIN_inst_string; // 0x2C
	private string DLENPPIJNPA_json; // 0x30
	private JFBMDLGBPEN_JsonType INDDJNMPONH_type; // 0x34
	private IList<KeyValuePair<string, EDOHBJAPLPF_JsonData>> NAMGNKNCNON_object_list; // 0x38
	#endregion

	// ???
	// private static string HKICMNAACDA; // 0x0
	// private static string BNKHBCBJBKI; // 0x4
	// private static string CKHEDJODNIP; // 0x8

	#region Properties
	// // RVA: 0x1509FFC Offset: 0x1509FFC VA: 0x1509FFC
	//public int get_Count() 
	public int HNBFOAJIIAL_Count {get { return CBJBIDKHLFM_EnsureCollection ().Count; }}
	// // RVA: 0x150A1E4 Offset: 0x150A1E4 VA: 0x150A1E4
	// public bool HJENKHBBMMO() { }
	public bool EPNGJLOKGIF_IsArray { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array; } }
	// // RVA: 0x150A1F8 Offset: 0x150A1F8 VA: 0x150A1F8
	// public bool BEINOJJBBHP() { }
	public bool DGGFODFFPFJ_IsBoolean { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean; } }
	// // RVA: 0x150A20C Offset: 0x150A20C VA: 0x150A20C
	// public bool AIAPBMFKNKL() { }
	public bool NFPOKKABOHN_IsDouble { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double; } }
	// // RVA: 0x150A220 Offset: 0x150A220 VA: 0x150A220
	// public bool HPAMBFKGDJC() { }
	public bool MDDJBLEDMBJ_IsInt { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int; } }
	// // RVA: 0x150A234 Offset: 0x150A234 VA: 0x150A234
	// public bool FAPIDDCBEAC() { }
	public bool DCPEFFOMOOK_IsLong { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long; } }
	// // RVA: 0x150A248 Offset: 0x150A248 VA: 0x150A248
	// public bool CBKPPCPDEOB() { }
	public bool LLHIGGPIILM_IsObject { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object; } }
	// // RVA: 0x1502328 Offset: 0x1502328 VA: 0x1502328
	// public bool OKNHHEOKLNL() { }
	public bool EPNAPDBIJJE_IsString { get { return INDDJNMPONH_type == JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String; } }
	#endregion

	#region ICollection Properties
	// // RVA: 0x150A258 Offset: 0x150A258 VA: 0x150A258 Slot: 37
	// private int System.Collections.ICollection.get_Count() { }
	int /*JBBONHKCLEP*/ICollection.Count { get { return HNBFOAJIIAL_Count; } }
	// // RVA: 0x150A25C Offset: 0x150A25C VA: 0x150A25C Slot: 39
	// private bool System.Collections.ICollection.get_IsSynchronized() { }
	bool /*DFHCHKNCOKH*/ICollection.IsSynchronized { get { return CBJBIDKHLFM_EnsureCollection ().IsSynchronized; } }
	// // RVA: 0x150A33C Offset: 0x150A33C VA: 0x150A33C Slot: 38
	// private object System.Collections.ICollection.get_SyncRoot() { }
	object /*JGFINCEMACP*/ICollection.SyncRoot { get {return CBJBIDKHLFM_EnsureCollection ().SyncRoot;} }
	#endregion

	#region IDictionary Properties
	// // RVA: 0x150A41C Offset: 0x150A41C VA: 0x150A41C Slot: 54
	// private bool System.Collections.IDictionary.get_IsFixedSize() { }
	bool /*DFLHBPEDLDP*/IDictionary.IsFixedSize { get {return OGLGGGMGCPL_EnsureDictionary ().IsFixedSize;} }
	// // RVA: 0x150A668 Offset: 0x150A668 VA: 0x150A668 Slot: 53
	// private bool System.Collections.IDictionary.get_IsReadOnly() { }
	bool /*AOCHNLCOLHA*/IDictionary.IsReadOnly { get { return OGLGGGMGCPL_EnsureDictionary ().IsReadOnly;} }
	// // RVA: 0x150A748 Offset: 0x150A748 VA: 0x150A748 Slot: 48
	// private ICollection System.Collections.IDictionary.get_Keys() { }
	ICollection /*KPHOGDGIDEP*/IDictionary.Keys {
		get {
			OGLGGGMGCPL_EnsureDictionary ();
			IList<string> keys = new List<string> ();

			foreach (KeyValuePair<string, EDOHBJAPLPF_JsonData> entry in
						NAMGNKNCNON_object_list) {
				keys.Add (entry.Key);
			}

			return (ICollection) keys;
		}
	}
	// // RVA: 0x150ABE4 Offset: 0x150ABE4 VA: 0x150ABE4 Slot: 49
	// private ICollection System.Collections.IDictionary.get_Values() { }
	ICollection /*PHHGIAPGFCA*/IDictionary.Values {
		get {
			OGLGGGMGCPL_EnsureDictionary ();
			IList<EDOHBJAPLPF_JsonData> values = new List<EDOHBJAPLPF_JsonData> ();

			foreach (KeyValuePair<string, EDOHBJAPLPF_JsonData> entry in
						NAMGNKNCNON_object_list) {
				values.Add (entry.Value);
			}

			return (ICollection) values;
		}
	}
    #endregion

	#region IJsonWrapper Properties
	// // RVA: 0x150B080 Offset: 0x150B080 VA: 0x150B080 Slot: 4
	// private bool JIAGMFDJIPD() { }
	bool /*KJEGFCBGEPI*/IHIFCPDDDKN_IJsonWrapper.EPNGJLOKGIF_IsArray { get { return EPNGJLOKGIF_IsArray; } }
	// // RVA: 0x150B094 Offset: 0x150B094 VA: 0x150B094 Slot: 5
	//private bool DIKHMCDIHBD() { }
	bool /*GBFCKKLPFEC*/IHIFCPDDDKN_IJsonWrapper.DGGFODFFPFJ_IsBoolean {get { return DGGFODFFPFJ_IsBoolean; }}
	// // RVA: 0x150B0A8 Offset: 0x150B0A8 VA: 0x150B0A8 Slot: 6
	// private bool IOBNCJIPAHL() { }
	bool /*HPHDMLCBFBB*/IHIFCPDDDKN_IJsonWrapper.NFPOKKABOHN_IsDouble { get { return NFPOKKABOHN_IsDouble; } }
	// // RVA: 0x150B0BC Offset: 0x150B0BC VA: 0x150B0BC Slot: 7
	// private bool DDJEKBOGJKA() { }
	bool /*HCEOKJCMBPH*/IHIFCPDDDKN_IJsonWrapper.MDDJBLEDMBJ_IsInt { get { return MDDJBLEDMBJ_IsInt; } }
	// // RVA: 0x150B0D0 Offset: 0x150B0D0 VA: 0x150B0D0 Slot: 8
	// private bool PAAEFKOJPJK() { }
	bool /*OPMKCKPKFNK*/IHIFCPDDDKN_IJsonWrapper.DCPEFFOMOOK_IsLong { get { return DCPEFFOMOOK_IsLong; } }
	// // RVA: 0x150B0E4 Offset: 0x150B0E4 VA: 0x150B0E4 Slot: 9
	// private bool EHGMMJOKECG() { }
	bool /*CJEIAHJDJFG*/IHIFCPDDDKN_IJsonWrapper.LLHIGGPIILM_IsObject { get { return LLHIGGPIILM_IsObject; } }
	// // RVA: 0x150B0F4 Offset: 0x150B0F4 VA: 0x150B0F4 Slot: 10
	// private bool CIJPOELFMLM() { }
	bool /*HFDLKHMFBAP*/IHIFCPDDDKN_IJsonWrapper.EPNAPDBIJJE_IsString { get { return EPNAPDBIJJE_IsString; } }
    #endregion

	#region IList Properties
	// // RVA: 0x150B108 Offset: 0x150B108 VA: 0x150B108 Slot: 31
	// private bool System.Collections.IList.get_IsFixedSize() { }
	bool /*OKCODHDEHFP*/IList.IsFixedSize { get {
                return FMCDHFLLBGD_EnsureList ().IsFixedSize;
            } }
	// // RVA: 0x150B380 Offset: 0x150B380 VA: 0x150B380 Slot: 30
	// private bool System.Collections.IList.get_IsReadOnly() { }
	bool /*FDMEFDCFEEE*/IList.IsReadOnly { get {
                return FMCDHFLLBGD_EnsureList ().IsReadOnly;
            } }
    #endregion

	#region IDictionary Indexer
	// // RVA: 0x150B460 Offset: 0x150B460 VA: 0x150B460 Slot: 46
	// private object System.Collections.IDictionary.get_Item(object LJNAKDMILMC) { }
	// // RVA: 0x150B548 Offset: 0x150B548 VA: 0x150B548 Slot: 47
	// private void System.Collections.IDictionary.set_Item(object LJNAKDMILMC, object NANNGLGOFKH) { }
	object IDictionary.this[object key]  {
		get {
			return OGLGGGMGCPL_EnsureDictionary ()[key];
		}

		set {
			if (! (key is String))
				throw new ArgumentException (
					"The key has to be a string");

			EDOHBJAPLPF_JsonData data = NOJCMGAFAAC_ToJsonData (value);

			this[(string) key] = data;
		}
	}
	#endregion

	#region IOrderedDictionary Indexer
	// // RVA: 0x150B6EC Offset: 0x150B6EC VA: 0x150B6EC Slot: 41
	// private object System.Collections.Specialized.IOrderedDictionary.get_Item(int IOPHIHFOOEP) { }
	// // RVA: 0x150B808 Offset: 0x150B808 VA: 0x150B808 Slot: 42
	// private void System.Collections.Specialized.IOrderedDictionary.set_Item(int IOPHIHFOOEP, object NANNGLGOFKH) { }
	object /*NDBMABPFOBH*/IOrderedDictionary.this[int idx] {
		get {
			OGLGGGMGCPL_EnsureDictionary ();
			return NAMGNKNCNON_object_list[idx].Value;
		}

		set {
			OGLGGGMGCPL_EnsureDictionary ();
			EDOHBJAPLPF_JsonData data = NOJCMGAFAAC_ToJsonData (value);

			KeyValuePair<string, EDOHBJAPLPF_JsonData> old_entry = NAMGNKNCNON_object_list[idx];

			JMGLNPKCBPG_inst_object[old_entry.Key] = data;

			KeyValuePair<string, EDOHBJAPLPF_JsonData> entry =
				new KeyValuePair<string, EDOHBJAPLPF_JsonData> (old_entry.Key, data);

			NAMGNKNCNON_object_list[idx] = entry;
		}
	}
	#endregion

	#region IList Indexer
	// // RVA: 0x150BAB4 Offset: 0x150BAB4 VA: 0x150BAB4 Slot: 25
	// private object System.Collections.IList.get_Item(int OIPCCBHIKIA) { }
	// // RVA: 0x150BB9C Offset: 0x150BB9C VA: 0x150BB9C Slot: 26
	// private void System.Collections.IList.set_Item(int OIPCCBHIKIA, object NANNGLGOFKH) { }
	object /*EGJHEEAKBOH*/IList.this[int index] {
		get {
			return FMCDHFLLBGD_EnsureList ()[index];
		}

		set {
			FMCDHFLLBGD_EnsureList ();
			EDOHBJAPLPF_JsonData data = NOJCMGAFAAC_ToJsonData (value);

			this[index] = data;
		}
	}
	#endregion

	#region Public Indexers
	// // RVA: 0x14F3A88 Offset: 0x14F3A88 VA: 0x14F3A88
	// public EDOHBJAPLPF_JsonData GOAMILGNJIE(string GODGBGGHPNG) 
	// // RVA: 0x14F3498 Offset: 0x14F3498 VA: 0x14F3498
	// public void set_Item(string GODGBGGHPNG, EDOHBJAPLPF NANNGLGOFKH) { }
	public EDOHBJAPLPF_JsonData /*INIMBLOHIEF*/this[string GODGBGGHPNG_prop_name] {
		get {
			OGLGGGMGCPL_EnsureDictionary ();
			return JMGLNPKCBPG_inst_object[GODGBGGHPNG_prop_name];
		}

		set {
			OGLGGGMGCPL_EnsureDictionary ();

			KeyValuePair<string, EDOHBJAPLPF_JsonData> entry =
				new KeyValuePair<string, EDOHBJAPLPF_JsonData> (GODGBGGHPNG_prop_name, value);

			if (JMGLNPKCBPG_inst_object.ContainsKey (GODGBGGHPNG_prop_name)) {
				for (int i = 0; i < NAMGNKNCNON_object_list.Count; i++) {
					if (NAMGNKNCNON_object_list[i].Key == GODGBGGHPNG_prop_name) {
						NAMGNKNCNON_object_list[i] = entry;
						break;
					}
				}
			} else
				NAMGNKNCNON_object_list.Add (entry);

			JMGLNPKCBPG_inst_object[GODGBGGHPNG_prop_name] = value;

			DLENPPIJNPA_json = null;
		}
	}

	// // RVA: 0x150C0F8 Offset: 0x150C0F8 VA: 0x150C0F8
	//public EDOHBJAPLPF_JsonData GOAMILGNJIE(int OIPCCBHIKIA) 
	// // RVA: 0x150BBD0 Offset: 0x150BBD0 VA: 0x150BBD0
	// public void set_Item(int OIPCCBHIKIA, EDOHBJAPLPF NANNGLGOFKH) { }
	public EDOHBJAPLPF_JsonData /*INIMBLOHIEF*/this[int index] {
		get {
			CBJBIDKHLFM_EnsureCollection ();

			if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array)
				return HGNCNIHIPJJ_inst_array[index];

			return NAMGNKNCNON_object_list[index].Value;
		}

		set {
			CBJBIDKHLFM_EnsureCollection ();

			if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array)
				HGNCNIHIPJJ_inst_array[index] = value;
			else {
				KeyValuePair<string, EDOHBJAPLPF_JsonData> entry = NAMGNKNCNON_object_list[index];
				KeyValuePair<string, EDOHBJAPLPF_JsonData> new_entry =
					new KeyValuePair<string, EDOHBJAPLPF_JsonData> (entry.Key, value);

				NAMGNKNCNON_object_list[index] = new_entry;
				JMGLNPKCBPG_inst_object[entry.Key] = value;
			}

			DLENPPIJNPA_json = null;
		}
	}
    #endregion

	#region Constructors
	// // RVA: 0x14F3414 Offset: 0x14F3414 VA: 0x14F3414
	public EDOHBJAPLPF_JsonData() { }

	// // RVA: 0x150C2B4 Offset: 0x150C2B4 VA: 0x150C2B4
	public EDOHBJAPLPF_JsonData(bool GOOAMNCOICJ_boolean)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean;
		KIDMELNMHEN_inst_boolean = GOOAMNCOICJ_boolean;
	}

	// // RVA: 0x150C2DC Offset: 0x150C2DC VA: 0x150C2DC
	public EDOHBJAPLPF_JsonData(double AMFBGBPJEEC_number)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double;
		EMLHILAIKMM_inst_double = AMFBGBPJEEC_number;
	}

	// // RVA: 0x150C30C Offset: 0x150C30C VA: 0x150C30C
	public EDOHBJAPLPF_JsonData(int AMFBGBPJEEC_number)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int;
		NFGINMFAEOB_inst_int = AMFBGBPJEEC_number;
	}

	// // RVA: 0x150C334 Offset: 0x150C334 VA: 0x150C334
	public EDOHBJAPLPF_JsonData(long AMFBGBPJEEC_number)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long;
		IKLMIBFMGEC_inst_long = AMFBGBPJEEC_number;
	}

	// // RVA: 0x150C364 Offset: 0x150C364 VA: 0x150C364
	public EDOHBJAPLPF_JsonData(object LMNBBOIJBBL_obj)
	{
		if (LMNBBOIJBBL_obj is Boolean) {
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean;
			KIDMELNMHEN_inst_boolean = (bool) LMNBBOIJBBL_obj;
			return;
		}

		if (LMNBBOIJBBL_obj is Double) {
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double;
			EMLHILAIKMM_inst_double = (double) LMNBBOIJBBL_obj;
			return;
		}

		if (LMNBBOIJBBL_obj is Int32) {
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int;
			NFGINMFAEOB_inst_int = (int) LMNBBOIJBBL_obj;
			return;
		}

		if (LMNBBOIJBBL_obj is Int64) {
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long;
			IKLMIBFMGEC_inst_long = (long) LMNBBOIJBBL_obj;
			return;
		}

		if (LMNBBOIJBBL_obj is String) {
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String;
			FCNDAFPPLIN_inst_string = (string) LMNBBOIJBBL_obj;
			return;
		}

		throw new ArgumentException (
			"Unable to wrap the given object with JsonData");
	}

	// // RVA: 0x150C530 Offset: 0x150C530 VA: 0x150C530
	public EDOHBJAPLPF_JsonData(string JEHFDJPOEFF_str)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String;
		FCNDAFPPLIN_inst_string = JEHFDJPOEFF_str;
	}
    #endregion

	#region Implicit Conversions
	// // RVA: 0x150C558 Offset: 0x150C558 VA: 0x150C558
	public static /*EDOHBJAPLPF JNEJKMKNIJJ*/implicit operator EDOHBJAPLPF_JsonData(bool IDLHJIOMJBK_data) 
	{ 
		return new EDOHBJAPLPF_JsonData(IDLHJIOMJBK_data);
	}

	// // RVA: 0x150C5D4 Offset: 0x150C5D4 VA: 0x150C5D4
	public static /*EDOHBJAPLPF JNEJKMKNIJJ*/implicit operator EDOHBJAPLPF_JsonData(double IDLHJIOMJBK_data)
	{ 
		return new EDOHBJAPLPF_JsonData(IDLHJIOMJBK_data);
	}

	// // RVA: 0x14F3988 Offset: 0x14F3988 VA: 0x14F3988
	public static /*EDOHBJAPLPF JNEJKMKNIJJ*/implicit operator EDOHBJAPLPF_JsonData(int IDLHJIOMJBK_data)
	{ 
		return new EDOHBJAPLPF_JsonData(IDLHJIOMJBK_data);
	}

	// // RVA: 0x14F3A04 Offset: 0x14F3A04 VA: 0x14F3A04
	public static /*EDOHBJAPLPF JNEJKMKNIJJ*/implicit operator EDOHBJAPLPF_JsonData(long IDLHJIOMJBK_data)
	{ 
		return new EDOHBJAPLPF_JsonData(IDLHJIOMJBK_data);
	}

	// // RVA: 0x14F341C Offset: 0x14F341C VA: 0x14F341C
	public static /*EDOHBJAPLPF JNEJKMKNIJJ*/implicit operator EDOHBJAPLPF_JsonData(string IDLHJIOMJBK_data)
	{ 
		return new EDOHBJAPLPF_JsonData(IDLHJIOMJBK_data);
	}
	#endregion
	
	#region Explicit Conversions
	// // RVA: 0x150C658 Offset: 0x150C658 VA: 0x150C658
	public static /*bool HBPCIELOBKD*/explicit operator Boolean(EDOHBJAPLPF_JsonData IDLHJIOMJBK_data) 
    { 
        if (IDLHJIOMJBK_data.INDDJNMPONH_type != JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean)
			throw new InvalidCastException (
				"Instance of JsonData doesn't hold a double");

		return IDLHJIOMJBK_data.KIDMELNMHEN_inst_boolean;
    }

	// // RVA: 0x150C718 Offset: 0x150C718 VA: 0x150C718
	public static /*double HBPCIELOBKD*/explicit operator Double(EDOHBJAPLPF_JsonData IDLHJIOMJBK_data)
	{
		if (IDLHJIOMJBK_data.INDDJNMPONH_type != JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double)
			throw new InvalidCastException (
				"Instance of JsonData doesn't hold a double");

		return IDLHJIOMJBK_data.EMLHILAIKMM_inst_double;
	}

	// // RVA: 0x14FDF94 Offset: 0x14FDF94 VA: 0x14FDF94
	public static /*int HBPCIELOBKD_Int*/explicit operator Int32(EDOHBJAPLPF_JsonData IDLHJIOMJBK_data)
	{
		if (IDLHJIOMJBK_data.INDDJNMPONH_type != JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int)
			throw new InvalidCastException (
				"Instance of JsonData doesn't hold an int");

		return IDLHJIOMJBK_data.NFGINMFAEOB_inst_int;
	}

	// // RVA: 0x150C7DC Offset: 0x150C7DC VA: 0x150C7DC
	public static /*long HBPCIELOBKD*/explicit operator Int64(EDOHBJAPLPF_JsonData IDLHJIOMJBK_data)
	{
		if (IDLHJIOMJBK_data.INDDJNMPONH_type != JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long)
			throw new InvalidCastException (
				"Instance of JsonData doesn't hold an int");

		return IDLHJIOMJBK_data.IKLMIBFMGEC_inst_long;
	}

	// // RVA: 0x1502260 Offset: 0x1502260 VA: 0x1502260
	public static /*string HBPCIELOBKD_Str*/explicit operator String(EDOHBJAPLPF_JsonData IDLHJIOMJBK_data) 
	{
		if (IDLHJIOMJBK_data.INDDJNMPONH_type != JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String)
			throw new InvalidCastException (
				"Instance of JsonData doesn't hold a string");

		return IDLHJIOMJBK_data.FCNDAFPPLIN_inst_string;
	}
	#endregion

	#region ICollection Methods
	// // RVA: 0x150C89C Offset: 0x150C89C VA: 0x150C89C Slot: 36
	void ICollection.CopyTo(Array GJCOEKPLFAD_array, int OIPCCBHIKIA_index)
	{
		CBJBIDKHLFM_EnsureCollection ().CopyTo (GJCOEKPLFAD_array, OIPCCBHIKIA_index);
	}
	#endregion

	#region IDictionary Methods
	// // RVA: 0x150C98C Offset: 0x150C98C VA: 0x150C98C Slot: 51
	void IDictionary.Add(object LJNAKDMILMC_key, object NANNGLGOFKH_value)
	{
		EDOHBJAPLPF_JsonData data = NOJCMGAFAAC_ToJsonData (NANNGLGOFKH_value);

		OGLGGGMGCPL_EnsureDictionary ().Add (LJNAKDMILMC_key, NANNGLGOFKH_value);

		KeyValuePair<string, EDOHBJAPLPF_JsonData> entry =
			new KeyValuePair<string, EDOHBJAPLPF_JsonData> ((string) LJNAKDMILMC_key, data);
		NAMGNKNCNON_object_list.Add (entry);

		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150CBD8 Offset: 0x150CBD8 VA: 0x150CBD8 Slot: 52
	void IDictionary.Clear()
	{
		OGLGGGMGCPL_EnsureDictionary ().Clear ();
		NAMGNKNCNON_object_list.Clear ();
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150CD4C Offset: 0x150CD4C VA: 0x150CD4C Slot: 50
	bool IDictionary.Contains(object LJNAKDMILMC_key)
	{
		return OGLGGGMGCPL_EnsureDictionary ().Contains (LJNAKDMILMC_key);
	}

	// // RVA: 0x150CE34 Offset: 0x150CE34 VA: 0x150CE34 Slot: 55
	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return ((IOrderedDictionary) this).GetEnumerator ();
	}

	// // RVA: 0x150CEF8 Offset: 0x150CEF8 VA: 0x150CEF8 Slot: 56
	void IDictionary.Remove(object LJNAKDMILMC_key)
	{
		OGLGGGMGCPL_EnsureDictionary ().Remove (LJNAKDMILMC_key);

		for (int i = 0; i < NAMGNKNCNON_object_list.Count; i++) {
			if (NAMGNKNCNON_object_list[i].Key == (string) LJNAKDMILMC_key) {
				NAMGNKNCNON_object_list.RemoveAt (i);
				break;
			}
		}

		DLENPPIJNPA_json = null;
	}
	#endregion

	#region IEnumerable Methods
	// // RVA: 0x150D2A0 Offset: 0x150D2A0 VA: 0x150D2A0 Slot: 40
	IEnumerator IEnumerable.GetEnumerator()
	{
		return CBJBIDKHLFM_EnsureCollection ().GetEnumerator ();
	}
	#endregion

	#region IJsonWrapper Methods
	// // RVA: 0x150D380 Offset: 0x150D380 VA: 0x150D380 Slot: 11
	bool /*MMNPAPMKGBL*/IHIFCPDDDKN_IJsonWrapper.AHKIFBLKFAF_GetBoolean()
	{
		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean)
			throw new InvalidOperationException (
				"JsonData instance doesn't hold a boolean");

		return KIDMELNMHEN_inst_boolean;
	}

	// // RVA: 0x150D430 Offset: 0x150D430 VA: 0x150D430 Slot: 12
	double /*MICDOKHDEJF*/IHIFCPDDDKN_IJsonWrapper.BLDINLMJHAF_GetDouble()
	{
		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double)
			throw new InvalidOperationException (
				"JsonData instance doesn't hold a double");

		return EMLHILAIKMM_inst_double;
	}

	// // RVA: 0x150D4E4 Offset: 0x150D4E4 VA: 0x150D4E4 Slot: 13
	int /*NPFBJPPOAFI*/IHIFCPDDDKN_IJsonWrapper.CJAENOMGPDA_GetInt()
	{
		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int)
			throw new InvalidOperationException (
				"JsonData instance doesn't hold an int");

		return NFGINMFAEOB_inst_int;
	}

	// // RVA: 0x150D594 Offset: 0x150D594 VA: 0x150D594 Slot: 15
	long /*ENPHDGBDANH*/IHIFCPDDDKN_IJsonWrapper.DKMPHAPBDLH_GetLong()
	{
		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long)
			throw new InvalidOperationException (
				"JsonData instance doesn't hold a long");

		return IKLMIBFMGEC_inst_long;
	}

	// // RVA: 0x150D644 Offset: 0x150D644 VA: 0x150D644 Slot: 16
	string /*MOHJAHHLOEN*/IHIFCPDDDKN_IJsonWrapper.FGCNMLBACGO_GetString()
	{
		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String)
			throw new InvalidOperationException (
				"JsonData instance doesn't hold a string");

		return FCNDAFPPLIN_inst_string;
	}

	// // RVA: 0x150D6F4 Offset: 0x150D6F4 VA: 0x150D6F4 Slot: 17
	void /*IJGMFLBOBJP*/IHIFCPDDDKN_IJsonWrapper.BDMBEANLAFO_SetBoolean(bool JBGEEPFKIGG_val)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean;
		KIDMELNMHEN_inst_boolean = JBGEEPFKIGG_val;
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150D70C Offset: 0x150D70C VA: 0x150D70C Slot: 18
	// private void OOPDIPEJEHE(double JBGEEPFKIGG) { }
	void /*OOPDIPEJEHE*/IHIFCPDDDKN_IJsonWrapper.LACMCDADMBP_SetDouble(double JBGEEPFKIGG_val)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double;
		EMLHILAIKMM_inst_double = JBGEEPFKIGG_val;
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150D72C Offset: 0x150D72C VA: 0x150D72C Slot: 19
	void /*DPNLIJMIJBC*/IHIFCPDDDKN_IJsonWrapper.EOPNENFNMGE_SetInt(int JBGEEPFKIGG_val)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int;
		NFGINMFAEOB_inst_int = JBGEEPFKIGG_val;
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150D744 Offset: 0x150D744 VA: 0x150D744 Slot: 21
	void /*DLEJMKPFGDM*/IHIFCPDDDKN_IJsonWrapper.BOGHKGJMJKL_SetLong(long JBGEEPFKIGG_val)
	{ 
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long;
		IKLMIBFMGEC_inst_long = JBGEEPFKIGG_val;
		DLENPPIJNPA_json = null;
	}

	// // RVA: g Offset: 0x150D764 VA: 0x150D764 Slot: 22
	void /*KPFPJHPDBHL*/IHIFCPDDDKN_IJsonWrapper.BIFDLDOBBEF_SetString(string JBGEEPFKIGG_val) // ??
	{ 
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String;
		FCNDAFPPLIN_inst_string = JBGEEPFKIGG_val;
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150D77C Offset: 0x150D77C VA: 0x150D77C Slot: 23
	string /*PNHDLFAEMHF*/IHIFCPDDDKN_IJsonWrapper.EJCOJCGIBNG_ToJson()
	{
		return EJCOJCGIBNG_ToJson ();
	}

	// // RVA: 0x150D89C Offset: 0x150D89C VA: 0x150D89C Slot: 24
	void /*PNHDLFAEMHF*/IHIFCPDDDKN_IJsonWrapper.EJCOJCGIBNG_ToJson(KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer)
	{
		EJCOJCGIBNG_ToJson (OMLLGAKPMAN_writer);
	}
	#endregion

	#region IList Methods
	// // RVA: 0x150D994 Offset: 0x150D994 VA: 0x150D994 Slot: 27
	int IList.Add(object NANNGLGOFKH_value)
	{
		return Add(NANNGLGOFKH_value);
	}

	// // RVA: 0x150DA94 Offset: 0x150DA94 VA: 0x150DA94 Slot: 29
	void IList.Clear()
	{
		FMCDHFLLBGD_EnsureList ().Clear ();
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150DB7C Offset: 0x150DB7C VA: 0x150DB7C Slot: 28
	bool IList.Contains(object NANNGLGOFKH_value)
	{
		return FMCDHFLLBGD_EnsureList ().Contains (NANNGLGOFKH_value);
	}

	// // RVA: 0x150DC64 Offset: 0x150DC64 VA: 0x150DC64 Slot: 32
	int IList.IndexOf(object NANNGLGOFKH_value)
	{
		return FMCDHFLLBGD_EnsureList ().IndexOf (NANNGLGOFKH_value);
	}

	// // RVA: 0x150DD4C Offset: 0x150DD4C VA: 0x150DD4C Slot: 33
	void IList.Insert(int OIPCCBHIKIA_index, object NANNGLGOFKH_value)
	{
		FMCDHFLLBGD_EnsureList ().Insert (OIPCCBHIKIA_index, NANNGLGOFKH_value);
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150DE4C Offset: 0x150DE4C VA: 0x150DE4C Slot: 34
	void IList.Remove(object NANNGLGOFKH_value)
	{
		FMCDHFLLBGD_EnsureList ().Remove (NANNGLGOFKH_value);
		DLENPPIJNPA_json = null;
	}

	// // RVA: 0x150DF3C Offset: 0x150DF3C VA: 0x150DF3C Slot: 35
	void IList.RemoveAt(int OIPCCBHIKIA_index)
	{
		FMCDHFLLBGD_EnsureList ().RemoveAt (OIPCCBHIKIA_index);
		DLENPPIJNPA_json = null;
	}
	#endregion

	#region IOrderedDictionary Methods
	// // RVA: 0x150E02C Offset: 0x150E02C VA: 0x150E02C Slot: 43
	IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
	{
		OGLGGGMGCPL_EnsureDictionary ();

		return new COHBCOLJMBI_OrderedDictionaryEnumerator (
			NAMGNKNCNON_object_list.GetEnumerator ());
	}

	// // RVA: 0x150E138 Offset: 0x150E138 VA: 0x150E138 Slot: 44
	void IOrderedDictionary.Insert(int IOPHIHFOOEP_idx, object LJNAKDMILMC_key, object NANNGLGOFKH_value)
	{
		string property = (string) LJNAKDMILMC_key;
		EDOHBJAPLPF_JsonData data  = NOJCMGAFAAC_ToJsonData (NANNGLGOFKH_value);

		this[property] = data;

		KeyValuePair<string, EDOHBJAPLPF_JsonData> entry =
			new KeyValuePair<string, EDOHBJAPLPF_JsonData> (property, data);

		NAMGNKNCNON_object_list.Insert (IOPHIHFOOEP_idx, entry);
	}

	// // RVA: 0x150E2FC Offset: 0x150E2FC VA: 0x150E2FC Slot: 45
	void IOrderedDictionary.RemoveAt(int IOPHIHFOOEP_idx)
	{
		OGLGGGMGCPL_EnsureDictionary ();

		JMGLNPKCBPG_inst_object.Remove (NAMGNKNCNON_object_list[IOPHIHFOOEP_idx].Key);
		NAMGNKNCNON_object_list.RemoveAt (IOPHIHFOOEP_idx);
	}
	#endregion

	#region Private Methods
	// // RVA: 0x150A0DC Offset: 0x150A0DC VA: 0x150A0DC
	private ICollection CBJBIDKHLFM_EnsureCollection ()
	{
		if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array)
			return (ICollection) HGNCNIHIPJJ_inst_array;

		if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object)
			return (ICollection) JMGLNPKCBPG_inst_object;

		throw new InvalidOperationException (
			"The JsonData instance has to be initialized first");
	}

	// // RVA: 0x150A4FC Offset: 0x150A4FC VA: 0x150A4FC
	private IDictionary OGLGGGMGCPL_EnsureDictionary ()
	{
		if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object)
			return (IDictionary) JMGLNPKCBPG_inst_object;

		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.HJNNKCMLGFL_None)
			throw new InvalidOperationException (
				"Instance of JsonData is not a dictionary");

		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object;
		JMGLNPKCBPG_inst_object = new Dictionary<string, EDOHBJAPLPF_JsonData> ();
		NAMGNKNCNON_object_list = new List<KeyValuePair<string, EDOHBJAPLPF_JsonData>> ();

		return (IDictionary) JMGLNPKCBPG_inst_object;
	}

	// // RVA: 0x150B1E8 Offset: 0x150B1E8 VA: 0x150B1E8
	private IList FMCDHFLLBGD_EnsureList ()
	{
		if (INDDJNMPONH_type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array)
			return (IList) HGNCNIHIPJJ_inst_array;

		if (INDDJNMPONH_type != JFBMDLGBPEN_JsonType.HJNNKCMLGFL_None)
			throw new InvalidOperationException (
				"Instance of JsonData is not a list");

		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array;
		HGNCNIHIPJJ_inst_array = new List<EDOHBJAPLPF_JsonData> ();

		return (IList) HGNCNIHIPJJ_inst_array;
	}

	// // RVA: 0x150B63C Offset: 0x150B63C VA: 0x150B63C
	private EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData (object LMNBBOIJBBL_obj)
	{
		if (LMNBBOIJBBL_obj == null)
			return null;

		if (LMNBBOIJBBL_obj is EDOHBJAPLPF_JsonData)
			return (EDOHBJAPLPF_JsonData) LMNBBOIJBBL_obj;

		return new EDOHBJAPLPF_JsonData (LMNBBOIJBBL_obj);
	}

	// // RVA: 0x150E53C Offset: 0x150E53C VA: 0x150E53C
	private static void GCGCPPFMFDL_WriteJson (IHIFCPDDDKN_IJsonWrapper LMNBBOIJBBL_obj, KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer)
	{
		if (LMNBBOIJBBL_obj == null) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (null);
			return;
		}

		if (LMNBBOIJBBL_obj.EPNAPDBIJJE_IsString) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (LMNBBOIJBBL_obj.FGCNMLBACGO_GetString ());
			return;
		}

		if (LMNBBOIJBBL_obj.DGGFODFFPFJ_IsBoolean) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (LMNBBOIJBBL_obj.AHKIFBLKFAF_GetBoolean ());
			return;
		}

		if (LMNBBOIJBBL_obj.NFPOKKABOHN_IsDouble) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (LMNBBOIJBBL_obj.BLDINLMJHAF_GetDouble ());
			return;
		}

		if (LMNBBOIJBBL_obj.MDDJBLEDMBJ_IsInt) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (LMNBBOIJBBL_obj.CJAENOMGPDA_GetInt ());
			return;
		}

		if (LMNBBOIJBBL_obj.DCPEFFOMOOK_IsLong) {
			OMLLGAKPMAN_writer.FPEKCEGADMG_Write (LMNBBOIJBBL_obj.DKMPHAPBDLH_GetLong ());
			return;
		}

		if (LMNBBOIJBBL_obj.EPNGJLOKGIF_IsArray) {
			OMLLGAKPMAN_writer.PCMFCDODNMB_WriteArrayStart ();
			foreach (object elem in (IList) LMNBBOIJBBL_obj)
				GCGCPPFMFDL_WriteJson ((EDOHBJAPLPF_JsonData) elem, OMLLGAKPMAN_writer);
			OMLLGAKPMAN_writer.KJLDOKNDPCO_WriteArrayEnd ();

			return;
		}

		if (LMNBBOIJBBL_obj.LLHIGGPIILM_IsObject) {
			OMLLGAKPMAN_writer.APFBNDGICIA_WriteObjectStart ();

			foreach (DictionaryEntry entry in ((IDictionary) LMNBBOIJBBL_obj)) {
				OMLLGAKPMAN_writer.ABKCJDMNIOC_WritePropertyName ((string) entry.Key);
				GCGCPPFMFDL_WriteJson ((EDOHBJAPLPF_JsonData) entry.Value, OMLLGAKPMAN_writer);
			}
			OMLLGAKPMAN_writer.LKJOBFDIMPF_WriteObjectEnd ();

			return;
		}
	}
	#endregion

	// // RVA: 0x150D998 Offset: 0x150D998 VA: 0x150D998
	public int Add(object NANNGLGOFKH_value)
	{
		EDOHBJAPLPF_JsonData data = NOJCMGAFAAC_ToJsonData (NANNGLGOFKH_value);

		DLENPPIJNPA_json = null;

		return FMCDHFLLBGD_EnsureList ().Add (data);
	}

	// // RVA: 0x150F4D8 Offset: 0x150F4D8 VA: 0x150F4D8
	public void Clear()
	{
		if (LLHIGGPIILM_IsObject) {
			((IDictionary) this).Clear ();
			return;
		}

		if (EPNGJLOKGIF_IsArray) {
			((IList) this).Clear ();
			return;
		}
	}

	// // RVA: 0x150F618 Offset: 0x150F618 VA: 0x150F618 Slot: 57
	public bool Equals(EDOHBJAPLPF_JsonData GHPLINIACBB_x)
	{
		if (GHPLINIACBB_x == null)
			return false;

		if (GHPLINIACBB_x.INDDJNMPONH_type != this.INDDJNMPONH_type)
			return false;

		switch (this.INDDJNMPONH_type) {
		case JFBMDLGBPEN_JsonType.HJNNKCMLGFL_None:
			return true;

		case JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object:
			return this.JMGLNPKCBPG_inst_object.Equals (GHPLINIACBB_x.JMGLNPKCBPG_inst_object);

		case JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array:
			return this.HGNCNIHIPJJ_inst_array.Equals (GHPLINIACBB_x.HGNCNIHIPJJ_inst_array);

		case JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String:
			return this.FCNDAFPPLIN_inst_string.Equals (GHPLINIACBB_x.FCNDAFPPLIN_inst_string);

		case JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int:
			return this.NFGINMFAEOB_inst_int.Equals (GHPLINIACBB_x.NFGINMFAEOB_inst_int);

		case JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long:
			return this.IKLMIBFMGEC_inst_long.Equals (GHPLINIACBB_x.IKLMIBFMGEC_inst_long);

		case JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double:
			return this.EMLHILAIKMM_inst_double.Equals (GHPLINIACBB_x.EMLHILAIKMM_inst_double);

		case JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean:
			return this.KIDMELNMHEN_inst_boolean.Equals (GHPLINIACBB_x.KIDMELNMHEN_inst_boolean);
		}

		return false;
	}

	// // RVA: 0x1502320 Offset: 0x1502320 VA: 0x1502320 Slot: 14
	public JFBMDLGBPEN_JsonType OGFMMFKKCEF_GetJsonType ()
	{
		return INDDJNMPONH_type;
	}

	// // RVA: 0x150F768 Offset: 0x150F768 VA: 0x150F768 Slot: 20
	public void LAJDIPCJCPO_SetJsonType (JFBMDLGBPEN_JsonType INDDJNMPONH_type) 
	{
		if (this.INDDJNMPONH_type == INDDJNMPONH_type)
			return;

		switch (INDDJNMPONH_type) {
		case JFBMDLGBPEN_JsonType.HJNNKCMLGFL_None:
			break;

		case JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object:
			JMGLNPKCBPG_inst_object = new Dictionary<string, EDOHBJAPLPF_JsonData> ();
			NAMGNKNCNON_object_list = new List<KeyValuePair<string, EDOHBJAPLPF_JsonData>> ();
			break;

		case JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array:
			HGNCNIHIPJJ_inst_array = new List<EDOHBJAPLPF_JsonData> ();
			break;

		case JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String:
			FCNDAFPPLIN_inst_string = default (String);
			break;

		case JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int:
			NFGINMFAEOB_inst_int = default (Int32);
			break;

		case JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long:
			IKLMIBFMGEC_inst_long = default (Int64);
			break;

		case JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double:
			EMLHILAIKMM_inst_double = default (Double);
			break;

		case JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean:
			KIDMELNMHEN_inst_boolean = default (Boolean);
			break;
		}

		this.INDDJNMPONH_type = INDDJNMPONH_type;
	}

	// // RVA: 0x150D780 Offset: 0x150D780 VA: 0x150D780
	public string EJCOJCGIBNG_ToJson ()
	{
		if (DLENPPIJNPA_json != null)
			return DLENPPIJNPA_json;

		StringWriter sw = new StringWriter ();
		KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter (sw);
		writer.GEJEDJNKBOF_Validate = false;

		GCGCPPFMFDL_WriteJson (this, writer);
		DLENPPIJNPA_json = sw.ToString ();

		return DLENPPIJNPA_json;
	}

	// // RVA: 0x150D8A0 Offset: 0x150D8A0 VA: 0x150D8A0
	public void EJCOJCGIBNG_ToJson (KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer)
	{
		bool old_validate = OMLLGAKPMAN_writer.GEJEDJNKBOF_Validate;

		OMLLGAKPMAN_writer.GEJEDJNKBOF_Validate = false;

		GCGCPPFMFDL_WriteJson (this, OMLLGAKPMAN_writer);

		OMLLGAKPMAN_writer.GEJEDJNKBOF_Validate = old_validate;
	}

	// // RVA: 0x150F8E4 Offset: 0x150F8E4 VA: 0x150F8E4 Slot: 3
	public override string ToString()
	{
		switch (INDDJNMPONH_type) {
		case JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array:
			return "JsonData array";

		case JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean:
			return KIDMELNMHEN_inst_boolean.ToString ();

		case JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double:
			return EMLHILAIKMM_inst_double.ToString ();

		case JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int:
			return NFGINMFAEOB_inst_int.ToString ();

		case JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long:
			return IKLMIBFMGEC_inst_long.ToString ();

		case JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object:
			return "JsonData object";

		case JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String:
			return FCNDAFPPLIN_inst_string;
		}

		return "Uninitialized JsonData";
	}

	// // RVA: 0x150FA88 Offset: 0x150FA88 VA: 0x150FA88
	// private static void .cctor() { }
	
	// // RVA: 0x150BF1C Offset: 0x150BF1C VA: 0x150BF1C
	// public string FLPBHNAOIOB(int OIPCCBHIKIA) { }

	// // RVA: 0x14F4048 Offset: 0x14F4048 VA: 0x14F4048
	public bool BBAJPINMOEP_Contains(string GODGBGGHPNG_prop_name) 
    {
		return JMGLNPKCBPG_inst_object.ContainsKey(GODGBGGHPNG_prop_name);
    }
	
	
	// Namespace: 
	internal class COHBCOLJMBI_OrderedDictionaryEnumerator : IDictionaryEnumerator
	{
		// Fields
		private IEnumerator<KeyValuePair<string, EDOHBJAPLPF_JsonData>> GIJHIKDBGFM_list_enumerator; // 0x8

		// Properties
		// RVA: 0x176431C Offset: 0x176431C VA: 0x176431C Slot: 8
		//public object get_Current() { }
		public object /*FKPCEJPAOCF_*/Current { get { return Entry; } }
		// RVA: 0x17643A0 Offset: 0x17643A0 VA: 0x17643A0 Slot: 6
		//public DictionaryEntry get_Entry() { }
		public DictionaryEntry /*MFEGLKEAPLA_*/Entry { 
			get {
				KeyValuePair<string, EDOHBJAPLPF_JsonData> curr = GIJHIKDBGFM_list_enumerator.Current;
				return new DictionaryEntry (curr.Key, curr.Value);
			} 
		}
		// RVA: 0x17644EC Offset: 0x17644EC VA: 0x17644EC Slot: 4
		//public object get_Key() { }
		public object /*LHIIFHGEBJM_*/Key { get { return GIJHIKDBGFM_list_enumerator.Current.Key; } }
		// RVA: 0x17645F8 Offset: 0x17645F8 VA: 0x17645F8 Slot: 5
		//public object get_Value() { }
		public object /*BLNDFNMPILA_*/Value { get { return GIJHIKDBGFM_list_enumerator.Current.Value; } }

		// Methods
		// RVA: 0x1764704 Offset: 0x1764704 VA: 0x1764704
		public COHBCOLJMBI_OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, EDOHBJAPLPF_JsonData>> CAMOPBPPDLF_enumerator)
        {
            GIJHIKDBGFM_list_enumerator = CAMOPBPPDLF_enumerator;
        }

		// RVA: 0x1764724 Offset: 0x1764724 VA: 0x1764724 Slot: 7
		public bool MoveNext() 
		{ 
			return GIJHIKDBGFM_list_enumerator.MoveNext ();
		}

		// RVA: 0x17647FC Offset: 0x17647FC VA: 0x17647FC Slot: 9
		public void Reset() 
		{
			GIJHIKDBGFM_list_enumerator.Reset ();			
		}
	}


}
