package com.criware.filesystem;

import android.os.AsyncTask;
import android.os.Handler;
import android.os.Looper;
import android.os.Build;
import android.os.Build.VERSION;
import android.util.Log;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.InetSocketAddress;
import java.net.MalformedURLException;
import java.net.UnknownHostException;
import java.net.ProtocolException;
import java.net.SocketException;
import java.net.SocketTimeoutException;
import java.net.URL;
import java.security.GeneralSecurityException;
import java.util.Date;
import java.util.Locale;
import java.util.zip.CRC32;
import java.net.Proxy;

import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLException;
import javax.net.ssl.SSLHandshakeException;
import javax.net.ssl.SSLSocketFactory;
import javax.net.ssl.X509TrustManager;

public class CriFsWebInstaller {
   private static final boolean ENABLE_DEBUG_PRINT = false;
   private static CriFsWebInstallerManager manager;
   private boolean can_access_asynctask;
   private CRC32 crc_num;
   public boolean is_stop_required = false;
   private boolean is_timeouted;
   private boolean is_waiting_to_start;
   private long start_time;
   private StatusInfo synced_statusinfo = new StatusInfo();
   private WebInstallerTask task;
   private AsyncTaskParam task_params;
   private long timeout_start_time;

   CriFsWebInstaller() {
      if (manager.crc_enabled) {
         this.crc_num = new CRC32();
      }

      this.ClearMember();
   }

   private void ClearMember() {
      this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_STOP;
      this.synced_statusinfo.error = Error.CRIFSWEBINSTALLER_ERROR_NONE;
      this.synced_statusinfo.http_status_code = -1;
      this.synced_statusinfo.contents_size = -1L;
      this.synced_statusinfo.received_size = 0L;
      this.start_time = 0L;
      this.timeout_start_time = 0L;
      this.is_waiting_to_start = false;
      this.is_timeouted = false;
      this.can_access_asynctask = false;
      if (manager.crc_enabled && this.crc_num != null) {
         this.crc_num.reset();
      }

   }

   public static CriFsWebInstaller Create() {
      if (manager != null) {
         return manager.CreateInstaller();
      } else {
         ErrorEntry(1);
         return null;
      }
   }

   private static native boolean ErrorCallback(int var0);

   public static boolean ErrorEntry(int var0) {
      return ErrorCallback(var0);
   }

   public static void ExecuteMain() {
      if (manager != null) {
         manager.ExecuteMain();
      }

   }

   public static void Finalize() {
      if (manager != null) {
         manager.Manager_Finalize();
         manager = null;
      } else {
         ErrorEntry(1);
      }

   }

   private long GetNow() {
      return (new Date()).getTime();
   }

   public static void Initialize(Config var0) {
      if (manager == null) {
         manager = new CriFsWebInstallerManager();
         manager.Manager_Initialize(var0);
      } else {
         ErrorEntry(1);
      }

   }

   private static boolean IsRetryable(Error var0, long var1) {
      Error var7 = Error.CRIFSWEBINSTALLER_ERROR_CONNECTION;
      boolean var6 = false;
      boolean var3;
      if (var0 != var7 && var0 != Error.CRIFSWEBINSTALLER_ERROR_DNS) {
         var3 = false;
      } else {
         var3 = true;
      }

      boolean var4;
      if (var1 != -1L) {
         var4 = true;
      } else {
         var4 = false;
      }

      boolean var5 = var6;
      if (var3) {
         var5 = var6;
         if (var4) {
            var5 = true;
         }
      }

      return var5;
   }

   public static void SetRequestHeader(String var0, String var1) {
      if (manager != null) {
         manager.request_headers.set(var0, var1);
      }

   }

