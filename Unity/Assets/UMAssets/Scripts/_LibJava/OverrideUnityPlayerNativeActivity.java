package jp.co.xeen.xeapp;

import android.content.Intent;
import android.media.AudioManager;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URI;
import java.util.Objects;

//import com.adjust.sdk.Adjust;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;
//import jp.dena.sakasho.api.SakashoFacebookWithBrowser;
//import jp.dena.sakasho.api.SakashoLine;
//import jp.dena.sakasho.api.SakashoTwitter;

public class OverrideUnityPlayerNativeActivity extends UnityPlayerActivity {
    //private static final String CREATE_PLAYER_PATH = "/create_player";
    //private static final String FACEBOOK_CALLBACK = "facebook_callback";
    //private static final String LINE_CALLBACK = "line_callback";
    //private static final String LINK_WITH_PATH = "/linkage";
    //private static final String SCHEME_MAP = "uta-macross";
    //private static final String TWITTER_CALLBACK = "twitter_callback";
    private static volatile boolean active;
    private static int m_result;

    //public static void clearMapParam() {
    //}

    //public static String getMapParam() {
    //    return "";
    //}

    //private static void saveDecoMapParam(Uri uri) {
    //}

    /*@Override // com.unity3d.player.UnityPlayerActivity, android.app.Activity
    protected void onCreate(Bundle bundle) {
        super.onCreate(bundle);
        Intent intent = getIntent();
        if (intent != null) {
            callAuthenticationMethod(intent);
        }
    }*/

    /*@Override // com.unity3d.player.UnityPlayerActivity, android.app.Activity
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        setIntent(intent);
        if (intent != null) {
            callAuthenticationMethod(intent);
        }
    }*/

    /*private void callAuthenticationMethod(Intent intent) {
        if ("android.intent.action.VIEW".equals(intent.getAction())) {
            Uri data = intent.getData();
            if (data.getHost().equals(TWITTER_CALLBACK)) {
                if (data.getPath().equals(CREATE_PLAYER_PATH)) {
                    SakashoTwitter.callCreatePlayerFromTwitterAfterOAuth();
                    return;
                } else {
                    if (data.getPath().equals(LINK_WITH_PATH)) {
                        SakashoTwitter.callLinkWithTwitterAfterOAuth();
                        return;
                    }
                    return;
                }
            }
            if (data.getHost().equals(LINE_CALLBACK)) {
                if (data.getPath().equals(CREATE_PLAYER_PATH)) {
                    SakashoLine.callCreatePlayerFromLineAfterOAuth();
                    return;
                } else {
                    if (data.getPath().equals(LINK_WITH_PATH)) {
                        SakashoLine.callLinkWithLineAfterOAuth();
                        return;
                    }
                    return;
                }
            }
            if (data.getHost().equals(FACEBOOK_CALLBACK)) {
                String queryParameter = data.getQueryParameter("h");
                if (data.getPath().equals(CREATE_PLAYER_PATH)) {
                    SakashoFacebookWithBrowser.callCreatePlayerFromFacebookAfterOAuth(queryParameter);
                    return;
                } else {
                    if (data.getPath().equals(LINK_WITH_PATH)) {
                        SakashoFacebookWithBrowser.callLinkWithFacebookAfterOAuth(queryParameter);
                        return;
                    }
                    return;
                }
            }
            Adjust.appWillOpenUrl(data, getApplicationContext());
        }
    }*/

    @Override // com.unity3d.player.UnityPlayerActivity, android.app.Activity
    protected void onResume() {
        super.onResume();
        setActive(true);
        /*((AudioManager) getSystemService("audio")).requestAudioFocus(new AudioManager.OnAudioFocusChangeListener() { // from class: jp.co.xeen.xeapp.OverrideUnityPlayerNativeActivity.1
            @Override // android.media.AudioManager.OnAudioFocusChangeListener
            public void onAudioFocusChange(int i) {
            }
        }, 3, 1);*/
    }

    @Override // com.unity3d.player.UnityPlayerActivity, android.app.Activity
    protected void onPause() {
        super.onPause();
        setActive(false);
        /*((AudioManager) getSystemService("audio")).abandonAudioFocus(new AudioManager.OnAudioFocusChangeListener() { // from class: jp.co.xeen.xeapp.OverrideUnityPlayerNativeActivity.2
            @Override // android.media.AudioManager.OnAudioFocusChangeListener
            public void onAudioFocusChange(int i) {
            }
        });*/
    }

    @Override // android.app.Activity
    public void onRequestPermissionsResult(int i, String[] strArr, int[] iArr) {
        m_result = 1;
        if (i != 0) {
            return;
        }
        m_result = 2;
        if (iArr.length > 0 && iArr[0] == 0) {
            UnityPlayer.UnitySendMessage("UniAndroidPermission", "OnPermit", "");
            m_result = 3;
        } else {
            UnityPlayer.UnitySendMessage("UniAndroidPermission", "NotPermit", "");
            m_result = 4;
        }
    }

    FileLoadCallback loadCallbacks;

    public void setLoadCallbacks(FileLoadCallback callback) {
        loadCallbacks = callback;
    }

    @Override
    public void onActivityResult(int requestCode, 
                int resultCode, 
                Intent data)
    {
        if(requestCode == 0 && loadCallbacks != null)
        {
            if(resultCode == RESULT_OK)
            {
                Uri uri = data.getData();
                try
                {
                    byte[] myText = readDataFromUri( uri);
                    loadCallbacks.onSuccess(new ReadData(myText));
                }
                catch(IOException e) {
                    e.printStackTrace();
                    loadCallbacks.onError(("Load error"));    
                }
            }
            else
            {
                loadCallbacks.onError(("Load error"));
            }
        }
    }
    
    public String readTextFromUri(Uri uri) throws IOException
    {
        StringBuilder stringBuilder = new StringBuilder();
        try (InputStream inputStream =
                    getContentResolver().openInputStream(uri);
            BufferedReader reader = new BufferedReader(
                    new InputStreamReader(Objects.requireNonNull(inputStream)))) {
            String line;
            while ((line = reader.readLine()) != null) {
                stringBuilder.append(line);
            }
        }
        return stringBuilder.toString();
    }
    
    public byte[] readDataFromUri(Uri uri) throws IOException
    {
        byte[] res = null;
        try (InputStream inputStream =
                    getContentResolver().openInputStream(uri);)
        {
            ByteArrayOutputStream buffer = new ByteArrayOutputStream();

            int nRead;
            byte[] data = new byte[16384];

            while ((nRead = inputStream.read(data, 0, data.length)) != -1) {
                buffer.write(data, 0, nRead);
            }

            res = buffer.toByteArray();
        }
        return res;
    }

    /*public static int GetResultNo() {
        return m_result;
    }*/

    public static void setActive(boolean z) {
        active = z;
    }

    public static boolean isActive() {
        return active;
    }
}