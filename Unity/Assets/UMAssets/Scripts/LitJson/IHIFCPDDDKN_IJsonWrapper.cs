
using System;
using System.Collections;
using System.Collections.Specialized;


public enum JFBMDLGBPEN{}
public enum JFBMDLGBPEN_JsonType
{
	HJNNKCMLGFL_None = 0,
	JKMLKAMHJIF_Object = 1,
	BDHGEFMCJDF_Array = 2,
	IAAHPCHFCFB_String = 3,
	CEIBAFOCNCA_Int = 4,
	HJBKGEBNJMP_Long = 5,
	PFOFBNKFKCA_Double = 6,
	JIJLIKNGOOH_Boolean = 7
}


public interface IHIFCPDDDKN_IJsonWrapper : IList, IOrderedDictionary
{
	// // RVA: -1 Offset: -1 Slot: 0
	// public abstract bool HJENKHBBMMO();
	bool EPNGJLOKGIF_IsArray { get; }
	// // RVA: -1 Offset: -1 Slot: 1
	// public abstract bool BEINOJJBBHP();
	bool DGGFODFFPFJ_IsBoolean { get; }
	// // RVA: -1 Offset: -1 Slot: 2
	// public abstract bool AIAPBMFKNKL();
	bool NFPOKKABOHN_IsDouble { get; }
	// // RVA: -1 Offset: -1 Slot: 3
	// public abstract bool HPAMBFKGDJC();
	bool MDDJBLEDMBJ_IsInt { get; }
	// // RVA: -1 Offset: -1 Slot: 4
	// public abstract bool FAPIDDCBEAC();
	bool DCPEFFOMOOK_IsLong { get; }
	// // RVA: -1 Offset: -1 Slot: 5
	// public abstract bool CBKPPCPDEOB();
	bool LLHIGGPIILM_IsObject { get; }
	// // RVA: -1 Offset: -1 Slot: 6
	// public abstract bool OKNHHEOKLNL();
	bool EPNAPDBIJJE_IsString { get; }


	// // RVA: -1 Offset: -1 Slot: 7
	bool AHKIFBLKFAF_GetBoolean();

	// // RVA: -1 Offset: -1 Slot: 8
	double BLDINLMJHAF_GetDouble();

	// // RVA: -1 Offset: -1 Slot: 9
	int CJAENOMGPDA_GetInt();

	// // RVA: -1 Offset: -1 Slot: 10
	JFBMDLGBPEN_JsonType OGFMMFKKCEF_GetJsonType();

	// // RVA: -1 Offset: -1 Slot: 11
	long DKMPHAPBDLH_GetLong();

	// // RVA: -1 Offset: -1 Slot: 12
	string FGCNMLBACGO_GetString();

	// // RVA: -1 Offset: -1 Slot: 13
	void BDMBEANLAFO_SetBoolean(bool JBGEEPFKIGG_val);

	// // RVA: -1 Offset: -1 Slot: 14
	void LACMCDADMBP_SetDouble(double JBGEEPFKIGG_val);

	// // RVA: -1 Offset: -1 Slot: 15
	void EOPNENFNMGE_SetInt(int JBGEEPFKIGG_val);

	// // RVA: -1 Offset: -1 Slot: 16
	void LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType INDDJNMPONH);

	// // RVA: -1 Offset: -1 Slot: 17
	void BOGHKGJMJKL_SetLong(long JBGEEPFKIGG_val);

	// // RVA: -1 Offset: -1 Slot: 18
	void BIFDLDOBBEF_SetString(string JBGEEPFKIGG_val);

	// // RVA: -1 Offset: -1 Slot: 19
	string EJCOJCGIBNG_ToJson();

	// // RVA: -1 Offset: -1 Slot: 20
	void EJCOJCGIBNG_ToJson(KIJECNFNNDB_JsonWriter OMLLGAKPMAN_writer);
}
