package jp.co.xeen.xeapp;

public interface FileLoadCallback {
    public void onSuccess(ReadData data);
    public void onError(String errorMessage);
}
