package com.criware.filesystem;

import java.io.IOException;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;
import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import javax.net.ssl.KeyManager;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSocket;
import javax.net.ssl.SSLSocketFactory;
import javax.net.ssl.TrustManager;

public class TLSSocketFactory extends SSLSocketFactory {
   private SSLSocketFactory internalSSLSocketFactory;

   public TLSSocketFactory(SSLSocketFactory var1) throws KeyManagementException, NoSuchAlgorithmException {
      if (var1 != null) {
         this.internalSSLSocketFactory = var1;
      } else {
         SSLContext var2 = SSLContext.getInstance("TLS");
         var2.init((KeyManager[])null, (TrustManager[])null, (SecureRandom)null);
         this.internalSSLSocketFactory = var2.getSocketFactory();
      }

   }

   public Socket createSocket() throws IOException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket());
   }

   public Socket createSocket(String var1, int var2) throws IOException, UnknownHostException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket(var1, var2));
   }

   public Socket createSocket(String var1, int var2, InetAddress var3, int var4) throws IOException, UnknownHostException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket(var1, var2, var3, var4));
   }

   public Socket createSocket(InetAddress var1, int var2) throws IOException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket(var1, var2));
   }

   public Socket createSocket(InetAddress var1, int var2, InetAddress var3, int var4) throws IOException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket(var1, var2, var3, var4));
   }

   public Socket createSocket(Socket var1, String var2, int var3, boolean var4) throws IOException {
      return this.enableTLSOnSocket(this.internalSSLSocketFactory.createSocket(var1, var2, var3, var4));
   }

   protected Socket enableTLSOnSocket(Socket var1) {
      if (var1 != null && var1 instanceof SSLSocket) {
         ((SSLSocket)var1).setEnabledProtocols(new String[]{"TLSv1", "TLSv1.1", "TLSv1.2"});
      }

      return var1;
   }

   public String[] getDefaultCipherSuites() {
      return this.internalSSLSocketFactory.getDefaultCipherSuites();
   }

   public String[] getSupportedCipherSuites() {
      return this.internalSSLSocketFactory.getSupportedCipherSuites();
   }
}
