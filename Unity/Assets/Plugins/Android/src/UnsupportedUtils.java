package com.sony.smartar.unsupportedutils;

import java.io.File;

import android.annotation.TargetApi;
import android.content.Context;
import android.hardware.Camera;
import android.hardware.Camera.CameraInfo;
import android.hardware.camera2.CameraCharacteristics;
import android.hardware.camera2.CameraManager;
import android.media.MediaActionSound;
import android.media.MediaScannerConnection;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.os.Handler;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

@SuppressWarnings("deprecation")
public class UnsupportedUtils {

    private static final String SMART_CAPTURE_DIRECTORY = "/smartar/capture/";
    
    private UnsupportedUtils() {
    }

    @TargetApi(Build.VERSION_CODES.JELLY_BEAN)
    public static void playSystemShutterSound() {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.JELLY_BEAN) { return; }

        final MediaActionSound mas = new MediaActionSound();
        mas.load(MediaActionSound.SHUTTER_CLICK);
        new Handler(UnityPlayer.currentActivity.getMainLooper()).postDelayed(new Runnable() {
            @Override
            public void run() {
                mas.play(MediaActionSound.SHUTTER_CLICK);
            }
        }, 100);
    }

    public static String moveToExternalDir(String path) {
        final File captureImageFile = new File(path);
        if (!captureImageFile.exists()) { return null; }

        final String outputPath = Environment.getExternalStorageDirectory().getAbsolutePath() + SMART_CAPTURE_DIRECTORY;
        if (!new File(outputPath).exists()) {
            new File(outputPath).mkdirs();
        }
        final File dest = new File(outputPath, captureImageFile.getName());
        final boolean success = captureImageFile.renameTo(dest);

        return success ? dest.getAbsolutePath() : null;
    }

    public static void scanCaptureImage(String path) {
        final Context context = UnityPlayer.currentActivity.getApplicationContext();
        final String[] paths = new String[] { path };
        final String[] mimeTypes = new String[] { "image/*" };
        MediaScannerConnection.scanFile(context, paths, mimeTypes, new MediaScannerConnection.OnScanCompletedListener() {
            @Override
            public void onScanCompleted(String path, Uri uri) {
                UnityPlayer.currentActivity.runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(context, "Completed capture image.", Toast.LENGTH_LONG).show();
                    }
                });
            }
        });
    }
    
    public static float getFovY(boolean isFront) {
    	final Camera.Parameters params = getCameraParams(isFront);
    	if (params == null) {
    		return 0.0f;
    	}
    	return params.getVerticalViewAngle();
    }
    
    public static float getFocalLength(boolean isFront) {
    	final Camera.Parameters params = getCameraParams(isFront);
    	if (params == null) {
    		return 0.0f;
    	}
    	return params.getFocalLength();
    }
    
    public static int getImageSensorRotation(boolean isFront, Context context) {
    	if (android.os.Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP) {	// camera 2
    		try {
	    		CameraManager manager = (CameraManager) context.getSystemService(Context.CAMERA_SERVICE);
	    		
	    		String cameraIdStr = null;
				for (String curCameraIdStr : manager.getCameraIdList()) {
				    CameraCharacteristics characteristics = manager.getCameraCharacteristics(curCameraIdStr);
				    Integer facing = characteristics.get(CameraCharacteristics.LENS_FACING);
				    if (facing != null && facing == CameraCharacteristics.LENS_FACING_FRONT) {
			    		if (isFront) {
					        // front camera
			    			cameraIdStr = curCameraIdStr;
			    			break;
			    		}
				    }
				    else if (facing != null && facing == CameraCharacteristics.LENS_FACING_BACK) {
				    	if (!isFront) {
					    	// back camera
				    		cameraIdStr = curCameraIdStr;
				    		break;
				    	}
				    }
				}
				if (cameraIdStr == null) {
					return defaultImageSensorRotation(isFront);
				}

	    		CameraCharacteristics camChars = null;
	   			camChars = manager.getCameraCharacteristics(cameraIdStr);
	   	        return camChars.get(CameraCharacteristics.SENSOR_ORIENTATION);
    		}
    		catch (Exception e) {
        		return defaultImageSensorRotation(isFront);
    		}
    	}
    	else {	// camera 1
    		return defaultImageSensorRotation(isFront);
    	}
    }
    
    private static int defaultImageSensorRotation(boolean isFront) {
		if (isFront) {
			return 270;
		}
		else {
			return 90;
		}
    }
    
    private static Camera.Parameters getCameraParams(boolean isFront) {
    	final int cameraId = isFront ? 1 : 0;
    	Camera camera = Camera.open(cameraId);
    	if (camera == null) {
    		return null;
    	}
    	
    	CameraInfo cameraInfo = new CameraInfo();
    	Camera.getCameraInfo(cameraId, cameraInfo);
    	if (cameraInfo.facing == CameraInfo.CAMERA_FACING_FRONT
    			&& cameraId == 0) {
    		camera.release();
    		camera = null;
    		return null;	// error. Nexus 7(2012)
    	}
    	
    	Camera.Parameters params = camera.getParameters();
    	camera.release();
    	camera = null;
    	return params;
    }
}