   private void StartTask(AsyncTaskParam var1) {
      try {
         Handler var3;
         if (VERSION.SDK_INT < 11) {
            var3 = new Handler(Looper.getMainLooper());
            Runnable var6 = new Runnable() {
               public void run() {
                  task = new WebInstallerTask();
                  task.execute((Object[])new AsyncTaskParam[]{var1});
                  can_access_asynctask = true;
               }
            };
            var3.post(var6);
         } else {
            if (VERSION.SDK_INT < 11 || VERSION.SDK_INT >= 16) {
               WebInstallerTask var5 = new WebInstallerTask();
               this.task = var5;
               this.task.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR, (Object[])new AsyncTaskParam[]{var1});
               this.can_access_asynctask = true;
               return;
            }

            var3 = new Handler(Looper.getMainLooper());
            Runnable var2 = new Runnable() {
               public void run() {
                  task = new WebInstallerTask();
                  task.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR, (Object[])new AsyncTaskParam[]{var1});
                  can_access_asynctask = true;
               }
            };
            var3.post(var2);
         }

      } catch (NullPointerException var4) {
         ErrorEntry(10);
         this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_ERROR;
         this.synced_statusinfo.error = Error.CRIFSWEBINSTALLER_ERROR_MEMORY;
      }
   }
/*
   static CriFsWebInstallerManager access$000() {
      return manager;
   }

   static CRC32 access$100(CriFsWebInstaller var0) {
      return var0.crc_num;
   }

   static WebInstallerTask access$200(CriFsWebInstaller var0) {
      return var0.task;
   }

   static WebInstallerTask access$202(CriFsWebInstaller var0, WebInstallerTask var1) {
      var0.task = var1;
      return var1;
   }

   static boolean access$302(CriFsWebInstaller var0, boolean var1) {
      var0.can_access_asynctask = var1;
      return var1;
   }
 */
   public void Copy(String var1, String var2) {
      if (this.synced_statusinfo.status != Status.CRIFSWEBINSTALLER_STATUS_STOP) {
         ErrorEntry(2);
      } else {
         this.ClearMember();
         this.is_stop_required = false;
         this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_BUSY;
         this.task_params = new AsyncTaskParam(var1, var2, this.synced_statusinfo.contents_size, this.synced_statusinfo.received_size);
         this.timeout_start_time = this.GetNow() / 1000L;
         this.StartTask(this.task_params);
      }
   }

   public void Destroy() {
      if (this.synced_statusinfo.status != Status.CRIFSWEBINSTALLER_STATUS_STOP) {
         ErrorEntry(2);
      } else {
         if (manager.installer_list.remove(this)) {
            CriFsWebInstallerManager var1 = manager;
            --var1.num_installers;
         }

      }
   }

   public long GetCRC32() {
      return this.crc_num.getValue();
   }

   public long GetStatusInfo_contents_size() {
      return this.synced_statusinfo.contents_size;
   }

   public int GetStatusInfo_error() {
      return this.synced_statusinfo.error.getValue();
   }

   public int GetStatusInfo_http_status_code() {
      return this.synced_statusinfo.http_status_code;
   }

   public long GetStatusInfo_received_size() {
      return this.synced_statusinfo.received_size;
   }

   public int GetStatusInfo_status() {
      return this.synced_statusinfo.status.getValue();
   }

   public int IsCRCEnabled() {
      return manager.crc_enabled ? 1 : 0;
   }

   public void Stop() {
      switch (Unknown._Status[this.synced_statusinfo.status.ordinal()]) {
         case 1:
         default:
            break;
         case 2:
            this.is_stop_required = true;
            break;
         case 3:
         case 4:
            this.ClearMember();
      }

   }

   public void Update() {
      if (this.synced_statusinfo.status == Status.CRIFSWEBINSTALLER_STATUS_BUSY && this.can_access_asynctask) {
         TaskStatusInfo var5 = this.task.GetTaskStatusInfo();
         if (var5 != null) {
            int var2 = Unknown._TaskStatus[var5.status.ordinal()];
            boolean var1 = false;
            long var3;
            switch (var2) {
               case 1:
                  if (this.is_stop_required) {
                     this.task.Cancel();
                  } else {
                     this.synced_statusinfo.contents_size = var5.contents_size;
                     if (var5.received_size > this.synced_statusinfo.received_size) {
                        var1 = true;
                     }

                     if (var1) {
                        this.synced_statusinfo.received_size = var5.received_size;
                        this.timeout_start_time = this.GetNow() / 1000L;
                     } else {
                        var3 = this.GetNow() / 1000L;
                        if (this.timeout_start_time + (long)manager.inactive_timeout_sec < var3) {
                           this.is_timeouted = true;
                           this.task.cancel(true);
                        }
                     }
                  }
                  break;
               case 2:
                  if (this.is_stop_required) {
                     StringBuilder var6 = new StringBuilder();
                     var6.append(this.task_params.param_dst_path);
                     var6.append(".tmp");
                     (new File(var6.toString())).delete();
                     this.ClearMember();
                  } else if (this.is_timeouted) {
                     this.synced_statusinfo.contents_size = var5.contents_size;
                     this.synced_statusinfo.received_size = var5.received_size;
                     this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_ERROR;
                     this.synced_statusinfo.error = Error.CRIFSWEBINSTALLER_ERROR_TIMEOUT;
                  } else {
                     this.synced_statusinfo.contents_size = var5.contents_size;
                     this.synced_statusinfo.received_size = var5.received_size;
                     var3 = this.GetNow() / 1000L;
                     if (this.timeout_start_time + (long)manager.inactive_timeout_sec < var3) {
                        this.is_timeouted = true;
                     }

                     if (var5.error == Error.CRIFSWEBINSTALLER_ERROR_NONE) {
                        this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_COMPLETE;
                        this.synced_statusinfo.http_status_code = var5.http_status_code;
                     } else if (IsRetryable(var5.error, this.synced_statusinfo.contents_size)) {
                        if (!this.is_waiting_to_start) {
                           this.is_waiting_to_start = true;
                           this.start_time = this.GetNow();
                        } else if (this.GetNow() - this.start_time >= 5000L) {
                           this.is_waiting_to_start = false;
                           this.task_params.param_contents_size = this.synced_statusinfo.contents_size;
                           this.task_params.param_received_size = this.synced_statusinfo.received_size;
                           this.can_access_asynctask = false;
                           this.StartTask(this.task_params);
                        }
                     } else {
                        this.synced_statusinfo.status = Status.CRIFSWEBINSTALLER_STATUS_ERROR;
                        this.synced_statusinfo.error = var5.error;
                        this.synced_statusinfo.http_status_code = var5.http_status_code;
                     }
                  }
                  break;
               case 3:
                  this.synced_statusinfo.contents_size = var5.contents_size;
                  this.synced_statusinfo.received_size = var5.received_size;
            }

         }
      }
   }

   public class AsyncTaskParam {
      long param_contents_size;
      String param_dst_path;
      long param_received_size;
      String param_src_path;

      AsyncTaskParam(String var2, String var3, long var4, long var6) {
         this.param_src_path = var2;
         this.param_dst_path = var3;
         this.param_contents_size = var4;
         this.param_received_size = var6;
      }
   }

   public class Config {
      boolean allow_insecure_ssl;
      boolean crc_enabled;
      int inactive_timeout_sec;
      int max_request_fields;
      int num_installers;
      String proxy_host;
      short proxy_port;
      String user_agent;
   }
   
   public enum Error {
      CRIFSWEBINSTALLER_ERROR_CONNECTION(5),
      CRIFSWEBINSTALLER_ERROR_DNS(4),
      CRIFSWEBINSTALLER_ERROR_HTTP(7),
      CRIFSWEBINSTALLER_ERROR_INTERNAL(8),
      CRIFSWEBINSTALLER_ERROR_LOCALFS(3),
      CRIFSWEBINSTALLER_ERROR_MEMORY(2),
      CRIFSWEBINSTALLER_ERROR_NONE(0),
      CRIFSWEBINSTALLER_ERROR_SSL(6),
      CRIFSWEBINSTALLER_ERROR_TIMEOUT(1);

      private int value;

      private Error(int var3) {
         this.value = var3;
      }

      public int getValue() {
         return this.value;
      }
   }

   public enum Status {
      CRIFSWEBINSTALLER_STATUS_BUSY(1),
      CRIFSWEBINSTALLER_STATUS_COMPLETE(2),
      CRIFSWEBINSTALLER_STATUS_ERROR(3),
      CRIFSWEBINSTALLER_STATUS_STOP(0);

      private int value;
   
      private Status(int var3) {
         this.value = var3;
      }
   
      public int getValue() {
         return this.value;
      }
   }
   
   public class StatusInfo {
      long contents_size;
      Error error;
      int http_status_code;
      long received_size;
      Status status;
   }

   public enum TaskStatus {
      BUSY,
      STOP,
      STOPPING
   }
   
   public class TaskStatusInfo {
      long contents_size;
      Error error;
      int http_status_code;
      long received_size;
      TaskStatus status;

      TaskStatusInfo() {
         this.status = TaskStatus.BUSY;
         this.error = Error.CRIFSWEBINSTALLER_ERROR_NONE;
         this.http_status_code = -1;
         this.contents_size = -1L;
         this.received_size = 0L;
      }
   }

   class WebInstallerTask extends AsyncTask {
      private static final int CONNECT_FAILURE = 1;
      private static final int CONNECT_SUCCESS = 0;
      private static final int MAX_REDIRECT_COUNT = 10;
      private static final int NEEDS_REDIRECT = 2;
      private HttpURLConnection http_connection;
      private boolean is_ssl;
      private String task_dst_path;
      private TaskStatusInfo task_internal_info;
      private String task_src_path;
      private File tmp_file;

      WebInstallerTask() {
         this.http_connection = null;
         this.task_internal_info = new TaskStatusInfo();
      }

      private void SetError(Error error, int i) {
         synchronized (this) {
            if (!(error == Error.CRIFSWEBINSTALLER_ERROR_CONNECTION || error == Error.CRIFSWEBINSTALLER_ERROR_DNS) && this.tmp_file.exists()) {
               this.tmp_file.delete();
            }
            this.task_internal_info.status = TaskStatus.STOP;
            this.task_internal_info.error = error;
            this.task_internal_info.http_status_code = i;
         }
      }


      private int task_connect() {
         long contentLength;
         try {
               this.http_connection.connect();
               int responseCode = this.http_connection.getResponseCode();
               //Log.w("AAAA", "code = "+responseCode+" "+task_internal_info.received_size);
               if (!(this.task_internal_info.received_size <= 0 || responseCode != 200)/*? CONNECT_SUCCESS : CONNECT_FAILURE */ ) {
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_HTTP, -1);
                  ErrorEntry(15);
                  return CONNECT_FAILURE;
               }
               if (responseCode == 200) {
                  contentLength = this.http_connection.getContentLength();
               } else if (responseCode == 206) {
                  contentLength = this.http_connection.getContentLength() + this.task_internal_info.received_size;
               } else if (responseCode >= 300 && responseCode <= 307 && responseCode != 306 && responseCode != 304) {
                  this.task_src_path = this.http_connection.getHeaderField("Location");
                  return NEEDS_REDIRECT;
               } else if (responseCode >= 0) {
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_HTTP, responseCode);
                  return CONNECT_FAILURE;
               } else {
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
                  return CONNECT_FAILURE;
               }
               synchronized (this) {
                  this.task_internal_info.http_status_code = responseCode;
                  this.task_internal_info.contents_size = contentLength;
               }
               return CONNECT_SUCCESS;
         } catch (FileNotFoundException e) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_HTTP, -1);
               return CONNECT_FAILURE;
         } catch (SocketException e2) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
               return CONNECT_FAILURE;
         } catch (SocketTimeoutException e3) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
               return CONNECT_FAILURE;
         } catch (UnknownHostException e4) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
               return CONNECT_FAILURE;
         } catch (SSLHandshakeException e5) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_SSL, -1);
               return CONNECT_FAILURE;
         } catch (SSLException e6) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_SSL, -1);
               return CONNECT_FAILURE;
         } catch (IOException e7) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
               ErrorEntry(5);
               e7.printStackTrace();
               return CONNECT_FAILURE;
         }
      }

      private boolean task_copyfile() {
         try {
               InputStream inputStream = this.http_connection.getInputStream();
               FileOutputStream fileOutputStream = new FileOutputStream(this.tmp_file, true);
               byte[] bArr = new byte[65536];
               while (!isCancelled()) {
                  try {
                     int read = inputStream.read(bArr);
                     if (read != -1) {
                           if (read == 0) {
                              try {
                                 Thread.sleep(10L);
                              } catch (InterruptedException e) {
                              }
                           } else {
                              if (manager.crc_enabled) {
                                 try {
                                       crc_num.update(bArr, 0, read);
                                 } catch (ArrayIndexOutOfBoundsException e2) {
                                       SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, -1);
                                       ErrorEntry(13);
                                       break;
                                 }
                              }
                              try {
                                 fileOutputStream.write(bArr, 0, read);
                                 synchronized (this) {
                                       this.task_internal_info.received_size += read;
                                 }
                              } catch (IOException e3) {
                                 SetError(Error.CRIFSWEBINSTALLER_ERROR_LOCALFS, -1);
                                 break;
                              }
                           }
                     }
                     else
                        break;
                  } catch (IOException e4) {
                     SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
                  }
               }
               try {
                  inputStream.close();
               } catch (IOException e5) {
               }
               try {
                  fileOutputStream.close();
               } catch (IOException e6) {
               }
               this.http_connection.disconnect();
               if (this.task_internal_info.error != Error.CRIFSWEBINSTALLER_ERROR_NONE) {
                  if (this.task_internal_info.error == Error.CRIFSWEBINSTALLER_ERROR_LOCALFS) {
                     this.tmp_file.delete();
                  }
                  return false;
               } else if (isCancelled()) {
                  this.tmp_file.delete();
                  return false;
               } else if (this.task_internal_info.received_size != this.task_internal_info.contents_size) {
                  this.tmp_file.delete();
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, -1);
                  ErrorEntry(14);
                  return false;
               } else {
                  File file = new File(this.task_dst_path);
                  if (file.exists()) {
                     this.tmp_file.delete();
                     SetError(Error.CRIFSWEBINSTALLER_ERROR_LOCALFS, -1);
                     return false;
                  }
                  this.tmp_file.renameTo(file);
                  return true;
               }
         } catch (SocketTimeoutException e7) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, -1);
               return false;
         } catch (FileNotFoundException e8) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_LOCALFS, -1);
               return false;
         } catch (NullPointerException e9) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_MEMORY, -1);
               return false;
         } catch (IOException e10) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, -1);
               ErrorEntry(6);
               e10.printStackTrace();
               return false;
         } finally {
               this.http_connection.disconnect();
         }
      }

      private boolean task_setup() {
         X509TrustManager[] x509TrustManagerArr;
         SSLSocketFactory sSLSocketFactory;
         try {
               this.tmp_file = new File(this.task_dst_path + ".tmp");
               if (this.task_src_path.toLowerCase(Locale.ENGLISH).startsWith("https://")) {
                  this.is_ssl = true;
               } else if (this.task_src_path.toLowerCase(Locale.ENGLISH).startsWith("http://")) {
                  this.is_ssl = false;
               } else {
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
                  ErrorEntry(7);
                  return false;
               }
               URL url = new URL(this.task_src_path);
               if (!manager.allow_insecure_ssl || !this.is_ssl) {
                  x509TrustManagerArr = null;
               } else {
                  X509TrustManager[] x509TrustManagerArr2 = new X509TrustManager[1];
                  x509TrustManagerArr2[0] = manager.new LooseTrustManager();
                  x509TrustManagerArr = x509TrustManagerArr2;
               }
               boolean z = !(Build.VERSION.SDK_INT < 16 || Build.VERSION.SDK_INT >= 21) /*? CONNECT_SUCCESS : CONNECT_FAILURE*/;
               if (z || x509TrustManagerArr != null) {
                  SSLContext instance = SSLContext.getInstance("TLS");
                  instance.init(null, x509TrustManagerArr, null);
                  sSLSocketFactory = z ? new TLSSocketFactory(instance.getSocketFactory()) : instance.getSocketFactory();
               } else {
                  sSLSocketFactory = null;
               }
               try {
                  if (manager.proxy_host == null || manager.proxy_port == 0) {
                     CriFsWebInstallerManager access$000 = manager;
                     String property = System.getProperty("http.proxyHost");
                     access$000.proxy_host = property;
                     if (property != null) {
                           String property2 = System.getProperty("http.proxyPort");
                           CriFsWebInstallerManager access$0002 = manager;
                           if (property2 == null) {
                              property2 = "-1";
                           }
                           access$0002.proxy_port = Short.parseShort(property2);
                           this.http_connection = (HttpURLConnection) url.openConnection(new Proxy(Proxy.Type.HTTP, new InetSocketAddress(manager.proxy_host, manager.proxy_port)));
                     } else {
                           this.http_connection = (HttpURLConnection) url.openConnection();
                     }
                  } else {
                     this.http_connection = (HttpURLConnection) url.openConnection(new Proxy(Proxy.Type.HTTP, new InetSocketAddress(manager.proxy_host, manager.proxy_port)));
                  }
                  this.http_connection.setRequestMethod("GET");
                  this.http_connection.setInstanceFollowRedirects(false);
                  this.http_connection.setDoInput(true);
                  this.http_connection.setConnectTimeout(5000);
                  this.http_connection.setReadTimeout(5000);
                  this.http_connection.setRequestProperty("User-Agent", manager.user_agent);
                  this.http_connection.setRequestProperty("Accept-Encoding", "identity");
                  for (int i = 0; i < manager.request_headers.length(); i += 1) {
                     try {
                           this.http_connection.setRequestProperty(manager.request_headers.getFieldName(i), manager.request_headers.getValue(i));
                     } catch (IllegalArgumentException e) {
                           SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
                           ErrorEntry(12);
                           return false;
                     }
                  }
                  if (sSLSocketFactory != null && this.is_ssl/* == CONNECT_FAILURE*/) {
                     ((HttpsURLConnection) this.http_connection).setSSLSocketFactory(sSLSocketFactory);
                  }
                  if (this.task_internal_info.contents_size != -1) {
                     if (!this.tmp_file.exists()) {
                           ErrorEntry(8);
                           SetError(Error.CRIFSWEBINSTALLER_ERROR_LOCALFS, this.task_internal_info.http_status_code);
                           return false;
                     } else if (this.tmp_file.length() != this.task_internal_info.received_size) {
                           ErrorEntry(9);
                           SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
                           return false;
                     } else {
                           this.http_connection.setRequestProperty("Range", "bytes=" + this.tmp_file.length() + "-");
                     }
                  } else if (this.tmp_file.exists()) {
                     this.tmp_file.delete();
                  }
                  return true;
               } catch (IllegalArgumentException e2) {
                  SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
                  ErrorEntry(11);
                  return false;
               }
         } catch (MalformedURLException e3) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_DNS, this.task_internal_info.http_status_code);
               e3.printStackTrace();
               return false;
         } catch (ProtocolException e4) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_CONNECTION, this.task_internal_info.http_status_code);
               e4.printStackTrace();
               return false;
         } catch (IOException e5) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
               ErrorEntry(4);
               e5.printStackTrace();
               return false;
         } catch (NullPointerException e6) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_MEMORY, this.task_internal_info.http_status_code);
               e6.printStackTrace();
               return false;
         } catch (GeneralSecurityException e7) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_SSL, this.task_internal_info.http_status_code);
               e7.printStackTrace();
               return false;
         }
      }

      public void Cancel() {
         cancel(true);
         synchronized (this) {
            this.task_internal_info.status = TaskStatus.STOPPING;
         }
      }

      public TaskStatusInfo GetTaskStatusInfo() {
         TaskStatusInfo taskStatusInfo;
         synchronized (this) {
            taskStatusInfo = this.task_internal_info;
         }
         return taskStatusInfo;
      }

      @Override
      protected Boolean doInBackground(Object... param) {
         AsyncTaskParam[] asyncTaskParamArr = (AsyncTaskParam[])param;
         this.task_src_path = asyncTaskParamArr[0].param_src_path;
         this.task_dst_path = asyncTaskParamArr[0].param_dst_path;
         synchronized (this) {
            this.task_internal_info.contents_size = asyncTaskParamArr[0].param_contents_size;
            this.task_internal_info.received_size = asyncTaskParamArr[0].param_received_size;
         }
         int i = 0;
         while (task_setup()) {
            if (isCancelled()) {
               this.tmp_file.delete();
               this.http_connection.disconnect();
               return false;
            }
            int task_connect = task_connect();
            if (task_connect == 2) {
               this.http_connection.disconnect();
               i += 1;
            }
            if (i > MAX_REDIRECT_COUNT) {
               SetError(Error.CRIFSWEBINSTALLER_ERROR_INTERNAL, this.task_internal_info.http_status_code);
               ErrorEntry(16);
               return false;
            } else if (task_connect != 2) {
               if (task_connect == 1) {
                     this.http_connection.disconnect();
                     return false;
               } else if (!task_copyfile()) {
                     return false;
               } else {
                     synchronized (this) {
                        this.task_internal_info.status = TaskStatus.STOP;
                     }
                     return true;
               }
            }
         }
         if (this.http_connection != null) {
            this.http_connection.disconnect();
         }
         return false;
      }

      @Override // android.os.AsyncTask
      protected void onCancelled() {
         synchronized (this) {
            this.task_internal_info.status = TaskStatus.STOP;
         }
      }

      protected void onPostExecute(Boolean bool) {
         synchronized (this) {
            this.task_internal_info.status = TaskStatus.STOP;
         }
      }
   }

   static class Unknown {
      static final int[] _Status = new int[Status.values().length];
      static final int[] _TaskStatus;
   
      static {
         try {
            _Status[Status.CRIFSWEBINSTALLER_STATUS_STOP.ordinal()] = 1;
         } catch (NoSuchFieldError var7) {
         }
   
         try {
            _Status[Status.CRIFSWEBINSTALLER_STATUS_BUSY.ordinal()] = 2;
         } catch (NoSuchFieldError var6) {
         }
   
         try {
            _Status[Status.CRIFSWEBINSTALLER_STATUS_COMPLETE.ordinal()] = 3;
         } catch (NoSuchFieldError var5) {
         }
   
         try {
            _Status[Status.CRIFSWEBINSTALLER_STATUS_ERROR.ordinal()] = 4;
         } catch (NoSuchFieldError var4) {
         }
   
         _TaskStatus = new int[TaskStatus.values().length];
   
         try {
            _TaskStatus[TaskStatus.BUSY.ordinal()] = 1;
         } catch (NoSuchFieldError var3) {
         }
   
         try {
            _TaskStatus[TaskStatus.STOP.ordinal()] = 2;
         } catch (NoSuchFieldError var2) {
         }
   
         try {
            _TaskStatus[TaskStatus.STOPPING.ordinal()] = 3;
         } catch (NoSuchFieldError var1) {
         }
   
      }
   }
   
}
