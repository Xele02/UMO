public class CriWareInitializer : CriMonoBehaviour
{
	public bool initializesFileSystem;
	public CriFsConfig fileSystemConfig;
	public bool initializesAtom;
	public CriAtomConfig atomConfig;
	public bool initializesMana;
	public CriManaConfig manaConfig;
	public bool useDecrypter;
	public CriWareDecrypterConfig decrypterConfig;
	public bool dontInitializeOnAwake;
	public bool dontDestroyOnLoad;
}
