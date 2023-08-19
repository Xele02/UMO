package com.criware.filesystem;

import java.security.cert.CertificateException;
import java.security.cert.X509Certificate;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ConcurrentLinkedQueue;

import javax.net.ssl.X509TrustManager;

public class CriFsWebInstallerManager {
   public boolean allow_insecure_ssl;
   public boolean crc_enabled;
   public int inactive_timeout_sec;
   public ConcurrentLinkedQueue installer_list;
   public boolean is_initialized;
   public int num_installers;
   private int num_installers_max;
   public String proxy_host = "";
   public short proxy_port = -1;
   public RequestHeaders request_headers;
   public String user_agent;

   public CriFsWebInstaller CreateInstaller() {
      if (this.num_installers >= this.num_installers_max) {
         CriFsWebInstaller.ErrorEntry(3);
         return null;
      } else {
         CriFsWebInstaller var1 = new CriFsWebInstaller();
         if (this.installer_list.add(var1)) {
            ++this.num_installers;
         }

         return var1;
      }
   }

   public void ExecuteMain() {
      Iterator var1 = this.installer_list.iterator();

      while(var1.hasNext()) {
         ((CriFsWebInstaller)var1.next()).Update();
      }

   }

   public void Manager_Finalize() {
      if (this.is_initialized) {
         Iterator var1 = this.installer_list.iterator();

         while(var1.hasNext()) {
            CriFsWebInstaller var2 = (CriFsWebInstaller)var1.next();
            var2.is_stop_required = true;
            this.installer_list.remove(var2);
         }

         this.is_initialized = false;
      }
   }

   public void Manager_Initialize(CriFsWebInstaller.Config var1) {
      if (!this.is_initialized) {
         this.num_installers = var1.num_installers;
         this.allow_insecure_ssl = var1.allow_insecure_ssl;
         this.inactive_timeout_sec = var1.inactive_timeout_sec;
         this.proxy_host = var1.proxy_host;
         this.proxy_port = var1.proxy_port;
         this.user_agent = var1.user_agent;
         this.crc_enabled = var1.crc_enabled;
         this.num_installers_max = this.num_installers;
         this.num_installers = 0;
         this.installer_list = new ConcurrentLinkedQueue();
         this.request_headers = new RequestHeaders(var1.max_request_fields);
         this.is_initialized = true;
      }
   }

   public class LooseTrustManager implements X509TrustManager {
      public void checkClientTrusted(X509Certificate[] var1, String var2) throws CertificateException {
      }

      public void checkServerTrusted(X509Certificate[] var1, String var2) throws CertificateException {
      }

      public X509Certificate[] getAcceptedIssuers() {
         return null;
      }
   }

   public final class RequestHeaders {
      private List fieldAndValues;

      public RequestHeaders(int var2) {
         this.fieldAndValues = null;
         this.fieldAndValues = new ArrayList(var2 * 2);
      }

      private void add(String var1, String var2) {
         this.fieldAndValues.add(var1);
         this.fieldAndValues.add(var2);
      }

      private void removeAll(String var1) {
         for(int var2 = 0; var2 < this.fieldAndValues.size(); var2 += 2) {
            if (var1.equalsIgnoreCase((String)this.fieldAndValues.get(var2))) {
               this.fieldAndValues.remove(var2);
               this.fieldAndValues.remove(var2);
            }
         }

      }

      public String getFieldName(int var1) {
         var1 *= 2;
         return var1 >= 0 && var1 < this.fieldAndValues.size() ? (String)this.fieldAndValues.get(var1) : null;
      }

      public String getValue(int var1) {
         var1 = var1 * 2 + 1;
         return var1 >= 0 && var1 < this.fieldAndValues.size() ? (String)this.fieldAndValues.get(var1) : null;
      }

      public int length() {
         return this.fieldAndValues.size() / 2;
      }

      public void set(String var1, String var2) {
         this.removeAll(var1);
         if (var2 != null) {
            this.add(var1, var2);
         }

      }
   }

}
