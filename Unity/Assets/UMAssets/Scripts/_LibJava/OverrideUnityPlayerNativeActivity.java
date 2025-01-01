package jp.co.xeen.xeapp;

import android.content.Intent;
import android.media.AudioManager;
import android.net.Uri;
import android.os.Bundle;
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