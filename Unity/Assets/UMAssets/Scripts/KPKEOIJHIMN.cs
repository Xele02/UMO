
public class KPKEOIJHIMN
{
    public enum GIDACIOHFNN
    {
        NHHHCIINJKO = 0,
        OGKLAGIPCEE = 1,
        GJCDHOAEIHP = 2,
        DNKAABNOOBF = 3,
    }

	private OBOKMHHMOIL_ServerInfo IBLKLEMGCCG = new OBOKMHHMOIL_ServerInfo(); // 0x8
	private OBOKMHHMOIL_ServerInfo CINGFPEPPED = new OBOKMHHMOIL_ServerInfo(); // 0xC

	// public OBOKMHHMOIL LKCCMBEOLLA { get; } // ?

	// // RVA: 0xD8E910 Offset: 0xD8E910 VA: 0xD8E910
	// public OBOKMHHMOIL JMKNKBNCKFB() { }

	// // RVA: 0xD8E918 Offset: 0xD8E918 VA: 0xD8E918
	public void EHMKHLIGFEJ(OBOKMHHMOIL_ServerInfo HKGPAMEKGKG)
    {
        CINGFPEPPED.ODDIHGPONFL_Copy(HKGPAMEKGKG);
    }

	// // RVA: 0xD8E94C Offset: 0xD8E94C VA: 0xD8E94C
	public void LOHGCAPLCNA(OBOKMHHMOIL_ServerInfo HKGPAMEKGKG)
    {
        IBLKLEMGCCG.ODDIHGPONFL_Copy(HKGPAMEKGKG);
    }

	// // RVA: 0xD8E980 Offset: 0xD8E980 VA: 0xD8E980
	// public void CMPIODFNMLE(string IEJLCENFLNK) { }

	// // RVA: 0xD8E9A8 Offset: 0xD8E9A8 VA: 0xD8E9A8
	public void FFEJIGPPHOA(string IEJLCENFLNK)
    {
        IBLKLEMGCCG.AJBPBEALBOB_ServerCurrentAssetRevision = IEJLCENFLNK;
    }

	// // RVA: 0xD8E9D0 Offset: 0xD8E9D0 VA: 0xD8E9D0
	public GIDACIOHFNN PGBOFGNOBLD()
    {
        if(CINGFPEPPED.AJBPBEALBOB_ServerCurrentAssetRevision == null)
            return GIDACIOHFNN.NHHHCIINJKO;

        if(IBLKLEMGCCG.AJBPBEALBOB_ServerCurrentAssetRevision == CINGFPEPPED.AJBPBEALBOB_ServerCurrentAssetRevision)
            return GIDACIOHFNN.GJCDHOAEIHP;
            
		return GIDACIOHFNN.NHHHCIINJKO;
    }
}
