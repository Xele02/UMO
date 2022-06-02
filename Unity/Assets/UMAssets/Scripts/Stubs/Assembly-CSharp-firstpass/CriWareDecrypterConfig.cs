using System;

[Serializable]
public class CriWareDecrypterConfig
{
	public string key;
	public string authenticationFile;
	public bool enableAtomDecryption;
	public bool enableManaDecryption;
}
