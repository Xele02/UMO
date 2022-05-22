using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

namespace Cryptor
{
    public class DsfdLoader
    {
        public interface ILoadRequest
        {
            bool IsDone { get; } // Slot: 0
            bool IsSuccess { get; } // Slot: 1
            byte[] Result { get; } // Slot: 2
            string FilePath { get; } // Slot: 3
        }

        public class LoadRequest : ILoadRequest
        {
            private object lockObject; // 0x8
            
            public bool IsDone { get; set; } // IsDone 0xC
            public bool IsSuccess { get; set; } // IsSuccess 0xD
            public byte[] Result { get; set; } // Result // 0x10
            public string FilePath { get; set; } // FilePath // 0x14

            // // RVA: 0x2BAFBC4 Offset: 0x2BAFBC4 VA: 0x2BAFBC4
            // public void FinishRequest(bool succeed, byte[] result) { }

            public LoadRequest(string path)
            {
                lockObject = new object();
                IsDone = false;
                Result = null;
                FilePath = path;
            }
        }

        private class Key
        {
            public byte[] key = new byte[16];
        }

        private class KeyGenerator
        {
            static private bool GetSeedFromString(Key key, string seed)
            {
                if(seed.StartsWith("0x"))
                {
                    seed.Replace("0x","");
                }
                if(0x20 != seed.Length)
                {
                    Debug.LogError("Seed size don't match");
                    return false;
                }
                for(int i = 0; i < 16; i++)
                {
                    key.key[i] = (byte)int.Parse(seed.Substring(i*2, 2),System.Globalization.NumberStyles.HexNumber);
                }
                return true;
            }

            static public bool Gen(Key key, string seed1, string seed2, string seed3)
            {
                Key k1 = new Key();
                Key k2 = new Key();
                Key k3 = new Key();
                if(!GetSeedFromString(k1, seed1))
                    return false;
                if(!GetSeedFromString(k2, seed2))
                    return false;
                if(!GetSeedFromString(k3, seed3))
                    return false;
                //ldmia int to byte[4] order?
                byte[] h = new byte[0x30] { 
                    0xd3, 0x1f, 0x5d, 0xdd,//0xdd5d1fd3, 
                    0x61, 0x4b, 0xeb, 0x82,//0x82eb4b61, 
                    0x8f, 0x86, 0x37, 0x81,//0x8137868f, 
                    0xf0, 0xb2, 0x52, 0xd4,//0xd452b2f0, 
                    0x52, 0x3f, 0x1c, 0x1e,//0x1e1c3f52, 
                    0xcc, 0x05, 0x22, 0x22,//0x222205cc, 
                    0x08, 0x78, 0xef, 0xe5,//0xe5ef7808, 
                    0xeb, 0x25, 0xa0, 0xc4,//0xc4a025eb, 
                    0x82, 0x2c, 0xc1, 0x8c,//0x8cc12c82, 
                    0x02, 0xe8, 0x12, 0x81,//0x8112e802, 
                    0x8d, 0xaa, 0x51, 0xa8,//0xa851aa8d, 
                    0xf2, 0x79, 0xc6, 0x1d//0x1dc679f2 
                };

                byte[] resTotal = new byte[0x30];

                IncrementalHash im = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
                im.AppendData(k1.key, 0, 0x10);
                im.AppendData(h, 0, 0x10);
                byte[] res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0, 0x10);

                im.AppendData(k2.key, 0, 0x10);
                im.AppendData(h, 0x10, 0x10);
                res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0x10, 0x10);

                im.AppendData(k3.key, 0, 0x10);
                im.AppendData(h, 0x20, 0x10);
                res1 = im.GetHashAndReset();
                System.Buffer.BlockCopy(res1, 0, resTotal, 0x20, 0x10);

