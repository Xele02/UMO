
[System.Serializable]
public class CriWareDecrypterConfig {
	/*JP 暗号化キー */
	public string key = "";
	/*JP 復号化認証ファイルのパス */
	public string authenticationFile = "";
	/*JP CRI Atomの復号化を有効にするかどうか */
	public bool enableAtomDecryption = true;
	/*JP CRI Manaの復号化を有効にするかどうか */
	public bool enableManaDecryption = true;
}