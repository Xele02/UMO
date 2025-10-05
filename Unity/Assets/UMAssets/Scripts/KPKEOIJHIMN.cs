
public class KPKEOIJHIMN
{
    public enum GIDACIOHFNN_UpdateState
    {
        NHHHCIINJKO_0_UpToDate = 0,
        OGKLAGIPCEE_1_NewData = 1,
        GJCDHOAEIHP_2_NewDownloadData = 2,
        DNKAABNOOBF = 3,
    }

	private OBOKMHHMOIL_ServerInfo IBLKLEMGCCG = new OBOKMHHMOIL_ServerInfo(); // 0x8
	private OBOKMHHMOIL_ServerInfo CINGFPEPPED = new OBOKMHHMOIL_ServerInfo(); // 0xC

	// public OBOKMHHMOIL_ServerInfo LKCCMBEOLLA { get; } // ?

	// // RVA: 0xD8E910 Offset: 0xD8E910 VA: 0xD8E910
	// public OBOKMHHMOIL_ServerInfo JMKNKBNCKFB() { }

	// // RVA: 0xD8E918 Offset: 0xD8E918 VA: 0xD8E918
	public void EHMKHLIGFEJ(OBOKMHHMOIL_ServerInfo _HKGPAMEKGKG_Header)
    {
        CINGFPEPPED.ODDIHGPONFL_Copy(_HKGPAMEKGKG_Header);
    }

	// // RVA: 0xD8E94C Offset: 0xD8E94C VA: 0xD8E94C
	public void LOHGCAPLCNA(OBOKMHHMOIL_ServerInfo _HKGPAMEKGKG_Header)
    {
        IBLKLEMGCCG.ODDIHGPONFL_Copy(_HKGPAMEKGKG_Header);
    }

	// // RVA: 0xD8E980 Offset: 0xD8E980 VA: 0xD8E980
	// public void CMPIODFNMLE(string IEJLCENFLNK) { }

	// // RVA: 0xD8E9A8 Offset: 0xD8E9A8 VA: 0xD8E9A8
	public void FFEJIGPPHOA(string IEJLCENFLNK)
    {
        IBLKLEMGCCG.AJBPBEALBOB_SakashoCurrentAssetRevision = IEJLCENFLNK;
    }

	// // RVA: 0xD8E9D0 Offset: 0xD8E9D0 VA: 0xD8E9D0
	public GIDACIOHFNN_UpdateState PGBOFGNOBLD()
    {
        if(CINGFPEPPED.AJBPBEALBOB_SakashoCurrentAssetRevision == null)
            return GIDACIOHFNN_UpdateState.NHHHCIINJKO_0_UpToDate;

        if(IBLKLEMGCCG.AJBPBEALBOB_SakashoCurrentAssetRevision != CINGFPEPPED.AJBPBEALBOB_SakashoCurrentAssetRevision)
            return GIDACIOHFNN_UpdateState.GJCDHOAEIHP_2_NewDownloadData;
            
		return GIDACIOHFNN_UpdateState.NHHHCIINJKO_0_UpToDate;
    }
}