                im.AppendData(resTotal, 0, 0x30);
                key.key = im.GetHashAndReset();
                return true;
            }
        }

        // https://github.com/MersenneTwister-Lab/XSadd/blob/master/xsadd.c
        private class XSadd
        {
            uint[] state;

            const int LOOP = 8;


            /**
            * This function initializes the internal state array with a 32-bit
            * unsigned integer seed.
            * @param[out] xsadd xsadd state vector.
            * @param[in] seed a 32-bit unsigned integer used as a seed.
            */
            public void Init(uint seed)
            {
                state = new uint[4];
                state[0] = seed;
                state[1] = 0;
                state[2] = 0;
                state[3] = 0;
                for (int i = 1; i < LOOP; i++) {
                    state[i & 3] ^= (uint)(i + 1812433253
                        * (state[(i - 1) & 3]
                        ^ (state[(i - 1) & 3] >> 30)));
                }
                PeriodCertification();
                for (int i = 0; i < LOOP; i++) {
                    NextState();
                }
            }

            void PeriodCertification()
            {
                if (state[0] == 0 &&
                    state[1] == 0 &&
                    state[2] == 0 &&
                    state[3] == 0) {
                    state[0] = 'X';
                    state[1] = 'S';
                    state[2] = 'A';
                    state[3] = 'D';
                }
            }

            /**
            * This function changes internal state of xsadd.
            * Users should not call this function directly.
            * @param[in,out] xsadd xsadd internal state
            */
            void NextState()
            {
                const int sh1 = 15;
                const int sh2 = 18;
                const int sh3 = 11;
                uint t;
                t = state[0];
                t ^= t << sh1;
                t ^= t >> sh2;
                t ^= state[3] << sh3;
                state[0] = state[1];
                state[1] = state[2];
                state[2] = state[3];
                state[3] = t;
            }

            /**
            * This function outputs 32-bit unsigned integer from internal state.
            * @param[in,out] xsadd xsadd internal state
            * @return 32-bit unsigned integer r (0 <= r < 2^32)
            */
            public uint Uint32()
            {
                NextState();
                return state[3] + state[2];
            }
        }

        private class DeRandomXSadd
        {
            XSadd xsadd;
            public DeRandomXSadd()
            {
                xsadd = new XSadd();
            }

            public void SetSeed(uint seed)
            {
                xsadd.Init(seed);
            }

            public void GetRandBytes(byte[] outData, int size)
            {
                int numInt = size / 4;
                int idx = 0;
                while(numInt > 0)
                {
                    uint rand = xsadd.Uint32();
                    outData[idx++] = (byte)rand;
                    outData[idx++] = (byte)(rand >> 8);
                    outData[idx++] = (byte)(rand >> 16);
                    outData[idx++] = (byte)(rand >> 24);
                    numInt--;
                }
                if((size & 0x3) != 0)
                {
                    uint rand = xsadd.Uint32();
                    for(int i = 0; i < (size & 0x3); i++)
                    {
                        outData[idx++] = (byte)(rand >> (i*8));
                    }
                }
            }
        }

        private class DeDecryptAES
        {
            char[] key;
            byte[] k = new byte[16];
            byte[] k2 = new byte[16];
            DeRandomXSadd randXSadd;

            public DeDecryptAES()
            {
                key = null;
                randXSadd = new DeRandomXSadd();
                System.DateTime time = System.DateTime.Now;
                randXSadd.SetSeed(0); // todo rand
            }

            public bool Initialize(Key _k)
            {
                if(key != null)
                    return false;
                key = new char[0x160];
                randXSadd.GetRandBytes(k2, 0x10);
                for(int i = 0; i < 16; i++)
                    k[i] = (byte)(k2[i] ^ _k.key[i]);
                return true;
            }
        }

        private class Decryptor
        {
            bool AesInitialized;
            DeDecryptAES aes;

            public Decryptor()
            {
                aes = new  DeDecryptAES();
                // 0x34 = 0;
            }

            public bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3)
            {
                Key k = new Key();
                string s1 = System.Text.Encoding.Default.GetString(seed1);
                string s2 = System.Text.Encoding.Default.GetString(seed2);
                string s3 = System.Text.Encoding.Default.GetString(seed3);
                bool r = KeyGenerator.Gen(k, s1, s2, s3);
                if(!r)
                {
                    Debug.LogError("Error generating key");
                    return false;
                }
                if(!AesInitialized)
                    AesInitialized = aes.Initialize(k);
                
                return AesInitialized;
            }
        }

        private class DeRingBuffer
        {

        }

        private class DecryptManager
        {
            public Decryptor decryptor;

            public bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3)
            {
                decryptor = new Decryptor();
                bool res = decryptor.Initialize(seed1, seed2, seed3);
                if(!res)
                    return false;
                // stuff with ringbuffer
                return true;
            }

            public uint Request(string filePath)
            {
                return ExecRequest(filePath); // async in original dll
            }

            public uint ExecRequest(string filePath)
            {
                DeRingBuffer ringBuffer = new DeRingBuffer();
                //!!!
                return 0;
            }
        }
        static private DecryptManager decryptManager;


        private static bool isInitialized; // 0x0
        private static Dictionary<uint, LoadRequest> loadRequestDict; // 0x4

        // // Methods

        // // RVA: 0x2BAE368 Offset: 0x2BAE368 VA: 0x2BAE368
        private static /*extern */bool dsfd_initialize(byte[] seed1, byte[] seed2, byte[] seed3/*[In] IntPtr seed1, [In] IntPtr seed2, [In] IntPtr seed3*/) 
        { 
            // Call lib dsfd dsfd_initialize

            // stuff with the array...
            decryptManager = new DecryptManager();
            bool res = decryptManager.Initialize(seed1, seed2, seed3);
            return res;
        }

        // // RVA: 0x2BAE488 Offset: 0x2BAE488 VA: 0x2BAE488
        // private static extern void dsfd_finalize() { }

        // // RVA: 0x2BAE578 Offset: 0x2BAE578 VA: 0x2BAE578
        // private static extern void dsfd_release_results([In] DsfdLoader.DecryptedResultList result) { }

        // // RVA: 0x2BAE690 Offset: 0x2BAE690 VA: 0x2BAE690
        private static /*extern */uint dsfd_single(string filePath)
        {
            // Call lib dsfd  dsfd_single
            return decryptManager.Request(filePath);
        }

        // // RVA: 0x2BAE7B0 Offset: 0x2BAE7B0 VA: 0x2BAE7B0
        // private static extern uint dsfd_multiple(uint[] handles, string[] filePaths, int size) { }

        // // RVA: 0x2BAE998 Offset: 0x2BAE998 VA: 0x2BAE998
        // private static extern DsfdLoader.DecryptedResultList dsfd_poll_results() { }

        // // RVA: 0x2BAEAA8 Offset: 0x2BAEAA8 VA: 0x2BAEAA8
        public static bool Initialize(byte[] seed1, byte[] seed2, byte[] seed3, bool shouldShowLogOnEditor = true)
        {
            loadRequestDict = new Dictionary<uint, LoadRequest>();
            if(seed1.Length == 0x10 && seed2.Length == 0x10 && seed3.Length == 0x10)
            {
                if(isInitialized)
                {
                    Debug.LogWarning("StringLiteral_8278 (dsfd alread initialzed ?");
                    return false;
                }
                isInitialized = true;
                bool res = dsfd_initialize(seed1, seed2, seed3);
                if(res)
                    return true;
            }
            Debug.LogError("Size wrong or init fail");
            return false;
        }

        // // RVA: 0x2BAEF20 Offset: 0x2BAEF20 VA: 0x2BAEF20
        // public static void Terminate() { }

        // // RVA: 0x2BAF080 Offset: 0x2BAF080 VA: 0x2BAF080
        public static DsfdLoader.ILoadRequest LoadFile(string filePath)
        {
            if(isInitialized)
            {
                uint res = dsfd_single(filePath);
                if(res != 0)
                {
                    loadRequestDict[res] = new LoadRequest(filePath);
                    return loadRequestDict[res];
                }
            }
            return null;
        }

        // // RVA: 0x2BAF274 Offset: 0x2BAF274 VA: 0x2BAF274
        // public static DsfdLoader.IMultiLoadRequest LoadFiles(string[] filePaths) { }

        // // RVA: 0x2BAF708 Offset: 0x2BAF708 VA: 0x2BAF708
        // public static void Update() { }
    }
}