using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;

//https://github.com/LitJSON/litjson/blob/develop/src/LitJson/JsonData.cs 0.7.0

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
	public int HNBFOAJIIAL_Count {get { return EnsureCollection ().Count; }}
	// // RVA: 0x150A1E4 Offset: 0x150A1E4 VA: 0x150A1E4
	// public bool HJENKHBBMMO() { }
	public bool EPNGJLOKGIF_IsArray { get { return type == JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array; } }
	// // RVA: 0x150A1F8 Offset: 0x150A1F8 VA: 0x150A1F8
	// public bool BEINOJJBBHP() { }
	public bool DGGFODFFPFJ_IsBoolean { get { return type == JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean; } }
	// // RVA: 0x150A20C Offset: 0x150A20C VA: 0x150A20C
	// public bool AIAPBMFKNKL() { }
	public bool NFPOKKABOHN_IsDouble { get { return type == JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double; } }
	// // RVA: 0x150A220 Offset: 0x150A220 VA: 0x150A220
	// public bool HPAMBFKGDJC() { }
	public bool MDDJBLEDMBJ_IsInt { get { return type == JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int; } }
	// // RVA: 0x150A234 Offset: 0x150A234 VA: 0x150A234
	// public bool FAPIDDCBEAC() { }
	public bool DCPEFFOMOOK_IsLong { get { return type == JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long; } }
	// // RVA: 0x150A248 Offset: 0x150A248 VA: 0x150A248
	// public bool CBKPPCPDEOB() { }
	public bool LLHIGGPIILM_IsObject { get { return type == JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object; } }
	// // RVA: 0x1502328 Offset: 0x1502328 VA: 0x1502328
	// public bool OKNHHEOKLNL() { }
	public bool EPNAPDBIJJE_IsString { get { return type == JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String; } }
	#endregion

	#region ICollection Properties
	// // RVA: 0x150A258 Offset: 0x150A258 VA: 0x150A258 Slot: 37
	// private int System.Collections.ICollection.get_Count() { }
	int /*JBBONHKCLEP*/ICollection.Count { get { return Count; } }
	// // RVA: 0x150A25C Offset: 0x150A25C VA: 0x150A25C Slot: 39
	// private bool System.Collections.ICollection.get_IsSynchronized() { }
	bool /*DFHCHKNCOKH*/ICollection.IsSynchronized { get { return EnsureCollection ().IsSynchronized; } }
	// // RVA: 0x150A33C Offset: 0x150A33C VA: 0x150A33C Slot: 38
	// private object System.Collections.ICollection.get_SyncRoot() { }
	object /*JGFINCEMACP*/ICollection.SyncRoot { get {return EnsureCollection ().SyncRoot;} }
	#endregion

	#region IDictionary Properties
	// // RVA: 0x150A41C Offset: 0x150A41C VA: 0x150A41C Slot: 54
	// private bool System.Collections.IDictionary.get_IsFixedSize() { }
	bool /*DFLHBPEDLDP*/IDictionary.IsFixedSize { get {return EnsureDictionary ().IsFixedSize;} }
	// // RVA: 0x150A668 Offset: 0x150A668 VA: 0x150A668 Slot: 53
	// private bool System.Collections.IDictionary.get_IsReadOnly() { }
	bool /*AOCHNLCOLHA*/IDictionary.IsReadOnly { get { return EnsureDictionary ().IsReadOnly;} }
	// // RVA: 0x150A748 Offset: 0x150A748 VA: 0x150A748 Slot: 48
	// private ICollection System.Collections.IDictionary.get_Keys() { }
	ICollection /*KPHOGDGIDEP*/IDictionary.Keys {
		get {
			EnsureDictionary ();
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
			EnsureDictionary ();
			IList<JsonData> values = new List<JsonData> ();

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
                return EnsureList ().IsFixedSize;
            } }
	// // RVA: 0x150B380 Offset: 0x150B380 VA: 0x150B380 Slot: 30
	// private bool System.Collections.IList.get_IsReadOnly() { }
	bool /*FDMEFDCFEEE*/IList.IsReadOnly { get {
                return EnsureList ().IsReadOnly;
            } }
    #endregion

	#region IDictionary Indexer
	// // RVA: 0x150B460 Offset: 0x150B460 VA: 0x150B460 Slot: 46
	// private object System.Collections.IDictionary.get_Item(object LJNAKDMILMC) { }
	// // RVA: 0x150B548 Offset: 0x150B548 VA: 0x150B548 Slot: 47
	// private void System.Collections.IDictionary.set_Item(object LJNAKDMILMC, object NANNGLGOFKH) { }
	object IDictionary.this[object key]  {
		get {
			return EnsureDictionary ()[key];
		}

		set {
			if (! (key is String))
				throw new ArgumentException (
					"The key has to be a string");

			EDOHBJAPLPF_JsonData data = ToJsonData (value);

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
			EnsureDictionary ();
			return object_list[idx].Value;
		}

		set {
			EnsureDictionary ();
			JsonData data = ToJsonData (value);

			KeyValuePair<string, EDOHBJAPLPF_JsonData> old_entry = object_list[idx];

			inst_object[old_entry.Key] = data;

			KeyValuePair<string, JsonData> entry =
				new KeyValuePair<string, EDOHBJAPLPF_JsonData> (old_entry.Key, data);

			object_list[idx] = entry;
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
			return EnsureList ()[index];
		}

		set {
			EnsureList ();
			EDOHBJAPLPF_JsonData data = ToJsonData (value);

			this[index] = data;
		}
	}
	#endregion

	#region Public Indexers
	// // RVA: 0x14F3A88 Offset: 0x14F3A88 VA: 0x14F3A88
	// public EDOHBJAPLPF_JsonData GOAMILGNJIE(string GODGBGGHPNG) 
	// // RVA: 0x14F3498 Offset: 0x14F3498 VA: 0x14F3498
	// public void set_Item(string GODGBGGHPNG, EDOHBJAPLPF NANNGLGOFKH) { }
	public EDOHBJAPLPF_JsonData /*INIMBLOHIEF*/this[string prop_name] {
		get {
			EnsureDictionary ();
			return inst_object[prop_name];
		}

		set {
			EnsureDictionary ();

			KeyValuePair<string, JsonData> entry =
				new KeyValuePair<string, JsonData> (prop_name, value);

			if (inst_object.ContainsKey (prop_name)) {
				for (int i = 0; i < object_list.Count; i++) {
					if (object_list[i].Key == prop_name) {
						object_list[i] = entry;
						break;
					}
				}
			} else
				object_list.Add (entry);

			inst_object[prop_name] = value;

			json = null;
		}
	}

	// // RVA: 0x150C0F8 Offset: 0x150C0F8 VA: 0x150C0F8
	//public EDOHBJAPLPF_JsonData GOAMILGNJIE(int OIPCCBHIKIA) 
	// // RVA: 0x150BBD0 Offset: 0x150BBD0 VA: 0x150BBD0
	// public void set_Item(int OIPCCBHIKIA, EDOHBJAPLPF NANNGLGOFKH) { }
	public EDOHBJAPLPF_JsonData /*INIMBLOHIEF*/this[int index] {
		get {
			EnsureCollection ();

			if (type == JsonType.Array)
				return inst_array[index];

			return object_list[index].Value;
		}

		set {
			EnsureCollection ();

			if (type == JsonType.Array)
				inst_array[index] = value;
			else {
				KeyValuePair<string, JsonData> entry = object_list[index];
				KeyValuePair<string, JsonData> new_entry =
					new KeyValuePair<string, JsonData> (entry.Key, value);

				object_list[index] = new_entry;
				inst_object[entry.Key] = value;
			}

			json = null;
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
	public void JsonData(string JEHFDJPOEFF_str)
	{
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String;
		FCNDAFPPLIN_inst_string = JEHFDJPOEFF_str;
	}
    #endregion

	// // RVA: 0x150C558 Offset: 0x150C558 VA: 0x150C558
	// public static EDOHBJAPLPF JNEJKMKNIJJ(bool IDLHJIOMJBK) { }

	// // RVA: 0x150C5D4 Offset: 0x150C5D4 VA: 0x150C5D4
	// public static EDOHBJAPLPF JNEJKMKNIJJ(double IDLHJIOMJBK) { }

	// // RVA: 0x14F3988 Offset: 0x14F3988 VA: 0x14F3988
	// public static EDOHBJAPLPF JNEJKMKNIJJ(int IDLHJIOMJBK) { }

	// // RVA: 0x14F3A04 Offset: 0x14F3A04 VA: 0x14F3A04
	// public static EDOHBJAPLPF JNEJKMKNIJJ(long IDLHJIOMJBK) { }

	// // RVA: 0x14F341C Offset: 0x14F341C VA: 0x14F341C
	// public static EDOHBJAPLPF JNEJKMKNIJJ(string IDLHJIOMJBK) { }

	// // RVA: 0x1509FFC Offset: 0x1509FFC VA: 0x1509FFC
	public int Count/*get_Count*/() 
	{ 
		return 0;
		// TODO
	}


	// // RVA: 0x150BF1C Offset: 0x150BF1C VA: 0x150BF1C
	// public string FLPBHNAOIOB(int OIPCCBHIKIA) { }

	// // RVA: 0x14F4048 Offset: 0x14F4048 VA: 0x14F4048
	public bool BBAJPINMOEP(string GODGBGGHPNG) 
    { 
        return false; // TODO
    }


	// // RVA: 0x150C658 Offset: 0x150C658 VA: 0x150C658
	public static bool HBPCIELOBKD(EDOHBJAPLPF_JsonData IDLHJIOMJBK) 
    { 
        return false;
        // TODO
    }

	// // RVA: 0x150C718 Offset: 0x150C718 VA: 0x150C718
	// public static double HBPCIELOBKD(EDOHBJAPLPF IDLHJIOMJBK) { }

	// // RVA: 0x14FDF94 Offset: 0x14FDF94 VA: 0x14FDF94
	public static int HBPCIELOBKD_Int(EDOHBJAPLPF_JsonData IDLHJIOMJBK) 
    { 
        return 0;
        // TODO
    }

	// // RVA: 0x150C7DC Offset: 0x150C7DC VA: 0x150C7DC
	// public static long HBPCIELOBKD(EDOHBJAPLPF IDLHJIOMJBK) { }

	// // RVA: 0x1502260 Offset: 0x1502260 VA: 0x1502260
	public static string HBPCIELOBKD_Str(EDOHBJAPLPF_JsonData IDLHJIOMJBK) 
    { 
        return "";
        // TODO
    }

	// // RVA: 0x150C89C Offset: 0x150C89C VA: 0x150C89C Slot: 36
	// private void System.Collections.ICollection.CopyTo(Array GJCOEKPLFAD, int OIPCCBHIKIA) { }

	// // RVA: 0x150C98C Offset: 0x150C98C VA: 0x150C98C Slot: 51
	// private void System.Collections.IDictionary.Add(object LJNAKDMILMC, object NANNGLGOFKH) { }

	// // RVA: 0x150CBD8 Offset: 0x150CBD8 VA: 0x150CBD8 Slot: 52
	// private void System.Collections.IDictionary.Clear() { }

	// // RVA: 0x150CD4C Offset: 0x150CD4C VA: 0x150CD4C Slot: 50
	// private bool System.Collections.IDictionary.Contains(object LJNAKDMILMC) { }

	// // RVA: 0x150CE34 Offset: 0x150CE34 VA: 0x150CE34 Slot: 55
	// private IDictionaryEnumerator System.Collections.IDictionary.GetEnumerator() { }

	// // RVA: 0x150CEF8 Offset: 0x150CEF8 VA: 0x150CEF8 Slot: 56
	// private void System.Collections.IDictionary.Remove(object LJNAKDMILMC) { }

	// // RVA: 0x150D2A0 Offset: 0x150D2A0 VA: 0x150D2A0 Slot: 40
	// private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

	// // RVA: 0x150D380 Offset: 0x150D380 VA: 0x150D380 Slot: 11
	// private bool MMNPAPMKGBL() { }

	// // RVA: 0x150D430 Offset: 0x150D430 VA: 0x150D430 Slot: 12
	// private double MICDOKHDEJF() { }

	// // RVA: 0x150D4E4 Offset: 0x150D4E4 VA: 0x150D4E4 Slot: 13
	// private int NPFBJPPOAFI() { }

	// // RVA: 0x150D594 Offset: 0x150D594 VA: 0x150D594 Slot: 15
	// private long ENPHDGBDANH() { }

	// // RVA: 0x150D644 Offset: 0x150D644 VA: 0x150D644 Slot: 16
	// private string MOHJAHHLOEN() { }

	// // RVA: 0x150D6F4 Offset: 0x150D6F4 VA: 0x150D6F4 Slot: 17
	// private void IJGMFLBOBJP(bool JBGEEPFKIGG) { }

	// // RVA: 0x150D70C Offset: 0x150D70C VA: 0x150D70C Slot: 18
	// private void OOPDIPEJEHE(double JBGEEPFKIGG) { }
	public void LACMCDADMBP(double JBGEEPFKIGG)
	{
		EMLHILAIKMM = JBGEEPFKIGG;
		DLENPPIJNPA = "";
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double;
	}

	// // RVA: 0x150D72C Offset: 0x150D72C VA: 0x150D72C Slot: 19
	// private void DPNLIJMIJBC(int JBGEEPFKIGG) { }

	// // RVA: 0x150D744 Offset: 0x150D744 VA: 0x150D744 Slot: 21
	// private void DLEJMKPFGDM(long JBGEEPFKIGG) 
	public void BOGHKGJMJKL(long JBGEEPFKIGG)
	{ 
		IKLMIBFMGEC = JBGEEPFKIGG;
		DLENPPIJNPA = "";
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long;
	}

	// // RVA: g Offset: 0x150D764 VA: 0x150D764 Slot: 22
	//private void KPFPJHPDBHL(string JBGEEPFKIGG) 
	public void BIFDLDOBBEF(string JBGEEPFKIGG) // ??
	{ 
		FCNDAFPPLIN = JBGEEPFKIGG;
		DLENPPIJNPA = "";
		INDDJNMPONH_type = JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String;
	}

	// // RVA: 0x150D77C Offset: 0x150D77C VA: 0x150D77C Slot: 23
	// private string PNHDLFAEMHF() { }

	// // RVA: 0x150D89C Offset: 0x150D89C VA: 0x150D89C Slot: 24
	// private void PNHDLFAEMHF(KIJECNFNNDB OMLLGAKPMAN) { }

	// // RVA: 0x150D994 Offset: 0x150D994 VA: 0x150D994 Slot: 27
	int System.Collections.IList.Add(object NANNGLGOFKH)
	{
		this.Add(NANNGLGOFKH);
	}

	// // RVA: 0x150DA94 Offset: 0x150DA94 VA: 0x150DA94 Slot: 29
	// private void System.Collections.IList.Clear() { }

	// // RVA: 0x150DB7C Offset: 0x150DB7C VA: 0x150DB7C Slot: 28
	// private bool System.Collections.IList.Contains(object NANNGLGOFKH) { }

	// // RVA: 0x150DC64 Offset: 0x150DC64 VA: 0x150DC64 Slot: 32
	// private int System.Collections.IList.IndexOf(object NANNGLGOFKH) { }

	// // RVA: 0x150DD4C Offset: 0x150DD4C VA: 0x150DD4C Slot: 33
	// private void System.Collections.IList.Insert(int OIPCCBHIKIA, object NANNGLGOFKH) { }

	// // RVA: 0x150DE4C Offset: 0x150DE4C VA: 0x150DE4C Slot: 34
	// private void System.Collections.IList.Remove(object NANNGLGOFKH) { }

	// // RVA: 0x150DF3C Offset: 0x150DF3C VA: 0x150DF3C Slot: 35
	// private void System.Collections.IList.RemoveAt(int OIPCCBHIKIA) { }

	// // RVA: 0x150E02C Offset: 0x150E02C VA: 0x150E02C Slot: 43
	// private IDictionaryEnumerator System.Collections.Specialized.IOrderedDictionary.GetEnumerator() { }

	// // RVA: 0x150E138 Offset: 0x150E138 VA: 0x150E138 Slot: 44
	// private void System.Collections.Specialized.IOrderedDictionary.Insert(int IOPHIHFOOEP, object LJNAKDMILMC, object NANNGLGOFKH) { }

	// // RVA: 0x150E2FC Offset: 0x150E2FC VA: 0x150E2FC Slot: 45
	// private void System.Collections.Specialized.IOrderedDictionary.RemoveAt(int IOPHIHFOOEP) { }

	// // RVA: 0x150A0DC Offset: 0x150A0DC VA: 0x150A0DC
	// private ICollection CBJBIDKHLFM() { }

	// // RVA: 0x150A4FC Offset: 0x150A4FC VA: 0x150A4FC
	// private IDictionary OGLGGGMGCPL() { }

	// // RVA: 0x150B1E8 Offset: 0x150B1E8 VA: 0x150B1E8
	private IList FMCDHFLLBGD() 
	{ 
		if(INDDJNMPONH_type == JFBMDLGBPEN_JsonType.HJNNKCMLGFL_None)
		{
			INDDJNMPONH_type = JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array;
			HGNCNIHIPJJ = new List<EDOHBJAPLPF_JsonData>();
		}
		else
		{
			if(INDDJNMPONH_type != JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array)
			{
				new System.InvalidOperationException("Instance of JsonData is not a list");
			}
		}
	}

	// // RVA: 0x150B63C Offset: 0x150B63C VA: 0x150B63C
	private EDOHBJAPLPF_JsonData NOJCMGAFAAC(object LMNBBOIJBBL)
	{
		return new EDOHBJAPLPF_JsonData(LMNBBOIJBBL);
	}

	// // RVA: 0x150E53C Offset: 0x150E53C VA: 0x150E53C
	// private static void GCGCPPFMFDL(IHIFCPDDDKN LMNBBOIJBBL, KIJECNFNNDB OMLLGAKPMAN) { }

	// // RVA: 0x150D998 Offset: 0x150D998 VA: 0x150D998
	public int Add(object NANNGLGOFKH)
	{
		EDOHBJAPLPF_JsonData data = NOJCMGAFAAC(NANNGLGOFKH);
		DLENPPIJNPA = "";
		
	}

	// // RVA: 0x150F4D8 Offset: 0x150F4D8 VA: 0x150F4D8
	// public void Clear() { }

	// // RVA: 0x150F618 Offset: 0x150F618 VA: 0x150F618 Slot: 57
	// public bool Equals(EDOHBJAPLPF GHPLINIACBB) { }

	// // RVA: 0x1502320 Offset: 0x1502320 VA: 0x1502320 Slot: 14
	// public JFBMDLGBPEN OGFMMFKKCEF() { }

	// // RVA: 0x150F768 Offset: 0x150F768 VA: 0x150F768 Slot: 20
	public void LAJDIPCJCPO_SetType(JFBMDLGBPEN_JsonType INDDJNMPONH) 
	{ 
		if(this.INDDJNMPONH_type != INDDJNMPONH)
		{
			switch(INDDJNMPONH)
			{
				case JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object:
					JMGLNPKCBPG = new Dictionary<string, EDOHBJAPLPF_JsonData>();
					NAMGNKNCNON = new List<KeyValuePair<string, EDOHBJAPLPF_JsonData>>();
				break;
				case JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array:
					HGNCNIHIPJJ = new List<EDOHBJAPLPF_JsonData>();
				break;
				case JFBMDLGBPEN_JsonType.IAAHPCHFCFB_String:
					FCNDAFPPLIN = "";
				break;
				case JFBMDLGBPEN_JsonType.CEIBAFOCNCA_Int:
					NFGINMFAEOB = 0;
				break;
				case JFBMDLGBPEN_JsonType.HJBKGEBNJMP_Long:
					IKLMIBFMGEC = 0;
				break;
				case JFBMDLGBPEN_JsonType.PFOFBNKFKCA_Double:
					EMLHILAIKMM = 0;
				break;
				case JFBMDLGBPEN_JsonType.JIJLIKNGOOH_Boolean:
					KIDMELNMHEN = false;
				break;
				default: break;
			}
			this.INDDJNMPONH_type = INDDJNMPONH;
		}
	}

	// // RVA: 0x150D780 Offset: 0x150D780 VA: 0x150D780
	// public string EJCOJCGIBNG() { }

	// // RVA: 0x150D8A0 Offset: 0x150D8A0 VA: 0x150D8A0
	// public void EJCOJCGIBNG(KIJECNFNNDB OMLLGAKPMAN) { }

	// // RVA: 0x150F8E4 Offset: 0x150F8E4 VA: 0x150F8E4 Slot: 3
	// public override string ToString() { }

	// // RVA: 0x150FA88 Offset: 0x150FA88 VA: 0x150FA88
	// private static void .cctor() { }
}
